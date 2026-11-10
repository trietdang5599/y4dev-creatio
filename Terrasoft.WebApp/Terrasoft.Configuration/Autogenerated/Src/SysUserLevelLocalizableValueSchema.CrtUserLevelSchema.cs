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

	#region Class: SysUserLevelLocalizableValueSchema

	/// <exclude/>
	public class SysUserLevelLocalizableValueSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysUserLevelLocalizableValueSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysUserLevelLocalizableValueSchema(SysUserLevelLocalizableValueSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysUserLevelLocalizableValueSchema(SysUserLevelLocalizableValueSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4fe99b05-c5c2-4a5f-8f20-7431603616bd");
			RealUId = new Guid("4fe99b05-c5c2-4a5f-8f20-7431603616bd");
			Name = "SysUserLevelLocalizableValue";
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
			if (Columns.FindByUId(new Guid("16f6b636-2919-fe78-9353-7bcb191fd5be")) == null) {
				Columns.Add(CreateSysSchemaColumn());
			}
			if (Columns.FindByUId(new Guid("a6835354-a64d-c8e3-2d61-429523041ca5")) == null) {
				Columns.Add(CreateSysCultureColumn());
			}
			if (Columns.FindByUId(new Guid("ba098647-952a-138e-3dff-b1b0a7278b28")) == null) {
				Columns.Add(CreateResourceTypeColumn());
			}
			if (Columns.FindByUId(new Guid("b7854b90-e283-0c44-04ae-75ab30b0c389")) == null) {
				Columns.Add(CreateKeyColumn());
			}
			if (Columns.FindByUId(new Guid("0e8ecfec-e5e1-649d-cafb-f8c2631abb32")) == null) {
				Columns.Add(CreateImageDataColumn());
			}
			if (Columns.FindByUId(new Guid("d5ef9e73-d276-33c1-e558-643abcf18e0f")) == null) {
				Columns.Add(CreateValueColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysSchemaColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("16f6b636-2919-fe78-9353-7bcb191fd5be"),
				Name = @"SysSchema",
				ReferenceSchemaUId = new Guid("ae9b430e-f1ab-4eeb-930d-a0360fca21d2"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("4fe99b05-c5c2-4a5f-8f20-7431603616bd"),
				ModifiedInSchemaUId = new Guid("4fe99b05-c5c2-4a5f-8f20-7431603616bd"),
				CreatedInPackageId = new Guid("5ce9c96b-344c-4843-8b76-59991939e873")
			};
		}

		protected virtual EntitySchemaColumn CreateSysCultureColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("a6835354-a64d-c8e3-2d61-429523041ca5"),
				Name = @"SysCulture",
				ReferenceSchemaUId = new Guid("ffc193e1-04bc-472b-bdc0-3333d1df84e4"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("4fe99b05-c5c2-4a5f-8f20-7431603616bd"),
				ModifiedInSchemaUId = new Guid("4fe99b05-c5c2-4a5f-8f20-7431603616bd"),
				CreatedInPackageId = new Guid("5ce9c96b-344c-4843-8b76-59991939e873")
			};
		}

		protected virtual EntitySchemaColumn CreateResourceTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("ba098647-952a-138e-3dff-b1b0a7278b28"),
				Name = @"ResourceType",
				CreatedInSchemaUId = new Guid("4fe99b05-c5c2-4a5f-8f20-7431603616bd"),
				ModifiedInSchemaUId = new Guid("4fe99b05-c5c2-4a5f-8f20-7431603616bd"),
				CreatedInPackageId = new Guid("5ce9c96b-344c-4843-8b76-59991939e873")
			};
		}

		protected virtual EntitySchemaColumn CreateKeyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("b7854b90-e283-0c44-04ae-75ab30b0c389"),
				Name = @"Key",
				CreatedInSchemaUId = new Guid("4fe99b05-c5c2-4a5f-8f20-7431603616bd"),
				ModifiedInSchemaUId = new Guid("4fe99b05-c5c2-4a5f-8f20-7431603616bd"),
				CreatedInPackageId = new Guid("5ce9c96b-344c-4843-8b76-59991939e873")
			};
		}

		protected virtual EntitySchemaColumn CreateImageDataColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Binary")) {
				UId = new Guid("0e8ecfec-e5e1-649d-cafb-f8c2631abb32"),
				Name = @"ImageData",
				CreatedInSchemaUId = new Guid("4fe99b05-c5c2-4a5f-8f20-7431603616bd"),
				ModifiedInSchemaUId = new Guid("4fe99b05-c5c2-4a5f-8f20-7431603616bd"),
				CreatedInPackageId = new Guid("5ce9c96b-344c-4843-8b76-59991939e873")
			};
		}

		protected virtual EntitySchemaColumn CreateValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("d5ef9e73-d276-33c1-e558-643abcf18e0f"),
				Name = @"Value",
				CreatedInSchemaUId = new Guid("4fe99b05-c5c2-4a5f-8f20-7431603616bd"),
				ModifiedInSchemaUId = new Guid("4fe99b05-c5c2-4a5f-8f20-7431603616bd"),
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
			return new SysUserLevelLocalizableValue(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysUserLevelLocalizableValue_CrtUserLevelSchemaEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysUserLevelLocalizableValueSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysUserLevelLocalizableValueSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4fe99b05-c5c2-4a5f-8f20-7431603616bd"));
		}

		#endregion

	}

	#endregion

	#region Class: SysUserLevelLocalizableValue

	/// <summary>
	/// User level schema localizable values.
	/// </summary>
	public class SysUserLevelLocalizableValue : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysUserLevelLocalizableValue(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysUserLevelLocalizableValue";
		}

		public SysUserLevelLocalizableValue(SysUserLevelLocalizableValue source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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

		private SysUserLevelSchema _sysSchema;
		/// <summary>
		/// User level schema.
		/// </summary>
		public SysUserLevelSchema SysSchema {
			get {
				return _sysSchema ??
					(_sysSchema = LookupColumnEntities.GetEntity("SysSchema") as SysUserLevelSchema);
			}
		}

		/// <exclude/>
		public Guid SysCultureId {
			get {
				return GetTypedColumnValue<Guid>("SysCultureId");
			}
			set {
				SetColumnValue("SysCultureId", value);
				_sysCulture = null;
			}
		}

		/// <exclude/>
		public string SysCultureName {
			get {
				return GetTypedColumnValue<string>("SysCultureName");
			}
			set {
				SetColumnValue("SysCultureName", value);
				if (_sysCulture != null) {
					_sysCulture.Name = value;
				}
			}
		}

		private SysCulture _sysCulture;
		/// <summary>
		/// Culture.
		/// </summary>
		public SysCulture SysCulture {
			get {
				return _sysCulture ??
					(_sysCulture = LookupColumnEntities.GetEntity("SysCulture") as SysCulture);
			}
		}

		/// <summary>
		/// Type of resource.
		/// </summary>
		public int ResourceType {
			get {
				return GetTypedColumnValue<int>("ResourceType");
			}
			set {
				SetColumnValue("ResourceType", value);
			}
		}

		/// <summary>
		/// Key.
		/// </summary>
		public string Key {
			get {
				return GetTypedColumnValue<string>("Key");
			}
			set {
				SetColumnValue("Key", value);
			}
		}

		/// <summary>
		/// Value.
		/// </summary>
		public string Value {
			get {
				return GetTypedColumnValue<string>("Value");
			}
			set {
				SetColumnValue("Value", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysUserLevelLocalizableValue_CrtUserLevelSchemaEventsProcess(UserConnection);
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
			return new SysUserLevelLocalizableValue(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysUserLevelLocalizableValue_CrtUserLevelSchemaEventsProcess

	/// <exclude/>
	public partial class SysUserLevelLocalizableValue_CrtUserLevelSchemaEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysUserLevelLocalizableValue
	{

		public SysUserLevelLocalizableValue_CrtUserLevelSchemaEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysUserLevelLocalizableValue_CrtUserLevelSchemaEventsProcess";
			SchemaUId = new Guid("4fe99b05-c5c2-4a5f-8f20-7431603616bd");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("4fe99b05-c5c2-4a5f-8f20-7431603616bd");
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

	#region Class: SysUserLevelLocalizableValue_CrtUserLevelSchemaEventsProcess

	/// <exclude/>
	public class SysUserLevelLocalizableValue_CrtUserLevelSchemaEventsProcess : SysUserLevelLocalizableValue_CrtUserLevelSchemaEventsProcess<SysUserLevelLocalizableValue>
	{

		public SysUserLevelLocalizableValue_CrtUserLevelSchemaEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysUserLevelLocalizableValue_CrtUserLevelSchemaEventsProcess

	public partial class SysUserLevelLocalizableValue_CrtUserLevelSchemaEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysUserLevelLocalizableValueEventsProcess

	/// <exclude/>
	public class SysUserLevelLocalizableValueEventsProcess : SysUserLevelLocalizableValue_CrtUserLevelSchemaEventsProcess
	{

		public SysUserLevelLocalizableValueEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

