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

	#region Class: CustomLlmModelSchema

	/// <exclude/>
	[IsVirtual]
	public class CustomLlmModelSchema : Terrasoft.Configuration.LlmModelSchema
	{

		#region Constructors: Public

		public CustomLlmModelSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CustomLlmModelSchema(CustomLlmModelSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CustomLlmModelSchema(CustomLlmModelSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("072f6633-a517-4cdf-ad94-b108708483dd");
			RealUId = new Guid("072f6633-a517-4cdf-ad94-b108708483dd");
			Name = "CustomLlmModel";
			ParentSchemaUId = new Guid("eeb580f0-c12b-4659-96ab-0bd2ea709941");
			ExtendParent = false;
			CreatedInPackageId = new Guid("11a936bf-8ee0-4505-a8db-e67a2dd080a5");
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
			if (Columns.FindByUId(new Guid("bba1ce8a-6dac-38a5-fc13-c5743a85ad98")) == null) {
				Columns.Add(CreateJsonConfigColumn());
			}
		}

		protected override EntitySchemaColumn CreateCodeColumn() {
			EntitySchemaColumn column = base.CreateCodeColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.Sequence,
				ValueSource = @""
			};
			column.ModifiedInSchemaUId = new Guid("072f6633-a517-4cdf-ad94-b108708483dd");
			return column;
		}

		protected virtual EntitySchemaColumn CreateJsonConfigColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("bba1ce8a-6dac-38a5-fc13-c5743a85ad98"),
				Name = @"JsonConfig",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("072f6633-a517-4cdf-ad94-b108708483dd"),
				ModifiedInSchemaUId = new Guid("072f6633-a517-4cdf-ad94-b108708483dd"),
				CreatedInPackageId = new Guid("11a936bf-8ee0-4505-a8db-e67a2dd080a5"),
				IsSensitiveData = true
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new CustomLlmModel(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CustomLlmModel_CrtCopilotEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CustomLlmModelSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CustomLlmModelSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("072f6633-a517-4cdf-ad94-b108708483dd"));
		}

		#endregion

	}

	#endregion

	#region Class: CustomLlmModel

	/// <summary>
	/// CustomLlmModel.
	/// </summary>
	/// <remarks>
	/// LLM model configuration.
	/// </remarks>
	public class CustomLlmModel : Terrasoft.Configuration.LlmModel
	{

		#region Constructors: Public

		public CustomLlmModel(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CustomLlmModel";
		}

		public CustomLlmModel(CustomLlmModel source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Model configuration (JSON).
		/// </summary>
		public string JsonConfig {
			get {
				return GetTypedColumnValue<string>("JsonConfig");
			}
			set {
				SetColumnValue("JsonConfig", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CustomLlmModel_CrtCopilotEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("CustomLlmModelDeleted", e);
			Deleting += (s, e) => ThrowEvent("CustomLlmModelDeleting", e);
			Inserted += (s, e) => ThrowEvent("CustomLlmModelInserted", e);
			Inserting += (s, e) => ThrowEvent("CustomLlmModelInserting", e);
			Saved += (s, e) => ThrowEvent("CustomLlmModelSaved", e);
			Saving += (s, e) => ThrowEvent("CustomLlmModelSaving", e);
			Validating += (s, e) => ThrowEvent("CustomLlmModelValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new CustomLlmModel(this);
		}

		#endregion

	}

	#endregion

	#region Class: CustomLlmModel_CrtCopilotEventsProcess

	/// <exclude/>
	public partial class CustomLlmModel_CrtCopilotEventsProcess<TEntity> : Terrasoft.Configuration.LlmModel_CrtCopilotEventsProcess<TEntity> where TEntity : CustomLlmModel
	{

		public CustomLlmModel_CrtCopilotEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CustomLlmModel_CrtCopilotEventsProcess";
			SchemaUId = new Guid("072f6633-a517-4cdf-ad94-b108708483dd");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("072f6633-a517-4cdf-ad94-b108708483dd");
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

	#region Class: CustomLlmModel_CrtCopilotEventsProcess

	/// <exclude/>
	public class CustomLlmModel_CrtCopilotEventsProcess : CustomLlmModel_CrtCopilotEventsProcess<CustomLlmModel>
	{

		public CustomLlmModel_CrtCopilotEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CustomLlmModel_CrtCopilotEventsProcess

	public partial class CustomLlmModel_CrtCopilotEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CustomLlmModelEventsProcess

	/// <exclude/>
	public class CustomLlmModelEventsProcess : CustomLlmModel_CrtCopilotEventsProcess
	{

		public CustomLlmModelEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

