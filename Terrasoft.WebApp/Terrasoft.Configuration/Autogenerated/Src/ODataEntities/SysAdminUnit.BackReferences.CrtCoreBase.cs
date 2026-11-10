namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: SysAdminUnit

	/// <exclude/>
	public class SysAdminUnit : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SysAdminUnit(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysAdminUnit";
		}

		public SysAdminUnit(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SysAdminUnit";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<AdminUnitFeatureState> AdminUnitFeatureStateCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<AIManagement> AIManagementCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<Calendar> CalendarCollectionByUser {
			get;
			set;
		}

		public IEnumerable<ChatQueueOperator> ChatQueueOperatorCollectionByOperator {
			get;
			set;
		}

		public IEnumerable<CompilationHistory> CompilationHistoryCollectionByStartedBy {
			get;
			set;
		}

		public IEnumerable<CopilotSessionEnt> CopilotSessionEntCollectionByUser {
			get;
			set;
		}

		public IEnumerable<EmailDefRights> EmailDefRightsCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<FolderFavorite> FolderFavoriteCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<FolderTreeFavorite> FolderTreeFavoriteCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<MailboxSyncSettings> MailboxSyncSettingsCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<MultiDeleteQueue> MultiDeleteQueueCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<OAuthAppAllowedUser> OAuthAppAllowedUserCollectionBySysUser {
			get;
			set;
		}

		public IEnumerable<OAuthApplications> OAuthApplicationsCollectionBySharedUser {
			get;
			set;
		}

		public IEnumerable<OAuthClientApp> OAuthClientAppCollectionBySystemUser {
			get;
			set;
		}

		public IEnumerable<OAuthDelegationGrant> OAuthDelegationGrantCollectionBySysUser {
			get;
			set;
		}

		public IEnumerable<OAuthTokenExchangeTrustedClientApp> OAuthTokenExchangeTrustedClientAppCollectionBySysUser {
			get;
			set;
		}

		public IEnumerable<OAuthTokenStorage> OAuthTokenStorageCollectionBySysUser {
			get;
			set;
		}

		public IEnumerable<OidcUserIdentity> OidcUserIdentityCollectionByUser {
			get;
			set;
		}

		public IEnumerable<OmniChat> OmniChatCollectionByDirectedOperator {
			get;
			set;
		}

		public IEnumerable<OmniChat> OmniChatCollectionByOperator {
			get;
			set;
		}

		public IEnumerable<OperatorSession> OperatorSessionCollectionBySysUser {
			get;
			set;
		}

		public IEnumerable<OperatorTemplateUsage> OperatorTemplateUsageCollectionByOperator {
			get;
			set;
		}

		public IEnumerable<OptionalFuncSspRole> OptionalFuncSspRoleCollectionByFuncRole {
			get;
			set;
		}

		public IEnumerable<OptionalFuncSspRole> OptionalFuncSspRoleCollectionByOrgRole {
			get;
			set;
		}

		public IEnumerable<OrganizationProperty> OrganizationPropertyCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<PushNotificationToken> PushNotificationTokenCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<QuickAddMenuSettings> QuickAddMenuSettingsCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<SocialAccount> SocialAccountCollectionByUser {
			get;
			set;
		}

		public IEnumerable<SocialChannelPublisher> SocialChannelPublisherCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<SocialFeedFavoriteTpl> SocialFeedFavoriteTplCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<SocialLike> SocialLikeCollectionByUser {
			get;
			set;
		}

		public IEnumerable<SocialSubscription> SocialSubscriptionCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<SocialUnsubscription> SocialUnsubscriptionCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<SysAdminOperationGrantee> SysAdminOperationGranteeCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<SysAdminUnit> SysAdminUnitCollectionByParentRole {
			get;
			set;
		}

		public IEnumerable<SysAdminUnitInFolder> SysAdminUnitInFolderCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<SysAdminUnitInRole> SysAdminUnitInRoleCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<SysAdminUnitInWorkplace> SysAdminUnitInWorkplaceCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<SysAdminUnitIPRange> SysAdminUnitIPRangeCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<SysAlmRole> SysAlmRoleCollectionByRole {
			get;
			set;
		}

		public IEnumerable<SysApproval> SysApprovalCollectionByDelegatedFrom {
			get;
			set;
		}

		public IEnumerable<SysApproval> SysApprovalCollectionByVisaOwner {
			get;
			set;
		}

		public IEnumerable<SysEntityOperationGrantee> SysEntityOperationGranteeCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<SysEntitySchemaOperationRight> SysEntitySchemaOperationRightCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<SysExtServiceOperationRight> SysExtServiceOperationRightCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<SysFuncRoleInOrgRole> SysFuncRoleInOrgRoleCollectionByFuncRole {
			get;
			set;
		}

		public IEnumerable<SysFuncRoleInOrgRole> SysFuncRoleInOrgRoleCollectionByOrgRole {
			get;
			set;
		}

		public IEnumerable<SysLastUserPassword> SysLastUserPasswordCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<SysLicPackageInRole> SysLicPackageInRoleCollectionBySysRole {
			get;
			set;
		}

		public IEnumerable<SysLicUser> SysLicUserCollectionBySysUser {
			get;
			set;
		}

		public IEnumerable<SysMsgUserSettings> SysMsgUserSettingsCollectionByUser {
			get;
			set;
		}

		public IEnumerable<SysProcessSchemaOperationRight> SysProcessSchemaOperationRightCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<SysProfileData> SysProfileDataCollectionBySysUser {
			get;
			set;
		}

		public IEnumerable<SysRecentEntity> SysRecentEntityCollectionBySysUser {
			get;
			set;
		}

		public IEnumerable<SysRecoveryHashCode> SysRecoveryHashCodeCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<SysRegistrationData> SysRegistrationDataCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<SysRepositoryUser> SysRepositoryUserCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<SysRoleInMobWorkplace> SysRoleInMobWorkplaceCollectionBySysRole {
			get;
			set;
		}

		public IEnumerable<SysSchema> SysSchemaCollectionByLockedBy {
			get;
			set;
		}

		public IEnumerable<SysSchemaAdminUnitRight> SysSchemaAdminUnitRightCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<SysSchemaDefOperationRight> SysSchemaDefOperationRightCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<SysSchemaOperationRight> SysSchemaOperationRightCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<SysSettingsValue> SysSettingsValueCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<SysTwoFactorCode> SysTwoFactorCodeCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<SysUserInRole> SysUserInRoleCollectionBySysRole {
			get;
			set;
		}

		public IEnumerable<SysUserInRole> SysUserInRoleCollectionBySysUser {
			get;
			set;
		}

		public IEnumerable<SysUserLevelSchema> SysUserLevelSchemaCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<SysUserRoleNotInhByMng> SysUserRoleNotInhByMngCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<SysUserSession> SysUserSessionCollectionBySysUser {
			get;
			set;
		}

		public IEnumerable<TagAccessGrantee> TagAccessGranteeCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<TotpSecret> TotpSecretCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<TotpSetupToken> TotpSetupTokenCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<UISwitcherAdminUnitUIType> UISwitcherAdminUnitUITypeCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<UserOAuthSharedAccess> UserOAuthSharedAccessCollectionBySysUser {
			get;
			set;
		}

		public IEnumerable<VwCopilotSessionEx> VwCopilotSessionExCollectionByUser {
			get;
			set;
		}

		public IEnumerable<VwEmployeesHierarchy> VwEmployeesHierarchyCollectionByManagerUser {
			get;
			set;
		}

		public IEnumerable<VwOAuthAppUser> VwOAuthAppUserCollectionBySysUser {
			get;
			set;
		}

		public IEnumerable<VwRemindingsCount> VwRemindingsCountCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<VwSocialSubscription> VwSocialSubscriptionCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<VwSocialUnsubscription> VwSocialUnsubscriptionCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<VwSysAdminOperationGrantee> VwSysAdminOperationGranteeCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<VwSysAdminUnit> VwSysAdminUnitCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<VwSysProcessSchemaUserRight> VwSysProcessSchemaUserRightCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<VwUserEmailsCount> VwUserEmailsCountCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<VwUserRemindingsCount> VwUserRemindingsCountCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<VwVisa> VwVisaCollectionByDelegatedFrom {
			get;
			set;
		}

		public IEnumerable<VwVisa> VwVisaCollectionByVisaOwner {
			get;
			set;
		}

		/// <summary>
		/// Id.
		/// </summary>
		public Guid Id {
			get {
				return GetTypedColumnValue<Guid>("Id");
			}
			set {
				SetColumnValue("Id", value);
			}
		}

		/// <summary>
		/// Created on.
		/// </summary>
		public DateTime CreatedOn {
			get {
				return GetTypedColumnValue<DateTime>("CreatedOn");
			}
			set {
				SetColumnValue("CreatedOn", value);
			}
		}

		/// <summary>
		/// Modified on.
		/// </summary>
		public DateTime ModifiedOn {
			get {
				return GetTypedColumnValue<DateTime>("ModifiedOn");
			}
			set {
				SetColumnValue("ModifiedOn", value);
			}
		}

		/// <summary>
		/// Name.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		/// <summary>
		/// Description.
		/// </summary>
		public string Description {
			get {
				return GetTypedColumnValue<string>("Description");
			}
			set {
				SetColumnValue("Description", value);
			}
		}

		/// <summary>
		/// Type.
		/// </summary>
		public int SysAdminUnitTypeValue {
			get {
				return GetTypedColumnValue<int>("SysAdminUnitTypeValue");
			}
			set {
				SetColumnValue("SysAdminUnitTypeValue", value);
			}
		}

		/// <summary>
		/// Domain user.
		/// </summary>
		public bool IsDirectoryEntry {
			get {
				return GetTypedColumnValue<bool>("IsDirectoryEntry");
			}
			set {
				SetColumnValue("IsDirectoryEntry", value);
			}
		}

		/// <summary>
		/// Time zone.
		/// </summary>
		public string TimeZoneId {
			get {
				return GetTypedColumnValue<string>("TimeZoneId");
			}
			set {
				SetColumnValue("TimeZoneId", value);
			}
		}

		/// <summary>
		/// Password.
		/// </summary>
		public string UserPassword {
			get {
				return GetTypedColumnValue<string>("UserPassword");
			}
			set {
				SetColumnValue("UserPassword", value);
			}
		}

		/// <summary>
		/// Active.
		/// </summary>
		public bool Active {
			get {
				return GetTypedColumnValue<bool>("Active");
			}
			set {
				SetColumnValue("Active", value);
			}
		}

		/// <summary>
		/// Synchronize with LDAP.
		/// </summary>
		public bool SynchronizeWithLDAP {
			get {
				return GetTypedColumnValue<bool>("SynchronizeWithLDAP");
			}
			set {
				SetColumnValue("SynchronizeWithLDAP", value);
			}
		}

		/// <summary>
		/// LDAP element.
		/// </summary>
		public string LDAPEntry {
			get {
				return GetTypedColumnValue<string>("LDAPEntry");
			}
			set {
				SetColumnValue("LDAPEntry", value);
			}
		}

		/// <summary>
		/// LDAP element Id.
		/// </summary>
		public string LDAPEntryId {
			get {
				return GetTypedColumnValue<string>("LDAPEntryId");
			}
			set {
				SetColumnValue("LDAPEntryId", value);
			}
		}

		/// <summary>
		/// LDAP element unique name.
		/// </summary>
		public string LDAPEntryDN {
			get {
				return GetTypedColumnValue<string>("LDAPEntryDN");
			}
			set {
				SetColumnValue("LDAPEntryDN", value);
			}
		}

		/// <summary>
		/// Logged in.
		/// </summary>
		public bool LoggedIn {
			get {
				return GetTypedColumnValue<bool>("LoggedIn");
			}
			set {
				SetColumnValue("LoggedIn", value);
			}
		}

		/// <summary>
		/// Active processes.
		/// </summary>
		public int ProcessListeners {
			get {
				return GetTypedColumnValue<int>("ProcessListeners");
			}
			set {
				SetColumnValue("ProcessListeners", value);
			}
		}

		/// <summary>
		/// Number of logon attempts.
		/// </summary>
		public int LoginAttemptCount {
			get {
				return GetTypedColumnValue<int>("LoginAttemptCount");
			}
			set {
				SetColumnValue("LoginAttemptCount", value);
			}
		}

		/// <summary>
		/// Repository login.
		/// </summary>
		public string SourceControlLogin {
			get {
				return GetTypedColumnValue<string>("SourceControlLogin");
			}
			set {
				SetColumnValue("SourceControlLogin", value);
			}
		}

		/// <summary>
		/// Repository password.
		/// </summary>
		public string SourceControlPassword {
			get {
				return GetTypedColumnValue<string>("SourceControlPassword");
			}
			set {
				SetColumnValue("SourceControlPassword", value);
			}
		}

		/// <summary>
		/// Password expiration date.
		/// </summary>
		public DateTime PasswordExpireDate {
			get {
				return GetTypedColumnValue<DateTime>("PasswordExpireDate");
			}
			set {
				SetColumnValue("PasswordExpireDate", value);
			}
		}

		/// <summary>
		/// Connection type.
		/// </summary>
		public int ConnectionType {
			get {
				return GetTypedColumnValue<int>("ConnectionType");
			}
			set {
				SetColumnValue("ConnectionType", value);
			}
		}

		/// <summary>
		/// Unlocking time.
		/// </summary>
		public DateTime UnblockTime {
			get {
				return GetTypedColumnValue<DateTime>("UnblockTime");
			}
			set {
				SetColumnValue("UnblockTime", value);
			}
		}

		/// <summary>
		/// Reset password.
		/// </summary>
		public bool ForceChangePassword {
			get {
				return GetTypedColumnValue<bool>("ForceChangePassword");
			}
			set {
				SetColumnValue("ForceChangePassword", value);
			}
		}

		/// <summary>
		/// Session timeout (minutes).
		/// </summary>
		public int SessionTimeout {
			get {
				return GetTypedColumnValue<int>("SessionTimeout");
			}
			set {
				SetColumnValue("SessionTimeout", value);
			}
		}

		/// <summary>
		/// Email.
		/// </summary>
		public string Email {
			get {
				return GetTypedColumnValue<string>("Email");
			}
			set {
				SetColumnValue("Email", value);
			}
		}

		/// <summary>
		/// OpenID sub claim.
		/// </summary>
		public string OpenIDSub {
			get {
				return GetTypedColumnValue<string>("OpenIDSub");
			}
			set {
				SetColumnValue("OpenIDSub", value);
			}
		}

		/// <summary>
		/// Phone.
		/// </summary>
		public string Phone {
			get {
				return GetTypedColumnValue<string>("Phone");
			}
			set {
				SetColumnValue("Phone", value);
			}
		}

		/// <exclude/>
		public Guid CreatedById {
			get {
				return GetTypedColumnValue<Guid>("CreatedById");
			}
			set {
				SetColumnValue("CreatedById", value);
				_createdBy = null;
			}
		}

		/// <exclude/>
		public string CreatedByName {
			get {
				return GetTypedColumnValue<string>("CreatedByName");
			}
			set {
				SetColumnValue("CreatedByName", value);
				if (_createdBy != null) {
					_createdBy.Name = value;
				}
			}
		}

		private Contact _createdBy;
		/// <summary>
		/// Created by.
		/// </summary>
		public Contact CreatedBy {
			get {
				return _createdBy ??
					(_createdBy = new Contact(LookupColumnEntities.GetEntity("CreatedBy")));
			}
		}

		/// <exclude/>
		public Guid ModifiedById {
			get {
				return GetTypedColumnValue<Guid>("ModifiedById");
			}
			set {
				SetColumnValue("ModifiedById", value);
				_modifiedBy = null;
			}
		}

		/// <exclude/>
		public string ModifiedByName {
			get {
				return GetTypedColumnValue<string>("ModifiedByName");
			}
			set {
				SetColumnValue("ModifiedByName", value);
				if (_modifiedBy != null) {
					_modifiedBy.Name = value;
				}
			}
		}

		private Contact _modifiedBy;
		/// <summary>
		/// Modified by.
		/// </summary>
		public Contact ModifiedBy {
			get {
				return _modifiedBy ??
					(_modifiedBy = new Contact(LookupColumnEntities.GetEntity("ModifiedBy")));
			}
		}

		/// <exclude/>
		public Guid ParentRoleId {
			get {
				return GetTypedColumnValue<Guid>("ParentRoleId");
			}
			set {
				SetColumnValue("ParentRoleId", value);
				_parentRole = null;
			}
		}

		/// <exclude/>
		public string ParentRoleName {
			get {
				return GetTypedColumnValue<string>("ParentRoleName");
			}
			set {
				SetColumnValue("ParentRoleName", value);
				if (_parentRole != null) {
					_parentRole.Name = value;
				}
			}
		}

		private SysAdminUnit _parentRole;
		/// <summary>
		/// Inherited from.
		/// </summary>
		public SysAdminUnit ParentRole {
			get {
				return _parentRole ??
					(_parentRole = new SysAdminUnit(LookupColumnEntities.GetEntity("ParentRole")));
			}
		}

		/// <exclude/>
		public Guid ContactId {
			get {
				return GetTypedColumnValue<Guid>("ContactId");
			}
			set {
				SetColumnValue("ContactId", value);
				_contact = null;
			}
		}

		/// <exclude/>
		public string ContactName {
			get {
				return GetTypedColumnValue<string>("ContactName");
			}
			set {
				SetColumnValue("ContactName", value);
				if (_contact != null) {
					_contact.Name = value;
				}
			}
		}

		private Contact _contact;
		/// <summary>
		/// Contact.
		/// </summary>
		public Contact Contact {
			get {
				return _contact ??
					(_contact = new Contact(LookupColumnEntities.GetEntity("Contact")));
			}
		}

		/// <exclude/>
		public Guid AccountId {
			get {
				return GetTypedColumnValue<Guid>("AccountId");
			}
			set {
				SetColumnValue("AccountId", value);
				_account = null;
			}
		}

		/// <exclude/>
		public string AccountName {
			get {
				return GetTypedColumnValue<string>("AccountName");
			}
			set {
				SetColumnValue("AccountName", value);
				if (_account != null) {
					_account.Name = value;
				}
			}
		}

		private Account _account;
		/// <summary>
		/// Account.
		/// </summary>
		public Account Account {
			get {
				return _account ??
					(_account = new Account(LookupColumnEntities.GetEntity("Account")));
			}
		}

		/// <exclude/>
		public Guid SysCultureId {
			get {
				return GetTypedColumnValue<Guid>("SysCultureId");
			}
			set {
				SetColumnValue("SysCultureId", value);
				_sysCulture = null;
			}
		}

		/// <exclude/>
		public string SysCultureName {
			get {
				return GetTypedColumnValue<string>("SysCultureName");
			}
			set {
				SetColumnValue("SysCultureName", value);
				if (_sysCulture != null) {
					_sysCulture.Name = value;
				}
			}
		}

		private SysCulture _sysCulture;
		/// <summary>
		/// Culture.
		/// </summary>
		public SysCulture SysCulture {
			get {
				return _sysCulture ??
					(_sysCulture = new SysCulture(LookupColumnEntities.GetEntity("SysCulture")));
			}
		}

		/// <exclude/>
		public Guid HomePageId {
			get {
				return GetTypedColumnValue<Guid>("HomePageId");
			}
			set {
				SetColumnValue("HomePageId", value);
				_homePage = null;
			}
		}

		/// <exclude/>
		public string HomePageCaption {
			get {
				return GetTypedColumnValue<string>("HomePageCaption");
			}
			set {
				SetColumnValue("HomePageCaption", value);
				if (_homePage != null) {
					_homePage.Caption = value;
				}
			}
		}

		private SysModule _homePage;
		/// <summary>
		/// Home page.
		/// </summary>
		public SysModule HomePage {
			get {
				return _homePage ??
					(_homePage = new SysModule(LookupColumnEntities.GetEntity("HomePage")));
			}
		}

		/// <exclude/>
		public Guid LDAPElementId {
			get {
				return GetTypedColumnValue<Guid>("LDAPElementId");
			}
			set {
				SetColumnValue("LDAPElementId", value);
				_lDAPElement = null;
			}
		}

		/// <exclude/>
		public string LDAPElementName {
			get {
				return GetTypedColumnValue<string>("LDAPElementName");
			}
			set {
				SetColumnValue("LDAPElementName", value);
				if (_lDAPElement != null) {
					_lDAPElement.Name = value;
				}
			}
		}

		private LDAPElement _lDAPElement;
		/// <summary>
		/// LDAP element.
		/// </summary>
		public LDAPElement LDAPElement {
			get {
				return _lDAPElement ??
					(_lDAPElement = new LDAPElement(LookupColumnEntities.GetEntity("LDAPElement")));
			}
		}

		/// <exclude/>
		public Guid DateTimeFormatId {
			get {
				return GetTypedColumnValue<Guid>("DateTimeFormatId");
			}
			set {
				SetColumnValue("DateTimeFormatId", value);
				_dateTimeFormat = null;
			}
		}

		/// <exclude/>
		public string DateTimeFormatName {
			get {
				return GetTypedColumnValue<string>("DateTimeFormatName");
			}
			set {
				SetColumnValue("DateTimeFormatName", value);
				if (_dateTimeFormat != null) {
					_dateTimeFormat.Name = value;
				}
			}
		}

		private SysLanguage _dateTimeFormat;
		/// <summary>
		/// Display date and time format.
		/// </summary>
		public SysLanguage DateTimeFormat {
			get {
				return _dateTimeFormat ??
					(_dateTimeFormat = new SysLanguage(LookupColumnEntities.GetEntity("DateTimeFormat")));
			}
		}

		/// <exclude/>
		public Guid PortalAccountId {
			get {
				return GetTypedColumnValue<Guid>("PortalAccountId");
			}
			set {
				SetColumnValue("PortalAccountId", value);
				_portalAccount = null;
			}
		}

		/// <exclude/>
		public string PortalAccountName {
			get {
				return GetTypedColumnValue<string>("PortalAccountName");
			}
			set {
				SetColumnValue("PortalAccountName", value);
				if (_portalAccount != null) {
					_portalAccount.Name = value;
				}
			}
		}

		private Account _portalAccount;
		/// <summary>
		/// PortalAccount.
		/// </summary>
		public Account PortalAccount {
			get {
				return _portalAccount ??
					(_portalAccount = new Account(LookupColumnEntities.GetEntity("PortalAccount")));
			}
		}

		/// <exclude/>
		public Guid WeekFirstDayId {
			get {
				return GetTypedColumnValue<Guid>("WeekFirstDayId");
			}
			set {
				SetColumnValue("WeekFirstDayId", value);
				_weekFirstDay = null;
			}
		}

		/// <exclude/>
		public string WeekFirstDayName {
			get {
				return GetTypedColumnValue<string>("WeekFirstDayName");
			}
			set {
				SetColumnValue("WeekFirstDayName", value);
				if (_weekFirstDay != null) {
					_weekFirstDay.Name = value;
				}
			}
		}

		private WeekFirstDay _weekFirstDay;
		/// <summary>
		/// First day of week.
		/// </summary>
		public WeekFirstDay WeekFirstDay {
			get {
				return _weekFirstDay ??
					(_weekFirstDay = new WeekFirstDay(LookupColumnEntities.GetEntity("WeekFirstDay")));
			}
		}

		/// <exclude/>
		public Guid NumberFormatId {
			get {
				return GetTypedColumnValue<Guid>("NumberFormatId");
			}
			set {
				SetColumnValue("NumberFormatId", value);
				_numberFormat = null;
			}
		}

		/// <exclude/>
		public string NumberFormatName {
			get {
				return GetTypedColumnValue<string>("NumberFormatName");
			}
			set {
				SetColumnValue("NumberFormatName", value);
				if (_numberFormat != null) {
					_numberFormat.Name = value;
				}
			}
		}

		private SysNumberFormat _numberFormat;
		/// <summary>
		/// Number format.
		/// </summary>
		public SysNumberFormat NumberFormat {
			get {
				return _numberFormat ??
					(_numberFormat = new SysNumberFormat(LookupColumnEntities.GetEntity("NumberFormat")));
			}
		}

		/// <exclude/>
		public Guid MobileHomePageId {
			get {
				return GetTypedColumnValue<Guid>("MobileHomePageId");
			}
			set {
				SetColumnValue("MobileHomePageId", value);
				_mobileHomePage = null;
			}
		}

		/// <exclude/>
		public string MobileHomePageCaption {
			get {
				return GetTypedColumnValue<string>("MobileHomePageCaption");
			}
			set {
				SetColumnValue("MobileHomePageCaption", value);
				if (_mobileHomePage != null) {
					_mobileHomePage.Caption = value;
				}
			}
		}

		private SysSchema _mobileHomePage;
		/// <summary>
		/// Mobile home page.
		/// </summary>
		public SysSchema MobileHomePage {
			get {
				return _mobileHomePage ??
					(_mobileHomePage = new SysSchema(LookupColumnEntities.GetEntity("MobileHomePage")));
			}
		}

		#endregion

	}

	#endregion

}

