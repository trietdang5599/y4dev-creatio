namespace Terrasoft.Configuration
{

	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.IO;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;

	#region Class: VwSysAdminOperationGranteeSchema

	/// <exclude/>
	public class VwSysAdminOperationGranteeSchema : Terrasoft.Core.Entities.EntitySchema
	{

		#region Constructors: Public

		public VwSysAdminOperationGranteeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwSysAdminOperationGranteeSchema(VwSysAdminOperationGranteeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwSysAdminOperationGranteeSchema(VwSysAdminOperationGranteeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("01b6a706-8496-4038-b5df-f8aae1979426");
			RealUId = new Guid("01b6a706-8496-4038-b5df-f8aae1979426");
			Name = "VwSysAdminOperationGrantee";
			ParentSchemaUId = new Guid("1b56b061-4e91-4974-9038-df8340e534f2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("3d9857ab-9071-4ca0-a609-9be5644e9279");
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

		protected override void InitializePrimaryColumn() {
			base.InitializePrimaryColumn();
			PrimaryColumn = CreateIdColumn();
			if (Columns.FindByUId(PrimaryColumn.UId) == null) {
				Columns.Add(PrimaryColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("427d4e42-eb66-e7eb-c51f-bef524f301aa")) == null) {
				Columns.Add(CreateCanExecuteColumn());
			}
			if (Columns.FindByUId(new Guid("86909788-ace2-8cb7-b6f0-a1f6b2573c88")) == null) {
				Columns.Add(CreateSysAdminOperationColumn());
			}
			if (Columns.FindByUId(new Guid("31cea678-a885-4a3c-f117-b75dbbc2cb27")) == null) {
				Columns.Add(CreateSysAdminUnitColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCanExecuteColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("427d4e42-eb66-e7eb-c51f-bef524f301aa"),
				Name = @"CanExecute",
				CreatedInSchemaUId = new Guid("01b6a706-8496-4038-b5df-f8aae1979426"),
				ModifiedInSchemaUId = new Guid("01b6a706-8496-4038-b5df-f8aae1979426"),
				CreatedInPackageId = new Guid("3d9857ab-9071-4ca0-a609-9be5644e9279")
			};
		}

		protected virtual EntitySchemaColumn CreateSysAdminOperationColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("86909788-ace2-8cb7-b6f0-a1f6b2573c88"),
				Name = @"SysAdminOperation",
				ReferenceSchemaUId = new Guid("c8fd2fd0-1f44-48c7-84e4-045250b9a638"),
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("01b6a706-8496-4038-b5df-f8aae1979426"),
				ModifiedInSchemaUId = new Guid("01b6a706-8496-4038-b5df-f8aae1979426"),
				CreatedInPackageId = new Guid("3d9857ab-9071-4ca0-a609-9be5644e9279"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateSysAdminUnitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("31cea678-a885-4a3c-f117-b75dbbc2cb27"),
				Name = @"SysAdminUnit",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("01b6a706-8496-4038-b5df-f8aae1979426"),
				ModifiedInSchemaUId = new Guid("01b6a706-8496-4038-b5df-f8aae1979426"),
				CreatedInPackageId = new Guid("3d9857ab-9071-4ca0-a609-9be5644e9279"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("b015c8eb-33ea-f191-9123-f4079b0f2194"),
				Name = @"Id",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("01b6a706-8496-4038-b5df-f8aae1979426"),
				ModifiedInSchemaUId = new Guid("01b6a706-8496-4038-b5df-f8aae1979426"),
				CreatedInPackageId = new Guid("3d9857ab-9071-4ca0-a609-9be5644e9279")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwSysAdminOperationGrantee(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwSysAdminOperationGrantee_CrtTechnicalUsersEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwSysAdminOperationGranteeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwSysAdminOperationGranteeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("01b6a706-8496-4038-b5df-f8aae1979426"));
		}

		#endregion

	}

	#endregion

	#region Class: VwSysAdminOperationGrantee

	/// <summary>
	/// Permission granted to users.
	/// </summary>
	public class VwSysAdminOperationGrantee : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public VwSysAdminOperationGrantee(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwSysAdminOperationGrantee";
		}

		public VwSysAdminOperationGrantee(VwSysAdminOperationGrantee source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Access level.
		/// </summary>
		public bool CanExecute {
			get {
				return GetTypedColumnValue<bool>("CanExecute");
			}
			set {
				SetColumnValue("CanExecute", value);
			}
		}

		/// <exclude/>
		public Guid SysAdminOperationId {
			get {
				return GetTypedColumnValue<Guid>("SysAdminOperationId");
			}
			set {
				SetColumnValue("SysAdminOperationId", value);
				_sysAdminOperation = null;
			}
		}

		/// <exclude/>
		public string SysAdminOperationName {
			get {
				return GetTypedColumnValue<string>("SysAdminOperationName");
			}
			set {
				SetColumnValue("SysAdminOperationName", value);
				if (_sysAdminOperation != null) {
					_sysAdminOperation.Name = value;
				}
			}
		}

		private SysAdminOperation _sysAdminOperation;
		/// <summary>
		/// Operation.
		/// </summary>
		public SysAdminOperation SysAdminOperation {
			get {
				return _sysAdminOperation ??
					(_sysAdminOperation = LookupColumnEntities.GetEntity("SysAdminOperation") as SysAdminOperation);
			}
		}

		/// <exclude/>
		public Guid SysAdminUnitId {
			get {
				return GetTypedColumnValue<Guid>("SysAdminUnitId");
			}
			set {
				SetColumnValue("SysAdminUnitId", value);
				_sysAdminUnit = null;
			}
		}

		/// <exclude/>
		public string SysAdminUnitName {
			get {
				return GetTypedColumnValue<string>("SysAdminUnitName");
			}
			set {
				SetColumnValue("SysAdminUnitName", value);
				if (_sysAdminUnit != null) {
					_sysAdminUnit.Name = value;
				}
			}
		}

		private SysAdminUnit _sysAdminUnit;
		/// <summary>
		/// User.
		/// </summary>
		public SysAdminUnit SysAdminUnit {
			get {
				return _sysAdminUnit ??
					(_sysAdminUnit = LookupColumnEntities.GetEntity("SysAdminUnit") as SysAdminUnit);
			}
		}

		/// <summary>
		/// Id.
		/// </summary>
		public Guid Id {
			get {
				return GetTypedColumnValue<Guid>("Id");
			}
			set {
				SetColumnValue("Id", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwSysAdminOperationGrantee_CrtTechnicalUsersEventsProcess(UserConnection);
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
			return new VwSysAdminOperationGrantee(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwSysAdminOperationGrantee_CrtTechnicalUsersEventsProcess

	/// <exclude/>
	public partial class VwSysAdminOperationGrantee_CrtTechnicalUsersEventsProcess<TEntity> : Terrasoft.Core.Process.EmbeddedProcess where TEntity : VwSysAdminOperationGrantee
	{

		private TEntity _entity;
		public TEntity Entity {
			get {
				return _entity;
			}
			set {
				_entity = value;
			}
		}

		public VwSysAdminOperationGrantee_CrtTechnicalUsersEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwSysAdminOperationGrantee_CrtTechnicalUsersEventsProcess";
			SchemaUId = new Guid("01b6a706-8496-4038-b5df-f8aae1979426");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("01b6a706-8496-4038-b5df-f8aae1979426");
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

	#region Class: VwSysAdminOperationGrantee_CrtTechnicalUsersEventsProcess

	/// <exclude/>
	public class VwSysAdminOperationGrantee_CrtTechnicalUsersEventsProcess : VwSysAdminOperationGrantee_CrtTechnicalUsersEventsProcess<VwSysAdminOperationGrantee>
	{

		public VwSysAdminOperationGrantee_CrtTechnicalUsersEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwSysAdminOperationGrantee_CrtTechnicalUsersEventsProcess

	public partial class VwSysAdminOperationGrantee_CrtTechnicalUsersEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwSysAdminOperationGranteeEventsProcess

	/// <exclude/>
	public class VwSysAdminOperationGranteeEventsProcess : VwSysAdminOperationGrantee_CrtTechnicalUsersEventsProcess
	{

		public VwSysAdminOperationGranteeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

