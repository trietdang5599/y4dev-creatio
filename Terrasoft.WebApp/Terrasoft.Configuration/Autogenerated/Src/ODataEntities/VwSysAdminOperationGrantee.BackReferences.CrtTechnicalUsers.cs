namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: VwSysAdminOperationGrantee

	/// <exclude/>
	public class VwSysAdminOperationGrantee : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public VwSysAdminOperationGrantee(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwSysAdminOperationGrantee";
		}

		public VwSysAdminOperationGrantee(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "VwSysAdminOperationGrantee";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Access level.
		/// </summary>
		public bool CanExecute {
			get {
				return GetTypedColumnValue<bool>("CanExecute");
			}
			set {
				SetColumnValue("CanExecute", value);
			}
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

		/// <exclude/>
		public Guid SysAdminOperationId {
			get {
				return GetTypedColumnValue<Guid>("SysAdminOperationId");
			}
			set {
				SetColumnValue("SysAdminOperationId", value);
				_sysAdminOperation = null;
			}
		}

		/// <exclude/>
		public string SysAdminOperationName {
			get {
				return GetTypedColumnValue<string>("SysAdminOperationName");
			}
			set {
				SetColumnValue("SysAdminOperationName", value);
				if (_sysAdminOperation != null) {
					_sysAdminOperation.Name = value;
				}
			}
		}

		private SysAdminOperation _sysAdminOperation;
		/// <summary>
		/// Operation.
		/// </summary>
		public SysAdminOperation SysAdminOperation {
			get {
				return _sysAdminOperation ??
					(_sysAdminOperation = new SysAdminOperation(LookupColumnEntities.GetEntity("SysAdminOperation")));
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
		/// User.
		/// </summary>
		public SysAdminUnit SysAdminUnit {
			get {
				return _sysAdminUnit ??
					(_sysAdminUnit = new SysAdminUnit(LookupColumnEntities.GetEntity("SysAdminUnit")));
			}
		}

		#endregion

	}

	#endregion

}

