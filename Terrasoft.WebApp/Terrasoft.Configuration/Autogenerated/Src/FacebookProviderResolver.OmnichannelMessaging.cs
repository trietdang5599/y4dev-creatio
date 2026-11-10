namespace Terrasoft.Configuration.Omnichannel.Messaging
{
	using OmnichannelProviders.Domain.Entities;
	using OmnichannelProviders.ProviderResolver;
	using System;
	using Terrasoft.Core;
	using Terrasoft.Core.Factories;

	#region Class: FacebookProviderResolver

	/// <summary>
	/// Facebook channel provider resolver implementation.
	/// </summary>
	[DefaultBinding(typeof(ChannelProviderResolver), Name = "Facebook")]
	public class FacebookProviderResolver: IntegrationChannelProviderResolver
	{

		#region Properties: Protected

		/// <inheritdoc cref="ChannelProviderResolver.ProviderName"/>
		protected override string ProviderName => ChannelType.Facebook.ToString();

		/// <inheritdoc cref="IntegrationChannelProviderResolver.MessageRouterUrl"/>
		protected override string MessageRouterUrl => "/api/facebook/messenger/";

		#endregion

		#region Properties: Public

		/// <inheritdoc cref="ChannelProviderResolver.ProviderId"/>
		public override Guid ProviderId => Guid.Parse("50491C6C-D82B-4B86-B38C-99262D11A5AC");

		#endregion

		#region Constructor: Public

		/// <summary>
		/// .ctor.
		/// </summary>
		/// <param name="uc"><see cref="UserConnection"/> intance.</param>
		public FacebookProviderResolver(UserConnection uc) : base(uc) { }

		#endregion

	}

	#endregion

}

