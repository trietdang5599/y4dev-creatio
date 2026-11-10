namespace Terrasoft.Configuration
{
	using System.Collections.Generic;

	#region Class: DefaultFieldMapper

	/// <inheritdoc cref="IFieldMapper"/>
	public class DefaultFieldMapper : IFieldMapper
	{

		#region Methods: Public

		/// <inheritdoc cref="IFieldMapper.MapFields"/>
		public void MapFields(IEnumerable<string> webhookFields, List<WebhookColumnMap> mappedFields) {
			foreach (string webhookField in webhookFields) {
				var mapObject = new WebhookColumnMap {
					EntityColumnName = webhookField,
					WebhookColumnName = webhookField
				};
				mappedFields.Add(mapObject);
			}
		}

		#endregion

	}

	#endregion

}

