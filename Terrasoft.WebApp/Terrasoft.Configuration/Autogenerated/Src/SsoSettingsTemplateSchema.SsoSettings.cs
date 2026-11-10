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

	#region Class: SsoSettingsTemplateSchema

	/// <exclude/>
	public class SsoSettingsTemplateSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public SsoSettingsTemplateSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SsoSettingsTemplateSchema(SsoSettingsTemplateSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SsoSettingsTemplateSchema(SsoSettingsTemplateSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a1771533-7e22-4f39-b869-e19d2c54f911");
			RealUId = new Guid("a1771533-7e22-4f39-b869-e19d2c54f911");
			Name = "SsoSettingsTemplate";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("e5aa7639-5b66-4d72-9308-0563d89b2353");
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
			if (Columns.FindByUId(new Guid("f7b25b01-d61f-d58a-d7cd-ff1c0c47a274")) == null) {
				Columns.Add(CreateProviderTypeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateProviderTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("f7b25b01-d61f-d58a-d7cd-ff1c0c47a274"),
				Name = @"ProviderType",
				ReferenceSchemaUId = new Guid("92ecd864-36c7-48ad-a8c2-2aad861077b9"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("a1771533-7e22-4f39-b869-e19d2c54f911"),
				ModifiedInSchemaUId = new Guid("a1771533-7e22-4f39-b869-e19d2c54f911"),
				CreatedInPackageId = new Guid("e5aa7639-5b66-4d72-9308-0563d89b2353"),
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
			return new SsoSettingsTemplate(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SsoSettingsTemplate_SsoSettingsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SsoSettingsTemplateSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SsoSettingsTemplateSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a1771533-7e22-4f39-b869-e19d2c54f911"));
		}

		#endregion

	}

	#endregion

	#region Class: SsoSettingsTemplate

	/// <summary>
	/// Sso settings template.
	/// </summary>
	public class SsoSettingsTemplate : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public SsoSettingsTemplate(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SsoSettingsTemplate";
		}

		public SsoSettingsTemplate(SsoSettingsTemplate source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ProviderTypeId {
			get {
				return GetTypedColumnValue<Guid>("ProviderTypeId");
			}
			set {
				SetColumnValue("ProviderTypeId", value);
				_providerType = null;
			}
		}

		/// <exclude/>
		public string ProviderTypeName {
			get {
				return GetTypedColumnValue<string>("ProviderTypeName");
			}
			set {
				SetColumnValue("ProviderTypeName", value);
				if (_providerType != null) {
					_providerType.Name = value;
				}
			}
		}

		private SsoProviderType _providerType;
		/// <summary>
		/// Type.
		/// </summary>
		public SsoProviderType ProviderType {
			get {
				return _providerType ??
					(_providerType = LookupColumnEntities.GetEntity("ProviderType") as SsoProviderType);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SsoSettingsTemplate_SsoSettingsEventsProcess(UserConnection);
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
			return new SsoSettingsTemplate(this);
		}

		#endregion

	}

	#endregion

	#region Class: SsoSettingsTemplate_SsoSettingsEventsProcess

	/// <exclude/>
	public partial class SsoSettingsTemplate_SsoSettingsEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : SsoSettingsTemplate
	{

		public SsoSettingsTemplate_SsoSettingsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SsoSettingsTemplate_SsoSettingsEventsProcess";
			SchemaUId = new Guid("a1771533-7e22-4f39-b869-e19d2c54f911");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("a1771533-7e22-4f39-b869-e19d2c54f911");
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

	#region Class: SsoSettingsTemplate_SsoSettingsEventsProcess

	/// <exclude/>
	public class SsoSettingsTemplate_SsoSettingsEventsProcess : SsoSettingsTemplate_SsoSettingsEventsProcess<SsoSettingsTemplate>
	{

		public SsoSettingsTemplate_SsoSettingsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SsoSettingsTemplate_SsoSettingsEventsProcess

	public partial class SsoSettingsTemplate_SsoSettingsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SsoSettingsTemplateEventsProcess

	/// <exclude/>
	public class SsoSettingsTemplateEventsProcess : SsoSettingsTemplate_SsoSettingsEventsProcess
	{

		public SsoSettingsTemplateEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

