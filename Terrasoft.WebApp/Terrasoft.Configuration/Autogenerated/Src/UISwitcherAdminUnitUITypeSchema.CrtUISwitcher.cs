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

	#region Class: UISwitcherAdminUnitUITypeSchema

	/// <exclude/>
	public class UISwitcherAdminUnitUITypeSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public UISwitcherAdminUnitUITypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public UISwitcherAdminUnitUITypeSchema(UISwitcherAdminUnitUITypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public UISwitcherAdminUnitUITypeSchema(UISwitcherAdminUnitUITypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("2c6c3fbf-79e0-42d5-8a9f-3d14a5299fd8");
			RealUId = new Guid("2c6c3fbf-79e0-42d5-8a9f-3d14a5299fd8");
			Name = "UISwitcherAdminUnitUIType";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("a9901a66-d58b-42c5-b270-d8f44a8fd449");
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
			if (Columns.FindByUId(new Guid("0f926530-df33-3920-f7fe-c5b29d9305e8")) == null) {
				Columns.Add(CreateFreedomUIEnabledColumn());
			}
			if (Columns.FindByUId(new Guid("750e78a0-a47e-c1a0-160a-fe44057866d5")) == null) {
				Columns.Add(CreateSysAdminUnitColumn());
			}
			if (Columns.FindByUId(new Guid("d960a20e-a500-c215-069e-a2ec0ce2be50")) == null) {
				Columns.Add(CreatePriorityColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateFreedomUIEnabledColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("0f926530-df33-3920-f7fe-c5b29d9305e8"),
				Name = @"FreedomUIEnabled",
				CreatedInSchemaUId = new Guid("2c6c3fbf-79e0-42d5-8a9f-3d14a5299fd8"),
				ModifiedInSchemaUId = new Guid("2c6c3fbf-79e0-42d5-8a9f-3d14a5299fd8"),
				CreatedInPackageId = new Guid("a9901a66-d58b-42c5-b270-d8f44a8fd449")
			};
		}

		protected virtual EntitySchemaColumn CreateSysAdminUnitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("750e78a0-a47e-c1a0-160a-fe44057866d5"),
				Name = @"SysAdminUnit",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("2c6c3fbf-79e0-42d5-8a9f-3d14a5299fd8"),
				ModifiedInSchemaUId = new Guid("2c6c3fbf-79e0-42d5-8a9f-3d14a5299fd8"),
				CreatedInPackageId = new Guid("a9901a66-d58b-42c5-b270-d8f44a8fd449")
			};
		}

		protected virtual EntitySchemaColumn CreatePriorityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("d960a20e-a500-c215-069e-a2ec0ce2be50"),
				Name = @"Priority",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("2c6c3fbf-79e0-42d5-8a9f-3d14a5299fd8"),
				ModifiedInSchemaUId = new Guid("2c6c3fbf-79e0-42d5-8a9f-3d14a5299fd8"),
				CreatedInPackageId = new Guid("a9901a66-d58b-42c5-b270-d8f44a8fd449"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"0"
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
			return new UISwitcherAdminUnitUIType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new UISwitcherAdminUnitUIType_CrtUISwitcherEventsProcess(userConnection);
		}

		public override object Clone() {
			return new UISwitcherAdminUnitUITypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new UISwitcherAdminUnitUITypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2c6c3fbf-79e0-42d5-8a9f-3d14a5299fd8"));
		}

		#endregion

	}

	#endregion

	#region Class: UISwitcherAdminUnitUIType

	/// <summary>
	/// UI type for system administration object.
	/// </summary>
	/// <remarks>
	/// Used in UI switcher process to store temporary data.
	/// </remarks>
	public class UISwitcherAdminUnitUIType : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public UISwitcherAdminUnitUIType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "UISwitcherAdminUnitUIType";
		}

		public UISwitcherAdminUnitUIType(UISwitcherAdminUnitUIType source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Freedom UI is enabled.
		/// </summary>
		public bool FreedomUIEnabled {
			get {
				return GetTypedColumnValue<bool>("FreedomUIEnabled");
			}
			set {
				SetColumnValue("FreedomUIEnabled", value);
			}
		}

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

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new UISwitcherAdminUnitUIType_CrtUISwitcherEventsProcess(UserConnection);
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
			return new UISwitcherAdminUnitUIType(this);
		}

		#endregion

	}

	#endregion

	#region Class: UISwitcherAdminUnitUIType_CrtUISwitcherEventsProcess

	/// <exclude/>
	public partial class UISwitcherAdminUnitUIType_CrtUISwitcherEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : UISwitcherAdminUnitUIType
	{

		public UISwitcherAdminUnitUIType_CrtUISwitcherEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "UISwitcherAdminUnitUIType_CrtUISwitcherEventsProcess";
			SchemaUId = new Guid("2c6c3fbf-79e0-42d5-8a9f-3d14a5299fd8");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("2c6c3fbf-79e0-42d5-8a9f-3d14a5299fd8");
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

	#region Class: UISwitcherAdminUnitUIType_CrtUISwitcherEventsProcess

	/// <exclude/>
	public class UISwitcherAdminUnitUIType_CrtUISwitcherEventsProcess : UISwitcherAdminUnitUIType_CrtUISwitcherEventsProcess<UISwitcherAdminUnitUIType>
	{

		public UISwitcherAdminUnitUIType_CrtUISwitcherEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: UISwitcherAdminUnitUIType_CrtUISwitcherEventsProcess

	public partial class UISwitcherAdminUnitUIType_CrtUISwitcherEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: UISwitcherAdminUnitUITypeEventsProcess

	/// <exclude/>
	public class UISwitcherAdminUnitUITypeEventsProcess : UISwitcherAdminUnitUIType_CrtUISwitcherEventsProcess
	{

		public UISwitcherAdminUnitUITypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

