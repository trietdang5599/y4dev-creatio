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

	#region Class: DuplicateStatusSchema

	/// <exclude/>
	public class DuplicateStatusSchema : Terrasoft.Configuration.BaseCodeLookupSchema
	{

		#region Constructors: Public

		public DuplicateStatusSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public DuplicateStatusSchema(DuplicateStatusSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public DuplicateStatusSchema(DuplicateStatusSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("590f25a6-b7bf-4ca0-816a-415e3518a148");
			RealUId = new Guid("590f25a6-b7bf-4ca0-816a-415e3518a148");
			Name = "DuplicateStatus";
			ParentSchemaUId = new Guid("2681062b-df59-4e52-89ed-f9b7dc909ab2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
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
			return new DuplicateStatus(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new DuplicateStatus_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new DuplicateStatusSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new DuplicateStatusSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("590f25a6-b7bf-4ca0-816a-415e3518a148"));
		}

		#endregion

	}

	#endregion

	#region Class: DuplicateStatus

	/// <summary>
	/// Record Status.
	/// </summary>
	public class DuplicateStatus : Terrasoft.Configuration.BaseCodeLookup
	{

		#region Constructors: Public

		public DuplicateStatus(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "DuplicateStatus";
		}

		public DuplicateStatus(DuplicateStatus source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new DuplicateStatus_CrtBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("DuplicateStatusDeleted", e);
			Deleting += (s, e) => ThrowEvent("DuplicateStatusDeleting", e);
			Inserted += (s, e) => ThrowEvent("DuplicateStatusInserted", e);
			Inserting += (s, e) => ThrowEvent("DuplicateStatusInserting", e);
			Saved += (s, e) => ThrowEvent("DuplicateStatusSaved", e);
			Saving += (s, e) => ThrowEvent("DuplicateStatusSaving", e);
			Validating += (s, e) => ThrowEvent("DuplicateStatusValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new DuplicateStatus(this);
		}

		#endregion

	}

	#endregion

	#region Class: DuplicateStatus_CrtBaseEventsProcess

	/// <exclude/>
	public partial class DuplicateStatus_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseCodeLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : DuplicateStatus
	{

		public DuplicateStatus_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "DuplicateStatus_CrtBaseEventsProcess";
			SchemaUId = new Guid("590f25a6-b7bf-4ca0-816a-415e3518a148");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("590f25a6-b7bf-4ca0-816a-415e3518a148");
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

	#region Class: DuplicateStatus_CrtBaseEventsProcess

	/// <exclude/>
	public class DuplicateStatus_CrtBaseEventsProcess : DuplicateStatus_CrtBaseEventsProcess<DuplicateStatus>
	{

		public DuplicateStatus_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: DuplicateStatus_CrtBaseEventsProcess

	public partial class DuplicateStatus_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: DuplicateStatusEventsProcess

	/// <exclude/>
	public class DuplicateStatusEventsProcess : DuplicateStatus_CrtBaseEventsProcess
	{

		public DuplicateStatusEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

