namespace Terrasoft.Configuration.SysInstalledAppPackage
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Terrasoft.Core.Applications.Abstractions.Synchronization;
	using Terrasoft.Core.Applications.Abstractions.Validators;
	using Terrasoft.Common;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Entities.Events;
	using Core.Factories;
	using SysInstalledApp = Terrasoft.Configuration.SysInstalledApp;

	#region Class: SysInstalledAppListener

	/// <summary>
	/// Listener for 'SysInstalledApp' entity events.
	/// </summary>
	/// <seealso cref="Terrasoft.Core.Entities.Events.BaseEntityEventListener" />
	[EntityEventListener(SchemaName = "SysInstalledApp")]
	public class SysInstalledAppListener : BaseEntityEventListener
	{

		#region Methods: Private

		private static void ValidateAppName(SysInstalledApp sysInstalledApp) {
			sysInstalledApp.Name = sysInstalledApp.Name.Trim();
			var appValidator = ClassFactory.Get<IAppValidator>();
			if (!appValidator.ValidateName(sysInstalledApp.Name, out string validationErrorMessage)) {
				throw new ArgumentException(validationErrorMessage);
			}
			EntitySchema entitySchema = sysInstalledApp.Schema;
			Entity sysInstalledAppFromDB = entitySchema.CreateEntity(sysInstalledApp.UserConnection);
			sysInstalledAppFromDB.UseAdminRights = false;
			if (sysInstalledAppFromDB.FetchFromDB("Name", sysInstalledApp.Name, new[] { "Id" })
					&& sysInstalledAppFromDB.GetTypedColumnValue<Guid>("Id") != sysInstalledApp.Id) {
				throw new ArgumentException(string.Format(
					new LocalizableString(sysInstalledApp.UserConnection.ResourceStorage, "SysInstalledAppListener",
						"LocalizableStrings.AppAlreadyExists.Value"), sysInstalledApp.Name));
			}
		}

		private static void ClearSysInstalledAppChecksum(SysInstalledApp sysInstalledApp) {
			IEnumerable<EntityColumnValue> changedColumns = sysInstalledApp.GetChangedColumnValues();
			var isChecksumChanged = changedColumns.Any(x => x.Name == "Checksum");
			if (!isChecksumChanged) {
				sysInstalledApp.SetColumnValue("Checksum", string.Empty);
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Handles entity Saving event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:Terrasoft.Core.Entities.EntityBeforeEventArgs" /> instance containing the
		/// event data.</param>
		/// <exception cref="SystemOperationRestrictedException">Current user session is created using external access.
		/// </exception>
		public override void OnSaving(object sender, EntityBeforeEventArgs e) {
			var sysInstalledApp = (SysInstalledApp)sender;
			ValidateAppName(sysInstalledApp);
			ClearSysInstalledAppChecksum(sysInstalledApp);
			base.OnSaving(sender, e);
		}

		/// <summary>
		/// Handles entity Saved event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:Terrasoft.Core.Entities.EntityAfterEventArgs" /> instance containing the
		/// event data.</param>
		/// <exception cref="SystemOperationRestrictedException">Current user session is created using external access.
		/// </exception>
		public override void OnSaved(object sender, EntityAfterEventArgs e) {
			base.OnSaved(sender, e);
			var appInfoSynchronizer = ClassFactory.Get<IAppInfoSynchronizer>();
			var sysInstalledApp = (SysInstalledApp)sender;
			bool isSyncFromFile = e.ModifiedColumnValues.TryGetValue("Checksum", out string checksum) &&
				checksum.IsNotNullOrEmpty();
			if (!isSyncFromFile) {
				appInfoSynchronizer.SaveToFileContent(sysInstalledApp.Id);
			}
		}

		#endregion

	}

	#endregion

}

