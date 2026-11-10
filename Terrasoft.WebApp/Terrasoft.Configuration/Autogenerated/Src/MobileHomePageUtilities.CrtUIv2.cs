namespace Terrasoft.Configuration.MobileHomePageUtilities
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using ClientUnitSchema = Terrasoft.Core.ClientUnitSchema;

	#region Interface: IMobileHomePageUtilities

	public interface IMobileHomePageUtilities
	{

		#region Methods: Public

		bool GetIsMobileHomePageSchema(ISchemaManagerItem<ClientUnitSchema> item);

		void UpdateMobileHomePage(ISchemaManagerItem<ClientUnitSchema> managerItem);

		void DeleteMobileHomePage(ISchemaManagerItem<ClientUnitSchema> managerItem);

		void SyncMobileHomePages();

		#endregion

	}

	#endregion

	[DefaultBinding(typeof(IMobileHomePageUtilities))]
	public class MobileHomePageUtilities : IMobileHomePageUtilities
	{

		#region Class: MobileHomePage

		private class MobileHomePage
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

		private const string MobileHomePageSchemaGroup = "MobileHomePage";
		private const string MobileHomePageSchemaName = "MobileHomePage";

		#endregion

		#region Properties: Private

		private UserConnection UserConnection { get; }

		private EntitySchema _mobileHomePageEntitySchema;

		private EntitySchema MobileHomePageEntitySchema =>
			_mobileHomePageEntitySchema ?? (_mobileHomePageEntitySchema =
				UserConnection.EntitySchemaManager.FindRuntimeInstanceByName(MobileHomePageSchemaName));

		#endregion

		#region Constructors: Public

		public MobileHomePageUtilities(UserConnection userConnection) {
			userConnection.CheckArgumentNull(nameof(userConnection));
			UserConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private ClientUnitSchemaType GetSchemaType(ISchemaManagerItem<ClientUnitSchema> item) {
			var extraProperties = item.ExtraProperties;
			var schemaTypeExtraProperty = extraProperties.GetByName("SchemaType");
			Enum.TryParse(schemaTypeExtraProperty?.Value?.ToString(), out ClientUnitSchemaType schemaType);
			return schemaType;
		}

		private string GetGroup(ISchemaManagerItem<ClientUnitSchema> item) {
			var extraProperties = item.ExtraProperties;
			var schemaGroupExtraProperty = extraProperties.GetByName("Group");
			return schemaGroupExtraProperty.GetValue(string.Empty);
		}

		private MobileHomePage CreateMobileHomePageFromManagerItem(ISchemaManagerItem managerItem) {
			return new MobileHomePage {
				SchemaName = managerItem.Name,
				Caption = managerItem.Caption,
				SchemaUId = managerItem.UId.ToString(),
				SchemaRealUId = managerItem.RealUId.ToString(),
				ExtendParent = managerItem.ExtendParent,
				ParentSchemaUId = managerItem.ParentUId
			};
		}

		private IList<MobileHomePage> GetMobileHomePageSchemes() {
			return UserConnection.ClientUnitSchemaManager.GetItems().Where(GetIsMobileHomePageSchema)
				.Select(CreateMobileHomePageFromManagerItem).ToList();
		}

		private IList<MobileHomePage> GetRegisteredMobileHomePages() {
			var esq = new EntitySchemaQuery(MobileHomePageEntitySchema) {
				UseAdminRights = true,
			};
			var schemaNameColumn = esq.AddColumn("MobileHomePageSchemaName");
			var schemaUIdColumn = esq.AddColumn("SchemaUId");
			var schemaRealUIdColumn = esq.AddColumn("SchemaRealUId");
			return esq.GetEntityCollection(UserConnection).Select(entity => new MobileHomePage {
				SchemaName = entity.GetTypedColumnValue<string>(schemaNameColumn.Name),
				SchemaUId = entity.GetTypedColumnValue<string>(schemaUIdColumn.Name),
				SchemaRealUId = entity.GetTypedColumnValue<string>(schemaRealUIdColumn.Name),
			}).Select(mobileHomePage => {
				if (string.IsNullOrEmpty(mobileHomePage.SchemaUId)) {
					return mobileHomePage;
				}
				var schemaUId = Guid.Parse(mobileHomePage.SchemaUId);
				var managerItem = UserConnection.ClientUnitSchemaManager.FindItemByUId(schemaUId);
				if (managerItem != null) {
					mobileHomePage.ExtendParent = managerItem.ExtendParent;
					mobileHomePage.ParentSchemaUId = managerItem.ParentUId;
					mobileHomePage.Caption = managerItem.Caption;
				}
				return mobileHomePage;
			}).ToList();
		}

		private bool IsMobileHomePageRegistered(MobileHomePage mobileHomePage) {
			var entity = MobileHomePageEntitySchema.CreateEntity(UserConnection);
			return entity.FetchFromDB("SchemaUId", mobileHomePage.SchemaUId);
		}

		private void SaveMobileHomePage(MobileHomePage mobileHomePage) {
			if (IsMobileHomePageRegistered(mobileHomePage)) {
				return;
			}
			var entity = MobileHomePageEntitySchema.CreateEntity(UserConnection);
			entity.SetDefColumnValues();
			entity.SetColumnValue(MobileHomePageEntitySchema.Columns.GetByName("MobileHomePageSchemaName"),
				mobileHomePage.SchemaName);
			entity.SetColumnValue(MobileHomePageEntitySchema.Columns.GetByName("SchemaRealUId"),
				mobileHomePage.SchemaRealUId);
			entity.SetColumnValue(MobileHomePageEntitySchema.Columns.GetByName("SchemaUId"),
				mobileHomePage.SchemaUId);
			entity.SetColumnValue(MobileHomePageEntitySchema.Columns.GetByName("Title"), mobileHomePage.Caption);
			entity.Save();
		}

		private void UpdateMobileHomePage(MobileHomePage mobileHomePage) {
			var primaryColumn = MobileHomePageEntitySchema.PrimaryColumn;
			var schemaUIdColumn = MobileHomePageEntitySchema.Columns.GetByName("SchemaUId");
			var esq = new EntitySchemaQuery(MobileHomePageEntitySchema) {
				UseAdminRights = true,
			};
			var esqPrimaryColumn = esq.AddColumn(MobileHomePageEntitySchema.PrimaryColumn.Name);
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, schemaUIdColumn.Name,
				mobileHomePage.SchemaUId));
			var mobileHomePageEntities = esq.GetEntityCollection(UserConnection);
			if (mobileHomePageEntities.Count != 0) {
				mobileHomePageEntities.ForEach(esqEntity => {
					var entity = MobileHomePageEntitySchema.CreateEntity(UserConnection);
					if (entity.FetchFromDB(primaryColumn, esqEntity.GetColumnValue(esqPrimaryColumn.Name))) {
						entity.SetColumnValue(MobileHomePageEntitySchema.Columns.GetByName("Title"),
							mobileHomePage.Caption);
						entity.SetColumnValue(MobileHomePageEntitySchema.Columns.GetByName("MobileHomePageSchemaName"),
							mobileHomePage.SchemaName);
						entity.SetColumnValue(MobileHomePageEntitySchema.Columns.GetByName("SchemaRealUId"),
							mobileHomePage.SchemaRealUId);
						entity.Save();
					}
				});
			} else if (mobileHomePage.ExtendParent) {
				var primaryParentColumn = MobileHomePageEntitySchema.PrimaryColumn;
				var parentSchemaUIdColumn = MobileHomePageEntitySchema.Columns.GetByName("SchemaUId");
				var parentEsq = new EntitySchemaQuery(MobileHomePageEntitySchema) {
					UseAdminRights = true,
				};
				var parentEsqPrimaryColumn = parentEsq.AddColumn(MobileHomePageEntitySchema.PrimaryColumn.Name);
				parentEsq.Filters.Add(parentEsq.CreateFilterWithParameters(FilterComparisonType.Equal,
					parentSchemaUIdColumn.Name, mobileHomePage.ParentSchemaUId));
				var parentMobileHomePageEntities = parentEsq.GetEntityCollection(UserConnection);
				if (parentMobileHomePageEntities.Count != 0) {
					parentMobileHomePageEntities.ForEach(esqEntity => {
						var entity = MobileHomePageEntitySchema.CreateEntity(UserConnection);
						if (entity.FetchFromDB(primaryParentColumn,
								esqEntity.GetColumnValue(parentEsqPrimaryColumn.Name))) {
							entity.SetColumnValue(MobileHomePageEntitySchema.Columns.GetByName("Title"),
								mobileHomePage.Caption);
							entity.SetColumnValue(MobileHomePageEntitySchema.Columns.GetByName("MobileHomePageSchemaName"),
								mobileHomePage.SchemaName);
							entity.SetColumnValue(MobileHomePageEntitySchema.Columns.GetByName("SchemaRealUId"),
								mobileHomePage.SchemaRealUId);
							entity.Save();
						}
					});
					return;
				}
				SaveMobileHomePage(mobileHomePage);
			} else {
				SaveMobileHomePage(mobileHomePage);
			}
		}

		private void DeleteMobileHomePage(MobileHomePage mobileHomePage) {
			var primaryColumn = MobileHomePageEntitySchema.PrimaryColumn;
			var schemaUIdColumn = MobileHomePageEntitySchema.Columns.GetByName("SchemaUId");
			var schemaNameColumn = MobileHomePageEntitySchema.Columns.GetByName("MobileHomePageSchemaName");
			var esq = new EntitySchemaQuery(MobileHomePageEntitySchema) {
				UseAdminRights = true,
			};
			var esqPrimaryColumn = esq.AddColumn(MobileHomePageEntitySchema.PrimaryColumn.Name);
			if (string.IsNullOrEmpty(mobileHomePage.SchemaUId)) {
				esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, schemaNameColumn.Name,
					mobileHomePage.SchemaName));
			} else {
				esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, schemaUIdColumn.Name,
					mobileHomePage.SchemaUId));
			}
			esq.GetEntityCollection(UserConnection).ForEach(esqEntity => {
				var entity = MobileHomePageEntitySchema.CreateEntity(UserConnection);
				if (entity.FetchFromDB(primaryColumn, esqEntity.GetColumnValue(esqPrimaryColumn.Name))) {
					entity.Delete();
				}
			});
		}

		private void DeleteReplacedMobileHomePage(MobileHomePage mobileHomePage) {
			if (IsMobileHomePageRegistered(mobileHomePage)) {
				if (mobileHomePage.ExtendParent) {
					var parentSchema =
						UserConnection.ClientUnitSchemaManager.FindItemByUId(Guid.Parse(mobileHomePage.SchemaUId));
					var parentMobileHomePage = CreateMobileHomePageFromManagerItem(parentSchema);
					UpdateMobileHomePage(parentMobileHomePage);
				} else {
					DeleteMobileHomePage(mobileHomePage);
				}
			}
		}

		private void CheckMobileHomePageSchema(ISchemaManagerItem<ClientUnitSchema> managerItem) {
			managerItem.CheckArgumentNull(nameof(managerItem));
			if (!GetIsMobileHomePageSchema(managerItem)) {
				throw new Exception("ManagerItem is not MobileHomePage schema");
			}
		}

		#endregion

		#region Methods: Public

		public bool GetIsMobileHomePageSchema(ISchemaManagerItem<ClientUnitSchema> item) {
			var schemaType = GetSchemaType(item);
			if (schemaType != ClientUnitSchemaType.MobileSchema) {
				return false;
			}
			var group = GetGroup(item);
			return group == MobileHomePageSchemaGroup;
		}

		public void UpdateMobileHomePage(ISchemaManagerItem<ClientUnitSchema> managerItem) {
			CheckMobileHomePageSchema(managerItem);
			var mobileHomePage = CreateMobileHomePageFromManagerItem(managerItem);
			UpdateMobileHomePage(mobileHomePage);
		}

		public void DeleteMobileHomePage(ISchemaManagerItem<ClientUnitSchema> managerItem) {
			CheckMobileHomePageSchema(managerItem);
			var mobileHomePage = CreateMobileHomePageFromManagerItem(managerItem);
			DeleteReplacedMobileHomePage(mobileHomePage);
		}

		public void SyncMobileHomePages() {
			var mobileHomePageSchemes = GetMobileHomePageSchemes();
			var registeredMobileHomePages = GetRegisteredMobileHomePages();
			var mobileHomePageSchemesUIds = mobileHomePageSchemes.Select(mobileHomePage => mobileHomePage.SchemaUId);
			var mobileHomePagesToRemove = registeredMobileHomePages.Where(mobileHomePage =>
				string.IsNullOrEmpty(mobileHomePage.SchemaUId) || string.IsNullOrEmpty(mobileHomePage.SchemaRealUId) ||
				!mobileHomePageSchemesUIds.Contains(mobileHomePage.SchemaUId));
			var registeredMobileHomePageSchemesUIds = registeredMobileHomePages.Select(
					mobileHomePage => mobileHomePage.SchemaUId)
				.Where(schemaUId =>
					mobileHomePagesToRemove.All(mobileHomePage => mobileHomePage.SchemaUId != schemaUId));
			foreach (var mobileHomePage in mobileHomePagesToRemove) {
				DeleteMobileHomePage(mobileHomePage);
			}
			var mobileHomePagesToRegister = mobileHomePageSchemes.Where(mobileHomePage =>
				!string.IsNullOrEmpty(mobileHomePage.SchemaUId) &&
				!string.IsNullOrEmpty(mobileHomePage.SchemaRealUId) &&
				!registeredMobileHomePageSchemesUIds.Contains(mobileHomePage.SchemaUId));
			foreach (var mobileHomePage in mobileHomePagesToRegister) {
				if (mobileHomePage.ExtendParent) {
					UpdateMobileHomePage(mobileHomePage);
				} else {
					SaveMobileHomePage(mobileHomePage);
				}
			}
		}

		#endregion

	}
}

