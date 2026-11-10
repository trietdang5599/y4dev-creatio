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

	#region Class: SysSegmentSystemStatusSchema

	/// <exclude/>
	public class SysSegmentSystemStatusSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public SysSegmentSystemStatusSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysSegmentSystemStatusSchema(SysSegmentSystemStatusSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysSegmentSystemStatusSchema(SysSegmentSystemStatusSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4d8e6e3c-2e7b-4eff-8636-f0eda136eba2");
			RealUId = new Guid("4d8e6e3c-2e7b-4eff-8636-f0eda136eba2");
			Name = "SysSegmentSystemStatus";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("e977f9d9-4739-4382-993f-c704e8026345");
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
			return new SysSegmentSystemStatus(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysSegmentSystemStatus_CrtSegmentationEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysSegmentSystemStatusSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysSegmentSystemStatusSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4d8e6e3c-2e7b-4eff-8636-f0eda136eba2"));
		}

		#endregion

	}

	#endregion

	#region Class: SysSegmentSystemStatus

	/// <summary>
	/// Segment system status.
	/// </summary>
	public class SysSegmentSystemStatus : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public SysSegmentSystemStatus(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysSegmentSystemStatus";
		}

		public SysSegmentSystemStatus(SysSegmentSystemStatus source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysSegmentSystemStatus_CrtSegmentationEventsProcess(UserConnection);
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
			return new SysSegmentSystemStatus(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysSegmentSystemStatus_CrtSegmentationEventsProcess

	/// <exclude/>
	public partial class SysSegmentSystemStatus_CrtSegmentationEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysSegmentSystemStatus
	{

		public SysSegmentSystemStatus_CrtSegmentationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysSegmentSystemStatus_CrtSegmentationEventsProcess";
			SchemaUId = new Guid("4d8e6e3c-2e7b-4eff-8636-f0eda136eba2");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("4d8e6e3c-2e7b-4eff-8636-f0eda136eba2");
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

	#region Class: SysSegmentSystemStatus_CrtSegmentationEventsProcess

	/// <exclude/>
	public class SysSegmentSystemStatus_CrtSegmentationEventsProcess : SysSegmentSystemStatus_CrtSegmentationEventsProcess<SysSegmentSystemStatus>
	{

		public SysSegmentSystemStatus_CrtSegmentationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysSegmentSystemStatus_CrtSegmentationEventsProcess

	public partial class SysSegmentSystemStatus_CrtSegmentationEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysSegmentSystemStatusEventsProcess

	/// <exclude/>
	public class SysSegmentSystemStatusEventsProcess : SysSegmentSystemStatus_CrtSegmentationEventsProcess
	{

		public SysSegmentSystemStatusEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

