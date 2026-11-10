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

	#region Class: SsoProviderSchema

	/// <exclude/>
	public class SsoProviderSchema : Terrasoft.Configuration.BaseCodeLookupSchema
	{

		#region Constructors: Public

		public SsoProviderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SsoProviderSchema(SsoProviderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SsoProviderSchema(SsoProviderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateISsoProviderCodeIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = true
			};
			index.UId = new Guid("4f588d26-3ef5-4264-9935-a93294492c38");
			index.Name = "ISsoProviderCode";
			index.CreatedInSchemaUId = new Guid("1e5b03af-036d-47c4-b8a6-d51aef0e795f");
			index.ModifiedInSchemaUId = new Guid("1e5b03af-036d-47c4-b8a6-d51aef0e795f");
			index.CreatedInPackageId = new Guid("8579352f-cfdd-4183-b428-a1dc774bf344");
			EntitySchemaIndexColumn codeIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("3917232c-68a0-88fc-faec-85ca3af5c2c1"),
				ColumnUId = new Guid("13aad544-ec30-4e76-a373-f0cff3202e24"),
				CreatedInSchemaUId = new Guid("1e5b03af-036d-47c4-b8a6-d51aef0e795f"),
				ModifiedInSchemaUId = new Guid("1e5b03af-036d-47c4-b8a6-d51aef0e795f"),
				CreatedInPackageId = new Guid("8579352f-cfdd-4183-b428-a1dc774bf344"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(codeIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("1e5b03af-036d-47c4-b8a6-d51aef0e795f");
			RealUId = new Guid("1e5b03af-036d-47c4-b8a6-d51aef0e795f");
			Name = "SsoProvider";
			ParentSchemaUId = new Guid("2681062b-df59-4e52-89ed-f9b7dc909ab2");
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
			if (Columns.FindByUId(new Guid("4e1e2677-1439-4e98-9b7d-dfbc12c2d61a")) == null) {
				Columns.Add(CreateEnableAutoLoginColumn());
			}
			if (Columns.FindByUId(new Guid("207b9d69-9f2e-e151-5d77-3e40ef05140d")) == null) {
				Columns.Add(CreateSsoSettingsTemplateColumn());
			}
			if (Columns.FindByUId(new Guid("8419ab06-d90f-6c0a-6989-cd452a2f261c")) == null) {
				Columns.Add(CreateUserTypeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateEnableAutoLoginColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("4e1e2677-1439-4e98-9b7d-dfbc12c2d61a"),
				Name = @"EnableAutoLogin",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("1e5b03af-036d-47c4-b8a6-d51aef0e795f"),
				ModifiedInSchemaUId = new Guid("1e5b03af-036d-47c4-b8a6-d51aef0e795f"),
				CreatedInPackageId = new Guid("e5aa7639-5b66-4d72-9308-0563d89b2353")
			};
		}

		protected virtual EntitySchemaColumn CreateSsoSettingsTemplateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("207b9d69-9f2e-e151-5d77-3e40ef05140d"),
				Name = @"SsoSettingsTemplate",
				ReferenceSchemaUId = new Guid("a1771533-7e22-4f39-b869-e19d2c54f911"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("1e5b03af-036d-47c4-b8a6-d51aef0e795f"),
				ModifiedInSchemaUId = new Guid("1e5b03af-036d-47c4-b8a6-d51aef0e795f"),
				CreatedInPackageId = new Guid("e5aa7639-5b66-4d72-9308-0563d89b2353"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateUserTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("8419ab06-d90f-6c0a-6989-cd452a2f261c"),
				Name = @"UserType",
				ReferenceSchemaUId = new Guid("c1e35112-a039-4bf4-94a0-1afce4211706"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("1e5b03af-036d-47c4-b8a6-d51aef0e795f"),
				ModifiedInSchemaUId = new Guid("1e5b03af-036d-47c4-b8a6-d51aef0e795f"),
				CreatedInPackageId = new Guid("e8fcf94c-c989-4493-bb03-10b5c86c0b32"),
				IsSimpleLookup = true,
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"e96a0adf-3e4f-47f9-81c3-e8628eab55f0"
				}
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateISsoProviderCodeIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SsoProvider(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SsoProvider_SsoSettingsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SsoProviderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SsoProviderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1e5b03af-036d-47c4-b8a6-d51aef0e795f"));
		}

		#endregion

	}

	#endregion

	#region Class: SsoProvider

	/// <summary>
	/// SsoProvider.
	/// </summary>
	public class SsoProvider : Terrasoft.Configuration.BaseCodeLookup
	{

		#region Constructors: Public

		public SsoProvider(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SsoProvider";
		}

		public SsoProvider(SsoProvider source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		public bool EnableAutoLogin {
			get {
				return GetTypedColumnValue<bool>("EnableAutoLogin");
			}
			set {
				SetColumnValue("EnableAutoLogin", value);
			}
		}

		/// <exclude/>
		public Guid SsoSettingsTemplateId {
			get {
				return GetTypedColumnValue<Guid>("SsoSettingsTemplateId");
			}
			set {
				SetColumnValue("SsoSettingsTemplateId", value);
				_ssoSettingsTemplate = null;
			}
		}

		/// <exclude/>
		public string SsoSettingsTemplateName {
			get {
				return GetTypedColumnValue<string>("SsoSettingsTemplateName");
			}
			set {
				SetColumnValue("SsoSettingsTemplateName", value);
				if (_ssoSettingsTemplate != null) {
					_ssoSettingsTemplate.Name = value;
				}
			}
		}

		private SsoSettingsTemplate _ssoSettingsTemplate;
		/// <summary>
		/// Settings template.
		/// </summary>
		public SsoSettingsTemplate SsoSettingsTemplate {
			get {
				return _ssoSettingsTemplate ??
					(_ssoSettingsTemplate = LookupColumnEntities.GetEntity("SsoSettingsTemplate") as SsoSettingsTemplate);
			}
		}

		/// <exclude/>
		public Guid UserTypeId {
			get {
				return GetTypedColumnValue<Guid>("UserTypeId");
			}
			set {
				SetColumnValue("UserTypeId", value);
				_userType = null;
			}
		}

		/// <exclude/>
		public string UserTypeName {
			get {
				return GetTypedColumnValue<string>("UserTypeName");
			}
			set {
				SetColumnValue("UserTypeName", value);
				if (_userType != null) {
					_userType.Name = value;
				}
			}
		}

		private SsoUserType _userType;
		/// <summary>
		/// User type.
		/// </summary>
		public SsoUserType UserType {
			get {
				return _userType ??
					(_userType = LookupColumnEntities.GetEntity("UserType") as SsoUserType);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SsoProvider_SsoSettingsEventsProcess(UserConnection);
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
			return new SsoProvider(this);
		}

		#endregion

	}

	#endregion

	#region Class: SsoProvider_SsoSettingsEventsProcess

	/// <exclude/>
	public partial class SsoProvider_SsoSettingsEventsProcess<TEntity> : Terrasoft.Configuration.BaseCodeLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : SsoProvider
	{

		public SsoProvider_SsoSettingsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SsoProvider_SsoSettingsEventsProcess";
			SchemaUId = new Guid("1e5b03af-036d-47c4-b8a6-d51aef0e795f");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("1e5b03af-036d-47c4-b8a6-d51aef0e795f");
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

	#region Class: SsoProvider_SsoSettingsEventsProcess

	/// <exclude/>
	public class SsoProvider_SsoSettingsEventsProcess : SsoProvider_SsoSettingsEventsProcess<SsoProvider>
	{

		public SsoProvider_SsoSettingsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SsoProvider_SsoSettingsEventsProcess

	public partial class SsoProvider_SsoSettingsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SsoProviderEventsProcess

	/// <exclude/>
	public class SsoProviderEventsProcess : SsoProvider_SsoSettingsEventsProcess
	{

		public SsoProviderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

