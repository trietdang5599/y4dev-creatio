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

	#region Class: SegmentResumeModeSchema

	/// <exclude/>
	public class SegmentResumeModeSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public SegmentResumeModeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SegmentResumeModeSchema(SegmentResumeModeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SegmentResumeModeSchema(SegmentResumeModeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a6913a8a-2b1e-43a6-88ba-003407ed1334");
			RealUId = new Guid("a6913a8a-2b1e-43a6-88ba-003407ed1334");
			Name = "SegmentResumeMode";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("17c282fb-177d-4424-a984-3d2c606e7aad");
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
			return new SegmentResumeMode(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SegmentResumeMode_CrtSegmentationEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SegmentResumeModeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SegmentResumeModeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a6913a8a-2b1e-43a6-88ba-003407ed1334"));
		}

		#endregion

	}

	#endregion

	#region Class: SegmentResumeMode

	/// <summary>
	/// Segment resume mode.
	/// </summary>
	public class SegmentResumeMode : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public SegmentResumeMode(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SegmentResumeMode";
		}

		public SegmentResumeMode(SegmentResumeMode source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SegmentResumeMode_CrtSegmentationEventsProcess(UserConnection);
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
			return new SegmentResumeMode(this);
		}

		#endregion

	}

	#endregion

	#region Class: SegmentResumeMode_CrtSegmentationEventsProcess

	/// <exclude/>
	public partial class SegmentResumeMode_CrtSegmentationEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : SegmentResumeMode
	{

		public SegmentResumeMode_CrtSegmentationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SegmentResumeMode_CrtSegmentationEventsProcess";
			SchemaUId = new Guid("a6913a8a-2b1e-43a6-88ba-003407ed1334");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("a6913a8a-2b1e-43a6-88ba-003407ed1334");
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

	#region Class: SegmentResumeMode_CrtSegmentationEventsProcess

	/// <exclude/>
	public class SegmentResumeMode_CrtSegmentationEventsProcess : SegmentResumeMode_CrtSegmentationEventsProcess<SegmentResumeMode>
	{

		public SegmentResumeMode_CrtSegmentationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SegmentResumeMode_CrtSegmentationEventsProcess

	public partial class SegmentResumeMode_CrtSegmentationEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SegmentResumeModeEventsProcess

	/// <exclude/>
	public class SegmentResumeModeEventsProcess : SegmentResumeMode_CrtSegmentationEventsProcess
	{

		public SegmentResumeModeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

