 namespace Terrasoft.Configuration.GenAI
 {
	using Terrasoft.Core;
	using Terrasoft.Core.Applications.Abstractions.Creation;
	using Terrasoft.Core.Factories;

	#region Interface: IGenAICardSchemaGenerator

	public interface IGenAICardSchemaGenerator
	{

		#region Methods: Public

		void GenerateCards(ApplicationGenerationResult contentGenerationResult, string appCode);

		#endregion

	}

	#endregion

	#region Class: GenAICardSchemaGenerator

	[DefaultBinding(typeof(IGenAICardSchemaGenerator))]
	public class GenAICardSchemaGenerator : IGenAICardSchemaGenerator
	{

		#region Constants: Private

		private const string PageNameTemplate = "{0}_FormPage";

		#endregion

		#region Methods: Private

		private string GetPageName(string appCode) {
			string name = string.Format(PageNameTemplate, appCode);
			if (UserConnection.Current.ClientUnitSchemaManager.FindInstanceByName(name) != null) {
				name = string.Format(PageNameTemplate, appCode);
			}
			return name;
		}

		#endregion

		#region Methods: Public

		public void GenerateCards(ApplicationGenerationResult contentGenerationResult, string appCode) {
			UserConnection userConnection = UserConnection.Current;
			ClientUnitSchema existingMainEntityCard =
				userConnection.ClientUnitSchemaManager.FindInstanceByName(GetPageName(appCode));
			contentGenerationResult.Sections[0].PageSchemaUId = existingMainEntityCard.UId;
		}

		#endregion

	}

	#endregion

}
