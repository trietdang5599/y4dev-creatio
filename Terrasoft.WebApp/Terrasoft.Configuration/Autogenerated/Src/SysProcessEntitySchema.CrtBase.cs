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

	#region Class: SysProcessEntitySchema

	/// <exclude/>
	public class SysProcessEntitySchema : Terrasoft.Configuration.SysBaseProcessEntitySchema
	{

		#region Constructors: Public

		public SysProcessEntitySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysProcessEntitySchema(SysProcessEntitySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysProcessEntitySchema(SysProcessEntitySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIX_SysProcessEntity_EntityIdIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("d9d3d491-459e-4147-a675-d4bfcbff6acd");
			index.Name = "IX_SysProcessEntity_EntityId";
			index.CreatedInSchemaUId = new Guid("b01b6fea-b44a-4cf0-ae42-c74065cf2a8a");
			index.ModifiedInSchemaUId = new Guid("b01b6fea-b44a-4cf0-ae42-c74065cf2a8a");
			index.CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f");
			EntitySchemaIndexColumn entityIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("7c31ffa3-d76e-06f7-0987-765d0615fcfe"),
				ColumnUId = new Guid("2f6d04e2-dfa3-45ab-9a1f-e60c69b68736"),
				CreatedInSchemaUId = new Guid("b01b6fea-b44a-4cf0-ae42-c74065cf2a8a"),
				ModifiedInSchemaUId = new Guid("b01b6fea-b44a-4cf0-ae42-c74065cf2a8a"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(entityIdIndexColumn);
			return index;
		}

		private EntitySchemaIndex CreateIXSPE_EntitySchemaUIdEntityIdIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("b81c981e-76a1-4a35-87f9-75afc549af29");
			index.Name = "IXSPE_EntitySchemaUIdEntityId";
			index.CreatedInSchemaUId = new Guid("b01b6fea-b44a-4cf0-ae42-c74065cf2a8a");
			index.ModifiedInSchemaUId = new Guid("b01b6fea-b44a-4cf0-ae42-c74065cf2a8a");
			index.CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f");
			EntitySchemaIndexColumn entitySchemaUIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("621ef70c-7357-6560-463f-c66725c87d06"),
				ColumnUId = new Guid("36dc520e-160c-4d05-916b-2c4d4c0b0689"),
				CreatedInSchemaUId = new Guid("b01b6fea-b44a-4cf0-ae42-c74065cf2a8a"),
				ModifiedInSchemaUId = new Guid("b01b6fea-b44a-4cf0-ae42-c74065cf2a8a"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(entitySchemaUIdIndexColumn);
			EntitySchemaIndexColumn entityIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("df46e2d2-e70a-6f02-72a7-d6c3f839038d"),
				ColumnUId = new Guid("2f6d04e2-dfa3-45ab-9a1f-e60c69b68736"),
				CreatedInSchemaUId = new Guid("b01b6fea-b44a-4cf0-ae42-c74065cf2a8a"),
				ModifiedInSchemaUId = new Guid("b01b6fea-b44a-4cf0-ae42-c74065cf2a8a"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(entityIdIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b01b6fea-b44a-4cf0-ae42-c74065cf2a8a");
			RealUId = new Guid("b01b6fea-b44a-4cf0-ae42-c74065cf2a8a");
			Name = "SysProcessEntity";
			ParentSchemaUId = new Guid("60a89d9d-9ede-4d78-97b9-5e20373db518");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = false;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("3c7ebc1b-a71d-4072-b990-f7d4550774e8")) == null) {
				Columns.Add(CreateSysProcessColumn());
			}
			if (Columns.FindByUId(new Guid("36118e4b-8e9c-1e98-d77c-587e3c9eef2b")) == null) {
				Columns.Add(CreatePartitionKeyColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysProcessColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("3c7ebc1b-a71d-4072-b990-f7d4550774e8"),
				Name = @"SysProcess",
				ReferenceSchemaUId = new Guid("ac2d8e0f-a926-4f76-a1fa-604d5eaaa1d2"),
				IsIndexed = true,
				IsWeakReference = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("b01b6fea-b44a-4cf0-ae42-c74065cf2a8a"),
				ModifiedInSchemaUId = new Guid("b01b6fea-b44a-4cf0-ae42-c74065cf2a8a"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreatePartitionKeyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("36118e4b-8e9c-1e98-d77c-587e3c9eef2b"),
				Name = @"PartitionKey",
				IsValueCloneable = false,
				IsIndexed = true,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("b01b6fea-b44a-4cf0-ae42-c74065cf2a8a"),
				ModifiedInSchemaUId = new Guid("b01b6fea-b44a-4cf0-ae42-c74065cf2a8a"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2"),
				IsNullable = false,
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"CurrentDate")
				}
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIX_SysProcessEntity_EntityIdIndex());
			Indexes.Add(CreateIXSPE_EntitySchemaUIdEntityIdIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysProcessEntity(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysProcessEntity_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysProcessEntitySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysProcessEntitySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b01b6fea-b44a-4cf0-ae42-c74065cf2a8a"));
		}

		#endregion

	}

	#endregion

	#region Class: SysProcessEntity

	/// <summary>
	/// Object in process.
	/// </summary>
	public class SysProcessEntity : Terrasoft.Configuration.SysBaseProcessEntity
	{

		#region Constructors: Public

		public SysProcessEntity(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysProcessEntity";
		}

		public SysProcessEntity(SysProcessEntity source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SysProcessId {
			get {
				return GetTypedColumnValue<Guid>("SysProcessId");
			}
			set {
				SetColumnValue("SysProcessId", value);
				_sysProcess = null;
			}
		}

		/// <exclude/>
		public string SysProcessName {
			get {
				return GetTypedColumnValue<string>("SysProcessName");
			}
			set {
				SetColumnValue("SysProcessName", value);
				if (_sysProcess != null) {
					_sysProcess.Name = value;
				}
			}
		}

		private SysProcessLog _sysProcess;
		/// <summary>
		/// Process.
		/// </summary>
		public SysProcessLog SysProcess {
			get {
				return _sysProcess ??
					(_sysProcess = LookupColumnEntities.GetEntity("SysProcess") as SysProcessLog);
			}
		}

		/// <summary>
		/// Partition key.
		/// </summary>
		public DateTime PartitionKey {
			get {
				return GetTypedColumnValue<DateTime>("PartitionKey");
			}
			set {
				SetColumnValue("PartitionKey", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysProcessEntity_CrtBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysProcessEntityDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysProcessEntityDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysProcessEntityInserted", e);
			Inserting += (s, e) => ThrowEvent("SysProcessEntityInserting", e);
			Saved += (s, e) => ThrowEvent("SysProcessEntitySaved", e);
			Saving += (s, e) => ThrowEvent("SysProcessEntitySaving", e);
			Validating += (s, e) => ThrowEvent("SysProcessEntityValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysProcessEntity(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysProcessEntity_CrtBaseEventsProcess

	/// <exclude/>
	public partial class SysProcessEntity_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.SysBaseProcessEntity_CrtBaseEventsProcess<TEntity> where TEntity : SysProcessEntity
	{

		public SysProcessEntity_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysProcessEntity_CrtBaseEventsProcess";
			SchemaUId = new Guid("b01b6fea-b44a-4cf0-ae42-c74065cf2a8a");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("b01b6fea-b44a-4cf0-ae42-c74065cf2a8a");
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

	#region Class: SysProcessEntity_CrtBaseEventsProcess

	/// <exclude/>
	public class SysProcessEntity_CrtBaseEventsProcess : SysProcessEntity_CrtBaseEventsProcess<SysProcessEntity>
	{

		public SysProcessEntity_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysProcessEntity_CrtBaseEventsProcess

	public partial class SysProcessEntity_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysProcessEntityEventsProcess

	/// <exclude/>
	public class SysProcessEntityEventsProcess : SysProcessEntity_CrtBaseEventsProcess
	{

		public SysProcessEntityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

