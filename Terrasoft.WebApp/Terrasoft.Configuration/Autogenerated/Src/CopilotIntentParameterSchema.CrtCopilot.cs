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

	#region Class: CopilotIntentParameterSchema

	/// <exclude/>
	[IsVirtual]
	public class CopilotIntentParameterSchema : Terrasoft.Configuration.BaseCodeLookupSchema
	{

		#region Constructors: Public

		public CopilotIntentParameterSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CopilotIntentParameterSchema(CopilotIntentParameterSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CopilotIntentParameterSchema(CopilotIntentParameterSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("413195ef-eb9f-4598-9250-65dbfb2a0148");
			RealUId = new Guid("413195ef-eb9f-4598-9250-65dbfb2a0148");
			Name = "CopilotIntentParameter";
			ParentSchemaUId = new Guid("2681062b-df59-4e52-89ed-f9b7dc909ab2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("ed753793-30d5-4797-a3f9-3019dcc6e358");
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
			if (Columns.FindByUId(new Guid("8803968c-6096-227c-aa11-007c870ddcf6")) == null) {
				Columns.Add(CreateIntentColumn());
			}
			if (Columns.FindByUId(new Guid("114e1a0d-833f-60e4-e9d0-fca1a20b23b2")) == null) {
				Columns.Add(CreateSourceCollectionColumn());
			}
			if (Columns.FindByUId(new Guid("fc4d2ebf-0a53-60af-e5f7-c8c4c00ae7d6")) == null) {
				Columns.Add(CreateDataValueTypeUIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateIntentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("8803968c-6096-227c-aa11-007c870ddcf6"),
				Name = @"Intent",
				ReferenceSchemaUId = new Guid("7cd7a99a-b22e-4e50-af02-6ee4ac8612ec"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("413195ef-eb9f-4598-9250-65dbfb2a0148"),
				ModifiedInSchemaUId = new Guid("413195ef-eb9f-4598-9250-65dbfb2a0148"),
				CreatedInPackageId = new Guid("ed753793-30d5-4797-a3f9-3019dcc6e358"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateSourceCollectionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("114e1a0d-833f-60e4-e9d0-fca1a20b23b2"),
				Name = @"SourceCollection",
				CreatedInSchemaUId = new Guid("413195ef-eb9f-4598-9250-65dbfb2a0148"),
				ModifiedInSchemaUId = new Guid("413195ef-eb9f-4598-9250-65dbfb2a0148"),
				CreatedInPackageId = new Guid("ed753793-30d5-4797-a3f9-3019dcc6e358")
			};
		}

		protected virtual EntitySchemaColumn CreateDataValueTypeUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("fc4d2ebf-0a53-60af-e5f7-c8c4c00ae7d6"),
				Name = @"DataValueTypeUId",
				CreatedInSchemaUId = new Guid("413195ef-eb9f-4598-9250-65dbfb2a0148"),
				ModifiedInSchemaUId = new Guid("413195ef-eb9f-4598-9250-65dbfb2a0148"),
				CreatedInPackageId = new Guid("ed753793-30d5-4797-a3f9-3019dcc6e358")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new CopilotIntentParameter(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CopilotIntentParameter_CrtCopilotEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CopilotIntentParameterSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CopilotIntentParameterSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("413195ef-eb9f-4598-9250-65dbfb2a0148"));
		}

		#endregion

	}

	#endregion

	#region Class: CopilotIntentParameter

	/// <summary>
	/// Creatio.ai Skill Parameter.
	/// </summary>
	public class CopilotIntentParameter : Terrasoft.Configuration.BaseCodeLookup
	{

		#region Constructors: Public

		public CopilotIntentParameter(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CopilotIntentParameter";
		}

		public CopilotIntentParameter(CopilotIntentParameter source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid IntentId {
			get {
				return GetTypedColumnValue<Guid>("IntentId");
			}
			set {
				SetColumnValue("IntentId", value);
				_intent = null;
			}
		}

		/// <exclude/>
		public string IntentName {
			get {
				return GetTypedColumnValue<string>("IntentName");
			}
			set {
				SetColumnValue("IntentName", value);
				if (_intent != null) {
					_intent.Name = value;
				}
			}
		}

		private CopilotIntent _intent;
		/// <summary>
		/// Skill.
		/// </summary>
		public CopilotIntent Intent {
			get {
				return _intent ??
					(_intent = LookupColumnEntities.GetEntity("Intent") as CopilotIntent);
			}
		}

		/// <summary>
		/// SourceCollection.
		/// </summary>
		public string SourceCollection {
			get {
				return GetTypedColumnValue<string>("SourceCollection");
			}
			set {
				SetColumnValue("SourceCollection", value);
			}
		}

		/// <summary>
		/// Data type.
		/// </summary>
		public Guid DataValueTypeUId {
			get {
				return GetTypedColumnValue<Guid>("DataValueTypeUId");
			}
			set {
				SetColumnValue("DataValueTypeUId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CopilotIntentParameter_CrtCopilotEventsProcess(UserConnection);
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
			return new CopilotIntentParameter(this);
		}

		#endregion

	}

	#endregion

	#region Class: CopilotIntentParameter_CrtCopilotEventsProcess

	/// <exclude/>
	public partial class CopilotIntentParameter_CrtCopilotEventsProcess<TEntity> : Terrasoft.Configuration.BaseCodeLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : CopilotIntentParameter
	{

		public CopilotIntentParameter_CrtCopilotEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CopilotIntentParameter_CrtCopilotEventsProcess";
			SchemaUId = new Guid("413195ef-eb9f-4598-9250-65dbfb2a0148");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("413195ef-eb9f-4598-9250-65dbfb2a0148");
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

	#region Class: CopilotIntentParameter_CrtCopilotEventsProcess

	/// <exclude/>
	public class CopilotIntentParameter_CrtCopilotEventsProcess : CopilotIntentParameter_CrtCopilotEventsProcess<CopilotIntentParameter>
	{

		public CopilotIntentParameter_CrtCopilotEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CopilotIntentParameter_CrtCopilotEventsProcess

	public partial class CopilotIntentParameter_CrtCopilotEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CopilotIntentParameterEventsProcess

	/// <exclude/>
	public class CopilotIntentParameterEventsProcess : CopilotIntentParameter_CrtCopilotEventsProcess
	{

		public CopilotIntentParameterEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

