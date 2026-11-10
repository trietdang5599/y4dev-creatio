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

	#region Class: SysPluginPackageStatusSchema

	/// <exclude/>
	public class SysPluginPackageStatusSchema : Terrasoft.Configuration.BaseCodeLookupSchema
	{

		#region Constructors: Public

		public SysPluginPackageStatusSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysPluginPackageStatusSchema(SysPluginPackageStatusSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysPluginPackageStatusSchema(SysPluginPackageStatusSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("2fc5cf81-9713-4d54-8f05-8883ade66f7f");
			RealUId = new Guid("2fc5cf81-9713-4d54-8f05-8883ade66f7f");
			Name = "SysPluginPackageStatus";
			ParentSchemaUId = new Guid("2681062b-df59-4e52-89ed-f9b7dc909ab2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723");
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
			return new SysPluginPackageStatus(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysPluginPackageStatus_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysPluginPackageStatusSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysPluginPackageStatusSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2fc5cf81-9713-4d54-8f05-8883ade66f7f"));
		}

		#endregion

	}

	#endregion

	#region Class: SysPluginPackageStatus

	/// <summary>
	/// Plugin package status.
	/// </summary>
	public class SysPluginPackageStatus : Terrasoft.Configuration.BaseCodeLookup
	{

		#region Constructors: Public

		public SysPluginPackageStatus(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysPluginPackageStatus";
		}

		public SysPluginPackageStatus(SysPluginPackageStatus source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysPluginPackageStatus_CrtBaseEventsProcess(UserConnection);
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
			return new SysPluginPackageStatus(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysPluginPackageStatus_CrtBaseEventsProcess

	/// <exclude/>
	public partial class SysPluginPackageStatus_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseCodeLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysPluginPackageStatus
	{

		public SysPluginPackageStatus_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysPluginPackageStatus_CrtBaseEventsProcess";
			SchemaUId = new Guid("2fc5cf81-9713-4d54-8f05-8883ade66f7f");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("2fc5cf81-9713-4d54-8f05-8883ade66f7f");
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

	#region Class: SysPluginPackageStatus_CrtBaseEventsProcess

	/// <exclude/>
	public class SysPluginPackageStatus_CrtBaseEventsProcess : SysPluginPackageStatus_CrtBaseEventsProcess<SysPluginPackageStatus>
	{

		public SysPluginPackageStatus_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysPluginPackageStatus_CrtBaseEventsProcess

	public partial class SysPluginPackageStatus_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysPluginPackageStatusEventsProcess

	/// <exclude/>
	public class SysPluginPackageStatusEventsProcess : SysPluginPackageStatus_CrtBaseEventsProcess
	{

		public SysPluginPackageStatusEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

