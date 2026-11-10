namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: SsoBaseSettings

	/// <exclude/>
	public class SsoBaseSettings : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SsoBaseSettings(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SsoBaseSettings";
		}

		public SsoBaseSettings(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SsoBaseSettings";
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

		#endregion

	}

	#endregion

}

