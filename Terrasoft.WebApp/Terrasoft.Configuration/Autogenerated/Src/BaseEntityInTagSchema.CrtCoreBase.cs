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

	#region Class: BaseEntityInTagSchema

	/// <exclude/>
	[IsVirtual]
	public class BaseEntityInTagSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public BaseEntityInTagSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public BaseEntityInTagSchema(BaseEntityInTagSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public BaseEntityInTagSchema(BaseEntityInTagSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5894a2b0-51d5-419a-82bb-238674634270");
			RealUId = new Guid("5894a2b0-51d5-419a-82bb-238674634270");
			Name = "BaseEntityInTag";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("9e68a40f-2533-42d0-8fe0-88fdb6bf5704");
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
			if (Columns.FindByUId(new Guid("b48bfc16-bdfd-4658-b339-1f02b5a7f342")) == null) {
				Columns.Add(CreateTagColumn());
			}
			if (Columns.FindByUId(new Guid("a3eb8e36-6d55-4d8d-9c14-102bc79fe48a")) == null) {
				Columns.Add(CreateEntityColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateTagColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("b48bfc16-bdfd-4658-b339-1f02b5a7f342"),
				Name = @"Tag",
				ReferenceSchemaUId = new Guid("2aecdb97-990e-4c17-96f4-240ca6531c84"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("5894a2b0-51d5-419a-82bb-238674634270"),
				ModifiedInSchemaUId = new Guid("5894a2b0-51d5-419a-82bb-238674634270"),
				CreatedInPackageId = new Guid("9e68a40f-2533-42d0-8fe0-88fdb6bf5704")
			};
		}

		protected virtual EntitySchemaColumn CreateEntityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("a3eb8e36-6d55-4d8d-9c14-102bc79fe48a"),
				Name = @"Entity",
				ReferenceSchemaUId = new Guid("2aecdb97-990e-4c17-96f4-240ca6531c84"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("5894a2b0-51d5-419a-82bb-238674634270"),
				ModifiedInSchemaUId = new Guid("5894a2b0-51d5-419a-82bb-238674634270"),
				CreatedInPackageId = new Guid("9e68a40f-2533-42d0-8fe0-88fdb6bf5704")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new BaseEntityInTag(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new BaseEntityInTag_CrtCoreBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new BaseEntityInTagSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new BaseEntityInTagSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5894a2b0-51d5-419a-82bb-238674634270"));
		}

		#endregion

	}

	#endregion

	#region Class: BaseEntityInTag

	/// <summary>
	/// Base tag in base object.
	/// </summary>
	public class BaseEntityInTag : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public BaseEntityInTag(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BaseEntityInTag";
		}

		public BaseEntityInTag(BaseEntityInTag source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid TagId {
			get {
				return GetTypedColumnValue<Guid>("TagId");
			}
			set {
				SetColumnValue("TagId", value);
				_tag = null;
			}
		}

		/// <exclude/>
		public string TagName {
			get {
				return GetTypedColumnValue<string>("TagName");
			}
			set {
				SetColumnValue("TagName", value);
				if (_tag != null) {
					_tag.Name = value;
				}
			}
		}

		private Lookup _tag;
		/// <summary>
		/// Tag.
		/// </summary>
		public Lookup Tag {
			get {
				return _tag ??
					(_tag = LookupColumnEntities.GetEntity("Tag") as Lookup);
			}
		}

		/// <exclude/>
		public Guid EntityId {
			get {
				return GetTypedColumnValue<Guid>("EntityId");
			}
			set {
				SetColumnValue("EntityId", value);
				_entity = null;
			}
		}

		/// <exclude/>
		public string EntityName {
			get {
				return GetTypedColumnValue<string>("EntityName");
			}
			set {
				SetColumnValue("EntityName", value);
				if (_entity != null) {
					_entity.Name = value;
				}
			}
		}

		private Lookup _entity;
		/// <summary>
		/// Object.
		/// </summary>
		public Lookup Entity {
			get {
				return _entity ??
					(_entity = LookupColumnEntities.GetEntity("Entity") as Lookup);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new BaseEntityInTag_CrtCoreBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("BaseEntityInTagDeleted", e);
			Inserting += (s, e) => ThrowEvent("BaseEntityInTagInserting", e);
			Saving += (s, e) => ThrowEvent("BaseEntityInTagSaving", e);
			Validating += (s, e) => ThrowEvent("BaseEntityInTagValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new BaseEntityInTag(this);
		}

		#endregion

	}

	#endregion

	#region Class: BaseEntityInTag_CrtCoreBaseEventsProcess

	/// <exclude/>
	public partial class BaseEntityInTag_CrtCoreBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : BaseEntityInTag
	{

		public BaseEntityInTag_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "BaseEntityInTag_CrtCoreBaseEventsProcess";
			SchemaUId = new Guid("5894a2b0-51d5-419a-82bb-238674634270");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("5894a2b0-51d5-419a-82bb-238674634270");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _baseTagInObjectEventSubProcess;
		public ProcessFlowElement BaseTagInObjectEventSubProcess {
			get {
				return _baseTagInObjectEventSubProcess ?? (_baseTagInObjectEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "BaseTagInObjectEventSubProcess",
					SchemaElementUId = new Guid("f5e594b3-4c80-4c8e-9cfe-83e875ca305d"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _baseEntityInTagSavingStartMessage;
		public ProcessFlowElement BaseEntityInTagSavingStartMessage {
			get {
				return _baseEntityInTagSavingStartMessage ?? (_baseEntityInTagSavingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "BaseEntityInTagSavingStartMessage",
					SchemaElementUId = new Guid("d24f1b1a-bd79-4bbf-91a7-569f7e70e03e"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _checkDuplicationScriptTask;
		public ProcessScriptTask CheckDuplicationScriptTask {
			get {
				return _checkDuplicationScriptTask ?? (_checkDuplicationScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "CheckDuplicationScriptTask",
					SchemaElementUId = new Guid("c8a6db28-3103-4618-b235-e68a923fdd51"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = CheckDuplicationScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _baseEntityInTagInsertingStartMessage;
		public ProcessFlowElement BaseEntityInTagInsertingStartMessage {
			get {
				return _baseEntityInTagInsertingStartMessage ?? (_baseEntityInTagInsertingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "BaseEntityInTagInsertingStartMessage",
					SchemaElementUId = new Guid("8567de8f-8764-4f0d-8d64-222a77099cee"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[BaseTagInObjectEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseTagInObjectEventSubProcess };
			FlowElements[BaseEntityInTagSavingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseEntityInTagSavingStartMessage };
			FlowElements[CheckDuplicationScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { CheckDuplicationScriptTask };
			FlowElements[BaseEntityInTagInsertingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseEntityInTagInsertingStartMessage };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "BaseTagInObjectEventSubProcess":
						break;
					case "BaseEntityInTagSavingStartMessage":
						e.Context.QueueTasks.Enqueue("CheckDuplicationScriptTask");
						break;
					case "CheckDuplicationScriptTask":
						break;
					case "BaseEntityInTagInsertingStartMessage":
						e.Context.QueueTasks.Enqueue("CheckDuplicationScriptTask");
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("BaseEntityInTagSavingStartMessage");
			ActivatedEventElements.Add("BaseEntityInTagInsertingStartMessage");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "BaseTagInObjectEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "BaseEntityInTagSavingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "BaseEntityInTagSavingStartMessage";
					result = BaseEntityInTagSavingStartMessage.Execute(context);
					break;
				case "CheckDuplicationScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "CheckDuplicationScriptTask";
					result = CheckDuplicationScriptTask.Execute(context, CheckDuplicationScriptTaskExecute);
					break;
				case "BaseEntityInTagInsertingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "BaseEntityInTagInsertingStartMessage";
					result = BaseEntityInTagInsertingStartMessage.Execute(context);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool CheckDuplicationScriptTaskExecute(ProcessExecutingContext context) {
			CheckDuplicationEntityInTag();
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "BaseEntityInTagSaving":
							if (ActivatedEventElements.Contains("BaseEntityInTagSavingStartMessage")) {
							context.QueueTasks.Enqueue("BaseEntityInTagSavingStartMessage");
						}
						break;
					case "BaseEntityInTagInserting":
							if (ActivatedEventElements.Contains("BaseEntityInTagInsertingStartMessage")) {
							context.QueueTasks.Enqueue("BaseEntityInTagInsertingStartMessage");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: BaseEntityInTag_CrtCoreBaseEventsProcess

	/// <exclude/>
	public class BaseEntityInTag_CrtCoreBaseEventsProcess : BaseEntityInTag_CrtCoreBaseEventsProcess<BaseEntityInTag>
	{

		public BaseEntityInTag_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion


	#region Class: BaseEntityInTagEventsProcess

	/// <exclude/>
	public class BaseEntityInTagEventsProcess : BaseEntityInTag_CrtCoreBaseEventsProcess
	{

		public BaseEntityInTagEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

