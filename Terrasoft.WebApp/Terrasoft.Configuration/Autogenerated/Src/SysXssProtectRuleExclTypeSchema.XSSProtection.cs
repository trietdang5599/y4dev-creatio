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

	#region Class: SysXssProtectRuleExclTypeSchema

	/// <exclude/>
	public class SysXssProtectRuleExclTypeSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public SysXssProtectRuleExclTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysXssProtectRuleExclTypeSchema(SysXssProtectRuleExclTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysXssProtectRuleExclTypeSchema(SysXssProtectRuleExclTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4f04dbf8-e4c0-4c06-8b1c-c9ab5c646bd2");
			RealUId = new Guid("4f04dbf8-e4c0-4c06-8b1c-c9ab5c646bd2");
			Name = "SysXssProtectRuleExclType";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("04cf391a-3fb7-4a0d-af93-87866ea53034");
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
			column.ModifiedInSchemaUId = new Guid("4f04dbf8-e4c0-4c06-8b1c-c9ab5c646bd2");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.IsLocalizable = false;
			column.ModifiedInSchemaUId = new Guid("4f04dbf8-e4c0-4c06-8b1c-c9ab5c646bd2");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysXssProtectRuleExclType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysXssProtectRuleExclType_XSSProtectionEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysXssProtectRuleExclTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysXssProtectRuleExclTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4f04dbf8-e4c0-4c06-8b1c-c9ab5c646bd2"));
		}

		#endregion

	}

	#endregion

	#region Class: SysXssProtectRuleExclType

	/// <summary>
	/// XSS protection rule exclusion type.
	/// </summary>
	public class SysXssProtectRuleExclType : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public SysXssProtectRuleExclType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysXssProtectRuleExclType";
		}

		public SysXssProtectRuleExclType(SysXssProtectRuleExclType source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysXssProtectRuleExclType_XSSProtectionEventsProcess(UserConnection);
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
			return new SysXssProtectRuleExclType(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysXssProtectRuleExclType_XSSProtectionEventsProcess

	/// <exclude/>
	public partial class SysXssProtectRuleExclType_XSSProtectionEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysXssProtectRuleExclType
	{

		public SysXssProtectRuleExclType_XSSProtectionEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysXssProtectRuleExclType_XSSProtectionEventsProcess";
			SchemaUId = new Guid("4f04dbf8-e4c0-4c06-8b1c-c9ab5c646bd2");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("4f04dbf8-e4c0-4c06-8b1c-c9ab5c646bd2");
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

	#region Class: SysXssProtectRuleExclType_XSSProtectionEventsProcess

	/// <exclude/>
	public class SysXssProtectRuleExclType_XSSProtectionEventsProcess : SysXssProtectRuleExclType_XSSProtectionEventsProcess<SysXssProtectRuleExclType>
	{

		public SysXssProtectRuleExclType_XSSProtectionEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysXssProtectRuleExclType_XSSProtectionEventsProcess

	public partial class SysXssProtectRuleExclType_XSSProtectionEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysXssProtectRuleExclTypeEventsProcess

	/// <exclude/>
	public class SysXssProtectRuleExclTypeEventsProcess : SysXssProtectRuleExclType_XSSProtectionEventsProcess
	{

		public SysXssProtectRuleExclTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

