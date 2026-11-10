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

	#region Class: LlmProviderSchema

	/// <exclude/>
	public class LlmProviderSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public LlmProviderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public LlmProviderSchema(LlmProviderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public LlmProviderSchema(LlmProviderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5aa8333a-659c-47df-adff-95fb4796e263");
			RealUId = new Guid("5aa8333a-659c-47df-adff-95fb4796e263");
			Name = "LlmProvider";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("800f00c8-04db-4ed1-bc94-0c44b7e5e4f0");
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
			if (Columns.FindByUId(new Guid("21b324a6-85db-75a3-1d35-c9c11aaec2ff")) == null) {
				Columns.Add(CreateIsServiceHostedColumn());
			}
			if (Columns.FindByUId(new Guid("ed839393-5a78-c203-1b46-c61a63dacb0a")) == null) {
				Columns.Add(CreateCodeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateIsServiceHostedColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("21b324a6-85db-75a3-1d35-c9c11aaec2ff"),
				Name = @"IsServiceHosted",
				CreatedInSchemaUId = new Guid("5aa8333a-659c-47df-adff-95fb4796e263"),
				ModifiedInSchemaUId = new Guid("5aa8333a-659c-47df-adff-95fb4796e263"),
				CreatedInPackageId = new Guid("800f00c8-04db-4ed1-bc94-0c44b7e5e4f0")
			};
		}

		protected virtual EntitySchemaColumn CreateCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("ed839393-5a78-c203-1b46-c61a63dacb0a"),
				Name = @"Code",
				CreatedInSchemaUId = new Guid("5aa8333a-659c-47df-adff-95fb4796e263"),
				ModifiedInSchemaUId = new Guid("5aa8333a-659c-47df-adff-95fb4796e263"),
				CreatedInPackageId = new Guid("125b7a8a-c96a-4aa1-a9da-b53467f2b91f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new LlmProvider(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new LlmProvider_CrtCopilotEventsProcess(userConnection);
		}

		public override object Clone() {
			return new LlmProviderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new LlmProviderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5aa8333a-659c-47df-adff-95fb4796e263"));
		}

		#endregion

	}

	#endregion

	#region Class: LlmProvider

	/// <summary>
	/// LLM Provider.
	/// </summary>
	/// <remarks>
	/// Provider of LLM model.
	/// </remarks>
	public class LlmProvider : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public LlmProvider(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "LlmProvider";
		}

		public LlmProvider(LlmProvider source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// IsServiceHosted.
		/// </summary>
		public bool IsServiceHosted {
			get {
				return GetTypedColumnValue<bool>("IsServiceHosted");
			}
			set {
				SetColumnValue("IsServiceHosted", value);
			}
		}

		/// <summary>
		/// Code.
		/// </summary>
		/// <remarks>
		/// Provider code.
		/// </remarks>
		public string Code {
			get {
				return GetTypedColumnValue<string>("Code");
			}
			set {
				SetColumnValue("Code", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new LlmProvider_CrtCopilotEventsProcess(UserConnection);
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
			return new LlmProvider(this);
		}

		#endregion

	}

	#endregion

	#region Class: LlmProvider_CrtCopilotEventsProcess

	/// <exclude/>
	public partial class LlmProvider_CrtCopilotEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : LlmProvider
	{

		public LlmProvider_CrtCopilotEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "LlmProvider_CrtCopilotEventsProcess";
			SchemaUId = new Guid("5aa8333a-659c-47df-adff-95fb4796e263");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("5aa8333a-659c-47df-adff-95fb4796e263");
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

	#region Class: LlmProvider_CrtCopilotEventsProcess

	/// <exclude/>
	public class LlmProvider_CrtCopilotEventsProcess : LlmProvider_CrtCopilotEventsProcess<LlmProvider>
	{

		public LlmProvider_CrtCopilotEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: LlmProvider_CrtCopilotEventsProcess

	public partial class LlmProvider_CrtCopilotEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: LlmProviderEventsProcess

	/// <exclude/>
	public class LlmProviderEventsProcess : LlmProvider_CrtCopilotEventsProcess
	{

		public LlmProviderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

