namespace Terrasoft.Configuration.Deduplication
{
	using System;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using System.Web.SessionState;
	using Newtonsoft.Json;
	using Terrasoft.Core.Factories;

	#region Class: BulkDeduplicationService

	/// <summary>
	/// Represent class for bulk deduplication service.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class BulkDeduplicationService : IReadOnlySessionState
	{

		#region Properties: Protected

		private IBulkDeduplicationManagerV2 _deduplicationManager;
		protected IBulkDeduplicationManagerV2 DeduplicationManager =>
			_deduplicationManager ??
			(_deduplicationManager = ClassFactory.Get<IBulkDeduplicationManagerV2>());

		private IBulkDeduplicationGroupManager _deduplicationGroupManager;
		protected IBulkDeduplicationGroupManager DeduplicationGroupManager =>
			_deduplicationGroupManager ??
			(_deduplicationGroupManager = ClassFactory.Get<IBulkDeduplicationGroupManager>());

		#endregion

		#region Methods: Public

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetDeduplicationInfo", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "deduplicationInfo")]
		public BulkDeduplicationInfo GetDeduplicationInfo(string entityName) {
			return DeduplicationManager.GetDeduplicationInfo(entityName);
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "FindDuplicateEntities", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "success")]
		public bool FindDuplicateEntities(string entityName) {
			return DeduplicationManager.StartDeduplicationTask(entityName);
		}

		/// <summary>
		/// Web-method invokes canceling of duplicates search task.
		/// </summary>
		/// <param name="schemaName">Schema name.</param>
		/// <returns>Response of search request.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "CancelDeduplicationTask", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "success")]
		public void CancelDeduplicationTask(string schemaName) {
			DeduplicationManager.CancelDeduplicationTask(schemaName);
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetDuplicateEntities", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "result")]
		public string GetDuplicateEntities(string entityName, string[] columns, int offset, int count) {
			var result = DeduplicationManager.GetDuplicateEntitiesGroups(entityName, columns, offset, count);
			return JsonConvert.SerializeObject(result);
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetGroupsOfDuplicates", BodyStyle = WebMessageBodyStyle.WrappedResponse,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "result")]
		public string GetGroupsOfDuplicatesV2(GetGroupsOfDuplicatesParams parameters) {
			var result = DeduplicationManager.GetGroupsOfDuplicates(parameters);
			return JsonConvert.SerializeObject(result);
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetDuplicateEntitiesByGroup", BodyStyle = WebMessageBodyStyle.WrappedResponse,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "result")]
		public string GetDuplicateEntitiesByGroup(GetDuplicateEntitiesByGroupParams parameters) {
			var result = DeduplicationManager.GetDuplicateEntitiesByGroup(parameters);
			return JsonConvert.SerializeObject(result);
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "AddToUniqueList", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "success")]
		public bool AddToUniqueList(string schemaName, Guid[] uniqueRecordIds) {
			return DeduplicationManager.AddToUniqueList(schemaName, uniqueRecordIds);
		}
		
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "AddGroupToUniqueList", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "success")]
		public bool AddGroupToUniqueList(string schemaName, Guid groupId) {
			return DeduplicationGroupManager.AddGroupToUniqueList(schemaName, groupId);
		}
		
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetDuplicatesCountData", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "result")]
		public string GetDuplicatesCountData(string entityName) {
			var result = DeduplicationManager.GetDuplicateCountData(entityName);
			return JsonConvert.SerializeObject(result);
		}

		#endregion
	}

	#endregion

}
