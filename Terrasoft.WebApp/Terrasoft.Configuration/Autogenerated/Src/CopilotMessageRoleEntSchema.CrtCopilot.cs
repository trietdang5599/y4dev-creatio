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

	#region Class: CopilotMessageRoleEntSchema

	/// <exclude/>
	public class CopilotMessageRoleEntSchema : Terrasoft.Configuration.BaseCodeLookupSchema
	{

		#region Constructors: Public

		public CopilotMessageRoleEntSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CopilotMessageRoleEntSchema(CopilotMessageRoleEntSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CopilotMessageRoleEntSchema(CopilotMessageRoleEntSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0b692a14-a874-4feb-848d-5efa3b022184");
			RealUId = new Guid("0b692a14-a874-4feb-848d-5efa3b022184");
			Name = "CopilotMessageRoleEnt";
			ParentSchemaUId = new Guid("2681062b-df59-4e52-89ed-f9b7dc909ab2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("7a3a8162-4be1-46b5-bd50-b3efc2df6d2e");
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
			return new CopilotMessageRoleEnt(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CopilotMessageRoleEnt_CrtCopilotEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CopilotMessageRoleEntSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CopilotMessageRoleEntSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0b692a14-a874-4feb-848d-5efa3b022184"));
		}

		#endregion

	}

	#endregion

	#region Class: CopilotMessageRoleEnt

	/// <summary>
	/// Creatio.ai Message role.
	/// </summary>
	public class CopilotMessageRoleEnt : Terrasoft.Configuration.BaseCodeLookup
	{

		#region Constructors: Public

		public CopilotMessageRoleEnt(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CopilotMessageRoleEnt";
		}

		public CopilotMessageRoleEnt(CopilotMessageRoleEnt source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CopilotMessageRoleEnt_CrtCopilotEventsProcess(UserConnection);
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
			return new CopilotMessageRoleEnt(this);
		}

		#endregion

	}

	#endregion

	#region Class: CopilotMessageRoleEnt_CrtCopilotEventsProcess

	/// <exclude/>
	public partial class CopilotMessageRoleEnt_CrtCopilotEventsProcess<TEntity> : Terrasoft.Configuration.BaseCodeLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : CopilotMessageRoleEnt
	{

		public CopilotMessageRoleEnt_CrtCopilotEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CopilotMessageRoleEnt_CrtCopilotEventsProcess";
			SchemaUId = new Guid("0b692a14-a874-4feb-848d-5efa3b022184");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("0b692a14-a874-4feb-848d-5efa3b022184");
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

	#region Class: CopilotMessageRoleEnt_CrtCopilotEventsProcess

	/// <exclude/>
	public class CopilotMessageRoleEnt_CrtCopilotEventsProcess : CopilotMessageRoleEnt_CrtCopilotEventsProcess<CopilotMessageRoleEnt>
	{

		public CopilotMessageRoleEnt_CrtCopilotEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CopilotMessageRoleEnt_CrtCopilotEventsProcess

	public partial class CopilotMessageRoleEnt_CrtCopilotEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CopilotMessageRoleEntEventsProcess

	/// <exclude/>
	public class CopilotMessageRoleEntEventsProcess : CopilotMessageRoleEnt_CrtCopilotEventsProcess
	{

		public CopilotMessageRoleEntEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

