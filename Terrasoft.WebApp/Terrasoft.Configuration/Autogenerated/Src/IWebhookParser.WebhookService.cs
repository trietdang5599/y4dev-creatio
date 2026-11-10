namespace Terrasoft.Configuration
{
	using System.Collections.Generic;
	using Newtonsoft.Json.Linq;

	/// <summary>
	/// Webhook body parser
	/// </summary>
	public interface IWebhookParser
	{

		#region Properties: Public

		/// <summary>
		/// Supported types for parser
		/// </summary>
		IEnumerable<string> SupportedTypes { get; }

		#endregion

		#region Methods: Public

		/// <summary>
		/// Parse webhook body
		/// </summary>
		/// <param name="webhookBody">webhook body</param>
		/// <returns>JsonDocument</returns>
		bool TryGetObject(string webhookBody, out JObject jsonDocument);

		#endregion

	}
}
