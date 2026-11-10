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

	#region Class: CallEventInboxSchema

	/// <exclude/>
	public class CallEventInboxSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public CallEventInboxSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CallEventInboxSchema(CallEventInboxSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CallEventInboxSchema(CallEventInboxSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("420ea659-491e-4225-8d75-8f48fa2114dd");
			RealUId = new Guid("420ea659-491e-4225-8d75-8f48fa2114dd");
			Name = "CallEventInbox";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
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

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateEventDataColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("45fc2d8e-dbd2-47e3-b813-9d210ce0ef87")) == null) {
				Columns.Add(CreateCallColumn());
			}
			if (Columns.FindByUId(new Guid("55c69745-2eb6-41f1-8341-35b9f0ed43b0")) == null) {
				Columns.Add(CreateEventTimeStampColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCallColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("45fc2d8e-dbd2-47e3-b813-9d210ce0ef87"),
				Name = @"Call",
				ReferenceSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("420ea659-491e-4225-8d75-8f48fa2114dd"),
				ModifiedInSchemaUId = new Guid("420ea659-491e-4225-8d75-8f48fa2114dd"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateEventTimeStampColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("55c69745-2eb6-41f1-8341-35b9f0ed43b0"),
				Name = @"EventTimeStamp",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("420ea659-491e-4225-8d75-8f48fa2114dd"),
				ModifiedInSchemaUId = new Guid("420ea659-491e-4225-8d75-8f48fa2114dd"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateEventDataColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("268e4555-b745-4fc1-bdaf-630e992651c0"),
				Name = @"EventData",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("420ea659-491e-4225-8d75-8f48fa2114dd"),
				ModifiedInSchemaUId = new Guid("420ea659-491e-4225-8d75-8f48fa2114dd"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new CallEventInbox(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CallEventInbox_CrtCoreBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CallEventInboxSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CallEventInboxSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("420ea659-491e-4225-8d75-8f48fa2114dd"));
		}

		#endregion

	}

	#endregion

	#region Class: CallEventInbox

	/// <summary>
	/// Call event inbox.
	/// </summary>
	public class CallEventInbox : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public CallEventInbox(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CallEventInbox";
		}

		public CallEventInbox(CallEventInbox source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid CallId {
			get {
				return GetTypedColumnValue<Guid>("CallId");
			}
			set {
				SetColumnValue("CallId", value);
				_call = null;
			}
		}

		/// <exclude/>
		public string CallCaption {
			get {
				return GetTypedColumnValue<string>("CallCaption");
			}
			set {
				SetColumnValue("CallCaption", value);
				if (_call != null) {
					_call.Caption = value;
				}
			}
		}

		private Call _call;
		/// <summary>
		/// Call.
		/// </summary>
		public Call Call {
			get {
				return _call ??
					(_call = LookupColumnEntities.GetEntity("Call") as Call);
			}
		}

		/// <summary>
		/// Event timestamp.
		/// </summary>
		public DateTime EventTimeStamp {
			get {
				return GetTypedColumnValue<DateTime>("EventTimeStamp");
			}
			set {
				SetColumnValue("EventTimeStamp", value);
			}
		}

		/// <summary>
		/// Event data.
		/// </summary>
		public string EventData {
			get {
				return GetTypedColumnValue<string>("EventData");
			}
			set {
				SetColumnValue("EventData", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CallEventInbox_CrtCoreBaseEventsProcess(UserConnection);
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
			return new CallEventInbox(this);
		}

		#endregion

	}

	#endregion

	#region Class: CallEventInbox_CrtCoreBaseEventsProcess

	/// <exclude/>
	public partial class CallEventInbox_CrtCoreBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : CallEventInbox
	{

		public CallEventInbox_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CallEventInbox_CrtCoreBaseEventsProcess";
			SchemaUId = new Guid("420ea659-491e-4225-8d75-8f48fa2114dd");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("420ea659-491e-4225-8d75-8f48fa2114dd");
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

	#region Class: CallEventInbox_CrtCoreBaseEventsProcess

	/// <exclude/>
	public class CallEventInbox_CrtCoreBaseEventsProcess : CallEventInbox_CrtCoreBaseEventsProcess<CallEventInbox>
	{

		public CallEventInbox_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CallEventInbox_CrtCoreBaseEventsProcess

	public partial class CallEventInbox_CrtCoreBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CallEventInboxEventsProcess

	/// <exclude/>
	public class CallEventInboxEventsProcess : CallEventInbox_CrtCoreBaseEventsProcess
	{

		public CallEventInboxEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

