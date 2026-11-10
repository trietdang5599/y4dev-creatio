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

	#region Class: SysCronTriggerStateSchema

	/// <exclude/>
	public class SysCronTriggerStateSchema : Terrasoft.Configuration.SysCodeLookupSchema
	{

		#region Constructors: Public

		public SysCronTriggerStateSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysCronTriggerStateSchema(SysCronTriggerStateSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysCronTriggerStateSchema(SysCronTriggerStateSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b66ce7af-f391-4504-a6e5-552ba42f2016");
			RealUId = new Guid("b66ce7af-f391-4504-a6e5-552ba42f2016");
			Name = "SysCronTriggerState";
			ParentSchemaUId = new Guid("28699730-9cf0-4702-87a9-c64d612e4b14");
			ExtendParent = false;
			CreatedInPackageId = new Guid("79d5e1e4-18af-4001-8dc1-26f09fca92c2");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysCronTriggerState(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysCronTriggerState_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysCronTriggerStateSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysCronTriggerStateSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b66ce7af-f391-4504-a6e5-552ba42f2016"));
		}

		#endregion

	}

	#endregion

	#region Class: SysCronTriggerState

	/// <summary>
	/// Cron trigger state lookup.
	/// </summary>
	public class SysCronTriggerState : Terrasoft.Configuration.SysCodeLookup
	{

		#region Constructors: Public

		public SysCronTriggerState(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysCronTriggerState";
		}

		public SysCronTriggerState(SysCronTriggerState source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysCronTriggerState_CrtBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysCronTriggerStateDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysCronTriggerState(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysCronTriggerState_CrtBaseEventsProcess

	/// <exclude/>
	public partial class SysCronTriggerState_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.SysCodeLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysCronTriggerState
	{

		public SysCronTriggerState_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysCronTriggerState_CrtBaseEventsProcess";
			SchemaUId = new Guid("b66ce7af-f391-4504-a6e5-552ba42f2016");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("b66ce7af-f391-4504-a6e5-552ba42f2016");
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

	#region Class: SysCronTriggerState_CrtBaseEventsProcess

	/// <exclude/>
	public class SysCronTriggerState_CrtBaseEventsProcess : SysCronTriggerState_CrtBaseEventsProcess<SysCronTriggerState>
	{

		public SysCronTriggerState_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysCronTriggerState_CrtBaseEventsProcess

	public partial class SysCronTriggerState_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysCronTriggerStateEventsProcess

	/// <exclude/>
	public class SysCronTriggerStateEventsProcess : SysCronTriggerState_CrtBaseEventsProcess
	{

		public SysCronTriggerStateEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

