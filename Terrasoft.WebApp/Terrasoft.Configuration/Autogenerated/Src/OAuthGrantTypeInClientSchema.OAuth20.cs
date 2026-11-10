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

	#region Class: OAuthGrantTypeInClientSchema

	/// <exclude/>
	public class OAuthGrantTypeInClientSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public OAuthGrantTypeInClientSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OAuthGrantTypeInClientSchema(OAuthGrantTypeInClientSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OAuthGrantTypeInClientSchema(OAuthGrantTypeInClientSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5df87f67-4ad6-4e48-9dd5-65c1ff8713cf");
			RealUId = new Guid("5df87f67-4ad6-4e48-9dd5-65c1ff8713cf");
			Name = "OAuthGrantTypeInClient";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("2e618fe0-496b-4dc6-9b5c-1f29508fde14");
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
			if (Columns.FindByUId(new Guid("6b2f4dd9-1f35-4a2f-ad0d-7f89aa18d51d")) == null) {
				Columns.Add(CreateOAuthClientAppColumn());
			}
			if (Columns.FindByUId(new Guid("f1e9a83c-9c36-487c-a466-9fc04ee65b16")) == null) {
				Columns.Add(CreateOAuthGrantTypeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateOAuthClientAppColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("6b2f4dd9-1f35-4a2f-ad0d-7f89aa18d51d"),
				Name = @"OAuthClientApp",
				ReferenceSchemaUId = new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("5df87f67-4ad6-4e48-9dd5-65c1ff8713cf"),
				ModifiedInSchemaUId = new Guid("5df87f67-4ad6-4e48-9dd5-65c1ff8713cf"),
				CreatedInPackageId = new Guid("2e618fe0-496b-4dc6-9b5c-1f29508fde14"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateOAuthGrantTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("f1e9a83c-9c36-487c-a466-9fc04ee65b16"),
				Name = @"OAuthGrantType",
				ReferenceSchemaUId = new Guid("97bd1aa6-6685-4335-8bf1-4d6a0a78149b"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("5df87f67-4ad6-4e48-9dd5-65c1ff8713cf"),
				ModifiedInSchemaUId = new Guid("5df87f67-4ad6-4e48-9dd5-65c1ff8713cf"),
				CreatedInPackageId = new Guid("2e618fe0-496b-4dc6-9b5c-1f29508fde14")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new OAuthGrantTypeInClient(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OAuthGrantTypeInClient_OAuth20EventsProcess(userConnection);
		}

		public override object Clone() {
			return new OAuthGrantTypeInClientSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OAuthGrantTypeInClientSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5df87f67-4ad6-4e48-9dd5-65c1ff8713cf"));
		}

		#endregion

	}

	#endregion

	#region Class: OAuthGrantTypeInClient

	/// <summary>
	/// Base object.
	/// </summary>
	public class OAuthGrantTypeInClient : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public OAuthGrantTypeInClient(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OAuthGrantTypeInClient";
		}

		public OAuthGrantTypeInClient(OAuthGrantTypeInClient source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid OAuthClientAppId {
			get {
				return GetTypedColumnValue<Guid>("OAuthClientAppId");
			}
			set {
				SetColumnValue("OAuthClientAppId", value);
				_oAuthClientApp = null;
			}
		}

		/// <exclude/>
		public string OAuthClientAppName {
			get {
				return GetTypedColumnValue<string>("OAuthClientAppName");
			}
			set {
				SetColumnValue("OAuthClientAppName", value);
				if (_oAuthClientApp != null) {
					_oAuthClientApp.Name = value;
				}
			}
		}

		private OAuthClientApp _oAuthClientApp;
		public OAuthClientApp OAuthClientApp {
			get {
				return _oAuthClientApp ??
					(_oAuthClientApp = LookupColumnEntities.GetEntity("OAuthClientApp") as OAuthClientApp);
			}
		}

		/// <exclude/>
		public Guid OAuthGrantTypeId {
			get {
				return GetTypedColumnValue<Guid>("OAuthGrantTypeId");
			}
			set {
				SetColumnValue("OAuthGrantTypeId", value);
				_oAuthGrantType = null;
			}
		}

		/// <exclude/>
		public string OAuthGrantTypeName {
			get {
				return GetTypedColumnValue<string>("OAuthGrantTypeName");
			}
			set {
				SetColumnValue("OAuthGrantTypeName", value);
				if (_oAuthGrantType != null) {
					_oAuthGrantType.Name = value;
				}
			}
		}

		private OAuthGrantType _oAuthGrantType;
		public OAuthGrantType OAuthGrantType {
			get {
				return _oAuthGrantType ??
					(_oAuthGrantType = LookupColumnEntities.GetEntity("OAuthGrantType") as OAuthGrantType);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OAuthGrantTypeInClient_OAuth20EventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("OAuthGrantTypeInClientDeleted", e);
			Deleting += (s, e) => ThrowEvent("OAuthGrantTypeInClientDeleting", e);
			Inserted += (s, e) => ThrowEvent("OAuthGrantTypeInClientInserted", e);
			Inserting += (s, e) => ThrowEvent("OAuthGrantTypeInClientInserting", e);
			Saved += (s, e) => ThrowEvent("OAuthGrantTypeInClientSaved", e);
			Saving += (s, e) => ThrowEvent("OAuthGrantTypeInClientSaving", e);
			Validating += (s, e) => ThrowEvent("OAuthGrantTypeInClientValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new OAuthGrantTypeInClient(this);
		}

		#endregion

	}

	#endregion

	#region Class: OAuthGrantTypeInClient_OAuth20EventsProcess

	/// <exclude/>
	public partial class OAuthGrantTypeInClient_OAuth20EventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : OAuthGrantTypeInClient
	{

		public OAuthGrantTypeInClient_OAuth20EventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OAuthGrantTypeInClient_OAuth20EventsProcess";
			SchemaUId = new Guid("5df87f67-4ad6-4e48-9dd5-65c1ff8713cf");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("5df87f67-4ad6-4e48-9dd5-65c1ff8713cf");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		public virtual Object ProcessListeners {
			get;
			set;
		}

		public virtual Object ProcessSchemaListeners {
			get;
			set;
		}

		public virtual bool NextProcessElementReady {
			get;
			set;
		}

		public virtual bool IsProcessModeSave {
			get;
			set;
		}

		public virtual bool CanUseDcm {
			get;
			set;
		}

		public virtual Object DcmEntityUtil {
			get;
			set;
		}

		private ProcessFlowElement _baseEntityDeletingEventSubProcess2;
		public ProcessFlowElement BaseEntityDeletingEventSubProcess2 {
			get {
				return _baseEntityDeletingEventSubProcess2 ?? (_baseEntityDeletingEventSubProcess2 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "BaseEntityDeletingEventSubProcess2",
					SchemaElementUId = new Guid("08594d74-60b0-45ce-bf17-bac1a8b127f7"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _baseEntityDeletingStartMessage2;
		public ProcessFlowElement BaseEntityDeletingStartMessage2 {
			get {
				return _baseEntityDeletingStartMessage2 ?? (_baseEntityDeletingStartMessage2 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "BaseEntityDeletingStartMessage2",
					SchemaElementUId = new Guid("496d4a3c-b644-4a65-b0ed-2534d9236da5"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _tryProcessCompleteScriptTask2;
		public ProcessScriptTask TryProcessCompleteScriptTask2 {
			get {
				return _tryProcessCompleteScriptTask2 ?? (_tryProcessCompleteScriptTask2 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "TryProcessCompleteScriptTask2",
					SchemaElementUId = new Guid("441daff4-4808-48db-ac28-d9a42d61ac31"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = TryProcessCompleteScriptTask2Execute,
				});
			}
		}

		private ProcessFlowElement _baseEntityEventSubProcess1;
		public ProcessFlowElement BaseEntityEventSubProcess1 {
			get {
				return _baseEntityEventSubProcess1 ?? (_baseEntityEventSubProcess1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "BaseEntityEventSubProcess1",
					SchemaElementUId = new Guid("90027ac8-c9c3-4d21-a4f9-da1cde752cd1"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _baseEntityStartMessage1;
		public ProcessFlowElement BaseEntityStartMessage1 {
			get {
				return _baseEntityStartMessage1 ?? (_baseEntityStartMessage1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "BaseEntityStartMessage1",
					SchemaElementUId = new Guid("d8b8410f-5c8a-4ddc-8fc2-353483452aed"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _tryProcessCompleteScriptTask1;
		public ProcessScriptTask TryProcessCompleteScriptTask1 {
			get {
				return _tryProcessCompleteScriptTask1 ?? (_tryProcessCompleteScriptTask1 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "TryProcessCompleteScriptTask1",
					SchemaElementUId = new Guid("9494818b-220e-4e19-a635-fdca641dde5f"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = TryProcessCompleteScriptTask1Execute,
				});
			}
		}

		private ProcessScriptTask _baseEntitySavedIndexingTask;
		public ProcessScriptTask BaseEntitySavedIndexingTask {
			get {
				return _baseEntitySavedIndexingTask ?? (_baseEntitySavedIndexingTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "BaseEntitySavedIndexingTask",
					SchemaElementUId = new Guid("b8ff0739-6ead-4da7-ac8d-538cfc641fcf"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = BaseEntitySavedIndexingTaskExecute,
				});
			}
		}

		private ProcessFlowElement _baseInsertedEventSubProcess;
		public ProcessFlowElement BaseInsertedEventSubProcess {
			get {
				return _baseInsertedEventSubProcess ?? (_baseInsertedEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "BaseInsertedEventSubProcess",
					SchemaElementUId = new Guid("5f3bfbbe-1820-44ca-92f1-6f993169b2dd"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _insertedStartMessage1;
		public ProcessFlowElement InsertedStartMessage1 {
			get {
				return _insertedStartMessage1 ?? (_insertedStartMessage1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "InsertedStartMessage1",
					SchemaElementUId = new Guid("d7c806b7-a29b-4ce5-9167-b3319472e772"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptTaskInsertedBaseEntity;
		public ProcessScriptTask ScriptTaskInsertedBaseEntity {
			get {
				return _scriptTaskInsertedBaseEntity ?? (_scriptTaskInsertedBaseEntity = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTaskInsertedBaseEntity",
					SchemaElementUId = new Guid("5528724d-213b-4ae6-88d5-aa7301a1dbb0"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTaskInsertedBaseEntityExecute,
				});
			}
		}

		private ProcessFlowElement _baseEntitySavingEventSubProcess;
		public ProcessFlowElement BaseEntitySavingEventSubProcess {
			get {
				return _baseEntitySavingEventSubProcess ?? (_baseEntitySavingEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "BaseEntitySavingEventSubProcess",
					SchemaElementUId = new Guid("dbf48103-dcf6-4f53-a052-d727a95ea0b4"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _baseEntitySavingStartMessage;
		public ProcessFlowElement BaseEntitySavingStartMessage {
			get {
				return _baseEntitySavingStartMessage ?? (_baseEntitySavingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "BaseEntitySavingStartMessage",
					SchemaElementUId = new Guid("933bf2fc-d052-40c8-a3e0-bf60049da5d8"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _baseEntitySavingScriptTask;
		public ProcessScriptTask BaseEntitySavingScriptTask {
			get {
				return _baseEntitySavingScriptTask ?? (_baseEntitySavingScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "BaseEntitySavingScriptTask",
					SchemaElementUId = new Guid("9b990da0-84e4-4aa1-ab8f-219ff3a429fa"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = BaseEntitySavingScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _baseEnityValidatingEventSubProcess_f0646c74f291474f9a10143ee868f1c9;
		public ProcessFlowElement BaseEnityValidatingEventSubProcess_f0646c74f291474f9a10143ee868f1c9 {
			get {
				return _baseEnityValidatingEventSubProcess_f0646c74f291474f9a10143ee868f1c9 ?? (_baseEnityValidatingEventSubProcess_f0646c74f291474f9a10143ee868f1c9 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "BaseEnityValidatingEventSubProcess_f0646c74f291474f9a10143ee868f1c9",
					SchemaElementUId = new Guid("f0646c74-f291-474f-9a10-143ee868f1c9"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _baseEnityValidatingStartMessage_b3d5b61f7afe48b5a8cc40317ea9c428;
		public ProcessFlowElement BaseEnityValidatingStartMessage_b3d5b61f7afe48b5a8cc40317ea9c428 {
			get {
				return _baseEnityValidatingStartMessage_b3d5b61f7afe48b5a8cc40317ea9c428 ?? (_baseEnityValidatingStartMessage_b3d5b61f7afe48b5a8cc40317ea9c428 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "BaseEnityValidatingStartMessage_b3d5b61f7afe48b5a8cc40317ea9c428",
					SchemaElementUId = new Guid("b3d5b61f-7afe-48b5-a8cc-40317ea9c428"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _baseEnityValidatingScriptTask_a553628ef6dc4e09bdcf27e446fdc16f;
		public ProcessScriptTask BaseEnityValidatingScriptTask_a553628ef6dc4e09bdcf27e446fdc16f {
			get {
				return _baseEnityValidatingScriptTask_a553628ef6dc4e09bdcf27e446fdc16f ?? (_baseEnityValidatingScriptTask_a553628ef6dc4e09bdcf27e446fdc16f = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "BaseEnityValidatingScriptTask_a553628ef6dc4e09bdcf27e446fdc16f",
					SchemaElementUId = new Guid("a553628e-f6dc-4e09-bdcf-27e446fdc16f"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = BaseEnityValidatingScriptTask_a553628ef6dc4e09bdcf27e446fdc16fExecute,
				});
			}
		}

		private ProcessFlowElement _baseEntityDeletedSubProcess;
		public ProcessFlowElement BaseEntityDeletedSubProcess {
			get {
				return _baseEntityDeletedSubProcess ?? (_baseEntityDeletedSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "BaseEntityDeletedSubProcess",
					SchemaElementUId = new Guid("8140d7e7-fb91-4999-8347-543345440efb"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _baseEntityDeletedStartMessage;
		public ProcessFlowElement BaseEntityDeletedStartMessage {
			get {
				return _baseEntityDeletedStartMessage ?? (_baseEntityDeletedStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "BaseEntityDeletedStartMessage",
					SchemaElementUId = new Guid("c803a450-c8dc-47a4-b704-7125c23db317"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _baseEntityDeletedScriptTask;
		public ProcessScriptTask BaseEntityDeletedScriptTask {
			get {
				return _baseEntityDeletedScriptTask ?? (_baseEntityDeletedScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "BaseEntityDeletedScriptTask",
					SchemaElementUId = new Guid("60f96d87-85be-4d31-856d-8edd6bb953c1"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = BaseEntityDeletedScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[BaseEntityDeletingEventSubProcess2.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseEntityDeletingEventSubProcess2 };
			FlowElements[BaseEntityDeletingStartMessage2.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseEntityDeletingStartMessage2 };
			FlowElements[TryProcessCompleteScriptTask2.SchemaElementUId] = new Collection<ProcessFlowElement> { TryProcessCompleteScriptTask2 };
			FlowElements[BaseEntityEventSubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseEntityEventSubProcess1 };
			FlowElements[BaseEntityStartMessage1.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseEntityStartMessage1 };
			FlowElements[TryProcessCompleteScriptTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { TryProcessCompleteScriptTask1 };
			FlowElements[BaseEntitySavedIndexingTask.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseEntitySavedIndexingTask };
			FlowElements[BaseInsertedEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseInsertedEventSubProcess };
			FlowElements[InsertedStartMessage1.SchemaElementUId] = new Collection<ProcessFlowElement> { InsertedStartMessage1 };
			FlowElements[ScriptTaskInsertedBaseEntity.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTaskInsertedBaseEntity };
			FlowElements[BaseEntitySavingEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseEntitySavingEventSubProcess };
			FlowElements[BaseEntitySavingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseEntitySavingStartMessage };
			FlowElements[BaseEntitySavingScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseEntitySavingScriptTask };
			FlowElements[BaseEnityValidatingEventSubProcess_f0646c74f291474f9a10143ee868f1c9.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseEnityValidatingEventSubProcess_f0646c74f291474f9a10143ee868f1c9 };
			FlowElements[BaseEnityValidatingStartMessage_b3d5b61f7afe48b5a8cc40317ea9c428.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseEnityValidatingStartMessage_b3d5b61f7afe48b5a8cc40317ea9c428 };
			FlowElements[BaseEnityValidatingScriptTask_a553628ef6dc4e09bdcf27e446fdc16f.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseEnityValidatingScriptTask_a553628ef6dc4e09bdcf27e446fdc16f };
			FlowElements[BaseEntityDeletedSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseEntityDeletedSubProcess };
			FlowElements[BaseEntityDeletedStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseEntityDeletedStartMessage };
			FlowElements[BaseEntityDeletedScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseEntityDeletedScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "BaseEntityDeletingEventSubProcess2":
						break;
					case "BaseEntityDeletingStartMessage2":
						e.Context.QueueTasks.Enqueue("TryProcessCompleteScriptTask2");
						break;
					case "TryProcessCompleteScriptTask2":
						break;
					case "BaseEntityEventSubProcess1":
						break;
					case "BaseEntityStartMessage1":
						e.Context.QueueTasks.Enqueue("TryProcessCompleteScriptTask1");
						e.Context.QueueTasks.Enqueue("BaseEntitySavedIndexingTask");
						break;
					case "TryProcessCompleteScriptTask1":
						break;
					case "BaseEntitySavedIndexingTask":
						break;
					case "BaseInsertedEventSubProcess":
						break;
					case "InsertedStartMessage1":
						e.Context.QueueTasks.Enqueue("ScriptTaskInsertedBaseEntity");
						break;
					case "ScriptTaskInsertedBaseEntity":
						break;
					case "BaseEntitySavingEventSubProcess":
						break;
					case "BaseEntitySavingStartMessage":
						e.Context.QueueTasks.Enqueue("BaseEntitySavingScriptTask");
						break;
					case "BaseEntitySavingScriptTask":
						break;
					case "BaseEnityValidatingEventSubProcess_f0646c74f291474f9a10143ee868f1c9":
						break;
					case "BaseEnityValidatingStartMessage_b3d5b61f7afe48b5a8cc40317ea9c428":
						e.Context.QueueTasks.Enqueue("BaseEnityValidatingScriptTask_a553628ef6dc4e09bdcf27e446fdc16f");
						break;
					case "BaseEnityValidatingScriptTask_a553628ef6dc4e09bdcf27e446fdc16f":
						break;
					case "BaseEntityDeletedSubProcess":
						break;
					case "BaseEntityDeletedStartMessage":
						e.Context.QueueTasks.Enqueue("BaseEntityDeletedScriptTask");
						break;
					case "BaseEntityDeletedScriptTask":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("BaseEntityDeletingStartMessage2");
			ActivatedEventElements.Add("BaseEntityStartMessage1");
			ActivatedEventElements.Add("InsertedStartMessage1");
			ActivatedEventElements.Add("BaseEntitySavingStartMessage");
			ActivatedEventElements.Add("BaseEnityValidatingStartMessage_b3d5b61f7afe48b5a8cc40317ea9c428");
			ActivatedEventElements.Add("BaseEntityDeletedStartMessage");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "BaseEntityDeletingEventSubProcess2":
					context.QueueTasks.Dequeue();
					break;
				case "BaseEntityDeletingStartMessage2":
					context.QueueTasks.Dequeue();
					context.SenderName = "BaseEntityDeletingStartMessage2";
					result = BaseEntityDeletingStartMessage2.Execute(context);
					break;
				case "TryProcessCompleteScriptTask2":
					context.QueueTasks.Dequeue();
					context.SenderName = "TryProcessCompleteScriptTask2";
					result = TryProcessCompleteScriptTask2.Execute(context, TryProcessCompleteScriptTask2Execute);
					break;
				case "BaseEntityEventSubProcess1":
					context.QueueTasks.Dequeue();
					break;
				case "BaseEntityStartMessage1":
					context.QueueTasks.Dequeue();
					context.SenderName = "BaseEntityStartMessage1";
					result = BaseEntityStartMessage1.Execute(context);
					break;
				case "TryProcessCompleteScriptTask1":
					context.QueueTasks.Dequeue();
					context.SenderName = "TryProcessCompleteScriptTask1";
					result = TryProcessCompleteScriptTask1.Execute(context, TryProcessCompleteScriptTask1Execute);
					break;
				case "BaseEntitySavedIndexingTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "BaseEntitySavedIndexingTask";
					result = BaseEntitySavedIndexingTask.Execute(context, BaseEntitySavedIndexingTaskExecute);
					break;
				case "BaseInsertedEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "InsertedStartMessage1":
					context.QueueTasks.Dequeue();
					context.SenderName = "InsertedStartMessage1";
					result = InsertedStartMessage1.Execute(context);
					break;
				case "ScriptTaskInsertedBaseEntity":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTaskInsertedBaseEntity";
					result = ScriptTaskInsertedBaseEntity.Execute(context, ScriptTaskInsertedBaseEntityExecute);
					break;
				case "BaseEntitySavingEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "BaseEntitySavingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "BaseEntitySavingStartMessage";
					result = BaseEntitySavingStartMessage.Execute(context);
					break;
				case "BaseEntitySavingScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "BaseEntitySavingScriptTask";
					result = BaseEntitySavingScriptTask.Execute(context, BaseEntitySavingScriptTaskExecute);
					break;
				case "BaseEnityValidatingEventSubProcess_f0646c74f291474f9a10143ee868f1c9":
					context.QueueTasks.Dequeue();
					break;
				case "BaseEnityValidatingStartMessage_b3d5b61f7afe48b5a8cc40317ea9c428":
					context.QueueTasks.Dequeue();
					context.SenderName = "BaseEnityValidatingStartMessage_b3d5b61f7afe48b5a8cc40317ea9c428";
					result = BaseEnityValidatingStartMessage_b3d5b61f7afe48b5a8cc40317ea9c428.Execute(context);
					break;
				case "BaseEnityValidatingScriptTask_a553628ef6dc4e09bdcf27e446fdc16f":
					context.QueueTasks.Dequeue();
					context.SenderName = "BaseEnityValidatingScriptTask_a553628ef6dc4e09bdcf27e446fdc16f";
					result = BaseEnityValidatingScriptTask_a553628ef6dc4e09bdcf27e446fdc16f.Execute(context, BaseEnityValidatingScriptTask_a553628ef6dc4e09bdcf27e446fdc16fExecute);
					break;
				case "BaseEntityDeletedSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "BaseEntityDeletedStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "BaseEntityDeletedStartMessage";
					result = BaseEntityDeletedStartMessage.Execute(context);
					break;
				case "BaseEntityDeletedScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "BaseEntityDeletedScriptTask";
					result = BaseEntityDeletedScriptTask.Execute(context, BaseEntityDeletedScriptTaskExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool TryProcessCompleteScriptTask2Execute(ProcessExecutingContext context) {
			TryProcessComplete(EntityChangeType.Deleted);
			LocalMessageExecuting(EntityChangeType.Deleted);
			ProcessCompleteExecuting();
			return true;
		}

		public virtual bool TryProcessCompleteScriptTask1Execute(ProcessExecutingContext context) {
			ProcessCompleteExecuting();
			return true;
		}

		public virtual bool BaseEntitySavedIndexingTaskExecute(ProcessExecutingContext context) {
			IndexEntity(IndexingOperationType.Index, Entity.PrimaryColumnValue);
			return true;
		}

		public virtual bool ScriptTaskInsertedBaseEntityExecute(ProcessExecutingContext context) {
			TryProcessComplete(EntityChangeType.Inserted);
			LocalMessageExecuting(EntityChangeType.Inserted);
			ProcessCompleteExecuting();
			return true;
		}

		public virtual bool BaseEntitySavingScriptTaskExecute(ProcessExecutingContext context) {
			if (Entity.StoringState == StoringObjectState.New
					|| Entity.StoringState == StoringObjectState.Deleted) {
				return true;
			}
			InitDcmOnEntityChanging();
			TryProcessComplete(EntityChangeType.Updated);
			LocalMessageExecuting(EntityChangeType.Updated);
			return true;
		}

		public virtual bool BaseEnityValidatingScriptTask_a553628ef6dc4e09bdcf27e446fdc16fExecute(ProcessExecutingContext context) {
			if (CanUseDcm) {
				DcmEntityUtilities dcmEntityUtilities = GetDcmEntityUtilities();
				dcmEntityUtilities.ValidateDcmRequiredElement(Entity, (Collection<ProcessListener>)ProcessListeners);
				if (UserConnection.GetIsFeatureEnabled("DcmStagesPermissions")) {
					dcmEntityUtilities.ValidateDcmStagePermissions(Entity, (Collection<ProcessListener>)ProcessListeners);
				}
			}
			return true;
		}

		public virtual bool BaseEntityDeletedScriptTaskExecute(ProcessExecutingContext context) {
			IndexEntity(IndexingOperationType.Delete, Entity.PrimaryColumnValue);
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "BaseEntityDeleting":
							if (ActivatedEventElements.Contains("BaseEntityDeletingStartMessage2")) {
							context.QueueTasks.Enqueue("BaseEntityDeletingStartMessage2");
						}
						break;
					case "BaseEntitySaved":
							if (ActivatedEventElements.Contains("BaseEntityStartMessage1")) {
							context.QueueTasks.Enqueue("BaseEntityStartMessage1");
						}
						break;
					case "BaseEntityInserted":
							if (ActivatedEventElements.Contains("InsertedStartMessage1")) {
							context.QueueTasks.Enqueue("InsertedStartMessage1");
						}
						break;
					case "BaseEntitySaving":
							if (ActivatedEventElements.Contains("BaseEntitySavingStartMessage")) {
							context.QueueTasks.Enqueue("BaseEntitySavingStartMessage");
						}
						break;
					case "BaseEntityValidating":
							if (ActivatedEventElements.Contains("BaseEnityValidatingStartMessage_b3d5b61f7afe48b5a8cc40317ea9c428")) {
							context.QueueTasks.Enqueue("BaseEnityValidatingStartMessage_b3d5b61f7afe48b5a8cc40317ea9c428");
						}
						break;
					case "BaseEntityDeleted":
							if (ActivatedEventElements.Contains("BaseEntityDeletedStartMessage")) {
							context.QueueTasks.Enqueue("BaseEntityDeletedStartMessage");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: OAuthGrantTypeInClient_OAuth20EventsProcess

	/// <exclude/>
	public class OAuthGrantTypeInClient_OAuth20EventsProcess : OAuthGrantTypeInClient_OAuth20EventsProcess<OAuthGrantTypeInClient>
	{

		public OAuthGrantTypeInClient_OAuth20EventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OAuthGrantTypeInClient_OAuth20EventsProcess

	public partial class OAuthGrantTypeInClient_OAuth20EventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual void TryProcessComplete(EntityChangeType changeType) {
			var processEngine = UserConnection.ProcessEngine;
			ProcessListeners = processEngine.GetProcessListeners(UserConnection, Entity, changeType);
			ProcessSchemaListeners = processEngine.GetProcessSchemaListeners(Entity, changeType);
		}

		public virtual bool IsConditionDataMatch(string conditionData) {
			if (string.IsNullOrEmpty(conditionData)) {
				return true;
			}
			var esq = new EntitySchemaQuery(Entity.Schema);
			IEntitySchemaQueryFilterItem filterCollection = null;
			try {
				var userConnectionArgument = new ConstructorArgument("userConnection", UserConnection);
				var processDataContractFilterConverter = ClassFactory
					.Get<IProcessDataContractFilterConverter>(userConnectionArgument);
				filterCollection = processDataContractFilterConverter.ConvertToEntitySchemaQueryFilterItem(esq, conditionData);
			} catch {
				var oldConditionData = ConditionData.Deserialize(conditionData);
				bool oldConditionCompleted = oldConditionData == null || oldConditionData.Count == 0;
				if (!oldConditionCompleted) {
					foreach (var condition in oldConditionData) {
						oldConditionCompleted = Entity.GetColumnValue(Entity.Schema.Columns.GetByUId(condition.Key)).Equals(condition.Value);
						if (oldConditionCompleted) {
							break;
						}
					}
				}
				return oldConditionCompleted;
			}
			if (filterCollection != null) {
				esq.AddColumn(Entity.Schema.PrimaryColumn.Name);
				esq.Filters.Add(filterCollection);
				var entity = esq.GetEntity(UserConnection, Entity.PrimaryColumnValue);
				return entity != null;
			}
			return true;
		}

		public virtual bool IsChangedColumnsMatch(string changedColumns) {
			if (string.IsNullOrEmpty(changedColumns)) {
				return true;
			}
			var changedColumnsMetaPaths = JsonConvert.DeserializeObject<Collection<string>>(changedColumns);
			foreach(var columnMetaPath in changedColumnsMetaPaths){
				var changedColumn = Entity.Schema.GetSchemaColumnByMetaPath(columnMetaPath);
				foreach (var columnValue in Entity.GetChangedColumnValues()) {
					if (Guid.Equals(columnValue.Column.UId, changedColumn.UId)) {
						return true;
					}
				}
			}
			return false;
		}

		public virtual void ProcessCompleteExecuting() {
			var processEngine = UserConnection.ProcessEngine;
			var processListeners = (Collection<ProcessListener>)ProcessListeners;
			var processSchemaListeners = (Collection<ProcessSchemaListener>)ProcessSchemaListeners;
			processEngine.ActualizeProcessSchemaListeners(Entity, processSchemaListeners);
			Collection<ProcessDescriptor> processDescriptors;
			bool nextPrcElReady = false;
			IList<ProcessListener> clonedProcessListeners = null;
			if (processListeners != null && processListeners.Count > 0) {
				clonedProcessListeners = new List<ProcessListener>(processListeners);
				processDescriptors = processEngine.ContinueExecuting(UserConnection, Entity, processListeners);
				foreach (ProcessDescriptor processDescriptor in processDescriptors) {
					nextPrcElReady = nextPrcElReady || processDescriptor.IsNextElementReady;
				}
				processListeners.Clear();
			}
			if (CanUseDcm) {
				processEngine.RunDcmProcesses(Entity, clonedProcessListeners);
			}
			bool nextPrcElReadyBySignal = false;
			if (processSchemaListeners != null && processSchemaListeners.Count > 0) {
				processDescriptors = processEngine.RunProcesses(UserConnection, Entity, processSchemaListeners);
				foreach (ProcessDescriptor processDescriptor in processDescriptors) {
					nextPrcElReadyBySignal = nextPrcElReadyBySignal || processDescriptor.IsNextElementReady;
				}
				processSchemaListeners.Clear();
			}
			if (!nextPrcElReady) {
				nextPrcElReady = nextPrcElReadyBySignal;
			}
			NextProcessElementReady = NextProcessElementReady || nextPrcElReady;
		}

		public virtual bool GetNextPrcElReadyPropertyValue(Entity entity) {
			if (entity != null && entity.Process != null) {
				object nextPrcElReady;
				if (entity.Process.TryGetPropertyValue("NextProcessElementReady", out nextPrcElReady)) {
					return (bool)nextPrcElReady;
				}
			}
			return false;
		}

		public virtual void LocalMessageExecuting(EntityChangeType changeType) {
			return;
		}

		public virtual void InitDcmOnEntityChanging() {
			if (!CanInitDcmForEntity()) {
				return;
			}
			var dcmEntityUtilities = GetDcmEntityUtilities();
			CanUseDcm = dcmEntityUtilities.GetCanEntityUseDcm(Entity.Schema.UId, Entity.GetChangedColumnValues());
			CancelNotEnabledDcmProcess();
		}

		public virtual void CancelNotEnabledDcmProcess() {
			if (CanUseDcm) {
				UserConnection.IProcessEngine.CancelNotEnabledDcmProcess(Entity.Schema.UId, Entity.PrimaryColumnValue);
			}
		}

		public virtual DcmEntityUtilities GetDcmEntityUtilities() {
			if (DcmEntityUtil == null) {
				DcmEntityUtil = new DcmEntityUtilities(UserConnection);
			}
			return (DcmEntityUtilities)DcmEntityUtil;
		}

		public virtual bool CanInitDcmForEntity() {
			var schema = Entity.Schema;
			return schema != null &&
				schema.Name != "AdminUnitFeatureState" &&
				schema.Name != "Feature";
		}

		public virtual void IndexEntity(IndexingOperationType indexingOperationType, Guid primaryColumnValue) {
		}

		#endregion

	}

	#endregion


	#region Class: OAuthGrantTypeInClientEventsProcess

	/// <exclude/>
	public class OAuthGrantTypeInClientEventsProcess : OAuthGrantTypeInClient_OAuth20EventsProcess
	{

		public OAuthGrantTypeInClientEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

