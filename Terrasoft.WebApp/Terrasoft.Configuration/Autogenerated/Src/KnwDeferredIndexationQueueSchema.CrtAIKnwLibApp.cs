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

	#region Class: KnwDeferredIndexationQueueSchema

	/// <exclude/>
	public class KnwDeferredIndexationQueueSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public KnwDeferredIndexationQueueSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public KnwDeferredIndexationQueueSchema(KnwDeferredIndexationQueueSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public KnwDeferredIndexationQueueSchema(KnwDeferredIndexationQueueSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a485a1e8-2133-4a86-8c7b-0d0aa7473cbe");
			RealUId = new Guid("a485a1e8-2133-4a86-8c7b-0d0aa7473cbe");
			Name = "KnwDeferredIndexationQueue";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("34fa8763-a4ac-48d9-8bd9-b1ff8f7140ca");
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
			if (Columns.FindByUId(new Guid("be089e64-125b-4c03-1f6e-a35d784b643d")) == null) {
				Columns.Add(CreateKnwSourceIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateKnwSourceIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("be089e64-125b-4c03-1f6e-a35d784b643d"),
				Name = @"KnwSourceId",
				CreatedInSchemaUId = new Guid("a485a1e8-2133-4a86-8c7b-0d0aa7473cbe"),
				ModifiedInSchemaUId = new Guid("a485a1e8-2133-4a86-8c7b-0d0aa7473cbe"),
				CreatedInPackageId = new Guid("34fa8763-a4ac-48d9-8bd9-b1ff8f7140ca")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new KnwDeferredIndexationQueue(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new KnwDeferredIndexationQueue_CrtAIKnwLibAppEventsProcess(userConnection);
		}

		public override object Clone() {
			return new KnwDeferredIndexationQueueSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new KnwDeferredIndexationQueueSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a485a1e8-2133-4a86-8c7b-0d0aa7473cbe"));
		}

		#endregion

	}

	#endregion

	#region Class: KnwDeferredIndexationQueue

	/// <summary>
	/// Deferred Knowledge Indexation Queue.
	/// </summary>
	public class KnwDeferredIndexationQueue : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public KnwDeferredIndexationQueue(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "KnwDeferredIndexationQueue";
		}

		public KnwDeferredIndexationQueue(KnwDeferredIndexationQueue source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// KnwSourceId.
		/// </summary>
		public string KnwSourceId {
			get {
				return GetTypedColumnValue<string>("KnwSourceId");
			}
			set {
				SetColumnValue("KnwSourceId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new KnwDeferredIndexationQueue_CrtAIKnwLibAppEventsProcess(UserConnection);
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
			return new KnwDeferredIndexationQueue(this);
		}

		#endregion

	}

	#endregion

	#region Class: KnwDeferredIndexationQueue_CrtAIKnwLibAppEventsProcess

	/// <exclude/>
	public partial class KnwDeferredIndexationQueue_CrtAIKnwLibAppEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : KnwDeferredIndexationQueue
	{

		public KnwDeferredIndexationQueue_CrtAIKnwLibAppEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "KnwDeferredIndexationQueue_CrtAIKnwLibAppEventsProcess";
			SchemaUId = new Guid("a485a1e8-2133-4a86-8c7b-0d0aa7473cbe");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("a485a1e8-2133-4a86-8c7b-0d0aa7473cbe");
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

	#region Class: KnwDeferredIndexationQueue_CrtAIKnwLibAppEventsProcess

	/// <exclude/>
	public class KnwDeferredIndexationQueue_CrtAIKnwLibAppEventsProcess : KnwDeferredIndexationQueue_CrtAIKnwLibAppEventsProcess<KnwDeferredIndexationQueue>
	{

		public KnwDeferredIndexationQueue_CrtAIKnwLibAppEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: KnwDeferredIndexationQueue_CrtAIKnwLibAppEventsProcess

	public partial class KnwDeferredIndexationQueue_CrtAIKnwLibAppEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: KnwDeferredIndexationQueueEventsProcess

	/// <exclude/>
	public class KnwDeferredIndexationQueueEventsProcess : KnwDeferredIndexationQueue_CrtAIKnwLibAppEventsProcess
	{

		public KnwDeferredIndexationQueueEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

