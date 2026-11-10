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

	#region Class: CopilotAgentSubSkillSchema

	/// <exclude/>
	[IsVirtual]
	public class CopilotAgentSubSkillSchema : Terrasoft.Configuration.CopilotIntentSchema
	{

		#region Constructors: Public

		public CopilotAgentSubSkillSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CopilotAgentSubSkillSchema(CopilotAgentSubSkillSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CopilotAgentSubSkillSchema(CopilotAgentSubSkillSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4326fc32-fcbd-4721-80e9-69332aa196ff");
			RealUId = new Guid("4326fc32-fcbd-4721-80e9-69332aa196ff");
			Name = "CopilotAgentSubSkill";
			ParentSchemaUId = new Guid("7cd7a99a-b22e-4e50-af02-6ee4ac8612ec");
			ExtendParent = false;
			CreatedInPackageId = new Guid("c23dfaf0-0051-4966-86f8-cbe8197258d0");
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
			if (Columns.FindByUId(new Guid("fbc68064-6b80-5cb4-f189-69829a10fac5")) == null) {
				Columns.Add(CreateIntentColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateIntentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("fbc68064-6b80-5cb4-f189-69829a10fac5"),
				Name = @"Intent",
				ReferenceSchemaUId = new Guid("7cd7a99a-b22e-4e50-af02-6ee4ac8612ec"),
				IsIndexed = true,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4326fc32-fcbd-4721-80e9-69332aa196ff"),
				ModifiedInSchemaUId = new Guid("4326fc32-fcbd-4721-80e9-69332aa196ff"),
				CreatedInPackageId = new Guid("c23dfaf0-0051-4966-86f8-cbe8197258d0"),
				IsSimpleLookup = true
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new CopilotAgentSubSkill(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CopilotAgentSubSkill_CrtCopilotEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CopilotAgentSubSkillSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CopilotAgentSubSkillSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4326fc32-fcbd-4721-80e9-69332aa196ff"));
		}

		#endregion

	}

	#endregion

	#region Class: CopilotAgentSubSkill

	/// <summary>
	/// Creatio.ai agent subskill.
	/// </summary>
	public class CopilotAgentSubSkill : Terrasoft.Configuration.CopilotIntent
	{

		#region Constructors: Public

		public CopilotAgentSubSkill(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CopilotAgentSubSkill";
		}

		public CopilotAgentSubSkill(CopilotAgentSubSkill source)
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
		/// Intent.
		/// </summary>
		public CopilotIntent Intent {
			get {
				return _intent ??
					(_intent = LookupColumnEntities.GetEntity("Intent") as CopilotIntent);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CopilotAgentSubSkill_CrtCopilotEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("CopilotAgentSubSkillDeleted", e);
			Deleting += (s, e) => ThrowEvent("CopilotAgentSubSkillDeleting", e);
			Inserted += (s, e) => ThrowEvent("CopilotAgentSubSkillInserted", e);
			Inserting += (s, e) => ThrowEvent("CopilotAgentSubSkillInserting", e);
			Saved += (s, e) => ThrowEvent("CopilotAgentSubSkillSaved", e);
			Saving += (s, e) => ThrowEvent("CopilotAgentSubSkillSaving", e);
			Validating += (s, e) => ThrowEvent("CopilotAgentSubSkillValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new CopilotAgentSubSkill(this);
		}

		#endregion

	}

	#endregion

	#region Class: CopilotAgentSubSkill_CrtCopilotEventsProcess

	/// <exclude/>
	public partial class CopilotAgentSubSkill_CrtCopilotEventsProcess<TEntity> : Terrasoft.Configuration.CopilotIntent_CrtCopilotEventsProcess<TEntity> where TEntity : CopilotAgentSubSkill
	{

		public CopilotAgentSubSkill_CrtCopilotEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CopilotAgentSubSkill_CrtCopilotEventsProcess";
			SchemaUId = new Guid("4326fc32-fcbd-4721-80e9-69332aa196ff");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("4326fc32-fcbd-4721-80e9-69332aa196ff");
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

	#region Class: CopilotAgentSubSkill_CrtCopilotEventsProcess

	/// <exclude/>
	public class CopilotAgentSubSkill_CrtCopilotEventsProcess : CopilotAgentSubSkill_CrtCopilotEventsProcess<CopilotAgentSubSkill>
	{

		public CopilotAgentSubSkill_CrtCopilotEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CopilotAgentSubSkill_CrtCopilotEventsProcess

	public partial class CopilotAgentSubSkill_CrtCopilotEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CopilotAgentSubSkillEventsProcess

	/// <exclude/>
	public class CopilotAgentSubSkillEventsProcess : CopilotAgentSubSkill_CrtCopilotEventsProcess
	{

		public CopilotAgentSubSkillEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

