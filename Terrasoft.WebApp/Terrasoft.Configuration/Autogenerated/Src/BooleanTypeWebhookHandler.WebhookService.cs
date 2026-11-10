namespace Terrasoft.Configuration
{
	using System;
	using Terrasoft.Core.Factories;

	#region Class: BooleanTypeWebhookHandler

	/// <summary>
	/// Webhook Handler for <see cref="bool"/> type
	/// </summary>
	/// <seealso cref="Terrasoft.Configuration.ICustomTypeWebhookHandler" />
	[DefaultBinding(typeof(ICustomTypeWebhookHandler), Name = "BooleanTypeWebhookHandler")]
	public class BooleanTypeWebhookHandler : ICustomTypeWebhookHandler
	{

		#region Properties: Public

		/// <summary>
		/// Provider name.
		/// </summary>
		public string ProviderName => WebhookSourceConstants.Any;

		/// <summary>
		/// Handling type.
		/// </summary>
		public Type Type => typeof(bool);

		#endregion

		#region Methods: Public

		/// <summary>
		/// Handling webhook parameter value.
		/// </summary>
		/// <param name="input">string value of webhook parameter for Handling.</param>
		/// <returns></returns>
		public object Handle(string input) {
			if (bool.TryParse(input, out bool result)) {
				return result;
			}
			return null;
		}

		#endregion

	}

	#endregion

}

