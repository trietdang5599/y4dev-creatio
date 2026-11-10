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

	#region Class: SysSegmentUserStatusSchema

	/// <exclude/>
	public class SysSegmentUserStatusSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public SysSegmentUserStatusSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysSegmentUserStatusSchema(SysSegmentUserStatusSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysSegmentUserStatusSchema(SysSegmentUserStatusSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("3eeed09c-3a42-47f0-81fa-b37973bcb342");
			RealUId = new Guid("3eeed09c-3a42-47f0-81fa-b37973bcb342");
			Name = "SysSegmentUserStatus";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("bc787634-383d-40bd-9054-9c3505b00b85");
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

		protected override void InitializePrimaryColorColumn() {
			base.InitializePrimaryColorColumn();
			PrimaryColorColumn = CreateColorColumn();
			if (Columns.FindByUId(PrimaryColorColumn.UId) == null) {
				Columns.Add(PrimaryColorColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected virtual EntitySchemaColumn CreateColorColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Color")) {
				UId = new Guid("66924fc0-37d6-6ed6-7908-577005801fc3"),
				Name = @"Color",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("3eeed09c-3a42-47f0-81fa-b37973bcb342"),
				ModifiedInSchemaUId = new Guid("3eeed09c-3a42-47f0-81fa-b37973bcb342"),
				CreatedInPackageId = new Guid("17c282fb-177d-4424-a984-3d2c606e7aad")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysSegmentUserStatus(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysSegmentUserStatus_CrtSegmentationEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysSegmentUserStatusSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysSegmentUserStatusSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3eeed09c-3a42-47f0-81fa-b37973bcb342"));
		}

		#endregion

	}

	#endregion

	#region Class: SysSegmentUserStatus

	/// <summary>
	/// Segment user status.
	/// </summary>
	public class SysSegmentUserStatus : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public SysSegmentUserStatus(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysSegmentUserStatus";
		}

		public SysSegmentUserStatus(SysSegmentUserStatus source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Color.
		/// </summary>
		public Color Color {
			get {
				return GetTypedColumnValue<Color>("Color");
			}
			set {
				SetColumnValue("Color", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysSegmentUserStatus_CrtSegmentationEventsProcess(UserConnection);
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
			return new SysSegmentUserStatus(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysSegmentUserStatus_CrtSegmentationEventsProcess

	/// <exclude/>
	public partial class SysSegmentUserStatus_CrtSegmentationEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysSegmentUserStatus
	{

		public SysSegmentUserStatus_CrtSegmentationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysSegmentUserStatus_CrtSegmentationEventsProcess";
			SchemaUId = new Guid("3eeed09c-3a42-47f0-81fa-b37973bcb342");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("3eeed09c-3a42-47f0-81fa-b37973bcb342");
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

	#region Class: SysSegmentUserStatus_CrtSegmentationEventsProcess

	/// <exclude/>
	public class SysSegmentUserStatus_CrtSegmentationEventsProcess : SysSegmentUserStatus_CrtSegmentationEventsProcess<SysSegmentUserStatus>
	{

		public SysSegmentUserStatus_CrtSegmentationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysSegmentUserStatus_CrtSegmentationEventsProcess

	public partial class SysSegmentUserStatus_CrtSegmentationEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysSegmentUserStatusEventsProcess

	/// <exclude/>
	public class SysSegmentUserStatusEventsProcess : SysSegmentUserStatus_CrtSegmentationEventsProcess
	{

		public SysSegmentUserStatusEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

