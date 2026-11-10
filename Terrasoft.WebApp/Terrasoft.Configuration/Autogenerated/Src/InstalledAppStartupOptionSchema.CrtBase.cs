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

	#region Class: InstalledAppStartupOptionSchema

	/// <exclude/>
	[IsVirtual]
	public class InstalledAppStartupOptionSchema : Terrasoft.Core.Entities.EntitySchema
	{

		#region Constructors: Public

		public InstalledAppStartupOptionSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public InstalledAppStartupOptionSchema(InstalledAppStartupOptionSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public InstalledAppStartupOptionSchema(InstalledAppStartupOptionSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d7a798d1-d3bd-9f93-d0cb-b5f0331da842");
			RealUId = new Guid("d7a798d1-d3bd-9f93-d0cb-b5f0331da842");
			Name = "InstalledAppStartupOption";
			ParentSchemaUId = new Guid("1b56b061-4e91-4974-9038-df8340e534f2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryColumn() {
			base.InitializePrimaryColumn();
			PrimaryColumn = CreateIdColumn();
			if (Columns.FindByUId(PrimaryColumn.UId) == null) {
				Columns.Add(PrimaryColumn);
			}
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
			if (Columns.FindByUId(new Guid("4a690161-e3bf-0f18-3e26-5aaf333dde8a")) == null) {
				Columns.Add(CreateIsActiveColumn());
			}
			if (Columns.FindByUId(new Guid("67bb8115-bd33-41d4-610d-5e6b8a298028")) == null) {
				Columns.Add(CreateRunTypeColumn());
			}
			if (Columns.FindByUId(new Guid("96001313-75be-586f-a64a-42dae50a02e5")) == null) {
				Columns.Add(CreateInstalledAppColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateIsActiveColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("4a690161-e3bf-0f18-3e26-5aaf333dde8a"),
				Name = @"IsActive",
				CreatedInSchemaUId = new Guid("d7a798d1-d3bd-9f93-d0cb-b5f0331da842"),
				ModifiedInSchemaUId = new Guid("d7a798d1-d3bd-9f93-d0cb-b5f0331da842"),
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723")
			};
		}

		protected virtual EntitySchemaColumn CreateRunTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("67bb8115-bd33-41d4-610d-5e6b8a298028"),
				Name = @"RunType",
				ReferenceSchemaUId = new Guid("a135004f-e6dd-4c3c-b7a9-652d6abafe31"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("d7a798d1-d3bd-9f93-d0cb-b5f0331da842"),
				ModifiedInSchemaUId = new Guid("d7a798d1-d3bd-9f93-d0cb-b5f0331da842"),
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateInstalledAppColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("96001313-75be-586f-a64a-42dae50a02e5"),
				Name = @"InstalledApp",
				ReferenceSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("d7a798d1-d3bd-9f93-d0cb-b5f0331da842"),
				ModifiedInSchemaUId = new Guid("d7a798d1-d3bd-9f93-d0cb-b5f0331da842"),
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("215990de-d8e7-b0e4-9576-be25dd3d4a02"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("d7a798d1-d3bd-9f93-d0cb-b5f0331da842"),
				ModifiedInSchemaUId = new Guid("d7a798d1-d3bd-9f93-d0cb-b5f0331da842"),
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("eac4acea-34cb-3b49-2094-9e014efd0e71"),
				Name = @"Id",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				UsageType = EntitySchemaColumnUsageType.Advanced,
				CreatedInSchemaUId = new Guid("d7a798d1-d3bd-9f93-d0cb-b5f0331da842"),
				ModifiedInSchemaUId = new Guid("d7a798d1-d3bd-9f93-d0cb-b5f0331da842"),
				CreatedInPackageId = new Guid("50f552a9-0668-454a-8ecf-9cb468aabd1f"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"AutoGuid")
				}
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new InstalledAppStartupOption(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new InstalledAppStartupOption_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new InstalledAppStartupOptionSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new InstalledAppStartupOptionSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d7a798d1-d3bd-9f93-d0cb-b5f0331da842"));
		}

		#endregion

	}

	#endregion

	#region Class: InstalledAppStartupOption

	/// <summary>
	/// Installed application startup option.
	/// </summary>
	public class InstalledAppStartupOption : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public InstalledAppStartupOption(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "InstalledAppStartupOption";
		}

		public InstalledAppStartupOption(InstalledAppStartupOption source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Is active.
		/// </summary>
		public bool IsActive {
			get {
				return GetTypedColumnValue<bool>("IsActive");
			}
			set {
				SetColumnValue("IsActive", value);
			}
		}

		/// <exclude/>
		public Guid RunTypeId {
			get {
				return GetTypedColumnValue<Guid>("RunTypeId");
			}
			set {
				SetColumnValue("RunTypeId", value);
				_runType = null;
			}
		}

		/// <exclude/>
		public string RunTypeName {
			get {
				return GetTypedColumnValue<string>("RunTypeName");
			}
			set {
				SetColumnValue("RunTypeName", value);
				if (_runType != null) {
					_runType.Name = value;
				}
			}
		}

		private SysInstalledAppRunType _runType;
		/// <summary>
		/// Run type.
		/// </summary>
		public SysInstalledAppRunType RunType {
			get {
				return _runType ??
					(_runType = LookupColumnEntities.GetEntity("RunType") as SysInstalledAppRunType);
			}
		}

		/// <exclude/>
		public Guid InstalledAppId {
			get {
				return GetTypedColumnValue<Guid>("InstalledAppId");
			}
			set {
				SetColumnValue("InstalledAppId", value);
				_installedApp = null;
			}
		}

		/// <exclude/>
		public string InstalledAppName {
			get {
				return GetTypedColumnValue<string>("InstalledAppName");
			}
			set {
				SetColumnValue("InstalledAppName", value);
				if (_installedApp != null) {
					_installedApp.Name = value;
				}
			}
		}

		private SysInstalledApp _installedApp;
		/// <summary>
		/// Installed application.
		/// </summary>
		public SysInstalledApp InstalledApp {
			get {
				return _installedApp ??
					(_installedApp = LookupColumnEntities.GetEntity("InstalledApp") as SysInstalledApp);
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

		/// <summary>
		/// Id.
		/// </summary>
		public Guid Id {
			get {
				return GetTypedColumnValue<Guid>("Id");
			}
			set {
				SetColumnValue("Id", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new InstalledAppStartupOption_CrtBaseEventsProcess(UserConnection);
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
			return new InstalledAppStartupOption(this);
		}

		#endregion

	}

	#endregion

	#region Class: InstalledAppStartupOption_CrtBaseEventsProcess

	/// <exclude/>
	public partial class InstalledAppStartupOption_CrtBaseEventsProcess<TEntity> : Terrasoft.Core.Process.EmbeddedProcess where TEntity : InstalledAppStartupOption
	{

		private TEntity _entity;
		public TEntity Entity {
			get {
				return _entity;
			}
			set {
				_entity = value;
			}
		}

		public InstalledAppStartupOption_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "InstalledAppStartupOption_CrtBaseEventsProcess";
			SchemaUId = new Guid("d7a798d1-d3bd-9f93-d0cb-b5f0331da842");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("d7a798d1-d3bd-9f93-d0cb-b5f0331da842");
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

	#region Class: InstalledAppStartupOption_CrtBaseEventsProcess

	/// <exclude/>
	public class InstalledAppStartupOption_CrtBaseEventsProcess : InstalledAppStartupOption_CrtBaseEventsProcess<InstalledAppStartupOption>
	{

		public InstalledAppStartupOption_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: InstalledAppStartupOption_CrtBaseEventsProcess

	public partial class InstalledAppStartupOption_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: InstalledAppStartupOptionEventsProcess

	/// <exclude/>
	public class InstalledAppStartupOptionEventsProcess : InstalledAppStartupOption_CrtBaseEventsProcess
	{

		public InstalledAppStartupOptionEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

