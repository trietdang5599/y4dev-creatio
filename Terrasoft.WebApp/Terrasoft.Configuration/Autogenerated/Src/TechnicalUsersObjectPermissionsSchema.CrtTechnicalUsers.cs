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

	#region Class: TechnicalUsersObjectPermissionsSchema

	/// <exclude/>
	[IsVirtual]
	public class TechnicalUsersObjectPermissionsSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public TechnicalUsersObjectPermissionsSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public TechnicalUsersObjectPermissionsSchema(TechnicalUsersObjectPermissionsSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public TechnicalUsersObjectPermissionsSchema(TechnicalUsersObjectPermissionsSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("cf2f4bd9-91b5-4ac2-a7eb-0207682fbaab");
			RealUId = new Guid("cf2f4bd9-91b5-4ac2-a7eb-0207682fbaab");
			Name = "TechnicalUsersObjectPermissions";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("ebffa783-6cf4-479d-971b-6407c9c52362");
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
			if (Columns.FindByUId(new Guid("26cc22a2-6c48-79b8-446a-917c6a62bc35")) == null) {
				Columns.Add(CreateTechnicalUserIdColumn());
			}
			if (Columns.FindByUId(new Guid("e90d525d-305b-8d93-df99-6f383b959210")) == null) {
				Columns.Add(CreateObjectPermissionsUrlColumn());
			}
			if (Columns.FindByUId(new Guid("a8da8b51-7c5b-18a4-477f-aab8b27afd4d")) == null) {
				Columns.Add(CreateObjectColumn());
			}
			if (Columns.FindByUId(new Guid("77454bc0-280a-5518-9018-5feb5902fd55")) == null) {
				Columns.Add(CreateCanReadColumn());
			}
			if (Columns.FindByUId(new Guid("86abea74-73f8-f126-fc69-2ef321f45ff3")) == null) {
				Columns.Add(CreateCanEditColumn());
			}
			if (Columns.FindByUId(new Guid("24b589be-508f-2a86-6505-2bd95a6f9d09")) == null) {
				Columns.Add(CreateCanDeleteColumn());
			}
			if (Columns.FindByUId(new Guid("ad7ec6ff-c0e9-6150-cf8f-04a92e50cb20")) == null) {
				Columns.Add(CreateCanAppendColumn());
			}
			if (Columns.FindByUId(new Guid("ad3cea1a-f170-cf02-f996-155a18e9ae6a")) == null) {
				Columns.Add(CreateAdministratedByRecordsColumn());
			}
			if (Columns.FindByUId(new Guid("687db031-d606-674c-a855-c5c7da9c7854")) == null) {
				Columns.Add(CreateAdministratedByColumnsColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateTechnicalUserIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("26cc22a2-6c48-79b8-446a-917c6a62bc35"),
				Name = @"TechnicalUserId",
				CreatedInSchemaUId = new Guid("cf2f4bd9-91b5-4ac2-a7eb-0207682fbaab"),
				ModifiedInSchemaUId = new Guid("cf2f4bd9-91b5-4ac2-a7eb-0207682fbaab"),
				CreatedInPackageId = new Guid("ebffa783-6cf4-479d-971b-6407c9c52362")
			};
		}

		protected virtual EntitySchemaColumn CreateObjectPermissionsUrlColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("e90d525d-305b-8d93-df99-6f383b959210"),
				Name = @"ObjectPermissionsUrl",
				CreatedInSchemaUId = new Guid("cf2f4bd9-91b5-4ac2-a7eb-0207682fbaab"),
				ModifiedInSchemaUId = new Guid("cf2f4bd9-91b5-4ac2-a7eb-0207682fbaab"),
				CreatedInPackageId = new Guid("ebffa783-6cf4-479d-971b-6407c9c52362")
			};
		}

		protected virtual EntitySchemaColumn CreateObjectColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("a8da8b51-7c5b-18a4-477f-aab8b27afd4d"),
				Name = @"Object",
				CreatedInSchemaUId = new Guid("cf2f4bd9-91b5-4ac2-a7eb-0207682fbaab"),
				ModifiedInSchemaUId = new Guid("cf2f4bd9-91b5-4ac2-a7eb-0207682fbaab"),
				CreatedInPackageId = new Guid("ebffa783-6cf4-479d-971b-6407c9c52362")
			};
		}

		protected virtual EntitySchemaColumn CreateCanReadColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("77454bc0-280a-5518-9018-5feb5902fd55"),
				Name = @"CanRead",
				CreatedInSchemaUId = new Guid("cf2f4bd9-91b5-4ac2-a7eb-0207682fbaab"),
				ModifiedInSchemaUId = new Guid("cf2f4bd9-91b5-4ac2-a7eb-0207682fbaab"),
				CreatedInPackageId = new Guid("ebffa783-6cf4-479d-971b-6407c9c52362")
			};
		}

		protected virtual EntitySchemaColumn CreateCanEditColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("86abea74-73f8-f126-fc69-2ef321f45ff3"),
				Name = @"CanEdit",
				CreatedInSchemaUId = new Guid("cf2f4bd9-91b5-4ac2-a7eb-0207682fbaab"),
				ModifiedInSchemaUId = new Guid("cf2f4bd9-91b5-4ac2-a7eb-0207682fbaab"),
				CreatedInPackageId = new Guid("ebffa783-6cf4-479d-971b-6407c9c52362")
			};
		}

		protected virtual EntitySchemaColumn CreateCanDeleteColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("24b589be-508f-2a86-6505-2bd95a6f9d09"),
				Name = @"CanDelete",
				CreatedInSchemaUId = new Guid("cf2f4bd9-91b5-4ac2-a7eb-0207682fbaab"),
				ModifiedInSchemaUId = new Guid("cf2f4bd9-91b5-4ac2-a7eb-0207682fbaab"),
				CreatedInPackageId = new Guid("ebffa783-6cf4-479d-971b-6407c9c52362")
			};
		}

		protected virtual EntitySchemaColumn CreateCanAppendColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("ad7ec6ff-c0e9-6150-cf8f-04a92e50cb20"),
				Name = @"CanAppend",
				CreatedInSchemaUId = new Guid("cf2f4bd9-91b5-4ac2-a7eb-0207682fbaab"),
				ModifiedInSchemaUId = new Guid("cf2f4bd9-91b5-4ac2-a7eb-0207682fbaab"),
				CreatedInPackageId = new Guid("ebffa783-6cf4-479d-971b-6407c9c52362")
			};
		}

		protected virtual EntitySchemaColumn CreateAdministratedByRecordsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("ad3cea1a-f170-cf02-f996-155a18e9ae6a"),
				Name = @"AdministratedByRecords",
				CreatedInSchemaUId = new Guid("cf2f4bd9-91b5-4ac2-a7eb-0207682fbaab"),
				ModifiedInSchemaUId = new Guid("cf2f4bd9-91b5-4ac2-a7eb-0207682fbaab"),
				CreatedInPackageId = new Guid("ebffa783-6cf4-479d-971b-6407c9c52362")
			};
		}

		protected virtual EntitySchemaColumn CreateAdministratedByColumnsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("687db031-d606-674c-a855-c5c7da9c7854"),
				Name = @"AdministratedByColumns",
				CreatedInSchemaUId = new Guid("cf2f4bd9-91b5-4ac2-a7eb-0207682fbaab"),
				ModifiedInSchemaUId = new Guid("cf2f4bd9-91b5-4ac2-a7eb-0207682fbaab"),
				CreatedInPackageId = new Guid("ebffa783-6cf4-479d-971b-6407c9c52362")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new TechnicalUsersObjectPermissions(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new TechnicalUsersObjectPermissions_CrtTechnicalUsersEventsProcess(userConnection);
		}

		public override object Clone() {
			return new TechnicalUsersObjectPermissionsSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new TechnicalUsersObjectPermissionsSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("cf2f4bd9-91b5-4ac2-a7eb-0207682fbaab"));
		}

		#endregion

	}

	#endregion

	#region Class: TechnicalUsersObjectPermissions

	/// <summary>
	/// Technical users object permissions.
	/// </summary>
	public class TechnicalUsersObjectPermissions : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public TechnicalUsersObjectPermissions(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "TechnicalUsersObjectPermissions";
		}

		public TechnicalUsersObjectPermissions(TechnicalUsersObjectPermissions source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Technical user identifier.
		/// </summary>
		public Guid TechnicalUserId {
			get {
				return GetTypedColumnValue<Guid>("TechnicalUserId");
			}
			set {
				SetColumnValue("TechnicalUserId", value);
			}
		}

		/// <summary>
		/// Object permissions URL.
		/// </summary>
		public string ObjectPermissionsUrl {
			get {
				return GetTypedColumnValue<string>("ObjectPermissionsUrl");
			}
			set {
				SetColumnValue("ObjectPermissionsUrl", value);
			}
		}

		/// <summary>
		/// Object.
		/// </summary>
		public string Object {
			get {
				return GetTypedColumnValue<string>("Object");
			}
			set {
				SetColumnValue("Object", value);
			}
		}

		/// <summary>
		/// Read.
		/// </summary>
		public bool CanRead {
			get {
				return GetTypedColumnValue<bool>("CanRead");
			}
			set {
				SetColumnValue("CanRead", value);
			}
		}

		/// <summary>
		/// Edit.
		/// </summary>
		public bool CanEdit {
			get {
				return GetTypedColumnValue<bool>("CanEdit");
			}
			set {
				SetColumnValue("CanEdit", value);
			}
		}

		/// <summary>
		/// Delete.
		/// </summary>
		public bool CanDelete {
			get {
				return GetTypedColumnValue<bool>("CanDelete");
			}
			set {
				SetColumnValue("CanDelete", value);
			}
		}

		/// <summary>
		/// Create.
		/// </summary>
		public bool CanAppend {
			get {
				return GetTypedColumnValue<bool>("CanAppend");
			}
			set {
				SetColumnValue("CanAppend", value);
			}
		}

		/// <summary>
		/// Managed by records.
		/// </summary>
		public bool AdministratedByRecords {
			get {
				return GetTypedColumnValue<bool>("AdministratedByRecords");
			}
			set {
				SetColumnValue("AdministratedByRecords", value);
			}
		}

		/// <summary>
		/// Managed by column.
		/// </summary>
		public bool AdministratedByColumns {
			get {
				return GetTypedColumnValue<bool>("AdministratedByColumns");
			}
			set {
				SetColumnValue("AdministratedByColumns", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new TechnicalUsersObjectPermissions_CrtTechnicalUsersEventsProcess(UserConnection);
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
			return new TechnicalUsersObjectPermissions(this);
		}

		#endregion

	}

	#endregion

	#region Class: TechnicalUsersObjectPermissions_CrtTechnicalUsersEventsProcess

	/// <exclude/>
	public partial class TechnicalUsersObjectPermissions_CrtTechnicalUsersEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : TechnicalUsersObjectPermissions
	{

		public TechnicalUsersObjectPermissions_CrtTechnicalUsersEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "TechnicalUsersObjectPermissions_CrtTechnicalUsersEventsProcess";
			SchemaUId = new Guid("cf2f4bd9-91b5-4ac2-a7eb-0207682fbaab");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("cf2f4bd9-91b5-4ac2-a7eb-0207682fbaab");
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

	#region Class: TechnicalUsersObjectPermissions_CrtTechnicalUsersEventsProcess

	/// <exclude/>
	public class TechnicalUsersObjectPermissions_CrtTechnicalUsersEventsProcess : TechnicalUsersObjectPermissions_CrtTechnicalUsersEventsProcess<TechnicalUsersObjectPermissions>
	{

		public TechnicalUsersObjectPermissions_CrtTechnicalUsersEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: TechnicalUsersObjectPermissions_CrtTechnicalUsersEventsProcess

	public partial class TechnicalUsersObjectPermissions_CrtTechnicalUsersEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: TechnicalUsersObjectPermissionsEventsProcess

	/// <exclude/>
	public class TechnicalUsersObjectPermissionsEventsProcess : TechnicalUsersObjectPermissions_CrtTechnicalUsersEventsProcess
	{

		public TechnicalUsersObjectPermissionsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

