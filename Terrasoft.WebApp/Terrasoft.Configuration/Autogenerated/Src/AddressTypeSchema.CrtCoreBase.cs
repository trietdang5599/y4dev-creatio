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

	#region Class: AddressType_CrtCoreBase_CreatioSchema

	/// <exclude/>
	public class AddressType_CrtCoreBase_CreatioSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public AddressType_CrtCoreBase_CreatioSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public AddressType_CrtCoreBase_CreatioSchema(AddressType_CrtCoreBase_CreatioSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public AddressType_CrtCoreBase_CreatioSchema(AddressType_CrtCoreBase_CreatioSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("50837bfc-43ff-466b-94bb-de0847eecd1b");
			RealUId = new Guid("50837bfc-43ff-466b-94bb-de0847eecd1b");
			Name = "AddressType_CrtCoreBase_Creatio";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
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

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("7421096a-1fe8-477b-b718-8d66554c0f97")) == null) {
				Columns.Add(CreateForContactColumn());
			}
			if (Columns.FindByUId(new Guid("4c02f622-12ca-4649-a1bf-17cf7a94b168")) == null) {
				Columns.Add(CreateForAccountColumn());
			}
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("50837bfc-43ff-466b-94bb-de0847eecd1b");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("50837bfc-43ff-466b-94bb-de0847eecd1b");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected virtual EntitySchemaColumn CreateForContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("7421096a-1fe8-477b-b718-8d66554c0f97"),
				Name = @"ForContact",
				CreatedInSchemaUId = new Guid("50837bfc-43ff-466b-94bb-de0847eecd1b"),
				ModifiedInSchemaUId = new Guid("50837bfc-43ff-466b-94bb-de0847eecd1b"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateForAccountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("4c02f622-12ca-4649-a1bf-17cf7a94b168"),
				Name = @"ForAccount",
				CreatedInSchemaUId = new Guid("50837bfc-43ff-466b-94bb-de0847eecd1b"),
				ModifiedInSchemaUId = new Guid("50837bfc-43ff-466b-94bb-de0847eecd1b"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new AddressType_CrtCoreBase_Creatio(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new AddressType_CrtCoreBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new AddressType_CrtCoreBase_CreatioSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new AddressType_CrtCoreBase_CreatioSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("50837bfc-43ff-466b-94bb-de0847eecd1b"));
		}

		#endregion

	}

	#endregion

	#region Class: AddressType_CrtCoreBase_Creatio

	/// <summary>
	/// Address type.
	/// </summary>
	public class AddressType_CrtCoreBase_Creatio : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public AddressType_CrtCoreBase_Creatio(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "AddressType_CrtCoreBase_Creatio";
		}

		public AddressType_CrtCoreBase_Creatio(AddressType_CrtCoreBase_Creatio source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Use in contacts.
		/// </summary>
		public bool ForContact {
			get {
				return GetTypedColumnValue<bool>("ForContact");
			}
			set {
				SetColumnValue("ForContact", value);
			}
		}

		/// <summary>
		/// Use in accounts.
		/// </summary>
		public bool ForAccount {
			get {
				return GetTypedColumnValue<bool>("ForAccount");
			}
			set {
				SetColumnValue("ForAccount", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new AddressType_CrtCoreBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("AddressType_CrtCoreBase_CreatioDeleted", e);
			Deleting += (s, e) => ThrowEvent("AddressType_CrtCoreBase_CreatioDeleting", e);
			Inserted += (s, e) => ThrowEvent("AddressType_CrtCoreBase_CreatioInserted", e);
			Inserting += (s, e) => ThrowEvent("AddressType_CrtCoreBase_CreatioInserting", e);
			Saved += (s, e) => ThrowEvent("AddressType_CrtCoreBase_CreatioSaved", e);
			Saving += (s, e) => ThrowEvent("AddressType_CrtCoreBase_CreatioSaving", e);
			Validating += (s, e) => ThrowEvent("AddressType_CrtCoreBase_CreatioValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new AddressType_CrtCoreBase_Creatio(this);
		}

		#endregion

	}

	#endregion

	#region Class: AddressType_CrtCoreBaseEventsProcess

	/// <exclude/>
	public partial class AddressType_CrtCoreBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : AddressType_CrtCoreBase_Creatio
	{

		public AddressType_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "AddressType_CrtCoreBaseEventsProcess";
			SchemaUId = new Guid("50837bfc-43ff-466b-94bb-de0847eecd1b");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("50837bfc-43ff-466b-94bb-de0847eecd1b");
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

	#region Class: AddressType_CrtCoreBaseEventsProcess

	/// <exclude/>
	public class AddressType_CrtCoreBaseEventsProcess : AddressType_CrtCoreBaseEventsProcess<AddressType_CrtCoreBase_Creatio>
	{

		public AddressType_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: AddressType_CrtCoreBaseEventsProcess

	public partial class AddressType_CrtCoreBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

