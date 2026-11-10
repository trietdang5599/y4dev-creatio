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

	#region Class: CopilotIntentStatusSchema

	/// <exclude/>
	public class CopilotIntentStatusSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public CopilotIntentStatusSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CopilotIntentStatusSchema(CopilotIntentStatusSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CopilotIntentStatusSchema(CopilotIntentStatusSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("157ceb57-a606-426e-952e-7cadeac5650a");
			RealUId = new Guid("157ceb57-a606-426e-952e-7cadeac5650a");
			Name = "CopilotIntentStatus";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("a3e3308b-36cb-4442-aa9c-95f9845e2ff2");
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
			if (Columns.FindByUId(new Guid("aa802206-382e-b24d-a14d-072b0c1c2a34")) == null) {
				Columns.Add(CreateCodeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("aa802206-382e-b24d-a14d-072b0c1c2a34"),
				Name = @"Code",
				CreatedInSchemaUId = new Guid("157ceb57-a606-426e-952e-7cadeac5650a"),
				ModifiedInSchemaUId = new Guid("157ceb57-a606-426e-952e-7cadeac5650a"),
				CreatedInPackageId = new Guid("bb0dbad8-d67b-49e0-a79c-79fc53c5d9d9")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new CopilotIntentStatus(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CopilotIntentStatus_CrtCopilotEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CopilotIntentStatusSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CopilotIntentStatusSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("157ceb57-a606-426e-952e-7cadeac5650a"));
		}

		#endregion

	}

	#endregion

	#region Class: CopilotIntentStatus

	/// <summary>
	/// Creatio.ai skill status.
	/// </summary>
	public class CopilotIntentStatus : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public CopilotIntentStatus(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CopilotIntentStatus";
		}

		public CopilotIntentStatus(CopilotIntentStatus source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Code.
		/// </summary>
		public string Code {
			get {
				return GetTypedColumnValue<string>("Code");
			}
			set {
				SetColumnValue("Code", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CopilotIntentStatus_CrtCopilotEventsProcess(UserConnection);
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
			return new CopilotIntentStatus(this);
		}

		#endregion

	}

	#endregion

	#region Class: CopilotIntentStatus_CrtCopilotEventsProcess

	/// <exclude/>
	public partial class CopilotIntentStatus_CrtCopilotEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : CopilotIntentStatus
	{

		public CopilotIntentStatus_CrtCopilotEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CopilotIntentStatus_CrtCopilotEventsProcess";
			SchemaUId = new Guid("157ceb57-a606-426e-952e-7cadeac5650a");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("157ceb57-a606-426e-952e-7cadeac5650a");
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

	#region Class: CopilotIntentStatus_CrtCopilotEventsProcess

	/// <exclude/>
	public class CopilotIntentStatus_CrtCopilotEventsProcess : CopilotIntentStatus_CrtCopilotEventsProcess<CopilotIntentStatus>
	{

		public CopilotIntentStatus_CrtCopilotEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CopilotIntentStatus_CrtCopilotEventsProcess

	public partial class CopilotIntentStatus_CrtCopilotEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CopilotIntentStatusEventsProcess

	/// <exclude/>
	public class CopilotIntentStatusEventsProcess : CopilotIntentStatus_CrtCopilotEventsProcess
	{

		public CopilotIntentStatusEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

