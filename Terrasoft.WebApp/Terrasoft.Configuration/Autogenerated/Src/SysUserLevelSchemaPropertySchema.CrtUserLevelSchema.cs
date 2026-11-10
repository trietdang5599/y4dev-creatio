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

	#region Class: SysUserLevelSchemaPropertySchema

	/// <exclude/>
	public class SysUserLevelSchemaPropertySchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysUserLevelSchemaPropertySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysUserLevelSchemaPropertySchema(SysUserLevelSchemaPropertySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysUserLevelSchemaPropertySchema(SysUserLevelSchemaPropertySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("26c253ff-83e3-46de-a1b2-83462af45c71");
			RealUId = new Guid("26c253ff-83e3-46de-a1b2-83462af45c71");
			Name = "SysUserLevelSchemaProperty";
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
			if (Columns.FindByUId(new Guid("ecedc4a5-e0fb-8309-d3d9-9f923c8f1eae")) == null) {
				Columns.Add(CreateSysSchemaColumn());
			}
			if (Columns.FindByUId(new Guid("1c292f08-9156-9931-89d7-14af162fd81f")) == null) {
				Columns.Add(CreateNameColumn());
			}
			if (Columns.FindByUId(new Guid("f4b25203-4eeb-def4-d648-a961fb0a7920")) == null) {
				Columns.Add(CreateValueColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysSchemaColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ecedc4a5-e0fb-8309-d3d9-9f923c8f1eae"),
				Name = @"SysSchema",
				ReferenceSchemaUId = new Guid("ae9b430e-f1ab-4eeb-930d-a0360fca21d2"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("26c253ff-83e3-46de-a1b2-83462af45c71"),
				ModifiedInSchemaUId = new Guid("26c253ff-83e3-46de-a1b2-83462af45c71"),
				CreatedInPackageId = new Guid("5ce9c96b-344c-4843-8b76-59991939e873")
			};
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("1c292f08-9156-9931-89d7-14af162fd81f"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("26c253ff-83e3-46de-a1b2-83462af45c71"),
				ModifiedInSchemaUId = new Guid("26c253ff-83e3-46de-a1b2-83462af45c71"),
				CreatedInPackageId = new Guid("5ce9c96b-344c-4843-8b76-59991939e873")
			};
		}

		protected virtual EntitySchemaColumn CreateValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("f4b25203-4eeb-def4-d648-a961fb0a7920"),
				Name = @"Value",
				CreatedInSchemaUId = new Guid("26c253ff-83e3-46de-a1b2-83462af45c71"),
				ModifiedInSchemaUId = new Guid("26c253ff-83e3-46de-a1b2-83462af45c71"),
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
			return new SysUserLevelSchemaProperty(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysUserLevelSchemaProperty_CrtUserLevelSchemaEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysUserLevelSchemaPropertySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysUserLevelSchemaPropertySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("26c253ff-83e3-46de-a1b2-83462af45c71"));
		}

		#endregion

	}

	#endregion

	#region Class: SysUserLevelSchemaProperty

	/// <summary>
	/// User level schema property.
	/// </summary>
	public class SysUserLevelSchemaProperty : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysUserLevelSchemaProperty(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysUserLevelSchemaProperty";
		}

		public SysUserLevelSchemaProperty(SysUserLevelSchemaProperty source)
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
		/// Name.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
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
			var process = new SysUserLevelSchemaProperty_CrtUserLevelSchemaEventsProcess(UserConnection);
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
			return new SysUserLevelSchemaProperty(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysUserLevelSchemaProperty_CrtUserLevelSchemaEventsProcess

	/// <exclude/>
	public partial class SysUserLevelSchemaProperty_CrtUserLevelSchemaEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysUserLevelSchemaProperty
	{

		public SysUserLevelSchemaProperty_CrtUserLevelSchemaEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysUserLevelSchemaProperty_CrtUserLevelSchemaEventsProcess";
			SchemaUId = new Guid("26c253ff-83e3-46de-a1b2-83462af45c71");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("26c253ff-83e3-46de-a1b2-83462af45c71");
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

	#region Class: SysUserLevelSchemaProperty_CrtUserLevelSchemaEventsProcess

	/// <exclude/>
	public class SysUserLevelSchemaProperty_CrtUserLevelSchemaEventsProcess : SysUserLevelSchemaProperty_CrtUserLevelSchemaEventsProcess<SysUserLevelSchemaProperty>
	{

		public SysUserLevelSchemaProperty_CrtUserLevelSchemaEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysUserLevelSchemaProperty_CrtUserLevelSchemaEventsProcess

	public partial class SysUserLevelSchemaProperty_CrtUserLevelSchemaEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysUserLevelSchemaPropertyEventsProcess

	/// <exclude/>
	public class SysUserLevelSchemaPropertyEventsProcess : SysUserLevelSchemaProperty_CrtUserLevelSchemaEventsProcess
	{

		public SysUserLevelSchemaPropertyEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

