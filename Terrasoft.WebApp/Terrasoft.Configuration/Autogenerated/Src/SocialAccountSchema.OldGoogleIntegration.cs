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

	#region Class: SocialAccountSchema

	/// <exclude/>
	public class SocialAccountSchema : Terrasoft.Configuration.SocialAccount_IntegrationV2_CreatioSchema
	{

		#region Constructors: Public

		public SocialAccountSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SocialAccountSchema(SocialAccountSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SocialAccountSchema(SocialAccountSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("4e62e4bd-1569-4da9-a9fc-c608d58891d4");
			Name = "SocialAccount";
			ParentSchemaUId = new Guid("76e3d8e8-6c6b-48b5-9f43-3b361c368bff");
			ExtendParent = true;
			CreatedInPackageId = new Guid("52b3cada-ce6c-428b-8a0e-143feca571df");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("71a9d7b4-9e55-d643-e1bb-d308a72a1820")) == null) {
				Columns.Add(CreateMailServerColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateMailServerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("71a9d7b4-9e55-d643-e1bb-d308a72a1820"),
				Name = @"MailServer",
				ReferenceSchemaUId = new Guid("7ba8351f-9a61-49e6-9e0d-8b32ed25c4c4"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("4e62e4bd-1569-4da9-a9fc-c608d58891d4"),
				ModifiedInSchemaUId = new Guid("4e62e4bd-1569-4da9-a9fc-c608d58891d4"),
				CreatedInPackageId = new Guid("52b3cada-ce6c-428b-8a0e-143feca571df"),
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
			return new SocialAccount(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SocialAccount_OldGoogleIntegrationEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SocialAccountSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SocialAccountSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4e62e4bd-1569-4da9-a9fc-c608d58891d4"));
		}

		#endregion

	}

	#endregion

	#region Class: SocialAccount

	/// <summary>
	/// Accounts in external resources.
	/// </summary>
	public class SocialAccount : Terrasoft.Configuration.SocialAccount_IntegrationV2_Creatio
	{

		#region Constructors: Public

		public SocialAccount(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SocialAccount";
		}

		public SocialAccount(SocialAccount source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid MailServerId {
			get {
				return GetTypedColumnValue<Guid>("MailServerId");
			}
			set {
				SetColumnValue("MailServerId", value);
				_mailServer = null;
			}
		}

		/// <exclude/>
		public string MailServerName {
			get {
				return GetTypedColumnValue<string>("MailServerName");
			}
			set {
				SetColumnValue("MailServerName", value);
				if (_mailServer != null) {
					_mailServer.Name = value;
				}
			}
		}

		private MailServer _mailServer;
		/// <summary>
		/// Mail provider.
		/// </summary>
		public MailServer MailServer {
			get {
				return _mailServer ??
					(_mailServer = LookupColumnEntities.GetEntity("MailServer") as MailServer);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SocialAccount_OldGoogleIntegrationEventsProcess(UserConnection);
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
			return new SocialAccount(this);
		}

		#endregion

	}

	#endregion

	#region Class: SocialAccount_OldGoogleIntegrationEventsProcess

	/// <exclude/>
	public partial class SocialAccount_OldGoogleIntegrationEventsProcess<TEntity> : Terrasoft.Configuration.SocialAccount_IntegrationV2EventsProcess<TEntity> where TEntity : SocialAccount
	{

		public SocialAccount_OldGoogleIntegrationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SocialAccount_OldGoogleIntegrationEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("4e62e4bd-1569-4da9-a9fc-c608d58891d4");
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

	#region Class: SocialAccount_OldGoogleIntegrationEventsProcess

	/// <exclude/>
	public class SocialAccount_OldGoogleIntegrationEventsProcess : SocialAccount_OldGoogleIntegrationEventsProcess<SocialAccount>
	{

		public SocialAccount_OldGoogleIntegrationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SocialAccount_OldGoogleIntegrationEventsProcess

	public partial class SocialAccount_OldGoogleIntegrationEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SocialAccountEventsProcess

	/// <exclude/>
	public class SocialAccountEventsProcess : SocialAccount_OldGoogleIntegrationEventsProcess
	{

		public SocialAccountEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

