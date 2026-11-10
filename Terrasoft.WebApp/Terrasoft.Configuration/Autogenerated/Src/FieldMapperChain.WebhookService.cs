namespace Terrasoft.Configuration
{
	using System.Collections.Generic;
	using System.Linq;

	#region Class: FieldMapperChain

	/// <inheritdoc cref="IFieldMapperChain"/>
	public class FieldMapperChain : IFieldMapperChain
	{

		#region Fields: Private

		private IFieldMapperFactory _fieldMapperFactory;

		#endregion

		#region Properties: Public

		/// <summary>
		/// Gets or sets the field mapper factory.
		/// </summary>
		public IFieldMapperFactory FieldMapperFactory {
			get {
				if (_fieldMapperFactory == null) {
					return _fieldMapperFactory = new FieldMapperFactory();
				}
				return _fieldMapperFactory;
			}
			set => _fieldMapperFactory = value;
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc cref="IFieldMapperChain.GetMappedFields"/>
		public IEnumerable<WebhookColumnMap> GetMappedFields(IEnumerable<string> webhookFields, string webhookSource,
			string entityName) {
			var mappedFields = new List<WebhookColumnMap>();
			IEnumerable<IFieldMapper> mappers = FieldMapperFactory.GetMappers(webhookSource, entityName);
			foreach (IFieldMapper fieldMapper in mappers) {
				fieldMapper.MapFields(webhookFields, mappedFields);
			}
			return mappedFields;
		}

		#endregion

	}

	#endregion

}

