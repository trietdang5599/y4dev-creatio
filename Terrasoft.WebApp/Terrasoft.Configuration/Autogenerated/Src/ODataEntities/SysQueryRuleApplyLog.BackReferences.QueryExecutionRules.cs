namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: SysQueryRuleApplyLog

	/// <exclude/>
	public class SysQueryRuleApplyLog : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SysQueryRuleApplyLog(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysQueryRuleApplyLog";
		}

		public SysQueryRuleApplyLog(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SysQueryRuleApplyLog";
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
		public Guid SysQueryStackTraceId {
			get {
				return GetTypedColumnValue<Guid>("SysQueryStackTraceId");
			}
			set {
				SetColumnValue("SysQueryStackTraceId", value);
				_sysQueryStackTrace = null;
			}
		}

		private SysQueryStackTrace _sysQueryStackTrace;
		/// <summary>
		/// Query stack trace.
		/// </summary>
		public SysQueryStackTrace SysQueryStackTrace {
			get {
				return _sysQueryStackTrace ??
					(_sysQueryStackTrace = new SysQueryStackTrace(LookupColumnEntities.GetEntity("SysQueryStackTrace")));
			}
		}

		/// <exclude/>
		public Guid SysQuerySqlTextId {
			get {
				return GetTypedColumnValue<Guid>("SysQuerySqlTextId");
			}
			set {
				SetColumnValue("SysQuerySqlTextId", value);
				_sysQuerySqlText = null;
			}
		}

		private SysQuerySqlText _sysQuerySqlText;
		/// <summary>
		/// Query sql text.
		/// </summary>
		public SysQuerySqlText SysQuerySqlText {
			get {
				return _sysQuerySqlText ??
					(_sysQuerySqlText = new SysQuerySqlText(LookupColumnEntities.GetEntity("SysQuerySqlText")));
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

		/// <summary>
		/// Message.
		/// </summary>
		public string Message {
			get {
				return GetTypedColumnValue<string>("Message");
			}
			set {
				SetColumnValue("Message", value);
			}
		}

		/// <summary>
		/// Schema name.
		/// </summary>
		public string RootSchemaName {
			get {
				return GetTypedColumnValue<string>("RootSchemaName");
			}
			set {
				SetColumnValue("RootSchemaName", value);
			}
		}

		/// <summary>
		/// User login.
		/// </summary>
		public string UserName {
			get {
				return GetTypedColumnValue<string>("UserName");
			}
			set {
				SetColumnValue("UserName", value);
			}
		}

		/// <summary>
		/// Execution time, sec.
		/// </summary>
		public Decimal QueryExecutionTime {
			get {
				return GetTypedColumnValue<Decimal>("QueryExecutionTime");
			}
			set {
				SetColumnValue("QueryExecutionTime", value);
			}
		}

		#endregion

	}

	#endregion

}

