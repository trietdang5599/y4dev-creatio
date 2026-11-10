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

	#region Class: FinishedSyncSessionSchema

	/// <exclude/>
	public class FinishedSyncSessionSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public FinishedSyncSessionSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public FinishedSyncSessionSchema(FinishedSyncSessionSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public FinishedSyncSessionSchema(FinishedSyncSessionSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("cdcd12e2-6301-4e3d-ba8b-1ecc93972e17");
			RealUId = new Guid("cdcd12e2-6301-4e3d-ba8b-1ecc93972e17");
			Name = "FinishedSyncSession";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("adabfe3b-0923-4e02-ac46-cbcc5e35d9f1")) == null) {
				Columns.Add(CreateSyncSessionIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSyncSessionIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("adabfe3b-0923-4e02-ac46-cbcc5e35d9f1"),
				Name = @"SyncSessionId",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("cdcd12e2-6301-4e3d-ba8b-1ecc93972e17"),
				ModifiedInSchemaUId = new Guid("cdcd12e2-6301-4e3d-ba8b-1ecc93972e17"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new FinishedSyncSession(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new FinishedSyncSession_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new FinishedSyncSessionSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new FinishedSyncSessionSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("cdcd12e2-6301-4e3d-ba8b-1ecc93972e17"));
		}

		#endregion

	}

	#endregion

	#region Class: FinishedSyncSession

	/// <summary>
	/// FinishedSyncSession.
	/// </summary>
	public class FinishedSyncSession : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public FinishedSyncSession(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "FinishedSyncSession";
		}

		public FinishedSyncSession(FinishedSyncSession source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// SyncSessionId.
		/// </summary>
		public string SyncSessionId {
			get {
				return GetTypedColumnValue<string>("SyncSessionId");
			}
			set {
				SetColumnValue("SyncSessionId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new FinishedSyncSession_CrtBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("FinishedSyncSessionDeleted", e);
			Validating += (s, e) => ThrowEvent("FinishedSyncSessionValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new FinishedSyncSession(this);
		}

		#endregion

	}

	#endregion

	#region Class: FinishedSyncSession_CrtBaseEventsProcess

	/// <exclude/>
	public partial class FinishedSyncSession_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : FinishedSyncSession
	{

		public FinishedSyncSession_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "FinishedSyncSession_CrtBaseEventsProcess";
			SchemaUId = new Guid("cdcd12e2-6301-4e3d-ba8b-1ecc93972e17");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("cdcd12e2-6301-4e3d-ba8b-1ecc93972e17");
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

	#region Class: FinishedSyncSession_CrtBaseEventsProcess

	/// <exclude/>
	public class FinishedSyncSession_CrtBaseEventsProcess : FinishedSyncSession_CrtBaseEventsProcess<FinishedSyncSession>
	{

		public FinishedSyncSession_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: FinishedSyncSession_CrtBaseEventsProcess

	public partial class FinishedSyncSession_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: FinishedSyncSessionEventsProcess

	/// <exclude/>
	public class FinishedSyncSessionEventsProcess : FinishedSyncSession_CrtBaseEventsProcess
	{

		public FinishedSyncSessionEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

