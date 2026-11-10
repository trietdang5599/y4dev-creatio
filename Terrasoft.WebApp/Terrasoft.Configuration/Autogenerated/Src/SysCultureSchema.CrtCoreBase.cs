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

	#region Class: SysCulture_CrtCoreBase_CreatioSchema

	/// <exclude/>
	public class SysCulture_CrtCoreBase_CreatioSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public SysCulture_CrtCoreBase_CreatioSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysCulture_CrtCoreBase_CreatioSchema(SysCulture_CrtCoreBase_CreatioSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysCulture_CrtCoreBase_CreatioSchema(SysCulture_CrtCoreBase_CreatioSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIUSysCultureNameIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = true
			};
			index.UId = new Guid("efddfdc3-a0fc-45fc-b5b3-9c4034829274");
			index.Name = "IUSysCultureName";
			index.CreatedInSchemaUId = new Guid("ffc193e1-04bc-472b-bdc0-3333d1df84e4");
			index.ModifiedInSchemaUId = new Guid("ffc193e1-04bc-472b-bdc0-3333d1df84e4");
			index.CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f");
			EntitySchemaIndexColumn nameIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("8cfb8483-9c62-b47a-8bd7-414df6b3f5dc"),
				ColumnUId = new Guid("736c30a7-c0ec-4fa9-b034-2552b319b633"),
				CreatedInSchemaUId = new Guid("ffc193e1-04bc-472b-bdc0-3333d1df84e4"),
				ModifiedInSchemaUId = new Guid("ffc193e1-04bc-472b-bdc0-3333d1df84e4"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(nameIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ffc193e1-04bc-472b-bdc0-3333d1df84e4");
			RealUId = new Guid("ffc193e1-04bc-472b-bdc0-3333d1df84e4");
			Name = "SysCulture_CrtCoreBase_Creatio";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
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
			if (Columns.FindByUId(new Guid("3902b321-877b-464f-a0a9-563b9eec78ed")) == null) {
				Columns.Add(CreateDefaultColumn());
			}
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.IsLocalizable = false;
			column.ModifiedInSchemaUId = new Guid("ffc193e1-04bc-472b-bdc0-3333d1df84e4");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.IsLocalizable = false;
			column.ModifiedInSchemaUId = new Guid("ffc193e1-04bc-472b-bdc0-3333d1df84e4");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected virtual EntitySchemaColumn CreateDefaultColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("3902b321-877b-464f-a0a9-563b9eec78ed"),
				Name = @"Default",
				CreatedInSchemaUId = new Guid("ffc193e1-04bc-472b-bdc0-3333d1df84e4"),
				ModifiedInSchemaUId = new Guid("ffc193e1-04bc-472b-bdc0-3333d1df84e4"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIUSysCultureNameIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysCulture_CrtCoreBase_Creatio(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysCulture_CrtCoreBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysCulture_CrtCoreBase_CreatioSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysCulture_CrtCoreBase_CreatioSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ffc193e1-04bc-472b-bdc0-3333d1df84e4"));
		}

		#endregion

	}

	#endregion

	#region Class: SysCulture_CrtCoreBase_Creatio

	/// <summary>
	/// Culture.
	/// </summary>
	public class SysCulture_CrtCoreBase_Creatio : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public SysCulture_CrtCoreBase_Creatio(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysCulture_CrtCoreBase_Creatio";
		}

		public SysCulture_CrtCoreBase_Creatio(SysCulture_CrtCoreBase_Creatio source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Use by default.
		/// </summary>
		public bool Default {
			get {
				return GetTypedColumnValue<bool>("Default");
			}
			set {
				SetColumnValue("Default", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysCulture_CrtCoreBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysCulture_CrtCoreBase_CreatioDeleted", e);
			Inserting += (s, e) => ThrowEvent("SysCulture_CrtCoreBase_CreatioInserting", e);
			Validating += (s, e) => ThrowEvent("SysCulture_CrtCoreBase_CreatioValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysCulture_CrtCoreBase_Creatio(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysCulture_CrtCoreBaseEventsProcess

	/// <exclude/>
	public partial class SysCulture_CrtCoreBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysCulture_CrtCoreBase_Creatio
	{

		public SysCulture_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysCulture_CrtCoreBaseEventsProcess";
			SchemaUId = new Guid("ffc193e1-04bc-472b-bdc0-3333d1df84e4");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ffc193e1-04bc-472b-bdc0-3333d1df84e4");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _baseSysCultureInsertedEventSubProcess;
		public ProcessFlowElement BaseSysCultureInsertedEventSubProcess {
			get {
				return _baseSysCultureInsertedEventSubProcess ?? (_baseSysCultureInsertedEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "BaseSysCultureInsertedEventSubProcess",
					SchemaElementUId = new Guid("824b56ec-d7d4-4885-8918-51ecb733ede4"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _baseSysCultureInsertedStartMessage;
		public ProcessFlowElement BaseSysCultureInsertedStartMessage {
			get {
				return _baseSysCultureInsertedStartMessage ?? (_baseSysCultureInsertedStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "BaseSysCultureInsertedStartMessage",
					SchemaElementUId = new Guid("abcdcb87-f12c-4a61-af41-d9f4e3a2f5f8"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _baseSysCultureInsertedScriptTask;
		public ProcessScriptTask BaseSysCultureInsertedScriptTask {
			get {
				return _baseSysCultureInsertedScriptTask ?? (_baseSysCultureInsertedScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "BaseSysCultureInsertedScriptTask",
					SchemaElementUId = new Guid("daac240d-f629-426b-b93e-f5c627460a2a"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = BaseSysCultureInsertedScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _baseSysCultureDeletedEventSubProcess;
		public ProcessFlowElement BaseSysCultureDeletedEventSubProcess {
			get {
				return _baseSysCultureDeletedEventSubProcess ?? (_baseSysCultureDeletedEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "BaseSysCultureDeletedEventSubProcess",
					SchemaElementUId = new Guid("c0be634c-baec-4865-b04e-d686ca12e984"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _baseSysCultureDeletedStartMessage;
		public ProcessFlowElement BaseSysCultureDeletedStartMessage {
			get {
				return _baseSysCultureDeletedStartMessage ?? (_baseSysCultureDeletedStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "BaseSysCultureDeletedStartMessage",
					SchemaElementUId = new Guid("5a6585ef-3c5c-4947-9572-9c3806722ef0"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _baseSysCultureDeletedScriptTask;
		public ProcessScriptTask BaseSysCultureDeletedScriptTask {
			get {
				return _baseSysCultureDeletedScriptTask ?? (_baseSysCultureDeletedScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "BaseSysCultureDeletedScriptTask",
					SchemaElementUId = new Guid("26b7ec2e-1de7-4c86-84d4-9f3ca3defde5"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = BaseSysCultureDeletedScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[BaseSysCultureInsertedEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseSysCultureInsertedEventSubProcess };
			FlowElements[BaseSysCultureInsertedStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseSysCultureInsertedStartMessage };
			FlowElements[BaseSysCultureInsertedScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseSysCultureInsertedScriptTask };
			FlowElements[BaseSysCultureDeletedEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseSysCultureDeletedEventSubProcess };
			FlowElements[BaseSysCultureDeletedStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseSysCultureDeletedStartMessage };
			FlowElements[BaseSysCultureDeletedScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseSysCultureDeletedScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "BaseSysCultureInsertedEventSubProcess":
						break;
					case "BaseSysCultureInsertedStartMessage":
						e.Context.QueueTasks.Enqueue("BaseSysCultureInsertedScriptTask");
						break;
					case "BaseSysCultureInsertedScriptTask":
						break;
					case "BaseSysCultureDeletedEventSubProcess":
						break;
					case "BaseSysCultureDeletedStartMessage":
						e.Context.QueueTasks.Enqueue("BaseSysCultureDeletedScriptTask");
						break;
					case "BaseSysCultureDeletedScriptTask":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("BaseSysCultureInsertedStartMessage");
			ActivatedEventElements.Add("BaseSysCultureDeletedStartMessage");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "BaseSysCultureInsertedEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "BaseSysCultureInsertedStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "BaseSysCultureInsertedStartMessage";
					result = BaseSysCultureInsertedStartMessage.Execute(context);
					break;
				case "BaseSysCultureInsertedScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "BaseSysCultureInsertedScriptTask";
					result = BaseSysCultureInsertedScriptTask.Execute(context, BaseSysCultureInsertedScriptTaskExecute);
					break;
				case "BaseSysCultureDeletedEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "BaseSysCultureDeletedStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "BaseSysCultureDeletedStartMessage";
					result = BaseSysCultureDeletedStartMessage.Execute(context);
					break;
				case "BaseSysCultureDeletedScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "BaseSysCultureDeletedScriptTask";
					result = BaseSysCultureDeletedScriptTask.Execute(context, BaseSysCultureDeletedScriptTaskExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool BaseSysCultureInsertedScriptTaskExecute(ProcessExecutingContext context) {
			return OnBaseSysCultureInserted();
		}

		public virtual bool BaseSysCultureDeletedScriptTaskExecute(ProcessExecutingContext context) {
			return OnBaseSysCultureDeleted();
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "SysCultureInserted":
							if (ActivatedEventElements.Contains("BaseSysCultureInsertedStartMessage")) {
							context.QueueTasks.Enqueue("BaseSysCultureInsertedStartMessage");
						}
						break;
					case "SysCulture_CrtCoreBase_CreatioDeleted":
							if (ActivatedEventElements.Contains("BaseSysCultureDeletedStartMessage")) {
							context.QueueTasks.Enqueue("BaseSysCultureDeletedStartMessage");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: SysCulture_CrtCoreBaseEventsProcess

	/// <exclude/>
	public class SysCulture_CrtCoreBaseEventsProcess : SysCulture_CrtCoreBaseEventsProcess<SysCulture_CrtCoreBase_Creatio>
	{

		public SysCulture_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysCulture_CrtCoreBaseEventsProcess

	public partial class SysCulture_CrtCoreBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual bool OnBaseSysCultureInserted() {
			CultureInfo cultureInfo = CultureInfo.GetCultureInfo(Entity.Name);
			GeneralResourceStorage.AddCultureInfo(cultureInfo);
			return true;
		}

		public virtual bool OnBaseSysCultureDeleted() {
			CultureInfo cultureInfo = CultureInfo.GetCultureInfo(Entity.Name);
			GeneralResourceStorage.RemoveCultureInfo(cultureInfo);
			return true;
		}

		#endregion

	}

	#endregion

}

