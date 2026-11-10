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

	#region Class: EmailSyncQueueSchema

	/// <exclude/>
	public class EmailSyncQueueSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public EmailSyncQueueSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public EmailSyncQueueSchema(EmailSyncQueueSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public EmailSyncQueueSchema(EmailSyncQueueSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIx_MessageId_MailboxIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("bf3aac4b-5f98-47a7-b36d-58d777208f52");
			index.Name = "Ix_MessageId_Mailbox";
			index.CreatedInSchemaUId = new Guid("f25f02f1-f7c2-4440-bac8-3f3842564cbc");
			index.ModifiedInSchemaUId = new Guid("f25f02f1-f7c2-4440-bac8-3f3842564cbc");
			index.CreatedInPackageId = new Guid("ae09655d-6d1e-4f67-a349-758ea4dc6e33");
			EntitySchemaIndexColumn messageIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("3d818697-696b-6bbd-b234-de0daff38d1d"),
				ColumnUId = new Guid("5b419b02-5833-9aee-cdb7-ab087807e7a2"),
				CreatedInSchemaUId = new Guid("f25f02f1-f7c2-4440-bac8-3f3842564cbc"),
				ModifiedInSchemaUId = new Guid("f25f02f1-f7c2-4440-bac8-3f3842564cbc"),
				CreatedInPackageId = new Guid("ae09655d-6d1e-4f67-a349-758ea4dc6e33"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(messageIdIndexColumn);
			EntitySchemaIndexColumn mailboxIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("74e2e392-e4fa-3145-d30b-7999f056b8e5"),
				ColumnUId = new Guid("0913466e-f8cf-4048-3619-d6ecdca3e306"),
				CreatedInSchemaUId = new Guid("f25f02f1-f7c2-4440-bac8-3f3842564cbc"),
				ModifiedInSchemaUId = new Guid("f25f02f1-f7c2-4440-bac8-3f3842564cbc"),
				CreatedInPackageId = new Guid("ae09655d-6d1e-4f67-a349-758ea4dc6e33"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(mailboxIdIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f25f02f1-f7c2-4440-bac8-3f3842564cbc");
			RealUId = new Guid("f25f02f1-f7c2-4440-bac8-3f3842564cbc");
			Name = "EmailSyncQueue";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("ae09655d-6d1e-4f67-a349-758ea4dc6e33");
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
			if (Columns.FindByUId(new Guid("5b419b02-5833-9aee-cdb7-ab087807e7a2")) == null) {
				Columns.Add(CreateMessageIdColumn());
			}
			if (Columns.FindByUId(new Guid("0913466e-f8cf-4048-3619-d6ecdca3e306")) == null) {
				Columns.Add(CreateMailboxColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateMessageIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("5b419b02-5833-9aee-cdb7-ab087807e7a2"),
				Name = @"MessageId",
				CreatedInSchemaUId = new Guid("f25f02f1-f7c2-4440-bac8-3f3842564cbc"),
				ModifiedInSchemaUId = new Guid("f25f02f1-f7c2-4440-bac8-3f3842564cbc"),
				CreatedInPackageId = new Guid("ae09655d-6d1e-4f67-a349-758ea4dc6e33")
			};
		}

		protected virtual EntitySchemaColumn CreateMailboxColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("0913466e-f8cf-4048-3619-d6ecdca3e306"),
				Name = @"Mailbox",
				ReferenceSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("f25f02f1-f7c2-4440-bac8-3f3842564cbc"),
				ModifiedInSchemaUId = new Guid("f25f02f1-f7c2-4440-bac8-3f3842564cbc"),
				CreatedInPackageId = new Guid("ae09655d-6d1e-4f67-a349-758ea4dc6e33"),
				IsSimpleLookup = true
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIx_MessageId_MailboxIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new EmailSyncQueue(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new EmailSyncQueue_IntegrationV2EventsProcess(userConnection);
		}

		public override object Clone() {
			return new EmailSyncQueueSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new EmailSyncQueueSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f25f02f1-f7c2-4440-bac8-3f3842564cbc"));
		}

		#endregion

	}

	#endregion

	#region Class: EmailSyncQueue

	/// <summary>
	/// Email sync queue.
	/// </summary>
	public class EmailSyncQueue : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public EmailSyncQueue(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "EmailSyncQueue";
		}

		public EmailSyncQueue(EmailSyncQueue source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// MessageId.
		/// </summary>
		public string MessageId {
			get {
				return GetTypedColumnValue<string>("MessageId");
			}
			set {
				SetColumnValue("MessageId", value);
			}
		}

		/// <exclude/>
		public Guid MailboxId {
			get {
				return GetTypedColumnValue<Guid>("MailboxId");
			}
			set {
				SetColumnValue("MailboxId", value);
				_mailbox = null;
			}
		}

		/// <exclude/>
		public string MailboxUserName {
			get {
				return GetTypedColumnValue<string>("MailboxUserName");
			}
			set {
				SetColumnValue("MailboxUserName", value);
				if (_mailbox != null) {
					_mailbox.UserName = value;
				}
			}
		}

		private MailboxSyncSettings _mailbox;
		/// <summary>
		/// Mailbox.
		/// </summary>
		public MailboxSyncSettings Mailbox {
			get {
				return _mailbox ??
					(_mailbox = LookupColumnEntities.GetEntity("Mailbox") as MailboxSyncSettings);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new EmailSyncQueue_IntegrationV2EventsProcess(UserConnection);
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
			return new EmailSyncQueue(this);
		}

		#endregion

	}

	#endregion

	#region Class: EmailSyncQueue_IntegrationV2EventsProcess

	/// <exclude/>
	public partial class EmailSyncQueue_IntegrationV2EventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : EmailSyncQueue
	{

		public EmailSyncQueue_IntegrationV2EventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "EmailSyncQueue_IntegrationV2EventsProcess";
			SchemaUId = new Guid("f25f02f1-f7c2-4440-bac8-3f3842564cbc");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("f25f02f1-f7c2-4440-bac8-3f3842564cbc");
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

	#region Class: EmailSyncQueue_IntegrationV2EventsProcess

	/// <exclude/>
	public class EmailSyncQueue_IntegrationV2EventsProcess : EmailSyncQueue_IntegrationV2EventsProcess<EmailSyncQueue>
	{

		public EmailSyncQueue_IntegrationV2EventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: EmailSyncQueue_IntegrationV2EventsProcess

	public partial class EmailSyncQueue_IntegrationV2EventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: EmailSyncQueueEventsProcess

	/// <exclude/>
	public class EmailSyncQueueEventsProcess : EmailSyncQueue_IntegrationV2EventsProcess
	{

		public EmailSyncQueueEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

