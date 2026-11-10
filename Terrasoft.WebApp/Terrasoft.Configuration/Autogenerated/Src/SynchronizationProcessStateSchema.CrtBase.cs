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

	#region Class: SynchronizationProcessStateSchema

	/// <exclude/>
	public class SynchronizationProcessStateSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public SynchronizationProcessStateSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SynchronizationProcessStateSchema(SynchronizationProcessStateSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SynchronizationProcessStateSchema(SynchronizationProcessStateSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("af74e228-c087-4d54-9dbb-d329b65b6afa");
			RealUId = new Guid("af74e228-c087-4d54-9dbb-d329b65b6afa");
			Name = "SynchronizationProcessState";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
			DesignLocalizationSchemaName = @"SysSyncProcessStateLcz";
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("729ff718-d5e7-4cf2-9bcf-a5ce51639fbf")) == null) {
				Columns.Add(CreateValueColumn());
			}
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("af74e228-c087-4d54-9dbb-d329b65b6afa");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("af74e228-c087-4d54-9dbb-d329b65b6afa");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected virtual EntitySchemaColumn CreateValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("729ff718-d5e7-4cf2-9bcf-a5ce51639fbf"),
				Name = @"Value",
				CreatedInSchemaUId = new Guid("af74e228-c087-4d54-9dbb-d329b65b6afa"),
				ModifiedInSchemaUId = new Guid("af74e228-c087-4d54-9dbb-d329b65b6afa"),
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
			return new SynchronizationProcessState(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SynchronizationProcessState_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SynchronizationProcessStateSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SynchronizationProcessStateSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("af74e228-c087-4d54-9dbb-d329b65b6afa"));
		}

		#endregion

	}

	#endregion

	#region Class: SynchronizationProcessState

	/// <summary>
	/// Synchronization process state.
	/// </summary>
	public class SynchronizationProcessState : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public SynchronizationProcessState(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SynchronizationProcessState";
		}

		public SynchronizationProcessState(SynchronizationProcessState source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Value.
		/// </summary>
		public int Value {
			get {
				return GetTypedColumnValue<int>("Value");
			}
			set {
				SetColumnValue("Value", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SynchronizationProcessState_CrtBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SynchronizationProcessStateDeleted", e);
			Inserting += (s, e) => ThrowEvent("SynchronizationProcessStateInserting", e);
			Validating += (s, e) => ThrowEvent("SynchronizationProcessStateValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SynchronizationProcessState(this);
		}

		#endregion

	}

	#endregion

	#region Class: SynchronizationProcessState_CrtBaseEventsProcess

	/// <exclude/>
	public partial class SynchronizationProcessState_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : SynchronizationProcessState
	{

		public SynchronizationProcessState_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SynchronizationProcessState_CrtBaseEventsProcess";
			SchemaUId = new Guid("af74e228-c087-4d54-9dbb-d329b65b6afa");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("af74e228-c087-4d54-9dbb-d329b65b6afa");
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

	#region Class: SynchronizationProcessState_CrtBaseEventsProcess

	/// <exclude/>
	public class SynchronizationProcessState_CrtBaseEventsProcess : SynchronizationProcessState_CrtBaseEventsProcess<SynchronizationProcessState>
	{

		public SynchronizationProcessState_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SynchronizationProcessState_CrtBaseEventsProcess

	public partial class SynchronizationProcessState_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SynchronizationProcessStateEventsProcess

	/// <exclude/>
	public class SynchronizationProcessStateEventsProcess : SynchronizationProcessState_CrtBaseEventsProcess
	{

		public SynchronizationProcessStateEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

