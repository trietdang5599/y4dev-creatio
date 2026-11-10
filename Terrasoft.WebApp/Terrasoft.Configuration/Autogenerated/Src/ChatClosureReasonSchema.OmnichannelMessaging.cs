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

	#region Class: ChatClosureReasonSchema

	/// <exclude/>
	public class ChatClosureReasonSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public ChatClosureReasonSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ChatClosureReasonSchema(ChatClosureReasonSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ChatClosureReasonSchema(ChatClosureReasonSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7a7dee9a-0839-4186-aa6c-f89885522b2f");
			RealUId = new Guid("7a7dee9a-0839-4186-aa6c-f89885522b2f");
			Name = "ChatClosureReason";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("08afff10-3d0c-4f3d-b6a0-28a42952a988");
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

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ChatClosureReason(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ChatClosureReason_OmnichannelMessagingEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ChatClosureReasonSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ChatClosureReasonSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7a7dee9a-0839-4186-aa6c-f89885522b2f"));
		}

		#endregion

	}

	#endregion

	#region Class: ChatClosureReason

	/// <summary>
	/// Base lookup.
	/// </summary>
	public class ChatClosureReason : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public ChatClosureReason(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ChatClosureReason";
		}

		public ChatClosureReason(ChatClosureReason source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ChatClosureReason_OmnichannelMessagingEventsProcess(UserConnection);
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
			return new ChatClosureReason(this);
		}

		#endregion

	}

	#endregion

	#region Class: ChatClosureReason_OmnichannelMessagingEventsProcess

	/// <exclude/>
	public partial class ChatClosureReason_OmnichannelMessagingEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : ChatClosureReason
	{

		public ChatClosureReason_OmnichannelMessagingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ChatClosureReason_OmnichannelMessagingEventsProcess";
			SchemaUId = new Guid("7a7dee9a-0839-4186-aa6c-f89885522b2f");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("7a7dee9a-0839-4186-aa6c-f89885522b2f");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _baseLookupEventSubProcess;
		public ProcessFlowElement BaseLookupEventSubProcess {
			get {
				return _baseLookupEventSubProcess ?? (_baseLookupEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "BaseLookupEventSubProcess",
					SchemaElementUId = new Guid("e57d317f-6f21-48a8-9999-5ecf05719145"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _baseLookupInsertingStartMessage;
		public ProcessFlowElement BaseLookupInsertingStartMessage {
			get {
				return _baseLookupInsertingStartMessage ?? (_baseLookupInsertingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "BaseLookupInsertingStartMessage",
					SchemaElementUId = new Guid("9f186c66-1b04-4f3f-a712-2aadefc904c7"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _baseLookupSavingStartMessage;
		public ProcessFlowElement BaseLookupSavingStartMessage {
			get {
				return _baseLookupSavingStartMessage ?? (_baseLookupSavingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "BaseLookupSavingStartMessage",
					SchemaElementUId = new Guid("48ed15e5-1285-49c5-8946-0344c7a15bbe"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _baseLookupDeletingStartMessage;
		public ProcessFlowElement BaseLookupDeletingStartMessage {
			get {
				return _baseLookupDeletingStartMessage ?? (_baseLookupDeletingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "BaseLookupDeletingStartMessage",
					SchemaElementUId = new Guid("e0bb263d-5a8e-4ea3-a9e2-c824eb9ec5aa"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _checkCanManageLookupsScriptTask;
		public ProcessScriptTask CheckCanManageLookupsScriptTask {
			get {
				return _checkCanManageLookupsScriptTask ?? (_checkCanManageLookupsScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "CheckCanManageLookupsScriptTask",
					SchemaElementUId = new Guid("bdca0c6b-eb97-4d14-83df-aa53b214c463"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = CheckCanManageLookupsScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[BaseLookupEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseLookupEventSubProcess };
			FlowElements[BaseLookupInsertingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseLookupInsertingStartMessage };
			FlowElements[BaseLookupSavingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseLookupSavingStartMessage };
			FlowElements[BaseLookupDeletingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseLookupDeletingStartMessage };
			FlowElements[CheckCanManageLookupsScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { CheckCanManageLookupsScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "BaseLookupEventSubProcess":
						break;
					case "BaseLookupInsertingStartMessage":
						e.Context.QueueTasks.Enqueue("CheckCanManageLookupsScriptTask");
						break;
					case "BaseLookupSavingStartMessage":
						e.Context.QueueTasks.Enqueue("CheckCanManageLookupsScriptTask");
						break;
					case "BaseLookupDeletingStartMessage":
						e.Context.QueueTasks.Enqueue("CheckCanManageLookupsScriptTask");
						break;
					case "CheckCanManageLookupsScriptTask":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("BaseLookupInsertingStartMessage");
			ActivatedEventElements.Add("BaseLookupSavingStartMessage");
			ActivatedEventElements.Add("BaseLookupDeletingStartMessage");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "BaseLookupEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "BaseLookupInsertingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "BaseLookupInsertingStartMessage";
					result = BaseLookupInsertingStartMessage.Execute(context);
					break;
				case "BaseLookupSavingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "BaseLookupSavingStartMessage";
					result = BaseLookupSavingStartMessage.Execute(context);
					break;
				case "BaseLookupDeletingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "BaseLookupDeletingStartMessage";
					result = BaseLookupDeletingStartMessage.Execute(context);
					break;
				case "CheckCanManageLookupsScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "CheckCanManageLookupsScriptTask";
					result = CheckCanManageLookupsScriptTask.Execute(context, CheckCanManageLookupsScriptTaskExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool CheckCanManageLookupsScriptTaskExecute(ProcessExecutingContext context) {
			CheckCanManageLookups();
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "BaseLookupInserting":
							if (ActivatedEventElements.Contains("BaseLookupInsertingStartMessage")) {
							context.QueueTasks.Enqueue("BaseLookupInsertingStartMessage");
						}
						break;
					case "BaseLookupSaving":
							if (ActivatedEventElements.Contains("BaseLookupSavingStartMessage")) {
							context.QueueTasks.Enqueue("BaseLookupSavingStartMessage");
						}
						break;
					case "BaseLookupDeleting":
							if (ActivatedEventElements.Contains("BaseLookupDeletingStartMessage")) {
							context.QueueTasks.Enqueue("BaseLookupDeletingStartMessage");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: ChatClosureReason_OmnichannelMessagingEventsProcess

	/// <exclude/>
	public class ChatClosureReason_OmnichannelMessagingEventsProcess : ChatClosureReason_OmnichannelMessagingEventsProcess<ChatClosureReason>
	{

		public ChatClosureReason_OmnichannelMessagingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ChatClosureReason_OmnichannelMessagingEventsProcess

	public partial class ChatClosureReason_OmnichannelMessagingEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual void CheckCanManageLookups() {
			UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManageLookups");
		}

		#endregion

	}

	#endregion


	#region Class: ChatClosureReasonEventsProcess

	/// <exclude/>
	public class ChatClosureReasonEventsProcess : ChatClosureReason_OmnichannelMessagingEventsProcess
	{

		public ChatClosureReasonEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

