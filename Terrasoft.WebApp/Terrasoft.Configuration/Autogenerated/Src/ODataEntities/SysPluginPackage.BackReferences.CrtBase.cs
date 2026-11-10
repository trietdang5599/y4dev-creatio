namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: SysPluginPackage

	/// <exclude/>
	public class SysPluginPackage : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SysPluginPackage(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysPluginPackage";
		}

		public SysPluginPackage(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SysPluginPackage";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<SysPluginPackageDeps> SysPluginPackageDepsCollectionBySysPluginPackage {
			get;
			set;
		}

		public IEnumerable<SysPluginPackageInApp> SysPluginPackageInAppCollectionBySysPluginPackage {
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
		/// Description.
		/// </summary>
		public string Description {
			get {
				return GetTypedColumnValue<string>("Description");
			}
			set {
				SetColumnValue("Description", value);
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
		/// Package UId.
		/// </summary>
		public Guid SysPackageUId {
			get {
				return GetTypedColumnValue<Guid>("SysPackageUId");
			}
			set {
				SetColumnValue("SysPackageUId", value);
			}
		}

		/// <exclude/>
		public Guid SysPluginPackageStatusId {
			get {
				return GetTypedColumnValue<Guid>("SysPluginPackageStatusId");
			}
			set {
				SetColumnValue("SysPluginPackageStatusId", value);
				_sysPluginPackageStatus = null;
			}
		}

		/// <exclude/>
		public string SysPluginPackageStatusName {
			get {
				return GetTypedColumnValue<string>("SysPluginPackageStatusName");
			}
			set {
				SetColumnValue("SysPluginPackageStatusName", value);
				if (_sysPluginPackageStatus != null) {
					_sysPluginPackageStatus.Name = value;
				}
			}
		}

		private SysPluginPackageStatus _sysPluginPackageStatus;
		/// <summary>
		/// Plugin package status.
		/// </summary>
		public SysPluginPackageStatus SysPluginPackageStatus {
			get {
				return _sysPluginPackageStatus ??
					(_sysPluginPackageStatus = new SysPluginPackageStatus(LookupColumnEntities.GetEntity("SysPluginPackageStatus")));
			}
		}

		#endregion

	}

	#endregion

}

