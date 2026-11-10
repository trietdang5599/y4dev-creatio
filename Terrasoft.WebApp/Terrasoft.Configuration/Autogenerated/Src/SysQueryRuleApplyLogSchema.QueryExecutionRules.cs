namespace Terrasoft.Configuration
{

	using DataContract = Terrasoft.Nui.ServiceModel.DataContract;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Data;
	using System.Drawing;
	using System.Globalization;
	using System.IO;
	using System.Linq;
	using Terrasoft.Common;
	using Terrasoft.Common.Json;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.DcmProcess;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;
	using Terrasoft.GlobalSearch.Indexing;
	using Terrasoft.UI.WebControls.Controls;
	using Terrasoft.UI.WebControls.Utilities.Json.Converters;

	#region Class: SysQueryRuleApplyLogSchema

	/// <exclude/>
	public class SysQueryRuleApplyLogSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysQueryRuleApplyLogSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysQueryRuleApplyLogSchema(SysQueryRuleApplyLogSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysQueryRuleApplyLogSchema(SysQueryRuleApplyLogSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIXU_SysQueryRuleApplyLogIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = true
			};
			index.UId = new Guid("f0c44edd-819a-4558-9a07-9091994602ad");
			index.Name = "IXU_SysQueryRuleApplyLog";
			index.CreatedInSchemaUId = new Guid("923d0996-7e08-47f8-bce7-e74ae7f7a20e");
			index.ModifiedInSchemaUId = new Guid("923d0996-7e08-47f8-bce7-e74ae7f7a20e");
			index.CreatedInPackageId = new Guid("4e6ccfb8-9251-4fde-a337-f61d1d253a58");
			EntitySchemaIndexColumn rootSchemaNameIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("dc8ff5b1-eef7-e3a8-e38f-a4576660d311"),
				ColumnUId = new Guid("5a63d8fa-c91e-c9e0-c5a1-346f5480dcb8"),
				CreatedInSchemaUId = new Guid("923d0996-7e08-47f8-bce7-e74ae7f7a20e"),
				ModifiedInSchemaUId = new Guid("923d0996-7e08-47f8-bce7-e74ae7f7a20e"),
				CreatedInPackageId = new Guid("4e6ccfb8-9251-4fde-a337-f61d1d253a58"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(rootSchemaNameIndexColumn);
			EntitySchemaIndexColumn sysQueryActionIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("fc7a3c08-198a-882e-c7ef-3b227f16c81f"),
				ColumnUId = new Guid("77635c6a-eb4c-0c7d-f419-f728dca6d10f"),
				CreatedInSchemaUId = new Guid("923d0996-7e08-47f8-bce7-e74ae7f7a20e"),
				ModifiedInSchemaUId = new Guid("923d0996-7e08-47f8-bce7-e74ae7f7a20e"),
				CreatedInPackageId = new Guid("4e6ccfb8-9251-4fde-a337-f61d1d253a58"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(sysQueryActionIdIndexColumn);
			EntitySchemaIndexColumn sysQueryDetectorIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("81b27571-3b24-8ff5-e7b2-2943a4c49c1d"),
				ColumnUId = new Guid("72e650af-7a08-c8c6-d7c6-1ab8ec096fa8"),
				CreatedInSchemaUId = new Guid("923d0996-7e08-47f8-bce7-e74ae7f7a20e"),
				ModifiedInSchemaUId = new Guid("923d0996-7e08-47f8-bce7-e74ae7f7a20e"),
				CreatedInPackageId = new Guid("4e6ccfb8-9251-4fde-a337-f61d1d253a58"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(sysQueryDetectorIdIndexColumn);
			EntitySchemaIndexColumn sysQuerySqlTextIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("811aadef-4ce6-9144-3ec2-ea386d012351"),
				ColumnUId = new Guid("c0e6b3aa-eb71-53b3-98c0-f526d11f93ca"),
				CreatedInSchemaUId = new Guid("923d0996-7e08-47f8-bce7-e74ae7f7a20e"),
				ModifiedInSchemaUId = new Guid("923d0996-7e08-47f8-bce7-e74ae7f7a20e"),
				CreatedInPackageId = new Guid("4e6ccfb8-9251-4fde-a337-f61d1d253a58"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(sysQuerySqlTextIdIndexColumn);
			EntitySchemaIndexColumn sysQueryStackTraceIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("52de5049-78bc-57ab-30d8-6978b901fd63"),
				ColumnUId = new Guid("fb4f1c70-3606-3403-1531-0b74919d1603"),
				CreatedInSchemaUId = new Guid("923d0996-7e08-47f8-bce7-e74ae7f7a20e"),
				ModifiedInSchemaUId = new Guid("923d0996-7e08-47f8-bce7-e74ae7f7a20e"),
				CreatedInPackageId = new Guid("4e6ccfb8-9251-4fde-a337-f61d1d253a58"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(sysQueryStackTraceIdIndexColumn);
			EntitySchemaIndexColumn userNameIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("fa4b5af7-cc2c-e35a-4f37-7c239a948b99"),
				ColumnUId = new Guid("7a5cec88-9cf0-481c-0684-3ea18891567e"),
				CreatedInSchemaUId = new Guid("923d0996-7e08-47f8-bce7-e74ae7f7a20e"),
				ModifiedInSchemaUId = new Guid("923d0996-7e08-47f8-bce7-e74ae7f7a20e"),
				CreatedInPackageId = new Guid("4e6ccfb8-9251-4fde-a337-f61d1d253a58"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(userNameIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("923d0996-7e08-47f8-bce7-e74ae7f7a20e");
			RealUId = new Guid("923d0996-7e08-47f8-bce7-e74ae7f7a20e");
			Name = "SysQueryRuleApplyLog";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("893cdaa8-120b-49c2-9275-32fda5bd010f");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("fb4f1c70-3606-3403-1531-0b74919d1603")) == null) {
				Columns.Add(CreateSysQueryStackTraceColumn());
			}
			if (Columns.FindByUId(new Guid("c0e6b3aa-eb71-53b3-98c0-f526d11f93ca")) == null) {
				Columns.Add(CreateSysQuerySqlTextColumn());
			}
			if (Columns.FindByUId(new Guid("72e650af-7a08-c8c6-d7c6-1ab8ec096fa8")) == null) {
				Columns.Add(CreateSysQueryDetectorColumn());
			}
			if (Columns.FindByUId(new Guid("77635c6a-eb4c-0c7d-f419-f728dca6d10f")) == null) {
				Columns.Add(CreateSysQueryActionColumn());
			}
			if (Columns.FindByUId(new Guid("58da2805-dda7-416a-52b8-47fccff27d7d")) == null) {
				Columns.Add(CreateMessageColumn());
			}
			if (Columns.FindByUId(new Guid("5a63d8fa-c91e-c9e0-c5a1-346f5480dcb8")) == null) {
				Columns.Add(CreateRootSchemaNameColumn());
			}
			if (Columns.FindByUId(new Guid("7a5cec88-9cf0-481c-0684-3ea18891567e")) == null) {
				Columns.Add(CreateUserNameColumn());
			}
			if (Columns.FindByUId(new Guid("ae3c7412-29a0-a16f-2fe5-5a83bab39cc0")) == null) {
				Columns.Add(CreateQueryExecutionTimeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysQueryStackTraceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("fb4f1c70-3606-3403-1531-0b74919d1603"),
				Name = @"SysQueryStackTrace",
				ReferenceSchemaUId = new Guid("104ee061-3cc4-4b03-94ce-27f57c2cdd4a"),
				IsIndexed = true,
				IsWeakReference = true,
				CreatedInSchemaUId = new Guid("923d0996-7e08-47f8-bce7-e74ae7f7a20e"),
				ModifiedInSchemaUId = new Guid("923d0996-7e08-47f8-bce7-e74ae7f7a20e"),
				CreatedInPackageId = new Guid("893cdaa8-120b-49c2-9275-32fda5bd010f")
			};
		}

		protected virtual EntitySchemaColumn CreateSysQuerySqlTextColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("c0e6b3aa-eb71-53b3-98c0-f526d11f93ca"),
				Name = @"SysQuerySqlText",
				ReferenceSchemaUId = new Guid("6d570bdd-5c1f-4bf2-a8ce-2195c9a638b2"),
				IsIndexed = true,
				IsWeakReference = true,
				CreatedInSchemaUId = new Guid("923d0996-7e08-47f8-bce7-e74ae7f7a20e"),
				ModifiedInSchemaUId = new Guid("923d0996-7e08-47f8-bce7-e74ae7f7a20e"),
				CreatedInPackageId = new Guid("893cdaa8-120b-49c2-9275-32fda5bd010f")
			};
		}

		protected virtual EntitySchemaColumn CreateSysQueryDetectorColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("72e650af-7a08-c8c6-d7c6-1ab8ec096fa8"),
				Name = @"SysQueryDetector",
				ReferenceSchemaUId = new Guid("63b874db-289b-4bd2-97b2-6391c737fc9e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("923d0996-7e08-47f8-bce7-e74ae7f7a20e"),
				ModifiedInSchemaUId = new Guid("923d0996-7e08-47f8-bce7-e74ae7f7a20e"),
				CreatedInPackageId = new Guid("893cdaa8-120b-49c2-9275-32fda5bd010f")
			};
		}

		protected virtual EntitySchemaColumn CreateSysQueryActionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("77635c6a-eb4c-0c7d-f419-f728dca6d10f"),
				Name = @"SysQueryAction",
				ReferenceSchemaUId = new Guid("8bc63dbf-e5fa-4635-afed-a3c8f853a5ab"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("923d0996-7e08-47f8-bce7-e74ae7f7a20e"),
				ModifiedInSchemaUId = new Guid("923d0996-7e08-47f8-bce7-e74ae7f7a20e"),
				CreatedInPackageId = new Guid("893cdaa8-120b-49c2-9275-32fda5bd010f")
			};
		}

		protected virtual EntitySchemaColumn CreateMessageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("58da2805-dda7-416a-52b8-47fccff27d7d"),
				Name = @"Message",
				CreatedInSchemaUId = new Guid("923d0996-7e08-47f8-bce7-e74ae7f7a20e"),
				ModifiedInSchemaUId = new Guid("923d0996-7e08-47f8-bce7-e74ae7f7a20e"),
				CreatedInPackageId = new Guid("893cdaa8-120b-49c2-9275-32fda5bd010f")
			};
		}

		protected virtual EntitySchemaColumn CreateRootSchemaNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("5a63d8fa-c91e-c9e0-c5a1-346f5480dcb8"),
				Name = @"RootSchemaName",
				CreatedInSchemaUId = new Guid("923d0996-7e08-47f8-bce7-e74ae7f7a20e"),
				ModifiedInSchemaUId = new Guid("923d0996-7e08-47f8-bce7-e74ae7f7a20e"),
				CreatedInPackageId = new Guid("893cdaa8-120b-49c2-9275-32fda5bd010f")
			};
		}

		protected virtual EntitySchemaColumn CreateUserNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("7a5cec88-9cf0-481c-0684-3ea18891567e"),
				Name = @"UserName",
				CreatedInSchemaUId = new Guid("923d0996-7e08-47f8-bce7-e74ae7f7a20e"),
				ModifiedInSchemaUId = new Guid("923d0996-7e08-47f8-bce7-e74ae7f7a20e"),
				CreatedInPackageId = new Guid("893cdaa8-120b-49c2-9275-32fda5bd010f")
			};
		}

		protected virtual EntitySchemaColumn CreateQueryExecutionTimeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("ae3c7412-29a0-a16f-2fe5-5a83bab39cc0"),
				Name = @"QueryExecutionTime",
				CreatedInSchemaUId = new Guid("923d0996-7e08-47f8-bce7-e74ae7f7a20e"),
				ModifiedInSchemaUId = new Guid("923d0996-7e08-47f8-bce7-e74ae7f7a20e"),
				CreatedInPackageId = new Guid("6de86b15-f244-46b6-84c4-207bb6ab164c")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIXU_SysQueryRuleApplyLogIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysQueryRuleApplyLog(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysQueryRuleApplyLog_QueryExecutionRulesEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysQueryRuleApplyLogSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysQueryRuleApplyLogSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("923d0996-7e08-47f8-bce7-e74ae7f7a20e"));
		}

		#endregion

	}

	#endregion

	#region Class: SysQueryRuleApplyLog

	/// <summary>
	/// Query rule apply log.
	/// </summary>
	public class SysQueryRuleApplyLog : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysQueryRuleApplyLog(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysQueryRuleApplyLog";
		}

		public SysQueryRuleApplyLog(SysQueryRuleApplyLog source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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
					(_sysQueryStackTrace = LookupColumnEntities.GetEntity("SysQueryStackTrace") as SysQueryStackTrace);
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
					(_sysQuerySqlText = LookupColumnEntities.GetEntity("SysQuerySqlText") as SysQuerySqlText);
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
					(_sysQueryDetector = LookupColumnEntities.GetEntity("SysQueryDetector") as SysQueryDetector);
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
					(_sysQueryAction = LookupColumnEntities.GetEntity("SysQueryAction") as SysQueryAction);
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

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysQueryRuleApplyLog_QueryExecutionRulesEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysQueryRuleApplyLog(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysQueryRuleApplyLog_QueryExecutionRulesEventsProcess

	/// <exclude/>
	public partial class SysQueryRuleApplyLog_QueryExecutionRulesEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysQueryRuleApplyLog
	{

		public SysQueryRuleApplyLog_QueryExecutionRulesEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysQueryRuleApplyLog_QueryExecutionRulesEventsProcess";
			SchemaUId = new Guid("923d0996-7e08-47f8-bce7-e74ae7f7a20e");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("923d0996-7e08-47f8-bce7-e74ae7f7a20e");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: SysQueryRuleApplyLog_QueryExecutionRulesEventsProcess

	/// <exclude/>
	public class SysQueryRuleApplyLog_QueryExecutionRulesEventsProcess : SysQueryRuleApplyLog_QueryExecutionRulesEventsProcess<SysQueryRuleApplyLog>
	{

		public SysQueryRuleApplyLog_QueryExecutionRulesEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysQueryRuleApplyLog_QueryExecutionRulesEventsProcess

	public partial class SysQueryRuleApplyLog_QueryExecutionRulesEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysQueryRuleApplyLogEventsProcess

	/// <exclude/>
	public class SysQueryRuleApplyLogEventsProcess : SysQueryRuleApplyLog_QueryExecutionRulesEventsProcess
	{

		public SysQueryRuleApplyLogEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

