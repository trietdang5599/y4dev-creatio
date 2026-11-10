namespace Terrasoft.Configuration
{
	using System;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Factories;
	using Terrasoft.Web.Common;
	using Terrasoft.Configuration.CachingSupport;

	#region Class: PortalAppEventListener

	public class PortalAppEventListener: IAppEventListener
	{
		#region Methods: Public

		public void OnAppStart(AppEventContext context) {
			ClassFactory.Bind<ISectionStructureBuilder, PortalSectionStructureBuilder>(UserType.SSP.ToString());
			ClassFactory.Bind<ISectionStructureBuilder, GeneralSectionStructureBuilder>(UserType.General.ToString());
		}

		public void OnAppEnd(AppEventContext context) {
		}

		public void OnSessionStart(AppEventContext context) {
		}

		public void OnSessionEnd(AppEventContext context) {
		}

		#endregion
	}

	#endregion

	#region Class: PortalSectionStructureBuilder

	public class PortalSectionStructureBuilder: ISectionStructureBuilder, ICachingSupport
	{

		#region Fields: Private

		private Guid SectionSchemaViewModuleUId = new Guid("12244568-6D4F-F201-ED26-AC3913021080");

		#endregion

		#region Methods: Public

		public void ApplyCustomConditions(string schemaName, Select select) {
			select.AddCondition("SysModule", "SectionModuleSchemaUId", LogicalOperation.And).IsEqual(Column.Parameter(SectionSchemaViewModuleUId));
			select.AddCondition("SysModuleEntityInPortal", "SysModuleEntityId", LogicalOperation.Or).Not().IsNull();
			select.Join(JoinType.LeftOuter, "SysModuleEntityInPortal")
				.On("SysModuleEntityInPortal", "SysModuleEntityId").IsEqual(schemaName, "SysModuleEntityId");
		}

		#endregion
	}

	#endregion

	#region Class: GeneralSectionStructureBuilder

	public class GeneralSectionStructureBuilder: ISectionStructureBuilder, ICachingSupport
	{

		#region Methods: Public

		public void ApplyCustomConditions(string schemaName, Select select) {
			var sysModuleEntityInPortalSelect = new Select(select.UserConnection)
					.Column("SysModuleEntityId")
				.From("SysModuleEntityInPortal")
				.Where("SysModuleEntityId").Not().IsNull() as Select;
			select.AddCondition(schemaName, "SysModuleEntityId", LogicalOperation.And)
				.Not().In(sysModuleEntityInPortalSelect);
		}

		#endregion

	}

	#endregion

}
