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

	#region Class: SysCspViolationSchema

	/// <exclude/>
	public class SysCspViolationSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysCspViolationSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysCspViolationSchema(SysCspViolationSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysCspViolationSchema(SysCspViolationSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateUQ_SysCspViolation_DU_BU_VD_SIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("07bd20dc-b5c7-4a54-b8f0-a9fa0c8f6a67");
			index.Name = "UQ_SysCspViolation_DU_BU_VD_S";
			index.CreatedInSchemaUId = new Guid("9a047398-b471-4ed4-904c-febc9eccfeac");
			index.ModifiedInSchemaUId = new Guid("9a047398-b471-4ed4-904c-febc9eccfeac");
			index.CreatedInPackageId = new Guid("8a0c5ff2-0881-4762-b701-4721e25a1ed5");
			EntitySchemaIndexColumn documentUriIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("fe1c3f9b-8799-bb69-ee05-b3a20a79bf5c"),
				ColumnUId = new Guid("a573c1b5-9c92-67df-3955-7658dbea4864"),
				CreatedInSchemaUId = new Guid("9a047398-b471-4ed4-904c-febc9eccfeac"),
				ModifiedInSchemaUId = new Guid("9a047398-b471-4ed4-904c-febc9eccfeac"),
				CreatedInPackageId = new Guid("8a0c5ff2-0881-4762-b701-4721e25a1ed5"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(documentUriIndexColumn);
			EntitySchemaIndexColumn blockedUriIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("c87659a1-e652-9c56-146c-25151acd08b0"),
				ColumnUId = new Guid("a974619f-b115-74f2-0d8a-2f49bf9a8780"),
				CreatedInSchemaUId = new Guid("9a047398-b471-4ed4-904c-febc9eccfeac"),
				ModifiedInSchemaUId = new Guid("9a047398-b471-4ed4-904c-febc9eccfeac"),
				CreatedInPackageId = new Guid("8a0c5ff2-0881-4762-b701-4721e25a1ed5"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(blockedUriIndexColumn);
			EntitySchemaIndexColumn violatedDirectiveIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("d2d17e26-3db8-6c1c-99b1-77f87b922134"),
				ColumnUId = new Guid("a5d362fb-bc56-235c-e1ac-d7f79aa62f16"),
				CreatedInSchemaUId = new Guid("9a047398-b471-4ed4-904c-febc9eccfeac"),
				ModifiedInSchemaUId = new Guid("9a047398-b471-4ed4-904c-febc9eccfeac"),
				CreatedInPackageId = new Guid("8a0c5ff2-0881-4762-b701-4721e25a1ed5"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(violatedDirectiveIndexColumn);
			EntitySchemaIndexColumn sourceIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("c7757f06-ff5e-e672-b5ff-a48bb1b12a9f"),
				ColumnUId = new Guid("ab6f303e-6419-7403-f34e-9f2c48295dea"),
				CreatedInSchemaUId = new Guid("9a047398-b471-4ed4-904c-febc9eccfeac"),
				ModifiedInSchemaUId = new Guid("9a047398-b471-4ed4-904c-febc9eccfeac"),
				CreatedInPackageId = new Guid("03ae62ce-75a7-4e4f-a795-214fbd9cfd1f"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(sourceIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("9a047398-b471-4ed4-904c-febc9eccfeac");
			RealUId = new Guid("9a047398-b471-4ed4-904c-febc9eccfeac");
			Name = "SysCspViolation";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("8a0c5ff2-0881-4762-b701-4721e25a1ed5");
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

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateDocumentUriColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("a974619f-b115-74f2-0d8a-2f49bf9a8780")) == null) {
				Columns.Add(CreateBlockedUriColumn());
			}
			if (Columns.FindByUId(new Guid("a5d362fb-bc56-235c-e1ac-d7f79aa62f16")) == null) {
				Columns.Add(CreateViolatedDirectiveColumn());
			}
			if (Columns.FindByUId(new Guid("724b7fc8-345f-e753-96e5-4d40b83bf7ec")) == null) {
				Columns.Add(CreateLastModifiedDateColumn());
			}
			if (Columns.FindByUId(new Guid("ab6f303e-6419-7403-f34e-9f2c48295dea")) == null) {
				Columns.Add(CreateSourceColumn());
			}
			if (Columns.FindByUId(new Guid("f2d9661a-832f-1c99-e53e-ae4c7e23ff27")) == null) {
				Columns.Add(CreateBlockedHostColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateDocumentUriColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("a573c1b5-9c92-67df-3955-7658dbea4864"),
				Name = @"DocumentUri",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("9a047398-b471-4ed4-904c-febc9eccfeac"),
				ModifiedInSchemaUId = new Guid("9a047398-b471-4ed4-904c-febc9eccfeac"),
				CreatedInPackageId = new Guid("8a0c5ff2-0881-4762-b701-4721e25a1ed5")
			};
		}

		protected virtual EntitySchemaColumn CreateBlockedUriColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("a974619f-b115-74f2-0d8a-2f49bf9a8780"),
				Name = @"BlockedUri",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("9a047398-b471-4ed4-904c-febc9eccfeac"),
				ModifiedInSchemaUId = new Guid("9a047398-b471-4ed4-904c-febc9eccfeac"),
				CreatedInPackageId = new Guid("8a0c5ff2-0881-4762-b701-4721e25a1ed5")
			};
		}

		protected virtual EntitySchemaColumn CreateViolatedDirectiveColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("a5d362fb-bc56-235c-e1ac-d7f79aa62f16"),
				Name = @"ViolatedDirective",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("9a047398-b471-4ed4-904c-febc9eccfeac"),
				ModifiedInSchemaUId = new Guid("9a047398-b471-4ed4-904c-febc9eccfeac"),
				CreatedInPackageId = new Guid("8a0c5ff2-0881-4762-b701-4721e25a1ed5")
			};
		}

		protected virtual EntitySchemaColumn CreateLastModifiedDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("724b7fc8-345f-e753-96e5-4d40b83bf7ec"),
				Name = @"LastModifiedDate",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("9a047398-b471-4ed4-904c-febc9eccfeac"),
				ModifiedInSchemaUId = new Guid("9a047398-b471-4ed4-904c-febc9eccfeac"),
				CreatedInPackageId = new Guid("8a0c5ff2-0881-4762-b701-4721e25a1ed5"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"CurrentDate")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateSourceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("ab6f303e-6419-7403-f34e-9f2c48295dea"),
				Name = @"Source",
				CreatedInSchemaUId = new Guid("9a047398-b471-4ed4-904c-febc9eccfeac"),
				ModifiedInSchemaUId = new Guid("9a047398-b471-4ed4-904c-febc9eccfeac"),
				CreatedInPackageId = new Guid("9acc6780-473e-4622-a1b4-a9672747b2c4")
			};
		}

		protected virtual EntitySchemaColumn CreateBlockedHostColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("f2d9661a-832f-1c99-e53e-ae4c7e23ff27"),
				Name = @"BlockedHost",
				CreatedInSchemaUId = new Guid("9a047398-b471-4ed4-904c-febc9eccfeac"),
				ModifiedInSchemaUId = new Guid("9a047398-b471-4ed4-904c-febc9eccfeac"),
				CreatedInPackageId = new Guid("9acc6780-473e-4622-a1b4-a9672747b2c4")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateUQ_SysCspViolation_DU_BU_VD_SIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysCspViolation(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysCspViolation_CSPEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysCspViolationSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysCspViolationSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9a047398-b471-4ed4-904c-febc9eccfeac"));
		}

		#endregion

	}

	#endregion

	#region Class: SysCspViolation

	/// <summary>
	/// Content security policy violations log.
	/// </summary>
	public class SysCspViolation : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysCspViolation(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysCspViolation";
		}

		public SysCspViolation(SysCspViolation source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Document URL.
		/// </summary>
		public string DocumentUri {
			get {
				return GetTypedColumnValue<string>("DocumentUri");
			}
			set {
				SetColumnValue("DocumentUri", value);
			}
		}

		/// <summary>
		/// Blocked URL.
		/// </summary>
		public string BlockedUri {
			get {
				return GetTypedColumnValue<string>("BlockedUri");
			}
			set {
				SetColumnValue("BlockedUri", value);
			}
		}

		/// <summary>
		/// Violated directive.
		/// </summary>
		public string ViolatedDirective {
			get {
				return GetTypedColumnValue<string>("ViolatedDirective");
			}
			set {
				SetColumnValue("ViolatedDirective", value);
			}
		}

		/// <summary>
		/// Last violation date.
		/// </summary>
		public DateTime LastModifiedDate {
			get {
				return GetTypedColumnValue<DateTime>("LastModifiedDate");
			}
			set {
				SetColumnValue("LastModifiedDate", value);
			}
		}

		/// <summary>
		/// Source.
		/// </summary>
		public string Source {
			get {
				return GetTypedColumnValue<string>("Source");
			}
			set {
				SetColumnValue("Source", value);
			}
		}

		/// <summary>
		/// Blocked host.
		/// </summary>
		public string BlockedHost {
			get {
				return GetTypedColumnValue<string>("BlockedHost");
			}
			set {
				SetColumnValue("BlockedHost", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysCspViolation_CSPEventsProcess(UserConnection);
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
			return new SysCspViolation(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysCspViolation_CSPEventsProcess

	/// <exclude/>
	public partial class SysCspViolation_CSPEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysCspViolation
	{

		public SysCspViolation_CSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysCspViolation_CSPEventsProcess";
			SchemaUId = new Guid("9a047398-b471-4ed4-904c-febc9eccfeac");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("9a047398-b471-4ed4-904c-febc9eccfeac");
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

	#region Class: SysCspViolation_CSPEventsProcess

	/// <exclude/>
	public class SysCspViolation_CSPEventsProcess : SysCspViolation_CSPEventsProcess<SysCspViolation>
	{

		public SysCspViolation_CSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysCspViolation_CSPEventsProcess

	public partial class SysCspViolation_CSPEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysCspViolationEventsProcess

	/// <exclude/>
	public class SysCspViolationEventsProcess : SysCspViolation_CSPEventsProcess
	{

		public SysCspViolationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

