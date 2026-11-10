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

	#region Class: LendingStateSchema

	/// <exclude/>
	public class LendingStateSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public LendingStateSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public LendingStateSchema(LendingStateSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public LendingStateSchema(LendingStateSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("967d4133-7d63-492f-a8f3-e406d06c6bbd");
			RealUId = new Guid("967d4133-7d63-492f-a8f3-e406d06c6bbd");
			Name = "LendingState";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("2f566863-6a05-41ae-bb68-b647818b8f61");
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

		protected override void InitializePrimaryColorColumn() {
			base.InitializePrimaryColorColumn();
			PrimaryColorColumn = CreateColorColumn();
			if (Columns.FindByUId(PrimaryColorColumn.UId) == null) {
				Columns.Add(PrimaryColorColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected virtual EntitySchemaColumn CreateColorColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Color")) {
				UId = new Guid("a4c3f8a7-8be6-ec03-7731-71d72ea0293b"),
				Name = @"Color",
				CreatedInSchemaUId = new Guid("967d4133-7d63-492f-a8f3-e406d06c6bbd"),
				ModifiedInSchemaUId = new Guid("967d4133-7d63-492f-a8f3-e406d06c6bbd"),
				CreatedInPackageId = new Guid("0207a48b-15fc-4078-897d-d9287dd55c45")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new LendingState(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new LendingState_CrtWebFormEventsProcess(userConnection);
		}

		public override object Clone() {
			return new LendingStateSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new LendingStateSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("967d4133-7d63-492f-a8f3-e406d06c6bbd"));
		}

		#endregion

	}

	#endregion

	#region Class: LendingState

	/// <summary>
	/// Landing status.
	/// </summary>
	/// <remarks>
	/// Shows the status of a legacy landing page, such as active or inactive, to indicate whether it is currently in use. This column is not used for new landing pages (LandingPage object).
	/// </remarks>
	public class LendingState : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public LendingState(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "LendingState";
		}

		public LendingState(LendingState source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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
			var process = new LendingState_CrtWebFormEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("LendingStateDeleted", e);
			Validating += (s, e) => ThrowEvent("LendingStateValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new LendingState(this);
		}

		#endregion

	}

	#endregion

	#region Class: LendingState_CrtWebFormEventsProcess

	/// <exclude/>
	public partial class LendingState_CrtWebFormEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : LendingState
	{

		public LendingState_CrtWebFormEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "LendingState_CrtWebFormEventsProcess";
			SchemaUId = new Guid("967d4133-7d63-492f-a8f3-e406d06c6bbd");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("967d4133-7d63-492f-a8f3-e406d06c6bbd");
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

	#region Class: LendingState_CrtWebFormEventsProcess

	/// <exclude/>
	public class LendingState_CrtWebFormEventsProcess : LendingState_CrtWebFormEventsProcess<LendingState>
	{

		public LendingState_CrtWebFormEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: LendingState_CrtWebFormEventsProcess

	public partial class LendingState_CrtWebFormEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: LendingStateEventsProcess

	/// <exclude/>
	public class LendingStateEventsProcess : LendingState_CrtWebFormEventsProcess
	{

		public LendingStateEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

