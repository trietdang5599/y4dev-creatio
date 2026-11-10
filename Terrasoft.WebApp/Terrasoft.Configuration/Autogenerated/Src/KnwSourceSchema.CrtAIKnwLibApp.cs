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

	#region Class: KnwSourceSchema

	/// <exclude/>
	public class KnwSourceSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public KnwSourceSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public KnwSourceSchema(KnwSourceSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public KnwSourceSchema(KnwSourceSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("6ec4827f-1e9a-4077-8c37-b7e97686fb92");
			RealUId = new Guid("6ec4827f-1e9a-4077-8c37-b7e97686fb92");
			Name = "KnwSource";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("2c4cab0f-1fe9-47b5-95fa-4053b7ea1637");
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

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateNameColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("1a9797d5-d1ea-855d-f6df-e77b7e5202a7")) == null) {
				Columns.Add(CreateKnwProviderConnectionColumn());
			}
			if (Columns.FindByUId(new Guid("393dd392-815f-525c-60da-aced630a5e2f")) == null) {
				Columns.Add(CreateKnwProviderColumn());
			}
			if (Columns.FindByUId(new Guid("fe8b64a0-95b2-6904-74c7-0594c34d466e")) == null) {
				Columns.Add(CreateDescriptionColumn());
			}
			if (Columns.FindByUId(new Guid("b4464dbf-3f79-3373-b458-2a323a8e2705")) == null) {
				Columns.Add(CreateKnwSourceStatusColumn());
			}
			if (Columns.FindByUId(new Guid("21401a40-bf07-93b4-6807-0c6da6ab9c94")) == null) {
				Columns.Add(CreateLastIndexedOnColumn());
			}
			if (Columns.FindByUId(new Guid("01e4df17-63fc-fa15-0c12-8ca3bb7085be")) == null) {
				Columns.Add(CreateKnwSourceConfigColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateKnwProviderConnectionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("1a9797d5-d1ea-855d-f6df-e77b7e5202a7"),
				Name = @"KnwProviderConnection",
				ReferenceSchemaUId = new Guid("b081050d-8817-4d00-87c5-9c26c5c4fff6"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("6ec4827f-1e9a-4077-8c37-b7e97686fb92"),
				ModifiedInSchemaUId = new Guid("6ec4827f-1e9a-4077-8c37-b7e97686fb92"),
				CreatedInPackageId = new Guid("2c4cab0f-1fe9-47b5-95fa-4053b7ea1637"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateKnwProviderColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("393dd392-815f-525c-60da-aced630a5e2f"),
				Name = @"KnwProvider",
				ReferenceSchemaUId = new Guid("51aed477-551c-4521-9a27-e296dea692c4"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("6ec4827f-1e9a-4077-8c37-b7e97686fb92"),
				ModifiedInSchemaUId = new Guid("6ec4827f-1e9a-4077-8c37-b7e97686fb92"),
				CreatedInPackageId = new Guid("2c4cab0f-1fe9-47b5-95fa-4053b7ea1637"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateDescriptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("fe8b64a0-95b2-6904-74c7-0594c34d466e"),
				Name = @"Description",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("6ec4827f-1e9a-4077-8c37-b7e97686fb92"),
				ModifiedInSchemaUId = new Guid("6ec4827f-1e9a-4077-8c37-b7e97686fb92"),
				CreatedInPackageId = new Guid("2c4cab0f-1fe9-47b5-95fa-4053b7ea1637")
			};
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("9bb3da1e-e9ab-4f60-33d6-fc9feb4ecff7"),
				Name = @"Name",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("6ec4827f-1e9a-4077-8c37-b7e97686fb92"),
				ModifiedInSchemaUId = new Guid("6ec4827f-1e9a-4077-8c37-b7e97686fb92"),
				CreatedInPackageId = new Guid("2c4cab0f-1fe9-47b5-95fa-4053b7ea1637")
			};
		}

		protected virtual EntitySchemaColumn CreateKnwSourceStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("b4464dbf-3f79-3373-b458-2a323a8e2705"),
				Name = @"KnwSourceStatus",
				ReferenceSchemaUId = new Guid("ec6f6f58-f2c6-4659-83aa-8fa2ba04c433"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("6ec4827f-1e9a-4077-8c37-b7e97686fb92"),
				ModifiedInSchemaUId = new Guid("6ec4827f-1e9a-4077-8c37-b7e97686fb92"),
				CreatedInPackageId = new Guid("2c4cab0f-1fe9-47b5-95fa-4053b7ea1637"),
				IsSimpleLookup = true,
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"31d0607f-8bd9-4bab-9549-41274f5ef3f0"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateLastIndexedOnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("21401a40-bf07-93b4-6807-0c6da6ab9c94"),
				Name = @"LastIndexedOn",
				CreatedInSchemaUId = new Guid("6ec4827f-1e9a-4077-8c37-b7e97686fb92"),
				ModifiedInSchemaUId = new Guid("6ec4827f-1e9a-4077-8c37-b7e97686fb92"),
				CreatedInPackageId = new Guid("fc5a15eb-1c52-4ea9-828b-8fee971a8bbd")
			};
		}

		protected virtual EntitySchemaColumn CreateKnwSourceConfigColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("01e4df17-63fc-fa15-0c12-8ca3bb7085be"),
				Name = @"KnwSourceConfig",
				UsageType = EntitySchemaColumnUsageType.Advanced,
				CreatedInSchemaUId = new Guid("6ec4827f-1e9a-4077-8c37-b7e97686fb92"),
				ModifiedInSchemaUId = new Guid("6ec4827f-1e9a-4077-8c37-b7e97686fb92"),
				CreatedInPackageId = new Guid("24c8e5df-c744-4935-aba4-7d94e7d27608")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new KnwSource(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new KnwSource_CrtAIKnwLibAppEventsProcess(userConnection);
		}

		public override object Clone() {
			return new KnwSourceSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new KnwSourceSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6ec4827f-1e9a-4077-8c37-b7e97686fb92"));
		}

		#endregion

	}

	#endregion

	#region Class: KnwSource

	/// <summary>
	/// Knowledge source.
	/// </summary>
	public class KnwSource : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public KnwSource(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "KnwSource";
		}

		public KnwSource(KnwSource source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid KnwProviderConnectionId {
			get {
				return GetTypedColumnValue<Guid>("KnwProviderConnectionId");
			}
			set {
				SetColumnValue("KnwProviderConnectionId", value);
				_knwProviderConnection = null;
			}
		}

		/// <exclude/>
		public string KnwProviderConnectionName {
			get {
				return GetTypedColumnValue<string>("KnwProviderConnectionName");
			}
			set {
				SetColumnValue("KnwProviderConnectionName", value);
				if (_knwProviderConnection != null) {
					_knwProviderConnection.Name = value;
				}
			}
		}

		private KnwProviderConnection _knwProviderConnection;
		/// <summary>
		/// Сonnection.
		/// </summary>
		public KnwProviderConnection KnwProviderConnection {
			get {
				return _knwProviderConnection ??
					(_knwProviderConnection = LookupColumnEntities.GetEntity("KnwProviderConnection") as KnwProviderConnection);
			}
		}

		/// <exclude/>
		public Guid KnwProviderId {
			get {
				return GetTypedColumnValue<Guid>("KnwProviderId");
			}
			set {
				SetColumnValue("KnwProviderId", value);
				_knwProvider = null;
			}
		}

		/// <exclude/>
		public string KnwProviderName {
			get {
				return GetTypedColumnValue<string>("KnwProviderName");
			}
			set {
				SetColumnValue("KnwProviderName", value);
				if (_knwProvider != null) {
					_knwProvider.Name = value;
				}
			}
		}

		private KnwProvider _knwProvider;
		/// <summary>
		/// Provider.
		/// </summary>
		public KnwProvider KnwProvider {
			get {
				return _knwProvider ??
					(_knwProvider = LookupColumnEntities.GetEntity("KnwProvider") as KnwProvider);
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

		/// <exclude/>
		public Guid KnwSourceStatusId {
			get {
				return GetTypedColumnValue<Guid>("KnwSourceStatusId");
			}
			set {
				SetColumnValue("KnwSourceStatusId", value);
				_knwSourceStatus = null;
			}
		}

		/// <exclude/>
		public string KnwSourceStatusName {
			get {
				return GetTypedColumnValue<string>("KnwSourceStatusName");
			}
			set {
				SetColumnValue("KnwSourceStatusName", value);
				if (_knwSourceStatus != null) {
					_knwSourceStatus.Name = value;
				}
			}
		}

		private KnwSourceStatus _knwSourceStatus;
		/// <summary>
		/// Status.
		/// </summary>
		public KnwSourceStatus KnwSourceStatus {
			get {
				return _knwSourceStatus ??
					(_knwSourceStatus = LookupColumnEntities.GetEntity("KnwSourceStatus") as KnwSourceStatus);
			}
		}

		/// <summary>
		/// Last Indexed On.
		/// </summary>
		public DateTime LastIndexedOn {
			get {
				return GetTypedColumnValue<DateTime>("LastIndexedOn");
			}
			set {
				SetColumnValue("LastIndexedOn", value);
			}
		}

		/// <summary>
		/// Config.
		/// </summary>
		public string KnwSourceConfig {
			get {
				return GetTypedColumnValue<string>("KnwSourceConfig");
			}
			set {
				SetColumnValue("KnwSourceConfig", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new KnwSource_CrtAIKnwLibAppEventsProcess(UserConnection);
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
			return new KnwSource(this);
		}

		#endregion

	}

	#endregion

	#region Class: KnwSource_CrtAIKnwLibAppEventsProcess

	/// <exclude/>
	public partial class KnwSource_CrtAIKnwLibAppEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : KnwSource
	{

		public KnwSource_CrtAIKnwLibAppEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "KnwSource_CrtAIKnwLibAppEventsProcess";
			SchemaUId = new Guid("6ec4827f-1e9a-4077-8c37-b7e97686fb92");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("6ec4827f-1e9a-4077-8c37-b7e97686fb92");
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

	#region Class: KnwSource_CrtAIKnwLibAppEventsProcess

	/// <exclude/>
	public class KnwSource_CrtAIKnwLibAppEventsProcess : KnwSource_CrtAIKnwLibAppEventsProcess<KnwSource>
	{

		public KnwSource_CrtAIKnwLibAppEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: KnwSource_CrtAIKnwLibAppEventsProcess

	public partial class KnwSource_CrtAIKnwLibAppEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: KnwSourceEventsProcess

	/// <exclude/>
	public class KnwSourceEventsProcess : KnwSource_CrtAIKnwLibAppEventsProcess
	{

		public KnwSourceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

