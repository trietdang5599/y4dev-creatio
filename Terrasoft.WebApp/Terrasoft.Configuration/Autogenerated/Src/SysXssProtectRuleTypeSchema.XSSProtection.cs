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

	#region Class: SysXssProtectRuleTypeSchema

	/// <exclude/>
	public class SysXssProtectRuleTypeSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public SysXssProtectRuleTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysXssProtectRuleTypeSchema(SysXssProtectRuleTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysXssProtectRuleTypeSchema(SysXssProtectRuleTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0e92afa3-1557-4113-9f07-ff97326fda0f");
			RealUId = new Guid("0e92afa3-1557-4113-9f07-ff97326fda0f");
			Name = "SysXssProtectRuleType";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
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
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.IsLocalizable = false;
			column.ModifiedInSchemaUId = new Guid("0e92afa3-1557-4113-9f07-ff97326fda0f");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.IsLocalizable = false;
			column.ModifiedInSchemaUId = new Guid("0e92afa3-1557-4113-9f07-ff97326fda0f");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysXssProtectRuleType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysXssProtectRuleType_XSSProtectionEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysXssProtectRuleTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysXssProtectRuleTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0e92afa3-1557-4113-9f07-ff97326fda0f"));
		}

		#endregion

	}

	#endregion

	#region Class: SysXssProtectRuleType

	/// <summary>
	/// XSS protection rule type.
	/// </summary>
	public class SysXssProtectRuleType : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public SysXssProtectRuleType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysXssProtectRuleType";
		}

		public SysXssProtectRuleType(SysXssProtectRuleType source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysXssProtectRuleType_XSSProtectionEventsProcess(UserConnection);
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
			return new SysXssProtectRuleType(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysXssProtectRuleType_XSSProtectionEventsProcess

	/// <exclude/>
	public partial class SysXssProtectRuleType_XSSProtectionEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysXssProtectRuleType
	{

		public SysXssProtectRuleType_XSSProtectionEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysXssProtectRuleType_XSSProtectionEventsProcess";
			SchemaUId = new Guid("0e92afa3-1557-4113-9f07-ff97326fda0f");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("0e92afa3-1557-4113-9f07-ff97326fda0f");
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

	#region Class: SysXssProtectRuleType_XSSProtectionEventsProcess

	/// <exclude/>
	public class SysXssProtectRuleType_XSSProtectionEventsProcess : SysXssProtectRuleType_XSSProtectionEventsProcess<SysXssProtectRuleType>
	{

		public SysXssProtectRuleType_XSSProtectionEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysXssProtectRuleType_XSSProtectionEventsProcess

	public partial class SysXssProtectRuleType_XSSProtectionEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysXssProtectRuleTypeEventsProcess

	/// <exclude/>
	public class SysXssProtectRuleTypeEventsProcess : SysXssProtectRuleType_XSSProtectionEventsProcess
	{

		public SysXssProtectRuleTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

