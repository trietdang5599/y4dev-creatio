namespace Terrasoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Data;
	using System.IO;
	using System.Globalization;
	using System.Linq;
	using System.Text;
	using System.ServiceModel;
	using System.ServiceModel.Web;
	using System.Web.SessionState;
	using Terrasoft.Common;
	using Terrasoft.Common.Json;
	using Terrasoft.Core.Licensing;
	using Creatio.FeatureToggling;
	using Terrasoft.Core.Feature;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Newtonsoft.Json;
	using Terrasoft.Core.ServiceModelContract;
	using LicType = Terrasoft.Core.Configuration.SysLicType;
	using SysSettingConfiguration = Core.Configuration.SysSettings;

	#region Class: RoleNotFoundException

	[Serializable]
	public class RoleNotFoundException : ApplicationException
	{
		public RoleNotFoundException(UserConnection userConnection, Guid roleId) 
			: base(string.Format(new LocalizableString(userConnection.Workspace.ResourceStorage,
				"AdministrationServiceLicenses", "LocalizableStrings.RoleNotFoundException.Value"), roleId)) {

		}
	}

	#endregion

	#region Class: LicenseItem

	public class LicenseItem
	{
		/// <summary>
		/// License package ID.
		/// </summary>
		public Guid Id {
			get;
			set;
		}

		/// <summary>
		/// License type.
		/// </summary>
		public LicType Type {
			get;
			set;
		}

		/// <summary>
		/// License package name.
		/// </summary>
		public string Caption {
			get;
			set;
		}

		/// <summary>
		/// Indicates whether a license is available for selection.
		/// </summary>
		public bool Enabled {
			get;
			set;
		}

		/// <summary>
		/// Indicates whether a license has been checked.
		/// </summary>
		public bool Checked {
			get;
			set;
		}

		/// <summary>
		/// Number of available licenses.
		/// </summary>
		public int AvailableCount {
			get;
			set;
		}

		/// <summary>
		/// Number of paid licenses.
		/// </summary>
		public int PaidCount {
			get;
			set;
		}

		/// <summary>
		/// Number of licenses distributed.
		/// </summary>
		public int UsedCount {
			get;
			set;
		}

		/// <summary>
		/// Licensing source.
		/// </summary>
		public string SysLicSource {
			get;
			set;
		}

	}

	#endregion
	
	#region Class: AdministrationService

	public partial class AdministrationService : IReadOnlySessionState
	{

		#region Constants: Private

		private const string ServerLicPackageOperation = "IsServerLicPackage";

		#endregion

		#region Properties: Private

		private EntityCollection _availablePackages;
		/// <summary>
		/// List of licensing products available to the system userRole.
		/// </summary>
		private EntityCollection AvailablePackages {
			get {
				return _availablePackages ?? (_availablePackages = UserConnection.LicHelper.GetAvailablePackages());
			}
		}

		#endregion Properties: Private

		#region Methods: Private

		/// <summary>
		/// Returns whether the userRole is active.
		/// </summary>
		/// <param name="userId">User ID.</param>
		/// <returns>The "Active" sign for an entry in the SysAdminUnit table,
		/// obtained by userId.</returns>
		private bool IsUserActive(Guid userId) {
			Select selectIsActiveUser =
				new Select(UserConnection)
				.Column("Active")
				.From("SysAdminUnit")
				.Where("Id").IsEqual(Column.Parameter(userId))
				as Select;
			return selectIsActiveUser.ExecuteScalar<bool>();
		}

		/// <summary>
		/// Serializes the object.
		/// </summary>
		/// <param name="obj">The object that needs to be serialized.</param>
		/// <param name="quoteName">Indicates whether orgRole not to use quotes in property names.</param>
		/// <returns>Serialized string.</returns>
		private static string Serialize(object obj, bool quoteName) {
			using (var sw = new StringWriter(CultureInfo.InvariantCulture)) {
				using (var writer = new JsonTextWriter(sw) {
					QuoteName = quoteName
				}) {
					var serializer = new JsonSerializer();
					serializer.Serialize(writer, obj);
				}
				return sw.GetStringBuilder().ToString();
			}
		}

		/// <summary>
		/// Checks whether the userRole has the given license.
		/// </summary>
		/// <param name="userId">User ID.</param>
		/// <param name="licPackageId">License package ID.</param>
		/// <returns>True if the userRole has this license, otherwise false.</returns>
		private bool GetUserHasLicense(Guid userId, Guid licPackageId) {
			var sysLicUserSchemaQuery = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SysLicUser");
			EntitySchemaQueryColumn countColumn = sysLicUserSchemaQuery.AddColumn("Id");
			countColumn.SummaryType = AggregationType.Count;
			IEntitySchemaQueryFilterItem userIdFilter = sysLicUserSchemaQuery.CreateFilterWithParameters(
				FilterComparisonType.Equal, "SysUser", userId);
			IEntitySchemaQueryFilterItem sysPackageIdFilter = sysLicUserSchemaQuery.CreateFilterWithParameters(
				FilterComparisonType.Equal, "SysLicPackage", licPackageId);
			var filter = new EntitySchemaQueryFilterCollection(sysLicUserSchemaQuery, LogicalOperationStrict.And,
				userIdFilter, sysPackageIdFilter);
			sysLicUserSchemaQuery.Filters.Add(filter);
			Entity summary = sysLicUserSchemaQuery.GetSummaryEntity(UserConnection);
			return (summary != null) ? summary.GetTypedColumnValue<int>(countColumn.Name) > 0 : false;
		}

		/// <summary>
		/// Checks the available number of licenses in the product.
		/// </summary>
		/// <param name="sysLicPackageGuid">Licensing product ID.</param>
		/// <returns>Product name if the number of personal issued
		/// licenses exceeds the available number, orgRole empty string otherwise.</returns>
		private string HasLicErrors(Guid sysLicPackageGuid) {
			var sb = new StringBuilder();
			foreach (Entity item in AvailablePackages) {
				Guid sysLicPackageId = item.GetTypedColumnValue<Guid>("SysLicPackageId");
				if (sysLicPackageId == sysLicPackageGuid) {
					string operations = item.GetTypedColumnValue<string>("Operations");
					SysLicType licType = item.GetTypedColumnValue<SysLicType>("LicType");
					if (!operations.Contains("IsServerLicPackage") && licType == SysLicType.Personal &&
						item.GetTypedColumnValue<int>("PersonalLicCount") >=
						item.GetTypedColumnValue<int>("Count")) {
						sb.AppendIfNotEmpty(", ");
						sb.Append(item.GetTypedColumnValue<string>("SysPackageName"));
					}
				}
			}
			return sb.ToString();
		}

		/// <summary>
		/// Adds userRole package license.
		/// </summary>
		/// <param name="userId">User identifier.</param>
		/// <param name="sysPackageId">Licensing package identifier.</param>
		private void AddSysLicUser(Guid userId, Guid sysPackageId) {
			var sysLicSource = Features.GetIsEnabled<UseRoleBasedLicenseDistribution>()
				? SysLicSource.Manual
				: SysLicSource.Default;
			UserConnection.AppConnection.LicManager.AddUserLicense(UserConnection, userId, sysPackageId,
				sysLicSource);
		}

		/// <summary>
		/// Deletes userRole package license.
		/// </summary>
		/// <param name="userId">User identifier.</param>
		/// <param name="sysPackageId">Licensing package identifier.</param>
		private void DeleteSysLicUser(Guid userId, Guid sysPackageId) {
			UserConnection.AppConnection.LicManager.DeleteUserLicense(UserConnection, userId, sysPackageId);
		}

		/// <summary>
		/// Creates a subquery to obtain the number of licenses distributed to changedUsers. 
		/// </summary>
		/// <returns>Subquery to obtain the number of distributed licenses.</returns>
		private Select GenerateSelectForCase() {
			 return 
				new Select(UserConnection)
					.Column(Func.Count("SysLicUser", "Id"))
				.From("SysLicUser")
				.InnerJoin("SysAdminUnit")
					.On("SysAdminUnit", "Id").IsEqual("SysLicUser", "SysUserId")
				.Where("lic", "SysLicPackageId").IsEqual("SysLicPackageId")
				.And("SysLicUser", "Active").IsEqual(Column.Parameter(true))
				.And("SysAdminUnit", "Active").IsEqual(Column.Parameter(true)) as Select;
		}

		/// <summary>
		/// Creates a condition for CASE that compares the received parameter to one. 
		/// </summary>
		/// <param name="columnExpression">Parameter to be inserted into the left side of the expression.</param>
		/// <returns>Condition for checking the accepted parameter for equality to one.</returns>
		private QueryCondition CreateQueryCondition(QueryColumnExpression columnExpression) {
			var queryCondition = new QueryCondition(QueryConditionType.Greater) {
				LeftExpression = columnExpression
			};
			queryCondition.IsEqual(Column.Const(1));
			return queryCondition;
		}

		/// <summary>
		/// Generates a CASE expression based on the parameters it accepts.
		/// </summary>
		/// <param name="conditionForCaseExpression">A parameter inserted into the left side of the
		/// WHEN condition.</param>
		/// <param name="expressionForThenInCase">The expression that will be executed in the THEN branch.</param>
		/// <param name="expressionForElseInCase">The expression that will be executed in the ELSE branch.</param>
		/// <returns>CASE expression.</returns>
		private QueryCase GenerateCaseForLicQuery(QueryColumnExpression conditionForCaseExpression, 
				QueryColumnExpression expressionForThenInCase, QueryColumnExpression expressionForElseInCase) {
			var queryCase = new QueryCase();
			QueryCondition queryCondition = CreateQueryCondition(conditionForCaseExpression);
			queryCase.AddWhenItem(queryCondition, expressionForThenInCase);
			queryCase.SetElseExpression(expressionForElseInCase);
			return queryCase;
		}

		/// <summary>
		/// Generates a CASE expression to obtain the number of available licenses.
		/// </summary>
		/// <returns>CASE expression.</returns>
		private QueryCase GenerateCaseForAvailableLic() {
			Select selectForCase = GenerateSelectForCase();
			return GenerateCaseForLicQuery(new QueryColumnExpression("lic", "LicType"),
				new QueryColumnExpression("lic", "Count"),
				new QueryColumnExpression(ArithmeticOperation.Subtraction, 
					new QueryColumnExpression("lic", "Count"),
					Column.SubSelect(selectForCase)));
		}

		/// <summary>
		/// Generates a CASE expression to determine whether the current license is allocated to the target userRole. 
		/// </summary>
		/// <param name="userId">The ID of the userRole for whom we are checking for a license.</param>
		/// <returns>CASE expression.</returns>
		private QueryCase GenerateCaseForHadLic(Guid userId) {
			Select selectForCase = GenerateSelectForCase();
			selectForCase
				.And("SysUserId").IsEqual(Column.Const(userId));
			return GenerateCaseForLicQuery(new QueryColumnExpression(selectForCase),
				Column.Const(1), Column.Const(0));
		}

		/// <summary>
		/// Returns list of available licenses with license amount 
		/// and presence information for target userRole.
		/// </summary>
		/// <param name="userId">User identifier.</param>
		/// <param name="isNew">Indicates if userRole is new orgRole not.</param>
		/// <returns>Licenses list.</returns>
		private EntityCollection GetAvailableLic(Guid userId, bool isNew) {
			QueryCase caseForAvailable = GenerateCaseForAvailableLic();
			var select =
				new Select(UserConnection)
					.Column("SysLicPackageId")
					.Column("Count").As("Purchased")
					.Column(Column.SubSelect(GenerateSelectForCase())).As("Used")
					.Column(caseForAvailable).As("Available")
					.Column("licPackage", "Name").As("SysPackageName")
					.Column("licPackage", "Operations").As("PackageOperations")
					.Column("LicType")
				.From("SysLic").As("lic")
				.InnerJoin("SysLicPackage").As("licPackage").On("lic", "SysLicPackageId").IsEqual("licPackage", "Id")
				.Where(new QueryParameter(DateTime.Now.Date)).IsBetween("StartDate").And("DueDate")
				.OrderByAsc("licPackage", "Name").OrderByDesc("lic", "DueDate") as Select;
			if (!isNew) {
				QueryCase caseForHadLic = GenerateCaseForHadLic(userId);
				select
					.Column(caseForHadLic).As("HadLicense");
			}
			if (!UserConnection.GetIsFeatureEnabled("ShowsServerLicensesForUser")) {
				select.And("licPackage", "Operations").Not().IsLike(Column.Parameter($"%{ServerLicPackageOperation}%"));
			}
			EntitySchema licSchema = UserConnection.EntitySchemaManager.GetInstanceByName("SysLic");
			var result = new EntityCollection(UserConnection, licSchema);
			using (DBExecutor executor = UserConnection.EnsureDBConnection()) {
				using (System.Data.IDataReader reader = select.ExecuteReader(executor)) {
					result.Load(reader);
				}
			}
			return result;
		}

		private void SetHighestPriorityPackageChecked(List<LicenseItem> collection, Collection<string> prioritizedLicPackages) {
			if (prioritizedLicPackages == null) {
				return;
			}
			foreach (string licPackageName in prioritizedLicPackages) {
				var priorityPackage = collection.FirstOrDefault(p => p.Caption == licPackageName);
				if (priorityPackage != null && priorityPackage.AvailableCount > 0) {
					priorityPackage.Checked = true;
					return;
				}
			}
		}

		private Dictionary<Guid, SysLicSource> GetPackageSources(Guid userId, bool isNewUser,
				EntityCollection sysLicenses) {
			var result = new Dictionary<Guid, SysLicSource>();
			if (Features.GetIsDisabled<UseRoleBasedLicenseDistribution>() || isNewUser) {
				return result;
			}
			var licPackageIds = sysLicenses
				.Where(licPackage => licPackage.GetTypedColumnValue<int>("HadLicense") == 1)
				.Select(sysLic => sysLic.GetTypedColumnValue<Guid>("SysLicPackageId"))
				.ToArray();
			if (licPackageIds.IsEmpty()) {
				return result;
			}
			var select =
				new Select(UserConnection)
					.Column("Source")
					.Column("SysLicPackageId")
				.From("SysLicUser")
				.Where("SysUserId").IsEqual(Column.Parameter(userId))
					.And("SysLicPackageId").In(Column.Parameters(licPackageIds)) as Select;
			using (DBExecutor executor = UserConnection.EnsureDBConnection()) {
				using (System.Data.IDataReader reader = select.ExecuteReader(executor)) {
					while (reader.Read()) {
						var licPackageId = reader.GetColumnValue<Guid>("SysLicPackageId");
						var licSource = reader.GetColumnValue<SysLicSource>("Source");
						result.Add(licPackageId, licSource);
					}
				}
			}
			return result;
		}

		private Select GetActiveUsersSelect(bool keepManualLicenses) {
			Select usersToValidate =
				new Select(UserConnection)
					.Column("SysAdminUnit", "Id").As("UserId")
				.From("SysAdminUnit");
				
			if (keepManualLicenses) {
				usersToValidate?.LeftOuterJoin("SysLicUser").On("SysAdminUnit", "Id")
					.IsEqual("SysLicUser", "SysUserId").And("SysLicUser", "Source")
					.IsEqual(Column.Parameter(SysLicSource.Manual));
			}
			usersToValidate?	
				.Where("SysAdminUnit", "Active").IsEqual(Column.Parameter(true))
				.And("SysAdminUnit", "SysAdminUnitTypeValue")
				.IsEqual(Column.Parameter(Core.DB.SysAdminUnitType.User));
			if (keepManualLicenses) {
				usersToValidate?.And("SysLicUser", "SysUserId").IsNull();
			}
			return usersToValidate;
		}

		private Select GetUsersInRoleSelect(Guid roleId, bool keepManualLicenses, bool useRoleHierarchy) {
			string userInRolesTableName = useRoleHierarchy ? "SysAdminUnitInRole" : "SysUserInRole";
			string userIdColumnName = useRoleHierarchy ? "SysAdminUnitId" : "SysUserId";
			string roleIdColumnName = useRoleHierarchy ? "SysAdminUnitRoleId" : "SysRoleId";
			Select usersToValidate = 
					new Select(UserConnection)
						.Distinct()
						.Column(userInRolesTableName,userIdColumnName).As("UserId")
						.From(userInRolesTableName)
						.InnerJoin("SysAdminUnit")
						.On(userInRolesTableName, userIdColumnName).IsEqual("SysAdminUnit", "Id")
						.And("SysAdminUnit", "Active").IsEqual(Column.Parameter(true)) as Select;	
			if (keepManualLicenses) {
				usersToValidate?.LeftOuterJoin("SysLicUser").On(userInRolesTableName, userIdColumnName)
					.IsEqual("SysLicUser", "SysUserId").And("SysLicUser", "Source")
					.IsEqual(Column.Parameter(SysLicSource.Manual));
			}
			usersToValidate?.Where(userInRolesTableName, roleIdColumnName).IsEqual(Column.Parameter(roleId));
			if (keepManualLicenses) {
				usersToValidate?.And("SysLicUser", "SysUserId").IsNull();
			}
			return usersToValidate;
		}

		private Select GetSysLicPackageInRoleSelect() {
			return 
				new Select(UserConnection)
					.Column("SysLicPackageInRole", "SysRoleId")
					.Column(Func.Count("SysLicPackageInRole", "SysLicPackageId")).As("licCount")
				.From("SysLicPackageInRole")
				.GroupBy("SysRoleId") as Select;
		}

		private Select GetUsersToValidateSelect(Guid roleId, bool keepManualLicenses, bool useRoleHierarchy) {
			string userInRolesTableName = useRoleHierarchy ? "SysAdminUnitInRole" : "SysUserInRole";
			string userIdColumnName = useRoleHierarchy ? "SysAdminUnitId" : "SysUserId";
			string roleIdColumnName = useRoleHierarchy ? "SysAdminUnitRoleId" : "SysRoleId";
			Select usersInRoleSelect = roleId.IsEmpty()
				? GetActiveUsersSelect(keepManualLicenses)
				: GetUsersInRoleSelect(roleId, keepManualLicenses, useRoleHierarchy);
				
			var checkExpression = Column.SourceColumn("LicensesInRoles", "licCount");
			var havingExpression =
				Func.Sum(Func.IsNull(checkExpression, Column.Const(0)));
			Select query = 
				new Select(UserConnection)
					.Column(userInRolesTableName, userIdColumnName).As("UserId")
				.From(userInRolesTableName)
				.LeftOuterJoin(GetSysLicPackageInRoleSelect()).As("LicensesInRoles")
				.On(userInRolesTableName,roleIdColumnName).IsEqual("LicensesInRoles","SysRoleId")
				.Where(userInRolesTableName,userIdColumnName).In(usersInRoleSelect)
				.GroupBy(userInRolesTableName,userIdColumnName)
				.Having(havingExpression).IsEqual(Column.Parameter(0))
				as Select;
			return query;
		}

		private HashSet<Guid> GetUsersWithoutRoles(bool keepManualLicenses) {
			var result = new HashSet<Guid>();
			Select query = GetActiveUsersSelect(keepManualLicenses);
			query.And("SysAdminUnit", "Id")
				.Not()
				.In(new Select(UserConnection).Distinct().Column("SysUserInRole", "SysUserId").From("SysUserInRole"));
			using (var dbExecutor = UserConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = query.ExecuteReader(dbExecutor)) {
					while (dataReader.Read()) {
						var userId = dataReader.GetColumnValue<Guid>("UserId");
						result.Add(userId);
					}
				}
			}
			return result;
		}

		private string GetUserNameById(Guid userId) {
			Select userNameSelect =
				new Select(UserConnection)
					.Column("Name")
				.From("SysAdminUnit")
				.Where("Id").IsEqual(Column.Parameter(userId)) as Select;
			return userNameSelect?.ExecuteScalar<string>();
		}

		private string GetRoleBasedLicenseValidationMassage(HashSet<Guid> userIds) {
			int totalCount = userIds.Count;
			string[] userNames = userIds.Select(GetUserNameById).OrderBy(name => name).ToArray();
			string template;
			string message;
			switch (totalCount) {
				case 1:
					template = new LocalizableString(UserConnection.Workspace.ResourceStorage,
						"AdministrationServiceLicenses", "LocalizableStrings.InvalidRoleBasedLicenses1.Value");
					message = string.Format(template, userNames[0]);
					break;
				case 2:
					template = new LocalizableString(UserConnection.Workspace.ResourceStorage,
						"AdministrationServiceLicenses", "LocalizableStrings.InvalidRoleBasedLicenses2.Value");
					message = string.Format(template, userNames[0], userNames[1]);
					break;
				default:
					template = new LocalizableString(UserConnection.Workspace.ResourceStorage,
						"AdministrationServiceLicenses", "LocalizableStrings.InvalidRoleBasedLicenses.Value");
					message = string.Format(template, userNames[0], userNames[1], totalCount - 2);
					break;
			}
			return message;
		}

		private BaseResponse GetRoleBasedLicenseResult(string roleId, bool keepManualLicenses) {
			var result = new BaseResponse {
				Success = true,
				ErrorInfo = null,
			};
			if (Features.GetIsDisabled<UseRoleBasedLicenseDistribution>()) {
				return result;
			}
			try {
				var userIds = new HashSet<Guid>(); 
				Guid roleIdGuid = Guid.Parse(roleId);
				bool useRoleHierarchy = SysSettingConfiguration
					.GetValue(UserConnection, "UseFullHierarchyDuringLicenseDistribution", false);
				Select usersToValidate = GetUsersToValidateSelect(roleIdGuid, keepManualLicenses, useRoleHierarchy);
				using (var dbExecutor = UserConnection.EnsureDBConnection()) {
					using (IDataReader dataReader = usersToValidate.ExecuteReader(dbExecutor)) {
						while (dataReader.Read()) {
							var userId = dataReader.GetColumnValue<Guid>("UserId");
							userIds.Add(userId);
						}
					}
				}
				if (roleIdGuid.IsEmpty() && !useRoleHierarchy) {
					userIds.AddRange(GetUsersWithoutRoles(keepManualLicenses));
				}
				if (userIds.IsNotEmpty()) {
					result.Success = false;
					result.ErrorInfo = new ErrorInfo {
						Message = GetRoleBasedLicenseValidationMassage(userIds)
					};
				}
				
			} catch (Exception e) {
				result.Success = false;
				result.ErrorInfo = new ErrorInfo {
					ErrorCode = "exception",
					Message = e.Message
				};
			}
			return result;
		}

		private void AddAllParentsInHierarchy(Guid current, Dictionary<Guid, Guid> rolesWithParents, HashSet<Guid> result) {
			if (rolesWithParents.ContainsKey(current)) {
				Guid parent = rolesWithParents[current];
				if (parent.IsNotEmpty()) {
					result.Add(parent);
					AddAllParentsInHierarchy(parent, rolesWithParents, result);	
				}
			} 
		}

		private Dictionary<Guid, HashSet<Guid>> GetFlatRolesHierarchy(Dictionary<Guid, Guid> rolesWithParents) {
			var result = new Dictionary<Guid, HashSet<Guid>>();
			foreach (Guid role in rolesWithParents.Keys) {
				var allRoles = new HashSet<Guid>();
				AddAllParentsInHierarchy(role, rolesWithParents, allRoles);
				result[role] = allRoles;
			}
			return result;
		}

		private Dictionary<Guid, HashSet<Guid>> GetFullRolesHierarchy() {
			Core.DB.SysAdminUnitType[] allowedTypes = {
				Core.DB.SysAdminUnitType.Organisation,
				Core.DB.SysAdminUnitType.Department,
				Core.DB.SysAdminUnitType.Manager,
				Core.DB.SysAdminUnitType.Team,
				Core.DB.SysAdminUnitType.FunctionalRole
			};
			Select allRolesSelect =
				new Select(UserConnection)
					.Column("Id")
					.Column("ParentRoleId")
					.Column("SysAdminUnitTypeValue")
				.From("SysAdminUnit")
				.Where("SysAdminUnitTypeValue").In(Column.Parameters(allowedTypes)) as Select;
			Dictionary<Guid, Guid> rolesWithParents = new Dictionary<Guid, Guid>();
			using (var dbExecutor = UserConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = allRolesSelect.ExecuteReader(dbExecutor)) {
					while (dataReader.Read()) {
						Guid roleId = dataReader.GetColumnValue<Guid>("Id");
						Guid parentId = dataReader.GetColumnValue<Guid>("ParentRoleId");
						rolesWithParents[roleId] = parentId;
					}
				}
			}
			var flatRolesHierarchy = GetFlatRolesHierarchy(rolesWithParents);
			return flatRolesHierarchy;
		}

		private IDictionary<Guid, HashSet<Guid>> GetLinkedRolesHierarchy(CheckUsersWillHaveLicensesDto request) {
			var fullRolesHierarchy = GetFullRolesHierarchy();
			var existingLinkedRoles = new Dictionary<Guid, HashSet<Guid>>();
			Select select =
				new Select(UserConnection)
					.Column("OrgRoleId")
					.Column("FuncRoleId")
				.From("SysFuncRoleInOrgRole") as Select;
			using (var dbExecutor = UserConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = select.ExecuteReader(dbExecutor)) {
					while (dataReader.Read()) {
						Guid orgRoleId = dataReader.GetColumnValue<Guid>("OrgRoleId");
						Guid funcRoleId = dataReader.GetColumnValue<Guid>("FuncRoleId");
						HashSet<Guid> linkedFuncRoles;
						if (existingLinkedRoles.ContainsKey(orgRoleId)) {
							linkedFuncRoles = existingLinkedRoles[orgRoleId];
						} else {
							linkedFuncRoles = new HashSet<Guid>();
							existingLinkedRoles[orgRoleId] = linkedFuncRoles;
						}
						linkedFuncRoles.Add(funcRoleId);						
					}
				}
			}
			var orgRoles = request.OrgRoles.Select(orgRole => Guid.Parse(orgRole)).ToList();
			var funcRoles = request.FuncRoles.Select(funcRole => Guid.Parse(funcRole)).ToList();
			switch (request.ChangeRoleOperationType) {
				case ChangeRoleOperationType.AddFuncRoleToOrgRole:
					AddFuncRoleToOrgRole(existingLinkedRoles, orgRoles, funcRoles);
					break;
				case ChangeRoleOperationType.DeleteFuncRoleFromOrgRole:
					DeleteFuncRoleFromOrgRole(existingLinkedRoles, orgRoles, funcRoles);
					break;
				case ChangeRoleOperationType.AddRolesToUser:
				case ChangeRoleOperationType.DeleteRoleFromUser:
				default:
					break;
			}
			LinkFullRolesHierarchy(fullRolesHierarchy, existingLinkedRoles);
			return fullRolesHierarchy;
		}

		private void LinkFullRolesHierarchy(Dictionary<Guid, HashSet<Guid>> flatRolesHierarchy,
				Dictionary<Guid, HashSet<Guid>> existingLinkedRoles) {
			foreach (var linkedRoles in existingLinkedRoles) {
				var orgRole = linkedRoles.Key;
				var addedFuncRoles = new HashSet<Guid>();
				foreach (var funcRole in linkedRoles.Value) {
					addedFuncRoles.Add(funcRole);
					if (flatRolesHierarchy.ContainsKey(funcRole)) {
						addedFuncRoles.AddRange(flatRolesHierarchy[funcRole]);
					}
				}
				if (flatRolesHierarchy.ContainsKey(orgRole)) {
					flatRolesHierarchy[orgRole].AddRange(addedFuncRoles);
				} else {
					throw new RoleNotFoundException(UserConnection, orgRole);
				}
				foreach (var inheritedCandidate in flatRolesHierarchy) {
					if (inheritedCandidate.Value.Contains(orgRole)) {
						inheritedCandidate.Value.AddRange(addedFuncRoles);
					}
				}
			}
		}

		private void DeleteFuncRoleFromOrgRole(Dictionary<Guid, HashSet<Guid>> existingLinkedRoles, List<Guid> orgRoles,
				List<Guid> funcRoles) {
			foreach (var orgRole in orgRoles) {
				if (!existingLinkedRoles.ContainsKey(orgRole)) {
					continue;
				}
				var linkedFuncRoles = existingLinkedRoles[orgRole];
				foreach (var funcRole in funcRoles) {
					linkedFuncRoles.Remove(funcRole);
				}
			}
		}

		private void AddFuncRoleToOrgRole(Dictionary<Guid, HashSet<Guid>> existingLinkedRoles, List<Guid> orgRoles,
				List<Guid> funcRoles) {
			foreach (var orgRole in orgRoles) {
				if (!existingLinkedRoles.ContainsKey(orgRole)) {
					existingLinkedRoles[orgRole] = new HashSet<Guid>();
				}
				var linkedFuncRoles = existingLinkedRoles[orgRole];
				foreach(var funcRole in funcRoles) {
					linkedFuncRoles.Add(funcRole);
				}
			}
		}

		private string GetLicValidationMessage(IDictionary<Guid, string> affectedUsers) {
			int totalCount = affectedUsers.Count;
			string template;
			string message;
			IList<string> userNames;
			switch (totalCount) {
				case 1:
					var userName = affectedUsers.Values.First();
					template = new LocalizableString(UserConnection.Workspace.ResourceStorage,
						"AdministrationServiceLicenses", "LocalizableStrings.InvalidRoleBasedLicensesRolesChanged1.Value");
					message = string.Format(template, userName);
					break;
				case 2:
					userNames = affectedUsers.Values.OrderBy(name => name).Take(2).ToList();
					template = new LocalizableString(UserConnection.Workspace.ResourceStorage,
						"AdministrationServiceLicenses", "LocalizableStrings.InvalidRoleBasedLicensesRolesChanged2.Value");
					message = string.Format(template, userNames[0], userNames[1]);
					break;
				default:
					userNames = affectedUsers.Values.OrderBy(name => name).Take(2).ToList();
					template = new LocalizableString(UserConnection.Workspace.ResourceStorage,
						"AdministrationServiceLicenses", "LocalizableStrings.InvalidRoleBasedLicensesRolesChanged.Value");
					message = string.Format(template, userNames[0], userNames[1], totalCount - 2);
					break;
			}
			return message;
		}

		private bool GetWillUsersHaveLicensesWhenRolesRelationChanged(CheckUsersWillHaveLicensesDto request,
				out IDictionary<Guid, string> affectedUsers) {
			affectedUsers = new Dictionary<Guid, string>();
			var changedOrgRoles = request.OrgRoles.Select(orgRole => Guid.Parse(orgRole));
			var rolesHierarchy = GetLinkedRolesHierarchy(request);
			var changedOrgRolesWithChildRoles = new HashSet<Guid>(changedOrgRoles);
			foreach (var changedRole in changedOrgRoles) {
				var childOrgRoles = rolesHierarchy.Where(roleNode => roleNode.Value.Contains(changedRole))
					.Select(roleNode => roleNode.Key).ToHashSet();
				changedOrgRolesWithChildRoles.AddRange(childOrgRoles);
			}
			Select usersInChangedRolesSelect = GetUsersInChangedRolesSelect(changedOrgRolesWithChildRoles);
			var usersInChangedRoles = new Dictionary<Guid, HashSet<Guid>>();
			var userNames = new Dictionary<Guid, string>();
			usersInChangedRolesSelect.ExecuteReader(reader => {
				var userId = reader.GetColumnValue<Guid>("SysAdminUnitId");
				var roleId = reader.GetColumnValue<Guid>("SysAdminUnitRoleId");
				var name = reader.GetColumnValue<string>("Name");
				if (!usersInChangedRoles.ContainsKey(userId)) {
					usersInChangedRoles[userId] = new HashSet<Guid>();
				}
				usersInChangedRoles[userId].Add(roleId);
				if (!userNames.ContainsKey(userId)) {
					userNames[userId] = name;
				}
			});
			var result = true;
			var allFuncRoles = new List<Guid>();
			var allFuncRolesSelect =
				new Select(UserConnection)
					.Column("Id")
				.From("SysAdminUnit")
				.Where("SysAdminUnitTypeValue").IsEqual(Column.Parameter(Core.DB.SysAdminUnitType.FunctionalRole)) as Select;
			allFuncRolesSelect.ExecuteReader(reader => {
				allFuncRoles.Add(reader.GetColumnValue<Guid>("Id"));
			});
			foreach (var userInRoles in usersInChangedRoles) {
				var funcRolesToAdd = new HashSet<Guid>();
				HashSet<Guid> userRoles = userInRoles.Value;
				foreach (var userRole in userRoles) {
					var directLinkedFuncRoles = rolesHierarchy[userRole].Where(role => allFuncRoles.Contains(role));
					funcRolesToAdd.AddRange(directLinkedFuncRoles);
				}
				userRoles.AddRange(funcRolesToAdd);
				var licenseRoleMap = GetLicInRoles();
				var userCheckResult = CheckWillUserHaveLicenses(userRoles, licenseRoleMap);
				if (!userCheckResult) {
					affectedUsers.Add(userInRoles.Key, userNames[userInRoles.Key]);
				}
				result &= userCheckResult;
			}
			return result;
		}

		private Select GetUsersInChangedRolesSelect(IEnumerable<Guid> changedOrgRoles) {
			var select =
				new Select(UserConnection)
					.Column("SysAdminUnitId")
					.Column("SysAdminUnitRoleId")
					.Column("User", "Name")
				.From("SysAdminUnitInRole")
				.InnerJoin("SysAdminUnit").As("Role")
					.On("SysAdminUnitInRole", "SysAdminUnitRoleId").IsEqual("Role", "Id")
				.InnerJoin("SysAdminUnit").As("User")
					.On("SysAdminUnitInRole", "SysAdminUnitId").IsEqual("User", "Id")
				.Where("SysAdminUnitId").In(
					new Select(UserConnection)
						.Column("SysAdminUnitId")
					.From("SysAdminUnitInRole")
					.InnerJoin("SysAdminUnit").As("ChangedRole")
						.On("SysAdminUnitInRole", "SysAdminUnitRoleId").IsEqual("ChangedRole", "Id")
					.Where("SysAdminUnitRoleId").In(Column.Parameters(changedOrgRoles))
					.And().Not().Exists(
						new Select(UserConnection)
							.Column("Id")
						.From("SysLicUser")
						.Where("SysUserId").IsEqual("SysAdminUnitInRole", "SysAdminUnitId")
						.And("Active").IsEqual(Column.Parameter(true))
						.And("Source").IsEqual(Column.Parameter(SysLicSource.Manual)))
					.And().Exists(
						new Select(UserConnection)
							.Column("Id")
						.From("SysLicUser")
						.Where("SysUserId").IsEqual("SysAdminUnitInRole", "SysAdminUnitId")
						.And("Active").IsEqual(Column.Parameter(true))
						.And("Source").Not().IsEqual(Column.Parameter(SysLicSource.Manual))))
				.And("Role", "SysAdminUnitTypeValue").Not().In(Column.Parameters(Core.DB.SysAdminUnitType.User,
					Core.DB.SysAdminUnitType.SelfServicePortalUser, Core.DB.SysAdminUnitType.FunctionalRole)) as Select;
			return select;
		}

		private bool GetWillUsersHaveLicensesWhenUserRolesChanged(CheckUsersWillHaveLicensesDto request,
				bool useFullHierarchyDuringLicenseDistribution, out IDictionary<Guid, string> affectedUsers) {
			affectedUsers = new Dictionary<Guid, string>();
			var changedUsers = request.Users.Select(userId => Guid.Parse(userId)).ToList();
			var usersWithAutoLicensesSelect =
				new Select(UserConnection)
					.Column("Id")
					.Column("Name")
				.From("SysAdminUnit")
				.Where("Id").In(Column.Parameters(changedUsers))
				.And().Not().Exists(
					new Select(UserConnection)
						.Column("Id")
					.From("SysLicUser")
					.Where("SysUserId").IsEqual("SysAdminUnit", "Id")
					.And("Active").IsEqual(Column.Parameter(true))
					.And("Source").IsEqual(Column.Parameter(SysLicSource.Manual)))
				.And().Exists(
					new Select(UserConnection)
						.Column("Id")
					.From("SysLicUser")
					.Where("SysUserId").IsEqual("SysAdminUnit", "Id")
					.And("Active").IsEqual(Column.Parameter(true))
					.And("Source").Not().IsEqual(Column.Parameter(SysLicSource.Manual))) as Select;
			var usersWithAutoLicenses = new Dictionary<Guid, string>();
			usersWithAutoLicensesSelect.ExecuteReader(reader => {
				usersWithAutoLicenses.Add(reader.GetColumnValue<Guid>("Id"), reader.GetColumnValue<string>("Name"));
			});
			if (usersWithAutoLicenses.IsEmpty()) {
				return true;
			}
			var currentUserRolesSelect =
				new Select(UserConnection).Distinct()
					.Column("SysUserId")
					.Column("SysRoleId")
				.From("SysUserInRole")
				.Where("SysUserId").In(Column.Parameters(usersWithAutoLicenses.Keys)) as Select;
			var currentUsersRoles = new Dictionary<Guid, HashSet<Guid>>();
			currentUserRolesSelect.ExecuteReader(reader => {
				var userId = reader.GetColumnValue<Guid>("SysUserId");
				var roleId = reader.GetColumnValue<Guid>("SysRoleId");
				if (currentUsersRoles.ContainsKey(userId)) {
					currentUsersRoles[userId].Add(roleId);
				} else {
					currentUsersRoles[userId] = new HashSet<Guid> {
						roleId
					};
				}
			});
			var result = true;
			var orgRoles = request.OrgRoles.Select(orgRole => Guid.Parse(orgRole));
			var funcRoles = request.FuncRoles.Select(funcRole => Guid.Parse(funcRole));
			foreach (var user in currentUsersRoles) {
				HashSet<Guid> userRoles = user.Value;
				if (request.ChangeRoleOperationType == ChangeRoleOperationType.AddRolesToUser) {				
					userRoles.AddRange(orgRoles);					
					userRoles.AddRange(funcRoles);
				}
				if (request.ChangeRoleOperationType == ChangeRoleOperationType.DeleteRoleFromUser) {
					userRoles.RemoveRange(orgRoles);
					userRoles.RemoveRange(funcRoles);
				}
				var inheritedRoles = new HashSet<Guid>();
				if (useFullHierarchyDuringLicenseDistribution) {
					var rolesHierarchy = GetLinkedRolesHierarchy(request);
					foreach (var userRole in userRoles) {
						inheritedRoles.AddRange(rolesHierarchy[userRole]);
					}
					userRoles.AddRange(inheritedRoles);
				}
				var licenseRoleMap = GetLicInRoles();
				var userCheckResult = CheckWillUserHaveLicenses(userRoles, licenseRoleMap);
				if (!userCheckResult) {
					affectedUsers.Add(user.Key, usersWithAutoLicenses[user.Key]);
				}
				result &= userCheckResult;
			}
			return result;
		}

		private Dictionary<Guid, HashSet<Guid>> GetLicInRoles() {
			var selectLicInRole =
				new Select(UserConnection)
					.Column("SysLicPackageId")
					.Column("SysRoleId")
				.From("SysLicPackageInRole") as Select;
			var licInRoles = new Dictionary<Guid, HashSet<Guid>>();
			selectLicInRole.ExecuteReader(reader => {
				var licPackage = reader.GetColumnValue<Guid>("SysLicPackageId");
				var role = reader.GetColumnValue<Guid>("SysRoleId");
				if (!licInRoles.ContainsKey(role)) {
					licInRoles[role] = new HashSet<Guid>();
				}
				licInRoles[role].Add(licPackage);
			});
			return licInRoles;
		}

		private bool CheckWillUserHaveLicenses(HashSet<Guid> userRoles, Dictionary<Guid, HashSet<Guid>> licRoleMap) {
			var availableLicenses = new HashSet<Guid>();
			foreach (var userRole in userRoles) {
				if (licRoleMap.ContainsKey(userRole)) {
					availableLicenses.AddRange(licRoleMap[userRole]);
				}
			}
			return availableLicenses.Any();
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Builds a list of license packages for a userRole.
		/// </summary>
		/// <param name="userId">User ID.</param>
		/// <returns>Serialized list of license objects.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetAvailableLicPackages", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string GetAvailableLicPackages(string userId) {
			var collection = new List<LicenseItem>();
			var recordId = new Guid(userId);
			bool isNew = (recordId == Guid.Empty);
			bool useRoleBasedLicenseDistribution = Features.GetIsEnabled<UseRoleBasedLicenseDistribution>();
			EntityCollection result = GetAvailableLic(recordId, isNew);
			Dictionary<Guid, SysLicSource> packageSources = GetPackageSources(recordId, isNew, result);
			bool isActive = isNew || IsUserActive(recordId);
			bool canManageLicUsers = UserConnection.DBSecurityEngine.GetCanExecuteOperation("CanManageLicUsers");
			Collection<string> prioritizedLicPackages = UserConnection.LicHelper.GetPrioritizedLicPackages();
			foreach (Entity licPackage in result) {
				Guid licPackageId = licPackage.GetTypedColumnValue<Guid>("SysLicPackageId");
				string licPackageName = licPackage.GetTypedColumnValue<string>("SysPackageName");
				int availableLicensesCount = licPackage.GetTypedColumnValue<int>("Available");
				bool userInitiallyHadLicense = !isNew && licPackage.GetTypedColumnValue<int>("HadLicense") == 1;
				SysLicSource licSource = packageSources.TryGetValue(licPackageId, out var source)
					? source
					: SysLicSource.Default;
				string licSourceString = useRoleBasedLicenseDistribution
					? LicHelper.GetLicenseSource(licSource)
					: string.Empty;
				LicType licType;
				string packageOperations = licPackage.GetTypedColumnValue<string>("PackageOperations");
				if (packageOperations.Contains(ServerLicPackageOperation)) {
					licType = LicType.Server;
				} else {
					licType = licPackage.GetTypedColumnValue<LicType>("LicType");
				}
				bool isEnabled = false, isChecked = false;
				if (isActive) {
					isEnabled = (canManageLicUsers && (userInitiallyHadLicense || availableLicensesCount > 0 
						|| licType == LicType.Server));
					isChecked = (userInitiallyHadLicense || (isNew && availableLicensesCount > 0 &&
						UserConnection.GetIsFeatureEnabled("EnableNewUserLicensing")));
				}
				var licItem = new LicenseItem {
					Id = licPackageId,
					Type = licType,
					Caption = licPackageName,
					Enabled = isEnabled,
					AvailableCount = availableLicensesCount,
					PaidCount = licPackage.GetTypedColumnValue<int>("Purchased"),
					UsedCount = licPackage.GetTypedColumnValue<int>("Used"),
					SysLicSource = licSourceString
				};
				if (GlobalAppSettings.UseLicPackagesPriorityInUserLicenseAdding &&
						prioritizedLicPackages != null && prioritizedLicPackages.Contains(licPackageName)) {
					licItem.Checked = isActive && userInitiallyHadLicense;
				} else {
					licItem.Checked = isChecked;
				}
				if (isNew && UserConnection.GetIsFeatureEnabled("UseRoleBasedLicenseDistribution")) {
					licItem.Checked = false;
				}
				collection.Add(licItem);
			}
			if (GlobalAppSettings.UseLicPackagesPriorityInUserLicenseAdding && isNew 
					&& UserConnection.GetIsFeatureEnabled("EnableNewUserLicensing") 
					&& !UserConnection.GetIsFeatureEnabled("UseRoleBasedLicenseDistribution")) {
				SetHighestPriorityPackageChecked(collection, prioritizedLicPackages);
			} 
			collection = collection.GroupBy(i => i.Id).Select(o => o.First()).ToList();
			return Serialize(collection, true);
		}

		/// <summary>
		/// Updating userRole licenses.
		/// </summary>
		/// <param name="userId">User ID.</param>
		/// <param name="licenseItems">A serialized dictionary, where the key is the license identifier
		/// and the userRoles is an indication that the license is active.</param>
		/// <returns>Error text for exceeding the number of licenses orgRole an empty line
		/// if the number has not been exceeded.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "UpdateLicenseInfo", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string UpdateLicenseInfo(string userId, string licenseItems) {
			try {
				UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManageLicUsers");
				Dictionary<string, bool> licenses = Json.Deserialize<Dictionary<string, bool>>(licenseItems);
				var sb = new StringBuilder();
				foreach (KeyValuePair<string, bool> licItem in licenses) {
					var userGuid = new Guid(userId);
					var sysPackageGuid = new Guid(licItem.Key);
					bool userHasLicense = GetUserHasLicense(userGuid, sysPackageGuid);
					if (licItem.Value && !userHasLicense) {
						string errors = HasLicErrors(sysPackageGuid);
						if (errors.Length > 0) {
							sb.Append(errors);
						} else {
							AddSysLicUser(userGuid, sysPackageGuid);
						}
					}
					if (!licItem.Value && userHasLicense) {
						DeleteSysLicUser(userGuid, sysPackageGuid);
					}
				}
				if (sb.Length > 0) {
					return string.Format(
						new LocalizableString("Terrasoft.WebApp.Loader", "LicManager.PaidLicenseCountExceededMessage"),
						sb);
				}
			} catch (Exception e) {
				return e.Message;
			}
			return string.Empty;
		}

		/// <summary>
		/// Attempts to grant the specified licenses to the specified userRole.
		/// </summary>
		/// <param name="userId">User identifier.</param>
		/// <param name="licPackages">Array of names of licenses to be issued.</param>
		/// <returns></returns>
		[WebInvoke(Method = "POST", UriTemplate = "RedistributeLicenses", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string RedistributeLicenses(string userId, string[] licPackages) {
			if (Features.GetIsDisabled<UseRoleBasedLicenseDistribution>()) {
				return "Endpoint disabled.";
			}
			try {
				var userIdGuid = Guid.Parse(userId);
				Collection<string> licenseNames = licPackages.IsEmpty() ? null : new Collection<string>(licPackages);
				var canUseDefaultBehavior = UserConnection.GetIsFeatureEnabled("EnableNewUserLicensing");
				UserConnection.AppConnection.LicManager.AddUserAvailableLicences(userIdGuid, licenseNames, canUseDefaultBehavior);
			} catch (Exception e) {
				return e.Message;
			}
			return string.Empty;
		}

		/// <summary>
		/// Validate that all changedUsers will have licenses after redistribution 
		/// </summary>
		/// <param name="roleId">Role identifier. If empty guid - for all changedUsers</param>
		/// <param name="keepManualLicenses">Keep manually granted licenses</param>
		/// <returns></returns>
		[WebInvoke(Method = "POST", UriTemplate = "ValidateLicenseDistribution", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public BaseResponse ValidateLicenseDistribution(string roleId, bool keepManualLicenses) {
			return GetRoleBasedLicenseResult(roleId, keepManualLicenses);
		}

		/// <summary>
		/// Check that changedUsers will have licenses
		/// </summary>
		/// <param name="request">Identifiers of organizational and functional roles</param>
		/// <returns></returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "CheckUsersWillHaveLicenses", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public BaseResponse CheckUsersWillHaveLicenses(CheckUsersWillHaveLicensesDto request) {
			var result = new BaseResponse {
				Success = true,
				ErrorInfo = null,
			};
			bool redistributeLicensesOnRoleChanges = SysSettingConfiguration
					.GetValue(UserConnection, "RedistributeLicensesOnRoleChanges", false);
			if (!redistributeLicensesOnRoleChanges || Features.GetIsDisabled<UseRoleBasedLicenseDistribution>()) {
				return result;
			}
			IDictionary<Guid, string> affectedUsers = null;
			if (Features.GetIsEnabled<ValidateUserLicensesOnRoleChanges>()) {
				ChangeRoleOperationType changeRoleOperationType = request.ChangeRoleOperationType;
				var isRoleRelationChange = changeRoleOperationType == ChangeRoleOperationType.AddFuncRoleToOrgRole
					|| changeRoleOperationType == ChangeRoleOperationType.DeleteFuncRoleFromOrgRole;
				bool useFullHierarchyDuringLicenseDistribution = SysSettingConfiguration
					.GetValue(UserConnection, "UseFullHierarchyDuringLicenseDistribution", false);
				if (isRoleRelationChange && !useFullHierarchyDuringLicenseDistribution) {
					return result;
				}
				try {				
					switch (changeRoleOperationType) {
						case ChangeRoleOperationType.AddRolesToUser:
						case ChangeRoleOperationType.DeleteRoleFromUser:
							result.Success = GetWillUsersHaveLicensesWhenUserRolesChanged(request,
								useFullHierarchyDuringLicenseDistribution, out affectedUsers);
							break;
						case ChangeRoleOperationType.AddFuncRoleToOrgRole:
						case ChangeRoleOperationType.DeleteFuncRoleFromOrgRole:
							result.Success = GetWillUsersHaveLicensesWhenRolesRelationChanged(request, out affectedUsers);
							break;
					}
					if (!result.Success) {
						result.ErrorInfo = new ErrorInfo {
							Message = GetLicValidationMessage(affectedUsers)
						};
					}
				} catch (Exception e) {
					result.Success = false;
					result.ErrorInfo = new ErrorInfo {
						ErrorCode = "exception",
						Message = e.Message
					};
				}
			}
			return result;
		}

		#endregion

	}

	#endregion

}
