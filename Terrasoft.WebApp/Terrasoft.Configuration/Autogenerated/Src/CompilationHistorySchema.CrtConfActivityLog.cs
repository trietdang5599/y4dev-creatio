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

	#region Class: CompilationHistorySchema

	/// <exclude/>
	public class CompilationHistorySchema : Terrasoft.Configuration.CompilationHistory_CrtBase_CreatioSchema
	{

		#region Constructors: Public

		public CompilationHistorySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CompilationHistorySchema(CompilationHistorySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CompilationHistorySchema(CompilationHistorySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("eb84acfc-af6f-455e-bfc4-72f0a6409c43");
			Name = "CompilationHistory";
			ParentSchemaUId = new Guid("4b57024f-c037-47f6-af95-04677d2e8f1e");
			ExtendParent = true;
			CreatedInPackageId = new Guid("13dcad14-c34c-4c22-9bae-7939adc82560");
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
			if (Columns.FindByUId(new Guid("fad40b48-2128-f84d-3d12-ecb7fb497f5e")) == null) {
				Columns.Add(CreateConfActivityLogColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateConfActivityLogColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("fad40b48-2128-f84d-3d12-ecb7fb497f5e"),
				Name = @"ConfActivityLog",
				CreatedInSchemaUId = new Guid("eb84acfc-af6f-455e-bfc4-72f0a6409c43"),
				ModifiedInSchemaUId = new Guid("eb84acfc-af6f-455e-bfc4-72f0a6409c43"),
				CreatedInPackageId = new Guid("7bf42743-159e-4d03-9496-c87980494cb8")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new CompilationHistory(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CompilationHistory_CrtConfActivityLogEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CompilationHistorySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CompilationHistorySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("eb84acfc-af6f-455e-bfc4-72f0a6409c43"));
		}

		#endregion

	}

	#endregion

	#region Class: CompilationHistory

	/// <summary>
	/// Compilation history.
	/// </summary>
	public class CompilationHistory : Terrasoft.Configuration.CompilationHistory_CrtBase_Creatio
	{

		#region Constructors: Public

		public CompilationHistory(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CompilationHistory";
		}

		public CompilationHistory(CompilationHistory source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// ConfActivityLog.
		/// </summary>
		public Guid ConfActivityLog {
			get {
				return GetTypedColumnValue<Guid>("ConfActivityLog");
			}
			set {
				SetColumnValue("ConfActivityLog", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CompilationHistory_CrtConfActivityLogEventsProcess(UserConnection);
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
			return new CompilationHistory(this);
		}

		#endregion

	}

	#endregion

	#region Class: CompilationHistory_CrtConfActivityLogEventsProcess

	/// <exclude/>
	public partial class CompilationHistory_CrtConfActivityLogEventsProcess<TEntity> : Terrasoft.Configuration.CompilationHistory_CrtBaseEventsProcess<TEntity> where TEntity : CompilationHistory
	{

		public CompilationHistory_CrtConfActivityLogEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CompilationHistory_CrtConfActivityLogEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("eb84acfc-af6f-455e-bfc4-72f0a6409c43");
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

	#region Class: CompilationHistory_CrtConfActivityLogEventsProcess

	/// <exclude/>
	public class CompilationHistory_CrtConfActivityLogEventsProcess : CompilationHistory_CrtConfActivityLogEventsProcess<CompilationHistory>
	{

		public CompilationHistory_CrtConfActivityLogEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CompilationHistory_CrtConfActivityLogEventsProcess

	public partial class CompilationHistory_CrtConfActivityLogEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CompilationHistoryEventsProcess

	/// <exclude/>
	public class CompilationHistoryEventsProcess : CompilationHistory_CrtConfActivityLogEventsProcess
	{

		public CompilationHistoryEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

