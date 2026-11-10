namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: SsoSamlProvider

	/// <exclude/>
	public class SsoSamlProvider : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SsoSamlProvider(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SsoSamlProvider";
		}

		public SsoSamlProvider(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SsoSamlProvider";
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
		/// Additional parameters.
		/// </summary>
		public string AdditionalParams {
			get {
				return GetTypedColumnValue<string>("AdditionalParams");
			}
			set {
				SetColumnValue("AdditionalParams", value);
			}
		}

		/// <summary>
		/// Active certificate for signing.
		/// </summary>
		public string PartnerCertificateThumbprint {
			get {
				return GetTypedColumnValue<string>("PartnerCertificateThumbprint");
			}
			set {
				SetColumnValue("PartnerCertificateThumbprint", value);
			}
		}

		/// <summary>
		/// Single Sign On URL.
		/// </summary>
		public string SingleSignOnServiceUrl {
			get {
				return GetTypedColumnValue<string>("SingleSignOnServiceUrl");
			}
			set {
				SetColumnValue("SingleSignOnServiceUrl", value);
			}
		}

		/// <summary>
		/// Single Logout URL.
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
		/// Display name.
		/// </summary>
		/// <remarks>
		/// Display name.
		/// </remarks>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		/// <summary>
		/// Code.
		/// </summary>
		public string Code {
			get {
				return GetTypedColumnValue<string>("Code");
			}
			set {
				SetColumnValue("Code", value);
			}
		}

		/// <summary>
		/// Entity ID.
		/// </summary>
		public string EntityID {
			get {
				return GetTypedColumnValue<string>("EntityID");
			}
			set {
				SetColumnValue("EntityID", value);
			}
		}

		/// <summary>
		/// Default Provider.
		/// </summary>
		public bool IsDefault {
			get {
				return GetTypedColumnValue<bool>("IsDefault");
			}
			set {
				SetColumnValue("IsDefault", value);
			}
		}

		/// <summary>
		/// SSO secure only.
		/// </summary>
		public bool SsoSecureOnly {
			get {
				return GetTypedColumnValue<bool>("SsoSecureOnly");
			}
			set {
				SetColumnValue("SsoSecureOnly", value);
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
		public Guid SsoProviderId {
			get {
				return GetTypedColumnValue<Guid>("SsoProviderId");
			}
			set {
				SetColumnValue("SsoProviderId", value);
				_ssoProvider = null;
			}
		}

		/// <exclude/>
		public string SsoProviderName {
			get {
				return GetTypedColumnValue<string>("SsoProviderName");
			}
			set {
				SetColumnValue("SsoProviderName", value);
				if (_ssoProvider != null) {
					_ssoProvider.Name = value;
				}
			}
		}

		private SsoProvider _ssoProvider;
		/// <summary>
		/// Sso identity provider.
		/// </summary>
		public SsoProvider SsoProvider {
			get {
				return _ssoProvider ??
					(_ssoProvider = new SsoProvider(LookupColumnEntities.GetEntity("SsoProvider")));
			}
		}

		/// <exclude/>
		public Guid SsoSettingsTemplateId {
			get {
				return GetTypedColumnValue<Guid>("SsoSettingsTemplateId");
			}
			set {
				SetColumnValue("SsoSettingsTemplateId", value);
				_ssoSettingsTemplate = null;
			}
		}

		/// <exclude/>
		public string SsoSettingsTemplateName {
			get {
				return GetTypedColumnValue<string>("SsoSettingsTemplateName");
			}
			set {
				SetColumnValue("SsoSettingsTemplateName", value);
				if (_ssoSettingsTemplate != null) {
					_ssoSettingsTemplate.Name = value;
				}
			}
		}

		private SsoSettingsTemplate _ssoSettingsTemplate;
		/// <summary>
		/// Settings template.
		/// </summary>
		public SsoSettingsTemplate SsoSettingsTemplate {
			get {
				return _ssoSettingsTemplate ??
					(_ssoSettingsTemplate = new SsoSettingsTemplate(LookupColumnEntities.GetEntity("SsoSettingsTemplate")));
			}
		}

		/// <exclude/>
		public Guid UserTypeId {
			get {
				return GetTypedColumnValue<Guid>("UserTypeId");
			}
			set {
				SetColumnValue("UserTypeId", value);
				_userType = null;
			}
		}

		/// <exclude/>
		public string UserTypeName {
			get {
				return GetTypedColumnValue<string>("UserTypeName");
			}
			set {
				SetColumnValue("UserTypeName", value);
				if (_userType != null) {
					_userType.Name = value;
				}
			}
		}

		private SsoUserType _userType;
		/// <summary>
		/// User type.
		/// </summary>
		public SsoUserType UserType {
			get {
				return _userType ??
					(_userType = new SsoUserType(LookupColumnEntities.GetEntity("UserType")));
			}
		}

		#endregion

	}

	#endregion

}

