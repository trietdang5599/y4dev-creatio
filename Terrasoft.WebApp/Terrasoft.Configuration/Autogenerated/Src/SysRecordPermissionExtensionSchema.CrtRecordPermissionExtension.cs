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

	#region Class: SysRecordPermissionExtensionSchema

	/// <exclude/>
	public class SysRecordPermissionExtensionSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public SysRecordPermissionExtensionSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysRecordPermissionExtensionSchema(SysRecordPermissionExtensionSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysRecordPermissionExtensionSchema(SysRecordPermissionExtensionSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("bd64fae3-a3da-4527-9e3e-2f8db7cd7c7b");
			RealUId = new Guid("bd64fae3-a3da-4527-9e3e-2f8db7cd7c7b");
			Name = "SysRecordPermissionExtension";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("bee0921d-0743-4248-9d96-2340963fce43");
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
			if (Columns.FindByUId(new Guid("39e7291d-0cf3-de4b-00c7-2ca265b0949e")) == null) {
				Columns.Add(CreateSchemaNamesColumn());
			}
			if (Columns.FindByUId(new Guid("479a1eae-52be-3d68-4c33-9d158564c309")) == null) {
				Columns.Add(CreateIsActiveColumn());
			}
			if (Columns.FindByUId(new Guid("ab9bfc1a-bf58-abf0-27b0-2d7f3c1fcbec")) == null) {
				Columns.Add(CreatePositionColumn());
			}
			if (Columns.FindByUId(new Guid("5449e430-7ac3-ebf2-28f7-ea356ba53233")) == null) {
				Columns.Add(CreateExtensionNameColumn());
			}
			if (Columns.FindByUId(new Guid("fb9645b9-7035-1142-ec36-be5438904d20")) == null) {
				Columns.Add(CreateExtensionCombinationModeColumn());
			}
			if (Columns.FindByUId(new Guid("5f3b5e07-e0e8-761a-1808-8fcc2c6645a5")) == null) {
				Columns.Add(CreateRecordPermissionOperationTypeColumn());
			}
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.RequirementType = EntitySchemaColumnRequirementType.None;
			column.ModifiedInSchemaUId = new Guid("bd64fae3-a3da-4527-9e3e-2f8db7cd7c7b");
			return column;
		}

		protected virtual EntitySchemaColumn CreateSchemaNamesColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("39e7291d-0cf3-de4b-00c7-2ca265b0949e"),
				Name = @"SchemaNames",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("bd64fae3-a3da-4527-9e3e-2f8db7cd7c7b"),
				ModifiedInSchemaUId = new Guid("bd64fae3-a3da-4527-9e3e-2f8db7cd7c7b"),
				CreatedInPackageId = new Guid("bee0921d-0743-4248-9d96-2340963fce43")
			};
		}

		protected virtual EntitySchemaColumn CreateIsActiveColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("479a1eae-52be-3d68-4c33-9d158564c309"),
				Name = @"IsActive",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("bd64fae3-a3da-4527-9e3e-2f8db7cd7c7b"),
				ModifiedInSchemaUId = new Guid("bd64fae3-a3da-4527-9e3e-2f8db7cd7c7b"),
				CreatedInPackageId = new Guid("bee0921d-0743-4248-9d96-2340963fce43")
			};
		}

		protected virtual EntitySchemaColumn CreatePositionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("ab9bfc1a-bf58-abf0-27b0-2d7f3c1fcbec"),
				Name = @"Position",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("bd64fae3-a3da-4527-9e3e-2f8db7cd7c7b"),
				ModifiedInSchemaUId = new Guid("bd64fae3-a3da-4527-9e3e-2f8db7cd7c7b"),
				CreatedInPackageId = new Guid("bee0921d-0743-4248-9d96-2340963fce43")
			};
		}

		protected virtual EntitySchemaColumn CreateExtensionNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("5449e430-7ac3-ebf2-28f7-ea356ba53233"),
				Name = @"ExtensionName",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("bd64fae3-a3da-4527-9e3e-2f8db7cd7c7b"),
				ModifiedInSchemaUId = new Guid("bd64fae3-a3da-4527-9e3e-2f8db7cd7c7b"),
				CreatedInPackageId = new Guid("bee0921d-0743-4248-9d96-2340963fce43")
			};
		}

		protected virtual EntitySchemaColumn CreateExtensionCombinationModeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("fb9645b9-7035-1142-ec36-be5438904d20"),
				Name = @"ExtensionCombinationMode",
				ReferenceSchemaUId = new Guid("2683bf9d-7fdb-4666-a438-46064658787f"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("bd64fae3-a3da-4527-9e3e-2f8db7cd7c7b"),
				ModifiedInSchemaUId = new Guid("bd64fae3-a3da-4527-9e3e-2f8db7cd7c7b"),
				CreatedInPackageId = new Guid("e6afa403-be48-47fb-8972-4c5ae0d21355"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateRecordPermissionOperationTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("5f3b5e07-e0e8-761a-1808-8fcc2c6645a5"),
				Name = @"RecordPermissionOperationType",
				ReferenceSchemaUId = new Guid("01618739-cd25-41bf-9cda-86594ea9f512"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("bd64fae3-a3da-4527-9e3e-2f8db7cd7c7b"),
				ModifiedInSchemaUId = new Guid("bd64fae3-a3da-4527-9e3e-2f8db7cd7c7b"),
				CreatedInPackageId = new Guid("e6afa403-be48-47fb-8972-4c5ae0d21355"),
				IsSimpleLookup = true
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysRecordPermissionExtension(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysRecordPermissionExtension_CrtRecordPermissionExtensionEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysRecordPermissionExtensionSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysRecordPermissionExtensionSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("bd64fae3-a3da-4527-9e3e-2f8db7cd7c7b"));
		}

		#endregion

	}

	#endregion

	#region Class: SysRecordPermissionExtension

	/// <summary>
	/// Record permission extension.
	/// </summary>
	public class SysRecordPermissionExtension : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public SysRecordPermissionExtension(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysRecordPermissionExtension";
		}

		public SysRecordPermissionExtension(SysRecordPermissionExtension source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Schema names.
		/// </summary>
		public string SchemaNames {
			get {
				return GetTypedColumnValue<string>("SchemaNames");
			}
			set {
				SetColumnValue("SchemaNames", value);
			}
		}

		/// <summary>
		/// Is active.
		/// </summary>
		public bool IsActive {
			get {
				return GetTypedColumnValue<bool>("IsActive");
			}
			set {
				SetColumnValue("IsActive", value);
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
		/// Extension name.
		/// </summary>
		public string ExtensionName {
			get {
				return GetTypedColumnValue<string>("ExtensionName");
			}
			set {
				SetColumnValue("ExtensionName", value);
			}
		}

		/// <exclude/>
		public Guid ExtensionCombinationModeId {
			get {
				return GetTypedColumnValue<Guid>("ExtensionCombinationModeId");
			}
			set {
				SetColumnValue("ExtensionCombinationModeId", value);
				_extensionCombinationMode = null;
			}
		}

		/// <exclude/>
		public string ExtensionCombinationModeName {
			get {
				return GetTypedColumnValue<string>("ExtensionCombinationModeName");
			}
			set {
				SetColumnValue("ExtensionCombinationModeName", value);
				if (_extensionCombinationMode != null) {
					_extensionCombinationMode.Name = value;
				}
			}
		}

		private SysExtensionCombinationMode _extensionCombinationMode;
		/// <summary>
		/// Extension combination mode.
		/// </summary>
		public SysExtensionCombinationMode ExtensionCombinationMode {
			get {
				return _extensionCombinationMode ??
					(_extensionCombinationMode = LookupColumnEntities.GetEntity("ExtensionCombinationMode") as SysExtensionCombinationMode);
			}
		}

		/// <exclude/>
		public Guid RecordPermissionOperationTypeId {
			get {
				return GetTypedColumnValue<Guid>("RecordPermissionOperationTypeId");
			}
			set {
				SetColumnValue("RecordPermissionOperationTypeId", value);
				_recordPermissionOperationType = null;
			}
		}

		/// <exclude/>
		public string RecordPermissionOperationTypeName {
			get {
				return GetTypedColumnValue<string>("RecordPermissionOperationTypeName");
			}
			set {
				SetColumnValue("RecordPermissionOperationTypeName", value);
				if (_recordPermissionOperationType != null) {
					_recordPermissionOperationType.Name = value;
				}
			}
		}

		private EntitySchemaRecRightOperation _recordPermissionOperationType;
		/// <summary>
		/// Record permission operation type.
		/// </summary>
		public EntitySchemaRecRightOperation RecordPermissionOperationType {
			get {
				return _recordPermissionOperationType ??
					(_recordPermissionOperationType = LookupColumnEntities.GetEntity("RecordPermissionOperationType") as EntitySchemaRecRightOperation);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysRecordPermissionExtension_CrtRecordPermissionExtensionEventsProcess(UserConnection);
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
			return new SysRecordPermissionExtension(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysRecordPermissionExtension_CrtRecordPermissionExtensionEventsProcess

	/// <exclude/>
	public partial class SysRecordPermissionExtension_CrtRecordPermissionExtensionEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysRecordPermissionExtension
	{

		public SysRecordPermissionExtension_CrtRecordPermissionExtensionEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysRecordPermissionExtension_CrtRecordPermissionExtensionEventsProcess";
			SchemaUId = new Guid("bd64fae3-a3da-4527-9e3e-2f8db7cd7c7b");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("bd64fae3-a3da-4527-9e3e-2f8db7cd7c7b");
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

	#region Class: SysRecordPermissionExtension_CrtRecordPermissionExtensionEventsProcess

	/// <exclude/>
	public class SysRecordPermissionExtension_CrtRecordPermissionExtensionEventsProcess : SysRecordPermissionExtension_CrtRecordPermissionExtensionEventsProcess<SysRecordPermissionExtension>
	{

		public SysRecordPermissionExtension_CrtRecordPermissionExtensionEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysRecordPermissionExtension_CrtRecordPermissionExtensionEventsProcess

	public partial class SysRecordPermissionExtension_CrtRecordPermissionExtensionEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysRecordPermissionExtensionEventsProcess

	/// <exclude/>
	public class SysRecordPermissionExtensionEventsProcess : SysRecordPermissionExtension_CrtRecordPermissionExtensionEventsProcess
	{

		public SysRecordPermissionExtensionEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

