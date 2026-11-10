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

	#region Class: SysDataSegmentSchema

	/// <exclude/>
	public class SysDataSegmentSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysDataSegmentSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysDataSegmentSchema(SysDataSegmentSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysDataSegmentSchema(SysDataSegmentSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIX_Name_UniqueIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = true
			};
			index.UId = new Guid("3e4ae137-980d-ac51-f3d6-f882bb297f79");
			index.Name = "IX_Name_Unique";
			index.CreatedInSchemaUId = new Guid("91cb9657-9d75-4e75-ac6c-4704630636db");
			index.ModifiedInSchemaUId = new Guid("91cb9657-9d75-4e75-ac6c-4704630636db");
			index.CreatedInPackageId = new Guid("8215d77a-263e-4d23-a383-2960c4f89ac7");
			EntitySchemaIndexColumn nameIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("3702f4b9-51c0-9668-3cd7-663e9b093df1"),
				ColumnUId = new Guid("2835a0ce-d53f-4c6c-8f4c-921ea7746d35"),
				CreatedInSchemaUId = new Guid("91cb9657-9d75-4e75-ac6c-4704630636db"),
				ModifiedInSchemaUId = new Guid("91cb9657-9d75-4e75-ac6c-4704630636db"),
				CreatedInPackageId = new Guid("8215d77a-263e-4d23-a383-2960c4f89ac7"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(nameIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("91cb9657-9d75-4e75-ac6c-4704630636db");
			RealUId = new Guid("91cb9657-9d75-4e75-ac6c-4704630636db");
			Name = "SysDataSegment";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("6f71e54c-1960-40c9-94f6-073fd67699ab");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = false;
			UseLiveEditing = true;
			Paging.IsPageable = true;
			Filtering.IsFilterable = true;
			Sorting.IsSortable = true;
			Write.IsInsertable = true;
			Write.IsUpdatable = true;
			Write.IsDeletable = true;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateNameColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("e01c8a80-e47b-8bb4-5fcf-7a64dd6abb3e")) == null) {
				Columns.Add(CreateSegmentDataTableNameColumn());
			}
			if (Columns.FindByUId(new Guid("cce38b97-2cfa-9efe-154f-1e71b273e651")) == null) {
				Columns.Add(CreateSysStatusColumn());
			}
			if (Columns.FindByUId(new Guid("8eb3d9ba-4213-f828-489d-2443ecc8a326")) == null) {
				Columns.Add(CreateSysRefreshModeColumn());
			}
			if (Columns.FindByUId(new Guid("ea43c428-aeb2-ed8a-406b-49dfea30b942")) == null) {
				Columns.Add(CreateSysExitModeColumn());
			}
			if (Columns.FindByUId(new Guid("3344dc97-dda3-cc47-ae60-fd557755ff49")) == null) {
				Columns.Add(CreateExitFilterDataColumn());
			}
			if (Columns.FindByUId(new Guid("057db8ef-af9c-f4c3-0c2d-e31d0f5513a1")) == null) {
				Columns.Add(CreateEntryFilterDataColumn());
			}
			if (Columns.FindByUId(new Guid("ff1abc3d-48e8-f6a8-0110-4013d3c8821c")) == null) {
				Columns.Add(CreateEntitySchemaColumn());
			}
			if (Columns.FindByUId(new Guid("256a82bf-ff1c-4997-5feb-9d84cd3ae885")) == null) {
				Columns.Add(CreateDescriptionColumn());
			}
			if (Columns.FindByUId(new Guid("485834b0-c526-af5c-8f70-eb52e45803f5")) == null) {
				Columns.Add(CreateSysUserStatusColumn());
			}
			if (Columns.FindByUId(new Guid("28f66e93-9862-45b0-0da4-c1b4cb0c723b")) == null) {
				Columns.Add(CreateRecordCountColumn());
			}
			if (Columns.FindByUId(new Guid("4d1ad1a6-de82-5669-6fed-85a97494ce54")) == null) {
				Columns.Add(CreateLastActualizationDurationColumn());
			}
			if (Columns.FindByUId(new Guid("ef8a31e0-c251-f2b4-4ce6-11feb1d6c385")) == null) {
				Columns.Add(CreateLastActualizationDateColumn());
			}
			if (Columns.FindByUId(new Guid("8b141276-29e5-f74b-b0e7-26b08a35a8e5")) == null) {
				Columns.Add(CreateLastActualizationErrorColumn());
			}
			if (Columns.FindByUId(new Guid("71319587-008e-26b5-769f-8caf6e89e8ff")) == null) {
				Columns.Add(CreateIsUsableWhileUpdatingColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.IsTrackChangesInDB = true;
			column.ModifiedInSchemaUId = new Guid("91cb9657-9d75-4e75-ac6c-4704630636db");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.IsTrackChangesInDB = true;
			column.ModifiedInSchemaUId = new Guid("91cb9657-9d75-4e75-ac6c-4704630636db");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.IsTrackChangesInDB = true;
			column.ModifiedInSchemaUId = new Guid("91cb9657-9d75-4e75-ac6c-4704630636db");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.IsTrackChangesInDB = true;
			column.ModifiedInSchemaUId = new Guid("91cb9657-9d75-4e75-ac6c-4704630636db");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.IsTrackChangesInDB = true;
			column.ModifiedInSchemaUId = new Guid("91cb9657-9d75-4e75-ac6c-4704630636db");
			return column;
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("2835a0ce-d53f-4c6c-8f4c-921ea7746d35"),
				Name = @"Name",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("91cb9657-9d75-4e75-ac6c-4704630636db"),
				ModifiedInSchemaUId = new Guid("91cb9657-9d75-4e75-ac6c-4704630636db"),
				CreatedInPackageId = new Guid("6f71e54c-1960-40c9-94f6-073fd67699ab"),
				IsTrackChangesInDB = true,
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateSegmentDataTableNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("e01c8a80-e47b-8bb4-5fcf-7a64dd6abb3e"),
				Name = @"SegmentDataTableName",
				CreatedInSchemaUId = new Guid("91cb9657-9d75-4e75-ac6c-4704630636db"),
				ModifiedInSchemaUId = new Guid("91cb9657-9d75-4e75-ac6c-4704630636db"),
				CreatedInPackageId = new Guid("e977f9d9-4739-4382-993f-c704e8026345"),
				IsTrackChangesInDB = true
			};
		}

		protected virtual EntitySchemaColumn CreateSysStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("cce38b97-2cfa-9efe-154f-1e71b273e651"),
				Name = @"SysStatus",
				ReferenceSchemaUId = new Guid("4d8e6e3c-2e7b-4eff-8636-f0eda136eba2"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("91cb9657-9d75-4e75-ac6c-4704630636db"),
				ModifiedInSchemaUId = new Guid("91cb9657-9d75-4e75-ac6c-4704630636db"),
				CreatedInPackageId = new Guid("e977f9d9-4739-4382-993f-c704e8026345"),
				IsSimpleLookup = true,
				IsTrackChangesInDB = true,
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"831af280-4c6a-4a2a-a800-92a54e3f683a"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateSysRefreshModeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("8eb3d9ba-4213-f828-489d-2443ecc8a326"),
				Name = @"SysRefreshMode",
				ReferenceSchemaUId = new Guid("ffc2da14-9e8b-4518-95c8-eb0d7a2b98f8"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("91cb9657-9d75-4e75-ac6c-4704630636db"),
				ModifiedInSchemaUId = new Guid("91cb9657-9d75-4e75-ac6c-4704630636db"),
				CreatedInPackageId = new Guid("e977f9d9-4739-4382-993f-c704e8026345"),
				IsSimpleLookup = true,
				IsTrackChangesInDB = true,
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"784b7c0d-29dd-4868-a0df-fa026730820b"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateSysExitModeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ea43c428-aeb2-ed8a-406b-49dfea30b942"),
				Name = @"SysExitMode",
				ReferenceSchemaUId = new Guid("0c32ec6c-943c-472f-ba68-e3dee139a524"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("91cb9657-9d75-4e75-ac6c-4704630636db"),
				ModifiedInSchemaUId = new Guid("91cb9657-9d75-4e75-ac6c-4704630636db"),
				CreatedInPackageId = new Guid("e977f9d9-4739-4382-993f-c704e8026345"),
				IsSimpleLookup = true,
				IsTrackChangesInDB = true,
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"2766f77a-f64c-4dce-b539-e7fc03212a87"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateExitFilterDataColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("3344dc97-dda3-cc47-ae60-fd557755ff49"),
				Name = @"ExitFilterData",
				CreatedInSchemaUId = new Guid("91cb9657-9d75-4e75-ac6c-4704630636db"),
				ModifiedInSchemaUId = new Guid("91cb9657-9d75-4e75-ac6c-4704630636db"),
				CreatedInPackageId = new Guid("e977f9d9-4739-4382-993f-c704e8026345"),
				IsMultiLineText = true,
				IsTrackChangesInDB = true
			};
		}

		protected virtual EntitySchemaColumn CreateEntryFilterDataColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("057db8ef-af9c-f4c3-0c2d-e31d0f5513a1"),
				Name = @"EntryFilterData",
				CreatedInSchemaUId = new Guid("91cb9657-9d75-4e75-ac6c-4704630636db"),
				ModifiedInSchemaUId = new Guid("91cb9657-9d75-4e75-ac6c-4704630636db"),
				CreatedInPackageId = new Guid("e977f9d9-4739-4382-993f-c704e8026345"),
				IsMultiLineText = true,
				IsTrackChangesInDB = true
			};
		}

		protected virtual EntitySchemaColumn CreateEntitySchemaColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ff1abc3d-48e8-f6a8-0110-4013d3c8821c"),
				Name = @"EntitySchema",
				ReferenceSchemaUId = new Guid("c82db13a-7f77-4085-b3ef-91c5420fd417"),
				IsIndexed = true,
				IsWeakReference = true,
				CreatedInSchemaUId = new Guid("91cb9657-9d75-4e75-ac6c-4704630636db"),
				ModifiedInSchemaUId = new Guid("91cb9657-9d75-4e75-ac6c-4704630636db"),
				CreatedInPackageId = new Guid("e977f9d9-4739-4382-993f-c704e8026345"),
				IsSimpleLookup = true,
				IsTrackChangesInDB = true,
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"16be3651-8fe2-4159-8dd0-a803d4683dd3"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateDescriptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("256a82bf-ff1c-4997-5feb-9d84cd3ae885"),
				Name = @"Description",
				CreatedInSchemaUId = new Guid("91cb9657-9d75-4e75-ac6c-4704630636db"),
				ModifiedInSchemaUId = new Guid("91cb9657-9d75-4e75-ac6c-4704630636db"),
				CreatedInPackageId = new Guid("e977f9d9-4739-4382-993f-c704e8026345"),
				IsMultiLineText = true,
				IsTrackChangesInDB = true,
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateSysUserStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("485834b0-c526-af5c-8f70-eb52e45803f5"),
				Name = @"SysUserStatus",
				ReferenceSchemaUId = new Guid("3eeed09c-3a42-47f0-81fa-b37973bcb342"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("91cb9657-9d75-4e75-ac6c-4704630636db"),
				ModifiedInSchemaUId = new Guid("91cb9657-9d75-4e75-ac6c-4704630636db"),
				CreatedInPackageId = new Guid("bc787634-383d-40bd-9054-9c3505b00b85"),
				IsSimpleLookup = true,
				IsTrackChangesInDB = true,
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"08f98887-eacc-4510-8d94-648f8f5d5f2f"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateRecordCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("28f66e93-9862-45b0-0da4-c1b4cb0c723b"),
				Name = @"RecordCount",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("91cb9657-9d75-4e75-ac6c-4704630636db"),
				ModifiedInSchemaUId = new Guid("91cb9657-9d75-4e75-ac6c-4704630636db"),
				CreatedInPackageId = new Guid("bc787634-383d-40bd-9054-9c3505b00b85"),
				IsTrackChangesInDB = true
			};
		}

		protected virtual EntitySchemaColumn CreateLastActualizationDurationColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("4d1ad1a6-de82-5669-6fed-85a97494ce54"),
				Name = @"LastActualizationDuration",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("91cb9657-9d75-4e75-ac6c-4704630636db"),
				ModifiedInSchemaUId = new Guid("91cb9657-9d75-4e75-ac6c-4704630636db"),
				CreatedInPackageId = new Guid("bc787634-383d-40bd-9054-9c3505b00b85"),
				IsTrackChangesInDB = true
			};
		}

		protected virtual EntitySchemaColumn CreateLastActualizationDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("ef8a31e0-c251-f2b4-4ce6-11feb1d6c385"),
				Name = @"LastActualizationDate",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("91cb9657-9d75-4e75-ac6c-4704630636db"),
				ModifiedInSchemaUId = new Guid("91cb9657-9d75-4e75-ac6c-4704630636db"),
				CreatedInPackageId = new Guid("bc787634-383d-40bd-9054-9c3505b00b85"),
				IsTrackChangesInDB = true
			};
		}

		protected virtual EntitySchemaColumn CreateLastActualizationErrorColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("8b141276-29e5-f74b-b0e7-26b08a35a8e5"),
				Name = @"LastActualizationError",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("91cb9657-9d75-4e75-ac6c-4704630636db"),
				ModifiedInSchemaUId = new Guid("91cb9657-9d75-4e75-ac6c-4704630636db"),
				CreatedInPackageId = new Guid("8215d77a-263e-4d23-a383-2960c4f89ac7"),
				IsMultiLineText = true,
				IsTrackChangesInDB = true
			};
		}

		protected virtual EntitySchemaColumn CreateIsUsableWhileUpdatingColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("71319587-008e-26b5-769f-8caf6e89e8ff"),
				Name = @"IsUsableWhileUpdating",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("91cb9657-9d75-4e75-ac6c-4704630636db"),
				ModifiedInSchemaUId = new Guid("91cb9657-9d75-4e75-ac6c-4704630636db"),
				CreatedInPackageId = new Guid("c78a5285-2fa3-44be-a154-e5273104b42a"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"False"
				}
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIX_Name_UniqueIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysDataSegment(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysDataSegment_CrtSegmentationEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysDataSegmentSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysDataSegmentSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("91cb9657-9d75-4e75-ac6c-4704630636db"));
		}

		#endregion

	}

	#endregion

	#region Class: SysDataSegment

	/// <summary>
	/// Segments.
	/// </summary>
	public class SysDataSegment : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysDataSegment(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysDataSegment";
		}

		public SysDataSegment(SysDataSegment source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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
		/// Segment data table name.
		/// </summary>
		public string SegmentDataTableName {
			get {
				return GetTypedColumnValue<string>("SegmentDataTableName");
			}
			set {
				SetColumnValue("SegmentDataTableName", value);
			}
		}

		/// <exclude/>
		public Guid SysStatusId {
			get {
				return GetTypedColumnValue<Guid>("SysStatusId");
			}
			set {
				SetColumnValue("SysStatusId", value);
				_sysStatus = null;
			}
		}

		/// <exclude/>
		public string SysStatusName {
			get {
				return GetTypedColumnValue<string>("SysStatusName");
			}
			set {
				SetColumnValue("SysStatusName", value);
				if (_sysStatus != null) {
					_sysStatus.Name = value;
				}
			}
		}

		private SysSegmentSystemStatus _sysStatus;
		/// <summary>
		/// Population status.
		/// </summary>
		public SysSegmentSystemStatus SysStatus {
			get {
				return _sysStatus ??
					(_sysStatus = LookupColumnEntities.GetEntity("SysStatus") as SysSegmentSystemStatus);
			}
		}

		/// <exclude/>
		public Guid SysRefreshModeId {
			get {
				return GetTypedColumnValue<Guid>("SysRefreshModeId");
			}
			set {
				SetColumnValue("SysRefreshModeId", value);
				_sysRefreshMode = null;
			}
		}

		/// <exclude/>
		public string SysRefreshModeName {
			get {
				return GetTypedColumnValue<string>("SysRefreshModeName");
			}
			set {
				SetColumnValue("SysRefreshModeName", value);
				if (_sysRefreshMode != null) {
					_sysRefreshMode.Name = value;
				}
			}
		}

		private SysSegmentRefreshMode _sysRefreshMode;
		/// <summary>
		/// Population mode.
		/// </summary>
		public SysSegmentRefreshMode SysRefreshMode {
			get {
				return _sysRefreshMode ??
					(_sysRefreshMode = LookupColumnEntities.GetEntity("SysRefreshMode") as SysSegmentRefreshMode);
			}
		}

		/// <exclude/>
		public Guid SysExitModeId {
			get {
				return GetTypedColumnValue<Guid>("SysExitModeId");
			}
			set {
				SetColumnValue("SysExitModeId", value);
				_sysExitMode = null;
			}
		}

		/// <exclude/>
		public string SysExitModeName {
			get {
				return GetTypedColumnValue<string>("SysExitModeName");
			}
			set {
				SetColumnValue("SysExitModeName", value);
				if (_sysExitMode != null) {
					_sysExitMode.Name = value;
				}
			}
		}

		private SysSegmentExitMode _sysExitMode;
		/// <summary>
		/// Exit strategy.
		/// </summary>
		public SysSegmentExitMode SysExitMode {
			get {
				return _sysExitMode ??
					(_sysExitMode = LookupColumnEntities.GetEntity("SysExitMode") as SysSegmentExitMode);
			}
		}

		/// <summary>
		/// Exit filter data.
		/// </summary>
		public string ExitFilterData {
			get {
				return GetTypedColumnValue<string>("ExitFilterData");
			}
			set {
				SetColumnValue("ExitFilterData", value);
			}
		}

		/// <summary>
		/// Entry filter data.
		/// </summary>
		public string EntryFilterData {
			get {
				return GetTypedColumnValue<string>("EntryFilterData");
			}
			set {
				SetColumnValue("EntryFilterData", value);
			}
		}

		/// <exclude/>
		public Guid EntitySchemaId {
			get {
				return GetTypedColumnValue<Guid>("EntitySchemaId");
			}
			set {
				SetColumnValue("EntitySchemaId", value);
				_entitySchema = null;
			}
		}

		/// <exclude/>
		public string EntitySchemaTitle {
			get {
				return GetTypedColumnValue<string>("EntitySchemaTitle");
			}
			set {
				SetColumnValue("EntitySchemaTitle", value);
				if (_entitySchema != null) {
					_entitySchema.Title = value;
				}
			}
		}

		private VwEntityObjects _entitySchema;
		/// <summary>
		/// Segment of.
		/// </summary>
		public VwEntityObjects EntitySchema {
			get {
				return _entitySchema ??
					(_entitySchema = LookupColumnEntities.GetEntity("EntitySchema") as VwEntityObjects);
			}
		}

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

		/// <exclude/>
		public Guid SysUserStatusId {
			get {
				return GetTypedColumnValue<Guid>("SysUserStatusId");
			}
			set {
				SetColumnValue("SysUserStatusId", value);
				_sysUserStatus = null;
			}
		}

		/// <exclude/>
		public string SysUserStatusName {
			get {
				return GetTypedColumnValue<string>("SysUserStatusName");
			}
			set {
				SetColumnValue("SysUserStatusName", value);
				if (_sysUserStatus != null) {
					_sysUserStatus.Name = value;
				}
			}
		}

		private SysSegmentUserStatus _sysUserStatus;
		/// <summary>
		/// Segment status.
		/// </summary>
		public SysSegmentUserStatus SysUserStatus {
			get {
				return _sysUserStatus ??
					(_sysUserStatus = LookupColumnEntities.GetEntity("SysUserStatus") as SysSegmentUserStatus);
			}
		}

		/// <summary>
		/// Current contacts.
		/// </summary>
		public int RecordCount {
			get {
				return GetTypedColumnValue<int>("RecordCount");
			}
			set {
				SetColumnValue("RecordCount", value);
			}
		}

		/// <summary>
		/// Last actualization duration (sec).
		/// </summary>
		public int LastActualizationDuration {
			get {
				return GetTypedColumnValue<int>("LastActualizationDuration");
			}
			set {
				SetColumnValue("LastActualizationDuration", value);
			}
		}

		/// <summary>
		/// Updated.
		/// </summary>
		public DateTime LastActualizationDate {
			get {
				return GetTypedColumnValue<DateTime>("LastActualizationDate");
			}
			set {
				SetColumnValue("LastActualizationDate", value);
			}
		}

		/// <summary>
		/// Last actualization error.
		/// </summary>
		public string LastActualizationError {
			get {
				return GetTypedColumnValue<string>("LastActualizationError");
			}
			set {
				SetColumnValue("LastActualizationError", value);
			}
		}

		/// <summary>
		/// Is usable while updating.
		/// </summary>
		public bool IsUsableWhileUpdating {
			get {
				return GetTypedColumnValue<bool>("IsUsableWhileUpdating");
			}
			set {
				SetColumnValue("IsUsableWhileUpdating", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysDataSegment_CrtSegmentationEventsProcess(UserConnection);
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
			return new SysDataSegment(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysDataSegment_CrtSegmentationEventsProcess

	/// <exclude/>
	public partial class SysDataSegment_CrtSegmentationEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysDataSegment
	{

		public SysDataSegment_CrtSegmentationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysDataSegment_CrtSegmentationEventsProcess";
			SchemaUId = new Guid("91cb9657-9d75-4e75-ac6c-4704630636db");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("91cb9657-9d75-4e75-ac6c-4704630636db");
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

	#region Class: SysDataSegment_CrtSegmentationEventsProcess

	/// <exclude/>
	public class SysDataSegment_CrtSegmentationEventsProcess : SysDataSegment_CrtSegmentationEventsProcess<SysDataSegment>
	{

		public SysDataSegment_CrtSegmentationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysDataSegment_CrtSegmentationEventsProcess

	public partial class SysDataSegment_CrtSegmentationEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysDataSegmentEventsProcess

	/// <exclude/>
	public class SysDataSegmentEventsProcess : SysDataSegment_CrtSegmentationEventsProcess
	{

		public SysDataSegmentEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

