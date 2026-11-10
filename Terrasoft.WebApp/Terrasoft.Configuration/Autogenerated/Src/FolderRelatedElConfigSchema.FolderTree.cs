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

	#region Class: FolderRelatedElConfigSchema

	/// <exclude/>
	public class FolderRelatedElConfigSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public FolderRelatedElConfigSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public FolderRelatedElConfigSchema(FolderRelatedElConfigSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public FolderRelatedElConfigSchema(FolderRelatedElConfigSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("81f21fea-8172-45a5-bed2-9554d238e805");
			RealUId = new Guid("81f21fea-8172-45a5-bed2-9554d238e805");
			Name = "FolderRelatedElConfig";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("92092752-1c22-486c-88e9-2a46418ad47a");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("a8dcc7cd-6091-71ab-38e7-745126a9400f")) == null) {
				Columns.Add(CreateElementConfigColumn());
			}
			if (Columns.FindByUId(new Guid("069fe3d5-f48c-78af-9b5a-a357fba7c025")) == null) {
				Columns.Add(CreateFolderIdColumn());
			}
			if (Columns.FindByUId(new Guid("ea3b8cd4-081f-e536-e131-009ab98520c5")) == null) {
				Columns.Add(CreateClientSchemaNameColumn());
			}
			if (Columns.FindByUId(new Guid("2bf2db44-24ec-dffe-c3d6-34734b62780b")) == null) {
				Columns.Add(CreateElementNameColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateElementConfigColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Binary")) {
				UId = new Guid("a8dcc7cd-6091-71ab-38e7-745126a9400f"),
				Name = @"ElementConfig",
				CreatedInSchemaUId = new Guid("81f21fea-8172-45a5-bed2-9554d238e805"),
				ModifiedInSchemaUId = new Guid("81f21fea-8172-45a5-bed2-9554d238e805"),
				CreatedInPackageId = new Guid("92092752-1c22-486c-88e9-2a46418ad47a")
			};
		}

		protected virtual EntitySchemaColumn CreateFolderIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("069fe3d5-f48c-78af-9b5a-a357fba7c025"),
				Name = @"FolderId",
				CreatedInSchemaUId = new Guid("81f21fea-8172-45a5-bed2-9554d238e805"),
				ModifiedInSchemaUId = new Guid("81f21fea-8172-45a5-bed2-9554d238e805"),
				CreatedInPackageId = new Guid("92092752-1c22-486c-88e9-2a46418ad47a")
			};
		}

		protected virtual EntitySchemaColumn CreateClientSchemaNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("ea3b8cd4-081f-e536-e131-009ab98520c5"),
				Name = @"ClientSchemaName",
				CreatedInSchemaUId = new Guid("81f21fea-8172-45a5-bed2-9554d238e805"),
				ModifiedInSchemaUId = new Guid("81f21fea-8172-45a5-bed2-9554d238e805"),
				CreatedInPackageId = new Guid("92092752-1c22-486c-88e9-2a46418ad47a")
			};
		}

		protected virtual EntitySchemaColumn CreateElementNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("2bf2db44-24ec-dffe-c3d6-34734b62780b"),
				Name = @"ElementName",
				CreatedInSchemaUId = new Guid("81f21fea-8172-45a5-bed2-9554d238e805"),
				ModifiedInSchemaUId = new Guid("81f21fea-8172-45a5-bed2-9554d238e805"),
				CreatedInPackageId = new Guid("92092752-1c22-486c-88e9-2a46418ad47a")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new FolderRelatedElConfig(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new FolderRelatedElConfig_FolderTreeEventsProcess(userConnection);
		}

		public override object Clone() {
			return new FolderRelatedElConfigSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new FolderRelatedElConfigSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("81f21fea-8172-45a5-bed2-9554d238e805"));
		}

		#endregion

	}

	#endregion

	#region Class: FolderRelatedElConfig

	/// <summary>
	/// Folder tree related elements configuration.
	/// </summary>
	public class FolderRelatedElConfig : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public FolderRelatedElConfig(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "FolderRelatedElConfig";
		}

		public FolderRelatedElConfig(FolderRelatedElConfig source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Folder Id.
		/// </summary>
		public Guid FolderId {
			get {
				return GetTypedColumnValue<Guid>("FolderId");
			}
			set {
				SetColumnValue("FolderId", value);
			}
		}

		/// <summary>
		/// Schema Name.
		/// </summary>
		public string ClientSchemaName {
			get {
				return GetTypedColumnValue<string>("ClientSchemaName");
			}
			set {
				SetColumnValue("ClientSchemaName", value);
			}
		}

		/// <summary>
		/// Element Name.
		/// </summary>
		public string ElementName {
			get {
				return GetTypedColumnValue<string>("ElementName");
			}
			set {
				SetColumnValue("ElementName", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new FolderRelatedElConfig_FolderTreeEventsProcess(UserConnection);
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
			return new FolderRelatedElConfig(this);
		}

		#endregion

	}

	#endregion

	#region Class: FolderRelatedElConfig_FolderTreeEventsProcess

	/// <exclude/>
	public partial class FolderRelatedElConfig_FolderTreeEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : FolderRelatedElConfig
	{

		public FolderRelatedElConfig_FolderTreeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "FolderRelatedElConfig_FolderTreeEventsProcess";
			SchemaUId = new Guid("81f21fea-8172-45a5-bed2-9554d238e805");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("81f21fea-8172-45a5-bed2-9554d238e805");
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

	#region Class: FolderRelatedElConfig_FolderTreeEventsProcess

	/// <exclude/>
	public class FolderRelatedElConfig_FolderTreeEventsProcess : FolderRelatedElConfig_FolderTreeEventsProcess<FolderRelatedElConfig>
	{

		public FolderRelatedElConfig_FolderTreeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: FolderRelatedElConfig_FolderTreeEventsProcess

	public partial class FolderRelatedElConfig_FolderTreeEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: FolderRelatedElConfigEventsProcess

	/// <exclude/>
	public class FolderRelatedElConfigEventsProcess : FolderRelatedElConfig_FolderTreeEventsProcess
	{

		public FolderRelatedElConfigEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

