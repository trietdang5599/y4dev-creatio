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

	#region Class: SysUserLevelSchemaSchema

	/// <exclude/>
	public class SysUserLevelSchemaSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysUserLevelSchemaSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysUserLevelSchemaSchema(SysUserLevelSchemaSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysUserLevelSchemaSchema(SysUserLevelSchemaSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ae9b430e-f1ab-4eeb-930d-a0360fca21d2");
			RealUId = new Guid("ae9b430e-f1ab-4eeb-930d-a0360fca21d2");
			Name = "SysUserLevelSchema";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("5ce9c96b-344c-4843-8b76-59991939e873");
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
			if (Columns.FindByUId(new Guid("3c576898-12d1-f7fd-4ad1-8cb873f520b1")) == null) {
				Columns.Add(CreateDescriptionColumn());
			}
			if (Columns.FindByUId(new Guid("867613e3-3691-42a6-9010-895b856d1e5e")) == null) {
				Columns.Add(CreateChecksumColumn());
			}
			if (Columns.FindByUId(new Guid("3cd70dc5-737c-1963-c64d-a35e29641514")) == null) {
				Columns.Add(CreateCaptionColumn());
			}
			if (Columns.FindByUId(new Guid("8a3a3592-36c9-d5fd-f477-aac9f7917070")) == null) {
				Columns.Add(CreateUIdColumn());
			}
			if (Columns.FindByUId(new Guid("d52090b9-7155-2889-defb-f41aa46bed1e")) == null) {
				Columns.Add(CreateExtendParentColumn());
			}
			if (Columns.FindByUId(new Guid("eefc5f57-49db-8eb1-ed1b-0b856df6e336")) == null) {
				Columns.Add(CreateDescriptorColumn());
			}
			if (Columns.FindByUId(new Guid("51a7f562-ed09-b8d9-8c0e-0dc1aa72da0a")) == null) {
				Columns.Add(CreateClientContentModifiedOnColumn());
			}
			if (Columns.FindByUId(new Guid("a0b39f45-da27-b86c-4d27-adb67bace7f9")) == null) {
				Columns.Add(CreateParentUIdColumn());
			}
			if (Columns.FindByUId(new Guid("4e86a5e6-457f-8234-ab7c-a34def4ca7e8")) == null) {
				Columns.Add(CreateNameColumn());
			}
			if (Columns.FindByUId(new Guid("338f74fe-d735-7cc9-3b82-9864c27c819f")) == null) {
				Columns.Add(CreateMetaDataModifiedOnColumn());
			}
			if (Columns.FindByUId(new Guid("a74826b9-0d8a-4aaa-e406-fdb6f62cc1f6")) == null) {
				Columns.Add(CreateMetaDataColumn());
			}
			if (Columns.FindByUId(new Guid("927fc8b6-08cc-515d-79ed-eb975ae79535")) == null) {
				Columns.Add(CreateManagerNameColumn());
			}
			if (Columns.FindByUId(new Guid("c16d9345-e023-ca8f-2108-f82009723a21")) == null) {
				Columns.Add(CreateSysAdminUnitColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateDescriptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("3c576898-12d1-f7fd-4ad1-8cb873f520b1"),
				Name = @"Description",
				CreatedInSchemaUId = new Guid("ae9b430e-f1ab-4eeb-930d-a0360fca21d2"),
				ModifiedInSchemaUId = new Guid("ae9b430e-f1ab-4eeb-930d-a0360fca21d2"),
				CreatedInPackageId = new Guid("5ce9c96b-344c-4843-8b76-59991939e873")
			};
		}

		protected virtual EntitySchemaColumn CreateChecksumColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("867613e3-3691-42a6-9010-895b856d1e5e"),
				Name = @"Checksum",
				CreatedInSchemaUId = new Guid("ae9b430e-f1ab-4eeb-930d-a0360fca21d2"),
				ModifiedInSchemaUId = new Guid("ae9b430e-f1ab-4eeb-930d-a0360fca21d2"),
				CreatedInPackageId = new Guid("5ce9c96b-344c-4843-8b76-59991939e873")
			};
		}

		protected virtual EntitySchemaColumn CreateCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("3cd70dc5-737c-1963-c64d-a35e29641514"),
				Name = @"Caption",
				CreatedInSchemaUId = new Guid("ae9b430e-f1ab-4eeb-930d-a0360fca21d2"),
				ModifiedInSchemaUId = new Guid("ae9b430e-f1ab-4eeb-930d-a0360fca21d2"),
				CreatedInPackageId = new Guid("5ce9c96b-344c-4843-8b76-59991939e873"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("8a3a3592-36c9-d5fd-f477-aac9f7917070"),
				Name = @"UId",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ae9b430e-f1ab-4eeb-930d-a0360fca21d2"),
				ModifiedInSchemaUId = new Guid("ae9b430e-f1ab-4eeb-930d-a0360fca21d2"),
				CreatedInPackageId = new Guid("5ce9c96b-344c-4843-8b76-59991939e873"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"AutoGuid")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateExtendParentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("d52090b9-7155-2889-defb-f41aa46bed1e"),
				Name = @"ExtendParent",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("ae9b430e-f1ab-4eeb-930d-a0360fca21d2"),
				ModifiedInSchemaUId = new Guid("ae9b430e-f1ab-4eeb-930d-a0360fca21d2"),
				CreatedInPackageId = new Guid("5ce9c96b-344c-4843-8b76-59991939e873")
			};
		}

		protected virtual EntitySchemaColumn CreateDescriptorColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Binary")) {
				UId = new Guid("eefc5f57-49db-8eb1-ed1b-0b856df6e336"),
				Name = @"Descriptor",
				CreatedInSchemaUId = new Guid("ae9b430e-f1ab-4eeb-930d-a0360fca21d2"),
				ModifiedInSchemaUId = new Guid("ae9b430e-f1ab-4eeb-930d-a0360fca21d2"),
				CreatedInPackageId = new Guid("5ce9c96b-344c-4843-8b76-59991939e873")
			};
		}

		protected virtual EntitySchemaColumn CreateClientContentModifiedOnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("51a7f562-ed09-b8d9-8c0e-0dc1aa72da0a"),
				Name = @"ClientContentModifiedOn",
				CreatedInSchemaUId = new Guid("ae9b430e-f1ab-4eeb-930d-a0360fca21d2"),
				ModifiedInSchemaUId = new Guid("ae9b430e-f1ab-4eeb-930d-a0360fca21d2"),
				CreatedInPackageId = new Guid("5ce9c96b-344c-4843-8b76-59991939e873")
			};
		}

		protected virtual EntitySchemaColumn CreateParentUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("a0b39f45-da27-b86c-4d27-adb67bace7f9"),
				Name = @"ParentUId",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ae9b430e-f1ab-4eeb-930d-a0360fca21d2"),
				ModifiedInSchemaUId = new Guid("ae9b430e-f1ab-4eeb-930d-a0360fca21d2"),
				CreatedInPackageId = new Guid("5ce9c96b-344c-4843-8b76-59991939e873")
			};
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("4e86a5e6-457f-8234-ab7c-a34def4ca7e8"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("ae9b430e-f1ab-4eeb-930d-a0360fca21d2"),
				ModifiedInSchemaUId = new Guid("ae9b430e-f1ab-4eeb-930d-a0360fca21d2"),
				CreatedInPackageId = new Guid("5ce9c96b-344c-4843-8b76-59991939e873")
			};
		}

		protected virtual EntitySchemaColumn CreateMetaDataModifiedOnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("338f74fe-d735-7cc9-3b82-9864c27c819f"),
				Name = @"MetaDataModifiedOn",
				CreatedInSchemaUId = new Guid("ae9b430e-f1ab-4eeb-930d-a0360fca21d2"),
				ModifiedInSchemaUId = new Guid("ae9b430e-f1ab-4eeb-930d-a0360fca21d2"),
				CreatedInPackageId = new Guid("5ce9c96b-344c-4843-8b76-59991939e873")
			};
		}

		protected virtual EntitySchemaColumn CreateMetaDataColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Binary")) {
				UId = new Guid("a74826b9-0d8a-4aaa-e406-fdb6f62cc1f6"),
				Name = @"MetaData",
				CreatedInSchemaUId = new Guid("ae9b430e-f1ab-4eeb-930d-a0360fca21d2"),
				ModifiedInSchemaUId = new Guid("ae9b430e-f1ab-4eeb-930d-a0360fca21d2"),
				CreatedInPackageId = new Guid("5ce9c96b-344c-4843-8b76-59991939e873")
			};
		}

		protected virtual EntitySchemaColumn CreateManagerNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("927fc8b6-08cc-515d-79ed-eb975ae79535"),
				Name = @"ManagerName",
				CreatedInSchemaUId = new Guid("ae9b430e-f1ab-4eeb-930d-a0360fca21d2"),
				ModifiedInSchemaUId = new Guid("ae9b430e-f1ab-4eeb-930d-a0360fca21d2"),
				CreatedInPackageId = new Guid("5ce9c96b-344c-4843-8b76-59991939e873")
			};
		}

		protected virtual EntitySchemaColumn CreateSysAdminUnitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("c16d9345-e023-ca8f-2108-f82009723a21"),
				Name = @"SysAdminUnit",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("ae9b430e-f1ab-4eeb-930d-a0360fca21d2"),
				ModifiedInSchemaUId = new Guid("ae9b430e-f1ab-4eeb-930d-a0360fca21d2"),
				CreatedInPackageId = new Guid("5ce9c96b-344c-4843-8b76-59991939e873")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysUserLevelSchema(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysUserLevelSchema_CrtUserLevelSchemaEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysUserLevelSchemaSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysUserLevelSchemaSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ae9b430e-f1ab-4eeb-930d-a0360fca21d2"));
		}

		#endregion

	}

	#endregion

	#region Class: SysUserLevelSchema

	/// <summary>
	/// User level schema.
	/// </summary>
	public class SysUserLevelSchema : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysUserLevelSchema(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysUserLevelSchema";
		}

		public SysUserLevelSchema(SysUserLevelSchema source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Description.
		/// </summary>
		public string Description {
			get {
				return GetTypedColumnValue<string>("Description");
			}
			set {
				SetColumnValue("Description", value);
			}
		}

		/// <summary>
		/// Checksum.
		/// </summary>
		public string Checksum {
			get {
				return GetTypedColumnValue<string>("Checksum");
			}
			set {
				SetColumnValue("Checksum", value);
			}
		}

		/// <summary>
		/// Title.
		/// </summary>
		public string Caption {
			get {
				return GetTypedColumnValue<string>("Caption");
			}
			set {
				SetColumnValue("Caption", value);
			}
		}

		/// <summary>
		/// UId.
		/// </summary>
		public Guid UId {
			get {
				return GetTypedColumnValue<Guid>("UId");
			}
			set {
				SetColumnValue("UId", value);
			}
		}

		/// <summary>
		/// Replace parent.
		/// </summary>
		public bool ExtendParent {
			get {
				return GetTypedColumnValue<bool>("ExtendParent");
			}
			set {
				SetColumnValue("ExtendParent", value);
			}
		}

		/// <summary>
		/// Client module updated on.
		/// </summary>
		public DateTime ClientContentModifiedOn {
			get {
				return GetTypedColumnValue<DateTime>("ClientContentModifiedOn");
			}
			set {
				SetColumnValue("ClientContentModifiedOn", value);
			}
		}

		/// <summary>
		/// Parent schema UId.
		/// </summary>
		public Guid ParentUId {
			get {
				return GetTypedColumnValue<Guid>("ParentUId");
			}
			set {
				SetColumnValue("ParentUId", value);
			}
		}

		/// <summary>
		/// Name.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		/// <summary>
		/// Metadata changed.
		/// </summary>
		public DateTime MetaDataModifiedOn {
			get {
				return GetTypedColumnValue<DateTime>("MetaDataModifiedOn");
			}
			set {
				SetColumnValue("MetaDataModifiedOn", value);
			}
		}

		/// <summary>
		/// Manager.
		/// </summary>
		public string ManagerName {
			get {
				return GetTypedColumnValue<string>("ManagerName");
			}
			set {
				SetColumnValue("ManagerName", value);
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

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysUserLevelSchema_CrtUserLevelSchemaEventsProcess(UserConnection);
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
			return new SysUserLevelSchema(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysUserLevelSchema_CrtUserLevelSchemaEventsProcess

	/// <exclude/>
	public partial class SysUserLevelSchema_CrtUserLevelSchemaEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysUserLevelSchema
	{

		public SysUserLevelSchema_CrtUserLevelSchemaEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysUserLevelSchema_CrtUserLevelSchemaEventsProcess";
			SchemaUId = new Guid("ae9b430e-f1ab-4eeb-930d-a0360fca21d2");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ae9b430e-f1ab-4eeb-930d-a0360fca21d2");
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

	#region Class: SysUserLevelSchema_CrtUserLevelSchemaEventsProcess

	/// <exclude/>
	public class SysUserLevelSchema_CrtUserLevelSchemaEventsProcess : SysUserLevelSchema_CrtUserLevelSchemaEventsProcess<SysUserLevelSchema>
	{

		public SysUserLevelSchema_CrtUserLevelSchemaEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysUserLevelSchema_CrtUserLevelSchemaEventsProcess

	public partial class SysUserLevelSchema_CrtUserLevelSchemaEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysUserLevelSchemaEventsProcess

	/// <exclude/>
	public class SysUserLevelSchemaEventsProcess : SysUserLevelSchema_CrtUserLevelSchemaEventsProcess
	{

		public SysUserLevelSchemaEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

