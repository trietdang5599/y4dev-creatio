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

	#region Class: OAuthClientAppSchema

	/// <exclude/>
	public class OAuthClientAppSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public OAuthClientAppSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OAuthClientAppSchema(OAuthClientAppSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OAuthClientAppSchema(OAuthClientAppSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed");
			RealUId = new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed");
			Name = "OAuthClientApp";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("2e618fe0-496b-4dc6-9b5c-1f29508fde14");
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
			if (Columns.FindByUId(new Guid("16220101-22c4-40ca-a6c9-8c3c1afa75a1")) == null) {
				Columns.Add(CreateClientIdColumn());
			}
			if (Columns.FindByUId(new Guid("701b3c29-37f1-4d60-9361-c29bb15c25cb")) == null) {
				Columns.Add(CreateClientSecretColumn());
			}
			if (Columns.FindByUId(new Guid("a5c9087d-a8de-464e-9375-9aec4759eb05")) == null) {
				Columns.Add(CreateRedirectUrlColumn());
			}
			if (Columns.FindByUId(new Guid("9c9cd4e6-da72-49e5-96b2-b9c9d6450492")) == null) {
				Columns.Add(CreateApplicationUrlColumn());
			}
			if (Columns.FindByUId(new Guid("eea83bb7-ff41-4c06-a99e-c9b334f7e91d")) == null) {
				Columns.Add(CreateIsActiveColumn());
			}
			if (Columns.FindByUId(new Guid("c26abcd2-3719-48c1-856a-f9d28c8bfb57")) == null) {
				Columns.Add(CreateSystemUserColumn());
			}
			if (Columns.FindByUId(new Guid("5dad3c79-ebcd-40cd-ad94-b51ec88bd452")) == null) {
				Columns.Add(CreateDescriptionColumn());
			}
			if (Columns.FindByUId(new Guid("6573758c-5c7f-d7cd-50a1-68d1cdafd87f")) == null) {
				Columns.Add(CreateGrantTypeColumn());
			}
			if (Columns.FindByUId(new Guid("10586996-ffaf-6fc8-3170-847e98fbee12")) == null) {
				Columns.Add(CreateLogoColumn());
			}
			if (Columns.FindByUId(new Guid("17f10d28-e75e-c968-ab1d-020d5dc33dda")) == null) {
				Columns.Add(CreateAllowPlainTextPkceColumn());
			}
			if (Columns.FindByUId(new Guid("62488ad8-d0b7-db14-6f87-95f8106efacf")) == null) {
				Columns.Add(CreateRequirePKCEColumn());
			}
			if (Columns.FindByUId(new Guid("39a3c404-7efe-8989-dbf6-455cd66a0249")) == null) {
				Columns.Add(CreateIsPublicColumn());
			}
			if (Columns.FindByUId(new Guid("89cc97fd-1bee-4430-bad6-6c52494efc68")) == null) {
				Columns.Add(CreateConsentModeColumn());
			}
			if (Columns.FindByUId(new Guid("db76db0f-a0b2-62b6-51ab-94f3e312d1bd")) == null) {
				Columns.Add(CreateStatusColumn());
			}
			if (Columns.FindByUId(new Guid("b8e4a2c1-3f6d-4e8a-9c2b-1d5e7f0a9b34")) == null) {
				Columns.Add(CreateGenerateClientIdColumn());
			}
			if (Columns.FindByUId(new Guid("4f6c1a2e-9d3b-4c7a-8e5f-1a2b3c4d5e60")) == null) {
				Columns.Add(CreateAccessTokenLifetimeColumn());
			}
			if (Columns.FindByUId(new Guid("5a7d2b3f-0e4c-4d8b-9f60-2b3c4d5e6f71")) == null) {
				Columns.Add(CreateSlidingRefreshTokenLifetimeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("a38174ae-0e3e-4c37-8630-4f88fac36c0c"),
				Name = @"Name",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed"),
				ModifiedInSchemaUId = new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed"),
				CreatedInPackageId = new Guid("2e618fe0-496b-4dc6-9b5c-1f29508fde14")
			};
		}

		protected virtual EntitySchemaColumn CreateClientIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("16220101-22c4-40ca-a6c9-8c3c1afa75a1"),
				Name = @"ClientId",
				CreatedInSchemaUId = new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed"),
				ModifiedInSchemaUId = new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed"),
				CreatedInPackageId = new Guid("2e618fe0-496b-4dc6-9b5c-1f29508fde14")
			};
		}

		protected virtual EntitySchemaColumn CreateClientSecretColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("SecureText")) {
				UId = new Guid("701b3c29-37f1-4d60-9361-c29bb15c25cb"),
				Name = @"ClientSecret",
				CreatedInSchemaUId = new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed"),
				ModifiedInSchemaUId = new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed"),
				CreatedInPackageId = new Guid("2e618fe0-496b-4dc6-9b5c-1f29508fde14")
			};
		}

		protected virtual EntitySchemaColumn CreateRedirectUrlColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("a5c9087d-a8de-464e-9375-9aec4759eb05"),
				Name = @"RedirectUrl",
				CreatedInSchemaUId = new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed"),
				ModifiedInSchemaUId = new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed"),
				CreatedInPackageId = new Guid("2e618fe0-496b-4dc6-9b5c-1f29508fde14")
			};
		}

		protected virtual EntitySchemaColumn CreateApplicationUrlColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("WebText")) {
				UId = new Guid("9c9cd4e6-da72-49e5-96b2-b9c9d6450492"),
				Name = @"ApplicationUrl",
				CreatedInSchemaUId = new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed"),
				ModifiedInSchemaUId = new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed"),
				CreatedInPackageId = new Guid("2e618fe0-496b-4dc6-9b5c-1f29508fde14")
			};
		}

		protected virtual EntitySchemaColumn CreateIsActiveColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("eea83bb7-ff41-4c06-a99e-c9b334f7e91d"),
				Name = @"IsActive",
				CreatedInSchemaUId = new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed"),
				ModifiedInSchemaUId = new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed"),
				CreatedInPackageId = new Guid("2e618fe0-496b-4dc6-9b5c-1f29508fde14"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"True"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateSystemUserColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("c26abcd2-3719-48c1-856a-f9d28c8bfb57"),
				Name = @"SystemUser",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed"),
				ModifiedInSchemaUId = new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed"),
				CreatedInPackageId = new Guid("2e618fe0-496b-4dc6-9b5c-1f29508fde14"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateDescriptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("5dad3c79-ebcd-40cd-ad94-b51ec88bd452"),
				Name = @"Description",
				CreatedInSchemaUId = new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed"),
				ModifiedInSchemaUId = new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed"),
				CreatedInPackageId = new Guid("49af2168-effb-4b7f-bce2-28e45d430d96")
			};
		}

		protected virtual EntitySchemaColumn CreateGrantTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("6573758c-5c7f-d7cd-50a1-68d1cdafd87f"),
				Name = @"GrantType",
				ReferenceSchemaUId = new Guid("97bd1aa6-6685-4335-8bf1-4d6a0a78149b"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed"),
				ModifiedInSchemaUId = new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed"),
				CreatedInPackageId = new Guid("49af2168-effb-4b7f-bce2-28e45d430d96"),
				IsSimpleLookup = true,
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"73f0cc6d-0634-4db3-96ab-0cb549958f91"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateLogoColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ImageLookup")) {
				UId = new Guid("10586996-ffaf-6fc8-3170-847e98fbee12"),
				Name = @"Logo",
				ReferenceSchemaUId = new Guid("93986bfe-2dbd-46bc-9bf9-d03dfefbf3b8"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed"),
				ModifiedInSchemaUId = new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed"),
				CreatedInPackageId = new Guid("49af2168-effb-4b7f-bce2-28e45d430d96"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateAllowPlainTextPkceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("17f10d28-e75e-c968-ab1d-020d5dc33dda"),
				Name = @"AllowPlainTextPkce",
				CreatedInSchemaUId = new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed"),
				ModifiedInSchemaUId = new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed"),
				CreatedInPackageId = new Guid("49af2168-effb-4b7f-bce2-28e45d430d96"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"False"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateRequirePKCEColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("62488ad8-d0b7-db14-6f87-95f8106efacf"),
				Name = @"RequirePKCE",
				CreatedInSchemaUId = new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed"),
				ModifiedInSchemaUId = new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed"),
				CreatedInPackageId = new Guid("49af2168-effb-4b7f-bce2-28e45d430d96"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"False"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateIsPublicColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("39a3c404-7efe-8989-dbf6-455cd66a0249"),
				Name = @"IsPublic",
				CreatedInSchemaUId = new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed"),
				ModifiedInSchemaUId = new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed"),
				CreatedInPackageId = new Guid("49af2168-effb-4b7f-bce2-28e45d430d96"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"False"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateConsentModeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("89cc97fd-1bee-4430-bad6-6c52494efc68"),
				Name = @"ConsentMode",
				ReferenceSchemaUId = new Guid("61ec9bc0-e9f4-41a1-9a2f-fd7aefb900e8"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed"),
				ModifiedInSchemaUId = new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed"),
				CreatedInPackageId = new Guid("49af2168-effb-4b7f-bce2-28e45d430d96"),
				IsSimpleLookup = true,
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"0fbae234-131f-4a20-b57b-fd0acb853cb1"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("db76db0f-a0b2-62b6-51ab-94f3e312d1bd"),
				Name = @"Status",
				ReferenceSchemaUId = new Guid("4088b7c2-278a-435f-8231-f44083af7875"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed"),
				ModifiedInSchemaUId = new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed"),
				CreatedInPackageId = new Guid("24a107aa-9a97-48af-9bdd-eac299d821dd"),
				IsSimpleLookup = true,
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"87f2cf13-71e7-4f69-8dd8-19d3c4d2cd69"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateGenerateClientIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("b8e4a2c1-3f6d-4e8a-9c2b-1d5e7f0a9b34"),
				Name = @"GenerateClientId",
				CreatedInSchemaUId = new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed"),
				ModifiedInSchemaUId = new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed"),
				CreatedInPackageId = new Guid("49af2168-effb-4b7f-bce2-28e45d430d96"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"False"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateAccessTokenLifetimeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("4f6c1a2e-9d3b-4c7a-8e5f-1a2b3c4d5e60"),
				Name = @"AccessTokenLifetime",
				CreatedInSchemaUId = new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed"),
				ModifiedInSchemaUId = new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed"),
				CreatedInPackageId = new Guid("49af2168-effb-4b7f-bce2-28e45d430d96")
			};
		}

		protected virtual EntitySchemaColumn CreateSlidingRefreshTokenLifetimeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("5a7d2b3f-0e4c-4d8b-9f60-2b3c4d5e6f71"),
				Name = @"SlidingRefreshTokenLifetime",
				CreatedInSchemaUId = new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed"),
				ModifiedInSchemaUId = new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed"),
				CreatedInPackageId = new Guid("49af2168-effb-4b7f-bce2-28e45d430d96")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new OAuthClientApp(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OAuthClientApp_OAuth20EventsProcess(userConnection);
		}

		public override object Clone() {
			return new OAuthClientAppSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OAuthClientAppSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed"));
		}

		#endregion

	}

	#endregion

	#region Class: OAuthClientApp

	/// <summary>
	/// OAuth client application.
	/// </summary>
	public class OAuthClientApp : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public OAuthClientApp(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OAuthClientApp";
		}

		public OAuthClientApp(OAuthClientApp source)
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
		/// Client Id.
		/// </summary>
		public string ClientId {
			get {
				return GetTypedColumnValue<string>("ClientId");
			}
			set {
				SetColumnValue("ClientId", value);
			}
		}

		/// <summary>
		/// Client secret.
		/// </summary>
		public string ClientSecret {
			get {
				return GetTypedColumnValue<string>("ClientSecret");
			}
			set {
				SetColumnValue("ClientSecret", value);
			}
		}

		/// <summary>
		/// Redirect URL.
		/// </summary>
		public string RedirectUrl {
			get {
				return GetTypedColumnValue<string>("RedirectUrl");
			}
			set {
				SetColumnValue("RedirectUrl", value);
			}
		}

		/// <summary>
		/// Application URL.
		/// </summary>
		public string ApplicationUrl {
			get {
				return GetTypedColumnValue<string>("ApplicationUrl");
			}
			set {
				SetColumnValue("ApplicationUrl", value);
			}
		}

		/// <summary>
		/// Integration is active.
		/// </summary>
		public bool IsActive {
			get {
				return GetTypedColumnValue<bool>("IsActive");
			}
			set {
				SetColumnValue("IsActive", value);
			}
		}

		/// <exclude/>
		public Guid SystemUserId {
			get {
				return GetTypedColumnValue<Guid>("SystemUserId");
			}
			set {
				SetColumnValue("SystemUserId", value);
				_systemUser = null;
			}
		}

		/// <exclude/>
		public string SystemUserName {
			get {
				return GetTypedColumnValue<string>("SystemUserName");
			}
			set {
				SetColumnValue("SystemUserName", value);
				if (_systemUser != null) {
					_systemUser.Name = value;
				}
			}
		}

		private SysAdminUnit _systemUser;
		/// <summary>
		/// System user.
		/// </summary>
		public SysAdminUnit SystemUser {
			get {
				return _systemUser ??
					(_systemUser = LookupColumnEntities.GetEntity("SystemUser") as SysAdminUnit);
			}
		}

		/// <summary>
		/// Description.
		/// </summary>
		public string Description {
			get {
				return GetTypedColumnValue<string>("Description");
			}
			set {
				SetColumnValue("Description", value);
			}
		}

		/// <exclude/>
		public Guid GrantTypeId {
			get {
				return GetTypedColumnValue<Guid>("GrantTypeId");
			}
			set {
				SetColumnValue("GrantTypeId", value);
				_grantType = null;
			}
		}

		/// <exclude/>
		public string GrantTypeName {
			get {
				return GetTypedColumnValue<string>("GrantTypeName");
			}
			set {
				SetColumnValue("GrantTypeName", value);
				if (_grantType != null) {
					_grantType.Name = value;
				}
			}
		}

		private OAuthGrantType _grantType;
		/// <summary>
		/// Grant type.
		/// </summary>
		public OAuthGrantType GrantType {
			get {
				return _grantType ??
					(_grantType = LookupColumnEntities.GetEntity("GrantType") as OAuthGrantType);
			}
		}

		/// <exclude/>
		public Guid LogoId {
			get {
				return GetTypedColumnValue<Guid>("LogoId");
			}
			set {
				SetColumnValue("LogoId", value);
				_logo = null;
			}
		}

		/// <exclude/>
		public string LogoName {
			get {
				return GetTypedColumnValue<string>("LogoName");
			}
			set {
				SetColumnValue("LogoName", value);
				if (_logo != null) {
					_logo.Name = value;
				}
			}
		}

		private SysImage _logo;
		/// <summary>
		/// Logo.
		/// </summary>
		public SysImage Logo {
			get {
				return _logo ??
					(_logo = LookupColumnEntities.GetEntity("Logo") as SysImage);
			}
		}

		/// <summary>
		/// Allow plain text PKCE.
		/// </summary>
		/// <remarks>
		/// Specifies whether a proof key can be sent using plain method.
		/// </remarks>
		public bool AllowPlainTextPkce {
			get {
				return GetTypedColumnValue<bool>("AllowPlainTextPkce");
			}
			set {
				SetColumnValue("AllowPlainTextPkce", value);
			}
		}

		/// <summary>
		/// Enforce PKCE usage.
		/// </summary>
		/// <remarks>
		/// Specifies whether a proof key is required for authorization code based token requests.
		/// </remarks>
		public bool RequirePKCE {
			get {
				return GetTypedColumnValue<bool>("RequirePKCE");
			}
			set {
				SetColumnValue("RequirePKCE", value);
			}
		}

		/// <summary>
		/// Public client.
		/// </summary>
		/// <remarks>
		/// If set to false, no client secret is needed to request tokens at the token endpoint.
		/// </remarks>
		public bool IsPublic {
			get {
				return GetTypedColumnValue<bool>("IsPublic");
			}
			set {
				SetColumnValue("IsPublic", value);
			}
		}

		/// <exclude/>
		public Guid ConsentModeId {
			get {
				return GetTypedColumnValue<Guid>("ConsentModeId");
			}
			set {
				SetColumnValue("ConsentModeId", value);
				_consentMode = null;
			}
		}

		/// <exclude/>
		public string ConsentModeName {
			get {
				return GetTypedColumnValue<string>("ConsentModeName");
			}
			set {
				SetColumnValue("ConsentModeName", value);
				if (_consentMode != null) {
					_consentMode.Name = value;
				}
			}
		}

		private OAuthConsentMode _consentMode;
		/// <summary>
		/// Consent mode.
		/// </summary>
		/// <remarks>
		/// Controls the consent screen during the Authorization Code flow: ask consent on every connection, remember consent until access is revoked, or bypass consent for trusted applications.
		/// </remarks>
		public OAuthConsentMode ConsentMode {
			get {
				return _consentMode ??
					(_consentMode = LookupColumnEntities.GetEntity("ConsentMode") as OAuthConsentMode);
			}
		}

		/// <exclude/>
		public Guid StatusId {
			get {
				return GetTypedColumnValue<Guid>("StatusId");
			}
			set {
				SetColumnValue("StatusId", value);
				_status = null;
			}
		}

		/// <exclude/>
		public string StatusName {
			get {
				return GetTypedColumnValue<string>("StatusName");
			}
			set {
				SetColumnValue("StatusName", value);
				if (_status != null) {
					_status.Name = value;
				}
			}
		}

		private OAuthClientAppStatus _status;
		public OAuthClientAppStatus Status {
			get {
				return _status ??
					(_status = LookupColumnEntities.GetEntity("Status") as OAuthClientAppStatus);
			}
		}

		public bool GenerateClientId {
			get {
				return GetTypedColumnValue<bool>("GenerateClientId");
			}
			set {
				SetColumnValue("GenerateClientId", value);
			}
		}

		public int AccessTokenLifetime {
			get {
				return GetTypedColumnValue<int>("AccessTokenLifetime");
			}
			set {
				SetColumnValue("AccessTokenLifetime", value);
			}
		}

		public int SlidingRefreshTokenLifetime {
			get {
				return GetTypedColumnValue<int>("SlidingRefreshTokenLifetime");
			}
			set {
				SetColumnValue("SlidingRefreshTokenLifetime", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OAuthClientApp_OAuth20EventsProcess(UserConnection);
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
			return new OAuthClientApp(this);
		}

		#endregion

	}

	#endregion

	#region Class: OAuthClientApp_OAuth20EventsProcess

	/// <exclude/>
	public partial class OAuthClientApp_OAuth20EventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : OAuthClientApp
	{

		public OAuthClientApp_OAuth20EventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OAuthClientApp_OAuth20EventsProcess";
			SchemaUId = new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed");
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

	#region Class: OAuthClientApp_OAuth20EventsProcess

	/// <exclude/>
	public class OAuthClientApp_OAuth20EventsProcess : OAuthClientApp_OAuth20EventsProcess<OAuthClientApp>
	{

		public OAuthClientApp_OAuth20EventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OAuthClientApp_OAuth20EventsProcess

	public partial class OAuthClientApp_OAuth20EventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: OAuthClientAppEventsProcess

	/// <exclude/>
	public class OAuthClientAppEventsProcess : OAuthClientApp_OAuth20EventsProcess
	{

		public OAuthClientAppEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

