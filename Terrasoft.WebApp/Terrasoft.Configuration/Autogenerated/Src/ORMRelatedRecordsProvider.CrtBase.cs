namespace Terrasoft.Configuration.RelatedRecords
{
	using System.Collections.Generic;
	using System.Linq;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;

	#region Interface: IORMRelatedRecordsProvider

	/// <summary>
	/// Interface of ORM related records provider.
	/// </summary>
	public interface IORMRelatedRecordsProvider : IRelatedRecordsProvider
	{ }

	#endregion

	#region Class: ORMRelatedRecordsProvider

	/// <summary>
	/// ORM related records provider.
	/// </summary>
	[DefaultBinding(typeof(IORMRelatedRecordsProvider), Name = nameof(ORMRelatedRecordsProvider))]
	public class ORMRelatedRecordsProvider : BaseRelatedRecordsProvider, IORMRelatedRecordsProvider
	{

		#region Constructors: Public

		public ORMRelatedRecordsProvider(UserConnection userConnection)
			: base(userConnection) { }

		#endregion

		#region Methods: Private

		private void SetDefColumnValuesToInsert(Insert insert) {
			insert.Set("CreatedById", Column.Parameter(UserConnection.CurrentUser.ContactId));
			insert.Set("ModifiedById", Column.Parameter(UserConnection.CurrentUser.ContactId));
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Creates and saves related in main records by <see cref="Insert"/>.
		/// </summary>
		/// <param name="relatedInMainRecordSchemaName">Schema name of related in main record object.</param>
		/// <param name="mainRecord">Main record <see cref="Entity"/>.</param>
		/// <param name="relatedRecords">Collection of related record <see cref="Entity"/>.</param>
		/// <param name="providerData"><see cref="AddRelatedRecordsProviderData"/>.</param>
		/// <returns>Boolean value that indicates successfully saved record.</returns>
		protected virtual bool CreateAndSaveRelatedInMainRecords(string relatedInMainRecordSchemaName,
			Entity mainRecord, IEnumerable<Entity> relatedRecords, AddRelatedRecordsProviderData providerData) {
			return CreateRelatedInMainRecordsInsert(relatedInMainRecordSchemaName, mainRecord, relatedRecords,
					providerData).Execute() >
				0;
		}

		/// <summary>
		/// Creates <see cref="Insert"/> for related in main records.
		/// </summary>
		/// <param name="relatedInMainRecordSchemaName">Schema name of related in main record object.</param>
		/// <param name="mainRecord">Main record <see cref="Entity"/>.</param>
		/// <param name="relatedRecords">Collection of related record <see cref="Entity"/>.</param>
		/// <param name="providerData"><see cref="AddRelatedRecordsProviderData"/>.</param>
		/// <returns><see cref="Insert"/> of related in main records.</returns>
		protected virtual Insert CreateRelatedInMainRecordsInsert(string relatedInMainRecordSchemaName,
			Entity mainRecord, IEnumerable<Entity> relatedRecords, AddRelatedRecordsProviderData providerData) {
			var relatedInMainRecordsInsert = new Insert(UserConnection).Into(relatedInMainRecordSchemaName);
			relatedRecords.ForEach(relatedRecord => {
				relatedInMainRecordsInsert.Values();
				SetDefColumnValuesToInsert(relatedInMainRecordsInsert);
				relatedInMainRecordsInsert.Set(GetColumnNameForLookupField(providerData.MainRecordColumnName),
					Column.Parameter(mainRecord.PrimaryColumnValue));
				relatedInMainRecordsInsert.Set(GetColumnNameForLookupField(providerData.RelatedRecordColumnName),
					Column.Parameter(relatedRecord.PrimaryColumnValue));
				providerData.DefaultValues?.ForEach(defaultValue =>
					relatedInMainRecordsInsert.Set(defaultValue.Key, Column.Parameter(defaultValue.Value)));
			});
			return relatedInMainRecordsInsert;
		}

		/// <summary>
		/// Creates <see cref="Select"/> for remove processed records count.
		/// </summary>
		/// <param name="providerData"><see cref="RemoveRelatedRecordsProviderData"/>.</param>
		/// <returns><see cref="Select"/> of processed records count.</returns>
		protected virtual Select
			CreateRemoveProcessedRecordsCountSelect(RemoveRelatedRecordsProviderData providerData) {
			var subSelect = new Select(UserConnection).From(providerData.RelatedInMainRecordsSchemaName);
			subSelect.Column(GetColumnNameForLookupField(providerData.RelatedRecordColumnName));
			subSelect.Where(GetColumnNameForLookupField(providerData.MainRecordColumnName))
				.In(GetMainRecordsEsq(providerData).GetSelectQuery(UserConnection))
				.And(GetColumnNameForLookupField(providerData.RelatedRecordColumnName))
				.In(GetRelatedRecordsEsq(providerData).GetSelectQuery(UserConnection));
			subSelect.GroupBy(GetColumnNameForLookupField(providerData.RelatedRecordColumnName));
			return new Select(UserConnection).From(subSelect).As("t").Column(Func.Count(Column.Const(1)));
		}

		/// <summary>
		/// Creates <see cref="Delete"/> for related in main records.
		/// </summary>
		/// <param name="providerData"><see cref="RemoveRelatedRecordsProviderData"/>.</param>
		/// <returns><see cref="Delete"/> of related in main records.</returns>
		protected virtual Delete CreateRelatedInMainRecordsDelete(RemoveRelatedRecordsProviderData providerData) {
			var delete = new Delete(UserConnection).From(providerData.RelatedInMainRecordsSchemaName);
			delete.Where(GetColumnNameForLookupField(providerData.MainRecordColumnName))
				.In(GetMainRecordsEsq(providerData).GetSelectQuery(UserConnection))
				.And(GetColumnNameForLookupField(providerData.RelatedRecordColumnName))
				.In(GetRelatedRecordsEsq(providerData).GetSelectQuery(UserConnection));
			return delete;
		}

		/// <summary>
		/// Removes related in main records.
		/// </summary>
		/// <param name="relatedInMainRecordsDelete">Delete of related in main records.</param>
		/// <returns>Boolean value that indicates successfully delete record.</returns>
		protected virtual bool RemoveRelatedInMainRecords(Delete relatedInMainRecordsDelete) {
			return relatedInMainRecordsDelete.Execute() > 0;
		}

		/// <inheritdoc />
		protected override int ProcessAddRelatedInMainRecords(AddRelatedRecordsProviderData providerData) {
			var mainRecordsCollection = GetMainRecordsEsq(providerData).GetEntityCollection(UserConnection).ToList();
			var relatedRecordsCollection =
				GetRelatedRecordsEsq(providerData).GetEntityCollection(UserConnection).ToList();
			mainRecordsCollection.ForEach(mainRecord => {
				var notExistRelatedRecordsCollection =
					GetNotExistRelatedRecordsEntities(relatedRecordsCollection, mainRecord, providerData);
				CollectionInParallel(notExistRelatedRecordsCollection, partOfRelatedRecordsCollection => {
					SafeExecuteAction(false,
						() => CreateAndSaveRelatedInMainRecords(providerData.RelatedInMainRecordsSchemaName, mainRecord,
							partOfRelatedRecordsCollection, providerData));
				});
			});
			return relatedRecordsCollection.Count;
		}

		/// <inheritdoc />
		protected override int ProcessRemoveRelatedInMainRecords(RemoveRelatedRecordsProviderData providerData) {
			var processedRecordsCountSelect = CreateRemoveProcessedRecordsCountSelect(providerData);
			var relatedInMainRecordsDelete = CreateRelatedInMainRecordsDelete(providerData);
			var processedRecordsCount = SafeExecuteAction(-1, () => processedRecordsCountSelect.ExecuteScalar<int>());
			SafeExecuteAction(false, () => RemoveRelatedInMainRecords(relatedInMainRecordsDelete));
			return processedRecordsCount;
		}

		#endregion

	}

	#endregion

}

