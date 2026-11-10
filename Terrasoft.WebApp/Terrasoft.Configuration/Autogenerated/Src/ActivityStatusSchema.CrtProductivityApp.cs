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

	#region Class: ActivityStatusSchema

	/// <exclude/>
	public class ActivityStatusSchema : Terrasoft.Configuration.ActivityStatus_CrtCoreBase_CreatioSchema
	{

		#region Constructors: Public

		public ActivityStatusSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ActivityStatusSchema(ActivityStatusSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ActivityStatusSchema(ActivityStatusSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("304ac55b-d782-4c0c-847c-8837f1b929dd");
			Name = "ActivityStatus";
			ParentSchemaUId = new Guid("805aace4-8604-40e7-a9eb-0f54174593c0");
			ExtendParent = true;
			CreatedInPackageId = new Guid("1d4adbb8-703e-4da2-8aea-e164a0dad03c");
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

		protected override void InitializePrimaryColorColumn() {
			base.InitializePrimaryColorColumn();
			PrimaryColorColumn = CreateColorColumn();
			if (Columns.FindByUId(PrimaryColorColumn.UId) == null) {
				Columns.Add(PrimaryColorColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected virtual EntitySchemaColumn CreateColorColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Color")) {
				UId = new Guid("983558da-75f4-7893-546c-1bc635f595c7"),
				Name = @"Color",
				CreatedInSchemaUId = new Guid("304ac55b-d782-4c0c-847c-8837f1b929dd"),
				ModifiedInSchemaUId = new Guid("304ac55b-d782-4c0c-847c-8837f1b929dd"),
				CreatedInPackageId = new Guid("1d4adbb8-703e-4da2-8aea-e164a0dad03c")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ActivityStatus(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ActivityStatus_CrtProductivityAppEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ActivityStatusSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ActivityStatusSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("304ac55b-d782-4c0c-847c-8837f1b929dd"));
		}

		#endregion

	}

	#endregion

	#region Class: ActivityStatus

	/// <summary>
	/// Activity status.
	/// </summary>
	public class ActivityStatus : Terrasoft.Configuration.ActivityStatus_CrtCoreBase_Creatio
	{

		#region Constructors: Public

		public ActivityStatus(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ActivityStatus";
		}

		public ActivityStatus(ActivityStatus source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Color.
		/// </summary>
		public Color Color {
			get {
				return GetTypedColumnValue<Color>("Color");
			}
			set {
				SetColumnValue("Color", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ActivityStatus_CrtProductivityAppEventsProcess(UserConnection);
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
			return new ActivityStatus(this);
		}

		#endregion

	}

	#endregion

	#region Class: ActivityStatus_CrtProductivityAppEventsProcess

	/// <exclude/>
	public partial class ActivityStatus_CrtProductivityAppEventsProcess<TEntity> : Terrasoft.Configuration.ActivityStatus_CrtCoreBaseEventsProcess<TEntity> where TEntity : ActivityStatus
	{

		public ActivityStatus_CrtProductivityAppEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ActivityStatus_CrtProductivityAppEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("304ac55b-d782-4c0c-847c-8837f1b929dd");
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

	#region Class: ActivityStatus_CrtProductivityAppEventsProcess

	/// <exclude/>
	public class ActivityStatus_CrtProductivityAppEventsProcess : ActivityStatus_CrtProductivityAppEventsProcess<ActivityStatus>
	{

		public ActivityStatus_CrtProductivityAppEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ActivityStatus_CrtProductivityAppEventsProcess

	public partial class ActivityStatus_CrtProductivityAppEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ActivityStatusEventsProcess

	/// <exclude/>
	public class ActivityStatusEventsProcess : ActivityStatus_CrtProductivityAppEventsProcess
	{

		public ActivityStatusEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

