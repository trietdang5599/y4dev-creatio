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

	#region Class: XssProtectionModeSchema

	/// <exclude/>
	public class XssProtectionModeSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public XssProtectionModeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public XssProtectionModeSchema(XssProtectionModeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public XssProtectionModeSchema(XssProtectionModeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("717d6f06-2f31-4b9e-aea8-b2edb91a728b");
			RealUId = new Guid("717d6f06-2f31-4b9e-aea8-b2edb91a728b");
			Name = "XssProtectionMode";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("41135374-8a2c-4dff-a3cc-3495e07083bc");
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

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateNameColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("24b60871-ffb2-56d3-222a-66e687ff3c40"),
				Name = @"Name",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("717d6f06-2f31-4b9e-aea8-b2edb91a728b"),
				ModifiedInSchemaUId = new Guid("717d6f06-2f31-4b9e-aea8-b2edb91a728b"),
				CreatedInPackageId = new Guid("41135374-8a2c-4dff-a3cc-3495e07083bc"),
				IsLocalizable = true
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new XssProtectionMode(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new XssProtectionMode_XSSProtectionEventsProcess(userConnection);
		}

		public override object Clone() {
			return new XssProtectionModeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new XssProtectionModeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("717d6f06-2f31-4b9e-aea8-b2edb91a728b"));
		}

		#endregion

	}

	#endregion

	#region Class: XssProtectionMode

	/// <summary>
	/// XSS protection mode.
	/// </summary>
	public class XssProtectionMode : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public XssProtectionMode(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "XssProtectionMode";
		}

		public XssProtectionMode(XssProtectionMode source)
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

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new XssProtectionMode_XSSProtectionEventsProcess(UserConnection);
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
			return new XssProtectionMode(this);
		}

		#endregion

	}

	#endregion

	#region Class: XssProtectionMode_XSSProtectionEventsProcess

	/// <exclude/>
	public partial class XssProtectionMode_XSSProtectionEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : XssProtectionMode
	{

		public XssProtectionMode_XSSProtectionEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "XssProtectionMode_XSSProtectionEventsProcess";
			SchemaUId = new Guid("717d6f06-2f31-4b9e-aea8-b2edb91a728b");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("717d6f06-2f31-4b9e-aea8-b2edb91a728b");
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

	#region Class: XssProtectionMode_XSSProtectionEventsProcess

	/// <exclude/>
	public class XssProtectionMode_XSSProtectionEventsProcess : XssProtectionMode_XSSProtectionEventsProcess<XssProtectionMode>
	{

		public XssProtectionMode_XSSProtectionEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: XssProtectionMode_XSSProtectionEventsProcess

	public partial class XssProtectionMode_XSSProtectionEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: XssProtectionModeEventsProcess

	/// <exclude/>
	public class XssProtectionModeEventsProcess : XssProtectionMode_XSSProtectionEventsProcess
	{

		public XssProtectionModeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

