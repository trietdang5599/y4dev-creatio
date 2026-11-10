namespace Terrasoft.Configuration
{

	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.IO;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;

	#region Class: AIManagementSchema

	/// <exclude/>
	public class AIManagementSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public AIManagementSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public AIManagementSchema(AIManagementSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public AIManagementSchema(AIManagementSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("eb4454ea-8f77-4631-b0c7-6ab0c69cde07");
			RealUId = new Guid("eb4454ea-8f77-4631-b0c7-6ab0c69cde07");
			Name = "AIManagement";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("6f71e54c-1960-40c9-94f6-073fd67699ab");
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
			if (Columns.FindByUId(new Guid("1e7dfb0c-169f-d864-13f1-50a7af4fd784")) == null) {
				Columns.Add(CreateSysAdminUnitColumn());
			}
			if (Columns.FindByUId(new Guid("3aa2c7ab-3d73-089d-d06f-f2ba1269605f")) == null) {
				Columns.Add(CreatePriorityColumn());
			}
			if (Columns.FindByUId(new Guid("916a784e-0b1b-e887-f317-f76edd7640fb")) == null) {
				Columns.Add(CreateNewAIEnabledColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysAdminUnitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("1e7dfb0c-169f-d864-13f1-50a7af4fd784"),
				Name = @"SysAdminUnit",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("eb4454ea-8f77-4631-b0c7-6ab0c69cde07"),
				ModifiedInSchemaUId = new Guid("eb4454ea-8f77-4631-b0c7-6ab0c69cde07"),
				CreatedInPackageId = new Guid("940856ec-d8fc-4c1c-bf51-05f9a6f6a977")
			};
		}

		protected virtual EntitySchemaColumn CreatePriorityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("3aa2c7ab-3d73-089d-d06f-f2ba1269605f"),
				Name = @"Priority",
				CreatedInSchemaUId = new Guid("eb4454ea-8f77-4631-b0c7-6ab0c69cde07"),
				ModifiedInSchemaUId = new Guid("eb4454ea-8f77-4631-b0c7-6ab0c69cde07"),
				CreatedInPackageId = new Guid("940856ec-d8fc-4c1c-bf51-05f9a6f6a977")
			};
		}

		protected virtual EntitySchemaColumn CreateNewAIEnabledColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("916a784e-0b1b-e887-f317-f76edd7640fb"),
				Name = @"NewAIEnabled",
				CreatedInSchemaUId = new Guid("eb4454ea-8f77-4631-b0c7-6ab0c69cde07"),
				ModifiedInSchemaUId = new Guid("eb4454ea-8f77-4631-b0c7-6ab0c69cde07"),
				CreatedInPackageId = new Guid("940856ec-d8fc-4c1c-bf51-05f9a6f6a977")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new AIManagement(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new AIManagement_CrtAiTwinAppEventsProcess(userConnection);
		}

		public override object Clone() {
			return new AIManagementSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new AIManagementSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("eb4454ea-8f77-4631-b0c7-6ab0c69cde07"));
		}

		#endregion

	}

	#endregion

	#region Class: AIManagement

	/// <summary>
	/// AI type for system administration object.
	/// </summary>
	public class AIManagement : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public AIManagement(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "AIManagement";
		}

		public AIManagement(AIManagement source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SysAdminUnitId {
			get {
				return GetTypedColumnValue<Guid>("SysAdminUnitId");
			}
			set {
				SetColumnValue("SysAdminUnitId", value);
				_sysAdminUnit = null;
			}
		}

		/// <exclude/>
		public string SysAdminUnitName {
			get {
				return GetTypedColumnValue<string>("SysAdminUnitName");
			}
			set {
				SetColumnValue("SysAdminUnitName", value);
				if (_sysAdminUnit != null) {
					_sysAdminUnit.Name = value;
				}
			}
		}

		private SysAdminUnit _sysAdminUnit;
		/// <summary>
		/// System administration object.
		/// </summary>
		public SysAdminUnit SysAdminUnit {
			get {
				return _sysAdminUnit ??
					(_sysAdminUnit = LookupColumnEntities.GetEntity("SysAdminUnit") as SysAdminUnit);
			}
		}

		/// <summary>
		/// Priority.
		/// </summary>
		public int Priority {
			get {
				return GetTypedColumnValue<int>("Priority");
			}
			set {
				SetColumnValue("Priority", value);
			}
		}

		/// <summary>
		/// Creatio.ai Twin Chat is enabled.
		/// </summary>
		public bool NewAIEnabled {
			get {
				return GetTypedColumnValue<bool>("NewAIEnabled");
			}
			set {
				SetColumnValue("NewAIEnabled", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new AIManagement_CrtAiTwinAppEventsProcess(UserConnection);
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
			return new AIManagement(this);
		}

		#endregion

	}

	#endregion

	#region Class: AIManagement_CrtAiTwinAppEventsProcess

	/// <exclude/>
	public partial class AIManagement_CrtAiTwinAppEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : AIManagement
	{

		public AIManagement_CrtAiTwinAppEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "AIManagement_CrtAiTwinAppEventsProcess";
			SchemaUId = new Guid("eb4454ea-8f77-4631-b0c7-6ab0c69cde07");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("eb4454ea-8f77-4631-b0c7-6ab0c69cde07");
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

	#region Class: AIManagement_CrtAiTwinAppEventsProcess

	/// <exclude/>
	public class AIManagement_CrtAiTwinAppEventsProcess : AIManagement_CrtAiTwinAppEventsProcess<AIManagement>
	{

		public AIManagement_CrtAiTwinAppEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: AIManagement_CrtAiTwinAppEventsProcess

	public partial class AIManagement_CrtAiTwinAppEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: AIManagementEventsProcess

	/// <exclude/>
	public class AIManagementEventsProcess : AIManagement_CrtAiTwinAppEventsProcess
	{

		public AIManagementEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

