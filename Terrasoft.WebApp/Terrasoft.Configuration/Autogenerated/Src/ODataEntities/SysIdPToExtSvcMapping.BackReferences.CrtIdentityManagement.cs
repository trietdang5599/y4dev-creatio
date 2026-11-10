namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: SysIdPToExtSvcMapping

	/// <exclude/>
	public class SysIdPToExtSvcMapping : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SysIdPToExtSvcMapping(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysIdPToExtSvcMapping";
		}

		public SysIdPToExtSvcMapping(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SysIdPToExtSvcMapping";
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
		public Guid IdentityProviderId {
			get {
				return GetTypedColumnValue<Guid>("IdentityProviderId");
			}
			set {
				SetColumnValue("IdentityProviderId", value);
				_identityProvider = null;
			}
		}

		/// <exclude/>
		public string IdentityProviderName {
			get {
				return GetTypedColumnValue<string>("IdentityProviderName");
			}
			set {
				SetColumnValue("IdentityProviderName", value);
				if (_identityProvider != null) {
					_identityProvider.Name = value;
				}
			}
		}

		private SysIdentityProvider _identityProvider;
		/// <summary>
		/// Identity Provider.
		/// </summary>
		public SysIdentityProvider IdentityProvider {
			get {
				return _identityProvider ??
					(_identityProvider = new SysIdentityProvider(LookupColumnEntities.GetEntity("IdentityProvider")));
			}
		}

		/// <exclude/>
		public Guid ServiceId {
			get {
				return GetTypedColumnValue<Guid>("ServiceId");
			}
			set {
				SetColumnValue("ServiceId", value);
				_service = null;
			}
		}

		/// <exclude/>
		public string ServiceName {
			get {
				return GetTypedColumnValue<string>("ServiceName");
			}
			set {
				SetColumnValue("ServiceName", value);
				if (_service != null) {
					_service.Name = value;
				}
			}
		}

		private SysExternalService _service;
		/// <summary>
		/// Service.
		/// </summary>
		public SysExternalService Service {
			get {
				return _service ??
					(_service = new SysExternalService(LookupColumnEntities.GetEntity("Service")));
			}
		}

		#endregion

	}

	#endregion

}

