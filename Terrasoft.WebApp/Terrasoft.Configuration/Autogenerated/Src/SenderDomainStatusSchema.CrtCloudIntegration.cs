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

	#region Class: SenderDomainStatusSchema

	/// <exclude/>
	public class SenderDomainStatusSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public SenderDomainStatusSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SenderDomainStatusSchema(SenderDomainStatusSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SenderDomainStatusSchema(SenderDomainStatusSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("bc488040-3b2b-4566-bd9a-01cd9f99919f");
			RealUId = new Guid("bc488040-3b2b-4566-bd9a-01cd9f99919f");
			Name = "SenderDomainStatus";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("fc1a2769-1cc9-44d3-a1a6-003d1b8450f5");
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
				UId = new Guid("2b51f367-b985-23dc-bc65-e1349322ec0d"),
				Name = @"Color",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("bc488040-3b2b-4566-bd9a-01cd9f99919f"),
				ModifiedInSchemaUId = new Guid("bc488040-3b2b-4566-bd9a-01cd9f99919f"),
				CreatedInPackageId = new Guid("fc1a2769-1cc9-44d3-a1a6-003d1b8450f5")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SenderDomainStatus(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SenderDomainStatus_CrtCloudIntegrationEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SenderDomainStatusSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SenderDomainStatusSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("bc488040-3b2b-4566-bd9a-01cd9f99919f"));
		}

		#endregion

	}

	#endregion

	#region Class: SenderDomainStatus

	/// <summary>
	/// Sender domain status.
	/// </summary>
	public class SenderDomainStatus : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public SenderDomainStatus(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SenderDomainStatus";
		}

		public SenderDomainStatus(SenderDomainStatus source)
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
			var process = new SenderDomainStatus_CrtCloudIntegrationEventsProcess(UserConnection);
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
			return new SenderDomainStatus(this);
		}

		#endregion

	}

	#endregion

	#region Class: SenderDomainStatus_CrtCloudIntegrationEventsProcess

	/// <exclude/>
	public partial class SenderDomainStatus_CrtCloudIntegrationEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : SenderDomainStatus
	{

		public SenderDomainStatus_CrtCloudIntegrationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SenderDomainStatus_CrtCloudIntegrationEventsProcess";
			SchemaUId = new Guid("bc488040-3b2b-4566-bd9a-01cd9f99919f");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("bc488040-3b2b-4566-bd9a-01cd9f99919f");
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

	#region Class: SenderDomainStatus_CrtCloudIntegrationEventsProcess

	/// <exclude/>
	public class SenderDomainStatus_CrtCloudIntegrationEventsProcess : SenderDomainStatus_CrtCloudIntegrationEventsProcess<SenderDomainStatus>
	{

		public SenderDomainStatus_CrtCloudIntegrationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SenderDomainStatus_CrtCloudIntegrationEventsProcess

	public partial class SenderDomainStatus_CrtCloudIntegrationEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SenderDomainStatusEventsProcess

	/// <exclude/>
	public class SenderDomainStatusEventsProcess : SenderDomainStatus_CrtCloudIntegrationEventsProcess
	{

		public SenderDomainStatusEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

