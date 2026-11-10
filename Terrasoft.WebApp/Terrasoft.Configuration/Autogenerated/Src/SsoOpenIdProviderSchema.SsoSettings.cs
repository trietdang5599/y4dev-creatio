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

	#region Class: SsoOpenIdProviderSchema

	/// <exclude/>
	[IsVirtual]
	public class SsoOpenIdProviderSchema : Terrasoft.Configuration.SsoOpenIdSettingsSchema
	{

		#region Constructors: Public

		public SsoOpenIdProviderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SsoOpenIdProviderSchema(SsoOpenIdProviderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SsoOpenIdProviderSchema(SsoOpenIdProviderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("660e6fe9-148b-48c9-86ce-917609c718e8");
			RealUId = new Guid("660e6fe9-148b-48c9-86ce-917609c718e8");
			Name = "SsoOpenIdProvider";
			ParentSchemaUId = new Guid("3ac183b2-7c55-4b83-9d62-dbff3151f6ed");
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
			if (Columns.FindByUId(new Guid("5b2cd02f-ea9a-3608-c35f-18507fa4b730")) == null) {
				Columns.Add(CreateCodeColumn());
			}
			if (Columns.FindByUId(new Guid("1d754fa0-2ed8-27d5-9154-e6a00b8e6367")) == null) {
				Columns.Add(CreateSsoSettingsTemplateColumn());
			}
			if (Columns.FindByUId(new Guid("fb0624b6-1606-06e1-8a04-ed2d649d6668")) == null) {
				Columns.Add(CreateIsDefaultColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("5b2cd02f-ea9a-3608-c35f-18507fa4b730"),
				Name = @"Code",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("660e6fe9-148b-48c9-86ce-917609c718e8"),
				ModifiedInSchemaUId = new Guid("660e6fe9-148b-48c9-86ce-917609c718e8"),
				CreatedInPackageId = new Guid("e5aa7639-5b66-4d72-9308-0563d89b2353"),
				IsFormatValidated = true,
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Sequence,
					SequencePrefix = "openid_",
					SequenceNumberOfChars = 1
				}
			};
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("9c351444-929e-3753-faae-a47881e9361e"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("660e6fe9-148b-48c9-86ce-917609c718e8"),
				ModifiedInSchemaUId = new Guid("660e6fe9-148b-48c9-86ce-917609c718e8"),
				CreatedInPackageId = new Guid("e5aa7639-5b66-4d72-9308-0563d89b2353"),
				IsFormatValidated = true
			};
		}

		protected virtual EntitySchemaColumn CreateSsoSettingsTemplateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("1d754fa0-2ed8-27d5-9154-e6a00b8e6367"),
				Name = @"SsoSettingsTemplate",
				ReferenceSchemaUId = new Guid("a1771533-7e22-4f39-b869-e19d2c54f911"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("660e6fe9-148b-48c9-86ce-917609c718e8"),
				ModifiedInSchemaUId = new Guid("660e6fe9-148b-48c9-86ce-917609c718e8"),
				CreatedInPackageId = new Guid("e5aa7639-5b66-4d72-9308-0563d89b2353"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateIsDefaultColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("fb0624b6-1606-06e1-8a04-ed2d649d6668"),
				Name = @"IsDefault",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("660e6fe9-148b-48c9-86ce-917609c718e8"),
				ModifiedInSchemaUId = new Guid("660e6fe9-148b-48c9-86ce-917609c718e8"),
				CreatedInPackageId = new Guid("3883e66b-3a55-490c-b61a-fd048c6542f1")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SsoOpenIdProvider(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SsoOpenIdProvider_SsoSettingsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SsoOpenIdProviderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SsoOpenIdProviderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("660e6fe9-148b-48c9-86ce-917609c718e8"));
		}

		#endregion

	}

	#endregion

	#region Class: SsoOpenIdProvider

	/// <summary>
	/// OpenID provider (virtual).
	/// </summary>
	/// <remarks>
	/// SSO OpenID provider (virtual).
	/// </remarks>
	public class SsoOpenIdProvider : Terrasoft.Configuration.SsoOpenIdSettings
	{

		#region Constructors: Public

		public SsoOpenIdProvider(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SsoOpenIdProvider";
		}

		public SsoOpenIdProvider(SsoOpenIdProvider source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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
		/// Display name.
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

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SsoOpenIdProvider_SsoSettingsEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SsoOpenIdProviderDeleted", e);
			Deleting += (s, e) => ThrowEvent("SsoOpenIdProviderDeleting", e);
			Inserted += (s, e) => ThrowEvent("SsoOpenIdProviderInserted", e);
			Inserting += (s, e) => ThrowEvent("SsoOpenIdProviderInserting", e);
			Saved += (s, e) => ThrowEvent("SsoOpenIdProviderSaved", e);
			Saving += (s, e) => ThrowEvent("SsoOpenIdProviderSaving", e);
			Validating += (s, e) => ThrowEvent("SsoOpenIdProviderValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SsoOpenIdProvider(this);
		}

		#endregion

	}

	#endregion

	#region Class: SsoOpenIdProvider_SsoSettingsEventsProcess

	/// <exclude/>
	public partial class SsoOpenIdProvider_SsoSettingsEventsProcess<TEntity> : Terrasoft.Configuration.SsoOpenIdSettings_SsoSettingsEventsProcess<TEntity> where TEntity : SsoOpenIdProvider
	{

		public SsoOpenIdProvider_SsoSettingsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SsoOpenIdProvider_SsoSettingsEventsProcess";
			SchemaUId = new Guid("660e6fe9-148b-48c9-86ce-917609c718e8");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("660e6fe9-148b-48c9-86ce-917609c718e8");
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

	#region Class: SsoOpenIdProvider_SsoSettingsEventsProcess

	/// <exclude/>
	public class SsoOpenIdProvider_SsoSettingsEventsProcess : SsoOpenIdProvider_SsoSettingsEventsProcess<SsoOpenIdProvider>
	{

		public SsoOpenIdProvider_SsoSettingsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SsoOpenIdProvider_SsoSettingsEventsProcess

	public partial class SsoOpenIdProvider_SsoSettingsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SsoOpenIdProviderEventsProcess

	/// <exclude/>
	public class SsoOpenIdProviderEventsProcess : SsoOpenIdProvider_SsoSettingsEventsProcess
	{

		public SsoOpenIdProviderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

