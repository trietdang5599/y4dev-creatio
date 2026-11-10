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

	#region Class: DeduplicateExecLockerSchema

	/// <exclude/>
	public class DeduplicateExecLockerSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public DeduplicateExecLockerSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public DeduplicateExecLockerSchema(DeduplicateExecLockerSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public DeduplicateExecLockerSchema(DeduplicateExecLockerSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("912f6630-b727-4b7d-aaf9-71ae8d1637cb");
			RealUId = new Guid("912f6630-b727-4b7d-aaf9-71ae8d1637cb");
			Name = "DeduplicateExecLocker";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("a2cb4b0a-72d7-4fbf-b57c-bc3bae7898e7");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateEntitySchemaNameColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("efa1d59a-9306-4176-b1a1-16ab1e0c0822")) == null) {
				Columns.Add(CreateConversationColumn());
			}
			if (Columns.FindByUId(new Guid("ff672427-2b11-45d4-a32f-0568b7b0f4e0")) == null) {
				Columns.Add(CreateOperationColumn());
			}
			if (Columns.FindByUId(new Guid("f34d69e8-fd2f-4e9f-93ab-395a1bbc6537")) == null) {
				Columns.Add(CreateIsInProgressColumn());
			}
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.IsIndexed = false;
			column.ModifiedInSchemaUId = new Guid("912f6630-b727-4b7d-aaf9-71ae8d1637cb");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.IsIndexed = false;
			column.ModifiedInSchemaUId = new Guid("912f6630-b727-4b7d-aaf9-71ae8d1637cb");
			return column;
		}

		protected virtual EntitySchemaColumn CreateEntitySchemaNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("99f7f2f9-3e6a-40f6-9219-7c9bf8546b13"),
				Name = @"EntitySchemaName",
				CreatedInSchemaUId = new Guid("912f6630-b727-4b7d-aaf9-71ae8d1637cb"),
				ModifiedInSchemaUId = new Guid("912f6630-b727-4b7d-aaf9-71ae8d1637cb"),
				CreatedInPackageId = new Guid("a2cb4b0a-72d7-4fbf-b57c-bc3bae7898e7")
			};
		}

		protected virtual EntitySchemaColumn CreateConversationColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("efa1d59a-9306-4176-b1a1-16ab1e0c0822"),
				Name = @"Conversation",
				ReferenceSchemaUId = new Guid("16ffbae1-539a-45e3-96d5-a65dd1f6e045"),
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("912f6630-b727-4b7d-aaf9-71ae8d1637cb"),
				ModifiedInSchemaUId = new Guid("912f6630-b727-4b7d-aaf9-71ae8d1637cb"),
				CreatedInPackageId = new Guid("a2cb4b0a-72d7-4fbf-b57c-bc3bae7898e7")
			};
		}

		protected virtual EntitySchemaColumn CreateOperationColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ff672427-2b11-45d4-a32f-0568b7b0f4e0"),
				Name = @"Operation",
				ReferenceSchemaUId = new Guid("34c91fed-b922-43f7-a0d4-03aed72f7833"),
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("912f6630-b727-4b7d-aaf9-71ae8d1637cb"),
				ModifiedInSchemaUId = new Guid("912f6630-b727-4b7d-aaf9-71ae8d1637cb"),
				CreatedInPackageId = new Guid("a2cb4b0a-72d7-4fbf-b57c-bc3bae7898e7")
			};
		}

		protected virtual EntitySchemaColumn CreateIsInProgressColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("f34d69e8-fd2f-4e9f-93ab-395a1bbc6537"),
				Name = @"IsInProgress",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("912f6630-b727-4b7d-aaf9-71ae8d1637cb"),
				ModifiedInSchemaUId = new Guid("912f6630-b727-4b7d-aaf9-71ae8d1637cb"),
				CreatedInPackageId = new Guid("a2cb4b0a-72d7-4fbf-b57c-bc3bae7898e7")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new DeduplicateExecLocker(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new DeduplicateExecLocker_CrtDeduplicationEventsProcess(userConnection);
		}

		public override object Clone() {
			return new DeduplicateExecLockerSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new DeduplicateExecLockerSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("912f6630-b727-4b7d-aaf9-71ae8d1637cb"));
		}

		#endregion

	}

	#endregion

	#region Class: DeduplicateExecLocker

	/// <summary>
	/// Deduplication locker.
	/// </summary>
	public class DeduplicateExecLocker : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public DeduplicateExecLocker(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "DeduplicateExecLocker";
		}

		public DeduplicateExecLocker(DeduplicateExecLocker source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// EntitySchemaName.
		/// </summary>
		public string EntitySchemaName {
			get {
				return GetTypedColumnValue<string>("EntitySchemaName");
			}
			set {
				SetColumnValue("EntitySchemaName", value);
			}
		}

		/// <exclude/>
		public Guid ConversationId {
			get {
				return GetTypedColumnValue<Guid>("ConversationId");
			}
			set {
				SetColumnValue("ConversationId", value);
				_conversation = null;
			}
		}

		/// <exclude/>
		public string ConversationProcedureName {
			get {
				return GetTypedColumnValue<string>("ConversationProcedureName");
			}
			set {
				SetColumnValue("ConversationProcedureName", value);
				if (_conversation != null) {
					_conversation.ProcedureName = value;
				}
			}
		}

		private DeduplicateExecLog _conversation;
		/// <summary>
		/// Conversation.
		/// </summary>
		public DeduplicateExecLog Conversation {
			get {
				return _conversation ??
					(_conversation = LookupColumnEntities.GetEntity("Conversation") as DeduplicateExecLog);
			}
		}

		/// <exclude/>
		public Guid OperationId {
			get {
				return GetTypedColumnValue<Guid>("OperationId");
			}
			set {
				SetColumnValue("OperationId", value);
				_operation = null;
			}
		}

		/// <exclude/>
		public string OperationName {
			get {
				return GetTypedColumnValue<string>("OperationName");
			}
			set {
				SetColumnValue("OperationName", value);
				if (_operation != null) {
					_operation.Name = value;
				}
			}
		}

		private DeduplicateOperation _operation;
		/// <summary>
		/// Operation.
		/// </summary>
		public DeduplicateOperation Operation {
			get {
				return _operation ??
					(_operation = LookupColumnEntities.GetEntity("Operation") as DeduplicateOperation);
			}
		}

		/// <summary>
		/// IsInProgress.
		/// </summary>
		public bool IsInProgress {
			get {
				return GetTypedColumnValue<bool>("IsInProgress");
			}
			set {
				SetColumnValue("IsInProgress", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new DeduplicateExecLocker_CrtDeduplicationEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("DeduplicateExecLockerDeleted", e);
			Validating += (s, e) => ThrowEvent("DeduplicateExecLockerValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new DeduplicateExecLocker(this);
		}

		#endregion

	}

	#endregion

	#region Class: DeduplicateExecLocker_CrtDeduplicationEventsProcess

	/// <exclude/>
	public partial class DeduplicateExecLocker_CrtDeduplicationEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : DeduplicateExecLocker
	{

		public DeduplicateExecLocker_CrtDeduplicationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "DeduplicateExecLocker_CrtDeduplicationEventsProcess";
			SchemaUId = new Guid("912f6630-b727-4b7d-aaf9-71ae8d1637cb");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("912f6630-b727-4b7d-aaf9-71ae8d1637cb");
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

	#region Class: DeduplicateExecLocker_CrtDeduplicationEventsProcess

	/// <exclude/>
	public class DeduplicateExecLocker_CrtDeduplicationEventsProcess : DeduplicateExecLocker_CrtDeduplicationEventsProcess<DeduplicateExecLocker>
	{

		public DeduplicateExecLocker_CrtDeduplicationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: DeduplicateExecLocker_CrtDeduplicationEventsProcess

	public partial class DeduplicateExecLocker_CrtDeduplicationEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: DeduplicateExecLockerEventsProcess

	/// <exclude/>
	public class DeduplicateExecLockerEventsProcess : DeduplicateExecLocker_CrtDeduplicationEventsProcess
	{

		public DeduplicateExecLockerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

