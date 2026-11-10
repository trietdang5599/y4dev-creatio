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

	#region Class: SsoSamlProviderSchema

	/// <exclude/>
	[IsVirtual]
	public class SsoSamlProviderSchema : Terrasoft.Configuration.SsoSamlSettingsSchema
	{

		#region Constructors: Public

		public SsoSamlProviderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SsoSamlProviderSchema(SsoSamlProviderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SsoSamlProviderSchema(SsoSamlProviderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("49c301ee-4a8e-46b4-a98e-6280360204d9");
			RealUId = new Guid("49c301ee-4a8e-46b4-a98e-6280360204d9");
			Name = "SsoSamlProvider";
			ParentSchemaUId = new Guid("9e12ce5e-b1b1-487f-9642-e37c63790b94");
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

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateNameColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("c916047e-a3f0-def1-0c66-6fe976b05a24")) == null) {
				Columns.Add(CreateSsoSettingsTemplateColumn());
			}
			if (Columns.FindByUId(new Guid("c83382b6-c313-0352-0e23-571b2a21b569")) == null) {
				Columns.Add(CreateCodeColumn());
			}
			if (Columns.FindByUId(new Guid("bdc7dd16-c08d-600b-6d04-c3ca3b8743aa")) == null) {
				Columns.Add(CreateIsDefaultColumn());
			}
			if (Columns.FindByUId(new Guid("1266ee68-5c3b-2479-2cc4-6591e6ab06b1")) == null) {
				Columns.Add(CreateUserTypeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSsoSettingsTemplateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("c916047e-a3f0-def1-0c66-6fe976b05a24"),
				Name = @"SsoSettingsTemplate",
				ReferenceSchemaUId = new Guid("a1771533-7e22-4f39-b869-e19d2c54f911"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("49c301ee-4a8e-46b4-a98e-6280360204d9"),
				ModifiedInSchemaUId = new Guid("49c301ee-4a8e-46b4-a98e-6280360204d9"),
				CreatedInPackageId = new Guid("e5aa7639-5b66-4d72-9308-0563d89b2353"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("e62337f1-8cc9-d243-8944-175485b6b5d1"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("49c301ee-4a8e-46b4-a98e-6280360204d9"),
				ModifiedInSchemaUId = new Guid("49c301ee-4a8e-46b4-a98e-6280360204d9"),
				CreatedInPackageId = new Guid("e5aa7639-5b66-4d72-9308-0563d89b2353")
			};
		}

		protected virtual EntitySchemaColumn CreateCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("c83382b6-c313-0352-0e23-571b2a21b569"),
				Name = @"Code",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("49c301ee-4a8e-46b4-a98e-6280360204d9"),
				ModifiedInSchemaUId = new Guid("49c301ee-4a8e-46b4-a98e-6280360204d9"),
				CreatedInPackageId = new Guid("e5aa7639-5b66-4d72-9308-0563d89b2353"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Sequence,
					SequencePrefix = "saml_",
					SequenceNumberOfChars = 1
				}
			};
		}

		protected virtual EntitySchemaColumn CreateIsDefaultColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("bdc7dd16-c08d-600b-6d04-c3ca3b8743aa"),
				Name = @"IsDefault",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("49c301ee-4a8e-46b4-a98e-6280360204d9"),
				ModifiedInSchemaUId = new Guid("49c301ee-4a8e-46b4-a98e-6280360204d9"),
				CreatedInPackageId = new Guid("3883e66b-3a55-490c-b61a-fd048c6542f1"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"True"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateUserTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("1266ee68-5c3b-2479-2cc4-6591e6ab06b1"),
				Name = @"UserType",
				ReferenceSchemaUId = new Guid("c1e35112-a039-4bf4-94a0-1afce4211706"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("49c301ee-4a8e-46b4-a98e-6280360204d9"),
				ModifiedInSchemaUId = new Guid("49c301ee-4a8e-46b4-a98e-6280360204d9"),
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

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SsoSamlProvider(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SsoSamlProvider_SsoSettingsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SsoSamlProviderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SsoSamlProviderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("49c301ee-4a8e-46b4-a98e-6280360204d9"));
		}

		#endregion

	}

	#endregion

	#region Class: SsoSamlProvider

	/// <summary>
	/// SAML provider (virtual).
	/// </summary>
	/// <remarks>
	/// SSO SAML provider (virtual).
	/// </remarks>
	public class SsoSamlProvider : Terrasoft.Configuration.SsoSamlSettings
	{

		#region Constructors: Public

		public SsoSamlProvider(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SsoSamlProvider";
		}

		public SsoSamlProvider(SsoSamlProvider source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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

		/// <summary>
		/// Display name.
		/// </summary>
		/// <remarks>
		/// Display name.
		/// </remarks>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
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

		/// <summary>
		/// Default Provider.
		/// </summary>
		public bool IsDefault {
			get {
				return GetTypedColumnValue<bool>("IsDefault");
			}
			set {
				SetColumnValue("IsDefault", value);
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
			var process = new SsoSamlProvider_SsoSettingsEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SsoSamlProviderDeleted", e);
			Deleting += (s, e) => ThrowEvent("SsoSamlProviderDeleting", e);
			Inserted += (s, e) => ThrowEvent("SsoSamlProviderInserted", e);
			Inserting += (s, e) => ThrowEvent("SsoSamlProviderInserting", e);
			Saved += (s, e) => ThrowEvent("SsoSamlProviderSaved", e);
			Saving += (s, e) => ThrowEvent("SsoSamlProviderSaving", e);
			Validating += (s, e) => ThrowEvent("SsoSamlProviderValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SsoSamlProvider(this);
		}

		#endregion

	}

	#endregion

	#region Class: SsoSamlProvider_SsoSettingsEventsProcess

	/// <exclude/>
	public partial class SsoSamlProvider_SsoSettingsEventsProcess<TEntity> : Terrasoft.Configuration.SsoSamlSettings_SsoSettingsEventsProcess<TEntity> where TEntity : SsoSamlProvider
	{

		public SsoSamlProvider_SsoSettingsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SsoSamlProvider_SsoSettingsEventsProcess";
			SchemaUId = new Guid("49c301ee-4a8e-46b4-a98e-6280360204d9");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("49c301ee-4a8e-46b4-a98e-6280360204d9");
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

	#region Class: SsoSamlProvider_SsoSettingsEventsProcess

	/// <exclude/>
	public class SsoSamlProvider_SsoSettingsEventsProcess : SsoSamlProvider_SsoSettingsEventsProcess<SsoSamlProvider>
	{

		public SsoSamlProvider_SsoSettingsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SsoSamlProvider_SsoSettingsEventsProcess

	public partial class SsoSamlProvider_SsoSettingsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SsoSamlProviderEventsProcess

	/// <exclude/>
	public class SsoSamlProviderEventsProcess : SsoSamlProvider_SsoSettingsEventsProcess
	{

		public SsoSamlProviderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

