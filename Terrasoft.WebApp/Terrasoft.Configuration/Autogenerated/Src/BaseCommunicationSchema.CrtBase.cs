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

	#region Class: BaseCommunicationSchema

	/// <exclude/>
	[IsVirtual]
	public class BaseCommunicationSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public BaseCommunicationSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public BaseCommunicationSchema(BaseCommunicationSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public BaseCommunicationSchema(BaseCommunicationSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("33245659-4fea-425d-b591-9ed4bdeacaf5");
			RealUId = new Guid("33245659-4fea-425d-b591-9ed4bdeacaf5");
			Name = "BaseCommunication";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = false;
			UseLiveEditing = false;
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
			if (Columns.FindByUId(new Guid("12f1d73a-43c5-4a52-9bd6-3e0ecafd3fb4")) == null) {
				Columns.Add(CreateCommunicationTypeColumn());
			}
			if (Columns.FindByUId(new Guid("0c103353-496a-4ff9-a8eb-877dfed4af26")) == null) {
				Columns.Add(CreatePositionColumn());
			}
			if (Columns.FindByUId(new Guid("c8c5a7d8-f9c8-420a-af2a-cdb3f130e16d")) == null) {
				Columns.Add(CreateSocialMediaIdColumn());
			}
			if (Columns.FindByUId(new Guid("44278aac-22bf-44eb-8b94-c5e9b3525027")) == null) {
				Columns.Add(CreateSearchNumberColumn());
			}
			if (Columns.FindByUId(new Guid("83980e6d-09cc-4104-8a0b-64e974eecbdd")) == null) {
				Columns.Add(CreatePrimaryColumn());
			}
			if (Columns.FindByUId(new Guid("ad63b6ff-8842-4d58-ba4a-8e4ff366964b")) == null) {
				Columns.Add(CreateNonActualColumn());
			}
			if (Columns.FindByUId(new Guid("88fe3140-5c42-4b10-898a-95b988e40720")) == null) {
				Columns.Add(CreateNonActualReasonColumn());
			}
			if (Columns.FindByUId(new Guid("dfed1095-db33-4c53-9a03-6fa884b9cc3f")) == null) {
				Columns.Add(CreateDateSetNonActualColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCommunicationTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("12f1d73a-43c5-4a52-9bd6-3e0ecafd3fb4"),
				Name = @"CommunicationType",
				ReferenceSchemaUId = new Guid("d846cb4f-f18d-469e-83ff-e961f3fba873"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("33245659-4fea-425d-b591-9ed4bdeacaf5"),
				ModifiedInSchemaUId = new Guid("33245659-4fea-425d-b591-9ed4bdeacaf5"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateNumberColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("02fcae57-fafa-4e4f-9367-b58317a6e2ec"),
				Name = @"Number",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("33245659-4fea-425d-b591-9ed4bdeacaf5"),
				ModifiedInSchemaUId = new Guid("33245659-4fea-425d-b591-9ed4bdeacaf5"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				IsSensitiveData = true
			};
		}

		protected virtual EntitySchemaColumn CreatePositionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("0c103353-496a-4ff9-a8eb-877dfed4af26"),
				Name = @"Position",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("33245659-4fea-425d-b591-9ed4bdeacaf5"),
				ModifiedInSchemaUId = new Guid("33245659-4fea-425d-b591-9ed4bdeacaf5"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSocialMediaIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("c8c5a7d8-f9c8-420a-af2a-cdb3f130e16d"),
				Name = @"SocialMediaId",
				CreatedInSchemaUId = new Guid("33245659-4fea-425d-b591-9ed4bdeacaf5"),
				ModifiedInSchemaUId = new Guid("33245659-4fea-425d-b591-9ed4bdeacaf5"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				IsSensitiveData = true
			};
		}

		protected virtual EntitySchemaColumn CreateSearchNumberColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("44278aac-22bf-44eb-8b94-c5e9b3525027"),
				Name = @"SearchNumber",
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("33245659-4fea-425d-b591-9ed4bdeacaf5"),
				ModifiedInSchemaUId = new Guid("33245659-4fea-425d-b591-9ed4bdeacaf5"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				IsSensitiveData = true
			};
		}

		protected virtual EntitySchemaColumn CreatePrimaryColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("83980e6d-09cc-4104-8a0b-64e974eecbdd"),
				Name = @"Primary",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("33245659-4fea-425d-b591-9ed4bdeacaf5"),
				ModifiedInSchemaUId = new Guid("33245659-4fea-425d-b591-9ed4bdeacaf5"),
				CreatedInPackageId = new Guid("11c768bc-fae6-4a11-84ba-23628061715e")
			};
		}

		protected virtual EntitySchemaColumn CreateNonActualColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("ad63b6ff-8842-4d58-ba4a-8e4ff366964b"),
				Name = @"NonActual",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("33245659-4fea-425d-b591-9ed4bdeacaf5"),
				ModifiedInSchemaUId = new Guid("33245659-4fea-425d-b591-9ed4bdeacaf5"),
				CreatedInPackageId = new Guid("06d9ef10-51d8-122c-8933-9212e84236c9")
			};
		}

		protected virtual EntitySchemaColumn CreateNonActualReasonColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("88fe3140-5c42-4b10-898a-95b988e40720"),
				Name = @"NonActualReason",
				ReferenceSchemaUId = new Guid("88029a14-efa8-4fa9-9c87-e5131319caef"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("33245659-4fea-425d-b591-9ed4bdeacaf5"),
				ModifiedInSchemaUId = new Guid("33245659-4fea-425d-b591-9ed4bdeacaf5"),
				CreatedInPackageId = new Guid("06d9ef10-51d8-122c-8933-9212e84236c9")
			};
		}

		protected virtual EntitySchemaColumn CreateDateSetNonActualColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("dfed1095-db33-4c53-9a03-6fa884b9cc3f"),
				Name = @"DateSetNonActual",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("33245659-4fea-425d-b591-9ed4bdeacaf5"),
				ModifiedInSchemaUId = new Guid("33245659-4fea-425d-b591-9ed4bdeacaf5"),
				CreatedInPackageId = new Guid("06d9ef10-51d8-122c-8933-9212e84236c9")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new BaseCommunication(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new BaseCommunication_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new BaseCommunicationSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new BaseCommunicationSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("33245659-4fea-425d-b591-9ed4bdeacaf5"));
		}

		#endregion

	}

	#endregion

	#region Class: BaseCommunication

	/// <summary>
	/// Base communication option.
	/// </summary>
	public class BaseCommunication : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public BaseCommunication(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BaseCommunication";
		}

		public BaseCommunication(BaseCommunication source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid CommunicationTypeId {
			get {
				return GetTypedColumnValue<Guid>("CommunicationTypeId");
			}
			set {
				SetColumnValue("CommunicationTypeId", value);
				_communicationType = null;
			}
		}

		/// <exclude/>
		public string CommunicationTypeName {
			get {
				return GetTypedColumnValue<string>("CommunicationTypeName");
			}
			set {
				SetColumnValue("CommunicationTypeName", value);
				if (_communicationType != null) {
					_communicationType.Name = value;
				}
			}
		}

		private CommunicationType _communicationType;
		/// <summary>
		/// Type.
		/// </summary>
		public CommunicationType CommunicationType {
			get {
				return _communicationType ??
					(_communicationType = LookupColumnEntities.GetEntity("CommunicationType") as CommunicationType);
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

		/// <summary>
		/// Position.
		/// </summary>
		public int Position {
			get {
				return GetTypedColumnValue<int>("Position");
			}
			set {
				SetColumnValue("Position", value);
			}
		}

		/// <summary>
		/// Social network Id.
		/// </summary>
		public string SocialMediaId {
			get {
				return GetTypedColumnValue<string>("SocialMediaId");
			}
			set {
				SetColumnValue("SocialMediaId", value);
			}
		}

		/// <summary>
		/// Number for search.
		/// </summary>
		public string SearchNumber {
			get {
				return GetTypedColumnValue<string>("SearchNumber");
			}
			set {
				SetColumnValue("SearchNumber", value);
			}
		}

		/// <summary>
		/// Primary.
		/// </summary>
		public bool Primary {
			get {
				return GetTypedColumnValue<bool>("Primary");
			}
			set {
				SetColumnValue("Primary", value);
			}
		}

		/// <summary>
		/// Invalid.
		/// </summary>
		public bool NonActual {
			get {
				return GetTypedColumnValue<bool>("NonActual");
			}
			set {
				SetColumnValue("NonActual", value);
			}
		}

		/// <exclude/>
		public Guid NonActualReasonId {
			get {
				return GetTypedColumnValue<Guid>("NonActualReasonId");
			}
			set {
				SetColumnValue("NonActualReasonId", value);
				_nonActualReason = null;
			}
		}

		/// <exclude/>
		public string NonActualReasonName {
			get {
				return GetTypedColumnValue<string>("NonActualReasonName");
			}
			set {
				SetColumnValue("NonActualReasonName", value);
				if (_nonActualReason != null) {
					_nonActualReason.Name = value;
				}
			}
		}

		private NonActualReason _nonActualReason;
		/// <summary>
		/// Reason for irrelevance.
		/// </summary>
		public NonActualReason NonActualReason {
			get {
				return _nonActualReason ??
					(_nonActualReason = LookupColumnEntities.GetEntity("NonActualReason") as NonActualReason);
			}
		}

		/// <summary>
		/// Invalid since.
		/// </summary>
		public DateTime DateSetNonActual {
			get {
				return GetTypedColumnValue<DateTime>("DateSetNonActual");
			}
			set {
				SetColumnValue("DateSetNonActual", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new BaseCommunication_CrtBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("BaseCommunicationDeleted", e);
			Deleting += (s, e) => ThrowEvent("BaseCommunicationDeleting", e);
			Inserted += (s, e) => ThrowEvent("BaseCommunicationInserted", e);
			Inserting += (s, e) => ThrowEvent("BaseCommunicationInserting", e);
			Saved += (s, e) => ThrowEvent("BaseCommunicationSaved", e);
			Saving += (s, e) => ThrowEvent("BaseCommunicationSaving", e);
			Validating += (s, e) => ThrowEvent("BaseCommunicationValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new BaseCommunication(this);
		}

		#endregion

	}

	#endregion

	#region Class: BaseCommunication_CrtBaseEventsProcess

	/// <exclude/>
	public partial class BaseCommunication_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : BaseCommunication
	{

		public BaseCommunication_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "BaseCommunication_CrtBaseEventsProcess";
			SchemaUId = new Guid("33245659-4fea-425d-b591-9ed4bdeacaf5");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("33245659-4fea-425d-b591-9ed4bdeacaf5");
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

	#region Class: BaseCommunication_CrtBaseEventsProcess

	/// <exclude/>
	public class BaseCommunication_CrtBaseEventsProcess : BaseCommunication_CrtBaseEventsProcess<BaseCommunication>
	{

		public BaseCommunication_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion


	#region Class: BaseCommunicationEventsProcess

	/// <exclude/>
	public class BaseCommunicationEventsProcess : BaseCommunication_CrtBaseEventsProcess
	{

		public BaseCommunicationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

