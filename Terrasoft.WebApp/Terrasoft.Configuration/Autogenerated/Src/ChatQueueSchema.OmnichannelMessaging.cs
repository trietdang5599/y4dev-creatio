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

	#region Class: ChatQueue_OmnichannelMessaging_CreatioSchema

	/// <exclude/>
	public class ChatQueue_OmnichannelMessaging_CreatioSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ChatQueue_OmnichannelMessaging_CreatioSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ChatQueue_OmnichannelMessaging_CreatioSchema(ChatQueue_OmnichannelMessaging_CreatioSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ChatQueue_OmnichannelMessaging_CreatioSchema(ChatQueue_OmnichannelMessaging_CreatioSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("607ebc03-4933-45ff-abe9-ba80df351a8c");
			RealUId = new Guid("607ebc03-4933-45ff-abe9-ba80df351a8c");
			Name = "ChatQueue_OmnichannelMessaging_Creatio";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("fe318069-3d3c-4328-afd6-b81d71766949");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateNameColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("3eee9d1c-ac37-43ba-a21c-77280f41448a")) == null) {
				Columns.Add(CreateOperatorRoutingRuleColumn());
			}
			if (Columns.FindByUId(new Guid("56ff7252-79d6-4dca-96c8-916bb85cc7f0")) == null) {
				Columns.Add(CreateSimultaneousChatsColumn());
			}
			if (Columns.FindByUId(new Guid("08c14b79-af5d-4551-8f59-a302bf604fa4")) == null) {
				Columns.Add(CreateChatTimeoutColumn());
			}
			if (Columns.FindByUId(new Guid("05d56abf-277e-4ba7-adc5-cb92376b0dbe")) == null) {
				Columns.Add(CreateTimeToWaitInQueueColumn());
			}
			if (Columns.FindByUId(new Guid("7cb00841-40c0-d993-8acb-42ea0ea3db1b")) == null) {
				Columns.Add(CreateOngoingResponseTimeColumn());
			}
			if (Columns.FindByUId(new Guid("e3425c1e-dfdb-4681-b72c-ae712b456536")) == null) {
				Columns.Add(CreateFirstResponseTimeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("57e101aa-33fe-4f2f-a1af-a070d779a02b"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("607ebc03-4933-45ff-abe9-ba80df351a8c"),
				ModifiedInSchemaUId = new Guid("607ebc03-4933-45ff-abe9-ba80df351a8c"),
				CreatedInPackageId = new Guid("fe318069-3d3c-4328-afd6-b81d71766949"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateOperatorRoutingRuleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("3eee9d1c-ac37-43ba-a21c-77280f41448a"),
				Name = @"OperatorRoutingRule",
				ReferenceSchemaUId = new Guid("b50aefe5-94b9-49a4-bdba-d91846c5d2c2"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("607ebc03-4933-45ff-abe9-ba80df351a8c"),
				ModifiedInSchemaUId = new Guid("607ebc03-4933-45ff-abe9-ba80df351a8c"),
				CreatedInPackageId = new Guid("fe318069-3d3c-4328-afd6-b81d71766949")
			};
		}

		protected virtual EntitySchemaColumn CreateSimultaneousChatsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("56ff7252-79d6-4dca-96c8-916bb85cc7f0"),
				Name = @"SimultaneousChats",
				CreatedInSchemaUId = new Guid("607ebc03-4933-45ff-abe9-ba80df351a8c"),
				ModifiedInSchemaUId = new Guid("607ebc03-4933-45ff-abe9-ba80df351a8c"),
				CreatedInPackageId = new Guid("fe318069-3d3c-4328-afd6-b81d71766949")
			};
		}

		protected virtual EntitySchemaColumn CreateChatTimeoutColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("08c14b79-af5d-4551-8f59-a302bf604fa4"),
				Name = @"ChatTimeout",
				CreatedInSchemaUId = new Guid("607ebc03-4933-45ff-abe9-ba80df351a8c"),
				ModifiedInSchemaUId = new Guid("607ebc03-4933-45ff-abe9-ba80df351a8c"),
				CreatedInPackageId = new Guid("fe318069-3d3c-4328-afd6-b81d71766949")
			};
		}

		protected virtual EntitySchemaColumn CreateTimeToWaitInQueueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("05d56abf-277e-4ba7-adc5-cb92376b0dbe"),
				Name = @"TimeToWaitInQueue",
				CreatedInSchemaUId = new Guid("607ebc03-4933-45ff-abe9-ba80df351a8c"),
				ModifiedInSchemaUId = new Guid("607ebc03-4933-45ff-abe9-ba80df351a8c"),
				CreatedInPackageId = new Guid("559bd000-2cc9-4c85-a75e-e0f0e89dfe52")
			};
		}

		protected virtual EntitySchemaColumn CreateOngoingResponseTimeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("7cb00841-40c0-d993-8acb-42ea0ea3db1b"),
				Name = @"OngoingResponseTime",
				CreatedInSchemaUId = new Guid("607ebc03-4933-45ff-abe9-ba80df351a8c"),
				ModifiedInSchemaUId = new Guid("607ebc03-4933-45ff-abe9-ba80df351a8c"),
				CreatedInPackageId = new Guid("08afff10-3d0c-4f3d-b6a0-28a42952a988")
			};
		}

		protected virtual EntitySchemaColumn CreateFirstResponseTimeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("e3425c1e-dfdb-4681-b72c-ae712b456536"),
				Name = @"FirstResponseTime",
				CreatedInSchemaUId = new Guid("607ebc03-4933-45ff-abe9-ba80df351a8c"),
				ModifiedInSchemaUId = new Guid("607ebc03-4933-45ff-abe9-ba80df351a8c"),
				CreatedInPackageId = new Guid("08afff10-3d0c-4f3d-b6a0-28a42952a988")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ChatQueue_OmnichannelMessaging_Creatio(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ChatQueue_OmnichannelMessagingEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ChatQueue_OmnichannelMessaging_CreatioSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ChatQueue_OmnichannelMessaging_CreatioSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("607ebc03-4933-45ff-abe9-ba80df351a8c"));
		}

		#endregion

	}

	#endregion

	#region Class: ChatQueue_OmnichannelMessaging_Creatio

	/// <summary>
	/// Chat queue.
	/// </summary>
	/// <remarks>
	/// Manages the queue of incoming chats to distribute conversations among available agents and ensure timely customer responses.
	/// </remarks>
	public class ChatQueue_OmnichannelMessaging_Creatio : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ChatQueue_OmnichannelMessaging_Creatio(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ChatQueue_OmnichannelMessaging_Creatio";
		}

		public ChatQueue_OmnichannelMessaging_Creatio(ChatQueue_OmnichannelMessaging_Creatio source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Name.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		/// <exclude/>
		public Guid OperatorRoutingRuleId {
			get {
				return GetTypedColumnValue<Guid>("OperatorRoutingRuleId");
			}
			set {
				SetColumnValue("OperatorRoutingRuleId", value);
				_operatorRoutingRule = null;
			}
		}

		/// <exclude/>
		public string OperatorRoutingRuleName {
			get {
				return GetTypedColumnValue<string>("OperatorRoutingRuleName");
			}
			set {
				SetColumnValue("OperatorRoutingRuleName", value);
				if (_operatorRoutingRule != null) {
					_operatorRoutingRule.Name = value;
				}
			}
		}

		private OperatorRoutingRules _operatorRoutingRule;
		/// <summary>
		/// Routing rule.
		/// </summary>
		public OperatorRoutingRules OperatorRoutingRule {
			get {
				return _operatorRoutingRule ??
					(_operatorRoutingRule = LookupColumnEntities.GetEntity("OperatorRoutingRule") as OperatorRoutingRules);
			}
		}

		/// <summary>
		/// Simultaneous Chats.
		/// </summary>
		public int SimultaneousChats {
			get {
				return GetTypedColumnValue<int>("SimultaneousChats");
			}
			set {
				SetColumnValue("SimultaneousChats", value);
			}
		}

		/// <summary>
		/// Chat timeout, minutes.
		/// </summary>
		public int ChatTimeout {
			get {
				return GetTypedColumnValue<int>("ChatTimeout");
			}
			set {
				SetColumnValue("ChatTimeout", value);
			}
		}

		/// <summary>
		/// Time to wait in queue.
		/// </summary>
		public int TimeToWaitInQueue {
			get {
				return GetTypedColumnValue<int>("TimeToWaitInQueue");
			}
			set {
				SetColumnValue("TimeToWaitInQueue", value);
			}
		}

		/// <summary>
		/// Ongoing response time, minutes.
		/// </summary>
		/// <remarks>
		/// Maximum time allowed for the agent to reply to customer messages during an active chat before it becomes overdue.
		/// </remarks>
		public int OngoingResponseTime {
			get {
				return GetTypedColumnValue<int>("OngoingResponseTime");
			}
			set {
				SetColumnValue("OngoingResponseTime", value);
			}
		}

		/// <summary>
		/// First response time, minutes.
		/// </summary>
		/// <remarks>
		/// Maximum time allowed for the agent to send the first reply before the chat becomes overdue.
		/// </remarks>
		public int FirstResponseTime {
			get {
				return GetTypedColumnValue<int>("FirstResponseTime");
			}
			set {
				SetColumnValue("FirstResponseTime", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ChatQueue_OmnichannelMessagingEventsProcess(UserConnection);
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
			return new ChatQueue_OmnichannelMessaging_Creatio(this);
		}

		#endregion

	}

	#endregion

	#region Class: ChatQueue_OmnichannelMessagingEventsProcess

	/// <exclude/>
	public partial class ChatQueue_OmnichannelMessagingEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : ChatQueue_OmnichannelMessaging_Creatio
	{

		public ChatQueue_OmnichannelMessagingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ChatQueue_OmnichannelMessagingEventsProcess";
			SchemaUId = new Guid("607ebc03-4933-45ff-abe9-ba80df351a8c");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("607ebc03-4933-45ff-abe9-ba80df351a8c");
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

	#region Class: ChatQueue_OmnichannelMessagingEventsProcess

	/// <exclude/>
	public class ChatQueue_OmnichannelMessagingEventsProcess : ChatQueue_OmnichannelMessagingEventsProcess<ChatQueue_OmnichannelMessaging_Creatio>
	{

		public ChatQueue_OmnichannelMessagingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ChatQueue_OmnichannelMessagingEventsProcess

	public partial class ChatQueue_OmnichannelMessagingEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

