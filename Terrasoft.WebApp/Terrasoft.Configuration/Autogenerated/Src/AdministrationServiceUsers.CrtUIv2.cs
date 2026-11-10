namespace Terrasoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Globalization;
	using System.Linq;
	using System.Runtime.Serialization;
	using System.Security;
	using System.ServiceModel;
	using System.ServiceModel.Web;
	using System.Web.SessionState;
	using Terrasoft.Common;
	using Terrasoft.Common.Json;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Nui.ServiceModel.Extensions;
	using Newtonsoft.Json;
	using Terrasoft.Core.ExternalUsers;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Feature;
	using Features = Creatio.FeatureToggling.Features;
	using SysSettingConfiguration = Core.Configuration.SysSettings;
	using global::Common.Logging;

	#region Class: TechnicalUserInfoDto

	[DataContract]
	public class TechnicalUserInfoDto
	{

		#region Properties: Public

		[DataMember(IsRequired = true)]
		public Guid Id { get; set; }

		[DataMember(IsRequired = true)]
		public string Name { get; set; }

		[DataMember]
		public bool Active { get; set; }

		[DataMember]
		public Guid SysLanguageId { get; set; }

		[DataMember]
		public Guid ContactId { get; set; }

		[DataMember]
		public Guid TimeZoneId { get; set; }

		#endregion

	}

	#endregion
  
	#region Class: AdministrationService
	public partial class AdministrationService : IReadOnlySessionState
	{
		#region Fields: Private

		/// <summary>
		/// ####### ########## ####### ##### ####### "VwSysAdminUnit".
		/// #### - ### ######## ####### #######, ######## - ### ######## #######.
		/// </summary>
		private Dictionary<string, object> changedValues;

		/// <summary>
		/// ############# #### ######### ###############.
		/// </summary>
		private readonly Guid sysAdminsRoleId = new Guid("83a43ebc-f36b-1410-298d-001e8c82bcad");
		private readonly Guid rootRoleId = new Guid("A29A3BA5-4B0D-DE11-9A51-005056C00008");
		private static readonly ILog _log = LogManager.GetLogger(typeof(AdministrationService));

		#endregion Fields: Private

		#region Methods: Private

		private static Guid GetGuidFromObject(object guidObject) {
			var result = Guid.Empty;
			switch (guidObject) {
				case Guid guid:
					result = guid;
					break;
				case string stringGuid:
					result = Guid.Parse(stringGuid);
					break;
			}
			return result;
		}

		/// <summary>
		/// ####### ###### # ####### "SysUserInRole" ### ########## ############ # ####.
		/// </summary>
		/// <param name="userId">############# ############.</param>
		/// <param name="roleId">############# ####.</param>
		private void AddUserInRole(object userId, object roleId) {
			List<object> listUsers = new List<object>();
			listUsers.Add(userId);
			AddUsersInRole(listUsers, roleId);
		}

		/// <summary>
		/// ########## ########## ######### ###############.
		/// </summary>
		/// <returns>########## ############### # #######.</returns>
		private int GetSysAdminsCount() {
			var sysUserInRoleQuery = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SysUserInRole");
			EntitySchemaQueryColumn countColumn = sysUserInRoleQuery.AddColumn("Id");
			countColumn.SummaryType = AggregationType.Count;
			IEntitySchemaQueryFilterItem roleFilter = sysUserInRoleQuery.CreateFilterWithParameters(
				FilterComparisonType.Equal, "SysRole", sysAdminsRoleId);
			sysUserInRoleQuery.Filters.Add(roleFilter);
			Entity summary = sysUserInRoleQuery.GetSummaryEntity(UserConnection);
			return summary != null ? summary.GetTypedColumnValue<int>(countColumn.Name) : 0;
		}

		/// #########, ###### ## ############ # ###### ######### ###############.
		/// #### ##, ## ######## ##### CheckCanRemoveUserFromRole ### #### ###. ###############.
		/// </summary>
		/// <param name="userId"></param>
		private void CheckCanDeleteUser(Guid userId) {
			var sysUserInRoleQuery = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SysUserInRole");
			EntitySchemaQueryColumn countColumn = sysUserInRoleQuery.AddColumn("Id");
			countColumn.SummaryType = AggregationType.Count;
			IEntitySchemaQueryFilterItem userFilter = sysUserInRoleQuery.CreateFilterWithParameters(
				FilterComparisonType.Equal, "SysUser", userId);
			IEntitySchemaQueryFilterItem roleFilter = sysUserInRoleQuery.CreateFilterWithParameters(
				FilterComparisonType.Equal, "SysRole", sysAdminsRoleId);
			sysUserInRoleQuery.Filters.Add(userFilter);
			sysUserInRoleQuery.Filters.Add(roleFilter);
			Entity summary = sysUserInRoleQuery.GetSummaryEntity(UserConnection);
			if (summary != null && summary.GetTypedColumnValue<int>(countColumn.Name) > 0) {
				CheckCanRemoveUserFromRole(sysAdminsRoleId);
			}
		}

		/// <summary>
		/// #########, ######## ## ############ ####### ############# ############## #######,
		/// # #### ### ###, ########## ########## <see cref="SecurityException"/>.
		/// </summary>
		/// <param name="roleId">############# ####.</param>
		private void CheckCanRemoveUserFromRole(Guid roleId) {
			if (roleId != sysAdminsRoleId) {
				return;
			}
			if (GetSysAdminsCount() == 1) {
				throw new SecurityException(new LocalizableString(UserConnection.Workspace.ResourceStorage,
					"AdministrationServiceUsers",
					"LocalizableStrings.CannotRemoveLastUserFromSysAdminsExceptionMessage.Value"));
			}
		}

		/// <summary>
		/// ####### ###### # ####### "SysUserInRole" ### ########## ############# # ####.
		/// </summary>
		/// <param name="recordId">############# ########## ######.</param>
		/// <param name="userId">############# ############.</param>
		/// <param name="roleId">############# ####.</param>
		private void ChangeUserInRole(object recordId, object roleId, object userId) {
			EntitySchema tableSchema = UserConnection.EntitySchemaManager.GetInstanceByName("SysUserInRole");
			Entity sysUserInRole = tableSchema.CreateEntity(UserConnection);
			if (sysUserInRole.FetchFromDB(recordId)) {
				EntitySchemaColumn userColumn = tableSchema.Columns.GetByName("SysUser");
				EntitySchemaColumn roleColumn = tableSchema.Columns.GetByName("SysRole");
				sysUserInRole.SetColumnValue(userColumn.ColumnValueName, userId);
				sysUserInRole.SetColumnValue(roleColumn.ColumnValueName, roleId);
				sysUserInRole.Save();
			}
		}

		/// <summary>
		/// ####### ###### # ####### "SysUserInRole" ### ########## ############# # ####.
		/// </summary>
		/// <param name="userIds">###### ############### #############.</param>
		/// <param name="roleId">############# ####.</param>
		private void AddUsersInRole(List<object> userIds, object roleId) {
			EntitySchema tableSchema = UserConnection.EntitySchemaManager.GetInstanceByName("SysUserInRole");
			foreach (object userId in userIds) {
				Entity sysUserInRole = tableSchema.CreateEntity(UserConnection);
				Dictionary<string, object> conditions = new Dictionary<string, object> {
					{ "SysUser", userId },
					{ "SysRole", roleId }
				};
				if (!sysUserInRole.FetchFromDB(conditions)) {
					sysUserInRole.SetDefColumnValues();
					EntitySchemaColumn userColumn = tableSchema.Columns.GetByName("SysUser");
					EntitySchemaColumn roleColumn = tableSchema.Columns.GetByName("SysRole");
					sysUserInRole.SetColumnValue(userColumn.ColumnValueName, userId);
					sysUserInRole.SetColumnValue(roleColumn.ColumnValueName, roleId);
					sysUserInRole.Save();
				}
			}
		}

		/// <summary>
		/// ####### ###### # ####### "SysFuncRoleInOrgRole".
		/// </summary>
		/// <param name="orgRoleId">############### ####.</param>
		/// <param name="funcRoleId">############## ####.</param>
		private void AddFuncRoleInOrgRole(object orgRoleId, object funcRoleId) {
			EntitySchema tableSchema = UserConnection.EntitySchemaManager.GetInstanceByName("SysFuncRoleInOrgRole");
			Entity sysFuncRoleInOrgRole = tableSchema.CreateEntity(UserConnection);
			Dictionary<string, object> conditions = new Dictionary<string, object> {
				{ "FuncRole", funcRoleId },
				{ "OrgRole", orgRoleId }
			};
			if (!sysFuncRoleInOrgRole.FetchFromDB(conditions)) {
				sysFuncRoleInOrgRole.SetDefColumnValues();
				EntitySchemaColumn funcRoleColumn = tableSchema.Columns.GetByName("FuncRole");
				EntitySchemaColumn orgRoleColumn = tableSchema.Columns.GetByName("OrgRole");
				sysFuncRoleInOrgRole.SetColumnValue(funcRoleColumn.ColumnValueName, funcRoleId);
				sysFuncRoleInOrgRole.SetColumnValue(orgRoleColumn.ColumnValueName, orgRoleId);
				sysFuncRoleInOrgRole.Save();
			}
		}

		/// <summary>
		/// Remove user from all roles.
		/// </summary>
		/// <param name="userId">User Id.</param>
		private void RemoveUserInAllRoles(object userId) {
			var schemaQuery = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SysUserInRole");
			schemaQuery.AddAllSchemaColumns();
			IEntitySchemaQueryFilterItem userFilter = schemaQuery.CreateFilterWithParameters(FilterComparisonType.Equal, "SysUser", userId);
			schemaQuery.Filters.Add(userFilter);
			EntityCollection collection = schemaQuery.GetEntityCollection(UserConnection);
			var roleIds = collection.Select(x => (object)x.GetTypedColumnValue<Guid>("SysRoleId")).ToList();
			if (roleIds.Count > 0) {
				RemoveUserInRoles(userId, roleIds);
			}
		}

		/// <summary>
		/// ####### ############ ## ###### ######### #####.
		/// </summary>
		/// <param name="userId">############# ############.</param>
		/// <param name="roleIds">###### ############### #####.</param>
		/// <param name="guids">###### ############### ######### #######.</param>
		private void RemoveUserInRoles(object userId, List<object> roleIds, List<Guid> guids = null) {
			SecurityException ex = null;
			EntitySchemaQuery schemaQuery = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SysUserInRole");
			schemaQuery.AddAllSchemaColumns();
			IEntitySchemaQueryFilterItem roleFilter = schemaQuery.CreateFilterWithParameters(FilterComparisonType.Equal, "SysRole", roleIds);
			IEntitySchemaQueryFilterItem userFilter = schemaQuery.CreateFilterWithParameters(FilterComparisonType.Equal, "SysUser", userId);
			schemaQuery.Filters.Add(roleFilter);
			schemaQuery.Filters.Add(userFilter);
			EntityCollection collection = schemaQuery.GetEntityCollection(UserConnection);
			foreach (Entity entity in collection.ToList()) {
				try {
					CheckCanRemoveUserFromRole(entity.GetTypedColumnValue<Guid>("SysRoleId"));
					entity.Delete();
					if (guids != null) {
						guids.Add(entity.GetTypedColumnValue<Guid>("SysUserId"));
					}
				} catch (SecurityException e) {
					ex = e;
				}
			}
			if (ex != null) {
				throw ex;
			}
		}

		/// <summary>
		/// Removes users from the list of specified roles.
		/// </summary>
		/// <param name="recordIds">List of record IDs.</param>
		/// <param name="guids">List of deleted record IDs.</param>
		/// <param name="changedUserIds">List of users IDs, removed from roles</param>
		private void RemoveUserInRoles(List<object> recordIds, List<Guid> guids, out List<object> changedUserIds) {
			SecurityException ex = null;
			changedUserIds = new List<object>();
			EntitySchemaQuery schemaQuery = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SysUserInRole");
			schemaQuery.AddAllSchemaColumns();
			IEntitySchemaQueryFilterItem primaryColumnFilter = schemaQuery.CreateFilterWithParameters(FilterComparisonType.Equal,
				schemaQuery.RootSchema.PrimaryColumn.Name, recordIds);
			schemaQuery.Filters.Add(primaryColumnFilter);
			EntityCollection collection = schemaQuery.GetEntityCollection(UserConnection);
			foreach (Entity entity in collection.ToList()) {
				try {
					var userId = entity.GetTypedColumnValue<Guid>("SysUserId");
					if (!changedUserIds.Contains(userId)) {
						changedUserIds.Add(userId);
					}
					CheckCanRemoveUserFromRole(entity.GetTypedColumnValue<Guid>("SysRoleId"));
					entity.Delete();
					guids.Add(entity.PrimaryColumnValue);
				} catch (SecurityException e) {
					ex = e;
				}
			}
			if (ex != null) {
				throw ex;
			}
		}

		/// <summary>
		/// ####### ############# ## ###### ######### #####.
		/// </summary>
		/// <param name="userIds">###### #####.</param>
		/// <param name="roleIds">###### #############.</param>
		/// <param name="guids">###### ############### ######### #######.</param>
		private void RemoveUsersInRoles(List<object> userIds, List<object> roleIds, List<Guid> guids) {
			foreach (object userId in userIds) {
				RemoveUserInRoles(userId, roleIds, guids);
			}
		}

		/// <summary>
		/// ####### ############.
		/// </summary>
		/// <param name="userId">############# ############</param>
		private void DeleteUser(Guid userId) {
			EntitySchema adminUnitSchema = UserConnection.EntitySchemaManager.GetInstanceByName("VwSysAdminUnit");
			Entity adminUnitEntity = adminUnitSchema.CreateEntity(UserConnection);
			if (adminUnitEntity.FetchFromDB(userId)) {
				var delete = new Delete(UserConnection)
					.From("SysUserInRole")
					.Where("SysUserId").IsEqual(Column.Parameter(userId));
				delete.Execute();
				adminUnitEntity.Delete();
			}
		}

		/// <summary>
		/// Return true if user connection type is General.
		/// </summary>
		/// <param name="connectionType">User connection type 0 - General, 1 - SSP.</param>
		/// <returns>true if user connection type is General, false - other.</returns>
		private bool IsUserConnectionTypeGeneral(int connectionType) {
			return connectionType.Equals((int)UserType.General);
		}

		/// <summary>
		/// Return parent role by user connection type.
		/// </summary>
		/// <param name="connectionType">User connection type 0 - General, 1 - SSP.</param>
		/// <returns>User role Id.</returns>
		private Guid GetParentRoleByConnectionType(int connectionType) {
			return IsUserConnectionTypeGeneral(connectionType) ?
				BaseConsts.AllEmployersSysAdminUnitUId : BaseConsts.PortalUsersSysAdminUnitUId;
		}

		/// <summary>
		/// Returns array of primary column values from filters.
		/// </summary>
		/// <param name="filterConfigs">Serialized filters config.</param>
		/// <returns>Array of primary column values.</returns>
		private Guid[] InnerGetUserIds(string filterConfigs) { 
			var select = new Terrasoft.Nui.ServiceModel.DataContract.SelectQuery {
				RootSchemaName = "SysAdminUnit"
			};
			if (!string.IsNullOrEmpty(filterConfigs)) {
				var filters =
					JsonConvert.DeserializeObject<Terrasoft.Nui.ServiceModel.DataContract.Filters>(filterConfigs);
				select.Filters = filters;
			}
			var esq = select.BuildEsq(UserConnection);
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"SysAdminUnitTypeValue", Terrasoft.Core.DB.SysAdminUnitType.User));
			EntityCollection entities = esq.GetEntityCollection(UserConnection);
			return entities.Select(x => x.PrimaryColumnValue).ToArray();
		}

		/// <summary>
		/// Validate user password.
		/// </summary>
		/// <param name="userName">User name.</param>
		private void ValidateUserPassword(string userName) {
			changedValues.TryGetValue("UserPassword", out object userPassworColumnValue);
			if (userPassworColumnValue == null) {
				return;
			}
			string result = ValidatePassword(userName, (string)userPassworColumnValue);
			if (result.IsNotEmpty()) {
				throw new SecurityException(result);
			}
		}

		private void ValidateEmailDomain(string email) {
			var emailDomainValidator = ClassFactory.Get<IExternalUserEmailDomainValidator>();
			if (!emailDomainValidator.IsValidEmailDomainForExternalUser(email)) {
				throw new SecurityException(new LocalizableString(UserConnection.Workspace.ResourceStorage,
					"AdministrationServiceUsers",
					"LocalizableStrings.EmailDomainIsRestrictedOnSaveExceptionMessage.Value"));
			}
		}

		private void ValidateContactEmailDomains(ISet<string> emails) {
			var emailDomainValidator = ClassFactory.Get<IExternalUserEmailDomainValidator>();
			if (!emailDomainValidator.ShouldValidateEmailDomainForExternalUser()) {
				return;
			}
			if (!emailDomainValidator.IsValidEmailDomainForExternalUser(emails)) {
				throw new SecurityException(new LocalizableString(UserConnection.Workspace.ResourceStorage,
					"AdministrationServiceUsers",
					"LocalizableStrings.CommunicationOptionEmailDomainIsRestrictedOnSaveExceptionMessage.Value"));
			}
		}

		private string GetEmail(bool isNew, Entity sysAdminUnit) {
			string email;
			if (!changedValues.TryGetValue("Email", out var result)) {
				email = isNew 
					? string.Empty
					: sysAdminUnit.GetTypedColumnValue<string>("Email");
			} else {
				email = result?.ToString();
			}
			return email;
		}

		private ISet<string> GetContactEmails(bool isNew, Entity sysAdminUnit) {
			Guid contactId;
			if (!changedValues.TryGetValue("Contact", out var result)) {
				if (isNew) {
					return null;
				}
				contactId = sysAdminUnit.GetTypedColumnValue<Guid>("ContactId");
			} else {
				contactId = new Guid(result.ToString());
			}
			var externalUserContactHelper = ClassFactory.Get<IExternalUserContactHelper>();
			return externalUserContactHelper.GetContactEmailsByContactId(contactId, true);
		}

		private bool IsExternalUser(bool isNew, Entity sysAdminUnit) {
			UserType connectionType;
			if (!changedValues.TryGetValue("ConnectionType", out var result)) {
				connectionType = isNew
					? UserType.General
					: sysAdminUnit.GetTypedColumnValue<UserType>("ConnectionType");
			} else {
				Enum.TryParse(result.ToString(), out connectionType);
			}
			return connectionType == UserType.SSP;
		}

		private bool IsTechnicalUser(Entity vwSysAdminUnit) {
			var sysAdminUnitTypeId = vwSysAdminUnit.GetTypedColumnValue<Guid>("SysAdminUnitTypeId");
			EntitySchema sysAdminUnitTypeSchema = UserConnection.EntitySchemaManager.GetInstanceByName("SysAdminUnitType");
			Entity sysAdminUnitType = sysAdminUnitTypeSchema.CreateEntity(UserConnection);
			if (sysAdminUnitType.FetchFromDB(sysAdminUnitTypeId)) {
				var value = sysAdminUnitType.GetTypedColumnValue<int>("Value");
				return value == (int)Core.DB.SysAdminUnitType.TechnicalUser;
			}
			return false;
		}

		private bool IsTechnicalUser(Guid sysAdminUnitId) {
			EntitySchema sysAdminUnitSchema = UserConnection.EntitySchemaManager.GetInstanceByName("VwSysAdminUnit");
			Entity sysAdminUnit = sysAdminUnitSchema.CreateEntity(UserConnection);
			return sysAdminUnit.FetchFromDB(sysAdminUnitId) && IsTechnicalUser(sysAdminUnit);
		}

		private void ValidateSingleRoleAssignment(Guid userId, Guid roleId) {
			if(roleId == rootRoleId && IsTechnicalUser(userId)) {
				string message = new LocalizableString(UserConnection.Workspace.ResourceStorage,
					"AdministrationServiceUsers",
					"LocalizableStrings.CannotIncludeTechnicalUserInAllEmployees.Value");
				throw new InvalidOperationException(message);
			}
		}

		private void ValidateMultipleRoleAssignment(Guid userId, List<object> roleIds) {
			bool isTechnicalUser = IsTechnicalUser(userId);
			if (isTechnicalUser && roleIds.Any(roleId => roleId != null && new Guid(roleId.ToString()) == rootRoleId)) {
			string message = new LocalizableString(UserConnection.Workspace.ResourceStorage,
				"AdministrationServiceUsers",
				"LocalizableStrings.CannotIncludeTechnicalUserInAllEmployees.Value");
				throw new InvalidOperationException(message);
			}
		}

		private bool GetCallLicenseRedistribution() {
			return Features.GetIsEnabled<UseRoleBasedLicenseDistribution>() &&
				SysSettingConfiguration.GetValue(UserConnection, "RedistributeLicensesOnRoleChanges", false);
		}

		private void RedistributeUserLicenses(string userId) {
			if (!GetCallLicenseRedistribution()) {
				return;
			}
			AddUserAvailableLicences(userId);
		}

		private void RedistributeUsersLicenses(List<object> userIdList) {
			if (!GetCallLicenseRedistribution()) {
				return;
			}
			if (userIdList.IsNullOrEmpty()) {
				return;
			}
			foreach (object userId in userIdList) {
				AddUserAvailableLicences(userId);	
			}
		}

		private void CallRedistributeLicensesProcess(Guid roleId) {
			var processParameters = new Dictionary<string, object> {
				["RedistributeLicencesForSpecificRole"] = true,
				["RedistributeManuallyAssignedLicences"] = false,
				["RoleId"] = roleId
			};
			SystemUserConnection.RunProcess("ScheduleLicensesRedistribution", processParameters);
		}

		private void AddUserAvailableLicences(object userIdObject) {
			Guid userId = GetGuidFromObject(userIdObject);
			if (userId.Equals(Guid.Empty) || IsTechnicalUser(userId)) {
				return;
			}
			UserConnection.AppConnection.LicManager.AddUserAvailableLicences(userId, null, false);
		}
		
		private void RedistributeRolesLicenses(List<object> roleIds) {
			if (!GetCallLicenseRedistribution()) {
				return;
			}
			if (roleIds.IsNullOrEmpty()) {
				return;
			}
			foreach (object roleIdObject in roleIds) {
				Guid roleId = GetGuidFromObject(roleIdObject);
				if (roleId.Equals(Guid.Empty)) {
					continue;
				}
				CallRedistributeLicensesProcess(roleId);	
			}
		}

		private void RedistributeRoleLicenses(string roleId) {
			if (!GetCallLicenseRedistribution()) {
				return;
			}
			Guid roleIdGuid = Guid.Parse(roleId);
			CallRedistributeLicensesProcess(roleIdGuid);
		}

		private static Guid GetGuidRoleFromObject(object roleId) {
			if (roleId == null) {
				return Guid.Empty;
			}
			return Guid.TryParse(roleId.ToString(), out Guid guidValue) ? guidValue : Guid.Empty;
		}

		private Guid GetSysCultureByLanguageId(Guid sysLanguageId) {
			var sysCulture = new SysCulture(UserConnection);
			var conditions = new Dictionary<string, object>() {
				{ "Language", sysLanguageId }
			};
			if (sysCulture.FetchFromDB(conditions)) {
				return sysCulture.PrimaryColumnValue;
			}
			var errorMessage = new LocalizableString(UserConnection.Workspace.ResourceStorage,
				"AdministrationServiceUsers",
				"LocalizableStrings.CannotFindSysCultureByLanguageIdMessage.Value");
			errorMessage = string.Format(errorMessage, sysLanguageId);
			throw new CultureNotFoundException(errorMessage);
		}

		private void SetTimeZoneId(TechnicalUserInfoDto userInfoDto,
				Dictionary<string, object> technicalUserColumnValues) {
			var timeZoneId = userInfoDto.TimeZoneId != default ? userInfoDto.TimeZoneId : GetTimeZoneId();
			technicalUserColumnValues.Add("TimeZone", timeZoneId);
		}

		private Guid GetTimeZoneId() {
			if (SysSettingConfiguration.TryGetValue(UserConnection, "DefaultTimeZone", out var defaultTimeZoneId) 
					&& defaultTimeZoneId != null) {
				return (Guid)defaultTimeZoneId;
			}
			var timeZone = new TimeZone(UserConnection);
			var conditions = new Dictionary<string, object> {
				{ "Code", "UTC" }
			};
			if (timeZone.FetchFromDB(conditions)) {
				return timeZone.PrimaryColumnValue;
			}
			var errorMessage = new LocalizableString(UserConnection.Workspace.ResourceStorage,
				"AdministrationServiceUsers",
				"LocalizableStrings.CannotFindIdForUtcTimeZone.Value");
			errorMessage = string.Format(errorMessage);
			throw new TimeZoneNotFoundException(errorMessage);
		}

		private void CheckSecondFactorRequirement(List<object> roleIdList) {
			foreach (var roleId in roleIdList) {
				if (new Guid(roleId.ToString()) == sysAdminsRoleId) {
					_twoFactorAuthorizationEngine.Value.CheckAuth();
				}
			}
		}

		private bool ValidateTechnicalUserUniqueName(TechnicalUserInfoDto userInfoDto) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SysAdminUnit");
			esq.AddColumn("Name");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.NotEqual, "Id", userInfoDto.Id));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Name", userInfoDto.Name));
			EntityCollection entities = esq.GetEntityCollection(UserConnection);
			return !entities.Any();
		}

		#endregion

		#region Methods: Protected
		/// <summary>
		/// ######### ###### ################# # ##### "############" #, #### 
		/// ### ##### ############, ######### ### # ######### ####.
		/// </summary>
		/// <param name="roleId">####, # ####### ##### ######## ##### ############.</param>
		protected void SaveUser(object roleId) {
			bool isNew = false;
			object primaryColumnValue;
			changedValues.TryGetValue("Id", out primaryColumnValue);
			changedValues.TryGetValue("SynchronizeWithLDAP", out object isSynchronizeWithLDAP);
			EntitySchema entitySchema = UserConnection.EntitySchemaManager.GetInstanceByName("VwSysAdminUnit");
			Entity entity = entitySchema.CreateEntity(UserConnection);
			isNew = !entity.FetchFromDB(primaryColumnValue);
			string userName = isNew ? null : (string)entity.GetColumnValue("Name");
			if (IsExternalUser(isNew, entity)) {
				var email = GetEmail(isNew, entity);
				ValidateEmailDomain(email);
				ISet<string> contactEmails = GetContactEmails(isNew, entity);
				if (contactEmails.IsNotNullOrEmpty()) {
					ValidateContactEmailDomains(contactEmails);
				}
			}
			if (isSynchronizeWithLDAP == null || !(bool)isSynchronizeWithLDAP) {
				ValidateUserPassword(userName);
			}
			if (isNew) {
				entity.SetDefColumnValues();
			}
			bool sensitiveColumnsChanged = false;
			foreach (KeyValuePair<string, object> item in changedValues) {
				EntitySchemaColumn column = entitySchema.Columns.GetByName(item.Key);
				object columnValue = item.Value;
				if ((column.DataValueType is DateTimeDataValueType) && (item.Value != null)) {
					columnValue = DataTypeUtilities.ValueAsType<DateTime>(item.Value);
				}
				entity.SetColumnValue(column.ColumnValueName, columnValue);
				if (column.ColumnValueName == "Active" && (columnValue is bool value) && value) {
					string primaryColumnTextValue = primaryColumnValue as string;
					if(Guid.TryParse(primaryColumnTextValue, out Guid id)) {
						_twoFactorAuthorizationEngine.Value.UnblockUser(id);
					}
				}
				sensitiveColumnsChanged |= IsSensitiveDataColumn(item.Key);
			}
			Guid roleGuid = GetGuidRoleFromObject(roleId);
			if(IsTechnicalUser(entity) && roleGuid == rootRoleId) {
				string message = new LocalizableString(UserConnection.Workspace.ResourceStorage,
					"AdministrationServiceUsers",
					"LocalizableStrings.CannotIncludeTechnicalUserInAllEmployees.Value");
				throw new InvalidOperationException(message);
			}
			if (!isNew) {
				CheckTwoFactorOnUserSave(primaryColumnValue, entity, sensitiveColumnsChanged);
			}
			entity.Save();
			if (!isNew) {
				return;
			}
			if (roleGuid != Guid.Empty) {
				AddUserInRole(entity.PrimaryColumnValue, roleId);	
			} else if (IsTechnicalUser(entity)) {
				ActualizeAdminUnitInRole();
			}
		}

		#endregion Methods: Protected

		#region Methods: Public

		/// <summary>
		/// ######### ##### ###. ##### # ############## #####.
		/// </summary>
		/// <param name="orgRoleIds">############### ####.</param>
		/// <param name="funcRoleId">############## ####.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "AddFuncRoleInOrgRoles", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string AddFuncRoleInOrgRoles(string orgRoleIds, string funcRoleId) {
			string errorMessage = string.Empty;
			List<object> roleIdList = Json.Deserialize<List<object>>(orgRoleIds);
			try {
				UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManageAdministration");
				foreach (var roleId in roleIdList) {
					AddFuncRoleInOrgRole(roleId, funcRoleId);
				}
				RedistributeRolesLicenses(roleIdList);
			} catch (Exception e) {
				errorMessage = e.Message;
			}
			return errorMessage;
		}

		/// <summary>
		/// ######### ##### ############## ##### # ###. #####.
		/// </summary>
		/// <param name="orgRoleId">############### ####.</param>
		/// <param name="funcRoleIds">############### ###### ############### ############## #####.</param>
		/// <returns>##### ##########, #### ### #### ##########, ##### ###### ######.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "AddFuncRolesInOrgRole", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string AddFuncRolesInOrgRole(string orgRoleId, string funcRoleIds) {
			string errorMessage = string.Empty;
			List<object> roleIdList = Json.Deserialize<List<object>>(funcRoleIds);
			try {
				UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManageAdministration");
				foreach (var roleId in roleIdList) {
					AddFuncRoleInOrgRole(orgRoleId, roleId);
				}
				RedistributeRoleLicenses(orgRoleId);
			} catch (Exception e) {
				errorMessage = e.Message;
			}
			return errorMessage;
		}

		/// <summary>
		/// ######### ############ # ####.
		/// </summary>
		/// <param name="roleIds">####, # ####### ##### ######## ############.</param>
		/// <param name="userId">############# ############.</param>
		/// <returns>##### ##########, #### ### #### ##########, ##### ###### ######.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "AddUserRoles", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string AddUserRoles(string roleIds, string userId) {
			string errorMessage = string.Empty;
			List<object> roleIdList = Json.Deserialize<List<object>>(roleIds);
				try {
					UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManageAdministration");
					ValidateMultipleRoleAssignment(new Guid(userId), roleIdList);
					CheckSecondFactorRequirement(roleIdList);
					foreach (var roleId in roleIdList) {
						AddUserInRole(userId, roleId);
					}
					RedistributeUserLicenses(userId);
				} catch (Exception e) {
					errorMessage = e.Message;
				}
			return errorMessage;
		}

		/// <summary>
		/// ####### ### ######## ############.
		/// </summary>
		/// <param name="jsonObject">############### ###### ########## ####### ##### "VwSysAdminUnit".</param>
		/// <param name="roleId">####, # ####### ##### ######## ##### ############.</param>
		/// <returns>##### ##########, #### ### #### ##########, ##### ###### ######.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "UpdateOrCreateUser", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string UpdateOrCreateUser(string jsonObject, string roleId) {
			string errorMessage = string.Empty;
			changedValues = Json.Deserialize<Dictionary<string, object>>(jsonObject);
			changedValues.TryGetValue("Id", out var targetUserId);
			var changedColumns = string.Join(", ", changedValues.Keys);
			var initiator = UserConnection.CurrentUser?.Name ?? "unknown";
			var hasRoleId = !string.IsNullOrEmpty(roleId);
			if (hasRoleId) {
				_log.InfoFormat(
					"UpdateOrCreateUser invoked. TargetUserId={0}, RoleId={1}, ChangedColumns=[{2}], InitiatedBy={3}",
					targetUserId, roleId, changedColumns, initiator);
			} else {
				_log.InfoFormat(
					"UpdateOrCreateUser invoked. TargetUserId={0}, ChangedColumns=[{1}], InitiatedBy={2}",
					targetUserId, changedColumns, initiator);
			}
			try {
				UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManageAdministration");
				SaveUser(roleId);
				if (hasRoleId) {
					_log.InfoFormat(
						"UpdateOrCreateUser succeeded. TargetUserId={0}, RoleId={1}",
						targetUserId, roleId);
				} else {
					_log.InfoFormat(
						"UpdateOrCreateUser succeeded. TargetUserId={0}",
						targetUserId);
				}
			}
			catch (Exception e) {
				if (hasRoleId) {
					_log.ErrorFormat(
						"UpdateOrCreateUser failed. TargetUserId={0}, RoleId={1}.",
						e, targetUserId, roleId);
				} else {
					_log.ErrorFormat(
						"UpdateOrCreateUser failed. TargetUserId={0}.",
						e, targetUserId);
				}
				errorMessage = e.Message;
			}
			return errorMessage;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "UpdateOrCreateTechnicalUser", BodyStyle = WebMessageBodyStyle.Bare,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string UpdateOrCreateTechnicalUser(TechnicalUserInfoDto userInfoDto) {
			string errorMessage = string.Empty;
			var roleId = string.Empty;
			var technicalUserColumnValues = new Dictionary<string, object> {
				{ "Id", userInfoDto.Id },
				{ "Name", userInfoDto.Name },
				{ "Active", userInfoDto.Active },
				{ "SysAdminUnitType", BaseConsts.TechnicalUserSysAdminUnitTypeId},
				{ "UserConnectionType", Guid.Parse("df8ff7a2-c9bf-4f28-80b1-ed16fa77818d")},
				{ "ConnectionType", 0 }
			};
			if (!ValidateTechnicalUserUniqueName(userInfoDto)) {
				return new LocalizableString(UserConnection.Workspace.ResourceStorage,
					"AdministrationServiceUsers",
					"LocalizableStrings.CannotSaveTechnicalUserWithSameName.Value");
			}
			if (userInfoDto.SysLanguageId != default) {
				var sysCultureId = GetSysCultureByLanguageId(userInfoDto.SysLanguageId);
				technicalUserColumnValues.Add("SysCulture", sysCultureId);
			}
			if (userInfoDto.ContactId != default) {
				technicalUserColumnValues.Add("Contact", userInfoDto.ContactId);
			}
			SetTimeZoneId(userInfoDto, technicalUserColumnValues);
			changedValues = technicalUserColumnValues;
			try {
				UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManageAdministration");
				UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManageTechnicalUsers");
				SaveUser(roleId);
			} catch (Exception e) {
				errorMessage = e.Message;
			}
			return errorMessage;
		}

		/// <summary>
		/// ######### ############# # ####.
		/// </summary>
		/// <param name="roleId">####, # ####### ##### ######## ############.</param>
		/// <param name="userIds">############### ###### ############### #############,
		/// ####### ########## ######## # ######### ####.</param>
		/// <returns>##### ##########, #### ### #### ##########, ##### ###### ######.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "AddUsersInRole", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string AddUsersInRole(string roleId, string userIds) {
			string errorMessage = string.Empty;
			List<object> userIdList = Json.Deserialize<List<object>>(userIds);
			try {
				UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManageAdministration");
				if(new Guid(roleId) == rootRoleId) {
					foreach(var userId in userIdList) {
						ValidateSingleRoleAssignment(new Guid(userId.ToString()), new Guid(roleId));
					}
				}
				AddUsersInRole(userIdList, roleId);
				RedistributeUsersLicenses(userIdList);
			} catch (Exception e) {
				errorMessage = e.Message;
			}
			return errorMessage;
		}

		/// <summary>
		/// ######### #### ############.
		/// </summary>
		/// <param name="recordId">############# ########## ######.</param>
		/// <param name="roleId">####, # ####### ##### ######## ############.</param>
		/// <param name="userId">############# ############.</param>
		/// <returns>##### ##########, #### ### #### ##########, ##### ###### ######.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "SaveUsersInRole", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string SaveUsersInRole(string recordId, string roleId, string userId) {
			string errorMessage = string.Empty;
			try {
				UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManageAdministration");
				ValidateSingleRoleAssignment(new Guid(userId), new Guid(roleId));
				if (string.IsNullOrEmpty(recordId)) {
					AddUserInRole(userId, roleId);
				} else {
					ChangeUserInRole(recordId, roleId, userId);
				}
				RedistributeUserLicenses(userId);
			} catch (Exception e) {
				errorMessage = e.Message;
			}
			return errorMessage;
		}

		/// <summary>
		/// ####### ############# ## ####.
		/// </summary>
		/// <param name="roleIds">############### ###### ############### #####,
		/// ## ####### ########## ####### #############.</param>
		/// <param name="userIds">############### ###### ############### #############,
		/// ####### ########## ####### ## ######### #####.</param>
		/// <param name="recordIds">############### ###### ############### ####### SysUserInRole.</param>
		/// <returns>############### ######, ## ########## Success, DeletedItems # ExceptionMessage.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "RemoveUsersInRoles", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string RemoveUsersInRoles(string roleIds, string userIds, string recordIds) {
			string exceptionMessage = string.Empty;
			bool success = false;
			List<object> userIdList = Json.Deserialize<List<object>>(userIds);
			List<object> roleIdList = Json.Deserialize<List<object>>(roleIds);
			List<object> recordIdList = Json.Deserialize<List<object>>(recordIds);
			List<Guid> guids = new List<Guid>();
			try {
				UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManageAdministration");
				if (recordIdList != null && recordIdList.Count > 0) {
					RemoveUserInRoles(recordIdList, guids, out userIdList);
				} else {
					RemoveUsersInRoles(userIdList, roleIdList, guids);
				}
				RedistributeUsersLicenses(userIdList);	
				success = true;
			} catch (Exception e) {
				exceptionMessage = e.Message;
			}
			var returnObject = new {
				Success = success,
				DeletedItems = guids,
				ExceptionMessage = exceptionMessage
			};
			return JsonConvert.SerializeObject(returnObject);
		}

		/// <summary>
		/// Modify user connection type on specified.
		/// </summary>
		/// <param name="userId">User Id.</param>
		/// <param name="connectionType">User connection type 0 - General, 1 - SSP.</param>
		/// <returns>Serialized object with properties Success, ExceptionMessage.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "ChangeUserConnectionType", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string ChangeUserConnectionType(string userId, string connectionType) {
			var exceptionMessage = string.Empty;
			var success = false;
			try {
				var connectionTypeValue = Int32.Parse(connectionType);
				var userIdValue = Guid.Parse(userId);
				UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManageAdministration");
				if(IsTechnicalUser(userIdValue) && connectionTypeValue == 1) {
					string message = new LocalizableString(UserConnection.Workspace.ResourceStorage,
						"AdministrationServiceUsers",
						"LocalizableStrings.CannotSaveExternalTechnicalUser.Value");
					throw new InvalidOperationException(message);
				}
				RemoveUserInAllRoles(userIdValue);
				AddUserInRole(userIdValue, GetParentRoleByConnectionType(connectionTypeValue));
				changedValues = new Dictionary<string, object>
				{
					{ "Id", userIdValue },
					{ "ConnectionType", connectionTypeValue },
				};
				if (IsUserConnectionTypeGeneral(connectionTypeValue)) {
					changedValues.Add("Active", false);
				}
				SaveUser(null);
				success = true;
			} catch (Exception e) {
				exceptionMessage = e.Message;
			}
			var returnObject = new {
				Success = success,
				ExceptionMessage = exceptionMessage
			};
			return JsonConvert.SerializeObject(returnObject);
		}

		/// <summary>
		/// ####### #############.
		/// </summary>
		/// <param name="userIds">############### ###### ############### ############# ### ########</param>
		/// <returns>############### ######, ## ########## Success, IsSecurityException # ExceptionMessage.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "DeleteUser", BodyStyle = WebMessageBodyStyle.Wrapped,
		RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string DeleteUser(string userId) {
			string result = string.Empty;
			bool success = false;
			bool isSecurityException = false;
			string exceptionMessage = null;
			Guid userGuid = Guid.Parse(userId);
			try {
				UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManageAdministration");
				CheckCanDeleteUser(userGuid);
				DeleteUser(userGuid);
				success = true;
			} catch (SecurityException e) {
				isSecurityException = true;
				exceptionMessage = e.Message;
			} catch (Exception e) {
				exceptionMessage = e.Message;
			}
			var returnObject = new {
				Success = success,
				IsSecurityException = isSecurityException,
				ExceptionMessage = exceptionMessage
			};
			return JsonConvert.SerializeObject(returnObject);
		}

		/// <summary>
		/// Returns user identifiers by query filters.
		/// </summary>
		/// <param name="filterConfigs">Serialized filters config.</param>
		/// <returns>User identifiers.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetUserIds", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string GetUserIds(string filtersConfig = null) {
			Guid[] primaryColumnValues = new Guid[0];
			string exceptionMessage = string.Empty;
			bool success = false;
			try {
				UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManageAdministration");
				primaryColumnValues = InnerGetUserIds(filtersConfig);
				success = true;
			} catch (Exception e) {
				exceptionMessage = e.Message;
			}
			var returnObject = new {
				Success = success,
				UserIds = primaryColumnValues,
				ExceptionMessage = exceptionMessage
			};
			return JsonConvert.SerializeObject(returnObject);
		}

		
		/// <summary>
		/// Returns if the user is blocked.
		/// </summary>
		/// <param name="userId">User identifier.</param>
		/// <returns>True if user is blocked, otherwise - false.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetIsUserBlocked", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public bool GetIsUserBlocked(string userId) {
			Guid userGuid = Guid.Parse(userId);
			var blockedUserSelect =
				new Select(SystemUserConnection)
					.Column(Column.Parameter(1))
				.From("SysAdminUnit")
				.Where("Id").IsEqual(Column.Parameter(userGuid))
				.And("UnblockTime").IsGreater(Column.Parameter(DateTime.UtcNow)) as Select;
			bool isUserBlocked;
			using (DBExecutor dbExecutor = SystemUserConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = blockedUserSelect.ExecuteReader(dbExecutor)) {
					isUserBlocked = dataReader.Read();
				}
			}
			return isUserBlocked || _twoFactorAuthorizationEngine.Value.GetIsUserBlocked(userGuid);
		}

		/// <summary>
		/// Unblocks user, blocked after several unsuccessful password attempts.
		/// </summary>
		/// <param name="userIds">User identifier</param>
		/// <returns>Serialized object, with properties Success, IsSecurityException # ExceptionMessage.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "UnblockUser", BodyStyle = WebMessageBodyStyle.Wrapped,
		RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string UnblockUser(string userId) {
			string result = string.Empty;
			bool success = false;
			bool isSecurityException = false;
			string exceptionMessage = null;
			try {
				Guid userGuid = Guid.Parse(userId);
				UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManageAdministration");
				new Update(UserConnection, "SysAdminUnit")
					.Set("UnblockTime", Column.Parameter(null, "DateTime"))
					.Where("Id").IsEqual(Column.Parameter(userGuid)).Execute();
				_twoFactorAuthorizationEngine.Value.UnblockUser(userGuid);
				success = true;
			} catch (SecurityException e) {
				isSecurityException = true;
				exceptionMessage = e.Message;
			} catch (Exception e) {
				exceptionMessage = e.Message;
			}
			var returnObject = new {
				Success = success,
				IsSecurityException = isSecurityException,
				ExceptionMessage = exceptionMessage
			};
			return JsonConvert.SerializeObject(returnObject);
		}

		#endregion Methods: Public

	}

	#endregion Class: AdministrationService

}
