namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: AppFeatureState

	/// <exclude/>
	public class AppFeatureState : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public AppFeatureState(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "AppFeatureState";
		}

		public AppFeatureState(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "AppFeatureState";
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
		/// Feature state.
		/// </summary>
		public bool FeatureState {
			get {
				return GetTypedColumnValue<bool>("FeatureState");
			}
			set {
				SetColumnValue("FeatureState", value);
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
		public Guid AdminUnitId {
			get {
				return GetTypedColumnValue<Guid>("AdminUnitId");
			}
			set {
				SetColumnValue("AdminUnitId", value);
				_adminUnit = null;
			}
		}

		/// <exclude/>
		public string AdminUnitName {
			get {
				return GetTypedColumnValue<string>("AdminUnitName");
			}
			set {
				SetColumnValue("AdminUnitName", value);
				if (_adminUnit != null) {
					_adminUnit.Name = value;
				}
			}
		}

		private SysAdminUnit _adminUnit;
		/// <summary>
		/// Admin unit.
		/// </summary>
		public SysAdminUnit AdminUnit {
			get {
				return _adminUnit ??
					(_adminUnit = new SysAdminUnit(LookupColumnEntities.GetEntity("AdminUnit")));
			}
		}

		/// <exclude/>
		public Guid FeatureId {
			get {
				return GetTypedColumnValue<Guid>("FeatureId");
			}
			set {
				SetColumnValue("FeatureId", value);
				_feature = null;
			}
		}

		/// <exclude/>
		public string FeatureCode {
			get {
				return GetTypedColumnValue<string>("FeatureCode");
			}
			set {
				SetColumnValue("FeatureCode", value);
				if (_feature != null) {
					_feature.Code = value;
				}
			}
		}

		private AppFeature _feature;
		/// <summary>
		/// Feature.
		/// </summary>
		public AppFeature Feature {
			get {
				return _feature ??
					(_feature = new AppFeature(LookupColumnEntities.GetEntity("Feature")));
			}
		}

		#endregion

	}

	#endregion

}

