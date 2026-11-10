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

	#region Class: SysPrcEntityHistorySchema

	/// <exclude/>
	public class SysPrcEntityHistorySchema : Terrasoft.Configuration.SysBaseProcessEntitySchema
	{

		#region Constructors: Public

		public SysPrcEntityHistorySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysPrcEntityHistorySchema(SysPrcEntityHistorySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysPrcEntityHistorySchema(SysPrcEntityHistorySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("3ff70cac-48aa-48e2-9b39-76952e10a18e");
			RealUId = new Guid("3ff70cac-48aa-48e2-9b39-76952e10a18e");
			Name = "SysPrcEntityHistory";
			ParentSchemaUId = new Guid("60a89d9d-9ede-4d78-97b9-5e20373db518");
			ExtendParent = false;
			CreatedInPackageId = new Guid("db484552-1edf-492e-83ab-076c107943f4");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("f72f4a90-4d85-4337-bdfe-45ef7904c759")) == null) {
				Columns.Add(CreateSysProcessColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysProcessColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("f72f4a90-4d85-4337-bdfe-45ef7904c759"),
				Name = @"SysProcess",
				ReferenceSchemaUId = new Guid("c8cd120d-c91b-4104-bad0-88b1b892a49d"),
				IsIndexed = true,
				IsWeakReference = true,
				CreatedInSchemaUId = new Guid("3ff70cac-48aa-48e2-9b39-76952e10a18e"),
				ModifiedInSchemaUId = new Guid("3ff70cac-48aa-48e2-9b39-76952e10a18e"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysPrcEntityHistory(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysPrcEntityHistory_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysPrcEntityHistorySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysPrcEntityHistorySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3ff70cac-48aa-48e2-9b39-76952e10a18e"));
		}

		#endregion

	}

	#endregion

	#region Class: SysPrcEntityHistory

	/// <summary>
	/// System process entity history.
	/// </summary>
	public class SysPrcEntityHistory : Terrasoft.Configuration.SysBaseProcessEntity
	{

		#region Constructors: Public

		public SysPrcEntityHistory(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysPrcEntityHistory";
		}

		public SysPrcEntityHistory(SysPrcEntityHistory source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SysProcessId {
			get {
				return GetTypedColumnValue<Guid>("SysProcessId");
			}
			set {
				SetColumnValue("SysProcessId", value);
				_sysProcess = null;
			}
		}

		/// <exclude/>
		public string SysProcessName {
			get {
				return GetTypedColumnValue<string>("SysProcessName");
			}
			set {
				SetColumnValue("SysProcessName", value);
				if (_sysProcess != null) {
					_sysProcess.Name = value;
				}
			}
		}

		private SysPrcHistoryLog _sysProcess;
		/// <summary>
		/// Process.
		/// </summary>
		public SysPrcHistoryLog SysProcess {
			get {
				return _sysProcess ??
					(_sysProcess = LookupColumnEntities.GetEntity("SysProcess") as SysPrcHistoryLog);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysPrcEntityHistory_CrtBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysPrcEntityHistoryDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysPrcEntityHistoryDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysPrcEntityHistoryInserted", e);
			Inserting += (s, e) => ThrowEvent("SysPrcEntityHistoryInserting", e);
			Saved += (s, e) => ThrowEvent("SysPrcEntityHistorySaved", e);
			Saving += (s, e) => ThrowEvent("SysPrcEntityHistorySaving", e);
			Validating += (s, e) => ThrowEvent("SysPrcEntityHistoryValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysPrcEntityHistory(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysPrcEntityHistory_CrtBaseEventsProcess

	/// <exclude/>
	public partial class SysPrcEntityHistory_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.SysBaseProcessEntity_CrtBaseEventsProcess<TEntity> where TEntity : SysPrcEntityHistory
	{

		public SysPrcEntityHistory_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysPrcEntityHistory_CrtBaseEventsProcess";
			SchemaUId = new Guid("3ff70cac-48aa-48e2-9b39-76952e10a18e");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("3ff70cac-48aa-48e2-9b39-76952e10a18e");
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

	#region Class: SysPrcEntityHistory_CrtBaseEventsProcess

	/// <exclude/>
	public class SysPrcEntityHistory_CrtBaseEventsProcess : SysPrcEntityHistory_CrtBaseEventsProcess<SysPrcEntityHistory>
	{

		public SysPrcEntityHistory_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysPrcEntityHistory_CrtBaseEventsProcess

	public partial class SysPrcEntityHistory_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysPrcEntityHistoryEventsProcess

	/// <exclude/>
	public class SysPrcEntityHistoryEventsProcess : SysPrcEntityHistory_CrtBaseEventsProcess
	{

		public SysPrcEntityHistoryEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

