namespace Terrasoft.Configuration
{
	using Terrasoft.Core;
	using Terrasoft.Core.Factories;
	using Terrasoft.Nui;

	#region Class: SectionHelper

	public class SectionHelper: ISectionHelper {

		#region Methods: Public

		public virtual string GetConfigurationScript(UserConnection userConnection) {
			var helper = ClassFactory.Get<ConfigurationSectionHelper>();
			return helper.GetConfigurationScript(userConnection);
		}

		public virtual string GetClientUnitSchemaDescriptors(UserConnection userConnection) {
			var helper = ClassFactory.Get<ConfigurationSectionHelper>();
			return helper.GetClientUnitSchemaDescriptors(userConnection);
		}

		#endregion

	}

	#endregion

}

