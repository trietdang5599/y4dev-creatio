namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: OAuthClientApp

	/// <exclude/>
	public class OAuthClientApp : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public OAuthClientApp(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OAuthClientApp";
		}

		public OAuthClientApp(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "OAuthClientApp";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<OAuthAppAllowedUser> OAuthAppAllowedUserCollectionByOAuthClientApp {
			get;
			set;
		}

		public IEnumerable<OAuthDelegationGrant> OAuthDelegationGrantCollectionByCallerOAuthClientApp {
			get;
			set;
		}

		public IEnumerable<OAuthDelegationGrant> OAuthDelegationGrantCollectionByOAuthClientApp {
			get;
			set;
		}

		public IEnumerable<OAuthGrantTypeInClient> OAuthGrantTypeInClientCollectionByOAuthClientApp {
			get;
			set;
		}

		public IEnumerable<OAuthResourceInClient> OAuthResourceInClientCollectionByOAuthClient {
			get;
			set;
		}

		public IEnumerable<OAuthTokenExchangeTrustedClientApp> OAuthTokenExchangeTrustedClientAppCollectionByOAuthClientApp {
			get;
			set;
		}

		public IEnumerable<RedirectUrlInOAuthClientApp> RedirectUrlInOAuthClientAppCollectionByOAuthClientApp {
			get;
			set;
		}

		public IEnumerable<SysUserSession> SysUserSessionCollectionByOAuthClientApp {
			get;
			set;
		}

		public IEnumerable<UserOAuthSharedAccess> UserOAuthSharedAccessCollectionByOAuthClientApp {
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
		/// Client Id.
		/// </summary>
		public string ClientId {
			get {
				return GetTypedColumnValue<string>("ClientId");
			}
			set {
				SetColumnValue("ClientId", value);
			}
		}

		/// <summary>
		/// Client secret.
		/// </summary>
		public string ClientSecret {
			get {
				return GetTypedColumnValue<string>("ClientSecret");
			}
			set {
				SetColumnValue("ClientSecret", value);
			}
		}

		/// <summary>
		/// Redirect URL.
		/// </summary>
		public string RedirectUrl {
			get {
				return GetTypedColumnValue<string>("RedirectUrl");
			}
			set {
				SetColumnValue("RedirectUrl", value);
			}
		}

		/// <summary>
		/// Application URL.
		/// </summary>
		public string ApplicationUrl {
			get {
				return GetTypedColumnValue<string>("ApplicationUrl");
			}
			set {
				SetColumnValue("ApplicationUrl", value);
			}
		}

		/// <summary>
		/// Integration is active.
		/// </summary>
		public bool IsActive {
			get {
				return GetTypedColumnValue<bool>("IsActive");
			}
			set {
				SetColumnValue("IsActive", value);
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
		/// Allow plain text PKCE.
		/// </summary>
		/// <remarks>
		/// Specifies whether a proof key can be sent using plain method.
		/// </remarks>
		public bool AllowPlainTextPkce {
			get {
				return GetTypedColumnValue<bool>("AllowPlainTextPkce");
			}
			set {
				SetColumnValue("AllowPlainTextPkce", value);
			}
		}

		/// <summary>
		/// Enforce PKCE usage.
		/// </summary>
		/// <remarks>
		/// Specifies whether a proof key is required for authorization code based token requests.
		/// </remarks>
		public bool RequirePKCE {
			get {
				return GetTypedColumnValue<bool>("RequirePKCE");
			}
			set {
				SetColumnValue("RequirePKCE", value);
			}
		}

		/// <summary>
		/// Public client.
		/// </summary>
		/// <remarks>
		/// If set to false, no client secret is needed to request tokens at the token endpoint.
		/// </remarks>
		public bool IsPublic {
			get {
				return GetTypedColumnValue<bool>("IsPublic");
			}
			set {
				SetColumnValue("IsPublic", value);
			}
		}

		public bool GenerateClientId {
			get {
				return GetTypedColumnValue<bool>("GenerateClientId");
			}
			set {
				SetColumnValue("GenerateClientId", value);
			}
		}

		public int AccessTokenLifetime {
			get {
				return GetTypedColumnValue<int>("AccessTokenLifetime");
			}
			set {
				SetColumnValue("AccessTokenLifetime", value);
			}
		}

		public int SlidingRefreshTokenLifetime {
			get {
				return GetTypedColumnValue<int>("SlidingRefreshTokenLifetime");
			}
			set {
				SetColumnValue("SlidingRefreshTokenLifetime", value);
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
		public Guid SystemUserId {
			get {
				return GetTypedColumnValue<Guid>("SystemUserId");
			}
			set {
				SetColumnValue("SystemUserId", value);
				_systemUser = null;
			}
		}

		/// <exclude/>
		public string SystemUserName {
			get {
				return GetTypedColumnValue<string>("SystemUserName");
			}
			set {
				SetColumnValue("SystemUserName", value);
				if (_systemUser != null) {
					_systemUser.Name = value;
				}
			}
		}

		private SysAdminUnit _systemUser;
		/// <summary>
		/// System user.
		/// </summary>
		public SysAdminUnit SystemUser {
			get {
				return _systemUser ??
					(_systemUser = new SysAdminUnit(LookupColumnEntities.GetEntity("SystemUser")));
			}
		}

		/// <exclude/>
		public Guid GrantTypeId {
			get {
				return GetTypedColumnValue<Guid>("GrantTypeId");
			}
			set {
				SetColumnValue("GrantTypeId", value);
				_grantType = null;
			}
		}

		/// <exclude/>
		public string GrantTypeName {
			get {
				return GetTypedColumnValue<string>("GrantTypeName");
			}
			set {
				SetColumnValue("GrantTypeName", value);
				if (_grantType != null) {
					_grantType.Name = value;
				}
			}
		}

		private OAuthGrantType _grantType;
		/// <summary>
		/// Grant type.
		/// </summary>
		public OAuthGrantType GrantType {
			get {
				return _grantType ??
					(_grantType = new OAuthGrantType(LookupColumnEntities.GetEntity("GrantType")));
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
		public Guid ConsentModeId {
			get {
				return GetTypedColumnValue<Guid>("ConsentModeId");
			}
			set {
				SetColumnValue("ConsentModeId", value);
				_consentMode = null;
			}
		}

		/// <exclude/>
		public string ConsentModeName {
			get {
				return GetTypedColumnValue<string>("ConsentModeName");
			}
			set {
				SetColumnValue("ConsentModeName", value);
				if (_consentMode != null) {
					_consentMode.Name = value;
				}
			}
		}

		private OAuthConsentMode _consentMode;
		/// <summary>
		/// Consent mode.
		/// </summary>
		/// <remarks>
		/// Controls the consent screen during the Authorization Code flow: ask consent on every connection, remember consent until access is revoked, or bypass consent for trusted applications.
		/// </remarks>
		public OAuthConsentMode ConsentMode {
			get {
				return _consentMode ??
					(_consentMode = new OAuthConsentMode(LookupColumnEntities.GetEntity("ConsentMode")));
			}
		}

		/// <exclude/>
		public Guid StatusId {
			get {
				return GetTypedColumnValue<Guid>("StatusId");
			}
			set {
				SetColumnValue("StatusId", value);
				_status = null;
			}
		}

		/// <exclude/>
		public string StatusName {
			get {
				return GetTypedColumnValue<string>("StatusName");
			}
			set {
				SetColumnValue("StatusName", value);
				if (_status != null) {
					_status.Name = value;
				}
			}
		}

		private OAuthClientAppStatus _status;
		public OAuthClientAppStatus Status {
			get {
				return _status ??
					(_status = new OAuthClientAppStatus(LookupColumnEntities.GetEntity("Status")));
			}
		}

		#endregion

	}

	#endregion

}

