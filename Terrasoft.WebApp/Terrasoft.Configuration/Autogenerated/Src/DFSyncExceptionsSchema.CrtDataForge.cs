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

	#region Class: DFSyncExceptionsSchema

	/// <exclude/>
	public class DFSyncExceptionsSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public DFSyncExceptionsSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public DFSyncExceptionsSchema(DFSyncExceptionsSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public DFSyncExceptionsSchema(DFSyncExceptionsSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("9a705a7d-2244-4176-b1d2-44933a3a7d0c");
			RealUId = new Guid("9a705a7d-2244-4176-b1d2-44933a3a7d0c");
			Name = "DFSyncExceptions";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("91aabbd5-240e-43c0-80e4-a7a9868a6c43");
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
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new DFSyncExceptions(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new DFSyncExceptions_CrtDataForgeEventsProcess(userConnection);
		}

		public override object Clone() {
			return new DFSyncExceptionsSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new DFSyncExceptionsSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9a705a7d-2244-4176-b1d2-44933a3a7d0c"));
		}

		#endregion

	}

	#endregion

	#region Class: DFSyncExceptions

	/// <summary>
	/// DataForge lookup sync exceptions.
	/// </summary>
	public class DFSyncExceptions : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public DFSyncExceptions(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "DFSyncExceptions";
		}

		public DFSyncExceptions(DFSyncExceptions source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new DFSyncExceptions_CrtDataForgeEventsProcess(UserConnection);
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
			return new DFSyncExceptions(this);
		}

		#endregion

	}

	#endregion

	#region Class: DFSyncExceptions_CrtDataForgeEventsProcess

	/// <exclude/>
	public partial class DFSyncExceptions_CrtDataForgeEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : DFSyncExceptions
	{

		public DFSyncExceptions_CrtDataForgeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "DFSyncExceptions_CrtDataForgeEventsProcess";
			SchemaUId = new Guid("9a705a7d-2244-4176-b1d2-44933a3a7d0c");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("9a705a7d-2244-4176-b1d2-44933a3a7d0c");
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

	#region Class: DFSyncExceptions_CrtDataForgeEventsProcess

	/// <exclude/>
	public class DFSyncExceptions_CrtDataForgeEventsProcess : DFSyncExceptions_CrtDataForgeEventsProcess<DFSyncExceptions>
	{

		public DFSyncExceptions_CrtDataForgeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: DFSyncExceptions_CrtDataForgeEventsProcess

	public partial class DFSyncExceptions_CrtDataForgeEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: DFSyncExceptionsEventsProcess

	/// <exclude/>
	public class DFSyncExceptionsEventsProcess : DFSyncExceptions_CrtDataForgeEventsProcess
	{

		public DFSyncExceptionsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

