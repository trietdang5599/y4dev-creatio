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
	using System.Text;
	using System.Text.RegularExpressions;
	using System.Web;
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
	using Terrasoft.Core.Store;
	using Terrasoft.GlobalSearch.Indexing;
	using Terrasoft.UI.WebControls.Controls;
	using Terrasoft.UI.WebControls.Utilities.Json.Converters;

	#region Class: ActivitySchema

	/// <exclude/>
	public class ActivitySchema : Terrasoft.Configuration.Activity_Timeline_CreatioSchema
	{

		#region Constructors: Public

		public ActivitySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ActivitySchema(ActivitySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ActivitySchema(ActivitySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("87d566cd-7f96-4e23-9145-1ae23a765eda");
			Name = "Activity";
			ParentSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89");
			ExtendParent = true;
			CreatedInPackageId = new Guid("08afff10-3d0c-4f3d-b6a0-28a42952a988");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = false;
			UseLiveEditing = true;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("e4eae837-3880-4fb6-b3d9-1e07e1412230")) == null) {
				Columns.Add(CreateOmniChatColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("87d566cd-7f96-4e23-9145-1ae23a765eda");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("87d566cd-7f96-4e23-9145-1ae23a765eda");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("87d566cd-7f96-4e23-9145-1ae23a765eda");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("87d566cd-7f96-4e23-9145-1ae23a765eda");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("87d566cd-7f96-4e23-9145-1ae23a765eda");
			return column;
		}

		protected override EntitySchemaColumn CreateTimeZoneColumn() {
			EntitySchemaColumn column = base.CreateTimeZoneColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("87d566cd-7f96-4e23-9145-1ae23a765eda");
			return column;
		}

		protected override EntitySchemaColumn CreateNotesColumn() {
			EntitySchemaColumn column = base.CreateNotesColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("87d566cd-7f96-4e23-9145-1ae23a765eda");
			return column;
		}

		protected override EntitySchemaColumn CreateColorColumn() {
			EntitySchemaColumn column = base.CreateColorColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("87d566cd-7f96-4e23-9145-1ae23a765eda");
			return column;
		}

		protected override EntitySchemaColumn CreateAllowedResultColumn() {
			EntitySchemaColumn column = base.CreateAllowedResultColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("87d566cd-7f96-4e23-9145-1ae23a765eda");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByInvCRMColumn() {
			EntitySchemaColumn column = base.CreateCreatedByInvCRMColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("87d566cd-7f96-4e23-9145-1ae23a765eda");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("87d566cd-7f96-4e23-9145-1ae23a765eda");
			return column;
		}

		protected override EntitySchemaColumn CreateIsHtmlBodyColumn() {
			EntitySchemaColumn column = base.CreateIsHtmlBodyColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("87d566cd-7f96-4e23-9145-1ae23a765eda");
			return column;
		}

		protected override EntitySchemaColumn CreateMailHashColumn() {
			EntitySchemaColumn column = base.CreateMailHashColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("87d566cd-7f96-4e23-9145-1ae23a765eda");
			return column;
		}

		protected virtual EntitySchemaColumn CreateOmniChatColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e4eae837-3880-4fb6-b3d9-1e07e1412230"),
				Name = @"OmniChat",
				ReferenceSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("87d566cd-7f96-4e23-9145-1ae23a765eda"),
				ModifiedInSchemaUId = new Guid("87d566cd-7f96-4e23-9145-1ae23a765eda"),
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
			return new Activity(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Activity_OmnichannelMessagingEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ActivitySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ActivitySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("87d566cd-7f96-4e23-9145-1ae23a765eda"));
		}

		#endregion

	}

	#endregion

	#region Class: Activity

	/// <summary>
	/// Activity.
	/// </summary>
	public class Activity : Terrasoft.Configuration.Activity_Timeline_Creatio
	{

		#region Constructors: Public

		public Activity(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Activity";
		}

		public Activity(Activity source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid OmniChatId {
			get {
				return GetTypedColumnValue<Guid>("OmniChatId");
			}
			set {
				SetColumnValue("OmniChatId", value);
				_omniChat = null;
			}
		}

		/// <exclude/>
		public string OmniChatName {
			get {
				return GetTypedColumnValue<string>("OmniChatName");
			}
			set {
				SetColumnValue("OmniChatName", value);
				if (_omniChat != null) {
					_omniChat.Name = value;
				}
			}
		}

		private OmniChat _omniChat;
		/// <summary>
		/// Chat.
		/// </summary>
		public OmniChat OmniChat {
			get {
				return _omniChat ??
					(_omniChat = LookupColumnEntities.GetEntity("OmniChat") as OmniChat);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Activity_OmnichannelMessagingEventsProcess(UserConnection);
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
			return new Activity(this);
		}

		#endregion

	}

	#endregion

	#region Class: Activity_OmnichannelMessagingEventsProcess

	/// <exclude/>
	public partial class Activity_OmnichannelMessagingEventsProcess<TEntity> : Terrasoft.Configuration.Activity_TimelineEventsProcess<TEntity> where TEntity : Activity
	{

		public Activity_OmnichannelMessagingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Activity_OmnichannelMessagingEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("87d566cd-7f96-4e23-9145-1ae23a765eda");
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

	#region Class: Activity_OmnichannelMessagingEventsProcess

	/// <exclude/>
	public class Activity_OmnichannelMessagingEventsProcess : Activity_OmnichannelMessagingEventsProcess<Activity>
	{

		public Activity_OmnichannelMessagingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Activity_OmnichannelMessagingEventsProcess

	public partial class Activity_OmnichannelMessagingEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ActivityEventsProcess

	/// <exclude/>
	public class ActivityEventsProcess : Activity_OmnichannelMessagingEventsProcess
	{

		public ActivityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

