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

	#region Class: OAuthApplicationsSchema

	/// <exclude/>
	public class OAuthApplicationsSchema : Terrasoft.Configuration.OAuthApplications_CrtCoreBase_CreatioSchema
	{

		#region Constructors: Public

		public OAuthApplicationsSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OAuthApplicationsSchema(OAuthApplicationsSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OAuthApplicationsSchema(OAuthApplicationsSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("5f3d940c-3582-4d20-bba2-abab76ac1fc9");
			Name = "OAuthApplications";
			ParentSchemaUId = new Guid("2d30ef0a-87fb-474a-a348-a8cb46e23e6e");
			ExtendParent = true;
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
			if (Columns.FindByUId(new Guid("08cd23f6-9242-a9eb-d7b4-e86dbc43b397")) == null) {
				Columns.Add(CreateTenantIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateTenantIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("08cd23f6-9242-a9eb-d7b4-e86dbc43b397"),
				Name = @"TenantId",
				CreatedInSchemaUId = new Guid("5f3d940c-3582-4d20-bba2-abab76ac1fc9"),
				ModifiedInSchemaUId = new Guid("5f3d940c-3582-4d20-bba2-abab76ac1fc9"),
				CreatedInPackageId = new Guid("ae09655d-6d1e-4f67-a349-758ea4dc6e33")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new OAuthApplications(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OAuthApplications_IntegrationV2EventsProcess(userConnection);
		}

		public override object Clone() {
			return new OAuthApplicationsSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OAuthApplicationsSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5f3d940c-3582-4d20-bba2-abab76ac1fc9"));
		}

		#endregion

	}

	#endregion

	#region Class: OAuthApplications

	/// <summary>
	/// OAuth applications settings.
	/// </summary>
	public class OAuthApplications : Terrasoft.Configuration.OAuthApplications_CrtCoreBase_Creatio
	{

		#region Constructors: Public

		public OAuthApplications(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OAuthApplications";
		}

		public OAuthApplications(OAuthApplications source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// TenantId.
		/// </summary>
		public string TenantId {
			get {
				return GetTypedColumnValue<string>("TenantId");
			}
			set {
				SetColumnValue("TenantId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OAuthApplications_IntegrationV2EventsProcess(UserConnection);
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
			return new OAuthApplications(this);
		}

		#endregion

	}

	#endregion

	#region Class: OAuthApplications_IntegrationV2EventsProcess

	/// <exclude/>
	public partial class OAuthApplications_IntegrationV2EventsProcess<TEntity> : Terrasoft.Configuration.OAuthApplications_CrtCoreBaseEventsProcess<TEntity> where TEntity : OAuthApplications
	{

		public OAuthApplications_IntegrationV2EventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OAuthApplications_IntegrationV2EventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("5f3d940c-3582-4d20-bba2-abab76ac1fc9");
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

	#region Class: OAuthApplications_IntegrationV2EventsProcess

	/// <exclude/>
	public class OAuthApplications_IntegrationV2EventsProcess : OAuthApplications_IntegrationV2EventsProcess<OAuthApplications>
	{

		public OAuthApplications_IntegrationV2EventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OAuthApplications_IntegrationV2EventsProcess

	public partial class OAuthApplications_IntegrationV2EventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: OAuthApplicationsEventsProcess

	/// <exclude/>
	public class OAuthApplicationsEventsProcess : OAuthApplications_IntegrationV2EventsProcess
	{

		public OAuthApplicationsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

