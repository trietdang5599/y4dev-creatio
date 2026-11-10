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

	#region Class: SysPackageHotfixInfoSchema

	/// <exclude/>
	public class SysPackageHotfixInfoSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysPackageHotfixInfoSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysPackageHotfixInfoSchema(SysPackageHotfixInfoSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysPackageHotfixInfoSchema(SysPackageHotfixInfoSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreatePackageHotfixInfo_PackageIndexIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = true
			};
			index.UId = new Guid("b6d4b3d8-1664-4b3c-be4e-6efd7b75d749");
			index.Name = "PackageHotfixInfo_PackageIndex";
			index.CreatedInSchemaUId = new Guid("39af1f34-96a2-46f7-b739-8d2f75ea9300");
			index.ModifiedInSchemaUId = new Guid("39af1f34-96a2-46f7-b739-8d2f75ea9300");
			index.CreatedInPackageId = new Guid("1e78c195-217a-4877-a718-71dfe1dfe442");
			EntitySchemaIndexColumn packageIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("61fc4eeb-de1c-2a7b-03f1-c3dfbc13c429"),
				ColumnUId = new Guid("cf332c3f-d3f8-4eb7-ccfe-ad5a6bd997e6"),
				CreatedInSchemaUId = new Guid("39af1f34-96a2-46f7-b739-8d2f75ea9300"),
				ModifiedInSchemaUId = new Guid("39af1f34-96a2-46f7-b739-8d2f75ea9300"),
				CreatedInPackageId = new Guid("1e78c195-217a-4877-a718-71dfe1dfe442"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(packageIdIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("39af1f34-96a2-46f7-b739-8d2f75ea9300");
			RealUId = new Guid("39af1f34-96a2-46f7-b739-8d2f75ea9300");
			Name = "SysPackageHotfixInfo";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("672cc0bc-01f3-4dc2-b726-8244e6d9f05c");
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
			if (Columns.FindByUId(new Guid("cf332c3f-d3f8-4eb7-ccfe-ad5a6bd997e6")) == null) {
				Columns.Add(CreatePackageColumn());
			}
			if (Columns.FindByUId(new Guid("f80f6b12-a3e0-df6f-406c-227230be777e")) == null) {
				Columns.Add(CreateIsUnderHotfixColumn());
			}
			if (Columns.FindByUId(new Guid("f7eccbc8-50e2-7cb2-608b-5a792774dbbd")) == null) {
				Columns.Add(CreateStartDateColumn());
			}
			if (Columns.FindByUId(new Guid("a26dc163-72fc-39bc-2c9e-7532a7577bb1")) == null) {
				Columns.Add(CreateEndDateColumn());
			}
			if (Columns.FindByUId(new Guid("fd1a0f5e-5ad0-e4bc-7311-996d43aeaabc")) == null) {
				Columns.Add(CreateOriginalInstallTypeColumn());
			}
			if (Columns.FindByUId(new Guid("3958a88c-9754-63b8-cd5a-7e438c46eda5")) == null) {
				Columns.Add(CreateOriginalMaintainerColumn());
			}
		}

		protected virtual EntitySchemaColumn CreatePackageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("cf332c3f-d3f8-4eb7-ccfe-ad5a6bd997e6"),
				Name = @"Package",
				ReferenceSchemaUId = new Guid("ca400a85-ec48-4b42-8e50-271929d27871"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("39af1f34-96a2-46f7-b739-8d2f75ea9300"),
				ModifiedInSchemaUId = new Guid("39af1f34-96a2-46f7-b739-8d2f75ea9300"),
				CreatedInPackageId = new Guid("672cc0bc-01f3-4dc2-b726-8244e6d9f05c"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateIsUnderHotfixColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("f80f6b12-a3e0-df6f-406c-227230be777e"),
				Name = @"IsUnderHotfix",
				CreatedInSchemaUId = new Guid("39af1f34-96a2-46f7-b739-8d2f75ea9300"),
				ModifiedInSchemaUId = new Guid("39af1f34-96a2-46f7-b739-8d2f75ea9300"),
				CreatedInPackageId = new Guid("672cc0bc-01f3-4dc2-b726-8244e6d9f05c")
			};
		}

		protected virtual EntitySchemaColumn CreateStartDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("f7eccbc8-50e2-7cb2-608b-5a792774dbbd"),
				Name = @"StartDate",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("39af1f34-96a2-46f7-b739-8d2f75ea9300"),
				ModifiedInSchemaUId = new Guid("39af1f34-96a2-46f7-b739-8d2f75ea9300"),
				CreatedInPackageId = new Guid("672cc0bc-01f3-4dc2-b726-8244e6d9f05c")
			};
		}

		protected virtual EntitySchemaColumn CreateEndDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("a26dc163-72fc-39bc-2c9e-7532a7577bb1"),
				Name = @"EndDate",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("39af1f34-96a2-46f7-b739-8d2f75ea9300"),
				ModifiedInSchemaUId = new Guid("39af1f34-96a2-46f7-b739-8d2f75ea9300"),
				CreatedInPackageId = new Guid("672cc0bc-01f3-4dc2-b726-8244e6d9f05c")
			};
		}

		protected virtual EntitySchemaColumn CreateOriginalInstallTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("fd1a0f5e-5ad0-e4bc-7311-996d43aeaabc"),
				Name = @"OriginalInstallType",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("39af1f34-96a2-46f7-b739-8d2f75ea9300"),
				ModifiedInSchemaUId = new Guid("39af1f34-96a2-46f7-b739-8d2f75ea9300"),
				CreatedInPackageId = new Guid("672cc0bc-01f3-4dc2-b726-8244e6d9f05c")
			};
		}

		protected virtual EntitySchemaColumn CreateOriginalMaintainerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("3958a88c-9754-63b8-cd5a-7e438c46eda5"),
				Name = @"OriginalMaintainer",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("39af1f34-96a2-46f7-b739-8d2f75ea9300"),
				ModifiedInSchemaUId = new Guid("39af1f34-96a2-46f7-b739-8d2f75ea9300"),
				CreatedInPackageId = new Guid("672cc0bc-01f3-4dc2-b726-8244e6d9f05c")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreatePackageHotfixInfo_PackageIndexIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysPackageHotfixInfo(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysPackageHotfixInfo_CrtCoreBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysPackageHotfixInfoSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysPackageHotfixInfoSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("39af1f34-96a2-46f7-b739-8d2f75ea9300"));
		}

		#endregion

	}

	#endregion

	#region Class: SysPackageHotfixInfo

	/// <summary>
	/// Package hotfix info.
	/// </summary>
	public class SysPackageHotfixInfo : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysPackageHotfixInfo(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysPackageHotfixInfo";
		}

		public SysPackageHotfixInfo(SysPackageHotfixInfo source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid PackageId {
			get {
				return GetTypedColumnValue<Guid>("PackageId");
			}
			set {
				SetColumnValue("PackageId", value);
				_package = null;
			}
		}

		/// <exclude/>
		public string PackageName {
			get {
				return GetTypedColumnValue<string>("PackageName");
			}
			set {
				SetColumnValue("PackageName", value);
				if (_package != null) {
					_package.Name = value;
				}
			}
		}

		private SysPackage _package;
		/// <summary>
		/// Package.
		/// </summary>
		public SysPackage Package {
			get {
				return _package ??
					(_package = LookupColumnEntities.GetEntity("Package") as SysPackage);
			}
		}

		/// <summary>
		/// Is under hotfix.
		/// </summary>
		public bool IsUnderHotfix {
			get {
				return GetTypedColumnValue<bool>("IsUnderHotfix");
			}
			set {
				SetColumnValue("IsUnderHotfix", value);
			}
		}

		/// <summary>
		/// Start date.
		/// </summary>
		public DateTime StartDate {
			get {
				return GetTypedColumnValue<DateTime>("StartDate");
			}
			set {
				SetColumnValue("StartDate", value);
			}
		}

		/// <summary>
		/// End date.
		/// </summary>
		public DateTime EndDate {
			get {
				return GetTypedColumnValue<DateTime>("EndDate");
			}
			set {
				SetColumnValue("EndDate", value);
			}
		}

		/// <summary>
		/// Original install type.
		/// </summary>
		public int OriginalInstallType {
			get {
				return GetTypedColumnValue<int>("OriginalInstallType");
			}
			set {
				SetColumnValue("OriginalInstallType", value);
			}
		}

		/// <summary>
		/// Original maintainer.
		/// </summary>
		public string OriginalMaintainer {
			get {
				return GetTypedColumnValue<string>("OriginalMaintainer");
			}
			set {
				SetColumnValue("OriginalMaintainer", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysPackageHotfixInfo_CrtCoreBaseEventsProcess(UserConnection);
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
			return new SysPackageHotfixInfo(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysPackageHotfixInfo_CrtCoreBaseEventsProcess

	/// <exclude/>
	public partial class SysPackageHotfixInfo_CrtCoreBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysPackageHotfixInfo
	{

		public SysPackageHotfixInfo_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysPackageHotfixInfo_CrtCoreBaseEventsProcess";
			SchemaUId = new Guid("39af1f34-96a2-46f7-b739-8d2f75ea9300");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("39af1f34-96a2-46f7-b739-8d2f75ea9300");
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

	#region Class: SysPackageHotfixInfo_CrtCoreBaseEventsProcess

	/// <exclude/>
	public class SysPackageHotfixInfo_CrtCoreBaseEventsProcess : SysPackageHotfixInfo_CrtCoreBaseEventsProcess<SysPackageHotfixInfo>
	{

		public SysPackageHotfixInfo_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysPackageHotfixInfo_CrtCoreBaseEventsProcess

	public partial class SysPackageHotfixInfo_CrtCoreBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysPackageHotfixInfoEventsProcess

	/// <exclude/>
	public class SysPackageHotfixInfoEventsProcess : SysPackageHotfixInfo_CrtCoreBaseEventsProcess
	{

		public SysPackageHotfixInfoEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

