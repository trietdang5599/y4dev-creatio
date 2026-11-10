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

	#region Class: WebhookSchema

	/// <exclude/>
	public class WebhookSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public WebhookSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public WebhookSchema(WebhookSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public WebhookSchema(WebhookSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ebc02c48-ec89-46c6-a8c9-103f84207c23");
			RealUId = new Guid("ebc02c48-ec89-46c6-a8c9-103f84207c23");
			Name = "Webhook";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("c57d96f3-f6a9-41c3-a651-44ed58ea0c9a");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateApiKeyColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("aacd5739-9079-58ee-fa1f-f5524b0e4703")) == null) {
				Columns.Add(CreateSourceUrlColumn());
			}
			if (Columns.FindByUId(new Guid("3d0d2646-d393-b231-d63b-f3aab78f3216")) == null) {
				Columns.Add(CreateWebhookSourceColumn());
			}
			if (Columns.FindByUId(new Guid("feb1f5a0-0436-2679-5698-b0f8e2b09926")) == null) {
				Columns.Add(CreateContentTypeColumn());
			}
			if (Columns.FindByUId(new Guid("ba556cfe-8a64-873b-556f-3c570c0c0669")) == null) {
				Columns.Add(CreateHeadersColumn());
			}
			if (Columns.FindByUId(new Guid("a37fddc3-0de1-d515-e2a7-a92580a79cbe")) == null) {
				Columns.Add(CreateQueryParametersColumn());
			}
			if (Columns.FindByUId(new Guid("21d6578f-bbb6-40ae-b515-e88991b1f824")) == null) {
				Columns.Add(CreateRequestBodyColumn());
			}
			if (Columns.FindByUId(new Guid("41144f15-247a-d382-8f2e-31edbba7a7f0")) == null) {
				Columns.Add(CreateStatusColumn());
			}
			if (Columns.FindByUId(new Guid("3fa0cf53-a526-124b-13c6-6437327a4e62")) == null) {
				Columns.Add(CreateBatchIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateApiKeyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("f9680b32-75cf-cf3b-3858-aefa40d004ad"),
				Name = @"ApiKey",
				CreatedInSchemaUId = new Guid("ebc02c48-ec89-46c6-a8c9-103f84207c23"),
				ModifiedInSchemaUId = new Guid("ebc02c48-ec89-46c6-a8c9-103f84207c23"),
				CreatedInPackageId = new Guid("c57d96f3-f6a9-41c3-a651-44ed58ea0c9a")
			};
		}

		protected virtual EntitySchemaColumn CreateSourceUrlColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("aacd5739-9079-58ee-fa1f-f5524b0e4703"),
				Name = @"SourceUrl",
				CreatedInSchemaUId = new Guid("ebc02c48-ec89-46c6-a8c9-103f84207c23"),
				ModifiedInSchemaUId = new Guid("ebc02c48-ec89-46c6-a8c9-103f84207c23"),
				CreatedInPackageId = new Guid("c57d96f3-f6a9-41c3-a651-44ed58ea0c9a")
			};
		}

		protected virtual EntitySchemaColumn CreateWebhookSourceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("3d0d2646-d393-b231-d63b-f3aab78f3216"),
				Name = @"WebhookSource",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ebc02c48-ec89-46c6-a8c9-103f84207c23"),
				ModifiedInSchemaUId = new Guid("ebc02c48-ec89-46c6-a8c9-103f84207c23"),
				CreatedInPackageId = new Guid("c57d96f3-f6a9-41c3-a651-44ed58ea0c9a")
			};
		}

		protected virtual EntitySchemaColumn CreateContentTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("feb1f5a0-0436-2679-5698-b0f8e2b09926"),
				Name = @"ContentType",
				CreatedInSchemaUId = new Guid("ebc02c48-ec89-46c6-a8c9-103f84207c23"),
				ModifiedInSchemaUId = new Guid("ebc02c48-ec89-46c6-a8c9-103f84207c23"),
				CreatedInPackageId = new Guid("c57d96f3-f6a9-41c3-a651-44ed58ea0c9a")
			};
		}

		protected virtual EntitySchemaColumn CreateHeadersColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("ba556cfe-8a64-873b-556f-3c570c0c0669"),
				Name = @"Headers",
				CreatedInSchemaUId = new Guid("ebc02c48-ec89-46c6-a8c9-103f84207c23"),
				ModifiedInSchemaUId = new Guid("ebc02c48-ec89-46c6-a8c9-103f84207c23"),
				CreatedInPackageId = new Guid("c57d96f3-f6a9-41c3-a651-44ed58ea0c9a"),
				IsSensitiveData = true
			};
		}

		protected virtual EntitySchemaColumn CreateQueryParametersColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("a37fddc3-0de1-d515-e2a7-a92580a79cbe"),
				Name = @"QueryParameters",
				CreatedInSchemaUId = new Guid("ebc02c48-ec89-46c6-a8c9-103f84207c23"),
				ModifiedInSchemaUId = new Guid("ebc02c48-ec89-46c6-a8c9-103f84207c23"),
				CreatedInPackageId = new Guid("c57d96f3-f6a9-41c3-a651-44ed58ea0c9a"),
				IsSensitiveData = true
			};
		}

		protected virtual EntitySchemaColumn CreateRequestBodyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("21d6578f-bbb6-40ae-b515-e88991b1f824"),
				Name = @"RequestBody",
				CreatedInSchemaUId = new Guid("ebc02c48-ec89-46c6-a8c9-103f84207c23"),
				ModifiedInSchemaUId = new Guid("ebc02c48-ec89-46c6-a8c9-103f84207c23"),
				CreatedInPackageId = new Guid("c57d96f3-f6a9-41c3-a651-44ed58ea0c9a"),
				IsSensitiveData = true
			};
		}

		protected virtual EntitySchemaColumn CreateStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("41144f15-247a-d382-8f2e-31edbba7a7f0"),
				Name = @"Status",
				ReferenceSchemaUId = new Guid("585fa8f0-f606-43c9-a053-9122912b4c9e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ebc02c48-ec89-46c6-a8c9-103f84207c23"),
				ModifiedInSchemaUId = new Guid("ebc02c48-ec89-46c6-a8c9-103f84207c23"),
				CreatedInPackageId = new Guid("c57d96f3-f6a9-41c3-a651-44ed58ea0c9a"),
				IsSimpleLookup = true,
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"1546b667-b37a-4dc4-9be9-1ceb3a025332"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateBatchIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("3fa0cf53-a526-124b-13c6-6437327a4e62"),
				Name = @"BatchId",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ebc02c48-ec89-46c6-a8c9-103f84207c23"),
				ModifiedInSchemaUId = new Guid("ebc02c48-ec89-46c6-a8c9-103f84207c23"),
				CreatedInPackageId = new Guid("465cad42-ff63-4d73-9a55-2ad1421a09f5")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Webhook(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Webhook_WebhookServiceEventsProcess(userConnection);
		}

		public override object Clone() {
			return new WebhookSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new WebhookSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ebc02c48-ec89-46c6-a8c9-103f84207c23"));
		}

		#endregion

	}

	#endregion

	#region Class: Webhook

	/// <summary>
	/// Webhook.
	/// </summary>
	/// <remarks>
	/// Represents incoming webhooks from third-party services to extend Creatio functionality through automated callbacks, enabling event-driven data imports and process execution without custom coding.
	/// </remarks>
	public class Webhook : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public Webhook(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Webhook";
		}

		public Webhook(Webhook source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// API key.
		/// </summary>
		public string ApiKey {
			get {
				return GetTypedColumnValue<string>("ApiKey");
			}
			set {
				SetColumnValue("ApiKey", value);
			}
		}

		/// <summary>
		/// SourceUrl.
		/// </summary>
		public string SourceUrl {
			get {
				return GetTypedColumnValue<string>("SourceUrl");
			}
			set {
				SetColumnValue("SourceUrl", value);
			}
		}

		/// <summary>
		/// Webhook source.
		/// </summary>
		/// <remarks>
		/// Indicates the external platform or system that triggered the webhook, helping teams trace data origin and monitor integration performance.
		/// </remarks>
		public string WebhookSource {
			get {
				return GetTypedColumnValue<string>("WebhookSource");
			}
			set {
				SetColumnValue("WebhookSource", value);
			}
		}

		/// <summary>
		/// Content type.
		/// </summary>
		public string ContentType {
			get {
				return GetTypedColumnValue<string>("ContentType");
			}
			set {
				SetColumnValue("ContentType", value);
			}
		}

		/// <summary>
		/// Headers.
		/// </summary>
		/// <remarks>
		/// Specifies the data format used in the webhook payload, ensuring recipients know how to interpret and process incoming information.
		/// </remarks>
		public string Headers {
			get {
				return GetTypedColumnValue<string>("Headers");
			}
			set {
				SetColumnValue("Headers", value);
			}
		}

		/// <summary>
		/// Query parameters.
		/// </summary>
		public string QueryParameters {
			get {
				return GetTypedColumnValue<string>("QueryParameters");
			}
			set {
				SetColumnValue("QueryParameters", value);
			}
		}

		/// <summary>
		/// Request body.
		/// </summary>
		/// <remarks>
		/// Contains the full data payload sent by the webhook, showing the information passed from the source system to support event handling or record updates.
		/// </remarks>
		public string RequestBody {
			get {
				return GetTypedColumnValue<string>("RequestBody");
			}
			set {
				SetColumnValue("RequestBody", value);
			}
		}

		/// <exclude/>
		public Guid StatusId {
			get {
				return GetTypedColumnValue<Guid>("StatusId");
			}
			set {
				SetColumnValue("StatusId", value);
				_status = null;
			}
		}

		/// <exclude/>
		public string StatusName {
			get {
				return GetTypedColumnValue<string>("StatusName");
			}
			set {
				SetColumnValue("StatusName", value);
				if (_status != null) {
					_status.Name = value;
				}
			}
		}

		private WebhookStatus _status;
		/// <summary>
		/// Status.
		/// </summary>
		public WebhookStatus Status {
			get {
				return _status ??
					(_status = LookupColumnEntities.GetEntity("Status") as WebhookStatus);
			}
		}

		/// <summary>
		/// Batch Id.
		/// </summary>
		public Guid BatchId {
			get {
				return GetTypedColumnValue<Guid>("BatchId");
			}
			set {
				SetColumnValue("BatchId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Webhook_WebhookServiceEventsProcess(UserConnection);
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
			return new Webhook(this);
		}

		#endregion

	}

	#endregion

	#region Class: Webhook_WebhookServiceEventsProcess

	/// <exclude/>
	public partial class Webhook_WebhookServiceEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : Webhook
	{

		public Webhook_WebhookServiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Webhook_WebhookServiceEventsProcess";
			SchemaUId = new Guid("ebc02c48-ec89-46c6-a8c9-103f84207c23");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ebc02c48-ec89-46c6-a8c9-103f84207c23");
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

	#region Class: Webhook_WebhookServiceEventsProcess

	/// <exclude/>
	public class Webhook_WebhookServiceEventsProcess : Webhook_WebhookServiceEventsProcess<Webhook>
	{

		public Webhook_WebhookServiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Webhook_WebhookServiceEventsProcess

	public partial class Webhook_WebhookServiceEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: WebhookEventsProcess

	/// <exclude/>
	public class WebhookEventsProcess : Webhook_WebhookServiceEventsProcess
	{

		public WebhookEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

