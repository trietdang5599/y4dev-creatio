namespace Terrasoft.Configuration.LandingiIntegration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Terrasoft.Core.Factories;

	#region Class: ISubAccountProviderFactory

	/// <summary>
	/// The factory for sub account providers.
	/// </summary>
	public interface ISubAccountProviderFactory
	{
		/// <summary>
		/// Gets the webhook account provider.
		/// </summary>
		/// <param name="webhookSource">The webhook source.</param>
		/// <returns>The webhook account provider</returns>
		IWebhookAccountProvider GetWebhookAccountProvider(string webhookSource, bool canUseDefaultProvider = false);
	}

    #endregion

    #region Class: SubAccountProviderFactory

    /// <inheritdoc cref="ISubAccountProviderFactory"/>
    public class SubAccountProviderFactory : ISubAccountProviderFactory
	{

		#region Fields: Private

		private IEnumerable<IWebhookAccountProvider> _providers;

		#endregion

		#region Properties: Private

		private IEnumerable<IWebhookAccountProvider> Providers {
			get {
				if (_providers != null && _providers.Any()) {
					return _providers;
				}
				return _providers = ClassFactory.GetAll<IWebhookAccountProvider>();
			}
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc cref="ISubAccountProviderFactory.GetWebhookAccountProvider"/>
		public IWebhookAccountProvider GetWebhookAccountProvider(string webhookSource, bool canUseDefaultProvider = false) {
			IWebhookAccountProvider provider = Providers.FirstOrDefault(x => x.WebhookSources.Contains(webhookSource));
			if (provider != null) {
				return provider;
			}
			if(canUseDefaultProvider) {
				return ClassFactory.Get(typeof(WebhookAccountProvider)) as IWebhookAccountProvider;
			}
			var errorMessage = $"Sub-account provider with source: {webhookSource} not found.";
			throw new Exception(errorMessage);
		}

		#endregion

	}

	#endregion
}

