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

	#region Class: FolderTypeSchema

	/// <exclude/>
	public class FolderTypeSchema : Terrasoft.Configuration.BaseCodeImageLookupSchema
	{

		#region Constructors: Public

		public FolderTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public FolderTypeSchema(FolderTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public FolderTypeSchema(FolderTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("6fce7412-b527-4e0d-94f1-4b4c02d8e69f");
			RealUId = new Guid("6fce7412-b527-4e0d-94f1-4b4c02d8e69f");
			Name = "FolderType";
			ParentSchemaUId = new Guid("c21771d2-01fa-4646-96b0-e4b69e582b44");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
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

		protected override void InitializePrimaryImageColumn() {
			base.InitializePrimaryImageColumn();
			PrimaryImageColumn = CreateImageColumn();
			if (Columns.FindByUId(PrimaryImageColumn.UId) == null) {
				Columns.Add(PrimaryImageColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("6c300833-04d9-4742-99c3-f0eb9d7580e8")) == null) {
				Columns.Add(CreateOrderColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateOrderColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("6c300833-04d9-4742-99c3-f0eb9d7580e8"),
				Name = @"Order",
				CreatedInSchemaUId = new Guid("6fce7412-b527-4e0d-94f1-4b4c02d8e69f"),
				ModifiedInSchemaUId = new Guid("6fce7412-b527-4e0d-94f1-4b4c02d8e69f"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new FolderType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new FolderType_CrtCoreBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new FolderTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new FolderTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6fce7412-b527-4e0d-94f1-4b4c02d8e69f"));
		}

		#endregion

	}

	#endregion

	#region Class: FolderType

	/// <summary>
	/// Folder type.
	/// </summary>
	public class FolderType : Terrasoft.Configuration.BaseCodeImageLookup
	{

		#region Constructors: Public

		public FolderType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "FolderType";
		}

		public FolderType(FolderType source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Order.
		/// </summary>
		public int Order {
			get {
				return GetTypedColumnValue<int>("Order");
			}
			set {
				SetColumnValue("Order", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new FolderType_CrtCoreBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("FolderTypeDeleted", e);
			Deleting += (s, e) => ThrowEvent("FolderTypeDeleting", e);
			Inserted += (s, e) => ThrowEvent("FolderTypeInserted", e);
			Inserting += (s, e) => ThrowEvent("FolderTypeInserting", e);
			Saved += (s, e) => ThrowEvent("FolderTypeSaved", e);
			Saving += (s, e) => ThrowEvent("FolderTypeSaving", e);
			Validating += (s, e) => ThrowEvent("FolderTypeValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new FolderType(this);
		}

		#endregion

	}

	#endregion

	#region Class: FolderType_CrtCoreBaseEventsProcess

	/// <exclude/>
	public partial class FolderType_CrtCoreBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseCodeImageLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : FolderType
	{

		public FolderType_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "FolderType_CrtCoreBaseEventsProcess";
			SchemaUId = new Guid("6fce7412-b527-4e0d-94f1-4b4c02d8e69f");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("6fce7412-b527-4e0d-94f1-4b4c02d8e69f");
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

	#region Class: FolderType_CrtCoreBaseEventsProcess

	/// <exclude/>
	public class FolderType_CrtCoreBaseEventsProcess : FolderType_CrtCoreBaseEventsProcess<FolderType>
	{

		public FolderType_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: FolderType_CrtCoreBaseEventsProcess

	public partial class FolderType_CrtCoreBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: FolderTypeEventsProcess

	/// <exclude/>
	public class FolderTypeEventsProcess : FolderType_CrtCoreBaseEventsProcess
	{

		public FolderTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

