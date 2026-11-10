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

	#region Class: DeduplicateOperationSchema

	/// <exclude/>
	public class DeduplicateOperationSchema : Terrasoft.Configuration.LookupSchema
	{

		#region Constructors: Public

		public DeduplicateOperationSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public DeduplicateOperationSchema(DeduplicateOperationSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public DeduplicateOperationSchema(DeduplicateOperationSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("34c91fed-b922-43f7-a0d4-03aed72f7833");
			RealUId = new Guid("34c91fed-b922-43f7-a0d4-03aed72f7833");
			Name = "DeduplicateOperation";
			ParentSchemaUId = new Guid("2aecdb97-990e-4c17-96f4-240ca6531c84");
			ExtendParent = false;
			CreatedInPackageId = new Guid("a2cb4b0a-72d7-4fbf-b57c-bc3bae7898e7");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
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
			return new DeduplicateOperation(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new DeduplicateOperation_CrtDeduplicationEventsProcess(userConnection);
		}

		public override object Clone() {
			return new DeduplicateOperationSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new DeduplicateOperationSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("34c91fed-b922-43f7-a0d4-03aed72f7833"));
		}

		#endregion

	}

	#endregion

	#region Class: DeduplicateOperation

	/// <summary>
	/// Deduplication operation.
	/// </summary>
	public class DeduplicateOperation : Terrasoft.Configuration.Lookup
	{

		#region Constructors: Public

		public DeduplicateOperation(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "DeduplicateOperation";
		}

		public DeduplicateOperation(DeduplicateOperation source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new DeduplicateOperation_CrtDeduplicationEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("DeduplicateOperationDeleted", e);
			Validating += (s, e) => ThrowEvent("DeduplicateOperationValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new DeduplicateOperation(this);
		}

		#endregion

	}

	#endregion

	#region Class: DeduplicateOperation_CrtDeduplicationEventsProcess

	/// <exclude/>
	public partial class DeduplicateOperation_CrtDeduplicationEventsProcess<TEntity> : Terrasoft.Configuration.Lookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : DeduplicateOperation
	{

		public DeduplicateOperation_CrtDeduplicationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "DeduplicateOperation_CrtDeduplicationEventsProcess";
			SchemaUId = new Guid("34c91fed-b922-43f7-a0d4-03aed72f7833");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("34c91fed-b922-43f7-a0d4-03aed72f7833");
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

	#region Class: DeduplicateOperation_CrtDeduplicationEventsProcess

	/// <exclude/>
	public class DeduplicateOperation_CrtDeduplicationEventsProcess : DeduplicateOperation_CrtDeduplicationEventsProcess<DeduplicateOperation>
	{

		public DeduplicateOperation_CrtDeduplicationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: DeduplicateOperation_CrtDeduplicationEventsProcess

	public partial class DeduplicateOperation_CrtDeduplicationEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: DeduplicateOperationEventsProcess

	/// <exclude/>
	public class DeduplicateOperationEventsProcess : DeduplicateOperation_CrtDeduplicationEventsProcess
	{

		public DeduplicateOperationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

