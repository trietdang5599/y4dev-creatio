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

	#region Class: SysSchemaOperationRightSchema

	/// <exclude/>
	public class SysSchemaOperationRightSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysSchemaOperationRightSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysSchemaOperationRightSchema(SysSchemaOperationRightSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysSchemaOperationRightSchema(SysSchemaOperationRightSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c1ec751f-e48d-4163-a4e8-bce2a38be2f4");
			RealUId = new Guid("c1ec751f-e48d-4163-a4e8-bce2a38be2f4");
			Name = "SysSchemaOperationRight";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723");
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
			if (Columns.FindByUId(new Guid("e19a254b-5e61-d1df-27a5-954a4bc1d2f9")) == null) {
				Columns.Add(CreateSysSchemaUIdColumn());
			}
			if (Columns.FindByUId(new Guid("7827124e-9789-281e-e867-beb0f4196374")) == null) {
				Columns.Add(CreateOperationColumn());
			}
			if (Columns.FindByUId(new Guid("1d6fcb73-470f-6eb7-4fe5-56fdb0119df1")) == null) {
				Columns.Add(CreatePositionColumn());
			}
			if (Columns.FindByUId(new Guid("2907adc9-c5e3-d380-9906-f4fa49641507")) == null) {
				Columns.Add(CreateSysAdminUnitColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysSchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("e19a254b-5e61-d1df-27a5-954a4bc1d2f9"),
				Name = @"SysSchemaUId",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("c1ec751f-e48d-4163-a4e8-bce2a38be2f4"),
				ModifiedInSchemaUId = new Guid("c1ec751f-e48d-4163-a4e8-bce2a38be2f4"),
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723")
			};
		}

		protected virtual EntitySchemaColumn CreateOperationColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("7827124e-9789-281e-e867-beb0f4196374"),
				Name = @"Operation",
				CreatedInSchemaUId = new Guid("c1ec751f-e48d-4163-a4e8-bce2a38be2f4"),
				ModifiedInSchemaUId = new Guid("c1ec751f-e48d-4163-a4e8-bce2a38be2f4"),
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723")
			};
		}

		protected virtual EntitySchemaColumn CreatePositionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("1d6fcb73-470f-6eb7-4fe5-56fdb0119df1"),
				Name = @"Position",
				CreatedInSchemaUId = new Guid("c1ec751f-e48d-4163-a4e8-bce2a38be2f4"),
				ModifiedInSchemaUId = new Guid("c1ec751f-e48d-4163-a4e8-bce2a38be2f4"),
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723")
			};
		}

		protected virtual EntitySchemaColumn CreateSysAdminUnitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("2907adc9-c5e3-d380-9906-f4fa49641507"),
				Name = @"SysAdminUnit",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsWeakReference = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("c1ec751f-e48d-4163-a4e8-bce2a38be2f4"),
				ModifiedInSchemaUId = new Guid("c1ec751f-e48d-4163-a4e8-bce2a38be2f4"),
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysSchemaOperationRight(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysSchemaOperationRight_CrtCoreBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysSchemaOperationRightSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysSchemaOperationRightSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c1ec751f-e48d-4163-a4e8-bce2a38be2f4"));
		}

		#endregion

	}

	#endregion

	#region Class: SysSchemaOperationRight

	/// <summary>
	/// Schema operation right.
	/// </summary>
	public class SysSchemaOperationRight : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysSchemaOperationRight(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysSchemaOperationRight";
		}

		public SysSchemaOperationRight(SysSchemaOperationRight source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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

		/// <summary>
		/// Operation type.
		/// </summary>
		public int Operation {
			get {
				return GetTypedColumnValue<int>("Operation");
			}
			set {
				SetColumnValue("Operation", value);
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
		/// User/role.
		/// </summary>
		public SysAdminUnit SysAdminUnit {
			get {
				return _sysAdminUnit ??
					(_sysAdminUnit = LookupColumnEntities.GetEntity("SysAdminUnit") as SysAdminUnit);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysSchemaOperationRight_CrtCoreBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysSchemaOperationRightDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysSchemaOperationRightDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysSchemaOperationRightInserted", e);
			Inserting += (s, e) => ThrowEvent("SysSchemaOperationRightInserting", e);
			Saved += (s, e) => ThrowEvent("SysSchemaOperationRightSaved", e);
			Saving += (s, e) => ThrowEvent("SysSchemaOperationRightSaving", e);
			Validating += (s, e) => ThrowEvent("SysSchemaOperationRightValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysSchemaOperationRight(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysSchemaOperationRight_CrtCoreBaseEventsProcess

	/// <exclude/>
	public partial class SysSchemaOperationRight_CrtCoreBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysSchemaOperationRight
	{

		public SysSchemaOperationRight_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysSchemaOperationRight_CrtCoreBaseEventsProcess";
			SchemaUId = new Guid("c1ec751f-e48d-4163-a4e8-bce2a38be2f4");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("c1ec751f-e48d-4163-a4e8-bce2a38be2f4");
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

	#region Class: SysSchemaOperationRight_CrtCoreBaseEventsProcess

	/// <exclude/>
	public class SysSchemaOperationRight_CrtCoreBaseEventsProcess : SysSchemaOperationRight_CrtCoreBaseEventsProcess<SysSchemaOperationRight>
	{

		public SysSchemaOperationRight_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysSchemaOperationRight_CrtCoreBaseEventsProcess

	public partial class SysSchemaOperationRight_CrtCoreBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysSchemaOperationRightEventsProcess

	/// <exclude/>
	public class SysSchemaOperationRightEventsProcess : SysSchemaOperationRight_CrtCoreBaseEventsProcess
	{

		public SysSchemaOperationRightEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

