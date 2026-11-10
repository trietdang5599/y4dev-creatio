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

	#region Class: MLModelColumnTypeSchema

	/// <exclude/>
	public class MLModelColumnTypeSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public MLModelColumnTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public MLModelColumnTypeSchema(MLModelColumnTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public MLModelColumnTypeSchema(MLModelColumnTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("cd028dd3-6f53-10d3-345f-cd38863ae5d4");
			RealUId = new Guid("cd028dd3-6f53-10d3-345f-cd38863ae5d4");
			Name = "MLModelColumnType";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("cad98641-0ee5-4173-9c03-6ef86b0857c5");
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
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new MLModelColumnType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new MLModelColumnType_CrtMLEventsProcess(userConnection);
		}

		public override object Clone() {
			return new MLModelColumnTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new MLModelColumnTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("cd028dd3-6f53-10d3-345f-cd38863ae5d4"));
		}

		#endregion

	}

	#endregion

	#region Class: MLModelColumnType

	/// <summary>
	/// ML model column type.
	/// </summary>
	public class MLModelColumnType : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public MLModelColumnType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MLModelColumnType";
		}

		public MLModelColumnType(MLModelColumnType source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new MLModelColumnType_CrtMLEventsProcess(UserConnection);
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
			return new MLModelColumnType(this);
		}

		#endregion

	}

	#endregion

	#region Class: MLModelColumnType_CrtMLEventsProcess

	/// <exclude/>
	public partial class MLModelColumnType_CrtMLEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : MLModelColumnType
	{

		public MLModelColumnType_CrtMLEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "MLModelColumnType_CrtMLEventsProcess";
			SchemaUId = new Guid("cd028dd3-6f53-10d3-345f-cd38863ae5d4");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("cd028dd3-6f53-10d3-345f-cd38863ae5d4");
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

	#region Class: MLModelColumnType_CrtMLEventsProcess

	/// <exclude/>
	public class MLModelColumnType_CrtMLEventsProcess : MLModelColumnType_CrtMLEventsProcess<MLModelColumnType>
	{

		public MLModelColumnType_CrtMLEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: MLModelColumnType_CrtMLEventsProcess

	public partial class MLModelColumnType_CrtMLEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: MLModelColumnTypeEventsProcess

	/// <exclude/>
	public class MLModelColumnTypeEventsProcess : MLModelColumnType_CrtMLEventsProcess
	{

		public MLModelColumnTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

