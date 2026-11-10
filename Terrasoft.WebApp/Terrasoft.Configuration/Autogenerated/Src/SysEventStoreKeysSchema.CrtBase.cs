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

	#region Class: SysEventStoreKeysSchema

	/// <exclude/>
	public class SysEventStoreKeysSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysEventStoreKeysSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysEventStoreKeysSchema(SysEventStoreKeysSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysEventStoreKeysSchema(SysEventStoreKeysSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4c7e6f2f-4e70-4eb0-973b-f07ac6073d28");
			RealUId = new Guid("4c7e6f2f-4e70-4eb0-973b-f07ac6073d28");
			Name = "SysEventStoreKeys";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("e0aab226-2b0a-263a-3629-b0f0d4349ea0")) == null) {
				Columns.Add(CreateEventStreamIdColumn());
			}
			if (Columns.FindByUId(new Guid("afc54247-eb40-b67a-882f-2581f3570f07")) == null) {
				Columns.Add(CreateEventGroupIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateEventStreamIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("e0aab226-2b0a-263a-3629-b0f0d4349ea0"),
				Name = @"EventStreamId",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("4c7e6f2f-4e70-4eb0-973b-f07ac6073d28"),
				ModifiedInSchemaUId = new Guid("4c7e6f2f-4e70-4eb0-973b-f07ac6073d28"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected virtual EntitySchemaColumn CreateEventGroupIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("afc54247-eb40-b67a-882f-2581f3570f07"),
				Name = @"EventGroupId",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("4c7e6f2f-4e70-4eb0-973b-f07ac6073d28"),
				ModifiedInSchemaUId = new Guid("4c7e6f2f-4e70-4eb0-973b-f07ac6073d28"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysEventStoreKeys(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysEventStoreKeys_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysEventStoreKeysSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysEventStoreKeysSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4c7e6f2f-4e70-4eb0-973b-f07ac6073d28"));
		}

		#endregion

	}

	#endregion

	#region Class: SysEventStoreKeys

	/// <summary>
	/// Event store keys.
	/// </summary>
	public class SysEventStoreKeys : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysEventStoreKeys(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysEventStoreKeys";
		}

		public SysEventStoreKeys(SysEventStoreKeys source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Event stream.
		/// </summary>
		public string EventStreamId {
			get {
				return GetTypedColumnValue<string>("EventStreamId");
			}
			set {
				SetColumnValue("EventStreamId", value);
			}
		}

		/// <summary>
		/// Event group.
		/// </summary>
		public string EventGroupId {
			get {
				return GetTypedColumnValue<string>("EventGroupId");
			}
			set {
				SetColumnValue("EventGroupId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysEventStoreKeys_CrtBaseEventsProcess(UserConnection);
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
			return new SysEventStoreKeys(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysEventStoreKeys_CrtBaseEventsProcess

	/// <exclude/>
	public partial class SysEventStoreKeys_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysEventStoreKeys
	{

		public SysEventStoreKeys_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysEventStoreKeys_CrtBaseEventsProcess";
			SchemaUId = new Guid("4c7e6f2f-4e70-4eb0-973b-f07ac6073d28");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("4c7e6f2f-4e70-4eb0-973b-f07ac6073d28");
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

	#region Class: SysEventStoreKeys_CrtBaseEventsProcess

	/// <exclude/>
	public class SysEventStoreKeys_CrtBaseEventsProcess : SysEventStoreKeys_CrtBaseEventsProcess<SysEventStoreKeys>
	{

		public SysEventStoreKeys_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysEventStoreKeys_CrtBaseEventsProcess

	public partial class SysEventStoreKeys_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysEventStoreKeysEventsProcess

	/// <exclude/>
	public class SysEventStoreKeysEventsProcess : SysEventStoreKeys_CrtBaseEventsProcess
	{

		public SysEventStoreKeysEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

