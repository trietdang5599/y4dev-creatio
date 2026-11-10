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

	#region Class: ImportSessionSchema

	/// <exclude/>
	public class ImportSessionSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ImportSessionSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ImportSessionSchema(ImportSessionSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ImportSessionSchema(ImportSessionSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a6374de9-cff0-40b1-a7b7-f2dc8ecc0531");
			RealUId = new Guid("a6374de9-cff0-40b1-a7b7-f2dc8ecc0531");
			Name = "ImportSession";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("79cdeed7-eef0-4dd8-9765-07d140cf1035");
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

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("7f65eb85-dbdc-48fb-9c22-05a7c076dad8")) == null) {
				Columns.Add(CreateIsCanceledColumn());
			}
			if (Columns.FindByUId(new Guid("baf144cc-7880-4c10-8c5e-1d6a9aee78dd")) == null) {
				Columns.Add(CreateProcessIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateIsCanceledColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("7f65eb85-dbdc-48fb-9c22-05a7c076dad8"),
				Name = @"IsCanceled",
				CreatedInSchemaUId = new Guid("a6374de9-cff0-40b1-a7b7-f2dc8ecc0531"),
				ModifiedInSchemaUId = new Guid("a6374de9-cff0-40b1-a7b7-f2dc8ecc0531"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateProcessIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("baf144cc-7880-4c10-8c5e-1d6a9aee78dd"),
				Name = @"ProcessId",
				CreatedInSchemaUId = new Guid("a6374de9-cff0-40b1-a7b7-f2dc8ecc0531"),
				ModifiedInSchemaUId = new Guid("a6374de9-cff0-40b1-a7b7-f2dc8ecc0531"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ImportSession(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ImportSession_CrtFileImportEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ImportSessionSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ImportSessionSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a6374de9-cff0-40b1-a7b7-f2dc8ecc0531"));
		}

		#endregion

	}

	#endregion

	#region Class: ImportSession

	/// <summary>
	/// ImportSession.
	/// </summary>
	public class ImportSession : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ImportSession(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ImportSession";
		}

		public ImportSession(ImportSession source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// IsCanceled.
		/// </summary>
		public bool IsCanceled {
			get {
				return GetTypedColumnValue<bool>("IsCanceled");
			}
			set {
				SetColumnValue("IsCanceled", value);
			}
		}

		/// <summary>
		/// ProcessId.
		/// </summary>
		public Guid ProcessId {
			get {
				return GetTypedColumnValue<Guid>("ProcessId");
			}
			set {
				SetColumnValue("ProcessId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ImportSession_CrtFileImportEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ImportSessionDeleted", e);
			Validating += (s, e) => ThrowEvent("ImportSessionValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ImportSession(this);
		}

		#endregion

	}

	#endregion

	#region Class: ImportSession_CrtFileImportEventsProcess

	/// <exclude/>
	public partial class ImportSession_CrtFileImportEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : ImportSession
	{

		public ImportSession_CrtFileImportEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ImportSession_CrtFileImportEventsProcess";
			SchemaUId = new Guid("a6374de9-cff0-40b1-a7b7-f2dc8ecc0531");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("a6374de9-cff0-40b1-a7b7-f2dc8ecc0531");
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

	#region Class: ImportSession_CrtFileImportEventsProcess

	/// <exclude/>
	public class ImportSession_CrtFileImportEventsProcess : ImportSession_CrtFileImportEventsProcess<ImportSession>
	{

		public ImportSession_CrtFileImportEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ImportSession_CrtFileImportEventsProcess

	public partial class ImportSession_CrtFileImportEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ImportSessionEventsProcess

	/// <exclude/>
	public class ImportSessionEventsProcess : ImportSession_CrtFileImportEventsProcess
	{

		public ImportSessionEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

