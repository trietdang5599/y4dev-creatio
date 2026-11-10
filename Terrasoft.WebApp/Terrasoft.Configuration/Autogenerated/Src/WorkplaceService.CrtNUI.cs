namespace Terrasoft.Configuration.WorkplaceService
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using global::Common.Logging;
	using Terrasoft.Common;
	using Terrasoft.Configuration.Workplace;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.ServiceModelContract;
	using Terrasoft.Web.Common;

	#region Class: CreateWorkplaceRequest

	[DataContract]
	public class CreateWorkplaceRequest
	{

		#region Properties: Public

		[DataMember(Name = "name", IsRequired = true)]
		public string Name { get; set; }

		[DataMember(Name = "type")]
		public WorkplaceType Type { get; set; }

		[DataMember(Name = "homePageUId")]
		public Guid? HomePageUId { get; set; }

		[DataMember(Name = "clientApplicationTypeId")]
		public Guid? ClientApplicationTypeId { get; set; }

		#endregion

	}

	#endregion

	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class WorkplaceService : BaseService
	{

		#region Properties: Private

			private ILog _log;
			private ILog Logger => _log ?? (_log = LogManager.GetLogger("WorkplaceService"));

		#endregion

		#region Constructors: Public

		public WorkplaceService() {
		}

		public WorkplaceService(IWorkplaceManager workplaceManager) {
			_workplaceManager = workplaceManager;
		}

		#endregion

		#region Properties: Protected

		/// <summary>
		/// <see cref="IWorkplaceManager"/> implementation instance.
		/// </summary>
		private IWorkplaceManager _workplaceManager;
		protected IWorkplaceManager WorkplaceManager => _workplaceManager ?? (_workplaceManager =
			ClassFactory.Get<IWorkplaceManager>(new ConstructorArgument("uc", UserConnection)));

		#endregion

		#region Methods: Private

		private void ResetCache() {
			ConfigurationSectionHelper.ClearCache(UserConnection);
		}

		private string GetWorkplacesScript(Guid applicationClientTypeId) {
			ConfigurationSectionHelper helper = new ConfigurationSectionHelper(UserConnection);
			return helper.GetWorkplacesConfig(UserConnection, true, applicationClientTypeId);
		}

		private void ResetWorkplace() {
			ConfigurationSectionHelper.ResetWorkplaceCache(UserConnection);
		}

		private void SetWorkplaceId(string workplaceId) {
			if (string.IsNullOrEmpty(workplaceId)) {
				return;
			}
			Guid wId = new Guid(workplaceId);
			ConfigurationSectionHelper.SetWorkplaceCache(UserConnection, wId);
		}

		private T TryExecute<T>(Action<T> action) where T: BaseResponse, new() {
			T response = new T();
			try {
				action(response);
			} catch (Exception e) {
				Logger.Error(e);
				response.Success = false;
				response.ErrorInfo = new ErrorInfo {
					Message = "Internal server error",
				};
			}
			return response;
		}

		#endregion

		#region Methods: Public

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void ResetScriptCache() {
			ResetCache();
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void ResetWorkplaceCache() {
			ResetWorkplace();
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void SetWorkplaceCache(string workplaceId) {
			SetWorkplaceId(workplaceId);
		}
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string RefreshWorkplace(Guid applicationClientTypeId = default(Guid)) {
			return GetWorkplacesScript(applicationClientTypeId);
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public IEnumerable<string> GetWorkplacesByType(int type) {
			var result = WorkplaceManager.GetWorkplacesByType((WorkplaceType)type).Select(w => w.ToString());
			return result;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedResponse,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public Guid CreateWorkplace(CreateWorkplaceRequest request) {
			var parameters = new CreateWorkplaceParameters {
				Name = request.Name,
				Type = request.Type,
				HomePageUId = request.HomePageUId,
				ClientApplicationTypeId = request.ClientApplicationTypeId
			};
			var workplace = WorkplaceManager.CreateWorkplace(parameters);
			return workplace.Id;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void ChangeWorkplaceName(Guid workplaceId, string name) {
			WorkplaceManager.ChangeName(workplaceId, name);
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void ChangeWorkplacePosition(Guid workplaceId, int position) {
			WorkplaceManager.ChangePosition(workplaceId, position);
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void DeleteWorkplace(Guid workplaceId) {
			WorkplaceManager.DeleteWorkplace(workplaceId);
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void AddSectionToWorkplace(Guid workplaceId, Guid sectionId) {
			WorkplaceManager.AddSectionToWorkplace(workplaceId, sectionId);
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void RemoveSectionFromWorkplace(Guid workplaceId, Guid sectionId) {
			WorkplaceManager.RemoveSectionFromWorkplace(workplaceId, sectionId);
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public BaseResponse ResetWorkplaceCacheByApplicationClientTypeId(Guid applicationClientTypeId) {
			return TryExecute<BaseResponse>(_ => {
				applicationClientTypeId.CheckArgumentEmpty(nameof(applicationClientTypeId));
				if (applicationClientTypeId == BaseConsts.BrowserClientTypeId) {
					ConfigurationSectionHelper.ClearWorkplaceCache(UserConnection);
				}
				WorkplaceManager.ReloadWorkplacesByApplicationClientType(applicationClientTypeId);
			});
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public ValueResponse<int> GetWorkplaceSectionCount(Guid workplaceId) {
			return TryExecute<ValueResponse<int>>(response => {
				workplaceId.CheckArgumentEmpty(nameof(workplaceId));
				response.Value = WorkplaceManager.GetWorkplaceSectionCount(workplaceId);
			});
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public BaseResponse RemoveAllSectionsFromWorkplace(Guid workplaceId) {
			return TryExecute<BaseResponse>(_ => {
				workplaceId.CheckArgumentEmpty(nameof(workplaceId));
				WorkplaceManager.RemoveAllSectionsFromWorkplace(workplaceId);
			});
		}

		#endregion

	}

}

