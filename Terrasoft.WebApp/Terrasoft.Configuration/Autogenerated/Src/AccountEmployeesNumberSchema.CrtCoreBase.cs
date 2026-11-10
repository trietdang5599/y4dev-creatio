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

	#region Class: AccountEmployeesNumberSchema

	/// <exclude/>
	public class AccountEmployeesNumberSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public AccountEmployeesNumberSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public AccountEmployeesNumberSchema(AccountEmployeesNumberSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public AccountEmployeesNumberSchema(AccountEmployeesNumberSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ccf7d7bf-b4b7-4eb3-a191-3f47d6c4ee8d");
			RealUId = new Guid("ccf7d7bf-b4b7-4eb3-a191-3f47d6c4ee8d");
			Name = "AccountEmployeesNumber";
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

		protected override void InitializePrimaryOrderColumn() {
			base.InitializePrimaryOrderColumn();
			PrimaryOrderColumn = CreatePositionColumn();
			if (Columns.FindByUId(PrimaryOrderColumn.UId) == null) {
				Columns.Add(PrimaryOrderColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("a534015b-7838-4ee1-2b15-a059fae020db")) == null) {
				Columns.Add(CreateEmployeesNumberToColumn());
			}
			if (Columns.FindByUId(new Guid("c12f2207-32c6-4c76-2035-154d1a75379b")) == null) {
				Columns.Add(CreateEmployeesNumberFromColumn());
			}
		}

		protected virtual EntitySchemaColumn CreatePositionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("6747dac6-782e-4f7b-8fa4-4eeda529087f"),
				Name = @"Position",
				CreatedInSchemaUId = new Guid("ccf7d7bf-b4b7-4eb3-a191-3f47d6c4ee8d"),
				ModifiedInSchemaUId = new Guid("ccf7d7bf-b4b7-4eb3-a191-3f47d6c4ee8d"),
				CreatedInPackageId = new Guid("c42d95b3-a17f-45a6-9dff-a6ab283daf22")
			};
		}

		protected virtual EntitySchemaColumn CreateEmployeesNumberToColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("a534015b-7838-4ee1-2b15-a059fae020db"),
				Name = @"EmployeesNumberTo",
				CreatedInSchemaUId = new Guid("ccf7d7bf-b4b7-4eb3-a191-3f47d6c4ee8d"),
				ModifiedInSchemaUId = new Guid("ccf7d7bf-b4b7-4eb3-a191-3f47d6c4ee8d"),
				CreatedInPackageId = new Guid("569a44ff-cedc-4f91-92e5-4b7c7294fe05")
			};
		}

		protected virtual EntitySchemaColumn CreateEmployeesNumberFromColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("c12f2207-32c6-4c76-2035-154d1a75379b"),
				Name = @"EmployeesNumberFrom",
				CreatedInSchemaUId = new Guid("ccf7d7bf-b4b7-4eb3-a191-3f47d6c4ee8d"),
				ModifiedInSchemaUId = new Guid("ccf7d7bf-b4b7-4eb3-a191-3f47d6c4ee8d"),
				CreatedInPackageId = new Guid("569a44ff-cedc-4f91-92e5-4b7c7294fe05")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new AccountEmployeesNumber(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new AccountEmployeesNumber_CrtCoreBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new AccountEmployeesNumberSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new AccountEmployeesNumberSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ccf7d7bf-b4b7-4eb3-a191-3f47d6c4ee8d"));
		}

		#endregion

	}

	#endregion

	#region Class: AccountEmployeesNumber

	/// <summary>
	/// Number of account employees.
	/// </summary>
	public class AccountEmployeesNumber : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public AccountEmployeesNumber(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "AccountEmployeesNumber";
		}

		public AccountEmployeesNumber(AccountEmployeesNumber source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Position.
		/// </summary>
		public int Position {
			get {
				return GetTypedColumnValue<int>("Position");
			}
			set {
				SetColumnValue("Position", value);
			}
		}

		/// <summary>
		/// Employees Number To.
		/// </summary>
		public int EmployeesNumberTo {
			get {
				return GetTypedColumnValue<int>("EmployeesNumberTo");
			}
			set {
				SetColumnValue("EmployeesNumberTo", value);
			}
		}

		/// <summary>
		/// Employees Number From.
		/// </summary>
		public int EmployeesNumberFrom {
			get {
				return GetTypedColumnValue<int>("EmployeesNumberFrom");
			}
			set {
				SetColumnValue("EmployeesNumberFrom", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new AccountEmployeesNumber_CrtCoreBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("AccountEmployeesNumberDeleted", e);
			Deleting += (s, e) => ThrowEvent("AccountEmployeesNumberDeleting", e);
			Inserted += (s, e) => ThrowEvent("AccountEmployeesNumberInserted", e);
			Inserting += (s, e) => ThrowEvent("AccountEmployeesNumberInserting", e);
			Saved += (s, e) => ThrowEvent("AccountEmployeesNumberSaved", e);
			Saving += (s, e) => ThrowEvent("AccountEmployeesNumberSaving", e);
			Validating += (s, e) => ThrowEvent("AccountEmployeesNumberValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new AccountEmployeesNumber(this);
		}

		#endregion

	}

	#endregion

	#region Class: AccountEmployeesNumber_CrtCoreBaseEventsProcess

	/// <exclude/>
	public partial class AccountEmployeesNumber_CrtCoreBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : AccountEmployeesNumber
	{

		public AccountEmployeesNumber_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "AccountEmployeesNumber_CrtCoreBaseEventsProcess";
			SchemaUId = new Guid("ccf7d7bf-b4b7-4eb3-a191-3f47d6c4ee8d");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ccf7d7bf-b4b7-4eb3-a191-3f47d6c4ee8d");
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

	#region Class: AccountEmployeesNumber_CrtCoreBaseEventsProcess

	/// <exclude/>
	public class AccountEmployeesNumber_CrtCoreBaseEventsProcess : AccountEmployeesNumber_CrtCoreBaseEventsProcess<AccountEmployeesNumber>
	{

		public AccountEmployeesNumber_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: AccountEmployeesNumber_CrtCoreBaseEventsProcess

	public partial class AccountEmployeesNumber_CrtCoreBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: AccountEmployeesNumberEventsProcess

	/// <exclude/>
	public class AccountEmployeesNumberEventsProcess : AccountEmployeesNumber_CrtCoreBaseEventsProcess
	{

		public AccountEmployeesNumberEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

