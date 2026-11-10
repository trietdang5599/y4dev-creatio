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

	#region Class: SysQueryActionSchema

	/// <exclude/>
	public class SysQueryActionSchema : Terrasoft.Configuration.BaseCodeLookupSchema
	{

		#region Constructors: Public

		public SysQueryActionSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysQueryActionSchema(SysQueryActionSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysQueryActionSchema(SysQueryActionSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIU_SysQueryAction_CodeIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = true
			};
			index.UId = new Guid("bb56822a-f65b-47c1-aad8-1857fdc79f38");
			index.Name = "IU_SysQueryAction_Code";
			index.CreatedInSchemaUId = new Guid("8bc63dbf-e5fa-4635-afed-a3c8f853a5ab");
			index.ModifiedInSchemaUId = new Guid("8bc63dbf-e5fa-4635-afed-a3c8f853a5ab");
			index.CreatedInPackageId = new Guid("24377658-5c78-47a6-b5ee-e5beab1bcee6");
			EntitySchemaIndexColumn codeIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("93cf24e5-a7a0-e73f-582a-d0780e33d5d3"),
				ColumnUId = new Guid("13aad544-ec30-4e76-a373-f0cff3202e24"),
				CreatedInSchemaUId = new Guid("8bc63dbf-e5fa-4635-afed-a3c8f853a5ab"),
				ModifiedInSchemaUId = new Guid("8bc63dbf-e5fa-4635-afed-a3c8f853a5ab"),
				CreatedInPackageId = new Guid("24377658-5c78-47a6-b5ee-e5beab1bcee6"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(codeIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("8bc63dbf-e5fa-4635-afed-a3c8f853a5ab");
			RealUId = new Guid("8bc63dbf-e5fa-4635-afed-a3c8f853a5ab");
			Name = "SysQueryAction";
			ParentSchemaUId = new Guid("2681062b-df59-4e52-89ed-f9b7dc909ab2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("7b5e3dcc-55e1-412a-833e-7c39ca77d614");
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

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIU_SysQueryAction_CodeIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysQueryAction(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysQueryAction_QueryExecutionRulesEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysQueryActionSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysQueryActionSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("8bc63dbf-e5fa-4635-afed-a3c8f853a5ab"));
		}

		#endregion

	}

	#endregion

	#region Class: SysQueryAction

	/// <summary>
	/// Query action.
	/// </summary>
	public class SysQueryAction : Terrasoft.Configuration.BaseCodeLookup
	{

		#region Constructors: Public

		public SysQueryAction(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysQueryAction";
		}

		public SysQueryAction(SysQueryAction source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysQueryAction_QueryExecutionRulesEventsProcess(UserConnection);
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
			return new SysQueryAction(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysQueryAction_QueryExecutionRulesEventsProcess

	/// <exclude/>
	public partial class SysQueryAction_QueryExecutionRulesEventsProcess<TEntity> : Terrasoft.Configuration.BaseCodeLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysQueryAction
	{

		public SysQueryAction_QueryExecutionRulesEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysQueryAction_QueryExecutionRulesEventsProcess";
			SchemaUId = new Guid("8bc63dbf-e5fa-4635-afed-a3c8f853a5ab");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("8bc63dbf-e5fa-4635-afed-a3c8f853a5ab");
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

	#region Class: SysQueryAction_QueryExecutionRulesEventsProcess

	/// <exclude/>
	public class SysQueryAction_QueryExecutionRulesEventsProcess : SysQueryAction_QueryExecutionRulesEventsProcess<SysQueryAction>
	{

		public SysQueryAction_QueryExecutionRulesEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysQueryAction_QueryExecutionRulesEventsProcess

	public partial class SysQueryAction_QueryExecutionRulesEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysQueryActionEventsProcess

	/// <exclude/>
	public class SysQueryActionEventsProcess : SysQueryAction_QueryExecutionRulesEventsProcess
	{

		public SysQueryActionEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

