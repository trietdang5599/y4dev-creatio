namespace Terrasoft.Configuration
{
	/// <summary>
	/// Provider webhook description from webhook entity
	/// </summary>
	public interface IWebhookDescriptionProvider
	{

		#region Methods: Public

		/// <summary>
		/// Create webhook description.
		/// </summary>
		/// <param name="webhook">Webhook entity.</param>
		/// <param name="webhookDescription">Result.</param>
		/// <param name="errorMessage">The message error.</param>
		/// <returns>Parsed webhook.</returns>
		bool TryGetWebhookDescription(WebhookObj webhook, out WebhookDescription webhookDescription, 
			out string errorMessage);

		#endregion

	}
}
