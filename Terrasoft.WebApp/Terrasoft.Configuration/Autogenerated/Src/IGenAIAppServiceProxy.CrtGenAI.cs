namespace Terrasoft.Configuration.GenAI
{
	using System.Collections.Generic;
	using Terrasoft.Enrichment.Interfaces.GenAI;

	/// <summary>
	/// Interface for GenAI application service proxy.
	/// </summary>
	public interface IGenAIAppServiceProxy
	{
		List<GenAIEntity> GenerateEntitiesByDescription(string description);
		List<string> GenerateDcmStages(string description);
		List<GenAIEntityData> GenerateData(string description, List<GenAIEntity> entities);
	}
} 
