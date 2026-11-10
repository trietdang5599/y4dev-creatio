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

	#region Class: SysQueryHandleRuleSchema

	/// <exclude/>
	public class SysQueryHandleRuleSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public SysQueryHandleRuleSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysQueryHandleRuleSchema(SysQueryHandleRuleSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysQueryHandleRuleSchema(SysQueryHandleRuleSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIU_SysQueryHandleRule_NameIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = true
			};
			index.UId = new Guid("5e0f513d-038f-4c2c-93f6-d88647785c24");
			index.Name = "IU_SysQueryHandleRule_Name";
			index.CreatedInSchemaUId = new Guid("25d4db17-93e6-49e1-82a0-a86aaeb83e03");
			index.ModifiedInSchemaUId = new Guid("25d4db17-93e6-49e1-82a0-a86aaeb83e03");
			index.CreatedInPackageId = new Guid("4e6ccfb8-9251-4fde-a337-f61d1d253a58");
			EntitySchemaIndexColumn nameIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("5f822f28-69b0-2542-cdc5-59063eccc121"),
				ColumnUId = new Guid("736c30a7-c0ec-4fa9-b034-2552b319b633"),
				CreatedInSchemaUId = new Guid("25d4db17-93e6-49e1-82a0-a86aaeb83e03"),
				ModifiedInSchemaUId = new Guid("25d4db17-93e6-49e1-82a0-a86aaeb83e03"),
				CreatedInPackageId = new Guid("4e6ccfb8-9251-4fde-a337-f61d1d253a58"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(nameIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("25d4db17-93e6-49e1-82a0-a86aaeb83e03");
			RealUId = new Guid("25d4db17-93e6-49e1-82a0-a86aaeb83e03");
			Name = "SysQueryHandleRule";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("3bbfe949-b951-43d9-9731-34da65187e20");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("50d93a6b-d9bc-e018-6361-cfbb3a5a5613")) == null) {
				Columns.Add(CreateSysQueryActionColumn());
			}
			if (Columns.FindByUId(new Guid("a7739811-0a1b-9b78-f61b-6207df99ee34")) == null) {
				Columns.Add(CreateSysQueryDetectorColumn());
			}
			if (Columns.FindByUId(new Guid("ab6fef3c-66e0-fac0-dadf-df9e15de4b94")) == null) {
				Columns.Add(CreateSysSchemaColumn());
			}
			if (Columns.FindByUId(new Guid("3642de17-f6b1-4a37-27f9-bd0d37aed828")) == null) {
				Columns.Add(CreateIsActiveColumn());
			}
			if (Columns.FindByUId(new Guid("672e6557-0ee0-50ed-3d50-78704bac60f7")) == null) {
				Columns.Add(CreateMinRowCountColumn());
			}
			if (Columns.FindByUId(new Guid("d1089d43-6725-e31a-e3fe-18d817c2734e")) == null) {
				Columns.Add(CreateIsSystemColumn());
			}
			if (Columns.FindByUId(new Guid("2e1f6911-afe5-7479-cd92-cc7a5d9b045f")) == null) {
				Columns.Add(CreateLogStackTraceColumn());
			}
			if (Columns.FindByUId(new Guid("488002e3-907e-cef3-3193-ed3a5a2f3e62")) == null) {
				Columns.Add(CreateLogQueryExecutionTimeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysQueryActionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("50d93a6b-d9bc-e018-6361-cfbb3a5a5613"),
				Name = @"SysQueryAction",
				ReferenceSchemaUId = new Guid("8bc63dbf-e5fa-4635-afed-a3c8f853a5ab"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("25d4db17-93e6-49e1-82a0-a86aaeb83e03"),
				ModifiedInSchemaUId = new Guid("25d4db17-93e6-49e1-82a0-a86aaeb83e03"),
				CreatedInPackageId = new Guid("3bbfe949-b951-43d9-9731-34da65187e20"),
				IsTrackChangesInDB = true
			};
		}

		protected virtual EntitySchemaColumn CreateSysQueryDetectorColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("a7739811-0a1b-9b78-f61b-6207df99ee34"),
				Name = @"SysQueryDetector",
				ReferenceSchemaUId = new Guid("63b874db-289b-4bd2-97b2-6391c737fc9e"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("25d4db17-93e6-49e1-82a0-a86aaeb83e03"),
				ModifiedInSchemaUId = new Guid("25d4db17-93e6-49e1-82a0-a86aaeb83e03"),
				CreatedInPackageId = new Guid("3bbfe949-b951-43d9-9731-34da65187e20"),
				IsTrackChangesInDB = true
			};
		}

		protected virtual EntitySchemaColumn CreateSysSchemaColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ab6fef3c-66e0-fac0-dadf-df9e15de4b94"),
				Name = @"SysSchema",
				ReferenceSchemaUId = new Guid("c82db13a-7f77-4085-b3ef-91c5420fd417"),
				IsIndexed = true,
				IsWeakReference = true,
				CreatedInSchemaUId = new Guid("25d4db17-93e6-49e1-82a0-a86aaeb83e03"),
				ModifiedInSchemaUId = new Guid("25d4db17-93e6-49e1-82a0-a86aaeb83e03"),
				CreatedInPackageId = new Guid("3bbfe949-b951-43d9-9731-34da65187e20"),
				IsTrackChangesInDB = true
			};
		}

		protected virtual EntitySchemaColumn CreateIsActiveColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("3642de17-f6b1-4a37-27f9-bd0d37aed828"),
				Name = @"IsActive",
				CreatedInSchemaUId = new Guid("25d4db17-93e6-49e1-82a0-a86aaeb83e03"),
				ModifiedInSchemaUId = new Guid("25d4db17-93e6-49e1-82a0-a86aaeb83e03"),
				CreatedInPackageId = new Guid("3bbfe949-b951-43d9-9731-34da65187e20"),
				IsTrackChangesInDB = true,
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"True"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateMinRowCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("672e6557-0ee0-50ed-3d50-78704bac60f7"),
				Name = @"MinRowCount",
				CreatedInSchemaUId = new Guid("25d4db17-93e6-49e1-82a0-a86aaeb83e03"),
				ModifiedInSchemaUId = new Guid("25d4db17-93e6-49e1-82a0-a86aaeb83e03"),
				CreatedInPackageId = new Guid("3bbfe949-b951-43d9-9731-34da65187e20"),
				IsTrackChangesInDB = true,
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"1000"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateIsSystemColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("d1089d43-6725-e31a-e3fe-18d817c2734e"),
				Name = @"IsSystem",
				CreatedInSchemaUId = new Guid("25d4db17-93e6-49e1-82a0-a86aaeb83e03"),
				ModifiedInSchemaUId = new Guid("25d4db17-93e6-49e1-82a0-a86aaeb83e03"),
				CreatedInPackageId = new Guid("3bbfe949-b951-43d9-9731-34da65187e20"),
				IsTrackChangesInDB = true
			};
		}

		protected virtual EntitySchemaColumn CreateLogStackTraceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("2e1f6911-afe5-7479-cd92-cc7a5d9b045f"),
				Name = @"LogStackTrace",
				CreatedInSchemaUId = new Guid("25d4db17-93e6-49e1-82a0-a86aaeb83e03"),
				ModifiedInSchemaUId = new Guid("25d4db17-93e6-49e1-82a0-a86aaeb83e03"),
				CreatedInPackageId = new Guid("3bbfe949-b951-43d9-9731-34da65187e20"),
				IsTrackChangesInDB = true
			};
		}

		protected virtual EntitySchemaColumn CreateLogQueryExecutionTimeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("488002e3-907e-cef3-3193-ed3a5a2f3e62"),
				Name = @"LogQueryExecutionTime",
				CreatedInSchemaUId = new Guid("25d4db17-93e6-49e1-82a0-a86aaeb83e03"),
				ModifiedInSchemaUId = new Guid("25d4db17-93e6-49e1-82a0-a86aaeb83e03"),
				CreatedInPackageId = new Guid("6de86b15-f244-46b6-84c4-207bb6ab164c"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"True"
				}
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIU_SysQueryHandleRule_NameIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysQueryHandleRule(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysQueryHandleRule_QueryExecutionRulesEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysQueryHandleRuleSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysQueryHandleRuleSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("25d4db17-93e6-49e1-82a0-a86aaeb83e03"));
		}

		#endregion

	}

	#endregion

	#region Class: SysQueryHandleRule

	/// <summary>
	/// Query handle rule.
	/// </summary>
	public class SysQueryHandleRule : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public SysQueryHandleRule(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysQueryHandleRule";
		}

		public SysQueryHandleRule(SysQueryHandleRule source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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
					(_sysSchema = LookupColumnEntities.GetEntity("SysSchema") as VwEntityObjects);
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

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysQueryHandleRule_QueryExecutionRulesEventsProcess(UserConnection);
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
			return new SysQueryHandleRule(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysQueryHandleRule_QueryExecutionRulesEventsProcess

	/// <exclude/>
	public partial class SysQueryHandleRule_QueryExecutionRulesEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysQueryHandleRule
	{

		public SysQueryHandleRule_QueryExecutionRulesEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysQueryHandleRule_QueryExecutionRulesEventsProcess";
			SchemaUId = new Guid("25d4db17-93e6-49e1-82a0-a86aaeb83e03");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("25d4db17-93e6-49e1-82a0-a86aaeb83e03");
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

	#region Class: SysQueryHandleRule_QueryExecutionRulesEventsProcess

	/// <exclude/>
	public class SysQueryHandleRule_QueryExecutionRulesEventsProcess : SysQueryHandleRule_QueryExecutionRulesEventsProcess<SysQueryHandleRule>
	{

		public SysQueryHandleRule_QueryExecutionRulesEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysQueryHandleRule_QueryExecutionRulesEventsProcess

	public partial class SysQueryHandleRule_QueryExecutionRulesEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysQueryHandleRuleEventsProcess

	/// <exclude/>
	public class SysQueryHandleRuleEventsProcess : SysQueryHandleRule_QueryExecutionRulesEventsProcess
	{

		public SysQueryHandleRuleEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

