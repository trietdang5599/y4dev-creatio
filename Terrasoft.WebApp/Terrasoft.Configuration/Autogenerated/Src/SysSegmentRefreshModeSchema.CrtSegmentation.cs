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

	#region Class: SysSegmentRefreshModeSchema

	/// <exclude/>
	public class SysSegmentRefreshModeSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public SysSegmentRefreshModeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysSegmentRefreshModeSchema(SysSegmentRefreshModeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysSegmentRefreshModeSchema(SysSegmentRefreshModeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ffc2da14-9e8b-4518-95c8-eb0d7a2b98f8");
			RealUId = new Guid("ffc2da14-9e8b-4518-95c8-eb0d7a2b98f8");
			Name = "SysSegmentRefreshMode";
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
			return new SysSegmentRefreshMode(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysSegmentRefreshMode_CrtSegmentationEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysSegmentRefreshModeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysSegmentRefreshModeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ffc2da14-9e8b-4518-95c8-eb0d7a2b98f8"));
		}

		#endregion

	}

	#endregion

	#region Class: SysSegmentRefreshMode

	/// <summary>
	/// Segment refresh mode.
	/// </summary>
	public class SysSegmentRefreshMode : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public SysSegmentRefreshMode(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysSegmentRefreshMode";
		}

		public SysSegmentRefreshMode(SysSegmentRefreshMode source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysSegmentRefreshMode_CrtSegmentationEventsProcess(UserConnection);
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
			return new SysSegmentRefreshMode(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysSegmentRefreshMode_CrtSegmentationEventsProcess

	/// <exclude/>
	public partial class SysSegmentRefreshMode_CrtSegmentationEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysSegmentRefreshMode
	{

		public SysSegmentRefreshMode_CrtSegmentationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysSegmentRefreshMode_CrtSegmentationEventsProcess";
			SchemaUId = new Guid("ffc2da14-9e8b-4518-95c8-eb0d7a2b98f8");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ffc2da14-9e8b-4518-95c8-eb0d7a2b98f8");
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

	#region Class: SysSegmentRefreshMode_CrtSegmentationEventsProcess

	/// <exclude/>
	public class SysSegmentRefreshMode_CrtSegmentationEventsProcess : SysSegmentRefreshMode_CrtSegmentationEventsProcess<SysSegmentRefreshMode>
	{

		public SysSegmentRefreshMode_CrtSegmentationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysSegmentRefreshMode_CrtSegmentationEventsProcess

	public partial class SysSegmentRefreshMode_CrtSegmentationEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysSegmentRefreshModeEventsProcess

	/// <exclude/>
	public class SysSegmentRefreshModeEventsProcess : SysSegmentRefreshMode_CrtSegmentationEventsProcess
	{

		public SysSegmentRefreshModeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

