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

	#region Class: AIPlatformEntityEventsSchema

	/// <exclude/>
	public class AIPlatformEntityEventsSchema : Terrasoft.Configuration.BaseCodeLookupSchema
	{

		#region Constructors: Public

		public AIPlatformEntityEventsSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public AIPlatformEntityEventsSchema(AIPlatformEntityEventsSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public AIPlatformEntityEventsSchema(AIPlatformEntityEventsSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("59ce3e27-9672-4b0f-83ac-887f407da05b");
			RealUId = new Guid("59ce3e27-9672-4b0f-83ac-887f407da05b");
			Name = "AIPlatformEntityEvents";
			ParentSchemaUId = new Guid("2681062b-df59-4e52-89ed-f9b7dc909ab2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("1f312fb9-1e4e-4b50-ad53-58709ec834ae");
			IsDBView = false;
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

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("2c4cd616-dd4d-3e17-1954-d9a5b93407cc")) == null) {
				Columns.Add(CreateEntitySchemaFiltersColumn());
			}
			if (Columns.FindByUId(new Guid("696eefba-37a7-be42-aa39-ca80dbafabd7")) == null) {
				Columns.Add(CreateAIPlatformTriggerCodeColumn());
			}
			if (Columns.FindByUId(new Guid("8a324ef8-6cb4-877b-13f0-262175171a12")) == null) {
				Columns.Add(CreateEntitySchemaColumn());
			}
			if (Columns.FindByUId(new Guid("0be09732-c97c-d377-adc3-ac4d26d8e0b5")) == null) {
				Columns.Add(CreateEntitySchemaChangeTypeColumn());
			}
			if (Columns.FindByUId(new Guid("a14943be-128c-cd1d-7c1d-4b2e23d3b62f")) == null) {
				Columns.Add(CreateChangedColumnsColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateEntitySchemaFiltersColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("2c4cd616-dd4d-3e17-1954-d9a5b93407cc"),
				Name = @"EntitySchemaFilters",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("59ce3e27-9672-4b0f-83ac-887f407da05b"),
				ModifiedInSchemaUId = new Guid("59ce3e27-9672-4b0f-83ac-887f407da05b"),
				CreatedInPackageId = new Guid("1f312fb9-1e4e-4b50-ad53-58709ec834ae")
			};
		}

		protected virtual EntitySchemaColumn CreateAIPlatformTriggerCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("696eefba-37a7-be42-aa39-ca80dbafabd7"),
				Name = @"AIPlatformTriggerCode",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("59ce3e27-9672-4b0f-83ac-887f407da05b"),
				ModifiedInSchemaUId = new Guid("59ce3e27-9672-4b0f-83ac-887f407da05b"),
				CreatedInPackageId = new Guid("6c6aab54-eafd-41da-91c1-7d113a2689fb"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"creatio_entity_change"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateEntitySchemaColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("8a324ef8-6cb4-877b-13f0-262175171a12"),
				Name = @"EntitySchema",
				ReferenceSchemaUId = new Guid("c82db13a-7f77-4085-b3ef-91c5420fd417"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsWeakReference = true,
				CreatedInSchemaUId = new Guid("59ce3e27-9672-4b0f-83ac-887f407da05b"),
				ModifiedInSchemaUId = new Guid("59ce3e27-9672-4b0f-83ac-887f407da05b"),
				CreatedInPackageId = new Guid("5f01b6ef-194a-4415-95d7-b0d5e4649d18"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateEntitySchemaChangeTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("0be09732-c97c-d377-adc3-ac4d26d8e0b5"),
				Name = @"EntitySchemaChangeType",
				ReferenceSchemaUId = new Guid("ad89be25-db7b-4d61-a4d4-672d29a9be7b"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("59ce3e27-9672-4b0f-83ac-887f407da05b"),
				ModifiedInSchemaUId = new Guid("59ce3e27-9672-4b0f-83ac-887f407da05b"),
				CreatedInPackageId = new Guid("5f01b6ef-194a-4415-95d7-b0d5e4649d18"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateChangedColumnsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("a14943be-128c-cd1d-7c1d-4b2e23d3b62f"),
				Name = @"ChangedColumns",
				CreatedInSchemaUId = new Guid("59ce3e27-9672-4b0f-83ac-887f407da05b"),
				ModifiedInSchemaUId = new Guid("59ce3e27-9672-4b0f-83ac-887f407da05b"),
				CreatedInPackageId = new Guid("b2d41f8a-feaf-452d-a4a3-fcca32c5cc8a")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new AIPlatformEntityEvents(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new AIPlatformEntityEvents_CrtAIAgenticBridgeAppEventsProcess(userConnection);
		}

		public override object Clone() {
			return new AIPlatformEntityEventsSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new AIPlatformEntityEventsSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("59ce3e27-9672-4b0f-83ac-887f407da05b"));
		}

		#endregion

	}

	#endregion

	#region Class: AIPlatformEntityEvents

	/// <summary>
	/// Creatio.ai platform entity events.
	/// </summary>
	public class AIPlatformEntityEvents : Terrasoft.Configuration.BaseCodeLookup
	{

		#region Constructors: Public

		public AIPlatformEntityEvents(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "AIPlatformEntityEvents";
		}

		public AIPlatformEntityEvents(AIPlatformEntityEvents source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Object filter.
		/// </summary>
		public string EntitySchemaFilters {
			get {
				return GetTypedColumnValue<string>("EntitySchemaFilters");
			}
			set {
				SetColumnValue("EntitySchemaFilters", value);
			}
		}

		/// <summary>
		/// AI Platform Trigger Code.
		/// </summary>
		public string AIPlatformTriggerCode {
			get {
				return GetTypedColumnValue<string>("AIPlatformTriggerCode");
			}
			set {
				SetColumnValue("AIPlatformTriggerCode", value);
			}
		}

		/// <exclude/>
		public Guid EntitySchemaId {
			get {
				return GetTypedColumnValue<Guid>("EntitySchemaId");
			}
			set {
				SetColumnValue("EntitySchemaId", value);
				_entitySchema = null;
			}
		}

		/// <exclude/>
		public string EntitySchemaTitle {
			get {
				return GetTypedColumnValue<string>("EntitySchemaTitle");
			}
			set {
				SetColumnValue("EntitySchemaTitle", value);
				if (_entitySchema != null) {
					_entitySchema.Title = value;
				}
			}
		}

		private VwEntityObjects _entitySchema;
		/// <summary>
		/// Object.
		/// </summary>
		public VwEntityObjects EntitySchema {
			get {
				return _entitySchema ??
					(_entitySchema = LookupColumnEntities.GetEntity("EntitySchema") as VwEntityObjects);
			}
		}

		/// <exclude/>
		public Guid EntitySchemaChangeTypeId {
			get {
				return GetTypedColumnValue<Guid>("EntitySchemaChangeTypeId");
			}
			set {
				SetColumnValue("EntitySchemaChangeTypeId", value);
				_entitySchemaChangeType = null;
			}
		}

		/// <exclude/>
		public string EntitySchemaChangeTypeName {
			get {
				return GetTypedColumnValue<string>("EntitySchemaChangeTypeName");
			}
			set {
				SetColumnValue("EntitySchemaChangeTypeName", value);
				if (_entitySchemaChangeType != null) {
					_entitySchemaChangeType.Name = value;
				}
			}
		}

		private SysEntityChangeType _entitySchemaChangeType;
		/// <summary>
		/// Event type.
		/// </summary>
		public SysEntityChangeType EntitySchemaChangeType {
			get {
				return _entitySchemaChangeType ??
					(_entitySchemaChangeType = LookupColumnEntities.GetEntity("EntitySchemaChangeType") as SysEntityChangeType);
			}
		}

		/// <summary>
		/// Event start conditions by changed columns.
		/// </summary>
		public string ChangedColumns {
			get {
				return GetTypedColumnValue<string>("ChangedColumns");
			}
			set {
				SetColumnValue("ChangedColumns", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new AIPlatformEntityEvents_CrtAIAgenticBridgeAppEventsProcess(UserConnection);
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
			return new AIPlatformEntityEvents(this);
		}

		#endregion

	}

	#endregion

	#region Class: AIPlatformEntityEvents_CrtAIAgenticBridgeAppEventsProcess

	/// <exclude/>
	public partial class AIPlatformEntityEvents_CrtAIAgenticBridgeAppEventsProcess<TEntity> : Terrasoft.Configuration.BaseCodeLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : AIPlatformEntityEvents
	{

		public AIPlatformEntityEvents_CrtAIAgenticBridgeAppEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "AIPlatformEntityEvents_CrtAIAgenticBridgeAppEventsProcess";
			SchemaUId = new Guid("59ce3e27-9672-4b0f-83ac-887f407da05b");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("59ce3e27-9672-4b0f-83ac-887f407da05b");
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

	#region Class: AIPlatformEntityEvents_CrtAIAgenticBridgeAppEventsProcess

	/// <exclude/>
	public class AIPlatformEntityEvents_CrtAIAgenticBridgeAppEventsProcess : AIPlatformEntityEvents_CrtAIAgenticBridgeAppEventsProcess<AIPlatformEntityEvents>
	{

		public AIPlatformEntityEvents_CrtAIAgenticBridgeAppEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: AIPlatformEntityEvents_CrtAIAgenticBridgeAppEventsProcess

	public partial class AIPlatformEntityEvents_CrtAIAgenticBridgeAppEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: AIPlatformEntityEventsEventsProcess

	/// <exclude/>
	public class AIPlatformEntityEventsEventsProcess : AIPlatformEntityEvents_CrtAIAgenticBridgeAppEventsProcess
	{

		public AIPlatformEntityEventsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

