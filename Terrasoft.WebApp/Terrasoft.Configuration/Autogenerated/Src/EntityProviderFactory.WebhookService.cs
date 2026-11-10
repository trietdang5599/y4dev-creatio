namespace Terrasoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Terrasoft.Core;
	using Terrasoft.Core.Factories;

	#region Class: EntityProviderFactory

	/// <summary>
	/// The factory of entity providers.
	/// </summary>
	public class EntityProviderFactory
	{

		private IWebhookEntityProvider _defaultProvider;
		private IEnumerable<IWebhookEntityProvider> _providers;

		#region Constructors: Public

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="userConnection">The user connection.</param>
		public EntityProviderFactory(UserConnection userConnection) {
			_defaultProvider = new WebhookEntityProvider(userConnection);
		}

		#endregion

		#region Properties: Private

		private IEnumerable<IWebhookEntityProvider> Providers {
			get {
				if (_providers != null && _providers.Any()) {
					return _providers;
				}
				return _providers = ClassFactory.GetAll<IWebhookEntityProvider>();
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Gets the webhook entity provider.
		/// </summary>
		/// <param name="entityName">Name of the entity.</param>
		/// <param name="useDefaultProvider">Use default provider if don`t found provider by entity name</param>
		/// <param name="errorMessage">The error message.</param>
		/// <param name="webhookEntityProvider">Result</param>
		/// <returns>The specified entity provider.</returns>
		public bool TryGetWebhookEntityProvider(string entityName, out IWebhookEntityProvider webhookEntityProvider,
			out string errorMessage, bool useDefaultProvider) {
			errorMessage = null;
			IWebhookEntityProvider provider = Providers.FirstOrDefault(x =>
				x.EntityNames.Contains(entityName, StringComparer.InvariantCultureIgnoreCase));
			if (provider != null) {
				webhookEntityProvider = provider;
				return true;
			}
			if (useDefaultProvider) {
				webhookEntityProvider = _defaultProvider;
				return true;
			}
			webhookEntityProvider = null;
			errorMessage = $"Can't resolve the entity provider for the specified entityName: {entityName}.";
			return false;
		}

		#endregion

	}

	#endregion

}

