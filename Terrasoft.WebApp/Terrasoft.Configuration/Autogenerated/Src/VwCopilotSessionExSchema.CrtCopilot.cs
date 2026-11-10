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

	#region Class: VwCopilotSessionExSchema

	/// <exclude/>
	public class VwCopilotSessionExSchema : Terrasoft.Configuration.CopilotSessionEntSchema
	{

		#region Constructors: Public

		public VwCopilotSessionExSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwCopilotSessionExSchema(VwCopilotSessionExSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwCopilotSessionExSchema(VwCopilotSessionExSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0867cfe4-56ec-4614-b11a-edeb6f6a2d42");
			RealUId = new Guid("0867cfe4-56ec-4614-b11a-edeb6f6a2d42");
			Name = "VwCopilotSessionEx";
			ParentSchemaUId = new Guid("b5e91b69-1cf7-456c-a553-76302e52f42f");
			ExtendParent = false;
			CreatedInPackageId = new Guid("421a8d84-5f16-4efa-b563-3ab0d40eb264");
			IsDBView = true;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = false;
			UseLiveEditing = true;
			Paging.IsPageable = true;
			Filtering.IsFilterable = true;
			Sorting.IsSortable = true;
			Write.IsInsertable = true;
			Write.IsUpdatable = true;
			Write.IsDeletable = true;
			UseRecordDeactivation = false;
		}

		protected override void InitializeOwnerColumn() {
			base.InitializeOwnerColumn();
			OwnerColumn = CreateUserColumn();
			if (Columns.FindByUId(OwnerColumn.UId) == null) {
				Columns.Add(OwnerColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("0db0ca46-ea69-089c-fcf0-b4ffdb79284b")) == null) {
				Columns.Add(CreateLastMessageDateColumn());
			}
			if (Columns.FindByUId(new Guid("52a8d246-a76d-d675-7355-5e8ff7fd6f94")) == null) {
				Columns.Add(CreateLastMessageContentColumn());
			}
		}

		protected override EntitySchemaColumn CreateTitleColumn() {
			EntitySchemaColumn column = base.CreateTitleColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.Sequence,
				ValueSource = @""
			};
			column.ModifiedInSchemaUId = new Guid("0867cfe4-56ec-4614-b11a-edeb6f6a2d42");
			return column;
		}

		protected virtual EntitySchemaColumn CreateLastMessageDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("0db0ca46-ea69-089c-fcf0-b4ffdb79284b"),
				Name = @"LastMessageDate",
				CreatedInSchemaUId = new Guid("0867cfe4-56ec-4614-b11a-edeb6f6a2d42"),
				ModifiedInSchemaUId = new Guid("0867cfe4-56ec-4614-b11a-edeb6f6a2d42"),
				CreatedInPackageId = new Guid("421a8d84-5f16-4efa-b563-3ab0d40eb264")
			};
		}

		protected virtual EntitySchemaColumn CreateLastMessageContentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("52a8d246-a76d-d675-7355-5e8ff7fd6f94"),
				Name = @"LastMessageContent",
				CreatedInSchemaUId = new Guid("0867cfe4-56ec-4614-b11a-edeb6f6a2d42"),
				ModifiedInSchemaUId = new Guid("0867cfe4-56ec-4614-b11a-edeb6f6a2d42"),
				CreatedInPackageId = new Guid("421a8d84-5f16-4efa-b563-3ab0d40eb264")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwCopilotSessionEx(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwCopilotSessionEx_CrtCopilotEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwCopilotSessionExSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwCopilotSessionExSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0867cfe4-56ec-4614-b11a-edeb6f6a2d42"));
		}

		#endregion

	}

	#endregion

	#region Class: VwCopilotSessionEx

	/// <summary>
	/// Creatio.ai session (view).
	/// </summary>
	public class VwCopilotSessionEx : Terrasoft.Configuration.CopilotSessionEnt
	{

		#region Constructors: Public

		public VwCopilotSessionEx(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwCopilotSessionEx";
		}

		public VwCopilotSessionEx(VwCopilotSessionEx source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Last message date.
		/// </summary>
		public DateTime LastMessageDate {
			get {
				return GetTypedColumnValue<DateTime>("LastMessageDate");
			}
			set {
				SetColumnValue("LastMessageDate", value);
			}
		}

		/// <summary>
		/// Last message content.
		/// </summary>
		public string LastMessageContent {
			get {
				return GetTypedColumnValue<string>("LastMessageContent");
			}
			set {
				SetColumnValue("LastMessageContent", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwCopilotSessionEx_CrtCopilotEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwCopilotSessionExDeleted", e);
			Deleting += (s, e) => ThrowEvent("VwCopilotSessionExDeleting", e);
			Inserted += (s, e) => ThrowEvent("VwCopilotSessionExInserted", e);
			Inserting += (s, e) => ThrowEvent("VwCopilotSessionExInserting", e);
			Saved += (s, e) => ThrowEvent("VwCopilotSessionExSaved", e);
			Saving += (s, e) => ThrowEvent("VwCopilotSessionExSaving", e);
			Validating += (s, e) => ThrowEvent("VwCopilotSessionExValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwCopilotSessionEx(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwCopilotSessionEx_CrtCopilotEventsProcess

	/// <exclude/>
	public partial class VwCopilotSessionEx_CrtCopilotEventsProcess<TEntity> : Terrasoft.Configuration.CopilotSessionEnt_CrtCopilotEventsProcess<TEntity> where TEntity : VwCopilotSessionEx
	{

		public VwCopilotSessionEx_CrtCopilotEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwCopilotSessionEx_CrtCopilotEventsProcess";
			SchemaUId = new Guid("0867cfe4-56ec-4614-b11a-edeb6f6a2d42");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("0867cfe4-56ec-4614-b11a-edeb6f6a2d42");
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

	#region Class: VwCopilotSessionEx_CrtCopilotEventsProcess

	/// <exclude/>
	public class VwCopilotSessionEx_CrtCopilotEventsProcess : VwCopilotSessionEx_CrtCopilotEventsProcess<VwCopilotSessionEx>
	{

		public VwCopilotSessionEx_CrtCopilotEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwCopilotSessionEx_CrtCopilotEventsProcess

	public partial class VwCopilotSessionEx_CrtCopilotEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwCopilotSessionExEventsProcess

	/// <exclude/>
	public class VwCopilotSessionExEventsProcess : VwCopilotSessionEx_CrtCopilotEventsProcess
	{

		public VwCopilotSessionExEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

