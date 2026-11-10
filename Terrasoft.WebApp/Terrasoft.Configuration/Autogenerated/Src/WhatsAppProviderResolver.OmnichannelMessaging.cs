namespace Terrasoft.Configuration.Omnichannel.Messaging
{
	using OmnichannelProviders.Domain.Entities;
	using OmnichannelProviders.ProviderResolver;
	using System;
	using Terrasoft.Core;
	using Terrasoft.Core.Factories;

	#region Class: WhatsAppProviderResolver

	/// <summary>
	/// WhatsApp channel provider resolver implementation.
	/// </summary>
	[DefaultBinding(typeof(ChannelProviderResolver), Name = "WhatsApp")]
	public class WhatsAppProviderResolver: IntegrationChannelProviderResolver
	{

		#region Properties: Protected

		/// <inheritdoc cref="ChannelProviderResolver.ProviderName"/>
		protected override string ProviderName => ChannelType.WhatsApp.ToString();

		/// <inheritdoc cref="IntegrationChannelProviderResolver.MessageRouterUrl"/>
		protected override string MessageRouterUrl => "/api/whatsapp/messenger/";

		#endregion

		#region Properties: Public

		/// <inheritdoc cref="ChannelProviderResolver.ProviderId"/>
		public override Guid ProviderId => Guid.Parse("1398DC73-B428-4E21-B97A-C1BB6B4BC621");

		#endregion

		#region Constructor: Public

		/// <summary>
		/// .ctor.
		/// </summary>
		/// <param name="uc"><see cref="UserConnection"/> intance.</param>
		public WhatsAppProviderResolver(UserConnection uc) : base(uc) { }

		#endregion

	}

	#endregion
}

