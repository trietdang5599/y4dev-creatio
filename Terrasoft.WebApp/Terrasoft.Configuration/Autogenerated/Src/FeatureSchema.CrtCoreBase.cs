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

	#region Class: FeatureSchema

	/// <exclude/>
	public class FeatureSchema : Terrasoft.Configuration.BaseCodeLookupSchema
	{

		#region Constructors: Public

		public FeatureSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public FeatureSchema(FeatureSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public FeatureSchema(FeatureSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("28f8de6e-0c1e-4100-a868-11c6b934575f");
			RealUId = new Guid("28f8de6e-0c1e-4100-a868-11c6b934575f");
			Name = "Feature";
			ParentSchemaUId = new Guid("2681062b-df59-4e52-89ed-f9b7dc909ab2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("2e3e95a4-2024-4552-b820-30e9633c8933");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
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
			if (Columns.FindByUId(new Guid("e04c95c8-b8d3-5e4d-c0b4-789430916f33")) == null) {
				Columns.Add(CreateDefaultStateColumn());
			}
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.DataValueType = DataValueTypeManager.GetInstanceByName("LongText");
			column.ModifiedInSchemaUId = new Guid("28f8de6e-0c1e-4100-a868-11c6b934575f");
			return column;
		}

		protected override EntitySchemaColumn CreateCodeColumn() {
			EntitySchemaColumn column = base.CreateCodeColumn();
			column.DataValueType = DataValueTypeManager.GetInstanceByName("LongText");
			column.ModifiedInSchemaUId = new Guid("28f8de6e-0c1e-4100-a868-11c6b934575f");
			return column;
		}

		protected virtual EntitySchemaColumn CreateDefaultStateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("e04c95c8-b8d3-5e4d-c0b4-789430916f33"),
				Name = @"DefaultState",
				CreatedInSchemaUId = new Guid("28f8de6e-0c1e-4100-a868-11c6b934575f"),
				ModifiedInSchemaUId = new Guid("28f8de6e-0c1e-4100-a868-11c6b934575f"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Feature(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Feature_CrtCoreBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new FeatureSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new FeatureSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("28f8de6e-0c1e-4100-a868-11c6b934575f"));
		}

		#endregion

	}

	#endregion

	#region Class: Feature

	/// <summary>
	/// Creatio functionality.
	/// </summary>
	public class Feature : Terrasoft.Configuration.BaseCodeLookup
	{

		#region Constructors: Public

		public Feature(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Feature";
		}

		public Feature(Feature source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Default state.
		/// </summary>
		public int DefaultState {
			get {
				return GetTypedColumnValue<int>("DefaultState");
			}
			set {
				SetColumnValue("DefaultState", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Feature_CrtCoreBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("FeatureDeleted", e);
			Validating += (s, e) => ThrowEvent("FeatureValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Feature(this);
		}

		#endregion

	}

	#endregion

	#region Class: Feature_CrtCoreBaseEventsProcess

	/// <exclude/>
	public partial class Feature_CrtCoreBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseCodeLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : Feature
	{

		public Feature_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Feature_CrtCoreBaseEventsProcess";
			SchemaUId = new Guid("28f8de6e-0c1e-4100-a868-11c6b934575f");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("28f8de6e-0c1e-4100-a868-11c6b934575f");
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

	#region Class: Feature_CrtCoreBaseEventsProcess

	/// <exclude/>
	public class Feature_CrtCoreBaseEventsProcess : Feature_CrtCoreBaseEventsProcess<Feature>
	{

		public Feature_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Feature_CrtCoreBaseEventsProcess

	public partial class Feature_CrtCoreBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: FeatureEventsProcess

	/// <exclude/>
	public class FeatureEventsProcess : Feature_CrtCoreBaseEventsProcess
	{

		public FeatureEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

