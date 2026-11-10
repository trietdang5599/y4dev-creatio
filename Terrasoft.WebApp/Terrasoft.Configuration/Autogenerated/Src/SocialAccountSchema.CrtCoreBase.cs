namespace Terrasoft.Configuration
{

	using DataContract = Terrasoft.Nui.ServiceModel.DataContract;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.IO;
	using System.Linq;
	using Terrasoft.Common;
	using Terrasoft.Common.Json;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DcmProcess;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;
	using Terrasoft.GlobalSearch.Indexing;
	using Terrasoft.Social;

	#region Class: SocialAccount_CrtCoreBase_CreatioSchema

	/// <exclude/>
	public class SocialAccount_CrtCoreBase_CreatioSchema : Terrasoft.Configuration.BaseEntityNotesSchema
	{

		#region Constructors: Public

		public SocialAccount_CrtCoreBase_CreatioSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SocialAccount_CrtCoreBase_CreatioSchema(SocialAccount_CrtCoreBase_CreatioSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SocialAccount_CrtCoreBase_CreatioSchema(SocialAccount_CrtCoreBase_CreatioSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("76e3d8e8-6c6b-48b5-9f43-3b361c368bff");
			RealUId = new Guid("76e3d8e8-6c6b-48b5-9f43-3b361c368bff");
			Name = "SocialAccount_CrtCoreBase_Creatio";
			ParentSchemaUId = new Guid("a22b1e79-7fc1-4fe5-aba0-538e9df96f17");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
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
			PrimaryDisplayColumn = CreateLoginColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("6287d2bd-93ac-4ca2-921f-3e87d81dc00b")) == null) {
				Columns.Add(CreatePublicColumn());
			}
			if (Columns.FindByUId(new Guid("14f15a6f-d70a-4c77-8f00-984f7bc1821f")) == null) {
				Columns.Add(CreateAccessTokenColumn());
			}
			if (Columns.FindByUId(new Guid("ef8d65a0-3f11-43ac-a259-a28a34494d23")) == null) {
				Columns.Add(CreateAccessSecretTokenColumn());
			}
			if (Columns.FindByUId(new Guid("eee3f2c0-52b4-4d86-95bf-bf4d7fe00f24")) == null) {
				Columns.Add(CreateConsumerKeyColumn());
			}
			if (Columns.FindByUId(new Guid("6be6d2f0-6c1c-463b-8daa-972f1687ec4f")) == null) {
				Columns.Add(CreateTypeColumn());
			}
			if (Columns.FindByUId(new Guid("f22ba771-1414-4be2-9ff8-3028ce093bcf")) == null) {
				Columns.Add(CreateUserColumn());
			}
			if (Columns.FindByUId(new Guid("72ef9eba-b06f-4bda-b9e1-4c04309aaf5e")) == null) {
				Columns.Add(CreateSocialIdColumn());
			}
			if (Columns.FindByUId(new Guid("e2a409c4-5ace-48d0-ac77-766ed29cb397")) == null) {
				Columns.Add(CreateIsExpiredColumn());
			}
			if (Columns.FindByUId(new Guid("bbaf2034-8e52-432d-849c-9ddf83e19d6f")) == null) {
				Columns.Add(CreateNameColumn());
			}
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("76e3d8e8-6c6b-48b5-9f43-3b361c368bff");
			return column;
		}

		protected override EntitySchemaColumn CreateNotesColumn() {
			EntitySchemaColumn column = base.CreateNotesColumn();
			column.ModifiedInSchemaUId = new Guid("76e3d8e8-6c6b-48b5-9f43-3b361c368bff");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected virtual EntitySchemaColumn CreateLoginColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("6a86e81d-86b2-4650-b1dc-fd775bd0a277"),
				Name = @"Login",
				UsageType = EntitySchemaColumnUsageType.Advanced,
				CreatedInSchemaUId = new Guid("76e3d8e8-6c6b-48b5-9f43-3b361c368bff"),
				ModifiedInSchemaUId = new Guid("76e3d8e8-6c6b-48b5-9f43-3b361c368bff"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				IsSensitiveData = true
			};
		}

		protected virtual EntitySchemaColumn CreatePublicColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("6287d2bd-93ac-4ca2-921f-3e87d81dc00b"),
				Name = @"Public",
				CreatedInSchemaUId = new Guid("76e3d8e8-6c6b-48b5-9f43-3b361c368bff"),
				ModifiedInSchemaUId = new Guid("76e3d8e8-6c6b-48b5-9f43-3b361c368bff"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"True"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateAccessTokenColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("14f15a6f-d70a-4c77-8f00-984f7bc1821f"),
				Name = @"AccessToken",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("76e3d8e8-6c6b-48b5-9f43-3b361c368bff"),
				ModifiedInSchemaUId = new Guid("76e3d8e8-6c6b-48b5-9f43-3b361c368bff"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				IsSensitiveData = true
			};
		}

		protected virtual EntitySchemaColumn CreateAccessSecretTokenColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("ef8d65a0-3f11-43ac-a259-a28a34494d23"),
				Name = @"AccessSecretToken",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("76e3d8e8-6c6b-48b5-9f43-3b361c368bff"),
				ModifiedInSchemaUId = new Guid("76e3d8e8-6c6b-48b5-9f43-3b361c368bff"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				IsSensitiveData = true
			};
		}

		protected virtual EntitySchemaColumn CreateConsumerKeyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("eee3f2c0-52b4-4d86-95bf-bf4d7fe00f24"),
				Name = @"ConsumerKey",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("76e3d8e8-6c6b-48b5-9f43-3b361c368bff"),
				ModifiedInSchemaUId = new Guid("76e3d8e8-6c6b-48b5-9f43-3b361c368bff"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				IsSensitiveData = true
			};
		}

		protected virtual EntitySchemaColumn CreateTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("6be6d2f0-6c1c-463b-8daa-972f1687ec4f"),
				Name = @"Type",
				ReferenceSchemaUId = new Guid("d846cb4f-f18d-469e-83ff-e961f3fba873"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("76e3d8e8-6c6b-48b5-9f43-3b361c368bff"),
				ModifiedInSchemaUId = new Guid("76e3d8e8-6c6b-48b5-9f43-3b361c368bff"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateUserColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("f22ba771-1414-4be2-9ff8-3028ce093bcf"),
				Name = @"User",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("76e3d8e8-6c6b-48b5-9f43-3b361c368bff"),
				ModifiedInSchemaUId = new Guid("76e3d8e8-6c6b-48b5-9f43-3b361c368bff"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSocialIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("72ef9eba-b06f-4bda-b9e1-4c04309aaf5e"),
				Name = @"SocialId",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				UsageType = EntitySchemaColumnUsageType.Advanced,
				CreatedInSchemaUId = new Guid("76e3d8e8-6c6b-48b5-9f43-3b361c368bff"),
				ModifiedInSchemaUId = new Guid("76e3d8e8-6c6b-48b5-9f43-3b361c368bff"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				IsSensitiveData = true
			};
		}

		protected virtual EntitySchemaColumn CreateIsExpiredColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("e2a409c4-5ace-48d0-ac77-766ed29cb397"),
				Name = @"IsExpired",
				UsageType = EntitySchemaColumnUsageType.Advanced,
				CreatedInSchemaUId = new Guid("76e3d8e8-6c6b-48b5-9f43-3b361c368bff"),
				ModifiedInSchemaUId = new Guid("76e3d8e8-6c6b-48b5-9f43-3b361c368bff"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("bbaf2034-8e52-432d-849c-9ddf83e19d6f"),
				Name = @"Name",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("76e3d8e8-6c6b-48b5-9f43-3b361c368bff"),
				ModifiedInSchemaUId = new Guid("76e3d8e8-6c6b-48b5-9f43-3b361c368bff"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				IsLocalizable = true,
				IsSensitiveData = true
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SocialAccount_CrtCoreBase_Creatio(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SocialAccount_CrtCoreBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SocialAccount_CrtCoreBase_CreatioSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SocialAccount_CrtCoreBase_CreatioSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("76e3d8e8-6c6b-48b5-9f43-3b361c368bff"));
		}

		#endregion

	}

	#endregion

	#region Class: SocialAccount_CrtCoreBase_Creatio

	/// <summary>
	/// Accounts in external resources.
	/// </summary>
	public class SocialAccount_CrtCoreBase_Creatio : Terrasoft.Configuration.BaseEntityNotes
	{

		#region Constructors: Public

		public SocialAccount_CrtCoreBase_Creatio(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SocialAccount_CrtCoreBase_Creatio";
		}

		public SocialAccount_CrtCoreBase_Creatio(SocialAccount_CrtCoreBase_Creatio source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// User login.
		/// </summary>
		public string Login {
			get {
				return GetTypedColumnValue<string>("Login");
			}
			set {
				SetColumnValue("Login", value);
			}
		}

		/// <summary>
		/// Public.
		/// </summary>
		public bool Public {
			get {
				return GetTypedColumnValue<bool>("Public");
			}
			set {
				SetColumnValue("Public", value);
			}
		}

		/// <summary>
		/// Access Token.
		/// </summary>
		public string AccessToken {
			get {
				return GetTypedColumnValue<string>("AccessToken");
			}
			set {
				SetColumnValue("AccessToken", value);
			}
		}

		/// <summary>
		/// Access Secret Token.
		/// </summary>
		public string AccessSecretToken {
			get {
				return GetTypedColumnValue<string>("AccessSecretToken");
			}
			set {
				SetColumnValue("AccessSecretToken", value);
			}
		}

		/// <summary>
		/// Consumer Key.
		/// </summary>
		public string ConsumerKey {
			get {
				return GetTypedColumnValue<string>("ConsumerKey");
			}
			set {
				SetColumnValue("ConsumerKey", value);
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

		private CommunicationType _type;
		/// <summary>
		/// Type.
		/// </summary>
		public CommunicationType Type {
			get {
				return _type ??
					(_type = LookupColumnEntities.GetEntity("Type") as CommunicationType);
			}
		}

		/// <exclude/>
		public Guid UserId {
			get {
				return GetTypedColumnValue<Guid>("UserId");
			}
			set {
				SetColumnValue("UserId", value);
				_user = null;
			}
		}

		/// <exclude/>
		public string UserName {
			get {
				return GetTypedColumnValue<string>("UserName");
			}
			set {
				SetColumnValue("UserName", value);
				if (_user != null) {
					_user.Name = value;
				}
			}
		}

		private SysAdminUnit _user;
		/// <summary>
		/// User.
		/// </summary>
		public SysAdminUnit User {
			get {
				return _user ??
					(_user = LookupColumnEntities.GetEntity("User") as SysAdminUnit);
			}
		}

		/// <summary>
		/// Social network user.
		/// </summary>
		public string SocialId {
			get {
				return GetTypedColumnValue<string>("SocialId");
			}
			set {
				SetColumnValue("SocialId", value);
			}
		}

		/// <summary>
		/// Expired on.
		/// </summary>
		public bool IsExpired {
			get {
				return GetTypedColumnValue<bool>("IsExpired");
			}
			set {
				SetColumnValue("IsExpired", value);
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

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SocialAccount_CrtCoreBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SocialAccount_CrtCoreBase_CreatioDeleted", e);
			Deleting += (s, e) => ThrowEvent("SocialAccount_CrtCoreBase_CreatioDeleting", e);
			Inserted += (s, e) => ThrowEvent("SocialAccount_CrtCoreBase_CreatioInserted", e);
			Inserting += (s, e) => ThrowEvent("SocialAccount_CrtCoreBase_CreatioInserting", e);
			Saved += (s, e) => ThrowEvent("SocialAccount_CrtCoreBase_CreatioSaved", e);
			Saving += (s, e) => ThrowEvent("SocialAccount_CrtCoreBase_CreatioSaving", e);
			Validating += (s, e) => ThrowEvent("SocialAccount_CrtCoreBase_CreatioValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SocialAccount_CrtCoreBase_Creatio(this);
		}

		#endregion

	}

	#endregion

	#region Class: SocialAccount_CrtCoreBaseEventsProcess

	/// <exclude/>
	public partial class SocialAccount_CrtCoreBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntityNotes_CrtCoreBaseEventsProcess<TEntity> where TEntity : SocialAccount_CrtCoreBase_Creatio
	{

		public SocialAccount_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SocialAccount_CrtCoreBaseEventsProcess";
			SchemaUId = new Guid("76e3d8e8-6c6b-48b5-9f43-3b361c368bff");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("76e3d8e8-6c6b-48b5-9f43-3b361c368bff");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _socialAccountSavedEventSubProcess1;
		public ProcessFlowElement SocialAccountSavedEventSubProcess1 {
			get {
				return _socialAccountSavedEventSubProcess1 ?? (_socialAccountSavedEventSubProcess1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "SocialAccountSavedEventSubProcess1",
					SchemaElementUId = new Guid("51eb168e-71bb-4142-9ea3-2fe289bce25d"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _socialAccountSaved;
		public ProcessFlowElement SocialAccountSaved {
			get {
				return _socialAccountSaved ?? (_socialAccountSaved = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "SocialAccountSaved",
					SchemaElementUId = new Guid("42561331-80fc-43d9-a2a5-67058765dd55"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _socialAccountSavedScriptTask1;
		public ProcessScriptTask SocialAccountSavedScriptTask1 {
			get {
				return _socialAccountSavedScriptTask1 ?? (_socialAccountSavedScriptTask1 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SocialAccountSavedScriptTask1",
					SchemaElementUId = new Guid("0cf42978-6370-4f7c-aa83-9ba26a8ba6c4"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = SocialAccountSavedScriptTask1Execute,
				});
			}
		}

		private ProcessFlowElement _socialAccountSavingEventSubProcess2;
		public ProcessFlowElement SocialAccountSavingEventSubProcess2 {
			get {
				return _socialAccountSavingEventSubProcess2 ?? (_socialAccountSavingEventSubProcess2 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "SocialAccountSavingEventSubProcess2",
					SchemaElementUId = new Guid("5e4e0bc7-831c-4729-8480-28d1f840eb72"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _socialAccountSavingStartMessage;
		public ProcessFlowElement SocialAccountSavingStartMessage {
			get {
				return _socialAccountSavingStartMessage ?? (_socialAccountSavingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "SocialAccountSavingStartMessage",
					SchemaElementUId = new Guid("d06130ed-2183-4942-801f-1e30eeb0861b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _socialAccountSavingScriptTask2;
		public ProcessScriptTask SocialAccountSavingScriptTask2 {
			get {
				return _socialAccountSavingScriptTask2 ?? (_socialAccountSavingScriptTask2 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SocialAccountSavingScriptTask2",
					SchemaElementUId = new Guid("7103bc2e-16dc-44c0-bccd-f388aa6e1f64"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = SocialAccountSavingScriptTask2Execute,
				});
			}
		}

		private LocalizableString _wrongSocialNetworkTypeLS;
		public LocalizableString WrongSocialNetworkTypeLS {
			get {
				return _wrongSocialNetworkTypeLS ?? (_wrongSocialNetworkTypeLS = new LocalizableString(Storage, Schema.GetResourceManagerName(), "EventsProcessSchema.LocalizableStrings.WrongSocialNetworkTypeLS.Value"));
			}
		}

		private LocalizableString _defNameColumnValue;
		public LocalizableString DefNameColumnValue {
			get {
				return _defNameColumnValue ?? (_defNameColumnValue = new LocalizableString(Storage, Schema.GetResourceManagerName(), "EventsProcessSchema.LocalizableStrings.DefNameColumnValue.Value"));
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[SocialAccountSavedEventSubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { SocialAccountSavedEventSubProcess1 };
			FlowElements[SocialAccountSaved.SchemaElementUId] = new Collection<ProcessFlowElement> { SocialAccountSaved };
			FlowElements[SocialAccountSavedScriptTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { SocialAccountSavedScriptTask1 };
			FlowElements[SocialAccountSavingEventSubProcess2.SchemaElementUId] = new Collection<ProcessFlowElement> { SocialAccountSavingEventSubProcess2 };
			FlowElements[SocialAccountSavingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { SocialAccountSavingStartMessage };
			FlowElements[SocialAccountSavingScriptTask2.SchemaElementUId] = new Collection<ProcessFlowElement> { SocialAccountSavingScriptTask2 };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "SocialAccountSavedEventSubProcess1":
						break;
					case "SocialAccountSaved":
						e.Context.QueueTasks.Enqueue("SocialAccountSavedScriptTask1");
						break;
					case "SocialAccountSavedScriptTask1":
						break;
					case "SocialAccountSavingEventSubProcess2":
						break;
					case "SocialAccountSavingStartMessage":
						e.Context.QueueTasks.Enqueue("SocialAccountSavingScriptTask2");
						break;
					case "SocialAccountSavingScriptTask2":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("SocialAccountSaved");
			ActivatedEventElements.Add("SocialAccountSavingStartMessage");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "SocialAccountSavedEventSubProcess1":
					context.QueueTasks.Dequeue();
					break;
				case "SocialAccountSaved":
					context.QueueTasks.Dequeue();
					context.SenderName = "SocialAccountSaved";
					result = SocialAccountSaved.Execute(context);
					break;
				case "SocialAccountSavedScriptTask1":
					context.QueueTasks.Dequeue();
					context.SenderName = "SocialAccountSavedScriptTask1";
					result = SocialAccountSavedScriptTask1.Execute(context, SocialAccountSavedScriptTask1Execute);
					break;
				case "SocialAccountSavingEventSubProcess2":
					context.QueueTasks.Dequeue();
					break;
				case "SocialAccountSavingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "SocialAccountSavingStartMessage";
					result = SocialAccountSavingStartMessage.Execute(context);
					break;
				case "SocialAccountSavingScriptTask2":
					context.QueueTasks.Dequeue();
					context.SenderName = "SocialAccountSavingScriptTask2";
					result = SocialAccountSavingScriptTask2.Execute(context, SocialAccountSavingScriptTask2Execute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool SocialAccountSavedScriptTask1Execute(ProcessExecutingContext context) {
			return OnSocialAccountSaved(context);
		}

		public virtual bool SocialAccountSavingScriptTask2Execute(ProcessExecutingContext context) {
			var socialNetwork = GetSocialNetworkType();
			
			if (string.IsNullOrEmpty(Entity.Name)) {
				Entity.Name = string.Format(DefNameColumnValue, socialNetwork.ToString());
			}
			#if !NETSTANDARD2_0 // TODO CRM-42481
			
			// HACK #125916 автоматически устанавливать в поле логин имя пользователя
			if (socialNetwork == SocialNetwork.Google) {
				try {
					Entity.Login = Terrasoft.Social.Google.GoogleConsumer.GetUserEmail(Entity.AccessToken);
				} catch (System.Net.WebException){
					Entity.Login = Entity.Name;
				}
			}
			#endif
			if (string.IsNullOrEmpty(Entity.ConsumerKey)) {
				var value = Terrasoft.Core.Configuration.SysSettings.GetValue(UserConnection, socialNetwork.ToString() + "ConsumerKey");
			 	if (value == null) {
				 	throw new ArgumentNullOrEmptyException("SystemValue." + socialNetwork.ToString() + "ConsumerKey");
				}
				Entity.ConsumerKey = value.ToString();
			}
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "SocialAccount_CrtCoreBase_CreatioSaved":
							if (ActivatedEventElements.Contains("SocialAccountSaved")) {
							context.QueueTasks.Enqueue("SocialAccountSaved");
						}
						break;
					case "SocialAccount_CrtCoreBase_CreatioSaving":
							if (ActivatedEventElements.Contains("SocialAccountSavingStartMessage")) {
							context.QueueTasks.Enqueue("SocialAccountSavingStartMessage");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: SocialAccount_CrtCoreBaseEventsProcess

	/// <exclude/>
	public class SocialAccount_CrtCoreBaseEventsProcess : SocialAccount_CrtCoreBaseEventsProcess<SocialAccount_CrtCoreBase_Creatio>
	{

		public SocialAccount_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SocialAccount_CrtCoreBaseEventsProcess

	public partial class SocialAccount_CrtCoreBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual SocialNetwork GetSocialNetworkType() {
			/*var socialNetworkName = Entity.TypeName;
			
			SocialNetwork socialNetworkType;
			if (!SocialNetwork.TryParse(socialNetworkName, true, out socialNetworkType)) {
				throw new ArgumentException(WrongSocialNetworkTypeLS);
			}
			return socialNetworkType;*/
			/**/
			var typeId = Entity.TypeId;
			
			Guid facebook = new Guid("2795DD03-BACF-E011-92C3-00155D04C01D");
			Guid twitter = new Guid("E7139487-BAD3-E011-92C3-00155D04C01D");
			Guid google = new Guid("efe5d7a2-5f38-e111-851e-00155d04c01d");
			
			if (typeId == facebook) {
				return SocialNetwork.Facebook;
			}
			if (typeId == twitter) {
				return SocialNetwork.Twitter;
			}
			if (typeId == google) {
				return SocialNetwork.Google;
			}
			throw new ArgumentException(WrongSocialNetworkTypeLS);
			//*/
		}

		public virtual bool OnSocialAccountSaved(ProcessExecutingContext context) {
			#if !NETSTANDARD2_0 // TODO CRM-42481
			SocialNetwork socialNetwork = GetSocialNetworkType();
			BaseConsumer.TokenManagers[socialNetwork].Refresh();
			#endif
			return true;
		}

		#endregion

	}

	#endregion

}

