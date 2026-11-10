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

	#region Class: ProcessSchemaTypeSchema

	/// <exclude/>
	public class ProcessSchemaTypeSchema : Terrasoft.Configuration.BaseCodeLookupSchema
	{

		#region Constructors: Public

		public ProcessSchemaTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ProcessSchemaTypeSchema(ProcessSchemaTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ProcessSchemaTypeSchema(ProcessSchemaTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("cd5b7045-5f50-4fff-9b87-a4036df2355a");
			RealUId = new Guid("cd5b7045-5f50-4fff-9b87-a4036df2355a");
			Name = "ProcessSchemaType";
			ParentSchemaUId = new Guid("2681062b-df59-4e52-89ed-f9b7dc909ab2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("42153226-7fbf-4ddd-9a0b-5c3f0ef85ffa");
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
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("cd5b7045-5f50-4fff-9b87-a4036df2355a");
			column.CreatedInPackageId = new Guid("42153226-7fbf-4ddd-9a0b-5c3f0ef85ffa");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("cd5b7045-5f50-4fff-9b87-a4036df2355a");
			column.CreatedInPackageId = new Guid("42153226-7fbf-4ddd-9a0b-5c3f0ef85ffa");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("cd5b7045-5f50-4fff-9b87-a4036df2355a");
			column.CreatedInPackageId = new Guid("42153226-7fbf-4ddd-9a0b-5c3f0ef85ffa");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("cd5b7045-5f50-4fff-9b87-a4036df2355a");
			column.CreatedInPackageId = new Guid("42153226-7fbf-4ddd-9a0b-5c3f0ef85ffa");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("cd5b7045-5f50-4fff-9b87-a4036df2355a");
			column.CreatedInPackageId = new Guid("42153226-7fbf-4ddd-9a0b-5c3f0ef85ffa");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("cd5b7045-5f50-4fff-9b87-a4036df2355a");
			column.CreatedInPackageId = new Guid("42153226-7fbf-4ddd-9a0b-5c3f0ef85ffa");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("cd5b7045-5f50-4fff-9b87-a4036df2355a");
			column.CreatedInPackageId = new Guid("42153226-7fbf-4ddd-9a0b-5c3f0ef85ffa");
			return column;
		}

		protected override EntitySchemaColumn CreateCodeColumn() {
			EntitySchemaColumn column = base.CreateCodeColumn();
			column.ModifiedInSchemaUId = new Guid("cd5b7045-5f50-4fff-9b87-a4036df2355a");
			column.CreatedInPackageId = new Guid("42153226-7fbf-4ddd-9a0b-5c3f0ef85ffa");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("cd5b7045-5f50-4fff-9b87-a4036df2355a");
			column.CreatedInPackageId = new Guid("42153226-7fbf-4ddd-9a0b-5c3f0ef85ffa");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ProcessSchemaType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ProcessSchemaType_CrtCoreBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ProcessSchemaTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ProcessSchemaTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("cd5b7045-5f50-4fff-9b87-a4036df2355a"));
		}

		#endregion

	}

	#endregion

	#region Class: ProcessSchemaType

	/// <summary>
	/// Process schema type.
	/// </summary>
	public class ProcessSchemaType : Terrasoft.Configuration.BaseCodeLookup
	{

		#region Constructors: Public

		public ProcessSchemaType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ProcessSchemaType";
		}

		public ProcessSchemaType(ProcessSchemaType source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ProcessSchemaType_CrtCoreBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ProcessSchemaTypeDeleted", e);
			Inserting += (s, e) => ThrowEvent("ProcessSchemaTypeInserting", e);
			Validating += (s, e) => ThrowEvent("ProcessSchemaTypeValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ProcessSchemaType(this);
		}

		#endregion

	}

	#endregion

	#region Class: ProcessSchemaType_CrtCoreBaseEventsProcess

	/// <exclude/>
	public partial class ProcessSchemaType_CrtCoreBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseCodeLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : ProcessSchemaType
	{

		public ProcessSchemaType_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ProcessSchemaType_CrtCoreBaseEventsProcess";
			SchemaUId = new Guid("cd5b7045-5f50-4fff-9b87-a4036df2355a");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("cd5b7045-5f50-4fff-9b87-a4036df2355a");
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

	#region Class: ProcessSchemaType_CrtCoreBaseEventsProcess

	/// <exclude/>
	public class ProcessSchemaType_CrtCoreBaseEventsProcess : ProcessSchemaType_CrtCoreBaseEventsProcess<ProcessSchemaType>
	{

		public ProcessSchemaType_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ProcessSchemaType_CrtCoreBaseEventsProcess

	public partial class ProcessSchemaType_CrtCoreBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ProcessSchemaTypeEventsProcess

	/// <exclude/>
	public class ProcessSchemaTypeEventsProcess : ProcessSchemaType_CrtCoreBaseEventsProcess
	{

		public ProcessSchemaTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

