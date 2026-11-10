namespace Terrasoft.Configuration
{
	using System;
	using System.Linq;
	using Creatio.FeatureToggling;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Applications.Abstractions.Synchronization;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Entities.Events;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Packages;

	#region Class: SysPackageInInstalledAppListener

	/// <summary>
	/// Listener for 'SysPackageInInstalledApp' entity events.
	/// </summary>
	/// <seealso cref="Terrasoft.Core.Entities.Events.BaseEntityEventListener" />
	[EntityEventListener(SchemaName = "SysPackageInInstalledApp")]
	public class SysPackageInInstalledAppListener : BaseEntityEventListener
	{

		#region Fields: Private

		private static readonly string[] _columnsToHandleAppPrimaryPackageChangeOnUpdate = {
			"Primary", "SysPackageId", "SysInstalledAppId"
		};

		#endregion

		#region Properties: Private

		private static bool NeedPreventChangingForeignPrimaryPackage =>
			Features.GetIsEnabled("AppsFeatures.PreventChangingForeignPrimaryPackage");

		private static bool UseAppDescriptorExtensions =>
			Features.GetIsEnabled("AppsFeatures.UseAppDescriptorExtensions");

		#endregion

		#region Methods: Private

		private static IAppInfoSynchronizer GetAppInfoSynchronizer() => ClassFactory.Get<IAppInfoSynchronizer>();

		private static void SynchronizeAppInfo(SysPackageInInstalledApp packageInApp,
				bool appPrimaryPackageChanged) {
			IAppInfoSynchronizer appInfoSynchronizer = GetAppInfoSynchronizer();
			appInfoSynchronizer.SaveToFileContent(packageInApp.SysInstalledAppId,
				new AppInfoSyncToFileOptions {
					DeleteRedundantAppInfoFiles = appPrimaryPackageChanged,
					AutoAdjustPrimaryPackage = !appPrimaryPackageChanged
				});
		}

		private static void ClearSysInstalledAppChecksum(SysPackageInInstalledApp packageInApp) =>
			new Update(packageInApp.UserConnection, "SysInstalledApp")
					.Set("Checksum", Column.Parameter(string.Empty))
				.Where("Id").IsEqual(Column.Parameter(packageInApp.SysInstalledAppId))
				.Execute();

		private static bool CheckNeedHandleAppPrimaryPackageChangeOnUpdate(EntityAfterEventArgs e) =>
			_columnsToHandleAppPrimaryPackageChangeOnUpdate
				.Any(columnName => e.ModifiedColumnValues.FindByName(columnName) != null);

		private static bool IsColumnChanged(SysPackageInInstalledApp packageInApp, string columnName) =>
			packageInApp.GetChangedColumnValues().Any(x => x.Name == columnName);

		private static void CheckCanPrimaryPackageBeModified(Guid sysInstalledAppId, Guid? packageUId = null) {
			IAppInfoSynchronizer appInfoSynchronizer = GetAppInfoSynchronizer();
			if (!appInfoSynchronizer.GetCanPrimaryPackageBeModified(sysInstalledAppId, packageUId,
					out string errorMessage)) {
				throw new InvalidOperationException(errorMessage);
			}
		}

		private static void CheckCanPrimaryPackageBeModified(Guid packageUId) {
			IAppInfoSynchronizer appInfoSynchronizer = GetAppInfoSynchronizer();
			if (!appInfoSynchronizer.GetCanPrimaryPackageBeModified(packageUId, out string errorMessage)) {
				throw new InvalidOperationException(errorMessage);
			}
		}

		private static Guid GetPackageUId(SysPackageInInstalledApp packageInApp) =>
			GetPackageUId(packageInApp.SysPackageId, packageInApp.UserConnection);

		private static Guid GetPackageUId(Guid packageId, UserConnection userConnection) =>
			WorkspaceUtilities.GetPackageUIdById(packageId, userConnection);

		private static void ValidateAppPrimaryPackageOnUpdating(SysPackageInInstalledApp packageInApp) {
			if (!NeedPreventChangingForeignPrimaryPackage) {
				return;
			}
			bool isPrimaryColumnChanged = IsColumnChanged(packageInApp, "Primary");
			bool isPackageColumnChanged = IsColumnChanged(packageInApp, "SysPackageId");
			bool isAppColumnChanged = IsColumnChanged(packageInApp, "SysInstalledAppId");
			bool isAnyAppPrimaryPackageBeingModified = (isPrimaryColumnChanged
					|| (packageInApp.Primary && (isPackageColumnChanged || isAppColumnChanged)));
			if (!isAnyAppPrimaryPackageBeingModified) {
				return;
			}
			if (UseAppDescriptorExtensions) {
				if (isPackageColumnChanged) {
					Guid oldUId = GetPackageUId(packageInApp.GetTypedOldColumnValue<Guid>("SysPackageId"),
						packageInApp.UserConnection);
					Guid newUId = GetPackageUId(packageInApp.SysPackageId,
						packageInApp.UserConnection);
					CheckCanPrimaryPackageBeModified(oldUId);
					CheckCanPrimaryPackageBeModified(newUId);
				} else {
					CheckCanPrimaryPackageBeModified(GetPackageUId(packageInApp));
				}
				return;
			}
			Guid? packageToSetPrimaryUId = null;
			if (packageInApp.Primary) {
				packageToSetPrimaryUId = GetPackageUId(packageInApp);
			}
			CheckCanPrimaryPackageBeModified(packageInApp.SysInstalledAppId, packageToSetPrimaryUId);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Handles entity Inserting event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:Terrasoft.Core.Entities.EntityBeforeEventArgs" /> instance containing
		/// the event data.</param>
		public override void OnInserting(object sender, EntityBeforeEventArgs e) {
			var packageInApp = (SysPackageInInstalledApp)sender;
			if (NeedPreventChangingForeignPrimaryPackage && packageInApp.Primary) {
				if (UseAppDescriptorExtensions) {
					CheckCanPrimaryPackageBeModified(GetPackageUId(packageInApp));
				} else {
					CheckCanPrimaryPackageBeModified(packageInApp.SysInstalledAppId, GetPackageUId(packageInApp));
				}
			}
			base.OnInserting(sender, e);
		}

		/// <summary>
		/// Handles entity Updating event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:Terrasoft.Core.Entities.EntityBeforeEventArgs" /> instance containing
		/// the event data.</param>
		public override void OnUpdating(object sender, EntityBeforeEventArgs e) {
			ValidateAppPrimaryPackageOnUpdating((SysPackageInInstalledApp)sender);
			base.OnUpdating(sender, e);
		}

		/// <summary>
		/// Handles entity Deleting event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:Terrasoft.Core.Entities.EntityBeforeEventArgs" /> instance containing
		/// the event data.</param>
		public override void OnDeleting(object sender, EntityBeforeEventArgs e) {
			var packageInApp = (SysPackageInInstalledApp)sender;
			if (NeedPreventChangingForeignPrimaryPackage && packageInApp.Primary) {
				if (UseAppDescriptorExtensions) {
					CheckCanPrimaryPackageBeModified(GetPackageUId(packageInApp));
				} else {
					CheckCanPrimaryPackageBeModified(packageInApp.SysInstalledAppId, null);
				}
			}
			base.OnDeleting(sender, e);
		}

		/// <summary>
		/// Handles entity Inserted event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:Terrasoft.Core.Entities.EntityAfterEventArgs" /> instance containing
		/// the event data.</param>
		public override void OnInserted(object sender, EntityAfterEventArgs e) {
			base.OnInserted(sender, e);
			var packageInApp = (SysPackageInInstalledApp)sender;
			SynchronizeAppInfo(packageInApp, appPrimaryPackageChanged: packageInApp.Primary);
		}

		/// <summary>
		/// Handles entity Updated event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:Terrasoft.Core.Entities.EntityAfterEventArgs" /> instance containing
		/// the event data.</param>
		public override void OnUpdated(object sender, EntityAfterEventArgs e) {
			base.OnUpdated(sender, e);
			var packageInApp = (SysPackageInInstalledApp)sender;
			ClearSysInstalledAppChecksum(packageInApp);
			bool appPrimaryPackageChanged = CheckNeedHandleAppPrimaryPackageChangeOnUpdate(e);
			SynchronizeAppInfo(packageInApp, appPrimaryPackageChanged);
		}

		/// <summary>
		/// Handles entity Deleted event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:Terrasoft.Core.Entities.EntityAfterEventArgs" /> instance containing the
		/// event data.</param>
		/// <exception cref="SystemOperationRestrictedException">Current user session is created using external access.
		/// </exception>
		public override void OnDeleted(object sender, EntityAfterEventArgs e) {
			base.OnDeleted(sender, e);
			var packageInApp = (SysPackageInInstalledApp)sender;
			ClearSysInstalledAppChecksum(packageInApp);
			SynchronizeAppInfo(packageInApp, appPrimaryPackageChanged: false);
		}

		#endregion

	}

	#endregion

}

