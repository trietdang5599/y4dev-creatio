namespace Terrasoft.Configuration
{

	using DataContract = Terrasoft.Nui.ServiceModel.DataContract;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.IO;
	using System.Linq;
	using Terrasoft.Common;
	using Terrasoft.Common.Json;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DcmProcess;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;
	using Terrasoft.GlobalSearch.Indexing;
	using Terrasoft.Social;

	#region Class: SocialAccount_IntegrationV2_CreatioSchema

	/// <exclude/>
	public class SocialAccount_IntegrationV2_CreatioSchema : Terrasoft.Configuration.SocialAccount_FacebookIntegration_CreatioSchema
	{

		#region Constructors: Public

		public SocialAccount_IntegrationV2_CreatioSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SocialAccount_IntegrationV2_CreatioSchema(SocialAccount_IntegrationV2_CreatioSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SocialAccount_IntegrationV2_CreatioSchema(SocialAccount_IntegrationV2_CreatioSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("c66a877d-aefb-4780-aaf3-c44cca7dee5d");
			Name = "SocialAccount_IntegrationV2_Creatio";
			ParentSchemaUId = new Guid("76e3d8e8-6c6b-48b5-9f43-3b361c368bff");
			ExtendParent = true;
			CreatedInPackageId = new Guid("53a64f50-911e-4e24-83fd-d5af8c28bfa3");
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
			if (Columns.FindByUId(new Guid("a9d64e3e-a2df-c59c-c162-3fb51c942bd1")) == null) {
				Columns.Add(CreateEnableColumn());
			}
			if (Columns.FindByUId(new Guid("c7f17ae5-e207-34d7-b382-6705c7e55a41")) == null) {
				Columns.Add(CreateMailboxSyncSettingsColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateEnableColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("a9d64e3e-a2df-c59c-c162-3fb51c942bd1"),
				Name = @"Enable",
				CreatedInSchemaUId = new Guid("c66a877d-aefb-4780-aaf3-c44cca7dee5d"),
				ModifiedInSchemaUId = new Guid("c66a877d-aefb-4780-aaf3-c44cca7dee5d"),
				CreatedInPackageId = new Guid("53a64f50-911e-4e24-83fd-d5af8c28bfa3"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"False"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateMailboxSyncSettingsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("c7f17ae5-e207-34d7-b382-6705c7e55a41"),
				Name = @"MailboxSyncSettings",
				ReferenceSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("c66a877d-aefb-4780-aaf3-c44cca7dee5d"),
				ModifiedInSchemaUId = new Guid("c66a877d-aefb-4780-aaf3-c44cca7dee5d"),
				CreatedInPackageId = new Guid("53a64f50-911e-4e24-83fd-d5af8c28bfa3"),
				IsSimpleLookup = true
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SocialAccount_IntegrationV2_Creatio(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SocialAccount_IntegrationV2EventsProcess(userConnection);
		}

		public override object Clone() {
			return new SocialAccount_IntegrationV2_CreatioSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SocialAccount_IntegrationV2_CreatioSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c66a877d-aefb-4780-aaf3-c44cca7dee5d"));
		}

		#endregion

	}

	#endregion

	#region Class: SocialAccount_IntegrationV2_Creatio

	/// <summary>
	/// Accounts in external resources.
	/// </summary>
	public class SocialAccount_IntegrationV2_Creatio : Terrasoft.Configuration.SocialAccount_FacebookIntegration_Creatio
	{

		#region Constructors: Public

		public SocialAccount_IntegrationV2_Creatio(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SocialAccount_IntegrationV2_Creatio";
		}

		public SocialAccount_IntegrationV2_Creatio(SocialAccount_IntegrationV2_Creatio source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Enable.
		/// </summary>
		public bool Enable {
			get {
				return GetTypedColumnValue<bool>("Enable");
			}
			set {
				SetColumnValue("Enable", value);
			}
		}

		/// <exclude/>
		public Guid MailboxSyncSettingsId {
			get {
				return GetTypedColumnValue<Guid>("MailboxSyncSettingsId");
			}
			set {
				SetColumnValue("MailboxSyncSettingsId", value);
				_mailboxSyncSettings = null;
			}
		}

		/// <exclude/>
		public string MailboxSyncSettingsUserName {
			get {
				return GetTypedColumnValue<string>("MailboxSyncSettingsUserName");
			}
			set {
				SetColumnValue("MailboxSyncSettingsUserName", value);
				if (_mailboxSyncSettings != null) {
					_mailboxSyncSettings.UserName = value;
				}
			}
		}

		private MailboxSyncSettings _mailboxSyncSettings;
		/// <summary>
		/// Mailbox synchronization settings.
		/// </summary>
		public MailboxSyncSettings MailboxSyncSettings {
			get {
				return _mailboxSyncSettings ??
					(_mailboxSyncSettings = LookupColumnEntities.GetEntity("MailboxSyncSettings") as MailboxSyncSettings);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SocialAccount_IntegrationV2EventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleting += (s, e) => ThrowEvent("SocialAccount_IntegrationV2_CreatioDeleting", e);
			Inserted += (s, e) => ThrowEvent("SocialAccount_IntegrationV2_CreatioInserted", e);
			Inserting += (s, e) => ThrowEvent("SocialAccount_IntegrationV2_CreatioInserting", e);
			Saved += (s, e) => ThrowEvent("SocialAccount_IntegrationV2_CreatioSaved", e);
			Saving += (s, e) => ThrowEvent("SocialAccount_IntegrationV2_CreatioSaving", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SocialAccount_IntegrationV2_Creatio(this);
		}

		#endregion

	}

	#endregion

	#region Class: SocialAccount_IntegrationV2EventsProcess

	/// <exclude/>
	public partial class SocialAccount_IntegrationV2EventsProcess<TEntity> : Terrasoft.Configuration.SocialAccount_FacebookIntegrationEventsProcess<TEntity> where TEntity : SocialAccount_IntegrationV2_Creatio
	{

		public SocialAccount_IntegrationV2EventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SocialAccount_IntegrationV2EventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("c66a877d-aefb-4780-aaf3-c44cca7dee5d");
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

	#region Class: SocialAccount_IntegrationV2EventsProcess

	/// <exclude/>
	public class SocialAccount_IntegrationV2EventsProcess : SocialAccount_IntegrationV2EventsProcess<SocialAccount_IntegrationV2_Creatio>
	{

		public SocialAccount_IntegrationV2EventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SocialAccount_IntegrationV2EventsProcess

	public partial class SocialAccount_IntegrationV2EventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

