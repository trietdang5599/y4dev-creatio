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

	#region Class: SysSchemaAdminUnitRightSchema

	/// <exclude/>
	public class SysSchemaAdminUnitRightSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysSchemaAdminUnitRightSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysSchemaAdminUnitRightSchema(SysSchemaAdminUnitRightSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysSchemaAdminUnitRightSchema(SysSchemaAdminUnitRightSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("6cf74c22-48b9-4cde-b007-9b449d4c4582");
			RealUId = new Guid("6cf74c22-48b9-4cde-b007-9b449d4c4582");
			Name = "SysSchemaAdminUnitRight";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723");
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
			if (Columns.FindByUId(new Guid("e480ba6c-908f-f986-17ef-cdff25a88a42")) == null) {
				Columns.Add(CreateSourceColumn());
			}
			if (Columns.FindByUId(new Guid("30cc0b9b-8f3c-5bef-9009-c59233b38d02")) == null) {
				Columns.Add(CreatePositionColumn());
			}
			if (Columns.FindByUId(new Guid("8dfce004-f778-1d1c-d9cc-c08d2dae79c9")) == null) {
				Columns.Add(CreateRightLevelColumn());
			}
			if (Columns.FindByUId(new Guid("cbbc22ab-80cd-8a55-1a5f-22d6e5b785de")) == null) {
				Columns.Add(CreateOperationColumn());
			}
			if (Columns.FindByUId(new Guid("05efcbd4-82f8-34eb-9c71-20d2251108cd")) == null) {
				Columns.Add(CreateSysAdminUnitColumn());
			}
			if (Columns.FindByUId(new Guid("e8a91cb6-8482-87d3-fa37-2286623c90f8")) == null) {
				Columns.Add(CreateRecordIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSourceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e480ba6c-908f-f986-17ef-cdff25a88a42"),
				Name = @"Source",
				ReferenceSchemaUId = new Guid("f990ac27-1b3c-4090-bea2-694e259c8c2c"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("6cf74c22-48b9-4cde-b007-9b449d4c4582"),
				ModifiedInSchemaUId = new Guid("6cf74c22-48b9-4cde-b007-9b449d4c4582"),
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreatePositionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("30cc0b9b-8f3c-5bef-9009-c59233b38d02"),
				Name = @"Position",
				CreatedInSchemaUId = new Guid("6cf74c22-48b9-4cde-b007-9b449d4c4582"),
				ModifiedInSchemaUId = new Guid("6cf74c22-48b9-4cde-b007-9b449d4c4582"),
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723")
			};
		}

		protected virtual EntitySchemaColumn CreateRightLevelColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("8dfce004-f778-1d1c-d9cc-c08d2dae79c9"),
				Name = @"RightLevel",
				CreatedInSchemaUId = new Guid("6cf74c22-48b9-4cde-b007-9b449d4c4582"),
				ModifiedInSchemaUId = new Guid("6cf74c22-48b9-4cde-b007-9b449d4c4582"),
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723")
			};
		}

		protected virtual EntitySchemaColumn CreateOperationColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("cbbc22ab-80cd-8a55-1a5f-22d6e5b785de"),
				Name = @"Operation",
				CreatedInSchemaUId = new Guid("6cf74c22-48b9-4cde-b007-9b449d4c4582"),
				ModifiedInSchemaUId = new Guid("6cf74c22-48b9-4cde-b007-9b449d4c4582"),
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723")
			};
		}

		protected virtual EntitySchemaColumn CreateSysAdminUnitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("05efcbd4-82f8-34eb-9c71-20d2251108cd"),
				Name = @"SysAdminUnit",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("6cf74c22-48b9-4cde-b007-9b449d4c4582"),
				ModifiedInSchemaUId = new Guid("6cf74c22-48b9-4cde-b007-9b449d4c4582"),
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateRecordIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("e8a91cb6-8482-87d3-fa37-2286623c90f8"),
				Name = @"RecordId",
				CreatedInSchemaUId = new Guid("6cf74c22-48b9-4cde-b007-9b449d4c4582"),
				ModifiedInSchemaUId = new Guid("6cf74c22-48b9-4cde-b007-9b449d4c4582"),
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
			return new SysSchemaAdminUnitRight(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysSchemaAdminUnitRight_CrtCoreBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysSchemaAdminUnitRightSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysSchemaAdminUnitRightSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6cf74c22-48b9-4cde-b007-9b449d4c4582"));
		}

		#endregion

	}

	#endregion

	#region Class: SysSchemaAdminUnitRight

	/// <summary>
	/// Schema admin unit operation right.
	/// </summary>
	public class SysSchemaAdminUnitRight : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysSchemaAdminUnitRight(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysSchemaAdminUnitRight";
		}

		public SysSchemaAdminUnitRight(SysSchemaAdminUnitRight source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SourceId {
			get {
				return GetTypedColumnValue<Guid>("SourceId");
			}
			set {
				SetColumnValue("SourceId", value);
				_source = null;
			}
		}

		/// <exclude/>
		public string SourceName {
			get {
				return GetTypedColumnValue<string>("SourceName");
			}
			set {
				SetColumnValue("SourceName", value);
				if (_source != null) {
					_source.Name = value;
				}
			}
		}

		private SysEntitySchemaRecRightSource _source;
		/// <summary>
		/// Record permission.
		/// </summary>
		public SysEntitySchemaRecRightSource Source {
			get {
				return _source ??
					(_source = LookupColumnEntities.GetEntity("Source") as SysEntitySchemaRecRightSource);
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
		/// Right level.
		/// </summary>
		public int RightLevel {
			get {
				return GetTypedColumnValue<int>("RightLevel");
			}
			set {
				SetColumnValue("RightLevel", value);
			}
		}

		/// <summary>
		/// Operation.
		/// </summary>
		public int Operation {
			get {
				return GetTypedColumnValue<int>("Operation");
			}
			set {
				SetColumnValue("Operation", value);
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
		/// System administration object.
		/// </summary>
		public SysAdminUnit SysAdminUnit {
			get {
				return _sysAdminUnit ??
					(_sysAdminUnit = LookupColumnEntities.GetEntity("SysAdminUnit") as SysAdminUnit);
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

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysSchemaAdminUnitRight_CrtCoreBaseEventsProcess(UserConnection);
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
			return new SysSchemaAdminUnitRight(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysSchemaAdminUnitRight_CrtCoreBaseEventsProcess

	/// <exclude/>
	public partial class SysSchemaAdminUnitRight_CrtCoreBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysSchemaAdminUnitRight
	{

		public SysSchemaAdminUnitRight_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysSchemaAdminUnitRight_CrtCoreBaseEventsProcess";
			SchemaUId = new Guid("6cf74c22-48b9-4cde-b007-9b449d4c4582");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("6cf74c22-48b9-4cde-b007-9b449d4c4582");
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

	#region Class: SysSchemaAdminUnitRight_CrtCoreBaseEventsProcess

	/// <exclude/>
	public class SysSchemaAdminUnitRight_CrtCoreBaseEventsProcess : SysSchemaAdminUnitRight_CrtCoreBaseEventsProcess<SysSchemaAdminUnitRight>
	{

		public SysSchemaAdminUnitRight_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysSchemaAdminUnitRight_CrtCoreBaseEventsProcess

	public partial class SysSchemaAdminUnitRight_CrtCoreBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysSchemaAdminUnitRightEventsProcess

	/// <exclude/>
	public class SysSchemaAdminUnitRightEventsProcess : SysSchemaAdminUnitRight_CrtCoreBaseEventsProcess
	{

		public SysSchemaAdminUnitRightEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

