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

	#region Class: SysDataLocalizableValueSchema

	/// <exclude/>
	public class SysDataLocalizableValueSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysDataLocalizableValueSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysDataLocalizableValueSchema(SysDataLocalizableValueSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysDataLocalizableValueSchema(SysDataLocalizableValueSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIPackageCultureKeyIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("e972bda0-fcb3-4afb-9b3e-e23269c42c4f");
			index.Name = "IPackageCultureKey";
			index.CreatedInSchemaUId = new Guid("411721fa-9a3b-4a11-bd00-52c4b4380b24");
			index.ModifiedInSchemaUId = new Guid("411721fa-9a3b-4a11-bd00-52c4b4380b24");
			index.CreatedInPackageId = new Guid("871d2d0e-2699-4cfb-a3a5-2020f3c00088");
			EntitySchemaIndexColumn sysPackageIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("fa83466b-eeef-a58d-d96e-25db22a7ab1a"),
				ColumnUId = new Guid("3eb0232a-2736-ca81-3f51-c2c6d6456726"),
				CreatedInSchemaUId = new Guid("411721fa-9a3b-4a11-bd00-52c4b4380b24"),
				ModifiedInSchemaUId = new Guid("411721fa-9a3b-4a11-bd00-52c4b4380b24"),
				CreatedInPackageId = new Guid("871d2d0e-2699-4cfb-a3a5-2020f3c00088"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(sysPackageIdIndexColumn);
			EntitySchemaIndexColumn sysCultureIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("f9634ba8-f5a4-77b1-a193-541df76c45aa"),
				ColumnUId = new Guid("1291cbfc-d9e0-5cbd-4660-28bd0252f7cf"),
				CreatedInSchemaUId = new Guid("411721fa-9a3b-4a11-bd00-52c4b4380b24"),
				ModifiedInSchemaUId = new Guid("411721fa-9a3b-4a11-bd00-52c4b4380b24"),
				CreatedInPackageId = new Guid("871d2d0e-2699-4cfb-a3a5-2020f3c00088"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(sysCultureIdIndexColumn);
			EntitySchemaIndexColumn dataSchemaNameIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("0355e699-57da-62a3-3781-2e95db747413"),
				ColumnUId = new Guid("7c8f91f9-8777-0bc0-d9e0-6bae7bf1165f"),
				CreatedInSchemaUId = new Guid("411721fa-9a3b-4a11-bd00-52c4b4380b24"),
				ModifiedInSchemaUId = new Guid("411721fa-9a3b-4a11-bd00-52c4b4380b24"),
				CreatedInPackageId = new Guid("871d2d0e-2699-4cfb-a3a5-2020f3c00088"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(dataSchemaNameIndexColumn);
			EntitySchemaIndexColumn columnNameIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("76c57bd4-3889-0edc-b390-bb195dedad6a"),
				ColumnUId = new Guid("4b7cee07-d726-50a2-9854-1aba3caef8b1"),
				CreatedInSchemaUId = new Guid("411721fa-9a3b-4a11-bd00-52c4b4380b24"),
				ModifiedInSchemaUId = new Guid("411721fa-9a3b-4a11-bd00-52c4b4380b24"),
				CreatedInPackageId = new Guid("871d2d0e-2699-4cfb-a3a5-2020f3c00088"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(columnNameIndexColumn);
			EntitySchemaIndexColumn recordIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("ae703362-50bc-7bc5-40e3-0fee0c15ddf6"),
				ColumnUId = new Guid("249214ad-d770-f7f0-3db0-7ccbc6ebaf9f"),
				CreatedInSchemaUId = new Guid("411721fa-9a3b-4a11-bd00-52c4b4380b24"),
				ModifiedInSchemaUId = new Guid("411721fa-9a3b-4a11-bd00-52c4b4380b24"),
				CreatedInPackageId = new Guid("871d2d0e-2699-4cfb-a3a5-2020f3c00088"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(recordIdIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("411721fa-9a3b-4a11-bd00-52c4b4380b24");
			RealUId = new Guid("411721fa-9a3b-4a11-bd00-52c4b4380b24");
			Name = "SysDataLocalizableValue";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("871d2d0e-2699-4cfb-a3a5-2020f3c00088");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("3eb0232a-2736-ca81-3f51-c2c6d6456726")) == null) {
				Columns.Add(CreateSysPackageColumn());
			}
			if (Columns.FindByUId(new Guid("1291cbfc-d9e0-5cbd-4660-28bd0252f7cf")) == null) {
				Columns.Add(CreateSysCultureColumn());
			}
			if (Columns.FindByUId(new Guid("a3982dfe-18b7-7e13-6508-7f47ac74a028")) == null) {
				Columns.Add(CreateValueColumn());
			}
			if (Columns.FindByUId(new Guid("249214ad-d770-f7f0-3db0-7ccbc6ebaf9f")) == null) {
				Columns.Add(CreateRecordIdColumn());
			}
			if (Columns.FindByUId(new Guid("4b7cee07-d726-50a2-9854-1aba3caef8b1")) == null) {
				Columns.Add(CreateColumnNameColumn());
			}
			if (Columns.FindByUId(new Guid("7c8f91f9-8777-0bc0-d9e0-6bae7bf1165f")) == null) {
				Columns.Add(CreateDataSchemaNameColumn());
			}
			if (Columns.FindByUId(new Guid("8a2cbc81-8eea-f3fe-0a48-4052f4547c4f")) == null) {
				Columns.Add(CreateColumnUIdColumn());
			}
			if (Columns.FindByUId(new Guid("59d7e4ab-4dcd-0e37-42cd-ccd136d84bfa")) == null) {
				Columns.Add(CreateDataSchemaUIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysPackageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("3eb0232a-2736-ca81-3f51-c2c6d6456726"),
				Name = @"SysPackage",
				ReferenceSchemaUId = new Guid("ca400a85-ec48-4b42-8e50-271929d27871"),
				IsValueCloneable = false,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("411721fa-9a3b-4a11-bd00-52c4b4380b24"),
				ModifiedInSchemaUId = new Guid("411721fa-9a3b-4a11-bd00-52c4b4380b24"),
				CreatedInPackageId = new Guid("871d2d0e-2699-4cfb-a3a5-2020f3c00088")
			};
		}

		protected virtual EntitySchemaColumn CreateSysCultureColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("1291cbfc-d9e0-5cbd-4660-28bd0252f7cf"),
				Name = @"SysCulture",
				ReferenceSchemaUId = new Guid("ffc193e1-04bc-472b-bdc0-3333d1df84e4"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				IsIndexed = true,
				IsWeakReference = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("411721fa-9a3b-4a11-bd00-52c4b4380b24"),
				ModifiedInSchemaUId = new Guid("411721fa-9a3b-4a11-bd00-52c4b4380b24"),
				CreatedInPackageId = new Guid("871d2d0e-2699-4cfb-a3a5-2020f3c00088")
			};
		}

		protected virtual EntitySchemaColumn CreateValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("a3982dfe-18b7-7e13-6508-7f47ac74a028"),
				Name = @"Value",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("411721fa-9a3b-4a11-bd00-52c4b4380b24"),
				ModifiedInSchemaUId = new Guid("411721fa-9a3b-4a11-bd00-52c4b4380b24"),
				CreatedInPackageId = new Guid("871d2d0e-2699-4cfb-a3a5-2020f3c00088")
			};
		}

		protected virtual EntitySchemaColumn CreateRecordIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("249214ad-d770-f7f0-3db0-7ccbc6ebaf9f"),
				Name = @"RecordId",
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("411721fa-9a3b-4a11-bd00-52c4b4380b24"),
				ModifiedInSchemaUId = new Guid("411721fa-9a3b-4a11-bd00-52c4b4380b24"),
				CreatedInPackageId = new Guid("871d2d0e-2699-4cfb-a3a5-2020f3c00088")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("4b7cee07-d726-50a2-9854-1aba3caef8b1"),
				Name = @"ColumnName",
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("411721fa-9a3b-4a11-bd00-52c4b4380b24"),
				ModifiedInSchemaUId = new Guid("411721fa-9a3b-4a11-bd00-52c4b4380b24"),
				CreatedInPackageId = new Guid("871d2d0e-2699-4cfb-a3a5-2020f3c00088")
			};
		}

		protected virtual EntitySchemaColumn CreateDataSchemaNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("7c8f91f9-8777-0bc0-d9e0-6bae7bf1165f"),
				Name = @"DataSchemaName",
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("411721fa-9a3b-4a11-bd00-52c4b4380b24"),
				ModifiedInSchemaUId = new Guid("411721fa-9a3b-4a11-bd00-52c4b4380b24"),
				CreatedInPackageId = new Guid("871d2d0e-2699-4cfb-a3a5-2020f3c00088")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("8a2cbc81-8eea-f3fe-0a48-4052f4547c4f"),
				Name = @"ColumnUId",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("411721fa-9a3b-4a11-bd00-52c4b4380b24"),
				ModifiedInSchemaUId = new Guid("411721fa-9a3b-4a11-bd00-52c4b4380b24"),
				CreatedInPackageId = new Guid("acb004d0-c421-4dff-b075-f4fdc1c90074")
			};
		}

		protected virtual EntitySchemaColumn CreateDataSchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("59d7e4ab-4dcd-0e37-42cd-ccd136d84bfa"),
				Name = @"DataSchemaUId",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("411721fa-9a3b-4a11-bd00-52c4b4380b24"),
				ModifiedInSchemaUId = new Guid("411721fa-9a3b-4a11-bd00-52c4b4380b24"),
				CreatedInPackageId = new Guid("acb004d0-c421-4dff-b075-f4fdc1c90074")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIPackageCultureKeyIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysDataLocalizableValue(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysDataLocalizableValue_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysDataLocalizableValueSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysDataLocalizableValueSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("411721fa-9a3b-4a11-bd00-52c4b4380b24"));
		}

		#endregion

	}

	#endregion

	#region Class: SysDataLocalizableValue

	/// <summary>
	/// Data localizable values.
	/// </summary>
	public class SysDataLocalizableValue : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysDataLocalizableValue(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysDataLocalizableValue";
		}

		public SysDataLocalizableValue(SysDataLocalizableValue source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SysPackageId {
			get {
				return GetTypedColumnValue<Guid>("SysPackageId");
			}
			set {
				SetColumnValue("SysPackageId", value);
				_sysPackage = null;
			}
		}

		/// <exclude/>
		public string SysPackageName {
			get {
				return GetTypedColumnValue<string>("SysPackageName");
			}
			set {
				SetColumnValue("SysPackageName", value);
				if (_sysPackage != null) {
					_sysPackage.Name = value;
				}
			}
		}

		private SysPackage _sysPackage;
		/// <summary>
		/// Package.
		/// </summary>
		public SysPackage SysPackage {
			get {
				return _sysPackage ??
					(_sysPackage = LookupColumnEntities.GetEntity("SysPackage") as SysPackage);
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

		/// <summary>
		/// Record Id.
		/// </summary>
		public Guid RecordId {
			get {
				return GetTypedColumnValue<Guid>("RecordId");
			}
			set {
				SetColumnValue("RecordId", value);
			}
		}

		/// <summary>
		/// Column.
		/// </summary>
		public string ColumnName {
			get {
				return GetTypedColumnValue<string>("ColumnName");
			}
			set {
				SetColumnValue("ColumnName", value);
			}
		}

		/// <summary>
		/// Schema.
		/// </summary>
		public string DataSchemaName {
			get {
				return GetTypedColumnValue<string>("DataSchemaName");
			}
			set {
				SetColumnValue("DataSchemaName", value);
			}
		}

		/// <summary>
		/// Column UId.
		/// </summary>
		public Guid ColumnUId {
			get {
				return GetTypedColumnValue<Guid>("ColumnUId");
			}
			set {
				SetColumnValue("ColumnUId", value);
			}
		}

		/// <summary>
		/// Schema UId.
		/// </summary>
		public Guid DataSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("DataSchemaUId");
			}
			set {
				SetColumnValue("DataSchemaUId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysDataLocalizableValue_CrtBaseEventsProcess(UserConnection);
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
			return new SysDataLocalizableValue(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysDataLocalizableValue_CrtBaseEventsProcess

	/// <exclude/>
	public partial class SysDataLocalizableValue_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysDataLocalizableValue
	{

		public SysDataLocalizableValue_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysDataLocalizableValue_CrtBaseEventsProcess";
			SchemaUId = new Guid("411721fa-9a3b-4a11-bd00-52c4b4380b24");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("411721fa-9a3b-4a11-bd00-52c4b4380b24");
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

	#region Class: SysDataLocalizableValue_CrtBaseEventsProcess

	/// <exclude/>
	public class SysDataLocalizableValue_CrtBaseEventsProcess : SysDataLocalizableValue_CrtBaseEventsProcess<SysDataLocalizableValue>
	{

		public SysDataLocalizableValue_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysDataLocalizableValue_CrtBaseEventsProcess

	public partial class SysDataLocalizableValue_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysDataLocalizableValueEventsProcess

	/// <exclude/>
	public class SysDataLocalizableValueEventsProcess : SysDataLocalizableValue_CrtBaseEventsProcess
	{

		public SysDataLocalizableValueEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

