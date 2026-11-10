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

	#region Class: PackageCompilationStateSchema

	/// <exclude/>
	public class PackageCompilationStateSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public PackageCompilationStateSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public PackageCompilationStateSchema(PackageCompilationStateSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public PackageCompilationStateSchema(PackageCompilationStateSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("09ab3202-3b21-4bd7-a595-23054025d4cd");
			RealUId = new Guid("09ab3202-3b21-4bd7-a595-23054025d4cd");
			Name = "PackageCompilationState";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("a5e2b265-8078-4de9-a58f-70804c80c57f");
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
			if (Columns.FindByUId(new Guid("67c30ba9-ad3f-0520-0a7e-b541f6550ef9")) == null) {
				Columns.Add(CreatePackageUIdColumn());
			}
			if (Columns.FindByUId(new Guid("bf53fa40-abab-7058-8c49-12028ca9b9e9")) == null) {
				Columns.Add(CreateRequiresRestoreColumn());
			}
			if (Columns.FindByUId(new Guid("941f045a-2ffc-47a1-78eb-3a734184eedb")) == null) {
				Columns.Add(CreateNeedCompileColumn());
			}
			if (Columns.FindByUId(new Guid("9bcc42e0-1f46-3391-8c7e-649438c04ed0")) == null) {
				Columns.Add(CreateNeedCompileDependentPackagesColumn());
			}
			if (Columns.FindByUId(new Guid("6e04ea7d-821e-ed91-fb17-126e3f7edad2")) == null) {
				Columns.Add(CreateNeedDownloadPackageSourceCodeColumn());
			}
			if (Columns.FindByUId(new Guid("6d11eeea-84a6-1c71-52f1-0f96648f826d")) == null) {
				Columns.Add(CreateNeedRegeneratePackagesCsprojColumn());
			}
			if (Columns.FindByUId(new Guid("ce385aef-eb78-1a9a-7523-29363868ec50")) == null) {
				Columns.Add(CreateNeedCompileODataColumn());
			}
		}

		protected virtual EntitySchemaColumn CreatePackageUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("67c30ba9-ad3f-0520-0a7e-b541f6550ef9"),
				Name = @"PackageUId",
				CreatedInSchemaUId = new Guid("09ab3202-3b21-4bd7-a595-23054025d4cd"),
				ModifiedInSchemaUId = new Guid("09ab3202-3b21-4bd7-a595-23054025d4cd"),
				CreatedInPackageId = new Guid("a5e2b265-8078-4de9-a58f-70804c80c57f")
			};
		}

		protected virtual EntitySchemaColumn CreateRequiresRestoreColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("bf53fa40-abab-7058-8c49-12028ca9b9e9"),
				Name = @"RequiresRestore",
				CreatedInSchemaUId = new Guid("09ab3202-3b21-4bd7-a595-23054025d4cd"),
				ModifiedInSchemaUId = new Guid("09ab3202-3b21-4bd7-a595-23054025d4cd"),
				CreatedInPackageId = new Guid("a5e2b265-8078-4de9-a58f-70804c80c57f")
			};
		}

		protected virtual EntitySchemaColumn CreateNeedCompileColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("941f045a-2ffc-47a1-78eb-3a734184eedb"),
				Name = @"NeedCompile",
				CreatedInSchemaUId = new Guid("09ab3202-3b21-4bd7-a595-23054025d4cd"),
				ModifiedInSchemaUId = new Guid("09ab3202-3b21-4bd7-a595-23054025d4cd"),
				CreatedInPackageId = new Guid("a5e2b265-8078-4de9-a58f-70804c80c57f")
			};
		}

		protected virtual EntitySchemaColumn CreateNeedCompileDependentPackagesColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("9bcc42e0-1f46-3391-8c7e-649438c04ed0"),
				Name = @"NeedCompileDependentPackages",
				CreatedInSchemaUId = new Guid("09ab3202-3b21-4bd7-a595-23054025d4cd"),
				ModifiedInSchemaUId = new Guid("09ab3202-3b21-4bd7-a595-23054025d4cd"),
				CreatedInPackageId = new Guid("a5e2b265-8078-4de9-a58f-70804c80c57f")
			};
		}

		protected virtual EntitySchemaColumn CreateNeedDownloadPackageSourceCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("6e04ea7d-821e-ed91-fb17-126e3f7edad2"),
				Name = @"NeedDownloadPackageSourceCode",
				CreatedInSchemaUId = new Guid("09ab3202-3b21-4bd7-a595-23054025d4cd"),
				ModifiedInSchemaUId = new Guid("09ab3202-3b21-4bd7-a595-23054025d4cd"),
				CreatedInPackageId = new Guid("a5e2b265-8078-4de9-a58f-70804c80c57f")
			};
		}

		protected virtual EntitySchemaColumn CreateNeedRegeneratePackagesCsprojColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("6d11eeea-84a6-1c71-52f1-0f96648f826d"),
				Name = @"NeedRegeneratePackagesCsproj",
				CreatedInSchemaUId = new Guid("09ab3202-3b21-4bd7-a595-23054025d4cd"),
				ModifiedInSchemaUId = new Guid("09ab3202-3b21-4bd7-a595-23054025d4cd"),
				CreatedInPackageId = new Guid("a5e2b265-8078-4de9-a58f-70804c80c57f")
			};
		}

		protected virtual EntitySchemaColumn CreateNeedCompileODataColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("ce385aef-eb78-1a9a-7523-29363868ec50"),
				Name = @"NeedCompileOData",
				CreatedInSchemaUId = new Guid("09ab3202-3b21-4bd7-a595-23054025d4cd"),
				ModifiedInSchemaUId = new Guid("09ab3202-3b21-4bd7-a595-23054025d4cd"),
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
			return new PackageCompilationState(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new PackageCompilationState_CrtCoreBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new PackageCompilationStateSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new PackageCompilationStateSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("09ab3202-3b21-4bd7-a595-23054025d4cd"));
		}

		#endregion

	}

	#endregion

	#region Class: PackageCompilationState

	/// <summary>
	/// Package Compilation State.
	/// </summary>
	public class PackageCompilationState : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public PackageCompilationState(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "PackageCompilationState";
		}

		public PackageCompilationState(PackageCompilationState source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// PackageUId.
		/// </summary>
		public Guid PackageUId {
			get {
				return GetTypedColumnValue<Guid>("PackageUId");
			}
			set {
				SetColumnValue("PackageUId", value);
			}
		}

		/// <summary>
		/// RequiresRestore.
		/// </summary>
		public bool RequiresRestore {
			get {
				return GetTypedColumnValue<bool>("RequiresRestore");
			}
			set {
				SetColumnValue("RequiresRestore", value);
			}
		}

		/// <summary>
		/// NeedCompile.
		/// </summary>
		public bool NeedCompile {
			get {
				return GetTypedColumnValue<bool>("NeedCompile");
			}
			set {
				SetColumnValue("NeedCompile", value);
			}
		}

		/// <summary>
		/// NeedCompileDependentPackages.
		/// </summary>
		public bool NeedCompileDependentPackages {
			get {
				return GetTypedColumnValue<bool>("NeedCompileDependentPackages");
			}
			set {
				SetColumnValue("NeedCompileDependentPackages", value);
			}
		}

		/// <summary>
		/// NeedDownloadPackageSourceCode.
		/// </summary>
		public bool NeedDownloadPackageSourceCode {
			get {
				return GetTypedColumnValue<bool>("NeedDownloadPackageSourceCode");
			}
			set {
				SetColumnValue("NeedDownloadPackageSourceCode", value);
			}
		}

		/// <summary>
		/// NeedRegeneratePackagesCsproj.
		/// </summary>
		public bool NeedRegeneratePackagesCsproj {
			get {
				return GetTypedColumnValue<bool>("NeedRegeneratePackagesCsproj");
			}
			set {
				SetColumnValue("NeedRegeneratePackagesCsproj", value);
			}
		}

		/// <summary>
		/// NeedCompileOData.
		/// </summary>
		public bool NeedCompileOData {
			get {
				return GetTypedColumnValue<bool>("NeedCompileOData");
			}
			set {
				SetColumnValue("NeedCompileOData", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new PackageCompilationState_CrtCoreBaseEventsProcess(UserConnection);
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
			return new PackageCompilationState(this);
		}

		#endregion

	}

	#endregion

	#region Class: PackageCompilationState_CrtCoreBaseEventsProcess

	/// <exclude/>
	public partial class PackageCompilationState_CrtCoreBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : PackageCompilationState
	{

		public PackageCompilationState_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "PackageCompilationState_CrtCoreBaseEventsProcess";
			SchemaUId = new Guid("09ab3202-3b21-4bd7-a595-23054025d4cd");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("09ab3202-3b21-4bd7-a595-23054025d4cd");
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

	#region Class: PackageCompilationState_CrtCoreBaseEventsProcess

	/// <exclude/>
	public class PackageCompilationState_CrtCoreBaseEventsProcess : PackageCompilationState_CrtCoreBaseEventsProcess<PackageCompilationState>
	{

		public PackageCompilationState_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: PackageCompilationState_CrtCoreBaseEventsProcess

	public partial class PackageCompilationState_CrtCoreBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: PackageCompilationStateEventsProcess

	/// <exclude/>
	public class PackageCompilationStateEventsProcess : PackageCompilationState_CrtCoreBaseEventsProcess
	{

		public PackageCompilationStateEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

