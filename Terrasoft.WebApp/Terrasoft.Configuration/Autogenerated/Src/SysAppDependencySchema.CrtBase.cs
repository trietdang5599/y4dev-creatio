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

	#region Class: SysAppDependencySchema

	/// <exclude/>
	public class SysAppDependencySchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysAppDependencySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysAppDependencySchema(SysAppDependencySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysAppDependencySchema(SysAppDependencySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIUSysInstalledAppDependencyIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = true
			};
			index.UId = new Guid("7a98e32e-5d2b-48b4-98a5-ae7ddba28919");
			index.Name = "IUSysInstalledAppDependency";
			index.CreatedInSchemaUId = new Guid("4bbdf9e2-8610-494e-beac-e5db51341141");
			index.ModifiedInSchemaUId = new Guid("4bbdf9e2-8610-494e-beac-e5db51341141");
			index.CreatedInPackageId = new Guid("50f552a9-0668-454a-8ecf-9cb468aabd1f");
			EntitySchemaIndexColumn sysInstalledAppIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("247bcf56-ce02-86b4-62ca-3415ef5ecdfe"),
				ColumnUId = new Guid("03cb8c7c-15cf-ceec-74c4-a483906fb66f"),
				CreatedInSchemaUId = new Guid("4bbdf9e2-8610-494e-beac-e5db51341141"),
				ModifiedInSchemaUId = new Guid("4bbdf9e2-8610-494e-beac-e5db51341141"),
				CreatedInPackageId = new Guid("50f552a9-0668-454a-8ecf-9cb468aabd1f"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(sysInstalledAppIdIndexColumn);
			EntitySchemaIndexColumn dependOnApplicationIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("4d6568a0-4812-2905-4fb6-b41a4d3a6435"),
				ColumnUId = new Guid("c9770703-6c23-ed74-392a-8083b9df4d68"),
				CreatedInSchemaUId = new Guid("4bbdf9e2-8610-494e-beac-e5db51341141"),
				ModifiedInSchemaUId = new Guid("4bbdf9e2-8610-494e-beac-e5db51341141"),
				CreatedInPackageId = new Guid("50f552a9-0668-454a-8ecf-9cb468aabd1f"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(dependOnApplicationIdIndexColumn);
			EntitySchemaIndexColumn dependOnPackageIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("e5cc00dd-4a0d-e36e-bb80-12b35543a16d"),
				ColumnUId = new Guid("7b9ea85a-4c8d-d739-1784-95ab26125c86"),
				CreatedInSchemaUId = new Guid("4bbdf9e2-8610-494e-beac-e5db51341141"),
				ModifiedInSchemaUId = new Guid("4bbdf9e2-8610-494e-beac-e5db51341141"),
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(dependOnPackageIdIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4bbdf9e2-8610-494e-beac-e5db51341141");
			RealUId = new Guid("4bbdf9e2-8610-494e-beac-e5db51341141");
			Name = "SysAppDependency";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("50f552a9-0668-454a-8ecf-9cb468aabd1f");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("c9770703-6c23-ed74-392a-8083b9df4d68")) == null) {
				Columns.Add(CreateDependOnApplicationColumn());
			}
			if (Columns.FindByUId(new Guid("03cb8c7c-15cf-ceec-74c4-a483906fb66f")) == null) {
				Columns.Add(CreateSysInstalledAppColumn());
			}
			if (Columns.FindByUId(new Guid("7b9ea85a-4c8d-d739-1784-95ab26125c86")) == null) {
				Columns.Add(CreateDependOnPackageColumn());
			}
			if (Columns.FindByUId(new Guid("7a12e54f-f418-9c21-3d5c-6a95e9c0336d")) == null) {
				Columns.Add(CreateVersionColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateDependOnApplicationColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("c9770703-6c23-ed74-392a-8083b9df4d68"),
				Name = @"DependOnApplication",
				ReferenceSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("4bbdf9e2-8610-494e-beac-e5db51341141"),
				ModifiedInSchemaUId = new Guid("4bbdf9e2-8610-494e-beac-e5db51341141"),
				CreatedInPackageId = new Guid("50f552a9-0668-454a-8ecf-9cb468aabd1f")
			};
		}

		protected virtual EntitySchemaColumn CreateSysInstalledAppColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("03cb8c7c-15cf-ceec-74c4-a483906fb66f"),
				Name = @"SysInstalledApp",
				ReferenceSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("4bbdf9e2-8610-494e-beac-e5db51341141"),
				ModifiedInSchemaUId = new Guid("4bbdf9e2-8610-494e-beac-e5db51341141"),
				CreatedInPackageId = new Guid("50f552a9-0668-454a-8ecf-9cb468aabd1f")
			};
		}

		protected virtual EntitySchemaColumn CreateDependOnPackageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("7b9ea85a-4c8d-d739-1784-95ab26125c86"),
				Name = @"DependOnPackage",
				ReferenceSchemaUId = new Guid("ca400a85-ec48-4b42-8e50-271929d27871"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("4bbdf9e2-8610-494e-beac-e5db51341141"),
				ModifiedInSchemaUId = new Guid("4bbdf9e2-8610-494e-beac-e5db51341141"),
				CreatedInPackageId = new Guid("50f552a9-0668-454a-8ecf-9cb468aabd1f")
			};
		}

		protected virtual EntitySchemaColumn CreateVersionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("7a12e54f-f418-9c21-3d5c-6a95e9c0336d"),
				Name = @"Version",
				CreatedInSchemaUId = new Guid("4bbdf9e2-8610-494e-beac-e5db51341141"),
				ModifiedInSchemaUId = new Guid("4bbdf9e2-8610-494e-beac-e5db51341141"),
				CreatedInPackageId = new Guid("77b94243-de9a-4817-9eba-3b13fe75e30c")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIUSysInstalledAppDependencyIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysAppDependency(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysAppDependency_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysAppDependencySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysAppDependencySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4bbdf9e2-8610-494e-beac-e5db51341141"));
		}

		#endregion

	}

	#endregion

	#region Class: SysAppDependency

	/// <summary>
	/// Application dependencies.
	/// </summary>
	public class SysAppDependency : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysAppDependency(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysAppDependency";
		}

		public SysAppDependency(SysAppDependency source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid DependOnApplicationId {
			get {
				return GetTypedColumnValue<Guid>("DependOnApplicationId");
			}
			set {
				SetColumnValue("DependOnApplicationId", value);
				_dependOnApplication = null;
			}
		}

		/// <exclude/>
		public string DependOnApplicationName {
			get {
				return GetTypedColumnValue<string>("DependOnApplicationName");
			}
			set {
				SetColumnValue("DependOnApplicationName", value);
				if (_dependOnApplication != null) {
					_dependOnApplication.Name = value;
				}
			}
		}

		private SysInstalledApp _dependOnApplication;
		/// <summary>
		/// Depends on application.
		/// </summary>
		/// <remarks>
		/// Depends on application.
		/// </remarks>
		public SysInstalledApp DependOnApplication {
			get {
				return _dependOnApplication ??
					(_dependOnApplication = LookupColumnEntities.GetEntity("DependOnApplication") as SysInstalledApp);
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
		/// Application.
		/// </summary>
		public SysInstalledApp SysInstalledApp {
			get {
				return _sysInstalledApp ??
					(_sysInstalledApp = LookupColumnEntities.GetEntity("SysInstalledApp") as SysInstalledApp);
			}
		}

		/// <exclude/>
		public Guid DependOnPackageId {
			get {
				return GetTypedColumnValue<Guid>("DependOnPackageId");
			}
			set {
				SetColumnValue("DependOnPackageId", value);
				_dependOnPackage = null;
			}
		}

		/// <exclude/>
		public string DependOnPackageName {
			get {
				return GetTypedColumnValue<string>("DependOnPackageName");
			}
			set {
				SetColumnValue("DependOnPackageName", value);
				if (_dependOnPackage != null) {
					_dependOnPackage.Name = value;
				}
			}
		}

		private SysPackage _dependOnPackage;
		/// <summary>
		/// Depends on package.
		/// </summary>
		/// <remarks>
		/// Depends on package.
		/// </remarks>
		public SysPackage DependOnPackage {
			get {
				return _dependOnPackage ??
					(_dependOnPackage = LookupColumnEntities.GetEntity("DependOnPackage") as SysPackage);
			}
		}

		/// <summary>
		/// Version.
		/// </summary>
		public string Version {
			get {
				return GetTypedColumnValue<string>("Version");
			}
			set {
				SetColumnValue("Version", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysAppDependency_CrtBaseEventsProcess(UserConnection);
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
			return new SysAppDependency(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysAppDependency_CrtBaseEventsProcess

	/// <exclude/>
	public partial class SysAppDependency_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysAppDependency
	{

		public SysAppDependency_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysAppDependency_CrtBaseEventsProcess";
			SchemaUId = new Guid("4bbdf9e2-8610-494e-beac-e5db51341141");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("4bbdf9e2-8610-494e-beac-e5db51341141");
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

	#region Class: SysAppDependency_CrtBaseEventsProcess

	/// <exclude/>
	public class SysAppDependency_CrtBaseEventsProcess : SysAppDependency_CrtBaseEventsProcess<SysAppDependency>
	{

		public SysAppDependency_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysAppDependency_CrtBaseEventsProcess

	public partial class SysAppDependency_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysAppDependencyEventsProcess

	/// <exclude/>
	public class SysAppDependencyEventsProcess : SysAppDependency_CrtBaseEventsProcess
	{

		public SysAppDependencyEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

