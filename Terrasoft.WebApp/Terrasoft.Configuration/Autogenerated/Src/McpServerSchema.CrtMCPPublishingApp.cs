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

	#region Class: McpServerSchema

	/// <exclude/>
	public class McpServerSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public McpServerSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public McpServerSchema(McpServerSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public McpServerSchema(McpServerSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateCode_Unique_IndexIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = true
			};
			index.UId = new Guid("7c54d928-46a7-c150-ce4d-a7c907aaeca7");
			index.Name = "Code_Unique_Index";
			index.CreatedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			index.ModifiedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			index.CreatedInPackageId = new Guid("76c4ad3d-328b-49d6-bd5e-eaf12305041a");
			EntitySchemaIndexColumn codeIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("d2f0db38-333d-dc47-d9d3-ffe0625c1393"),
				ColumnUId = new Guid("e61a713d-8385-ac01-386d-45d4372e65ca"),
				CreatedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				ModifiedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				CreatedInPackageId = new Guid("76c4ad3d-328b-49d6-bd5e-eaf12305041a"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(codeIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4cb13ab9-dbdd-400b-b2af-11d421901b6d");
			RealUId = new Guid("4cb13ab9-dbdd-400b-b2af-11d421901b6d");
			Name = "McpServer";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("76c4ad3d-328b-49d6-bd5e-eaf12305041a");
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
			if (Columns.FindByUId(new Guid("9bb19ab2-c3f3-7776-de15-4f19e341e2d4")) == null) {
				Columns.Add(CreateIsOnlineColumn());
			}
			if (Columns.FindByUId(new Guid("2e4bd670-e01c-0b39-336f-0a3f8acc7c54")) == null) {
				Columns.Add(CreateDescriptionColumn());
			}
			if (Columns.FindByUId(new Guid("e61a713d-8385-ac01-386d-45d4372e65ca")) == null) {
				Columns.Add(CreateCodeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateIsOnlineColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("9bb19ab2-c3f3-7776-de15-4f19e341e2d4"),
				Name = @"IsOnline",
				CreatedInSchemaUId = new Guid("4cb13ab9-dbdd-400b-b2af-11d421901b6d"),
				ModifiedInSchemaUId = new Guid("4cb13ab9-dbdd-400b-b2af-11d421901b6d"),
				CreatedInPackageId = new Guid("76c4ad3d-328b-49d6-bd5e-eaf12305041a"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"False"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateDescriptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("2e4bd670-e01c-0b39-336f-0a3f8acc7c54"),
				Name = @"Description",
				CreatedInSchemaUId = new Guid("4cb13ab9-dbdd-400b-b2af-11d421901b6d"),
				ModifiedInSchemaUId = new Guid("4cb13ab9-dbdd-400b-b2af-11d421901b6d"),
				CreatedInPackageId = new Guid("76c4ad3d-328b-49d6-bd5e-eaf12305041a")
			};
		}

		protected virtual EntitySchemaColumn CreateCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("e61a713d-8385-ac01-386d-45d4372e65ca"),
				Name = @"Code",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("4cb13ab9-dbdd-400b-b2af-11d421901b6d"),
				ModifiedInSchemaUId = new Guid("4cb13ab9-dbdd-400b-b2af-11d421901b6d"),
				CreatedInPackageId = new Guid("76c4ad3d-328b-49d6-bd5e-eaf12305041a")
			};
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("6e7aa22e-fa36-4cc1-a802-99fd32d9ae1c"),
				Name = @"Name",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("4cb13ab9-dbdd-400b-b2af-11d421901b6d"),
				ModifiedInSchemaUId = new Guid("4cb13ab9-dbdd-400b-b2af-11d421901b6d"),
				CreatedInPackageId = new Guid("76c4ad3d-328b-49d6-bd5e-eaf12305041a")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateCode_Unique_IndexIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new McpServer(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new McpServer_CrtMCPPublishingAppEventsProcess(userConnection);
		}

		public override object Clone() {
			return new McpServerSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new McpServerSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4cb13ab9-dbdd-400b-b2af-11d421901b6d"));
		}

		#endregion

	}

	#endregion

	#region Class: McpServer

	/// <summary>
	/// Published MCP server.
	/// </summary>
	public class McpServer : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public McpServer(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "McpServer";
		}

		public McpServer(McpServer source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Online.
		/// </summary>
		/// <remarks>
		/// Whether the server is currently published/online.
		/// </remarks>
		public bool IsOnline {
			get {
				return GetTypedColumnValue<bool>("IsOnline");
			}
			set {
				SetColumnValue("IsOnline", value);
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
		/// Code.
		/// </summary>
		public string Code {
			get {
				return GetTypedColumnValue<string>("Code");
			}
			set {
				SetColumnValue("Code", value);
			}
		}

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

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new McpServer_CrtMCPPublishingAppEventsProcess(UserConnection);
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
			return new McpServer(this);
		}

		#endregion

	}

	#endregion

	#region Class: McpServer_CrtMCPPublishingAppEventsProcess

	/// <exclude/>
	public partial class McpServer_CrtMCPPublishingAppEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : McpServer
	{

		public McpServer_CrtMCPPublishingAppEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "McpServer_CrtMCPPublishingAppEventsProcess";
			SchemaUId = new Guid("4cb13ab9-dbdd-400b-b2af-11d421901b6d");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("4cb13ab9-dbdd-400b-b2af-11d421901b6d");
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

	#region Class: McpServer_CrtMCPPublishingAppEventsProcess

	/// <exclude/>
	public class McpServer_CrtMCPPublishingAppEventsProcess : McpServer_CrtMCPPublishingAppEventsProcess<McpServer>
	{

		public McpServer_CrtMCPPublishingAppEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: McpServer_CrtMCPPublishingAppEventsProcess

	public partial class McpServer_CrtMCPPublishingAppEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: McpServerEventsProcess

	/// <exclude/>
	public class McpServerEventsProcess : McpServer_CrtMCPPublishingAppEventsProcess
	{

		public McpServerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

