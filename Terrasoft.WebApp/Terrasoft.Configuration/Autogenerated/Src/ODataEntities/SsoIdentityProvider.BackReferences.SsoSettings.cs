namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: SsoIdentityProvider

	/// <exclude/>
	public class SsoIdentityProvider : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SsoIdentityProvider(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SsoIdentityProvider";
		}

		public SsoIdentityProvider(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SsoIdentityProvider";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<SsoServiceProvider> SsoServiceProviderCollectionBySsoIdentityProvider {
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
		/// Entity ID.
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
		/// Display name.
		/// </summary>
		public string DisplayName {
			get {
				return GetTypedColumnValue<string>("DisplayName");
			}
			set {
				SetColumnValue("DisplayName", value);
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
		/// Partner certificate thumbprint.
		/// </summary>
		public string PartnerCertificateThumbprint {
			get {
				return GetTypedColumnValue<string>("PartnerCertificateThumbprint");
			}
			set {
				SetColumnValue("PartnerCertificateThumbprint", value);
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

		private SsoIdentityType _type;
		/// <summary>
		/// Type.
		/// </summary>
		public SsoIdentityType Type {
			get {
				return _type ??
					(_type = new SsoIdentityType(LookupColumnEntities.GetEntity("Type")));
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

