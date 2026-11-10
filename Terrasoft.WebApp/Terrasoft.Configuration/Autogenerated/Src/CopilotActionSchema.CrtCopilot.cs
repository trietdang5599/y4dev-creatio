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

	#region Class: CopilotActionSchema

	/// <exclude/>
	[IsVirtual]
	public class CopilotActionSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public CopilotActionSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CopilotActionSchema(CopilotActionSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CopilotActionSchema(CopilotActionSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("169514ea-c8a8-4cb4-a3d9-68ac3ae2b6ca");
			RealUId = new Guid("169514ea-c8a8-4cb4-a3d9-68ac3ae2b6ca");
			Name = "CopilotAction";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("e94aa263-bfb4-4fa2-906e-1a8040844e6c");
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
			if (Columns.FindByUId(new Guid("7bdbe150-9708-3118-06fb-9d22cc2941fd")) == null) {
				Columns.Add(CreateIntentColumn());
			}
			if (Columns.FindByUId(new Guid("eec9b5e5-857e-c33f-6db4-f00cad89efe3")) == null) {
				Columns.Add(CreateActionTypeColumn());
			}
			if (Columns.FindByUId(new Guid("04d1ca79-7f76-6cf7-423b-fa43cfa5ca26")) == null) {
				Columns.Add(CreateCodeColumn());
			}
			if (Columns.FindByUId(new Guid("a49ef323-2cb6-91c4-e156-8080638f1bca")) == null) {
				Columns.Add(CreateParamsColumn());
			}
			if (Columns.FindByUId(new Guid("370a0198-b708-680c-600d-9c4cbb8be8cb")) == null) {
				Columns.Add(CreatePackageUIdColumn());
			}
			if (Columns.FindByUId(new Guid("20cf6489-4ffd-d0cd-5047-e32f2ce2a33e")) == null) {
				Columns.Add(CreateIsConfirmRequiredColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateIntentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("7bdbe150-9708-3118-06fb-9d22cc2941fd"),
				Name = @"Intent",
				ReferenceSchemaUId = new Guid("7cd7a99a-b22e-4e50-af02-6ee4ac8612ec"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("169514ea-c8a8-4cb4-a3d9-68ac3ae2b6ca"),
				ModifiedInSchemaUId = new Guid("169514ea-c8a8-4cb4-a3d9-68ac3ae2b6ca"),
				CreatedInPackageId = new Guid("e94aa263-bfb4-4fa2-906e-1a8040844e6c"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateActionTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("eec9b5e5-857e-c33f-6db4-f00cad89efe3"),
				Name = @"ActionType",
				ReferenceSchemaUId = new Guid("eda968bd-464d-48c2-90bc-97ae68108fcb"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("169514ea-c8a8-4cb4-a3d9-68ac3ae2b6ca"),
				ModifiedInSchemaUId = new Guid("169514ea-c8a8-4cb4-a3d9-68ac3ae2b6ca"),
				CreatedInPackageId = new Guid("e94aa263-bfb4-4fa2-906e-1a8040844e6c"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("04d1ca79-7f76-6cf7-423b-fa43cfa5ca26"),
				Name = @"Code",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("169514ea-c8a8-4cb4-a3d9-68ac3ae2b6ca"),
				ModifiedInSchemaUId = new Guid("169514ea-c8a8-4cb4-a3d9-68ac3ae2b6ca"),
				CreatedInPackageId = new Guid("a4098b1e-9718-401a-b1c3-ae0a33f3e48f")
			};
		}

		protected virtual EntitySchemaColumn CreateParamsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("a49ef323-2cb6-91c4-e156-8080638f1bca"),
				Name = @"Params",
				CreatedInSchemaUId = new Guid("169514ea-c8a8-4cb4-a3d9-68ac3ae2b6ca"),
				ModifiedInSchemaUId = new Guid("169514ea-c8a8-4cb4-a3d9-68ac3ae2b6ca"),
				CreatedInPackageId = new Guid("a4098b1e-9718-401a-b1c3-ae0a33f3e48f")
			};
		}

		protected virtual EntitySchemaColumn CreatePackageUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("370a0198-b708-680c-600d-9c4cbb8be8cb"),
				Name = @"PackageUId",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("169514ea-c8a8-4cb4-a3d9-68ac3ae2b6ca"),
				ModifiedInSchemaUId = new Guid("169514ea-c8a8-4cb4-a3d9-68ac3ae2b6ca"),
				CreatedInPackageId = new Guid("706b374b-bd02-4c06-85f2-e99fd2129891")
			};
		}

		protected virtual EntitySchemaColumn CreateIsConfirmRequiredColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("20cf6489-4ffd-d0cd-5047-e32f2ce2a33e"),
				Name = @"IsConfirmRequired",
				CreatedInSchemaUId = new Guid("169514ea-c8a8-4cb4-a3d9-68ac3ae2b6ca"),
				ModifiedInSchemaUId = new Guid("169514ea-c8a8-4cb4-a3d9-68ac3ae2b6ca"),
				CreatedInPackageId = new Guid("ed753793-30d5-4797-a3f9-3019dcc6e358"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"False"
				}
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new CopilotAction(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CopilotAction_CrtCopilotEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CopilotActionSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CopilotActionSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("169514ea-c8a8-4cb4-a3d9-68ac3ae2b6ca"));
		}

		#endregion

	}

	#endregion

	#region Class: CopilotAction

	/// <summary>
	/// Creatio.ai action.
	/// </summary>
	public class CopilotAction : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public CopilotAction(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CopilotAction";
		}

		public CopilotAction(CopilotAction source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid IntentId {
			get {
				return GetTypedColumnValue<Guid>("IntentId");
			}
			set {
				SetColumnValue("IntentId", value);
				_intent = null;
			}
		}

		/// <exclude/>
		public string IntentName {
			get {
				return GetTypedColumnValue<string>("IntentName");
			}
			set {
				SetColumnValue("IntentName", value);
				if (_intent != null) {
					_intent.Name = value;
				}
			}
		}

		private CopilotIntent _intent;
		/// <summary>
		/// Creatio.ai skills.
		/// </summary>
		public CopilotIntent Intent {
			get {
				return _intent ??
					(_intent = LookupColumnEntities.GetEntity("Intent") as CopilotIntent);
			}
		}

		/// <exclude/>
		public Guid ActionTypeId {
			get {
				return GetTypedColumnValue<Guid>("ActionTypeId");
			}
			set {
				SetColumnValue("ActionTypeId", value);
				_actionType = null;
			}
		}

		/// <exclude/>
		public string ActionTypeName {
			get {
				return GetTypedColumnValue<string>("ActionTypeName");
			}
			set {
				SetColumnValue("ActionTypeName", value);
				if (_actionType != null) {
					_actionType.Name = value;
				}
			}
		}

		private CopilotActionType _actionType;
		/// <summary>
		/// Action type.
		/// </summary>
		public CopilotActionType ActionType {
			get {
				return _actionType ??
					(_actionType = LookupColumnEntities.GetEntity("ActionType") as CopilotActionType);
			}
		}

		/// <summary>
		/// Code.
		/// </summary>
		public string Code {
			get {
				return GetTypedColumnValue<string>("Code");
			}
			set {
				SetColumnValue("Code", value);
			}
		}

		/// <summary>
		/// Params.
		/// </summary>
		public string Params {
			get {
				return GetTypedColumnValue<string>("Params");
			}
			set {
				SetColumnValue("Params", value);
			}
		}

		/// <summary>
		/// Package unique identifier.
		/// </summary>
		public Guid PackageUId {
			get {
				return GetTypedColumnValue<Guid>("PackageUId");
			}
			set {
				SetColumnValue("PackageUId", value);
			}
		}

		/// <summary>
		/// Require confirmation before start.
		/// </summary>
		public bool IsConfirmRequired {
			get {
				return GetTypedColumnValue<bool>("IsConfirmRequired");
			}
			set {
				SetColumnValue("IsConfirmRequired", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CopilotAction_CrtCopilotEventsProcess(UserConnection);
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
			return new CopilotAction(this);
		}

		#endregion

	}

	#endregion

	#region Class: CopilotAction_CrtCopilotEventsProcess

	/// <exclude/>
	public partial class CopilotAction_CrtCopilotEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : CopilotAction
	{

		public CopilotAction_CrtCopilotEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CopilotAction_CrtCopilotEventsProcess";
			SchemaUId = new Guid("169514ea-c8a8-4cb4-a3d9-68ac3ae2b6ca");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("169514ea-c8a8-4cb4-a3d9-68ac3ae2b6ca");
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

	#region Class: CopilotAction_CrtCopilotEventsProcess

	/// <exclude/>
	public class CopilotAction_CrtCopilotEventsProcess : CopilotAction_CrtCopilotEventsProcess<CopilotAction>
	{

		public CopilotAction_CrtCopilotEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CopilotAction_CrtCopilotEventsProcess

	public partial class CopilotAction_CrtCopilotEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CopilotActionEventsProcess

	/// <exclude/>
	public class CopilotActionEventsProcess : CopilotAction_CrtCopilotEventsProcess
	{

		public CopilotActionEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

