namespace Terrasoft.Configuration
{
	using System;
	using Terrasoft.Core.Factories;

	#region Class: DateTimeTypeWebhookHandler

	/// <summary>
	/// Webhook handler for <see cref="DateTime"/> type.
	/// </summary>
	/// <seealso cref="Terrasoft.Configuration.ICustomTypeWebhookHandler" />
	[DefaultBinding(typeof(ICustomTypeWebhookHandler), Name = "DateTimeTypeWebhookHandler")]
	public class DateTimeTypeWebhookHandler : ICustomTypeWebhookHandler
	{
		#region Properties: Public

		/// <summary>
		/// Provider name.
		/// </summary>
		public string ProviderName => WebhookSourceConstants.Any;

		/// <summary>
		/// Handling type.
		/// </summary>
		public Type Type => typeof(DateTime);

		#endregion

		#region Methods: Public

		/// <summary>
		/// Handling webhook parameter value.
		/// </summary>
		/// <param name="input">String value of webhook parameter for Handling.</param>
		/// <returns></returns>
		public object Handle(string input) {
			if (DateTime.TryParse(input, out DateTime result)) {
				return result;
			}
			return null;
		}

		#endregion

	}

	#endregion

}

