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

	#region Class: BaseCopilotIntentSchema

	/// <exclude/>
	[IsVirtual]
	public class BaseCopilotIntentSchema : Terrasoft.Configuration.BaseCodeLookupSchema
	{

		#region Constructors: Public

		public BaseCopilotIntentSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public BaseCopilotIntentSchema(BaseCopilotIntentSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public BaseCopilotIntentSchema(BaseCopilotIntentSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a90230c0-2973-4d2a-b38e-935c9631258d");
			RealUId = new Guid("a90230c0-2973-4d2a-b38e-935c9631258d");
			Name = "BaseCopilotIntent";
			ParentSchemaUId = new Guid("2681062b-df59-4e52-89ed-f9b7dc909ab2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("c23dfaf0-0051-4966-86f8-cbe8197258d0");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
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
			if (Columns.FindByUId(new Guid("7dd0fecd-10eb-32db-d448-4cb8b0442a26")) == null) {
				Columns.Add(CreateTypeColumn());
			}
			if (Columns.FindByUId(new Guid("901a98c4-114b-5bd7-82eb-9f8a7d5d3b8f")) == null) {
				Columns.Add(CreateStatusColumn());
			}
			if (Columns.FindByUId(new Guid("ac7b7c49-f383-bb19-8823-0edd97829284")) == null) {
				Columns.Add(CreatePromptColumn());
			}
			if (Columns.FindByUId(new Guid("54fd4831-ced8-ca5a-b9d8-eed992d60cb7")) == null) {
				Columns.Add(CreatePackageUIdColumn());
			}
			if (Columns.FindByUId(new Guid("faf78084-31a6-d356-abcf-ce2db3dc65fc")) == null) {
				Columns.Add(CreateLlmModelColumn());
			}
			if (Columns.FindByUId(new Guid("0f241976-a4b3-f03d-c1b1-64af1a21d1c0")) == null) {
				Columns.Add(CreateUsePageContextColumn());
			}
			if (Columns.FindByUId(new Guid("3b115db9-cc80-e98f-deab-2e06a7c28c66")) == null) {
				Columns.Add(CreateWorkflowOnlyColumn());
			}
			if (Columns.FindByUId(new Guid("f81b3e0e-d81c-e4e3-063c-8975cf8a1c83")) == null) {
				Columns.Add(CreateUseChatHistoryColumn());
			}
			if (Columns.FindByUId(new Guid("297ab3a0-49ef-e4ee-c331-48a47adf5ce8")) == null) {
				Columns.Add(CreateUseDefaultSystemPromptColumn());
			}
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel;
			column.ModifiedInSchemaUId = new Guid("a90230c0-2973-4d2a-b38e-935c9631258d");
			return column;
		}

		protected virtual EntitySchemaColumn CreateTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("7dd0fecd-10eb-32db-d448-4cb8b0442a26"),
				Name = @"Type",
				ReferenceSchemaUId = new Guid("98aeb3cf-5caf-4a0e-964b-a9c40a043104"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("a90230c0-2973-4d2a-b38e-935c9631258d"),
				ModifiedInSchemaUId = new Guid("a90230c0-2973-4d2a-b38e-935c9631258d"),
				CreatedInPackageId = new Guid("c23dfaf0-0051-4966-86f8-cbe8197258d0"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("901a98c4-114b-5bd7-82eb-9f8a7d5d3b8f"),
				Name = @"Status",
				ReferenceSchemaUId = new Guid("157ceb57-a606-426e-952e-7cadeac5650a"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("a90230c0-2973-4d2a-b38e-935c9631258d"),
				ModifiedInSchemaUId = new Guid("a90230c0-2973-4d2a-b38e-935c9631258d"),
				CreatedInPackageId = new Guid("c23dfaf0-0051-4966-86f8-cbe8197258d0"),
				IsSimpleLookup = true,
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"4670b068-ad03-4364-9350-6cc61efd1b7f"
				}
			};
		}

		protected virtual EntitySchemaColumn CreatePromptColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("RichText")) {
				UId = new Guid("ac7b7c49-f383-bb19-8823-0edd97829284"),
				Name = @"Prompt",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("a90230c0-2973-4d2a-b38e-935c9631258d"),
				ModifiedInSchemaUId = new Guid("a90230c0-2973-4d2a-b38e-935c9631258d"),
				CreatedInPackageId = new Guid("c23dfaf0-0051-4966-86f8-cbe8197258d0")
			};
		}

		protected virtual EntitySchemaColumn CreatePackageUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("54fd4831-ced8-ca5a-b9d8-eed992d60cb7"),
				Name = @"PackageUId",
				CreatedInSchemaUId = new Guid("a90230c0-2973-4d2a-b38e-935c9631258d"),
				ModifiedInSchemaUId = new Guid("a90230c0-2973-4d2a-b38e-935c9631258d"),
				CreatedInPackageId = new Guid("c23dfaf0-0051-4966-86f8-cbe8197258d0")
			};
		}

		protected virtual EntitySchemaColumn CreateLlmModelColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("faf78084-31a6-d356-abcf-ce2db3dc65fc"),
				Name = @"LlmModel",
				ReferenceSchemaUId = new Guid("eeb580f0-c12b-4659-96ab-0bd2ea709941"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("a90230c0-2973-4d2a-b38e-935c9631258d"),
				ModifiedInSchemaUId = new Guid("a90230c0-2973-4d2a-b38e-935c9631258d"),
				CreatedInPackageId = new Guid("800f00c8-04db-4ed1-bc94-0c44b7e5e4f0"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateUsePageContextColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("0f241976-a4b3-f03d-c1b1-64af1a21d1c0"),
				Name = @"UsePageContext",
				CreatedInSchemaUId = new Guid("a90230c0-2973-4d2a-b38e-935c9631258d"),
				ModifiedInSchemaUId = new Guid("a90230c0-2973-4d2a-b38e-935c9631258d"),
				CreatedInPackageId = new Guid("800f00c8-04db-4ed1-bc94-0c44b7e5e4f0"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"True"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateWorkflowOnlyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("3b115db9-cc80-e98f-deab-2e06a7c28c66"),
				Name = @"WorkflowOnly",
				CreatedInSchemaUId = new Guid("a90230c0-2973-4d2a-b38e-935c9631258d"),
				ModifiedInSchemaUId = new Guid("a90230c0-2973-4d2a-b38e-935c9631258d"),
				CreatedInPackageId = new Guid("c23dfaf0-0051-4966-86f8-cbe8197258d0"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"False"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateUseChatHistoryColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("f81b3e0e-d81c-e4e3-063c-8975cf8a1c83"),
				Name = @"UseChatHistory",
				CreatedInSchemaUId = new Guid("a90230c0-2973-4d2a-b38e-935c9631258d"),
				ModifiedInSchemaUId = new Guid("a90230c0-2973-4d2a-b38e-935c9631258d"),
				CreatedInPackageId = new Guid("c23dfaf0-0051-4966-86f8-cbe8197258d0"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"False"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateUseDefaultSystemPromptColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("297ab3a0-49ef-e4ee-c331-48a47adf5ce8"),
				Name = @"UseDefaultSystemPrompt",
				CreatedInSchemaUId = new Guid("a90230c0-2973-4d2a-b38e-935c9631258d"),
				ModifiedInSchemaUId = new Guid("a90230c0-2973-4d2a-b38e-935c9631258d"),
				CreatedInPackageId = new Guid("c23dfaf0-0051-4966-86f8-cbe8197258d0"),
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

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new BaseCopilotIntent(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new BaseCopilotIntent_CrtCopilotEventsProcess(userConnection);
		}

		public override object Clone() {
			return new BaseCopilotIntentSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new BaseCopilotIntentSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a90230c0-2973-4d2a-b38e-935c9631258d"));
		}

		#endregion

	}

	#endregion

	#region Class: BaseCopilotIntent

	/// <summary>
	/// Base Creatio.ai Intent.
	/// </summary>
	public class BaseCopilotIntent : Terrasoft.Configuration.BaseCodeLookup
	{

		#region Constructors: Public

		public BaseCopilotIntent(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BaseCopilotIntent";
		}

		public BaseCopilotIntent(BaseCopilotIntent source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid TypeId {
			get {
				return GetTypedColumnValue<Guid>("TypeId");
			}
			set {
				SetColumnValue("TypeId", value);
				_type = null;
			}
		}

		/// <exclude/>
		public string TypeName {
			get {
				return GetTypedColumnValue<string>("TypeName");
			}
			set {
				SetColumnValue("TypeName", value);
				if (_type != null) {
					_type.Name = value;
				}
			}
		}

		private CopilotIntentType _type;
		/// <summary>
		/// Type.
		/// </summary>
		public CopilotIntentType Type {
			get {
				return _type ??
					(_type = LookupColumnEntities.GetEntity("Type") as CopilotIntentType);
			}
		}

		/// <exclude/>
		public Guid StatusId {
			get {
				return GetTypedColumnValue<Guid>("StatusId");
			}
			set {
				SetColumnValue("StatusId", value);
				_status = null;
			}
		}

		/// <exclude/>
		public string StatusName {
			get {
				return GetTypedColumnValue<string>("StatusName");
			}
			set {
				SetColumnValue("StatusName", value);
				if (_status != null) {
					_status.Name = value;
				}
			}
		}

		private CopilotIntentStatus _status;
		/// <summary>
		/// Status.
		/// </summary>
		public CopilotIntentStatus Status {
			get {
				return _status ??
					(_status = LookupColumnEntities.GetEntity("Status") as CopilotIntentStatus);
			}
		}

		/// <summary>
		/// Prompt.
		/// </summary>
		public string Prompt {
			get {
				return GetTypedColumnValue<string>("Prompt");
			}
			set {
				SetColumnValue("Prompt", value);
			}
		}

		/// <summary>
		/// Package unique identifier.
		/// </summary>
		public Guid PackageUId {
			get {
				return GetTypedColumnValue<Guid>("PackageUId");
			}
			set {
				SetColumnValue("PackageUId", value);
			}
		}

		/// <exclude/>
		public Guid LlmModelId {
			get {
				return GetTypedColumnValue<Guid>("LlmModelId");
			}
			set {
				SetColumnValue("LlmModelId", value);
				_llmModel = null;
			}
		}

		/// <exclude/>
		public string LlmModelName {
			get {
				return GetTypedColumnValue<string>("LlmModelName");
			}
			set {
				SetColumnValue("LlmModelName", value);
				if (_llmModel != null) {
					_llmModel.Name = value;
				}
			}
		}

		private LlmModel _llmModel;
		/// <summary>
		/// LLM Model.
		/// </summary>
		public LlmModel LlmModel {
			get {
				return _llmModel ??
					(_llmModel = LookupColumnEntities.GetEntity("LlmModel") as LlmModel);
			}
		}

		/// <summary>
		/// Use page context.
		/// </summary>
		public bool UsePageContext {
			get {
				return GetTypedColumnValue<bool>("UsePageContext");
			}
			set {
				SetColumnValue("UsePageContext", value);
			}
		}

		/// <summary>
		/// Is intent available only in workflow.
		/// </summary>
		public bool WorkflowOnly {
			get {
				return GetTypedColumnValue<bool>("WorkflowOnly");
			}
			set {
				SetColumnValue("WorkflowOnly", value);
			}
		}

		/// <summary>
		/// Use chat history.
		/// </summary>
		/// <remarks>
		/// Uses chat history when the skill is executed as part of a Workflow agent.
		/// </remarks>
		public bool UseChatHistory {
			get {
				return GetTypedColumnValue<bool>("UseChatHistory");
			}
			set {
				SetColumnValue("UseChatHistory", value);
			}
		}

		/// <summary>
		/// Use default system prompt.
		/// </summary>
		public bool UseDefaultSystemPrompt {
			get {
				return GetTypedColumnValue<bool>("UseDefaultSystemPrompt");
			}
			set {
				SetColumnValue("UseDefaultSystemPrompt", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new BaseCopilotIntent_CrtCopilotEventsProcess(UserConnection);
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
			return new BaseCopilotIntent(this);
		}

		#endregion

	}

	#endregion

	#region Class: BaseCopilotIntent_CrtCopilotEventsProcess

	/// <exclude/>
	public partial class BaseCopilotIntent_CrtCopilotEventsProcess<TEntity> : Terrasoft.Configuration.BaseCodeLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : BaseCopilotIntent
	{

		public BaseCopilotIntent_CrtCopilotEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "BaseCopilotIntent_CrtCopilotEventsProcess";
			SchemaUId = new Guid("a90230c0-2973-4d2a-b38e-935c9631258d");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("a90230c0-2973-4d2a-b38e-935c9631258d");
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

	#region Class: BaseCopilotIntent_CrtCopilotEventsProcess

	/// <exclude/>
	public class BaseCopilotIntent_CrtCopilotEventsProcess : BaseCopilotIntent_CrtCopilotEventsProcess<BaseCopilotIntent>
	{

		public BaseCopilotIntent_CrtCopilotEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: BaseCopilotIntent_CrtCopilotEventsProcess

	public partial class BaseCopilotIntent_CrtCopilotEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: BaseCopilotIntentEventsProcess

	/// <exclude/>
	public class BaseCopilotIntentEventsProcess : BaseCopilotIntent_CrtCopilotEventsProcess
	{

		public BaseCopilotIntentEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

