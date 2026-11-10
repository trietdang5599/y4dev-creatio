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

	#region Class: ProductTypeSchema

	/// <exclude/>
	public class ProductTypeSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public ProductTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ProductTypeSchema(ProductTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ProductTypeSchema(ProductTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("41663f5e-affb-406e-b92d-4d72eea6f8a8");
			RealUId = new Guid("41663f5e-affb-406e-b92d-4d72eea6f8a8");
			Name = "ProductType";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("3644c994-8f85-41ec-8125-47013bac161f");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
			UseLiveEditing = false;
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
			if (Columns.FindByUId(new Guid("b38bd826-cb96-46fc-8798-992420f5ef87")) == null) {
				Columns.Add(CreateIsServiceColumn());
			}
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("41663f5e-affb-406e-b92d-4d72eea6f8a8");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("41663f5e-affb-406e-b92d-4d72eea6f8a8");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected virtual EntitySchemaColumn CreateIsServiceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("b38bd826-cb96-46fc-8798-992420f5ef87"),
				Name = @"IsService",
				CreatedInSchemaUId = new Guid("41663f5e-affb-406e-b92d-4d72eea6f8a8"),
				ModifiedInSchemaUId = new Guid("41663f5e-affb-406e-b92d-4d72eea6f8a8"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateColorColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Color")) {
				UId = new Guid("ccfa8b12-0de7-dbf0-9b41-198384402140"),
				Name = @"Color",
				CreatedInSchemaUId = new Guid("41663f5e-affb-406e-b92d-4d72eea6f8a8"),
				ModifiedInSchemaUId = new Guid("41663f5e-affb-406e-b92d-4d72eea6f8a8"),
				CreatedInPackageId = new Guid("d2395af4-bb7a-4e67-9660-cf2552a8d860")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ProductType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ProductType_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ProductTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ProductTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("41663f5e-affb-406e-b92d-4d72eea6f8a8"));
		}

		#endregion

	}

	#endregion

	#region Class: ProductType

	/// <summary>
	/// Product type.
	/// </summary>
	public class ProductType : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public ProductType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ProductType";
		}

		public ProductType(ProductType source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Service.
		/// </summary>
		public bool IsService {
			get {
				return GetTypedColumnValue<bool>("IsService");
			}
			set {
				SetColumnValue("IsService", value);
			}
		}

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
			var process = new ProductType_CrtBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ProductTypeDeleted", e);
			Deleting += (s, e) => ThrowEvent("ProductTypeDeleting", e);
			Inserted += (s, e) => ThrowEvent("ProductTypeInserted", e);
			Inserting += (s, e) => ThrowEvent("ProductTypeInserting", e);
			Saved += (s, e) => ThrowEvent("ProductTypeSaved", e);
			Saving += (s, e) => ThrowEvent("ProductTypeSaving", e);
			Validating += (s, e) => ThrowEvent("ProductTypeValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ProductType(this);
		}

		#endregion

	}

	#endregion

	#region Class: ProductType_CrtBaseEventsProcess

	/// <exclude/>
	public partial class ProductType_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : ProductType
	{

		public ProductType_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ProductType_CrtBaseEventsProcess";
			SchemaUId = new Guid("41663f5e-affb-406e-b92d-4d72eea6f8a8");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("41663f5e-affb-406e-b92d-4d72eea6f8a8");
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

	#region Class: ProductType_CrtBaseEventsProcess

	/// <exclude/>
	public class ProductType_CrtBaseEventsProcess : ProductType_CrtBaseEventsProcess<ProductType>
	{

		public ProductType_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ProductType_CrtBaseEventsProcess

	public partial class ProductType_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ProductTypeEventsProcess

	/// <exclude/>
	public class ProductTypeEventsProcess : ProductType_CrtBaseEventsProcess
	{

		public ProductTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

