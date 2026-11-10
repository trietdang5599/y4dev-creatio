  namespace Terrasoft.Configuration
{
	using System.Linq;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using CoreSysSettings = Core.Configuration.SysSettings;

	#region Class: AcademyUrlDataQueryExecutor

	[DefaultBinding(typeof(IEntityQueryExecutor), Name = "AcademyUrlDataQueryExecutor")]
    public class AcademyUrlDataQueryExecutor : IEntityQueryExecutor
    {
		#region Fields: Private

		private readonly UserConnection _userConnection;

		private readonly string _entitySchemaName = "AcademyUrlData";
		
		private readonly string[] columnsForCheck = new string []{ "LMSUrl", "ProductEdition", "ConfigurationVersion" };
			
		#endregion

		#region Properties: Protected

		protected UserConnection UserConnection => _userConnection;

		protected EntitySchemaManager EntitySchemaManager => UserConnection.EntitySchemaManager;
		
		protected EntitySchema EntitySchema => EntitySchemaManager.GetInstanceByName(_entitySchemaName);

		#endregion

		#region Constructors: Public

		public AcademyUrlDataQueryExecutor(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private void SetNonEmptyValues(Entity entity, string columnName, string newValue) {
			if (!string.IsNullOrEmpty(newValue)) {
				entity.SetColumnValue(columnName, newValue);
            }
        }

        private string GetAcademyUrlFromDb() {
			var esq = new EntitySchemaQuery(EntitySchemaManager, "AcademyURL")
			{
				RowCount = 1
			};
			esq.AddColumn("Description");
			var entityCollection = esq.GetEntityCollection(UserConnection);
			return entityCollection.Any()
				? entityCollection.First().GetTypedColumnValue<string>("Description")
				: string.Empty;
        }

		private Entity GetAcademyUrlDataEntityFromSysSettings() {
			Entity academyUrlDataEntity = EntitySchema.CreateEntity(UserConnection);
			academyUrlDataEntity.SetColumnValue("UseLmsDocumentation", CoreSysSettings.GetValue(UserConnection, "UseLMSDocumentation", false));
			academyUrlDataEntity.SetColumnValue("LMSUrl", GetAcademyUrlFromDb());
			academyUrlDataEntity.SetColumnValue("EnableContextHelp", CoreSysSettings.GetValue(UserConnection, "EnableContextHelp", false));
			academyUrlDataEntity.SetColumnValue("ProductEdition", CoreSysSettings.GetValue(UserConnection, "ProductEdition", string.Empty));
			academyUrlDataEntity.SetColumnValue("ConfigurationVersion", CoreSysSettings.GetValue(UserConnection, "ConfigurationVersion", string.Empty));
			return academyUrlDataEntity;
		}

		private Entity GetContextHelpEntity(EntitySchemaQueryFilterCollection filters) {
			var esq = new EntitySchemaQuery(EntitySchemaManager, "ContextHelp");
			esq.AddColumn("ContextHelpId");
			esq.AddColumn("ProductEdition");
			esq.AddColumn("ConfigurationVersion");
			esq.AddColumn("Code");
			esq.Filters.Add(filters);
			var entityCollection = esq.GetEntityCollection(UserConnection);
			if (entityCollection.Count() > 1) {
				throw new DublicateDataException("ContextHelp");
			}
			return entityCollection.FirstOrDefault();
		}
		private Entity CompleteAcademyUrlDataEntity(Entity academyUrlDataEntity, Entity contextHelpEntity) {
			if (contextHelpEntity == null) {
				return academyUrlDataEntity;
			}
			
			var contextHelpId = contextHelpEntity.GetTypedColumnValue<string>("ContextHelpId");
			academyUrlDataEntity.SetColumnValue("ContextHelpId", contextHelpId);
			academyUrlDataEntity.SetColumnValue("EnableContextHelp", !contextHelpId.IsNullOrEmpty());
			academyUrlDataEntity.SetColumnValue("Code", contextHelpEntity.GetTypedColumnValue<string>("Code"));
			SetNonEmptyValues(academyUrlDataEntity, "ProductEdition", 
				contextHelpEntity.GetTypedColumnValue<string>("ProductEdition"));
			SetNonEmptyValues(academyUrlDataEntity, "ConfigurationVersion",
				contextHelpEntity.GetTypedColumnValue<string>("ConfigurationVersion"));
			return academyUrlDataEntity;
		}

		private Entity CheckAcademyUrlDataEntityIsEmpty(Entity academyUrlDataEntity) {
			foreach (var column in columnsForCheck) {
				if (!string.IsNullOrEmpty(academyUrlDataEntity.GetTypedColumnValue<string>(column))) {
					return academyUrlDataEntity;
				}
			}
			return null;
		}
		private Entity GetAcademyUrlDataEntity(EntitySchemaQueryFilterCollection filters) {
			var academyUrlDataEntityFromSysSettings = GetAcademyUrlDataEntityFromSysSettings();
			var contextHelpEntity = GetContextHelpEntity(filters);
			var academyUrlDataEntity = CompleteAcademyUrlDataEntity(academyUrlDataEntityFromSysSettings, contextHelpEntity);
			return CheckAcademyUrlDataEntityIsEmpty(academyUrlDataEntity);
		}

		#endregion

		#region Methods: Public
		
		public EntityCollection GetEntityCollection(EntitySchemaQuery esq) {
			var academyUrlDataEntity = GetAcademyUrlDataEntity(esq.Filters);
			var collection = new EntityCollection(UserConnection, EntitySchema);
			if (academyUrlDataEntity != null) {
				collection.Add(academyUrlDataEntity);
			}
			return collection;
        }
		
		#endregion
		
    }

    #endregion

}

