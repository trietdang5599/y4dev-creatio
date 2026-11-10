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

	#region Class: SamlIdpCertificateSchema

	/// <exclude/>
	public class SamlIdpCertificateSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SamlIdpCertificateSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SamlIdpCertificateSchema(SamlIdpCertificateSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SamlIdpCertificateSchema(SamlIdpCertificateSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a2ff1c7c-1fc5-416a-a091-1eb4bc4534d4");
			RealUId = new Guid("a2ff1c7c-1fc5-416a-a091-1eb4bc4534d4");
			Name = "SamlIdpCertificate";
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

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("bcd09138-4f23-1680-4f64-f4306a652709")) == null) {
				Columns.Add(CreateSsoSamlSettingsColumn());
			}
			if (Columns.FindByUId(new Guid("34cdc7fa-4145-d898-daa6-cab4d9c8ca08")) == null) {
				Columns.Add(CreateDataColumn());
			}
			if (Columns.FindByUId(new Guid("aa0694e7-decc-b5ec-36e1-7746f96b5893")) == null) {
				Columns.Add(CreateNameColumn());
			}
			if (Columns.FindByUId(new Guid("664fe164-e42f-6a6c-a4d8-dc77ae443863")) == null) {
				Columns.Add(CreateSizeColumn());
			}
			if (Columns.FindByUId(new Guid("2c7f9f42-f207-37c2-dca3-ed45897d92cc")) == null) {
				Columns.Add(CreateTypeColumn());
			}
			if (Columns.FindByUId(new Guid("dc5fe98e-8977-4eef-9e93-42d830875f05")) == null) {
				Columns.Add(CreateVersionColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSsoSamlSettingsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("bcd09138-4f23-1680-4f64-f4306a652709"),
				Name = @"SsoSamlSettings",
				ReferenceSchemaUId = new Guid("9e12ce5e-b1b1-487f-9642-e37c63790b94"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("a2ff1c7c-1fc5-416a-a091-1eb4bc4534d4"),
				ModifiedInSchemaUId = new Guid("a2ff1c7c-1fc5-416a-a091-1eb4bc4534d4"),
				CreatedInPackageId = new Guid("6ea8ffd3-a056-4527-8ee5-0d2e2601227e"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateDataColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Binary")) {
				UId = new Guid("34cdc7fa-4145-d898-daa6-cab4d9c8ca08"),
				Name = @"Data",
				CreatedInSchemaUId = new Guid("a2ff1c7c-1fc5-416a-a091-1eb4bc4534d4"),
				ModifiedInSchemaUId = new Guid("a2ff1c7c-1fc5-416a-a091-1eb4bc4534d4"),
				CreatedInPackageId = new Guid("6ea8ffd3-a056-4527-8ee5-0d2e2601227e")
			};
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("aa0694e7-decc-b5ec-36e1-7746f96b5893"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("a2ff1c7c-1fc5-416a-a091-1eb4bc4534d4"),
				ModifiedInSchemaUId = new Guid("a2ff1c7c-1fc5-416a-a091-1eb4bc4534d4"),
				CreatedInPackageId = new Guid("6ea8ffd3-a056-4527-8ee5-0d2e2601227e")
			};
		}

		protected virtual EntitySchemaColumn CreateSizeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("664fe164-e42f-6a6c-a4d8-dc77ae443863"),
				Name = @"Size",
				CreatedInSchemaUId = new Guid("a2ff1c7c-1fc5-416a-a091-1eb4bc4534d4"),
				ModifiedInSchemaUId = new Guid("a2ff1c7c-1fc5-416a-a091-1eb4bc4534d4"),
				CreatedInPackageId = new Guid("6ea8ffd3-a056-4527-8ee5-0d2e2601227e")
			};
		}

		protected virtual EntitySchemaColumn CreateTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("2c7f9f42-f207-37c2-dca3-ed45897d92cc"),
				Name = @"Type",
				ReferenceSchemaUId = new Guid("3c6fc826-bca3-49a7-ae4c-7e9454b386a5"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("a2ff1c7c-1fc5-416a-a091-1eb4bc4534d4"),
				ModifiedInSchemaUId = new Guid("a2ff1c7c-1fc5-416a-a091-1eb4bc4534d4"),
				CreatedInPackageId = new Guid("6ea8ffd3-a056-4527-8ee5-0d2e2601227e"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateVersionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("dc5fe98e-8977-4eef-9e93-42d830875f05"),
				Name = @"Version",
				CreatedInSchemaUId = new Guid("a2ff1c7c-1fc5-416a-a091-1eb4bc4534d4"),
				ModifiedInSchemaUId = new Guid("a2ff1c7c-1fc5-416a-a091-1eb4bc4534d4"),
				CreatedInPackageId = new Guid("6ea8ffd3-a056-4527-8ee5-0d2e2601227e")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SamlIdpCertificate(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SamlIdpCertificate_SsoSettingsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SamlIdpCertificateSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SamlIdpCertificateSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a2ff1c7c-1fc5-416a-a091-1eb4bc4534d4"));
		}

		#endregion

	}

	#endregion

	#region Class: SamlIdpCertificate

	/// <summary>
	/// SamlIdpCertificate.
	/// </summary>
	public class SamlIdpCertificate : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SamlIdpCertificate(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SamlIdpCertificate";
		}

		public SamlIdpCertificate(SamlIdpCertificate source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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
		/// Size.
		/// </summary>
		public int Size {
			get {
				return GetTypedColumnValue<int>("Size");
			}
			set {
				SetColumnValue("Size", value);
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

		private FileType _type;
		/// <summary>
		/// Type.
		/// </summary>
		public FileType Type {
			get {
				return _type ??
					(_type = LookupColumnEntities.GetEntity("Type") as FileType);
			}
		}

		/// <summary>
		/// Version.
		/// </summary>
		public int Version {
			get {
				return GetTypedColumnValue<int>("Version");
			}
			set {
				SetColumnValue("Version", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SamlIdpCertificate_SsoSettingsEventsProcess(UserConnection);
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
			return new SamlIdpCertificate(this);
		}

		#endregion

	}

	#endregion

	#region Class: SamlIdpCertificate_SsoSettingsEventsProcess

	/// <exclude/>
	public partial class SamlIdpCertificate_SsoSettingsEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : SamlIdpCertificate
	{

		public SamlIdpCertificate_SsoSettingsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SamlIdpCertificate_SsoSettingsEventsProcess";
			SchemaUId = new Guid("a2ff1c7c-1fc5-416a-a091-1eb4bc4534d4");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("a2ff1c7c-1fc5-416a-a091-1eb4bc4534d4");
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

	#region Class: SamlIdpCertificate_SsoSettingsEventsProcess

	/// <exclude/>
	public class SamlIdpCertificate_SsoSettingsEventsProcess : SamlIdpCertificate_SsoSettingsEventsProcess<SamlIdpCertificate>
	{

		public SamlIdpCertificate_SsoSettingsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SamlIdpCertificate_SsoSettingsEventsProcess

	public partial class SamlIdpCertificate_SsoSettingsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SamlIdpCertificateEventsProcess

	/// <exclude/>
	public class SamlIdpCertificateEventsProcess : SamlIdpCertificate_SsoSettingsEventsProcess
	{

		public SamlIdpCertificateEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

