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

	#region Class: SysInactivePackageInAppSchema

	/// <exclude/>
	public class SysInactivePackageInAppSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysInactivePackageInAppSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysInactivePackageInAppSchema(SysInactivePackageInAppSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysInactivePackageInAppSchema(SysInactivePackageInAppSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a148cfde-745d-4d6a-a6d6-e854e62335af");
			RealUId = new Guid("a148cfde-745d-4d6a-a6d6-e854e62335af");
			Name = "SysInactivePackageInApp";
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
			if (Columns.FindByUId(new Guid("b4fb58ed-e1a4-4b91-71f0-bdeadee9fabd")) == null) {
				Columns.Add(CreateSysInstalledAppColumn());
			}
			if (Columns.FindByUId(new Guid("fd53a80e-bb94-df1a-45f3-560fc7121677")) == null) {
				Columns.Add(CreateSysInactivePackageColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysInstalledAppColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("b4fb58ed-e1a4-4b91-71f0-bdeadee9fabd"),
				Name = @"SysInstalledApp",
				ReferenceSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("a148cfde-745d-4d6a-a6d6-e854e62335af"),
				ModifiedInSchemaUId = new Guid("a148cfde-745d-4d6a-a6d6-e854e62335af"),
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723")
			};
		}

		protected virtual EntitySchemaColumn CreateSysInactivePackageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("fd53a80e-bb94-df1a-45f3-560fc7121677"),
				Name = @"SysInactivePackage",
				ReferenceSchemaUId = new Guid("5d496d77-eb2c-d0a5-3ac1-6d283af2fc13"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("a148cfde-745d-4d6a-a6d6-e854e62335af"),
				ModifiedInSchemaUId = new Guid("a148cfde-745d-4d6a-a6d6-e854e62335af"),
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
			return new SysInactivePackageInApp(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysInactivePackageInApp_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysInactivePackageInAppSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysInactivePackageInAppSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a148cfde-745d-4d6a-a6d6-e854e62335af"));
		}

		#endregion

	}

	#endregion

	#region Class: SysInactivePackageInApp

	/// <summary>
	/// Inactive package in installed application.
	/// </summary>
	public class SysInactivePackageInApp : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysInactivePackageInApp(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysInactivePackageInApp";
		}

		public SysInactivePackageInApp(SysInactivePackageInApp source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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

		/// <exclude/>
		public Guid SysInactivePackageId {
			get {
				return GetTypedColumnValue<Guid>("SysInactivePackageId");
			}
			set {
				SetColumnValue("SysInactivePackageId", value);
				_sysInactivePackage = null;
			}
		}

		/// <exclude/>
		public string SysInactivePackageName {
			get {
				return GetTypedColumnValue<string>("SysInactivePackageName");
			}
			set {
				SetColumnValue("SysInactivePackageName", value);
				if (_sysInactivePackage != null) {
					_sysInactivePackage.Name = value;
				}
			}
		}

		private SysInactivePackage _sysInactivePackage;
		/// <summary>
		/// Inactive package.
		/// </summary>
		public SysInactivePackage SysInactivePackage {
			get {
				return _sysInactivePackage ??
					(_sysInactivePackage = LookupColumnEntities.GetEntity("SysInactivePackage") as SysInactivePackage);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysInactivePackageInApp_CrtBaseEventsProcess(UserConnection);
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
			return new SysInactivePackageInApp(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysInactivePackageInApp_CrtBaseEventsProcess

	/// <exclude/>
	public partial class SysInactivePackageInApp_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysInactivePackageInApp
	{

		public SysInactivePackageInApp_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysInactivePackageInApp_CrtBaseEventsProcess";
			SchemaUId = new Guid("a148cfde-745d-4d6a-a6d6-e854e62335af");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("a148cfde-745d-4d6a-a6d6-e854e62335af");
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

	#region Class: SysInactivePackageInApp_CrtBaseEventsProcess

	/// <exclude/>
	public class SysInactivePackageInApp_CrtBaseEventsProcess : SysInactivePackageInApp_CrtBaseEventsProcess<SysInactivePackageInApp>
	{

		public SysInactivePackageInApp_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysInactivePackageInApp_CrtBaseEventsProcess

	public partial class SysInactivePackageInApp_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysInactivePackageInAppEventsProcess

	/// <exclude/>
	public class SysInactivePackageInAppEventsProcess : SysInactivePackageInApp_CrtBaseEventsProcess
	{

		public SysInactivePackageInAppEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

