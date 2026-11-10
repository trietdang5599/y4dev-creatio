namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: MailServer

	/// <exclude/>
	public class MailServer : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public MailServer(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MailServer";
		}

		public MailServer(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "MailServer";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<MailboxSyncSettings> MailboxSyncSettingsCollectionByMailServer {
			get;
			set;
		}

		public IEnumerable<MailServerDomain> MailServerDomainCollectionByMailServer {
			get;
			set;
		}

		public IEnumerable<SocialAccount> SocialAccountCollectionByMailServer {
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
		/// Incoming mail server name or IP.
		/// </summary>
		public string Address {
			get {
				return GetTypedColumnValue<string>("Address");
			}
			set {
				SetColumnValue("Address", value);
			}
		}

		/// <summary>
		/// Port.
		/// </summary>
		public int Port {
			get {
				return GetTypedColumnValue<int>("Port");
			}
			set {
				SetColumnValue("Port", value);
			}
		}

		/// <summary>
		/// Use SSL.
		/// </summary>
		public bool UseSSL {
			get {
				return GetTypedColumnValue<bool>("UseSSL");
			}
			set {
				SetColumnValue("UseSSL", value);
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
		/// Allow downloading emails.
		/// </summary>
		public bool AllowEmailDownloading {
			get {
				return GetTypedColumnValue<bool>("AllowEmailDownloading");
			}
			set {
				SetColumnValue("AllowEmailDownloading", value);
			}
		}

		/// <summary>
		/// Allow sending emails.
		/// </summary>
		public bool AllowEmailSending {
			get {
				return GetTypedColumnValue<bool>("AllowEmailSending");
			}
			set {
				SetColumnValue("AllowEmailSending", value);
			}
		}

		/// <summary>
		/// Outgoing mail server name or IP (SMTP).
		/// </summary>
		public string SMTPServerAddress {
			get {
				return GetTypedColumnValue<string>("SMTPServerAddress");
			}
			set {
				SetColumnValue("SMTPServerAddress", value);
			}
		}

		/// <summary>
		/// Port.
		/// </summary>
		public int SMTPPort {
			get {
				return GetTypedColumnValue<int>("SMTPPort");
			}
			set {
				SetColumnValue("SMTPPort", value);
			}
		}

		/// <summary>
		/// Interval of waiting for server response when sending mail, seconds.
		/// </summary>
		public int SMTPServerTimeout {
			get {
				return GetTypedColumnValue<int>("SMTPServerTimeout");
			}
			set {
				SetColumnValue("SMTPServerTimeout", value);
			}
		}

		/// <summary>
		/// Use SSL.
		/// </summary>
		public bool UseSSLforSending {
			get {
				return GetTypedColumnValue<bool>("UseSSLforSending");
			}
			set {
				SetColumnValue("UseSSLforSending", value);
			}
		}

		/// <summary>
		/// Server address.
		/// </summary>
		public string ExchangeEmailAddress {
			get {
				return GetTypedColumnValue<string>("ExchangeEmailAddress");
			}
			set {
				SetColumnValue("ExchangeEmailAddress", value);
			}
		}

		/// <summary>
		/// Autodetect.
		/// </summary>
		public bool IsExchengeAutodiscover {
			get {
				return GetTypedColumnValue<bool>("IsExchengeAutodiscover");
			}
			set {
				SetColumnValue("IsExchengeAutodiscover", value);
			}
		}

		/// <summary>
		/// Create encrypted connection (STARTTLS).
		/// </summary>
		public bool IsStartTls {
			get {
				return GetTypedColumnValue<bool>("IsStartTls");
			}
			set {
				SetColumnValue("IsStartTls", value);
			}
		}

		/// <summary>
		/// Enter login manually.
		/// </summary>
		public bool UseLogin {
			get {
				return GetTypedColumnValue<bool>("UseLogin");
			}
			set {
				SetColumnValue("UseLogin", value);
			}
		}

		/// <summary>
		/// Use user name as login.
		/// </summary>
		public bool UseUserNameAsLogin {
			get {
				return GetTypedColumnValue<bool>("UseUserNameAsLogin");
			}
			set {
				SetColumnValue("UseUserNameAsLogin", value);
			}
		}

		/// <summary>
		/// Use email address as login.
		/// </summary>
		public bool UseEmailAddressAsLogin {
			get {
				return GetTypedColumnValue<bool>("UseEmailAddressAsLogin");
			}
			set {
				SetColumnValue("UseEmailAddressAsLogin", value);
			}
		}

		/// <summary>
		/// Strategy.
		/// </summary>
		public string Strategy {
			get {
				return GetTypedColumnValue<string>("Strategy");
			}
			set {
				SetColumnValue("Strategy", value);
			}
		}

		/// <summary>
		/// SubscriptionTtl.
		/// </summary>
		public int SubscriptionTtl {
			get {
				return GetTypedColumnValue<int>("SubscriptionTtl");
			}
			set {
				SetColumnValue("SubscriptionTtl", value);
			}
		}

		/// <summary>
		/// Limit mode flag.
		/// </summary>
		public bool IsLimitMode {
			get {
				return GetTypedColumnValue<bool>("IsLimitMode");
			}
			set {
				SetColumnValue("IsLimitMode", value);
			}
		}

		/// <summary>
		/// Service account password.
		/// </summary>
		public string ServiceAccountPassword {
			get {
				return GetTypedColumnValue<string>("ServiceAccountPassword");
			}
			set {
				SetColumnValue("ServiceAccountPassword", value);
			}
		}

		/// <summary>
		/// Service account login.
		/// </summary>
		public string ServiceAccountLogin {
			get {
				return GetTypedColumnValue<string>("ServiceAccountLogin");
			}
			set {
				SetColumnValue("ServiceAccountLogin", value);
			}
		}

		/// <summary>
		/// Use impersonation.
		/// </summary>
		public bool UseImpersonation {
			get {
				return GetTypedColumnValue<bool>("UseImpersonation");
			}
			set {
				SetColumnValue("UseImpersonation", value);
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
		public Guid EmailProtocolId {
			get {
				return GetTypedColumnValue<Guid>("EmailProtocolId");
			}
			set {
				SetColumnValue("EmailProtocolId", value);
				_emailProtocol = null;
			}
		}

		/// <exclude/>
		public string EmailProtocolName {
			get {
				return GetTypedColumnValue<string>("EmailProtocolName");
			}
			set {
				SetColumnValue("EmailProtocolName", value);
				if (_emailProtocol != null) {
					_emailProtocol.Name = value;
				}
			}
		}

		private EmailProtocol _emailProtocol;
		/// <summary>
		/// Connection protocol.
		/// </summary>
		public EmailProtocol EmailProtocol {
			get {
				return _emailProtocol ??
					(_emailProtocol = new EmailProtocol(LookupColumnEntities.GetEntity("EmailProtocol")));
			}
		}

		/// <exclude/>
		public Guid TypeId {
			get {
				return GetTypedColumnValue<Guid>("TypeId");
			}
			set {
				SetColumnValue("TypeId", value);
				_type = null;
			}
		}

		/// <exclude/>
		public string TypeName {
			get {
				return GetTypedColumnValue<string>("TypeName");
			}
			set {
				SetColumnValue("TypeName", value);
				if (_type != null) {
					_type.Name = value;
				}
			}
		}

		private MailServerType _type;
		/// <summary>
		/// Mail service provider type.
		/// </summary>
		public MailServerType Type {
			get {
				return _type ??
					(_type = new MailServerType(LookupColumnEntities.GetEntity("Type")));
			}
		}

		/// <exclude/>
		public Guid LogoId {
			get {
				return GetTypedColumnValue<Guid>("LogoId");
			}
			set {
				SetColumnValue("LogoId", value);
				_logo = null;
			}
		}

		/// <exclude/>
		public string LogoName {
			get {
				return GetTypedColumnValue<string>("LogoName");
			}
			set {
				SetColumnValue("LogoName", value);
				if (_logo != null) {
					_logo.Name = value;
				}
			}
		}

		private SysImage _logo;
		/// <summary>
		/// Logo.
		/// </summary>
		public SysImage Logo {
			get {
				return _logo ??
					(_logo = new SysImage(LookupColumnEntities.GetEntity("Logo")));
			}
		}

		/// <exclude/>
		public Guid OAuthApplicationId {
			get {
				return GetTypedColumnValue<Guid>("OAuthApplicationId");
			}
			set {
				SetColumnValue("OAuthApplicationId", value);
				_oAuthApplication = null;
			}
		}

		/// <exclude/>
		public string OAuthApplicationName {
			get {
				return GetTypedColumnValue<string>("OAuthApplicationName");
			}
			set {
				SetColumnValue("OAuthApplicationName", value);
				if (_oAuthApplication != null) {
					_oAuthApplication.Name = value;
				}
			}
		}

		private OAuthApplications _oAuthApplication;
		/// <summary>
		/// OAuth application identifier.
		/// </summary>
		public OAuthApplications OAuthApplication {
			get {
				return _oAuthApplication ??
					(_oAuthApplication = new OAuthApplications(LookupColumnEntities.GetEntity("OAuthApplication")));
			}
		}

		/// <exclude/>
		public Guid SmtpSecureOptionId {
			get {
				return GetTypedColumnValue<Guid>("SmtpSecureOptionId");
			}
			set {
				SetColumnValue("SmtpSecureOptionId", value);
				_smtpSecureOption = null;
			}
		}

		/// <exclude/>
		public string SmtpSecureOptionName {
			get {
				return GetTypedColumnValue<string>("SmtpSecureOptionName");
			}
			set {
				SetColumnValue("SmtpSecureOptionName", value);
				if (_smtpSecureOption != null) {
					_smtpSecureOption.Name = value;
				}
			}
		}

		private MailSecureOption _smtpSecureOption;
		/// <summary>
		/// Secure option for connection to smtp mail server.
		/// </summary>
		public MailSecureOption SmtpSecureOption {
			get {
				return _smtpSecureOption ??
					(_smtpSecureOption = new MailSecureOption(LookupColumnEntities.GetEntity("SmtpSecureOption")));
			}
		}

		/// <exclude/>
		public Guid ImapSecureOptionId {
			get {
				return GetTypedColumnValue<Guid>("ImapSecureOptionId");
			}
			set {
				SetColumnValue("ImapSecureOptionId", value);
				_imapSecureOption = null;
			}
		}

		/// <exclude/>
		public string ImapSecureOptionName {
			get {
				return GetTypedColumnValue<string>("ImapSecureOptionName");
			}
			set {
				SetColumnValue("ImapSecureOptionName", value);
				if (_imapSecureOption != null) {
					_imapSecureOption.Name = value;
				}
			}
		}

		private MailSecureOption _imapSecureOption;
		/// <summary>
		/// Secure option for connection to imap mail server.
		/// </summary>
		public MailSecureOption ImapSecureOption {
			get {
				return _imapSecureOption ??
					(_imapSecureOption = new MailSecureOption(LookupColumnEntities.GetEntity("ImapSecureOption")));
			}
		}

		#endregion

	}

	#endregion

}

