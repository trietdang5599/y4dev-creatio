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

	#region Class: SysQueryDetectorSchema

	/// <exclude/>
	public class SysQueryDetectorSchema : Terrasoft.Configuration.BaseCodeLookupSchema
	{

		#region Constructors: Public

		public SysQueryDetectorSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysQueryDetectorSchema(SysQueryDetectorSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysQueryDetectorSchema(SysQueryDetectorSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIU_SysQueryDetector_CodeIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = true
			};
			index.UId = new Guid("b910f153-ce5d-4efa-be15-9513d593bbc0");
			index.Name = "IU_SysQueryDetector_Code";
			index.CreatedInSchemaUId = new Guid("63b874db-289b-4bd2-97b2-6391c737fc9e");
			index.ModifiedInSchemaUId = new Guid("63b874db-289b-4bd2-97b2-6391c737fc9e");
			index.CreatedInPackageId = new Guid("24377658-5c78-47a6-b5ee-e5beab1bcee6");
			EntitySchemaIndexColumn codeIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("19f1562d-3c50-d99e-39b2-21b4d8177ab3"),
				ColumnUId = new Guid("13aad544-ec30-4e76-a373-f0cff3202e24"),
				CreatedInSchemaUId = new Guid("63b874db-289b-4bd2-97b2-6391c737fc9e"),
				ModifiedInSchemaUId = new Guid("63b874db-289b-4bd2-97b2-6391c737fc9e"),
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
			UId = new Guid("63b874db-289b-4bd2-97b2-6391c737fc9e");
			RealUId = new Guid("63b874db-289b-4bd2-97b2-6391c737fc9e");
			Name = "SysQueryDetector";
			ParentSchemaUId = new Guid("2681062b-df59-4e52-89ed-f9b7dc909ab2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("7b5e3dcc-55e1-412a-833e-7c39ca77d614");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("068aadcd-e834-7893-21d1-b6f381fc8576")) == null) {
				Columns.Add(CreateRecommendationColumn());
			}
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.DataValueType = DataValueTypeManager.GetInstanceByName("LongText");
			column.ModifiedInSchemaUId = new Guid("63b874db-289b-4bd2-97b2-6391c737fc9e");
			return column;
		}

		protected virtual EntitySchemaColumn CreateRecommendationColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("068aadcd-e834-7893-21d1-b6f381fc8576"),
				Name = @"Recommendation",
				CreatedInSchemaUId = new Guid("63b874db-289b-4bd2-97b2-6391c737fc9e"),
				ModifiedInSchemaUId = new Guid("63b874db-289b-4bd2-97b2-6391c737fc9e"),
				CreatedInPackageId = new Guid("7b5e3dcc-55e1-412a-833e-7c39ca77d614"),
				IsLocalizable = true
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIU_SysQueryDetector_CodeIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysQueryDetector(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysQueryDetector_QueryExecutionRulesEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysQueryDetectorSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysQueryDetectorSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("63b874db-289b-4bd2-97b2-6391c737fc9e"));
		}

		#endregion

	}

	#endregion

	#region Class: SysQueryDetector

	/// <summary>
	/// Query detector.
	/// </summary>
	public class SysQueryDetector : Terrasoft.Configuration.BaseCodeLookup
	{

		#region Constructors: Public

		public SysQueryDetector(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysQueryDetector";
		}

		public SysQueryDetector(SysQueryDetector source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Recommendation.
		/// </summary>
		public string Recommendation {
			get {
				return GetTypedColumnValue<string>("Recommendation");
			}
			set {
				SetColumnValue("Recommendation", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysQueryDetector_QueryExecutionRulesEventsProcess(UserConnection);
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
			return new SysQueryDetector(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysQueryDetector_QueryExecutionRulesEventsProcess

	/// <exclude/>
	public partial class SysQueryDetector_QueryExecutionRulesEventsProcess<TEntity> : Terrasoft.Configuration.BaseCodeLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysQueryDetector
	{

		public SysQueryDetector_QueryExecutionRulesEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysQueryDetector_QueryExecutionRulesEventsProcess";
			SchemaUId = new Guid("63b874db-289b-4bd2-97b2-6391c737fc9e");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("63b874db-289b-4bd2-97b2-6391c737fc9e");
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

	#region Class: SysQueryDetector_QueryExecutionRulesEventsProcess

	/// <exclude/>
	public class SysQueryDetector_QueryExecutionRulesEventsProcess : SysQueryDetector_QueryExecutionRulesEventsProcess<SysQueryDetector>
	{

		public SysQueryDetector_QueryExecutionRulesEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysQueryDetector_QueryExecutionRulesEventsProcess

	public partial class SysQueryDetector_QueryExecutionRulesEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysQueryDetectorEventsProcess

	/// <exclude/>
	public class SysQueryDetectorEventsProcess : SysQueryDetector_QueryExecutionRulesEventsProcess
	{

		public SysQueryDetectorEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

