namespace Terrasoft.Configuration
{
	using System.Collections.Generic;
	using System.Net.Http.Headers;
	using System.Linq;
	using Newtonsoft.Json.Linq;
	using Terrasoft.Core.Factories;

	#region Class: WebhookDescriptionProvider

	/// <inheritdoc cref="IWebhookDescriptionProvider"/>
	public class WebhookDescriptionProvider : IWebhookDescriptionProvider
	{

		private IEnumerable<IWebhookParser> _parsers;

		#region Properties: Private

		private IEnumerable<IWebhookParser> Parsers {
			get {
				if (_parsers != null && _parsers.Any()) {
					return _parsers;
				}
				return _parsers = ClassFactory.GetAll<IWebhookParser>();
			}
		}

		#endregion

		#region Methods: Private

		/// <summary>
		/// Factory for webhook parsers.
		/// </summary>
		/// <param name="webhookContentType">webhook content type.</param>
		/// <param name="webhookParser">Result.</param>
		/// <returns>Webhook body parser.</returns>
		private bool TryGetParser(string webhookContentType, out IWebhookParser webhookParser) {
			webhookParser = null;
			string mediaType = GetMediaType(webhookContentType);
			if (string.IsNullOrWhiteSpace(mediaType)) {
				return false;
			}

			webhookParser = Parsers
				.FirstOrDefault(x => x.SupportedTypes
					.Contains(mediaType, System.StringComparer.OrdinalIgnoreCase));

			return webhookParser != null;
		}

		private string GetMediaType(string contentType) {
			if (string.IsNullOrWhiteSpace(contentType)) {
				return null;
			}

			try {
				return MediaTypeHeaderValue.Parse(contentType).MediaType;
			} catch {
				return null;
			}
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc cref="IWebhookDescriptionProvider"/>
		public bool TryGetWebhookDescription(WebhookObj webhook, out WebhookDescription webhookDescription,
			out string errorMessage) {
			webhookDescription = null;
			errorMessage = null;
			if (!TryGetParser(webhook.ContentType, out IWebhookParser parser)) {
				errorMessage = $"{webhook.ContentType} type of webhook is not supported.";
				return false;
			}
			if (!parser.TryGetObject(webhook.RequestBody, out JObject webhookObj)) {
				errorMessage = $"Could not parse the webhook body: {webhook.RequestBody}.";
				return false;
			}
			webhookDescription = new WebhookDescription {
				RequestBody = webhookObj,
				SourceWebhook = webhook
			};
			return true;
		}

		#endregion

	}

	#endregion

}

