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

	#region Class: SysInstalledAppStatusSchema

	/// <exclude/>
	public class SysInstalledAppStatusSchema : Terrasoft.Configuration.SysCodeLookupSchema
	{

		#region Constructors: Public

		public SysInstalledAppStatusSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysInstalledAppStatusSchema(SysInstalledAppStatusSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysInstalledAppStatusSchema(SysInstalledAppStatusSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7f5115ca-22b4-42ee-b01d-c8846c1a6fa9");
			RealUId = new Guid("7f5115ca-22b4-42ee-b01d-c8846c1a6fa9");
			Name = "SysInstalledAppStatus";
			ParentSchemaUId = new Guid("28699730-9cf0-4702-87a9-c64d612e4b14");
			ExtendParent = false;
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
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
			return new SysInstalledAppStatus(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysInstalledAppStatus_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysInstalledAppStatusSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysInstalledAppStatusSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7f5115ca-22b4-42ee-b01d-c8846c1a6fa9"));
		}

		#endregion

	}

	#endregion

	#region Class: SysInstalledAppStatus

	/// <summary>
	/// Application status.
	/// </summary>
	public class SysInstalledAppStatus : Terrasoft.Configuration.SysCodeLookup
	{

		#region Constructors: Public

		public SysInstalledAppStatus(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysInstalledAppStatus";
		}

		public SysInstalledAppStatus(SysInstalledAppStatus source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysInstalledAppStatus_CrtBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysInstalledAppStatusDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysInstalledAppStatus(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysInstalledAppStatus_CrtBaseEventsProcess

	/// <exclude/>
	public partial class SysInstalledAppStatus_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.SysCodeLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysInstalledAppStatus
	{

		public SysInstalledAppStatus_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysInstalledAppStatus_CrtBaseEventsProcess";
			SchemaUId = new Guid("7f5115ca-22b4-42ee-b01d-c8846c1a6fa9");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("7f5115ca-22b4-42ee-b01d-c8846c1a6fa9");
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

	#region Class: SysInstalledAppStatus_CrtBaseEventsProcess

	/// <exclude/>
	public class SysInstalledAppStatus_CrtBaseEventsProcess : SysInstalledAppStatus_CrtBaseEventsProcess<SysInstalledAppStatus>
	{

		public SysInstalledAppStatus_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysInstalledAppStatus_CrtBaseEventsProcess

	public partial class SysInstalledAppStatus_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysInstalledAppStatusEventsProcess

	/// <exclude/>
	public class SysInstalledAppStatusEventsProcess : SysInstalledAppStatus_CrtBaseEventsProcess
	{

		public SysInstalledAppStatusEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

