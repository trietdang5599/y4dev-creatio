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

	#region Class: McpSourceCodeActionSchema

	/// <exclude/>
	[IsVirtual]
	public class McpSourceCodeActionSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public McpSourceCodeActionSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public McpSourceCodeActionSchema(McpSourceCodeActionSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public McpSourceCodeActionSchema(McpSourceCodeActionSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("2a1bc12f-49bc-421c-947d-510fdf720047");
			RealUId = new Guid("2a1bc12f-49bc-421c-947d-510fdf720047");
			Name = "McpSourceCodeAction";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("c16fbbdb-b12b-4fa8-8373-0b94f943be24");
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

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateNameColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("92214a93-293c-0512-85ce-cb99a49aecbe")) == null) {
				Columns.Add(CreateDescriptionColumn());
			}
			if (Columns.FindByUId(new Guid("60a865cb-e1da-8957-3b29-432762dc0d48")) == null) {
				Columns.Add(CreateFullTypeNameColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("195b295b-8992-4e2a-b1b9-3dc856166c57"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("2a1bc12f-49bc-421c-947d-510fdf720047"),
				ModifiedInSchemaUId = new Guid("2a1bc12f-49bc-421c-947d-510fdf720047"),
				CreatedInPackageId = new Guid("c16fbbdb-b12b-4fa8-8373-0b94f943be24")
			};
		}

		protected virtual EntitySchemaColumn CreateDescriptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("92214a93-293c-0512-85ce-cb99a49aecbe"),
				Name = @"Description",
				CreatedInSchemaUId = new Guid("2a1bc12f-49bc-421c-947d-510fdf720047"),
				ModifiedInSchemaUId = new Guid("2a1bc12f-49bc-421c-947d-510fdf720047"),
				CreatedInPackageId = new Guid("c16fbbdb-b12b-4fa8-8373-0b94f943be24")
			};
		}

		protected virtual EntitySchemaColumn CreateFullTypeNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("60a865cb-e1da-8957-3b29-432762dc0d48"),
				Name = @"FullTypeName",
				CreatedInSchemaUId = new Guid("2a1bc12f-49bc-421c-947d-510fdf720047"),
				ModifiedInSchemaUId = new Guid("2a1bc12f-49bc-421c-947d-510fdf720047"),
				CreatedInPackageId = new Guid("c16fbbdb-b12b-4fa8-8373-0b94f943be24")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new McpSourceCodeAction(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new McpSourceCodeAction_CrtMCPPublishingAppEventsProcess(userConnection);
		}

		public override object Clone() {
			return new McpSourceCodeActionSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new McpSourceCodeActionSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2a1bc12f-49bc-421c-947d-510fdf720047"));
		}

		#endregion

	}

	#endregion

	#region Class: McpSourceCodeAction

	/// <summary>
	/// Mcp source code action.
	/// </summary>
	public class McpSourceCodeAction : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public McpSourceCodeAction(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "McpSourceCodeAction";
		}

		public McpSourceCodeAction(McpSourceCodeAction source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Name.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		/// <summary>
		/// Description.
		/// </summary>
		public string Description {
			get {
				return GetTypedColumnValue<string>("Description");
			}
			set {
				SetColumnValue("Description", value);
			}
		}

		/// <summary>
		/// FullTypeName.
		/// </summary>
		public string FullTypeName {
			get {
				return GetTypedColumnValue<string>("FullTypeName");
			}
			set {
				SetColumnValue("FullTypeName", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new McpSourceCodeAction_CrtMCPPublishingAppEventsProcess(UserConnection);
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
			return new McpSourceCodeAction(this);
		}

		#endregion

	}

	#endregion

	#region Class: McpSourceCodeAction_CrtMCPPublishingAppEventsProcess

	/// <exclude/>
	public partial class McpSourceCodeAction_CrtMCPPublishingAppEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : McpSourceCodeAction
	{

		public McpSourceCodeAction_CrtMCPPublishingAppEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "McpSourceCodeAction_CrtMCPPublishingAppEventsProcess";
			SchemaUId = new Guid("2a1bc12f-49bc-421c-947d-510fdf720047");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("2a1bc12f-49bc-421c-947d-510fdf720047");
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

	#region Class: McpSourceCodeAction_CrtMCPPublishingAppEventsProcess

	/// <exclude/>
	public class McpSourceCodeAction_CrtMCPPublishingAppEventsProcess : McpSourceCodeAction_CrtMCPPublishingAppEventsProcess<McpSourceCodeAction>
	{

		public McpSourceCodeAction_CrtMCPPublishingAppEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: McpSourceCodeAction_CrtMCPPublishingAppEventsProcess

	public partial class McpSourceCodeAction_CrtMCPPublishingAppEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: McpSourceCodeActionEventsProcess

	/// <exclude/>
	public class McpSourceCodeActionEventsProcess : McpSourceCodeAction_CrtMCPPublishingAppEventsProcess
	{

		public McpSourceCodeActionEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

