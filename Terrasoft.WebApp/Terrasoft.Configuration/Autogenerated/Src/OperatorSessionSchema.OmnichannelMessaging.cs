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

	#region Class: OperatorSessionSchema

	/// <exclude/>
	public class OperatorSessionSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public OperatorSessionSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OperatorSessionSchema(OperatorSessionSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OperatorSessionSchema(OperatorSessionSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIX_OpSes_EndD_StartD_DESCIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("13186463-ee4f-4e9a-acbb-12791b3a6235");
			index.Name = "IX_OpSes_EndD_StartD_DESC";
			index.CreatedInSchemaUId = new Guid("ca498878-a6a0-4238-b63a-d9344c030215");
			index.ModifiedInSchemaUId = new Guid("ca498878-a6a0-4238-b63a-d9344c030215");
			index.CreatedInPackageId = new Guid("08afff10-3d0c-4f3d-b6a0-28a42952a988");
			EntitySchemaIndexColumn sessionEndDateIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("c467eba7-d59f-719f-641c-d405986493b6"),
				ColumnUId = new Guid("fa0dac61-be9c-48bf-8596-d0c1ce84a21f"),
				CreatedInSchemaUId = new Guid("ca498878-a6a0-4238-b63a-d9344c030215"),
				ModifiedInSchemaUId = new Guid("ca498878-a6a0-4238-b63a-d9344c030215"),
				CreatedInPackageId = new Guid("08afff10-3d0c-4f3d-b6a0-28a42952a988"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(sessionEndDateIndexColumn);
			EntitySchemaIndexColumn sessionStartDateIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("3d1cdb48-917c-9766-3eec-e0c0d7b01fdb"),
				ColumnUId = new Guid("6121486e-14e7-4557-9f86-23694d52a52d"),
				CreatedInSchemaUId = new Guid("ca498878-a6a0-4238-b63a-d9344c030215"),
				ModifiedInSchemaUId = new Guid("ca498878-a6a0-4238-b63a-d9344c030215"),
				CreatedInPackageId = new Guid("08afff10-3d0c-4f3d-b6a0-28a42952a988"),
				OrderDirection = OrderDirectionStrict.Descending
			};
			index.Columns.Add(sessionStartDateIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ca498878-a6a0-4238-b63a-d9344c030215");
			RealUId = new Guid("ca498878-a6a0-4238-b63a-d9344c030215");
			Name = "OperatorSession";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("a8569787-b88e-4075-aa85-f8031253bd51");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("65590713-7154-4fad-8ed8-0ec0afa6b00f")) == null) {
				Columns.Add(CreateSysUserColumn());
			}
			if (Columns.FindByUId(new Guid("6121486e-14e7-4557-9f86-23694d52a52d")) == null) {
				Columns.Add(CreateSessionStartDateColumn());
			}
			if (Columns.FindByUId(new Guid("fa0dac61-be9c-48bf-8596-d0c1ce84a21f")) == null) {
				Columns.Add(CreateSessionEndDateColumn());
			}
			if (Columns.FindByUId(new Guid("2a9aaf1b-83d5-43bb-b37b-4da2a7329905")) == null) {
				Columns.Add(CreateOperatorStateColumn());
			}
			if (Columns.FindByUId(new Guid("abc55009-7e98-4fd6-bd64-b7e673a743af")) == null) {
				Columns.Add(CreateDurationColumn());
			}
			if (Columns.FindByUId(new Guid("4ebfa872-8b2e-1aab-d4a8-72e781426410")) == null) {
				Columns.Add(CreateLastActivityDateColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysUserColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("65590713-7154-4fad-8ed8-0ec0afa6b00f"),
				Name = @"SysUser",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("ca498878-a6a0-4238-b63a-d9344c030215"),
				ModifiedInSchemaUId = new Guid("ca498878-a6a0-4238-b63a-d9344c030215"),
				CreatedInPackageId = new Guid("ad806488-98f4-482b-bb58-5e43a394961e")
			};
		}

		protected virtual EntitySchemaColumn CreateSessionStartDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("6121486e-14e7-4557-9f86-23694d52a52d"),
				Name = @"SessionStartDate",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("ca498878-a6a0-4238-b63a-d9344c030215"),
				ModifiedInSchemaUId = new Guid("ca498878-a6a0-4238-b63a-d9344c030215"),
				CreatedInPackageId = new Guid("ad806488-98f4-482b-bb58-5e43a394961e")
			};
		}

		protected virtual EntitySchemaColumn CreateSessionEndDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("fa0dac61-be9c-48bf-8596-d0c1ce84a21f"),
				Name = @"SessionEndDate",
				CreatedInSchemaUId = new Guid("ca498878-a6a0-4238-b63a-d9344c030215"),
				ModifiedInSchemaUId = new Guid("ca498878-a6a0-4238-b63a-d9344c030215"),
				CreatedInPackageId = new Guid("ad806488-98f4-482b-bb58-5e43a394961e")
			};
		}

		protected virtual EntitySchemaColumn CreateOperatorStateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("2a9aaf1b-83d5-43bb-b37b-4da2a7329905"),
				Name = @"OperatorState",
				ReferenceSchemaUId = new Guid("77c870a3-c8d9-41a0-abb2-60ddb7fcd9f7"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ca498878-a6a0-4238-b63a-d9344c030215"),
				ModifiedInSchemaUId = new Guid("ca498878-a6a0-4238-b63a-d9344c030215"),
				CreatedInPackageId = new Guid("ad806488-98f4-482b-bb58-5e43a394961e")
			};
		}

		protected virtual EntitySchemaColumn CreateDurationColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("abc55009-7e98-4fd6-bd64-b7e673a743af"),
				Name = @"Duration",
				CreatedInSchemaUId = new Guid("ca498878-a6a0-4238-b63a-d9344c030215"),
				ModifiedInSchemaUId = new Guid("ca498878-a6a0-4238-b63a-d9344c030215"),
				CreatedInPackageId = new Guid("ad806488-98f4-482b-bb58-5e43a394961e")
			};
		}

		protected virtual EntitySchemaColumn CreateLastActivityDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("4ebfa872-8b2e-1aab-d4a8-72e781426410"),
				Name = @"LastActivityDate",
				CreatedInSchemaUId = new Guid("ca498878-a6a0-4238-b63a-d9344c030215"),
				ModifiedInSchemaUId = new Guid("ca498878-a6a0-4238-b63a-d9344c030215"),
				CreatedInPackageId = new Guid("08afff10-3d0c-4f3d-b6a0-28a42952a988")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIX_OpSes_EndD_StartD_DESCIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new OperatorSession(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OperatorSession_OmnichannelMessagingEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OperatorSessionSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OperatorSessionSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ca498878-a6a0-4238-b63a-d9344c030215"));
		}

		#endregion

	}

	#endregion

	#region Class: OperatorSession

	/// <summary>
	/// Operator session.
	/// </summary>
	/// <remarks>
	/// Tracks agent sessions by recording availability and activity status for chat processing to monitor performance.
	/// </remarks>
	public class OperatorSession : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public OperatorSession(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OperatorSession";
		}

		public OperatorSession(OperatorSession source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SysUserId {
			get {
				return GetTypedColumnValue<Guid>("SysUserId");
			}
			set {
				SetColumnValue("SysUserId", value);
				_sysUser = null;
			}
		}

		/// <exclude/>
		public string SysUserName {
			get {
				return GetTypedColumnValue<string>("SysUserName");
			}
			set {
				SetColumnValue("SysUserName", value);
				if (_sysUser != null) {
					_sysUser.Name = value;
				}
			}
		}

		private SysAdminUnit _sysUser;
		/// <summary>
		/// User.
		/// </summary>
		public SysAdminUnit SysUser {
			get {
				return _sysUser ??
					(_sysUser = LookupColumnEntities.GetEntity("SysUser") as SysAdminUnit);
			}
		}

		/// <summary>
		/// Session start.
		/// </summary>
		public DateTime SessionStartDate {
			get {
				return GetTypedColumnValue<DateTime>("SessionStartDate");
			}
			set {
				SetColumnValue("SessionStartDate", value);
			}
		}

		/// <summary>
		/// Session end.
		/// </summary>
		public DateTime SessionEndDate {
			get {
				return GetTypedColumnValue<DateTime>("SessionEndDate");
			}
			set {
				SetColumnValue("SessionEndDate", value);
			}
		}

		/// <exclude/>
		public Guid OperatorStateId {
			get {
				return GetTypedColumnValue<Guid>("OperatorStateId");
			}
			set {
				SetColumnValue("OperatorStateId", value);
				_operatorState = null;
			}
		}

		/// <exclude/>
		public string OperatorStateName {
			get {
				return GetTypedColumnValue<string>("OperatorStateName");
			}
			set {
				SetColumnValue("OperatorStateName", value);
				if (_operatorState != null) {
					_operatorState.Name = value;
				}
			}
		}

		private OperatorState _operatorState;
		/// <summary>
		/// Operator's current state.
		/// </summary>
		public OperatorState OperatorState {
			get {
				return _operatorState ??
					(_operatorState = LookupColumnEntities.GetEntity("OperatorState") as OperatorState);
			}
		}

		/// <summary>
		/// Duration, min.
		/// </summary>
		public int Duration {
			get {
				return GetTypedColumnValue<int>("Duration");
			}
			set {
				SetColumnValue("Duration", value);
			}
		}

		/// <summary>
		/// Last activity date.
		/// </summary>
		public DateTime LastActivityDate {
			get {
				return GetTypedColumnValue<DateTime>("LastActivityDate");
			}
			set {
				SetColumnValue("LastActivityDate", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OperatorSession_OmnichannelMessagingEventsProcess(UserConnection);
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
			return new OperatorSession(this);
		}

		#endregion

	}

	#endregion

	#region Class: OperatorSession_OmnichannelMessagingEventsProcess

	/// <exclude/>
	public partial class OperatorSession_OmnichannelMessagingEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : OperatorSession
	{

		public OperatorSession_OmnichannelMessagingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OperatorSession_OmnichannelMessagingEventsProcess";
			SchemaUId = new Guid("ca498878-a6a0-4238-b63a-d9344c030215");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ca498878-a6a0-4238-b63a-d9344c030215");
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

	#region Class: OperatorSession_OmnichannelMessagingEventsProcess

	/// <exclude/>
	public class OperatorSession_OmnichannelMessagingEventsProcess : OperatorSession_OmnichannelMessagingEventsProcess<OperatorSession>
	{

		public OperatorSession_OmnichannelMessagingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OperatorSession_OmnichannelMessagingEventsProcess

	public partial class OperatorSession_OmnichannelMessagingEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: OperatorSessionEventsProcess

	/// <exclude/>
	public class OperatorSessionEventsProcess : OperatorSession_OmnichannelMessagingEventsProcess
	{

		public OperatorSessionEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

