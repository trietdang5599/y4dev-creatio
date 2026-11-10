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

	#region Class: SsoOpenIdSettingsSchema

	/// <exclude/>
	public class SsoOpenIdSettingsSchema : Terrasoft.Configuration.SsoBaseSettingsSchema
	{

		#region Constructors: Public

		public SsoOpenIdSettingsSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SsoOpenIdSettingsSchema(SsoOpenIdSettingsSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SsoOpenIdSettingsSchema(SsoOpenIdSettingsSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateISsoOpenIdSettings_SsoProviderIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = true
			};
			index.UId = new Guid("6d163856-9827-47ef-8e39-10b93f10dba6");
			index.Name = "ISsoOpenIdSettings_SsoProvider";
			index.CreatedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			index.ModifiedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			index.CreatedInPackageId = new Guid("e5aa7639-5b66-4d72-9308-0563d89b2353");
			EntitySchemaIndexColumn ssoProviderIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("369738ba-8d55-65c6-c165-06ac4f03d603"),
				ColumnUId = new Guid("ac66c105-0e16-d0f1-b322-242c79724262"),
				CreatedInSchemaUId = new Guid("3ac183b2-7c55-4b83-9d62-dbff3151f6ed"),
				ModifiedInSchemaUId = new Guid("3ac183b2-7c55-4b83-9d62-dbff3151f6ed"),
				CreatedInPackageId = new Guid("e5aa7639-5b66-4d72-9308-0563d89b2353"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(ssoProviderIdIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("3ac183b2-7c55-4b83-9d62-dbff3151f6ed");
			RealUId = new Guid("3ac183b2-7c55-4b83-9d62-dbff3151f6ed");
			Name = "SsoOpenIdSettings";
			ParentSchemaUId = new Guid("3572a4cd-22db-4f9e-a8a7-637f8baac3bb");
			ExtendParent = false;
			CreatedInPackageId = new Guid("e5aa7639-5b66-4d72-9308-0563d89b2353");
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
			PrimaryDisplayColumn = CreateUrlColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("f96adc79-ff8a-defc-1a12-0a40ebb7523b")) == null) {
				Columns.Add(CreateEndSessionEndpointUrlColumn());
			}
			if (Columns.FindByUId(new Guid("e82bd103-1636-3ed5-d28d-591c8a831291")) == null) {
				Columns.Add(CreateDiscoveryUrlColumn());
			}
			if (Columns.FindByUId(new Guid("a40d4337-5006-7bcd-df28-6ec8eaa76120")) == null) {
				Columns.Add(CreateClientSecretColumn());
			}
			if (Columns.FindByUId(new Guid("e4dc2267-bc58-46eb-f38e-ec2b3376d33a")) == null) {
				Columns.Add(CreateClientIDColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateEndSessionEndpointUrlColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("f96adc79-ff8a-defc-1a12-0a40ebb7523b"),
				Name = @"EndSessionEndpointUrl",
				CreatedInSchemaUId = new Guid("3ac183b2-7c55-4b83-9d62-dbff3151f6ed"),
				ModifiedInSchemaUId = new Guid("3ac183b2-7c55-4b83-9d62-dbff3151f6ed"),
				CreatedInPackageId = new Guid("e5aa7639-5b66-4d72-9308-0563d89b2353")
			};
		}

		protected virtual EntitySchemaColumn CreateDiscoveryUrlColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("e82bd103-1636-3ed5-d28d-591c8a831291"),
				Name = @"DiscoveryUrl",
				CreatedInSchemaUId = new Guid("3ac183b2-7c55-4b83-9d62-dbff3151f6ed"),
				ModifiedInSchemaUId = new Guid("3ac183b2-7c55-4b83-9d62-dbff3151f6ed"),
				CreatedInPackageId = new Guid("e5aa7639-5b66-4d72-9308-0563d89b2353")
			};
		}

		protected virtual EntitySchemaColumn CreateClientSecretColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("SecureText")) {
				UId = new Guid("a40d4337-5006-7bcd-df28-6ec8eaa76120"),
				Name = @"ClientSecret",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("3ac183b2-7c55-4b83-9d62-dbff3151f6ed"),
				ModifiedInSchemaUId = new Guid("3ac183b2-7c55-4b83-9d62-dbff3151f6ed"),
				CreatedInPackageId = new Guid("e5aa7639-5b66-4d72-9308-0563d89b2353")
			};
		}

		protected virtual EntitySchemaColumn CreateClientIDColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("e4dc2267-bc58-46eb-f38e-ec2b3376d33a"),
				Name = @"ClientID",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("3ac183b2-7c55-4b83-9d62-dbff3151f6ed"),
				ModifiedInSchemaUId = new Guid("3ac183b2-7c55-4b83-9d62-dbff3151f6ed"),
				CreatedInPackageId = new Guid("e5aa7639-5b66-4d72-9308-0563d89b2353")
			};
		}

		protected virtual EntitySchemaColumn CreateUrlColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("321b9c3c-395e-3fcf-d42a-b6d3e50aa8fc"),
				Name = @"Url",
				CreatedInSchemaUId = new Guid("3ac183b2-7c55-4b83-9d62-dbff3151f6ed"),
				ModifiedInSchemaUId = new Guid("3ac183b2-7c55-4b83-9d62-dbff3151f6ed"),
				CreatedInPackageId = new Guid("e5aa7639-5b66-4d72-9308-0563d89b2353")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateISsoOpenIdSettings_SsoProviderIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SsoOpenIdSettings(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SsoOpenIdSettings_SsoSettingsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SsoOpenIdSettingsSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SsoOpenIdSettingsSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3ac183b2-7c55-4b83-9d62-dbff3151f6ed"));
		}

		#endregion

	}

	#endregion

	#region Class: SsoOpenIdSettings

	/// <summary>
	/// SsoOpenIdSettings.
	/// </summary>
	/// <remarks>
	/// Sso openId settings.
	/// </remarks>
	public class SsoOpenIdSettings : Terrasoft.Configuration.SsoBaseSettings
	{

		#region Constructors: Public

		public SsoOpenIdSettings(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SsoOpenIdSettings";
		}

		public SsoOpenIdSettings(SsoOpenIdSettings source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// End session endpoint URL.
		/// </summary>
		public string EndSessionEndpointUrl {
			get {
				return GetTypedColumnValue<string>("EndSessionEndpointUrl");
			}
			set {
				SetColumnValue("EndSessionEndpointUrl", value);
			}
		}

		/// <summary>
		/// Discovery URL.
		/// </summary>
		public string DiscoveryUrl {
			get {
				return GetTypedColumnValue<string>("DiscoveryUrl");
			}
			set {
				SetColumnValue("DiscoveryUrl", value);
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
		/// Client ID.
		/// </summary>
		public string ClientID {
			get {
				return GetTypedColumnValue<string>("ClientID");
			}
			set {
				SetColumnValue("ClientID", value);
			}
		}

		/// <summary>
		/// URL.
		/// </summary>
		public string Url {
			get {
				return GetTypedColumnValue<string>("Url");
			}
			set {
				SetColumnValue("Url", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SsoOpenIdSettings_SsoSettingsEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SsoOpenIdSettingsDeleted", e);
			Deleting += (s, e) => ThrowEvent("SsoOpenIdSettingsDeleting", e);
			Inserted += (s, e) => ThrowEvent("SsoOpenIdSettingsInserted", e);
			Inserting += (s, e) => ThrowEvent("SsoOpenIdSettingsInserting", e);
			Saved += (s, e) => ThrowEvent("SsoOpenIdSettingsSaved", e);
			Saving += (s, e) => ThrowEvent("SsoOpenIdSettingsSaving", e);
			Validating += (s, e) => ThrowEvent("SsoOpenIdSettingsValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SsoOpenIdSettings(this);
		}

		#endregion

	}

	#endregion

	#region Class: SsoOpenIdSettings_SsoSettingsEventsProcess

	/// <exclude/>
	public partial class SsoOpenIdSettings_SsoSettingsEventsProcess<TEntity> : Terrasoft.Configuration.SsoBaseSettings_SsoSettingsEventsProcess<TEntity> where TEntity : SsoOpenIdSettings
	{

		public SsoOpenIdSettings_SsoSettingsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SsoOpenIdSettings_SsoSettingsEventsProcess";
			SchemaUId = new Guid("3ac183b2-7c55-4b83-9d62-dbff3151f6ed");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("3ac183b2-7c55-4b83-9d62-dbff3151f6ed");
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

	#region Class: SsoOpenIdSettings_SsoSettingsEventsProcess

	/// <exclude/>
	public class SsoOpenIdSettings_SsoSettingsEventsProcess : SsoOpenIdSettings_SsoSettingsEventsProcess<SsoOpenIdSettings>
	{

		public SsoOpenIdSettings_SsoSettingsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SsoOpenIdSettings_SsoSettingsEventsProcess

	public partial class SsoOpenIdSettings_SsoSettingsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SsoOpenIdSettingsEventsProcess

	/// <exclude/>
	public class SsoOpenIdSettingsEventsProcess : SsoOpenIdSettings_SsoSettingsEventsProcess
	{

		public SsoOpenIdSettingsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

