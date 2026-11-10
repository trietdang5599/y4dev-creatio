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

	#region Class: WebhookStatusSchema

	/// <exclude/>
	public class WebhookStatusSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public WebhookStatusSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public WebhookStatusSchema(WebhookStatusSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public WebhookStatusSchema(WebhookStatusSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("585fa8f0-f606-43c9-a053-9122912b4c9e");
			RealUId = new Guid("585fa8f0-f606-43c9-a053-9122912b4c9e");
			Name = "WebhookStatus";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("61c13b36-df90-4d5b-abdb-12d5efdb63fa");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryColorColumn() {
			base.InitializePrimaryColorColumn();
			PrimaryColorColumn = CreateColorColumn();
			if (Columns.FindByUId(PrimaryColorColumn.UId) == null) {
				Columns.Add(PrimaryColorColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("f56e0323-449a-f2e3-5e76-26dc94b110be")) == null) {
				Columns.Add(CreateDisasterRecoveryAfterColumn());
			}
			if (Columns.FindByUId(new Guid("8fb5d475-4641-733e-b09a-5871a559a6f1")) == null) {
				Columns.Add(CreateDeleteAfterDaysColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateDisasterRecoveryAfterColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("f56e0323-449a-f2e3-5e76-26dc94b110be"),
				Name = @"DisasterRecoveryAfter",
				CreatedInSchemaUId = new Guid("585fa8f0-f606-43c9-a053-9122912b4c9e"),
				ModifiedInSchemaUId = new Guid("585fa8f0-f606-43c9-a053-9122912b4c9e"),
				CreatedInPackageId = new Guid("61c13b36-df90-4d5b-abdb-12d5efdb63fa")
			};
		}

		protected virtual EntitySchemaColumn CreateDeleteAfterDaysColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("8fb5d475-4641-733e-b09a-5871a559a6f1"),
				Name = @"DeleteAfterDays",
				CreatedInSchemaUId = new Guid("585fa8f0-f606-43c9-a053-9122912b4c9e"),
				ModifiedInSchemaUId = new Guid("585fa8f0-f606-43c9-a053-9122912b4c9e"),
				CreatedInPackageId = new Guid("61c13b36-df90-4d5b-abdb-12d5efdb63fa")
			};
		}

		protected virtual EntitySchemaColumn CreateColorColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Color")) {
				UId = new Guid("bbd17fab-16c7-babb-e5cd-89c4051cad9c"),
				Name = @"Color",
				CreatedInSchemaUId = new Guid("585fa8f0-f606-43c9-a053-9122912b4c9e"),
				ModifiedInSchemaUId = new Guid("585fa8f0-f606-43c9-a053-9122912b4c9e"),
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
			return new WebhookStatus(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new WebhookStatus_WebhookServiceEventsProcess(userConnection);
		}

		public override object Clone() {
			return new WebhookStatusSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new WebhookStatusSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("585fa8f0-f606-43c9-a053-9122912b4c9e"));
		}

		#endregion

	}

	#endregion

	#region Class: WebhookStatus

	/// <summary>
	/// Webhook status.
	/// </summary>
	public class WebhookStatus : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public WebhookStatus(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "WebhookStatus";
		}

		public WebhookStatus(WebhookStatus source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Disaster recovery after (minutes).
		/// </summary>
		/// <remarks>
		/// Disaster recovery after N minutes.
		/// </remarks>
		public int DisasterRecoveryAfter {
			get {
				return GetTypedColumnValue<int>("DisasterRecoveryAfter");
			}
			set {
				SetColumnValue("DisasterRecoveryAfter", value);
			}
		}

		/// <summary>
		/// Delete after (days).
		/// </summary>
		/// <remarks>
		/// Delete webhooks in this status after N days.
		/// </remarks>
		public int DeleteAfterDays {
			get {
				return GetTypedColumnValue<int>("DeleteAfterDays");
			}
			set {
				SetColumnValue("DeleteAfterDays", value);
			}
		}

		/// <summary>
		/// Color.
		/// </summary>
		public Color Color {
			get {
				return GetTypedColumnValue<Color>("Color");
			}
			set {
				SetColumnValue("Color", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new WebhookStatus_WebhookServiceEventsProcess(UserConnection);
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
			return new WebhookStatus(this);
		}

		#endregion

	}

	#endregion

	#region Class: WebhookStatus_WebhookServiceEventsProcess

	/// <exclude/>
	public partial class WebhookStatus_WebhookServiceEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : WebhookStatus
	{

		public WebhookStatus_WebhookServiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "WebhookStatus_WebhookServiceEventsProcess";
			SchemaUId = new Guid("585fa8f0-f606-43c9-a053-9122912b4c9e");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("585fa8f0-f606-43c9-a053-9122912b4c9e");
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

	#region Class: WebhookStatus_WebhookServiceEventsProcess

	/// <exclude/>
	public class WebhookStatus_WebhookServiceEventsProcess : WebhookStatus_WebhookServiceEventsProcess<WebhookStatus>
	{

		public WebhookStatus_WebhookServiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: WebhookStatus_WebhookServiceEventsProcess

	public partial class WebhookStatus_WebhookServiceEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: WebhookStatusEventsProcess

	/// <exclude/>
	public class WebhookStatusEventsProcess : WebhookStatus_WebhookServiceEventsProcess
	{

		public WebhookStatusEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

