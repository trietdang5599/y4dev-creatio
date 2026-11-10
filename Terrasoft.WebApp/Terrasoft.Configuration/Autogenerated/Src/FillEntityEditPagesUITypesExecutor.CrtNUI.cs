namespace Terrasoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Terrasoft.Core;
	using Terrasoft.Common;
	using Terrasoft.Core.Addons;
	using Terrasoft.Core.Addons.Interfaces;
	using Terrasoft.Core.Entities;

	#region Class: FillEntityEditPagesUITypesExecutor

	public class FillEntityEditPagesUITypesExecutor
	{

		#region Constants: Private

		private readonly Guid v8InterfaceId = new Guid("f4d757e1-2aeb-496f-b751-3d5b39708ea3");
		private readonly UserConnection _userConnection;

		#endregion

		#region Constructors: Public

		public FillEntityEditPagesUITypesExecutor(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private bool IsNeedFillEntityEditPagesUITypes() {
			return HasLic() && IsEntityEditPagesUITypesEmpty();
		}

		private bool HasLic() {
			return HasEntitySchemaRecords("SysLic");
		}

		private bool IsEntityEditPagesUITypesEmpty() {
			return !HasEntitySchemaRecords("EntityEditPagesUITypes");
		}

		private bool HasEntitySchemaRecords(string schemaName) {
			var esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, schemaName) {
				UseAdminRights = false
			};
			esq.RowCount = 1;
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			var entities = esq.GetEntityCollection(_userConnection);
			return entities.Any();
		}

		private void FillEntityEditPagesUITypes() {
			var schemasUIds = GetSchemaWithRelatedPageUIds(_userConnection);
			foreach (var schemaId in schemasUIds) {
				var schema = _userConnection.EntitySchemaManager.FindItemByUId(schemaId);
				if (schema == null) {
					continue;
				}
				CreateEntityEditPagesUITypes(schema.Name, _userConnection);
			}
		}

		private void CreateEntityEditPagesUITypes(string schemaName, UserConnection userConnection) {
			EntitySchemaManager entitySchemaManager = userConnection.EntitySchemaManager;
			Entity entity = entitySchemaManager.GetEntityByName("EntityEditPagesUITypes", userConnection);
			entity.SetDefColumnValues();
			entity.SetColumnValue("EXTId", v8InterfaceId);
			entity.SetColumnValue("EntitySchemaName", schemaName);
			entity.Save();
		}

		private IEnumerable<Guid> GetSchemaWithRelatedPageUIds(UserConnection userConnection) {
			IAddonSchemaManager addonSchemaManager = (IAddonSchemaManager)userConnection.FindSchemaManager("AddonSchemaManager");
			AddonSchema[] addons = addonSchemaManager.FindAddons(userConnection.EntitySchemaManager.Name);
			IEnumerable<AddonSchema> addonsRelatedPages = addons.Where(x => x.AddonName.Equals("RelatedPage"));
			if (!addonsRelatedPages.Any()) {
				return Array.Empty<Guid>();
			}
			IEnumerable<Guid> addonsPackageUIds = addonsRelatedPages.Select(x => x.PackageUId).Distinct();
			IEnumerable<Guid> addonsCustomerPackageUIds = GetCustomerPackageUIds(addonsPackageUIds);
			return addonsRelatedPages
				.Where(x => addonsCustomerPackageUIds.Contains(x.PackageUId))
				.Select(x => x.TargetSchemaUId)
				.Where(x => x.IsNotEmpty())
				.Distinct();
		}

		private IEnumerable<Guid> GetCustomerPackageUIds(IEnumerable<Guid> packageUIds) {
			if (!packageUIds.Any()) {
				return Array.Empty<Guid>();
			}
			var esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "SysPackage");
			var uIdColumnName = esq.AddColumn("UId").Name;
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, 
				"UId", 
				packageUIds.Cast<object>().ToArray()));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.NotEqual, "Maintainer", "Terrasoft"));
			var packages = esq.GetEntityCollection(_userConnection);
			return packages.Select(package => package.GetTypedColumnValue<Guid>(uIdColumnName));
		}

		#endregion

		#region Methods: Public

		public void Execute() {
			if (!IsNeedFillEntityEditPagesUITypes()) {
				return;
			}
			FillEntityEditPagesUITypes();
		}

		#endregion

	}

	#endregion

}

