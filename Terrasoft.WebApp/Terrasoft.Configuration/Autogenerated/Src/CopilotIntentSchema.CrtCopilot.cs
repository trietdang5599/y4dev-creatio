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

	#region Class: CopilotIntentSchema

	/// <exclude/>
	[IsVirtual]
	public class CopilotIntentSchema : Terrasoft.Configuration.BaseCopilotIntentSchema
	{

		#region Constructors: Public

		public CopilotIntentSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CopilotIntentSchema(CopilotIntentSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CopilotIntentSchema(CopilotIntentSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7cd7a99a-b22e-4e50-af02-6ee4ac8612ec");
			RealUId = new Guid("7cd7a99a-b22e-4e50-af02-6ee4ac8612ec");
			Name = "CopilotIntent";
			ParentSchemaUId = new Guid("a90230c0-2973-4d2a-b38e-935c9631258d");
			ExtendParent = false;
			CreatedInPackageId = new Guid("e94aa263-bfb4-4fa2-906e-1a8040844e6c");
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
			if (Columns.FindByUId(new Guid("1faf575b-0e5f-9c15-5110-42359f4d83e5")) == null) {
				Columns.Add(CreateModeColumn());
			}
			if (Columns.FindByUId(new Guid("00aaf88b-4d3b-bc95-0fb7-3f70fe08fb91")) == null) {
				Columns.Add(CreateParentIntentIdColumn());
			}
			if (Columns.FindByUId(new Guid("c8c7f135-cecb-5226-3864-4560cde791c4")) == null) {
				Columns.Add(CreateResponseFormatJsonSchemaColumn());
			}
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.None;
			column.ModifiedInSchemaUId = new Guid("7cd7a99a-b22e-4e50-af02-6ee4ac8612ec");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.None;
			column.ModifiedInSchemaUId = new Guid("7cd7a99a-b22e-4e50-af02-6ee4ac8612ec");
			return column;
		}

		protected override EntitySchemaColumn CreatePackageUIdColumn() {
			EntitySchemaColumn column = base.CreatePackageUIdColumn();
			column.UsageType = EntitySchemaColumnUsageType.None;
			column.ModifiedInSchemaUId = new Guid("7cd7a99a-b22e-4e50-af02-6ee4ac8612ec");
			return column;
		}

		protected virtual EntitySchemaColumn CreateModeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("1faf575b-0e5f-9c15-5110-42359f4d83e5"),
				Name = @"Mode",
				ReferenceSchemaUId = new Guid("c541ee8e-5939-4e57-be5b-9c252fe968cf"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("7cd7a99a-b22e-4e50-af02-6ee4ac8612ec"),
				ModifiedInSchemaUId = new Guid("7cd7a99a-b22e-4e50-af02-6ee4ac8612ec"),
				CreatedInPackageId = new Guid("a5645ea0-1b73-4b60-b012-23b3100050d4"),
				IsSimpleLookup = true,
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"326bba59-302a-4a5e-857c-2576e1a38ab0"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateParentIntentIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("00aaf88b-4d3b-bc95-0fb7-3f70fe08fb91"),
				Name = @"ParentIntentId",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("7cd7a99a-b22e-4e50-af02-6ee4ac8612ec"),
				ModifiedInSchemaUId = new Guid("7cd7a99a-b22e-4e50-af02-6ee4ac8612ec"),
				CreatedInPackageId = new Guid("11a936bf-8ee0-4505-a8db-e67a2dd080a5")
			};
		}

		protected virtual EntitySchemaColumn CreateResponseFormatJsonSchemaColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("c8c7f135-cecb-5226-3864-4560cde791c4"),
				Name = @"ResponseFormatJsonSchema",
				UsageType = EntitySchemaColumnUsageType.Advanced,
				CreatedInSchemaUId = new Guid("7cd7a99a-b22e-4e50-af02-6ee4ac8612ec"),
				ModifiedInSchemaUId = new Guid("7cd7a99a-b22e-4e50-af02-6ee4ac8612ec"),
				CreatedInPackageId = new Guid("ed753793-30d5-4797-a3f9-3019dcc6e358"),
				IsMultiLineText = true
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new CopilotIntent(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CopilotIntent_CrtCopilotEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CopilotIntentSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CopilotIntentSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7cd7a99a-b22e-4e50-af02-6ee4ac8612ec"));
		}

		#endregion

	}

	#endregion

	#region Class: CopilotIntent

	/// <summary>
	/// Creatio.ai Skill.
	/// </summary>
	public class CopilotIntent : Terrasoft.Configuration.BaseCopilotIntent
	{

		#region Constructors: Public

		public CopilotIntent(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CopilotIntent";
		}

		public CopilotIntent(CopilotIntent source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ModeId {
			get {
				return GetTypedColumnValue<Guid>("ModeId");
			}
			set {
				SetColumnValue("ModeId", value);
				_mode = null;
			}
		}

		/// <exclude/>
		public string ModeName {
			get {
				return GetTypedColumnValue<string>("ModeName");
			}
			set {
				SetColumnValue("ModeName", value);
				if (_mode != null) {
					_mode.Name = value;
				}
			}
		}

		private CopilotIntentMode _mode;
		/// <summary>
		/// Mode.
		/// </summary>
		public CopilotIntentMode Mode {
			get {
				return _mode ??
					(_mode = LookupColumnEntities.GetEntity("Mode") as CopilotIntentMode);
			}
		}

		/// <summary>
		/// ParentIntentId.
		/// </summary>
		public Guid ParentIntentId {
			get {
				return GetTypedColumnValue<Guid>("ParentIntentId");
			}
			set {
				SetColumnValue("ParentIntentId", value);
			}
		}

		/// <summary>
		/// ResponseFormatJsonSchema.
		/// </summary>
		public string ResponseFormatJsonSchema {
			get {
				return GetTypedColumnValue<string>("ResponseFormatJsonSchema");
			}
			set {
				SetColumnValue("ResponseFormatJsonSchema", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CopilotIntent_CrtCopilotEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("CopilotIntentDeleted", e);
			Deleting += (s, e) => ThrowEvent("CopilotIntentDeleting", e);
			Inserted += (s, e) => ThrowEvent("CopilotIntentInserted", e);
			Inserting += (s, e) => ThrowEvent("CopilotIntentInserting", e);
			Saved += (s, e) => ThrowEvent("CopilotIntentSaved", e);
			Saving += (s, e) => ThrowEvent("CopilotIntentSaving", e);
			Validating += (s, e) => ThrowEvent("CopilotIntentValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new CopilotIntent(this);
		}

		#endregion

	}

	#endregion

	#region Class: CopilotIntent_CrtCopilotEventsProcess

	/// <exclude/>
	public partial class CopilotIntent_CrtCopilotEventsProcess<TEntity> : Terrasoft.Configuration.BaseCopilotIntent_CrtCopilotEventsProcess<TEntity> where TEntity : CopilotIntent
	{

		public CopilotIntent_CrtCopilotEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CopilotIntent_CrtCopilotEventsProcess";
			SchemaUId = new Guid("7cd7a99a-b22e-4e50-af02-6ee4ac8612ec");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("7cd7a99a-b22e-4e50-af02-6ee4ac8612ec");
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

	#region Class: CopilotIntent_CrtCopilotEventsProcess

	/// <exclude/>
	public class CopilotIntent_CrtCopilotEventsProcess : CopilotIntent_CrtCopilotEventsProcess<CopilotIntent>
	{

		public CopilotIntent_CrtCopilotEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CopilotIntent_CrtCopilotEventsProcess

	public partial class CopilotIntent_CrtCopilotEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CopilotIntentEventsProcess

	/// <exclude/>
	public class CopilotIntentEventsProcess : CopilotIntent_CrtCopilotEventsProcess
	{

		public CopilotIntentEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

