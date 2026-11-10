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

	#region Class: SysPkgInstallScriptSchema

	/// <exclude/>
	public class SysPkgInstallScriptSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysPkgInstallScriptSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysPkgInstallScriptSchema(SysPkgInstallScriptSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysPkgInstallScriptSchema(SysPkgInstallScriptSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("612b9f1a-cab4-439d-8c1b-f9c3cb1bfedb");
			RealUId = new Guid("612b9f1a-cab4-439d-8c1b-f9c3cb1bfedb");
			Name = "SysPkgInstallScript";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("85628317-7292-ee32-bf31-4027a0592175")) == null) {
				Columns.Add(CreatePositionColumn());
			}
			if (Columns.FindByUId(new Guid("de76bf33-f061-d6e8-0077-d5f3a5b34e2f")) == null) {
				Columns.Add(CreateInstallTypeColumn());
			}
			if (Columns.FindByUId(new Guid("603bd582-58e8-da9b-9e8c-9b2a670eeab1")) == null) {
				Columns.Add(CreateSysSchemaColumn());
			}
			if (Columns.FindByUId(new Guid("216413ff-acf1-4213-eaee-c52b660efe92")) == null) {
				Columns.Add(CreateSysPackageColumn());
			}
		}

		protected virtual EntitySchemaColumn CreatePositionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("85628317-7292-ee32-bf31-4027a0592175"),
				Name = @"Position",
				CreatedInSchemaUId = new Guid("612b9f1a-cab4-439d-8c1b-f9c3cb1bfedb"),
				ModifiedInSchemaUId = new Guid("612b9f1a-cab4-439d-8c1b-f9c3cb1bfedb"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected virtual EntitySchemaColumn CreateInstallTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("de76bf33-f061-d6e8-0077-d5f3a5b34e2f"),
				Name = @"InstallType",
				CreatedInSchemaUId = new Guid("612b9f1a-cab4-439d-8c1b-f9c3cb1bfedb"),
				ModifiedInSchemaUId = new Guid("612b9f1a-cab4-439d-8c1b-f9c3cb1bfedb"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected virtual EntitySchemaColumn CreateSysSchemaColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("603bd582-58e8-da9b-9e8c-9b2a670eeab1"),
				Name = @"SysSchema",
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("612b9f1a-cab4-439d-8c1b-f9c3cb1bfedb"),
				ModifiedInSchemaUId = new Guid("612b9f1a-cab4-439d-8c1b-f9c3cb1bfedb"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected virtual EntitySchemaColumn CreateSysPackageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("216413ff-acf1-4213-eaee-c52b660efe92"),
				Name = @"SysPackage",
				ReferenceSchemaUId = new Guid("ca400a85-ec48-4b42-8e50-271929d27871"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("612b9f1a-cab4-439d-8c1b-f9c3cb1bfedb"),
				ModifiedInSchemaUId = new Guid("612b9f1a-cab4-439d-8c1b-f9c3cb1bfedb"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysPkgInstallScript(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysPkgInstallScript_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysPkgInstallScriptSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysPkgInstallScriptSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("612b9f1a-cab4-439d-8c1b-f9c3cb1bfedb"));
		}

		#endregion

	}

	#endregion

	#region Class: SysPkgInstallScript

	/// <summary>
	/// Package install script.
	/// </summary>
	public class SysPkgInstallScript : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysPkgInstallScript(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysPkgInstallScript";
		}

		public SysPkgInstallScript(SysPkgInstallScript source)
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
		/// Install type.
		/// </summary>
		public int InstallType {
			get {
				return GetTypedColumnValue<int>("InstallType");
			}
			set {
				SetColumnValue("InstallType", value);
			}
		}

		/// <exclude/>
		public Guid SysSchemaId {
			get {
				return GetTypedColumnValue<Guid>("SysSchemaId");
			}
			set {
				SetColumnValue("SysSchemaId", value);
				_sysSchema = null;
			}
		}

		/// <exclude/>
		public string SysSchemaCaption {
			get {
				return GetTypedColumnValue<string>("SysSchemaCaption");
			}
			set {
				SetColumnValue("SysSchemaCaption", value);
				if (_sysSchema != null) {
					_sysSchema.Caption = value;
				}
			}
		}

		private SysSchema _sysSchema;
		/// <summary>
		/// Schema.
		/// </summary>
		public SysSchema SysSchema {
			get {
				return _sysSchema ??
					(_sysSchema = LookupColumnEntities.GetEntity("SysSchema") as SysSchema);
			}
		}

		/// <exclude/>
		public Guid SysPackageId {
			get {
				return GetTypedColumnValue<Guid>("SysPackageId");
			}
			set {
				SetColumnValue("SysPackageId", value);
				_sysPackage = null;
			}
		}

		/// <exclude/>
		public string SysPackageName {
			get {
				return GetTypedColumnValue<string>("SysPackageName");
			}
			set {
				SetColumnValue("SysPackageName", value);
				if (_sysPackage != null) {
					_sysPackage.Name = value;
				}
			}
		}

		private SysPackage _sysPackage;
		/// <summary>
		/// Package.
		/// </summary>
		public SysPackage SysPackage {
			get {
				return _sysPackage ??
					(_sysPackage = LookupColumnEntities.GetEntity("SysPackage") as SysPackage);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysPkgInstallScript_CrtBaseEventsProcess(UserConnection);
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
			return new SysPkgInstallScript(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysPkgInstallScript_CrtBaseEventsProcess

	/// <exclude/>
	public partial class SysPkgInstallScript_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysPkgInstallScript
	{

		public SysPkgInstallScript_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysPkgInstallScript_CrtBaseEventsProcess";
			SchemaUId = new Guid("612b9f1a-cab4-439d-8c1b-f9c3cb1bfedb");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("612b9f1a-cab4-439d-8c1b-f9c3cb1bfedb");
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

	#region Class: SysPkgInstallScript_CrtBaseEventsProcess

	/// <exclude/>
	public class SysPkgInstallScript_CrtBaseEventsProcess : SysPkgInstallScript_CrtBaseEventsProcess<SysPkgInstallScript>
	{

		public SysPkgInstallScript_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysPkgInstallScript_CrtBaseEventsProcess

	public partial class SysPkgInstallScript_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysPkgInstallScriptEventsProcess

	/// <exclude/>
	public class SysPkgInstallScriptEventsProcess : SysPkgInstallScript_CrtBaseEventsProcess
	{

		public SysPkgInstallScriptEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

