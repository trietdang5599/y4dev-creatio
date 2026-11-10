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

	#region Class: SysPluginPackageDepsSchema

	/// <exclude/>
	public class SysPluginPackageDepsSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysPluginPackageDepsSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysPluginPackageDepsSchema(SysPluginPackageDepsSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysPluginPackageDepsSchema(SysPluginPackageDepsSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e7b9c244-0d45-4a14-83c8-d1499d57e674");
			RealUId = new Guid("e7b9c244-0d45-4a14-83c8-d1499d57e674");
			Name = "SysPluginPackageDeps";
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
			if (Columns.FindByUId(new Guid("98a71bb8-d034-2021-0f99-941cea270b0d")) == null) {
				Columns.Add(CreateSysPluginPackageColumn());
			}
			if (Columns.FindByUId(new Guid("7197b0aa-f10e-c51b-ff6a-2aa12604b032")) == null) {
				Columns.Add(CreateSysPackageUIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysPluginPackageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("98a71bb8-d034-2021-0f99-941cea270b0d"),
				Name = @"SysPluginPackage",
				ReferenceSchemaUId = new Guid("80567be7-99c2-41c7-923a-ee9ec17ad93c"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("e7b9c244-0d45-4a14-83c8-d1499d57e674"),
				ModifiedInSchemaUId = new Guid("e7b9c244-0d45-4a14-83c8-d1499d57e674"),
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723")
			};
		}

		protected virtual EntitySchemaColumn CreateSysPackageUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("7197b0aa-f10e-c51b-ff6a-2aa12604b032"),
				Name = @"SysPackageUId",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("e7b9c244-0d45-4a14-83c8-d1499d57e674"),
				ModifiedInSchemaUId = new Guid("e7b9c244-0d45-4a14-83c8-d1499d57e674"),
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
			return new SysPluginPackageDeps(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysPluginPackageDeps_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysPluginPackageDepsSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysPluginPackageDepsSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e7b9c244-0d45-4a14-83c8-d1499d57e674"));
		}

		#endregion

	}

	#endregion

	#region Class: SysPluginPackageDeps

	/// <summary>
	/// Plugin package dependencies.
	/// </summary>
	public class SysPluginPackageDeps : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysPluginPackageDeps(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysPluginPackageDeps";
		}

		public SysPluginPackageDeps(SysPluginPackageDeps source)
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

		/// <summary>
		/// Package UId.
		/// </summary>
		public Guid SysPackageUId {
			get {
				return GetTypedColumnValue<Guid>("SysPackageUId");
			}
			set {
				SetColumnValue("SysPackageUId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysPluginPackageDeps_CrtBaseEventsProcess(UserConnection);
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
			return new SysPluginPackageDeps(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysPluginPackageDeps_CrtBaseEventsProcess

	/// <exclude/>
	public partial class SysPluginPackageDeps_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysPluginPackageDeps
	{

		public SysPluginPackageDeps_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysPluginPackageDeps_CrtBaseEventsProcess";
			SchemaUId = new Guid("e7b9c244-0d45-4a14-83c8-d1499d57e674");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("e7b9c244-0d45-4a14-83c8-d1499d57e674");
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

	#region Class: SysPluginPackageDeps_CrtBaseEventsProcess

	/// <exclude/>
	public class SysPluginPackageDeps_CrtBaseEventsProcess : SysPluginPackageDeps_CrtBaseEventsProcess<SysPluginPackageDeps>
	{

		public SysPluginPackageDeps_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysPluginPackageDeps_CrtBaseEventsProcess

	public partial class SysPluginPackageDeps_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysPluginPackageDepsEventsProcess

	/// <exclude/>
	public class SysPluginPackageDepsEventsProcess : SysPluginPackageDeps_CrtBaseEventsProcess
	{

		public SysPluginPackageDepsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

