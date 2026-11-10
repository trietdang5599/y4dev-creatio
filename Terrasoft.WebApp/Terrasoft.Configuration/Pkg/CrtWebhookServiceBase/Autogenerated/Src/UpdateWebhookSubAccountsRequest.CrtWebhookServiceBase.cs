namespace Terrasoft.Configuration.LandingiIntegration
{
	using System;

	#region Class: UpdateWebhookSubAccountsRequest

	/// <summary>
	/// Represents the update webhook subaccounts request.
	/// </summary>
	public class UpdateWebhookSubAccountsRequest
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
	}

	#endregion

}

