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

	#region Class: CopilotSysCapabilitySchema

	/// <exclude/>
	[IsVirtual]
	public class CopilotSysCapabilitySchema : Terrasoft.Configuration.CopilotIntentSchema
	{

		#region Constructors: Public

		public CopilotSysCapabilitySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CopilotSysCapabilitySchema(CopilotSysCapabilitySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CopilotSysCapabilitySchema(CopilotSysCapabilitySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0e89508c-e004-4249-8b37-be406cfadbc1");
			RealUId = new Guid("0e89508c-e004-4249-8b37-be406cfadbc1");
			Name = "CopilotSysCapability";
			ParentSchemaUId = new Guid("7cd7a99a-b22e-4e50-af02-6ee4ac8612ec");
			ExtendParent = false;
			CreatedInPackageId = new Guid("c23dfaf0-0051-4966-86f8-cbe8197258d0");
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
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new CopilotSysCapability(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CopilotSysCapability_CrtCopilotEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CopilotSysCapabilitySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CopilotSysCapabilitySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0e89508c-e004-4249-8b37-be406cfadbc1"));
		}

		#endregion

	}

	#endregion

	#region Class: CopilotSysCapability

	/// <summary>
	/// Creatio.ai system capability.
	/// </summary>
	public class CopilotSysCapability : Terrasoft.Configuration.CopilotIntent
	{

		#region Constructors: Public

		public CopilotSysCapability(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CopilotSysCapability";
		}

		public CopilotSysCapability(CopilotSysCapability source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CopilotSysCapability_CrtCopilotEventsProcess(UserConnection);
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
			return new CopilotSysCapability(this);
		}

		#endregion

	}

	#endregion

	#region Class: CopilotSysCapability_CrtCopilotEventsProcess

	/// <exclude/>
	public partial class CopilotSysCapability_CrtCopilotEventsProcess<TEntity> : Terrasoft.Configuration.CopilotIntent_CrtCopilotEventsProcess<TEntity> where TEntity : CopilotSysCapability
	{

		public CopilotSysCapability_CrtCopilotEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CopilotSysCapability_CrtCopilotEventsProcess";
			SchemaUId = new Guid("0e89508c-e004-4249-8b37-be406cfadbc1");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("0e89508c-e004-4249-8b37-be406cfadbc1");
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

	#region Class: CopilotSysCapability_CrtCopilotEventsProcess

	/// <exclude/>
	public class CopilotSysCapability_CrtCopilotEventsProcess : CopilotSysCapability_CrtCopilotEventsProcess<CopilotSysCapability>
	{

		public CopilotSysCapability_CrtCopilotEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CopilotSysCapability_CrtCopilotEventsProcess

	public partial class CopilotSysCapability_CrtCopilotEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CopilotSysCapabilityEventsProcess

	/// <exclude/>
	public class CopilotSysCapabilityEventsProcess : CopilotSysCapability_CrtCopilotEventsProcess
	{

		public CopilotSysCapabilityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

