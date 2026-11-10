namespace Terrasoft.Configuration.GenAI
{
	using System.Collections.Generic;
	using System.ServiceModel;
	using System.ServiceModel.Web;
	using System.ServiceModel.Activation;
	using Creatio.FeatureToggling;
	using Terrasoft.Common;
	using Terrasoft.Configuration.GenAI;
	using Terrasoft.Core.Applications.Abstractions.Creation;
	using Terrasoft.Core.Factories;
	using Terrasoft.Enrichment.Interfaces.GenAI;
	using Terrasoft.Web.Common;

	/// <summary>
	/// Web service for generating content using generative AI.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class GenAIService : BaseService
	{
        
		#region Methods: Public

		/// <summary>
		/// Generates demo data based on the application's description and its entity structure.
		/// </summary>
		/// <returns>Generated data.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "result")]
		public List<GenAIEntityData> GenerateDemoData(string appDescription, List<GeneratedEntity> sections) {
			if (Features.GetIsDisabled<GenAIFeatures.GenerateDemoData>() || sections.IsNullOrEmpty()) {
				return null;
			}
			IGenAIAppServiceProxy genAIServiceProxy = ClassFactory.Get<IGenAIAppServiceProxy>();
			IGeneratedEntityConverter entityConverter = ClassFactory.Get<IGeneratedEntityConverter>();
			var genAIEntityList = entityConverter.ToGenAIEntities(sections);
			var generatedData = genAIServiceProxy.GenerateData(appDescription, genAIEntityList);
			var dataSaver = ClassFactory.Get<IGeneratedEntityDataSaver>();
			dataSaver.SaveData(generatedData, genAIEntityList);
			return generatedData;
		}

		#endregion

	}

}

