 namespace Terrasoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Entities.Factories;
	using Terrasoft.Core.Factories;

	#region Class: SysModuleInWorkplaceByUITypeQueryExecutor


	[DefaultBinding(typeof(IEntityQueryExecutor), Name = "SysModuleInWorkplaceByUITypeQueryExecutor")]
	public class SysModuleInWorkplaceByUITypeQueryExecutor : BaseWorkplaceSchemaByUITypeQueryExecutor
	{
		private readonly IEntityFactory _factory;

		#region Constants: Private

		private const string MobileSectionSchemaUIdColumnName = "SysModule.MobileSectionSchemaUId";

		#endregion

		#region Fields: Private

		private bool? _isMobileWorkplace;

		#endregion

		#region Constructors: Public

		public SysModuleInWorkplaceByUITypeQueryExecutor(UserConnection userConnection,
			IFreedomUIClientUnitSchemaProvider clientUnitSchemaProvider, IEntityFactory factory)
			: base(userConnection, clientUnitSchemaProvider) {
			_factory = factory;
		}

		#endregion

		#region Properties: Protected

		protected override string TargetEntitySchemaName => "SysModuleInWorkplaceByUIType";
		protected override string ParentEntitySchemaName => "SysModuleInWorkplace";
		protected override string SectionSchemaUIdColumnPath => "SysModule.SectionSchemaUId";
		protected override string MobileSectionSchemaUIdColumnPath => MobileSectionSchemaUIdColumnName;

		#endregion

		#region Methods: Private

		private void InitIsMobileWorkPlaceFromFilters(IEntitySchemaQueryFilterItem filterItem) {
			IEnumerable<EntitySchemaQueryFilter> filterInstances = filterItem.GetFilterInstances();
			foreach (EntitySchemaQueryFilter filter in filterInstances) {
				InitIsMobileWorkPlaceFromFilter(filter);
				if (_isMobileWorkplace.HasValue) {
					break;
				}
			}
		}

		private void InitIsMobileWorkPlaceFromFilter(EntitySchemaQueryFilter filter) {
			const string workplaceSchemaName = "SysWorkplace";
			if (filter.LeftExpression?.SchemaColumn?.Name != workplaceSchemaName || 
				filter.RightExpressions.Count == 0 ||
				filter.RightExpressions[0].ExpressionType != EntitySchemaQueryExpressionType.Parameter) {
				return;
			}
			object value = filter.RightExpressions.First().ParameterValue;
			IEntity workplace = _factory.CreateEntity(workplaceSchemaName, new CreateEntityOptions {
				UseAdminRight = false
			});
			if (workplace.FetchFromDB("Id", value, false)) {
				_isMobileWorkplace = workplace.GetTypedColumnValue<Guid>("SysApplicationClientTypeId") ==
					BaseConsts.PhoneClientTypeId;
			}
		}

		#endregion

		#region Methods: Protected

		protected override bool GetIsMobileWorkplace(EntitySchemaQueryFilterCollection filters) {
			if (_isMobileWorkplace.HasValue) {
				return _isMobileWorkplace.Value;
			}
			foreach (IEntitySchemaQueryFilterItem entitySchemaQueryFilterItem in filters) {
				InitIsMobileWorkPlaceFromFilters(entitySchemaQueryFilterItem);
				if (_isMobileWorkplace.HasValue) {
					break;
				}
			}
			if (!_isMobileWorkplace.HasValue) {
				_isMobileWorkplace = false;
			}
			return _isMobileWorkplace.Value;
		}
	
		#endregion

	}

	#endregion

}

