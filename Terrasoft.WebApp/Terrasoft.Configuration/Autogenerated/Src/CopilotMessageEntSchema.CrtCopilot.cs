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

	#region Class: CopilotMessageEntSchema

	/// <exclude/>
	public class CopilotMessageEntSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public CopilotMessageEntSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CopilotMessageEntSchema(CopilotMessageEntSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CopilotMessageEntSchema(CopilotMessageEntSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateCreatedOnIndexIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("98f9a8dc-9f41-45b3-bafd-86cf988839f5");
			index.Name = "CreatedOnIndex";
			index.CreatedInSchemaUId = new Guid("427e6cd6-9696-4887-a905-5cfc48217c0a");
			index.ModifiedInSchemaUId = new Guid("427e6cd6-9696-4887-a905-5cfc48217c0a");
			index.CreatedInPackageId = new Guid("de27d792-746f-4099-886b-2a79fce1930c");
			EntitySchemaIndexColumn createdOnIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("e54a61d4-c526-94cd-0e39-22f74d63ef7b"),
				ColumnUId = new Guid("e80190a5-03b2-4095-90f7-a193a960adee"),
				CreatedInSchemaUId = new Guid("427e6cd6-9696-4887-a905-5cfc48217c0a"),
				ModifiedInSchemaUId = new Guid("427e6cd6-9696-4887-a905-5cfc48217c0a"),
				CreatedInPackageId = new Guid("de27d792-746f-4099-886b-2a79fce1930c"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(createdOnIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("427e6cd6-9696-4887-a905-5cfc48217c0a");
			RealUId = new Guid("427e6cd6-9696-4887-a905-5cfc48217c0a");
			Name = "CopilotMessageEnt";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("7a3a8162-4be1-46b5-bd50-b3efc2df6d2e");
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
			if (Columns.FindByUId(new Guid("189620e3-cecb-64b1-963e-061f764bdfa8")) == null) {
				Columns.Add(CreateToolCallIdColumn());
			}
			if (Columns.FindByUId(new Guid("f100144e-3028-59e1-57e0-69347d471c3e")) == null) {
				Columns.Add(CreateRoleColumn());
			}
			if (Columns.FindByUId(new Guid("d3eab9a1-1032-12d6-f591-1f63fb8a267f")) == null) {
				Columns.Add(CreateContentColumn());
			}
			if (Columns.FindByUId(new Guid("680c2c8c-f74f-8c26-91d9-5de4670a5aef")) == null) {
				Columns.Add(CreateCopilotSessionColumn());
			}
			if (Columns.FindByUId(new Guid("e66fba18-ba06-1679-8b64-93bea7a6b639")) == null) {
				Columns.Add(CreateIntentColumn());
			}
			if (Columns.FindByUId(new Guid("093c5917-f943-7c1c-7b75-e7b59a180023")) == null) {
				Columns.Add(CreateCopilotRequestColumn());
			}
			if (Columns.FindByUId(new Guid("1d6c0059-53a8-5fc2-ed4e-5f3932c7522e")) == null) {
				Columns.Add(CreateRootIntentColumn());
			}
			if (Columns.FindByUId(new Guid("a004540c-c09c-bcac-696a-5fabfd55646a")) == null) {
				Columns.Add(CreateSummarizedByColumn());
			}
			if (Columns.FindByUId(new Guid("0d70d5c1-4ec6-2fc1-8f6b-4e99a1128858")) == null) {
				Columns.Add(CreateIsSummaryColumn());
			}
			if (Columns.FindByUId(new Guid("ae602d87-73b7-2825-1a06-5dc684b0b407")) == null) {
				Columns.Add(CreateIsFromSystemIntentColumn());
			}
			if (Columns.FindByUId(new Guid("36d1d153-6113-c244-f391-98162b8a1e5d")) == null) {
				Columns.Add(CreateIsFromSystemPromptColumn());
			}
			if (Columns.FindByUId(new Guid("1ac193e8-0da3-8bac-3343-1701ce6cc49b")) == null) {
				Columns.Add(CreateForwardToClientColumn());
			}
			if (Columns.FindByUId(new Guid("e88c9ea4-6689-c34f-ce21-f61c0d6c1cb8")) == null) {
				Columns.Add(CreateContentTypeColumn());
			}
			if (Columns.FindByUId(new Guid("521ebdc7-c6c1-b8bb-0d7c-b8875a10c2ab")) == null) {
				Columns.Add(CreateOmitAssistantResponseColumn());
			}
			if (Columns.FindByUId(new Guid("3a5a1668-eb09-3ea5-cfb6-04e9af4b685a")) == null) {
				Columns.Add(CreateConfirmationResultColumn());
			}
			if (Columns.FindByUId(new Guid("207d3dd3-1586-7e6e-8b98-b41f8e4c6aac")) == null) {
				Columns.Add(CreateToolCallIdsRequireConfirmationColumn());
			}
			if (Columns.FindByUId(new Guid("ac9d5ccc-81da-41d0-dc88-7aa4ea4c75af")) == null) {
				Columns.Add(CreateProcessElementColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateToolCallIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("189620e3-cecb-64b1-963e-061f764bdfa8"),
				Name = @"ToolCallId",
				CreatedInSchemaUId = new Guid("427e6cd6-9696-4887-a905-5cfc48217c0a"),
				ModifiedInSchemaUId = new Guid("427e6cd6-9696-4887-a905-5cfc48217c0a"),
				CreatedInPackageId = new Guid("7a3a8162-4be1-46b5-bd50-b3efc2df6d2e")
			};
		}

		protected virtual EntitySchemaColumn CreateRoleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("f100144e-3028-59e1-57e0-69347d471c3e"),
				Name = @"Role",
				ReferenceSchemaUId = new Guid("0b692a14-a874-4feb-848d-5efa3b022184"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("427e6cd6-9696-4887-a905-5cfc48217c0a"),
				ModifiedInSchemaUId = new Guid("427e6cd6-9696-4887-a905-5cfc48217c0a"),
				CreatedInPackageId = new Guid("7a3a8162-4be1-46b5-bd50-b3efc2df6d2e"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateContentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("d3eab9a1-1032-12d6-f591-1f63fb8a267f"),
				Name = @"Content",
				CreatedInSchemaUId = new Guid("427e6cd6-9696-4887-a905-5cfc48217c0a"),
				ModifiedInSchemaUId = new Guid("427e6cd6-9696-4887-a905-5cfc48217c0a"),
				CreatedInPackageId = new Guid("7a3a8162-4be1-46b5-bd50-b3efc2df6d2e"),
				IsMultiLineText = true
			};
		}

		protected virtual EntitySchemaColumn CreateCopilotSessionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("680c2c8c-f74f-8c26-91d9-5de4670a5aef"),
				Name = @"CopilotSession",
				ReferenceSchemaUId = new Guid("b5e91b69-1cf7-456c-a553-76302e52f42f"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("427e6cd6-9696-4887-a905-5cfc48217c0a"),
				ModifiedInSchemaUId = new Guid("427e6cd6-9696-4887-a905-5cfc48217c0a"),
				CreatedInPackageId = new Guid("7a3a8162-4be1-46b5-bd50-b3efc2df6d2e")
			};
		}

		protected virtual EntitySchemaColumn CreateIntentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e66fba18-ba06-1679-8b64-93bea7a6b639"),
				Name = @"Intent",
				ReferenceSchemaUId = new Guid("90fa6d02-3e93-45d6-a72b-58dcffa411ae"),
				IsIndexed = true,
				IsWeakReference = true,
				CreatedInSchemaUId = new Guid("427e6cd6-9696-4887-a905-5cfc48217c0a"),
				ModifiedInSchemaUId = new Guid("427e6cd6-9696-4887-a905-5cfc48217c0a"),
				CreatedInPackageId = new Guid("7a3a8162-4be1-46b5-bd50-b3efc2df6d2e")
			};
		}

		protected virtual EntitySchemaColumn CreateCopilotRequestColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("093c5917-f943-7c1c-7b75-e7b59a180023"),
				Name = @"CopilotRequest",
				ReferenceSchemaUId = new Guid("b846aaa6-f2d5-4146-9fc0-606dfd041b5e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("427e6cd6-9696-4887-a905-5cfc48217c0a"),
				ModifiedInSchemaUId = new Guid("427e6cd6-9696-4887-a905-5cfc48217c0a"),
				CreatedInPackageId = new Guid("bad99159-33f2-43af-aab2-3508b9685277"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateRootIntentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("1d6c0059-53a8-5fc2-ed4e-5f3932c7522e"),
				Name = @"RootIntent",
				ReferenceSchemaUId = new Guid("90fa6d02-3e93-45d6-a72b-58dcffa411ae"),
				IsIndexed = true,
				IsWeakReference = true,
				CreatedInSchemaUId = new Guid("427e6cd6-9696-4887-a905-5cfc48217c0a"),
				ModifiedInSchemaUId = new Guid("427e6cd6-9696-4887-a905-5cfc48217c0a"),
				CreatedInPackageId = new Guid("c23dfaf0-0051-4966-86f8-cbe8197258d0")
			};
		}

		protected virtual EntitySchemaColumn CreateSummarizedByColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("a004540c-c09c-bcac-696a-5fabfd55646a"),
				Name = @"SummarizedBy",
				ReferenceSchemaUId = new Guid("427e6cd6-9696-4887-a905-5cfc48217c0a"),
				IsIndexed = true,
				IsWeakReference = true,
				CreatedInSchemaUId = new Guid("427e6cd6-9696-4887-a905-5cfc48217c0a"),
				ModifiedInSchemaUId = new Guid("427e6cd6-9696-4887-a905-5cfc48217c0a"),
				CreatedInPackageId = new Guid("c23dfaf0-0051-4966-86f8-cbe8197258d0"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateIsSummaryColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("0d70d5c1-4ec6-2fc1-8f6b-4e99a1128858"),
				Name = @"IsSummary",
				CreatedInSchemaUId = new Guid("427e6cd6-9696-4887-a905-5cfc48217c0a"),
				ModifiedInSchemaUId = new Guid("427e6cd6-9696-4887-a905-5cfc48217c0a"),
				CreatedInPackageId = new Guid("c23dfaf0-0051-4966-86f8-cbe8197258d0")
			};
		}

		protected virtual EntitySchemaColumn CreateIsFromSystemIntentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("ae602d87-73b7-2825-1a06-5dc684b0b407"),
				Name = @"IsFromSystemIntent",
				CreatedInSchemaUId = new Guid("427e6cd6-9696-4887-a905-5cfc48217c0a"),
				ModifiedInSchemaUId = new Guid("427e6cd6-9696-4887-a905-5cfc48217c0a"),
				CreatedInPackageId = new Guid("421a8d84-5f16-4efa-b563-3ab0d40eb264")
			};
		}

		protected virtual EntitySchemaColumn CreateIsFromSystemPromptColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("36d1d153-6113-c244-f391-98162b8a1e5d"),
				Name = @"IsFromSystemPrompt",
				CreatedInSchemaUId = new Guid("427e6cd6-9696-4887-a905-5cfc48217c0a"),
				ModifiedInSchemaUId = new Guid("427e6cd6-9696-4887-a905-5cfc48217c0a"),
				CreatedInPackageId = new Guid("421a8d84-5f16-4efa-b563-3ab0d40eb264")
			};
		}

		protected virtual EntitySchemaColumn CreateForwardToClientColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("1ac193e8-0da3-8bac-3343-1701ce6cc49b"),
				Name = @"ForwardToClient",
				CreatedInSchemaUId = new Guid("427e6cd6-9696-4887-a905-5cfc48217c0a"),
				ModifiedInSchemaUId = new Guid("427e6cd6-9696-4887-a905-5cfc48217c0a"),
				CreatedInPackageId = new Guid("ed753793-30d5-4797-a3f9-3019dcc6e358")
			};
		}

		protected virtual EntitySchemaColumn CreateContentTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("e88c9ea4-6689-c34f-ce21-f61c0d6c1cb8"),
				Name = @"ContentType",
				CreatedInSchemaUId = new Guid("427e6cd6-9696-4887-a905-5cfc48217c0a"),
				ModifiedInSchemaUId = new Guid("427e6cd6-9696-4887-a905-5cfc48217c0a"),
				CreatedInPackageId = new Guid("ed753793-30d5-4797-a3f9-3019dcc6e358")
			};
		}

		protected virtual EntitySchemaColumn CreateOmitAssistantResponseColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("521ebdc7-c6c1-b8bb-0d7c-b8875a10c2ab"),
				Name = @"OmitAssistantResponse",
				CreatedInSchemaUId = new Guid("427e6cd6-9696-4887-a905-5cfc48217c0a"),
				ModifiedInSchemaUId = new Guid("427e6cd6-9696-4887-a905-5cfc48217c0a"),
				CreatedInPackageId = new Guid("421a8d84-5f16-4efa-b563-3ab0d40eb264")
			};
		}

		protected virtual EntitySchemaColumn CreateConfirmationResultColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("3a5a1668-eb09-3ea5-cfb6-04e9af4b685a"),
				Name = @"ConfirmationResult",
				CreatedInSchemaUId = new Guid("427e6cd6-9696-4887-a905-5cfc48217c0a"),
				ModifiedInSchemaUId = new Guid("427e6cd6-9696-4887-a905-5cfc48217c0a"),
				CreatedInPackageId = new Guid("ed753793-30d5-4797-a3f9-3019dcc6e358")
			};
		}

		protected virtual EntitySchemaColumn CreateToolCallIdsRequireConfirmationColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("207d3dd3-1586-7e6e-8b98-b41f8e4c6aac"),
				Name = @"ToolCallIdsRequireConfirmation",
				CreatedInSchemaUId = new Guid("427e6cd6-9696-4887-a905-5cfc48217c0a"),
				ModifiedInSchemaUId = new Guid("427e6cd6-9696-4887-a905-5cfc48217c0a"),
				CreatedInPackageId = new Guid("c23dfaf0-0051-4966-86f8-cbe8197258d0")
			};
		}

		protected virtual EntitySchemaColumn CreateProcessElementColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ac9d5ccc-81da-41d0-dc88-7aa4ea4c75af"),
				Name = @"ProcessElement",
				ReferenceSchemaUId = new Guid("a195aa99-8c5b-47e0-a9a6-9bac0ddd5bd0"),
				IsIndexed = true,
				IsWeakReference = true,
				CreatedInSchemaUId = new Guid("427e6cd6-9696-4887-a905-5cfc48217c0a"),
				ModifiedInSchemaUId = new Guid("427e6cd6-9696-4887-a905-5cfc48217c0a"),
				CreatedInPackageId = new Guid("c23dfaf0-0051-4966-86f8-cbe8197258d0"),
				IsSimpleLookup = true
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateCreatedOnIndexIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new CopilotMessageEnt(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CopilotMessageEnt_CrtCopilotEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CopilotMessageEntSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CopilotMessageEntSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("427e6cd6-9696-4887-a905-5cfc48217c0a"));
		}

		#endregion

	}

	#endregion

	#region Class: CopilotMessageEnt

	/// <summary>
	/// Creatio.ai message.
	/// </summary>
	public class CopilotMessageEnt : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public CopilotMessageEnt(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CopilotMessageEnt";
		}

		public CopilotMessageEnt(CopilotMessageEnt source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// ToolCall identifier.
		/// </summary>
		public string ToolCallId {
			get {
				return GetTypedColumnValue<string>("ToolCallId");
			}
			set {
				SetColumnValue("ToolCallId", value);
			}
		}

		/// <exclude/>
		public Guid RoleId {
			get {
				return GetTypedColumnValue<Guid>("RoleId");
			}
			set {
				SetColumnValue("RoleId", value);
				_role = null;
			}
		}

		/// <exclude/>
		public string RoleName {
			get {
				return GetTypedColumnValue<string>("RoleName");
			}
			set {
				SetColumnValue("RoleName", value);
				if (_role != null) {
					_role.Name = value;
				}
			}
		}

		private CopilotMessageRoleEnt _role;
		/// <summary>
		/// Role.
		/// </summary>
		public CopilotMessageRoleEnt Role {
			get {
				return _role ??
					(_role = LookupColumnEntities.GetEntity("Role") as CopilotMessageRoleEnt);
			}
		}

		/// <summary>
		/// Content.
		/// </summary>
		public string Content {
			get {
				return GetTypedColumnValue<string>("Content");
			}
			set {
				SetColumnValue("Content", value);
			}
		}

		/// <exclude/>
		public Guid CopilotSessionId {
			get {
				return GetTypedColumnValue<Guid>("CopilotSessionId");
			}
			set {
				SetColumnValue("CopilotSessionId", value);
				_copilotSession = null;
			}
		}

		/// <exclude/>
		public string CopilotSessionTitle {
			get {
				return GetTypedColumnValue<string>("CopilotSessionTitle");
			}
			set {
				SetColumnValue("CopilotSessionTitle", value);
				if (_copilotSession != null) {
					_copilotSession.Title = value;
				}
			}
		}

		private CopilotSessionEnt _copilotSession;
		/// <summary>
		/// Creatio.ai Session.
		/// </summary>
		public CopilotSessionEnt CopilotSession {
			get {
				return _copilotSession ??
					(_copilotSession = LookupColumnEntities.GetEntity("CopilotSession") as CopilotSessionEnt);
			}
		}

		/// <exclude/>
		public Guid IntentId {
			get {
				return GetTypedColumnValue<Guid>("IntentId");
			}
			set {
				SetColumnValue("IntentId", value);
				_intent = null;
			}
		}

		/// <exclude/>
		public string IntentCaption {
			get {
				return GetTypedColumnValue<string>("IntentCaption");
			}
			set {
				SetColumnValue("IntentCaption", value);
				if (_intent != null) {
					_intent.Caption = value;
				}
			}
		}

		private VwSysSchemaInfo _intent;
		/// <summary>
		/// Skill.
		/// </summary>
		public VwSysSchemaInfo Intent {
			get {
				return _intent ??
					(_intent = LookupColumnEntities.GetEntity("Intent") as VwSysSchemaInfo);
			}
		}

		/// <exclude/>
		public Guid CopilotRequestId {
			get {
				return GetTypedColumnValue<Guid>("CopilotRequestId");
			}
			set {
				SetColumnValue("CopilotRequestId", value);
				_copilotRequest = null;
			}
		}

		private CopilotRequestEnt _copilotRequest;
		/// <summary>
		/// Creatio.ai Request.
		/// </summary>
		/// <remarks>
		/// Creatio.ai Request.
		/// </remarks>
		public CopilotRequestEnt CopilotRequest {
			get {
				return _copilotRequest ??
					(_copilotRequest = LookupColumnEntities.GetEntity("CopilotRequest") as CopilotRequestEnt);
			}
		}

		/// <exclude/>
		public Guid RootIntentId {
			get {
				return GetTypedColumnValue<Guid>("RootIntentId");
			}
			set {
				SetColumnValue("RootIntentId", value);
				_rootIntent = null;
			}
		}

		/// <exclude/>
		public string RootIntentCaption {
			get {
				return GetTypedColumnValue<string>("RootIntentCaption");
			}
			set {
				SetColumnValue("RootIntentCaption", value);
				if (_rootIntent != null) {
					_rootIntent.Caption = value;
				}
			}
		}

		private VwSysSchemaInfo _rootIntent;
		/// <summary>
		/// Root Intent.
		/// </summary>
		public VwSysSchemaInfo RootIntent {
			get {
				return _rootIntent ??
					(_rootIntent = LookupColumnEntities.GetEntity("RootIntent") as VwSysSchemaInfo);
			}
		}

		/// <exclude/>
		public Guid SummarizedById {
			get {
				return GetTypedColumnValue<Guid>("SummarizedById");
			}
			set {
				SetColumnValue("SummarizedById", value);
				_summarizedBy = null;
			}
		}

		private CopilotMessageEnt _summarizedBy;
		/// <summary>
		/// Summarized By.
		/// </summary>
		/// <remarks>
		/// Summarized By.
		/// </remarks>
		public CopilotMessageEnt SummarizedBy {
			get {
				return _summarizedBy ??
					(_summarizedBy = LookupColumnEntities.GetEntity("SummarizedBy") as CopilotMessageEnt);
			}
		}

		/// <summary>
		/// IsSummary.
		/// </summary>
		public bool IsSummary {
			get {
				return GetTypedColumnValue<bool>("IsSummary");
			}
			set {
				SetColumnValue("IsSummary", value);
			}
		}

		/// <summary>
		/// From System intent.
		/// </summary>
		public bool IsFromSystemIntent {
			get {
				return GetTypedColumnValue<bool>("IsFromSystemIntent");
			}
			set {
				SetColumnValue("IsFromSystemIntent", value);
			}
		}

		/// <summary>
		/// System prompt.
		/// </summary>
		public bool IsFromSystemPrompt {
			get {
				return GetTypedColumnValue<bool>("IsFromSystemPrompt");
			}
			set {
				SetColumnValue("IsFromSystemPrompt", value);
			}
		}

		/// <summary>
		/// Forward to Client.
		/// </summary>
		public bool ForwardToClient {
			get {
				return GetTypedColumnValue<bool>("ForwardToClient");
			}
			set {
				SetColumnValue("ForwardToClient", value);
			}
		}

		/// <summary>
		/// Content Type.
		/// </summary>
		public string ContentType {
			get {
				return GetTypedColumnValue<string>("ContentType");
			}
			set {
				SetColumnValue("ContentType", value);
			}
		}

		/// <summary>
		/// Omit Assistant Response.
		/// </summary>
		public bool OmitAssistantResponse {
			get {
				return GetTypedColumnValue<bool>("OmitAssistantResponse");
			}
			set {
				SetColumnValue("OmitAssistantResponse", value);
			}
		}

		/// <summary>
		/// Confirmation Result.
		/// </summary>
		public string ConfirmationResult {
			get {
				return GetTypedColumnValue<string>("ConfirmationResult");
			}
			set {
				SetColumnValue("ConfirmationResult", value);
			}
		}

		/// <summary>
		/// Tool Call Ids Require Confirmation.
		/// </summary>
		public string ToolCallIdsRequireConfirmation {
			get {
				return GetTypedColumnValue<string>("ToolCallIdsRequireConfirmation");
			}
			set {
				SetColumnValue("ToolCallIdsRequireConfirmation", value);
			}
		}

		/// <exclude/>
		public Guid ProcessElementId {
			get {
				return GetTypedColumnValue<Guid>("ProcessElementId");
			}
			set {
				SetColumnValue("ProcessElementId", value);
				_processElement = null;
			}
		}

		private SysProcessElementData _processElement;
		/// <summary>
		/// ProcessElement.
		/// </summary>
		public SysProcessElementData ProcessElement {
			get {
				return _processElement ??
					(_processElement = LookupColumnEntities.GetEntity("ProcessElement") as SysProcessElementData);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CopilotMessageEnt_CrtCopilotEventsProcess(UserConnection);
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
			return new CopilotMessageEnt(this);
		}

		#endregion

	}

	#endregion

	#region Class: CopilotMessageEnt_CrtCopilotEventsProcess

	/// <exclude/>
	public partial class CopilotMessageEnt_CrtCopilotEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : CopilotMessageEnt
	{

		public CopilotMessageEnt_CrtCopilotEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CopilotMessageEnt_CrtCopilotEventsProcess";
			SchemaUId = new Guid("427e6cd6-9696-4887-a905-5cfc48217c0a");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("427e6cd6-9696-4887-a905-5cfc48217c0a");
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

	#region Class: CopilotMessageEnt_CrtCopilotEventsProcess

	/// <exclude/>
	public class CopilotMessageEnt_CrtCopilotEventsProcess : CopilotMessageEnt_CrtCopilotEventsProcess<CopilotMessageEnt>
	{

		public CopilotMessageEnt_CrtCopilotEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CopilotMessageEnt_CrtCopilotEventsProcess

	public partial class CopilotMessageEnt_CrtCopilotEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CopilotMessageEntEventsProcess

	/// <exclude/>
	public class CopilotMessageEntEventsProcess : CopilotMessageEnt_CrtCopilotEventsProcess
	{

		public CopilotMessageEntEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

