namespace Terrasoft.Configuration.LandingiIntegration
{
	using System.Runtime.Serialization;
	using Terrasoft.Nui.ServiceModel.DataContract;

    #region Class: WebhookApiKeyResponse

    /// <summary>
    /// Response class for <see cref="WebhookApiKeyResponse"/> and inherited classes.
    /// </summary>
	[DataContract]
    public class WebhookApiKeyResponse : BaseResponse
    {

        #region Properties: Public

        /// <summary>
        /// Gets or sets the API key.
        /// </summary>
        [DataMember(Name = "apiKey")]
        public string ApiKey { get; set; }

		#endregion

	}

	#endregion
}

