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

	#region Class: LlmModelSchema

	/// <exclude/>
	public class LlmModelSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public LlmModelSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public LlmModelSchema(LlmModelSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public LlmModelSchema(LlmModelSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("eeb580f0-c12b-4659-96ab-0bd2ea709941");
			RealUId = new Guid("eeb580f0-c12b-4659-96ab-0bd2ea709941");
			Name = "LlmModel";
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

		protected override void InitializeMasterRecordColumn() {
			base.InitializeMasterRecordColumn();
			MasterRecordColumn = CreateLlmProviderColumn();
			if (Columns.FindByUId(MasterRecordColumn.UId) == null) {
				Columns.Add(MasterRecordColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("b4d9ab39-fac7-5b42-41b7-1f65ef6968a1")) == null) {
				Columns.Add(CreateCanUseStructuredOutputColumn());
			}
			if (Columns.FindByUId(new Guid("95be9890-63c1-1826-f783-fcd2b903437d")) == null) {
				Columns.Add(CreateCanUseFunctionCallingColumn());
			}
			if (Columns.FindByUId(new Guid("9dc0175c-b9b3-c6c7-0b96-762e673cb03c")) == null) {
				Columns.Add(CreateCodeColumn());
			}
			if (Columns.FindByUId(new Guid("9949899d-da72-1111-35f2-2c3c2b694e86")) == null) {
				Columns.Add(CreateEncryptedConfigColumn());
			}
			if (Columns.FindByUId(new Guid("3796ab5a-48f7-2599-0370-9dc68a7f2c52")) == null) {
				Columns.Add(CreateConfigurationFailureReasonColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCanUseStructuredOutputColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("b4d9ab39-fac7-5b42-41b7-1f65ef6968a1"),
				Name = @"CanUseStructuredOutput",
				CreatedInSchemaUId = new Guid("eeb580f0-c12b-4659-96ab-0bd2ea709941"),
				ModifiedInSchemaUId = new Guid("eeb580f0-c12b-4659-96ab-0bd2ea709941"),
				CreatedInPackageId = new Guid("800f00c8-04db-4ed1-bc94-0c44b7e5e4f0")
			};
		}

		protected virtual EntitySchemaColumn CreateCanUseFunctionCallingColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("95be9890-63c1-1826-f783-fcd2b903437d"),
				Name = @"CanUseFunctionCalling",
				CreatedInSchemaUId = new Guid("eeb580f0-c12b-4659-96ab-0bd2ea709941"),
				ModifiedInSchemaUId = new Guid("eeb580f0-c12b-4659-96ab-0bd2ea709941"),
				CreatedInPackageId = new Guid("800f00c8-04db-4ed1-bc94-0c44b7e5e4f0")
			};
		}

		protected virtual EntitySchemaColumn CreateLlmProviderColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("4d4518c4-b25c-c249-cd89-b9a769bb485a"),
				Name = @"LlmProvider",
				ReferenceSchemaUId = new Guid("5aa8333a-659c-47df-adff-95fb4796e263"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("eeb580f0-c12b-4659-96ab-0bd2ea709941"),
				ModifiedInSchemaUId = new Guid("eeb580f0-c12b-4659-96ab-0bd2ea709941"),
				CreatedInPackageId = new Guid("800f00c8-04db-4ed1-bc94-0c44b7e5e4f0"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("9dc0175c-b9b3-c6c7-0b96-762e673cb03c"),
				Name = @"Code",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("eeb580f0-c12b-4659-96ab-0bd2ea709941"),
				ModifiedInSchemaUId = new Guid("eeb580f0-c12b-4659-96ab-0bd2ea709941"),
				CreatedInPackageId = new Guid("800f00c8-04db-4ed1-bc94-0c44b7e5e4f0"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Sequence,
					SequencePrefix = "",
					SequenceNumberOfChars = 7
				}
			};
		}

		protected virtual EntitySchemaColumn CreateEncryptedConfigColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("SecureText")) {
				UId = new Guid("9949899d-da72-1111-35f2-2c3c2b694e86"),
				Name = @"EncryptedConfig",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("eeb580f0-c12b-4659-96ab-0bd2ea709941"),
				ModifiedInSchemaUId = new Guid("eeb580f0-c12b-4659-96ab-0bd2ea709941"),
				CreatedInPackageId = new Guid("11a936bf-8ee0-4505-a8db-e67a2dd080a5"),
				IsValueMasked = true,
				IsSensitiveData = true
			};
		}

		protected virtual EntitySchemaColumn CreateConfigurationFailureReasonColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("3796ab5a-48f7-2599-0370-9dc68a7f2c52"),
				Name = @"ConfigurationFailureReason",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("eeb580f0-c12b-4659-96ab-0bd2ea709941"),
				ModifiedInSchemaUId = new Guid("eeb580f0-c12b-4659-96ab-0bd2ea709941"),
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
			return new LlmModel(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new LlmModel_CrtCopilotEventsProcess(userConnection);
		}

		public override object Clone() {
			return new LlmModelSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new LlmModelSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("eeb580f0-c12b-4659-96ab-0bd2ea709941"));
		}

		#endregion

	}

	#endregion

	#region Class: LlmModel

	/// <summary>
	/// LLM Model.
	/// </summary>
	/// <remarks>
	/// LLM model configuration.
	/// </remarks>
	public class LlmModel : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public LlmModel(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "LlmModel";
		}

		public LlmModel(LlmModel source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// CanUseStructuredOutput.
		/// </summary>
		public bool CanUseStructuredOutput {
			get {
				return GetTypedColumnValue<bool>("CanUseStructuredOutput");
			}
			set {
				SetColumnValue("CanUseStructuredOutput", value);
			}
		}

		/// <summary>
		/// CanUseFunctionCalling.
		/// </summary>
		public bool CanUseFunctionCalling {
			get {
				return GetTypedColumnValue<bool>("CanUseFunctionCalling");
			}
			set {
				SetColumnValue("CanUseFunctionCalling", value);
			}
		}

		/// <exclude/>
		public Guid LlmProviderId {
			get {
				return GetTypedColumnValue<Guid>("LlmProviderId");
			}
			set {
				SetColumnValue("LlmProviderId", value);
				_llmProvider = null;
			}
		}

		/// <exclude/>
		public string LlmProviderName {
			get {
				return GetTypedColumnValue<string>("LlmProviderName");
			}
			set {
				SetColumnValue("LlmProviderName", value);
				if (_llmProvider != null) {
					_llmProvider.Name = value;
				}
			}
		}

		private LlmProvider _llmProvider;
		/// <summary>
		/// LLM provider.
		/// </summary>
		public LlmProvider LlmProvider {
			get {
				return _llmProvider ??
					(_llmProvider = LookupColumnEntities.GetEntity("LlmProvider") as LlmProvider);
			}
		}

		/// <summary>
		/// Code.
		/// </summary>
		public string Code {
			get {
				return GetTypedColumnValue<string>("Code");
			}
			set {
				SetColumnValue("Code", value);
			}
		}

		/// <summary>
		/// Json Config.
		/// </summary>
		public string EncryptedConfig {
			get {
				return GetTypedColumnValue<string>("EncryptedConfig");
			}
			set {
				SetColumnValue("EncryptedConfig", value);
			}
		}

		/// <summary>
		/// Configuration Failure Reason.
		/// </summary>
		public string ConfigurationFailureReason {
			get {
				return GetTypedColumnValue<string>("ConfigurationFailureReason");
			}
			set {
				SetColumnValue("ConfigurationFailureReason", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new LlmModel_CrtCopilotEventsProcess(UserConnection);
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
			return new LlmModel(this);
		}

		#endregion

	}

	#endregion

	#region Class: LlmModel_CrtCopilotEventsProcess

	/// <exclude/>
	public partial class LlmModel_CrtCopilotEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : LlmModel
	{

		public LlmModel_CrtCopilotEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "LlmModel_CrtCopilotEventsProcess";
			SchemaUId = new Guid("eeb580f0-c12b-4659-96ab-0bd2ea709941");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("eeb580f0-c12b-4659-96ab-0bd2ea709941");
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

	#region Class: LlmModel_CrtCopilotEventsProcess

	/// <exclude/>
	public class LlmModel_CrtCopilotEventsProcess : LlmModel_CrtCopilotEventsProcess<LlmModel>
	{

		public LlmModel_CrtCopilotEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: LlmModel_CrtCopilotEventsProcess

	public partial class LlmModel_CrtCopilotEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: LlmModelEventsProcess

	/// <exclude/>
	public class LlmModelEventsProcess : LlmModel_CrtCopilotEventsProcess
	{

		public LlmModelEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

