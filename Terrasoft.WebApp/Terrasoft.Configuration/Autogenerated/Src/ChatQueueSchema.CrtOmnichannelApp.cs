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

	#region Class: ChatQueueSchema

	/// <exclude/>
	public class ChatQueueSchema : Terrasoft.Configuration.ChatQueue_OmnichannelMessaging_CreatioSchema
	{

		#region Constructors: Public

		public ChatQueueSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ChatQueueSchema(ChatQueueSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ChatQueueSchema(ChatQueueSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("96ab274a-b3bf-4010-8bb7-e40946bf73ea");
			Name = "ChatQueue";
			ParentSchemaUId = new Guid("607ebc03-4933-45ff-abe9-ba80df351a8c");
			ExtendParent = true;
			CreatedInPackageId = new Guid("d8bd3670-48ca-4dba-8e6f-255949d3c62e");
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
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel;
			column.ModifiedInSchemaUId = new Guid("96ab274a-b3bf-4010-8bb7-e40946bf73ea");
			return column;
		}

		protected override EntitySchemaColumn CreateOperatorRoutingRuleColumn() {
			EntitySchemaColumn column = base.CreateOperatorRoutingRuleColumn();
			column.RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel;
			column.IsSimpleLookup = true;
			column.ModifiedInSchemaUId = new Guid("96ab274a-b3bf-4010-8bb7-e40946bf73ea");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ChatQueue(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ChatQueue_CrtOmnichannelAppEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ChatQueueSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ChatQueueSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("96ab274a-b3bf-4010-8bb7-e40946bf73ea"));
		}

		#endregion

	}

	#endregion

	#region Class: ChatQueue

	/// <summary>
	/// Chat queue.
	/// </summary>
	/// <remarks>
	/// Manages the queue of incoming chats to distribute conversations among available agents and ensure timely customer responses.
	/// </remarks>
	public class ChatQueue : Terrasoft.Configuration.ChatQueue_OmnichannelMessaging_Creatio
	{

		#region Constructors: Public

		public ChatQueue(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ChatQueue";
		}

		public ChatQueue(ChatQueue source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ChatQueue_CrtOmnichannelAppEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ChatQueueDeleted", e);
			Deleting += (s, e) => ThrowEvent("ChatQueueDeleting", e);
			Inserted += (s, e) => ThrowEvent("ChatQueueInserted", e);
			Inserting += (s, e) => ThrowEvent("ChatQueueInserting", e);
			Saved += (s, e) => ThrowEvent("ChatQueueSaved", e);
			Saving += (s, e) => ThrowEvent("ChatQueueSaving", e);
			Validating += (s, e) => ThrowEvent("ChatQueueValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ChatQueue(this);
		}

		#endregion

	}

	#endregion

	#region Class: ChatQueue_CrtOmnichannelAppEventsProcess

	/// <exclude/>
	public partial class ChatQueue_CrtOmnichannelAppEventsProcess<TEntity> : Terrasoft.Configuration.ChatQueue_OmnichannelMessagingEventsProcess<TEntity> where TEntity : ChatQueue
	{

		public ChatQueue_CrtOmnichannelAppEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ChatQueue_CrtOmnichannelAppEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("96ab274a-b3bf-4010-8bb7-e40946bf73ea");
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

	#region Class: ChatQueue_CrtOmnichannelAppEventsProcess

	/// <exclude/>
	public class ChatQueue_CrtOmnichannelAppEventsProcess : ChatQueue_CrtOmnichannelAppEventsProcess<ChatQueue>
	{

		public ChatQueue_CrtOmnichannelAppEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ChatQueue_CrtOmnichannelAppEventsProcess

	public partial class ChatQueue_CrtOmnichannelAppEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ChatQueueEventsProcess

	/// <exclude/>
	public class ChatQueueEventsProcess : ChatQueue_CrtOmnichannelAppEventsProcess
	{

		public ChatQueueEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

