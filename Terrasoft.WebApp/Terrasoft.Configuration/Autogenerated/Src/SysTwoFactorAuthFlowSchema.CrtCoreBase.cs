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

	#region Class: SysTwoFactorAuthFlowSchema

	/// <exclude/>
	public class SysTwoFactorAuthFlowSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysTwoFactorAuthFlowSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysTwoFactorAuthFlowSchema(SysTwoFactorAuthFlowSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysTwoFactorAuthFlowSchema(SysTwoFactorAuthFlowSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIUSysTwoFactorAuthFlowCodeIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = true
			};
			index.UId = new Guid("f2b80a28-1302-476d-9451-e5008e2f71f7");
			index.Name = "IUSysTwoFactorAuthFlowCode";
			index.CreatedInSchemaUId = new Guid("efe2f823-e5cb-4616-8f5d-ab1875810e03");
			index.ModifiedInSchemaUId = new Guid("efe2f823-e5cb-4616-8f5d-ab1875810e03");
			index.CreatedInPackageId = new Guid("1e78c195-217a-4877-a718-71dfe1dfe442");
			EntitySchemaIndexColumn codeIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("aefc8b1e-c3be-1185-751c-e923a84dbdce"),
				ColumnUId = new Guid("88b4d3cf-cece-3c48-3dc3-676e6345c420"),
				CreatedInSchemaUId = new Guid("efe2f823-e5cb-4616-8f5d-ab1875810e03"),
				ModifiedInSchemaUId = new Guid("efe2f823-e5cb-4616-8f5d-ab1875810e03"),
				CreatedInPackageId = new Guid("1e78c195-217a-4877-a718-71dfe1dfe442"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(codeIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("efe2f823-e5cb-4616-8f5d-ab1875810e03");
			RealUId = new Guid("efe2f823-e5cb-4616-8f5d-ab1875810e03");
			Name = "SysTwoFactorAuthFlow";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("acb004d0-c421-4dff-b075-f4fdc1c90074");
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
			if (Columns.FindByUId(new Guid("21eeec39-c493-43a5-6fda-930402a69ef5")) == null) {
				Columns.Add(CreateNameColumn());
			}
			if (Columns.FindByUId(new Guid("2102f3d5-bc85-613f-c258-092189d275a0")) == null) {
				Columns.Add(CreateEnabledColumn());
			}
			if (Columns.FindByUId(new Guid("7998e956-a6c6-fda2-e1c1-03d5d88a5bd5")) == null) {
				Columns.Add(CreatePrimaryColumn());
			}
			if (Columns.FindByUId(new Guid("88b4d3cf-cece-3c48-3dc3-676e6345c420")) == null) {
				Columns.Add(CreateCodeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("21eeec39-c493-43a5-6fda-930402a69ef5"),
				Name = @"Name",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("efe2f823-e5cb-4616-8f5d-ab1875810e03"),
				ModifiedInSchemaUId = new Guid("efe2f823-e5cb-4616-8f5d-ab1875810e03"),
				CreatedInPackageId = new Guid("acb004d0-c421-4dff-b075-f4fdc1c90074"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateEnabledColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("2102f3d5-bc85-613f-c258-092189d275a0"),
				Name = @"Enabled",
				CreatedInSchemaUId = new Guid("efe2f823-e5cb-4616-8f5d-ab1875810e03"),
				ModifiedInSchemaUId = new Guid("efe2f823-e5cb-4616-8f5d-ab1875810e03"),
				CreatedInPackageId = new Guid("acb004d0-c421-4dff-b075-f4fdc1c90074")
			};
		}

		protected virtual EntitySchemaColumn CreatePrimaryColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("7998e956-a6c6-fda2-e1c1-03d5d88a5bd5"),
				Name = @"Primary",
				CreatedInSchemaUId = new Guid("efe2f823-e5cb-4616-8f5d-ab1875810e03"),
				ModifiedInSchemaUId = new Guid("efe2f823-e5cb-4616-8f5d-ab1875810e03"),
				CreatedInPackageId = new Guid("acb004d0-c421-4dff-b075-f4fdc1c90074")
			};
		}

		protected virtual EntitySchemaColumn CreateCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("88b4d3cf-cece-3c48-3dc3-676e6345c420"),
				Name = @"Code",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("efe2f823-e5cb-4616-8f5d-ab1875810e03"),
				ModifiedInSchemaUId = new Guid("efe2f823-e5cb-4616-8f5d-ab1875810e03"),
				CreatedInPackageId = new Guid("acb004d0-c421-4dff-b075-f4fdc1c90074")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIUSysTwoFactorAuthFlowCodeIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysTwoFactorAuthFlow(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysTwoFactorAuthFlow_CrtCoreBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysTwoFactorAuthFlowSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysTwoFactorAuthFlowSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("efe2f823-e5cb-4616-8f5d-ab1875810e03"));
		}

		#endregion

	}

	#endregion

	#region Class: SysTwoFactorAuthFlow

	/// <summary>
	/// Two-Factor authentication flow.
	/// </summary>
	public class SysTwoFactorAuthFlow : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysTwoFactorAuthFlow(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysTwoFactorAuthFlow";
		}

		public SysTwoFactorAuthFlow(SysTwoFactorAuthFlow source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Name.
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
		/// Enabled.
		/// </summary>
		public bool Enabled {
			get {
				return GetTypedColumnValue<bool>("Enabled");
			}
			set {
				SetColumnValue("Enabled", value);
			}
		}

		/// <summary>
		/// Primary.
		/// </summary>
		public bool Primary {
			get {
				return GetTypedColumnValue<bool>("Primary");
			}
			set {
				SetColumnValue("Primary", value);
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

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysTwoFactorAuthFlow_CrtCoreBaseEventsProcess(UserConnection);
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
			return new SysTwoFactorAuthFlow(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysTwoFactorAuthFlow_CrtCoreBaseEventsProcess

	/// <exclude/>
	public partial class SysTwoFactorAuthFlow_CrtCoreBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysTwoFactorAuthFlow
	{

		public SysTwoFactorAuthFlow_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysTwoFactorAuthFlow_CrtCoreBaseEventsProcess";
			SchemaUId = new Guid("efe2f823-e5cb-4616-8f5d-ab1875810e03");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("efe2f823-e5cb-4616-8f5d-ab1875810e03");
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

	#region Class: SysTwoFactorAuthFlow_CrtCoreBaseEventsProcess

	/// <exclude/>
	public class SysTwoFactorAuthFlow_CrtCoreBaseEventsProcess : SysTwoFactorAuthFlow_CrtCoreBaseEventsProcess<SysTwoFactorAuthFlow>
	{

		public SysTwoFactorAuthFlow_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysTwoFactorAuthFlow_CrtCoreBaseEventsProcess

	public partial class SysTwoFactorAuthFlow_CrtCoreBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysTwoFactorAuthFlowEventsProcess

	/// <exclude/>
	public class SysTwoFactorAuthFlowEventsProcess : SysTwoFactorAuthFlow_CrtCoreBaseEventsProcess
	{

		public SysTwoFactorAuthFlowEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

