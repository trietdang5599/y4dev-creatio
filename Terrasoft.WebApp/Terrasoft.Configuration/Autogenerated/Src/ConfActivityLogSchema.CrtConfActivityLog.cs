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

	#region Class: ConfActivityLogSchema

	/// <exclude/>
	public class ConfActivityLogSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ConfActivityLogSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ConfActivityLogSchema(ConfActivityLogSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ConfActivityLogSchema(ConfActivityLogSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("2fef7560-653b-4502-94c4-943c543803cf");
			RealUId = new Guid("2fef7560-653b-4502-94c4-943c543803cf");
			Name = "ConfActivityLog";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("6f71e54c-1960-40c9-94f6-073fd67699ab");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
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
			PrimaryDisplayColumn = CreateNumberColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("9eb1896d-cfe1-450e-a02a-3111e02bc9a9")) == null) {
				Columns.Add(CreateNameColumn());
			}
			if (Columns.FindByUId(new Guid("3912d7cb-5a97-35a5-64b6-7f5b4aa6271b")) == null) {
				Columns.Add(CreateParentColumn());
			}
			if (Columns.FindByUId(new Guid("87c43412-280f-3497-6dd3-7cb0ad50d278")) == null) {
				Columns.Add(CreateElementColumn());
			}
			if (Columns.FindByUId(new Guid("a9997c37-8516-3bb4-658c-5e6b706cb938")) == null) {
				Columns.Add(CreateStatusColumn());
			}
			if (Columns.FindByUId(new Guid("abe8258b-324d-2583-ce2e-2a11488400b8")) == null) {
				Columns.Add(CreateTypeColumn());
			}
			if (Columns.FindByUId(new Guid("1a2b794a-7a48-52ff-39f8-d2e788568eb9")) == null) {
				Columns.Add(CreateOperationColumn());
			}
			if (Columns.FindByUId(new Guid("f29b9e63-7c05-9b55-67bb-a828e41eed56")) == null) {
				Columns.Add(CreateDescriptionColumn());
			}
			if (Columns.FindByUId(new Guid("c98d1e82-81d1-aa3d-5e8e-1c506c2bb7fa")) == null) {
				Columns.Add(CreateApplicationCodeColumn());
			}
			if (Columns.FindByUId(new Guid("af962d44-5b4a-805b-12f7-039b568901a2")) == null) {
				Columns.Add(CreatePackageNameColumn());
			}
			if (Columns.FindByUId(new Guid("d277e6d7-96e5-488b-76d8-cb10e9eb3ef3")) == null) {
				Columns.Add(CreateDurationInSecondsColumn());
			}
			if (Columns.FindByUId(new Guid("ed1bd81f-b3f0-bd85-ea36-7d4165fe38c5")) == null) {
				Columns.Add(CreateElementUIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("9eb1896d-cfe1-450e-a02a-3111e02bc9a9"),
				Name = @"Name",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("2fef7560-653b-4502-94c4-943c543803cf"),
				ModifiedInSchemaUId = new Guid("2fef7560-653b-4502-94c4-943c543803cf"),
				CreatedInPackageId = new Guid("6f71e54c-1960-40c9-94f6-073fd67699ab")
			};
		}

		protected virtual EntitySchemaColumn CreateParentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("3912d7cb-5a97-35a5-64b6-7f5b4aa6271b"),
				Name = @"Parent",
				ReferenceSchemaUId = new Guid("2fef7560-653b-4502-94c4-943c543803cf"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("2fef7560-653b-4502-94c4-943c543803cf"),
				ModifiedInSchemaUId = new Guid("2fef7560-653b-4502-94c4-943c543803cf"),
				CreatedInPackageId = new Guid("b442e8fe-c84e-419d-bd0d-cf5572b3d3f7"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateElementColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("87c43412-280f-3497-6dd3-7cb0ad50d278"),
				Name = @"Element",
				CreatedInSchemaUId = new Guid("2fef7560-653b-4502-94c4-943c543803cf"),
				ModifiedInSchemaUId = new Guid("2fef7560-653b-4502-94c4-943c543803cf"),
				CreatedInPackageId = new Guid("b442e8fe-c84e-419d-bd0d-cf5572b3d3f7")
			};
		}

		protected virtual EntitySchemaColumn CreateStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("a9997c37-8516-3bb4-658c-5e6b706cb938"),
				Name = @"Status",
				ReferenceSchemaUId = new Guid("5e88ab22-8e77-4bf7-b9cb-1a4ec849776d"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("2fef7560-653b-4502-94c4-943c543803cf"),
				ModifiedInSchemaUId = new Guid("2fef7560-653b-4502-94c4-943c543803cf"),
				CreatedInPackageId = new Guid("b442e8fe-c84e-419d-bd0d-cf5572b3d3f7"),
				IsSimpleLookup = true,
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"0792b021-98d2-4d46-842a-43f954ff8ed6"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("abe8258b-324d-2583-ce2e-2a11488400b8"),
				Name = @"Type",
				ReferenceSchemaUId = new Guid("b4f21ac3-d20a-4817-bdda-9e2a12a5c88e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("2fef7560-653b-4502-94c4-943c543803cf"),
				ModifiedInSchemaUId = new Guid("2fef7560-653b-4502-94c4-943c543803cf"),
				CreatedInPackageId = new Guid("b442e8fe-c84e-419d-bd0d-cf5572b3d3f7"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateNumberColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("0556d4f3-d673-e62a-8fab-7df5055510b0"),
				Name = @"Number",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("2fef7560-653b-4502-94c4-943c543803cf"),
				ModifiedInSchemaUId = new Guid("2fef7560-653b-4502-94c4-943c543803cf"),
				CreatedInPackageId = new Guid("b442e8fe-c84e-419d-bd0d-cf5572b3d3f7"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Sequence,
					SequencePrefix = "LOG-",
					SequenceNumberOfChars = 5
				}
			};
		}

		protected virtual EntitySchemaColumn CreateOperationColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("1a2b794a-7a48-52ff-39f8-d2e788568eb9"),
				Name = @"Operation",
				ReferenceSchemaUId = new Guid("e521e4ec-3aab-48c2-ba42-2223301ef86c"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("2fef7560-653b-4502-94c4-943c543803cf"),
				ModifiedInSchemaUId = new Guid("2fef7560-653b-4502-94c4-943c543803cf"),
				CreatedInPackageId = new Guid("b442e8fe-c84e-419d-bd0d-cf5572b3d3f7"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateDescriptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("RichText")) {
				UId = new Guid("f29b9e63-7c05-9b55-67bb-a828e41eed56"),
				Name = @"Description",
				CreatedInSchemaUId = new Guid("2fef7560-653b-4502-94c4-943c543803cf"),
				ModifiedInSchemaUId = new Guid("2fef7560-653b-4502-94c4-943c543803cf"),
				CreatedInPackageId = new Guid("a5202df4-32a0-4d6d-a11d-f9280bb95b51"),
				IsMultiLineText = true
			};
		}

		protected virtual EntitySchemaColumn CreateApplicationCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("c98d1e82-81d1-aa3d-5e8e-1c506c2bb7fa"),
				Name = @"ApplicationCode",
				CreatedInSchemaUId = new Guid("2fef7560-653b-4502-94c4-943c543803cf"),
				ModifiedInSchemaUId = new Guid("2fef7560-653b-4502-94c4-943c543803cf"),
				CreatedInPackageId = new Guid("a5202df4-32a0-4d6d-a11d-f9280bb95b51")
			};
		}

		protected virtual EntitySchemaColumn CreatePackageNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("af962d44-5b4a-805b-12f7-039b568901a2"),
				Name = @"PackageName",
				CreatedInSchemaUId = new Guid("2fef7560-653b-4502-94c4-943c543803cf"),
				ModifiedInSchemaUId = new Guid("2fef7560-653b-4502-94c4-943c543803cf"),
				CreatedInPackageId = new Guid("a5202df4-32a0-4d6d-a11d-f9280bb95b51")
			};
		}

		protected virtual EntitySchemaColumn CreateDurationInSecondsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float3")) {
				UId = new Guid("d277e6d7-96e5-488b-76d8-cb10e9eb3ef3"),
				Name = @"DurationInSeconds",
				CreatedInSchemaUId = new Guid("2fef7560-653b-4502-94c4-943c543803cf"),
				ModifiedInSchemaUId = new Guid("2fef7560-653b-4502-94c4-943c543803cf"),
				CreatedInPackageId = new Guid("228bb88c-2439-42dc-8012-818f8892ac47")
			};
		}

		protected virtual EntitySchemaColumn CreateElementUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("ed1bd81f-b3f0-bd85-ea36-7d4165fe38c5"),
				Name = @"ElementUId",
				CreatedInSchemaUId = new Guid("2fef7560-653b-4502-94c4-943c543803cf"),
				ModifiedInSchemaUId = new Guid("2fef7560-653b-4502-94c4-943c543803cf"),
				CreatedInPackageId = new Guid("17104062-1bc5-461c-9a50-fbfa7612019c")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ConfActivityLog(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ConfActivityLog_CrtConfActivityLogEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ConfActivityLogSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ConfActivityLogSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2fef7560-653b-4502-94c4-943c543803cf"));
		}

		#endregion

	}

	#endregion

	#region Class: ConfActivityLog

	/// <summary>
	/// Configuration activity log.
	/// </summary>
	public class ConfActivityLog : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ConfActivityLog(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ConfActivityLog";
		}

		public ConfActivityLog(ConfActivityLog source)
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

		/// <exclude/>
		public Guid ParentId {
			get {
				return GetTypedColumnValue<Guid>("ParentId");
			}
			set {
				SetColumnValue("ParentId", value);
				_parent = null;
			}
		}

		/// <exclude/>
		public string ParentNumber {
			get {
				return GetTypedColumnValue<string>("ParentNumber");
			}
			set {
				SetColumnValue("ParentNumber", value);
				if (_parent != null) {
					_parent.Number = value;
				}
			}
		}

		private ConfActivityLog _parent;
		/// <summary>
		/// Parent operation.
		/// </summary>
		public ConfActivityLog Parent {
			get {
				return _parent ??
					(_parent = LookupColumnEntities.GetEntity("Parent") as ConfActivityLog);
			}
		}

		/// <summary>
		/// Element.
		/// </summary>
		public string Element {
			get {
				return GetTypedColumnValue<string>("Element");
			}
			set {
				SetColumnValue("Element", value);
			}
		}

		/// <exclude/>
		public Guid StatusId {
			get {
				return GetTypedColumnValue<Guid>("StatusId");
			}
			set {
				SetColumnValue("StatusId", value);
				_status = null;
			}
		}

		/// <exclude/>
		public string StatusName {
			get {
				return GetTypedColumnValue<string>("StatusName");
			}
			set {
				SetColumnValue("StatusName", value);
				if (_status != null) {
					_status.Name = value;
				}
			}
		}

		private ConfActivityStatus _status;
		/// <summary>
		/// Status.
		/// </summary>
		public ConfActivityStatus Status {
			get {
				return _status ??
					(_status = LookupColumnEntities.GetEntity("Status") as ConfActivityStatus);
			}
		}

		/// <exclude/>
		public Guid TypeId {
			get {
				return GetTypedColumnValue<Guid>("TypeId");
			}
			set {
				SetColumnValue("TypeId", value);
				_type = null;
			}
		}

		/// <exclude/>
		public string TypeName {
			get {
				return GetTypedColumnValue<string>("TypeName");
			}
			set {
				SetColumnValue("TypeName", value);
				if (_type != null) {
					_type.Name = value;
				}
			}
		}

		private ConfElementType _type;
		/// <summary>
		/// Type.
		/// </summary>
		public ConfElementType Type {
			get {
				return _type ??
					(_type = LookupColumnEntities.GetEntity("Type") as ConfElementType);
			}
		}

		/// <summary>
		/// Number.
		/// </summary>
		public string Number {
			get {
				return GetTypedColumnValue<string>("Number");
			}
			set {
				SetColumnValue("Number", value);
			}
		}

		/// <exclude/>
		public Guid OperationId {
			get {
				return GetTypedColumnValue<Guid>("OperationId");
			}
			set {
				SetColumnValue("OperationId", value);
				_operation = null;
			}
		}

		/// <exclude/>
		public string OperationName {
			get {
				return GetTypedColumnValue<string>("OperationName");
			}
			set {
				SetColumnValue("OperationName", value);
				if (_operation != null) {
					_operation.Name = value;
				}
			}
		}

		private ConfOperation _operation;
		/// <summary>
		/// Operation.
		/// </summary>
		public ConfOperation Operation {
			get {
				return _operation ??
					(_operation = LookupColumnEntities.GetEntity("Operation") as ConfOperation);
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

		/// <summary>
		/// Application.
		/// </summary>
		public string ApplicationCode {
			get {
				return GetTypedColumnValue<string>("ApplicationCode");
			}
			set {
				SetColumnValue("ApplicationCode", value);
			}
		}

		/// <summary>
		/// Package.
		/// </summary>
		public string PackageName {
			get {
				return GetTypedColumnValue<string>("PackageName");
			}
			set {
				SetColumnValue("PackageName", value);
			}
		}

		/// <summary>
		/// Duration in seconds.
		/// </summary>
		public Decimal DurationInSeconds {
			get {
				return GetTypedColumnValue<Decimal>("DurationInSeconds");
			}
			set {
				SetColumnValue("DurationInSeconds", value);
			}
		}

		/// <summary>
		/// Element unique identificator.
		/// </summary>
		public Guid ElementUId {
			get {
				return GetTypedColumnValue<Guid>("ElementUId");
			}
			set {
				SetColumnValue("ElementUId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ConfActivityLog_CrtConfActivityLogEventsProcess(UserConnection);
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
			return new ConfActivityLog(this);
		}

		#endregion

	}

	#endregion

	#region Class: ConfActivityLog_CrtConfActivityLogEventsProcess

	/// <exclude/>
	public partial class ConfActivityLog_CrtConfActivityLogEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : ConfActivityLog
	{

		public ConfActivityLog_CrtConfActivityLogEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ConfActivityLog_CrtConfActivityLogEventsProcess";
			SchemaUId = new Guid("2fef7560-653b-4502-94c4-943c543803cf");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("2fef7560-653b-4502-94c4-943c543803cf");
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

	#region Class: ConfActivityLog_CrtConfActivityLogEventsProcess

	/// <exclude/>
	public class ConfActivityLog_CrtConfActivityLogEventsProcess : ConfActivityLog_CrtConfActivityLogEventsProcess<ConfActivityLog>
	{

		public ConfActivityLog_CrtConfActivityLogEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ConfActivityLog_CrtConfActivityLogEventsProcess

	public partial class ConfActivityLog_CrtConfActivityLogEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ConfActivityLogEventsProcess

	/// <exclude/>
	public class ConfActivityLogEventsProcess : ConfActivityLog_CrtConfActivityLogEventsProcess
	{

		public ConfActivityLogEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

