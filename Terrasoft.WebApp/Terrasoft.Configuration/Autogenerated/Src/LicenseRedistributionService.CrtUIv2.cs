namespace Terrasoft.Configuration.CrtUIv2
{
	using System;
	using System.Collections.Generic;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;
	using global::Common.Logging;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Licensing;
	using SystemSettings = Core.Configuration.SysSettings;

	#region Interface: ILicenseRedistributionService

	/// <summary>
	/// Service responsible for license redistribution
	/// </summary>
	public interface ILicenseRedistributionService
	{

		#region Methods: Public

		/// <summary>
		/// Redistributes licences for all users
		/// </summary>
		/// <param name="redistributeManuallyAssignedLicences">Specifies if manually assigned licences should be redistributed</param>
		void RedistributeLicences(bool redistributeManuallyAssignedLicences);
		
		/// <summary>
		/// Redistributes licences for all users within specified role
		/// </summary>
		/// <param name="redistributeManuallyAssignedLicences">Specifies if manually assigned licences should be redistributed</param>
		/// <param name="roleId">Identifier of role for which licenses should be distributed</param>
		void RedistributeLicencesForRole(bool redistributeManuallyAssignedLicences, Guid roleId);

		/// <summary>
		/// Redistributes licences for specific user
		/// </summary>
		/// <param name="redistributeManuallyAssignedLicences">Specifies if manually assigned licences should be redistributed</param>
		/// <param name="userId">Identifier of user role for which license distribution should be started</param>
		/// <param name="hasManuallyAssignedLicense">Specifies if there are any manually assigned licenses for this user</param>
		void RedistributeLicencesForUser(Guid userId, bool redistributeManuallyAssignedLicences = false, 
			bool hasManuallyAssignedLicense = false);

		#endregion

	}
	
	#endregion
	
	#region Class: LicenseRedistributionService

	[DefaultBinding(typeof(ILicenseRedistributionService))]
	public class LicenseRedistributionService : ILicenseRedistributionService
	{
			
		#region Fields: Private

		private readonly ILog _log;
		private readonly UserConnection _userConnection;
		private readonly RemindingUtilities _remindingUtilities;
		private readonly ILicManager _licManager;
		
		#endregion
		
		#region Constructors: Public

		public LicenseRedistributionService(UserConnection userConnection) {
			_userConnection = userConnection;
			_log = LogManager.GetLogger(nameof(LicenseRedistributionService));
			_remindingUtilities = ClassFactory.Get<RemindingUtilities>();
			_licManager = ClassFactory.Get<ILicManager>();
		}
		
		#endregion
		
		#region Methods: Private
		
		private string GetLocalizableValue(string key) {
			return new LocalizableString(_userConnection.ResourceStorage, "LicenseRedistributionService",
				$"LocalizableStrings.{key}.Value").ToString();
		}
		
		private Select GetActiveUsersFromSpecificRoleSelect(Guid roleId) {
			var queryCase = GetSubQueryToFetchInfoAboutManuallyAssignedLicences("SysUserInRole", "SysUserId");
			var select = 
				(Select)new Select(_userConnection)
							.Column("SysUserInRole", "SysUserId").As("Id")
							.Column(queryCase).As("HasManuallyAssignedLicense")
						.From("SysUserInRole")
						.InnerJoin("SysAdminUnit")
							.On("SysAdminUnit", "Id")
							.IsEqual("SysUserInRole", "SysUserId")
						.Where("SysUserInRole", "SysRoleId").IsEqual(Column.Parameter(roleId))
						.And("SysAdminUnit", "SysAdminUnitTypeValue").IsEqual(Column.Parameter(SysAdminUnitType.User))
						.And("SysAdminUnit", "Active").IsEqual(Column.Parameter(true));
			return select;
		}
		
		private Select GetActiveUsersFromEntireRoleHierarchySelect(Guid roleId) {
			var queryCase = GetSubQueryToFetchInfoAboutManuallyAssignedLicences("SysAdminUnitInRole", "SysAdminUnitId");
			var select = 
				(Select)new Select(_userConnection)
							.Column("SysAdminUnitInRole", "SysAdminUnitId").As("Id")
							.Column(queryCase).As("HasManuallyAssignedLicense")
						.From("SysAdminUnitInRole")
						.InnerJoin("SysAdminUnit")
							.On("SysAdminUnit", "Id")
							.IsEqual("SysAdminUnitInRole", "SysAdminUnitId")
						.Where("SysAdminUnitInRole", "SysAdminUnitRoleId").IsEqual(Column.Parameter(roleId))
						.And("SysAdminUnit", "SysAdminUnitTypeValue").IsEqual(Column.Parameter(SysAdminUnitType.User))
						.And("SysAdminUnit", "Active").IsEqual(Column.Parameter(true));
			return select;
		}

		private Select GetAllActiveUsersSelect() {
			var queryCase = GetSubQueryToFetchInfoAboutManuallyAssignedLicences("SysAdminUnit", "Id");
			var select = 
				(Select)new Select(_userConnection)
							.Column("Id")
							.Column(queryCase) .As("HasManuallyAssignedLicense")
						.From("SysAdminUnit")
						.Where("SysAdminUnitTypeValue").IsEqual(Column.Parameter(SysAdminUnitType.User))
						.And("Active").IsEqual(Column.Parameter(true));
			return select;
		}
		
		private QueryCase GetSubQueryToFetchInfoAboutManuallyAssignedLicences(string tableContainingUsers, string userIdColumnName) {
			var queryCase = new QueryCase();
			var condition = new QueryCondition(QueryConditionType.Exist);
			var subSelect = 
				new Select(_userConnection).Column("Id")
				.From("SysLicUser")
				.Where("SysLicUser", "SysUserId")
					.IsEqual(tableContainingUsers, userIdColumnName)
				.And("SysLicUser", "Source")
					.IsEqual(Column.Parameter(SysLicSource.Manual));
			var expression = new QueryColumnExpression(subSelect);
			condition.RightExpressions.Add(expression);
			queryCase.AddWhenItem(condition, Column.Parameter(true));
			queryCase.ElseExpression = Column.Parameter(false);
			return queryCase;
		}

		private HashSet<(Guid userId, bool hasManuallyAssignedLicense)> FetchUsersEligibleForLicenseDistribution(Select selectQuery) {
			var users = new HashSet<(Guid userId, bool hasManuallyAssignedLicense)>();
			selectQuery.ExecuteReader(dataReader => {
				var userId = dataReader.GetColumnValue<Guid>("Id");
				var hasManuallyAssignedLicense = dataReader.GetColumnValue<bool>("HasManuallyAssignedLicense");
				users.Add((userId, hasManuallyAssignedLicense));
			});
			return users;
		}
		
		private void GetManuallyAssignedLicenseIds(Guid userId, List<Guid> manuallyAssignedLicenseIds) {
			var select = 
				(Select)new Select(_userConnection)
							.Column("Id")
						.From("SysLicUser")
						.Where("SysUserId").IsEqual(Column.Parameter(userId))
						.And("Source").IsEqual(Column.Parameter(SysLicSource.Manual));
			select.ExecuteReader(dataReader => {
				var recordId = dataReader.GetColumnValue<Guid>("Id");
				manuallyAssignedLicenseIds.Add(recordId);
			});
		}
		
		private string GetRoleName(Guid roleId) {
			string roleName = string.Empty;
			var select = 
				(Select)new Select(_userConnection)
							.Column("Name")
						.From("SysAdminUnit")
						.Where("Id").IsEqual(Column.Parameter(roleId));
			select.ExecuteReader(dataReader => {
				roleName = dataReader.GetColumnValue<string>("Name");
			});
			return roleName;
		}
		
		private void ResetManuallyAssignedLicences(Guid userId) {
			Update updateQuery = 
				(Update)new Update(_userConnection, "SysLicUser")
							.Set("Source", Column.Parameter(SysLicSource.System))
						.Where("SysUserId").IsEqual(Column.Parameter(userId))
						.And("Source").IsEqual(Column.Parameter(SysLicSource.Manual));
			updateQuery.Execute();
		}

		private void RollbackLicenseSource(List<Guid> recordIds) {
			Update updateQuery = 
				(Update)new Update(_userConnection, "SysLicUser")
							.Set("Source", Column.Parameter(SysLicSource.Manual))
						.Where("Id").In(Column.Parameters(recordIds));
			updateQuery.Execute();
		}

        private void HandleException(Exception exception) {
          	_log.Error(exception.Message, exception);
			string notificationMessage = GetFailedRedistributionMessage(exceptionOccured: true);
			SendNotificationAboutCompletedLicenseDistribution(notificationMessage);
        }

		private string GetSuccessfulRedistributionForAllUsersMessage() {
			return GetLocalizableValue("MessageAfterSuccessfulRedistribution");
		}
		
		private string GetSuccessfulRedistributionForSpecificRoleMessage(Guid roleId) {
			string roleName = GetRoleName(roleId);
			string message = GetLocalizableValue("RoleSpecificMessageAfterSuccessfulDistribution");
			return string.Format(message, roleName);
		}

		private string GetFailedRedistributionMessage(bool exceptionOccured = false, int numberOfOmittedUsers = 0) {
			if (exceptionOccured) {
				return GetLocalizableValue("MessageAfterOccuredException");
			}
			string message = GetLocalizableValue("NotEnoughLicensesMessage");
			return string.Format(message, numberOfOmittedUsers);
		}

		private void SendNotificationAboutCompletedLicenseDistribution(string message) {
			var processLogSchema = _userConnection.EntitySchemaManager.FindInstanceByName("SysProcessLog");
			var remindingConfig = new RemindingConfig(processLogSchema.UId) {
				AuthorId = _userConnection.CurrentUser.ContactId,
				ContactId = _userConnection.CurrentUser.ContactId,
				SubjectId = _userConnection.ExternalAccessId,
				Description = message
			};
			_log.Info(message);
			_remindingUtilities.CreateReminding(_userConnection, remindingConfig);
		}

		private void DistributeLicences(HashSet<(Guid userId, bool hasManuallyAssignedLicense)> users, 
			bool redistributeManuallyAssignedLicences) {
			foreach ((Guid userId, bool hasManuallyAssignedLicense) user in users) {
				RedistributeLicencesForUser(user.userId, redistributeManuallyAssignedLicences, user.hasManuallyAssignedLicense);
			}
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc cref="ILicenseRedistributionService.RedistributeLicences"/>
		public void RedistributeLicences(bool redistributeManuallyAssignedLicences) {
			try {
				_log.Info("Starting license redistribution for all users");
				var activeUsersSelect = GetAllActiveUsersSelect();
				var users = FetchUsersEligibleForLicenseDistribution(activeUsersSelect);
				DistributeLicences(users, redistributeManuallyAssignedLicences);
				string notificationMessage = GetSuccessfulRedistributionForAllUsersMessage();
				SendNotificationAboutCompletedLicenseDistribution(notificationMessage);
			} catch (Exception ex) {
				HandleException(ex);
				throw;
			}
		}
		
		/// <inheritdoc cref="ILicenseRedistributionService.RedistributeLicencesForRole"/>
		public void RedistributeLicencesForRole(bool redistributeManuallyAssignedLicences, Guid roleId) {
			try {
				_log.Info($"Starting license redistribution for role: {roleId}");
				var useFullHierarchy = SystemSettings.GetValue(_userConnection, "UseFullHierarchyDuringLicenseDistribution", 
					false);
				var activeUsersSelect = useFullHierarchy 
					? GetActiveUsersFromEntireRoleHierarchySelect(roleId) 
                    : GetActiveUsersFromSpecificRoleSelect(roleId);
				var users = FetchUsersEligibleForLicenseDistribution(activeUsersSelect);
				DistributeLicences(users, redistributeManuallyAssignedLicences);
				string notificationMessage = GetSuccessfulRedistributionForSpecificRoleMessage(roleId);
				SendNotificationAboutCompletedLicenseDistribution(notificationMessage);
			} catch (Exception ex) {
				HandleException(ex);
				throw;
			}
		}

		/// <inheritdoc cref="ILicenseRedistributionService.RedistributeLicencesForUser"/>
		public void RedistributeLicencesForUser(Guid userId, bool redistributeManuallyAssignedLicences = false, 
			bool hasManuallyAssignedLicense = false) {
			var manuallyAssignedLicenseIds = new List<Guid>();
			try {
				if (redistributeManuallyAssignedLicences && hasManuallyAssignedLicense) {
					GetManuallyAssignedLicenseIds(userId, manuallyAssignedLicenseIds);
					ResetManuallyAssignedLicences(userId);
				}
				_licManager.AddUserAvailableLicences(userId, null, false);
			} catch (Exception ex) {
				_log.Error(ex.Message, ex);
				if (redistributeManuallyAssignedLicences && hasManuallyAssignedLicense) {
					RollbackLicenseSource(manuallyAssignedLicenseIds);
				}
				throw;
			}
		}

		#endregion

	}

	#endregion

}
