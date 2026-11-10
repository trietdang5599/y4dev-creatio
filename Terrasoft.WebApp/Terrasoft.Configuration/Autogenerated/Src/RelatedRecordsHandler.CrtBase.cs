namespace Terrasoft.Configuration.RelatedRecords
{
	using System;
	using System.Collections.Generic;
	using Terrasoft.Common;
	using Terrasoft.Common.Json;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.Nui.ServiceModel.DataContract;
	using Terrasoft.Nui.ServiceModel.Extensions;

	#region Interface: IRelatedRecordsHandler

	/// <summary>
	/// Interface of related records handler.
	/// </summary>
	public interface IRelatedRecordsHandler
	{

		#region Methods: Public

		/// <summary>
		/// Adds related records.
		/// </summary>
		/// <param name="handlerData"><see cref="RelatedRecordsHandlerData"/> for adding related records.</param>
		/// <returns><see cref="RelatedRecordsHandlerResult"/> of added related records.</returns>
		RelatedRecordsHandlerResult AddRelatedRecords(RelatedRecordsHandlerData handlerData);

		/// <summary>
		/// Removes related records.
		/// </summary>
		/// <param name="handlerData"><see cref="RelatedRecordsHandlerData"/> for removing related records.</param>
		/// <returns><see cref="RelatedRecordsHandlerResult"/> of removed related records.</returns>
		RelatedRecordsHandlerResult RemoveRelatedRecords(RelatedRecordsHandlerData handlerData);

		#endregion

	}

	#endregion

	#region Class: RelatedRecordsHandler

	/// <summary>
	/// Related records handler.
	/// </summary>
	[DefaultBinding(typeof(IRelatedRecordsHandler), Name = nameof(RelatedRecordsHandler))]
	public class RelatedRecordsHandler : IRelatedRecordsHandler
	{

		#region Properties: Protected

		/// <summary>
		/// User connection.
		/// </summary>
		protected UserConnection UserConnection { get; set; }

		#endregion

		#region Constructors: Public

		public RelatedRecordsHandler(UserConnection userConnection) {
			this.UserConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private RelatedRecordsHandlerResult ProcessRelatedRecordsAction(RelatedRecordsHandlerData handlerData,
			Func<RelatedRecordsManagerData, int> action) {
			try {
				var relatedRecordsManagerData = CreateRelatedRecordsManagerData(handlerData);
				CheckManagerData(relatedRecordsManagerData);
				var processedRecordsCount = action(relatedRecordsManagerData);
				return new RelatedRecordsHandlerResult(processedRecordsCount);
			} catch (Exception e) {
				return new RelatedRecordsHandlerResult(e);
			}
		}

		private int ProcessAddRelatedRecords(RelatedRecordsManagerData managerData) {
			return GetAddRelatedRecordsManager().AddRelatedRecords(managerData);
		}

		private int ProcessRemoveRelatedRecords(RelatedRecordsManagerData managerData) {
			return GetRemoveRelatedRecordsManager().RemoveRelatedRecords(managerData);
		}

		private IRelatedRecordsManager GetAddRelatedRecordsManager() {
			var relatedRecordsProvider = GetAddRelatedRecordsProvider();
			return GetRelatedRecordsManager(relatedRecordsProvider);
		}

		private IRelatedRecordsManager GetRemoveRelatedRecordsManager() {
			var relatedRecordsProvider = GetRemoveRelatedRecordsProvider();
			return GetRelatedRecordsManager(relatedRecordsProvider);
		}

		private IRelatedRecordsProvider GetDefaultRelatedRecordsProvider() {
			return ClassFactory.Get<IEntityRelatedRecordsProvider>(new ConstructorArgument("userConnection",
				UserConnection));
		}

		private IRelatedRecordsManager GetDefaultRelatedRecordsManager(IRelatedRecordsProvider relatedRecordsProvider) {
			return ClassFactory.Get<IRelatedRecordsManager>(new ConstructorArgument("userConnection", UserConnection),
				new ConstructorArgument("relatedRecordsProvider", relatedRecordsProvider));
		}

		private EntitySchemaQuery CreateEntitySchemaQueryBySerializedEsq(string serializedEsq, string argumentName) {
			var selectQuery = CreateSelectQueryFromSerializedEsq(serializedEsq, argumentName);
			return CreateEntitySchemaQueryFromSelectQuery(selectQuery, argumentName);
		}

		private SelectQuery CreateSelectQueryFromSerializedEsq(string serializedEsq, string argumentName) {
			var selectQuery = Json.Deserialize<SelectQuery>(serializedEsq);
			selectQuery.CheckArgumentNull($"Deserialize {argumentName}");
			return selectQuery;
		}

		private EntitySchemaQuery CreateEntitySchemaQueryFromSelectQuery(SelectQuery selectQuery, string argumentName) {
			var esq = selectQuery.BuildEsq(UserConnection);
			esq.CheckArgumentNull($"EntitySchemaQuery {argumentName}");
			return esq;
		}

		private void CheckManagerData(RelatedRecordsManagerData managerData) {
			managerData.MainRecordsSchemaQuery.CheckArgumentNull(nameof(managerData.MainRecordsSchemaQuery));
			managerData.RelatedRecordsSchemaQuery.CheckArgumentNull(nameof(managerData.RelatedRecordsSchemaQuery));
			managerData.RelatedInMainRecordsSchemaName.CheckArgumentNullOrEmpty(
				nameof(managerData.RelatedInMainRecordsSchemaName));
			managerData.MainRecordColumnName.CheckArgumentNullOrEmpty(nameof(managerData.MainRecordColumnName));
			managerData.RelatedRecordColumnName.CheckArgumentNullOrEmpty(nameof(managerData.RelatedRecordColumnName));
			managerData.DefaultValues.CheckArgumentNull(nameof(managerData.DefaultValues));
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Creates related records manager data.
		/// </summary>
		/// <param name="handlerData"><see cref="RelatedRecordsHandlerData"/>.</param>
		/// <returns><see cref="RelatedRecordsManagerData"/> for <see cref="IRelatedRecordsManager"/>.</returns>
		protected virtual RelatedRecordsManagerData CreateRelatedRecordsManagerData(
			RelatedRecordsHandlerData handlerData) {
			return new RelatedRecordsManagerData {
				MainRecordsSchemaQuery = handlerData.MainRecordsSchemaQuery ??
					CreateEntitySchemaQueryBySerializedEsq(handlerData.MainRecordsEsqSerialized,
						nameof(handlerData.MainRecordsEsqSerialized)),
				RelatedRecordsSchemaQuery = handlerData.RelatedRecordsSchemaQuery ??
					CreateEntitySchemaQueryBySerializedEsq(handlerData.RelatedRecordsEsqSerialized,
						nameof(handlerData.RelatedRecordsEsqSerialized)),
				RelatedInMainRecordsSchemaName = handlerData.RelatedInMainRecordsSchemaName,
				MainRecordColumnName = handlerData.MainRecordColumnName,
				RelatedRecordColumnName = handlerData.RelatedRecordColumnName,
				DefaultValues = handlerData.DefaultValues ?? new Dictionary<string, string>()
			};
		}

		/// <summary>
		/// Gets related records provider for adding action.
		/// </summary>
		/// <returns>Interface of <see cref="IRelatedRecordsProvider"/>.</returns>
		protected virtual IRelatedRecordsProvider GetAddRelatedRecordsProvider() {
			return GetDefaultRelatedRecordsProvider();
		}

		/// <summary>
		/// Gets related records provider for removing action.
		/// </summary>
		/// <returns>Instance of <see cref="IRelatedRecordsProvider"/>.</returns>
		protected virtual IRelatedRecordsProvider GetRemoveRelatedRecordsProvider() {
			return GetDefaultRelatedRecordsProvider();
		}

		/// <summary>
		/// Gets related record manager.
		/// </summary>
		/// <param name="relatedRecordsProvider">Instance of <see cref="IRelatedRecordsProvider"/>.</param>
		/// <returns>Instance of <see cref="IRelatedRecordsManager"/>.</returns>
		protected virtual IRelatedRecordsManager GetRelatedRecordsManager(
			IRelatedRecordsProvider relatedRecordsProvider) {
			return GetDefaultRelatedRecordsManager(relatedRecordsProvider);
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc />
		public RelatedRecordsHandlerResult AddRelatedRecords(RelatedRecordsHandlerData handlerData) {
			return ProcessRelatedRecordsAction(handlerData, ProcessAddRelatedRecords);
		}

		/// <inheritdoc />
		public RelatedRecordsHandlerResult RemoveRelatedRecords(RelatedRecordsHandlerData handlerData) {
			return ProcessRelatedRecordsAction(handlerData, ProcessRemoveRelatedRecords);
		}

		#endregion

	}

	#endregion

}

