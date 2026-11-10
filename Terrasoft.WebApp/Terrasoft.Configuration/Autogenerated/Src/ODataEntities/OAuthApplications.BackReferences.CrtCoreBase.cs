namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: OAuthApplications

	/// <exclude/>
	public class OAuthApplications : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public OAuthApplications(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OAuthApplications";
		}

		public OAuthApplications(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "OAuthApplications";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<MailServer> MailServerCollectionByOAuthApplication {
			get;
			set;
		}

		public IEnumerable<OAuth20AppFile> OAuth20AppFileCollectionByOAuth20App {
			get;
			set;
		}

		public IEnumerable<OAuth20AppInFolder> OAuth20AppInFolderCollectionByOAuth20App {
			get;
			set;
		}

		public IEnumerable<OAuth20AppInTag> OAuth20AppInTagCollectionByEntity {
			get;
			set;
		}

		public IEnumerable<OAuthAppExtraParams> OAuthAppExtraParamsCollectionByOAuth20App {
			get;
			set;
		}

		public IEnumerable<OAuthAppScope> OAuthAppScopeCollectionByOAuth20App {
			get;
			set;
		}

		public IEnumerable<OAuthTokenStorage> OAuthTokenStorageCollectionByOAuthApp {
			get;
			set;
		}

		public IEnumerable<VwOAuthAppUser> VwOAuthAppUserCollectionByOAuthApp {
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
		/// Application class name.
		/// </summary>
		public string AppClassName {
			get {
				return GetTypedColumnValue<string>("AppClassName");
			}
			set {
				SetColumnValue("AppClassName", value);
			}
		}

		/// <summary>
		/// Application client identifier.
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
		/// Application secret key.
		/// </summary>
		public string SecretKey {
			get {
				return GetTypedColumnValue<string>("SecretKey");
			}
			set {
				SetColumnValue("SecretKey", value);
			}
		}

		/// <summary>
		/// OAuth client class name.
		/// </summary>
		public string ClientClassName {
			get {
				return GetTypedColumnValue<string>("ClientClassName");
			}
			set {
				SetColumnValue("ClientClassName", value);
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
		/// Auth code request URL.
		/// </summary>
		public string AuthorizeUrl {
			get {
				return GetTypedColumnValue<string>("AuthorizeUrl");
			}
			set {
				SetColumnValue("AuthorizeUrl", value);
			}
		}

		/// <summary>
		/// Access token request URL.
		/// </summary>
		public string TokenUrl {
			get {
				return GetTypedColumnValue<string>("TokenUrl");
			}
			set {
				SetColumnValue("TokenUrl", value);
			}
		}

		/// <summary>
		/// Revoke token URL.
		/// </summary>
		public string RevokeTokenUrl {
			get {
				return GetTypedColumnValue<string>("RevokeTokenUrl");
			}
			set {
				SetColumnValue("RevokeTokenUrl", value);
			}
		}

		/// <summary>
		/// Use shared user.
		/// </summary>
		public bool UseSharedUser {
			get {
				return GetTypedColumnValue<bool>("UseSharedUser");
			}
			set {
				SetColumnValue("UseSharedUser", value);
			}
		}

		/// <summary>
		/// Send client credentials as.
		/// </summary>
		public int CredentialsLocationInRequest {
			get {
				return GetTypedColumnValue<int>("CredentialsLocationInRequest");
			}
			set {
				SetColumnValue("CredentialsLocationInRequest", value);
			}
		}

		/// <summary>
		/// AccessType.
		/// </summary>
		public int AccessType {
			get {
				return GetTypedColumnValue<int>("AccessType");
			}
			set {
				SetColumnValue("AccessType", value);
			}
		}

		/// <summary>
		/// TenantId.
		/// </summary>
		public string TenantId {
			get {
				return GetTypedColumnValue<string>("TenantId");
			}
			set {
				SetColumnValue("TenantId", value);
			}
		}

		/// <summary>
		/// AuthFlow.
		/// </summary>
		public int AuthFlow {
			get {
				return GetTypedColumnValue<int>("AuthFlow");
			}
			set {
				SetColumnValue("AuthFlow", value);
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
		public Guid SharedUserId {
			get {
				return GetTypedColumnValue<Guid>("SharedUserId");
			}
			set {
				SetColumnValue("SharedUserId", value);
				_sharedUser = null;
			}
		}

		/// <exclude/>
		public string SharedUserName {
			get {
				return GetTypedColumnValue<string>("SharedUserName");
			}
			set {
				SetColumnValue("SharedUserName", value);
				if (_sharedUser != null) {
					_sharedUser.Name = value;
				}
			}
		}

		private SysAdminUnit _sharedUser;
		/// <summary>
		/// Shared user.
		/// </summary>
		public SysAdminUnit SharedUser {
			get {
				return _sharedUser ??
					(_sharedUser = new SysAdminUnit(LookupColumnEntities.GetEntity("SharedUser")));
			}
		}

		/// <exclude/>
		public Guid ImageId {
			get {
				return GetTypedColumnValue<Guid>("ImageId");
			}
			set {
				SetColumnValue("ImageId", value);
				_image = null;
			}
		}

		/// <exclude/>
		public string ImageName {
			get {
				return GetTypedColumnValue<string>("ImageName");
			}
			set {
				SetColumnValue("ImageName", value);
				if (_image != null) {
					_image.Name = value;
				}
			}
		}

		private SysImage _image;
		/// <summary>
		/// Image.
		/// </summary>
		/// <remarks>
		/// Image.
		/// </remarks>
		public SysImage Image {
			get {
				return _image ??
					(_image = new SysImage(LookupColumnEntities.GetEntity("Image")));
			}
		}

		#endregion

	}

	#endregion

}

