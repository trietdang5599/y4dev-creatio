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

	#region Class: PropositionResultSchema

	/// <exclude/>
	public class PropositionResultSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public PropositionResultSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public PropositionResultSchema(PropositionResultSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public PropositionResultSchema(PropositionResultSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("801a201c-7040-4489-a705-5896b20d2f52");
			RealUId = new Guid("801a201c-7040-4489-a705-5896b20d2f52");
			Name = "PropositionResult";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
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
			return new PropositionResult(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new PropositionResult_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new PropositionResultSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new PropositionResultSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("801a201c-7040-4489-a705-5896b20d2f52"));
		}

		#endregion

	}

	#endregion

	#region Class: PropositionResult

	/// <summary>
	/// Quote Result.
	/// </summary>
	public class PropositionResult : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public PropositionResult(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "PropositionResult";
		}

		public PropositionResult(PropositionResult source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new PropositionResult_CrtBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("PropositionResultDeleted", e);
			Deleting += (s, e) => ThrowEvent("PropositionResultDeleting", e);
			Inserted += (s, e) => ThrowEvent("PropositionResultInserted", e);
			Inserting += (s, e) => ThrowEvent("PropositionResultInserting", e);
			Saved += (s, e) => ThrowEvent("PropositionResultSaved", e);
			Saving += (s, e) => ThrowEvent("PropositionResultSaving", e);
			Validating += (s, e) => ThrowEvent("PropositionResultValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new PropositionResult(this);
		}

		#endregion

	}

	#endregion

	#region Class: PropositionResult_CrtBaseEventsProcess

	/// <exclude/>
	public partial class PropositionResult_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : PropositionResult
	{

		public PropositionResult_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "PropositionResult_CrtBaseEventsProcess";
			SchemaUId = new Guid("801a201c-7040-4489-a705-5896b20d2f52");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("801a201c-7040-4489-a705-5896b20d2f52");
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

	#region Class: PropositionResult_CrtBaseEventsProcess

	/// <exclude/>
	public class PropositionResult_CrtBaseEventsProcess : PropositionResult_CrtBaseEventsProcess<PropositionResult>
	{

		public PropositionResult_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: PropositionResult_CrtBaseEventsProcess

	public partial class PropositionResult_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: PropositionResultEventsProcess

	/// <exclude/>
	public class PropositionResultEventsProcess : PropositionResult_CrtBaseEventsProcess
	{

		public PropositionResultEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

