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

	#region Class: SsoServiceProviderSchema

	/// <exclude/>
	public class SsoServiceProviderSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SsoServiceProviderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SsoServiceProviderSchema(SsoServiceProviderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SsoServiceProviderSchema(SsoServiceProviderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateUniqueBoolColumnIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = true
			};
			index.UId = new Guid("144150df-3e67-4930-86ee-b2218f312ce6");
			index.Name = "UniqueBoolColumn";
			index.CreatedInSchemaUId = new Guid("53edc668-0d2f-492a-9d23-012e04ad8786");
			index.ModifiedInSchemaUId = new Guid("53edc668-0d2f-492a-9d23-012e04ad8786");
			index.CreatedInPackageId = new Guid("0c0cefaa-76d3-43d9-b05f-e48aa147439f");
			EntitySchemaIndexColumn serviceUniqueColumnIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("91f02f97-910b-96fc-8a8d-37c1c53ff831"),
				ColumnUId = new Guid("088d7e27-71a2-8263-8866-1c6f9566ee2a"),
				CreatedInSchemaUId = new Guid("53edc668-0d2f-492a-9d23-012e04ad8786"),
				ModifiedInSchemaUId = new Guid("53edc668-0d2f-492a-9d23-012e04ad8786"),
				CreatedInPackageId = new Guid("0c0cefaa-76d3-43d9-b05f-e48aa147439f"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(serviceUniqueColumnIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("53edc668-0d2f-492a-9d23-012e04ad8786");
			RealUId = new Guid("53edc668-0d2f-492a-9d23-012e04ad8786");
			Name = "SsoServiceProvider";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("0c0cefaa-76d3-43d9-b05f-e48aa147439f");
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
			if (Columns.FindByUId(new Guid("6aed5469-304a-5418-29c5-29d7c1f1e533")) == null) {
				Columns.Add(CreateUseJitColumn());
			}
			if (Columns.FindByUId(new Guid("188e9396-2cf2-5092-5843-33bd154ead60")) == null) {
				Columns.Add(CreateSamlUserRoleColumn());
			}
			if (Columns.FindByUId(new Guid("fff5b6f8-26c6-0a74-b2a5-957f9cf6ccc4")) == null) {
				Columns.Add(CreateSamlUserNameColumn());
			}
			if (Columns.FindByUId(new Guid("1e9b4bc0-4fe6-8a7b-8e68-6f62af4014b4")) == null) {
				Columns.Add(CreateLocalCertificateThumbprintColumn());
			}
			if (Columns.FindByUId(new Guid("e86551a3-eec0-150a-2f9c-d7d918e2332f")) == null) {
				Columns.Add(CreateAssertionConsumerServiceUrlColumn());
			}
			if (Columns.FindByUId(new Guid("937feb82-bbe6-308b-3642-ccfc0ccc2cb6")) == null) {
				Columns.Add(CreateNameColumn());
			}
			if (Columns.FindByUId(new Guid("cdad8252-1f7d-94fe-abb4-88345cbc4667")) == null) {
				Columns.Add(CreateSsoIdentityProviderColumn());
			}
			if (Columns.FindByUId(new Guid("881e327e-b234-a01c-1dce-158bbdb87e6a")) == null) {
				Columns.Add(CreateSspUseJitColumn());
			}
			if (Columns.FindByUId(new Guid("088d7e27-71a2-8263-8866-1c6f9566ee2a")) == null) {
				Columns.Add(CreateServiceUniqueColumnColumn());
			}
			if (Columns.FindByUId(new Guid("1c123d02-c31b-3863-b6ef-d639138929e3")) == null) {
				Columns.Add(CreateSingleLogoutServiceUrlColumn());
			}
			if (Columns.FindByUId(new Guid("f7f255ef-93e5-6e13-419b-d7fc74bd634d")) == null) {
				Columns.Add(CreateUseSloColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateUseJitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("6aed5469-304a-5418-29c5-29d7c1f1e533"),
				Name = @"UseJit",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("53edc668-0d2f-492a-9d23-012e04ad8786"),
				ModifiedInSchemaUId = new Guid("53edc668-0d2f-492a-9d23-012e04ad8786"),
				CreatedInPackageId = new Guid("0c0cefaa-76d3-43d9-b05f-e48aa147439f")
			};
		}

		protected virtual EntitySchemaColumn CreateSamlUserRoleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("188e9396-2cf2-5092-5843-33bd154ead60"),
				Name = @"SamlUserRole",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("53edc668-0d2f-492a-9d23-012e04ad8786"),
				ModifiedInSchemaUId = new Guid("53edc668-0d2f-492a-9d23-012e04ad8786"),
				CreatedInPackageId = new Guid("0c0cefaa-76d3-43d9-b05f-e48aa147439f"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"role"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateSamlUserNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("fff5b6f8-26c6-0a74-b2a5-957f9cf6ccc4"),
				Name = @"SamlUserName",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("53edc668-0d2f-492a-9d23-012e04ad8786"),
				ModifiedInSchemaUId = new Guid("53edc668-0d2f-492a-9d23-012e04ad8786"),
				CreatedInPackageId = new Guid("0c0cefaa-76d3-43d9-b05f-e48aa147439f")
			};
		}

		protected virtual EntitySchemaColumn CreateLocalCertificateThumbprintColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("1e9b4bc0-4fe6-8a7b-8e68-6f62af4014b4"),
				Name = @"LocalCertificateThumbprint",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("53edc668-0d2f-492a-9d23-012e04ad8786"),
				ModifiedInSchemaUId = new Guid("53edc668-0d2f-492a-9d23-012e04ad8786"),
				CreatedInPackageId = new Guid("0c0cefaa-76d3-43d9-b05f-e48aa147439f")
			};
		}

		protected virtual EntitySchemaColumn CreateAssertionConsumerServiceUrlColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("e86551a3-eec0-150a-2f9c-d7d918e2332f"),
				Name = @"AssertionConsumerServiceUrl",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("53edc668-0d2f-492a-9d23-012e04ad8786"),
				ModifiedInSchemaUId = new Guid("53edc668-0d2f-492a-9d23-012e04ad8786"),
				CreatedInPackageId = new Guid("0c0cefaa-76d3-43d9-b05f-e48aa147439f")
			};
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("937feb82-bbe6-308b-3642-ccfc0ccc2cb6"),
				Name = @"Name",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("53edc668-0d2f-492a-9d23-012e04ad8786"),
				ModifiedInSchemaUId = new Guid("53edc668-0d2f-492a-9d23-012e04ad8786"),
				CreatedInPackageId = new Guid("0c0cefaa-76d3-43d9-b05f-e48aa147439f")
			};
		}

		protected virtual EntitySchemaColumn CreateSsoIdentityProviderColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("cdad8252-1f7d-94fe-abb4-88345cbc4667"),
				Name = @"SsoIdentityProvider",
				ReferenceSchemaUId = new Guid("b335809f-b168-4952-ac9c-6aa10c05e897"),
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("53edc668-0d2f-492a-9d23-012e04ad8786"),
				ModifiedInSchemaUId = new Guid("53edc668-0d2f-492a-9d23-012e04ad8786"),
				CreatedInPackageId = new Guid("0c0cefaa-76d3-43d9-b05f-e48aa147439f")
			};
		}

		protected virtual EntitySchemaColumn CreateSspUseJitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("881e327e-b234-a01c-1dce-158bbdb87e6a"),
				Name = @"SspUseJit",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("53edc668-0d2f-492a-9d23-012e04ad8786"),
				ModifiedInSchemaUId = new Guid("53edc668-0d2f-492a-9d23-012e04ad8786"),
				CreatedInPackageId = new Guid("215e526d-f587-4ae6-bb01-1466a5b04094")
			};
		}

		protected virtual EntitySchemaColumn CreateServiceUniqueColumnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("088d7e27-71a2-8263-8866-1c6f9566ee2a"),
				Name = @"ServiceUniqueColumn",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("53edc668-0d2f-492a-9d23-012e04ad8786"),
				ModifiedInSchemaUId = new Guid("53edc668-0d2f-492a-9d23-012e04ad8786"),
				CreatedInPackageId = new Guid("0c0cefaa-76d3-43d9-b05f-e48aa147439f"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"False"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateSingleLogoutServiceUrlColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("1c123d02-c31b-3863-b6ef-d639138929e3"),
				Name = @"SingleLogoutServiceUrl",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("53edc668-0d2f-492a-9d23-012e04ad8786"),
				ModifiedInSchemaUId = new Guid("53edc668-0d2f-492a-9d23-012e04ad8786"),
				CreatedInPackageId = new Guid("0c0cefaa-76d3-43d9-b05f-e48aa147439f")
			};
		}

		protected virtual EntitySchemaColumn CreateUseSloColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("f7f255ef-93e5-6e13-419b-d7fc74bd634d"),
				Name = @"UseSlo",
				CreatedInSchemaUId = new Guid("53edc668-0d2f-492a-9d23-012e04ad8786"),
				ModifiedInSchemaUId = new Guid("53edc668-0d2f-492a-9d23-012e04ad8786"),
				CreatedInPackageId = new Guid("6ea8ffd3-a056-4527-8ee5-0d2e2601227e")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateUniqueBoolColumnIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SsoServiceProvider(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SsoServiceProvider_SsoSettingsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SsoServiceProviderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SsoServiceProviderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("53edc668-0d2f-492a-9d23-012e04ad8786"));
		}

		#endregion

	}

	#endregion

	#region Class: SsoServiceProvider

	/// <summary>
	/// SSO service provider.
	/// </summary>
	public class SsoServiceProvider : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SsoServiceProvider(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SsoServiceProvider";
		}

		public SsoServiceProvider(SsoServiceProvider source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Create and update users data when log in (Just-In-Time Provisioning).
		/// </summary>
		public bool UseJit {
			get {
				return GetTypedColumnValue<bool>("UseJit");
			}
			set {
				SetColumnValue("UseJit", value);
			}
		}

		/// <summary>
		/// Saml user role.
		/// </summary>
		public string SamlUserRole {
			get {
				return GetTypedColumnValue<string>("SamlUserRole");
			}
			set {
				SetColumnValue("SamlUserRole", value);
			}
		}

		/// <summary>
		/// Saml user name.
		/// </summary>
		public string SamlUserName {
			get {
				return GetTypedColumnValue<string>("SamlUserName");
			}
			set {
				SetColumnValue("SamlUserName", value);
			}
		}

		/// <summary>
		/// Local certificate thumbprint.
		/// </summary>
		public string LocalCertificateThumbprint {
			get {
				return GetTypedColumnValue<string>("LocalCertificateThumbprint");
			}
			set {
				SetColumnValue("LocalCertificateThumbprint", value);
			}
		}

		/// <summary>
		/// Assertion consumer service Url.
		/// </summary>
		public string AssertionConsumerServiceUrl {
			get {
				return GetTypedColumnValue<string>("AssertionConsumerServiceUrl");
			}
			set {
				SetColumnValue("AssertionConsumerServiceUrl", value);
			}
		}

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

		/// <exclude/>
		public Guid SsoIdentityProviderId {
			get {
				return GetTypedColumnValue<Guid>("SsoIdentityProviderId");
			}
			set {
				SetColumnValue("SsoIdentityProviderId", value);
				_ssoIdentityProvider = null;
			}
		}

		/// <exclude/>
		public string SsoIdentityProviderDisplayName {
			get {
				return GetTypedColumnValue<string>("SsoIdentityProviderDisplayName");
			}
			set {
				SetColumnValue("SsoIdentityProviderDisplayName", value);
				if (_ssoIdentityProvider != null) {
					_ssoIdentityProvider.DisplayName = value;
				}
			}
		}

		private SsoIdentityProvider _ssoIdentityProvider;
		/// <summary>
		/// SSO identity provider.
		/// </summary>
		public SsoIdentityProvider SsoIdentityProvider {
			get {
				return _ssoIdentityProvider ??
					(_ssoIdentityProvider = LookupColumnEntities.GetEntity("SsoIdentityProvider") as SsoIdentityProvider);
			}
		}

		/// <summary>
		/// Use Just-in-Time Provisioning for portal users.
		/// </summary>
		public bool SspUseJit {
			get {
				return GetTypedColumnValue<bool>("SspUseJit");
			}
			set {
				SetColumnValue("SspUseJit", value);
			}
		}

		/// <summary>
		/// ServiceUniqueColumn.
		/// </summary>
		public bool ServiceUniqueColumn {
			get {
				return GetTypedColumnValue<bool>("ServiceUniqueColumn");
			}
			set {
				SetColumnValue("ServiceUniqueColumn", value);
			}
		}

		/// <summary>
		/// Single logout service Url.
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
		/// Use SLO.
		/// </summary>
		public bool UseSlo {
			get {
				return GetTypedColumnValue<bool>("UseSlo");
			}
			set {
				SetColumnValue("UseSlo", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SsoServiceProvider_SsoSettingsEventsProcess(UserConnection);
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
			return new SsoServiceProvider(this);
		}

		#endregion

	}

	#endregion

	#region Class: SsoServiceProvider_SsoSettingsEventsProcess

	/// <exclude/>
	public partial class SsoServiceProvider_SsoSettingsEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : SsoServiceProvider
	{

		public SsoServiceProvider_SsoSettingsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SsoServiceProvider_SsoSettingsEventsProcess";
			SchemaUId = new Guid("53edc668-0d2f-492a-9d23-012e04ad8786");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("53edc668-0d2f-492a-9d23-012e04ad8786");
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

	#region Class: SsoServiceProvider_SsoSettingsEventsProcess

	/// <exclude/>
	public class SsoServiceProvider_SsoSettingsEventsProcess : SsoServiceProvider_SsoSettingsEventsProcess<SsoServiceProvider>
	{

		public SsoServiceProvider_SsoSettingsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SsoServiceProvider_SsoSettingsEventsProcess

	public partial class SsoServiceProvider_SsoSettingsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SsoServiceProviderEventsProcess

	/// <exclude/>
	public class SsoServiceProviderEventsProcess : SsoServiceProvider_SsoSettingsEventsProcess
	{

		public SsoServiceProviderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

