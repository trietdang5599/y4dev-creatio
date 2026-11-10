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

	#region Class: SsoSamlSettingsSchema

	/// <exclude/>
	public class SsoSamlSettingsSchema : Terrasoft.Configuration.SsoBaseSettingsSchema
	{

		#region Constructors: Public

		public SsoSamlSettingsSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SsoSamlSettingsSchema(SsoSamlSettingsSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SsoSamlSettingsSchema(SsoSamlSettingsSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateISsoSamlSettings_SsoProviderIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = true
			};
			index.UId = new Guid("6d163856-9827-47ef-8e39-10b93f10dba6");
			index.Name = "ISsoSamlSettings_SsoProvider";
			index.CreatedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			index.ModifiedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			index.CreatedInPackageId = new Guid("e5aa7639-5b66-4d72-9308-0563d89b2353");
			EntitySchemaIndexColumn ssoProviderIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("859fc399-4770-2263-34cd-8eb8c5649e2f"),
				ColumnUId = new Guid("ac66c105-0e16-d0f1-b322-242c79724262"),
				CreatedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				ModifiedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				CreatedInPackageId = new Guid("e5aa7639-5b66-4d72-9308-0563d89b2353"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(ssoProviderIdIndexColumn);
			return index;
		}

		private EntitySchemaIndex CreateISsoSamlSettingsEntityIDIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = true
			};
			index.UId = new Guid("5c9ef88f-c80b-4dfa-af57-372c649ba6fe");
			index.Name = "ISsoSamlSettingsEntityID";
			index.CreatedInSchemaUId = new Guid("9e12ce5e-b1b1-487f-9642-e37c63790b94");
			index.ModifiedInSchemaUId = new Guid("9e12ce5e-b1b1-487f-9642-e37c63790b94");
			index.CreatedInPackageId = new Guid("8579352f-cfdd-4183-b428-a1dc774bf344");
			EntitySchemaIndexColumn entityIDIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("1c740f4f-2230-3395-d6a5-146eeb5c81ba"),
				ColumnUId = new Guid("535aebf0-3006-5185-dac3-3e27096ff129"),
				CreatedInSchemaUId = new Guid("9e12ce5e-b1b1-487f-9642-e37c63790b94"),
				ModifiedInSchemaUId = new Guid("9e12ce5e-b1b1-487f-9642-e37c63790b94"),
				CreatedInPackageId = new Guid("8579352f-cfdd-4183-b428-a1dc774bf344"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(entityIDIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("9e12ce5e-b1b1-487f-9642-e37c63790b94");
			RealUId = new Guid("9e12ce5e-b1b1-487f-9642-e37c63790b94");
			Name = "SsoSamlSettings";
			ParentSchemaUId = new Guid("3572a4cd-22db-4f9e-a8a7-637f8baac3bb");
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
			if (Columns.FindByUId(new Guid("a6647fc0-8361-e9d2-0c75-2a2843693420")) == null) {
				Columns.Add(CreateAdditionalParamsColumn());
			}
			if (Columns.FindByUId(new Guid("6ab00bd1-483a-58fa-b62f-fdbd200aa846")) == null) {
				Columns.Add(CreatePartnerCertificateThumbprintColumn());
			}
			if (Columns.FindByUId(new Guid("86b08ba3-f0b3-ad17-647e-59192068ee36")) == null) {
				Columns.Add(CreateSingleSignOnServiceUrlColumn());
			}
			if (Columns.FindByUId(new Guid("ec60200c-7a43-7729-bcfd-29dffa50fc37")) == null) {
				Columns.Add(CreateSingleLogoutServiceUrlColumn());
			}
			if (Columns.FindByUId(new Guid("535aebf0-3006-5185-dac3-3e27096ff129")) == null) {
				Columns.Add(CreateEntityIDColumn());
			}
			if (Columns.FindByUId(new Guid("eb24b989-76c2-6617-0ffa-b381c35cc9f2")) == null) {
				Columns.Add(CreateSsoSecureOnlyColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateAdditionalParamsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("a6647fc0-8361-e9d2-0c75-2a2843693420"),
				Name = @"AdditionalParams",
				CreatedInSchemaUId = new Guid("9e12ce5e-b1b1-487f-9642-e37c63790b94"),
				ModifiedInSchemaUId = new Guid("9e12ce5e-b1b1-487f-9642-e37c63790b94"),
				CreatedInPackageId = new Guid("e5aa7639-5b66-4d72-9308-0563d89b2353")
			};
		}

		protected virtual EntitySchemaColumn CreatePartnerCertificateThumbprintColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("6ab00bd1-483a-58fa-b62f-fdbd200aa846"),
				Name = @"PartnerCertificateThumbprint",
				CreatedInSchemaUId = new Guid("9e12ce5e-b1b1-487f-9642-e37c63790b94"),
				ModifiedInSchemaUId = new Guid("9e12ce5e-b1b1-487f-9642-e37c63790b94"),
				CreatedInPackageId = new Guid("e5aa7639-5b66-4d72-9308-0563d89b2353")
			};
		}

		protected virtual EntitySchemaColumn CreateSingleSignOnServiceUrlColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("86b08ba3-f0b3-ad17-647e-59192068ee36"),
				Name = @"SingleSignOnServiceUrl",
				CreatedInSchemaUId = new Guid("9e12ce5e-b1b1-487f-9642-e37c63790b94"),
				ModifiedInSchemaUId = new Guid("9e12ce5e-b1b1-487f-9642-e37c63790b94"),
				CreatedInPackageId = new Guid("e5aa7639-5b66-4d72-9308-0563d89b2353")
			};
		}

		protected virtual EntitySchemaColumn CreateSingleLogoutServiceUrlColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("ec60200c-7a43-7729-bcfd-29dffa50fc37"),
				Name = @"SingleLogoutServiceUrl",
				CreatedInSchemaUId = new Guid("9e12ce5e-b1b1-487f-9642-e37c63790b94"),
				ModifiedInSchemaUId = new Guid("9e12ce5e-b1b1-487f-9642-e37c63790b94"),
				CreatedInPackageId = new Guid("e5aa7639-5b66-4d72-9308-0563d89b2353")
			};
		}

		protected virtual EntitySchemaColumn CreateEntityIDColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("535aebf0-3006-5185-dac3-3e27096ff129"),
				Name = @"EntityID",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("9e12ce5e-b1b1-487f-9642-e37c63790b94"),
				ModifiedInSchemaUId = new Guid("9e12ce5e-b1b1-487f-9642-e37c63790b94"),
				CreatedInPackageId = new Guid("e5aa7639-5b66-4d72-9308-0563d89b2353")
			};
		}

		protected virtual EntitySchemaColumn CreateSsoSecureOnlyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("eb24b989-76c2-6617-0ffa-b381c35cc9f2"),
				Name = @"SsoSecureOnly",
				CreatedInSchemaUId = new Guid("9e12ce5e-b1b1-487f-9642-e37c63790b94"),
				ModifiedInSchemaUId = new Guid("9e12ce5e-b1b1-487f-9642-e37c63790b94"),
				CreatedInPackageId = new Guid("6ea8ffd3-a056-4527-8ee5-0d2e2601227e")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateISsoSamlSettings_SsoProviderIndex());
			Indexes.Add(CreateISsoSamlSettingsEntityIDIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SsoSamlSettings(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SsoSamlSettings_SsoSettingsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SsoSamlSettingsSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SsoSamlSettingsSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9e12ce5e-b1b1-487f-9642-e37c63790b94"));
		}

		#endregion

	}

	#endregion

	#region Class: SsoSamlSettings

	/// <summary>
	/// SsoSamlSettings.
	/// </summary>
	/// <remarks>
	/// Settings for SAML.
	/// </remarks>
	public class SsoSamlSettings : Terrasoft.Configuration.SsoBaseSettings
	{

		#region Constructors: Public

		public SsoSamlSettings(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SsoSamlSettings";
		}

		public SsoSamlSettings(SsoSamlSettings source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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
		/// Active certificate for signing.
		/// </summary>
		public string PartnerCertificateThumbprint {
			get {
				return GetTypedColumnValue<string>("PartnerCertificateThumbprint");
			}
			set {
				SetColumnValue("PartnerCertificateThumbprint", value);
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
		/// Entity ID.
		/// </summary>
		public string EntityID {
			get {
				return GetTypedColumnValue<string>("EntityID");
			}
			set {
				SetColumnValue("EntityID", value);
			}
		}

		/// <summary>
		/// SSO secure only.
		/// </summary>
		public bool SsoSecureOnly {
			get {
				return GetTypedColumnValue<bool>("SsoSecureOnly");
			}
			set {
				SetColumnValue("SsoSecureOnly", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SsoSamlSettings_SsoSettingsEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SsoSamlSettingsDeleted", e);
			Deleting += (s, e) => ThrowEvent("SsoSamlSettingsDeleting", e);
			Inserted += (s, e) => ThrowEvent("SsoSamlSettingsInserted", e);
			Inserting += (s, e) => ThrowEvent("SsoSamlSettingsInserting", e);
			Saved += (s, e) => ThrowEvent("SsoSamlSettingsSaved", e);
			Saving += (s, e) => ThrowEvent("SsoSamlSettingsSaving", e);
			Validating += (s, e) => ThrowEvent("SsoSamlSettingsValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SsoSamlSettings(this);
		}

		#endregion

	}

	#endregion

	#region Class: SsoSamlSettings_SsoSettingsEventsProcess

	/// <exclude/>
	public partial class SsoSamlSettings_SsoSettingsEventsProcess<TEntity> : Terrasoft.Configuration.SsoBaseSettings_SsoSettingsEventsProcess<TEntity> where TEntity : SsoSamlSettings
	{

		public SsoSamlSettings_SsoSettingsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SsoSamlSettings_SsoSettingsEventsProcess";
			SchemaUId = new Guid("9e12ce5e-b1b1-487f-9642-e37c63790b94");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("9e12ce5e-b1b1-487f-9642-e37c63790b94");
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

	#region Class: SsoSamlSettings_SsoSettingsEventsProcess

	/// <exclude/>
	public class SsoSamlSettings_SsoSettingsEventsProcess : SsoSamlSettings_SsoSettingsEventsProcess<SsoSamlSettings>
	{

		public SsoSamlSettings_SsoSettingsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SsoSamlSettings_SsoSettingsEventsProcess

	public partial class SsoSamlSettings_SsoSettingsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SsoSamlSettingsEventsProcess

	/// <exclude/>
	public class SsoSamlSettingsEventsProcess : SsoSamlSettings_SsoSettingsEventsProcess
	{

		public SsoSamlSettingsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

