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

	#region Class: TaxSchema

	/// <exclude/>
	public class TaxSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public TaxSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public TaxSchema(TaxSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public TaxSchema(TaxSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a32b5f57-0ef1-4d3d-a6ef-a6de2113fbe0");
			RealUId = new Guid("a32b5f57-0ef1-4d3d-a6ef-a6de2113fbe0");
			Name = "Tax";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("09de73af-3a4c-43d2-94ff-536f40a98048")) == null) {
				Columns.Add(CreatePercentColumn());
			}
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("a32b5f57-0ef1-4d3d-a6ef-a6de2113fbe0");
			column.CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("a32b5f57-0ef1-4d3d-a6ef-a6de2113fbe0");
			column.CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c");
			return column;
		}

		protected virtual EntitySchemaColumn CreatePercentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Money")) {
				UId = new Guid("09de73af-3a4c-43d2-94ff-536f40a98048"),
				Name = @"Percent",
				CreatedInSchemaUId = new Guid("a32b5f57-0ef1-4d3d-a6ef-a6de2113fbe0"),
				ModifiedInSchemaUId = new Guid("a32b5f57-0ef1-4d3d-a6ef-a6de2113fbe0"),
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
			return new Tax(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Tax_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new TaxSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new TaxSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a32b5f57-0ef1-4d3d-a6ef-a6de2113fbe0"));
		}

		#endregion

	}

	#endregion

	#region Class: Tax

	/// <summary>
	/// Tax.
	/// </summary>
	public class Tax : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public Tax(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Tax";
		}

		public Tax(Tax source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Rate, %.
		/// </summary>
		public Decimal Percent {
			get {
				return GetTypedColumnValue<Decimal>("Percent");
			}
			set {
				SetColumnValue("Percent", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Tax_CrtBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("TaxDeleted", e);
			Deleting += (s, e) => ThrowEvent("TaxDeleting", e);
			Inserted += (s, e) => ThrowEvent("TaxInserted", e);
			Inserting += (s, e) => ThrowEvent("TaxInserting", e);
			Saved += (s, e) => ThrowEvent("TaxSaved", e);
			Saving += (s, e) => ThrowEvent("TaxSaving", e);
			Validating += (s, e) => ThrowEvent("TaxValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Tax(this);
		}

		#endregion

	}

	#endregion

	#region Class: Tax_CrtBaseEventsProcess

	/// <exclude/>
	public partial class Tax_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : Tax
	{

		public Tax_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Tax_CrtBaseEventsProcess";
			SchemaUId = new Guid("a32b5f57-0ef1-4d3d-a6ef-a6de2113fbe0");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("a32b5f57-0ef1-4d3d-a6ef-a6de2113fbe0");
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

	#region Class: Tax_CrtBaseEventsProcess

	/// <exclude/>
	public class Tax_CrtBaseEventsProcess : Tax_CrtBaseEventsProcess<Tax>
	{

		public Tax_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Tax_CrtBaseEventsProcess

	public partial class Tax_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: TaxEventsProcess

	/// <exclude/>
	public class TaxEventsProcess : Tax_CrtBaseEventsProcess
	{

		public TaxEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

