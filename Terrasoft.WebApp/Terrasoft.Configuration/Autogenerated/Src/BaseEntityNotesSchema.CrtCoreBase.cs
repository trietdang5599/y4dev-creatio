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

	#region Class: BaseEntityNotesSchema

	/// <exclude/>
	[IsVirtual]
	public class BaseEntityNotesSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public BaseEntityNotesSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public BaseEntityNotesSchema(BaseEntityNotesSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public BaseEntityNotesSchema(BaseEntityNotesSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a22b1e79-7fc1-4fe5-aba0-538e9df96f17");
			RealUId = new Guid("a22b1e79-7fc1-4fe5-aba0-538e9df96f17");
			Name = "BaseEntityNotes";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
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
			if (Columns.FindByUId(new Guid("abc96728-faf6-451d-91f6-35bc53ea9745")) == null) {
				Columns.Add(CreateNotesColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateNotesColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("abc96728-faf6-451d-91f6-35bc53ea9745"),
				Name = @"Notes",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("a22b1e79-7fc1-4fe5-aba0-538e9df96f17"),
				ModifiedInSchemaUId = new Guid("a22b1e79-7fc1-4fe5-aba0-538e9df96f17"),
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
			return new BaseEntityNotes(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new BaseEntityNotes_CrtCoreBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new BaseEntityNotesSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new BaseEntityNotesSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a22b1e79-7fc1-4fe5-aba0-538e9df96f17"));
		}

		#endregion

	}

	#endregion

	#region Class: BaseEntityNotes

	/// <summary>
	/// Base object with notes.
	/// </summary>
	public class BaseEntityNotes : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public BaseEntityNotes(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BaseEntityNotes";
		}

		public BaseEntityNotes(BaseEntityNotes source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Notes.
		/// </summary>
		public string Notes {
			get {
				return GetTypedColumnValue<string>("Notes");
			}
			set {
				SetColumnValue("Notes", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new BaseEntityNotes_CrtCoreBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("BaseEntityNotesDeleted", e);
			Deleting += (s, e) => ThrowEvent("BaseEntityNotesDeleting", e);
			Inserted += (s, e) => ThrowEvent("BaseEntityNotesInserted", e);
			Inserting += (s, e) => ThrowEvent("BaseEntityNotesInserting", e);
			Saved += (s, e) => ThrowEvent("BaseEntityNotesSaved", e);
			Saving += (s, e) => ThrowEvent("BaseEntityNotesSaving", e);
			Validating += (s, e) => ThrowEvent("BaseEntityNotesValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new BaseEntityNotes(this);
		}

		#endregion

	}

	#endregion

	#region Class: BaseEntityNotes_CrtCoreBaseEventsProcess

	/// <exclude/>
	public partial class BaseEntityNotes_CrtCoreBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : BaseEntityNotes
	{

		public BaseEntityNotes_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "BaseEntityNotes_CrtCoreBaseEventsProcess";
			SchemaUId = new Guid("a22b1e79-7fc1-4fe5-aba0-538e9df96f17");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("a22b1e79-7fc1-4fe5-aba0-538e9df96f17");
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

	#region Class: BaseEntityNotes_CrtCoreBaseEventsProcess

	/// <exclude/>
	public class BaseEntityNotes_CrtCoreBaseEventsProcess : BaseEntityNotes_CrtCoreBaseEventsProcess<BaseEntityNotes>
	{

		public BaseEntityNotes_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: BaseEntityNotes_CrtCoreBaseEventsProcess

	public partial class BaseEntityNotes_CrtCoreBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: BaseEntityNotesEventsProcess

	/// <exclude/>
	public class BaseEntityNotesEventsProcess : BaseEntityNotes_CrtCoreBaseEventsProcess
	{

		public BaseEntityNotesEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

