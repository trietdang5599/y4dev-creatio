namespace Terrasoft.Configuration.LandingiIntegration
{
	using System;

	#region Class: BaseWebhookAccountResponse

	/// <summary>
	/// Cloud response DTO with information about account.
	/// </summary>
	public class BaseWebhookAccountResponse : BaseAccountResponse
	{

		#region Properties: Public

		/// <summary>
		/// The api key.
		/// </summary>
		public string ApiKey { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether HMAC is enabled.
		/// </summary>
		public bool HmacEnabled { get; set; }

		/// <summary>
		/// Gets or sets the HMAC secret key.
		/// </summary>
		public string HmacSecretKey { get; set; }

		#endregion

	}

	#endregion

}

