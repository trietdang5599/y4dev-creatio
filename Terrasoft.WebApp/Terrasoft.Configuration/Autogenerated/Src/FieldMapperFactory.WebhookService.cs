namespace Terrasoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Terrasoft.Core.Factories;

	#region Interface: IFieldMapperRepository

	/// <summary>
	/// Returns the list of webhook field mappers.
	/// </summary>
	public interface IFieldMapperFactory
	{
		/// <summary>
		/// Gets the mappers.
		/// </summary>
		/// <param name="webhookSource">The webhook source.</param>
		/// <param name="entityName">Name of the entity.</param>
		IEnumerable<IFieldMapper> GetMappers(string webhookSource, string entityName);

	}

	#endregion

	#region Class: FieldMapperRepository

	/// <inheritdoc cref="IFieldMapperFactory"/>
	public class FieldMapperFactory : IFieldMapperFactory
	{

		#region Methods: Private

		private static IEnumerable<IFieldMapper> GetCustomMappers(string webhookSource, string entityName) {
			IEnumerable<IFieldMapper> newCustomMappers = ClassFactory.GetAll<ICustomFieldMapper>()
				.Where(mapper => mapper.WebhookSource.Split('|').ToList().Contains(webhookSource)
					&& string.Equals(mapper.EntityName, entityName, StringComparison.CurrentCultureIgnoreCase));
			return newCustomMappers;
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc cref="IFieldMapperFactory.GetMappers"/>
		public IEnumerable<IFieldMapper> GetMappers(string webhookSource, string entityName) {
			yield return new DefaultFieldMapper();
			yield return new WebhookLookupFieldMapper(entityName);
			IEnumerable<IFieldMapper> customMappers = GetCustomMappers(webhookSource, entityName);
			foreach (IFieldMapper customMapper in customMappers) {
				yield return customMapper;
			}
		}

		#endregion

	}

	#endregion

}

