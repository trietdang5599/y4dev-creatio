namespace Terrasoft.Configuration.RelatedRecords
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading;
	using System.Threading.Tasks;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;

	#region Class: AddRelatedRecordsProviderData

	/// <summary>
	/// Class of related records provider data for adding action.
	/// </summary>
	public class AddRelatedRecordsProviderData : BaseRelatedRecordsProviderData
	{

		#region Properties: Public

		/// <summary>
		/// Collection of default values.
		/// </summary>
		public IDictionary<string, string> DefaultValues { get; set; }

		#endregion

		#region Constructors: Public

		public AddRelatedRecordsProviderData() { }

		public AddRelatedRecordsProviderData(BaseRelatedRecordsProviderData baseData)
			: base(baseData) { }

		#endregion

	}

	#endregion

	#region Class: RemoveRelatedRecordsProviderData

	/// <summary>
	/// Class of related records provider data for removing action.
	/// </summary>
	public class RemoveRelatedRecordsProviderData : BaseRelatedRecordsProviderData
	{

		#region Constructors: Public

		public RemoveRelatedRecordsProviderData() { }

		public RemoveRelatedRecordsProviderData(BaseRelatedRecordsProviderData baseData)
			: base(baseData) { }

		#endregion

	}

	#endregion

	#region Interface

	/// <summary>
	/// Interface of related records provider.
	/// </summary>
	public interface IRelatedRecordsProvider
	{

		#region Methods: Public

		/// <summary>
		/// Adds related records.
		/// </summary>
		/// <param name="providerData"><see cref="AddRelatedRecordsProviderData"/> for adding related records.</param>
		/// <returns>Count of processed records.</returns>
		int AddRelatedRecords(AddRelatedRecordsProviderData providerData);

		/// <summary>
		/// Remove related records.
		/// </summary>
		/// <param name="providerData"><see cref="RemoveRelatedRecordsProviderData"/> for removing related records.</param>
		/// <returns>Count of processed records.</returns>
		int RemoveRelatedRecords(RemoveRelatedRecordsProviderData providerData);

		#endregion

	}

	#endregion

	#region Class: BaseRelatedRecordsProvider

	/// <summary>
	/// Base related records provider.
	/// </summary>
	public abstract class BaseRelatedRecordsProvider : IRelatedRecordsProvider
	{

		#region Properties: Protected

		/// <summary>
		/// User connection.
		/// </summary>
		protected UserConnection UserConnection { get; set; }

		#endregion

		#region Constructors: Public

		public BaseRelatedRecordsProvider(UserConnection userConnection) {
			this.UserConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private void ExecuteActionInParallel(IEnumerable<Entity> collection, Action<IEnumerable<Entity>> action) {
			var chunkSize = 100;
			var maxDegreeOfParallelism = Math.Min(Math.Max(Environment.ProcessorCount / 2, 1), 10);
			var threadSleepTime = 10;
			var parts = collection.SplitOnChunks(chunkSize).ToList();
			Parallel.For(0, parts.Count, new ParallelOptions {
				MaxDegreeOfParallelism = maxDegreeOfParallelism
			}, i => {
				Thread.Sleep(threadSleepTime);
				IEnumerable<Entity> partItems = parts[i];
				action(partItems);
			});
		}

		private Select
			CreateExistRelatedRecordIdsSelect(Entity mainRecord, BaseRelatedRecordsProviderData providerData) {
			var existRelatedRecordIdsSelect =
				new Select(UserConnection).From(providerData.RelatedInMainRecordsSchemaName);
			existRelatedRecordIdsSelect.Distinct()
				.Column(GetColumnNameForLookupField(providerData.RelatedRecordColumnName));
			existRelatedRecordIdsSelect.Where(GetColumnNameForLookupField(providerData.RelatedRecordColumnName))
				.In(GetRelatedRecordsEsq(providerData).GetSelectQuery(UserConnection))
				.And(GetColumnNameForLookupField(providerData.MainRecordColumnName))
				.IsEqual(Column.Parameter(mainRecord.PrimaryColumnValue));
			return existRelatedRecordIdsSelect;
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Executes action for collection in parallel.
		/// </summary>
		/// <param name="collection">Collection of <see cref="Entity"/>.</param>
		/// <param name="action">Action with collection of <see cref="Entity"/> in parameters.</param>
		protected void CollectionInParallel(IEnumerable<Entity> collection, Action<IEnumerable<Entity>> action) {
			ExecuteActionInParallel(collection, action);
		}

		/// <summary>
		/// Executes action for each entity in collection in parallel.
		/// </summary>
		/// <param name="collection">Collection of <see cref="Entity"/>.</param>
		/// <param name="action">Action with <see cref="Entity"/> in parameters.</param>
		protected void ForeachInParallel(IEnumerable<Entity> collection, Action<Entity> action) {
			ExecuteActionInParallel(collection, entities => {
				entities.ForEach(action);
			});
		}

		/// <summary>
		/// Executes action in safe.
		/// </summary>
		/// <param name="catchValue">Default value on exception.</param>
		/// <param name="action">Action with T in parameters.</param>
		/// <typeparam name="T">Return type.</typeparam>
		/// <returns>Result of T type.</returns>
		protected T SafeExecuteAction<T>(T catchValue, Func<T> action) {
			try {
				return action();
			} catch {
				return catchValue;
			}
		}

		/// <summary>
		/// Gets not exist related records entities for main record in related in main records schema.
		/// </summary>
		/// <param name="relatedRecordsCollection">Collection of related records.</param>
		/// <param name="mainRecord">Main record <see cref="Entity"/>.</param>
		/// <param name="providerData"><see cref="BaseRelatedRecordsProviderData"/>.</param>
		protected IEnumerable<Entity> GetNotExistRelatedRecordsEntities(IEnumerable<Entity> relatedRecordsCollection,
			Entity mainRecord, BaseRelatedRecordsProviderData providerData) {
			var existRelatedRecordIdsSelect = CreateExistRelatedRecordIdsSelect(mainRecord, providerData);
			var existRelatedRecordIds = existRelatedRecordIdsSelect.ExecuteEnumerable(dataReader =>
				dataReader.GetColumnValue<Guid>(GetColumnNameForLookupField(providerData.RelatedRecordColumnName)));
			return relatedRecordsCollection.Where(relatedRecord =>
				!existRelatedRecordIds.Contains(relatedRecord.PrimaryColumnValue));
		}

		/// <summary>
		/// Gets column name for lookup field.
		/// </summary>
		/// <param name="originalColumnName">Original column name.</param>
		/// <returns>Column name with ends with Id.</returns>
		protected string GetColumnNameForLookupField(string originalColumnName) {
			if (originalColumnName.EndsWith("Id")) {
				return originalColumnName;
			}
			return $"{originalColumnName}Id";
		}

		/// <summary>
		/// Gets <see cref="EntitySchemaQuery"/> for main records.
		/// </summary>
		/// <param name="providerData"><see cref="BaseRelatedRecordsProviderData"/>.</param>
		/// <returns><see cref="EntitySchemaQuery"/> of main records.</returns>
		protected virtual EntitySchemaQuery GetMainRecordsEsq(BaseRelatedRecordsProviderData providerData) {
			var mainRecordsEsq = new EntitySchemaQuery(providerData.MainRecordsSchemaQuery);
			SetEntitySchemaQueryDefaultSettings(mainRecordsEsq);
			return mainRecordsEsq;
		}

		/// <summary>
		/// Gets <see cref="EntitySchemaQuery"/> for related records.
		/// </summary>
		/// <param name="providerData"><see cref="BaseRelatedRecordsProviderData"/>.</param>
		/// <returns><see cref="EntitySchemaQuery"/> of related records.</returns>
		protected virtual EntitySchemaQuery GetRelatedRecordsEsq(BaseRelatedRecordsProviderData providerData) {
			var relatedRecordsEsq = new EntitySchemaQuery(providerData.RelatedRecordsSchemaQuery);
			SetEntitySchemaQueryDefaultSettings(relatedRecordsEsq);
			return relatedRecordsEsq;
		}

		/// <summary>
		/// Sets default settings to <see cref="EntitySchemaQuery"/>.
		/// </summary>
		/// <param name="esq"><see cref="EntitySchemaQuery"/>.</param>
		protected virtual void SetEntitySchemaQueryDefaultSettings(EntitySchemaQuery esq) {
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.IgnoreDisplayValues = true;
		}

		/// <summary>
		/// Processes add related in main records.
		/// </summary>
		/// <param name="providerData"><see cref="AddRelatedRecordsProviderData"/> for add related in main records.</param>
		/// <returns>Processed records count.</returns>
		protected abstract int ProcessAddRelatedInMainRecords(AddRelatedRecordsProviderData providerData);

		/// <summary>
		/// Processes remove related in main records.
		/// </summary>
		/// <param name="providerData"><see cref="RemoveRelatedRecordsProviderData"/> for remove related in main records.</param>
		/// <returns>Processed records count.</returns>
		protected abstract int ProcessRemoveRelatedInMainRecords(RemoveRelatedRecordsProviderData providerData);

		#endregion

		#region Methods: Public

		/// <inheritdoc />
		public int AddRelatedRecords(AddRelatedRecordsProviderData providerData) {
			return ProcessAddRelatedInMainRecords(providerData);
		}

		/// <inheritdoc />
		public int RemoveRelatedRecords(RemoveRelatedRecordsProviderData providerData) {
			return ProcessRemoveRelatedInMainRecords(providerData);
		}

		#endregion

	}

	#endregion

}

