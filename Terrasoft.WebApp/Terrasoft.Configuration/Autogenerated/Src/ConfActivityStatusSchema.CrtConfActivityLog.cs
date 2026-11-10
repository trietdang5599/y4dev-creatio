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

	#region Class: ConfActivityStatusSchema

	/// <exclude/>
	public class ConfActivityStatusSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public ConfActivityStatusSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ConfActivityStatusSchema(ConfActivityStatusSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ConfActivityStatusSchema(ConfActivityStatusSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5e88ab22-8e77-4bf7-b9cb-1a4ec849776d");
			RealUId = new Guid("5e88ab22-8e77-4bf7-b9cb-1a4ec849776d");
			Name = "ConfActivityStatus";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("b442e8fe-c84e-419d-bd0d-cf5572b3d3f7");
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
				UId = new Guid("7425ffb7-b596-fe7e-cd5d-e217ec730c60"),
				Name = @"Color",
				CreatedInSchemaUId = new Guid("5e88ab22-8e77-4bf7-b9cb-1a4ec849776d"),
				ModifiedInSchemaUId = new Guid("5e88ab22-8e77-4bf7-b9cb-1a4ec849776d"),
				CreatedInPackageId = new Guid("b442e8fe-c84e-419d-bd0d-cf5572b3d3f7")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ConfActivityStatus(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ConfActivityStatus_CrtConfActivityLogEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ConfActivityStatusSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ConfActivityStatusSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5e88ab22-8e77-4bf7-b9cb-1a4ec849776d"));
		}

		#endregion

	}

	#endregion

	#region Class: ConfActivityStatus

	/// <summary>
	/// Configuration activity status.
	/// </summary>
	public class ConfActivityStatus : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public ConfActivityStatus(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ConfActivityStatus";
		}

		public ConfActivityStatus(ConfActivityStatus source)
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
			var process = new ConfActivityStatus_CrtConfActivityLogEventsProcess(UserConnection);
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
			return new ConfActivityStatus(this);
		}

		#endregion

	}

	#endregion

	#region Class: ConfActivityStatus_CrtConfActivityLogEventsProcess

	/// <exclude/>
	public partial class ConfActivityStatus_CrtConfActivityLogEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : ConfActivityStatus
	{

		public ConfActivityStatus_CrtConfActivityLogEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ConfActivityStatus_CrtConfActivityLogEventsProcess";
			SchemaUId = new Guid("5e88ab22-8e77-4bf7-b9cb-1a4ec849776d");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("5e88ab22-8e77-4bf7-b9cb-1a4ec849776d");
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

	#region Class: ConfActivityStatus_CrtConfActivityLogEventsProcess

	/// <exclude/>
	public class ConfActivityStatus_CrtConfActivityLogEventsProcess : ConfActivityStatus_CrtConfActivityLogEventsProcess<ConfActivityStatus>
	{

		public ConfActivityStatus_CrtConfActivityLogEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ConfActivityStatus_CrtConfActivityLogEventsProcess

	public partial class ConfActivityStatus_CrtConfActivityLogEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ConfActivityStatusEventsProcess

	/// <exclude/>
	public class ConfActivityStatusEventsProcess : ConfActivityStatus_CrtConfActivityLogEventsProcess
	{

		public ConfActivityStatusEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

