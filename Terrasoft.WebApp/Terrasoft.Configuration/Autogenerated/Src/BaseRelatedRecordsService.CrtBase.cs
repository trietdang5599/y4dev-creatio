namespace Terrasoft.Configuration.RelatedRecords
{
	using System;
	using System.Collections.Generic;
	using Newtonsoft.Json;
	using Terrasoft.Core;
	using Terrasoft.Core.Factories;
	using Terrasoft.Web.Common;

	#region Class: BaseRelatedRecordsService

	/// <summary>
	/// Provides base web-service for work with related records.
	/// </summary>
	public abstract class BaseRelatedRecordsService : BaseService
	{

		#region Constructors: Public

		public BaseRelatedRecordsService() { }

		public BaseRelatedRecordsService(UserConnection userConnection)
			: base(userConnection) { }

		#endregion

		#region Methods: Private

		private RelatedRecordsServiceResponse ProcessRelatedRecordsAction(IRelatedRecordsServiceRequest request,
			Func<RelatedRecordsHandlerData, RelatedRecordsHandlerResult> action) {
			var relatedRecordsManagerData = CreateRelatedRecordsHandlerData(request);
			var handlerResult = action(relatedRecordsManagerData);
			if (handlerResult.Exception == null) {
				return new RelatedRecordsServiceResponse(handlerResult.ProcessedRecordsCount);
			}
			return new RelatedRecordsServiceResponse(handlerResult.Exception);
		}

		private RelatedRecordsHandlerData CreateRelatedRecordsHandlerData(IRelatedRecordsServiceRequest request) {
			IDictionary<string, string> defaultValues = null;
			if (!string.IsNullOrEmpty(request.DefaultValues)) {
				defaultValues = JsonConvert.DeserializeObject<IDictionary<string, string>>(request.DefaultValues);
			}
			return new RelatedRecordsHandlerData {
				MainRecordsEsqSerialized = request.MainRecordsEsqSerialized,
				RelatedRecordsEsqSerialized = request.RelatedRecordsEsqSerialized,
				RelatedInMainRecordsSchemaName = request.RelatedInMainRecordsSchemaName,
				MainRecordColumnName = request.MainRecordColumnName,
				RelatedRecordColumnName = request.RelatedRecordColumnName,
				DefaultValues = defaultValues ?? new Dictionary<string, string>()
			};
		}

		private RelatedRecordsHandlerResult ProcessAddRelatedRecords(
			RelatedRecordsHandlerData relatedRecordsHandlerData) {
			return GetRelatedRecordsHandler().AddRelatedRecords(relatedRecordsHandlerData);
		}

		private RelatedRecordsHandlerResult ProcessRemoveRelatedRecords(
			RelatedRecordsHandlerData relatedRecordsHandlerData) {
			return GetRelatedRecordsHandler().RemoveRelatedRecords(relatedRecordsHandlerData);
		}

		private IRelatedRecordsHandler GetDefaultRelatedRecordsHandler() {
			return ClassFactory.Get<IRelatedRecordsHandler>(new ConstructorArgument("userConnection", UserConnection));
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Gets instance of related records handler.
		/// </summary>
		/// <returns>Instance of <see cref="IRelatedRecordsHandler"/>.</returns>
		protected virtual IRelatedRecordsHandler GetRelatedRecordsHandler() {
			return GetDefaultRelatedRecordsHandler();
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Adds related records to main records.
		/// </summary>
		/// <param name="request">Related records service request.</param>
		/// <returns><see cref="RelatedRecordsServiceResponse"/>.</returns>
		public RelatedRecordsServiceResponse AddRelatedRecords(IRelatedRecordsServiceRequest request) {
			return ProcessRelatedRecordsAction(request, ProcessAddRelatedRecords);
		}

		/// <summary>
		/// Removes related records from main records.
		/// </summary>
		/// <param name="request">Related records service request.</param>
		/// <returns><see cref="RelatedRecordsServiceResponse"/>.</returns>
		public RelatedRecordsServiceResponse RemoveRelatedRecords(IRelatedRecordsServiceRequest request) {
			return ProcessRelatedRecordsAction(request, ProcessRemoveRelatedRecords);
		}

		#endregion

	}

	#endregion

}

