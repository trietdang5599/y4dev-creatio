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

	#region Class: SysUserLevelSchemaContentSchema

	/// <exclude/>
	public class SysUserLevelSchemaContentSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysUserLevelSchemaContentSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysUserLevelSchemaContentSchema(SysUserLevelSchemaContentSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysUserLevelSchemaContentSchema(SysUserLevelSchemaContentSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5f62b906-58bf-45f7-b0ed-aa255e8161a5");
			RealUId = new Guid("5f62b906-58bf-45f7-b0ed-aa255e8161a5");
			Name = "SysUserLevelSchemaContent";
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
			if (Columns.FindByUId(new Guid("144edcd6-a9e0-e31d-5816-7e5c6a923732")) == null) {
				Columns.Add(CreateSysSchemaColumn());
			}
			if (Columns.FindByUId(new Guid("336021b6-8fde-ef46-571e-b75765831696")) == null) {
				Columns.Add(CreateContentTypeColumn());
			}
			if (Columns.FindByUId(new Guid("34cc2bcb-527b-4790-868f-d6548c5bc458")) == null) {
				Columns.Add(CreateContentColumn());
			}
			if (Columns.FindByUId(new Guid("4f350011-1f87-2a77-a751-d5e6c10019dc")) == null) {
				Columns.Add(CreateCodeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysSchemaColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("144edcd6-a9e0-e31d-5816-7e5c6a923732"),
				Name = @"SysSchema",
				ReferenceSchemaUId = new Guid("ae9b430e-f1ab-4eeb-930d-a0360fca21d2"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("5f62b906-58bf-45f7-b0ed-aa255e8161a5"),
				ModifiedInSchemaUId = new Guid("5f62b906-58bf-45f7-b0ed-aa255e8161a5"),
				CreatedInPackageId = new Guid("5ce9c96b-344c-4843-8b76-59991939e873")
			};
		}

		protected virtual EntitySchemaColumn CreateContentTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("336021b6-8fde-ef46-571e-b75765831696"),
				Name = @"ContentType",
				CreatedInSchemaUId = new Guid("5f62b906-58bf-45f7-b0ed-aa255e8161a5"),
				ModifiedInSchemaUId = new Guid("5f62b906-58bf-45f7-b0ed-aa255e8161a5"),
				CreatedInPackageId = new Guid("5ce9c96b-344c-4843-8b76-59991939e873")
			};
		}

		protected virtual EntitySchemaColumn CreateContentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Binary")) {
				UId = new Guid("34cc2bcb-527b-4790-868f-d6548c5bc458"),
				Name = @"Content",
				CreatedInSchemaUId = new Guid("5f62b906-58bf-45f7-b0ed-aa255e8161a5"),
				ModifiedInSchemaUId = new Guid("5f62b906-58bf-45f7-b0ed-aa255e8161a5"),
				CreatedInPackageId = new Guid("5ce9c96b-344c-4843-8b76-59991939e873")
			};
		}

		protected virtual EntitySchemaColumn CreateCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("4f350011-1f87-2a77-a751-d5e6c10019dc"),
				Name = @"Code",
				CreatedInSchemaUId = new Guid("5f62b906-58bf-45f7-b0ed-aa255e8161a5"),
				ModifiedInSchemaUId = new Guid("5f62b906-58bf-45f7-b0ed-aa255e8161a5"),
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
			return new SysUserLevelSchemaContent(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysUserLevelSchemaContent_CrtUserLevelSchemaEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysUserLevelSchemaContentSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysUserLevelSchemaContentSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5f62b906-58bf-45f7-b0ed-aa255e8161a5"));
		}

		#endregion

	}

	#endregion

	#region Class: SysUserLevelSchemaContent

	/// <summary>
	/// User level schema content.
	/// </summary>
	public class SysUserLevelSchemaContent : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysUserLevelSchemaContent(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysUserLevelSchemaContent";
		}

		public SysUserLevelSchemaContent(SysUserLevelSchemaContent source)
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

		/// <summary>
		/// Content type.
		/// </summary>
		public int ContentType {
			get {
				return GetTypedColumnValue<int>("ContentType");
			}
			set {
				SetColumnValue("ContentType", value);
			}
		}

		/// <summary>
		/// Code.
		/// </summary>
		public string Code {
			get {
				return GetTypedColumnValue<string>("Code");
			}
			set {
				SetColumnValue("Code", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysUserLevelSchemaContent_CrtUserLevelSchemaEventsProcess(UserConnection);
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
			return new SysUserLevelSchemaContent(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysUserLevelSchemaContent_CrtUserLevelSchemaEventsProcess

	/// <exclude/>
	public partial class SysUserLevelSchemaContent_CrtUserLevelSchemaEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysUserLevelSchemaContent
	{

		public SysUserLevelSchemaContent_CrtUserLevelSchemaEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysUserLevelSchemaContent_CrtUserLevelSchemaEventsProcess";
			SchemaUId = new Guid("5f62b906-58bf-45f7-b0ed-aa255e8161a5");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("5f62b906-58bf-45f7-b0ed-aa255e8161a5");
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

	#region Class: SysUserLevelSchemaContent_CrtUserLevelSchemaEventsProcess

	/// <exclude/>
	public class SysUserLevelSchemaContent_CrtUserLevelSchemaEventsProcess : SysUserLevelSchemaContent_CrtUserLevelSchemaEventsProcess<SysUserLevelSchemaContent>
	{

		public SysUserLevelSchemaContent_CrtUserLevelSchemaEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysUserLevelSchemaContent_CrtUserLevelSchemaEventsProcess

	public partial class SysUserLevelSchemaContent_CrtUserLevelSchemaEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysUserLevelSchemaContentEventsProcess

	/// <exclude/>
	public class SysUserLevelSchemaContentEventsProcess : SysUserLevelSchemaContent_CrtUserLevelSchemaEventsProcess
	{

		public SysUserLevelSchemaContentEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

