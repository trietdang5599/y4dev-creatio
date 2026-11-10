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

	#region Class: SysEntityRightByAdminOperationSchema

	/// <exclude/>
	public class SysEntityRightByAdminOperationSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysEntityRightByAdminOperationSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysEntityRightByAdminOperationSchema(SysEntityRightByAdminOperationSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysEntityRightByAdminOperationSchema(SysEntityRightByAdminOperationSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("6a72cf57-dacf-489d-ab70-2d9d1d3a9f55");
			RealUId = new Guid("6a72cf57-dacf-489d-ab70-2d9d1d3a9f55");
			Name = "SysEntityRightByAdminOperation";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = false;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("68e7c983-ac16-001c-2120-9e829496fe90")) == null) {
				Columns.Add(CreateSysSchemaColumn());
			}
			if (Columns.FindByUId(new Guid("b6f20d5f-0bd8-1f79-dc39-420716635d0f")) == null) {
				Columns.Add(CreateSysAdminOperationColumn());
			}
			if (Columns.FindByUId(new Guid("2b893048-dbc9-6c6b-8707-8bd090949790")) == null) {
				Columns.Add(CreateCanReadColumn());
			}
			if (Columns.FindByUId(new Guid("c1c542fe-acd3-6f84-faa9-70c643744f4b")) == null) {
				Columns.Add(CreateCanEditColumn());
			}
			if (Columns.FindByUId(new Guid("a8a8d4f1-536b-de56-b645-cfacaf96861e")) == null) {
				Columns.Add(CreateCanDeleteColumn());
			}
			if (Columns.FindByUId(new Guid("66d6e29a-bf0c-7157-afa4-ccae33dd8ec9")) == null) {
				Columns.Add(CreateCanAppendColumn());
			}
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.IsIndexed = false;
			column.ModifiedInSchemaUId = new Guid("6a72cf57-dacf-489d-ab70-2d9d1d3a9f55");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.IsIndexed = false;
			column.ModifiedInSchemaUId = new Guid("6a72cf57-dacf-489d-ab70-2d9d1d3a9f55");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.IsIndexed = false;
			column.ModifiedInSchemaUId = new Guid("6a72cf57-dacf-489d-ab70-2d9d1d3a9f55");
			return column;
		}

		protected virtual EntitySchemaColumn CreateSysSchemaColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("68e7c983-ac16-001c-2120-9e829496fe90"),
				Name = @"SysSchema",
				ReferenceSchemaUId = new Guid("c82db13a-7f77-4085-b3ef-91c5420fd417"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsWeakReference = true,
				CreatedInSchemaUId = new Guid("6a72cf57-dacf-489d-ab70-2d9d1d3a9f55"),
				ModifiedInSchemaUId = new Guid("6a72cf57-dacf-489d-ab70-2d9d1d3a9f55"),
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723")
			};
		}

		protected virtual EntitySchemaColumn CreateSysAdminOperationColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("b6f20d5f-0bd8-1f79-dc39-420716635d0f"),
				Name = @"SysAdminOperation",
				ReferenceSchemaUId = new Guid("c8fd2fd0-1f44-48c7-84e4-045250b9a638"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("6a72cf57-dacf-489d-ab70-2d9d1d3a9f55"),
				ModifiedInSchemaUId = new Guid("6a72cf57-dacf-489d-ab70-2d9d1d3a9f55"),
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateCanReadColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("2b893048-dbc9-6c6b-8707-8bd090949790"),
				Name = @"CanRead",
				CreatedInSchemaUId = new Guid("6a72cf57-dacf-489d-ab70-2d9d1d3a9f55"),
				ModifiedInSchemaUId = new Guid("6a72cf57-dacf-489d-ab70-2d9d1d3a9f55"),
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723")
			};
		}

		protected virtual EntitySchemaColumn CreateCanEditColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("c1c542fe-acd3-6f84-faa9-70c643744f4b"),
				Name = @"CanEdit",
				CreatedInSchemaUId = new Guid("6a72cf57-dacf-489d-ab70-2d9d1d3a9f55"),
				ModifiedInSchemaUId = new Guid("6a72cf57-dacf-489d-ab70-2d9d1d3a9f55"),
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723")
			};
		}

		protected virtual EntitySchemaColumn CreateCanDeleteColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("a8a8d4f1-536b-de56-b645-cfacaf96861e"),
				Name = @"CanDelete",
				CreatedInSchemaUId = new Guid("6a72cf57-dacf-489d-ab70-2d9d1d3a9f55"),
				ModifiedInSchemaUId = new Guid("6a72cf57-dacf-489d-ab70-2d9d1d3a9f55"),
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723")
			};
		}

		protected virtual EntitySchemaColumn CreateCanAppendColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("66d6e29a-bf0c-7157-afa4-ccae33dd8ec9"),
				Name = @"CanAppend",
				CreatedInSchemaUId = new Guid("6a72cf57-dacf-489d-ab70-2d9d1d3a9f55"),
				ModifiedInSchemaUId = new Guid("6a72cf57-dacf-489d-ab70-2d9d1d3a9f55"),
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysEntityRightByAdminOperation(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysEntityRightByAdminOperation_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysEntityRightByAdminOperationSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysEntityRightByAdminOperationSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6a72cf57-dacf-489d-ab70-2d9d1d3a9f55"));
		}

		#endregion

	}

	#endregion

	#region Class: SysEntityRightByAdminOperation

	/// <summary>
	/// Object permissions by system operations.
	/// </summary>
	public class SysEntityRightByAdminOperation : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysEntityRightByAdminOperation(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysEntityRightByAdminOperation";
		}

		public SysEntityRightByAdminOperation(SysEntityRightByAdminOperation source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SysSchemaId {
			get {
				return GetTypedColumnValue<Guid>("SysSchemaId");
			}
			set {
				SetColumnValue("SysSchemaId", value);
				_sysSchema = null;
			}
		}

		/// <exclude/>
		public string SysSchemaTitle {
			get {
				return GetTypedColumnValue<string>("SysSchemaTitle");
			}
			set {
				SetColumnValue("SysSchemaTitle", value);
				if (_sysSchema != null) {
					_sysSchema.Title = value;
				}
			}
		}

		private VwEntityObjects _sysSchema;
		/// <summary>
		/// Object.
		/// </summary>
		public VwEntityObjects SysSchema {
			get {
				return _sysSchema ??
					(_sysSchema = LookupColumnEntities.GetEntity("SysSchema") as VwEntityObjects);
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
		/// System operation.
		/// </summary>
		public SysAdminOperation SysAdminOperation {
			get {
				return _sysAdminOperation ??
					(_sysAdminOperation = LookupColumnEntities.GetEntity("SysAdminOperation") as SysAdminOperation);
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

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysEntityRightByAdminOperation_CrtBaseEventsProcess(UserConnection);
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
			return new SysEntityRightByAdminOperation(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysEntityRightByAdminOperation_CrtBaseEventsProcess

	/// <exclude/>
	public partial class SysEntityRightByAdminOperation_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysEntityRightByAdminOperation
	{

		public SysEntityRightByAdminOperation_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysEntityRightByAdminOperation_CrtBaseEventsProcess";
			SchemaUId = new Guid("6a72cf57-dacf-489d-ab70-2d9d1d3a9f55");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("6a72cf57-dacf-489d-ab70-2d9d1d3a9f55");
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

	#region Class: SysEntityRightByAdminOperation_CrtBaseEventsProcess

	/// <exclude/>
	public class SysEntityRightByAdminOperation_CrtBaseEventsProcess : SysEntityRightByAdminOperation_CrtBaseEventsProcess<SysEntityRightByAdminOperation>
	{

		public SysEntityRightByAdminOperation_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysEntityRightByAdminOperation_CrtBaseEventsProcess

	public partial class SysEntityRightByAdminOperation_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysEntityRightByAdminOperationEventsProcess

	/// <exclude/>
	public class SysEntityRightByAdminOperationEventsProcess : SysEntityRightByAdminOperation_CrtBaseEventsProcess
	{

		public SysEntityRightByAdminOperationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

