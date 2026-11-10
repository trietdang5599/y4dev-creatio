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

	#region Class: CallSchema

	/// <exclude/>
	public class CallSchema : Terrasoft.Configuration.Call_Timeline_CreatioSchema
	{

		#region Constructors: Public

		public CallSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CallSchema(CallSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CallSchema(CallSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("c0ba1d7d-2918-4eae-84a8-178376094bbb");
			Name = "Call";
			ParentSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad");
			ExtendParent = true;
			CreatedInPackageId = new Guid("86aa4580-107f-4b57-8ece-a7f3b6645305");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = false;
			UseLiveEditing = true;
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

		protected override EntitySchemaColumn CreateCallerIdColumn() {
			EntitySchemaColumn column = base.CreateCallerIdColumn();
			column.DataValueType = DataValueTypeManager.GetInstanceByName("PhoneText");
			column.ModifiedInSchemaUId = new Guid("c0ba1d7d-2918-4eae-84a8-178376094bbb");
			return column;
		}

		protected override EntitySchemaColumn CreateCalledIdColumn() {
			EntitySchemaColumn column = base.CreateCalledIdColumn();
			column.DataValueType = DataValueTypeManager.GetInstanceByName("PhoneText");
			column.ModifiedInSchemaUId = new Guid("c0ba1d7d-2918-4eae-84a8-178376094bbb");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Call(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Call_CrtCallEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CallSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CallSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c0ba1d7d-2918-4eae-84a8-178376094bbb"));
		}

		#endregion

	}

	#endregion

	#region Class: Call

	/// <summary>
	/// Call.
	/// </summary>
	/// <remarks>
	/// Captures all customer and internal phone interactions to provide a complete view of communication history, support service quality monitoring, and enable performance and engagement analysis across teams.
	/// </remarks>
	public class Call : Terrasoft.Configuration.Call_Timeline_Creatio
	{

		#region Constructors: Public

		public Call(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Call";
		}

		public Call(Call source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Call_CrtCallEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("CallDeleted", e);
			Deleting += (s, e) => ThrowEvent("CallDeleting", e);
			Inserted += (s, e) => ThrowEvent("CallInserted", e);
			Inserting += (s, e) => ThrowEvent("CallInserting", e);
			Saved += (s, e) => ThrowEvent("CallSaved", e);
			Saving += (s, e) => ThrowEvent("CallSaving", e);
			Validating += (s, e) => ThrowEvent("CallValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Call(this);
		}

		#endregion

	}

	#endregion

	#region Class: Call_CrtCallEventsProcess

	/// <exclude/>
	public partial class Call_CrtCallEventsProcess<TEntity> : Terrasoft.Configuration.Call_TimelineEventsProcess<TEntity> where TEntity : Call
	{

		public Call_CrtCallEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Call_CrtCallEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("c0ba1d7d-2918-4eae-84a8-178376094bbb");
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

	#region Class: Call_CrtCallEventsProcess

	/// <exclude/>
	public class Call_CrtCallEventsProcess : Call_CrtCallEventsProcess<Call>
	{

		public Call_CrtCallEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Call_CrtCallEventsProcess

	public partial class Call_CrtCallEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CallEventsProcess

	/// <exclude/>
	public class CallEventsProcess : Call_CrtCallEventsProcess
	{

		public CallEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

