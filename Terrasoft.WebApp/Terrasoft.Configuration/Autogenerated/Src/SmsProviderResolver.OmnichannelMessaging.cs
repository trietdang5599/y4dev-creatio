namespace Terrasoft.Configuration.Omnichannel.Messaging
{
	using OmnichannelProviders.Domain.Entities;
	using OmnichannelProviders.ProviderResolver;
	using System;
	using Terrasoft.Core;
	using Terrasoft.Core.Factories;

	#region Class: SmsProviderResolver

	/// <summary>
	/// SMS (Twilio) channel provider resolver implementation.
	/// </summary>
	[DefaultBinding(typeof(ChannelProviderResolver), Name = "SmsTwilio")]
	public class SmsProviderResolver: IntegrationChannelProviderResolver
	{

		#region Properties: Protected

		/// <inheritdoc cref="ChannelProviderResolver.ProviderName"/>
		protected override string ProviderName => ChannelType.SmsTwilio.ToString();

		/// <inheritdoc cref="IntegrationChannelProviderResolver.MessageRouterUrl"/>
		// SMS shares the Twilio backend with WhatsApp - same router endpoint is used
		// for both registration and deregistration of channels.
		protected override string MessageRouterUrl => "/api/whatsapp/messenger/";

		#endregion

		#region Properties: Public

		/// <inheritdoc cref="ChannelProviderResolver.ProviderId"/>
		public override Guid ProviderId => Guid.Parse("21AF0484-EEE0-4F61-8822-F8789838BA66");

		#endregion

		#region Constructor: Public

		/// <summary>
		/// .ctor.
		/// </summary>
		/// <param name="uc"><see cref="UserConnection"/> intance.</param>
		public SmsProviderResolver(UserConnection uc) : base(uc) { }

		#endregion

	}

	#endregion
}

