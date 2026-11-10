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

	#region Class: SamlIdpCertificateViewSchema

	/// <exclude/>
	[IsVirtual]
	public class SamlIdpCertificateViewSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SamlIdpCertificateViewSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SamlIdpCertificateViewSchema(SamlIdpCertificateViewSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SamlIdpCertificateViewSchema(SamlIdpCertificateViewSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("928f5b65-828b-4ea6-b7fd-8eb5d2bcc109");
			RealUId = new Guid("928f5b65-828b-4ea6-b7fd-8eb5d2bcc109");
			Name = "SamlIdpCertificateView";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("6ea8ffd3-a056-4527-8ee5-0d2e2601227e");
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
			if (Columns.FindByUId(new Guid("634d325e-4ef4-f527-f8a0-4b7fe8ddcb53")) == null) {
				Columns.Add(CreateNotBeforeColumn());
			}
			if (Columns.FindByUId(new Guid("d1c50773-0676-8740-61b1-c875fe6bce1d")) == null) {
				Columns.Add(CreateThumbprintColumn());
			}
			if (Columns.FindByUId(new Guid("640f844e-00c3-6697-e717-aac199adf75d")) == null) {
				Columns.Add(CreateNotAfterColumn());
			}
			if (Columns.FindByUId(new Guid("6dbb2a4c-b31d-c7a2-2ebd-b652fe23a11e")) == null) {
				Columns.Add(CreateSsoSamlSettingsColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateNotBeforeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("634d325e-4ef4-f527-f8a0-4b7fe8ddcb53"),
				Name = @"NotBefore",
				CreatedInSchemaUId = new Guid("928f5b65-828b-4ea6-b7fd-8eb5d2bcc109"),
				ModifiedInSchemaUId = new Guid("928f5b65-828b-4ea6-b7fd-8eb5d2bcc109"),
				CreatedInPackageId = new Guid("6ea8ffd3-a056-4527-8ee5-0d2e2601227e")
			};
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("ba4336e5-c39d-767a-981a-e952723ac4f2"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("928f5b65-828b-4ea6-b7fd-8eb5d2bcc109"),
				ModifiedInSchemaUId = new Guid("928f5b65-828b-4ea6-b7fd-8eb5d2bcc109"),
				CreatedInPackageId = new Guid("6ea8ffd3-a056-4527-8ee5-0d2e2601227e")
			};
		}

		protected virtual EntitySchemaColumn CreateThumbprintColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("d1c50773-0676-8740-61b1-c875fe6bce1d"),
				Name = @"Thumbprint",
				CreatedInSchemaUId = new Guid("928f5b65-828b-4ea6-b7fd-8eb5d2bcc109"),
				ModifiedInSchemaUId = new Guid("928f5b65-828b-4ea6-b7fd-8eb5d2bcc109"),
				CreatedInPackageId = new Guid("6ea8ffd3-a056-4527-8ee5-0d2e2601227e")
			};
		}

		protected virtual EntitySchemaColumn CreateNotAfterColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("640f844e-00c3-6697-e717-aac199adf75d"),
				Name = @"NotAfter",
				CreatedInSchemaUId = new Guid("928f5b65-828b-4ea6-b7fd-8eb5d2bcc109"),
				ModifiedInSchemaUId = new Guid("928f5b65-828b-4ea6-b7fd-8eb5d2bcc109"),
				CreatedInPackageId = new Guid("6ea8ffd3-a056-4527-8ee5-0d2e2601227e")
			};
		}

		protected virtual EntitySchemaColumn CreateSsoSamlSettingsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("6dbb2a4c-b31d-c7a2-2ebd-b652fe23a11e"),
				Name = @"SsoSamlSettings",
				ReferenceSchemaUId = new Guid("9e12ce5e-b1b1-487f-9642-e37c63790b94"),
				IsIndexed = true,
				IsWeakReference = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("928f5b65-828b-4ea6-b7fd-8eb5d2bcc109"),
				ModifiedInSchemaUId = new Guid("928f5b65-828b-4ea6-b7fd-8eb5d2bcc109"),
				CreatedInPackageId = new Guid("6ea8ffd3-a056-4527-8ee5-0d2e2601227e"),
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
			return new SamlIdpCertificateView(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SamlIdpCertificateView_SsoSettingsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SamlIdpCertificateViewSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SamlIdpCertificateViewSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("928f5b65-828b-4ea6-b7fd-8eb5d2bcc109"));
		}

		#endregion

	}

	#endregion

	#region Class: SamlIdpCertificateView

	/// <summary>
	/// SamlIdpCertificateView (virtual).
	/// </summary>
	public class SamlIdpCertificateView : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SamlIdpCertificateView(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SamlIdpCertificateView";
		}

		public SamlIdpCertificateView(SamlIdpCertificateView source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Valid from.
		/// </summary>
		public DateTime NotBefore {
			get {
				return GetTypedColumnValue<DateTime>("NotBefore");
			}
			set {
				SetColumnValue("NotBefore", value);
			}
		}

		/// <summary>
		/// Certificate subject.
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
		/// Thumbprint.
		/// </summary>
		public string Thumbprint {
			get {
				return GetTypedColumnValue<string>("Thumbprint");
			}
			set {
				SetColumnValue("Thumbprint", value);
			}
		}

		/// <summary>
		/// Valid untill.
		/// </summary>
		public DateTime NotAfter {
			get {
				return GetTypedColumnValue<DateTime>("NotAfter");
			}
			set {
				SetColumnValue("NotAfter", value);
			}
		}

		/// <exclude/>
		public Guid SsoSamlSettingsId {
			get {
				return GetTypedColumnValue<Guid>("SsoSamlSettingsId");
			}
			set {
				SetColumnValue("SsoSamlSettingsId", value);
				_ssoSamlSettings = null;
			}
		}

		private SsoSamlSettings _ssoSamlSettings;
		/// <summary>
		/// SsoSamlSettings.
		/// </summary>
		public SsoSamlSettings SsoSamlSettings {
			get {
				return _ssoSamlSettings ??
					(_ssoSamlSettings = LookupColumnEntities.GetEntity("SsoSamlSettings") as SsoSamlSettings);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SamlIdpCertificateView_SsoSettingsEventsProcess(UserConnection);
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
			return new SamlIdpCertificateView(this);
		}

		#endregion

	}

	#endregion

	#region Class: SamlIdpCertificateView_SsoSettingsEventsProcess

	/// <exclude/>
	public partial class SamlIdpCertificateView_SsoSettingsEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : SamlIdpCertificateView
	{

		public SamlIdpCertificateView_SsoSettingsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SamlIdpCertificateView_SsoSettingsEventsProcess";
			SchemaUId = new Guid("928f5b65-828b-4ea6-b7fd-8eb5d2bcc109");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("928f5b65-828b-4ea6-b7fd-8eb5d2bcc109");
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

	#region Class: SamlIdpCertificateView_SsoSettingsEventsProcess

	/// <exclude/>
	public class SamlIdpCertificateView_SsoSettingsEventsProcess : SamlIdpCertificateView_SsoSettingsEventsProcess<SamlIdpCertificateView>
	{

		public SamlIdpCertificateView_SsoSettingsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SamlIdpCertificateView_SsoSettingsEventsProcess

	public partial class SamlIdpCertificateView_SsoSettingsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SamlIdpCertificateViewEventsProcess

	/// <exclude/>
	public class SamlIdpCertificateViewEventsProcess : SamlIdpCertificateView_SsoSettingsEventsProcess
	{

		public SamlIdpCertificateViewEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

