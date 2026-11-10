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

	#region Class: OpenAIModelSchema

	/// <exclude/>
	[IsVirtual]
	public class OpenAIModelSchema : Terrasoft.Configuration.LlmModelSchema
	{

		#region Constructors: Public

		public OpenAIModelSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OpenAIModelSchema(OpenAIModelSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OpenAIModelSchema(OpenAIModelSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("8c82aac9-c03d-4f35-8a49-b9396f3bb9f1");
			RealUId = new Guid("8c82aac9-c03d-4f35-8a49-b9396f3bb9f1");
			Name = "OpenAIModel";
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
			if (Columns.FindByUId(new Guid("2fd63b5d-6a79-5b38-4fa8-c3bd66209035")) == null) {
				Columns.Add(CreateApiKeyColumn());
			}
			if (Columns.FindByUId(new Guid("d2a9d813-d147-e696-6594-e5f95ccf70da")) == null) {
				Columns.Add(CreateModelColumn());
			}
		}

		protected override EntitySchemaColumn CreateCodeColumn() {
			EntitySchemaColumn column = base.CreateCodeColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.Sequence,
				ValueSource = @""
			};
			column.ModifiedInSchemaUId = new Guid("8c82aac9-c03d-4f35-8a49-b9396f3bb9f1");
			return column;
		}

		protected virtual EntitySchemaColumn CreateApiKeyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("SecureText")) {
				UId = new Guid("2fd63b5d-6a79-5b38-4fa8-c3bd66209035"),
				Name = @"ApiKey",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("8c82aac9-c03d-4f35-8a49-b9396f3bb9f1"),
				ModifiedInSchemaUId = new Guid("8c82aac9-c03d-4f35-8a49-b9396f3bb9f1"),
				CreatedInPackageId = new Guid("11a936bf-8ee0-4505-a8db-e67a2dd080a5"),
				IsValueMasked = true,
				IsSensitiveData = true
			};
		}

		protected virtual EntitySchemaColumn CreateModelColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("d2a9d813-d147-e696-6594-e5f95ccf70da"),
				Name = @"Model",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("8c82aac9-c03d-4f35-8a49-b9396f3bb9f1"),
				ModifiedInSchemaUId = new Guid("8c82aac9-c03d-4f35-8a49-b9396f3bb9f1"),
				CreatedInPackageId = new Guid("11a936bf-8ee0-4505-a8db-e67a2dd080a5")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new OpenAIModel(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OpenAIModel_CrtCopilotEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OpenAIModelSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OpenAIModelSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("8c82aac9-c03d-4f35-8a49-b9396f3bb9f1"));
		}

		#endregion

	}

	#endregion

	#region Class: OpenAIModel

	/// <summary>
	/// OpenAI Model.
	/// </summary>
	/// <remarks>
	/// OpenAI Model configuration.
	/// </remarks>
	public class OpenAIModel : Terrasoft.Configuration.LlmModel
	{

		#region Constructors: Public

		public OpenAIModel(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OpenAIModel";
		}

		public OpenAIModel(OpenAIModel source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// API key.
		/// </summary>
		public string ApiKey {
			get {
				return GetTypedColumnValue<string>("ApiKey");
			}
			set {
				SetColumnValue("ApiKey", value);
			}
		}

		/// <summary>
		/// Model name.
		/// </summary>
		public string Model {
			get {
				return GetTypedColumnValue<string>("Model");
			}
			set {
				SetColumnValue("Model", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OpenAIModel_CrtCopilotEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("OpenAIModelDeleted", e);
			Deleting += (s, e) => ThrowEvent("OpenAIModelDeleting", e);
			Inserted += (s, e) => ThrowEvent("OpenAIModelInserted", e);
			Inserting += (s, e) => ThrowEvent("OpenAIModelInserting", e);
			Saved += (s, e) => ThrowEvent("OpenAIModelSaved", e);
			Saving += (s, e) => ThrowEvent("OpenAIModelSaving", e);
			Validating += (s, e) => ThrowEvent("OpenAIModelValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new OpenAIModel(this);
		}

		#endregion

	}

	#endregion

	#region Class: OpenAIModel_CrtCopilotEventsProcess

	/// <exclude/>
	public partial class OpenAIModel_CrtCopilotEventsProcess<TEntity> : Terrasoft.Configuration.LlmModel_CrtCopilotEventsProcess<TEntity> where TEntity : OpenAIModel
	{

		public OpenAIModel_CrtCopilotEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OpenAIModel_CrtCopilotEventsProcess";
			SchemaUId = new Guid("8c82aac9-c03d-4f35-8a49-b9396f3bb9f1");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("8c82aac9-c03d-4f35-8a49-b9396f3bb9f1");
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

	#region Class: OpenAIModel_CrtCopilotEventsProcess

	/// <exclude/>
	public class OpenAIModel_CrtCopilotEventsProcess : OpenAIModel_CrtCopilotEventsProcess<OpenAIModel>
	{

		public OpenAIModel_CrtCopilotEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OpenAIModel_CrtCopilotEventsProcess

	public partial class OpenAIModel_CrtCopilotEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: OpenAIModelEventsProcess

	/// <exclude/>
	public class OpenAIModelEventsProcess : OpenAIModel_CrtCopilotEventsProcess
	{

		public OpenAIModelEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

