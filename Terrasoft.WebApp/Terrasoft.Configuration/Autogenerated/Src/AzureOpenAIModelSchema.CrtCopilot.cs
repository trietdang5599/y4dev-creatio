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

	#region Class: AzureOpenAIModelSchema

	/// <exclude/>
	[IsVirtual]
	public class AzureOpenAIModelSchema : Terrasoft.Configuration.LlmModelSchema
	{

		#region Constructors: Public

		public AzureOpenAIModelSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public AzureOpenAIModelSchema(AzureOpenAIModelSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public AzureOpenAIModelSchema(AzureOpenAIModelSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d6e6fd9c-43ca-46dd-81ce-2970b0d5feed");
			RealUId = new Guid("d6e6fd9c-43ca-46dd-81ce-2970b0d5feed");
			Name = "AzureOpenAIModel";
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
			if (Columns.FindByUId(new Guid("5608e279-fa02-d647-486f-15d351238752")) == null) {
				Columns.Add(CreateModelColumn());
			}
			if (Columns.FindByUId(new Guid("e07fe648-03bd-7fd2-14a7-38bfe602d978")) == null) {
				Columns.Add(CreateApiKeyColumn());
			}
			if (Columns.FindByUId(new Guid("028beb94-fed8-84b4-c557-3b721df82986")) == null) {
				Columns.Add(CreateApiVersionColumn());
			}
			if (Columns.FindByUId(new Guid("c8f69f79-46e4-d79a-9d5b-3710fa4d5a37")) == null) {
				Columns.Add(CreateResourceNameColumn());
			}
		}

		protected override EntitySchemaColumn CreateCodeColumn() {
			EntitySchemaColumn column = base.CreateCodeColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.Sequence,
				ValueSource = @""
			};
			column.ModifiedInSchemaUId = new Guid("d6e6fd9c-43ca-46dd-81ce-2970b0d5feed");
			return column;
		}

		protected virtual EntitySchemaColumn CreateModelColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("5608e279-fa02-d647-486f-15d351238752"),
				Name = @"Model",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("d6e6fd9c-43ca-46dd-81ce-2970b0d5feed"),
				ModifiedInSchemaUId = new Guid("d6e6fd9c-43ca-46dd-81ce-2970b0d5feed"),
				CreatedInPackageId = new Guid("11a936bf-8ee0-4505-a8db-e67a2dd080a5")
			};
		}

		protected virtual EntitySchemaColumn CreateApiKeyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("SecureText")) {
				UId = new Guid("e07fe648-03bd-7fd2-14a7-38bfe602d978"),
				Name = @"ApiKey",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("d6e6fd9c-43ca-46dd-81ce-2970b0d5feed"),
				ModifiedInSchemaUId = new Guid("d6e6fd9c-43ca-46dd-81ce-2970b0d5feed"),
				CreatedInPackageId = new Guid("11a936bf-8ee0-4505-a8db-e67a2dd080a5"),
				IsValueMasked = true,
				IsSensitiveData = true
			};
		}

		protected virtual EntitySchemaColumn CreateApiVersionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("028beb94-fed8-84b4-c557-3b721df82986"),
				Name = @"ApiVersion",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("d6e6fd9c-43ca-46dd-81ce-2970b0d5feed"),
				ModifiedInSchemaUId = new Guid("d6e6fd9c-43ca-46dd-81ce-2970b0d5feed"),
				CreatedInPackageId = new Guid("11a936bf-8ee0-4505-a8db-e67a2dd080a5")
			};
		}

		protected virtual EntitySchemaColumn CreateResourceNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("c8f69f79-46e4-d79a-9d5b-3710fa4d5a37"),
				Name = @"ResourceName",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("d6e6fd9c-43ca-46dd-81ce-2970b0d5feed"),
				ModifiedInSchemaUId = new Guid("d6e6fd9c-43ca-46dd-81ce-2970b0d5feed"),
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
			return new AzureOpenAIModel(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new AzureOpenAIModel_CrtCopilotEventsProcess(userConnection);
		}

		public override object Clone() {
			return new AzureOpenAIModelSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new AzureOpenAIModelSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d6e6fd9c-43ca-46dd-81ce-2970b0d5feed"));
		}

		#endregion

	}

	#endregion

	#region Class: AzureOpenAIModel

	/// <summary>
	/// AzureOpenAIModel.
	/// </summary>
	/// <remarks>
	/// LLM model configuration.
	/// </remarks>
	public class AzureOpenAIModel : Terrasoft.Configuration.LlmModel
	{

		#region Constructors: Public

		public AzureOpenAIModel(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "AzureOpenAIModel";
		}

		public AzureOpenAIModel(AzureOpenAIModel source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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
		/// API version.
		/// </summary>
		public string ApiVersion {
			get {
				return GetTypedColumnValue<string>("ApiVersion");
			}
			set {
				SetColumnValue("ApiVersion", value);
			}
		}

		/// <summary>
		/// Azure resource name.
		/// </summary>
		public string ResourceName {
			get {
				return GetTypedColumnValue<string>("ResourceName");
			}
			set {
				SetColumnValue("ResourceName", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new AzureOpenAIModel_CrtCopilotEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("AzureOpenAIModelDeleted", e);
			Deleting += (s, e) => ThrowEvent("AzureOpenAIModelDeleting", e);
			Inserted += (s, e) => ThrowEvent("AzureOpenAIModelInserted", e);
			Inserting += (s, e) => ThrowEvent("AzureOpenAIModelInserting", e);
			Saved += (s, e) => ThrowEvent("AzureOpenAIModelSaved", e);
			Saving += (s, e) => ThrowEvent("AzureOpenAIModelSaving", e);
			Validating += (s, e) => ThrowEvent("AzureOpenAIModelValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new AzureOpenAIModel(this);
		}

		#endregion

	}

	#endregion

	#region Class: AzureOpenAIModel_CrtCopilotEventsProcess

	/// <exclude/>
	public partial class AzureOpenAIModel_CrtCopilotEventsProcess<TEntity> : Terrasoft.Configuration.LlmModel_CrtCopilotEventsProcess<TEntity> where TEntity : AzureOpenAIModel
	{

		public AzureOpenAIModel_CrtCopilotEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "AzureOpenAIModel_CrtCopilotEventsProcess";
			SchemaUId = new Guid("d6e6fd9c-43ca-46dd-81ce-2970b0d5feed");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("d6e6fd9c-43ca-46dd-81ce-2970b0d5feed");
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

	#region Class: AzureOpenAIModel_CrtCopilotEventsProcess

	/// <exclude/>
	public class AzureOpenAIModel_CrtCopilotEventsProcess : AzureOpenAIModel_CrtCopilotEventsProcess<AzureOpenAIModel>
	{

		public AzureOpenAIModel_CrtCopilotEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: AzureOpenAIModel_CrtCopilotEventsProcess

	public partial class AzureOpenAIModel_CrtCopilotEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: AzureOpenAIModelEventsProcess

	/// <exclude/>
	public class AzureOpenAIModelEventsProcess : AzureOpenAIModel_CrtCopilotEventsProcess
	{

		public AzureOpenAIModelEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

