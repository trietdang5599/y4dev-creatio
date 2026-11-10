namespace Terrasoft.Configuration
{
	using Terrasoft.Core;
	using Terrasoft.Core.Factories;

	#region Class: ShellSectionHelper

	public class ShellSectionHelper : SectionHelper {

		#region Methods: Public

		public override string GetConfigurationScript(UserConnection userConnection) {
			var helper = ClassFactory.Get<ShellConfigurationSectionHelper>();
			return helper.GetConfigurationScript(userConnection);
		}

		public override string GetClientUnitSchemaDescriptors(UserConnection userConnection) {
			var helper = ClassFactory.Get<ShellConfigurationSectionHelper>();
			return helper.GetClientUnitSchemaDescriptors(userConnection);
		}

		#endregion

	}

	#endregion

}

