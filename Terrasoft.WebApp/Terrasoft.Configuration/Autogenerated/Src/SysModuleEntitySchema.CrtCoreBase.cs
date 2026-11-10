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

	#region Class: SysModuleEntity_CrtCoreBase_CreatioSchema

	/// <exclude/>
	public class SysModuleEntity_CrtCoreBase_CreatioSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysModuleEntity_CrtCoreBase_CreatioSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysModuleEntity_CrtCoreBase_CreatioSchema(SysModuleEntity_CrtCoreBase_CreatioSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysModuleEntity_CrtCoreBase_CreatioSchema(SysModuleEntity_CrtCoreBase_CreatioSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("9c762665-90ad-497b-ac4b-45bb729630a1");
			RealUId = new Guid("9c762665-90ad-497b-ac4b-45bb729630a1");
			Name = "SysModuleEntity_CrtCoreBase_Creatio";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
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
			if (Columns.FindByUId(new Guid("3107ef98-a02e-4ea8-809a-67dc3025ef4a")) == null) {
				Columns.Add(CreateTypeColumnUIdColumn());
			}
			if (Columns.FindByUId(new Guid("0c59594b-490a-4b55-a564-5841cfae3c19")) == null) {
				Columns.Add(CreateSysEntitySchemaUIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateTypeColumnUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("3107ef98-a02e-4ea8-809a-67dc3025ef4a"),
				Name = @"TypeColumnUId",
				CreatedInSchemaUId = new Guid("9c762665-90ad-497b-ac4b-45bb729630a1"),
				ModifiedInSchemaUId = new Guid("9c762665-90ad-497b-ac4b-45bb729630a1"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSysEntitySchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("0c59594b-490a-4b55-a564-5841cfae3c19"),
				Name = @"SysEntitySchemaUId",
				CreatedInSchemaUId = new Guid("9c762665-90ad-497b-ac4b-45bb729630a1"),
				ModifiedInSchemaUId = new Guid("9c762665-90ad-497b-ac4b-45bb729630a1"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysModuleEntity_CrtCoreBase_Creatio(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysModuleEntity_CrtCoreBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysModuleEntity_CrtCoreBase_CreatioSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysModuleEntity_CrtCoreBase_CreatioSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9c762665-90ad-497b-ac4b-45bb729630a1"));
		}

		#endregion

	}

	#endregion

	#region Class: SysModuleEntity_CrtCoreBase_Creatio

	/// <summary>
	/// Section object.
	/// </summary>
	public class SysModuleEntity_CrtCoreBase_Creatio : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysModuleEntity_CrtCoreBase_Creatio(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysModuleEntity_CrtCoreBase_Creatio";
		}

		public SysModuleEntity_CrtCoreBase_Creatio(SysModuleEntity_CrtCoreBase_Creatio source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Type column.
		/// </summary>
		public Guid TypeColumnUId {
			get {
				return GetTypedColumnValue<Guid>("TypeColumnUId");
			}
			set {
				SetColumnValue("TypeColumnUId", value);
			}
		}

		/// <summary>
		/// Unique identifier of object.
		/// </summary>
		public Guid SysEntitySchemaUId {
			get {
				return GetTypedColumnValue<Guid>("SysEntitySchemaUId");
			}
			set {
				SetColumnValue("SysEntitySchemaUId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysModuleEntity_CrtCoreBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysModuleEntity_CrtCoreBase_CreatioDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysModuleEntity_CrtCoreBase_CreatioDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysModuleEntity_CrtCoreBase_CreatioInserted", e);
			Inserting += (s, e) => ThrowEvent("SysModuleEntity_CrtCoreBase_CreatioInserting", e);
			Saved += (s, e) => ThrowEvent("SysModuleEntity_CrtCoreBase_CreatioSaved", e);
			Saving += (s, e) => ThrowEvent("SysModuleEntity_CrtCoreBase_CreatioSaving", e);
			Validating += (s, e) => ThrowEvent("SysModuleEntity_CrtCoreBase_CreatioValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysModuleEntity_CrtCoreBase_Creatio(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysModuleEntity_CrtCoreBaseEventsProcess

	/// <exclude/>
	public partial class SysModuleEntity_CrtCoreBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysModuleEntity_CrtCoreBase_Creatio
	{

		public SysModuleEntity_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysModuleEntity_CrtCoreBaseEventsProcess";
			SchemaUId = new Guid("9c762665-90ad-497b-ac4b-45bb729630a1");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("9c762665-90ad-497b-ac4b-45bb729630a1");
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

	#region Class: SysModuleEntity_CrtCoreBaseEventsProcess

	/// <exclude/>
	public class SysModuleEntity_CrtCoreBaseEventsProcess : SysModuleEntity_CrtCoreBaseEventsProcess<SysModuleEntity_CrtCoreBase_Creatio>
	{

		public SysModuleEntity_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysModuleEntity_CrtCoreBaseEventsProcess

	public partial class SysModuleEntity_CrtCoreBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

