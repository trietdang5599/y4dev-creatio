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

	#region Class: SysUserLevelSchemaClientSourceSchema

	/// <exclude/>
	public class SysUserLevelSchemaClientSourceSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysUserLevelSchemaClientSourceSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysUserLevelSchemaClientSourceSchema(SysUserLevelSchemaClientSourceSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysUserLevelSchemaClientSourceSchema(SysUserLevelSchemaClientSourceSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("012cff3d-a5dc-459b-b8e2-e8e906b448f1");
			RealUId = new Guid("012cff3d-a5dc-459b-b8e2-e8e906b448f1");
			Name = "SysUserLevelSchemaClientSource";
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
			if (Columns.FindByUId(new Guid("aacbe5d5-865b-202d-0fe4-d5303f2138e9")) == null) {
				Columns.Add(CreateHashColumn());
			}
			if (Columns.FindByUId(new Guid("e1e9cc4c-5418-9b65-db58-943b92ebef0e")) == null) {
				Columns.Add(CreateBodyRawColumn());
			}
			if (Columns.FindByUId(new Guid("91e91b03-8d78-31f0-0d0b-6085546de8bc")) == null) {
				Columns.Add(CreateSysCultureColumn());
			}
			if (Columns.FindByUId(new Guid("7d3f3156-e206-5af3-d8a8-905d9ac834db")) == null) {
				Columns.Add(CreateSysSchemaColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateHashColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("aacbe5d5-865b-202d-0fe4-d5303f2138e9"),
				Name = @"Hash",
				CreatedInSchemaUId = new Guid("012cff3d-a5dc-459b-b8e2-e8e906b448f1"),
				ModifiedInSchemaUId = new Guid("012cff3d-a5dc-459b-b8e2-e8e906b448f1"),
				CreatedInPackageId = new Guid("5ce9c96b-344c-4843-8b76-59991939e873")
			};
		}

		protected virtual EntitySchemaColumn CreateBodyRawColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Binary")) {
				UId = new Guid("e1e9cc4c-5418-9b65-db58-943b92ebef0e"),
				Name = @"BodyRaw",
				CreatedInSchemaUId = new Guid("012cff3d-a5dc-459b-b8e2-e8e906b448f1"),
				ModifiedInSchemaUId = new Guid("012cff3d-a5dc-459b-b8e2-e8e906b448f1"),
				CreatedInPackageId = new Guid("5ce9c96b-344c-4843-8b76-59991939e873")
			};
		}

		protected virtual EntitySchemaColumn CreateSysCultureColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("91e91b03-8d78-31f0-0d0b-6085546de8bc"),
				Name = @"SysCulture",
				ReferenceSchemaUId = new Guid("ffc193e1-04bc-472b-bdc0-3333d1df84e4"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("012cff3d-a5dc-459b-b8e2-e8e906b448f1"),
				ModifiedInSchemaUId = new Guid("012cff3d-a5dc-459b-b8e2-e8e906b448f1"),
				CreatedInPackageId = new Guid("5ce9c96b-344c-4843-8b76-59991939e873")
			};
		}

		protected virtual EntitySchemaColumn CreateSysSchemaColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("7d3f3156-e206-5af3-d8a8-905d9ac834db"),
				Name = @"SysSchema",
				ReferenceSchemaUId = new Guid("ae9b430e-f1ab-4eeb-930d-a0360fca21d2"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("012cff3d-a5dc-459b-b8e2-e8e906b448f1"),
				ModifiedInSchemaUId = new Guid("012cff3d-a5dc-459b-b8e2-e8e906b448f1"),
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
			return new SysUserLevelSchemaClientSource(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysUserLevelSchemaClientSource_CrtUserLevelSchemaEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysUserLevelSchemaClientSourceSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysUserLevelSchemaClientSourceSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("012cff3d-a5dc-459b-b8e2-e8e906b448f1"));
		}

		#endregion

	}

	#endregion

	#region Class: SysUserLevelSchemaClientSource

	/// <summary>
	/// User level schemas client source code.
	/// </summary>
	public class SysUserLevelSchemaClientSource : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysUserLevelSchemaClientSource(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysUserLevelSchemaClientSource";
		}

		public SysUserLevelSchemaClientSource(SysUserLevelSchemaClientSource source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Hash.
		/// </summary>
		public string Hash {
			get {
				return GetTypedColumnValue<string>("Hash");
			}
			set {
				SetColumnValue("Hash", value);
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

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysUserLevelSchemaClientSource_CrtUserLevelSchemaEventsProcess(UserConnection);
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
			return new SysUserLevelSchemaClientSource(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysUserLevelSchemaClientSource_CrtUserLevelSchemaEventsProcess

	/// <exclude/>
	public partial class SysUserLevelSchemaClientSource_CrtUserLevelSchemaEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysUserLevelSchemaClientSource
	{

		public SysUserLevelSchemaClientSource_CrtUserLevelSchemaEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysUserLevelSchemaClientSource_CrtUserLevelSchemaEventsProcess";
			SchemaUId = new Guid("012cff3d-a5dc-459b-b8e2-e8e906b448f1");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("012cff3d-a5dc-459b-b8e2-e8e906b448f1");
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

	#region Class: SysUserLevelSchemaClientSource_CrtUserLevelSchemaEventsProcess

	/// <exclude/>
	public class SysUserLevelSchemaClientSource_CrtUserLevelSchemaEventsProcess : SysUserLevelSchemaClientSource_CrtUserLevelSchemaEventsProcess<SysUserLevelSchemaClientSource>
	{

		public SysUserLevelSchemaClientSource_CrtUserLevelSchemaEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysUserLevelSchemaClientSource_CrtUserLevelSchemaEventsProcess

	public partial class SysUserLevelSchemaClientSource_CrtUserLevelSchemaEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysUserLevelSchemaClientSourceEventsProcess

	/// <exclude/>
	public class SysUserLevelSchemaClientSourceEventsProcess : SysUserLevelSchemaClientSource_CrtUserLevelSchemaEventsProcess
	{

		public SysUserLevelSchemaClientSourceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

