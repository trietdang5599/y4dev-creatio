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

	#region Class: SsoIdentityProviderSchema

	/// <exclude/>
	public class SsoIdentityProviderSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SsoIdentityProviderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SsoIdentityProviderSchema(SsoIdentityProviderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SsoIdentityProviderSchema(SsoIdentityProviderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateUniqueNameColumnIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = true
			};
			index.UId = new Guid("527ba787-d1dd-476c-82a3-70f69cbfc445");
			index.Name = "UniqueNameColumn";
			index.CreatedInSchemaUId = new Guid("b335809f-b168-4952-ac9c-6aa10c05e897");
			index.ModifiedInSchemaUId = new Guid("b335809f-b168-4952-ac9c-6aa10c05e897");
			index.CreatedInPackageId = new Guid("0c0cefaa-76d3-43d9-b05f-e48aa147439f");
			EntitySchemaIndexColumn nameIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("7673eeac-d9eb-c0f1-8851-ca1fccb24c66"),
				ColumnUId = new Guid("10939200-1444-99ae-c147-354d05c27f81"),
				CreatedInSchemaUId = new Guid("b335809f-b168-4952-ac9c-6aa10c05e897"),
				ModifiedInSchemaUId = new Guid("b335809f-b168-4952-ac9c-6aa10c05e897"),
				CreatedInPackageId = new Guid("0c0cefaa-76d3-43d9-b05f-e48aa147439f"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(nameIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b335809f-b168-4952-ac9c-6aa10c05e897");
			RealUId = new Guid("b335809f-b168-4952-ac9c-6aa10c05e897");
			Name = "SsoIdentityProvider";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("215e526d-f587-4ae6-bb01-1466a5b04094");
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
			PrimaryDisplayColumn = CreateDisplayNameColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("10939200-1444-99ae-c147-354d05c27f81")) == null) {
				Columns.Add(CreateNameColumn());
			}
			if (Columns.FindByUId(new Guid("2d936135-27af-0727-65db-1a2f892278ee")) == null) {
				Columns.Add(CreateSingleLogoutServiceUrlColumn());
			}
			if (Columns.FindByUId(new Guid("3c1490b8-18c2-6bb7-c313-d7b942bfdb6c")) == null) {
				Columns.Add(CreateSingleSignOnServiceUrlColumn());
			}
			if (Columns.FindByUId(new Guid("b58447d6-d500-35c8-4ca9-9ef47a2ed413")) == null) {
				Columns.Add(CreateAdditionalParamsColumn());
			}
			if (Columns.FindByUId(new Guid("f26d9f2f-568c-fe52-5f0a-0d23819fb737")) == null) {
				Columns.Add(CreatePartnerCertificateThumbprintColumn());
			}
			if (Columns.FindByUId(new Guid("756c368f-a061-3329-82fa-3289282e4519")) == null) {
				Columns.Add(CreateTypeColumn());
			}
			if (Columns.FindByUId(new Guid("5cfbbf1e-4929-fbed-fa1e-6d8cb3c800a7")) == null) {
				Columns.Add(CreateUserTypeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("10939200-1444-99ae-c147-354d05c27f81"),
				Name = @"Name",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("b335809f-b168-4952-ac9c-6aa10c05e897"),
				ModifiedInSchemaUId = new Guid("b335809f-b168-4952-ac9c-6aa10c05e897"),
				CreatedInPackageId = new Guid("215e526d-f587-4ae6-bb01-1466a5b04094")
			};
		}

		protected virtual EntitySchemaColumn CreateDisplayNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("a00ee82e-8681-942e-b7ab-8961df777bfb"),
				Name = @"DisplayName",
				CreatedInSchemaUId = new Guid("b335809f-b168-4952-ac9c-6aa10c05e897"),
				ModifiedInSchemaUId = new Guid("b335809f-b168-4952-ac9c-6aa10c05e897"),
				CreatedInPackageId = new Guid("215e526d-f587-4ae6-bb01-1466a5b04094")
			};
		}

		protected virtual EntitySchemaColumn CreateSingleLogoutServiceUrlColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("2d936135-27af-0727-65db-1a2f892278ee"),
				Name = @"SingleLogoutServiceUrl",
				CreatedInSchemaUId = new Guid("b335809f-b168-4952-ac9c-6aa10c05e897"),
				ModifiedInSchemaUId = new Guid("b335809f-b168-4952-ac9c-6aa10c05e897"),
				CreatedInPackageId = new Guid("215e526d-f587-4ae6-bb01-1466a5b04094")
			};
		}

		protected virtual EntitySchemaColumn CreateSingleSignOnServiceUrlColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("3c1490b8-18c2-6bb7-c313-d7b942bfdb6c"),
				Name = @"SingleSignOnServiceUrl",
				CreatedInSchemaUId = new Guid("b335809f-b168-4952-ac9c-6aa10c05e897"),
				ModifiedInSchemaUId = new Guid("b335809f-b168-4952-ac9c-6aa10c05e897"),
				CreatedInPackageId = new Guid("215e526d-f587-4ae6-bb01-1466a5b04094")
			};
		}

		protected virtual EntitySchemaColumn CreateAdditionalParamsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("b58447d6-d500-35c8-4ca9-9ef47a2ed413"),
				Name = @"AdditionalParams",
				CreatedInSchemaUId = new Guid("b335809f-b168-4952-ac9c-6aa10c05e897"),
				ModifiedInSchemaUId = new Guid("b335809f-b168-4952-ac9c-6aa10c05e897"),
				CreatedInPackageId = new Guid("0c0cefaa-76d3-43d9-b05f-e48aa147439f")
			};
		}

		protected virtual EntitySchemaColumn CreatePartnerCertificateThumbprintColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("f26d9f2f-568c-fe52-5f0a-0d23819fb737"),
				Name = @"PartnerCertificateThumbprint",
				CreatedInSchemaUId = new Guid("b335809f-b168-4952-ac9c-6aa10c05e897"),
				ModifiedInSchemaUId = new Guid("b335809f-b168-4952-ac9c-6aa10c05e897"),
				CreatedInPackageId = new Guid("0c0cefaa-76d3-43d9-b05f-e48aa147439f")
			};
		}

		protected virtual EntitySchemaColumn CreateTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("756c368f-a061-3329-82fa-3289282e4519"),
				Name = @"Type",
				ReferenceSchemaUId = new Guid("614855f4-259f-41de-8a81-a98f27c12126"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("b335809f-b168-4952-ac9c-6aa10c05e897"),
				ModifiedInSchemaUId = new Guid("b335809f-b168-4952-ac9c-6aa10c05e897"),
				CreatedInPackageId = new Guid("0c0cefaa-76d3-43d9-b05f-e48aa147439f")
			};
		}

		protected virtual EntitySchemaColumn CreateUserTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("5cfbbf1e-4929-fbed-fa1e-6d8cb3c800a7"),
				Name = @"UserType",
				ReferenceSchemaUId = new Guid("c1e35112-a039-4bf4-94a0-1afce4211706"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("b335809f-b168-4952-ac9c-6aa10c05e897"),
				ModifiedInSchemaUId = new Guid("b335809f-b168-4952-ac9c-6aa10c05e897"),
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
			Indexes.Add(CreateUniqueNameColumnIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SsoIdentityProvider(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SsoIdentityProvider_SsoSettingsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SsoIdentityProviderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SsoIdentityProviderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b335809f-b168-4952-ac9c-6aa10c05e897"));
		}

		#endregion

	}

	#endregion

	#region Class: SsoIdentityProvider

	/// <summary>
	/// SSO identity provider.
	/// </summary>
	public class SsoIdentityProvider : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SsoIdentityProvider(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SsoIdentityProvider";
		}

		public SsoIdentityProvider(SsoIdentityProvider source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Entity ID.
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
		/// Display name.
		/// </summary>
		public string DisplayName {
			get {
				return GetTypedColumnValue<string>("DisplayName");
			}
			set {
				SetColumnValue("DisplayName", value);
			}
		}

		/// <summary>
		/// Single Logout URL.
		/// </summary>
		public string SingleLogoutServiceUrl {
			get {
				return GetTypedColumnValue<string>("SingleLogoutServiceUrl");
			}
			set {
				SetColumnValue("SingleLogoutServiceUrl", value);
			}
		}

		/// <summary>
		/// Single Sign On URL.
		/// </summary>
		public string SingleSignOnServiceUrl {
			get {
				return GetTypedColumnValue<string>("SingleSignOnServiceUrl");
			}
			set {
				SetColumnValue("SingleSignOnServiceUrl", value);
			}
		}

		/// <summary>
		/// Additional parameters.
		/// </summary>
		public string AdditionalParams {
			get {
				return GetTypedColumnValue<string>("AdditionalParams");
			}
			set {
				SetColumnValue("AdditionalParams", value);
			}
		}

		/// <summary>
		/// Partner certificate thumbprint.
		/// </summary>
		public string PartnerCertificateThumbprint {
			get {
				return GetTypedColumnValue<string>("PartnerCertificateThumbprint");
			}
			set {
				SetColumnValue("PartnerCertificateThumbprint", value);
			}
		}

		/// <exclude/>
		public Guid TypeId {
			get {
				return GetTypedColumnValue<Guid>("TypeId");
			}
			set {
				SetColumnValue("TypeId", value);
				_type = null;
			}
		}

		/// <exclude/>
		public string TypeName {
			get {
				return GetTypedColumnValue<string>("TypeName");
			}
			set {
				SetColumnValue("TypeName", value);
				if (_type != null) {
					_type.Name = value;
				}
			}
		}

		private SsoIdentityType _type;
		/// <summary>
		/// Type.
		/// </summary>
		public SsoIdentityType Type {
			get {
				return _type ??
					(_type = LookupColumnEntities.GetEntity("Type") as SsoIdentityType);
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
			var process = new SsoIdentityProvider_SsoSettingsEventsProcess(UserConnection);
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
			return new SsoIdentityProvider(this);
		}

		#endregion

	}

	#endregion

	#region Class: SsoIdentityProvider_SsoSettingsEventsProcess

	/// <exclude/>
	public partial class SsoIdentityProvider_SsoSettingsEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : SsoIdentityProvider
	{

		public SsoIdentityProvider_SsoSettingsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SsoIdentityProvider_SsoSettingsEventsProcess";
			SchemaUId = new Guid("b335809f-b168-4952-ac9c-6aa10c05e897");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("b335809f-b168-4952-ac9c-6aa10c05e897");
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

	#region Class: SsoIdentityProvider_SsoSettingsEventsProcess

	/// <exclude/>
	public class SsoIdentityProvider_SsoSettingsEventsProcess : SsoIdentityProvider_SsoSettingsEventsProcess<SsoIdentityProvider>
	{

		public SsoIdentityProvider_SsoSettingsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SsoIdentityProvider_SsoSettingsEventsProcess

	public partial class SsoIdentityProvider_SsoSettingsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SsoIdentityProviderEventsProcess

	/// <exclude/>
	public class SsoIdentityProviderEventsProcess : SsoIdentityProvider_SsoSettingsEventsProcess
	{

		public SsoIdentityProviderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

