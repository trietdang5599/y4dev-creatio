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

	#region Class: SysXssProtectionRuleExclusionSchema

	/// <exclude/>
	public class SysXssProtectionRuleExclusionSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysXssProtectionRuleExclusionSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysXssProtectionRuleExclusionSchema(SysXssProtectionRuleExclusionSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysXssProtectionRuleExclusionSchema(SysXssProtectionRuleExclusionSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b3baef6e-77c8-403d-8243-d1f6e3a14581");
			RealUId = new Guid("b3baef6e-77c8-403d-8243-d1f6e3a14581");
			Name = "SysXssProtectionRuleExclusion";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
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
			if (Columns.FindByUId(new Guid("8c1f0ba1-e652-fae2-5263-20c55694604d")) == null) {
				Columns.Add(CreateExclusionTypeColumn());
			}
			if (Columns.FindByUId(new Guid("8d36bd09-1617-05d1-0a86-6c7a7db25459")) == null) {
				Columns.Add(CreateValueColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateExclusionTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("8c1f0ba1-e652-fae2-5263-20c55694604d"),
				Name = @"ExclusionType",
				ReferenceSchemaUId = new Guid("4f04dbf8-e4c0-4c06-8b1c-c9ab5c646bd2"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("b3baef6e-77c8-403d-8243-d1f6e3a14581"),
				ModifiedInSchemaUId = new Guid("b3baef6e-77c8-403d-8243-d1f6e3a14581"),
				CreatedInPackageId = new Guid("04cf391a-3fb7-4a0d-af93-87866ea53034")
			};
		}

		protected virtual EntitySchemaColumn CreateValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("8d36bd09-1617-05d1-0a86-6c7a7db25459"),
				Name = @"Value",
				CreatedInSchemaUId = new Guid("b3baef6e-77c8-403d-8243-d1f6e3a14581"),
				ModifiedInSchemaUId = new Guid("b3baef6e-77c8-403d-8243-d1f6e3a14581"),
				CreatedInPackageId = new Guid("04cf391a-3fb7-4a0d-af93-87866ea53034")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysXssProtectionRuleExclusion(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysXssProtectionRuleExclusion_XSSProtectionEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysXssProtectionRuleExclusionSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysXssProtectionRuleExclusionSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b3baef6e-77c8-403d-8243-d1f6e3a14581"));
		}

		#endregion

	}

	#endregion

	#region Class: SysXssProtectionRuleExclusion

	/// <summary>
	/// XSS protection rule exclusion.
	/// </summary>
	public class SysXssProtectionRuleExclusion : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysXssProtectionRuleExclusion(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysXssProtectionRuleExclusion";
		}

		public SysXssProtectionRuleExclusion(SysXssProtectionRuleExclusion source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ExclusionTypeId {
			get {
				return GetTypedColumnValue<Guid>("ExclusionTypeId");
			}
			set {
				SetColumnValue("ExclusionTypeId", value);
				_exclusionType = null;
			}
		}

		/// <exclude/>
		public string ExclusionTypeName {
			get {
				return GetTypedColumnValue<string>("ExclusionTypeName");
			}
			set {
				SetColumnValue("ExclusionTypeName", value);
				if (_exclusionType != null) {
					_exclusionType.Name = value;
				}
			}
		}

		private SysXssProtectRuleExclType _exclusionType;
		/// <summary>
		/// Type.
		/// </summary>
		public SysXssProtectRuleExclType ExclusionType {
			get {
				return _exclusionType ??
					(_exclusionType = LookupColumnEntities.GetEntity("ExclusionType") as SysXssProtectRuleExclType);
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

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysXssProtectionRuleExclusion_XSSProtectionEventsProcess(UserConnection);
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
			return new SysXssProtectionRuleExclusion(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysXssProtectionRuleExclusion_XSSProtectionEventsProcess

	/// <exclude/>
	public partial class SysXssProtectionRuleExclusion_XSSProtectionEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysXssProtectionRuleExclusion
	{

		public SysXssProtectionRuleExclusion_XSSProtectionEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysXssProtectionRuleExclusion_XSSProtectionEventsProcess";
			SchemaUId = new Guid("b3baef6e-77c8-403d-8243-d1f6e3a14581");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("b3baef6e-77c8-403d-8243-d1f6e3a14581");
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

	#region Class: SysXssProtectionRuleExclusion_XSSProtectionEventsProcess

	/// <exclude/>
	public class SysXssProtectionRuleExclusion_XSSProtectionEventsProcess : SysXssProtectionRuleExclusion_XSSProtectionEventsProcess<SysXssProtectionRuleExclusion>
	{

		public SysXssProtectionRuleExclusion_XSSProtectionEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysXssProtectionRuleExclusion_XSSProtectionEventsProcess

	public partial class SysXssProtectionRuleExclusion_XSSProtectionEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysXssProtectionRuleExclusionEventsProcess

	/// <exclude/>
	public class SysXssProtectionRuleExclusionEventsProcess : SysXssProtectionRuleExclusion_XSSProtectionEventsProcess
	{

		public SysXssProtectionRuleExclusionEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

