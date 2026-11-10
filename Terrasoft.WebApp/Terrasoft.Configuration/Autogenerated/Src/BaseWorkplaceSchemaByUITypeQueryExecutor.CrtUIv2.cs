namespace Terrasoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;

	#region Class: BaseWorkplaceByUITypeQueryExecutor

	public abstract class BaseWorkplaceSchemaByUITypeQueryExecutor : IEntityQueryExecutor
	{

		#region Constants: Private

		private const string SectionUiTypeColumnName = "SectionUIType";
		private const string SectionUiTypeColumnValueQueryAlias = "SectionUITypeId";

		#endregion

		#region Fields: Private

		private readonly UserConnection _userConnection;
		private readonly IFreedomUIClientUnitSchemaProvider _clientUnitSchemaProvider;
		private string _sectionSchemaUIdColumnName;

		#endregion

		#region Constructors: Protected

		protected BaseWorkplaceSchemaByUITypeQueryExecutor(UserConnection userConnection,
			IFreedomUIClientUnitSchemaProvider clientUnitSchemaProvider) {
			_userConnection = userConnection;
			_clientUnitSchemaProvider = clientUnitSchemaProvider;
		}

		#endregion

		#region Properties: Protected

		protected abstract string TargetEntitySchemaName { get; }
		protected abstract string ParentEntitySchemaName { get; }
		protected abstract string SectionSchemaUIdColumnPath { get; }
		protected virtual string MobileSectionSchemaUIdColumnPath => null;

		#endregion

		#region Methods: Private

		private static void AddSchemaLookupColumn(EntitySchema schemaByUIType, string referenceSchemaName,
				string columnName) {
			schemaByUIType.AddLookupColumn(referenceSchemaName, columnName);
		}

		private static bool GetIsSchemaColumnExists(EntitySchema schemaByUIType, string columnName) {
			return schemaByUIType.Columns.FindByName(columnName) != null;
		}

		private static void AddSchemaColumnIfNotExists(EntitySchema schemaByUIType, EntitySchemaColumn esqSchemaColumn) {
			if (GetIsSchemaColumnExists(schemaByUIType, esqSchemaColumn.Name)) {
				return;
			}
			if (esqSchemaColumn.IsLookupType) {
				AddSchemaLookupColumn(schemaByUIType, esqSchemaColumn.ReferenceSchema.Name, esqSchemaColumn.Name);
			} else {
				schemaByUIType.AddColumn(esqSchemaColumn.DataValueType.Name, esqSchemaColumn.Name);
			}
		}

		private static bool TryGetSpecificColumnAtFilterExpressions(EntitySchemaQueryFilterCollection filters,
				string columnName, out EntitySchemaQueryFilter queryFilter) {
			queryFilter = filters.SelectMany(filterCollection => filterCollection.GetFilterInstances()).FirstOrDefault(
				filter => filter.LeftExpression?.ExpressionType == EntitySchemaQueryExpressionType.SchemaColumn &&
					filter.LeftExpression?.SchemaColumn?.Name == columnName);
			return queryFilter != null;
		}

		private static void AddColumnToQuery(EntitySchemaQueryColumn column, EntitySchemaQuery esq) {
			EntitySchemaQueryColumn schemaColumn = esq.AddColumn(column.Path);
			schemaColumn.Name = column.Name;
			schemaColumn.Caption = column.Caption;
			schemaColumn.OrderDirection = column.OrderDirection;
			schemaColumn.OrderPosition = column.OrderPosition;
		}

		private EntityCollection GetSchemaEntities(EntitySchemaQuery esq) {
			var schemaQuery = new EntitySchemaQuery(_userConnection.EntitySchemaManager, ParentEntitySchemaName) {
				PrimaryQueryColumn = {
					IsAlwaysSelect = esq.PrimaryQueryColumn.IsAlwaysSelect
				}
			};
			GetColumnsForSync(esq).ForEach(column => AddColumnToQuery(column, schemaQuery));
			_sectionSchemaUIdColumnName = schemaQuery.AddColumn(GetSectionSchemaUIdColumnPath(esq.Filters)).Name;
			EntitySchemaQueryFilterCollection filters = esq.Filters.Clone(schemaQuery);
			filters.ForEach(schemaQuery.Filters.Add);
			return schemaQuery.GetEntityCollection(_userConnection);
		}

		private void RemoveFilterFromCollection(EntitySchemaQueryFilter queryFilter,
				EntitySchemaQueryFilterCollection filterCollection) {
			var queryFilterCollection = filterCollection.FirstOrDefault(item =>
					item.GetFilterInstances()
						.Any(instance => instance.LeftExpression.SchemaColumn.Name == SectionUiTypeColumnName))
				as EntitySchemaQueryFilterCollection;
			if (queryFilterCollection == null || !queryFilterCollection.Remove(queryFilter)) {
				RemoveFilterFromCollection(queryFilter, queryFilterCollection);
			}
		}

		private List<Guid> GetAngularSchemasUIds() {
			return _clientUnitSchemaProvider.GetClientUnitSchemasInfos().Select(info => info.SchemaUId).ToList();
		}

		private static void OrderEntityCollection(EntitySchemaQuery esq, EntityCollection collection) {
			EntitySchemaQueryColumn sectionUITypeQueryColumn = esq.Columns.FirstOrDefault(column =>
				column.Path == SectionUiTypeColumnName);
			if (sectionUITypeQueryColumn != null && sectionUITypeQueryColumn.OrderPosition > 0) {
				collection.Order(SectionUiTypeColumnValueQueryAlias, sectionUITypeQueryColumn.OrderDirection);
			}
		}

		private IEnumerable<EntitySchemaQueryColumn> GetColumnsForSync(EntitySchemaQuery esq) {
			return esq.Columns.Where(column => column != null
				&& column.Name != esq.PrimaryQueryColumn.Name
				&& column.Name != SectionUiTypeColumnName
				&& column.ValueQueryAlias != SectionUiTypeColumnName
				&& !column.Path.Contains(SectionUiTypeColumnName)
				&& !column.Path.Contains(GetSectionSchemaUIdColumnPath(esq.Filters)));
		}

		private Entity CreateSchemaByUITypeEntity(EntitySchema sysModuleByUITypeSchema,
				Entity sysModuleEntity, List<Guid> angularSchemas) {
			Entity sysModuleByUITypeEntity = sysModuleByUITypeSchema.CreateEntity(_userConnection);
			sysModuleEntity.GetColumnValueNames()
				.Where(sysModuleEntity.GetIsColumnValueLoaded)
				.ForEach(columnName => {
				sysModuleByUITypeEntity.ForceSetColumnValue(columnName, sysModuleEntity.GetColumnValue(columnName));
			});
			var sectionSchemaUId = sysModuleEntity.GetTypedColumnValue<Guid>(_sectionSchemaUIdColumnName);
			Guid sectionUITypeId = angularSchemas.Any(schema => schema == sectionSchemaUId)
				? SectionUITypeConsts.FreedomUiSectionUiTypeId
				: SectionUITypeConsts.ClassicUiSectionUiTypeId;
			sysModuleByUITypeEntity.SetColumnValue(SectionUiTypeColumnValueQueryAlias, sectionUITypeId);
			sysModuleByUITypeEntity.LoadLookupDisplayValues(SectionUiTypeColumnName);
			return sysModuleByUITypeEntity;
		}

		private EntitySchema PrepareEntitySchema(EntitySchemaQuery esq) {
			EntitySchema entitySchema = _userConnection.EntitySchemaManager.GetInstanceByName(TargetEntitySchemaName)
				.CloneShallow();
			EntitySchemaColumnCollection esqSchemaColumns = esq.GetSchema().Columns;
			esqSchemaColumns.ForEach(esqSchemaColumn => {
				AddSchemaColumnIfNotExists(entitySchema, esqSchemaColumn);
			});
			if (!GetIsSchemaColumnExists(entitySchema, SectionUiTypeColumnName)) {
				AddSchemaLookupColumn(entitySchema, SectionUiTypeColumnName, SectionUiTypeColumnName);
			}
			return entitySchema;
		}

		private EntityCollection FilterCollectionByUIType(EntityCollection collection,
				EntitySchemaQueryFilter queryFilter) {
			var filteredCollection = new EntityCollection(_userConnection, collection.Schema);
			filteredCollection.AddRange(collection.Where(item =>
				item.GetTypedColumnValue<Guid>(SectionUiTypeColumnValueQueryAlias) ==
				(Guid)queryFilter.RightExpressions.First().ParameterValue));
			return filteredCollection;
		}

		#endregion

		#region Methods: Protected

		protected virtual string GetSectionSchemaUIdColumnPath(EntitySchemaQueryFilterCollection filters) {
			if (_userConnection.GetIsFeatureEnabled("DisableMobileSectionSchemaUIdColumnPathDetection")) {
				return SectionSchemaUIdColumnPath;
			}
			if (MobileSectionSchemaUIdColumnPath.IsNotNullOrEmpty() && GetIsMobileWorkplace(filters)) {
				return MobileSectionSchemaUIdColumnPath;
			}
			return SectionSchemaUIdColumnPath;
		}

		protected virtual bool GetIsMobileWorkplace(EntitySchemaQueryFilterCollection filters) {
			return false;
		}

		#endregion

		#region Methods: Public

		public EntityCollection GetEntityCollection(EntitySchemaQuery esq) {
			EntitySchema schemaByUIType = PrepareEntitySchema(esq);
			var collection = new EntityCollection(_userConnection, schemaByUIType);
			if (TryGetSpecificColumnAtFilterExpressions(esq.Filters, SectionUiTypeColumnName,
					out EntitySchemaQueryFilter queryByUITypeFilter)) {
				RemoveFilterFromCollection(queryByUITypeFilter, esq.Filters);
			}
			EntityCollection schemaEntities = GetSchemaEntities(esq);
			List<Guid> angularSchemas = GetAngularSchemasUIds();
			schemaEntities.ForEach(schemaEntity => {
				Entity sysModuleByUITypeEntity = CreateSchemaByUITypeEntity(schemaByUIType, schemaEntity,
					angularSchemas);
				collection.Add(sysModuleByUITypeEntity);
			});
			if (queryByUITypeFilter != null) {
				collection = FilterCollectionByUIType(collection, queryByUITypeFilter);
			}
			OrderEntityCollection(esq, collection);
			return collection;
		}

		#endregion

	}

	#endregion

}

