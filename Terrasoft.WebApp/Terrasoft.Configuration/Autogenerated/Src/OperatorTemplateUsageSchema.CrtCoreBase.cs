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

	#region Class: OperatorTemplateUsageSchema

	/// <exclude/>
	public class OperatorTemplateUsageSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public OperatorTemplateUsageSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OperatorTemplateUsageSchema(OperatorTemplateUsageSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OperatorTemplateUsageSchema(OperatorTemplateUsageSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f31e4fc3-d340-436c-aee6-efd20d90fb31");
			RealUId = new Guid("f31e4fc3-d340-436c-aee6-efd20d90fb31");
			Name = "OperatorTemplateUsage";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("2e25ab49-5dc6-4f9d-b82e-b54253963d38");
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
			if (Columns.FindByUId(new Guid("36a02be6-f471-9938-96b2-80c1ed3fdbbb")) == null) {
				Columns.Add(CreateTemplateColumn());
			}
			if (Columns.FindByUId(new Guid("47ed2ca3-cdca-18bc-4275-dd70d80b43f8")) == null) {
				Columns.Add(CreateUsageCountColumn());
			}
			if (Columns.FindByUId(new Guid("2e4b65ef-b79c-b453-8d4d-d64f5a19b364")) == null) {
				Columns.Add(CreateOperatorColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateTemplateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("36a02be6-f471-9938-96b2-80c1ed3fdbbb"),
				Name = @"Template",
				ReferenceSchemaUId = new Guid("93030575-f70f-4041-902e-c4badaf62c63"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("f31e4fc3-d340-436c-aee6-efd20d90fb31"),
				ModifiedInSchemaUId = new Guid("f31e4fc3-d340-436c-aee6-efd20d90fb31"),
				CreatedInPackageId = new Guid("2e25ab49-5dc6-4f9d-b82e-b54253963d38"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateUsageCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("47ed2ca3-cdca-18bc-4275-dd70d80b43f8"),
				Name = @"UsageCount",
				CreatedInSchemaUId = new Guid("f31e4fc3-d340-436c-aee6-efd20d90fb31"),
				ModifiedInSchemaUId = new Guid("f31e4fc3-d340-436c-aee6-efd20d90fb31"),
				CreatedInPackageId = new Guid("2e25ab49-5dc6-4f9d-b82e-b54253963d38")
			};
		}

		protected virtual EntitySchemaColumn CreateOperatorColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("2e4b65ef-b79c-b453-8d4d-d64f5a19b364"),
				Name = @"Operator",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("f31e4fc3-d340-436c-aee6-efd20d90fb31"),
				ModifiedInSchemaUId = new Guid("f31e4fc3-d340-436c-aee6-efd20d90fb31"),
				CreatedInPackageId = new Guid("2e25ab49-5dc6-4f9d-b82e-b54253963d38"),
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
			return new OperatorTemplateUsage(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OperatorTemplateUsage_CrtCoreBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OperatorTemplateUsageSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OperatorTemplateUsageSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f31e4fc3-d340-436c-aee6-efd20d90fb31"));
		}

		#endregion

	}

	#endregion

	#region Class: OperatorTemplateUsage

	/// <summary>
	/// OperatorTemplateUsage.
	/// </summary>
	/// <remarks>
	/// Stores template usage statistics per operator for personalized "Most Used" template suggestions.
	/// </remarks>
	public class OperatorTemplateUsage : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public OperatorTemplateUsage(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OperatorTemplateUsage";
		}

		public OperatorTemplateUsage(OperatorTemplateUsage source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid TemplateId {
			get {
				return GetTypedColumnValue<Guid>("TemplateId");
			}
			set {
				SetColumnValue("TemplateId", value);
				_template = null;
			}
		}

		/// <exclude/>
		public string TemplateName {
			get {
				return GetTypedColumnValue<string>("TemplateName");
			}
			set {
				SetColumnValue("TemplateName", value);
				if (_template != null) {
					_template.Name = value;
				}
			}
		}

		private EmailTemplate _template;
		/// <summary>
		/// Template.
		/// </summary>
		public EmailTemplate Template {
			get {
				return _template ??
					(_template = LookupColumnEntities.GetEntity("Template") as EmailTemplate);
			}
		}

		/// <summary>
		/// UsageCount.
		/// </summary>
		/// <remarks>
		/// Number of times the template was used by the operator.
		/// </remarks>
		public int UsageCount {
			get {
				return GetTypedColumnValue<int>("UsageCount");
			}
			set {
				SetColumnValue("UsageCount", value);
			}
		}

		/// <exclude/>
		public Guid OperatorId {
			get {
				return GetTypedColumnValue<Guid>("OperatorId");
			}
			set {
				SetColumnValue("OperatorId", value);
				_operator = null;
			}
		}

		/// <exclude/>
		public string OperatorName {
			get {
				return GetTypedColumnValue<string>("OperatorName");
			}
			set {
				SetColumnValue("OperatorName", value);
				if (_operator != null) {
					_operator.Name = value;
				}
			}
		}

		private SysAdminUnit _operator;
		/// <summary>
		/// Operator.
		/// </summary>
		/// <remarks>
		/// Id of Operator.
		/// </remarks>
		public SysAdminUnit Operator {
			get {
				return _operator ??
					(_operator = LookupColumnEntities.GetEntity("Operator") as SysAdminUnit);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OperatorTemplateUsage_CrtCoreBaseEventsProcess(UserConnection);
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
			return new OperatorTemplateUsage(this);
		}

		#endregion

	}

	#endregion

	#region Class: OperatorTemplateUsage_CrtCoreBaseEventsProcess

	/// <exclude/>
	public partial class OperatorTemplateUsage_CrtCoreBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : OperatorTemplateUsage
	{

		public OperatorTemplateUsage_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OperatorTemplateUsage_CrtCoreBaseEventsProcess";
			SchemaUId = new Guid("f31e4fc3-d340-436c-aee6-efd20d90fb31");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("f31e4fc3-d340-436c-aee6-efd20d90fb31");
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

	#region Class: OperatorTemplateUsage_CrtCoreBaseEventsProcess

	/// <exclude/>
	public class OperatorTemplateUsage_CrtCoreBaseEventsProcess : OperatorTemplateUsage_CrtCoreBaseEventsProcess<OperatorTemplateUsage>
	{

		public OperatorTemplateUsage_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OperatorTemplateUsage_CrtCoreBaseEventsProcess

	public partial class OperatorTemplateUsage_CrtCoreBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: OperatorTemplateUsageEventsProcess

	/// <exclude/>
	public class OperatorTemplateUsageEventsProcess : OperatorTemplateUsage_CrtCoreBaseEventsProcess
	{

		public OperatorTemplateUsageEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

