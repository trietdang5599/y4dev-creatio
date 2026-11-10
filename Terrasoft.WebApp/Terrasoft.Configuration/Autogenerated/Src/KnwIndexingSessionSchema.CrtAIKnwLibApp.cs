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

	#region Class: KnwIndexingSessionSchema

	/// <exclude/>
	public class KnwIndexingSessionSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public KnwIndexingSessionSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public KnwIndexingSessionSchema(KnwIndexingSessionSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public KnwIndexingSessionSchema(KnwIndexingSessionSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("757da3bf-4222-49b6-b0da-5f8892134113");
			RealUId = new Guid("757da3bf-4222-49b6-b0da-5f8892134113");
			Name = "KnwIndexingSession";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("fc5a15eb-1c52-4ea9-828b-8fee971a8bbd");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = false;
			UseLiveEditing = true;
			Paging.IsPageable = true;
			Filtering.IsFilterable = true;
			Sorting.IsSortable = true;
			Write.IsInsertable = true;
			Write.IsUpdatable = true;
			Write.IsDeletable = true;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("f704a5b7-a692-d690-6734-a115f9f280de")) == null) {
				Columns.Add(CreateKnwIndexingStatusColumn());
			}
			if (Columns.FindByUId(new Guid("2b08478e-9655-1262-8047-e9ec4381399c")) == null) {
				Columns.Add(CreateCompletedOnColumn());
			}
			if (Columns.FindByUId(new Guid("96d50840-fb3d-fd9f-3d69-f409dedd0d36")) == null) {
				Columns.Add(CreateTransferredOnColumn());
			}
			if (Columns.FindByUId(new Guid("1a5734c5-bfb6-641b-28f0-066fe11fa8d5")) == null) {
				Columns.Add(CreateStartedOnColumn());
			}
			if (Columns.FindByUId(new Guid("d4756992-c955-53c6-3bb9-57d41fac19d5")) == null) {
				Columns.Add(CreateKnwSourceColumn());
			}
			if (Columns.FindByUId(new Guid("aff245b4-c558-ab63-2deb-f3087966c7c4")) == null) {
				Columns.Add(CreateIndexIdColumn());
			}
			if (Columns.FindByUId(new Guid("b97a0a50-3cce-badb-9294-48995e4677d0")) == null) {
				Columns.Add(CreateSessionIdColumn());
			}
			if (Columns.FindByUId(new Guid("7288bb6f-f7a8-6cb0-1147-8500f86aa4ae")) == null) {
				Columns.Add(CreateIsCompletedColumn());
			}
			if (Columns.FindByUId(new Guid("637beec0-6916-8245-c251-1ffe08c519e4")) == null) {
				Columns.Add(CreateDetailsColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateKnwIndexingStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("f704a5b7-a692-d690-6734-a115f9f280de"),
				Name = @"KnwIndexingStatus",
				ReferenceSchemaUId = new Guid("73b16b9a-3c64-4ee9-95b1-34ed36b5b453"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("757da3bf-4222-49b6-b0da-5f8892134113"),
				ModifiedInSchemaUId = new Guid("757da3bf-4222-49b6-b0da-5f8892134113"),
				CreatedInPackageId = new Guid("fc5a15eb-1c52-4ea9-828b-8fee971a8bbd"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateCompletedOnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("2b08478e-9655-1262-8047-e9ec4381399c"),
				Name = @"CompletedOn",
				CreatedInSchemaUId = new Guid("757da3bf-4222-49b6-b0da-5f8892134113"),
				ModifiedInSchemaUId = new Guid("757da3bf-4222-49b6-b0da-5f8892134113"),
				CreatedInPackageId = new Guid("fc5a15eb-1c52-4ea9-828b-8fee971a8bbd")
			};
		}

		protected virtual EntitySchemaColumn CreateTransferredOnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("96d50840-fb3d-fd9f-3d69-f409dedd0d36"),
				Name = @"TransferredOn",
				CreatedInSchemaUId = new Guid("757da3bf-4222-49b6-b0da-5f8892134113"),
				ModifiedInSchemaUId = new Guid("757da3bf-4222-49b6-b0da-5f8892134113"),
				CreatedInPackageId = new Guid("fc5a15eb-1c52-4ea9-828b-8fee971a8bbd")
			};
		}

		protected virtual EntitySchemaColumn CreateStartedOnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("1a5734c5-bfb6-641b-28f0-066fe11fa8d5"),
				Name = @"StartedOn",
				CreatedInSchemaUId = new Guid("757da3bf-4222-49b6-b0da-5f8892134113"),
				ModifiedInSchemaUId = new Guid("757da3bf-4222-49b6-b0da-5f8892134113"),
				CreatedInPackageId = new Guid("fc5a15eb-1c52-4ea9-828b-8fee971a8bbd")
			};
		}

		protected virtual EntitySchemaColumn CreateKnwSourceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("d4756992-c955-53c6-3bb9-57d41fac19d5"),
				Name = @"KnwSource",
				ReferenceSchemaUId = new Guid("6ec4827f-1e9a-4077-8c37-b7e97686fb92"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("757da3bf-4222-49b6-b0da-5f8892134113"),
				ModifiedInSchemaUId = new Guid("757da3bf-4222-49b6-b0da-5f8892134113"),
				CreatedInPackageId = new Guid("fc5a15eb-1c52-4ea9-828b-8fee971a8bbd"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateIndexIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("aff245b4-c558-ab63-2deb-f3087966c7c4"),
				Name = @"IndexId",
				CreatedInSchemaUId = new Guid("757da3bf-4222-49b6-b0da-5f8892134113"),
				ModifiedInSchemaUId = new Guid("757da3bf-4222-49b6-b0da-5f8892134113"),
				CreatedInPackageId = new Guid("fc5a15eb-1c52-4ea9-828b-8fee971a8bbd")
			};
		}

		protected virtual EntitySchemaColumn CreateSessionIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("b97a0a50-3cce-badb-9294-48995e4677d0"),
				Name = @"SessionId",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				UsageType = EntitySchemaColumnUsageType.Advanced,
				CreatedInSchemaUId = new Guid("757da3bf-4222-49b6-b0da-5f8892134113"),
				ModifiedInSchemaUId = new Guid("757da3bf-4222-49b6-b0da-5f8892134113"),
				CreatedInPackageId = new Guid("fc5a15eb-1c52-4ea9-828b-8fee971a8bbd")
			};
		}

		protected virtual EntitySchemaColumn CreateIsCompletedColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("7288bb6f-f7a8-6cb0-1147-8500f86aa4ae"),
				Name = @"IsCompleted",
				CreatedInSchemaUId = new Guid("757da3bf-4222-49b6-b0da-5f8892134113"),
				ModifiedInSchemaUId = new Guid("757da3bf-4222-49b6-b0da-5f8892134113"),
				CreatedInPackageId = new Guid("fc5a15eb-1c52-4ea9-828b-8fee971a8bbd")
			};
		}

		protected virtual EntitySchemaColumn CreateDetailsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("637beec0-6916-8245-c251-1ffe08c519e4"),
				Name = @"Details",
				CreatedInSchemaUId = new Guid("757da3bf-4222-49b6-b0da-5f8892134113"),
				ModifiedInSchemaUId = new Guid("757da3bf-4222-49b6-b0da-5f8892134113"),
				CreatedInPackageId = new Guid("7fde53f3-8dfb-49d2-af8d-0767dd13dc3b")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new KnwIndexingSession(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new KnwIndexingSession_CrtAIKnwLibAppEventsProcess(userConnection);
		}

		public override object Clone() {
			return new KnwIndexingSessionSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new KnwIndexingSessionSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("757da3bf-4222-49b6-b0da-5f8892134113"));
		}

		#endregion

	}

	#endregion

	#region Class: KnwIndexingSession

	/// <summary>
	/// Knowledge Source Indexing Session.
	/// </summary>
	public class KnwIndexingSession : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public KnwIndexingSession(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "KnwIndexingSession";
		}

		public KnwIndexingSession(KnwIndexingSession source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid KnwIndexingStatusId {
			get {
				return GetTypedColumnValue<Guid>("KnwIndexingStatusId");
			}
			set {
				SetColumnValue("KnwIndexingStatusId", value);
				_knwIndexingStatus = null;
			}
		}

		/// <exclude/>
		public string KnwIndexingStatusName {
			get {
				return GetTypedColumnValue<string>("KnwIndexingStatusName");
			}
			set {
				SetColumnValue("KnwIndexingStatusName", value);
				if (_knwIndexingStatus != null) {
					_knwIndexingStatus.Name = value;
				}
			}
		}

		private KnwIndexingStatus _knwIndexingStatus;
		/// <summary>
		/// Status.
		/// </summary>
		public KnwIndexingStatus KnwIndexingStatus {
			get {
				return _knwIndexingStatus ??
					(_knwIndexingStatus = LookupColumnEntities.GetEntity("KnwIndexingStatus") as KnwIndexingStatus);
			}
		}

		/// <summary>
		/// Completed on.
		/// </summary>
		public DateTime CompletedOn {
			get {
				return GetTypedColumnValue<DateTime>("CompletedOn");
			}
			set {
				SetColumnValue("CompletedOn", value);
			}
		}

		/// <summary>
		/// Transferred on.
		/// </summary>
		public DateTime TransferredOn {
			get {
				return GetTypedColumnValue<DateTime>("TransferredOn");
			}
			set {
				SetColumnValue("TransferredOn", value);
			}
		}

		/// <summary>
		/// Started on.
		/// </summary>
		public DateTime StartedOn {
			get {
				return GetTypedColumnValue<DateTime>("StartedOn");
			}
			set {
				SetColumnValue("StartedOn", value);
			}
		}

		/// <exclude/>
		public Guid KnwSourceId {
			get {
				return GetTypedColumnValue<Guid>("KnwSourceId");
			}
			set {
				SetColumnValue("KnwSourceId", value);
				_knwSource = null;
			}
		}

		/// <exclude/>
		public string KnwSourceName {
			get {
				return GetTypedColumnValue<string>("KnwSourceName");
			}
			set {
				SetColumnValue("KnwSourceName", value);
				if (_knwSource != null) {
					_knwSource.Name = value;
				}
			}
		}

		private KnwSource _knwSource;
		/// <summary>
		/// Knowledge Source.
		/// </summary>
		public KnwSource KnwSource {
			get {
				return _knwSource ??
					(_knwSource = LookupColumnEntities.GetEntity("KnwSource") as KnwSource);
			}
		}

		/// <summary>
		/// Index identifier.
		/// </summary>
		/// <remarks>
		/// Index on microservice side.
		/// </remarks>
		public string IndexId {
			get {
				return GetTypedColumnValue<string>("IndexId");
			}
			set {
				SetColumnValue("IndexId", value);
			}
		}

		/// <summary>
		/// Session Identifier.
		/// </summary>
		public string SessionId {
			get {
				return GetTypedColumnValue<string>("SessionId");
			}
			set {
				SetColumnValue("SessionId", value);
			}
		}

		/// <summary>
		/// Completed.
		/// </summary>
		public bool IsCompleted {
			get {
				return GetTypedColumnValue<bool>("IsCompleted");
			}
			set {
				SetColumnValue("IsCompleted", value);
			}
		}

		/// <summary>
		/// Details.
		/// </summary>
		public string Details {
			get {
				return GetTypedColumnValue<string>("Details");
			}
			set {
				SetColumnValue("Details", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new KnwIndexingSession_CrtAIKnwLibAppEventsProcess(UserConnection);
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
			return new KnwIndexingSession(this);
		}

		#endregion

	}

	#endregion

	#region Class: KnwIndexingSession_CrtAIKnwLibAppEventsProcess

	/// <exclude/>
	public partial class KnwIndexingSession_CrtAIKnwLibAppEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : KnwIndexingSession
	{

		public KnwIndexingSession_CrtAIKnwLibAppEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "KnwIndexingSession_CrtAIKnwLibAppEventsProcess";
			SchemaUId = new Guid("757da3bf-4222-49b6-b0da-5f8892134113");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("757da3bf-4222-49b6-b0da-5f8892134113");
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

	#region Class: KnwIndexingSession_CrtAIKnwLibAppEventsProcess

	/// <exclude/>
	public class KnwIndexingSession_CrtAIKnwLibAppEventsProcess : KnwIndexingSession_CrtAIKnwLibAppEventsProcess<KnwIndexingSession>
	{

		public KnwIndexingSession_CrtAIKnwLibAppEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: KnwIndexingSession_CrtAIKnwLibAppEventsProcess

	public partial class KnwIndexingSession_CrtAIKnwLibAppEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: KnwIndexingSessionEventsProcess

	/// <exclude/>
	public class KnwIndexingSessionEventsProcess : KnwIndexingSession_CrtAIKnwLibAppEventsProcess
	{

		public KnwIndexingSessionEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

