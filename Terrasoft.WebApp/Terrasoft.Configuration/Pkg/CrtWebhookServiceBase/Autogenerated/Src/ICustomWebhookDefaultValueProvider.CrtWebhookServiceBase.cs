namespace Terrasoft.Configuration
{
	using System.Collections.Generic;
	using Terrasoft.Core.Entities;

	#region Interface: ICustomWebhookDefaultValueProvider

	/// <summary>
	/// Provides logic to set default values for webhook fields.
	/// </summary>
	public interface ICustomWebhookDefaultValueProvider
	{
		/// <summary>
		/// Gets the webhook source.
		/// </summary>
		string WebhookSource { get; }

		/// <summary>
		/// Applies default column values for the specified webhook fields.
		/// </summary>
		/// <param name="entity">Instance of the created <see cref="Entity"/>.</param>
		/// <param name="webhookFieldValues">Webhook field source values.</param>
		void SetDefaultValues(Entity entity, IDictionary<string, object> webhookFieldValues);
	}
	
	#endregion

}

