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

	#region Class: ProcessInModules_CrtBase_CreatioSchema

	/// <exclude/>
	public class ProcessInModules_CrtBase_CreatioSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ProcessInModules_CrtBase_CreatioSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ProcessInModules_CrtBase_CreatioSchema(ProcessInModules_CrtBase_CreatioSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ProcessInModules_CrtBase_CreatioSchema(ProcessInModules_CrtBase_CreatioSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("60c0cee6-ecb8-4987-bb4a-053bc314ee8d");
			RealUId = new Guid("60c0cee6-ecb8-4987-bb4a-053bc314ee8d");
			Name = "ProcessInModules_CrtBase_Creatio";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("4272a093-21fd-42d2-8625-8b2085681c68");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("4420cc5f-5a43-490b-b583-f8572ac29dce")) == null) {
				Columns.Add(CreateSysModuleColumn());
			}
			if (Columns.FindByUId(new Guid("a9f680eb-bc67-4aac-919e-0ad9f1000690")) == null) {
				Columns.Add(CreateSysSchemaUIdColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("60c0cee6-ecb8-4987-bb4a-053bc314ee8d");
			column.CreatedInPackageId = new Guid("4272a093-21fd-42d2-8625-8b2085681c68");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("60c0cee6-ecb8-4987-bb4a-053bc314ee8d");
			column.CreatedInPackageId = new Guid("4272a093-21fd-42d2-8625-8b2085681c68");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("60c0cee6-ecb8-4987-bb4a-053bc314ee8d");
			column.CreatedInPackageId = new Guid("4272a093-21fd-42d2-8625-8b2085681c68");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("60c0cee6-ecb8-4987-bb4a-053bc314ee8d");
			column.CreatedInPackageId = new Guid("4272a093-21fd-42d2-8625-8b2085681c68");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("60c0cee6-ecb8-4987-bb4a-053bc314ee8d");
			column.CreatedInPackageId = new Guid("4272a093-21fd-42d2-8625-8b2085681c68");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("60c0cee6-ecb8-4987-bb4a-053bc314ee8d");
			column.CreatedInPackageId = new Guid("4272a093-21fd-42d2-8625-8b2085681c68");
			return column;
		}

		protected virtual EntitySchemaColumn CreateSysModuleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("4420cc5f-5a43-490b-b583-f8572ac29dce"),
				Name = @"SysModule",
				ReferenceSchemaUId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("60c0cee6-ecb8-4987-bb4a-053bc314ee8d"),
				ModifiedInSchemaUId = new Guid("60c0cee6-ecb8-4987-bb4a-053bc314ee8d"),
				CreatedInPackageId = new Guid("4272a093-21fd-42d2-8625-8b2085681c68")
			};
		}

		protected virtual EntitySchemaColumn CreateSysSchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("a9f680eb-bc67-4aac-919e-0ad9f1000690"),
				Name = @"SysSchemaUId",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("60c0cee6-ecb8-4987-bb4a-053bc314ee8d"),
				ModifiedInSchemaUId = new Guid("60c0cee6-ecb8-4987-bb4a-053bc314ee8d"),
				CreatedInPackageId = new Guid("4272a093-21fd-42d2-8625-8b2085681c68")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ProcessInModules_CrtBase_Creatio(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ProcessInModules_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ProcessInModules_CrtBase_CreatioSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ProcessInModules_CrtBase_CreatioSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("60c0cee6-ecb8-4987-bb4a-053bc314ee8d"));
		}

		#endregion

	}

	#endregion

	#region Class: ProcessInModules_CrtBase_Creatio

	/// <summary>
	/// Business processes in sections.
	/// </summary>
	/// <remarks>
	/// Business processes in sections.
	/// </remarks>
	public class ProcessInModules_CrtBase_Creatio : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ProcessInModules_CrtBase_Creatio(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ProcessInModules_CrtBase_Creatio";
		}

		public ProcessInModules_CrtBase_Creatio(ProcessInModules_CrtBase_Creatio source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SysModuleId {
			get {
				return GetTypedColumnValue<Guid>("SysModuleId");
			}
			set {
				SetColumnValue("SysModuleId", value);
				_sysModule = null;
			}
		}

		/// <exclude/>
		public string SysModuleCaption {
			get {
				return GetTypedColumnValue<string>("SysModuleCaption");
			}
			set {
				SetColumnValue("SysModuleCaption", value);
				if (_sysModule != null) {
					_sysModule.Caption = value;
				}
			}
		}

		private SysModule _sysModule;
		/// <summary>
		/// Section.
		/// </summary>
		public SysModule SysModule {
			get {
				return _sysModule ??
					(_sysModule = LookupColumnEntities.GetEntity("SysModule") as SysModule);
			}
		}

		/// <summary>
		/// Process.
		/// </summary>
		public Guid SysSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("SysSchemaUId");
			}
			set {
				SetColumnValue("SysSchemaUId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ProcessInModules_CrtBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ProcessInModules_CrtBase_CreatioDeleted", e);
			Inserting += (s, e) => ThrowEvent("ProcessInModules_CrtBase_CreatioInserting", e);
			Validating += (s, e) => ThrowEvent("ProcessInModules_CrtBase_CreatioValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ProcessInModules_CrtBase_Creatio(this);
		}

		#endregion

	}

	#endregion

	#region Class: ProcessInModules_CrtBaseEventsProcess

	/// <exclude/>
	public partial class ProcessInModules_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : ProcessInModules_CrtBase_Creatio
	{

		public ProcessInModules_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ProcessInModules_CrtBaseEventsProcess";
			SchemaUId = new Guid("60c0cee6-ecb8-4987-bb4a-053bc314ee8d");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("60c0cee6-ecb8-4987-bb4a-053bc314ee8d");
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

	#region Class: ProcessInModules_CrtBaseEventsProcess

	/// <exclude/>
	public class ProcessInModules_CrtBaseEventsProcess : ProcessInModules_CrtBaseEventsProcess<ProcessInModules_CrtBase_Creatio>
	{

		public ProcessInModules_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ProcessInModules_CrtBaseEventsProcess

	public partial class ProcessInModules_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

