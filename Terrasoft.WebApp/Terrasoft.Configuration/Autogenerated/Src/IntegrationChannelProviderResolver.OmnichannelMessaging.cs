namespace Terrasoft.Configuration.Omnichannel.Messaging
{
	using OmnichannelProviders.Domain.Entities;
	using OmnichannelProviders.ProviderResolver;
	using System;
	using Terrasoft.Configuration.BpmonlineCloudIntegration;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.Factories;

	#region Class: IntegrationChannelProviderResolver

	/// <summary>
	/// Base implementation for channel provider resolver and base contract for integration channel provider resolver.
	/// </summary>
	public abstract class IntegrationChannelProviderResolver: ChannelProviderResolver
	{

		#region Fields: Private

		private IdentityServerProvider _identityServerProvider;

		#endregion

		#region Properties: Protected

		private string _omnichannelMessagingIntegrationApiUrl;

		/// <summary>
		/// Omnichannel messaging integration API URL <see cref="SysSettings"/> value.
		/// </summary>
		protected virtual string OmnichannelMessagingIntegrationApiUrl {
			get {
				return string.IsNullOrEmpty(_omnichannelMessagingIntegrationApiUrl)
					? (_omnichannelMessagingIntegrationApiUrl = SysSettings.GetValue(UserConnection,
						"OmnichannelMessagingIntegrationApiUrl", GlobalAppSettings.OmnichannelMessagingIntegrationApiUrl))
					: _omnichannelMessagingIntegrationApiUrl;
			}
		}

		/// <summary>
		/// Base part of integration message router URL.
		/// </summary>
		protected abstract string MessageRouterUrl { get; }

		/// <summary>
		/// API part of integration message router URL.
		/// </summary>
		protected virtual string MessageRouterUrlPath => "channel/remove";

		/// <summary>
		/// Scope of access token.
		/// </summary>
		protected virtual string Scope => "social_leadgen_api";

		/// <inheritdoc cref="ChannelProviderResolver.ProviderName"/>
		protected override string ProviderName { get; }

		#endregion

		#region Properties: Public

		/// <inheritdoc cref="ChannelProviderResolver.ProviderId"/>
		public override Guid ProviderId { get; }

		#endregion

		#region Constructor: Protected

		/// <summary>
		/// .ctor.
		/// </summary>
		/// <param name="uc"><see cref="UserConnection"/> intance.</param>
		protected IntegrationChannelProviderResolver(UserConnection uc): base(uc) { }

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Get full omnichannel messaging integration API URL.
		/// </summary>
		/// <param name="path">Omnichannel messaging integration API path.</param>
		/// <returns>Full omnichannel messaging integration API URL.</returns>
		protected virtual string GetMessageRouterUrl(string path) {
			if (string.IsNullOrEmpty(path)) {
				return string.Empty;
			}
			string url = OmnichannelMessagingIntegrationApiUrl;
			return string.Concat(url.TrimEnd('/'), MessageRouterUrl, path);
		}

		#endregion

		#region Methods: Private

		private IdentityServerProvider GetIdentityServerProvider(UserConnection uc) {
			return _identityServerProvider = _identityServerProvider
				?? ClassFactory.Get<IdentityServerProvider>(new ConstructorArgument("userConnection", uc));
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Gets <see cref="MessengerDeletionData"/> data.
		/// </summary>
		/// <param name="channelId">Channel identifier.</param>
		/// <returns><see cref="MessengerDeletionData"/> data.</returns>
		public override MessengerDeletionData GetDeletionData(string channelId) {
			var data = base.GetDeletionData(channelId);
			data.IdentityToken = GetIdentityServerProvider(UserConnection).GetAccessToken(Scope);
			data.MessageRouterUrl = GetMessageRouterUrl(MessageRouterUrlPath);
			return data;
		}

		#endregion

	}

	#endregion

}

