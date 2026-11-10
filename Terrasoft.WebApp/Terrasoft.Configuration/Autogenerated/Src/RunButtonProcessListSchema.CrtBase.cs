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

	#region Class: RunButtonProcessList_CrtBase_CreatioSchema

	/// <exclude/>
	public class RunButtonProcessList_CrtBase_CreatioSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public RunButtonProcessList_CrtBase_CreatioSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public RunButtonProcessList_CrtBase_CreatioSchema(RunButtonProcessList_CrtBase_CreatioSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public RunButtonProcessList_CrtBase_CreatioSchema(RunButtonProcessList_CrtBase_CreatioSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("9d6c6255-e35d-4af0-9e20-85feff01e245");
			RealUId = new Guid("9d6c6255-e35d-4af0-9e20-85feff01e245");
			Name = "RunButtonProcessList_CrtBase_Creatio";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("f92f6bea-5f0b-420e-8adc-843ed74daca8");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("e3c93e3d-7f92-4a2c-92c1-92608c3370fa")) == null) {
				Columns.Add(CreateSysSchemaUIdColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("9d6c6255-e35d-4af0-9e20-85feff01e245");
			column.CreatedInPackageId = new Guid("f92f6bea-5f0b-420e-8adc-843ed74daca8");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("9d6c6255-e35d-4af0-9e20-85feff01e245");
			column.CreatedInPackageId = new Guid("f92f6bea-5f0b-420e-8adc-843ed74daca8");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("9d6c6255-e35d-4af0-9e20-85feff01e245");
			column.CreatedInPackageId = new Guid("f92f6bea-5f0b-420e-8adc-843ed74daca8");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("9d6c6255-e35d-4af0-9e20-85feff01e245");
			column.CreatedInPackageId = new Guid("f92f6bea-5f0b-420e-8adc-843ed74daca8");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("9d6c6255-e35d-4af0-9e20-85feff01e245");
			column.CreatedInPackageId = new Guid("f92f6bea-5f0b-420e-8adc-843ed74daca8");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("9d6c6255-e35d-4af0-9e20-85feff01e245");
			column.CreatedInPackageId = new Guid("f92f6bea-5f0b-420e-8adc-843ed74daca8");
			return column;
		}

		protected virtual EntitySchemaColumn CreateSysSchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("e3c93e3d-7f92-4a2c-92c1-92608c3370fa"),
				Name = @"SysSchemaUId",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("9d6c6255-e35d-4af0-9e20-85feff01e245"),
				ModifiedInSchemaUId = new Guid("9d6c6255-e35d-4af0-9e20-85feff01e245"),
				CreatedInPackageId = new Guid("f92f6bea-5f0b-420e-8adc-843ed74daca8")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new RunButtonProcessList_CrtBase_Creatio(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new RunButtonProcessList_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new RunButtonProcessList_CrtBase_CreatioSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new RunButtonProcessList_CrtBase_CreatioSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9d6c6255-e35d-4af0-9e20-85feff01e245"));
		}

		#endregion

	}

	#endregion

	#region Class: RunButtonProcessList_CrtBase_Creatio

	/// <summary>
	/// Run process button list setup.
	/// </summary>
	/// <remarks>
	/// Run process button list setup.
	/// </remarks>
	public class RunButtonProcessList_CrtBase_Creatio : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public RunButtonProcessList_CrtBase_Creatio(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "RunButtonProcessList_CrtBase_Creatio";
		}

		public RunButtonProcessList_CrtBase_Creatio(RunButtonProcessList_CrtBase_Creatio source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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
			var process = new RunButtonProcessList_CrtBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("RunButtonProcessList_CrtBase_CreatioDeleted", e);
			Inserting += (s, e) => ThrowEvent("RunButtonProcessList_CrtBase_CreatioInserting", e);
			Validating += (s, e) => ThrowEvent("RunButtonProcessList_CrtBase_CreatioValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new RunButtonProcessList_CrtBase_Creatio(this);
		}

		#endregion

	}

	#endregion

	#region Class: RunButtonProcessList_CrtBaseEventsProcess

	/// <exclude/>
	public partial class RunButtonProcessList_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : RunButtonProcessList_CrtBase_Creatio
	{

		public RunButtonProcessList_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "RunButtonProcessList_CrtBaseEventsProcess";
			SchemaUId = new Guid("9d6c6255-e35d-4af0-9e20-85feff01e245");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("9d6c6255-e35d-4af0-9e20-85feff01e245");
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

	#region Class: RunButtonProcessList_CrtBaseEventsProcess

	/// <exclude/>
	public class RunButtonProcessList_CrtBaseEventsProcess : RunButtonProcessList_CrtBaseEventsProcess<RunButtonProcessList_CrtBase_Creatio>
	{

		public RunButtonProcessList_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: RunButtonProcessList_CrtBaseEventsProcess

	public partial class RunButtonProcessList_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

