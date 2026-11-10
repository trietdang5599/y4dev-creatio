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

	#region Class: WebhookEntitySchema

	/// <exclude/>
	public class WebhookEntitySchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public WebhookEntitySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public WebhookEntitySchema(WebhookEntitySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public WebhookEntitySchema(WebhookEntitySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("09074f8f-4005-45f7-959c-ce600e3ded56");
			RealUId = new Guid("09074f8f-4005-45f7-959c-ce600e3ded56");
			Name = "WebhookEntity";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("61c13b36-df90-4d5b-abdb-12d5efdb63fa");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = false;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.IsLocalizable = false;
			column.ModifiedInSchemaUId = new Guid("09074f8f-4005-45f7-959c-ce600e3ded56");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new WebhookEntity(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new WebhookEntity_WebhookServiceEventsProcess(userConnection);
		}

		public override object Clone() {
			return new WebhookEntitySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new WebhookEntitySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("09074f8f-4005-45f7-959c-ce600e3ded56"));
		}

		#endregion

	}

	#endregion

	#region Class: WebhookEntity

	/// <summary>
	/// Webhook entity.
	/// </summary>
	public class WebhookEntity : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public WebhookEntity(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "WebhookEntity";
		}

		public WebhookEntity(WebhookEntity source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new WebhookEntity_WebhookServiceEventsProcess(UserConnection);
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
			return new WebhookEntity(this);
		}

		#endregion

	}

	#endregion

	#region Class: WebhookEntity_WebhookServiceEventsProcess

	/// <exclude/>
	public partial class WebhookEntity_WebhookServiceEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : WebhookEntity
	{

		public WebhookEntity_WebhookServiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "WebhookEntity_WebhookServiceEventsProcess";
			SchemaUId = new Guid("09074f8f-4005-45f7-959c-ce600e3ded56");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("09074f8f-4005-45f7-959c-ce600e3ded56");
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

	#region Class: WebhookEntity_WebhookServiceEventsProcess

	/// <exclude/>
	public class WebhookEntity_WebhookServiceEventsProcess : WebhookEntity_WebhookServiceEventsProcess<WebhookEntity>
	{

		public WebhookEntity_WebhookServiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: WebhookEntity_WebhookServiceEventsProcess

	public partial class WebhookEntity_WebhookServiceEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: WebhookEntityEventsProcess

	/// <exclude/>
	public class WebhookEntityEventsProcess : WebhookEntity_WebhookServiceEventsProcess
	{

		public WebhookEntityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

