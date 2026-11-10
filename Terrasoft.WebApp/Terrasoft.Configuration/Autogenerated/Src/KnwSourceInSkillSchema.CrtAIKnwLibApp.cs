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

	#region Class: KnwSourceInSkillSchema

	/// <exclude/>
	public class KnwSourceInSkillSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public KnwSourceInSkillSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public KnwSourceInSkillSchema(KnwSourceInSkillSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public KnwSourceInSkillSchema(KnwSourceInSkillSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("305b6174-5d3e-4bf5-9a20-461c6eada314");
			RealUId = new Guid("305b6174-5d3e-4bf5-9a20-461c6eada314");
			Name = "KnwSourceInSkill";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("8aa4d699-3cf5-485e-8023-1440b0f17cf2");
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
			if (Columns.FindByUId(new Guid("48b17fb8-2e1d-ef9e-8c20-0fb9936e80e3")) == null) {
				Columns.Add(CreateIntentIdColumn());
			}
			if (Columns.FindByUId(new Guid("3b3e4515-caee-4f19-2529-104eaac937cc")) == null) {
				Columns.Add(CreateKnwSourceColumn());
			}
			if (Columns.FindByUId(new Guid("be69e382-9f56-9191-69ec-7418158fc02c")) == null) {
				Columns.Add(CreateUseCitationsColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateIntentIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("48b17fb8-2e1d-ef9e-8c20-0fb9936e80e3"),
				Name = @"IntentId",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("305b6174-5d3e-4bf5-9a20-461c6eada314"),
				ModifiedInSchemaUId = new Guid("305b6174-5d3e-4bf5-9a20-461c6eada314"),
				CreatedInPackageId = new Guid("8aa4d699-3cf5-485e-8023-1440b0f17cf2")
			};
		}

		protected virtual EntitySchemaColumn CreateKnwSourceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("3b3e4515-caee-4f19-2529-104eaac937cc"),
				Name = @"KnwSource",
				ReferenceSchemaUId = new Guid("6ec4827f-1e9a-4077-8c37-b7e97686fb92"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("305b6174-5d3e-4bf5-9a20-461c6eada314"),
				ModifiedInSchemaUId = new Guid("305b6174-5d3e-4bf5-9a20-461c6eada314"),
				CreatedInPackageId = new Guid("8aa4d699-3cf5-485e-8023-1440b0f17cf2"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateUseCitationsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("be69e382-9f56-9191-69ec-7418158fc02c"),
				Name = @"UseCitations",
				CreatedInSchemaUId = new Guid("305b6174-5d3e-4bf5-9a20-461c6eada314"),
				ModifiedInSchemaUId = new Guid("305b6174-5d3e-4bf5-9a20-461c6eada314"),
				CreatedInPackageId = new Guid("c4501506-50b4-45d9-8ebc-8eae604ce9c6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"True"
				}
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new KnwSourceInSkill(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new KnwSourceInSkill_CrtAIKnwLibAppEventsProcess(userConnection);
		}

		public override object Clone() {
			return new KnwSourceInSkillSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new KnwSourceInSkillSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("305b6174-5d3e-4bf5-9a20-461c6eada314"));
		}

		#endregion

	}

	#endregion

	#region Class: KnwSourceInSkill

	/// <summary>
	/// Knowledge source in Skill/Agent.
	/// </summary>
	public class KnwSourceInSkill : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public KnwSourceInSkill(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "KnwSourceInSkill";
		}

		public KnwSourceInSkill(KnwSourceInSkill source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Intent.
		/// </summary>
		public Guid IntentId {
			get {
				return GetTypedColumnValue<Guid>("IntentId");
			}
			set {
				SetColumnValue("IntentId", value);
			}
		}

		/// <exclude/>
		public Guid KnwSourceId {
			get {
				return GetTypedColumnValue<Guid>("KnwSourceId");
			}
			set {
				SetColumnValue("KnwSourceId", value);
				_knwSource = null;
			}
		}

		/// <exclude/>
		public string KnwSourceName {
			get {
				return GetTypedColumnValue<string>("KnwSourceName");
			}
			set {
				SetColumnValue("KnwSourceName", value);
				if (_knwSource != null) {
					_knwSource.Name = value;
				}
			}
		}

		private KnwSource _knwSource;
		/// <summary>
		/// Knowledge Source.
		/// </summary>
		public KnwSource KnwSource {
			get {
				return _knwSource ??
					(_knwSource = LookupColumnEntities.GetEntity("KnwSource") as KnwSource);
			}
		}

		/// <summary>
		/// Citations.
		/// </summary>
		public bool UseCitations {
			get {
				return GetTypedColumnValue<bool>("UseCitations");
			}
			set {
				SetColumnValue("UseCitations", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new KnwSourceInSkill_CrtAIKnwLibAppEventsProcess(UserConnection);
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
			return new KnwSourceInSkill(this);
		}

		#endregion

	}

	#endregion

	#region Class: KnwSourceInSkill_CrtAIKnwLibAppEventsProcess

	/// <exclude/>
	public partial class KnwSourceInSkill_CrtAIKnwLibAppEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : KnwSourceInSkill
	{

		public KnwSourceInSkill_CrtAIKnwLibAppEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "KnwSourceInSkill_CrtAIKnwLibAppEventsProcess";
			SchemaUId = new Guid("305b6174-5d3e-4bf5-9a20-461c6eada314");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("305b6174-5d3e-4bf5-9a20-461c6eada314");
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

	#region Class: KnwSourceInSkill_CrtAIKnwLibAppEventsProcess

	/// <exclude/>
	public class KnwSourceInSkill_CrtAIKnwLibAppEventsProcess : KnwSourceInSkill_CrtAIKnwLibAppEventsProcess<KnwSourceInSkill>
	{

		public KnwSourceInSkill_CrtAIKnwLibAppEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: KnwSourceInSkill_CrtAIKnwLibAppEventsProcess

	public partial class KnwSourceInSkill_CrtAIKnwLibAppEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: KnwSourceInSkillEventsProcess

	/// <exclude/>
	public class KnwSourceInSkillEventsProcess : KnwSourceInSkill_CrtAIKnwLibAppEventsProcess
	{

		public KnwSourceInSkillEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

