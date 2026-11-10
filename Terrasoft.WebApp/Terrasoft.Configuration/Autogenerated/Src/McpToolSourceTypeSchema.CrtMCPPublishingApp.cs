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

	#region Class: McpToolSourceTypeSchema

	/// <exclude/>
	public class McpToolSourceTypeSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public McpToolSourceTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public McpToolSourceTypeSchema(McpToolSourceTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public McpToolSourceTypeSchema(McpToolSourceTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d87b3d88-cd9f-44ef-8d5a-0a42e60e5274");
			RealUId = new Guid("d87b3d88-cd9f-44ef-8d5a-0a42e60e5274");
			Name = "McpToolSourceType";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("27bb82a7-2806-4989-bfe6-ec4e3982c003");
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
			return new McpToolSourceType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new McpToolSourceType_CrtMCPPublishingAppEventsProcess(userConnection);
		}

		public override object Clone() {
			return new McpToolSourceTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new McpToolSourceTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d87b3d88-cd9f-44ef-8d5a-0a42e60e5274"));
		}

		#endregion

	}

	#endregion

	#region Class: McpToolSourceType

	/// <summary>
	/// MCP Tool Source Type.
	/// </summary>
	public class McpToolSourceType : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public McpToolSourceType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "McpToolSourceType";
		}

		public McpToolSourceType(McpToolSourceType source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new McpToolSourceType_CrtMCPPublishingAppEventsProcess(UserConnection);
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
			return new McpToolSourceType(this);
		}

		#endregion

	}

	#endregion

	#region Class: McpToolSourceType_CrtMCPPublishingAppEventsProcess

	/// <exclude/>
	public partial class McpToolSourceType_CrtMCPPublishingAppEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : McpToolSourceType
	{

		public McpToolSourceType_CrtMCPPublishingAppEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "McpToolSourceType_CrtMCPPublishingAppEventsProcess";
			SchemaUId = new Guid("d87b3d88-cd9f-44ef-8d5a-0a42e60e5274");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("d87b3d88-cd9f-44ef-8d5a-0a42e60e5274");
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

	#region Class: McpToolSourceType_CrtMCPPublishingAppEventsProcess

	/// <exclude/>
	public class McpToolSourceType_CrtMCPPublishingAppEventsProcess : McpToolSourceType_CrtMCPPublishingAppEventsProcess<McpToolSourceType>
	{

		public McpToolSourceType_CrtMCPPublishingAppEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: McpToolSourceType_CrtMCPPublishingAppEventsProcess

	public partial class McpToolSourceType_CrtMCPPublishingAppEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: McpToolSourceTypeEventsProcess

	/// <exclude/>
	public class McpToolSourceTypeEventsProcess : McpToolSourceType_CrtMCPPublishingAppEventsProcess
	{

		public McpToolSourceTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

