namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: SsoServiceProvider

	/// <exclude/>
	public class SsoServiceProvider : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SsoServiceProvider(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SsoServiceProvider";
		}

		public SsoServiceProvider(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SsoServiceProvider";
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
		/// Create and update users data when log in (Just-In-Time Provisioning).
		/// </summary>
		public bool UseJit {
			get {
				return GetTypedColumnValue<bool>("UseJit");
			}
			set {
				SetColumnValue("UseJit", value);
			}
		}

		/// <summary>
		/// Saml user role.
		/// </summary>
		public string SamlUserRole {
			get {
				return GetTypedColumnValue<string>("SamlUserRole");
			}
			set {
				SetColumnValue("SamlUserRole", value);
			}
		}

		/// <summary>
		/// Saml user name.
		/// </summary>
		public string SamlUserName {
			get {
				return GetTypedColumnValue<string>("SamlUserName");
			}
			set {
				SetColumnValue("SamlUserName", value);
			}
		}

		/// <summary>
		/// Local certificate thumbprint.
		/// </summary>
		public string LocalCertificateThumbprint {
			get {
				return GetTypedColumnValue<string>("LocalCertificateThumbprint");
			}
			set {
				SetColumnValue("LocalCertificateThumbprint", value);
			}
		}

		/// <summary>
		/// Assertion consumer service Url.
		/// </summary>
		public string AssertionConsumerServiceUrl {
			get {
				return GetTypedColumnValue<string>("AssertionConsumerServiceUrl");
			}
			set {
				SetColumnValue("AssertionConsumerServiceUrl", value);
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
		/// Use Just-in-Time Provisioning for portal users.
		/// </summary>
		public bool SspUseJit {
			get {
				return GetTypedColumnValue<bool>("SspUseJit");
			}
			set {
				SetColumnValue("SspUseJit", value);
			}
		}

		/// <summary>
		/// ServiceUniqueColumn.
		/// </summary>
		public bool ServiceUniqueColumn {
			get {
				return GetTypedColumnValue<bool>("ServiceUniqueColumn");
			}
			set {
				SetColumnValue("ServiceUniqueColumn", value);
			}
		}

		/// <summary>
		/// Single logout service Url.
		/// </summary>
		public string SingleLogoutServiceUrl {
			get {
				return GetTypedColumnValue<string>("SingleLogoutServiceUrl");
			}
			set {
				SetColumnValue("SingleLogoutServiceUrl", value);
			}
		}

		/// <summary>
		/// Use SLO.
		/// </summary>
		public bool UseSlo {
			get {
				return GetTypedColumnValue<bool>("UseSlo");
			}
			set {
				SetColumnValue("UseSlo", value);
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
		public Guid SsoIdentityProviderId {
			get {
				return GetTypedColumnValue<Guid>("SsoIdentityProviderId");
			}
			set {
				SetColumnValue("SsoIdentityProviderId", value);
				_ssoIdentityProvider = null;
			}
		}

		/// <exclude/>
		public string SsoIdentityProviderDisplayName {
			get {
				return GetTypedColumnValue<string>("SsoIdentityProviderDisplayName");
			}
			set {
				SetColumnValue("SsoIdentityProviderDisplayName", value);
				if (_ssoIdentityProvider != null) {
					_ssoIdentityProvider.DisplayName = value;
				}
			}
		}

		private SsoIdentityProvider _ssoIdentityProvider;
		/// <summary>
		/// SSO identity provider.
		/// </summary>
		public SsoIdentityProvider SsoIdentityProvider {
			get {
				return _ssoIdentityProvider ??
					(_ssoIdentityProvider = new SsoIdentityProvider(LookupColumnEntities.GetEntity("SsoIdentityProvider")));
			}
		}

		#endregion

	}

	#endregion

}

