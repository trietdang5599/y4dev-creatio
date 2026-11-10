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

	#region Class: SysSegmentExitModeSchema

	/// <exclude/>
	public class SysSegmentExitModeSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public SysSegmentExitModeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysSegmentExitModeSchema(SysSegmentExitModeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysSegmentExitModeSchema(SysSegmentExitModeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0c32ec6c-943c-472f-ba68-e3dee139a524");
			RealUId = new Guid("0c32ec6c-943c-472f-ba68-e3dee139a524");
			Name = "SysSegmentExitMode";
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
			return new SysSegmentExitMode(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysSegmentExitMode_CrtSegmentationEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysSegmentExitModeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysSegmentExitModeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0c32ec6c-943c-472f-ba68-e3dee139a524"));
		}

		#endregion

	}

	#endregion

	#region Class: SysSegmentExitMode

	/// <summary>
	/// Segment exit mode.
	/// </summary>
	public class SysSegmentExitMode : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public SysSegmentExitMode(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysSegmentExitMode";
		}

		public SysSegmentExitMode(SysSegmentExitMode source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysSegmentExitMode_CrtSegmentationEventsProcess(UserConnection);
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
			return new SysSegmentExitMode(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysSegmentExitMode_CrtSegmentationEventsProcess

	/// <exclude/>
	public partial class SysSegmentExitMode_CrtSegmentationEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysSegmentExitMode
	{

		public SysSegmentExitMode_CrtSegmentationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysSegmentExitMode_CrtSegmentationEventsProcess";
			SchemaUId = new Guid("0c32ec6c-943c-472f-ba68-e3dee139a524");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("0c32ec6c-943c-472f-ba68-e3dee139a524");
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

	#region Class: SysSegmentExitMode_CrtSegmentationEventsProcess

	/// <exclude/>
	public class SysSegmentExitMode_CrtSegmentationEventsProcess : SysSegmentExitMode_CrtSegmentationEventsProcess<SysSegmentExitMode>
	{

		public SysSegmentExitMode_CrtSegmentationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysSegmentExitMode_CrtSegmentationEventsProcess

	public partial class SysSegmentExitMode_CrtSegmentationEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysSegmentExitModeEventsProcess

	/// <exclude/>
	public class SysSegmentExitModeEventsProcess : SysSegmentExitMode_CrtSegmentationEventsProcess
	{

		public SysSegmentExitModeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

