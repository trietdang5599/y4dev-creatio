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

	#region Class: RunButtonProcessListSchema

	/// <exclude/>
	public class RunButtonProcessListSchema : Terrasoft.Configuration.RunButtonProcessList_CrtBase_CreatioSchema
	{

		#region Constructors: Public

		public RunButtonProcessListSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public RunButtonProcessListSchema(RunButtonProcessListSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public RunButtonProcessListSchema(RunButtonProcessListSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("ffa2c4ad-cd73-47bd-851f-071936d45c3f");
			Name = "RunButtonProcessList";
			ParentSchemaUId = new Guid("9d6c6255-e35d-4af0-9e20-85feff01e245");
			ExtendParent = true;
			CreatedInPackageId = new Guid("7cc31540-fa76-4c79-9b86-a6eabd8e662c");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = false;
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
			return new RunButtonProcessList(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new RunButtonProcessList_SSPEventsProcess(userConnection);
		}

		public override object Clone() {
			return new RunButtonProcessListSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new RunButtonProcessListSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ffa2c4ad-cd73-47bd-851f-071936d45c3f"));
		}

		#endregion

	}

	#endregion

	#region Class: RunButtonProcessList

	/// <summary>
	/// Run process button list setup.
	/// </summary>
	/// <remarks>
	/// Run process button list setup.
	/// </remarks>
	public class RunButtonProcessList : Terrasoft.Configuration.RunButtonProcessList_CrtBase_Creatio
	{

		#region Constructors: Public

		public RunButtonProcessList(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "RunButtonProcessList";
		}

		public RunButtonProcessList(RunButtonProcessList source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new RunButtonProcessList_SSPEventsProcess(UserConnection);
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
			return new RunButtonProcessList(this);
		}

		#endregion

	}

	#endregion

	#region Class: RunButtonProcessList_SSPEventsProcess

	/// <exclude/>
	public partial class RunButtonProcessList_SSPEventsProcess<TEntity> : Terrasoft.Configuration.RunButtonProcessList_CrtBaseEventsProcess<TEntity> where TEntity : RunButtonProcessList
	{

		public RunButtonProcessList_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "RunButtonProcessList_SSPEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ffa2c4ad-cd73-47bd-851f-071936d45c3f");
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

	#region Class: RunButtonProcessList_SSPEventsProcess

	/// <exclude/>
	public class RunButtonProcessList_SSPEventsProcess : RunButtonProcessList_SSPEventsProcess<RunButtonProcessList>
	{

		public RunButtonProcessList_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: RunButtonProcessList_SSPEventsProcess

	public partial class RunButtonProcessList_SSPEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: RunButtonProcessListEventsProcess

	/// <exclude/>
	public class RunButtonProcessListEventsProcess : RunButtonProcessList_SSPEventsProcess
	{

		public RunButtonProcessListEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

