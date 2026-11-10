namespace Terrasoft.Configuration.LandingiIntegration
{
	using System;

	/// <summary>
	/// Represents the webhook account response.
	/// </summary>
	public class WebhookAccountResponse : BaseWebhookAccountResponse
	{
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
	}
}

