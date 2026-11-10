namespace Terrasoft.Configuration.LandingiIntegration
{
	using System.Runtime.Serialization;
	using Terrasoft.Nui.ServiceModel.DataContract;

	/// <summary>
	/// Represents the webhook account info response.
	/// </summary>
	[DataContract]
	public class WebhookAccountInfoResponse : BaseResponse
	{
		/// <summary>
		/// Gets or sets the API key.
		/// </summary>
		[DataMember(Name = "apiKey")]
		public string ApiKey { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether HMAC is enabled.
		/// </summary>
		[DataMember(Name = "hmacEnabled")]
		public bool HmacEnabled { get; set; }

		/// <summary>
		/// Gets or sets the HMAC secret key.
		/// </summary>
		[DataMember(Name = "hmacSecretKey")]
		public string HmacSecretKey { get; set; }
	}
}
