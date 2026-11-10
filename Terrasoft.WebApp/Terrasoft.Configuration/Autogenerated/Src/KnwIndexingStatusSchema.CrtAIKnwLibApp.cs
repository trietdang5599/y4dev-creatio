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

	#region Class: KnwIndexingStatusSchema

	/// <exclude/>
	public class KnwIndexingStatusSchema : Terrasoft.Configuration.BaseCodeLookupSchema
	{

		#region Constructors: Public

		public KnwIndexingStatusSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public KnwIndexingStatusSchema(KnwIndexingStatusSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public KnwIndexingStatusSchema(KnwIndexingStatusSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("73b16b9a-3c64-4ee9-95b1-34ed36b5b453");
			RealUId = new Guid("73b16b9a-3c64-4ee9-95b1-34ed36b5b453");
			Name = "KnwIndexingStatus";
			ParentSchemaUId = new Guid("2681062b-df59-4e52-89ed-f9b7dc909ab2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("fc5a15eb-1c52-4ea9-828b-8fee971a8bbd");
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
			if (Columns.FindByUId(new Guid("b23336c9-b5f1-4925-33da-326d57039fb9")) == null) {
				Columns.Add(CreateValueColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("b23336c9-b5f1-4925-33da-326d57039fb9"),
				Name = @"Value",
				CreatedInSchemaUId = new Guid("73b16b9a-3c64-4ee9-95b1-34ed36b5b453"),
				ModifiedInSchemaUId = new Guid("73b16b9a-3c64-4ee9-95b1-34ed36b5b453"),
				CreatedInPackageId = new Guid("fc5a15eb-1c52-4ea9-828b-8fee971a8bbd")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new KnwIndexingStatus(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new KnwIndexingStatus_CrtAIKnwLibAppEventsProcess(userConnection);
		}

		public override object Clone() {
			return new KnwIndexingStatusSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new KnwIndexingStatusSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("73b16b9a-3c64-4ee9-95b1-34ed36b5b453"));
		}

		#endregion

	}

	#endregion

	#region Class: KnwIndexingStatus

	/// <summary>
	/// KnwIndexingStatus.
	/// </summary>
	public class KnwIndexingStatus : Terrasoft.Configuration.BaseCodeLookup
	{

		#region Constructors: Public

		public KnwIndexingStatus(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "KnwIndexingStatus";
		}

		public KnwIndexingStatus(KnwIndexingStatus source)
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
			var process = new KnwIndexingStatus_CrtAIKnwLibAppEventsProcess(UserConnection);
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
			return new KnwIndexingStatus(this);
		}

		#endregion

	}

	#endregion

	#region Class: KnwIndexingStatus_CrtAIKnwLibAppEventsProcess

	/// <exclude/>
	public partial class KnwIndexingStatus_CrtAIKnwLibAppEventsProcess<TEntity> : Terrasoft.Configuration.BaseCodeLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : KnwIndexingStatus
	{

		public KnwIndexingStatus_CrtAIKnwLibAppEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "KnwIndexingStatus_CrtAIKnwLibAppEventsProcess";
			SchemaUId = new Guid("73b16b9a-3c64-4ee9-95b1-34ed36b5b453");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("73b16b9a-3c64-4ee9-95b1-34ed36b5b453");
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

	#region Class: KnwIndexingStatus_CrtAIKnwLibAppEventsProcess

	/// <exclude/>
	public class KnwIndexingStatus_CrtAIKnwLibAppEventsProcess : KnwIndexingStatus_CrtAIKnwLibAppEventsProcess<KnwIndexingStatus>
	{

		public KnwIndexingStatus_CrtAIKnwLibAppEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: KnwIndexingStatus_CrtAIKnwLibAppEventsProcess

	public partial class KnwIndexingStatus_CrtAIKnwLibAppEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: KnwIndexingStatusEventsProcess

	/// <exclude/>
	public class KnwIndexingStatusEventsProcess : KnwIndexingStatus_CrtAIKnwLibAppEventsProcess
	{

		public KnwIndexingStatusEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

