namespace Terrasoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;

	#region Interface: IEntityPageMetadataProvider

	/// <summary>
	/// Provides metadata-related helpers for entity pages.
	/// </summary>
	public interface IEntityPageMetadataProvider
	{

		#region Methods: Public

		/// <summary>
		/// Loads display values for the specified record identifiers from the given reference schema.
		/// </summary>
		/// <param name="userConnection">
		/// The current <see cref="UserConnection"/> used to access the database and schema metadata.
		/// </param>
		/// <param name="referenceSchema">
		/// The reference <see cref="EntitySchema"/> to query (primary key and primary display column are used).
		/// </param>
		/// <param name="typeIds">
		/// The record identifiers to load display values for.
		/// </param>
		/// <returns>
		/// A dictionary that maps each record identifier to its primary display value.
		/// </returns>
		IDictionary<Guid, string> LoadSchemaDisplayValues(UserConnection userConnection, EntitySchema referenceSchema,
			Guid[] typeIds);

		#endregion

	}

	#endregion


	#region Class: EntityPageMetadataProvider

	/// <summary>
	/// Default implementation of <see cref="IEntityPageMetadataProvider"/>.
	/// </summary>
	public sealed class EntityPageMetadataProvider : IEntityPageMetadataProvider
	{

		#region Methods: Public

		/// <inheritdoc/>
		public IDictionary<Guid, string> LoadSchemaDisplayValues(UserConnection userConnection,
				EntitySchema referenceSchema, Guid[] typeIds) {
			var records = new Dictionary<Guid, string>();
			string primaryColumnName = referenceSchema.PrimaryColumn.Name;
			string primaryDisplayColumnName = referenceSchema.PrimaryDisplayColumn.Name;
			var esq = new EntitySchemaQuery(referenceSchema) {
				PrimaryQueryColumn = {
					IsAlwaysSelect = true
				}
			};
			EntitySchemaQueryColumn primaryDisplayQueryColumn = esq.AddColumn(primaryDisplayColumnName);
			IEntitySchemaQueryFilterItem filter = esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				primaryColumnName, typeIds.Cast<object>().ToArray());
			esq.Filters.Add(filter);
			EntityCollection entityCollection = esq.GetEntityCollection(userConnection);
			if (entityCollection.Count > 0) {
				foreach (Entity entity in entityCollection) {
					var key = entity.GetTypedColumnValue<Guid>(primaryColumnName);
					var value = entity.GetTypedColumnValue<string>(primaryDisplayQueryColumn.Name);
					records.Add(key, value);
				}
			}
			return records;
		}

		#endregion

	}

	#endregion

}

