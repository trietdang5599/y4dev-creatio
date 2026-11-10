namespace Terrasoft.Configuration
{

	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.IO;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;

	#region Class: ApplicationCreatioAiSchema

	/// <exclude/>
	[IsVirtual]
	public class ApplicationCreatioAiSchema : Terrasoft.Configuration.ApplicationSchemaSchema
	{

		#region Constructors: Public

		public ApplicationCreatioAiSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ApplicationCreatioAiSchema(ApplicationCreatioAiSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ApplicationCreatioAiSchema(ApplicationCreatioAiSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c158b6c5-d484-4608-8909-a0bfb6452686");
			RealUId = new Guid("c158b6c5-d484-4608-8909-a0bfb6452686");
			Name = "ApplicationCreatioAi";
			ParentSchemaUId = new Guid("51fab605-6f0c-4ff7-8398-b933f6a09128");
			ExtendParent = false;
			CreatedInPackageId = new Guid("c23dfaf0-0051-4966-86f8-cbe8197258d0");
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
			if (Columns.FindByUId(new Guid("25373927-c030-4859-dee1-974ecedc18fb")) == null) {
				Columns.Add(CreateModelColumn());
			}
			if (Columns.FindByUId(new Guid("f15abb63-76f5-9e6b-4f5c-94971326b705")) == null) {
				Columns.Add(CreateStatusColumn());
			}
			if (Columns.FindByUId(new Guid("889fc303-1fdb-9539-140a-2ab688f196a8")) == null) {
				Columns.Add(CreateTypeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateModelColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("25373927-c030-4859-dee1-974ecedc18fb"),
				Name = @"Model",
				CreatedInSchemaUId = new Guid("c158b6c5-d484-4608-8909-a0bfb6452686"),
				ModifiedInSchemaUId = new Guid("c158b6c5-d484-4608-8909-a0bfb6452686"),
				CreatedInPackageId = new Guid("c23dfaf0-0051-4966-86f8-cbe8197258d0")
			};
		}

		protected virtual EntitySchemaColumn CreateStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("f15abb63-76f5-9e6b-4f5c-94971326b705"),
				Name = @"Status",
				CreatedInSchemaUId = new Guid("c158b6c5-d484-4608-8909-a0bfb6452686"),
				ModifiedInSchemaUId = new Guid("c158b6c5-d484-4608-8909-a0bfb6452686"),
				CreatedInPackageId = new Guid("c23dfaf0-0051-4966-86f8-cbe8197258d0")
			};
		}

		protected virtual EntitySchemaColumn CreateTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("889fc303-1fdb-9539-140a-2ab688f196a8"),
				Name = @"Type",
				CreatedInSchemaUId = new Guid("c158b6c5-d484-4608-8909-a0bfb6452686"),
				ModifiedInSchemaUId = new Guid("c158b6c5-d484-4608-8909-a0bfb6452686"),
				CreatedInPackageId = new Guid("c23dfaf0-0051-4966-86f8-cbe8197258d0")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ApplicationCreatioAi(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ApplicationCreatioAi_CrtCopilotEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ApplicationCreatioAiSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ApplicationCreatioAiSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c158b6c5-d484-4608-8909-a0bfb6452686"));
		}

		#endregion

	}

	#endregion

	#region Class: ApplicationCreatioAi

	/// <summary>
	/// Application Creatio ai.
	/// </summary>
	public class ApplicationCreatioAi : Terrasoft.Configuration.ApplicationSchema
	{

		#region Constructors: Public

		public ApplicationCreatioAi(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ApplicationCreatioAi";
		}

		public ApplicationCreatioAi(ApplicationCreatioAi source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Model.
		/// </summary>
		public string Model {
			get {
				return GetTypedColumnValue<string>("Model");
			}
			set {
				SetColumnValue("Model", value);
			}
		}

		/// <summary>
		/// Status.
		/// </summary>
		public string Status {
			get {
				return GetTypedColumnValue<string>("Status");
			}
			set {
				SetColumnValue("Status", value);
			}
		}

		/// <summary>
		/// Type.
		/// </summary>
		public string Type {
			get {
				return GetTypedColumnValue<string>("Type");
			}
			set {
				SetColumnValue("Type", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ApplicationCreatioAi_CrtCopilotEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ApplicationCreatioAi(this);
		}

		#endregion

	}

	#endregion

	#region Class: ApplicationCreatioAi_CrtCopilotEventsProcess

	/// <exclude/>
	public partial class ApplicationCreatioAi_CrtCopilotEventsProcess<TEntity> : Terrasoft.Configuration.ApplicationSchema_CrtBaseEventsProcess<TEntity> where TEntity : ApplicationCreatioAi
	{

		public ApplicationCreatioAi_CrtCopilotEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ApplicationCreatioAi_CrtCopilotEventsProcess";
			SchemaUId = new Guid("c158b6c5-d484-4608-8909-a0bfb6452686");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("c158b6c5-d484-4608-8909-a0bfb6452686");
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

	#region Class: ApplicationCreatioAi_CrtCopilotEventsProcess

	/// <exclude/>
	public class ApplicationCreatioAi_CrtCopilotEventsProcess : ApplicationCreatioAi_CrtCopilotEventsProcess<ApplicationCreatioAi>
	{

		public ApplicationCreatioAi_CrtCopilotEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ApplicationCreatioAi_CrtCopilotEventsProcess

	public partial class ApplicationCreatioAi_CrtCopilotEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ApplicationCreatioAiEventsProcess

	/// <exclude/>
	public class ApplicationCreatioAiEventsProcess : ApplicationCreatioAi_CrtCopilotEventsProcess
	{

		public ApplicationCreatioAiEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

