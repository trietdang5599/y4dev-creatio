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

	#region Class: LlmModelCategorySchema

	/// <exclude/>
	public class LlmModelCategorySchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public LlmModelCategorySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public LlmModelCategorySchema(LlmModelCategorySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public LlmModelCategorySchema(LlmModelCategorySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f1398003-edb1-4af0-918e-5e1e6f1f9ad7");
			RealUId = new Guid("f1398003-edb1-4af0-918e-5e1e6f1f9ad7");
			Name = "LlmModelCategory";
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
			if (Columns.FindByUId(new Guid("db44ab9e-274a-de92-00b5-7534e25079d9")) == null) {
				Columns.Add(CreateIsCustomizedColumn());
			}
			if (Columns.FindByUId(new Guid("e1dcaf29-e0c6-be6e-0b80-94c4073c540a")) == null) {
				Columns.Add(CreateDefaultLlmModelColumn());
			}
			if (Columns.FindByUId(new Guid("31761d50-776a-2684-24f8-90a2b9ffc27e")) == null) {
				Columns.Add(CreateCodeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateIsCustomizedColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("db44ab9e-274a-de92-00b5-7534e25079d9"),
				Name = @"IsCustomized",
				CreatedInSchemaUId = new Guid("f1398003-edb1-4af0-918e-5e1e6f1f9ad7"),
				ModifiedInSchemaUId = new Guid("f1398003-edb1-4af0-918e-5e1e6f1f9ad7"),
				CreatedInPackageId = new Guid("800f00c8-04db-4ed1-bc94-0c44b7e5e4f0")
			};
		}

		protected virtual EntitySchemaColumn CreateDefaultLlmModelColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e1dcaf29-e0c6-be6e-0b80-94c4073c540a"),
				Name = @"DefaultLlmModel",
				ReferenceSchemaUId = new Guid("eeb580f0-c12b-4659-96ab-0bd2ea709941"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("f1398003-edb1-4af0-918e-5e1e6f1f9ad7"),
				ModifiedInSchemaUId = new Guid("f1398003-edb1-4af0-918e-5e1e6f1f9ad7"),
				CreatedInPackageId = new Guid("800f00c8-04db-4ed1-bc94-0c44b7e5e4f0"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("31761d50-776a-2684-24f8-90a2b9ffc27e"),
				Name = @"Code",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("f1398003-edb1-4af0-918e-5e1e6f1f9ad7"),
				ModifiedInSchemaUId = new Guid("f1398003-edb1-4af0-918e-5e1e6f1f9ad7"),
				CreatedInPackageId = new Guid("800f00c8-04db-4ed1-bc94-0c44b7e5e4f0")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new LlmModelCategory(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new LlmModelCategory_CrtCopilotEventsProcess(userConnection);
		}

		public override object Clone() {
			return new LlmModelCategorySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new LlmModelCategorySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f1398003-edb1-4af0-918e-5e1e6f1f9ad7"));
		}

		#endregion

	}

	#endregion

	#region Class: LlmModelCategory

	/// <summary>
	/// LLM Model Category.
	/// </summary>
	/// <remarks>
	/// Categories of LLM models.
	/// </remarks>
	public class LlmModelCategory : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public LlmModelCategory(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "LlmModelCategory";
		}

		public LlmModelCategory(LlmModelCategory source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Is Customized.
		/// </summary>
		public bool IsCustomized {
			get {
				return GetTypedColumnValue<bool>("IsCustomized");
			}
			set {
				SetColumnValue("IsCustomized", value);
			}
		}

		/// <exclude/>
		public Guid DefaultLlmModelId {
			get {
				return GetTypedColumnValue<Guid>("DefaultLlmModelId");
			}
			set {
				SetColumnValue("DefaultLlmModelId", value);
				_defaultLlmModel = null;
			}
		}

		/// <exclude/>
		public string DefaultLlmModelName {
			get {
				return GetTypedColumnValue<string>("DefaultLlmModelName");
			}
			set {
				SetColumnValue("DefaultLlmModelName", value);
				if (_defaultLlmModel != null) {
					_defaultLlmModel.Name = value;
				}
			}
		}

		private LlmModel _defaultLlmModel;
		/// <summary>
		/// Default LLM Model.
		/// </summary>
		public LlmModel DefaultLlmModel {
			get {
				return _defaultLlmModel ??
					(_defaultLlmModel = LookupColumnEntities.GetEntity("DefaultLlmModel") as LlmModel);
			}
		}

		/// <summary>
		/// Code.
		/// </summary>
		/// <remarks>
		/// Category code.
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
			var process = new LlmModelCategory_CrtCopilotEventsProcess(UserConnection);
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
			return new LlmModelCategory(this);
		}

		#endregion

	}

	#endregion

	#region Class: LlmModelCategory_CrtCopilotEventsProcess

	/// <exclude/>
	public partial class LlmModelCategory_CrtCopilotEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : LlmModelCategory
	{

		public LlmModelCategory_CrtCopilotEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "LlmModelCategory_CrtCopilotEventsProcess";
			SchemaUId = new Guid("f1398003-edb1-4af0-918e-5e1e6f1f9ad7");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("f1398003-edb1-4af0-918e-5e1e6f1f9ad7");
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

	#region Class: LlmModelCategory_CrtCopilotEventsProcess

	/// <exclude/>
	public class LlmModelCategory_CrtCopilotEventsProcess : LlmModelCategory_CrtCopilotEventsProcess<LlmModelCategory>
	{

		public LlmModelCategory_CrtCopilotEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: LlmModelCategory_CrtCopilotEventsProcess

	public partial class LlmModelCategory_CrtCopilotEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: LlmModelCategoryEventsProcess

	/// <exclude/>
	public class LlmModelCategoryEventsProcess : LlmModelCategory_CrtCopilotEventsProcess
	{

		public LlmModelCategoryEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

