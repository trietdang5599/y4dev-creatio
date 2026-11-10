namespace Terrasoft.Configuration.GenAI
{
	/// <summary>
	/// Represents options for configuring chat completion requests in Generative AI services.
	/// </summary>
	public class ChatCompletionRequestOptions
	{

		#region Properties: Public

		/// <summary>
		/// Default options for chat completion requests.
		/// </summary>
		public static readonly ChatCompletionRequestOptions Default = new ChatCompletionRequestOptions();

		/// <summary>
		/// Gets or sets a value indicating whether to skip validation of the request options.
		/// </summary>
		public bool SkipValidation { get; set; } = false;

		#endregion

	}
}

