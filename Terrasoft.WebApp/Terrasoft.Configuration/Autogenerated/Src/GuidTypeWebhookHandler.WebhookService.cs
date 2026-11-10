namespace Terrasoft.Configuration
{
	using System;
	using Terrasoft.Core.Factories;

	#region Class: GuidTypeWebhookHandler

	/// <summary>
	/// Webhook Handler for guid type
	/// </summary>
	/// <seealso cref="Terrasoft.Configuration.ICustomTypeWebhookHandler" />
	[DefaultBinding(typeof(ICustomTypeWebhookHandler), Name = "GuidTypeWebhookHandler")]
	public class GuidTypeWebhookHandler : ICustomTypeWebhookHandler
	{

		#region Properties: Public

		/// <summary>
		/// Provider name.
		/// </summary>
		public string ProviderName => WebhookSourceConstants.Any;

		/// <summary>
		/// Handling type.
		/// </summary>
		public Type Type => typeof(Guid);

		#endregion

		#region Methods: Public

		/// <summary>
		/// Handling webhook parameter value.
		/// </summary>
		/// <param name="input">string value of webhook parameter for Handling.</param>
		/// <returns></returns>
		public object Handle(string input) {
			if (Guid.TryParse(input, out Guid result)) {
				return result;
			}
			return null;
		}

		#endregion

	}

	#endregion

}

