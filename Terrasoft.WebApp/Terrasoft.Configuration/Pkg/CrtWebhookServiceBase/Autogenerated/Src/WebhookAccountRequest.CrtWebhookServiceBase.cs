namespace Terrasoft.Configuration.LandingiIntegration
{
	using System;

	#region Class: WebhookAccountRequest

	/// <summary>
	/// Represents the webhook account request.
	/// </summary>
	public class WebhookAccountRequest
	{

		#region Properties: Public

		/// <summary>
		/// Gets or sets the API key.
		/// </summary>
		public string ApiKey { get; set; }

		/// <summary>
		/// Gets or sets the created by.
		/// </summary>
		public string CreatedBy { get; set; }

		/// <summary>
		/// Gets or sets the created on.
		/// </summary>
		public DateTime CreatedOn { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this instance is active.
		/// </summary>
		public bool IsActive { get; set; }

		/// <summary>
		/// Gets or sets the rate limit.
		/// </summary>
		public int RateLimit { get; set; }

		/// <summary>
		/// Gets or sets the webhook source.
		/// </summary>
		public string WebhookSource { get; set; }

		/// <summary>
		/// Gets or sets the identity client identifier.
		/// </summary>
		public string IdentityClientId { get; set; }

		/// <summary>
		/// Gets or sets the creatio client identifier.
		/// </summary>
		public string CreatioClientId { get; set; }

		/// <summary>
		/// Gets or sets the creatio client secret.
		/// </summary>
		public string CreatioClientSecret { get; set; }

		/// <summary>
		/// Gets or sets the creatio identity server URL.
		/// </summary>
		public string CreatioIdentityServerUrl { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this account supports batch processing.
		/// </summary>
		public bool BatchingEnabled { get; set; }

		#endregion

	}

	#endregion

}

