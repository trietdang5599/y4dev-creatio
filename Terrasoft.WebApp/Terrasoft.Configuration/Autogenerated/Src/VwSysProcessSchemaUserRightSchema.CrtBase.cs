namespace Terrasoft.Configuration
{

	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.IO;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;

	#region Class: VwSysProcessSchemaUserRight_CrtBase_CreatioSchema

	/// <exclude/>
	public class VwSysProcessSchemaUserRight_CrtBase_CreatioSchema : Terrasoft.Core.Entities.EntitySchema
	{

		#region Constructors: Public

		public VwSysProcessSchemaUserRight_CrtBase_CreatioSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwSysProcessSchemaUserRight_CrtBase_CreatioSchema(VwSysProcessSchemaUserRight_CrtBase_CreatioSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwSysProcessSchemaUserRight_CrtBase_CreatioSchema(VwSysProcessSchemaUserRight_CrtBase_CreatioSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a105b9c7-5ec0-40c3-9e0f-e32b7465b7b0");
			RealUId = new Guid("a105b9c7-5ec0-40c3-9e0f-e32b7465b7b0");
			Name = "VwSysProcessSchemaUserRight_CrtBase_Creatio";
			ParentSchemaUId = new Guid("1b56b061-4e91-4974-9038-df8340e534f2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("8065bd7a-b2d6-476a-b4da-b683c71630f8");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryColumn() {
			base.InitializePrimaryColumn();
			PrimaryColumn = CreateIdColumn();
			if (Columns.FindByUId(PrimaryColumn.UId) == null) {
				Columns.Add(PrimaryColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("008c0bf1-dd97-4cfe-5d71-16bf25aedc39")) == null) {
				Columns.Add(CreateSysAdminUnitColumn());
			}
			if (Columns.FindByUId(new Guid("f99bb190-3298-0c75-da20-ac0752ae8f34")) == null) {
				Columns.Add(CreateSysSchemaColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("07d99fc6-e660-ebf6-f047-1ed37d55f93c"),
				Name = @"Id",
				CreatedInSchemaUId = new Guid("a105b9c7-5ec0-40c3-9e0f-e32b7465b7b0"),
				ModifiedInSchemaUId = new Guid("a105b9c7-5ec0-40c3-9e0f-e32b7465b7b0"),
				CreatedInPackageId = new Guid("8065bd7a-b2d6-476a-b4da-b683c71630f8")
			};
		}

		protected virtual EntitySchemaColumn CreateSysAdminUnitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("008c0bf1-dd97-4cfe-5d71-16bf25aedc39"),
				Name = @"SysAdminUnit",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("a105b9c7-5ec0-40c3-9e0f-e32b7465b7b0"),
				ModifiedInSchemaUId = new Guid("a105b9c7-5ec0-40c3-9e0f-e32b7465b7b0"),
				CreatedInPackageId = new Guid("8065bd7a-b2d6-476a-b4da-b683c71630f8")
			};
		}

		protected virtual EntitySchemaColumn CreateSysSchemaColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("f99bb190-3298-0c75-da20-ac0752ae8f34"),
				Name = @"SysSchema",
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("a105b9c7-5ec0-40c3-9e0f-e32b7465b7b0"),
				ModifiedInSchemaUId = new Guid("a105b9c7-5ec0-40c3-9e0f-e32b7465b7b0"),
				CreatedInPackageId = new Guid("8065bd7a-b2d6-476a-b4da-b683c71630f8")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwSysProcessSchemaUserRight_CrtBase_Creatio(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwSysProcessSchemaUserRight_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwSysProcessSchemaUserRight_CrtBase_CreatioSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwSysProcessSchemaUserRight_CrtBase_CreatioSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a105b9c7-5ec0-40c3-9e0f-e32b7465b7b0"));
		}

		#endregion

	}

	#endregion

	#region Class: VwSysProcessSchemaUserRight_CrtBase_Creatio

	/// <summary>
	/// VwSysProcessSchemaUserRight.
	/// </summary>
	public class VwSysProcessSchemaUserRight_CrtBase_Creatio : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public VwSysProcessSchemaUserRight_CrtBase_Creatio(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwSysProcessSchemaUserRight_CrtBase_Creatio";
		}

		public VwSysProcessSchemaUserRight_CrtBase_Creatio(VwSysProcessSchemaUserRight_CrtBase_Creatio source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Id.
		/// </summary>
		public Guid Id {
			get {
				return GetTypedColumnValue<Guid>("Id");
			}
			set {
				SetColumnValue("Id", value);
			}
		}

		/// <exclude/>
		public Guid SysAdminUnitId {
			get {
				return GetTypedColumnValue<Guid>("SysAdminUnitId");
			}
			set {
				SetColumnValue("SysAdminUnitId", value);
				_sysAdminUnit = null;
			}
		}

		/// <exclude/>
		public string SysAdminUnitName {
			get {
				return GetTypedColumnValue<string>("SysAdminUnitName");
			}
			set {
				SetColumnValue("SysAdminUnitName", value);
				if (_sysAdminUnit != null) {
					_sysAdminUnit.Name = value;
				}
			}
		}

		private SysAdminUnit _sysAdminUnit;
		/// <summary>
		/// SysAdminUnit.
		/// </summary>
		public SysAdminUnit SysAdminUnit {
			get {
				return _sysAdminUnit ??
					(_sysAdminUnit = LookupColumnEntities.GetEntity("SysAdminUnit") as SysAdminUnit);
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
		public string SysSchemaCaption {
			get {
				return GetTypedColumnValue<string>("SysSchemaCaption");
			}
			set {
				SetColumnValue("SysSchemaCaption", value);
				if (_sysSchema != null) {
					_sysSchema.Caption = value;
				}
			}
		}

		private SysSchema _sysSchema;
		/// <summary>
		/// SysSchema.
		/// </summary>
		public SysSchema SysSchema {
			get {
				return _sysSchema ??
					(_sysSchema = LookupColumnEntities.GetEntity("SysSchema") as SysSchema);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwSysProcessSchemaUserRight_CrtBaseEventsProcess(UserConnection);
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
			return new VwSysProcessSchemaUserRight_CrtBase_Creatio(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwSysProcessSchemaUserRight_CrtBaseEventsProcess

	/// <exclude/>
	public partial class VwSysProcessSchemaUserRight_CrtBaseEventsProcess<TEntity> : Terrasoft.Core.Process.EmbeddedProcess where TEntity : VwSysProcessSchemaUserRight_CrtBase_Creatio
	{

		private TEntity _entity;
		public TEntity Entity {
			get {
				return _entity;
			}
			set {
				_entity = value;
			}
		}

		public VwSysProcessSchemaUserRight_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwSysProcessSchemaUserRight_CrtBaseEventsProcess";
			SchemaUId = new Guid("a105b9c7-5ec0-40c3-9e0f-e32b7465b7b0");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("a105b9c7-5ec0-40c3-9e0f-e32b7465b7b0");
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

	#region Class: VwSysProcessSchemaUserRight_CrtBaseEventsProcess

	/// <exclude/>
	public class VwSysProcessSchemaUserRight_CrtBaseEventsProcess : VwSysProcessSchemaUserRight_CrtBaseEventsProcess<VwSysProcessSchemaUserRight_CrtBase_Creatio>
	{

		public VwSysProcessSchemaUserRight_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwSysProcessSchemaUserRight_CrtBaseEventsProcess

	public partial class VwSysProcessSchemaUserRight_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

