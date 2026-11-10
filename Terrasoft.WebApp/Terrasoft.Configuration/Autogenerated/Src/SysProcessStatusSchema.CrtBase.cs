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

	#region Class: SysProcessStatusSchema

	/// <exclude/>
	public class SysProcessStatusSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public SysProcessStatusSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysProcessStatusSchema(SysProcessStatusSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysProcessStatusSchema(SysProcessStatusSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("dc1e2217-9af0-4216-935b-ace805adc929");
			RealUId = new Guid("dc1e2217-9af0-4216-935b-ace805adc929");
			Name = "SysProcessStatus";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("5783ef4c-f89f-4f36-a2ba-5bf0e0deba6f")) == null) {
				Columns.Add(CreateValueColumn());
			}
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("dc1e2217-9af0-4216-935b-ace805adc929");
			column.CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("dc1e2217-9af0-4216-935b-ace805adc929");
			column.CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c");
			return column;
		}

		protected virtual EntitySchemaColumn CreateValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("5783ef4c-f89f-4f36-a2ba-5bf0e0deba6f"),
				Name = @"Value",
				CreatedInSchemaUId = new Guid("dc1e2217-9af0-4216-935b-ace805adc929"),
				ModifiedInSchemaUId = new Guid("dc1e2217-9af0-4216-935b-ace805adc929"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysProcessStatus(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysProcessStatus_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysProcessStatusSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysProcessStatusSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("dc1e2217-9af0-4216-935b-ace805adc929"));
		}

		#endregion

	}

	#endregion

	#region Class: SysProcessStatus

	/// <summary>
	/// Process status.
	/// </summary>
	public class SysProcessStatus : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public SysProcessStatus(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysProcessStatus";
		}

		public SysProcessStatus(SysProcessStatus source)
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
			var process = new SysProcessStatus_CrtBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysProcessStatusDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysProcessStatusDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysProcessStatusInserted", e);
			Inserting += (s, e) => ThrowEvent("SysProcessStatusInserting", e);
			Saved += (s, e) => ThrowEvent("SysProcessStatusSaved", e);
			Saving += (s, e) => ThrowEvent("SysProcessStatusSaving", e);
			Validating += (s, e) => ThrowEvent("SysProcessStatusValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysProcessStatus(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysProcessStatus_CrtBaseEventsProcess

	/// <exclude/>
	public partial class SysProcessStatus_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysProcessStatus
	{

		public SysProcessStatus_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysProcessStatus_CrtBaseEventsProcess";
			SchemaUId = new Guid("dc1e2217-9af0-4216-935b-ace805adc929");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("dc1e2217-9af0-4216-935b-ace805adc929");
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

	#region Class: SysProcessStatus_CrtBaseEventsProcess

	/// <exclude/>
	public class SysProcessStatus_CrtBaseEventsProcess : SysProcessStatus_CrtBaseEventsProcess<SysProcessStatus>
	{

		public SysProcessStatus_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysProcessStatus_CrtBaseEventsProcess

	public partial class SysProcessStatus_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysProcessStatusEventsProcess

	/// <exclude/>
	public class SysProcessStatusEventsProcess : SysProcessStatus_CrtBaseEventsProcess
	{

		public SysProcessStatusEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

