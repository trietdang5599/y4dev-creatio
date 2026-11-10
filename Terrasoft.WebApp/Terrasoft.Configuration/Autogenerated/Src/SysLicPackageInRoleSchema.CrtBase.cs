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

	#region Class: SysLicPackageInRoleSchema

	/// <exclude/>
	public class SysLicPackageInRoleSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysLicPackageInRoleSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysLicPackageInRoleSchema(SysLicPackageInRoleSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysLicPackageInRoleSchema(SysLicPackageInRoleSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f30f4a02-0d61-4a5b-90ff-6f52a543bdc6");
			RealUId = new Guid("f30f4a02-0d61-4a5b-90ff-6f52a543bdc6");
			Name = "SysLicPackageInRole";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("acb004d0-c421-4dff-b075-f4fdc1c90074");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = false;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("4e02559b-c53a-7ef6-7116-3f12a46c01ac")) == null) {
				Columns.Add(CreateSysLicPackageColumn());
			}
			if (Columns.FindByUId(new Guid("750c1884-19b7-7db6-2668-68d14b366a04")) == null) {
				Columns.Add(CreateSysRoleColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysLicPackageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("4e02559b-c53a-7ef6-7116-3f12a46c01ac"),
				Name = @"SysLicPackage",
				ReferenceSchemaUId = new Guid("bba64ad2-ff65-46f4-911d-4068aa0af48a"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("f30f4a02-0d61-4a5b-90ff-6f52a543bdc6"),
				ModifiedInSchemaUId = new Guid("f30f4a02-0d61-4a5b-90ff-6f52a543bdc6"),
				CreatedInPackageId = new Guid("acb004d0-c421-4dff-b075-f4fdc1c90074"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateSysRoleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("750c1884-19b7-7db6-2668-68d14b366a04"),
				Name = @"SysRole",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("f30f4a02-0d61-4a5b-90ff-6f52a543bdc6"),
				ModifiedInSchemaUId = new Guid("f30f4a02-0d61-4a5b-90ff-6f52a543bdc6"),
				CreatedInPackageId = new Guid("acb004d0-c421-4dff-b075-f4fdc1c90074"),
				IsSimpleLookup = true
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysLicPackageInRole(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysLicPackageInRole_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysLicPackageInRoleSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysLicPackageInRoleSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f30f4a02-0d61-4a5b-90ff-6f52a543bdc6"));
		}

		#endregion

	}

	#endregion

	#region Class: SysLicPackageInRole

	/// <summary>
	/// Role licenses.
	/// </summary>
	public class SysLicPackageInRole : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysLicPackageInRole(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysLicPackageInRole";
		}

		public SysLicPackageInRole(SysLicPackageInRole source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SysLicPackageId {
			get {
				return GetTypedColumnValue<Guid>("SysLicPackageId");
			}
			set {
				SetColumnValue("SysLicPackageId", value);
				_sysLicPackage = null;
			}
		}

		/// <exclude/>
		public string SysLicPackageName {
			get {
				return GetTypedColumnValue<string>("SysLicPackageName");
			}
			set {
				SetColumnValue("SysLicPackageName", value);
				if (_sysLicPackage != null) {
					_sysLicPackage.Name = value;
				}
			}
		}

		private SysLicPackage _sysLicPackage;
		/// <summary>
		/// License.
		/// </summary>
		public SysLicPackage SysLicPackage {
			get {
				return _sysLicPackage ??
					(_sysLicPackage = LookupColumnEntities.GetEntity("SysLicPackage") as SysLicPackage);
			}
		}

		/// <exclude/>
		public Guid SysRoleId {
			get {
				return GetTypedColumnValue<Guid>("SysRoleId");
			}
			set {
				SetColumnValue("SysRoleId", value);
				_sysRole = null;
			}
		}

		/// <exclude/>
		public string SysRoleName {
			get {
				return GetTypedColumnValue<string>("SysRoleName");
			}
			set {
				SetColumnValue("SysRoleName", value);
				if (_sysRole != null) {
					_sysRole.Name = value;
				}
			}
		}

		private SysAdminUnit _sysRole;
		/// <summary>
		/// Role.
		/// </summary>
		public SysAdminUnit SysRole {
			get {
				return _sysRole ??
					(_sysRole = LookupColumnEntities.GetEntity("SysRole") as SysAdminUnit);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysLicPackageInRole_CrtBaseEventsProcess(UserConnection);
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
			return new SysLicPackageInRole(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysLicPackageInRole_CrtBaseEventsProcess

	/// <exclude/>
	public partial class SysLicPackageInRole_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysLicPackageInRole
	{

		public SysLicPackageInRole_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysLicPackageInRole_CrtBaseEventsProcess";
			SchemaUId = new Guid("f30f4a02-0d61-4a5b-90ff-6f52a543bdc6");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("f30f4a02-0d61-4a5b-90ff-6f52a543bdc6");
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

	#region Class: SysLicPackageInRole_CrtBaseEventsProcess

	/// <exclude/>
	public class SysLicPackageInRole_CrtBaseEventsProcess : SysLicPackageInRole_CrtBaseEventsProcess<SysLicPackageInRole>
	{

		public SysLicPackageInRole_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysLicPackageInRole_CrtBaseEventsProcess

	public partial class SysLicPackageInRole_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysLicPackageInRoleEventsProcess

	/// <exclude/>
	public class SysLicPackageInRoleEventsProcess : SysLicPackageInRole_CrtBaseEventsProcess
	{

		public SysLicPackageInRoleEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

