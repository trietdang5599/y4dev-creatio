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

	#region Class: SysXssProtectionRuleSchema

	/// <exclude/>
	public class SysXssProtectionRuleSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysXssProtectionRuleSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysXssProtectionRuleSchema(SysXssProtectionRuleSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysXssProtectionRuleSchema(SysXssProtectionRuleSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4c31d656-9fd6-41a4-846d-b2aa0bedf192");
			RealUId = new Guid("4c31d656-9fd6-41a4-846d-b2aa0bedf192");
			Name = "SysXssProtectionRule";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("9ba4937c-2efe-4172-bf08-6d8e00396177");
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
			if (Columns.FindByUId(new Guid("dbc5dee2-a3b8-06d3-870a-49122201154d")) == null) {
				Columns.Add(CreateRuleTypeColumn());
			}
			if (Columns.FindByUId(new Guid("ea7b4fe5-95f1-4762-dab5-1afad73a8fc9")) == null) {
				Columns.Add(CreateValueColumn());
			}
			if (Columns.FindByUId(new Guid("c8a5c209-f6dd-c874-a465-541bf7335036")) == null) {
				Columns.Add(CreateProtectionModeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateRuleTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("dbc5dee2-a3b8-06d3-870a-49122201154d"),
				Name = @"RuleType",
				ReferenceSchemaUId = new Guid("0e92afa3-1557-4113-9f07-ff97326fda0f"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("4c31d656-9fd6-41a4-846d-b2aa0bedf192"),
				ModifiedInSchemaUId = new Guid("4c31d656-9fd6-41a4-846d-b2aa0bedf192"),
				CreatedInPackageId = new Guid("9ba4937c-2efe-4172-bf08-6d8e00396177")
			};
		}

		protected virtual EntitySchemaColumn CreateValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("ea7b4fe5-95f1-4762-dab5-1afad73a8fc9"),
				Name = @"Value",
				CreatedInSchemaUId = new Guid("4c31d656-9fd6-41a4-846d-b2aa0bedf192"),
				ModifiedInSchemaUId = new Guid("4c31d656-9fd6-41a4-846d-b2aa0bedf192"),
				CreatedInPackageId = new Guid("9ba4937c-2efe-4172-bf08-6d8e00396177")
			};
		}

		protected virtual EntitySchemaColumn CreateProtectionModeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("c8a5c209-f6dd-c874-a465-541bf7335036"),
				Name = @"ProtectionMode",
				ReferenceSchemaUId = new Guid("717d6f06-2f31-4b9e-aea8-b2edb91a728b"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("4c31d656-9fd6-41a4-846d-b2aa0bedf192"),
				ModifiedInSchemaUId = new Guid("4c31d656-9fd6-41a4-846d-b2aa0bedf192"),
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
			return new SysXssProtectionRule(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysXssProtectionRule_XSSProtectionEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysXssProtectionRuleSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysXssProtectionRuleSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4c31d656-9fd6-41a4-846d-b2aa0bedf192"));
		}

		#endregion

	}

	#endregion

	#region Class: SysXssProtectionRule

	/// <summary>
	/// XSS protection rule.
	/// </summary>
	public class SysXssProtectionRule : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysXssProtectionRule(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysXssProtectionRule";
		}

		public SysXssProtectionRule(SysXssProtectionRule source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid RuleTypeId {
			get {
				return GetTypedColumnValue<Guid>("RuleTypeId");
			}
			set {
				SetColumnValue("RuleTypeId", value);
				_ruleType = null;
			}
		}

		/// <exclude/>
		public string RuleTypeName {
			get {
				return GetTypedColumnValue<string>("RuleTypeName");
			}
			set {
				SetColumnValue("RuleTypeName", value);
				if (_ruleType != null) {
					_ruleType.Name = value;
				}
			}
		}

		private SysXssProtectRuleType _ruleType;
		/// <summary>
		/// Type.
		/// </summary>
		public SysXssProtectRuleType RuleType {
			get {
				return _ruleType ??
					(_ruleType = LookupColumnEntities.GetEntity("RuleType") as SysXssProtectRuleType);
			}
		}

		/// <summary>
		/// Value.
		/// </summary>
		public string Value {
			get {
				return GetTypedColumnValue<string>("Value");
			}
			set {
				SetColumnValue("Value", value);
			}
		}

		/// <exclude/>
		public Guid ProtectionModeId {
			get {
				return GetTypedColumnValue<Guid>("ProtectionModeId");
			}
			set {
				SetColumnValue("ProtectionModeId", value);
				_protectionMode = null;
			}
		}

		/// <exclude/>
		public string ProtectionModeName {
			get {
				return GetTypedColumnValue<string>("ProtectionModeName");
			}
			set {
				SetColumnValue("ProtectionModeName", value);
				if (_protectionMode != null) {
					_protectionMode.Name = value;
				}
			}
		}

		private XssProtectionMode _protectionMode;
		/// <summary>
		/// Protection mode.
		/// </summary>
		public XssProtectionMode ProtectionMode {
			get {
				return _protectionMode ??
					(_protectionMode = LookupColumnEntities.GetEntity("ProtectionMode") as XssProtectionMode);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysXssProtectionRule_XSSProtectionEventsProcess(UserConnection);
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
			return new SysXssProtectionRule(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysXssProtectionRule_XSSProtectionEventsProcess

	/// <exclude/>
	public partial class SysXssProtectionRule_XSSProtectionEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysXssProtectionRule
	{

		public SysXssProtectionRule_XSSProtectionEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysXssProtectionRule_XSSProtectionEventsProcess";
			SchemaUId = new Guid("4c31d656-9fd6-41a4-846d-b2aa0bedf192");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("4c31d656-9fd6-41a4-846d-b2aa0bedf192");
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

	#region Class: SysXssProtectionRule_XSSProtectionEventsProcess

	/// <exclude/>
	public class SysXssProtectionRule_XSSProtectionEventsProcess : SysXssProtectionRule_XSSProtectionEventsProcess<SysXssProtectionRule>
	{

		public SysXssProtectionRule_XSSProtectionEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysXssProtectionRule_XSSProtectionEventsProcess

	public partial class SysXssProtectionRule_XSSProtectionEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysXssProtectionRuleEventsProcess

	/// <exclude/>
	public class SysXssProtectionRuleEventsProcess : SysXssProtectionRule_XSSProtectionEventsProcess
	{

		public SysXssProtectionRuleEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

