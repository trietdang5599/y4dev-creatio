namespace Terrasoft.Configuration.LandingiIntegration
{
	using System.Collections.Generic;

	/// <summary>
	/// Represents the response from webhook account service endpoint.
	/// </summary>
	public class WebhookSubAccountsResponse : BaseAccountResponse
	{
		/// <summary>
		/// Gets or sets the list of webhook service associated subaccounts.
		/// </summary>
		public List<WebhookAccountResponse> SubAccounts { get; set; }
	}

}

