namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: TechnicalUsersObjectPermissions

	/// <exclude/>
	public class TechnicalUsersObjectPermissions : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public TechnicalUsersObjectPermissions(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "TechnicalUsersObjectPermissions";
		}

		public TechnicalUsersObjectPermissions(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "TechnicalUsersObjectPermissions";
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
		/// Technical user identifier.
		/// </summary>
		public Guid TechnicalUserId {
			get {
				return GetTypedColumnValue<Guid>("TechnicalUserId");
			}
			set {
				SetColumnValue("TechnicalUserId", value);
			}
		}

		/// <summary>
		/// Object permissions URL.
		/// </summary>
		public string ObjectPermissionsUrl {
			get {
				return GetTypedColumnValue<string>("ObjectPermissionsUrl");
			}
			set {
				SetColumnValue("ObjectPermissionsUrl", value);
			}
		}

		/// <summary>
		/// Object.
		/// </summary>
		public string Object {
			get {
				return GetTypedColumnValue<string>("Object");
			}
			set {
				SetColumnValue("Object", value);
			}
		}

		/// <summary>
		/// Read.
		/// </summary>
		public bool CanRead {
			get {
				return GetTypedColumnValue<bool>("CanRead");
			}
			set {
				SetColumnValue("CanRead", value);
			}
		}

		/// <summary>
		/// Edit.
		/// </summary>
		public bool CanEdit {
			get {
				return GetTypedColumnValue<bool>("CanEdit");
			}
			set {
				SetColumnValue("CanEdit", value);
			}
		}

		/// <summary>
		/// Delete.
		/// </summary>
		public bool CanDelete {
			get {
				return GetTypedColumnValue<bool>("CanDelete");
			}
			set {
				SetColumnValue("CanDelete", value);
			}
		}

		/// <summary>
		/// Create.
		/// </summary>
		public bool CanAppend {
			get {
				return GetTypedColumnValue<bool>("CanAppend");
			}
			set {
				SetColumnValue("CanAppend", value);
			}
		}

		/// <summary>
		/// Managed by records.
		/// </summary>
		public bool AdministratedByRecords {
			get {
				return GetTypedColumnValue<bool>("AdministratedByRecords");
			}
			set {
				SetColumnValue("AdministratedByRecords", value);
			}
		}

		/// <summary>
		/// Managed by column.
		/// </summary>
		public bool AdministratedByColumns {
			get {
				return GetTypedColumnValue<bool>("AdministratedByColumns");
			}
			set {
				SetColumnValue("AdministratedByColumns", value);
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

		#endregion

	}

	#endregion

}

