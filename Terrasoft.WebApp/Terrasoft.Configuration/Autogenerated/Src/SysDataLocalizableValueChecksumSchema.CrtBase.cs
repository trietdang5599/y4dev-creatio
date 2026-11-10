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

	#region Class: SysDataLocalizableValueChecksumSchema

	/// <exclude/>
	public class SysDataLocalizableValueChecksumSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysDataLocalizableValueChecksumSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysDataLocalizableValueChecksumSchema(SysDataLocalizableValueChecksumSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysDataLocalizableValueChecksumSchema(SysDataLocalizableValueChecksumSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateISysDataPackageSchemaCultureIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("4c1b371f-5c03-6cf3-cca7-78f5d316c963");
			index.Name = "ISysDataPackageSchemaCulture";
			index.CreatedInSchemaUId = new Guid("3007b8a3-23a7-44af-8980-bf7413c56d56");
			index.ModifiedInSchemaUId = new Guid("3007b8a3-23a7-44af-8980-bf7413c56d56");
			index.CreatedInPackageId = new Guid("acb004d0-c421-4dff-b075-f4fdc1c90074");
			EntitySchemaIndexColumn sysPackageIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("712e8829-3db7-7b54-da08-6e723fbee11e"),
				ColumnUId = new Guid("5a8e6308-e39b-7b87-0a3e-142e2a9cc0a4"),
				CreatedInSchemaUId = new Guid("3007b8a3-23a7-44af-8980-bf7413c56d56"),
				ModifiedInSchemaUId = new Guid("3007b8a3-23a7-44af-8980-bf7413c56d56"),
				CreatedInPackageId = new Guid("acb004d0-c421-4dff-b075-f4fdc1c90074"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(sysPackageIdIndexColumn);
			EntitySchemaIndexColumn sysSchemaUIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("838ee08f-e09a-478d-b552-152a8df86af3"),
				ColumnUId = new Guid("cb88fc91-adf5-cf4c-766b-de539446784d"),
				CreatedInSchemaUId = new Guid("3007b8a3-23a7-44af-8980-bf7413c56d56"),
				ModifiedInSchemaUId = new Guid("3007b8a3-23a7-44af-8980-bf7413c56d56"),
				CreatedInPackageId = new Guid("acb004d0-c421-4dff-b075-f4fdc1c90074"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(sysSchemaUIdIndexColumn);
			EntitySchemaIndexColumn sysCultureIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("dcaf0b93-5299-50e8-b160-d253ffe62856"),
				ColumnUId = new Guid("e7e8b51f-dd73-4b19-8c0b-82905d290ed9"),
				CreatedInSchemaUId = new Guid("3007b8a3-23a7-44af-8980-bf7413c56d56"),
				ModifiedInSchemaUId = new Guid("3007b8a3-23a7-44af-8980-bf7413c56d56"),
				CreatedInPackageId = new Guid("acb004d0-c421-4dff-b075-f4fdc1c90074"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(sysCultureIdIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("3007b8a3-23a7-44af-8980-bf7413c56d56");
			RealUId = new Guid("3007b8a3-23a7-44af-8980-bf7413c56d56");
			Name = "SysDataLocalizableValueChecksum";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("acb004d0-c421-4dff-b075-f4fdc1c90074");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("e7e8b51f-dd73-4b19-8c0b-82905d290ed9")) == null) {
				Columns.Add(CreateSysCultureColumn());
			}
			if (Columns.FindByUId(new Guid("05946822-b1d4-9936-4582-c8ce8b4fce2c")) == null) {
				Columns.Add(CreateIsChangedColumn());
			}
			if (Columns.FindByUId(new Guid("2fc289e8-8963-fdfb-3f20-3f3cafbe15de")) == null) {
				Columns.Add(CreateChecksumColumn());
			}
			if (Columns.FindByUId(new Guid("5a8e6308-e39b-7b87-0a3e-142e2a9cc0a4")) == null) {
				Columns.Add(CreateSysPackageColumn());
			}
			if (Columns.FindByUId(new Guid("cb88fc91-adf5-cf4c-766b-de539446784d")) == null) {
				Columns.Add(CreateSysSchemaUIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysCultureColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e7e8b51f-dd73-4b19-8c0b-82905d290ed9"),
				Name = @"SysCulture",
				ReferenceSchemaUId = new Guid("ffc193e1-04bc-472b-bdc0-3333d1df84e4"),
				IsIndexed = true,
				IsWeakReference = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("3007b8a3-23a7-44af-8980-bf7413c56d56"),
				ModifiedInSchemaUId = new Guid("3007b8a3-23a7-44af-8980-bf7413c56d56"),
				CreatedInPackageId = new Guid("acb004d0-c421-4dff-b075-f4fdc1c90074")
			};
		}

		protected virtual EntitySchemaColumn CreateIsChangedColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("05946822-b1d4-9936-4582-c8ce8b4fce2c"),
				Name = @"IsChanged",
				CreatedInSchemaUId = new Guid("3007b8a3-23a7-44af-8980-bf7413c56d56"),
				ModifiedInSchemaUId = new Guid("3007b8a3-23a7-44af-8980-bf7413c56d56"),
				CreatedInPackageId = new Guid("acb004d0-c421-4dff-b075-f4fdc1c90074")
			};
		}

		protected virtual EntitySchemaColumn CreateChecksumColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("2fc289e8-8963-fdfb-3f20-3f3cafbe15de"),
				Name = @"Checksum",
				CreatedInSchemaUId = new Guid("3007b8a3-23a7-44af-8980-bf7413c56d56"),
				ModifiedInSchemaUId = new Guid("3007b8a3-23a7-44af-8980-bf7413c56d56"),
				CreatedInPackageId = new Guid("acb004d0-c421-4dff-b075-f4fdc1c90074")
			};
		}

		protected virtual EntitySchemaColumn CreateSysPackageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("5a8e6308-e39b-7b87-0a3e-142e2a9cc0a4"),
				Name = @"SysPackage",
				ReferenceSchemaUId = new Guid("ca400a85-ec48-4b42-8e50-271929d27871"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("3007b8a3-23a7-44af-8980-bf7413c56d56"),
				ModifiedInSchemaUId = new Guid("3007b8a3-23a7-44af-8980-bf7413c56d56"),
				CreatedInPackageId = new Guid("acb004d0-c421-4dff-b075-f4fdc1c90074")
			};
		}

		protected virtual EntitySchemaColumn CreateSysSchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("cb88fc91-adf5-cf4c-766b-de539446784d"),
				Name = @"SysSchemaUId",
				CreatedInSchemaUId = new Guid("3007b8a3-23a7-44af-8980-bf7413c56d56"),
				ModifiedInSchemaUId = new Guid("3007b8a3-23a7-44af-8980-bf7413c56d56"),
				CreatedInPackageId = new Guid("acb004d0-c421-4dff-b075-f4fdc1c90074")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateISysDataPackageSchemaCultureIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysDataLocalizableValueChecksum(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysDataLocalizableValueChecksum_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysDataLocalizableValueChecksumSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysDataLocalizableValueChecksumSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3007b8a3-23a7-44af-8980-bf7413c56d56"));
		}

		#endregion

	}

	#endregion

	#region Class: SysDataLocalizableValueChecksum

	/// <summary>
	/// Checksum of data localizable values.
	/// </summary>
	public class SysDataLocalizableValueChecksum : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysDataLocalizableValueChecksum(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysDataLocalizableValueChecksum";
		}

		public SysDataLocalizableValueChecksum(SysDataLocalizableValueChecksum source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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
		/// Is Changed.
		/// </summary>
		public bool IsChanged {
			get {
				return GetTypedColumnValue<bool>("IsChanged");
			}
			set {
				SetColumnValue("IsChanged", value);
			}
		}

		/// <summary>
		/// Checksum.
		/// </summary>
		public string Checksum {
			get {
				return GetTypedColumnValue<string>("Checksum");
			}
			set {
				SetColumnValue("Checksum", value);
			}
		}

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

		/// <summary>
		/// Schema unique identifier.
		/// </summary>
		public Guid SysSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("SysSchemaUId");
			}
			set {
				SetColumnValue("SysSchemaUId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysDataLocalizableValueChecksum_CrtBaseEventsProcess(UserConnection);
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
			return new SysDataLocalizableValueChecksum(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysDataLocalizableValueChecksum_CrtBaseEventsProcess

	/// <exclude/>
	public partial class SysDataLocalizableValueChecksum_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysDataLocalizableValueChecksum
	{

		public SysDataLocalizableValueChecksum_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysDataLocalizableValueChecksum_CrtBaseEventsProcess";
			SchemaUId = new Guid("3007b8a3-23a7-44af-8980-bf7413c56d56");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("3007b8a3-23a7-44af-8980-bf7413c56d56");
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

	#region Class: SysDataLocalizableValueChecksum_CrtBaseEventsProcess

	/// <exclude/>
	public class SysDataLocalizableValueChecksum_CrtBaseEventsProcess : SysDataLocalizableValueChecksum_CrtBaseEventsProcess<SysDataLocalizableValueChecksum>
	{

		public SysDataLocalizableValueChecksum_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysDataLocalizableValueChecksum_CrtBaseEventsProcess

	public partial class SysDataLocalizableValueChecksum_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysDataLocalizableValueChecksumEventsProcess

	/// <exclude/>
	public class SysDataLocalizableValueChecksumEventsProcess : SysDataLocalizableValueChecksum_CrtBaseEventsProcess
	{

		public SysDataLocalizableValueChecksumEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

