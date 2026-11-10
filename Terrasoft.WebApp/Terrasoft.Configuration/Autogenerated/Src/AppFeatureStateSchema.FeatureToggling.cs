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

	#region Class: AppFeatureStateSchema

	/// <exclude/>
	[IsVirtual]
	public class AppFeatureStateSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public AppFeatureStateSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public AppFeatureStateSchema(AppFeatureStateSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public AppFeatureStateSchema(AppFeatureStateSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("98323ece-e250-4d20-aad3-a3628d33463d");
			RealUId = new Guid("98323ece-e250-4d20-aad3-a3628d33463d");
			Name = "AppFeatureState";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("6f71e54c-1960-40c9-94f6-073fd67699ab");
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
			if (Columns.FindByUId(new Guid("740da936-0726-667f-14e3-ec0688d74169")) == null) {
				Columns.Add(CreateFeatureStateColumn());
			}
			if (Columns.FindByUId(new Guid("6e6c76e4-a7e1-3d9f-4c06-9860d0e8671c")) == null) {
				Columns.Add(CreateAdminUnitColumn());
			}
			if (Columns.FindByUId(new Guid("4bd77fe4-5157-0f5c-9110-37cbc652f50d")) == null) {
				Columns.Add(CreateFeatureColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateFeatureStateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("740da936-0726-667f-14e3-ec0688d74169"),
				Name = @"FeatureState",
				CreatedInSchemaUId = new Guid("98323ece-e250-4d20-aad3-a3628d33463d"),
				ModifiedInSchemaUId = new Guid("98323ece-e250-4d20-aad3-a3628d33463d"),
				CreatedInPackageId = new Guid("f0644392-b69e-4e52-90a7-66f9509f0134")
			};
		}

		protected virtual EntitySchemaColumn CreateAdminUnitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("6e6c76e4-a7e1-3d9f-4c06-9860d0e8671c"),
				Name = @"AdminUnit",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("98323ece-e250-4d20-aad3-a3628d33463d"),
				ModifiedInSchemaUId = new Guid("98323ece-e250-4d20-aad3-a3628d33463d"),
				CreatedInPackageId = new Guid("f0644392-b69e-4e52-90a7-66f9509f0134")
			};
		}

		protected virtual EntitySchemaColumn CreateFeatureColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("4bd77fe4-5157-0f5c-9110-37cbc652f50d"),
				Name = @"Feature",
				ReferenceSchemaUId = new Guid("1b221c58-4d4d-47ed-82ce-416181e775bf"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("98323ece-e250-4d20-aad3-a3628d33463d"),
				ModifiedInSchemaUId = new Guid("98323ece-e250-4d20-aad3-a3628d33463d"),
				CreatedInPackageId = new Guid("f0644392-b69e-4e52-90a7-66f9509f0134")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new AppFeatureState(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new AppFeatureState_FeatureTogglingEventsProcess(userConnection);
		}

		public override object Clone() {
			return new AppFeatureStateSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new AppFeatureStateSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("98323ece-e250-4d20-aad3-a3628d33463d"));
		}

		#endregion

	}

	#endregion

	#region Class: AppFeatureState

	/// <summary>
	/// Feature state.
	/// </summary>
	public class AppFeatureState : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public AppFeatureState(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "AppFeatureState";
		}

		public AppFeatureState(AppFeatureState source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Feature state.
		/// </summary>
		public bool FeatureState {
			get {
				return GetTypedColumnValue<bool>("FeatureState");
			}
			set {
				SetColumnValue("FeatureState", value);
			}
		}

		/// <exclude/>
		public Guid AdminUnitId {
			get {
				return GetTypedColumnValue<Guid>("AdminUnitId");
			}
			set {
				SetColumnValue("AdminUnitId", value);
				_adminUnit = null;
			}
		}

		/// <exclude/>
		public string AdminUnitName {
			get {
				return GetTypedColumnValue<string>("AdminUnitName");
			}
			set {
				SetColumnValue("AdminUnitName", value);
				if (_adminUnit != null) {
					_adminUnit.Name = value;
				}
			}
		}

		private SysAdminUnit _adminUnit;
		/// <summary>
		/// Admin unit.
		/// </summary>
		public SysAdminUnit AdminUnit {
			get {
				return _adminUnit ??
					(_adminUnit = LookupColumnEntities.GetEntity("AdminUnit") as SysAdminUnit);
			}
		}

		/// <exclude/>
		public Guid FeatureId {
			get {
				return GetTypedColumnValue<Guid>("FeatureId");
			}
			set {
				SetColumnValue("FeatureId", value);
				_feature = null;
			}
		}

		/// <exclude/>
		public string FeatureCode {
			get {
				return GetTypedColumnValue<string>("FeatureCode");
			}
			set {
				SetColumnValue("FeatureCode", value);
				if (_feature != null) {
					_feature.Code = value;
				}
			}
		}

		private AppFeature _feature;
		/// <summary>
		/// Feature.
		/// </summary>
		public AppFeature Feature {
			get {
				return _feature ??
					(_feature = LookupColumnEntities.GetEntity("Feature") as AppFeature);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new AppFeatureState_FeatureTogglingEventsProcess(UserConnection);
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
			return new AppFeatureState(this);
		}

		#endregion

	}

	#endregion

	#region Class: AppFeatureState_FeatureTogglingEventsProcess

	/// <exclude/>
	public partial class AppFeatureState_FeatureTogglingEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : AppFeatureState
	{

		public AppFeatureState_FeatureTogglingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "AppFeatureState_FeatureTogglingEventsProcess";
			SchemaUId = new Guid("98323ece-e250-4d20-aad3-a3628d33463d");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("98323ece-e250-4d20-aad3-a3628d33463d");
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

	#region Class: AppFeatureState_FeatureTogglingEventsProcess

	/// <exclude/>
	public class AppFeatureState_FeatureTogglingEventsProcess : AppFeatureState_FeatureTogglingEventsProcess<AppFeatureState>
	{

		public AppFeatureState_FeatureTogglingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: AppFeatureState_FeatureTogglingEventsProcess

	public partial class AppFeatureState_FeatureTogglingEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: AppFeatureStateEventsProcess

	/// <exclude/>
	public class AppFeatureStateEventsProcess : AppFeatureState_FeatureTogglingEventsProcess
	{

		public AppFeatureStateEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

