namespace Terrasoft.Configuration {
	using System;
	using System.Collections.Generic;
	using System.ServiceModel;
	using System.ServiceModel.Web;
	using System.ServiceModel.Activation;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.DcmProcess;
	using Terrasoft.Core.Factories;
	using Terrasoft.Web.Common;
	using System.Web.SessionState;

	#region Class: DcmService

	/// <summary>
	/// Provides web-service for work with section wizard case settings.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class DcmService : BaseService, IReadOnlySessionState {

		#region Methods: Public

		/// <summary>
		/// Runs dcm process.
		/// </summary>
		/// <param name="dcmSchemaUId">Schema identifier.</param>
		/// <param name="entityRecordId">Entity record identifier.</param>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "RunDcmProcess", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void RunDcmProcess(Guid dcmSchemaUId, Guid entityRecordId) {
			DcmSchemaManager dcmSchemaManager = UserConnection.DcmSchemaManager;
			DcmSchema dcmSchema = dcmSchemaManager.GetInstanceByUId(dcmSchemaUId);
			IProcessEngine processEngine = UserConnection.ProcessEngine;
			processEngine.RunDcmProcess(entityRecordId, dcmSchema);
		}

		/// <summary>
		/// Get allowed stages for current user.
		/// </summary>
		/// <param name="userId">Dcm schema unique identifier.</param>
		/// <returns>List allowed stages identifiers.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetAllowedStagesForCurrentUser", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public List<Guid> GetAllowedStagesForCurrentUser(Guid dcmSchemaUId) {
			var dcmEntityUtilities = ClassFactory.Get<DcmPermissions>();
			var allowedStages = dcmEntityUtilities.GetAllowedStagesForCurrentUser(dcmSchemaUId);
			return allowedStages;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetDcmStageColumnName", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string GetDcmStageColumnName(string entitySchemaName) {
			var entitySchema = UserConnection.EntitySchemaManager.FindInstanceByName(entitySchemaName);
			var entitySchemaUId = entitySchema?.UId;
			if (!entitySchemaUId.HasValue || entitySchemaUId.Value.IsEmpty()) {
				return null;
			}
			var select = new Select(UserConnection)
				.Top(1)
					.Column("sds", nameof(SysDcmSettings.StageColumnUId))
				.From(nameof(SysDcmSettings), "sds")
				.Join(JoinType.LeftOuter,nameof(SysModuleEntity)).As("sme")
					.On("sds", nameof(SysDcmSettings.SysModuleEntityId)).IsEqual("sme", nameof(SysModuleEntity.Id))
				.Where("sme", nameof(SysModuleEntity.SysEntitySchemaUId)).IsEqual(Column.Parameter(entitySchemaUId))
					.Or("sds", nameof(SysDcmSettings.SysSchemaUId)).IsEqual(Column.Parameter(entitySchemaUId))
				.OrderByDesc("sds", "ModifiedOn")
				as Select;
			select.SpecifyNoLockHints();
			var stageColumnUId = select.ExecuteScalar<Guid>();
			return entitySchema.Columns.FindByUId(stageColumnUId)?.Name;
		}

		#endregion

	}

	#endregion

}
