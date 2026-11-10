namespace Terrasoft.Configuration
{
	using System;

	/// <summary>
	/// Webhook custom type handler.
	/// </summary>
	public interface ICustomTypeWebhookHandler
	{

		#region Properties: Public

		/// <summary>
		/// Provider name.
		/// </summary>
		string ProviderName { get; }

		/// <summary>
		/// Handling type.
		/// </summary>
		Type Type { get; }

		#endregion

		#region Methods: Public

		/// <summary>
		/// Handling webhook parameter value.
		/// </summary>
		/// <param name="input">string value of webhook parameter for Handling.</param>
		/// <returns></returns>
		object Handle(string input);

		#endregion

	}
}
