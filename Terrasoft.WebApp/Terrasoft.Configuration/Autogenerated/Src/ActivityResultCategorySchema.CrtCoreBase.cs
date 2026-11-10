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

	#region Class: ActivityResultCategorySchema

	/// <exclude/>
	public class ActivityResultCategorySchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public ActivityResultCategorySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ActivityResultCategorySchema(ActivityResultCategorySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ActivityResultCategorySchema(ActivityResultCategorySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0b8e1c4e-71c0-4776-8b30-11f8689e6bac");
			RealUId = new Guid("0b8e1c4e-71c0-4776-8b30-11f8689e6bac");
			Name = "ActivityResultCategory";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("5f1bdcb0-8c10-43bc-aead-341648534099");
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
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("0b8e1c4e-71c0-4776-8b30-11f8689e6bac");
			column.CreatedInPackageId = new Guid("5f1bdcb0-8c10-43bc-aead-341648534099");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("0b8e1c4e-71c0-4776-8b30-11f8689e6bac");
			column.CreatedInPackageId = new Guid("5f1bdcb0-8c10-43bc-aead-341648534099");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("0b8e1c4e-71c0-4776-8b30-11f8689e6bac");
			column.CreatedInPackageId = new Guid("5f1bdcb0-8c10-43bc-aead-341648534099");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("0b8e1c4e-71c0-4776-8b30-11f8689e6bac");
			column.CreatedInPackageId = new Guid("5f1bdcb0-8c10-43bc-aead-341648534099");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("0b8e1c4e-71c0-4776-8b30-11f8689e6bac");
			column.CreatedInPackageId = new Guid("5f1bdcb0-8c10-43bc-aead-341648534099");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("0b8e1c4e-71c0-4776-8b30-11f8689e6bac");
			column.CreatedInPackageId = new Guid("5f1bdcb0-8c10-43bc-aead-341648534099");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("0b8e1c4e-71c0-4776-8b30-11f8689e6bac");
			column.CreatedInPackageId = new Guid("5f1bdcb0-8c10-43bc-aead-341648534099");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("0b8e1c4e-71c0-4776-8b30-11f8689e6bac");
			column.CreatedInPackageId = new Guid("5f1bdcb0-8c10-43bc-aead-341648534099");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ActivityResultCategory(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ActivityResultCategory_CrtCoreBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ActivityResultCategorySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ActivityResultCategorySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0b8e1c4e-71c0-4776-8b30-11f8689e6bac"));
		}

		#endregion

	}

	#endregion

	#region Class: ActivityResultCategory

	/// <summary>
	/// Category of activity result.
	/// </summary>
	public class ActivityResultCategory : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public ActivityResultCategory(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ActivityResultCategory";
		}

		public ActivityResultCategory(ActivityResultCategory source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ActivityResultCategory_CrtCoreBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ActivityResultCategoryDeleted", e);
			Inserting += (s, e) => ThrowEvent("ActivityResultCategoryInserting", e);
			Validating += (s, e) => ThrowEvent("ActivityResultCategoryValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ActivityResultCategory(this);
		}

		#endregion

	}

	#endregion

	#region Class: ActivityResultCategory_CrtCoreBaseEventsProcess

	/// <exclude/>
	public partial class ActivityResultCategory_CrtCoreBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : ActivityResultCategory
	{

		public ActivityResultCategory_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ActivityResultCategory_CrtCoreBaseEventsProcess";
			SchemaUId = new Guid("0b8e1c4e-71c0-4776-8b30-11f8689e6bac");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("0b8e1c4e-71c0-4776-8b30-11f8689e6bac");
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

	#region Class: ActivityResultCategory_CrtCoreBaseEventsProcess

	/// <exclude/>
	public class ActivityResultCategory_CrtCoreBaseEventsProcess : ActivityResultCategory_CrtCoreBaseEventsProcess<ActivityResultCategory>
	{

		public ActivityResultCategory_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ActivityResultCategory_CrtCoreBaseEventsProcess

	public partial class ActivityResultCategory_CrtCoreBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ActivityResultCategoryEventsProcess

	/// <exclude/>
	public class ActivityResultCategoryEventsProcess : ActivityResultCategory_CrtCoreBaseEventsProcess
	{

		public ActivityResultCategoryEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

