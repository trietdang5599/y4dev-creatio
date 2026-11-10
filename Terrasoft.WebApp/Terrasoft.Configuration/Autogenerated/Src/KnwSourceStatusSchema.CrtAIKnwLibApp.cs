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

	#region Class: KnwSourceStatusSchema

	/// <exclude/>
	public class KnwSourceStatusSchema : Terrasoft.Configuration.BaseCodeLookupSchema
	{

		#region Constructors: Public

		public KnwSourceStatusSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public KnwSourceStatusSchema(KnwSourceStatusSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public KnwSourceStatusSchema(KnwSourceStatusSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ec6f6f58-f2c6-4659-83aa-8fa2ba04c433");
			RealUId = new Guid("ec6f6f58-f2c6-4659-83aa-8fa2ba04c433");
			Name = "KnwSourceStatus";
			ParentSchemaUId = new Guid("2681062b-df59-4e52-89ed-f9b7dc909ab2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("2c4cab0f-1fe9-47b5-95fa-4053b7ea1637");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = false;
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
			if (Columns.FindByUId(new Guid("3263d098-de65-9b45-f690-82da01d63755")) == null) {
				Columns.Add(CreateValueColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("3263d098-de65-9b45-f690-82da01d63755"),
				Name = @"Value",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("ec6f6f58-f2c6-4659-83aa-8fa2ba04c433"),
				ModifiedInSchemaUId = new Guid("ec6f6f58-f2c6-4659-83aa-8fa2ba04c433"),
				CreatedInPackageId = new Guid("4b4f6d9f-1234-44a2-bd3b-b64923d93c0c")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new KnwSourceStatus(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new KnwSourceStatus_CrtAIKnwLibAppEventsProcess(userConnection);
		}

		public override object Clone() {
			return new KnwSourceStatusSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new KnwSourceStatusSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ec6f6f58-f2c6-4659-83aa-8fa2ba04c433"));
		}

		#endregion

	}

	#endregion

	#region Class: KnwSourceStatus

	/// <summary>
	/// Knowledge source status.
	/// </summary>
	public class KnwSourceStatus : Terrasoft.Configuration.BaseCodeLookup
	{

		#region Constructors: Public

		public KnwSourceStatus(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "KnwSourceStatus";
		}

		public KnwSourceStatus(KnwSourceStatus source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Value.
		/// </summary>
		public int Value {
			get {
				return GetTypedColumnValue<int>("Value");
			}
			set {
				SetColumnValue("Value", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new KnwSourceStatus_CrtAIKnwLibAppEventsProcess(UserConnection);
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
			return new KnwSourceStatus(this);
		}

		#endregion

	}

	#endregion

	#region Class: KnwSourceStatus_CrtAIKnwLibAppEventsProcess

	/// <exclude/>
	public partial class KnwSourceStatus_CrtAIKnwLibAppEventsProcess<TEntity> : Terrasoft.Configuration.BaseCodeLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : KnwSourceStatus
	{

		public KnwSourceStatus_CrtAIKnwLibAppEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "KnwSourceStatus_CrtAIKnwLibAppEventsProcess";
			SchemaUId = new Guid("ec6f6f58-f2c6-4659-83aa-8fa2ba04c433");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ec6f6f58-f2c6-4659-83aa-8fa2ba04c433");
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

	#region Class: KnwSourceStatus_CrtAIKnwLibAppEventsProcess

	/// <exclude/>
	public class KnwSourceStatus_CrtAIKnwLibAppEventsProcess : KnwSourceStatus_CrtAIKnwLibAppEventsProcess<KnwSourceStatus>
	{

		public KnwSourceStatus_CrtAIKnwLibAppEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: KnwSourceStatus_CrtAIKnwLibAppEventsProcess

	public partial class KnwSourceStatus_CrtAIKnwLibAppEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: KnwSourceStatusEventsProcess

	/// <exclude/>
	public class KnwSourceStatusEventsProcess : KnwSourceStatus_CrtAIKnwLibAppEventsProcess
	{

		public KnwSourceStatusEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

