namespace Terrasoft.Configuration
{

	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.IO;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;

	#region Class: VwCopilotSessionIntentSchema

	/// <exclude/>
	public class VwCopilotSessionIntentSchema : Terrasoft.Core.Entities.EntitySchema
	{

		#region Constructors: Public

		public VwCopilotSessionIntentSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwCopilotSessionIntentSchema(VwCopilotSessionIntentSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwCopilotSessionIntentSchema(VwCopilotSessionIntentSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ab99e342-ce78-4481-9407-512fe261930a");
			RealUId = new Guid("ab99e342-ce78-4481-9407-512fe261930a");
			Name = "VwCopilotSessionIntent";
			ParentSchemaUId = new Guid("1b56b061-4e91-4974-9038-df8340e534f2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("7a3a8162-4be1-46b5-bd50-b3efc2df6d2e");
			IsDBView = true;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = false;
			UseLiveEditing = false;
			Paging.IsPageable = true;
			Filtering.IsFilterable = true;
			Sorting.IsSortable = true;
			Write.IsInsertable = true;
			Write.IsUpdatable = true;
			Write.IsDeletable = true;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryColumn() {
			base.InitializePrimaryColumn();
			PrimaryColumn = CreateIdColumn();
			if (Columns.FindByUId(PrimaryColumn.UId) == null) {
				Columns.Add(PrimaryColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("c4a3a8cb-af9d-c9aa-156d-d19bfbf1f210")) == null) {
				Columns.Add(CreateTotalTokensColumn());
			}
			if (Columns.FindByUId(new Guid("1148bcf4-5f2d-f6f7-a106-9d40e2f295e8")) == null) {
				Columns.Add(CreateIntentColumn());
			}
			if (Columns.FindByUId(new Guid("262a775b-7dde-6408-15a9-d363bbde6ef4")) == null) {
				Columns.Add(CreateCopilotSessionColumn());
			}
			if (Columns.FindByUId(new Guid("10e7eb3d-1572-6a75-af1a-6e875a4a06ef")) == null) {
				Columns.Add(CreateTotalActionsColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateTotalTokensColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("c4a3a8cb-af9d-c9aa-156d-d19bfbf1f210"),
				Name = @"TotalTokens",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("ab99e342-ce78-4481-9407-512fe261930a"),
				ModifiedInSchemaUId = new Guid("ab99e342-ce78-4481-9407-512fe261930a"),
				CreatedInPackageId = new Guid("7a3a8162-4be1-46b5-bd50-b3efc2df6d2e")
			};
		}

		protected virtual EntitySchemaColumn CreateIntentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("1148bcf4-5f2d-f6f7-a106-9d40e2f295e8"),
				Name = @"Intent",
				ReferenceSchemaUId = new Guid("90fa6d02-3e93-45d6-a72b-58dcffa411ae"),
				CreatedInSchemaUId = new Guid("ab99e342-ce78-4481-9407-512fe261930a"),
				ModifiedInSchemaUId = new Guid("ab99e342-ce78-4481-9407-512fe261930a"),
				CreatedInPackageId = new Guid("7a3a8162-4be1-46b5-bd50-b3efc2df6d2e"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("84b0c317-29a0-f59e-8fd4-74af7580a8b9"),
				Name = @"Id",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("ab99e342-ce78-4481-9407-512fe261930a"),
				ModifiedInSchemaUId = new Guid("ab99e342-ce78-4481-9407-512fe261930a"),
				CreatedInPackageId = new Guid("7a3a8162-4be1-46b5-bd50-b3efc2df6d2e"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"AutoGuid")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateCopilotSessionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("262a775b-7dde-6408-15a9-d363bbde6ef4"),
				Name = @"CopilotSession",
				ReferenceSchemaUId = new Guid("b5e91b69-1cf7-456c-a553-76302e52f42f"),
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("ab99e342-ce78-4481-9407-512fe261930a"),
				ModifiedInSchemaUId = new Guid("ab99e342-ce78-4481-9407-512fe261930a"),
				CreatedInPackageId = new Guid("7a3a8162-4be1-46b5-bd50-b3efc2df6d2e"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateTotalActionsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("10e7eb3d-1572-6a75-af1a-6e875a4a06ef"),
				Name = @"TotalActions",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("ab99e342-ce78-4481-9407-512fe261930a"),
				ModifiedInSchemaUId = new Guid("ab99e342-ce78-4481-9407-512fe261930a"),
				CreatedInPackageId = new Guid("c23dfaf0-0051-4966-86f8-cbe8197258d0")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwCopilotSessionIntent(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwCopilotSessionIntent_CrtCopilotEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwCopilotSessionIntentSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwCopilotSessionIntentSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ab99e342-ce78-4481-9407-512fe261930a"));
		}

		#endregion

	}

	#endregion

	#region Class: VwCopilotSessionIntent

	/// <summary>
	/// Creatio.ai Session Skills (view).
	/// </summary>
	public class VwCopilotSessionIntent : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public VwCopilotSessionIntent(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwCopilotSessionIntent";
		}

		public VwCopilotSessionIntent(VwCopilotSessionIntent source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Total Tokens.
		/// </summary>
		public int TotalTokens {
			get {
				return GetTypedColumnValue<int>("TotalTokens");
			}
			set {
				SetColumnValue("TotalTokens", value);
			}
		}

		/// <exclude/>
		public Guid IntentId {
			get {
				return GetTypedColumnValue<Guid>("IntentId");
			}
			set {
				SetColumnValue("IntentId", value);
				_intent = null;
			}
		}

		/// <exclude/>
		public string IntentCaption {
			get {
				return GetTypedColumnValue<string>("IntentCaption");
			}
			set {
				SetColumnValue("IntentCaption", value);
				if (_intent != null) {
					_intent.Caption = value;
				}
			}
		}

		private VwSysSchemaInfo _intent;
		/// <summary>
		/// Skill.
		/// </summary>
		public VwSysSchemaInfo Intent {
			get {
				return _intent ??
					(_intent = LookupColumnEntities.GetEntity("Intent") as VwSysSchemaInfo);
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
		public Guid CopilotSessionId {
			get {
				return GetTypedColumnValue<Guid>("CopilotSessionId");
			}
			set {
				SetColumnValue("CopilotSessionId", value);
				_copilotSession = null;
			}
		}

		/// <exclude/>
		public string CopilotSessionTitle {
			get {
				return GetTypedColumnValue<string>("CopilotSessionTitle");
			}
			set {
				SetColumnValue("CopilotSessionTitle", value);
				if (_copilotSession != null) {
					_copilotSession.Title = value;
				}
			}
		}

		private CopilotSessionEnt _copilotSession;
		/// <summary>
		/// Creatio.ai Session.
		/// </summary>
		public CopilotSessionEnt CopilotSession {
			get {
				return _copilotSession ??
					(_copilotSession = LookupColumnEntities.GetEntity("CopilotSession") as CopilotSessionEnt);
			}
		}

		/// <summary>
		/// Total Actions.
		/// </summary>
		public int TotalActions {
			get {
				return GetTypedColumnValue<int>("TotalActions");
			}
			set {
				SetColumnValue("TotalActions", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwCopilotSessionIntent_CrtCopilotEventsProcess(UserConnection);
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
			return new VwCopilotSessionIntent(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwCopilotSessionIntent_CrtCopilotEventsProcess

	/// <exclude/>
	public partial class VwCopilotSessionIntent_CrtCopilotEventsProcess<TEntity> : Terrasoft.Core.Process.EmbeddedProcess where TEntity : VwCopilotSessionIntent
	{

		private TEntity _entity;
		public TEntity Entity {
			get {
				return _entity;
			}
			set {
				_entity = value;
			}
		}

		public VwCopilotSessionIntent_CrtCopilotEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwCopilotSessionIntent_CrtCopilotEventsProcess";
			SchemaUId = new Guid("ab99e342-ce78-4481-9407-512fe261930a");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ab99e342-ce78-4481-9407-512fe261930a");
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

	#region Class: VwCopilotSessionIntent_CrtCopilotEventsProcess

	/// <exclude/>
	public class VwCopilotSessionIntent_CrtCopilotEventsProcess : VwCopilotSessionIntent_CrtCopilotEventsProcess<VwCopilotSessionIntent>
	{

		public VwCopilotSessionIntent_CrtCopilotEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwCopilotSessionIntent_CrtCopilotEventsProcess

	public partial class VwCopilotSessionIntent_CrtCopilotEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwCopilotSessionIntentEventsProcess

	/// <exclude/>
	public class VwCopilotSessionIntentEventsProcess : VwCopilotSessionIntent_CrtCopilotEventsProcess
	{

		public VwCopilotSessionIntentEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

