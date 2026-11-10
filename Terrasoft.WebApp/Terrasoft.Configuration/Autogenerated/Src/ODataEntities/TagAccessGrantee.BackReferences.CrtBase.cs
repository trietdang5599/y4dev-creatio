namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: TagAccessGrantee

	/// <exclude/>
	public class TagAccessGrantee : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public TagAccessGrantee(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "TagAccessGrantee";
		}

		public TagAccessGrantee(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "TagAccessGrantee";
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
		public Guid SysAdminUnitId {
			get {
				return GetTypedColumnValue<Guid>("SysAdminUnitId");
			}
			set {
				SetColumnValue("SysAdminUnitId", value);
				_sysAdminUnit = null;
			}
		}

		/// <exclude/>
		public string SysAdminUnitName {
			get {
				return GetTypedColumnValue<string>("SysAdminUnitName");
			}
			set {
				SetColumnValue("SysAdminUnitName", value);
				if (_sysAdminUnit != null) {
					_sysAdminUnit.Name = value;
				}
			}
		}

		private SysAdminUnit _sysAdminUnit;
		/// <summary>
		/// System administration object.
		/// </summary>
		public SysAdminUnit SysAdminUnit {
			get {
				return _sysAdminUnit ??
					(_sysAdminUnit = new SysAdminUnit(LookupColumnEntities.GetEntity("SysAdminUnit")));
			}
		}

		/// <exclude/>
		public Guid TagAccessId {
			get {
				return GetTypedColumnValue<Guid>("TagAccessId");
			}
			set {
				SetColumnValue("TagAccessId", value);
				_tagAccess = null;
			}
		}

		/// <exclude/>
		public string TagAccessName {
			get {
				return GetTypedColumnValue<string>("TagAccessName");
			}
			set {
				SetColumnValue("TagAccessName", value);
				if (_tagAccess != null) {
					_tagAccess.Name = value;
				}
			}
		}

		private TagAccess _tagAccess;
		/// <summary>
		/// Access to tag.
		/// </summary>
		public TagAccess TagAccess {
			get {
				return _tagAccess ??
					(_tagAccess = new TagAccess(LookupColumnEntities.GetEntity("TagAccess")));
			}
		}

		/// <summary>
		/// Tagging.
		/// </summary>
		public bool CanTag {
			get {
				return GetTypedColumnValue<bool>("CanTag");
			}
			set {
				SetColumnValue("CanTag", value);
			}
		}

		/// <summary>
		/// Create.
		/// </summary>
		public bool CanCreate {
			get {
				return GetTypedColumnValue<bool>("CanCreate");
			}
			set {
				SetColumnValue("CanCreate", value);
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

		#endregion

	}

	#endregion

}

