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

	#region Class: SysAppTemplateSchema

	/// <exclude/>
	public class SysAppTemplateSchema : Terrasoft.Configuration.BaseCodeImageLookupSchema
	{

		#region Constructors: Public

		public SysAppTemplateSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysAppTemplateSchema(SysAppTemplateSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysAppTemplateSchema(SysAppTemplateSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("97e71819-5bc7-45a7-b0d9-f22f154dd0e2");
			RealUId = new Guid("97e71819-5bc7-45a7-b0d9-f22f154dd0e2");
			Name = "SysAppTemplate";
			ParentSchemaUId = new Guid("c21771d2-01fa-4646-96b0-e4b69e582b44");
			ExtendParent = false;
			CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = false;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("f0b79a2b-eb81-93ee-11bd-1bc40f3f2f47")) == null) {
				Columns.Add(CreatePositionColumn());
			}
			if (Columns.FindByUId(new Guid("00e8c3dd-4d68-8500-e9da-e8c0cf2f61cc")) == null) {
				Columns.Add(CreateTypeColumn());
			}
			if (Columns.FindByUId(new Guid("31d7dc01-67c6-428b-db30-2f47a690dffd")) == null) {
				Columns.Add(CreateInstallationLinkColumn());
			}
			if (Columns.FindByUId(new Guid("7e4703f2-9007-1fbd-c3fc-493e64badfa2")) == null) {
				Columns.Add(CreateIsHiddenColumn());
			}
			if (Columns.FindByUId(new Guid("d9f4f4fe-f680-1318-a3f1-bd9e5127a267")) == null) {
				Columns.Add(CreateIsPrereleaseColumn());
			}
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.DataValueType = DataValueTypeManager.GetInstanceByName("LongText");
			column.ModifiedInSchemaUId = new Guid("97e71819-5bc7-45a7-b0d9-f22f154dd0e2");
			return column;
		}

		protected virtual EntitySchemaColumn CreatePositionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("f0b79a2b-eb81-93ee-11bd-1bc40f3f2f47"),
				Name = @"Position",
				CreatedInSchemaUId = new Guid("97e71819-5bc7-45a7-b0d9-f22f154dd0e2"),
				ModifiedInSchemaUId = new Guid("97e71819-5bc7-45a7-b0d9-f22f154dd0e2"),
				CreatedInPackageId = new Guid("a5664658-26d5-4600-862a-86467fd59244")
			};
		}

		protected virtual EntitySchemaColumn CreateTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("00e8c3dd-4d68-8500-e9da-e8c0cf2f61cc"),
				Name = @"Type",
				CreatedInSchemaUId = new Guid("97e71819-5bc7-45a7-b0d9-f22f154dd0e2"),
				ModifiedInSchemaUId = new Guid("97e71819-5bc7-45a7-b0d9-f22f154dd0e2"),
				CreatedInPackageId = new Guid("11c768bc-fae6-4a11-84ba-23628061715e"),
				IsFormatValidated = true
			};
		}

		protected virtual EntitySchemaColumn CreateInstallationLinkColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("31d7dc01-67c6-428b-db30-2f47a690dffd"),
				Name = @"InstallationLink",
				CreatedInSchemaUId = new Guid("97e71819-5bc7-45a7-b0d9-f22f154dd0e2"),
				ModifiedInSchemaUId = new Guid("97e71819-5bc7-45a7-b0d9-f22f154dd0e2"),
				CreatedInPackageId = new Guid("11c768bc-fae6-4a11-84ba-23628061715e")
			};
		}

		protected virtual EntitySchemaColumn CreateIsHiddenColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("7e4703f2-9007-1fbd-c3fc-493e64badfa2"),
				Name = @"IsHidden",
				CreatedInSchemaUId = new Guid("97e71819-5bc7-45a7-b0d9-f22f154dd0e2"),
				ModifiedInSchemaUId = new Guid("97e71819-5bc7-45a7-b0d9-f22f154dd0e2"),
				CreatedInPackageId = new Guid("5f929ad0-82bf-40b9-9c9b-168806730a51")
			};
		}

		protected virtual EntitySchemaColumn CreateIsPrereleaseColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("d9f4f4fe-f680-1318-a3f1-bd9e5127a267"),
				Name = @"IsPrerelease",
				CreatedInSchemaUId = new Guid("97e71819-5bc7-45a7-b0d9-f22f154dd0e2"),
				ModifiedInSchemaUId = new Guid("97e71819-5bc7-45a7-b0d9-f22f154dd0e2"),
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysAppTemplate(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysAppTemplate_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysAppTemplateSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysAppTemplateSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("97e71819-5bc7-45a7-b0d9-f22f154dd0e2"));
		}

		#endregion

	}

	#endregion

	#region Class: SysAppTemplate

	/// <summary>
	/// SysAppTemplate.
	/// </summary>
	public class SysAppTemplate : Terrasoft.Configuration.BaseCodeImageLookup
	{

		#region Constructors: Public

		public SysAppTemplate(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysAppTemplate";
		}

		public SysAppTemplate(SysAppTemplate source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Position.
		/// </summary>
		public int Position {
			get {
				return GetTypedColumnValue<int>("Position");
			}
			set {
				SetColumnValue("Position", value);
			}
		}

		/// <summary>
		/// Type.
		/// </summary>
		public string Type {
			get {
				return GetTypedColumnValue<string>("Type");
			}
			set {
				SetColumnValue("Type", value);
			}
		}

		/// <summary>
		/// Installation link.
		/// </summary>
		public string InstallationLink {
			get {
				return GetTypedColumnValue<string>("InstallationLink");
			}
			set {
				SetColumnValue("InstallationLink", value);
			}
		}

		/// <summary>
		/// IsHidden.
		/// </summary>
		public bool IsHidden {
			get {
				return GetTypedColumnValue<bool>("IsHidden");
			}
			set {
				SetColumnValue("IsHidden", value);
			}
		}

		/// <summary>
		/// Pre-release version.
		/// </summary>
		public bool IsPrerelease {
			get {
				return GetTypedColumnValue<bool>("IsPrerelease");
			}
			set {
				SetColumnValue("IsPrerelease", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysAppTemplate_CrtBaseEventsProcess(UserConnection);
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
			return new SysAppTemplate(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysAppTemplate_CrtBaseEventsProcess

	/// <exclude/>
	public partial class SysAppTemplate_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseCodeImageLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysAppTemplate
	{

		public SysAppTemplate_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysAppTemplate_CrtBaseEventsProcess";
			SchemaUId = new Guid("97e71819-5bc7-45a7-b0d9-f22f154dd0e2");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("97e71819-5bc7-45a7-b0d9-f22f154dd0e2");
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

	#region Class: SysAppTemplate_CrtBaseEventsProcess

	/// <exclude/>
	public class SysAppTemplate_CrtBaseEventsProcess : SysAppTemplate_CrtBaseEventsProcess<SysAppTemplate>
	{

		public SysAppTemplate_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysAppTemplate_CrtBaseEventsProcess

	public partial class SysAppTemplate_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysAppTemplateEventsProcess

	/// <exclude/>
	public class SysAppTemplateEventsProcess : SysAppTemplate_CrtBaseEventsProcess
	{

		public SysAppTemplateEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

