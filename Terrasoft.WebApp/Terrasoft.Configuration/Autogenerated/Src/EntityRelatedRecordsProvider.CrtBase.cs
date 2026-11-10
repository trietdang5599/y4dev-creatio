namespace Terrasoft.Configuration.RelatedRecords
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;

	#region Interface: IEntityRelatedRecordsProvider

	/// <summary>
	/// Interface of entity related records provider.
	/// </summary>
	public interface IEntityRelatedRecordsProvider : IRelatedRecordsProvider
	{ }

	#endregion

	#region Class: EntityRelatedRecordsProvider

	/// <summary>
	/// Entity related records provider.
	/// </summary>
	[DefaultBinding(typeof(IEntityRelatedRecordsProvider), Name = nameof(EntityRelatedRecordsProvider))]
	public class EntityRelatedRecordsProvider : BaseRelatedRecordsProvider, IEntityRelatedRecordsProvider
	{

		#region Constructors: Public

		public EntityRelatedRecordsProvider(UserConnection userConnection)
			: base(userConnection) { }

		#endregion

		#region Methods: Private

		private int GetUniqueRecordsCount(IEnumerable<Entity> records, BaseRelatedRecordsProviderData providerData) {
			string relatedRecordColumnName = GetColumnNameForLookupField(providerData.RelatedRecordColumnName);
			return records.GroupBy(record => record.GetTypedColumnValue<Guid>(relatedRecordColumnName))
				.Select(group => group.First()).Count();
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Creates and saves <see cref="Entity"/> of related in main record.
		/// </summary>
		/// <param name="relatedInMainRecordSchema"><see cref="EntitySchema"/> of related in main record object.</param>
		/// <param name="mainRecord">Main record <see cref="Entity"/>.</param>
		/// <param name="relatedRecord">Related record <see cref="Entity"/>.</param>
		/// <param name="providerData"><see cref="AddRelatedRecordsProviderData"/>.</param>
		/// <returns>Boolean value that indicates successfully saved entity.</returns>
		protected virtual bool CreateAndSaveRelatedInMainRecord(EntitySchema relatedInMainRecordSchema,
			Entity mainRecord, Entity relatedRecord, AddRelatedRecordsProviderData providerData) {
			return GetRelatedInMainRecordEntityForCreate(relatedInMainRecordSchema, mainRecord, relatedRecord,
				providerData).Save();
		}

		/// <summary>
		/// Gets <see cref="Entity"/> of related in main records for create action.
		/// </summary>
		/// <param name="relatedInMainRecordSchema"><see cref="EntitySchema"/> of related in main record object.</param>
		/// <param name="mainRecord">Main record <see cref="Entity"/>.</param>
		/// <param name="relatedRecord">Related record <see cref="Entity"/>.</param>
		/// <param name="providerData"><see cref="AddRelatedRecordsProviderData"/>.</param>
		/// <returns><see cref="Entity"/> of related in main record.</returns>
		protected virtual Entity GetRelatedInMainRecordEntityForCreate(EntitySchema relatedInMainRecordSchema,
			Entity mainRecord, Entity relatedRecord, AddRelatedRecordsProviderData providerData) {
			var relatedInMainRecordEntity = relatedInMainRecordSchema.CreateEntity(UserConnection);
			relatedInMainRecordEntity.SetDefColumnValues();
			relatedInMainRecordEntity.SetColumnValue(GetColumnNameForLookupField(providerData.MainRecordColumnName),
				mainRecord.PrimaryColumnValue);
			relatedInMainRecordEntity.SetColumnValue(GetColumnNameForLookupField(providerData.RelatedRecordColumnName),
				relatedRecord.PrimaryColumnValue);
			providerData.DefaultValues?.ForEach(defaultValue =>
				relatedInMainRecordEntity.SetColumnValue(defaultValue.Key, defaultValue.Value));
			return relatedInMainRecordEntity;
		}

		/// <summary>
		/// Removes related in main records.
		/// </summary>
		/// <param name="relatedInMainRecordEntity"><see cref="EntitySchemaQuery"/> of related in main records.</param>
		/// <param name="providerData"><see cref="RemoveRelatedRecordsProviderData"/>.</param>
		/// <returns>Boolean value that indicates successfully delete record.</returns>
		protected virtual bool RemoveRelatedInMainRecord(Entity relatedInMainRecordEntity,
			RemoveRelatedRecordsProviderData providerData) {
			return GetRelatedInMainRecordEntityForRemove(relatedInMainRecordEntity, providerData).Delete();
		}

		/// <summary>
		/// Gets <see cref="Entity"/> of related in main record for remove action.
		/// </summary>
		/// <param name="relatedInMainRecordEntity">Related in main record <see cref="Entity"/>.</param>
		/// <param name="providerData"><see cref="RemoveRelatedRecordsProviderData"/>.</param>
		/// <returns><see cref="Entity"/> of related in main record.</returns>
		protected virtual Entity GetRelatedInMainRecordEntityForRemove(Entity relatedInMainRecordEntity,
			RemoveRelatedRecordsProviderData providerData) {
			return relatedInMainRecordEntity;
		}

		/// <summary>
		/// Gets <see cref="EntitySchemaQuery"/> for related in main records.
		/// </summary>
		/// <param name="providerData"><see cref="RemoveRelatedRecordsProviderData"/>.</param>
		/// <returns><see cref="EntitySchemaQuery"/> of related in main records.</returns>
		protected virtual EntitySchemaQuery GetRelatedInMainRecordsEsq(RemoveRelatedRecordsProviderData providerData) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager,
				providerData.RelatedInMainRecordsSchemaName);
			esq.AddAllSchemaColumns();
			SetEntitySchemaQueryDefaultSettings(esq);
			esq.Filters.LogicalOperation = LogicalOperationStrict.And;
			esq.Filters.Add(esq.CreateFilter(FilterComparisonType.Equal, providerData.MainRecordColumnName,
				GetMainRecordsEsq(providerData)));
			esq.Filters.Add(esq.CreateFilter(FilterComparisonType.Equal, providerData.RelatedRecordColumnName,
				GetRelatedRecordsEsq(providerData)));
			return esq;
		}

		/// <inheritdoc />
		protected override int ProcessAddRelatedInMainRecords(AddRelatedRecordsProviderData providerData) {
			var mainRecordsCollection = GetMainRecordsEsq(providerData).GetEntityCollection(UserConnection).ToList();
			var relatedRecordsCollection =
				GetRelatedRecordsEsq(providerData).GetEntityCollection(UserConnection).ToList();
			var relatedInMainRecordsSchema =
				UserConnection.EntitySchemaManager.GetInstanceByName(providerData.RelatedInMainRecordsSchemaName);
			mainRecordsCollection.ForEach(mainRecord => {
				var notExistRelatedRecordsCollection =
					GetNotExistRelatedRecordsEntities(relatedRecordsCollection, mainRecord, providerData);
				ForeachInParallel(notExistRelatedRecordsCollection, relatedRecord => {
					SafeExecuteAction(false,
						() => CreateAndSaveRelatedInMainRecord(relatedInMainRecordsSchema, mainRecord, relatedRecord,
							providerData));
				});
			});
			return relatedRecordsCollection.Count;
		}

		/// <inheritdoc />
		protected override int ProcessRemoveRelatedInMainRecords(RemoveRelatedRecordsProviderData providerData) {
			var relatedInMainRecordsCollection =
				GetRelatedInMainRecordsEsq(providerData).GetEntityCollection(UserConnection).ToList();
			relatedInMainRecordsCollection.ForEach(relatedInMainRecord => {
				SafeExecuteAction(false, () => RemoveRelatedInMainRecord(relatedInMainRecord, providerData));
			});
			return GetUniqueRecordsCount(relatedInMainRecordsCollection, providerData);
		}

		#endregion

	}

	#endregion

}

