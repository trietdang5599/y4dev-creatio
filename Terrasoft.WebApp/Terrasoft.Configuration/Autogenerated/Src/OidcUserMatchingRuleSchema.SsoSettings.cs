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

	#region Class: OidcUserMatchingRuleSchema

	/// <exclude/>
	public class OidcUserMatchingRuleSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public OidcUserMatchingRuleSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OidcUserMatchingRuleSchema(OidcUserMatchingRuleSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OidcUserMatchingRuleSchema(OidcUserMatchingRuleSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a80108d1-2231-4632-865a-53b0e8754578");
			RealUId = new Guid("a80108d1-2231-4632-865a-53b0e8754578");
			Name = "OidcUserMatchingRule";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("fe45ef90-0df4-4cc5-89d2-a38ddc4544cc");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = false;
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
			if (Columns.FindByUId(new Guid("8daf529d-2f20-40d3-b54b-78ce00aab35c")) == null) {
				Columns.Add(CreateOidcTokenClaimColumn());
			}
			if (Columns.FindByUId(new Guid("b2a8a3a9-622f-454b-ba69-c9b9d8c821d0")) == null) {
				Columns.Add(CreateSysAdminUnitColumnColumn());
			}
			if (Columns.FindByUId(new Guid("813cfece-9ee1-4a14-8707-81f0e7dbb5a4")) == null) {
				Columns.Add(CreateOrderColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateOidcTokenClaimColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("8daf529d-2f20-40d3-b54b-78ce00aab35c"),
				Name = @"OidcTokenClaim",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("a80108d1-2231-4632-865a-53b0e8754578"),
				ModifiedInSchemaUId = new Guid("a80108d1-2231-4632-865a-53b0e8754578"),
				CreatedInPackageId = new Guid("fe45ef90-0df4-4cc5-89d2-a38ddc4544cc")
			};
		}

		protected virtual EntitySchemaColumn CreateSysAdminUnitColumnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("b2a8a3a9-622f-454b-ba69-c9b9d8c821d0"),
				Name = @"SysAdminUnitColumn",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("a80108d1-2231-4632-865a-53b0e8754578"),
				ModifiedInSchemaUId = new Guid("a80108d1-2231-4632-865a-53b0e8754578"),
				CreatedInPackageId = new Guid("fe45ef90-0df4-4cc5-89d2-a38ddc4544cc")
			};
		}

		protected virtual EntitySchemaColumn CreateOrderColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("813cfece-9ee1-4a14-8707-81f0e7dbb5a4"),
				Name = @"Order",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("a80108d1-2231-4632-865a-53b0e8754578"),
				ModifiedInSchemaUId = new Guid("a80108d1-2231-4632-865a-53b0e8754578"),
				CreatedInPackageId = new Guid("fe45ef90-0df4-4cc5-89d2-a38ddc4544cc")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new OidcUserMatchingRule(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OidcUserMatchingRule_SsoSettingsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OidcUserMatchingRuleSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OidcUserMatchingRuleSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a80108d1-2231-4632-865a-53b0e8754578"));
		}

		#endregion

	}

	#endregion

	#region Class: OidcUserMatchingRule

	/// <summary>
	/// Base object.
	/// </summary>
	public class OidcUserMatchingRule : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public OidcUserMatchingRule(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OidcUserMatchingRule";
		}

		public OidcUserMatchingRule(OidcUserMatchingRule source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		public string OidcTokenClaim {
			get {
				return GetTypedColumnValue<string>("OidcTokenClaim");
			}
			set {
				SetColumnValue("OidcTokenClaim", value);
			}
		}

		public string SysAdminUnitColumn {
			get {
				return GetTypedColumnValue<string>("SysAdminUnitColumn");
			}
			set {
				SetColumnValue("SysAdminUnitColumn", value);
			}
		}

		public int Order {
			get {
				return GetTypedColumnValue<int>("Order");
			}
			set {
				SetColumnValue("Order", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OidcUserMatchingRule_SsoSettingsEventsProcess(UserConnection);
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
			return new OidcUserMatchingRule(this);
		}

		#endregion

	}

	#endregion

	#region Class: OidcUserMatchingRule_SsoSettingsEventsProcess

	/// <exclude/>
	public partial class OidcUserMatchingRule_SsoSettingsEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : OidcUserMatchingRule
	{

		public OidcUserMatchingRule_SsoSettingsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OidcUserMatchingRule_SsoSettingsEventsProcess";
			SchemaUId = new Guid("a80108d1-2231-4632-865a-53b0e8754578");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("a80108d1-2231-4632-865a-53b0e8754578");
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

	#region Class: OidcUserMatchingRule_SsoSettingsEventsProcess

	/// <exclude/>
	public class OidcUserMatchingRule_SsoSettingsEventsProcess : OidcUserMatchingRule_SsoSettingsEventsProcess<OidcUserMatchingRule>
	{

		public OidcUserMatchingRule_SsoSettingsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OidcUserMatchingRule_SsoSettingsEventsProcess

	public partial class OidcUserMatchingRule_SsoSettingsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: OidcUserMatchingRuleEventsProcess

	/// <exclude/>
	public class OidcUserMatchingRuleEventsProcess : OidcUserMatchingRule_SsoSettingsEventsProcess
	{

		public OidcUserMatchingRuleEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

