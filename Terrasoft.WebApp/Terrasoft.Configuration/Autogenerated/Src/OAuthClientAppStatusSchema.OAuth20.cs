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

	#region Class: OAuthClientAppStatusSchema

	/// <exclude/>
	public class OAuthClientAppStatusSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public OAuthClientAppStatusSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OAuthClientAppStatusSchema(OAuthClientAppStatusSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OAuthClientAppStatusSchema(OAuthClientAppStatusSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4088b7c2-278a-435f-8231-f44083af7875");
			RealUId = new Guid("4088b7c2-278a-435f-8231-f44083af7875");
			Name = "OAuthClientAppStatus";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("24a107aa-9a97-48af-9bdd-eac299d821dd");
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
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new OAuthClientAppStatus(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OAuthClientAppStatus_OAuth20EventsProcess(userConnection);
		}

		public override object Clone() {
			return new OAuthClientAppStatusSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OAuthClientAppStatusSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4088b7c2-278a-435f-8231-f44083af7875"));
		}

		#endregion

	}

	#endregion

	#region Class: OAuthClientAppStatus

	/// <summary>
	/// OAuth client application status.
	/// </summary>
	public class OAuthClientAppStatus : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public OAuthClientAppStatus(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OAuthClientAppStatus";
		}

		public OAuthClientAppStatus(OAuthClientAppStatus source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OAuthClientAppStatus_OAuth20EventsProcess(UserConnection);
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
			return new OAuthClientAppStatus(this);
		}

		#endregion

	}

	#endregion

	#region Class: OAuthClientAppStatus_OAuth20EventsProcess

	/// <exclude/>
	public partial class OAuthClientAppStatus_OAuth20EventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : OAuthClientAppStatus
	{

		public OAuthClientAppStatus_OAuth20EventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OAuthClientAppStatus_OAuth20EventsProcess";
			SchemaUId = new Guid("4088b7c2-278a-435f-8231-f44083af7875");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("4088b7c2-278a-435f-8231-f44083af7875");
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

	#region Class: OAuthClientAppStatus_OAuth20EventsProcess

	/// <exclude/>
	public class OAuthClientAppStatus_OAuth20EventsProcess : OAuthClientAppStatus_OAuth20EventsProcess<OAuthClientAppStatus>
	{

		public OAuthClientAppStatus_OAuth20EventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OAuthClientAppStatus_OAuth20EventsProcess

	public partial class OAuthClientAppStatus_OAuth20EventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: OAuthClientAppStatusEventsProcess

	/// <exclude/>
	public class OAuthClientAppStatusEventsProcess : OAuthClientAppStatus_OAuth20EventsProcess
	{

		public OAuthClientAppStatusEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

