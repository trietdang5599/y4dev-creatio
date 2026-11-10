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

	#region Class: SysEntityDeleteEventLogSchema

	/// <exclude/>
	public class SysEntityDeleteEventLogSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysEntityDeleteEventLogSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysEntityDeleteEventLogSchema(SysEntityDeleteEventLogSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysEntityDeleteEventLogSchema(SysEntityDeleteEventLogSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("41d3b425-4580-4e3f-ac7c-ccac03a5cc94");
			RealUId = new Guid("41d3b425-4580-4e3f-ac7c-ccac03a5cc94");
			Name = "SysEntityDeleteEventLog";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("b6a740c9-7e04-4faa-8b61-e7120bb23315");
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
			if (Columns.FindByUId(new Guid("e6c364c2-ff46-93f6-318f-b49cf13fd351")) == null) {
				Columns.Add(CreateOperationDateUTCColumn());
			}
			if (Columns.FindByUId(new Guid("5fcb72be-c538-7efa-41a2-238a6936325c")) == null) {
				Columns.Add(CreateRecordIdColumn());
			}
			if (Columns.FindByUId(new Guid("3e3630a9-07f8-6a54-c522-00f3b433a1f5")) == null) {
				Columns.Add(CreateEntitySchemaNameColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateOperationDateUTCColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("e6c364c2-ff46-93f6-318f-b49cf13fd351"),
				Name = @"OperationDateUTC",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("41d3b425-4580-4e3f-ac7c-ccac03a5cc94"),
				ModifiedInSchemaUId = new Guid("41d3b425-4580-4e3f-ac7c-ccac03a5cc94"),
				CreatedInPackageId = new Guid("b6a740c9-7e04-4faa-8b61-e7120bb23315"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"CurrentDateTime")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateRecordIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("5fcb72be-c538-7efa-41a2-238a6936325c"),
				Name = @"RecordId",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("41d3b425-4580-4e3f-ac7c-ccac03a5cc94"),
				ModifiedInSchemaUId = new Guid("41d3b425-4580-4e3f-ac7c-ccac03a5cc94"),
				CreatedInPackageId = new Guid("b6a740c9-7e04-4faa-8b61-e7120bb23315")
			};
		}

		protected virtual EntitySchemaColumn CreateEntitySchemaNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("3e3630a9-07f8-6a54-c522-00f3b433a1f5"),
				Name = @"EntitySchemaName",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("41d3b425-4580-4e3f-ac7c-ccac03a5cc94"),
				ModifiedInSchemaUId = new Guid("41d3b425-4580-4e3f-ac7c-ccac03a5cc94"),
				CreatedInPackageId = new Guid("b6a740c9-7e04-4faa-8b61-e7120bb23315")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysEntityDeleteEventLog(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysEntityDeleteEventLog_CrtEntityEventLogEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysEntityDeleteEventLogSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysEntityDeleteEventLogSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("41d3b425-4580-4e3f-ac7c-ccac03a5cc94"));
		}

		#endregion

	}

	#endregion

	#region Class: SysEntityDeleteEventLog

	/// <summary>
	/// Entity delete event log.
	/// </summary>
	public class SysEntityDeleteEventLog : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysEntityDeleteEventLog(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysEntityDeleteEventLog";
		}

		public SysEntityDeleteEventLog(SysEntityDeleteEventLog source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Operation date UTC.
		/// </summary>
		public DateTime OperationDateUTC {
			get {
				return GetTypedColumnValue<DateTime>("OperationDateUTC");
			}
			set {
				SetColumnValue("OperationDateUTC", value);
			}
		}

		/// <summary>
		/// Record id.
		/// </summary>
		public Guid RecordId {
			get {
				return GetTypedColumnValue<Guid>("RecordId");
			}
			set {
				SetColumnValue("RecordId", value);
			}
		}

		/// <summary>
		/// Entity schema name.
		/// </summary>
		public string EntitySchemaName {
			get {
				return GetTypedColumnValue<string>("EntitySchemaName");
			}
			set {
				SetColumnValue("EntitySchemaName", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysEntityDeleteEventLog_CrtEntityEventLogEventsProcess(UserConnection);
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
			return new SysEntityDeleteEventLog(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysEntityDeleteEventLog_CrtEntityEventLogEventsProcess

	/// <exclude/>
	public partial class SysEntityDeleteEventLog_CrtEntityEventLogEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysEntityDeleteEventLog
	{

		public SysEntityDeleteEventLog_CrtEntityEventLogEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysEntityDeleteEventLog_CrtEntityEventLogEventsProcess";
			SchemaUId = new Guid("41d3b425-4580-4e3f-ac7c-ccac03a5cc94");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("41d3b425-4580-4e3f-ac7c-ccac03a5cc94");
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

	#region Class: SysEntityDeleteEventLog_CrtEntityEventLogEventsProcess

	/// <exclude/>
	public class SysEntityDeleteEventLog_CrtEntityEventLogEventsProcess : SysEntityDeleteEventLog_CrtEntityEventLogEventsProcess<SysEntityDeleteEventLog>
	{

		public SysEntityDeleteEventLog_CrtEntityEventLogEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysEntityDeleteEventLog_CrtEntityEventLogEventsProcess

	public partial class SysEntityDeleteEventLog_CrtEntityEventLogEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysEntityDeleteEventLogEventsProcess

	/// <exclude/>
	public class SysEntityDeleteEventLogEventsProcess : SysEntityDeleteEventLog_CrtEntityEventLogEventsProcess
	{

		public SysEntityDeleteEventLogEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

