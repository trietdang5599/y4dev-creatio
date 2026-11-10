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

	#region Class: NotifySettingsByUserSchema

	/// <exclude/>
	[IsVirtual]
	public class NotifySettingsByUserSchema : Terrasoft.Core.Entities.EntitySchema
	{

		#region Constructors: Public

		public NotifySettingsByUserSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public NotifySettingsByUserSchema(NotifySettingsByUserSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public NotifySettingsByUserSchema(NotifySettingsByUserSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7a9002d3-3962-4679-afb5-5d711b49af63");
			RealUId = new Guid("7a9002d3-3962-4679-afb5-5d711b49af63");
			Name = "NotifySettingsByUser";
			ParentSchemaUId = new Guid("1b56b061-4e91-4974-9038-df8340e534f2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryColumn() {
			base.InitializePrimaryColumn();
			PrimaryColumn = CreateIdColumn();
			if (Columns.FindByUId(PrimaryColumn.UId) == null) {
				Columns.Add(PrimaryColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("ed387e59-9fcf-3ad6-af58-cd0005064661")) == null) {
				Columns.Add(CreateStateColumn());
			}
			if (Columns.FindByUId(new Guid("0dcd97f3-4254-9fd0-7bbd-3f36336aca11")) == null) {
				Columns.Add(CreateNameColumn());
			}
			if (Columns.FindByUId(new Guid("66146f5d-dc6a-97a2-4b93-1900134be8b6")) == null) {
				Columns.Add(CreateCodeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateStateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("ed387e59-9fcf-3ad6-af58-cd0005064661"),
				Name = @"State",
				CreatedInSchemaUId = new Guid("7a9002d3-3962-4679-afb5-5d711b49af63"),
				ModifiedInSchemaUId = new Guid("7a9002d3-3962-4679-afb5-5d711b49af63"),
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723")
			};
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("0dcd97f3-4254-9fd0-7bbd-3f36336aca11"),
				Name = @"Name",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("7a9002d3-3962-4679-afb5-5d711b49af63"),
				ModifiedInSchemaUId = new Guid("7a9002d3-3962-4679-afb5-5d711b49af63"),
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723")
			};
		}

		protected virtual EntitySchemaColumn CreateCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("66146f5d-dc6a-97a2-4b93-1900134be8b6"),
				Name = @"Code",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("7a9002d3-3962-4679-afb5-5d711b49af63"),
				ModifiedInSchemaUId = new Guid("7a9002d3-3962-4679-afb5-5d711b49af63"),
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723")
			};
		}

		protected virtual EntitySchemaColumn CreateIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("50c363d5-ceff-3fcc-6f3b-16461ab73f39"),
				Name = @"Id",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("7a9002d3-3962-4679-afb5-5d711b49af63"),
				ModifiedInSchemaUId = new Guid("7a9002d3-3962-4679-afb5-5d711b49af63"),
				CreatedInPackageId = new Guid("d699061b-815e-49b9-8730-21a5e5db2044")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new NotifySettingsByUser(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new NotifySettingsByUser_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new NotifySettingsByUserSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new NotifySettingsByUserSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7a9002d3-3962-4679-afb5-5d711b49af63"));
		}

		#endregion

	}

	#endregion

	#region Class: NotifySettingsByUser

	/// <summary>
	/// Notification settings by user.
	/// </summary>
	public class NotifySettingsByUser : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public NotifySettingsByUser(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "NotifySettingsByUser";
		}

		public NotifySettingsByUser(NotifySettingsByUser source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Enabled.
		/// </summary>
		public bool State {
			get {
				return GetTypedColumnValue<bool>("State");
			}
			set {
				SetColumnValue("State", value);
			}
		}

		/// <summary>
		/// Notifications category.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		/// <summary>
		/// Notification setting code.
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
		/// Id.
		/// </summary>
		public Guid Id {
			get {
				return GetTypedColumnValue<Guid>("Id");
			}
			set {
				SetColumnValue("Id", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new NotifySettingsByUser_CrtBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("NotifySettingsByUserDeleted", e);
			Deleting += (s, e) => ThrowEvent("NotifySettingsByUserDeleting", e);
			Inserted += (s, e) => ThrowEvent("NotifySettingsByUserInserted", e);
			Inserting += (s, e) => ThrowEvent("NotifySettingsByUserInserting", e);
			Saved += (s, e) => ThrowEvent("NotifySettingsByUserSaved", e);
			Saving += (s, e) => ThrowEvent("NotifySettingsByUserSaving", e);
			Validating += (s, e) => ThrowEvent("NotifySettingsByUserValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new NotifySettingsByUser(this);
		}

		#endregion

	}

	#endregion

	#region Class: NotifySettingsByUser_CrtBaseEventsProcess

	/// <exclude/>
	public partial class NotifySettingsByUser_CrtBaseEventsProcess<TEntity> : Terrasoft.Core.Process.EmbeddedProcess where TEntity : NotifySettingsByUser
	{

		private TEntity _entity;
		public TEntity Entity {
			get {
				return _entity;
			}
			set {
				_entity = value;
			}
		}

		public NotifySettingsByUser_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "NotifySettingsByUser_CrtBaseEventsProcess";
			SchemaUId = new Guid("7a9002d3-3962-4679-afb5-5d711b49af63");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("7a9002d3-3962-4679-afb5-5d711b49af63");
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

	#region Class: NotifySettingsByUser_CrtBaseEventsProcess

	/// <exclude/>
	public class NotifySettingsByUser_CrtBaseEventsProcess : NotifySettingsByUser_CrtBaseEventsProcess<NotifySettingsByUser>
	{

		public NotifySettingsByUser_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: NotifySettingsByUser_CrtBaseEventsProcess

	public partial class NotifySettingsByUser_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: NotifySettingsByUserEventsProcess

	/// <exclude/>
	public class NotifySettingsByUserEventsProcess : NotifySettingsByUser_CrtBaseEventsProcess
	{

		public NotifySettingsByUserEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

