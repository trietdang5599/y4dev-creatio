namespace Terrasoft.Configuration.GenAI
{
	using System.Threading.Tasks;
	using Terrasoft.Enrichment.Interfaces.GenAI.Model;

	#region Interface: IGenAILlmConfigurationServiceProxy

	/// <summary>
	/// Defines operations for managing Large Language Model (LLM) configurations
	/// through a service proxy. Supports adding, updating, and deleting model configurations.
	/// </summary>
	public interface IGenAILlmConfigurationServiceProxy
	{

		#region Methods: Public

		/// <summary>
		/// Adds a new LLM configuration to the system.
		/// </summary>
		/// <param name="llmModel">The LLM model configuration to add.</param>
		void AddLlmConfiguration(ModelConfiguration configuration);

		/// <summary>
		/// Updates an existing LLM configuration in the system.
		/// </summary>
		/// <param name="llmModel">The LLM model configuration with updated values.</param>
		void UpdateLlmConfiguration(ModelConfiguration configuration);

		/// <summary>
		/// Deletes an existing LLM configuration from the system.
		/// </summary>
		/// <param name="modelId">The unique identifier of the LLM model configuration to delete.</param>
		void DeleteLlmConfiguration(ModelConfiguration configuration);

		#endregion

	}

	#endregion

}

