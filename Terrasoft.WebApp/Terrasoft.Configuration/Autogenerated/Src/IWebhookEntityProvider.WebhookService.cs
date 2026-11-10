namespace Terrasoft.Configuration
{
	using System.Collections.Generic;
	using Terrasoft.Core.Entities;

	/// <summary>
	/// The provider of webhook entity.
	/// </summary>
	public interface IWebhookEntityProvider
	{

		#region Properties: Public

		/// <summary>
		/// List of entities the provider works with.
		/// </summary>
		IEnumerable<string> EntityNames { get; }

		#endregion

		#region Methods: Public

		/// <summary>
		/// Gets the entity.
		/// </summary>
		/// <param name="webhook">The webhook.</param>
		/// <returns>The specified entity.</returns>
		Entity GetEntity(WebhookDescription webhook);

		#endregion

	}
}
