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

	#region Class: BaseHierarchicalLookupSchema

	/// <exclude/>
	[IsVirtual]
	public class BaseHierarchicalLookupSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public BaseHierarchicalLookupSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public BaseHierarchicalLookupSchema(BaseHierarchicalLookupSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public BaseHierarchicalLookupSchema(BaseHierarchicalLookupSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5a39bd7c-8880-456c-aaf7-7645ce114e62");
			RealUId = new Guid("5a39bd7c-8880-456c-aaf7-7645ce114e62");
			Name = "BaseHierarchicalLookup";
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

		protected override void InitializeHierarchyColumn() {
			base.InitializeHierarchyColumn();
			HierarchyColumn = CreateParentColumn();
			if (Columns.FindByUId(HierarchyColumn.UId) == null) {
				Columns.Add(HierarchyColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.None,
				ValueSource = @""
			};
			column.ModifiedInSchemaUId = new Guid("5a39bd7c-8880-456c-aaf7-7645ce114e62");
			return column;
		}

		protected virtual EntitySchemaColumn CreateParentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("527b9e4e-7dbf-4721-a112-72b423b3365a"),
				Name = @"Parent",
				ReferenceSchemaUId = Guid.Empty,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("5a39bd7c-8880-456c-aaf7-7645ce114e62"),
				ModifiedInSchemaUId = new Guid("5a39bd7c-8880-456c-aaf7-7645ce114e62"),
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
			return new BaseHierarchicalLookup(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new BaseHierarchicalLookup_CrtCoreBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new BaseHierarchicalLookupSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new BaseHierarchicalLookupSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5a39bd7c-8880-456c-aaf7-7645ce114e62"));
		}

		#endregion

	}

	#endregion

	#region Class: BaseHierarchicalLookup

	/// <summary>
	/// Base hierarchical lookup.
	/// </summary>
	public class BaseHierarchicalLookup : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public BaseHierarchicalLookup(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BaseHierarchicalLookup";
		}

		public BaseHierarchicalLookup(BaseHierarchicalLookup source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new BaseHierarchicalLookup_CrtCoreBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("BaseHierarchicalLookupDeleted", e);
			Deleting += (s, e) => ThrowEvent("BaseHierarchicalLookupDeleting", e);
			Inserted += (s, e) => ThrowEvent("BaseHierarchicalLookupInserted", e);
			Inserting += (s, e) => ThrowEvent("BaseHierarchicalLookupInserting", e);
			Saved += (s, e) => ThrowEvent("BaseHierarchicalLookupSaved", e);
			Saving += (s, e) => ThrowEvent("BaseHierarchicalLookupSaving", e);
			Validating += (s, e) => ThrowEvent("BaseHierarchicalLookupValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new BaseHierarchicalLookup(this);
		}

		#endregion

	}

	#endregion

	#region Class: BaseHierarchicalLookup_CrtCoreBaseEventsProcess

	/// <exclude/>
	public partial class BaseHierarchicalLookup_CrtCoreBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : BaseHierarchicalLookup
	{

		public BaseHierarchicalLookup_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "BaseHierarchicalLookup_CrtCoreBaseEventsProcess";
			SchemaUId = new Guid("5a39bd7c-8880-456c-aaf7-7645ce114e62");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("5a39bd7c-8880-456c-aaf7-7645ce114e62");
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

	#region Class: BaseHierarchicalLookup_CrtCoreBaseEventsProcess

	/// <exclude/>
	public class BaseHierarchicalLookup_CrtCoreBaseEventsProcess : BaseHierarchicalLookup_CrtCoreBaseEventsProcess<BaseHierarchicalLookup>
	{

		public BaseHierarchicalLookup_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: BaseHierarchicalLookup_CrtCoreBaseEventsProcess

	public partial class BaseHierarchicalLookup_CrtCoreBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: BaseHierarchicalLookupEventsProcess

	/// <exclude/>
	public class BaseHierarchicalLookupEventsProcess : BaseHierarchicalLookup_CrtCoreBaseEventsProcess
	{

		public BaseHierarchicalLookupEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

