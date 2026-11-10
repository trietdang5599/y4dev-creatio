namespace Terrasoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Text;
	using System.Text.RegularExpressions;
	using Newtonsoft.Json.Linq;
	using Terrasoft.Core.Factories;

	#region Class: JsonWebhookParser

	/// <summary>
	/// Webhook body parser from json.
	/// </summary>
	[DefaultBinding(typeof(IWebhookParser))]
	public class JsonWebhookParser : IWebhookParser
	{

		#region Fields: Private

		/// <summary>
		/// Pattern of x-www-form-urlencoded format.
		/// </summary>
		private readonly string RegexPattern = "^([A-Za-z0-9]{4})*([A-Za-z0-9]{3}=|[A-Za-z0-9]{2}==)?$";

		#endregion

		#region Properties: Public

		/// <inheritdoc cref="IWebhookParser"/>
		public IEnumerable<string> SupportedTypes => new[] { "application/json" };

		#endregion

		#region Methods: Public

		/// <summary>
		/// Parse webhook body.
		/// </summary>
		/// <param name="webhookBody">JSON string.</param>
		/// <param name="jsonDocument">Result.</param>
		/// <returns>JsonDocument.</returns>
		public bool TryGetObject(string webhookBody, out JObject jsonDocument) {
			try {
				if (Regex.IsMatch(webhookBody, RegexPattern)) {
					byte[] bytes = Convert.FromBase64String(webhookBody);
					webhookBody = Encoding.UTF8.GetString(bytes);
				}
				jsonDocument = JObject.Parse(webhookBody);
				return jsonDocument != null;
			} catch {
				jsonDocument = null;
				return false;
			}
		}

		#endregion

	}

	#endregion

}

