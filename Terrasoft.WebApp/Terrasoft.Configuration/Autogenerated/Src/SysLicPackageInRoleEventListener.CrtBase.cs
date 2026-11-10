namespace Terrasoft.Configuration
{
	using System;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Entities.Events;

	#region Class: SysLicPackageInRoleEventListener

	/// <summary>
	/// Handler for SysLicPackageInRole entity events.
	/// </summary>
	/// <seealso cref="Terrasoft.Core.Entities.Events.BaseEntityEventListener" />
	[EntityEventListener(SchemaName = "SysLicPackageInRole")]
	public class SysLicPackageInRoleEventListener : BaseEntityEventListener
	{

		#region Fields: Private

		private UserConnection _userConnection;

		#endregion

		#region Methods: Private

		private void CheckLicenseType(Guid sysLicPackageId) {
			Core.Configuration.SysLicType licType = GetLicTypeProtected(sysLicPackageId);
			if (licType != Core.Configuration.SysLicType.Personal) {
				string message = new LocalizableString(_userConnection.ResourceStorage,
					"SysLicPackageInRoleEventListener", "LocalizableStrings.OnlyPersonalLicensesError.Value");
				throw new Exception(message);
			}
		}

		private void CheckSysAdminUnitType(Guid sysAdminUnitId) {
			var esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "SysAdminUnit");
			esq.AddColumn("Id");
			esq.AddColumn("SysAdminUnitTypeValue");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Id", sysAdminUnitId));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.NotEqual, "SysAdminUnitTypeValue",
				Core.DB.SysAdminUnitType.User));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.NotEqual, "SysAdminUnitTypeValue",
				Core.DB.SysAdminUnitType.SelfServicePortalUser));
			EntityCollection entities = esq.GetEntityCollection(_userConnection);
			if (entities.Count == 0) {
				string message = new LocalizableString(_userConnection.ResourceStorage,
					"SysLicPackageInRoleEventListener", "LocalizableStrings.OnlyRoleError.Value");
				throw new Exception(message);
			}
		}

		private void CheckForDuplicates(Guid sysAdminUnitId, Guid sysLicPackageId, Guid id) {
			var esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "SysLicPackageInRole");
			esq.AddColumn("Id");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "SysRole", sysAdminUnitId));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "SysLicPackage", sysLicPackageId));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.NotEqual, "Id", id));
			EntityCollection entities = esq.GetEntityCollection(_userConnection);
			if (entities.Count > 0) {
				string message = new LocalizableString(_userConnection.ResourceStorage,
					"SysLicPackageInRoleEventListener", "LocalizableStrings.DuplicatesError.Value");
				throw new Exception(message);
			}
		}

		#endregion

		#region Methods: Protected

		protected virtual Core.Configuration.SysLicType GetLicTypeProtected(Guid sysLicPackageId) {
			return _userConnection.LicHelper.GetSysPackageLicType(sysLicPackageId); 
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc />
		public override void OnSaving(object sender, EntityBeforeEventArgs e) {
			base.OnSaving(sender, e);
			Entity entity = (Entity)sender;
			_userConnection = entity.UserConnection;
			var sysAdminUnitId = entity.GetTypedColumnValue<Guid>("SysRoleId");
			var sysLicPackageId = entity.GetTypedColumnValue<Guid>("SysLicPackageId");
			if (sysAdminUnitId.IsEmpty() || sysLicPackageId.IsEmpty()) {
				return;
			}
			CheckSysAdminUnitType(sysAdminUnitId);
			CheckLicenseType(sysLicPackageId);
			var currentId = entity.GetTypedColumnValue<Guid>("Id");
			CheckForDuplicates(sysAdminUnitId, sysLicPackageId, currentId);
		}

		#endregion

	}

	#endregion

}

