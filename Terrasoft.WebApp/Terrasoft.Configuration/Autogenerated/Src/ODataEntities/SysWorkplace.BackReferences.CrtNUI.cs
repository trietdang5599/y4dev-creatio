namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: SysWorkplace

	/// <exclude/>
	public class SysWorkplace : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SysWorkplace(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysWorkplace";
		}

		public SysWorkplace(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SysWorkplace";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<SysAdminUnitInWorkplace> SysAdminUnitInWorkplaceCollectionBySysWorkplace {
			get;
			set;
		}

		public IEnumerable<SysModuleInWorkplace> SysModuleInWorkplaceCollectionBySysWorkplace {
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

		/// <summary>
		/// Position.
		/// </summary>
		public int Position {
			get {
				return GetTypedColumnValue<int>("Position");
			}
			set {
				SetColumnValue("Position", value);
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
		/// Personal.
		/// </summary>
		public bool IsPersonal {
			get {
				return GetTypedColumnValue<bool>("IsPersonal");
			}
			set {
				SetColumnValue("IsPersonal", value);
			}
		}

		/// <summary>
		/// Workplace loader schema.
		/// </summary>
		public Guid LoaderId {
			get {
				return GetTypedColumnValue<Guid>("LoaderId");
			}
			set {
				SetColumnValue("LoaderId", value);
			}
		}

		/// <exclude/>
		public Guid SysApplicationClientTypeId {
			get {
				return GetTypedColumnValue<Guid>("SysApplicationClientTypeId");
			}
			set {
				SetColumnValue("SysApplicationClientTypeId", value);
				_sysApplicationClientType = null;
			}
		}

		/// <exclude/>
		public string SysApplicationClientTypeName {
			get {
				return GetTypedColumnValue<string>("SysApplicationClientTypeName");
			}
			set {
				SetColumnValue("SysApplicationClientTypeName", value);
				if (_sysApplicationClientType != null) {
					_sysApplicationClientType.Name = value;
				}
			}
		}

		private SysApplicationClientType _sysApplicationClientType;
		/// <summary>
		/// Usage type.
		/// </summary>
		public SysApplicationClientType SysApplicationClientType {
			get {
				return _sysApplicationClientType ??
					(_sysApplicationClientType = new SysApplicationClientType(LookupColumnEntities.GetEntity("SysApplicationClientType")));
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

		private SysWorkplaceType _type;
		/// <summary>
		/// Type.
		/// </summary>
		public SysWorkplaceType Type {
			get {
				return _type ??
					(_type = new SysWorkplaceType(LookupColumnEntities.GetEntity("Type")));
			}
		}

		/// <summary>
		/// Home page schema identifier.
		/// </summary>
		public Guid HomePageUId {
			get {
				return GetTypedColumnValue<Guid>("HomePageUId");
			}
			set {
				SetColumnValue("HomePageUId", value);
			}
		}

		/// <summary>
		/// Use in Freedom UI only.
		/// </summary>
		public bool UseOnlyShell {
			get {
				return GetTypedColumnValue<bool>("UseOnlyShell");
			}
			set {
				SetColumnValue("UseOnlyShell", value);
			}
		}

		#endregion

	}

	#endregion

}

