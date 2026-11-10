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

	#region Class: ActivityCategoryResultEntrySchema

	/// <exclude/>
	public class ActivityCategoryResultEntrySchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ActivityCategoryResultEntrySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ActivityCategoryResultEntrySchema(ActivityCategoryResultEntrySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ActivityCategoryResultEntrySchema(ActivityCategoryResultEntrySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("bd4e2904-dfb9-460a-8fd8-1d5e20405782");
			RealUId = new Guid("bd4e2904-dfb9-460a-8fd8-1d5e20405782");
			Name = "ActivityCategoryResultEntry";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("a9b31a96-5933-4a24-9de8-e6312dbce20b")) == null) {
				Columns.Add(CreateActivityResultColumn());
			}
			if (Columns.FindByUId(new Guid("136bcedb-1f6d-4214-8815-551c71f345a8")) == null) {
				Columns.Add(CreateActivityCategoryColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateActivityResultColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("a9b31a96-5933-4a24-9de8-e6312dbce20b"),
				Name = @"ActivityResult",
				ReferenceSchemaUId = new Guid("329bd06e-f95f-4824-a0fb-85edff2f2948"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("bd4e2904-dfb9-460a-8fd8-1d5e20405782"),
				ModifiedInSchemaUId = new Guid("bd4e2904-dfb9-460a-8fd8-1d5e20405782"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateActivityCategoryColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("136bcedb-1f6d-4214-8815-551c71f345a8"),
				Name = @"ActivityCategory",
				ReferenceSchemaUId = new Guid("961e2086-a12b-4d27-b095-40b1e64d6cc0"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("bd4e2904-dfb9-460a-8fd8-1d5e20405782"),
				ModifiedInSchemaUId = new Guid("bd4e2904-dfb9-460a-8fd8-1d5e20405782"),
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
			return new ActivityCategoryResultEntry(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ActivityCategoryResultEntry_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ActivityCategoryResultEntrySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ActivityCategoryResultEntrySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("bd4e2904-dfb9-460a-8fd8-1d5e20405782"));
		}

		#endregion

	}

	#endregion

	#region Class: ActivityCategoryResultEntry

	/// <summary>
	/// Result by activity category.
	/// </summary>
	public class ActivityCategoryResultEntry : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ActivityCategoryResultEntry(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ActivityCategoryResultEntry";
		}

		public ActivityCategoryResultEntry(ActivityCategoryResultEntry source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ActivityResultId {
			get {
				return GetTypedColumnValue<Guid>("ActivityResultId");
			}
			set {
				SetColumnValue("ActivityResultId", value);
				_activityResult = null;
			}
		}

		/// <exclude/>
		public string ActivityResultName {
			get {
				return GetTypedColumnValue<string>("ActivityResultName");
			}
			set {
				SetColumnValue("ActivityResultName", value);
				if (_activityResult != null) {
					_activityResult.Name = value;
				}
			}
		}

		private ActivityResult _activityResult;
		/// <summary>
		/// Result of activity.
		/// </summary>
		public ActivityResult ActivityResult {
			get {
				return _activityResult ??
					(_activityResult = LookupColumnEntities.GetEntity("ActivityResult") as ActivityResult);
			}
		}

		/// <exclude/>
		public Guid ActivityCategoryId {
			get {
				return GetTypedColumnValue<Guid>("ActivityCategoryId");
			}
			set {
				SetColumnValue("ActivityCategoryId", value);
				_activityCategory = null;
			}
		}

		/// <exclude/>
		public string ActivityCategoryName {
			get {
				return GetTypedColumnValue<string>("ActivityCategoryName");
			}
			set {
				SetColumnValue("ActivityCategoryName", value);
				if (_activityCategory != null) {
					_activityCategory.Name = value;
				}
			}
		}

		private ActivityCategory _activityCategory;
		/// <summary>
		/// Activity category.
		/// </summary>
		public ActivityCategory ActivityCategory {
			get {
				return _activityCategory ??
					(_activityCategory = LookupColumnEntities.GetEntity("ActivityCategory") as ActivityCategory);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ActivityCategoryResultEntry_CrtBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ActivityCategoryResultEntryDeleted", e);
			Deleting += (s, e) => ThrowEvent("ActivityCategoryResultEntryDeleting", e);
			Inserted += (s, e) => ThrowEvent("ActivityCategoryResultEntryInserted", e);
			Inserting += (s, e) => ThrowEvent("ActivityCategoryResultEntryInserting", e);
			Saved += (s, e) => ThrowEvent("ActivityCategoryResultEntrySaved", e);
			Saving += (s, e) => ThrowEvent("ActivityCategoryResultEntrySaving", e);
			Validating += (s, e) => ThrowEvent("ActivityCategoryResultEntryValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ActivityCategoryResultEntry(this);
		}

		#endregion

	}

	#endregion

	#region Class: ActivityCategoryResultEntry_CrtBaseEventsProcess

	/// <exclude/>
	public partial class ActivityCategoryResultEntry_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : ActivityCategoryResultEntry
	{

		public ActivityCategoryResultEntry_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ActivityCategoryResultEntry_CrtBaseEventsProcess";
			SchemaUId = new Guid("bd4e2904-dfb9-460a-8fd8-1d5e20405782");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("bd4e2904-dfb9-460a-8fd8-1d5e20405782");
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

	#region Class: ActivityCategoryResultEntry_CrtBaseEventsProcess

	/// <exclude/>
	public class ActivityCategoryResultEntry_CrtBaseEventsProcess : ActivityCategoryResultEntry_CrtBaseEventsProcess<ActivityCategoryResultEntry>
	{

		public ActivityCategoryResultEntry_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ActivityCategoryResultEntry_CrtBaseEventsProcess

	public partial class ActivityCategoryResultEntry_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ActivityCategoryResultEntryEventsProcess

	/// <exclude/>
	public class ActivityCategoryResultEntryEventsProcess : ActivityCategoryResultEntry_CrtBaseEventsProcess
	{

		public ActivityCategoryResultEntryEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

