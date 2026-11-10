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

	#region Class: ChunkProcessResultSchema

	/// <exclude/>
	public class ChunkProcessResultSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ChunkProcessResultSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ChunkProcessResultSchema(ChunkProcessResultSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ChunkProcessResultSchema(ChunkProcessResultSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("51f35bd5-4faf-4c75-a7c2-b795acb6dfce");
			RealUId = new Guid("51f35bd5-4faf-4c75-a7c2-b795acb6dfce");
			Name = "ChunkProcessResult";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8");
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
			if (Columns.FindByUId(new Guid("43217ca0-9cc8-4686-97cb-b4e38c279a82")) == null) {
				Columns.Add(CreateImportSessionChunkColumn());
			}
			if (Columns.FindByUId(new Guid("c6b9a4ed-c0d3-4e08-a94e-033bd3174b28")) == null) {
				Columns.Add(CreateRowIndexColumn());
			}
			if (Columns.FindByUId(new Guid("c340fe4b-81bf-48c7-8d58-76b58ab301a6")) == null) {
				Columns.Add(CreateSuccessColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateImportSessionChunkColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("43217ca0-9cc8-4686-97cb-b4e38c279a82"),
				Name = @"ImportSessionChunk",
				ReferenceSchemaUId = new Guid("573c37a8-74f2-4cba-b256-3a4b87b625e7"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("51f35bd5-4faf-4c75-a7c2-b795acb6dfce"),
				ModifiedInSchemaUId = new Guid("51f35bd5-4faf-4c75-a7c2-b795acb6dfce"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateRowIndexColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("c6b9a4ed-c0d3-4e08-a94e-033bd3174b28"),
				Name = @"RowIndex",
				CreatedInSchemaUId = new Guid("51f35bd5-4faf-4c75-a7c2-b795acb6dfce"),
				ModifiedInSchemaUId = new Guid("51f35bd5-4faf-4c75-a7c2-b795acb6dfce"),
				CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8")
			};
		}

		protected virtual EntitySchemaColumn CreateSuccessColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("c340fe4b-81bf-48c7-8d58-76b58ab301a6"),
				Name = @"Success",
				CreatedInSchemaUId = new Guid("51f35bd5-4faf-4c75-a7c2-b795acb6dfce"),
				ModifiedInSchemaUId = new Guid("51f35bd5-4faf-4c75-a7c2-b795acb6dfce"),
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
			return new ChunkProcessResult(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ChunkProcessResult_CrtFileImportEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ChunkProcessResultSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ChunkProcessResultSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("51f35bd5-4faf-4c75-a7c2-b795acb6dfce"));
		}

		#endregion

	}

	#endregion

	#region Class: ChunkProcessResult

	/// <summary>
	/// ImportChunkProcessResult.
	/// </summary>
	public class ChunkProcessResult : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ChunkProcessResult(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ChunkProcessResult";
		}

		public ChunkProcessResult(ChunkProcessResult source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ImportSessionChunkId {
			get {
				return GetTypedColumnValue<Guid>("ImportSessionChunkId");
			}
			set {
				SetColumnValue("ImportSessionChunkId", value);
				_importSessionChunk = null;
			}
		}

		private ImportSessionChunk _importSessionChunk;
		/// <summary>
		/// ImportSessionChunk.
		/// </summary>
		public ImportSessionChunk ImportSessionChunk {
			get {
				return _importSessionChunk ??
					(_importSessionChunk = LookupColumnEntities.GetEntity("ImportSessionChunk") as ImportSessionChunk);
			}
		}

		/// <summary>
		/// RowIndex.
		/// </summary>
		public int RowIndex {
			get {
				return GetTypedColumnValue<int>("RowIndex");
			}
			set {
				SetColumnValue("RowIndex", value);
			}
		}

		/// <summary>
		/// Success.
		/// </summary>
		public bool Success {
			get {
				return GetTypedColumnValue<bool>("Success");
			}
			set {
				SetColumnValue("Success", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ChunkProcessResult_CrtFileImportEventsProcess(UserConnection);
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
			return new ChunkProcessResult(this);
		}

		#endregion

	}

	#endregion

	#region Class: ChunkProcessResult_CrtFileImportEventsProcess

	/// <exclude/>
	public partial class ChunkProcessResult_CrtFileImportEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : ChunkProcessResult
	{

		public ChunkProcessResult_CrtFileImportEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ChunkProcessResult_CrtFileImportEventsProcess";
			SchemaUId = new Guid("51f35bd5-4faf-4c75-a7c2-b795acb6dfce");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("51f35bd5-4faf-4c75-a7c2-b795acb6dfce");
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

	#region Class: ChunkProcessResult_CrtFileImportEventsProcess

	/// <exclude/>
	public class ChunkProcessResult_CrtFileImportEventsProcess : ChunkProcessResult_CrtFileImportEventsProcess<ChunkProcessResult>
	{

		public ChunkProcessResult_CrtFileImportEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ChunkProcessResult_CrtFileImportEventsProcess

	public partial class ChunkProcessResult_CrtFileImportEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ChunkProcessResultEventsProcess

	/// <exclude/>
	public class ChunkProcessResultEventsProcess : ChunkProcessResult_CrtFileImportEventsProcess
	{

		public ChunkProcessResultEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

