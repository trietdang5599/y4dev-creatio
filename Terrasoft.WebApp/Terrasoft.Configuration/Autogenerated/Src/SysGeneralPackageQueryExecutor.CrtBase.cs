namespace Terrasoft.Configuration
{
    using System.Linq;
    using Terrasoft.Common;
    using Terrasoft.Core;
    using Terrasoft.Core.Entities;
    using Terrasoft.Core.Factories;

    #region Class: SysGeneralPackageQueryExecutor

    /// <summary>
    /// Query executor for entity schemas of application.
    /// </summary>
    //[DefaultBinding(typeof(IEntityQueryExecutor), Name = "SysGeneralPackageQueryExecutor")]
    public class SysGeneralPackageQueryExecutor : IEntityQueryExecutor
    {

        #region Constantes: Private

        private const string IsActiveColumnName = "IsActive";

        private const string EntitySchemaName = "SysGeneralPackage";
        
        private const string SysPackageSchemaName = "SysPackage";
        
        private const string SysInactivePackageName = "SysInactivePackage";
        
        #endregion

        #region Fields: Private

        private readonly UserConnection _userConnection;

        #endregion

        #region Constructors: Public

        public SysGeneralPackageQueryExecutor(UserConnection userConnection) {
            _userConnection = userConnection;
        }

        #endregion

        #region Methods: Private

        private EntitySchemaQuery CreatePackageEsq(EntitySchemaQuery esq, string schemaName) {
            return new EntitySchemaQuery(_userConnection.EntitySchemaManager, schemaName) {
                PrimaryQueryColumn = {
                    IsAlwaysSelect = esq.PrimaryQueryColumn.IsAlwaysSelect
                },
                UseAdminRights = esq.UseAdminRights
            };
        }

        private EntityCollection GetPackageEntities(EntitySchemaQuery esq, string schemaName) {
            EntitySchemaQuery packageEsq = CreatePackageEsq(esq, schemaName);
            esq.Columns.Where(column => column?.Name != IsActiveColumnName).ForEach(packageEsq.AddColumn);
            bool isActive = schemaName == SysPackageSchemaName;
            EntitySchemaQueryColumn activeColumn = packageEsq.AddColumn(isActive, new BooleanDataValueType(_userConnection.DataValueTypeManager));
            activeColumn.Name = IsActiveColumnName;
            packageEsq.Filters.Add(esq.Filters);
            return packageEsq.GetEntityCollection(_userConnection);
        }

        private EntityCollection GetSysPackageEntity(EntitySchemaQuery esq) {
            return GetPackageEntities(esq, SysPackageSchemaName);
        }
        
        private EntityCollection GetSysInactivePackageEntity(EntitySchemaQuery esq) {
            return GetPackageEntities(esq, SysInactivePackageName);
        }

        private static bool TryGetSpecificColumnAtFilterExpressions(EntitySchemaQueryFilterCollection filters,
                string columnName, out EntitySchemaQueryFilter queryFilter) {
            queryFilter = filters.Select(filter => (EntitySchemaQueryFilter)filter)
                .FirstOrDefault(filter => filter.LeftExpression.ExpressionType == EntitySchemaQueryExpressionType.SchemaColumn &&
                    filter.LeftExpression.SchemaColumn.Name == columnName);
            return queryFilter != null;
        }
        
        
        private EntityCollection GetGeneralPackages(EntitySchemaQuery esq) {
            var sysGeneralPackageEntity = new EntityCollection(_userConnection, EntitySchemaName);
            if (TryGetSpecificColumnAtFilterExpressions(esq.Filters, IsActiveColumnName, out EntitySchemaQueryFilter queryFilter)) {
                var isActive = (bool)queryFilter.RightExpressions.First().ParameterValue;
                esq.Filters.Remove(queryFilter);
                EntityCollection entities = isActive ? GetSysPackageEntity(esq) : GetSysInactivePackageEntity(esq);
                sysGeneralPackageEntity.AddRange(entities);
            } else {
                sysGeneralPackageEntity.AddRange(GetSysPackageEntity(esq));
                sysGeneralPackageEntity.AddRange(GetSysInactivePackageEntity(esq));
            }
            return sysGeneralPackageEntity;
        }

        #endregion

        #region Methods: Public
        
        public EntityCollection GetEntityCollection(EntitySchemaQuery esq) {
            return GetGeneralPackages(esq);
        }
        
        #endregion

    }

    #endregion

}

