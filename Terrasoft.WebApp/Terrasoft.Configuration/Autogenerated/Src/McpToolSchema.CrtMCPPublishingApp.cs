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

	#region Class: McpToolSchema

	/// <exclude/>
	public class McpToolSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public McpToolSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public McpToolSchema(McpToolSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public McpToolSchema(McpToolSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateUnique_McpServer_McpToolNameIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = true
			};
			index.UId = new Guid("253d9929-4394-cc20-4c0c-c8f0cfa5a3bb");
			index.Name = "Unique_McpServer_McpToolName";
			index.CreatedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			index.ModifiedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			index.CreatedInPackageId = new Guid("76c4ad3d-328b-49d6-bd5e-eaf12305041a");
			EntitySchemaIndexColumn mcpServerIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("9182c4bb-d4c2-010b-5ca8-0814e1d65694"),
				ColumnUId = new Guid("8c4ee51e-c955-ca93-3656-b9f24f290b8e"),
				CreatedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				ModifiedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				CreatedInPackageId = new Guid("76c4ad3d-328b-49d6-bd5e-eaf12305041a"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(mcpServerIdIndexColumn);
			EntitySchemaIndexColumn externalNameIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("1bcc46d7-afe6-52a5-0c33-f59448c4d65c"),
				ColumnUId = new Guid("4a0efadf-5f79-ee5f-0c03-7a9048ed29fb"),
				CreatedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				ModifiedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				CreatedInPackageId = new Guid("76c4ad3d-328b-49d6-bd5e-eaf12305041a"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(externalNameIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("3435cd9f-bbf1-4bd7-a921-3db99c524826");
			RealUId = new Guid("3435cd9f-bbf1-4bd7-a921-3db99c524826");
			Name = "McpTool";
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
			PrimaryDisplayColumn = CreateExternalNameColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("bbe15828-e7a2-3c5a-6ae9-f4626e4d0572")) == null) {
				Columns.Add(CreateIsEnabledColumn());
			}
			if (Columns.FindByUId(new Guid("df126a74-9f04-b336-deb5-bfbd9caaf3f2")) == null) {
				Columns.Add(CreateAnnotationsColumn());
			}
			if (Columns.FindByUId(new Guid("2d0431d0-2fdc-74b5-79e9-d49875096835")) == null) {
				Columns.Add(CreateOutputSchemaColumn());
			}
			if (Columns.FindByUId(new Guid("a1a8e09c-fe4a-da62-c6e5-3ae932743019")) == null) {
				Columns.Add(CreateInputSchemaColumn());
			}
			if (Columns.FindByUId(new Guid("c489ce0a-e96f-baff-63a9-852d24277ac1")) == null) {
				Columns.Add(CreateDescriptionColumn());
			}
			if (Columns.FindByUId(new Guid("b5f0b546-9a71-d442-2587-350fe0fffd6a")) == null) {
				Columns.Add(CreateTitleColumn());
			}
			if (Columns.FindByUId(new Guid("8c4ee51e-c955-ca93-3656-b9f24f290b8e")) == null) {
				Columns.Add(CreateMcpServerColumn());
			}
			if (Columns.FindByUId(new Guid("853532df-094c-8951-f322-6eab84911d3d")) == null) {
				Columns.Add(CreateToolSourceTypeColumn());
			}
			if (Columns.FindByUId(new Guid("20a253b8-2320-2563-a420-e934aa762031")) == null) {
				Columns.Add(CreateBusinessProcessColumn());
			}
			if (Columns.FindByUId(new Guid("dfd65c0a-7635-6fac-53a5-0ff0f8f549bf")) == null) {
				Columns.Add(CreateSourceCodeActionColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateIsEnabledColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("bbe15828-e7a2-3c5a-6ae9-f4626e4d0572"),
				Name = @"IsEnabled",
				CreatedInSchemaUId = new Guid("3435cd9f-bbf1-4bd7-a921-3db99c524826"),
				ModifiedInSchemaUId = new Guid("3435cd9f-bbf1-4bd7-a921-3db99c524826"),
				CreatedInPackageId = new Guid("76c4ad3d-328b-49d6-bd5e-eaf12305041a"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"True"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateAnnotationsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("df126a74-9f04-b336-deb5-bfbd9caaf3f2"),
				Name = @"Annotations",
				CreatedInSchemaUId = new Guid("3435cd9f-bbf1-4bd7-a921-3db99c524826"),
				ModifiedInSchemaUId = new Guid("3435cd9f-bbf1-4bd7-a921-3db99c524826"),
				CreatedInPackageId = new Guid("76c4ad3d-328b-49d6-bd5e-eaf12305041a")
			};
		}

		protected virtual EntitySchemaColumn CreateOutputSchemaColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("2d0431d0-2fdc-74b5-79e9-d49875096835"),
				Name = @"OutputSchema",
				CreatedInSchemaUId = new Guid("3435cd9f-bbf1-4bd7-a921-3db99c524826"),
				ModifiedInSchemaUId = new Guid("3435cd9f-bbf1-4bd7-a921-3db99c524826"),
				CreatedInPackageId = new Guid("76c4ad3d-328b-49d6-bd5e-eaf12305041a")
			};
		}

		protected virtual EntitySchemaColumn CreateInputSchemaColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("a1a8e09c-fe4a-da62-c6e5-3ae932743019"),
				Name = @"InputSchema",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("3435cd9f-bbf1-4bd7-a921-3db99c524826"),
				ModifiedInSchemaUId = new Guid("3435cd9f-bbf1-4bd7-a921-3db99c524826"),
				CreatedInPackageId = new Guid("76c4ad3d-328b-49d6-bd5e-eaf12305041a")
			};
		}

		protected virtual EntitySchemaColumn CreateDescriptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("c489ce0a-e96f-baff-63a9-852d24277ac1"),
				Name = @"Description",
				CreatedInSchemaUId = new Guid("3435cd9f-bbf1-4bd7-a921-3db99c524826"),
				ModifiedInSchemaUId = new Guid("3435cd9f-bbf1-4bd7-a921-3db99c524826"),
				CreatedInPackageId = new Guid("76c4ad3d-328b-49d6-bd5e-eaf12305041a")
			};
		}

		protected virtual EntitySchemaColumn CreateExternalNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("4a0efadf-5f79-ee5f-0c03-7a9048ed29fb"),
				Name = @"ExternalName",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("3435cd9f-bbf1-4bd7-a921-3db99c524826"),
				ModifiedInSchemaUId = new Guid("3435cd9f-bbf1-4bd7-a921-3db99c524826"),
				CreatedInPackageId = new Guid("76c4ad3d-328b-49d6-bd5e-eaf12305041a")
			};
		}

		protected virtual EntitySchemaColumn CreateTitleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("b5f0b546-9a71-d442-2587-350fe0fffd6a"),
				Name = @"Title",
				CreatedInSchemaUId = new Guid("3435cd9f-bbf1-4bd7-a921-3db99c524826"),
				ModifiedInSchemaUId = new Guid("3435cd9f-bbf1-4bd7-a921-3db99c524826"),
				CreatedInPackageId = new Guid("76c4ad3d-328b-49d6-bd5e-eaf12305041a")
			};
		}

		protected virtual EntitySchemaColumn CreateMcpServerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("8c4ee51e-c955-ca93-3656-b9f24f290b8e"),
				Name = @"McpServer",
				ReferenceSchemaUId = new Guid("4cb13ab9-dbdd-400b-b2af-11d421901b6d"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("3435cd9f-bbf1-4bd7-a921-3db99c524826"),
				ModifiedInSchemaUId = new Guid("3435cd9f-bbf1-4bd7-a921-3db99c524826"),
				CreatedInPackageId = new Guid("76c4ad3d-328b-49d6-bd5e-eaf12305041a")
			};
		}

		protected virtual EntitySchemaColumn CreateToolSourceTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("853532df-094c-8951-f322-6eab84911d3d"),
				Name = @"ToolSourceType",
				ReferenceSchemaUId = new Guid("d87b3d88-cd9f-44ef-8d5a-0a42e60e5274"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("3435cd9f-bbf1-4bd7-a921-3db99c524826"),
				ModifiedInSchemaUId = new Guid("3435cd9f-bbf1-4bd7-a921-3db99c524826"),
				CreatedInPackageId = new Guid("27bb82a7-2806-4989-bfe6-ec4e3982c003"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"8dfb191a-a0af-433d-b088-fa1797ad2e50"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateBusinessProcessColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("20a253b8-2320-2563-a420-e934aa762031"),
				Name = @"BusinessProcess",
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("3435cd9f-bbf1-4bd7-a921-3db99c524826"),
				ModifiedInSchemaUId = new Guid("3435cd9f-bbf1-4bd7-a921-3db99c524826"),
				CreatedInPackageId = new Guid("27bb82a7-2806-4989-bfe6-ec4e3982c003")
			};
		}

		protected virtual EntitySchemaColumn CreateSourceCodeActionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("dfd65c0a-7635-6fac-53a5-0ff0f8f549bf"),
				Name = @"SourceCodeAction",
				CreatedInSchemaUId = new Guid("3435cd9f-bbf1-4bd7-a921-3db99c524826"),
				ModifiedInSchemaUId = new Guid("3435cd9f-bbf1-4bd7-a921-3db99c524826"),
				CreatedInPackageId = new Guid("c16fbbdb-b12b-4fa8-8373-0b94f943be24")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateUnique_McpServer_McpToolNameIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new McpTool(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new McpTool_CrtMCPPublishingAppEventsProcess(userConnection);
		}

		public override object Clone() {
			return new McpToolSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new McpToolSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3435cd9f-bbf1-4bd7-a921-3db99c524826"));
		}

		#endregion

	}

	#endregion

	#region Class: McpTool

	/// <summary>
	/// MCP Tool.
	/// </summary>
	public class McpTool : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public McpTool(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "McpTool";
		}

		public McpTool(McpTool source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Enabled.
		/// </summary>
		/// <remarks>
		/// Whether the tool is exposed in the server tool list.
		/// </remarks>
		public bool IsEnabled {
			get {
				return GetTypedColumnValue<bool>("IsEnabled");
			}
			set {
				SetColumnValue("IsEnabled", value);
			}
		}

		/// <summary>
		/// Annotations.
		/// </summary>
		/// <remarks>
		/// JSON annotations object per the MCP tool spec.
		/// </remarks>
		public string Annotations {
			get {
				return GetTypedColumnValue<string>("Annotations");
			}
			set {
				SetColumnValue("Annotations", value);
			}
		}

		/// <summary>
		/// Output schema.
		/// </summary>
		/// <remarks>
		/// JSON output schema (manually edited).
		/// </remarks>
		public string OutputSchema {
			get {
				return GetTypedColumnValue<string>("OutputSchema");
			}
			set {
				SetColumnValue("OutputSchema", value);
			}
		}

		/// <summary>
		/// Input schema.
		/// </summary>
		/// <remarks>
		/// JSON input schema (manually edited).
		/// </remarks>
		public string InputSchema {
			get {
				return GetTypedColumnValue<string>("InputSchema");
			}
			set {
				SetColumnValue("InputSchema", value);
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
		/// External tool name.
		/// </summary>
		/// <remarks>
		/// Tool name exposed to the AI platform (MCP name).
		/// </remarks>
		public string ExternalName {
			get {
				return GetTypedColumnValue<string>("ExternalName");
			}
			set {
				SetColumnValue("ExternalName", value);
			}
		}

		/// <summary>
		/// Title.
		/// </summary>
		public string Title {
			get {
				return GetTypedColumnValue<string>("Title");
			}
			set {
				SetColumnValue("Title", value);
			}
		}

		/// <exclude/>
		public Guid McpServerId {
			get {
				return GetTypedColumnValue<Guid>("McpServerId");
			}
			set {
				SetColumnValue("McpServerId", value);
				_mcpServer = null;
			}
		}

		/// <exclude/>
		public string McpServerName {
			get {
				return GetTypedColumnValue<string>("McpServerName");
			}
			set {
				SetColumnValue("McpServerName", value);
				if (_mcpServer != null) {
					_mcpServer.Name = value;
				}
			}
		}

		private McpServer _mcpServer;
		/// <summary>
		/// MCP Server.
		/// </summary>
		/// <remarks>
		/// Parent server this tool belongs to.
		/// </remarks>
		public McpServer McpServer {
			get {
				return _mcpServer ??
					(_mcpServer = LookupColumnEntities.GetEntity("McpServer") as McpServer);
			}
		}

		/// <exclude/>
		public Guid ToolSourceTypeId {
			get {
				return GetTypedColumnValue<Guid>("ToolSourceTypeId");
			}
			set {
				SetColumnValue("ToolSourceTypeId", value);
				_toolSourceType = null;
			}
		}

		/// <exclude/>
		public string ToolSourceTypeName {
			get {
				return GetTypedColumnValue<string>("ToolSourceTypeName");
			}
			set {
				SetColumnValue("ToolSourceTypeName", value);
				if (_toolSourceType != null) {
					_toolSourceType.Name = value;
				}
			}
		}

		private McpToolSourceType _toolSourceType;
		/// <summary>
		/// Source type.
		/// </summary>
		public McpToolSourceType ToolSourceType {
			get {
				return _toolSourceType ??
					(_toolSourceType = LookupColumnEntities.GetEntity("ToolSourceType") as McpToolSourceType);
			}
		}

		/// <exclude/>
		public Guid BusinessProcessId {
			get {
				return GetTypedColumnValue<Guid>("BusinessProcessId");
			}
			set {
				SetColumnValue("BusinessProcessId", value);
				_businessProcess = null;
			}
		}

		/// <exclude/>
		public string BusinessProcessCaption {
			get {
				return GetTypedColumnValue<string>("BusinessProcessCaption");
			}
			set {
				SetColumnValue("BusinessProcessCaption", value);
				if (_businessProcess != null) {
					_businessProcess.Caption = value;
				}
			}
		}

		private SysSchema _businessProcess;
		/// <summary>
		/// Source process.
		/// </summary>
		/// <remarks>
		/// Business process this tool is based on (process schema).
		/// </remarks>
		public SysSchema BusinessProcess {
			get {
				return _businessProcess ??
					(_businessProcess = LookupColumnEntities.GetEntity("BusinessProcess") as SysSchema);
			}
		}

		/// <summary>
		/// Source code action.
		/// </summary>
		public string SourceCodeAction {
			get {
				return GetTypedColumnValue<string>("SourceCodeAction");
			}
			set {
				SetColumnValue("SourceCodeAction", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new McpTool_CrtMCPPublishingAppEventsProcess(UserConnection);
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
			return new McpTool(this);
		}

		#endregion

	}

	#endregion

	#region Class: McpTool_CrtMCPPublishingAppEventsProcess

	/// <exclude/>
	public partial class McpTool_CrtMCPPublishingAppEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : McpTool
	{

		public McpTool_CrtMCPPublishingAppEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "McpTool_CrtMCPPublishingAppEventsProcess";
			SchemaUId = new Guid("3435cd9f-bbf1-4bd7-a921-3db99c524826");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("3435cd9f-bbf1-4bd7-a921-3db99c524826");
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

	#region Class: McpTool_CrtMCPPublishingAppEventsProcess

	/// <exclude/>
	public class McpTool_CrtMCPPublishingAppEventsProcess : McpTool_CrtMCPPublishingAppEventsProcess<McpTool>
	{

		public McpTool_CrtMCPPublishingAppEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: McpTool_CrtMCPPublishingAppEventsProcess

	public partial class McpTool_CrtMCPPublishingAppEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: McpToolEventsProcess

	/// <exclude/>
	public class McpToolEventsProcess : McpTool_CrtMCPPublishingAppEventsProcess
	{

		public McpToolEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

