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

	#region Class: NextStepSchema

	/// <exclude/>
	[IsVirtual]
	public class NextStepSchema : Terrasoft.Core.Entities.EntitySchema
	{

		#region Constructors: Public

		public NextStepSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public NextStepSchema(NextStepSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public NextStepSchema(NextStepSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("953be763-691e-4c7c-831d-d7e5318d4715");
			RealUId = new Guid("953be763-691e-4c7c-831d-d7e5318d4715");
			Name = "NextStep";
			ParentSchemaUId = new Guid("1b56b061-4e91-4974-9038-df8340e534f2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("95a133a1-cd5f-4df8-af8f-ad440775d7d1");
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

		protected override void InitializePrimaryColumn() {
			base.InitializePrimaryColumn();
			PrimaryColumn = CreateIdColumn();
			if (Columns.FindByUId(PrimaryColumn.UId) == null) {
				Columns.Add(PrimaryColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("2fadad61-6d22-b8fb-5421-c5e0691a7b03")) == null) {
				Columns.Add(CreateCaptionColumn());
			}
			if (Columns.FindByUId(new Guid("daac6137-0810-d610-b094-41a7764c21d2")) == null) {
				Columns.Add(CreateMasterEntityIdColumn());
			}
			if (Columns.FindByUId(new Guid("29956451-c1e8-4c91-f1b7-2ec8e543cda5")) == null) {
				Columns.Add(CreateEntityNameColumn());
			}
			if (Columns.FindByUId(new Guid("c6495efe-0663-4a94-ded1-9b393a42d62f")) == null) {
				Columns.Add(CreateMasterEntityNameColumn());
			}
			if (Columns.FindByUId(new Guid("18d7018b-5065-e3ec-21ff-3c5cf949bf63")) == null) {
				Columns.Add(CreateIsRequiredColumn());
			}
			if (Columns.FindByUId(new Guid("4998cf58-eac4-bdb0-5ee8-9e5eb8e82d2c")) == null) {
				Columns.Add(CreateProcessElementIdColumn());
			}
			if (Columns.FindByUId(new Guid("8185f764-ad2f-6fea-1093-94e6148e3f1f")) == null) {
				Columns.Add(CreateDateColumn());
			}
			if (Columns.FindByUId(new Guid("651185ea-1e5a-2a48-b58d-506e4a169b01")) == null) {
				Columns.Add(CreateAdditionalInfoColumn());
			}
			if (Columns.FindByUId(new Guid("9eddf217-f666-6bf4-40e6-9b2b5e83019e")) == null) {
				Columns.Add(CreateOwnerColumn());
			}
			if (Columns.FindByUId(new Guid("f484c715-f5a5-e2db-b095-23bb80f811bd")) == null) {
				Columns.Add(CreateIsOwnerRoleColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("3014ab94-afdc-1bab-f2c6-16e8e06a7e67"),
				Name = @"Id",
				CreatedInSchemaUId = new Guid("953be763-691e-4c7c-831d-d7e5318d4715"),
				ModifiedInSchemaUId = new Guid("953be763-691e-4c7c-831d-d7e5318d4715"),
				CreatedInPackageId = new Guid("95a133a1-cd5f-4df8-af8f-ad440775d7d1")
			};
		}

		protected virtual EntitySchemaColumn CreateCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("2fadad61-6d22-b8fb-5421-c5e0691a7b03"),
				Name = @"Caption",
				CreatedInSchemaUId = new Guid("953be763-691e-4c7c-831d-d7e5318d4715"),
				ModifiedInSchemaUId = new Guid("953be763-691e-4c7c-831d-d7e5318d4715"),
				CreatedInPackageId = new Guid("95a133a1-cd5f-4df8-af8f-ad440775d7d1"),
				IsFormatValidated = true
			};
		}

		protected virtual EntitySchemaColumn CreateMasterEntityIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("daac6137-0810-d610-b094-41a7764c21d2"),
				Name = @"MasterEntityId",
				CreatedInSchemaUId = new Guid("953be763-691e-4c7c-831d-d7e5318d4715"),
				ModifiedInSchemaUId = new Guid("953be763-691e-4c7c-831d-d7e5318d4715"),
				CreatedInPackageId = new Guid("95a133a1-cd5f-4df8-af8f-ad440775d7d1")
			};
		}

		protected virtual EntitySchemaColumn CreateEntityNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("29956451-c1e8-4c91-f1b7-2ec8e543cda5"),
				Name = @"EntityName",
				CreatedInSchemaUId = new Guid("953be763-691e-4c7c-831d-d7e5318d4715"),
				ModifiedInSchemaUId = new Guid("953be763-691e-4c7c-831d-d7e5318d4715"),
				CreatedInPackageId = new Guid("a39f3d79-3277-4890-a39e-707c83f6a851"),
				IsFormatValidated = true
			};
		}

		protected virtual EntitySchemaColumn CreateMasterEntityNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("c6495efe-0663-4a94-ded1-9b393a42d62f"),
				Name = @"MasterEntityName",
				CreatedInSchemaUId = new Guid("953be763-691e-4c7c-831d-d7e5318d4715"),
				ModifiedInSchemaUId = new Guid("953be763-691e-4c7c-831d-d7e5318d4715"),
				CreatedInPackageId = new Guid("a39f3d79-3277-4890-a39e-707c83f6a851"),
				IsFormatValidated = true
			};
		}

		protected virtual EntitySchemaColumn CreateIsRequiredColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("18d7018b-5065-e3ec-21ff-3c5cf949bf63"),
				Name = @"IsRequired",
				CreatedInSchemaUId = new Guid("953be763-691e-4c7c-831d-d7e5318d4715"),
				ModifiedInSchemaUId = new Guid("953be763-691e-4c7c-831d-d7e5318d4715"),
				CreatedInPackageId = new Guid("a39f3d79-3277-4890-a39e-707c83f6a851")
			};
		}

		protected virtual EntitySchemaColumn CreateProcessElementIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("4998cf58-eac4-bdb0-5ee8-9e5eb8e82d2c"),
				Name = @"ProcessElementId",
				CreatedInSchemaUId = new Guid("953be763-691e-4c7c-831d-d7e5318d4715"),
				ModifiedInSchemaUId = new Guid("953be763-691e-4c7c-831d-d7e5318d4715"),
				CreatedInPackageId = new Guid("a39f3d79-3277-4890-a39e-707c83f6a851")
			};
		}

		protected virtual EntitySchemaColumn CreateDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("8185f764-ad2f-6fea-1093-94e6148e3f1f"),
				Name = @"Date",
				CreatedInSchemaUId = new Guid("953be763-691e-4c7c-831d-d7e5318d4715"),
				ModifiedInSchemaUId = new Guid("953be763-691e-4c7c-831d-d7e5318d4715"),
				CreatedInPackageId = new Guid("a39f3d79-3277-4890-a39e-707c83f6a851")
			};
		}

		protected virtual EntitySchemaColumn CreateAdditionalInfoColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("651185ea-1e5a-2a48-b58d-506e4a169b01"),
				Name = @"AdditionalInfo",
				CreatedInSchemaUId = new Guid("953be763-691e-4c7c-831d-d7e5318d4715"),
				ModifiedInSchemaUId = new Guid("953be763-691e-4c7c-831d-d7e5318d4715"),
				CreatedInPackageId = new Guid("a39f3d79-3277-4890-a39e-707c83f6a851"),
				IsFormatValidated = true
			};
		}

		protected virtual EntitySchemaColumn CreateOwnerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("9eddf217-f666-6bf4-40e6-9b2b5e83019e"),
				Name = @"Owner",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("953be763-691e-4c7c-831d-d7e5318d4715"),
				ModifiedInSchemaUId = new Guid("953be763-691e-4c7c-831d-d7e5318d4715"),
				CreatedInPackageId = new Guid("032fd8ac-f1f1-4a8c-86e0-929d42537d25")
			};
		}

		protected virtual EntitySchemaColumn CreateIsOwnerRoleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("f484c715-f5a5-e2db-b095-23bb80f811bd"),
				Name = @"IsOwnerRole",
				CreatedInSchemaUId = new Guid("953be763-691e-4c7c-831d-d7e5318d4715"),
				ModifiedInSchemaUId = new Guid("953be763-691e-4c7c-831d-d7e5318d4715"),
				CreatedInPackageId = new Guid("032fd8ac-f1f1-4a8c-86e0-929d42537d25")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new NextStep(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new NextStep_CrtNextStepEventsProcess(userConnection);
		}

		public override object Clone() {
			return new NextStepSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new NextStepSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("953be763-691e-4c7c-831d-d7e5318d4715"));
		}

		#endregion

	}

	#endregion

	#region Class: NextStep

	/// <summary>
	/// NextStep.
	/// </summary>
	public class NextStep : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public NextStep(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "NextStep";
		}

		public NextStep(NextStep source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Unique identifier.
		/// </summary>
		public Guid Id {
			get {
				return GetTypedColumnValue<Guid>("Id");
			}
			set {
				SetColumnValue("Id", value);
			}
		}

		/// <summary>
		/// Caption.
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
		/// Master record identifier.
		/// </summary>
		public Guid MasterEntityId {
			get {
				return GetTypedColumnValue<Guid>("MasterEntityId");
			}
			set {
				SetColumnValue("MasterEntityId", value);
			}
		}

		/// <summary>
		/// Entity name.
		/// </summary>
		public string EntityName {
			get {
				return GetTypedColumnValue<string>("EntityName");
			}
			set {
				SetColumnValue("EntityName", value);
			}
		}

		/// <summary>
		/// Master record name.
		/// </summary>
		public string MasterEntityName {
			get {
				return GetTypedColumnValue<string>("MasterEntityName");
			}
			set {
				SetColumnValue("MasterEntityName", value);
			}
		}

		/// <summary>
		/// IsRequired.
		/// </summary>
		public bool IsRequired {
			get {
				return GetTypedColumnValue<bool>("IsRequired");
			}
			set {
				SetColumnValue("IsRequired", value);
			}
		}

		/// <summary>
		/// Process element identifier.
		/// </summary>
		public Guid ProcessElementId {
			get {
				return GetTypedColumnValue<Guid>("ProcessElementId");
			}
			set {
				SetColumnValue("ProcessElementId", value);
			}
		}

		/// <summary>
		/// Date.
		/// </summary>
		public DateTime Date {
			get {
				return GetTypedColumnValue<DateTime>("Date");
			}
			set {
				SetColumnValue("Date", value);
			}
		}

		/// <summary>
		/// Column with additional info.
		/// </summary>
		public string AdditionalInfo {
			get {
				return GetTypedColumnValue<string>("AdditionalInfo");
			}
			set {
				SetColumnValue("AdditionalInfo", value);
			}
		}

		/// <exclude/>
		public Guid OwnerId {
			get {
				return GetTypedColumnValue<Guid>("OwnerId");
			}
			set {
				SetColumnValue("OwnerId", value);
				_owner = null;
			}
		}

		/// <exclude/>
		public string OwnerName {
			get {
				return GetTypedColumnValue<string>("OwnerName");
			}
			set {
				SetColumnValue("OwnerName", value);
				if (_owner != null) {
					_owner.Name = value;
				}
			}
		}

		private Contact _owner;
		/// <summary>
		/// Owner.
		/// </summary>
		public Contact Owner {
			get {
				return _owner ??
					(_owner = LookupColumnEntities.GetEntity("Owner") as Contact);
			}
		}

		/// <summary>
		/// Is owner role.
		/// </summary>
		public bool IsOwnerRole {
			get {
				return GetTypedColumnValue<bool>("IsOwnerRole");
			}
			set {
				SetColumnValue("IsOwnerRole", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new NextStep_CrtNextStepEventsProcess(UserConnection);
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
			return new NextStep(this);
		}

		#endregion

	}

	#endregion

	#region Class: NextStep_CrtNextStepEventsProcess

	/// <exclude/>
	public partial class NextStep_CrtNextStepEventsProcess<TEntity> : Terrasoft.Core.Process.EmbeddedProcess where TEntity : NextStep
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

		public NextStep_CrtNextStepEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "NextStep_CrtNextStepEventsProcess";
			SchemaUId = new Guid("953be763-691e-4c7c-831d-d7e5318d4715");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("953be763-691e-4c7c-831d-d7e5318d4715");
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

	#region Class: NextStep_CrtNextStepEventsProcess

	/// <exclude/>
	public class NextStep_CrtNextStepEventsProcess : NextStep_CrtNextStepEventsProcess<NextStep>
	{

		public NextStep_CrtNextStepEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: NextStep_CrtNextStepEventsProcess

	public partial class NextStep_CrtNextStepEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: NextStepEventsProcess

	/// <exclude/>
	public class NextStepEventsProcess : NextStep_CrtNextStepEventsProcess
	{

		public NextStepEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

