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

	#region Class: WebhookLogSchema

	/// <exclude/>
	public class WebhookLogSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public WebhookLogSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public WebhookLogSchema(WebhookLogSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public WebhookLogSchema(WebhookLogSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("bd36a306-8659-43a0-bbf3-43e50ccaa4ee");
			RealUId = new Guid("bd36a306-8659-43a0-bbf3-43e50ccaa4ee");
			Name = "WebhookLog";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("36626603-47c4-466f-86bd-c3e914028c6d");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("0aaea9e1-49c4-b70e-6764-e8c3ec21ce85")) == null) {
				Columns.Add(CreateMessageColumn());
			}
			if (Columns.FindByUId(new Guid("8da3a0e7-cc64-57e8-76fc-9a09fb09b4ad")) == null) {
				Columns.Add(CreateWebhookColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateMessageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("0aaea9e1-49c4-b70e-6764-e8c3ec21ce85"),
				Name = @"Message",
				CreatedInSchemaUId = new Guid("bd36a306-8659-43a0-bbf3-43e50ccaa4ee"),
				ModifiedInSchemaUId = new Guid("bd36a306-8659-43a0-bbf3-43e50ccaa4ee"),
				CreatedInPackageId = new Guid("36626603-47c4-466f-86bd-c3e914028c6d")
			};
		}

		protected virtual EntitySchemaColumn CreateWebhookColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("8da3a0e7-cc64-57e8-76fc-9a09fb09b4ad"),
				Name = @"Webhook",
				ReferenceSchemaUId = new Guid("ebc02c48-ec89-46c6-a8c9-103f84207c23"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("bd36a306-8659-43a0-bbf3-43e50ccaa4ee"),
				ModifiedInSchemaUId = new Guid("bd36a306-8659-43a0-bbf3-43e50ccaa4ee"),
				CreatedInPackageId = new Guid("36626603-47c4-466f-86bd-c3e914028c6d")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new WebhookLog(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new WebhookLog_WebhookServiceEventsProcess(userConnection);
		}

		public override object Clone() {
			return new WebhookLogSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new WebhookLogSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("bd36a306-8659-43a0-bbf3-43e50ccaa4ee"));
		}

		#endregion

	}

	#endregion

	#region Class: WebhookLog

	/// <summary>
	/// Webhook log.
	/// </summary>
	public class WebhookLog : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public WebhookLog(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "WebhookLog";
		}

		public WebhookLog(WebhookLog source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Message.
		/// </summary>
		public string Message {
			get {
				return GetTypedColumnValue<string>("Message");
			}
			set {
				SetColumnValue("Message", value);
			}
		}

		/// <exclude/>
		public Guid WebhookId {
			get {
				return GetTypedColumnValue<Guid>("WebhookId");
			}
			set {
				SetColumnValue("WebhookId", value);
				_webhook = null;
			}
		}

		/// <exclude/>
		public string WebhookApiKey {
			get {
				return GetTypedColumnValue<string>("WebhookApiKey");
			}
			set {
				SetColumnValue("WebhookApiKey", value);
				if (_webhook != null) {
					_webhook.ApiKey = value;
				}
			}
		}

		private Webhook _webhook;
		/// <summary>
		/// Webhook.
		/// </summary>
		public Webhook Webhook {
			get {
				return _webhook ??
					(_webhook = LookupColumnEntities.GetEntity("Webhook") as Webhook);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new WebhookLog_WebhookServiceEventsProcess(UserConnection);
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
			return new WebhookLog(this);
		}

		#endregion

	}

	#endregion

	#region Class: WebhookLog_WebhookServiceEventsProcess

	/// <exclude/>
	public partial class WebhookLog_WebhookServiceEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : WebhookLog
	{

		public WebhookLog_WebhookServiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "WebhookLog_WebhookServiceEventsProcess";
			SchemaUId = new Guid("bd36a306-8659-43a0-bbf3-43e50ccaa4ee");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("bd36a306-8659-43a0-bbf3-43e50ccaa4ee");
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

	#region Class: WebhookLog_WebhookServiceEventsProcess

	/// <exclude/>
	public class WebhookLog_WebhookServiceEventsProcess : WebhookLog_WebhookServiceEventsProcess<WebhookLog>
	{

		public WebhookLog_WebhookServiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: WebhookLog_WebhookServiceEventsProcess

	public partial class WebhookLog_WebhookServiceEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: WebhookLogEventsProcess

	/// <exclude/>
	public class WebhookLogEventsProcess : WebhookLog_WebhookServiceEventsProcess
	{

		public WebhookLogEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

