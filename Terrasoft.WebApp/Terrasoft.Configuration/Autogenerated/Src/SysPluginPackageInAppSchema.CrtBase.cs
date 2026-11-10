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

	#region Class: SysPluginPackageInAppSchema

	/// <exclude/>
	public class SysPluginPackageInAppSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysPluginPackageInAppSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysPluginPackageInAppSchema(SysPluginPackageInAppSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysPluginPackageInAppSchema(SysPluginPackageInAppSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("07ad6591-4101-4658-9723-3727b54bbadb");
			RealUId = new Guid("07ad6591-4101-4658-9723-3727b54bbadb");
			Name = "SysPluginPackageInApp";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = false;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("73b94ca6-38c6-4c58-7efa-10a9b07d3a22")) == null) {
				Columns.Add(CreateSysPluginPackageColumn());
			}
			if (Columns.FindByUId(new Guid("ab4a24dc-41d5-f474-6a70-ef6e6bb232d8")) == null) {
				Columns.Add(CreateSysInstalledAppColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysPluginPackageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("73b94ca6-38c6-4c58-7efa-10a9b07d3a22"),
				Name = @"SysPluginPackage",
				ReferenceSchemaUId = new Guid("80567be7-99c2-41c7-923a-ee9ec17ad93c"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("07ad6591-4101-4658-9723-3727b54bbadb"),
				ModifiedInSchemaUId = new Guid("07ad6591-4101-4658-9723-3727b54bbadb"),
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723")
			};
		}

		protected virtual EntitySchemaColumn CreateSysInstalledAppColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ab4a24dc-41d5-f474-6a70-ef6e6bb232d8"),
				Name = @"SysInstalledApp",
				ReferenceSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("07ad6591-4101-4658-9723-3727b54bbadb"),
				ModifiedInSchemaUId = new Guid("07ad6591-4101-4658-9723-3727b54bbadb"),
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
			return new SysPluginPackageInApp(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysPluginPackageInApp_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysPluginPackageInAppSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysPluginPackageInAppSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("07ad6591-4101-4658-9723-3727b54bbadb"));
		}

		#endregion

	}

	#endregion

	#region Class: SysPluginPackageInApp

	/// <summary>
	/// Plugin package in installed application.
	/// </summary>
	public class SysPluginPackageInApp : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysPluginPackageInApp(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysPluginPackageInApp";
		}

		public SysPluginPackageInApp(SysPluginPackageInApp source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SysPluginPackageId {
			get {
				return GetTypedColumnValue<Guid>("SysPluginPackageId");
			}
			set {
				SetColumnValue("SysPluginPackageId", value);
				_sysPluginPackage = null;
			}
		}

		/// <exclude/>
		public string SysPluginPackageName {
			get {
				return GetTypedColumnValue<string>("SysPluginPackageName");
			}
			set {
				SetColumnValue("SysPluginPackageName", value);
				if (_sysPluginPackage != null) {
					_sysPluginPackage.Name = value;
				}
			}
		}

		private SysPluginPackage _sysPluginPackage;
		/// <summary>
		/// Plugin package.
		/// </summary>
		public SysPluginPackage SysPluginPackage {
			get {
				return _sysPluginPackage ??
					(_sysPluginPackage = LookupColumnEntities.GetEntity("SysPluginPackage") as SysPluginPackage);
			}
		}

		/// <exclude/>
		public Guid SysInstalledAppId {
			get {
				return GetTypedColumnValue<Guid>("SysInstalledAppId");
			}
			set {
				SetColumnValue("SysInstalledAppId", value);
				_sysInstalledApp = null;
			}
		}

		/// <exclude/>
		public string SysInstalledAppName {
			get {
				return GetTypedColumnValue<string>("SysInstalledAppName");
			}
			set {
				SetColumnValue("SysInstalledAppName", value);
				if (_sysInstalledApp != null) {
					_sysInstalledApp.Name = value;
				}
			}
		}

		private SysInstalledApp _sysInstalledApp;
		/// <summary>
		/// Installed application.
		/// </summary>
		public SysInstalledApp SysInstalledApp {
			get {
				return _sysInstalledApp ??
					(_sysInstalledApp = LookupColumnEntities.GetEntity("SysInstalledApp") as SysInstalledApp);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysPluginPackageInApp_CrtBaseEventsProcess(UserConnection);
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
			return new SysPluginPackageInApp(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysPluginPackageInApp_CrtBaseEventsProcess

	/// <exclude/>
	public partial class SysPluginPackageInApp_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysPluginPackageInApp
	{

		public SysPluginPackageInApp_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysPluginPackageInApp_CrtBaseEventsProcess";
			SchemaUId = new Guid("07ad6591-4101-4658-9723-3727b54bbadb");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("07ad6591-4101-4658-9723-3727b54bbadb");
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

	#region Class: SysPluginPackageInApp_CrtBaseEventsProcess

	/// <exclude/>
	public class SysPluginPackageInApp_CrtBaseEventsProcess : SysPluginPackageInApp_CrtBaseEventsProcess<SysPluginPackageInApp>
	{

		public SysPluginPackageInApp_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysPluginPackageInApp_CrtBaseEventsProcess

	public partial class SysPluginPackageInApp_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysPluginPackageInAppEventsProcess

	/// <exclude/>
	public class SysPluginPackageInAppEventsProcess : SysPluginPackageInApp_CrtBaseEventsProcess
	{

		public SysPluginPackageInAppEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

