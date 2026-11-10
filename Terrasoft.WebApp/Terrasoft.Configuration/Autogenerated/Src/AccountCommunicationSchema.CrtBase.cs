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
	using Terrasoft.Configuration;
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

	#region Class: AccountCommunicationSchema

	/// <exclude/>
	public class AccountCommunicationSchema : Terrasoft.Configuration.BaseCommunicationSchema
	{

		#region Constructors: Public

		public AccountCommunicationSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public AccountCommunicationSchema(AccountCommunicationSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public AccountCommunicationSchema(AccountCommunicationSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("81c43461-0619-44dd-8071-b724128085c6");
			RealUId = new Guid("81c43461-0619-44dd-8071-b724128085c6");
			Name = "AccountCommunication";
			ParentSchemaUId = new Guid("33245659-4fea-425d-b591-9ed4bdeacaf5");
			ExtendParent = false;
			CreatedInPackageId = new Guid("3644c994-8f85-41ec-8125-47013bac161f");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = false;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeMasterRecordColumn() {
			base.InitializeMasterRecordColumn();
			MasterRecordColumn = CreateAccountColumn();
			if (Columns.FindByUId(MasterRecordColumn.UId) == null) {
				Columns.Add(MasterRecordColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("81c43461-0619-44dd-8071-b724128085c6");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.IsIndexed = true;
			column.ModifiedInSchemaUId = new Guid("81c43461-0619-44dd-8071-b724128085c6");
			return column;
		}

		protected override EntitySchemaColumn CreateCommunicationTypeColumn() {
			EntitySchemaColumn column = base.CreateCommunicationTypeColumn();
			column.ModifiedInSchemaUId = new Guid("81c43461-0619-44dd-8071-b724128085c6");
			return column;
		}

		protected virtual EntitySchemaColumn CreateAccountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("3aee4a24-ecca-4e16-b795-483233d9d577"),
				Name = @"Account",
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("81c43461-0619-44dd-8071-b724128085c6"),
				ModifiedInSchemaUId = new Guid("81c43461-0619-44dd-8071-b724128085c6"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new AccountCommunication(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new AccountCommunication_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new AccountCommunicationSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new AccountCommunicationSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("81c43461-0619-44dd-8071-b724128085c6"));
		}

		#endregion

	}

	#endregion

	#region Class: AccountCommunication

	/// <summary>
	/// Account communication option.
	/// </summary>
	public class AccountCommunication : Terrasoft.Configuration.BaseCommunication
	{

		#region Constructors: Public

		public AccountCommunication(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "AccountCommunication";
		}

		public AccountCommunication(AccountCommunication source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid AccountId {
			get {
				return GetTypedColumnValue<Guid>("AccountId");
			}
			set {
				SetColumnValue("AccountId", value);
				_account = null;
			}
		}

		/// <exclude/>
		public string AccountName {
			get {
				return GetTypedColumnValue<string>("AccountName");
			}
			set {
				SetColumnValue("AccountName", value);
				if (_account != null) {
					_account.Name = value;
				}
			}
		}

		private Account _account;
		/// <summary>
		/// Account.
		/// </summary>
		public Account Account {
			get {
				return _account ??
					(_account = LookupColumnEntities.GetEntity("Account") as Account);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new AccountCommunication_CrtBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("AccountCommunicationDeleted", e);
			Inserting += (s, e) => ThrowEvent("AccountCommunicationInserting", e);
			Saved += (s, e) => ThrowEvent("AccountCommunicationSaved", e);
			Saving += (s, e) => ThrowEvent("AccountCommunicationSaving", e);
			Validating += (s, e) => ThrowEvent("AccountCommunicationValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new AccountCommunication(this);
		}

		#endregion

	}

	#endregion

	#region Class: AccountCommunication_CrtBaseEventsProcess

	/// <exclude/>
	public partial class AccountCommunication_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseCommunication_CrtBaseEventsProcess<TEntity> where TEntity : AccountCommunication
	{

		public AccountCommunication_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "AccountCommunication_CrtBaseEventsProcess";
			SchemaUId = new Guid("81c43461-0619-44dd-8071-b724128085c6");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("81c43461-0619-44dd-8071-b724128085c6");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		public virtual bool DeletedMain {
			get;
			set;
		}

		public virtual bool IsNew {
			get;
			set;
		}

		private ProcessFlowElement _eventSubProcess1;
		public ProcessFlowElement EventSubProcess1 {
			get {
				return _eventSubProcess1 ?? (_eventSubProcess1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess1",
					SchemaElementUId = new Guid("6e3db018-97ec-4f4e-ad47-985b036fd8d3"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _accountCommunicationSaved;
		public ProcessFlowElement AccountCommunicationSaved {
			get {
				return _accountCommunicationSaved ?? (_accountCommunicationSaved = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "AccountCommunicationSaved",
					SchemaElementUId = new Guid("bd2b3360-67f3-45c7-a46f-47b7fb613938"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptAccountCommunicationSaved;
		public ProcessScriptTask ScriptAccountCommunicationSaved {
			get {
				return _scriptAccountCommunicationSaved ?? (_scriptAccountCommunicationSaved = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptAccountCommunicationSaved",
					SchemaElementUId = new Guid("db608945-b58d-4730-a558-52386ad98988"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptAccountCommunicationSavedExecute,
				});
			}
		}

		private ProcessScriptTask _scriptAccountCommunicationDeleted;
		public ProcessScriptTask ScriptAccountCommunicationDeleted {
			get {
				return _scriptAccountCommunicationDeleted ?? (_scriptAccountCommunicationDeleted = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptAccountCommunicationDeleted",
					SchemaElementUId = new Guid("d4fb080d-ac0a-4010-b67d-2f92301cdf50"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptAccountCommunicationDeletedExecute,
				});
			}
		}

		private ProcessFlowElement _accountCommunicationDeleted;
		public ProcessFlowElement AccountCommunicationDeleted {
			get {
				return _accountCommunicationDeleted ?? (_accountCommunicationDeleted = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "AccountCommunicationDeleted",
					SchemaElementUId = new Guid("8c720986-f9d5-4a74-98c8-33efdc8aa5cd"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _subProcess2;
		public ProcessFlowElement SubProcess2 {
			get {
				return _subProcess2 ?? (_subProcess2 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "SubProcess2",
					SchemaElementUId = new Guid("c55a733c-3f20-475c-afca-1ac8ee10ef7b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _accountCommunicationSaving;
		public ProcessFlowElement AccountCommunicationSaving {
			get {
				return _accountCommunicationSaving ?? (_accountCommunicationSaving = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "AccountCommunicationSaving",
					SchemaElementUId = new Guid("0f606ff6-ae30-478e-91b3-f3bc17fd3b0d"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _accountCommunicationSavingScriptTask;
		public ProcessScriptTask AccountCommunicationSavingScriptTask {
			get {
				return _accountCommunicationSavingScriptTask ?? (_accountCommunicationSavingScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "AccountCommunicationSavingScriptTask",
					SchemaElementUId = new Guid("44f7d30b-805e-4511-8b77-de9af6d133a9"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = AccountCommunicationSavingScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _eventSubProcess3_61349fbc7b1b4c529458097513df8ba9;
		public ProcessFlowElement EventSubProcess3_61349fbc7b1b4c529458097513df8ba9 {
			get {
				return _eventSubProcess3_61349fbc7b1b4c529458097513df8ba9 ?? (_eventSubProcess3_61349fbc7b1b4c529458097513df8ba9 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess3_61349fbc7b1b4c529458097513df8ba9",
					SchemaElementUId = new Guid("61349fbc-7b1b-4c52-9458-097513df8ba9"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _startMessage3_0338dbb902fc4f4685a4729426881b85;
		public ProcessFlowElement StartMessage3_0338dbb902fc4f4685a4729426881b85 {
			get {
				return _startMessage3_0338dbb902fc4f4685a4729426881b85 ?? (_startMessage3_0338dbb902fc4f4685a4729426881b85 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "StartMessage3_0338dbb902fc4f4685a4729426881b85",
					SchemaElementUId = new Guid("0338dbb9-02fc-4f46-85a4-729426881b85"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptTask3_0c65d535a5454d95bb4abfa1b685568e;
		public ProcessScriptTask ScriptTask3_0c65d535a5454d95bb4abfa1b685568e {
			get {
				return _scriptTask3_0c65d535a5454d95bb4abfa1b685568e ?? (_scriptTask3_0c65d535a5454d95bb4abfa1b685568e = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask3_0c65d535a5454d95bb4abfa1b685568e",
					SchemaElementUId = new Guid("0c65d535-a545-4d95-bb4a-bfa1b685568e"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTask3_0c65d535a5454d95bb4abfa1b685568eExecute,
				});
			}
		}

		private LocalizableString _duplicateCommunicationErrorMessage;
		public LocalizableString DuplicateCommunicationErrorMessage {
			get {
				return _duplicateCommunicationErrorMessage ?? (_duplicateCommunicationErrorMessage = new LocalizableString(Storage, Schema.GetResourceManagerName(), "EventsProcessSchema.LocalizableStrings.DuplicateCommunicationErrorMessage.Value"));
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess1 };
			FlowElements[AccountCommunicationSaved.SchemaElementUId] = new Collection<ProcessFlowElement> { AccountCommunicationSaved };
			FlowElements[ScriptAccountCommunicationSaved.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptAccountCommunicationSaved };
			FlowElements[ScriptAccountCommunicationDeleted.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptAccountCommunicationDeleted };
			FlowElements[AccountCommunicationDeleted.SchemaElementUId] = new Collection<ProcessFlowElement> { AccountCommunicationDeleted };
			FlowElements[SubProcess2.SchemaElementUId] = new Collection<ProcessFlowElement> { SubProcess2 };
			FlowElements[AccountCommunicationSaving.SchemaElementUId] = new Collection<ProcessFlowElement> { AccountCommunicationSaving };
			FlowElements[AccountCommunicationSavingScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { AccountCommunicationSavingScriptTask };
			FlowElements[EventSubProcess3_61349fbc7b1b4c529458097513df8ba9.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess3_61349fbc7b1b4c529458097513df8ba9 };
			FlowElements[StartMessage3_0338dbb902fc4f4685a4729426881b85.SchemaElementUId] = new Collection<ProcessFlowElement> { StartMessage3_0338dbb902fc4f4685a4729426881b85 };
			FlowElements[ScriptTask3_0c65d535a5454d95bb4abfa1b685568e.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask3_0c65d535a5454d95bb4abfa1b685568e };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess1":
						break;
					case "AccountCommunicationSaved":
						e.Context.QueueTasks.Enqueue("ScriptAccountCommunicationSaved");
						break;
					case "ScriptAccountCommunicationSaved":
						break;
					case "ScriptAccountCommunicationDeleted":
						break;
					case "AccountCommunicationDeleted":
						e.Context.QueueTasks.Enqueue("ScriptAccountCommunicationDeleted");
						break;
					case "SubProcess2":
						break;
					case "AccountCommunicationSaving":
						e.Context.QueueTasks.Enqueue("AccountCommunicationSavingScriptTask");
						break;
					case "AccountCommunicationSavingScriptTask":
						break;
					case "EventSubProcess3_61349fbc7b1b4c529458097513df8ba9":
						break;
					case "StartMessage3_0338dbb902fc4f4685a4729426881b85":
						e.Context.QueueTasks.Enqueue("ScriptTask3_0c65d535a5454d95bb4abfa1b685568e");
						break;
					case "ScriptTask3_0c65d535a5454d95bb4abfa1b685568e":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("AccountCommunicationSaved");
			ActivatedEventElements.Add("AccountCommunicationDeleted");
			ActivatedEventElements.Add("AccountCommunicationSaving");
			ActivatedEventElements.Add("StartMessage3_0338dbb902fc4f4685a4729426881b85");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "EventSubProcess1":
					context.QueueTasks.Dequeue();
					break;
				case "AccountCommunicationSaved":
					context.QueueTasks.Dequeue();
					context.SenderName = "AccountCommunicationSaved";
					result = AccountCommunicationSaved.Execute(context);
					break;
				case "ScriptAccountCommunicationSaved":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptAccountCommunicationSaved";
					result = ScriptAccountCommunicationSaved.Execute(context, ScriptAccountCommunicationSavedExecute);
					break;
				case "ScriptAccountCommunicationDeleted":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptAccountCommunicationDeleted";
					result = ScriptAccountCommunicationDeleted.Execute(context, ScriptAccountCommunicationDeletedExecute);
					break;
				case "AccountCommunicationDeleted":
					context.QueueTasks.Dequeue();
					context.SenderName = "AccountCommunicationDeleted";
					result = AccountCommunicationDeleted.Execute(context);
					break;
				case "SubProcess2":
					context.QueueTasks.Dequeue();
					break;
				case "AccountCommunicationSaving":
					context.QueueTasks.Dequeue();
					context.SenderName = "AccountCommunicationSaving";
					result = AccountCommunicationSaving.Execute(context);
					break;
				case "AccountCommunicationSavingScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "AccountCommunicationSavingScriptTask";
					result = AccountCommunicationSavingScriptTask.Execute(context, AccountCommunicationSavingScriptTaskExecute);
					break;
				case "EventSubProcess3_61349fbc7b1b4c529458097513df8ba9":
					context.QueueTasks.Dequeue();
					break;
				case "StartMessage3_0338dbb902fc4f4685a4729426881b85":
					context.QueueTasks.Dequeue();
					context.SenderName = "StartMessage3_0338dbb902fc4f4685a4729426881b85";
					result = StartMessage3_0338dbb902fc4f4685a4729426881b85.Execute(context);
					break;
				case "ScriptTask3_0c65d535a5454d95bb4abfa1b685568e":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTask3_0c65d535a5454d95bb4abfa1b685568e";
					result = ScriptTask3_0c65d535a5454d95bb4abfa1b685568e.Execute(context, ScriptTask3_0c65d535a5454d95bb4abfa1b685568eExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool ScriptAccountCommunicationSavedExecute(ProcessExecutingContext context) {
			OnAccountCommunicationSaved();
			RemoveDuplicates();
			return true;
		}

		public virtual bool ScriptAccountCommunicationDeletedExecute(ProcessExecutingContext context) {
			OnAccountCommunicationDeleted();
			return true;
		}

		public virtual bool AccountCommunicationSavingScriptTaskExecute(ProcessExecutingContext context) {
			OnAccountCommunicationSaving();
			return true;
		}

		public virtual bool ScriptTask3_0c65d535a5454d95bb4abfa1b685568eExecute(ProcessExecutingContext context) {
			if (CheckDuplicateCommunication()) {
				var validationMessage = new EntityValidationMessage {
					Text = DuplicateCommunicationErrorMessage
				};
				EntityValidationEventArgs eventArgs = (EntityValidationEventArgs)context.ThrowEventArgs;
				eventArgs.Messages.Add(validationMessage);
			}
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "AccountCommunicationSaved":
							if (ActivatedEventElements.Contains("AccountCommunicationSaved")) {
							context.QueueTasks.Enqueue("AccountCommunicationSaved");
						}
						break;
					case "AccountCommunicationDeleted":
							if (ActivatedEventElements.Contains("AccountCommunicationDeleted")) {
							context.QueueTasks.Enqueue("AccountCommunicationDeleted");
						}
						break;
					case "AccountCommunicationSaving":
							if (ActivatedEventElements.Contains("AccountCommunicationSaving")) {
							context.QueueTasks.Enqueue("AccountCommunicationSaving");
						}
						break;
					case "AccountCommunicationValidating":
							if (ActivatedEventElements.Contains("StartMessage3_0338dbb902fc4f4685a4729426881b85")) {
							context.QueueTasks.Enqueue("StartMessage3_0338dbb902fc4f4685a4729426881b85");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: AccountCommunication_CrtBaseEventsProcess

	/// <exclude/>
	public class AccountCommunication_CrtBaseEventsProcess : AccountCommunication_CrtBaseEventsProcess<AccountCommunication>
	{

		public AccountCommunication_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion


	#region Class: AccountCommunicationEventsProcess

	/// <exclude/>
	public class AccountCommunicationEventsProcess : AccountCommunication_CrtBaseEventsProcess
	{

		public AccountCommunicationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

