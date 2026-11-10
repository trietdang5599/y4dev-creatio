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

	#region Class: CompilationHistory_CrtBase_CreatioSchema

	/// <exclude/>
	public class CompilationHistory_CrtBase_CreatioSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public CompilationHistory_CrtBase_CreatioSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CompilationHistory_CrtBase_CreatioSchema(CompilationHistory_CrtBase_CreatioSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CompilationHistory_CrtBase_CreatioSchema(CompilationHistory_CrtBase_CreatioSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4b57024f-c037-47f6-af95-04677d2e8f1e");
			RealUId = new Guid("4b57024f-c037-47f6-af95-04677d2e8f1e");
			Name = "CompilationHistory_CrtBase_Creatio";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("acb004d0-c421-4dff-b075-f4fdc1c90074");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = false;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateProjectNameColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("a8a849fc-d0e6-d637-4524-b4ac62d22164")) == null) {
				Columns.Add(CreateErrorsWarningsColumn());
			}
			if (Columns.FindByUId(new Guid("9c1ae07a-7a1f-bfb0-54d2-9105acd3820f")) == null) {
				Columns.Add(CreateResultColumn());
			}
			if (Columns.FindByUId(new Guid("dc0eb9d4-cddb-db57-95fe-aa8db9bdb6d7")) == null) {
				Columns.Add(CreateDurationInSecondsColumn());
			}
			if (Columns.FindByUId(new Guid("05fd09e3-0e8a-8aca-9c8b-352df6ea6311")) == null) {
				Columns.Add(CreateStartedByColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateErrorsWarningsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("a8a849fc-d0e6-d637-4524-b4ac62d22164"),
				Name = @"ErrorsWarnings",
				CreatedInSchemaUId = new Guid("4b57024f-c037-47f6-af95-04677d2e8f1e"),
				ModifiedInSchemaUId = new Guid("4b57024f-c037-47f6-af95-04677d2e8f1e"),
				CreatedInPackageId = new Guid("acb004d0-c421-4dff-b075-f4fdc1c90074")
			};
		}

		protected virtual EntitySchemaColumn CreateResultColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("9c1ae07a-7a1f-bfb0-54d2-9105acd3820f"),
				Name = @"Result",
				CreatedInSchemaUId = new Guid("4b57024f-c037-47f6-af95-04677d2e8f1e"),
				ModifiedInSchemaUId = new Guid("4b57024f-c037-47f6-af95-04677d2e8f1e"),
				CreatedInPackageId = new Guid("acb004d0-c421-4dff-b075-f4fdc1c90074")
			};
		}

		protected virtual EntitySchemaColumn CreateProjectNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("b574967f-70c3-495f-2e3c-4fdb0ab1be34"),
				Name = @"ProjectName",
				CreatedInSchemaUId = new Guid("4b57024f-c037-47f6-af95-04677d2e8f1e"),
				ModifiedInSchemaUId = new Guid("4b57024f-c037-47f6-af95-04677d2e8f1e"),
				CreatedInPackageId = new Guid("acb004d0-c421-4dff-b075-f4fdc1c90074")
			};
		}

		protected virtual EntitySchemaColumn CreateDurationInSecondsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("dc0eb9d4-cddb-db57-95fe-aa8db9bdb6d7"),
				Name = @"DurationInSeconds",
				CreatedInSchemaUId = new Guid("4b57024f-c037-47f6-af95-04677d2e8f1e"),
				ModifiedInSchemaUId = new Guid("4b57024f-c037-47f6-af95-04677d2e8f1e"),
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723")
			};
		}

		protected virtual EntitySchemaColumn CreateStartedByColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("05fd09e3-0e8a-8aca-9c8b-352df6ea6311"),
				Name = @"StartedBy",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				IsIndexed = true,
				IsWeakReference = true,
				UsageType = EntitySchemaColumnUsageType.Advanced,
				CreatedInSchemaUId = new Guid("4b57024f-c037-47f6-af95-04677d2e8f1e"),
				ModifiedInSchemaUId = new Guid("4b57024f-c037-47f6-af95-04677d2e8f1e"),
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
			return new CompilationHistory_CrtBase_Creatio(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CompilationHistory_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CompilationHistory_CrtBase_CreatioSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CompilationHistory_CrtBase_CreatioSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4b57024f-c037-47f6-af95-04677d2e8f1e"));
		}

		#endregion

	}

	#endregion

	#region Class: CompilationHistory_CrtBase_Creatio

	/// <summary>
	/// Compilation history.
	/// </summary>
	public class CompilationHistory_CrtBase_Creatio : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public CompilationHistory_CrtBase_Creatio(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CompilationHistory_CrtBase_Creatio";
		}

		public CompilationHistory_CrtBase_Creatio(CompilationHistory_CrtBase_Creatio source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Errors/Warnings.
		/// </summary>
		public string ErrorsWarnings {
			get {
				return GetTypedColumnValue<string>("ErrorsWarnings");
			}
			set {
				SetColumnValue("ErrorsWarnings", value);
			}
		}

		/// <summary>
		/// Result.
		/// </summary>
		public bool Result {
			get {
				return GetTypedColumnValue<bool>("Result");
			}
			set {
				SetColumnValue("Result", value);
			}
		}

		/// <summary>
		/// Project Name.
		/// </summary>
		public string ProjectName {
			get {
				return GetTypedColumnValue<string>("ProjectName");
			}
			set {
				SetColumnValue("ProjectName", value);
			}
		}

		/// <summary>
		/// Duration in seconds.
		/// </summary>
		public int DurationInSeconds {
			get {
				return GetTypedColumnValue<int>("DurationInSeconds");
			}
			set {
				SetColumnValue("DurationInSeconds", value);
			}
		}

		/// <exclude/>
		public Guid StartedById {
			get {
				return GetTypedColumnValue<Guid>("StartedById");
			}
			set {
				SetColumnValue("StartedById", value);
				_startedBy = null;
			}
		}

		/// <exclude/>
		public string StartedByName {
			get {
				return GetTypedColumnValue<string>("StartedByName");
			}
			set {
				SetColumnValue("StartedByName", value);
				if (_startedBy != null) {
					_startedBy.Name = value;
				}
			}
		}

		private SysAdminUnit _startedBy;
		/// <summary>
		/// Started by.
		/// </summary>
		public SysAdminUnit StartedBy {
			get {
				return _startedBy ??
					(_startedBy = LookupColumnEntities.GetEntity("StartedBy") as SysAdminUnit);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CompilationHistory_CrtBaseEventsProcess(UserConnection);
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
			return new CompilationHistory_CrtBase_Creatio(this);
		}

		#endregion

	}

	#endregion

	#region Class: CompilationHistory_CrtBaseEventsProcess

	/// <exclude/>
	public partial class CompilationHistory_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : CompilationHistory_CrtBase_Creatio
	{

		public CompilationHistory_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CompilationHistory_CrtBaseEventsProcess";
			SchemaUId = new Guid("4b57024f-c037-47f6-af95-04677d2e8f1e");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("4b57024f-c037-47f6-af95-04677d2e8f1e");
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

	#region Class: CompilationHistory_CrtBaseEventsProcess

	/// <exclude/>
	public class CompilationHistory_CrtBaseEventsProcess : CompilationHistory_CrtBaseEventsProcess<CompilationHistory_CrtBase_Creatio>
	{

		public CompilationHistory_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CompilationHistory_CrtBaseEventsProcess

	public partial class CompilationHistory_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

