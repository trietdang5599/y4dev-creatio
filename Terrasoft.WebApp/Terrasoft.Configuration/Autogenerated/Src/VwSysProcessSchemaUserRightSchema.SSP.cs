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

	#region Class: VwSysProcessSchemaUserRightSchema

	/// <exclude/>
	public class VwSysProcessSchemaUserRightSchema : Terrasoft.Configuration.VwSysProcessSchemaUserRight_CrtBase_CreatioSchema
	{

		#region Constructors: Public

		public VwSysProcessSchemaUserRightSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwSysProcessSchemaUserRightSchema(VwSysProcessSchemaUserRightSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwSysProcessSchemaUserRightSchema(VwSysProcessSchemaUserRightSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("5f64cfb8-eb9d-45df-87ba-6ea6927d762c");
			Name = "VwSysProcessSchemaUserRight";
			ParentSchemaUId = new Guid("a105b9c7-5ec0-40c3-9e0f-e32b7465b7b0");
			ExtendParent = true;
			CreatedInPackageId = new Guid("7cc31540-fa76-4c79-9b86-a6eabd8e662c");
			IsDBView = true;
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
			return new VwSysProcessSchemaUserRight(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwSysProcessSchemaUserRight_SSPEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwSysProcessSchemaUserRightSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwSysProcessSchemaUserRightSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5f64cfb8-eb9d-45df-87ba-6ea6927d762c"));
		}

		#endregion

	}

	#endregion

	#region Class: VwSysProcessSchemaUserRight

	/// <summary>
	/// VwSysProcessSchemaUserRight.
	/// </summary>
	public class VwSysProcessSchemaUserRight : Terrasoft.Configuration.VwSysProcessSchemaUserRight_CrtBase_Creatio
	{

		#region Constructors: Public

		public VwSysProcessSchemaUserRight(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwSysProcessSchemaUserRight";
		}

		public VwSysProcessSchemaUserRight(VwSysProcessSchemaUserRight source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwSysProcessSchemaUserRight_SSPEventsProcess(UserConnection);
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
			return new VwSysProcessSchemaUserRight(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwSysProcessSchemaUserRight_SSPEventsProcess

	/// <exclude/>
	public partial class VwSysProcessSchemaUserRight_SSPEventsProcess<TEntity> : Terrasoft.Configuration.VwSysProcessSchemaUserRight_CrtBaseEventsProcess<TEntity> where TEntity : VwSysProcessSchemaUserRight
	{

		public VwSysProcessSchemaUserRight_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwSysProcessSchemaUserRight_SSPEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("5f64cfb8-eb9d-45df-87ba-6ea6927d762c");
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

	#region Class: VwSysProcessSchemaUserRight_SSPEventsProcess

	/// <exclude/>
	public class VwSysProcessSchemaUserRight_SSPEventsProcess : VwSysProcessSchemaUserRight_SSPEventsProcess<VwSysProcessSchemaUserRight>
	{

		public VwSysProcessSchemaUserRight_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwSysProcessSchemaUserRight_SSPEventsProcess

	public partial class VwSysProcessSchemaUserRight_SSPEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwSysProcessSchemaUserRightEventsProcess

	/// <exclude/>
	public class VwSysProcessSchemaUserRightEventsProcess : VwSysProcessSchemaUserRight_SSPEventsProcess
	{

		public VwSysProcessSchemaUserRightEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

