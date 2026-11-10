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

	#region Class: VwCopilotRequestSchema

	/// <exclude/>
	public class VwCopilotRequestSchema : Terrasoft.Configuration.CopilotRequestEntSchema
	{

		#region Constructors: Public

		public VwCopilotRequestSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwCopilotRequestSchema(VwCopilotRequestSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwCopilotRequestSchema(VwCopilotRequestSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("2621cbb3-7817-4e99-8e01-320eff9c7b13");
			RealUId = new Guid("2621cbb3-7817-4e99-8e01-320eff9c7b13");
			Name = "VwCopilotRequest";
			ParentSchemaUId = new Guid("b846aaa6-f2d5-4146-9fc0-606dfd041b5e");
			ExtendParent = false;
			CreatedInPackageId = new Guid("7a3a8162-4be1-46b5-bd50-b3efc2df6d2e");
			IsDBView = true;
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
			if (Columns.FindByUId(new Guid("5d0d9e2b-37a4-7c5b-19d4-40e496345fdb")) == null) {
				Columns.Add(CreateIntentColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateIntentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("5d0d9e2b-37a4-7c5b-19d4-40e496345fdb"),
				Name = @"Intent",
				ReferenceSchemaUId = new Guid("90fa6d02-3e93-45d6-a72b-58dcffa411ae"),
				IsValueCloneable = false,
				IsWeakReference = true,
				CreatedInSchemaUId = new Guid("2621cbb3-7817-4e99-8e01-320eff9c7b13"),
				ModifiedInSchemaUId = new Guid("2621cbb3-7817-4e99-8e01-320eff9c7b13"),
				CreatedInPackageId = new Guid("7a3a8162-4be1-46b5-bd50-b3efc2df6d2e"),
				IsSimpleLookup = true
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwCopilotRequest(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwCopilotRequest_CrtCopilotEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwCopilotRequestSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwCopilotRequestSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2621cbb3-7817-4e99-8e01-320eff9c7b13"));
		}

		#endregion

	}

	#endregion

	#region Class: VwCopilotRequest

	/// <summary>
	/// Creatio.ai request (view).
	/// </summary>
	public class VwCopilotRequest : Terrasoft.Configuration.CopilotRequestEnt
	{

		#region Constructors: Public

		public VwCopilotRequest(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwCopilotRequest";
		}

		public VwCopilotRequest(VwCopilotRequest source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid IntentId {
			get {
				return GetTypedColumnValue<Guid>("IntentId");
			}
			set {
				SetColumnValue("IntentId", value);
				_intent = null;
			}
		}

		/// <exclude/>
		public string IntentCaption {
			get {
				return GetTypedColumnValue<string>("IntentCaption");
			}
			set {
				SetColumnValue("IntentCaption", value);
				if (_intent != null) {
					_intent.Caption = value;
				}
			}
		}

		private VwSysSchemaInfo _intent;
		/// <summary>
		/// Skill.
		/// </summary>
		public VwSysSchemaInfo Intent {
			get {
				return _intent ??
					(_intent = LookupColumnEntities.GetEntity("Intent") as VwSysSchemaInfo);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwCopilotRequest_CrtCopilotEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwCopilotRequestDeleted", e);
			Deleting += (s, e) => ThrowEvent("VwCopilotRequestDeleting", e);
			Inserted += (s, e) => ThrowEvent("VwCopilotRequestInserted", e);
			Inserting += (s, e) => ThrowEvent("VwCopilotRequestInserting", e);
			Saved += (s, e) => ThrowEvent("VwCopilotRequestSaved", e);
			Saving += (s, e) => ThrowEvent("VwCopilotRequestSaving", e);
			Validating += (s, e) => ThrowEvent("VwCopilotRequestValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwCopilotRequest(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwCopilotRequest_CrtCopilotEventsProcess

	/// <exclude/>
	public partial class VwCopilotRequest_CrtCopilotEventsProcess<TEntity> : Terrasoft.Configuration.CopilotRequestEnt_CrtCopilotEventsProcess<TEntity> where TEntity : VwCopilotRequest
	{

		public VwCopilotRequest_CrtCopilotEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwCopilotRequest_CrtCopilotEventsProcess";
			SchemaUId = new Guid("2621cbb3-7817-4e99-8e01-320eff9c7b13");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("2621cbb3-7817-4e99-8e01-320eff9c7b13");
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

	#region Class: VwCopilotRequest_CrtCopilotEventsProcess

	/// <exclude/>
	public class VwCopilotRequest_CrtCopilotEventsProcess : VwCopilotRequest_CrtCopilotEventsProcess<VwCopilotRequest>
	{

		public VwCopilotRequest_CrtCopilotEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwCopilotRequest_CrtCopilotEventsProcess

	public partial class VwCopilotRequest_CrtCopilotEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwCopilotRequestEventsProcess

	/// <exclude/>
	public class VwCopilotRequestEventsProcess : VwCopilotRequest_CrtCopilotEventsProcess
	{

		public VwCopilotRequestEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

