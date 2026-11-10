namespace Terrasoft.Configuration.DesktopUtilities
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using ClientUnitSchema = Terrasoft.Core.ClientUnitSchema;

	#region Interface: IDesktopUtilities

	public interface IDesktopUtilities
	{

		#region Methods: Public

		bool GetIsDesktopSchema(ISchemaManagerItem<ClientUnitSchema> item);

		void UpdateDesktop(ISchemaManagerItem<ClientUnitSchema> managerItem);

		void DeleteDesktop(ISchemaManagerItem<ClientUnitSchema> managerItem);

		void SyncDesktops();

		#endregion

	}

	#endregion

	[DefaultBinding(typeof(IDesktopUtilities))]
	public class DesktopUtilities : IDesktopUtilities
	{

		#region Class: Desktop

		private class Desktop
		{
			public string SchemaName;
			public LocalizableString Caption;
			public string SchemaUId;
			public string SchemaRealUId;
			public bool ExtendParent;
			public Guid ParentSchemaUId;
		}

		#endregion

		#region Fields: Private

		private const string DesktopAngularSchemaGroup = "Desktop";
		private const string DesktopSchemaName = "Desktop";

		#endregion

		#region Properties: Private

		private UserConnection UserConnection { get; }

		private EntitySchema _desktopEntitySchema;

		private EntitySchema DesktopEntitySchema =>
			_desktopEntitySchema ?? (_desktopEntitySchema =
				UserConnection.EntitySchemaManager.FindRuntimeInstanceByName(DesktopSchemaName));

		#endregion

		#region Constructors: Public

		public DesktopUtilities(UserConnection userConnection) {
			userConnection.CheckArgumentNull(nameof(userConnection));
			UserConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private ClientUnitSchemaType GetSchemaType(ISchemaManagerItem<ClientUnitSchema> item) {
			var extraProperties = item.ExtraProperties;
			ClientUnitSchemaType schemaType;
			var schemaTypeExtraProperty = extraProperties.GetByName("SchemaType");
			Enum.TryParse(schemaTypeExtraProperty?.Value?.ToString(), out ClientUnitSchemaType extraPropertySchemaType);
			schemaType = extraPropertySchemaType;
			return schemaType;
		}

		private string GetGroup(ISchemaManagerItem<ClientUnitSchema> item) {
			var extraProperties = item.ExtraProperties;
			var schemaGroupExtraProperty = extraProperties.GetByName("Group");
			var schemaGroup = schemaGroupExtraProperty.GetValue(string.Empty);
			return schemaGroup;
		}

		private Desktop CreateDesktopFromManagerItem(ISchemaManagerItem managerItem) {
			return new Desktop {
				SchemaName = managerItem.Name,
				Caption = managerItem.Caption,
				SchemaUId = managerItem.UId.ToString(),
				SchemaRealUId = managerItem.RealUId.ToString(),
				ExtendParent = managerItem.ExtendParent,
				ParentSchemaUId = managerItem.ParentUId
			};
		}

		private IList<Desktop> GetDesktopsSchemes() {
			return UserConnection.ClientUnitSchemaManager.GetItems().Where(GetIsDesktopSchema)
				.Select(CreateDesktopFromManagerItem).ToList();
		}

		private IList<Desktop> GetRegisteredDesktops() {
			var esq = new EntitySchemaQuery(DesktopEntitySchema) {
				UseAdminRights = true,
			};
			var schemaNameColumn = esq.AddColumn("DesktopSchemaName");
			var schemaUIdColumn = esq.AddColumn("SchemaUId");
			var schemaRealUIdColumn = esq.AddColumn("SchemaRealUId");
			return esq.GetEntityCollection(UserConnection).Select(desktopEntity => new Desktop {
				SchemaName = desktopEntity.GetTypedColumnValue<string>(schemaNameColumn.Name),
				SchemaUId = desktopEntity.GetTypedColumnValue<string>(schemaUIdColumn.Name),
				SchemaRealUId = desktopEntity.GetTypedColumnValue<string>(schemaRealUIdColumn.Name),
			}).Select(desktop => {
				if (string.IsNullOrEmpty(desktop.SchemaUId)) {
					return desktop;
				}
				var schemaUId = Guid.Parse(desktop.SchemaUId);
				var managerItem = UserConnection.ClientUnitSchemaManager.FindItemByUId(schemaUId);
				if (managerItem != null) {
					desktop.ExtendParent = managerItem.ExtendParent;
					desktop.ParentSchemaUId = managerItem.ParentUId;
					desktop.Caption = managerItem.Caption;
				}
				return desktop;
			}).ToList();
		}

		private bool IsDesktopRegistered(Desktop desktop) {
			var entity = DesktopEntitySchema.CreateEntity(UserConnection);
			return entity.FetchFromDB("SchemaUId", desktop.SchemaUId);
		}

		private void SaveDesktop(Desktop desktop) {
			if (IsDesktopRegistered(desktop)) {
				return;
			}
			var entity = DesktopEntitySchema.CreateEntity(UserConnection);
			entity.SetDefColumnValues();
			entity.SetColumnValue(DesktopEntitySchema.Columns.GetByName("DesktopSchemaName"), desktop.SchemaName);
			entity.SetColumnValue(DesktopEntitySchema.Columns.GetByName("SchemaRealUId"), desktop.SchemaRealUId);
			entity.SetColumnValue(DesktopEntitySchema.Columns.GetByName("SchemaUId"), desktop.SchemaUId);
			entity.SetColumnValue(DesktopEntitySchema.Columns.GetByName("Title"), desktop.Caption);
			entity.Save();
		}

		private void UpdateDesktop(Desktop desktop) {
			var primaryColumn = DesktopEntitySchema.PrimaryColumn;
			var schemaUIdColumn = DesktopEntitySchema.Columns.GetByName("SchemaUId");
			var esq = new EntitySchemaQuery(DesktopEntitySchema) {
				UseAdminRights = true,
			};
			var esqPrimaryColumn = esq.AddColumn(DesktopEntitySchema.PrimaryColumn.Name);
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, schemaUIdColumn.Name,
				desktop.SchemaUId));
			var desktopsEntities = esq.GetEntityCollection(UserConnection);
			if (desktopsEntities.Count != 0) {
				desktopsEntities.ForEach(esqEntity => {
					var entity = DesktopEntitySchema.CreateEntity(UserConnection);
					if (entity.FetchFromDB(primaryColumn, esqEntity.GetColumnValue(esqPrimaryColumn.Name))) {
						entity.SetColumnValue(DesktopEntitySchema.Columns.GetByName("Title"), desktop.Caption);
						entity.SetColumnValue(DesktopEntitySchema.Columns.GetByName("DesktopSchemaName"),
							desktop.SchemaName);
						entity.SetColumnValue(DesktopEntitySchema.Columns.GetByName("SchemaRealUId"),
							desktop.SchemaRealUId);
						entity.Save();
					}
				});
			} else {
				if (desktop.ExtendParent) {
					var primaryParentColumn = DesktopEntitySchema.PrimaryColumn;
					var parentSchemaUIdColumn = DesktopEntitySchema.Columns.GetByName("SchemaUId");
					var parentEsq = new EntitySchemaQuery(DesktopEntitySchema) {
						UseAdminRights = true,
					};
					var parentEsqPrimaryColumn = parentEsq.AddColumn(DesktopEntitySchema.PrimaryColumn.Name);
					parentEsq.Filters.Add(parentEsq.CreateFilterWithParameters(FilterComparisonType.Equal,
						parentSchemaUIdColumn.Name, desktop.ParentSchemaUId));
					var parentDesktopsEntities = parentEsq.GetEntityCollection(UserConnection);
					if (parentDesktopsEntities.Count != 0) {
						parentDesktopsEntities.ForEach(esqEntity => {
							var entity = DesktopEntitySchema.CreateEntity(UserConnection);
							if (entity.FetchFromDB(primaryParentColumn,
									esqEntity.GetColumnValue(parentEsqPrimaryColumn.Name))) {
								entity.SetColumnValue(DesktopEntitySchema.Columns.GetByName("Title"), desktop.Caption);
								entity.SetColumnValue(DesktopEntitySchema.Columns.GetByName("DesktopSchemaName"),
									desktop.SchemaName);
								entity.SetColumnValue(DesktopEntitySchema.Columns.GetByName("SchemaRealUId"),
									desktop.SchemaRealUId);
								entity.Save();
							}
						});
						return;
					}
				}
				SaveDesktop(desktop);
			}
		}

		private void DeleteDesktop(Desktop desktop) {
			var primaryColumn = DesktopEntitySchema.PrimaryColumn;
			var schemaUIdColumn = DesktopEntitySchema.Columns.GetByName("SchemaUId");
			var schemaNameColumn = DesktopEntitySchema.Columns.GetByName("DesktopSchemaName");
			var esq = new EntitySchemaQuery(DesktopEntitySchema) {
				UseAdminRights = true,
			};
			var esqPrimaryColumn = esq.AddColumn(DesktopEntitySchema.PrimaryColumn.Name);
			if (string.IsNullOrEmpty(desktop.SchemaUId)) {
				esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, schemaNameColumn.Name,
					desktop.SchemaName));
			} else {
				esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, schemaUIdColumn.Name,
					desktop.SchemaUId));
			}
			esq.GetEntityCollection(UserConnection).ForEach(esqEntity => {
				var entity = DesktopEntitySchema.CreateEntity(UserConnection);
				if (entity.FetchFromDB(primaryColumn, esqEntity.GetColumnValue(esqPrimaryColumn.Name))) {
					entity.Delete();
				}
			});
		}

		private void DeleteReplacedDesktop(Desktop desktop) {
			if (IsDesktopRegistered(desktop)) {
				if (desktop.ExtendParent) {
					var parentSchema =
						UserConnection.ClientUnitSchemaManager.FindItemByUId(Guid.Parse(desktop.SchemaUId));
					var parentDesktop = CreateDesktopFromManagerItem(parentSchema);
					UpdateDesktop(parentDesktop);
				} else {
					DeleteDesktop(desktop);
				}
			}
		}

		private void CheckDesktopSchema(ISchemaManagerItem<ClientUnitSchema> managerItem) {
			managerItem.CheckArgumentNull(nameof(managerItem));
			if (!GetIsDesktopSchema(managerItem)) {
				throw new Exception("ManagerItem is not Desktop schema");
			}
		}

		#endregion

		#region Methods: Public

		public bool GetIsDesktopSchema(ISchemaManagerItem<ClientUnitSchema> item) {
			var schemaType = GetSchemaType(item);
			if (schemaType != ClientUnitSchemaType.AngularSchema) {
				return false;
			}
			var group = GetGroup(item);
			return group == DesktopAngularSchemaGroup;
		}

		public void UpdateDesktop(ISchemaManagerItem<ClientUnitSchema> managerItem) {
			CheckDesktopSchema(managerItem);
			var desktop = CreateDesktopFromManagerItem(managerItem);
			UpdateDesktop(desktop);
		}

		public void DeleteDesktop(ISchemaManagerItem<ClientUnitSchema> managerItem) {
			CheckDesktopSchema(managerItem);
			var desktop = CreateDesktopFromManagerItem(managerItem);
			DeleteReplacedDesktop(desktop);
		}

		public void SyncDesktops() {
			var desktopsSchemes = GetDesktopsSchemes();
			var registeredDesktops = GetRegisteredDesktops();
			var desktopsSchemesUIds = desktopsSchemes.Select(desktop => desktop.SchemaUId);
			var desktopsToRemove = registeredDesktops.Where(desktop =>
				string.IsNullOrEmpty(desktop.SchemaUId) || string.IsNullOrEmpty(desktop.SchemaRealUId) ||
				!desktopsSchemesUIds.Contains(desktop.SchemaUId));
			var registeredDesktopsSchemesUIds = registeredDesktops.Select(desktop => desktop.SchemaUId)
				.Where(desktopSchemaUId => desktopsToRemove.All(desktop => desktop.SchemaUId != desktopSchemaUId));
			foreach (Desktop desktop in desktopsToRemove) {
				DeleteDesktop(desktop);
			}
			var desktopsToRegister = desktopsSchemes.Where(desktop =>
				!string.IsNullOrEmpty(desktop.SchemaUId) && !string.IsNullOrEmpty(desktop.SchemaRealUId) &&
				!registeredDesktopsSchemesUIds.Contains(desktop.SchemaUId));
			foreach (Desktop desktop in desktopsToRegister) {
				if (desktop.ExtendParent) {
					UpdateDesktop(desktop);
				} else {
					SaveDesktop(desktop);
				}
			}
		}

		#endregion

	}

}

