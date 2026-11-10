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

	#region Class: ProcessSequenceElementSchema

	/// <exclude/>
	public class ProcessSequenceElementSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ProcessSequenceElementSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ProcessSequenceElementSchema(ProcessSequenceElementSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ProcessSequenceElementSchema(ProcessSequenceElementSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("56143364-4580-4561-8814-8612fad2e5c0");
			RealUId = new Guid("56143364-4580-4561-8814-8612fad2e5c0");
			Name = "ProcessSequenceElement";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("3432d218-3bc3-4074-87f5-6b2d0cbf0877");
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
			if (Columns.FindByUId(new Guid("5c8bb0ef-1516-57b5-c5b6-94b7332c1ce4")) == null) {
				Columns.Add(CreatePositionColumn());
			}
			if (Columns.FindByUId(new Guid("28a9c973-6afb-d75f-c79d-28c2a799c7a4")) == null) {
				Columns.Add(CreateElementCodeColumn());
			}
			if (Columns.FindByUId(new Guid("a560b24e-662f-682a-626a-9a20de834c0e")) == null) {
				Columns.Add(CreateProcessSchemaUIdColumn());
			}
			if (Columns.FindByUId(new Guid("ae9b8eec-e94b-a0cf-37e7-b39e548dd5be")) == null) {
				Columns.Add(CreateSequenceIdColumn());
			}
			if (Columns.FindByUId(new Guid("f5c20589-fbef-2a1d-e575-3de9c5346305")) == null) {
				Columns.Add(CreateProcessSchemaNameColumn());
			}
		}

		protected virtual EntitySchemaColumn CreatePositionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("5c8bb0ef-1516-57b5-c5b6-94b7332c1ce4"),
				Name = @"Position",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("56143364-4580-4561-8814-8612fad2e5c0"),
				ModifiedInSchemaUId = new Guid("56143364-4580-4561-8814-8612fad2e5c0"),
				CreatedInPackageId = new Guid("3432d218-3bc3-4074-87f5-6b2d0cbf0877")
			};
		}

		protected virtual EntitySchemaColumn CreateElementCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("28a9c973-6afb-d75f-c79d-28c2a799c7a4"),
				Name = @"ElementCode",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("56143364-4580-4561-8814-8612fad2e5c0"),
				ModifiedInSchemaUId = new Guid("56143364-4580-4561-8814-8612fad2e5c0"),
				CreatedInPackageId = new Guid("3432d218-3bc3-4074-87f5-6b2d0cbf0877")
			};
		}

		protected virtual EntitySchemaColumn CreateProcessSchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("a560b24e-662f-682a-626a-9a20de834c0e"),
				Name = @"ProcessSchemaUId",
				CreatedInSchemaUId = new Guid("56143364-4580-4561-8814-8612fad2e5c0"),
				ModifiedInSchemaUId = new Guid("56143364-4580-4561-8814-8612fad2e5c0"),
				CreatedInPackageId = new Guid("3432d218-3bc3-4074-87f5-6b2d0cbf0877")
			};
		}

		protected virtual EntitySchemaColumn CreateSequenceIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("ae9b8eec-e94b-a0cf-37e7-b39e548dd5be"),
				Name = @"SequenceId",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("56143364-4580-4561-8814-8612fad2e5c0"),
				ModifiedInSchemaUId = new Guid("56143364-4580-4561-8814-8612fad2e5c0"),
				CreatedInPackageId = new Guid("3432d218-3bc3-4074-87f5-6b2d0cbf0877")
			};
		}

		protected virtual EntitySchemaColumn CreateProcessSchemaNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("f5c20589-fbef-2a1d-e575-3de9c5346305"),
				Name = @"ProcessSchemaName",
				CreatedInSchemaUId = new Guid("56143364-4580-4561-8814-8612fad2e5c0"),
				ModifiedInSchemaUId = new Guid("56143364-4580-4561-8814-8612fad2e5c0"),
				CreatedInPackageId = new Guid("74aeae22-acf1-4ea0-a9a3-4520bc167c1b")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ProcessSequenceElement(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ProcessSequenceElement_MLProcessDesignerEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ProcessSequenceElementSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ProcessSequenceElementSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("56143364-4580-4561-8814-8612fad2e5c0"));
		}

		#endregion

	}

	#endregion

	#region Class: ProcessSequenceElement

	/// <summary>
	/// ProcessSequenceElement.
	/// </summary>
	public class ProcessSequenceElement : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ProcessSequenceElement(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ProcessSequenceElement";
		}

		public ProcessSequenceElement(ProcessSequenceElement source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Position.
		/// </summary>
		/// <remarks>
		/// Element position in sequence.
		/// </remarks>
		public int Position {
			get {
				return GetTypedColumnValue<int>("Position");
			}
			set {
				SetColumnValue("Position", value);
			}
		}

		/// <summary>
		/// Code of element.
		/// </summary>
		public string ElementCode {
			get {
				return GetTypedColumnValue<string>("ElementCode");
			}
			set {
				SetColumnValue("ElementCode", value);
			}
		}

		/// <summary>
		/// Schema unique identifier of source process.
		/// </summary>
		public Guid ProcessSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("ProcessSchemaUId");
			}
			set {
				SetColumnValue("ProcessSchemaUId", value);
			}
		}

		/// <summary>
		/// Identifier of sequence.
		/// </summary>
		public Guid SequenceId {
			get {
				return GetTypedColumnValue<Guid>("SequenceId");
			}
			set {
				SetColumnValue("SequenceId", value);
			}
		}

		/// <summary>
		/// Process name.
		/// </summary>
		public string ProcessSchemaName {
			get {
				return GetTypedColumnValue<string>("ProcessSchemaName");
			}
			set {
				SetColumnValue("ProcessSchemaName", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ProcessSequenceElement_MLProcessDesignerEventsProcess(UserConnection);
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
			return new ProcessSequenceElement(this);
		}

		#endregion

	}

	#endregion

	#region Class: ProcessSequenceElement_MLProcessDesignerEventsProcess

	/// <exclude/>
	public partial class ProcessSequenceElement_MLProcessDesignerEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : ProcessSequenceElement
	{

		public ProcessSequenceElement_MLProcessDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ProcessSequenceElement_MLProcessDesignerEventsProcess";
			SchemaUId = new Guid("56143364-4580-4561-8814-8612fad2e5c0");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("56143364-4580-4561-8814-8612fad2e5c0");
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

	#region Class: ProcessSequenceElement_MLProcessDesignerEventsProcess

	/// <exclude/>
	public class ProcessSequenceElement_MLProcessDesignerEventsProcess : ProcessSequenceElement_MLProcessDesignerEventsProcess<ProcessSequenceElement>
	{

		public ProcessSequenceElement_MLProcessDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ProcessSequenceElement_MLProcessDesignerEventsProcess

	public partial class ProcessSequenceElement_MLProcessDesignerEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ProcessSequenceElementEventsProcess

	/// <exclude/>
	public class ProcessSequenceElementEventsProcess : ProcessSequenceElement_MLProcessDesignerEventsProcess
	{

		public ProcessSequenceElementEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

