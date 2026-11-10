namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: SysQueryHandleRule

	/// <exclude/>
	public class SysQueryHandleRule : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SysQueryHandleRule(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysQueryHandleRule";
		}

		public SysQueryHandleRule(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SysQueryHandleRule";
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

		/// <exclude/>
		public Guid SysQueryActionId {
			get {
				return GetTypedColumnValue<Guid>("SysQueryActionId");
			}
			set {
				SetColumnValue("SysQueryActionId", value);
				_sysQueryAction = null;
			}
		}

		/// <exclude/>
		public string SysQueryActionName {
			get {
				return GetTypedColumnValue<string>("SysQueryActionName");
			}
			set {
				SetColumnValue("SysQueryActionName", value);
				if (_sysQueryAction != null) {
					_sysQueryAction.Name = value;
				}
			}
		}

		private SysQueryAction _sysQueryAction;
		/// <summary>
		/// Query action.
		/// </summary>
		public SysQueryAction SysQueryAction {
			get {
				return _sysQueryAction ??
					(_sysQueryAction = new SysQueryAction(LookupColumnEntities.GetEntity("SysQueryAction")));
			}
		}

		/// <exclude/>
		public Guid SysQueryDetectorId {
			get {
				return GetTypedColumnValue<Guid>("SysQueryDetectorId");
			}
			set {
				SetColumnValue("SysQueryDetectorId", value);
				_sysQueryDetector = null;
			}
		}

		/// <exclude/>
		public string SysQueryDetectorName {
			get {
				return GetTypedColumnValue<string>("SysQueryDetectorName");
			}
			set {
				SetColumnValue("SysQueryDetectorName", value);
				if (_sysQueryDetector != null) {
					_sysQueryDetector.Name = value;
				}
			}
		}

		private SysQueryDetector _sysQueryDetector;
		/// <summary>
		/// Query detector.
		/// </summary>
		public SysQueryDetector SysQueryDetector {
			get {
				return _sysQueryDetector ??
					(_sysQueryDetector = new SysQueryDetector(LookupColumnEntities.GetEntity("SysQueryDetector")));
			}
		}

		/// <exclude/>
		public Guid SysSchemaId {
			get {
				return GetTypedColumnValue<Guid>("SysSchemaId");
			}
			set {
				SetColumnValue("SysSchemaId", value);
				_sysSchema = null;
			}
		}

		/// <exclude/>
		public string SysSchemaTitle {
			get {
				return GetTypedColumnValue<string>("SysSchemaTitle");
			}
			set {
				SetColumnValue("SysSchemaTitle", value);
				if (_sysSchema != null) {
					_sysSchema.Title = value;
				}
			}
		}

		private VwEntityObjects _sysSchema;
		/// <summary>
		/// Entity schema.
		/// </summary>
		public VwEntityObjects SysSchema {
			get {
				return _sysSchema ??
					(_sysSchema = new VwEntityObjects(LookupColumnEntities.GetEntity("SysSchema")));
			}
		}

		/// <summary>
		/// Active.
		/// </summary>
		public bool IsActive {
			get {
				return GetTypedColumnValue<bool>("IsActive");
			}
			set {
				SetColumnValue("IsActive", value);
			}
		}

		/// <summary>
		/// Min row count.
		/// </summary>
		public int MinRowCount {
			get {
				return GetTypedColumnValue<int>("MinRowCount");
			}
			set {
				SetColumnValue("MinRowCount", value);
			}
		}

		/// <summary>
		/// System.
		/// </summary>
		public bool IsSystem {
			get {
				return GetTypedColumnValue<bool>("IsSystem");
			}
			set {
				SetColumnValue("IsSystem", value);
			}
		}

		/// <summary>
		/// Log stack trace.
		/// </summary>
		public bool LogStackTrace {
			get {
				return GetTypedColumnValue<bool>("LogStackTrace");
			}
			set {
				SetColumnValue("LogStackTrace", value);
			}
		}

		/// <summary>
		/// Log query execution time.
		/// </summary>
		public bool LogQueryExecutionTime {
			get {
				return GetTypedColumnValue<bool>("LogQueryExecutionTime");
			}
			set {
				SetColumnValue("LogQueryExecutionTime", value);
			}
		}

		#endregion

	}

	#endregion

}

