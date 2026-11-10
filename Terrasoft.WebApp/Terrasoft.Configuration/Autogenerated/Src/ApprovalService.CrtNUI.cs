namespace Terrasoft.Configuration
{
	using Core.Factories;
	using System;
	using System.Collections.Generic;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using Terrasoft.Core;
	using Terrasoft.Common;
	using Terrasoft.Core.ServiceModelContract;
	using Terrasoft.Nui.ServiceModel.DataContract;
	using Terrasoft.Nui.ServiceModel.Extensions;
	using Web.Common;
	using BaseResponse = Terrasoft.Core.ServiceModelContract.BaseResponse;
	using ErrorInfo = Terrasoft.Core.ServiceModelContract.ErrorInfo;

	#region Class: ApprovalService

	/// <summary>
	/// ApprovalService service class for working with Approval Entities
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class ApprovalService : BaseService
	{
		#region Properties: Private

		private bool UseSystemUserConnectionForApproval => UserConnection.GetIsFeatureEnabled("UseSystemUserConnectionForApproval");

		#endregion

		#region Methods: Private
		
		private bool GetCanUseSystemConnectioonForApproval() {
			try {
				return UserConnection.DBSecurityEngine.GetCanExecuteOperation("CanUseSystemConnectionForApproval");
			} catch (Exception e) {
				return false;
			}
		}

		private UserConnection GetUserConnectionForApproval() {
			return GetCanUseSystemConnectioonForApproval() && UseSystemUserConnectionForApproval
				? UserConnection.AppConnection.SystemUserConnection
				: UserConnection;
		}


		private ApprovalResponse ChangeApproval(ApprovalRequest request, Guid statusId) {
			var userConnection = GetUserConnectionForApproval();
			return request.CollectProcessExecutionData(() => {
				var response = new ApprovalResponse {
					Result = false
				};
				if (request == null) {
					return response;
				}
				var action = ClassFactory.Get<IApprovalAction>(new ConstructorArgument("userConnection", userConnection));
				request.AdditionalColumnValues = GenerateAdditionalColumnValues(request,
					new Dictionary<string, object> {
						{"StatusId", statusId }
					});
				response.Result = action.ChangeApproval(request.SchemaName, request.Id, request.AdditionalColumnValues);
				response.Success = true;
				return response;
			}, userConnection);
		}

		private BaseResponseWithProcessExecutionData ChangeApprovalWithResponse(ApprovalRequest request, Guid statusId) {
			var userConnection = GetUserConnectionForApproval();
			return request.CollectProcessExecutionData(() => {
				var response = new BaseResponseWithProcessExecutionData {
					Success = false,
					ErrorInfo = new ErrorInfo {
						Message = "Exception: Unexpected exception."
					}
				};
				if (request == null) {
					response.ErrorInfo.Message = "Exception: Approval request is empty.";
					return response;
				}
				try {
					var action = ClassFactory.Get<IApprovalAction>(new ConstructorArgument("userConnection", userConnection));
					request.AdditionalColumnValues = GenerateAdditionalColumnValues(request,
						new Dictionary<string, object> {
							{"StatusId", statusId}
						});
					response.Success = action.ChangeApprovalWithLocationException(request.SchemaName, request.Id,
						request.AdditionalColumnValues);
				} catch (VisaNotFoundException) {
					response.ErrorInfo.Message = "Exception: Visa not found.";
				} catch (VisaFinalStatusException) {
					response.ErrorInfo.Message = "This request has already been approved or denied. No further activities are required on your part.";
				} catch (SaveVisaChangesException) {
					response.ErrorInfo.Message = "Exception: Visa changes didn't save.";
				} catch (Exception e) {
					response.ErrorInfo.Message = $"Exception: {e.Message}";
				}
				return response;
			}, userConnection);
		}

		private Dictionary<string, object> GenerateAdditionalColumnValues(ApprovalRequest request,
			Dictionary<string, object> extraValues = null) {
			var additionalColumnValues = request.AdditionalColumnValues ?? new Dictionary<string, object>();
			request.AdditionalValues?.ForEach(item => {
				if (!additionalColumnValues.ContainsKey(item.Key)) {
					additionalColumnValues.Add(item.Key, item.Value);
				}
			});
			extraValues?.ForEach(item => {
				if (!additionalColumnValues.ContainsKey(item.Key)) {
					additionalColumnValues.Add(item.Key, item.Value);
				}
			});
			return additionalColumnValues;
		}

		#endregion

		#region Methods: Public

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		[ResponseJsonFormatter]
		public ApprovalResponse Approve(ApprovalRequest request) {
			return ChangeApproval(request, ApprovalConstants.Accepted);
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		[ResponseJsonFormatter]
		public ApprovalResponse Reject(ApprovalRequest request) {
			return ChangeApproval(request, ApprovalConstants.Rejected);
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		[ResponseJsonFormatter]
		public BaseResponseWithProcessExecutionData ApproveWithResponse(ApprovalRequest request) {
			return ChangeApprovalWithResponse(request, ApprovalConstants.Accepted);
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		[ResponseJsonFormatter]
		public BaseResponseWithProcessExecutionData RejectWithResponse(ApprovalRequest request) {
			return ChangeApprovalWithResponse(request, ApprovalConstants.Rejected);
		}

		#endregion

	}

	#endregion

	#region Class: ApprovalRequest

	/// <summary>
	/// ApprovalRequest json object.
	/// </summary>
	[DataContract]
	public class ApprovalRequest: IQueryProcessExecutionData
	{

		#region Properties: Public

		/// <summary>
		/// Identifier.
		/// </summary>
		[DataMember(Name = "id")]
		public Guid Id { get; set; }

		/// <summary>
		/// Approval schema name.
		/// </summary>
		[DataMember(Name = "schemaName")]
		public string SchemaName { get; set; }

		/// <summary>
		/// Additional column values.
		/// </summary>
		[DataMember(Name = "additionalColumnValues")]
		public Dictionary<string, object> AdditionalColumnValues { get; set; }

		/// <summary>
		/// Additional values.
		/// </summary>
		[DataMember(Name = "additionalValues")]
		public List<ApprovalRequestAdditionalItem> AdditionalValues { get; set; }

		/// <summary>
		/// Indicates that execution data of process elements, started during executing current query, should be
		/// included in response.
		/// </summary>
		public bool IncludeProcessExecutionData { get; set; }

		/// <inheritdoc cref="IQueryProcessExecutionData.ForceBackgroundMode"/>
		[DataMember(Name = "forceBackgroundMode")]
		public bool ForceBackgroundMode { get; set; }

		/// <inheritdoc cref="IQueryProcessExecutionData.ProcessExecutionOptions"/>
		[DataMember(Name = "processExecutionOptions")]
		public ProcessExecutionOptions ProcessExecutionOptions { get; set; }

		#endregion

	}

	#endregion

	#region Class: ApprovalRequestAdditionalItem

	[DataContract]
	public class ApprovalRequestAdditionalItem
	{
		[DataMember(Name = "key")]
		public string Key;

		[DataMember(Name = "value")]
		public object Value;
	}

	#endregion

	#region ApprovalResponse

	/// <summary>
	/// Represents an approval response.
	/// </summary>
	[DataContract]
	public class ApprovalResponse : BaseResponse, IResponseWithProcessExecutionData
	{

		#region Properties: Public

		/// <summary>
		/// Approve result.
		/// </summary>
		[DataMember(Name = "result")]
		public bool Result { get; set; }

		/// <summary>
		/// Approve result. Obsolete.
		/// </summary>
		[Obsolete("8.1.1 | ApproveResult property is obsolete. Use Result instead.")]
		[DataMember]
		public bool ApproveResult => Result;

		/// <summary>
		/// Reject result. Obsolete.
		/// </summary>
		[Obsolete("8.1.1 | RejectResult property is obsolete. Use Result instead.")]
		[DataMember]
		public bool RejectResult => Result;

		/// <inheritdoc cref="IResponseWithProcessExecutionData.ProcessExecutionData"/>
		[DataMember(Name = "processExecutionData")]
		public JsonRaw ProcessExecutionData { get; set; }

		#endregion

	}

	#endregion

}

