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

	#region Class: CopilotPromptSchema

	/// <exclude/>
	public class CopilotPromptSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public CopilotPromptSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CopilotPromptSchema(CopilotPromptSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CopilotPromptSchema(CopilotPromptSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIX_CopilotPrompt_NameIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = true
			};
			index.UId = new Guid("2a420a11-8e05-46e8-abf6-5bb9a1a68828");
			index.Name = "IX_CopilotPrompt_Name";
			index.CreatedInSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			index.ModifiedInSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			index.CreatedInPackageId = new Guid("a5645ea0-1b73-4b60-b012-23b3100050d4");
			EntitySchemaIndexColumn nameIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("b284953b-4fd6-958a-1c6d-bbf2e4c3f286"),
				ColumnUId = new Guid("736c30a7-c0ec-4fa9-b034-2552b319b633"),
				CreatedInSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75"),
				ModifiedInSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75"),
				CreatedInPackageId = new Guid("a5645ea0-1b73-4b60-b012-23b3100050d4"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(nameIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("cab6836a-188f-4dd4-8531-0dde52a5e773");
			RealUId = new Guid("cab6836a-188f-4dd4-8531-0dde52a5e773");
			Name = "CopilotPrompt";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("a5645ea0-1b73-4b60-b012-23b3100050d4");
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
			if (Columns.FindByUId(new Guid("d72d2de1-99cd-99b2-0858-a72d8fd27190")) == null) {
				Columns.Add(CreatePromptColumn());
			}
			if (Columns.FindByUId(new Guid("ad7601c8-d10d-bced-bc1b-853ae8799025")) == null) {
				Columns.Add(CreateCodeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreatePromptColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("d72d2de1-99cd-99b2-0858-a72d8fd27190"),
				Name = @"Prompt",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("cab6836a-188f-4dd4-8531-0dde52a5e773"),
				ModifiedInSchemaUId = new Guid("cab6836a-188f-4dd4-8531-0dde52a5e773"),
				CreatedInPackageId = new Guid("a5645ea0-1b73-4b60-b012-23b3100050d4"),
				IsMultiLineText = true
			};
		}

		protected virtual EntitySchemaColumn CreateCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("ad7601c8-d10d-bced-bc1b-853ae8799025"),
				Name = @"Code",
				CreatedInSchemaUId = new Guid("cab6836a-188f-4dd4-8531-0dde52a5e773"),
				ModifiedInSchemaUId = new Guid("cab6836a-188f-4dd4-8531-0dde52a5e773"),
				CreatedInPackageId = new Guid("800f00c8-04db-4ed1-bc94-0c44b7e5e4f0")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIX_CopilotPrompt_NameIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new CopilotPrompt(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CopilotPrompt_CrtCopilotEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CopilotPromptSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CopilotPromptSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("cab6836a-188f-4dd4-8531-0dde52a5e773"));
		}

		#endregion

	}

	#endregion

	#region Class: CopilotPrompt

	/// <summary>
	/// Creatio.ai Prompts.
	/// </summary>
	/// <remarks>
	/// This table stores predefined system prompts used to guide the behavior of Creatio.ai.
	/// </remarks>
	public class CopilotPrompt : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public CopilotPrompt(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CopilotPrompt";
		}

		public CopilotPrompt(CopilotPrompt source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CopilotPrompt_CrtCopilotEventsProcess(UserConnection);
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
			return new CopilotPrompt(this);
		}

		#endregion

	}

	#endregion

	#region Class: CopilotPrompt_CrtCopilotEventsProcess

	/// <exclude/>
	public partial class CopilotPrompt_CrtCopilotEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : CopilotPrompt
	{

		public CopilotPrompt_CrtCopilotEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CopilotPrompt_CrtCopilotEventsProcess";
			SchemaUId = new Guid("cab6836a-188f-4dd4-8531-0dde52a5e773");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("cab6836a-188f-4dd4-8531-0dde52a5e773");
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

	#region Class: CopilotPrompt_CrtCopilotEventsProcess

	/// <exclude/>
	public class CopilotPrompt_CrtCopilotEventsProcess : CopilotPrompt_CrtCopilotEventsProcess<CopilotPrompt>
	{

		public CopilotPrompt_CrtCopilotEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CopilotPrompt_CrtCopilotEventsProcess

	public partial class CopilotPrompt_CrtCopilotEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CopilotPromptEventsProcess

	/// <exclude/>
	public class CopilotPromptEventsProcess : CopilotPrompt_CrtCopilotEventsProcess
	{

		public CopilotPromptEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

