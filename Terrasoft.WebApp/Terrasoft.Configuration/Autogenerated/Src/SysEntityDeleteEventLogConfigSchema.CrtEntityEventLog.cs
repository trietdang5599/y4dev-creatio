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

	#region Class: SysEntityDeleteEventLogConfigSchema

	/// <exclude/>
	public class SysEntityDeleteEventLogConfigSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysEntityDeleteEventLogConfigSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysEntityDeleteEventLogConfigSchema(SysEntityDeleteEventLogConfigSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysEntityDeleteEventLogConfigSchema(SysEntityDeleteEventLogConfigSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIU_SysEntityDeleteEventLogConfig_Schema_AppCodeIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = true
			};
			index.UId = new Guid("5c0a04bc-4afd-4b32-b051-41e8e14ae1ec");
			index.Name = "IU_SysEntityDeleteEventLogConfig_Schema_AppCode";
			index.CreatedInSchemaUId = new Guid("3a675522-49b3-46fd-9671-a987a2193955");
			index.ModifiedInSchemaUId = new Guid("3a675522-49b3-46fd-9671-a987a2193955");
			index.CreatedInPackageId = new Guid("08791919-d1ae-40dc-8e79-a223a1f7366a");
			EntitySchemaIndexColumn sysSchemaIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("d51eee90-e20d-de80-dae9-bf7989f06c7e"),
				ColumnUId = new Guid("74b76bc8-b936-0ab7-f9e3-cd95d7f980e1"),
				CreatedInSchemaUId = new Guid("3a675522-49b3-46fd-9671-a987a2193955"),
				ModifiedInSchemaUId = new Guid("3a675522-49b3-46fd-9671-a987a2193955"),
				CreatedInPackageId = new Guid("08791919-d1ae-40dc-8e79-a223a1f7366a"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(sysSchemaIdIndexColumn);
			EntitySchemaIndexColumn consumerAppCodeIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("cf5cfb82-817d-f8f8-0d8d-575a38e9f39c"),
				ColumnUId = new Guid("f3ed5b07-15a9-889e-744a-e3a58c2ac7af"),
				CreatedInSchemaUId = new Guid("3a675522-49b3-46fd-9671-a987a2193955"),
				ModifiedInSchemaUId = new Guid("3a675522-49b3-46fd-9671-a987a2193955"),
				CreatedInPackageId = new Guid("08791919-d1ae-40dc-8e79-a223a1f7366a"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(consumerAppCodeIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("3a675522-49b3-46fd-9671-a987a2193955");
			RealUId = new Guid("3a675522-49b3-46fd-9671-a987a2193955");
			Name = "SysEntityDeleteEventLogConfig";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("08791919-d1ae-40dc-8e79-a223a1f7366a");
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
			if (Columns.FindByUId(new Guid("f3ed5b07-15a9-889e-744a-e3a58c2ac7af")) == null) {
				Columns.Add(CreateConsumerAppCodeColumn());
			}
			if (Columns.FindByUId(new Guid("74b76bc8-b936-0ab7-f9e3-cd95d7f980e1")) == null) {
				Columns.Add(CreateSysSchemaColumn());
			}
			if (Columns.FindByUId(new Guid("5d03dc33-9976-ae1f-ed24-f74e2e2c16cd")) == null) {
				Columns.Add(CreateDescriptionColumn());
			}
			if (Columns.FindByUId(new Guid("c726e7b5-8184-243c-e9c7-83c406d18750")) == null) {
				Columns.Add(CreateIsActiveColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateConsumerAppCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("f3ed5b07-15a9-889e-744a-e3a58c2ac7af"),
				Name = @"ConsumerAppCode",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("3a675522-49b3-46fd-9671-a987a2193955"),
				ModifiedInSchemaUId = new Guid("3a675522-49b3-46fd-9671-a987a2193955"),
				CreatedInPackageId = new Guid("08791919-d1ae-40dc-8e79-a223a1f7366a"),
				IsTrackChangesInDB = true
			};
		}

		protected virtual EntitySchemaColumn CreateSysSchemaColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("74b76bc8-b936-0ab7-f9e3-cd95d7f980e1"),
				Name = @"SysSchema",
				ReferenceSchemaUId = new Guid("c82db13a-7f77-4085-b3ef-91c5420fd417"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsWeakReference = true,
				CreatedInSchemaUId = new Guid("3a675522-49b3-46fd-9671-a987a2193955"),
				ModifiedInSchemaUId = new Guid("3a675522-49b3-46fd-9671-a987a2193955"),
				CreatedInPackageId = new Guid("08791919-d1ae-40dc-8e79-a223a1f7366a"),
				IsTrackChangesInDB = true
			};
		}

		protected virtual EntitySchemaColumn CreateDescriptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("5d03dc33-9976-ae1f-ed24-f74e2e2c16cd"),
				Name = @"Description",
				CreatedInSchemaUId = new Guid("3a675522-49b3-46fd-9671-a987a2193955"),
				ModifiedInSchemaUId = new Guid("3a675522-49b3-46fd-9671-a987a2193955"),
				CreatedInPackageId = new Guid("08791919-d1ae-40dc-8e79-a223a1f7366a"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateIsActiveColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("c726e7b5-8184-243c-e9c7-83c406d18750"),
				Name = @"IsActive",
				CreatedInSchemaUId = new Guid("3a675522-49b3-46fd-9671-a987a2193955"),
				ModifiedInSchemaUId = new Guid("3a675522-49b3-46fd-9671-a987a2193955"),
				CreatedInPackageId = new Guid("08791919-d1ae-40dc-8e79-a223a1f7366a"),
				IsTrackChangesInDB = true,
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"True"
				}
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIU_SysEntityDeleteEventLogConfig_Schema_AppCodeIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysEntityDeleteEventLogConfig(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysEntityDeleteEventLogConfig_CrtEntityEventLogEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysEntityDeleteEventLogConfigSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysEntityDeleteEventLogConfigSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3a675522-49b3-46fd-9671-a987a2193955"));
		}

		#endregion

	}

	#endregion

	#region Class: SysEntityDeleteEventLogConfig

	/// <summary>
	/// Entity delete event log config.
	/// </summary>
	public class SysEntityDeleteEventLogConfig : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysEntityDeleteEventLogConfig(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysEntityDeleteEventLogConfig";
		}

		public SysEntityDeleteEventLogConfig(SysEntityDeleteEventLogConfig source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Consumer application code.
		/// </summary>
		public string ConsumerAppCode {
			get {
				return GetTypedColumnValue<string>("ConsumerAppCode");
			}
			set {
				SetColumnValue("ConsumerAppCode", value);
			}
		}

		/// <exclude/>
		public Guid SysSchemaId {
			get {
				return GetTypedColumnValue<Guid>("SysSchemaId");
			}
			set {
				SetColumnValue("SysSchemaId", value);
				_sysSchema = null;
			}
		}

		/// <exclude/>
		public string SysSchemaTitle {
			get {
				return GetTypedColumnValue<string>("SysSchemaTitle");
			}
			set {
				SetColumnValue("SysSchemaTitle", value);
				if (_sysSchema != null) {
					_sysSchema.Title = value;
				}
			}
		}

		private VwEntityObjects _sysSchema;
		/// <summary>
		/// Entity schema.
		/// </summary>
		public VwEntityObjects SysSchema {
			get {
				return _sysSchema ??
					(_sysSchema = LookupColumnEntities.GetEntity("SysSchema") as VwEntityObjects);
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
		/// Active.
		/// </summary>
		public bool IsActive {
			get {
				return GetTypedColumnValue<bool>("IsActive");
			}
			set {
				SetColumnValue("IsActive", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysEntityDeleteEventLogConfig_CrtEntityEventLogEventsProcess(UserConnection);
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
			return new SysEntityDeleteEventLogConfig(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysEntityDeleteEventLogConfig_CrtEntityEventLogEventsProcess

	/// <exclude/>
	public partial class SysEntityDeleteEventLogConfig_CrtEntityEventLogEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysEntityDeleteEventLogConfig
	{

		public SysEntityDeleteEventLogConfig_CrtEntityEventLogEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysEntityDeleteEventLogConfig_CrtEntityEventLogEventsProcess";
			SchemaUId = new Guid("3a675522-49b3-46fd-9671-a987a2193955");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("3a675522-49b3-46fd-9671-a987a2193955");
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

	#region Class: SysEntityDeleteEventLogConfig_CrtEntityEventLogEventsProcess

	/// <exclude/>
	public class SysEntityDeleteEventLogConfig_CrtEntityEventLogEventsProcess : SysEntityDeleteEventLogConfig_CrtEntityEventLogEventsProcess<SysEntityDeleteEventLogConfig>
	{

		public SysEntityDeleteEventLogConfig_CrtEntityEventLogEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysEntityDeleteEventLogConfig_CrtEntityEventLogEventsProcess

	public partial class SysEntityDeleteEventLogConfig_CrtEntityEventLogEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysEntityDeleteEventLogConfigEventsProcess

	/// <exclude/>
	public class SysEntityDeleteEventLogConfigEventsProcess : SysEntityDeleteEventLogConfig_CrtEntityEventLogEventsProcess
	{

		public SysEntityDeleteEventLogConfigEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

