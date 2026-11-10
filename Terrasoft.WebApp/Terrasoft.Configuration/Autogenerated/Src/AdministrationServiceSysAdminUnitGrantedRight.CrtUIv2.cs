namespace Terrasoft.Configuration
{
	using System.ServiceModel;
	using System.ServiceModel.Web;
	using Terrasoft.Core.Entities;
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
    using Terrasoft.Common;
	using Terrasoft.Common.Json;
	using Terrasoft.Core.DB;

	#region Class: AdministrationService
	public partial class AdministrationService
	{
		
		#region Methods: Private

		private Guid ConvertStringToGuid(string s) {
			return Guid.TryParse(s, out Guid guid) ? guid : Guid.Empty;
		}
		
		
		private bool HasTechnicalUser(string[] grantees, string grantor) {
			var users = grantees.Select(guidString => ConvertStringToGuid(guidString)).ToList();
			users.Add(ConvertStringToGuid(grantor));
			var selectQuery = new Select(UserConnection).Top(1)
					.Column("Id")
				.From("SysAdminUnit")
				.Where("Id").In(Column.Parameters(users))
					.And("SysAdminUnitTypeValue").IsEqual(Column.Parameter(Core.DB.SysAdminUnitType.TechnicalUser)) as Select;
			using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = selectQuery.ExecuteReader(dbExecutor)) {
					return dataReader.Read();
				}
			}
		}
      
		/// <summary>
		/// ######### ##### ###### # # ####### SysAdminUnitGrantedRight.
		/// </summary>
		/// <param name="granteeSysAdminUnitId">######## ####### "######## #####".</param>
		/// <param name="grantorSysAdminUnitId">######## ####### "####### #####".</param>
		private void InsertSysAdminUnitGrantedRight(object granteeSysAdminUnitId, object grantorSysAdminUnitId) {
			UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanChangeAdminUnitGrantedRight");
			EntitySchema tableSchema = UserConnection.EntitySchemaManager.GetInstanceByName("SysAdminUnitGrantedRight");
			Entity entity = tableSchema.CreateEntity(UserConnection);
			entity.SetDefColumnValues();
			entity.SetColumnValue("GranteeSysAdminUnitId", granteeSysAdminUnitId);
			entity.SetColumnValue("GrantorSysAdminUnitId", grantorSysAdminUnitId);
			entity.Save();
		}
		/// <summary>
		/// ####### ######### ###### # SysAdminUnitGrantedRight.
		/// </summary>
		/// <param name="selectedRecordId">######### ######.</param>
		private void DeleteSysAdminUnitGrantedRight(object selectedRecordId) {
			UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanChangeAdminUnitGrantedRight");
			EntitySchema tableSchema = UserConnection.EntitySchemaManager.GetInstanceByName("SysAdminUnitGrantedRight");
			Entity entity = tableSchema.CreateEntity(UserConnection);
			if (entity.FetchFromDB(selectedRecordId)) {
				entity.Delete();
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// ############ ######## ########## ####### # SysAdminUnitGrantedRight.
		/// </summary>
		/// <param name="masterRecordId">######## ####### ######.</param>
		/// <param name="selectedRecords">######## ######### #######.</param>
		/// <returns>###### ### ##########.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "AddSysAdminUnitGrantedRights", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string AddSysAdminUnitGrantedRights(string masterRecordId, string selectedRecords) {
			string[] selectedValues = Json.Deserialize<string[]>(selectedRecords);
			string errorMessage = string.Empty;
			if (HasTechnicalUser(selectedValues, masterRecordId)) {
				errorMessage = new LocalizableString(UserConnection.Workspace.ResourceStorage,
					"AdministrationServiceSysAdminUnitGrantedRight",
					"LocalizableStrings.TechnicalUserRightCannotBeDelegatedMessage.Value");
			} else {
				foreach (var item in selectedValues) {
					try {
						InsertSysAdminUnitGrantedRight(item, masterRecordId);
					} catch (Exception e) {
						errorMessage = e.Message;
					}
				}
			}
			return errorMessage;
		}

		/// <summary>
		/// ############ ########## #### # SysAdminUnitGrantedRight ## ######### #######.
		/// </summary>
		/// <param name="masterRecordId">############# ######, ####### ##### ############ #####.</param>
		/// <param name="selectedRecords">############## #######, ## ####### ##### ############ #####.</param>
		/// <returns>###### ### ##########.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "AddSysAdminUnitGrantedRightsFromSelectedRecords", 
			BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, 
			ResponseFormat = WebMessageFormat.Json)]
		public string AddSysAdminUnitGrantedRightsFromSelectedRecords(string masterRecordId, string selectedRecords) {
			string[] selectedValues = Json.Deserialize<string[]>(selectedRecords);
			string errorMessage = string.Empty;
			if(HasTechnicalUser(selectedValues, masterRecordId)) {
				errorMessage = new LocalizableString(UserConnection.Workspace.ResourceStorage,
					"AdministrationServiceSysAdminUnitGrantedRight",
					"LocalizableStrings.TechnicalUserRightCannotBeDelegatedMessage.Value");
			} else {
				foreach (string item in selectedValues) {
					try {
						InsertSysAdminUnitGrantedRight(masterRecordId, item);
					} catch (Exception e) {
						errorMessage = e.Message;
					}
				}
			}
			return errorMessage;
		}
		
		/// <summary>
		/// ####### ######### ###### # SysAdminUnitGrantedRight.
		/// </summary>
		/// <param name="selectedRecords">######### ######.</param>
		/// <returns>###### ### ##########.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "RemoveSysAdminUnitGrantedRights", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string RemoveSysAdminUnitGrantedRights(string selectedRecords) {
			string[] selectedValues = Json.Deserialize<string[]>(selectedRecords);
			string errorMessage = string.Empty;
			foreach (var item in selectedValues) {
				try {
					DeleteSysAdminUnitGrantedRight(item);
				} catch (Exception e) {
					errorMessage = e.Message;
				}
			}
			return errorMessage;
		}

		#endregion Methods: Public
	}
	#endregion Class: AdministrationService
}

