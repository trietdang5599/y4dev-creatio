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

	#region Class: SysRegistrationDataSchema

	/// <exclude/>
	public class SysRegistrationDataSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysRegistrationDataSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysRegistrationDataSchema(SysRegistrationDataSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysRegistrationDataSchema(SysRegistrationDataSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("edaaa2db-e52f-47bd-8c6d-6acb5d2d85cf");
			RealUId = new Guid("edaaa2db-e52f-47bd-8c6d-6acb5d2d85cf");
			Name = "SysRegistrationData";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("7e3646d2-65e6-4ea9-991f-980e1c476849");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("b3830140-ba6b-42f8-8bce-a7e40c353fa7")) == null) {
				Columns.Add(CreateSysAdminUnitColumn());
			}
			if (Columns.FindByUId(new Guid("5f2cc0e7-ce30-4567-ad54-35803a92130d")) == null) {
				Columns.Add(CreateContactColumn());
			}
			if (Columns.FindByUId(new Guid("551e5f41-c643-450d-9f96-56436bb1ff19")) == null) {
				Columns.Add(CreateUserPasswordColumn());
			}
			if (Columns.FindByUId(new Guid("1c447f44-b6a6-49af-9060-521d21b88c56")) == null) {
				Columns.Add(CreateLinkTypeColumn());
			}
			if (Columns.FindByUId(new Guid("b1ab3c7e-fd33-4e61-ab10-141ef4324859")) == null) {
				Columns.Add(CreateLinkIdColumn());
			}
			if (Columns.FindByUId(new Guid("f0834b8f-f92e-431e-83fa-ea61d3d6fe9a")) == null) {
				Columns.Add(CreateLinkExpireDateColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysAdminUnitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("b3830140-ba6b-42f8-8bce-a7e40c353fa7"),
				Name = @"SysAdminUnit",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("edaaa2db-e52f-47bd-8c6d-6acb5d2d85cf"),
				ModifiedInSchemaUId = new Guid("edaaa2db-e52f-47bd-8c6d-6acb5d2d85cf"),
				CreatedInPackageId = new Guid("7e3646d2-65e6-4ea9-991f-980e1c476849")
			};
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("5f2cc0e7-ce30-4567-ad54-35803a92130d"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("edaaa2db-e52f-47bd-8c6d-6acb5d2d85cf"),
				ModifiedInSchemaUId = new Guid("edaaa2db-e52f-47bd-8c6d-6acb5d2d85cf"),
				CreatedInPackageId = new Guid("bc74f040-1e92-44f3-b554-0124b41c1915")
			};
		}

		protected virtual EntitySchemaColumn CreateUserPasswordColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("SecureText")) {
				UId = new Guid("551e5f41-c643-450d-9f96-56436bb1ff19"),
				Name = @"UserPassword",
				CreatedInSchemaUId = new Guid("edaaa2db-e52f-47bd-8c6d-6acb5d2d85cf"),
				ModifiedInSchemaUId = new Guid("edaaa2db-e52f-47bd-8c6d-6acb5d2d85cf"),
				CreatedInPackageId = new Guid("bc74f040-1e92-44f3-b554-0124b41c1915")
			};
		}

		protected virtual EntitySchemaColumn CreateLinkTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("1c447f44-b6a6-49af-9060-521d21b88c56"),
				Name = @"LinkType",
				CreatedInSchemaUId = new Guid("edaaa2db-e52f-47bd-8c6d-6acb5d2d85cf"),
				ModifiedInSchemaUId = new Guid("edaaa2db-e52f-47bd-8c6d-6acb5d2d85cf"),
				CreatedInPackageId = new Guid("bc74f040-1e92-44f3-b554-0124b41c1915")
			};
		}

		protected virtual EntitySchemaColumn CreateLinkIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("b1ab3c7e-fd33-4e61-ab10-141ef4324859"),
				Name = @"LinkId",
				CreatedInSchemaUId = new Guid("edaaa2db-e52f-47bd-8c6d-6acb5d2d85cf"),
				ModifiedInSchemaUId = new Guid("edaaa2db-e52f-47bd-8c6d-6acb5d2d85cf"),
				CreatedInPackageId = new Guid("7e3646d2-65e6-4ea9-991f-980e1c476849")
			};
		}

		protected virtual EntitySchemaColumn CreateLinkExpireDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("f0834b8f-f92e-431e-83fa-ea61d3d6fe9a"),
				Name = @"LinkExpireDate",
				CreatedInSchemaUId = new Guid("edaaa2db-e52f-47bd-8c6d-6acb5d2d85cf"),
				ModifiedInSchemaUId = new Guid("edaaa2db-e52f-47bd-8c6d-6acb5d2d85cf"),
				CreatedInPackageId = new Guid("7e3646d2-65e6-4ea9-991f-980e1c476849")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysRegistrationData(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysRegistrationData_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysRegistrationDataSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysRegistrationDataSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("edaaa2db-e52f-47bd-8c6d-6acb5d2d85cf"));
		}

		#endregion

	}

	#endregion

	#region Class: SysRegistrationData

	/// <summary>
	/// Registration data.
	/// </summary>
	public class SysRegistrationData : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysRegistrationData(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysRegistrationData";
		}

		public SysRegistrationData(SysRegistrationData source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SysAdminUnitId {
			get {
				return GetTypedColumnValue<Guid>("SysAdminUnitId");
			}
			set {
				SetColumnValue("SysAdminUnitId", value);
				_sysAdminUnit = null;
			}
		}

		/// <exclude/>
		public string SysAdminUnitName {
			get {
				return GetTypedColumnValue<string>("SysAdminUnitName");
			}
			set {
				SetColumnValue("SysAdminUnitName", value);
				if (_sysAdminUnit != null) {
					_sysAdminUnit.Name = value;
				}
			}
		}

		private SysAdminUnit _sysAdminUnit;
		/// <summary>
		/// User.
		/// </summary>
		public SysAdminUnit SysAdminUnit {
			get {
				return _sysAdminUnit ??
					(_sysAdminUnit = LookupColumnEntities.GetEntity("SysAdminUnit") as SysAdminUnit);
			}
		}

		/// <exclude/>
		public Guid ContactId {
			get {
				return GetTypedColumnValue<Guid>("ContactId");
			}
			set {
				SetColumnValue("ContactId", value);
				_contact = null;
			}
		}

		/// <exclude/>
		public string ContactName {
			get {
				return GetTypedColumnValue<string>("ContactName");
			}
			set {
				SetColumnValue("ContactName", value);
				if (_contact != null) {
					_contact.Name = value;
				}
			}
		}

		private Contact _contact;
		/// <summary>
		/// Contact.
		/// </summary>
		public Contact Contact {
			get {
				return _contact ??
					(_contact = LookupColumnEntities.GetEntity("Contact") as Contact);
			}
		}

		/// <summary>
		/// User password.
		/// </summary>
		public string UserPassword {
			get {
				return GetTypedColumnValue<string>("UserPassword");
			}
			set {
				SetColumnValue("UserPassword", value);
			}
		}

		/// <summary>
		/// Link type.
		/// </summary>
		public int LinkType {
			get {
				return GetTypedColumnValue<int>("LinkType");
			}
			set {
				SetColumnValue("LinkType", value);
			}
		}

		/// <summary>
		/// Link Id.
		/// </summary>
		public Guid LinkId {
			get {
				return GetTypedColumnValue<Guid>("LinkId");
			}
			set {
				SetColumnValue("LinkId", value);
			}
		}

		/// <summary>
		/// Link expiration date.
		/// </summary>
		public DateTime LinkExpireDate {
			get {
				return GetTypedColumnValue<DateTime>("LinkExpireDate");
			}
			set {
				SetColumnValue("LinkExpireDate", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysRegistrationData_CrtBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysRegistrationDataDeleted", e);
			Validating += (s, e) => ThrowEvent("SysRegistrationDataValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysRegistrationData(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysRegistrationData_CrtBaseEventsProcess

	/// <exclude/>
	public partial class SysRegistrationData_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysRegistrationData
	{

		public SysRegistrationData_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysRegistrationData_CrtBaseEventsProcess";
			SchemaUId = new Guid("edaaa2db-e52f-47bd-8c6d-6acb5d2d85cf");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("edaaa2db-e52f-47bd-8c6d-6acb5d2d85cf");
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

	#region Class: SysRegistrationData_CrtBaseEventsProcess

	/// <exclude/>
	public class SysRegistrationData_CrtBaseEventsProcess : SysRegistrationData_CrtBaseEventsProcess<SysRegistrationData>
	{

		public SysRegistrationData_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysRegistrationData_CrtBaseEventsProcess

	public partial class SysRegistrationData_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysRegistrationDataEventsProcess

	/// <exclude/>
	public class SysRegistrationDataEventsProcess : SysRegistrationData_CrtBaseEventsProcess
	{

		public SysRegistrationDataEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

