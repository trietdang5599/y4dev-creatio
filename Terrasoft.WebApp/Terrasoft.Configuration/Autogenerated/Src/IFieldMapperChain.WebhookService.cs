namespace Terrasoft.Configuration
{
	using System.Collections.Generic;

	/// <summary>
	/// The provider of webhook entity.
	/// </summary>
	public interface IFieldMapperChain
	{

        #region Methods: Public

        /// <summary>
        /// Gets the mapped fields.
        /// </summary>
        /// <param name="webhookFields">The webhook fields.</param>
        /// <param name="webhookSource">The webhook source.</param>
        /// <param name="entityName">Name of the entity.</param>
        /// <returns>The mapped fields.</returns>
		IEnumerable<WebhookColumnMap> GetMappedFields(IEnumerable<string> webhookFields, string webhookSource, string entityName);

		#endregion

	}
}

