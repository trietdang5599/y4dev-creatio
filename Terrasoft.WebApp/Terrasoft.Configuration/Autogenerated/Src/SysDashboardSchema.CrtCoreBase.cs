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

	#region Class: SysDashboardSchema

	/// <exclude/>
	public class SysDashboardSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysDashboardSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysDashboardSchema(SysDashboardSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysDashboardSchema(SysDashboardSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("873fa71c-3434-43e7-93cb-6f77e1191e11");
			RealUId = new Guid("873fa71c-3434-43e7-93cb-6f77e1191e11");
			Name = "SysDashboard";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("3df20d40-4cdd-491f-acaf-50a86aeeadd3");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
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
			PrimaryDisplayColumn = CreateCaptionColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("78ed4015-b81f-49fc-9d50-847cf8df5e6c")) == null) {
				Columns.Add(CreatePositionColumn());
			}
			if (Columns.FindByUId(new Guid("fb750eb9-35b6-463e-b3b8-1a69ec871e43")) == null) {
				Columns.Add(CreateViewConfigColumn());
			}
			if (Columns.FindByUId(new Guid("551ce105-25dc-4a76-b318-cf37635e88c3")) == null) {
				Columns.Add(CreateItemsColumn());
			}
			if (Columns.FindByUId(new Guid("9eedf8ab-d02e-4a4a-9f9d-19ede1c873bc")) == null) {
				Columns.Add(CreateSectionColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("873fa71c-3434-43e7-93cb-6f77e1191e11");
			column.CreatedInPackageId = new Guid("3df20d40-4cdd-491f-acaf-50a86aeeadd3");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("873fa71c-3434-43e7-93cb-6f77e1191e11");
			column.CreatedInPackageId = new Guid("3df20d40-4cdd-491f-acaf-50a86aeeadd3");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("873fa71c-3434-43e7-93cb-6f77e1191e11");
			column.CreatedInPackageId = new Guid("3df20d40-4cdd-491f-acaf-50a86aeeadd3");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("873fa71c-3434-43e7-93cb-6f77e1191e11");
			column.CreatedInPackageId = new Guid("3df20d40-4cdd-491f-acaf-50a86aeeadd3");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("873fa71c-3434-43e7-93cb-6f77e1191e11");
			column.CreatedInPackageId = new Guid("3df20d40-4cdd-491f-acaf-50a86aeeadd3");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("873fa71c-3434-43e7-93cb-6f77e1191e11");
			column.CreatedInPackageId = new Guid("3df20d40-4cdd-491f-acaf-50a86aeeadd3");
			return column;
		}

		protected virtual EntitySchemaColumn CreateCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("a215f575-7283-41bd-8852-b2415a935051"),
				Name = @"Caption",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("873fa71c-3434-43e7-93cb-6f77e1191e11"),
				ModifiedInSchemaUId = new Guid("873fa71c-3434-43e7-93cb-6f77e1191e11"),
				CreatedInPackageId = new Guid("3df20d40-4cdd-491f-acaf-50a86aeeadd3"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreatePositionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("78ed4015-b81f-49fc-9d50-847cf8df5e6c"),
				Name = @"Position",
				CreatedInSchemaUId = new Guid("873fa71c-3434-43e7-93cb-6f77e1191e11"),
				ModifiedInSchemaUId = new Guid("873fa71c-3434-43e7-93cb-6f77e1191e11"),
				CreatedInPackageId = new Guid("3df20d40-4cdd-491f-acaf-50a86aeeadd3")
			};
		}

		protected virtual EntitySchemaColumn CreateViewConfigColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("fb750eb9-35b6-463e-b3b8-1a69ec871e43"),
				Name = @"ViewConfig",
				CreatedInSchemaUId = new Guid("873fa71c-3434-43e7-93cb-6f77e1191e11"),
				ModifiedInSchemaUId = new Guid("873fa71c-3434-43e7-93cb-6f77e1191e11"),
				CreatedInPackageId = new Guid("3df20d40-4cdd-491f-acaf-50a86aeeadd3")
			};
		}

		protected virtual EntitySchemaColumn CreateItemsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("551ce105-25dc-4a76-b318-cf37635e88c3"),
				Name = @"Items",
				CreatedInSchemaUId = new Guid("873fa71c-3434-43e7-93cb-6f77e1191e11"),
				ModifiedInSchemaUId = new Guid("873fa71c-3434-43e7-93cb-6f77e1191e11"),
				CreatedInPackageId = new Guid("3df20d40-4cdd-491f-acaf-50a86aeeadd3"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateSectionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("9eedf8ab-d02e-4a4a-9f9d-19ede1c873bc"),
				Name = @"Section",
				ReferenceSchemaUId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("873fa71c-3434-43e7-93cb-6f77e1191e11"),
				ModifiedInSchemaUId = new Guid("873fa71c-3434-43e7-93cb-6f77e1191e11"),
				CreatedInPackageId = new Guid("6452b18e-41a5-4cb4-a67b-6faf4661f7c8")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysDashboard(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysDashboard_CrtCoreBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysDashboardSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysDashboardSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("873fa71c-3434-43e7-93cb-6f77e1191e11"));
		}

		#endregion

	}

	#endregion

	#region Class: SysDashboard

	/// <summary>
	/// Dashboard.
	/// </summary>
	public class SysDashboard : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysDashboard(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysDashboard";
		}

		public SysDashboard(SysDashboard source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Title.
		/// </summary>
		public string Caption {
			get {
				return GetTypedColumnValue<string>("Caption");
			}
			set {
				SetColumnValue("Caption", value);
			}
		}

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
		/// Items display configuration.
		/// </summary>
		public string ViewConfig {
			get {
				return GetTypedColumnValue<string>("ViewConfig");
			}
			set {
				SetColumnValue("ViewConfig", value);
			}
		}

		/// <summary>
		/// Items modules configuration.
		/// </summary>
		public string Items {
			get {
				return GetTypedColumnValue<string>("Items");
			}
			set {
				SetColumnValue("Items", value);
			}
		}

		/// <exclude/>
		public Guid SectionId {
			get {
				return GetTypedColumnValue<Guid>("SectionId");
			}
			set {
				SetColumnValue("SectionId", value);
				_section = null;
			}
		}

		/// <exclude/>
		public string SectionCaption {
			get {
				return GetTypedColumnValue<string>("SectionCaption");
			}
			set {
				SetColumnValue("SectionCaption", value);
				if (_section != null) {
					_section.Caption = value;
				}
			}
		}

		private SysModule _section;
		/// <summary>
		/// Section.
		/// </summary>
		public SysModule Section {
			get {
				return _section ??
					(_section = LookupColumnEntities.GetEntity("Section") as SysModule);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysDashboard_CrtCoreBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysDashboardDeleted", e);
			Inserting += (s, e) => ThrowEvent("SysDashboardInserting", e);
			Validating += (s, e) => ThrowEvent("SysDashboardValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysDashboard(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysDashboard_CrtCoreBaseEventsProcess

	/// <exclude/>
	public partial class SysDashboard_CrtCoreBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysDashboard
	{

		public SysDashboard_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysDashboard_CrtCoreBaseEventsProcess";
			SchemaUId = new Guid("873fa71c-3434-43e7-93cb-6f77e1191e11");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("873fa71c-3434-43e7-93cb-6f77e1191e11");
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

	#region Class: SysDashboard_CrtCoreBaseEventsProcess

	/// <exclude/>
	public class SysDashboard_CrtCoreBaseEventsProcess : SysDashboard_CrtCoreBaseEventsProcess<SysDashboard>
	{

		public SysDashboard_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysDashboard_CrtCoreBaseEventsProcess

	public partial class SysDashboard_CrtCoreBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysDashboardEventsProcess

	/// <exclude/>
	public class SysDashboardEventsProcess : SysDashboard_CrtCoreBaseEventsProcess
	{

		public SysDashboardEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

