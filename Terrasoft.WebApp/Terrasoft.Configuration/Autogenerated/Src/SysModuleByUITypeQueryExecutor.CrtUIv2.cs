namespace Terrasoft.Configuration
{
	using System.Linq;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;

	#region Class: SysModuleByUITypeQueryExecutor

	[DefaultBinding(typeof(IEntityQueryExecutor), Name = "SysModuleByUITypeQueryExecutor")]
	public class SysModuleByUITypeQueryExecutor : BaseWorkplaceSchemaByUITypeQueryExecutor
	{

		#region Constants: Private

		private const string MobileSectionSchemaUIdColumnName = "MobileSectionSchemaUId";

		#endregion

		#region Fields: Private

		private bool? _isMobileWorkplace;

		#endregion

		#region Constructors: Public

		public SysModuleByUITypeQueryExecutor(UserConnection userConnection,
			IFreedomUIClientUnitSchemaProvider clientUnitSchemaProvider)
			: base(userConnection, clientUnitSchemaProvider) { }

		#endregion

		#region Properties: Protected

		protected override string TargetEntitySchemaName => "SysModuleByUIType";
		protected override string ParentEntitySchemaName => "SysModule";
		protected override string SectionSchemaUIdColumnPath => "SectionSchemaUId";
		protected override string MobileSectionSchemaUIdColumnPath => MobileSectionSchemaUIdColumnName;

		#endregion

		#region Methods: Protected

		protected override bool GetIsMobileWorkplace(EntitySchemaQueryFilterCollection filters) {
			if (_isMobileWorkplace.HasValue) {
				return _isMobileWorkplace.Value;
			}
			_isMobileWorkplace = filters
				.SelectMany(filterItem => filterItem.GetFilterInstances())
				.Any(filter =>
				filter.ComparisonType == FilterComparisonType.IsNotNull &&
				filter.LeftExpression?.SchemaColumnName == MobileSectionSchemaUIdColumnName);
			return _isMobileWorkplace.Value;
		}

		#endregion

	}

	#endregion

}

