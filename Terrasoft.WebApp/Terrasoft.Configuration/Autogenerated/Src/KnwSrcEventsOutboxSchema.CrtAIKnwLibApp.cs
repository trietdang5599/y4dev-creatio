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

	#region Class: KnwSrcEventsOutboxSchema

	/// <exclude/>
	public class KnwSrcEventsOutboxSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public KnwSrcEventsOutboxSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public KnwSrcEventsOutboxSchema(KnwSrcEventsOutboxSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public KnwSrcEventsOutboxSchema(KnwSrcEventsOutboxSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateProcessedIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("9bf4f30e-9a82-9632-a71d-588a99655d9c");
			index.Name = "Processed";
			index.CreatedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			index.ModifiedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			index.CreatedInPackageId = new Guid("3be5e65e-165e-4f2d-ba35-079adc9edce0");
			EntitySchemaIndexColumn processedOnIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("178e4ee9-4e2b-001d-dc8d-7b73c8b22748"),
				ColumnUId = new Guid("b54c0175-7a3b-ab7e-c98f-a9c533cb794c"),
				CreatedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				ModifiedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				CreatedInPackageId = new Guid("3be5e65e-165e-4f2d-ba35-079adc9edce0"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(processedOnIndexColumn);
			EntitySchemaIndexColumn isProcessedIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("b955a617-b605-328f-1c14-baeab8a9c981"),
				ColumnUId = new Guid("12135fb4-770d-61b3-867b-1655e0e5f8a8"),
				CreatedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				ModifiedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				CreatedInPackageId = new Guid("3be5e65e-165e-4f2d-ba35-079adc9edce0"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(isProcessedIndexColumn);
			return index;
		}

		private EntitySchemaIndex CreateNextAttemptWithLeaseIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("962d0684-06e2-4fef-81a2-14d1a896cb4c");
			index.Name = "NextAttemptWithLease";
			index.CreatedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			index.ModifiedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			index.CreatedInPackageId = new Guid("3be5e65e-165e-4f2d-ba35-079adc9edce0");
			EntitySchemaIndexColumn leaseUntilIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("2f52a385-6053-85e8-fda9-8fc5e15ebf3f"),
				ColumnUId = new Guid("2972ac93-3b49-a21c-3380-0fe27fb6f868"),
				CreatedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				ModifiedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				CreatedInPackageId = new Guid("3be5e65e-165e-4f2d-ba35-079adc9edce0"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(leaseUntilIndexColumn);
			EntitySchemaIndexColumn nextAttemptOnIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("0492ca87-e2ab-caad-3c3e-dcab9042a499"),
				ColumnUId = new Guid("22776337-4d50-48e7-b368-667a6531f3a7"),
				CreatedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				ModifiedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				CreatedInPackageId = new Guid("3be5e65e-165e-4f2d-ba35-079adc9edce0"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(nextAttemptOnIndexColumn);
			EntitySchemaIndexColumn isProcessedIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("f9ad7cbe-2a59-6d81-969f-cd7ac60106a9"),
				ColumnUId = new Guid("12135fb4-770d-61b3-867b-1655e0e5f8a8"),
				CreatedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				ModifiedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				CreatedInPackageId = new Guid("3be5e65e-165e-4f2d-ba35-079adc9edce0"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(isProcessedIndexColumn);
			return index;
		}

		private EntitySchemaIndex CreateKnwSourceRecordUniqueIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = true
			};
			index.UId = new Guid("f398910b-fb1f-4bb4-87e7-d0cf6a24f6da");
			index.Name = "KnwSourceRecordUnique";
			index.CreatedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			index.ModifiedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			index.CreatedInPackageId = new Guid("3be5e65e-165e-4f2d-ba35-079adc9edce0");
			EntitySchemaIndexColumn knwSourceIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("93e1881e-5b52-4245-9f32-e6b07767a1c8"),
				ColumnUId = new Guid("53e5948c-f846-3828-ab96-ab9d8cec1777"),
				CreatedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				ModifiedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				CreatedInPackageId = new Guid("3be5e65e-165e-4f2d-ba35-079adc9edce0"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(knwSourceIdIndexColumn);
			EntitySchemaIndexColumn recordIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("30114a32-b130-45e9-9818-1432b46ec6d0"),
				ColumnUId = new Guid("6ff8dc8f-f1c6-1357-abfb-cf4a819e35cc"),
				CreatedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				ModifiedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				CreatedInPackageId = new Guid("3be5e65e-165e-4f2d-ba35-079adc9edce0"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(recordIdIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("65ce22be-a558-4598-ba6c-aa5594895fae");
			RealUId = new Guid("65ce22be-a558-4598-ba6c-aa5594895fae");
			Name = "KnwSrcEventsOutbox";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("3be5e65e-165e-4f2d-ba35-079adc9edce0");
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

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("5714f40c-9135-a6ed-e748-49404780daa2")) == null) {
				Columns.Add(CreateProcessingTokenColumn());
			}
			if (Columns.FindByUId(new Guid("2972ac93-3b49-a21c-3380-0fe27fb6f868")) == null) {
				Columns.Add(CreateLeaseUntilColumn());
			}
			if (Columns.FindByUId(new Guid("22776337-4d50-48e7-b368-667a6531f3a7")) == null) {
				Columns.Add(CreateNextAttemptOnColumn());
			}
			if (Columns.FindByUId(new Guid("f73119e5-fcca-b83a-b688-b93d83b05555")) == null) {
				Columns.Add(CreateLastErrorColumn());
			}
			if (Columns.FindByUId(new Guid("58322d4c-c891-acf5-e1f1-be602bc019a5")) == null) {
				Columns.Add(CreateAttemptsColumn());
			}
			if (Columns.FindByUId(new Guid("b54c0175-7a3b-ab7e-c98f-a9c533cb794c")) == null) {
				Columns.Add(CreateProcessedOnColumn());
			}
			if (Columns.FindByUId(new Guid("f24cadf9-8f7e-48a4-b381-b0a2c3f09bc6")) == null) {
				Columns.Add(CreateDeadLetteredOnColumn());
			}
			if (Columns.FindByUId(new Guid("12135fb4-770d-61b3-867b-1655e0e5f8a8")) == null) {
				Columns.Add(CreateIsProcessedColumn());
			}
			if (Columns.FindByUId(new Guid("2e0292d1-4628-6e54-0e83-35a171948ab0")) == null) {
				Columns.Add(CreateEventOnColumn());
			}
			if (Columns.FindByUId(new Guid("f18d0f9d-33c9-673c-ae47-2362ba9824a5")) == null) {
				Columns.Add(CreateChangedColumnsColumn());
			}
			if (Columns.FindByUId(new Guid("a5f0a060-05f4-a03d-9a9e-ba6b41f76e3b")) == null) {
				Columns.Add(CreateEventTypeColumn());
			}
			if (Columns.FindByUId(new Guid("2b476a67-61f5-91e8-57a7-129dbc8d1de3")) == null) {
				Columns.Add(CreateEntitySchemaUIdColumn());
			}
			if (Columns.FindByUId(new Guid("6ff8dc8f-f1c6-1357-abfb-cf4a819e35cc")) == null) {
				Columns.Add(CreateRecordIdColumn());
			}
			if (Columns.FindByUId(new Guid("53e5948c-f846-3828-ab96-ab9d8cec1777")) == null) {
				Columns.Add(CreateKnwSourceColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateProcessingTokenColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("5714f40c-9135-a6ed-e748-49404780daa2"),
				Name = @"ProcessingToken",
				CreatedInSchemaUId = new Guid("65ce22be-a558-4598-ba6c-aa5594895fae"),
				ModifiedInSchemaUId = new Guid("65ce22be-a558-4598-ba6c-aa5594895fae"),
				CreatedInPackageId = new Guid("3be5e65e-165e-4f2d-ba35-079adc9edce0")
			};
		}

		protected virtual EntitySchemaColumn CreateLeaseUntilColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("2972ac93-3b49-a21c-3380-0fe27fb6f868"),
				Name = @"LeaseUntil",
				CreatedInSchemaUId = new Guid("65ce22be-a558-4598-ba6c-aa5594895fae"),
				ModifiedInSchemaUId = new Guid("65ce22be-a558-4598-ba6c-aa5594895fae"),
				CreatedInPackageId = new Guid("3be5e65e-165e-4f2d-ba35-079adc9edce0")
			};
		}

		protected virtual EntitySchemaColumn CreateNextAttemptOnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("22776337-4d50-48e7-b368-667a6531f3a7"),
				Name = @"NextAttemptOn",
				CreatedInSchemaUId = new Guid("65ce22be-a558-4598-ba6c-aa5594895fae"),
				ModifiedInSchemaUId = new Guid("65ce22be-a558-4598-ba6c-aa5594895fae"),
				CreatedInPackageId = new Guid("3be5e65e-165e-4f2d-ba35-079adc9edce0")
			};
		}

		protected virtual EntitySchemaColumn CreateLastErrorColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("f73119e5-fcca-b83a-b688-b93d83b05555"),
				Name = @"LastError",
				CreatedInSchemaUId = new Guid("65ce22be-a558-4598-ba6c-aa5594895fae"),
				ModifiedInSchemaUId = new Guid("65ce22be-a558-4598-ba6c-aa5594895fae"),
				CreatedInPackageId = new Guid("3be5e65e-165e-4f2d-ba35-079adc9edce0")
			};
		}

		protected virtual EntitySchemaColumn CreateAttemptsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("58322d4c-c891-acf5-e1f1-be602bc019a5"),
				Name = @"Attempts",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("65ce22be-a558-4598-ba6c-aa5594895fae"),
				ModifiedInSchemaUId = new Guid("65ce22be-a558-4598-ba6c-aa5594895fae"),
				CreatedInPackageId = new Guid("3be5e65e-165e-4f2d-ba35-079adc9edce0"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"0"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateProcessedOnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("b54c0175-7a3b-ab7e-c98f-a9c533cb794c"),
				Name = @"ProcessedOn",
				CreatedInSchemaUId = new Guid("65ce22be-a558-4598-ba6c-aa5594895fae"),
				ModifiedInSchemaUId = new Guid("65ce22be-a558-4598-ba6c-aa5594895fae"),
				CreatedInPackageId = new Guid("3be5e65e-165e-4f2d-ba35-079adc9edce0")
			};
		}

		protected virtual EntitySchemaColumn CreateDeadLetteredOnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("f24cadf9-8f7e-48a4-b381-b0a2c3f09bc6"),
				Name = @"DeadLetteredOn",
				CreatedInSchemaUId = new Guid("65ce22be-a558-4598-ba6c-aa5594895fae"),
				ModifiedInSchemaUId = new Guid("65ce22be-a558-4598-ba6c-aa5594895fae"),
				CreatedInPackageId = new Guid("3be5e65e-165e-4f2d-ba35-079adc9edce0")
			};
		}

		protected virtual EntitySchemaColumn CreateIsProcessedColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("12135fb4-770d-61b3-867b-1655e0e5f8a8"),
				Name = @"IsProcessed",
				CreatedInSchemaUId = new Guid("65ce22be-a558-4598-ba6c-aa5594895fae"),
				ModifiedInSchemaUId = new Guid("65ce22be-a558-4598-ba6c-aa5594895fae"),
				CreatedInPackageId = new Guid("3be5e65e-165e-4f2d-ba35-079adc9edce0"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"False"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateEventOnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("2e0292d1-4628-6e54-0e83-35a171948ab0"),
				Name = @"EventOn",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("65ce22be-a558-4598-ba6c-aa5594895fae"),
				ModifiedInSchemaUId = new Guid("65ce22be-a558-4598-ba6c-aa5594895fae"),
				CreatedInPackageId = new Guid("3be5e65e-165e-4f2d-ba35-079adc9edce0")
			};
		}

		protected virtual EntitySchemaColumn CreateChangedColumnsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("f18d0f9d-33c9-673c-ae47-2362ba9824a5"),
				Name = @"ChangedColumns",
				CreatedInSchemaUId = new Guid("65ce22be-a558-4598-ba6c-aa5594895fae"),
				ModifiedInSchemaUId = new Guid("65ce22be-a558-4598-ba6c-aa5594895fae"),
				CreatedInPackageId = new Guid("3be5e65e-165e-4f2d-ba35-079adc9edce0")
			};
		}

		protected virtual EntitySchemaColumn CreateEventTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("a5f0a060-05f4-a03d-9a9e-ba6b41f76e3b"),
				Name = @"EventType",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("65ce22be-a558-4598-ba6c-aa5594895fae"),
				ModifiedInSchemaUId = new Guid("65ce22be-a558-4598-ba6c-aa5594895fae"),
				CreatedInPackageId = new Guid("3be5e65e-165e-4f2d-ba35-079adc9edce0")
			};
		}

		protected virtual EntitySchemaColumn CreateEntitySchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("2b476a67-61f5-91e8-57a7-129dbc8d1de3"),
				Name = @"EntitySchemaUId",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("65ce22be-a558-4598-ba6c-aa5594895fae"),
				ModifiedInSchemaUId = new Guid("65ce22be-a558-4598-ba6c-aa5594895fae"),
				CreatedInPackageId = new Guid("3be5e65e-165e-4f2d-ba35-079adc9edce0")
			};
		}

		protected virtual EntitySchemaColumn CreateRecordIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("6ff8dc8f-f1c6-1357-abfb-cf4a819e35cc"),
				Name = @"RecordId",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("65ce22be-a558-4598-ba6c-aa5594895fae"),
				ModifiedInSchemaUId = new Guid("65ce22be-a558-4598-ba6c-aa5594895fae"),
				CreatedInPackageId = new Guid("3be5e65e-165e-4f2d-ba35-079adc9edce0")
			};
		}

		protected virtual EntitySchemaColumn CreateKnwSourceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("53e5948c-f846-3828-ab96-ab9d8cec1777"),
				Name = @"KnwSource",
				ReferenceSchemaUId = new Guid("6ec4827f-1e9a-4077-8c37-b7e97686fb92"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("65ce22be-a558-4598-ba6c-aa5594895fae"),
				ModifiedInSchemaUId = new Guid("65ce22be-a558-4598-ba6c-aa5594895fae"),
				CreatedInPackageId = new Guid("3be5e65e-165e-4f2d-ba35-079adc9edce0"),
				IsSimpleLookup = true
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateProcessedIndex());
			Indexes.Add(CreateNextAttemptWithLeaseIndex());
			Indexes.Add(CreateKnwSourceRecordUniqueIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new KnwSrcEventsOutbox(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new KnwSrcEventsOutbox_CrtAIKnwLibAppEventsProcess(userConnection);
		}

		public override object Clone() {
			return new KnwSrcEventsOutboxSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new KnwSrcEventsOutboxSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("65ce22be-a558-4598-ba6c-aa5594895fae"));
		}

		#endregion

	}

	#endregion

	#region Class: KnwSrcEventsOutbox

	/// <summary>
	/// KnwSrcEventsOutbox.
	/// </summary>
	public class KnwSrcEventsOutbox : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public KnwSrcEventsOutbox(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "KnwSrcEventsOutbox";
		}

		public KnwSrcEventsOutbox(KnwSrcEventsOutbox source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// ProcessingToken.
		/// </summary>
		public string ProcessingToken {
			get {
				return GetTypedColumnValue<string>("ProcessingToken");
			}
			set {
				SetColumnValue("ProcessingToken", value);
			}
		}

		/// <summary>
		/// LeaseUntil.
		/// </summary>
		public DateTime LeaseUntil {
			get {
				return GetTypedColumnValue<DateTime>("LeaseUntil");
			}
			set {
				SetColumnValue("LeaseUntil", value);
			}
		}

		/// <summary>
		/// NextAttemptOn.
		/// </summary>
		public DateTime NextAttemptOn {
			get {
				return GetTypedColumnValue<DateTime>("NextAttemptOn");
			}
			set {
				SetColumnValue("NextAttemptOn", value);
			}
		}

		/// <summary>
		/// LastError.
		/// </summary>
		public string LastError {
			get {
				return GetTypedColumnValue<string>("LastError");
			}
			set {
				SetColumnValue("LastError", value);
			}
		}

		/// <summary>
		/// Attempts.
		/// </summary>
		public int Attempts {
			get {
				return GetTypedColumnValue<int>("Attempts");
			}
			set {
				SetColumnValue("Attempts", value);
			}
		}

		/// <summary>
		/// ProcessedOn.
		/// </summary>
		public DateTime ProcessedOn {
			get {
				return GetTypedColumnValue<DateTime>("ProcessedOn");
			}
			set {
				SetColumnValue("ProcessedOn", value);
			}
		}

		/// <summary>
		/// DeadLetteredOn.
		/// </summary>
		public DateTime DeadLetteredOn {
			get {
				return GetTypedColumnValue<DateTime>("DeadLetteredOn");
			}
			set {
				SetColumnValue("DeadLetteredOn", value);
			}
		}

		/// <summary>
		/// IsProcessed.
		/// </summary>
		public bool IsProcessed {
			get {
				return GetTypedColumnValue<bool>("IsProcessed");
			}
			set {
				SetColumnValue("IsProcessed", value);
			}
		}

		/// <summary>
		/// EventOn.
		/// </summary>
		public DateTime EventOn {
			get {
				return GetTypedColumnValue<DateTime>("EventOn");
			}
			set {
				SetColumnValue("EventOn", value);
			}
		}

		/// <summary>
		/// ChangedColumns.
		/// </summary>
		public string ChangedColumns {
			get {
				return GetTypedColumnValue<string>("ChangedColumns");
			}
			set {
				SetColumnValue("ChangedColumns", value);
			}
		}

		/// <summary>
		/// EventType.
		/// </summary>
		public int EventType {
			get {
				return GetTypedColumnValue<int>("EventType");
			}
			set {
				SetColumnValue("EventType", value);
			}
		}

		/// <summary>
		/// EntitySchemaUId.
		/// </summary>
		public Guid EntitySchemaUId {
			get {
				return GetTypedColumnValue<Guid>("EntitySchemaUId");
			}
			set {
				SetColumnValue("EntitySchemaUId", value);
			}
		}

		/// <summary>
		/// RecordId.
		/// </summary>
		public Guid RecordId {
			get {
				return GetTypedColumnValue<Guid>("RecordId");
			}
			set {
				SetColumnValue("RecordId", value);
			}
		}

		/// <exclude/>
		public Guid KnwSourceId {
			get {
				return GetTypedColumnValue<Guid>("KnwSourceId");
			}
			set {
				SetColumnValue("KnwSourceId", value);
				_knwSource = null;
			}
		}

		/// <exclude/>
		public string KnwSourceName {
			get {
				return GetTypedColumnValue<string>("KnwSourceName");
			}
			set {
				SetColumnValue("KnwSourceName", value);
				if (_knwSource != null) {
					_knwSource.Name = value;
				}
			}
		}

		private KnwSource _knwSource;
		/// <summary>
		/// KnwSource.
		/// </summary>
		public KnwSource KnwSource {
			get {
				return _knwSource ??
					(_knwSource = LookupColumnEntities.GetEntity("KnwSource") as KnwSource);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new KnwSrcEventsOutbox_CrtAIKnwLibAppEventsProcess(UserConnection);
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
			return new KnwSrcEventsOutbox(this);
		}

		#endregion

	}

	#endregion

	#region Class: KnwSrcEventsOutbox_CrtAIKnwLibAppEventsProcess

	/// <exclude/>
	public partial class KnwSrcEventsOutbox_CrtAIKnwLibAppEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : KnwSrcEventsOutbox
	{

		public KnwSrcEventsOutbox_CrtAIKnwLibAppEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "KnwSrcEventsOutbox_CrtAIKnwLibAppEventsProcess";
			SchemaUId = new Guid("65ce22be-a558-4598-ba6c-aa5594895fae");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("65ce22be-a558-4598-ba6c-aa5594895fae");
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

	#region Class: KnwSrcEventsOutbox_CrtAIKnwLibAppEventsProcess

	/// <exclude/>
	public class KnwSrcEventsOutbox_CrtAIKnwLibAppEventsProcess : KnwSrcEventsOutbox_CrtAIKnwLibAppEventsProcess<KnwSrcEventsOutbox>
	{

		public KnwSrcEventsOutbox_CrtAIKnwLibAppEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: KnwSrcEventsOutbox_CrtAIKnwLibAppEventsProcess

	public partial class KnwSrcEventsOutbox_CrtAIKnwLibAppEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: KnwSrcEventsOutboxEventsProcess

	/// <exclude/>
	public class KnwSrcEventsOutboxEventsProcess : KnwSrcEventsOutbox_CrtAIKnwLibAppEventsProcess
	{

		public KnwSrcEventsOutboxEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

