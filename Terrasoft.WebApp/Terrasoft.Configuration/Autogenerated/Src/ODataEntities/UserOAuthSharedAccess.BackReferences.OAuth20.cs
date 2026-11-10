namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: UserOAuthSharedAccess

	/// <exclude/>
	public class UserOAuthSharedAccess : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public UserOAuthSharedAccess(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "UserOAuthSharedAccess";
		}

		public UserOAuthSharedAccess(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "UserOAuthSharedAccess";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

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
		/// Last access granted on.
		/// </summary>
		public DateTime AccessSharedOn {
			get {
				return GetTypedColumnValue<DateTime>("AccessSharedOn");
			}
			set {
				SetColumnValue("AccessSharedOn", value);
			}
		}

		/// <summary>
		/// Access active.
		/// </summary>
		public bool Active {
			get {
				return GetTypedColumnValue<bool>("Active");
			}
			set {
				SetColumnValue("Active", value);
			}
		}

		public DateTime ConsentGrantedOn {
			get {
				return GetTypedColumnValue<DateTime>("ConsentGrantedOn");
			}
			set {
				SetColumnValue("ConsentGrantedOn", value);
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
		public Guid OAuthClientAppId {
			get {
				return GetTypedColumnValue<Guid>("OAuthClientAppId");
			}
			set {
				SetColumnValue("OAuthClientAppId", value);
				_oAuthClientApp = null;
			}
		}

		/// <exclude/>
		public string OAuthClientAppName {
			get {
				return GetTypedColumnValue<string>("OAuthClientAppName");
			}
			set {
				SetColumnValue("OAuthClientAppName", value);
				if (_oAuthClientApp != null) {
					_oAuthClientApp.Name = value;
				}
			}
		}

		private OAuthClientApp _oAuthClientApp;
		/// <summary>
		/// OAuth client application.
		/// </summary>
		public OAuthClientApp OAuthClientApp {
			get {
				return _oAuthClientApp ??
					(_oAuthClientApp = new OAuthClientApp(LookupColumnEntities.GetEntity("OAuthClientApp")));
			}
		}

		/// <exclude/>
		public Guid SysUserId {
			get {
				return GetTypedColumnValue<Guid>("SysUserId");
			}
			set {
				SetColumnValue("SysUserId", value);
				_sysUser = null;
			}
		}

		/// <exclude/>
		public string SysUserName {
			get {
				return GetTypedColumnValue<string>("SysUserName");
			}
			set {
				SetColumnValue("SysUserName", value);
				if (_sysUser != null) {
					_sysUser.Name = value;
				}
			}
		}

		private SysAdminUnit _sysUser;
		/// <summary>
		/// User.
		/// </summary>
		public SysAdminUnit SysUser {
			get {
				return _sysUser ??
					(_sysUser = new SysAdminUnit(LookupColumnEntities.GetEntity("SysUser")));
			}
		}

		#endregion

	}

	#endregion

}

