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

	#region Class: SysXssProtectRuleViolationSchema

	/// <exclude/>
	public class SysXssProtectRuleViolationSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysXssProtectRuleViolationSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysXssProtectRuleViolationSchema(SysXssProtectRuleViolationSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysXssProtectRuleViolationSchema(SysXssProtectRuleViolationSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e322ec8a-e1da-4bf9-b18d-eec2a834e5fb");
			RealUId = new Guid("e322ec8a-e1da-4bf9-b18d-eec2a834e5fb");
			Name = "SysXssProtectRuleViolation";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("97c04b85-daed-4b3e-87b7-d7c7d8df72f2");
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
			if (Columns.FindByUId(new Guid("06bd7a19-d81c-fbc4-69f1-6cff531af383")) == null) {
				Columns.Add(CreateBlockedUrlColumn());
			}
			if (Columns.FindByUId(new Guid("213a9f0e-a50b-4222-47e3-081f3c54739f")) == null) {
				Columns.Add(CreateAgentColumn());
			}
			if (Columns.FindByUId(new Guid("19ae0516-df8a-2275-2c7a-293111116b02")) == null) {
				Columns.Add(CreateIPAddressColumn());
			}
			if (Columns.FindByUId(new Guid("8691d75a-c6c3-8e92-0c8a-88ee951f12f8")) == null) {
				Columns.Add(CreateUserLoginColumn());
			}
			if (Columns.FindByUId(new Guid("32f990cf-095f-3dce-c679-d58ed8a403bd")) == null) {
				Columns.Add(CreateViolationDateColumn());
			}
			if (Columns.FindByUId(new Guid("5bdc24f9-0dae-dc6b-26f3-7ef47cd90cd2")) == null) {
				Columns.Add(CreateEntitySchemaNameColumn());
			}
			if (Columns.FindByUId(new Guid("00592191-22b2-dde9-3a6d-a24d03c1cde7")) == null) {
				Columns.Add(CreateViolatedRuleColumn());
			}
			if (Columns.FindByUId(new Guid("8b4c0a4d-5cfe-658c-4ce5-226718816c20")) == null) {
				Columns.Add(CreateViolatedRuleTypeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateBlockedUrlColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("06bd7a19-d81c-fbc4-69f1-6cff531af383"),
				Name = @"BlockedUrl",
				CreatedInSchemaUId = new Guid("e322ec8a-e1da-4bf9-b18d-eec2a834e5fb"),
				ModifiedInSchemaUId = new Guid("e322ec8a-e1da-4bf9-b18d-eec2a834e5fb"),
				CreatedInPackageId = new Guid("97c04b85-daed-4b3e-87b7-d7c7d8df72f2")
			};
		}

		protected virtual EntitySchemaColumn CreateAgentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("213a9f0e-a50b-4222-47e3-081f3c54739f"),
				Name = @"Agent",
				CreatedInSchemaUId = new Guid("e322ec8a-e1da-4bf9-b18d-eec2a834e5fb"),
				ModifiedInSchemaUId = new Guid("e322ec8a-e1da-4bf9-b18d-eec2a834e5fb"),
				CreatedInPackageId = new Guid("97c04b85-daed-4b3e-87b7-d7c7d8df72f2")
			};
		}

		protected virtual EntitySchemaColumn CreateIPAddressColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("19ae0516-df8a-2275-2c7a-293111116b02"),
				Name = @"IPAddress",
				CreatedInSchemaUId = new Guid("e322ec8a-e1da-4bf9-b18d-eec2a834e5fb"),
				ModifiedInSchemaUId = new Guid("e322ec8a-e1da-4bf9-b18d-eec2a834e5fb"),
				CreatedInPackageId = new Guid("97c04b85-daed-4b3e-87b7-d7c7d8df72f2")
			};
		}

		protected virtual EntitySchemaColumn CreateUserLoginColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("8691d75a-c6c3-8e92-0c8a-88ee951f12f8"),
				Name = @"UserLogin",
				CreatedInSchemaUId = new Guid("e322ec8a-e1da-4bf9-b18d-eec2a834e5fb"),
				ModifiedInSchemaUId = new Guid("e322ec8a-e1da-4bf9-b18d-eec2a834e5fb"),
				CreatedInPackageId = new Guid("97c04b85-daed-4b3e-87b7-d7c7d8df72f2")
			};
		}

		protected virtual EntitySchemaColumn CreateViolationDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("32f990cf-095f-3dce-c679-d58ed8a403bd"),
				Name = @"ViolationDate",
				CreatedInSchemaUId = new Guid("e322ec8a-e1da-4bf9-b18d-eec2a834e5fb"),
				ModifiedInSchemaUId = new Guid("e322ec8a-e1da-4bf9-b18d-eec2a834e5fb"),
				CreatedInPackageId = new Guid("97c04b85-daed-4b3e-87b7-d7c7d8df72f2")
			};
		}

		protected virtual EntitySchemaColumn CreateEntitySchemaNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("5bdc24f9-0dae-dc6b-26f3-7ef47cd90cd2"),
				Name = @"EntitySchemaName",
				CreatedInSchemaUId = new Guid("e322ec8a-e1da-4bf9-b18d-eec2a834e5fb"),
				ModifiedInSchemaUId = new Guid("e322ec8a-e1da-4bf9-b18d-eec2a834e5fb"),
				CreatedInPackageId = new Guid("97c04b85-daed-4b3e-87b7-d7c7d8df72f2")
			};
		}

		protected virtual EntitySchemaColumn CreateViolatedRuleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("00592191-22b2-dde9-3a6d-a24d03c1cde7"),
				Name = @"ViolatedRule",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("e322ec8a-e1da-4bf9-b18d-eec2a834e5fb"),
				ModifiedInSchemaUId = new Guid("e322ec8a-e1da-4bf9-b18d-eec2a834e5fb"),
				CreatedInPackageId = new Guid("a04d8c51-c8d6-4a3d-abea-c03e8c6be079")
			};
		}

		protected virtual EntitySchemaColumn CreateViolatedRuleTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("8b4c0a4d-5cfe-658c-4ce5-226718816c20"),
				Name = @"ViolatedRuleType",
				ReferenceSchemaUId = new Guid("0e92afa3-1557-4113-9f07-ff97326fda0f"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("e322ec8a-e1da-4bf9-b18d-eec2a834e5fb"),
				ModifiedInSchemaUId = new Guid("e322ec8a-e1da-4bf9-b18d-eec2a834e5fb"),
				CreatedInPackageId = new Guid("a04d8c51-c8d6-4a3d-abea-c03e8c6be079")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysXssProtectRuleViolation(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysXssProtectRuleViolation_XSSProtectionEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysXssProtectRuleViolationSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysXssProtectRuleViolationSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e322ec8a-e1da-4bf9-b18d-eec2a834e5fb"));
		}

		#endregion

	}

	#endregion

	#region Class: SysXssProtectRuleViolation

	/// <summary>
	/// XSS protection rules violations log.
	/// </summary>
	public class SysXssProtectRuleViolation : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysXssProtectRuleViolation(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysXssProtectRuleViolation";
		}

		public SysXssProtectRuleViolation(SysXssProtectRuleViolation source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Blocked URL.
		/// </summary>
		public string BlockedUrl {
			get {
				return GetTypedColumnValue<string>("BlockedUrl");
			}
			set {
				SetColumnValue("BlockedUrl", value);
			}
		}

		/// <summary>
		/// Agent.
		/// </summary>
		public string Agent {
			get {
				return GetTypedColumnValue<string>("Agent");
			}
			set {
				SetColumnValue("Agent", value);
			}
		}

		/// <summary>
		/// IP address.
		/// </summary>
		public string IPAddress {
			get {
				return GetTypedColumnValue<string>("IPAddress");
			}
			set {
				SetColumnValue("IPAddress", value);
			}
		}

		/// <summary>
		/// User login.
		/// </summary>
		public string UserLogin {
			get {
				return GetTypedColumnValue<string>("UserLogin");
			}
			set {
				SetColumnValue("UserLogin", value);
			}
		}

		/// <summary>
		/// Violation date.
		/// </summary>
		public DateTime ViolationDate {
			get {
				return GetTypedColumnValue<DateTime>("ViolationDate");
			}
			set {
				SetColumnValue("ViolationDate", value);
			}
		}

		/// <summary>
		/// Entity schema name.
		/// </summary>
		public string EntitySchemaName {
			get {
				return GetTypedColumnValue<string>("EntitySchemaName");
			}
			set {
				SetColumnValue("EntitySchemaName", value);
			}
		}

		/// <summary>
		/// Violated rule.
		/// </summary>
		public string ViolatedRule {
			get {
				return GetTypedColumnValue<string>("ViolatedRule");
			}
			set {
				SetColumnValue("ViolatedRule", value);
			}
		}

		/// <exclude/>
		public Guid ViolatedRuleTypeId {
			get {
				return GetTypedColumnValue<Guid>("ViolatedRuleTypeId");
			}
			set {
				SetColumnValue("ViolatedRuleTypeId", value);
				_violatedRuleType = null;
			}
		}

		/// <exclude/>
		public string ViolatedRuleTypeName {
			get {
				return GetTypedColumnValue<string>("ViolatedRuleTypeName");
			}
			set {
				SetColumnValue("ViolatedRuleTypeName", value);
				if (_violatedRuleType != null) {
					_violatedRuleType.Name = value;
				}
			}
		}

		private SysXssProtectRuleType _violatedRuleType;
		/// <summary>
		/// Violated rule type.
		/// </summary>
		public SysXssProtectRuleType ViolatedRuleType {
			get {
				return _violatedRuleType ??
					(_violatedRuleType = LookupColumnEntities.GetEntity("ViolatedRuleType") as SysXssProtectRuleType);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysXssProtectRuleViolation_XSSProtectionEventsProcess(UserConnection);
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
			return new SysXssProtectRuleViolation(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysXssProtectRuleViolation_XSSProtectionEventsProcess

	/// <exclude/>
	public partial class SysXssProtectRuleViolation_XSSProtectionEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysXssProtectRuleViolation
	{

		public SysXssProtectRuleViolation_XSSProtectionEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysXssProtectRuleViolation_XSSProtectionEventsProcess";
			SchemaUId = new Guid("e322ec8a-e1da-4bf9-b18d-eec2a834e5fb");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("e322ec8a-e1da-4bf9-b18d-eec2a834e5fb");
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

	#region Class: SysXssProtectRuleViolation_XSSProtectionEventsProcess

	/// <exclude/>
	public class SysXssProtectRuleViolation_XSSProtectionEventsProcess : SysXssProtectRuleViolation_XSSProtectionEventsProcess<SysXssProtectRuleViolation>
	{

		public SysXssProtectRuleViolation_XSSProtectionEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysXssProtectRuleViolation_XSSProtectionEventsProcess

	public partial class SysXssProtectRuleViolation_XSSProtectionEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysXssProtectRuleViolationEventsProcess

	/// <exclude/>
	public class SysXssProtectRuleViolationEventsProcess : SysXssProtectRuleViolation_XSSProtectionEventsProcess
	{

		public SysXssProtectRuleViolationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

