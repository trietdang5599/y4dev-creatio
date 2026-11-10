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

	#region Class: SysAlmRoleSchema

	/// <exclude/>
	public class SysAlmRoleSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysAlmRoleSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysAlmRoleSchema(SysAlmRoleSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysAlmRoleSchema(SysAlmRoleSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("841696db-ea27-4ff4-ae55-f9796cb0de43");
			RealUId = new Guid("841696db-ea27-4ff4-ae55-f9796cb0de43");
			Name = "SysAlmRole";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("36494a42-7da1-4ee5-bdac-8ef181c90aa0");
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
			if (Columns.FindByUId(new Guid("ba2d464e-d240-a874-61ba-6ef3f230681d")) == null) {
				Columns.Add(CreateCodeColumn());
			}
			if (Columns.FindByUId(new Guid("ac5b016d-b1d6-d721-6ce1-a1e408848cc0")) == null) {
				Columns.Add(CreateRoleColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("ba2d464e-d240-a874-61ba-6ef3f230681d"),
				Name = @"Code",
				CreatedInSchemaUId = new Guid("841696db-ea27-4ff4-ae55-f9796cb0de43"),
				ModifiedInSchemaUId = new Guid("841696db-ea27-4ff4-ae55-f9796cb0de43"),
				CreatedInPackageId = new Guid("36494a42-7da1-4ee5-bdac-8ef181c90aa0")
			};
		}

		protected virtual EntitySchemaColumn CreateRoleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ac5b016d-b1d6-d721-6ce1-a1e408848cc0"),
				Name = @"Role",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("841696db-ea27-4ff4-ae55-f9796cb0de43"),
				ModifiedInSchemaUId = new Guid("841696db-ea27-4ff4-ae55-f9796cb0de43"),
				CreatedInPackageId = new Guid("36494a42-7da1-4ee5-bdac-8ef181c90aa0")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysAlmRole(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysAlmRole_OpenIdAuthEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysAlmRoleSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysAlmRoleSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("841696db-ea27-4ff4-ae55-f9796cb0de43"));
		}

		#endregion

	}

	#endregion

	#region Class: SysAlmRole

	/// <summary>
	/// SysAlmRole.
	/// </summary>
	public class SysAlmRole : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysAlmRole(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysAlmRole";
		}

		public SysAlmRole(SysAlmRole source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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

		/// <exclude/>
		public Guid RoleId {
			get {
				return GetTypedColumnValue<Guid>("RoleId");
			}
			set {
				SetColumnValue("RoleId", value);
				_role = null;
			}
		}

		/// <exclude/>
		public string RoleName {
			get {
				return GetTypedColumnValue<string>("RoleName");
			}
			set {
				SetColumnValue("RoleName", value);
				if (_role != null) {
					_role.Name = value;
				}
			}
		}

		private SysAdminUnit _role;
		/// <summary>
		/// Role.
		/// </summary>
		public SysAdminUnit Role {
			get {
				return _role ??
					(_role = LookupColumnEntities.GetEntity("Role") as SysAdminUnit);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysAlmRole_OpenIdAuthEventsProcess(UserConnection);
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
			return new SysAlmRole(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysAlmRole_OpenIdAuthEventsProcess

	/// <exclude/>
	public partial class SysAlmRole_OpenIdAuthEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysAlmRole
	{

		public SysAlmRole_OpenIdAuthEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysAlmRole_OpenIdAuthEventsProcess";
			SchemaUId = new Guid("841696db-ea27-4ff4-ae55-f9796cb0de43");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("841696db-ea27-4ff4-ae55-f9796cb0de43");
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

	#region Class: SysAlmRole_OpenIdAuthEventsProcess

	/// <exclude/>
	public class SysAlmRole_OpenIdAuthEventsProcess : SysAlmRole_OpenIdAuthEventsProcess<SysAlmRole>
	{

		public SysAlmRole_OpenIdAuthEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysAlmRole_OpenIdAuthEventsProcess

	public partial class SysAlmRole_OpenIdAuthEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysAlmRoleEventsProcess

	/// <exclude/>
	public class SysAlmRoleEventsProcess : SysAlmRole_OpenIdAuthEventsProcess
	{

		public SysAlmRoleEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

