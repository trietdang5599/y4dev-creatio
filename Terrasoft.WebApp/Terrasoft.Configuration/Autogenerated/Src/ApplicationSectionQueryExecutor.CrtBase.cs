namespace Terrasoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Applications.Abstractions;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Packages;

	#region Class: ApplicationSectionData

	public class ApplicationSectionData
	{

		#region Properties: Public

		public Guid Id { get; set; }

		public string Caption { get; set; }

		public string Description { get; set; }

		public string Code { get; set; }

		public string EntitySchemaName { get; set; }

		public Guid SectionSchemaUId { get; set; }

		public string SchemaType { get; set; }

		public int Type { get; set; }

		public Guid ApplicationId { get; set; }
		
		public Guid PackageId { get; set; }

		public Guid LogoId { get; set; }

		public DateTime ModifiedOn { get; set; }

		public string IconBackground { get; set; }

		#endregion

	}

	#endregion

	#region Class: ApplicationSectionQueryExecutor

	[DefaultBinding(typeof(IEntityQueryExecutor), Name = "ApplicationSectionQueryExecutor")]
	public class ApplicationSectionQueryExecutor : IEntityQueryExecutor
	{

		#region Fields: Private

		private readonly UserConnection _userConnection;

		private readonly string _entitySchemaName = "ApplicationSection";

		private readonly IAppManager _appManager;

		private readonly Dictionary<string, Func<List<Guid>, IEnumerable<ApplicationSectionData>>>
			_sectionGettersByColumnName = new Dictionary<string, Func<List<Guid>, IEnumerable<ApplicationSectionData>>>();

		private const string DefaultOrangeColor = "#ff4013";

		#endregion

		#region Properties: Protected

		protected UserConnection UserConnection => _userConnection;

		protected ClientUnitSchemaManager ClientUnitSchemaManager => UserConnection.ClientUnitSchemaManager;

		protected EntitySchemaManager EntitySchemaManager => UserConnection.EntitySchemaManager;

		private EntitySchema _entitySchema;
		protected EntitySchema EntitySchema =>
			_entitySchema ?? (_entitySchema = EntitySchemaManager.GetInstanceByName(_entitySchemaName));

		#endregion

		#region Constructors: Public

		public ApplicationSectionQueryExecutor(UserConnection userConnection, IAppManager appManager) {
			_userConnection = userConnection;
			_appManager = appManager;
			InitializeSectionActions();
		}

		#endregion

		#region Methods: Private

		private void InitializeSectionActions() {
			_sectionGettersByColumnName.Add("Id", filter => GetAppSectionListById(filter));
			_sectionGettersByColumnName.Add("ApplicationId", filter => GetAppSectionListByApplicationId(filter));
			_sectionGettersByColumnName.Add("PackageId", filter => GetAppSectionListByPackageIds(filter));
		}

		private List<ApplicationSectionData> GetAppSectionListById(List<Guid> sectionIds) {
			List <ApplicationSectionData> result = new List<ApplicationSectionData>();
			foreach (var sectionId in sectionIds) {
				ApplicationSectionData section = GetSection(sectionId);
				SetupApplicationIdAtSectionData(section);
				result.Add(section);
			}

			return result;
		}

		private ApplicationSectionData GetSection(Guid id) {
			Entity section = GetSysModuleEntity(id);
			return GetApplicationSectionData(section);
		}

		private Entity GetSysModuleEntity(Guid primaryColumnValue) {
			EntitySchemaQuery esq = CreateEntitySchemaQueryForSysModule();
			return esq.GetEntity(UserConnection, primaryColumnValue);
		}

		private void SetupApplicationIdAtSectionData(ApplicationSectionData sectionData) {
			Guid applicationId = GetApplicationIdFromSchema(sectionData.SectionSchemaUId);
			sectionData.ApplicationId = applicationId;
		}

		private Guid GetApplicationIdFromSchema(Guid schemaUId) {
			Guid packageUId = GetPackageUIdFromSchema(schemaUId);
			EntitySchemaQuery esq = new EntitySchemaQuery(EntitySchemaManager, "SysPackageInInstalledApp");
			esq.AddColumn("SysInstalledApp");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "SysPackage.UId", packageUId));
			EntityCollection collection = esq.GetEntityCollection(UserConnection);
			return collection.First.Value.GetTypedColumnValue<Guid>("SysInstalledAppId");
		}

		private Guid GetPackageUIdFromSchema(Guid schemaUId) {
			ISchemaManagerItem<ClientUnitSchema> schema = ClientUnitSchemaManager.FindItemByUId(schemaUId);
			return schema.PackageUId;
		}

		private List<ApplicationSectionData> GetAppSectionListByApplicationId(List<Guid> appIds)
		{
			List<ApplicationSectionData> allSections = GetAllSection();
			return appIds.SelectMany(appId => FindAppSections(appId, allSections))
				.ToHashSet().ToList();
		}
		
		private List<ApplicationSectionData> GetAppSectionListByPackageIds(List<Guid> pkgIds) {
			List<ApplicationSectionData> allSections = GetAllSection();
			return FindPkgSections(pkgIds, allSections).ToHashSet().ToList();
		}

		private List<ApplicationSectionData> GetAllSection() {
			EntityCollection sysModuleEntities = GetSysModuleEntities();
			return sysModuleEntities.Select(GetApplicationSectionData).ToList();
		}

		private EntityCollection GetSysModuleEntities() {
			EntitySchemaQuery esq = CreateEntitySchemaQueryForSysModule();
			return esq.GetEntityCollection(UserConnection);
		}

		private EntitySchemaQuery CreateEntitySchemaQueryForSysModule() {
			var esq = new EntitySchemaQuery(EntitySchemaManager, "SysModule");
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.AddColumn("Caption");
			esq.AddColumn("Description");
			esq.AddColumn("Code");
			esq.AddColumn("SectionSchemaUId");
			esq.AddColumn("Type");
			esq.AddColumn("Image32");
			esq.AddColumn("ModifiedOn");
			esq.AddColumn("SysModuleEntity.[SysSchema:UId:SysEntitySchemaUId].Name").Name = "EntitySchemaName";
			esq.AddColumn("IconBackground");
			return esq;
		}

		private ApplicationSectionData GetApplicationSectionData(Entity sysModuleEntity) {
			Guid sectionSchemaUId = sysModuleEntity.GetTypedColumnValue<Guid>("SectionSchemaUId");
			string schemaType = GetSchemaTypeBySchemaUId(sectionSchemaUId);
			string iconBackground = sysModuleEntity.GetTypedColumnValue<string>("IconBackground");
			return new ApplicationSectionData {
				Id = sysModuleEntity.PrimaryColumnValue,
				Caption = sysModuleEntity.GetTypedColumnValue<string>("Caption"),
				Description = sysModuleEntity.GetTypedColumnValue<string>("Description"),
				Code = sysModuleEntity.GetTypedColumnValue<string>("Code"),
				EntitySchemaName = sysModuleEntity.GetTypedColumnValue<string>("EntitySchemaName"),
				SectionSchemaUId = sectionSchemaUId,
				SchemaType = schemaType,
				Type = sysModuleEntity.GetTypedColumnValue<int>("Type"),
				LogoId = sysModuleEntity.GetTypedColumnValue<Guid>("Image32Id"),
				ModifiedOn = sysModuleEntity.GetTypedColumnValue<DateTime>("ModifiedOn"),
				IconBackground = iconBackground.IsNullOrWhiteSpace()? DefaultOrangeColor: iconBackground
			};
		}

		private string GetSchemaTypeBySchemaUId(Guid schemaUId) {
			ISchemaManagerItem<ClientUnitSchema> schema = ClientUnitSchemaManager.FindItemByUId(schemaUId);
			return schema != null ? GetSchemaType(schema) : string.Empty;
		}

		private string GetSchemaType(ISchemaManagerItem<ClientUnitSchema> sectionSchema) {
			ExtraPropertyCollection schemaExtraProperties = sectionSchema.ExtraProperties;
			if (schemaExtraProperties.Count == 0) {
				return string.Empty;
			}
			ExtraProperty schemaTypeExtraProperty = schemaExtraProperties.GetByName("SchemaType");
			return schemaTypeExtraProperty?.Value?.ToString();
		}

		private List<ApplicationSectionData> FindAppSections(Guid appId, List<ApplicationSectionData> allSections) {
			List<Guid> foundSysModulesSchemasUIds = FindAppSectionSchemasUIds(appId, allSections);
			var appSections = allSections
				.Where(sysModule => foundSysModulesSchemasUIds.Contains(sysModule.SectionSchemaUId))
				.ToList();
			appSections.ForEach(appSection => appSection.ApplicationId = appId);
			return appSections;
		}

		private List<ApplicationSectionData> FindPkgSections(List<Guid> pkgIds, List<ApplicationSectionData> allSections) {
			List<Guid> foundSysModulesSchemasUIds = FindPkgSectionSchemasUIds(pkgIds, allSections);
			var appSections = allSections
				.Where(sysModule => foundSysModulesSchemasUIds.Contains(sysModule.SectionSchemaUId))
				.ToList();
			return appSections;
		}

		private List<Guid> FindAppSectionSchemasUIds(Guid appId, List<ApplicationSectionData> allSections) {
			Dictionary<Guid, Guid> sysModulesSchemasRealUIds = GetSysModulesSchemasUIds(allSections);
			Dictionary<Guid, Guid> appSchemasRealUIds = GetAppSchemasUIds(appId);
			return sysModulesSchemasRealUIds
				.Where(sysModulesSchemasRealUId => appSchemasRealUIds
					.Any(appSchemaUIds => sysModulesSchemasRealUId.Value.Equals(appSchemaUIds.Value)))
				.Select(sysModulesSchemasRealUId => sysModulesSchemasRealUId.Key)
				.ToList();
		}
		
		private List<Guid> FindPkgSectionSchemasUIds(List<Guid> pkgIds, List<ApplicationSectionData> allSections) {
			Dictionary<Guid, Guid> sysModulesSchemasRealUIds = GetSysModulesSchemasUIds(allSections);
			Dictionary<Guid, Guid> appSchemasRealUIds = GetPkgSchemasUIds(pkgIds);
			return sysModulesSchemasRealUIds
				.Where(sysModulesSchemasRealUId => appSchemasRealUIds
					.Any(appSchemaUIds => sysModulesSchemasRealUId.Value.Equals(appSchemaUIds.Value)))
				.Select(sysModulesSchemasRealUId => sysModulesSchemasRealUId.Key)
				.ToList();
		}

		private Dictionary<Guid, Guid> GetAppSchemasUIds(Guid appId) {
			var packageUIds = GetAppPackageUIds(appId);
			return ClientUnitSchemaManager.GetPackageItems(packageUIds)
				.ToDictionary(schema => schema.UId, schema => schema.RealUId);
		}
		
		private Dictionary<Guid, Guid> GetPkgSchemasUIds(List<Guid> pkgIds) {
			IList<Guid> packageUIds =  pkgIds.Count > 0 ?
				WorkspaceUtilities.GetPackageUIdsByIds(_userConnection, pkgIds.ToArray()):
				new List<Guid>();
			return ClientUnitSchemaManager.GetPackageItems(packageUIds)
				.ToDictionary(schema => schema.UId, schema => schema.RealUId);
		}

		private Dictionary<Guid, Guid> GetSysModulesSchemasUIds(List<ApplicationSectionData> sections) {
			var sysModulesSchemasUIds = sections
				.Select(sysModule => sysModule.SectionSchemaUId)
				.ToList();
			return ClientUnitSchemaManager.GetItems()
				.Where(schema => sysModulesSchemasUIds.Contains(schema.UId))
				.ToDictionary(schema => schema.UId, schema => schema.RealUId);
		}

		private List<Guid> GetAppPackageUIds(Guid appId) {
			IEnumerable<Package> appPackages = _appManager.GetAppPackages(appId);
			return appPackages.Select(p => p.UId).ToList();
		}

		private IEnumerable<ApplicationSectionData> GetApplicationSectionsByFilter(
				EntitySchemaQueryFilterCollection filters) {
			var result = new List<ApplicationSectionData>();
			foreach (var sectionGetAction in _sectionGettersByColumnName) {
				string columnName = sectionGetAction.Key;
				if (HasSpecificColumnAtFilterExpressions(filters, columnName)) {
					var filterValues = GetSpecificColumnValuesAtFilterExpressions(filters, columnName);
					var sectionsGetter = sectionGetAction.Value;
					result.AddRange(sectionsGetter(filterValues));
				}
			}
			return result.DistinctBy(s => s.SectionSchemaUId);
		}

		private bool HasSpecificColumnAtFilterExpressions(EntitySchemaQueryFilterCollection filters,
				string columnName) {
			return filters.Select(filter => (EntitySchemaQueryFilter)filter)
				.Any(filter => filter.LeftExpression.ExpressionType == EntitySchemaQueryExpressionType.SchemaColumn &&
					filter.LeftExpression.SchemaColumn.Name == columnName);
		}

		private List<Guid> GetSpecificColumnValuesAtFilterExpressions(EntitySchemaQueryFilterCollection filters,
				string columnName) {
			return filters.Select(filter => (EntitySchemaQueryFilter)filter)
				.First(filter => filter.LeftExpression.ExpressionType == EntitySchemaQueryExpressionType.SchemaColumn &&
					filter.LeftExpression.SchemaColumn.Name == columnName).RightExpressions
					.Select(x => (Guid)x.ParameterValue).ToList();
		}

		private EntityCollection ConvertAppSectionsToEntityCollection(IEnumerable<ApplicationSectionData> appSections) {
			var collection = new EntityCollection(UserConnection, EntitySchema);
			appSections.ForEach(appSection => {
				collection.Add(ConvertAppSectionsToEntity(appSection));
			});
			return collection;
		}

		private Entity ConvertAppSectionsToEntity(ApplicationSectionData appSection) {
			Entity appSectionEntity = EntitySchema.CreateEntity(UserConnection);
			appSectionEntity.SetColumnValue("Id", appSection.Id);
			appSectionEntity.SetColumnValue("Caption", appSection.Caption);
			appSectionEntity.SetColumnValue("Description", appSection.Description);
			appSectionEntity.SetColumnValue("Code", appSection.Code);
			appSectionEntity.SetColumnValue("EntitySchemaName", appSection.EntitySchemaName);
			appSectionEntity.SetColumnValue("SectionSchemaUId", appSection.SectionSchemaUId);
			appSectionEntity.SetColumnValue("SchemaType", appSection.SchemaType);
			appSectionEntity.SetColumnValue("Type", appSection.Type);
			appSectionEntity.SetColumnValue("ApplicationId", appSection.ApplicationId);
			appSectionEntity.SetColumnValue("PackageId", appSection.PackageId);
			appSectionEntity.SetColumnValue("LogoId", appSection.LogoId);
			appSectionEntity.SetColumnValue("ModifiedOn", appSection.ModifiedOn);
			appSectionEntity.SetColumnValue("IconBackground", appSection.IconBackground);
			return appSectionEntity;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns application sections by esq filters.
		/// </summary>
		/// <param name="esq">Esq with filters.</param>
		/// <returns>Application sections.</returns>
		public EntityCollection GetEntityCollection(EntitySchemaQuery esq) {
			UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManageSolution");
			IEnumerable<ApplicationSectionData> appSections = GetApplicationSectionsByFilter(esq.Filters);
			return ConvertAppSectionsToEntityCollection(appSections);
		}

		#endregion

	}

	#endregion

}

