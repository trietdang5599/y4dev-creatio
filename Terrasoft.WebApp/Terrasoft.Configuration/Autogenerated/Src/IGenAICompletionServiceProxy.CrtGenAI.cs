namespace Terrasoft.Configuration.GenAI
{
	using System.Threading;
	using System.Threading.Tasks;
	using Terrasoft.Enrichment.Interfaces.ChatCompletion.Requests;
	using Terrasoft.Enrichment.Interfaces.ChatCompletion.Responses;

	/// <summary>
	/// Interface for GenAI completion service proxy.
	/// </summary>
	public interface IGenAICompletionServiceProxy
	{
		/// <summary>
		/// Gets chat completion response based on the provided request.
		/// </summary>
		/// <param name="request">The chat completion request containing messages and options.</param>
		/// <param name="options">Optional parameters for the chat completion request.</param>
		/// <returns>A chat completion response containing the generated messages and other details.</returns>
		ChatCompletionResponse ChatCompletion(ChatCompletionRequest request,
			ChatCompletionRequestOptions options = null);
		Task<ChatCompletionResponse> ChatCompletionAsync(ChatCompletionRequest request, CancellationToken token,
			ChatCompletionRequestOptions options = null);
		ClientQuotaResponse GetClientQuotaByClientId();
	}
} 
