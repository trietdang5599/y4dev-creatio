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

	#region Class: SsoBaseSettingsSchema

	/// <exclude/>
	[IsVirtual]
	public class SsoBaseSettingsSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SsoBaseSettingsSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SsoBaseSettingsSchema(SsoBaseSettingsSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SsoBaseSettingsSchema(SsoBaseSettingsSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateUniqueIdentityProviderColumnIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = true
			};
			index.UId = new Guid("6d163856-9827-47ef-8e39-10b93f10dba6");
			index.Name = "UniqueIdentityProviderColumn";
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

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("3572a4cd-22db-4f9e-a8a7-637f8baac3bb");
			RealUId = new Guid("3572a4cd-22db-4f9e-a8a7-637f8baac3bb");
			Name = "SsoBaseSettings";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
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
			if (Columns.FindByUId(new Guid("ac66c105-0e16-d0f1-b322-242c79724262")) == null) {
				Columns.Add(CreateSsoProviderColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSsoProviderColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ac66c105-0e16-d0f1-b322-242c79724262"),
				Name = @"SsoProvider",
				ReferenceSchemaUId = new Guid("1e5b03af-036d-47c4-b8a6-d51aef0e795f"),
				IsValueCloneable = false,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("3572a4cd-22db-4f9e-a8a7-637f8baac3bb"),
				ModifiedInSchemaUId = new Guid("3572a4cd-22db-4f9e-a8a7-637f8baac3bb"),
				CreatedInPackageId = new Guid("e5aa7639-5b66-4d72-9308-0563d89b2353")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateUniqueIdentityProviderColumnIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SsoBaseSettings(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SsoBaseSettings_SsoSettingsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SsoBaseSettingsSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SsoBaseSettingsSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3572a4cd-22db-4f9e-a8a7-637f8baac3bb"));
		}

		#endregion

	}

	#endregion

	#region Class: SsoBaseSettings

	/// <summary>
	/// SsoBaseSettings.
	/// </summary>
	public class SsoBaseSettings : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SsoBaseSettings(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SsoBaseSettings";
		}

		public SsoBaseSettings(SsoBaseSettings source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SsoProviderId {
			get {
				return GetTypedColumnValue<Guid>("SsoProviderId");
			}
			set {
				SetColumnValue("SsoProviderId", value);
				_ssoProvider = null;
			}
		}

		/// <exclude/>
		public string SsoProviderName {
			get {
				return GetTypedColumnValue<string>("SsoProviderName");
			}
			set {
				SetColumnValue("SsoProviderName", value);
				if (_ssoProvider != null) {
					_ssoProvider.Name = value;
				}
			}
		}

		private SsoProvider _ssoProvider;
		/// <summary>
		/// Sso identity provider.
		/// </summary>
		public SsoProvider SsoProvider {
			get {
				return _ssoProvider ??
					(_ssoProvider = LookupColumnEntities.GetEntity("SsoProvider") as SsoProvider);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SsoBaseSettings_SsoSettingsEventsProcess(UserConnection);
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
			return new SsoBaseSettings(this);
		}

		#endregion

	}

	#endregion

	#region Class: SsoBaseSettings_SsoSettingsEventsProcess

	/// <exclude/>
	public partial class SsoBaseSettings_SsoSettingsEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : SsoBaseSettings
	{

		public SsoBaseSettings_SsoSettingsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SsoBaseSettings_SsoSettingsEventsProcess";
			SchemaUId = new Guid("3572a4cd-22db-4f9e-a8a7-637f8baac3bb");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("3572a4cd-22db-4f9e-a8a7-637f8baac3bb");
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

	#region Class: SsoBaseSettings_SsoSettingsEventsProcess

	/// <exclude/>
	public class SsoBaseSettings_SsoSettingsEventsProcess : SsoBaseSettings_SsoSettingsEventsProcess<SsoBaseSettings>
	{

		public SsoBaseSettings_SsoSettingsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SsoBaseSettings_SsoSettingsEventsProcess

	public partial class SsoBaseSettings_SsoSettingsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SsoBaseSettingsEventsProcess

	/// <exclude/>
	public class SsoBaseSettingsEventsProcess : SsoBaseSettings_SsoSettingsEventsProcess
	{

		public SsoBaseSettingsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

