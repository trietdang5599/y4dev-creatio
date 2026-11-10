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

	#region Class: SysWorkspaceSchema

	/// <exclude/>
	public class SysWorkspaceSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public SysWorkspaceSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysWorkspaceSchema(SysWorkspaceSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysWorkspaceSchema(SysWorkspaceSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7f9653ec-2e91-4aaa-a065-7b1d46edd292");
			RealUId = new Guid("7f9653ec-2e91-4aaa-a065-7b1d46edd292");
			Name = "SysWorkspace";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
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
			if (Columns.FindByUId(new Guid("637f91a4-3143-4f93-b60c-5006633d58d8")) == null) {
				Columns.Add(CreateIsDefaultColumn());
			}
			if (Columns.FindByUId(new Guid("03c913bc-e34d-4681-9768-7bd095fb28ab")) == null) {
				Columns.Add(CreateNumberColumn());
			}
			if (Columns.FindByUId(new Guid("0517e3b2-a4b5-47c5-971d-d885fc05b271")) == null) {
				Columns.Add(CreateVersionColumn());
			}
			if (Columns.FindByUId(new Guid("a8c3e0db-13f1-43a1-818a-fceaa5d53767")) == null) {
				Columns.Add(CreateRepositoryUriColumn());
			}
			if (Columns.FindByUId(new Guid("398635d4-b784-422d-8eec-37078b3c268f")) == null) {
				Columns.Add(CreateWorkingCopyPathColumn());
			}
			if (Columns.FindByUId(new Guid("9ba51ca5-3a09-40c0-82e1-839d27055226")) == null) {
				Columns.Add(CreateRepositoryRevisionNumberColumn());
			}
			if (Columns.FindByUId(new Guid("664ca6bf-4f55-64e2-98e5-f970a156d23e")) == null) {
				Columns.Add(CreateBuildODataStartedByColumn());
			}
			if (Columns.FindByUId(new Guid("aa4fa25e-6250-5181-0ed7-627fadbc7bbc")) == null) {
				Columns.Add(CreateNeedRestartNodesColumn());
			}
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.IsLocalizable = false;
			column.ModifiedInSchemaUId = new Guid("7f9653ec-2e91-4aaa-a065-7b1d46edd292");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.IsLocalizable = false;
			column.ModifiedInSchemaUId = new Guid("7f9653ec-2e91-4aaa-a065-7b1d46edd292");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected virtual EntitySchemaColumn CreateIsDefaultColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("637f91a4-3143-4f93-b60c-5006633d58d8"),
				Name = @"IsDefault",
				CreatedInSchemaUId = new Guid("7f9653ec-2e91-4aaa-a065-7b1d46edd292"),
				ModifiedInSchemaUId = new Guid("7f9653ec-2e91-4aaa-a065-7b1d46edd292"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateNumberColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("03c913bc-e34d-4681-9768-7bd095fb28ab"),
				Name = @"Number",
				CreatedInSchemaUId = new Guid("7f9653ec-2e91-4aaa-a065-7b1d46edd292"),
				ModifiedInSchemaUId = new Guid("7f9653ec-2e91-4aaa-a065-7b1d46edd292"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateVersionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("0517e3b2-a4b5-47c5-971d-d885fc05b271"),
				Name = @"Version",
				CreatedInSchemaUId = new Guid("7f9653ec-2e91-4aaa-a065-7b1d46edd292"),
				ModifiedInSchemaUId = new Guid("7f9653ec-2e91-4aaa-a065-7b1d46edd292"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateRepositoryUriColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("a8c3e0db-13f1-43a1-818a-fceaa5d53767"),
				Name = @"RepositoryUri",
				CreatedInSchemaUId = new Guid("7f9653ec-2e91-4aaa-a065-7b1d46edd292"),
				ModifiedInSchemaUId = new Guid("7f9653ec-2e91-4aaa-a065-7b1d46edd292"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateWorkingCopyPathColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("398635d4-b784-422d-8eec-37078b3c268f"),
				Name = @"WorkingCopyPath",
				CreatedInSchemaUId = new Guid("7f9653ec-2e91-4aaa-a065-7b1d46edd292"),
				ModifiedInSchemaUId = new Guid("7f9653ec-2e91-4aaa-a065-7b1d46edd292"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateRepositoryRevisionNumberColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("9ba51ca5-3a09-40c0-82e1-839d27055226"),
				Name = @"RepositoryRevisionNumber",
				CreatedInSchemaUId = new Guid("7f9653ec-2e91-4aaa-a065-7b1d46edd292"),
				ModifiedInSchemaUId = new Guid("7f9653ec-2e91-4aaa-a065-7b1d46edd292"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateBuildODataStartedByColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("664ca6bf-4f55-64e2-98e5-f970a156d23e"),
				Name = @"BuildODataStartedBy",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("7f9653ec-2e91-4aaa-a065-7b1d46edd292"),
				ModifiedInSchemaUId = new Guid("7f9653ec-2e91-4aaa-a065-7b1d46edd292"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected virtual EntitySchemaColumn CreateNeedRestartNodesColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("aa4fa25e-6250-5181-0ed7-627fadbc7bbc"),
				Name = @"NeedRestartNodes",
				CreatedInSchemaUId = new Guid("7f9653ec-2e91-4aaa-a065-7b1d46edd292"),
				ModifiedInSchemaUId = new Guid("7f9653ec-2e91-4aaa-a065-7b1d46edd292"),
				CreatedInPackageId = new Guid("a5e2b265-8078-4de9-a58f-70804c80c57f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysWorkspace(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysWorkspace_CrtCoreBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysWorkspaceSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysWorkspaceSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7f9653ec-2e91-4aaa-a065-7b1d46edd292"));
		}

		#endregion

	}

	#endregion

	#region Class: SysWorkspace

	/// <summary>
	/// User workspace.
	/// </summary>
	public class SysWorkspace : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public SysWorkspace(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysWorkspace";
		}

		public SysWorkspace(SysWorkspace source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Default.
		/// </summary>
		public bool IsDefault {
			get {
				return GetTypedColumnValue<bool>("IsDefault");
			}
			set {
				SetColumnValue("IsDefault", value);
			}
		}

		/// <summary>
		/// Number.
		/// </summary>
		public int Number {
			get {
				return GetTypedColumnValue<int>("Number");
			}
			set {
				SetColumnValue("Number", value);
			}
		}

		/// <summary>
		/// Version.
		/// </summary>
		public int Version {
			get {
				return GetTypedColumnValue<int>("Version");
			}
			set {
				SetColumnValue("Version", value);
			}
		}

		/// <summary>
		/// Repository URI.
		/// </summary>
		public string RepositoryUri {
			get {
				return GetTypedColumnValue<string>("RepositoryUri");
			}
			set {
				SetColumnValue("RepositoryUri", value);
			}
		}

		/// <summary>
		/// Working copy path.
		/// </summary>
		public string WorkingCopyPath {
			get {
				return GetTypedColumnValue<string>("WorkingCopyPath");
			}
			set {
				SetColumnValue("WorkingCopyPath", value);
			}
		}

		/// <summary>
		/// Current repository revision number.
		/// </summary>
		public int RepositoryRevisionNumber {
			get {
				return GetTypedColumnValue<int>("RepositoryRevisionNumber");
			}
			set {
				SetColumnValue("RepositoryRevisionNumber", value);
			}
		}

		/// <exclude/>
		public Guid BuildODataStartedById {
			get {
				return GetTypedColumnValue<Guid>("BuildODataStartedById");
			}
			set {
				SetColumnValue("BuildODataStartedById", value);
				_buildODataStartedBy = null;
			}
		}

		/// <exclude/>
		public string BuildODataStartedByName {
			get {
				return GetTypedColumnValue<string>("BuildODataStartedByName");
			}
			set {
				SetColumnValue("BuildODataStartedByName", value);
				if (_buildODataStartedBy != null) {
					_buildODataStartedBy.Name = value;
				}
			}
		}

		private Contact _buildODataStartedBy;
		/// <summary>
		/// User who started compilation of OData entities.
		/// </summary>
		public Contact BuildODataStartedBy {
			get {
				return _buildODataStartedBy ??
					(_buildODataStartedBy = LookupColumnEntities.GetEntity("BuildODataStartedBy") as Contact);
			}
		}

		/// <summary>
		/// Need restart nodes.
		/// </summary>
		public bool NeedRestartNodes {
			get {
				return GetTypedColumnValue<bool>("NeedRestartNodes");
			}
			set {
				SetColumnValue("NeedRestartNodes", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysWorkspace_CrtCoreBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysWorkspaceDeleted", e);
			Inserting += (s, e) => ThrowEvent("SysWorkspaceInserting", e);
			Validating += (s, e) => ThrowEvent("SysWorkspaceValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysWorkspace(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysWorkspace_CrtCoreBaseEventsProcess

	/// <exclude/>
	public partial class SysWorkspace_CrtCoreBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysWorkspace
	{

		public SysWorkspace_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysWorkspace_CrtCoreBaseEventsProcess";
			SchemaUId = new Guid("7f9653ec-2e91-4aaa-a065-7b1d46edd292");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("7f9653ec-2e91-4aaa-a065-7b1d46edd292");
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

	#region Class: SysWorkspace_CrtCoreBaseEventsProcess

	/// <exclude/>
	public class SysWorkspace_CrtCoreBaseEventsProcess : SysWorkspace_CrtCoreBaseEventsProcess<SysWorkspace>
	{

		public SysWorkspace_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysWorkspace_CrtCoreBaseEventsProcess

	public partial class SysWorkspace_CrtCoreBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void CheckCanManageLookups() {
		}

		#endregion

	}

	#endregion


	#region Class: SysWorkspaceEventsProcess

	/// <exclude/>
	public class SysWorkspaceEventsProcess : SysWorkspace_CrtCoreBaseEventsProcess
	{

		public SysWorkspaceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

