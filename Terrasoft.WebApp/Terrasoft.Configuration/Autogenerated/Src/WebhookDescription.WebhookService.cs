namespace Terrasoft.Configuration
{
	using System.Collections.Generic;
	using Newtonsoft.Json.Linq;

	/// <summary>
	/// Parsed webhook.
	/// </summary>
	public class WebhookDescription
	{

		#region Properties: Public

		/// <summary>
		/// Gets or sets the headers.
		/// </summary>
		public Dictionary<string, string> Headers { get; set; }

		/// <summary>
		/// Gets or sets the query parameters.
		/// </summary>
		public Dictionary<string, string> QueryParameters { get; set; }

		/// <summary>
		/// Gets or sets the request body.
		/// </summary>
		public JObject RequestBody { get; set; }

		/// <summary>
		/// Gets or sets the source webhook.
		/// </summary>
		public WebhookObj SourceWebhook { get; set; }

		#endregion

		/// <summary>
		/// Gets the type of the entity.
		/// </summary>
		/// <param name="webhookObj">The webhook object.</param>
		public virtual string GetEntityType() {
			return RequestBody?.Value<string>("EntityName");
		}

	}

}
