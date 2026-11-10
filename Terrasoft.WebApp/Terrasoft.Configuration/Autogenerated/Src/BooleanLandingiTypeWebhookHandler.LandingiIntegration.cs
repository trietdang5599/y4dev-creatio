namespace Terrasoft.Configuration
{
	using System;
	using Terrasoft.Core.Factories;

	#region Class: ${Name}

	/// <summary>
	/// Webhook handler for Boolean type from Landingi.
	/// </summary>
	/// <seealso cref="Terrasoft.Configuration.ICustomTypeWebhookHandler" />
	[DefaultBinding(typeof(ICustomTypeWebhookHandler), Name = "BooleanLandingiTypeWebhookHandler")]
	public class BooleanLandingiTypeWebhookHandler : ICustomTypeWebhookHandler
	{

		#region Properties: Public

		/// <summary>
		/// Provider name.
		/// </summary>
		public string ProviderName => WebhookSourceConstants.Landingi;

		/// <summary>
		/// Handling type.
		/// </summary>
		public Type Type => typeof(bool);

		#endregion

		#region Methods: Public

		/// <summary>
		/// Handling webhook parameter value.
		/// </summary>
		/// <param name="input">String value of webhook parameter for Handling.</param>
		/// <returns>Parsed value</returns>
		public object Handle(string input) {
			input = input.ToLower();
			if (bool.TryParse(input, out bool result)) {
				return result;
			}
			switch (input) {
				case "on":
					return true;
				case "off":
					return false;
				default:
					throw new Exception($"{input} invalid value.");
			}
		}

		#endregion

	}

	#endregion

}

