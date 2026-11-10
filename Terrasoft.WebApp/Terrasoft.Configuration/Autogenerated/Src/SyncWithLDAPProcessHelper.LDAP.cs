namespace Terrasoft.Configuration.LDAP
{
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Data;
	using System.Linq;
	using Creatio.FeatureToggling;
	using global::Common.Logging;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Feature;
	using Terrasoft.Core.OrgStructure;

	#region class : LDAPLicenseInfo

	public class LDAPLicenseInfo
	{
		public Guid UserId { get; set; }
		public string UserName { get; set; }
		public List<string> MissingLicenses { get; set; }
	}

	#endregion

	#region Class: SyncWithLDAPProcessHelper

	public class SyncWithLDAPProcessHelper
	{

		#region Fields: Private

		private static readonly object _lockObject = new object();
		private readonly UserConnection _userConnection;
		private readonly Guid _allEmployeesGroupId = new Guid("{A29A3BA5-4B0D-DE11-9A51-005056C00008}");
		private readonly Guid _sspUsersGroupId = new Guid("{720B771C-E7A7-4F31-9CFB-52CD21C3739F}");
		private readonly ILog _log = LogManager.GetLogger("LDAP");
		private List<string> _availableLicenseNames;
		private List<LDAPLicenseInfo> _usersWithoutLicenses;
		private List<string> _systemSettingLicenseNames;

		#endregion

		#region Properties: Protected

		/// <summary>
		/// Gets IOrgStructureManager instance.
		/// </summary>
		protected IOrgStructureManager OrgStructureManager { get; }

		#endregion

		#region Constructors: Public

		public SyncWithLDAPProcessHelper(UserConnection userConnection) {
			_userConnection = userConnection;
			_usersWithoutLicenses = new List<LDAPLicenseInfo>();
			OrgStructureManager = new OrgStructureManager(_userConnection);
		}

		#endregion

		#region Methods: Private

		private DateTime? GetMinModifiedDateOfNewUsers() {
			var getMinModifiedDateOfNewUsers = (Select)new Select(_userConnection)
				.Column(Func.Min("ModifiedOn"))
				.From("SysLDAPSynchUser")
				.Where().Not().Exists(new Select(_userConnection)
					.Column(Column.Const(1))
					.From("SysAdminUnit")
					.Where("SysAdminUnit", "LDAPEntryId").IsEqual("SysLDAPSynchUser", "Id")
				);
			DateTime result = getMinModifiedDateOfNewUsers.ExecuteScalar<DateTime>();
			return (result == DateTime.MinValue) ? default(DateTime?) : result;
		}

		private IEnumerable<Guid> CheckUsersInGroup(LdapGroup group, Guid groupId, Guid syncId,
			out DateTime? minModifiedDateOfNewUser) {
			try {
				int usersCount;
				using (var ldapUtils = new LdapUtilities(_userConnection)) {
					usersCount = ldapUtils.InsertMembersOfGroupToTable(group, syncId);
				}
				var changedUserIds = new HashSet<Guid>();
				var ldapUsersInGroupSubQuery = CreateLdapUsersInGroupSubQuery(syncId);
				bool useRoleBasedLicensing = Features.GetIsEnabled<UseRoleBasedLicenseDistribution>();
				if (useRoleBasedLicensing) {
					ExecuteLDAPUsersToDeleteRolesSelect(groupId, ldapUsersInGroupSubQuery, changedUserIds);
				}
				var ldapUsersToDeleteRolesSubSelect = CreateLDAPUsersToDeleteRolesSubSelect(ldapUsersInGroupSubQuery);
				int operationsCount = ExecuteDeleteRoles(groupId, ldapUsersToDeleteRolesSubSelect);
				_log.InfoFormat("SyncID: {2}. {1} user(s) removed from folder {0}", group.Name, operationsCount,
					syncId);
				if (usersCount < 1) {
					minModifiedDateOfNewUser = DateTime.MaxValue;
					return changedUserIds;
				}
				if (useRoleBasedLicensing) {
					ExecuteLDAPUsersToAddRolesSelect(groupId, ldapUsersInGroupSubQuery, changedUserIds);
				}
				ExecuteInsertRoles(groupId, ldapUsersInGroupSubQuery);
				var ldapGroupId = GetLDAPGroupId(group);
				if (ldapGroupId.HasValue) {
					ExecuteDeleteLDAPGroup(ldapGroupId.Value, syncId);
					ExecuteInsertSelectGroup(ldapGroupId.Value, syncId);
				}
				minModifiedDateOfNewUser = GetMinModifiedDateOfNewUsers();
				LogMinModifiedDateOfNewUser(group, minModifiedDateOfNewUser, syncId);
				return changedUserIds;
			} finally {
				var delete = new Delete(_userConnection).From("SysLDAPSynchUser");
				if (syncId.IsNotEmpty()) {
					delete.Where("LdapSyncId").IsEqual(Column.Parameter(syncId));
				}
				delete.Execute();
			}
		}

		private Query CreateLdapUsersInGroupSubQuery(Guid syncId) {
			var ldapUsersInGroupSubSelect = new Select(_userConnection)
					.Column("Id")
				.From("SysLDAPSynchUser")
				.Where("SysLDAPSynchUser", "Id")
				.IsEqual("SysAdminUnit", "LDAPEntryId");
			if (syncId.IsNotEmpty()) {
				ldapUsersInGroupSubSelect.And("LdapSyncId").IsEqual(Column.Parameter(syncId));
			}
			return ldapUsersInGroupSubSelect;
		}

		private void ExecuteLDAPUsersToDeleteRolesSelect(Guid groupId, Query ldapUsersInGroupSubSelect,
			HashSet<Guid> changedUserIds) {
			var ldapUsersToDeleteRolesSelect =
				new Select(_userConnection)
					.Column("SysAdminUnit", "Id")
					.From("SysAdminUnit")
					.InnerJoin("SysUserInRole").On("SysUserInRole", "SysUserId").IsEqual("SysAdminUnit", "Id")
					.Where("SysUserInRole", "SysRoleId").IsEqual(Column.Parameter(groupId))
					.And("SynchronizeWithLDAP").IsEqual(Column.Parameter(true))
					.And("SysAdminUnit", "SysAdminUnitTypeValue").IsEqual(Column.Parameter((int)SysAdminUnitType.User))
					.And().Not().Exists(ldapUsersInGroupSubSelect) as Select;
			if (ShouldNotSyncExternalUsers()) {
				ldapUsersToDeleteRolesSelect.And("SysAdminUnit", "ConnectionType")
					.IsEqual(Column.Parameter((int)UserType.General));
			}
			ldapUsersToDeleteRolesSelect.ExecuteReader(reader => {
				var id = reader.GetColumnValue<Guid>("Id");
				changedUserIds.Add(id);
			});
		}

		private Select CreateLDAPUsersToDeleteRolesSubSelect(Query ldapUsersInGroupSubSelect) {
			Select ldapUsersToDeleteRolesSubSelect =
					new Select(_userConnection)
						.Column("Id")
					.From("SysAdminUnit")
					.Where("SysUserInRole", "SysUserId").IsEqual("SysAdminUnit", "Id")
						.And("SynchronizeWithLDAP").IsEqual(Column.Parameter(true))
						.And("SysAdminUnit", "SysAdminUnitTypeValue").IsEqual(Column.Parameter((int)SysAdminUnitType.User))
						.And().Not().Exists(ldapUsersInGroupSubSelect) as Select;
				if (ShouldNotSyncExternalUsers()) {
					ldapUsersToDeleteRolesSubSelect.And("SysAdminUnit", "ConnectionType")
						.IsEqual(Column.Parameter((int)UserType.General));
				}
				return ldapUsersToDeleteRolesSubSelect;
		}

		private int ExecuteDeleteRoles(Guid groupId, Select ldapUsersInGroupSubSelect) {
			var deleteRoles = new Delete(_userConnection)
				.From("SysUserInRole")
				.Where("SysRoleId").IsEqual(Column.Parameter(groupId))
				.And().Exists(ldapUsersInGroupSubSelect);
			return deleteRoles.Execute();
		}

		private void ExecuteLDAPUsersToAddRolesSelect(Guid groupId, Query ldapUsersInGroupSubQuery, HashSet<Guid> changedUserIds) {
			var ldapUsersToAddRolesSelect =
				new Select(_userConnection)
					.Column("SysAdminUnit", "Id")
					.From("SysAdminUnit")
					.InnerJoin("SysUserInRole").On("SysUserInRole", "SysUserId").IsEqual("SysAdminUnit", "Id")
					.Where("SynchronizeWithLDAP").IsEqual(Column.Parameter(true))
					.And("SysAdminUnit", "SysAdminUnitTypeValue").IsEqual(Column.Parameter((int)SysAdminUnitType.User))
					.And().Not().Exists(
						new Select(_userConnection)
							.Column("Id")
							.From("SysUserInRole").As("ur")
							.Where("ur", "SysUserId").IsEqual("SysAdminUnit", "Id")
							.And("ur", "SysRoleId").IsEqual(Column.Parameter(groupId)) as Select)
					.And().Exists(ldapUsersInGroupSubQuery) as Select;
			if (ShouldNotSyncExternalUsers()) {
				ldapUsersToAddRolesSelect.And("SysAdminUnit", "ConnectionType")
					.IsEqual(Column.Parameter((int)UserType.General));
			}
			ldapUsersToAddRolesSelect.ExecuteReader(reader => {
				var id = reader.GetColumnValue<Guid>("Id");
				changedUserIds.Add(id);
			});
		}

		private void ExecuteInsertRoles(Guid groupId, Query ldapUsersInGroupSubSelect) {
			var ldapUsersToAddRolesSubSelect = new Select(_userConnection)
				.Column(Column.Const(DateTime.Now))
				.Column(Column.Const(DateTime.Now))
				.Column(Column.Const(groupId))
				.Column("Id")
				.From("SysAdminUnit")
				.Where().Not().Exists(
					new Select(_userConnection)
							.Column("Id")
						.From("SysUserInRole").As("ur")
						.Where("ur", "SysUserId").IsEqual("SysAdminUnit", "Id")
							.And("ur", "SysRoleId").IsEqual(Column.Parameter(groupId)) as Select)
				.And().Exists(ldapUsersInGroupSubSelect)
				.And("SysAdminUnit", "SysAdminUnitTypeValue").IsEqual(Column.Parameter((int)SysAdminUnitType.User)) as Select;
			if (ShouldNotSyncExternalUsers()) {
				ldapUsersToAddRolesSubSelect.And("SysAdminUnit", "ConnectionType")
					.IsEqual(Column.Parameter((int)UserType.General));
			}
			var insertRoles = new InsertSelect(_userConnection)
				.Into("SysUserInRole")
					.Set("CreatedOn", "ModifiedOn", "SysRoleId", "SysUserId")
				.FromSelect(ldapUsersToAddRolesSubSelect);
			insertRoles.Execute();
		}

		private Guid? GetLDAPGroupId(LdapGroup group) {
			var manager = _userConnection.EntitySchemaManager;
			var query = new EntitySchemaQuery(manager, "LDAPElement") {
				UseAdminRights = false
			};
			var primaryColumnName = query.AddColumn(query.RootSchema.GetPrimaryColumnName()).Name;
			query.Filters.Add(query.CreateFilterWithParameters(FilterComparisonType.Equal, "LDAPEntryId", group.Id));
			query.Filters.Add(query.CreateFilterWithParameters(FilterComparisonType.NotEqual, "Type",
				(int)SysAdminUnitType.User));
			var collection = query.GetEntityCollection(_userConnection);
			return collection.Any() ? collection[0].GetTypedColumnValue<Guid>(primaryColumnName) : (Guid?)null;
		}

		private void ExecuteDeleteLDAPGroup(Guid ldapGroupId, Guid syncId) {
			var ldapUsersSubSelect = CreateLdapUsersSubSelect(syncId);
			var deleteLdapGroup = new Delete(_userConnection)
				.From("LDAPUserInLDAPGroup")
				.Where("LDAPGroupId").IsEqual(Column.Parameter(ldapGroupId))
				.And().Exists(
					new Select(_userConnection)
						.Column("Id")
						.From("LDAPElement")
						.Where("LDAPUserInLDAPGroup", "LDAPUserId").IsEqual("LDAPElement", "Id")
						.And("LDAPElement", "Type").IsEqual(Column.Const((int)SysAdminUnitType.User))
						.And().Not().Exists(ldapUsersSubSelect));
			deleteLdapGroup.Execute();
		}

		private Select CreateLdapUsersSubSelect(Guid syncId) {
			Select ldapUsersSubSelect = new Select(_userConnection)
				.Column("Id")
				.From("SysLDAPSynchUser")
				.Where("SysLDAPSynchUser", "Id").IsEqual("LDAPElement", "LDAPEntryId") as Select;
			if (syncId.IsNotEmpty()) {
				ldapUsersSubSelect.And("LdapSyncId").IsEqual(Column.Parameter(syncId));
			}
			return ldapUsersSubSelect;
		}

		private void ExecuteInsertSelectGroup(Guid ldapGroupId, Guid syncId) {
			var ldapUsersSubSelect = CreateLdapUsersSubSelect(syncId);
			var insertSelectGroup = new InsertSelect(_userConnection)
				.Into("LDAPUserInLDAPGroup")
				.Set("CreatedOn", "ModifiedOn", "LDAPGroupId", "LDAPUserId")
				.FromSelect(new Select(_userConnection)
					.Column(Column.Const(DateTime.Now))
					.Column(Column.Const(DateTime.Now))
					.Column(Column.Const(ldapGroupId))
					.Column("Id")
					.From("LDAPElement")
					.Where().Not().Exists(new Select(_userConnection)
						.Column("Id")
						.From("LDAPUserInLDAPGroup").As("ug")
						.Where("ug", "LDAPUserId").IsEqual("LDAPElement", "Id")
						.And("ug", "LDAPGroupId").IsEqual(Column.Parameter(ldapGroupId)) as Select)
					.And().Exists(ldapUsersSubSelect)
					.And("LDAPElement", "Type").IsEqual(Column.Const((int)SysAdminUnitType.User)));
			insertSelectGroup.Execute();
		}

		private void LogMinModifiedDateOfNewUser(LdapGroup group, DateTime? minModifiedDateOfNewUser, Guid syncId) {
			if (minModifiedDateOfNewUser.HasValue) {
				_log.InfoFormat("SyncID: {2}. Minimal date of new users in group {0}: {1}", group.Name, minModifiedDateOfNewUser.Value, syncId);
			} else {
				_log.InfoFormat("SyncID: {1}. Group {0} doesn't have a new users", group.Name, syncId);
			}
		}

		private void AddLicForUser(Entity user) {
			string licenseNames = SysSettings.GetValue(_userConnection, "LdapUserLicPackages", string.Empty);
			var licenses = licenseNames.IsNullOrWhiteSpace() ? null : new Collection<string>(licenseNames.Split(';'));
			var licManager = ClassFactory.Get<ILicManager>();
			var grantedLicenses = licManager.AddUserAvailableLicences(user.PrimaryColumnValue, licenses);
			var missingLicenses = GetMissingLicenses(grantedLicenses, licenses, user.PrimaryColumnValue);
			if (missingLicenses.Any()) {
				if (_usersWithoutLicenses.Count == 0) {
					_log.Warn(new LocalizableString(_userConnection.Workspace.ResourceStorage,
						"SyncWithLDAPProcessHelper","LocalizableStrings.LDAPLicenseLog.Value"));
				}
				LDAPLicenseInfo userWithMissingLicenses = GetUserWithMissingLicenses(user, missingLicenses);
				_usersWithoutLicenses.Add(userWithMissingLicenses);
				string logMessage = GetUserWithMissingLicensesLogMessage(user, missingLicenses);
				_log.Warn(logMessage);
			}
		}

		private List<string> GetMissingLicenses(Collection<Guid> grantedLicenses, IEnumerable<string> licenses,
			Guid userId) {
			var grantedLicenseNames = GetGrantedLicenseNames(grantedLicenses);
			var availableLicenseNames = GetAvailableLicenseNamesForUser(licenses, userId);
			var missingLicenses = GetMissingLicenses(grantedLicenseNames, availableLicenseNames);
			return missingLicenses;
		}

		private IEnumerable<string> GetAvailableLicenseNamesForUser(IEnumerable<string> licenses, Guid userId) {
			bool useRoleBasedLicensing = Features.GetIsEnabled<UseRoleBasedLicenseDistribution>();
			if (useRoleBasedLicensing) {
				var roleBasedLicenses = GetRoleBasedAvailableLicenceNames(userId);
				if (!roleBasedLicenses.IsNullOrEmpty()) {
					return roleBasedLicenses;
				}
			}
			return licenses == null ? GetAvailableLicenseNames() : GetSystemSettingLicenseNames(licenses);
		}

		private LDAPLicenseInfo GetUserWithMissingLicenses(Entity user, List<string> licenses) {
			var userName = user.GetTypedColumnValue<string>("Name");
			var result = new LDAPLicenseInfo {
				UserId = user.PrimaryColumnValue,
				UserName = userName,
				MissingLicenses = licenses
			};
			return result;
		}

		private IEnumerable<string> GetSystemSettingLicenseNames(IEnumerable<string> licenses) {
			if (!_systemSettingLicenseNames.IsNullOrEmpty()) {
				return _systemSettingLicenseNames;
			}
			var licenseNames = new List<string>();
			IEnumerable<QueryParameter> names =
				licenses.Select(name => new QueryParameter(name)).ToList();
			var select =
				new Select(_userConnection)
						.Column("SysLicPackage", "Name")
				.From("SysLic")
				.InnerJoin("SysLicPackage").On("SysLic", "SysLicPackageId")
					.IsEqual("SysLicPackage", "Id")
				.Where("SysLicPackage", "Name").In(names)
				.And("SysLicPackage", "Operations")
					.Not().IsLike(Column.Parameter("%IsServerLicPackage%"))
				as Select;
			select.ExecuteReader(reader => {
				var licenseName = reader.GetColumnValue<string>("Name");
				licenseNames.Add(licenseName);
			});
			_systemSettingLicenseNames = licenseNames.Distinct().ToList();
			return _systemSettingLicenseNames;
		}

		private IEnumerable<string> GetAvailableLicenseNames() {
			if (!_availableLicenseNames.IsNullOrEmpty()) {
				return _availableLicenseNames;
			}
			DateTime currentDay = DateTime.UtcNow.Date;
			var licenseNames = new List<string>();
			var select =
				new Select(_userConnection)
					.Column("SysLicPackage", "Name")
				.From("SysLic")
				.InnerJoin("SysLicPackage").On("SysLic", "SysLicPackageId")
					.IsEqual("SysLicPackage", "Id")
				.Where(Column.Parameter(currentDay))
					.IsBetween("SysLic", "StartDate")
						.And("SysLic", "DueDate")
					.And("SysLicPackage", "Operations")
						.Not().IsLike(Column.Parameter("%IsServerLicPackage%"))
					.OrderByAsc("SysLicPackage", "Name")
					as Select;
			select.ExecuteReader(reader => {
				var licenseName = reader.GetColumnValue<string>("Name");
				licenseNames.Add(licenseName);
			});
			_availableLicenseNames = licenseNames;
			return licenseNames;
		}

		private IEnumerable<string> GetRoleBasedAvailableLicenceNames(Guid userId) {
			DateTime currentDay = DateTime.UtcNow.Date;
			var licenseNames = new List<string>();
			var select =
				new Select(_userConnection)
					.Column("SysLicPackage", "Name")
				.From("SysLic")
				.InnerJoin("SysLicPackage").On("SysLic", "SysLicPackageId")
					.IsEqual("SysLicPackage", "Id")
				.InnerJoin("SysLicPackageInRole").On("SysLicPackageInRole", "SysLicPackageId")
					.IsEqual("SysLicPackage", "Id")
				.Where(Column.Parameter(currentDay))
					.IsBetween("SysLic", "StartDate")
						.And("SysLic", "DueDate")
					.And("SysLicPackage", "Operations")
						.Not().IsLike(Column.Parameter("%IsServerLicPackage%"))
					.And().Exists(
						new Select(_userConnection)
							.Column("Id")
						.From("SysUserInRole")
						.Where("SysUserInRole", "SysRoleId").IsEqual("SysLicPackageInRole", "SysRoleId")
							.And("SysUserInRole", "SysUserId").IsEqual(Column.Parameter(userId)))
					.OrderByAsc("SysLicPackage", "Name")
					as Select;
			select.ExecuteReader(reader => {
				var licenseName = reader.GetColumnValue<string>("Name");
				licenseNames.Add(licenseName);
			});
			return licenseNames;
		}

		private List<string> GetGrantedLicenseNames(Collection<Guid> licenses) {
			var licenseNames = new List<string>();
			if (licenses.IsEmpty()) {
				return licenseNames;
			}
			IEnumerable<QueryParameter> uids =
				licenses.Select(id => new QueryParameter(id)).ToList();
			var select =
				new Select(_userConnection)
					.Column("SysLicPackage", "Name")
				.From("SysLic")
				.InnerJoin("SysLicPackage").On("SysLic", "SysLicPackageId")
					.IsEqual("SysLicPackage", "Id")
				.Where("SysLicPackage", "Id").In(uids)
				.And("SysLicPackage", "Operations")
					.Not().IsLike(Column.Parameter("%IsServerLicPackage%"))
				.OrderByAsc("SysLicPackage", "Name")
				as Select;
			select.ExecuteReader(reader => {
				var licenseName = reader.GetColumnValue<string>("Name");
				licenseNames.Add(licenseName);
			});
			return licenseNames;
		}

		private List<string> GetMissingLicenses(IEnumerable<string> grantedLicenses, IEnumerable<string> licenses) {
			return licenses.Except(grantedLicenses).ToList();
		}

		private string GetUserWithMissingLicensesLogMessage(Entity user, List<string> licenses) {
			var userName = user.GetTypedColumnValue<string>("Name");
			var missingLicenses = string.Join(", ", licenses);
			return $"(id: {user.PrimaryColumnValue}) | {userName} | {missingLicenses}.";
		}

		private (bool IsSsp, bool Active) GetUserStatus(Guid userId) {
			Select userStatusSelect =
				new Select(_userConnection).Top(1)
					.Column("ConnectionType")
					.Column("Active")
				.From("SysAdminUnit")
				.Where("Id").IsEqual(Column.Parameter(userId))
				.And("SysAdminUnitTypeValue").IsEqual(Column.Parameter(SysAdminUnitType.User)) as Select;
			UserType connectionType = UserType.General;
			bool active = false;
			userStatusSelect.ExecuteReader(dataReader => {
				connectionType = dataReader.GetColumnValue<UserType>("ConnectionType");
				active = dataReader.GetColumnValue<bool>("Active");
			});
			return (connectionType == UserType.SSP, active);
		}

		private void AddLicForSSPUser(Guid userId) {
			if (ShouldNotSyncExternalUsers()) {
				return;
			}
			var licManager = ClassFactory.Get<ILicManager>();
			licManager.AddUserAvailableLicences(userId);
		}

		private void AddLicForSSPOrGeneralUser(Entity user) {
			var userStatus = GetUserStatus(user.PrimaryColumnValue);
			if (!userStatus.Active) {
				return;
			}
			if (userStatus.IsSsp) {
				AddLicForSSPUser(user.PrimaryColumnValue);
			} else {
				AddLicForUser(user);
			}
		}

		private Guid? GetIdByName(string name, string entityName, bool createNewIfNotFound) {
			if (string.IsNullOrEmpty(name)) {
				return null;
			}
			var select = new Select(_userConnection).
				Column("Id").
				From(entityName).
				Where("Name").IsEqual(Column.Parameter(name)) as Select;
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = select.ExecuteReader(dbExecutor)) {
					if (dataReader.Read()) {
						return dataReader.GetColumnValue<Guid>("Id");
					}
				}
			}
			if (createNewIfNotFound) {
				//todo find out is it necessary
			}
			return null;
		}

		private void ActualizeAdminUnitInRole() => OrgStructureManager.ActualizeSysAdminUnitInRole();

		private void ImportUsers(DateTime? minModifiedDateOfNewUser, Guid syncId,
			IEnumerable<Guid> changedUserInGroupsIds, out DateTime? maxModificationDateOfLDAPEntry) {
			_usersWithoutLicenses.Clear();
			bool createUsersAutomaticallyWhenLdapSynchronize = SysSettings.GetValue(_userConnection,
				"CreateUsersAutomaticallyWhenLdapSynchronize", false);
			if (!createUsersAutomaticallyWhenLdapSynchronize) {
				maxModificationDateOfLDAPEntry = null;
				return;
			}
			int users = 0;
			int errors = 0;
			var ldapGroups = LoadLDAPGroups();
			var existingUsers = LoadExistingUsers();
			var jobs = LoadExistingJobs();
			_log.InfoFormat("SyncID: {0}. Start user import.", syncId);
			var groupCount = 0;
			var newUserIds = new List<Entity>();
			_log.InfoFormat("SyncID: {1}. Found {0} LDAP group(s) to synchronize.", ldapGroups.Count, syncId);
			Guid defaultSysCultureId = GetDefaultSysCultureId();
			DateTime lastUserModifiedOn = DateTime.MinValue;
			var usersWithChangedRoles = new List<Entity>();
			var sysAdminUnitSchema = _userConnection.EntitySchemaManager.FindInstanceByName("SysAdminUnit");
			bool useRoleBasedLicensing = Features.GetIsEnabled<UseRoleBasedLicenseDistribution>();
			foreach (LdapGroup groupItem in ldapGroups) {
				Guid groupId;
				UserType connectionType;
				Select groupPropertiesSelect = new Select(_userConnection).Column("Id").Column("ConnectionType")
					.From("SysAdminUnit").Where("SysAdminUnitTypeValue").Not()
					.IsEqual(Column.Const((int)SysAdminUnitType.User)).And("LDAPEntry")
					.IsEqual(Column.Parameter(groupItem.Name)) as Select;
				using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
					using (IDataReader dataReader = groupPropertiesSelect.ExecuteReader(dbExecutor)) {
						if (dataReader.Read()) {
							groupId = dataReader.GetColumnValue<Guid>("Id");
							connectionType = dataReader.GetColumnValue<UserType>("ConnectionType");
						} else {
							_log.ErrorFormat("SyncID: {1}. Organizational role not found for LDAP group '{0}'",
								groupItem.Name, syncId);
							continue;
						}
					}
				}
				List<LdapUser> ldapUsers = GetLDAPUsers(groupItem, minModifiedDateOfNewUser, syncId);
				var employeeSchema = _userConnection.EntitySchemaManager.FindInstanceByName("Employee");
				var contactSchema = _userConnection.EntitySchemaManager.FindInstanceByName("Contact");
				var usersCount = 0;
				foreach (LdapUser user in ldapUsers) {
					if (string.IsNullOrEmpty(user.FullName)) {
						continue;
					}
					if (lastUserModifiedOn < user.ModifiedOn) {
						lastUserModifiedOn = user.ModifiedOn;
					}
					Guid accountId = GetAccountId(user);
					Guid contactId = Guid.NewGuid();
					var sysAdminUnitQuery = new EntitySchemaQuery(sysAdminUnitSchema);
					var contactNameColumn = sysAdminUnitQuery.AddColumn("Contact.Name");
					var contactAccountIdColumn = sysAdminUnitQuery.AddColumn("Contact.Account.Id");
					var ldapElementId = UpdateLDAPElement(user);
					var sysAdminUnit = GetSysAdminUnit(user, sysAdminUnitQuery);
					if (sysAdminUnit != null) {
						UpdateSysAdminUnit(user, sysAdminUnit, ldapElementId, accountId, contactSchema, contactNameColumn, contactAccountIdColumn);
						var rolesChanged = AddUserToRolesIfNotExist(
							sysAdminUnit.GetTypedColumnValue<Guid>(sysAdminUnitSchema.PrimaryColumn.Name), groupId,
							connectionType);
						if (useRoleBasedLicensing && rolesChanged) {
							usersWithChangedRoles.Add(sysAdminUnit);
						}
						LogUserSaved(user, syncId, ldapUsers.Count, ref usersCount);
						continue;
					}
					if (!user.IsActive) {
						LogUserDeactivated(user, syncId);
						continue;
					}
					if (existingUsers.Any(x => x == user.Name)) {
						LogExistingUser(user, syncId, ldapUsers.Count, ref usersCount, ref errors);
						continue;
					}

					#region FindExistingContact

					bool shouldCreateContact = true;
					List<Guid> contactIds = LdapUtilities.GetExistingContactIds(_userConnection, user.FullName,
						user.Phone, user.Email);
					if (contactIds.Count > 1) {
						_log.InfoFormat("SyncID: {1}. Several contacts found that can be duplicates of user {0}",
							user.Name, syncId);
						usersCount++;
						_log.InfoFormat("SyncID: {2}. Progress: {0} users processed from {1}", usersCount,
							ldapUsers.Count, syncId);
						errors++;
						continue;
					} else if (contactIds.Count == 1) {
						contactId = contactIds.First();
						shouldCreateContact = false;
					}

					#endregion

					#region SkipCreateUserAndRoleIfContactAlreadyHaveUser

					if (contactIds.Any()) {
						using (var ldapUtils = new LdapUtilities(_userConnection)) {
							List<Guid> userIds = ldapUtils.GetUserIdsByContactId(contactId);
							if (userIds.Any()) {
								_log.InfoFormat("SyncID: {1}. User is already created for the found contact ({0})",
									user.FullName, syncId);
								usersCount++;
								_log.InfoFormat("SyncID: {2}. Progress: {0} users processed from {1}", usersCount,
									ldapUsers.Count, syncId);
								errors++;
								continue;
							}
						}
					}

					#endregion

					#region CreateUser

					if (connectionType != UserType.General && ShouldNotSyncExternalUsers()) {
						continue;
					}
					if (shouldCreateContact) {
						CreateContact(contactSchema, employeeSchema, contactId, user, accountId, jobs);
					}
					Guid newUserId = Guid.NewGuid();
					lock (_lockObject) {
						sysAdminUnit = sysAdminUnitSchema.CreateEntity(_userConnection);
						var userConditions = new Dictionary<string, object> {
							{ "Name", user.Name },
							{ "SynchronizeWithLDAP", true }
						};
						if (sysAdminUnit.FetchFromDB(userConditions)) {
							LogUserAlreadyAdded(user, syncId, ldapUsers.Count, ref usersCount);
							continue;
						}
						InitializeSysAdminUnit(sysAdminUnit, sysAdminUnitSchema, newUserId, contactId, user,
							connectionType, defaultSysCultureId, ldapElementId);
						try {
							sysAdminUnit.Save();
							newUserIds.Add(sysAdminUnit);
						} catch (Exception e) {
							_log.ErrorFormat("SyncID: {1}. {0}", e, e.Message, syncId);
							throw;
						}
					}

					#endregion

					AddUserToRolesIfNotExist(newUserId, groupId, connectionType);
					_log.InfoFormat("SyncID: {1}. LDAP user {0} saved", user.Name, syncId);
					usersCount++;
					_log.InfoFormat("SyncID: {2}. Progress: {0} users processed from {1}", usersCount, ldapUsers.Count,
						syncId);
					users++;
				}
				_log.InfoFormat("SyncID: {1}. LDAP group {0} processed", groupItem.Name, syncId);
				groupCount++;
				_log.InfoFormat("SyncID: {2}. Progress: {0} groups processed from {1}", groupCount, ldapGroups.Count,
					syncId);
			}

			#region Update users in all groups

			var oldUsersWithChangedRolesIds = UpdateUsersInAllGroups(syncId);

			#endregion

			if (useRoleBasedLicensing) {
				oldUsersWithChangedRolesIds.UnionWith(changedUserInGroupsIds);
				foreach (var userId in oldUsersWithChangedRolesIds) {
					var sysAdminUnit = sysAdminUnitSchema.CreateEntity(_userConnection);
					sysAdminUnit.FetchFromDB(userId);
					usersWithChangedRoles.Add(sysAdminUnit);
				}
			}
			var usersForLicDistribution = useRoleBasedLicensing
				? newUserIds.Union(usersWithChangedRoles).Distinct()
				: newUserIds;
			if (_userConnection.GetIsFeatureEnabled("ControlLicenseDistributionDuringLDAPSync")) {
				if (SysSettings.GetValue(_userConnection, "LDAPAllowLicenseDistributionDuringLDAPSync", true)) {
					foreach (var licUser in usersForLicDistribution) {
						AddLicForSSPOrGeneralUser(licUser);
					}
				}
			} else {
				foreach (var licUser in usersForLicDistribution) {
					AddLicForSSPOrGeneralUser(licUser);
				}
			}
			if (users > 0) {
				ActualizeAdminUnitInRole();
			}
			maxModificationDateOfLDAPEntry =
				lastUserModifiedOn > DateTime.MinValue ? lastUserModifiedOn : default(DateTime?);
			LogSyncResult(syncId, users, errors);
		}

		private Guid GetDefaultSysCultureId() {
			var cultureSelect =
				new Select(_userConnection)
					.Column("Id")
					.From("SysCulture")
					.Where("Default").IsEqual(Column.Parameter(true)) as Select;
			return cultureSelect.ExecuteScalar<Guid>();
		}

		private void LogSyncResult(Guid syncId, int users, int errors) {
			string syncResult = "LDAP synchronization completed";
			if (users > 0) syncResult += string.Format(" Users added: {0}", users);
			if (errors > 0) syncResult += string.Format(" Errors: {0}", errors);
			_log.InfoFormat("SyncID: {1}. User import finished! SyncResult: {0}", syncResult, syncId);
		}

		private List<LdapGroup> LoadLDAPGroups() {
			Select groupSelect = new Select(_userConnection)
				.Column("LDAPEntryId")
				.Column("LDAPEntry")
				.Column("LDAPEntryDN")
				.Column("Name")
				.Column("ConnectionType")
				.From("SysAdminUnit")
				.Where("SynchronizeWithLDAP").IsEqual(Column.Parameter(true))
				.And("SysAdminUnitTypeValue").Not().IsEqual(Column.Parameter((int)SysAdminUnitType.User))
				.And("LDAPEntryId").Not().IsNull() as Select;
			bool shouldNotSyncExternalUsers = ShouldNotSyncExternalUsers();
			var ldapGroups = new List<LdapGroup>();
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = groupSelect.ExecuteReader(dbExecutor)) {
					while (dataReader.Read()) {
						var connectionType = (UserType)dataReader.GetColumnValue<int>("ConnectionType");
						if (shouldNotSyncExternalUsers && connectionType != UserType.General) {
							string name = dataReader.GetColumnValue<string>("Name");
							_log.Warn($"Cannot sync external role {name}");
							continue;
						}
						string groupId = dataReader.GetColumnValue<string>("LDAPEntryId");
						string groupName = dataReader.GetColumnValue<string>("LDAPEntry");
						string groupDn = dataReader.GetColumnValue<string>("LDAPEntryDN");
						ldapGroups.Add(new LdapGroup(groupId, groupName, groupDn));
					}
				}
			}
			return ldapGroups;
		}

		private List<string> LoadExistingUsers() {
			Select existedUsersSelect = new Select(_userConnection)
				.Column("Name")
				.From("SysAdminUnit")
				.Where("SysAdminUnitTypeValue").IsEqual(Column.Parameter(4)) as Select;
			var existingUsers = new List<string>();
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
				using (IDataReader dr = existedUsersSelect.ExecuteReader(dbExecutor)) {
					while (dr.Read()) {
						existingUsers.Add(dr.GetValue(0).ToString());
					}
				}
			}
			return existingUsers;
		}

		private Dictionary<Guid, string> LoadExistingJobs() {
			var jobs = new Dictionary<Guid, string>();
			var jobsSelect = new Select(_userConnection)
				.Column("Id")
				.Column("Name")
				.From("Job");
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
				using (IDataReader dr = jobsSelect.ExecuteReader(dbExecutor)) {
					while (dr.Read()) {
						var id = dr.GetColumnValue<Guid>("Id");
						var name = dr.GetColumnValue<string>("Name");
						jobs.Add(id, name);
					}
				}
			}
			return jobs;
		}

		private List<LdapUser> GetLDAPUsers(LdapGroup groupItem, DateTime? minModifiedDateOfNewUser, Guid syncId) {
			using (var ldapUtils = new LdapUtilities(_userConnection)) {
				var ldapUsers = ldapUtils.GetMembersOfGroup(groupItem, minModifiedDateOfNewUser);
				_log.InfoFormat("SyncID: {2}. Found {0} LDAP users to synchronize in LDAP group {1}", ldapUsers.Count,
					groupItem.Name, syncId);
				return ldapUsers;
			}
		}

		private Guid UpdateLDAPElement(LdapUser user) {
			var ldapElementSchema = _userConnection.EntitySchemaManager.GetInstanceByName("LDAPElement");
			var ldapElementEntity = ldapElementSchema.CreateEntity(_userConnection);
			ldapElementEntity.UseAdminRights = false;
			var conditions = new Dictionary<string, object> {
				{ "LDAPEntryId", user.Id },
				{ "Type", (int)SysAdminUnitType.User }
			};
			if (ldapElementEntity.FetchFromDB(conditions)) {
				var ldapElementId = ldapElementEntity.GetTypedColumnValue<Guid>("Id");
				ldapElementEntity.SetColumnValue("IsActive", user.IsActive);
				ldapElementEntity.Save();
				return ldapElementId;
			}
			return Guid.Empty;
		}

		private Entity GetSysAdminUnit(LdapUser user, EntitySchemaQuery sysAdminUnitQuery) {
			sysAdminUnitQuery.UseAdminRights = false;
			sysAdminUnitQuery.AddAllSchemaColumns();
			var entryIdFilter =
				sysAdminUnitQuery.CreateFilterWithParameters(FilterComparisonType.Equal, "LDAPEntryId", user.Id);
			var adminUnitTypeFilter = sysAdminUnitQuery.CreateFilterWithParameters(FilterComparisonType.Equal,
				"SysAdminUnitTypeValue", (int)SysAdminUnitType.User);
			sysAdminUnitQuery.Filters.Add(entryIdFilter);
			sysAdminUnitQuery.Filters.Add(adminUnitTypeFilter);
			if (ShouldNotSyncExternalUsers()) {
				var userTypeFilter = sysAdminUnitQuery.CreateFilterWithParameters(FilterComparisonType.Equal, "ConnectionType", (int)UserType.General);
				sysAdminUnitQuery.Filters.Add(userTypeFilter);
			}
			var sysAdminUnitCollection = sysAdminUnitQuery.GetEntityCollection(_userConnection);
			return sysAdminUnitCollection.FirstOrDefault();
		}

		private void UpdateSysAdminUnit(LdapUser user, Entity sysAdminUnit, Guid ldapElementId, Guid accountId, EntitySchema contactSchema,
			EntitySchemaQueryColumn contactNameColumn, EntitySchemaQueryColumn contactAccountIdColumn) {
			sysAdminUnit.SetColumnValue("LDAPEntryId", user.Id);
			sysAdminUnit.SetColumnValue("LDAPEntry", user.Name);
			sysAdminUnit.SetColumnValue("LDAPEntryDN", user.Dn);
			sysAdminUnit.SetColumnValue("Name", user.Name);
			sysAdminUnit.SetColumnValue("Active", user.IsActive);
			sysAdminUnit.SetColumnValue("SynchronizeWithLDAP", true);
			sysAdminUnit.SetColumnValue("UserPassword", string.Empty);
			if (ldapElementId != Guid.Empty) {
				sysAdminUnit.SetColumnValue("LDAPElementId", ldapElementId);
			}
			sysAdminUnit.Save();
			UpdateContact(user, sysAdminUnit, accountId, contactSchema, contactNameColumn, contactAccountIdColumn);
		}

		private void UpdateContact(LdapUser user, Entity sysAdminUnit, Guid accountId, EntitySchema contactSchema,
			EntitySchemaQueryColumn contactNameColumn, EntitySchemaQueryColumn contactAccountIdColumn) {
			string contactName = sysAdminUnit.GetTypedColumnValue<string>(contactNameColumn.Name);
			Guid contactAccountId = sysAdminUnit.GetTypedColumnValue<Guid>(contactAccountIdColumn.Name);
			if (contactName != user.FullName || accountId != contactAccountId) {
				var contactId = sysAdminUnit.GetTypedColumnValue<Guid>("ContactId");
				var contact = contactSchema.CreateEntity(_userConnection);
				if (contact.FetchFromDB(contactId)) {
					contact.SetColumnValue("Name", user.FullName);
					contact.SetColumnValue("AccountId", accountId);
					contact.Save();
				}
			}
		}

		private void LogUserSaved(LdapUser user, Guid syncId, int totalUsers, ref int usersCount) {
			_log.InfoFormat("SyncID: {1}. LDAP user {0} saved", user.Name, syncId);
			usersCount++;
			_log.InfoFormat("SyncID: {2}. Progress: {0} users processed from {1}", usersCount, totalUsers, syncId);
		}

		private void LogUserDeactivated(LdapUser user, Guid syncId) {
			_log.InfoFormat("SyncID: {1}. User AD {0} - deactivated", user.Name, syncId);
		}

		private void LogExistingUser(LdapUser user, Guid syncId, int totalUsers, ref int usersCount, ref int errors) {
			_log.InfoFormat("SyncID: {1}. Existing user has the LDAP username - {0}", user.Name, syncId);
			usersCount++;
			_log.InfoFormat("SyncID: {2}. Progress: {0} users processed from {1}", usersCount, totalUsers, syncId);
			errors++;
		}

		private void CreateContact(EntitySchema contactSchema, EntitySchema employeeSchema, Guid contactId, LdapUser user, Guid accountId, Dictionary<Guid, string> jobs) {
			var contact = contactSchema.CreateEntity(_userConnection);
			string jobTitle = user.JobTitle;
			Guid? jobId = GetJobIdByName(jobs, jobTitle);
			contact.SetDefColumnValues();
			contact.SetColumnValue("Id", contactId);
			contact.SetColumnValue(employeeSchema.PrimaryColumn.Name, contactId);
			contact.SetColumnValue("Name", user.FullName);
			contact.SetColumnValue("AccountId", accountId);
			contact.SetColumnValue("Email", user.Email);
			contact.SetColumnValue("Phone", user.Phone);
			contact.SetColumnValue("JobId", jobId);
			contact.SetColumnValue("JobTitle", jobTitle);
			contact.Save();
		}

		private void LogUserAlreadyAdded(LdapUser user, Guid syncId, int totalUsers, ref int usersCount) {
			_log.InfoFormat("SyncID: {1}. LDAP user {0} already added", user.Name, syncId);
			usersCount++;
			_log.InfoFormat("SyncID: {2}. Progress: {0} users processed from {1}", usersCount, totalUsers, syncId);
		}

		private void InitializeSysAdminUnit(Entity sysAdminUnit, EntitySchema sysAdminUnitSchema, Guid newUserId, Guid contactId, LdapUser user, UserType connectionType, Guid defaultSysCultureId, Guid ldapElementId) {
			sysAdminUnit.SetDefColumnValues();
			sysAdminUnit.SetColumnValue(sysAdminUnitSchema.PrimaryColumn.Name, newUserId);
			sysAdminUnit.SetColumnValue("SysAdminUnitTypeValue", (int)SysAdminUnitType.User);
			sysAdminUnit.SetColumnValue("ContactId", contactId);
			sysAdminUnit.SetColumnValue("LDAPEntryId", user.Id);
			sysAdminUnit.SetColumnValue("LDAPEntry", user.Name);
			sysAdminUnit.SetColumnValue("Name", user.Name);
			sysAdminUnit.SetColumnValue("SynchronizeWithLDAP", true);
			sysAdminUnit.SetColumnValue("Active", true);
			sysAdminUnit.SetColumnValue("UserPassword", string.Empty);
			sysAdminUnit.SetColumnValue("ConnectionType", connectionType);
			if (defaultSysCultureId != Guid.Empty) {
				sysAdminUnit.SetColumnValue("SysCultureId", defaultSysCultureId);
			}
			if (ldapElementId != Guid.Empty) {
				sysAdminUnit.SetColumnValue("LDAPElementId", ldapElementId);
			}
		}

		private HashSet<Guid> UpdateUsersInAllGroups(Guid syncId) {
			Select selectAllGroups = new Select(_userConnection)
					.Column("LDAPEntryId")
					.Column("LDAPEntry")
					.Column("LDAPEntryDN")
					.Column("Id")
					.Column("Name")
				.From("SysAdminUnit").Where("SynchronizeWithLDAP").IsEqual(Column.Parameter(true))
				.And("SysAdminUnitTypeValue").Not().IsEqual(Column.Parameter((int)SysAdminUnitType.User)) as Select;
			if (ShouldNotSyncExternalUsers()) {
				selectAllGroups?.And("ConnectionType").IsEqual(Column.Parameter((int)UserType.General));
			}
			var oldUsersWithChangedRolesIds = new HashSet<Guid>();
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
				using (IDataReader dr = selectAllGroups?.ExecuteReader(dbExecutor)) {
					while (dr.Read()) {
						var ldapEntryId = dr.GetValue(0).ToString();
						var ldapEntry = dr.GetValue(1).ToString();
						var ldapEntryDn = dr.GetValue(2).ToString();
						var groupId = new Guid(dr.GetValue(3).ToString());
						var ldapGroup = new LdapGroup(ldapEntryId, ldapEntry, ldapEntryDn);
						var changedUserIds = CheckUsersInGroup(ldapGroup, groupId, syncId, out _);
						oldUsersWithChangedRolesIds.AddRange(changedUserIds);
					}
				}
			}
			return oldUsersWithChangedRolesIds;
		}

		private Guid GetAccountId(LdapUser user) {
			return GetIdByName(user.Company, "Account", false) ?? AccountConsts.OurCompanyAccountId;
		}

		private bool AddUserToRolesIfNotExist(Guid userId, Guid groupId, UserType connectionType) {
			Guid mainGroupId = connectionType == UserType.SSP ? _sspUsersGroupId : _allEmployeesGroupId;
			var rolesChanged = AddUserToRoleIfNotExist(userId, mainGroupId) | AddUserToRoleIfNotExist(userId, groupId);
			return rolesChanged;
		}

		private bool AddUserToRoleIfNotExist(Guid userId, Guid groupId) {
			var userInRoleSelect =
				(Select)new Select(_userConnection)
					.Column(Func.Count(Column.Const(1)))
					.From("SysUserInRole")
					.Where("SysUserId").IsEqual(Column.Parameter(userId))
					.And("SysRoleId").IsEqual(Column.Parameter(groupId));
			int recordCount = userInRoleSelect.ExecuteScalar<int>();
			if (recordCount == 0) {
				var sysUserInRoleSchema = _userConnection.EntitySchemaManager.FindInstanceByName("SysUserInRole");
				Entity sysUserInRole = sysUserInRoleSchema.CreateEntity(_userConnection);
				sysUserInRole.UseAdminRights = false;
				sysUserInRole.SetDefColumnValues();
				sysUserInRole.SetColumnValue("SysUserId", userId);
				sysUserInRole.SetColumnValue("SysRoleId", groupId);
				return sysUserInRole.Save();
			}
			return false;
		}

		private IEnumerable<Guid> CheckAllLDAPUsersInEverySyncGroup(Guid syncId, out DateTime? minModifiedDateOfNewUser) {
			var oldUsersWithChangedRolesIds = new HashSet<Guid>();
			var delete = new Delete(_userConnection).From("SysLDAPSynchGroup");
			if (syncId.IsNotEmpty()) {
				delete.Where("LdapSyncId").IsEqual(Column.Parameter(syncId));
			}
			delete.Execute();

			minModifiedDateOfNewUser = null;

			using (var ldapUtils = new LdapUtilities(_userConnection)) {
				int groupsCount = ldapUtils.InsertGroupsToTable(syncId);
				if (groupsCount < 1) {
					return oldUsersWithChangedRolesIds;
				}
			}
			if (_userConnection.GetIsFeatureEnabled("DeactivateExcludedLdapUsers")) {
				DeactivateExcludedLDAPUsers(syncId);
			}

			var update = UpdateSysAdminUnitEntriesQuery();
			int operationsCount = update.Execute();

			var adminUnitExistsSubSelect = CreateAdminUnitExistsSubSelect(syncId);
			var adminUnitNotExistsSubSelect = CreateAdminUnitNotExistsSubSelect(syncId);
			delete = new Delete(_userConnection).From("SysLDAPSynchGroup");
			if (syncId.IsEmpty()) {
				delete.Where().Exists(adminUnitExistsSubSelect)
					.Or().Not().Exists(adminUnitNotExistsSubSelect);
			} else {
				delete.Where("LdapSyncId").IsEqual(Column.Parameter(syncId))
					.And().Exists(adminUnitExistsSubSelect)
					.Or().Not().Exists(adminUnitNotExistsSubSelect);
				QueryCondition where = delete.Condition;
				QueryCondition existsCondition = delete.Condition[1];
				QueryCondition notExistsCondition = delete.Condition[2];
				existsCondition.WrapBlock();
				existsCondition.Add(notExistsCondition);
				where.Remove(notExistsCondition);
			}
			delete.Execute();

			Select selectGroupProperties =
				new Select(_userConnection)
					.Column("Id")
					.Column("Name")
					.Column("Dn")
				.From("SysLDAPSynchGroup");
			if (syncId.IsNotEmpty()) {
				selectGroupProperties.Where("LdapSyncId").IsEqual(Column.Parameter(syncId));
			}
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = selectGroupProperties.ExecuteReader(dbExecutor)) {
					while (dataReader.Read()) {
						var ldapEntryId = dataReader.GetValue(0).ToString();
						var ldapEntry = dataReader.GetValue(1).ToString();
						var ldapEntryDn = dataReader.GetValue(2).ToString();
						update = new Update(_userConnection, "SysAdminUnit")
							.Set("LDAPEntry", Column.Parameter(ldapEntry))
							.Set("LDAPEntryDN", Column.Parameter(ldapEntryDn))
							.Where("LDAPEntryId").IsEqual(Column.Parameter(ldapEntryId))
							.And("SysAdminUnitTypeValue").Not().IsEqual(Column.Const((int)SysAdminUnitType.User));
						if (ShouldNotSyncExternalUsers()) {
							update.And("ConnectionType").IsEqual(Column.Parameter((int)UserType.General));
						}
						update.Execute();
						operationsCount++;
					}
				}
			}
			_log.InfoFormat("SyncID: {1}. LDAP fields have been updated for {0} group(s)", operationsCount, syncId);

			delete = new Delete(_userConnection)
				.From("SysLDAPSynchGroup");
			if (syncId.IsNotEmpty()) {
				delete.Where("LdapSyncId").IsEqual(Column.Parameter(syncId));
			}
			delete.Execute();

			oldUsersWithChangedRolesIds = UpdateAdminRoles(syncId, ref minModifiedDateOfNewUser);
			return oldUsersWithChangedRolesIds;
		}

		private Query CreateAdminUnitExistsSubSelect(Guid syncId) {
			var adminUnitExistsSubSelect = new Select(_userConnection)
				.Column("Id")
				.From("SysAdminUnit")
				.Where("SysLDAPSynchGroup", "Id").IsEqual("SysAdminUnit", "LDAPEntryId")
				.And("SysLDAPSynchGroup", "Name").IsEqual("SysAdminUnit", "LDAPEntry")
				.And("SysLDAPSynchGroup", "Dn").IsEqual("SysAdminUnit", "LDAPEntryDN")
				.And("SysAdminUnit", "SysAdminUnitTypeValue").Not()
				.IsEqual(Column.Parameter((int)SysAdminUnitType.User));
			if (syncId.IsNotEmpty()) {
				adminUnitExistsSubSelect.And("SysLDAPSynchGroup", "LdapSyncId").IsEqual(Column.Parameter(syncId));
			}
			return adminUnitExistsSubSelect;
		}

		private Query CreateAdminUnitNotExistsSubSelect(Guid syncId) {
			var adminUnitNotExistsSubSelect = new Select(_userConnection)
				.Column("Id")
				.From("SysAdminUnit")
				.Where("SysLDAPSynchGroup", "Id").IsEqual("SysAdminUnit", "LDAPEntryId")
				.And("SysAdminUnit", "SysAdminUnitTypeValue").Not()
				.IsEqual(Column.Parameter((int)SysAdminUnitType.User));
			if (syncId.IsNotEmpty()) {
				adminUnitNotExistsSubSelect.And("SysLDAPSynchGroup", "LdapSyncId").IsEqual(Column.Parameter(syncId));
			}
			return adminUnitNotExistsSubSelect;
		}

		private void DeactivateExcludedLDAPUsers(Guid syncId) {
			var groupExistsSubSelectQuery = CreateGroupExistsSubSelectQuery(syncId);
			var updateUsers = CreateUpdateUsersQuery(groupExistsSubSelectQuery);
			int deactivatedUsers = updateUsers.Execute();
			_log.InfoFormat("SyncID: {1}. {0} users from deleted groups were deactivated", deactivatedUsers, syncId);
		}

		private Query CreateGroupExistsSubSelectQuery(Guid syncId) {
			var groupExistsSubSelectQuery = new Select(_userConnection)
				.Column("Id")
				.From("SysLDAPSynchGroup")
				.Where("SysLDAPSynchGroup", "Id").IsEqual("AdminRole", "LDAPEntryId");
			if (syncId.IsNotEmpty()) {
				groupExistsSubSelectQuery.And("LdapSyncId").IsEqual(Column.Parameter(syncId));
			}
			return groupExistsSubSelectQuery;
		}

		private Query CreateUpdateUsersQuery(Query groupExistsSubSelectQuery) {
			var updateUsers = new Update(_userConnection, "SysAdminUnit")
				.Set("Active", Column.Parameter(false))
				.Where("SynchronizeWithLDAP").IsEqual(Column.Parameter(true))
				.And("SysAdminUnitTypeValue").IsEqual(Column.Parameter((int)SysAdminUnitType.User))
				.And().Exists(
					new Select(_userConnection)
						.Column("Id")
						.From("SysUserInRole")
						.Where("SysUserInRole", "SysUserId").IsEqual("SysAdminUnit", "Id")
						.And().Exists(
							new Select(_userConnection)
								.Column("Id")
								.From("SysAdminUnit").As("AdminRole")
								.Where("AdminRole", "Id").IsEqual("SysUserInRole", "SysRoleId")
								.And("AdminRole", "SysAdminUnitTypeValue")
								.Not().IsEqual(Column.Parameter((int)SysAdminUnitType.User))
								.And("AdminRole", "SynchronizeWithLDAP").IsEqual(Column.Parameter(true))
								.And().Not().Exists(groupExistsSubSelectQuery)))
				.And().Not().Exists(
					new Select(_userConnection)
						.Column("Id")
						.From("SysUserInRole")
						.Where("SysUserInRole", "SysUserId").IsEqual("SysAdminUnit", "Id")
						.And().Exists(
							new Select(_userConnection)
								.Column("Id")
								.From("SysAdminUnit").As("AdminRole")
								.Where("AdminRole", "Id").IsEqual("SysUserInRole", "SysRoleId")
								.And("AdminRole", "SysAdminUnitTypeValue")
								.Not().IsEqual(Column.Parameter((int)SysAdminUnitType.User))
								.And("AdminRole", "SynchronizeWithLDAP").IsEqual(Column.Parameter(true))
								.And().Exists(groupExistsSubSelectQuery)));
			if (ShouldNotSyncExternalUsers()) {
				updateUsers.And("ConnectionType").IsEqual(Column.Parameter((int)UserType.General));
			}
			return updateUsers;
		}

		private Query UpdateSysAdminUnitEntriesQuery() {
			var update = new Update(_userConnection, "SysAdminUnit")
				.Set("SynchronizeWithLDAP", Column.Parameter(false))
				.Set("LDAPEntryId", Column.Parameter(string.Empty))
				.Set("LDAPEntry", Column.Parameter(string.Empty))
				.Set("LDAPEntryDN", Column.Parameter(string.Empty))
				.Set("LDAPElementId", Column.Parameter(null, "Guid"))
				.Where("SynchronizeWithLDAP").IsEqual(Column.Parameter(true))
				.And("SysAdminUnitTypeValue").Not().IsEqual(Column.Parameter((int)SysAdminUnitType.User))
				.And().Not().Exists(
					new Select(_userConnection)
						.Column("Id")
						.From("SysLDAPSynchGroup")
						.Where("SysLDAPSynchGroup", "Id").IsEqual("SysAdminUnit", "LDAPEntryId"));
			if (ShouldNotSyncExternalUsers()) {
				update.And("ConnectionType").IsEqual(Column.Parameter((int)UserType.General));
			}
			return update;
		}

		private HashSet<Guid> UpdateAdminRoles(Guid syncId, ref DateTime? minModifiedDateOfNewUser) {
			var oldUsersWithChangedRolesIds = new HashSet<Guid>();
			var selectAdminRoles = new Select(_userConnection)
				.Column("LDAPEntryId")
				.Column("LDAPEntry")
				.Column("LDAPEntryDN")
				.Column("Id")
				.Column("Name")
				.Column("ConnectionType")
				.From("SysAdminUnit")
				.Where("SynchronizeWithLDAP").IsEqual(Column.Parameter(true))
				.And("SysAdminUnitTypeValue").Not().IsEqual(Column.Parameter((int)SysAdminUnitType.User)) as Select;
			bool shouldNotSyncExternalUsers = ShouldNotSyncExternalUsers();
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = selectAdminRoles.ExecuteReader(dbExecutor)) {
					while (dataReader.Read()) {
						var connectionType = (UserType)dataReader.GetColumnValue<int>("ConnectionType");
						if (shouldNotSyncExternalUsers && connectionType != UserType.General) {
							var name = dataReader.GetColumnValue<string>("Name");
							_log.Warn($"Cannot sync external role {name}");
							continue;
						}
						var ldapEntryId = dataReader.GetColumnValue<string>("LDAPEntryId");
						var ldapEntry = dataReader.GetColumnValue<string>("LDAPEntry");
						var ldapEntryDn = dataReader.GetColumnValue<string>("LDAPEntryDN");
						var groupId = dataReader.GetColumnValue<Guid>("Id");
						var changedUserIds = CheckUsersInGroup(new LdapGroup(ldapEntryId, ldapEntry, ldapEntryDn), groupId, syncId,
							out DateTime? minModifiedDate);
						oldUsersWithChangedRolesIds.AddRange(changedUserIds);
						if (minModifiedDate.HasValue && (!minModifiedDateOfNewUser.HasValue ||
								minModifiedDateOfNewUser.Value > minModifiedDate.Value)) {
							minModifiedDateOfNewUser = minModifiedDate;
						}
					}
				}
			}
			return oldUsersWithChangedRolesIds;
		}

		private void DeactivateDeletedAdUsers(Guid syncId) {
			if (!_userConnection.GetIsFeatureEnabled("DeactivateDeletedAdUsers")) {
				return;
			}
			try {
				using (var ldapUtils = new LdapUtilities(_userConnection)) {
					ldapUtils.InsertUsersIdsToTableByFilter(syncId);
					Select ldapUserIdsSelect =
						new Select(_userConnection)
							.Column("Id")
						.From("SysLDAPSynchUser");
					if (syncId.IsNotEmpty()) {
						ldapUserIdsSelect.Where("LdapSyncId").IsEqual(Column.Parameter(syncId));
					}
					var update = new Update(_userConnection, "SysAdminUnit")
							.Set("Active", Column.Parameter(false))
						.Where("LDAPEntryId")
							.Not().In(ldapUserIdsSelect)
						.And("SysAdminUnit", "SysAdminUnitTypeValue")
							.IsEqual(Column.Parameter((int)SysAdminUnitType.User))
						.And("Active")
							.IsEqual(Column.Parameter(true))
						.And("SynchronizeWithLDAP")
							.IsEqual(Column.Parameter(true));
					if (ShouldNotSyncExternalUsers()) {
						update.And("ConnectionType").IsEqual(Column.Parameter((int)UserType.General));
					}
					int deactivatedUsersCount = update.Execute();
					_log.InfoFormat("SyncID: {1}. {0} user(s) were deactivated in system, because they were deleted from AD.",
						deactivatedUsersCount, syncId);
				}
			} finally {
				var delete = new Delete(_userConnection)
					.From("SysLDAPSynchUser");
				if (syncId.IsNotEmpty()) {
					delete.Where("LdapSyncId").IsEqual(Column.Parameter(syncId));
				}
				delete.Execute();
			}
		}

		private void DeactivateExcludedUsers(Guid syncId) {
			if (!ShouldDeactivateExcludedUsers()) {
				return;
			}
			var update = CreateDeactivateExcludedUsersUpdateQuery();
			int updateResult = update.Execute();
			_log.InfoFormat("SyncID: {1}. {0} users were deactivated", updateResult, syncId);
		}

		private bool ShouldDeactivateExcludedUsers() {
			return _userConnection.GetIsFeatureEnabled("DeactivateExcludedLdapUsers")
				&& SysSettings.GetValue<bool>(_userConnection, "LDAPSynchronizeOnlyGroups", false);
		}

		private Query CreateDeactivateExcludedUsersUpdateQuery() {
			var update = new Update(_userConnection, "SysAdminUnit")
				.Set("Active", Column.Parameter(false))
				.Where("SysAdminUnit", "SynchronizeWithLDAP").IsEqual(Column.Parameter(true))
				.And("SysAdminUnit", "SysAdminUnitTypeValue").IsEqual(Column.Parameter((int)SysAdminUnitType.User))
				.And().Not().Exists(
					new Select(_userConnection)
						.Column("SysUserInRole", "Id")
						.From("SysUserInRole")
						.Where("SysUserInRole", "SysUserId").IsEqual("SysAdminUnit", "Id")
						.And().Exists(
							new Select(_userConnection)
								.Column("SysAdminRole", "Id")
								.From("SysAdminUnit").As("SysAdminRole")
								.Where("SysAdminRole", "SynchronizeWithLDAP").IsEqual(Column.Parameter(true))
								.And("SysAdminRole", "SysAdminUnitTypeValue").IsNotEqual(Column.Parameter((int)SysAdminUnitType.User))
								.And("SysAdminRole", "Id").IsEqual("SysUserInRole", "SysRoleId")));
			if (ShouldNotSyncExternalUsers()) {
				update.And("ConnectionType").IsEqual(Column.Parameter((int)UserType.General));
			}
			return update;
		}

		private bool ShouldNotSyncExternalUsers() {
			return _userConnection.AppConnection.IsDemoMode ||
				!_userConnection.LicHelper.GetHasOperationLicense("CanUseLdapForExternalUsers");
		}

		#endregion

		#region Methods: Internal

		internal void UpdateLDAPUsersWhichCanBeSynchronized(Guid syncId) {
			try {
				using (var ldapUtils = new LdapUtilities(_userConnection)) {
					int usersCount = ldapUtils.InsertUsersToTable(syncId);
					if (usersCount < 1) {
						return;
					}
					var delete =
						new Delete(_userConnection)
						.From("SysLDAPSynchUser")
						.Where().Not().Exists(
							new Select(_userConnection)
								.Column("Id")
							.From("SysAdminUnit")
							.Where("SysLDAPSynchUser", "Id").IsEqual("SysAdminUnit", "LDAPEntryId"));
					if (syncId.IsNotEmpty()) {
						delete.And("LdapSyncId").IsEqual(Column.Parameter(syncId));
					}
					delete.Execute();
					var synchronizeOnlyGroups = _userConnection.GetIsFeatureEnabled("DeactivateExcludedLdapUsers")
						&& SysSettings.GetValue<bool>(_userConnection, "LDAPSynchronizeOnlyGroups", false);
					if (!synchronizeOnlyGroups) {
						var isActiveSubSelect = new Select(_userConnection)
							.Column("IsActive")
						.From("SysLDAPSynchUser")
						.Where("SysLDAPSynchUser", "Id").IsEqual("SysAdminUnit", "LDAPEntryId");
						if (syncId.IsNotEmpty()) {
							isActiveSubSelect.And("LdapSyncId").IsEqual(Column.Parameter(syncId));
						}
						Query existingUsersSubSelect
							= new Select(_userConnection)
								.Column("Id")
							.From("SysLDAPSynchUser")
							.Where("SysLDAPSynchUser", "Id").IsEqual("SysAdminUnit", "LDAPEntryId");
						if (syncId.IsNotEmpty()) {
							existingUsersSubSelect.And("LdapSyncId").IsEqual(Column.Parameter(syncId));
						}
						var update =
							new Update(_userConnection, "SysAdminUnit")
								.Set("Active", isActiveSubSelect)
							.Where("SynchronizeWithLDAP").IsEqual(Column.Parameter(true))
							.And("SysAdminUnitTypeValue").IsEqual(Column.Parameter((int)SysAdminUnitType.User))
							.And().Exists(existingUsersSubSelect);
						if (ShouldNotSyncExternalUsers()) {
							update.And("ConnectionType").IsEqual(Column.Parameter((int)UserType.General));
						}
						var updateResult = update.Execute();
						_log.InfoFormat("SyncID: {1}. {0} users became active", updateResult, syncId);
						var currentUser = _userConnection.CurrentUser;
						DateTime currentDateTime = currentUser.GetCurrentDateTime();
						var select =
							new Select(_userConnection)
								.Column("Name")
							.From("SysLDAPSynchUser")
							.Where("Id").IsEqual("SysAdminUnit", "LDAPEntryId")
							.And("SysLDAPSynchUser", "Name").IsNotEqual("SysAdminUnit", "LDAPEntry");
						if (syncId.IsNotEmpty()) {
							select.And("LdapSyncId").IsEqual(Column.Parameter(syncId));
						}
						update =
							new Update(_userConnection, "SysAdminUnit")
								.Set("ModifiedOn", Column.Parameter(currentDateTime))
								.Set("ModifiedById", Column.Parameter(currentUser.Id))
								.Set("LDAPEntry", select)
							.Where().Exists(select)
							.And("SysAdminUnitTypeValue").IsEqual(Column.Const((int)SysAdminUnitType.User)) as Update;
						if (ShouldNotSyncExternalUsers()) {
							update.And("ConnectionType").IsEqual(Column.Parameter((int)UserType.General));
						}
						update.Execute();
					}
					if (ldapUtils.IsPhoneNeedUpdate || ldapUtils.IsEmailNeedUpdate || ldapUtils.IsJobTitleNeedUpdate) {
						var operationCount = 0;
						var jobs = new Dictionary<Guid, string>();
						var jobsSelect =
							new Select(_userConnection)
								.Column("Id")
								.Column("Name")
							.From("Job");
						var contactQuery = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "Contact");
						contactQuery.AddAllSchemaColumns();
						EntitySchemaQueryColumn ldapEntryColumn = contactQuery.AddColumn("[SysAdminUnit:Contact].LDAPEntryId");
						contactQuery.UseAdminRights = false;
						string ldapEntryColumnName = ldapEntryColumn.Name;
						contactQuery.Filters.Add(contactQuery.CreateFilterWithParameters(FilterComparisonType.Equal,
							"[SysAdminUnit:Contact].Active", true));
						contactQuery.Filters.Add(contactQuery.CreateFilterWithParameters(FilterComparisonType.IsNotNull,
							"[SysAdminUnit:Contact].LDAPEntryId"));
						contactQuery.Filters.Add(contactQuery.CreateFilterWithParameters(FilterComparisonType.Equal,
							"[SysAdminUnit:Contact].SysAdminUnitTypeValue", (int)SysAdminUnitType.User));
						if (ShouldNotSyncExternalUsers()) {
							contactQuery.Filters.Add(contactQuery.CreateFilterWithParameters(FilterComparisonType.Equal,
							"[SysAdminUnit:Contact].ConnectionType", (int)UserType.General));
						}
						EntityCollection contacts = contactQuery.GetEntityCollection(_userConnection);
						var ldapUsersSelect =
							new Select(_userConnection)
								.Column("Id")
								.Column("Email")
								.Column("Phone")
								.Column("JobTitle")
							.From("SysLDAPSynchUser");
						if (syncId.IsNotEmpty()) {
							ldapUsersSelect.Where("LdapSyncId").IsEqual(Column.Parameter(syncId));
						}
						using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
							using (IDataReader dr = jobsSelect.ExecuteReader(dbExecutor)) {
								while (dr.Read()) {
									var id = dr.GetColumnValue<Guid>("Id");
									var name = dr.GetColumnValue<string>("Name");
									jobs.Add(id, name);
								}
							}
							using (IDataReader dr = ldapUsersSelect.ExecuteReader(dbExecutor)) {
								while (dr.Read()) {
									var ldapEntryId = dr.GetColumnValue<string>("Id");
									var email = dr.GetColumnValue<string>("Email");
									var phone = dr.GetColumnValue<string>("Phone");
									var jobTitle = dr.GetColumnValue<string>("JobTitle");
									Entity contact = contacts.Find(entity =>
										entity.GetTypedColumnValue<string>(ldapEntryColumnName) == ldapEntryId);
									if (contact == null) {
										_log.InfoFormat("SyncID: {1}. Could not find contact for ldapEntryId={0}",
											ldapEntryId, syncId);
										continue;
									}
									if (ldapUtils.IsEmailNeedUpdate) {
										contact.SetColumnValue("Email", email);
									}
									if (ldapUtils.IsPhoneNeedUpdate) {
										contact.SetColumnValue("Phone", phone);
									}
									if (ldapUtils.IsJobTitleNeedUpdate) {
										Guid? jobId = GetJobIdByName(jobs, jobTitle);
										contact.SetColumnValue("JobId", jobId);
										contact.SetColumnValue("JobTitle", jobTitle);
									}
									contact.Save();
									operationCount++;
								}
							}
						}
						_log.InfoFormat("SyncID: {1}. LDAP fields have been updated for {0} user(s)", operationCount, syncId);
					}
				}
			} catch (Exception e) {
				_log.ErrorFormat("SyncID: {1}. {0}", e, e.Message, syncId);
				throw;
			} finally {
				var delete = new Delete(_userConnection)
					.From("SysLDAPSynchUser");
				if (syncId.IsNotEmpty()) {
					delete.Where("LdapSyncId").IsEqual(Column.Parameter(syncId));
				}
				delete.Execute();
			}
		}

		#endregion

		#region Methods: Public

		public void SetEntryMaxModifiedOn(DateTime synchronizationDate) {
			if (SysSettings.Exists(_userConnection, "LDAPEntryMaxModifiedOn")) {
				SysSettings.SetDefValue(_userConnection, "LDAPEntryMaxModifiedOn", synchronizationDate);
			}
		}

		public Guid? GetJobIdByName(Dictionary<Guid, string> jobs, string name) {
			if (string.IsNullOrEmpty(name)) {
				return null;
			}
			foreach (KeyValuePair<Guid, string> item in jobs) {
				if (item.Value.Equals(name, StringComparison.InvariantCulture)) {
					return item.Key;
				}
			}
			var job = new Job(_userConnection);
			job.SetDefColumnValues();
			job.Name = name;
			job.Save();
			Guid jobId = job.Id;
			jobs.Add(jobId, name);
			return jobId;
		}

		[Obsolete("7.18.2. Use UpdateLDAPUsersWhichCanBeSynchronized(Guid)")]
		public void CheckLDAPUsersWhichCanBeSynchronized() {
			UpdateLDAPUsersWhichCanBeSynchronized(Guid.Empty);
		}

		public void SyncWithLDAP() {
			try {
				var useLdapSyncId = _userConnection.GetIsFeatureEnabled("UseLDAPSyncId");
				var syncId = useLdapSyncId
					? Guid.NewGuid()
					: Guid.Empty;
				_log.InfoFormat("Starting LDAP synchonization with id {0}", syncId);

				// Update synchronized users
				UpdateLDAPUsersWhichCanBeSynchronized(syncId);

				// Checking if the LDAP users are part of the synchronized business units
				var changedUserIds = CheckAllLDAPUsersInEverySyncGroup(syncId, out DateTime ? minModifiedDateOfNewUser);

				// Import users automatically
				ImportUsers(minModifiedDateOfNewUser, syncId, changedUserIds,
					out DateTime? maxModificationDateOfLDAPEntry);

				DeactivateDeletedAdUsers(syncId);

				DeactivateExcludedUsers(syncId);

				if (maxModificationDateOfLDAPEntry.HasValue) {
					SetEntryMaxModifiedOn(maxModificationDateOfLDAPEntry.Value);
				}

			} catch (Exception e) {
				_log.Error(e.Message, e);
				throw;
			}
		}

		public List<LDAPLicenseInfo> GetUsersWithMissingLicenses() {
			return _usersWithoutLicenses;
		}

		#endregion

	}

	#endregion

}

