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

	#region Class: OidcUserIdentitySchema

	/// <exclude/>
	public class OidcUserIdentitySchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public OidcUserIdentitySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OidcUserIdentitySchema(OidcUserIdentitySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OidcUserIdentitySchema(OidcUserIdentitySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateUX_OidcUserIdentity_UserProviderIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = true
			};
			index.UId = new Guid("147aa7fe-107e-4f5e-9008-eea120078d3b");
			index.Name = "UX_OidcUserIdentity_UserProvider";
			index.CreatedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			index.ModifiedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			index.CreatedInPackageId = new Guid("f5b82e2a-9817-41b3-ae8d-14fc2ef74a61");
			EntitySchemaIndexColumn userIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("b4874daa-4827-42af-bdfb-0f8f6904e45e"),
				ColumnUId = new Guid("09480516-e7aa-4860-bee6-b4e2c32625f3"),
				CreatedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				ModifiedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				CreatedInPackageId = new Guid("f5b82e2a-9817-41b3-ae8d-14fc2ef74a61"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(userIdIndexColumn);
			EntitySchemaIndexColumn oidcProviderIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("c7fa2bf1-64c7-445d-84fc-697bb49cd3d0"),
				ColumnUId = new Guid("0d60d647-f0a7-48bb-9137-867fff194aa7"),
				CreatedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				ModifiedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				CreatedInPackageId = new Guid("f5b82e2a-9817-41b3-ae8d-14fc2ef74a61"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(oidcProviderIdIndexColumn);
			return index;
		}

		private EntitySchemaIndex CreateUX_OidcUserIdentity_ProviderSubIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = true
			};
			index.UId = new Guid("13a737f2-a76b-4d44-a58d-0d480acd7c2c");
			index.Name = "UX_OidcUserIdentity_ProviderSub";
			index.CreatedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			index.ModifiedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			index.CreatedInPackageId = new Guid("f5b82e2a-9817-41b3-ae8d-14fc2ef74a61");
			EntitySchemaIndexColumn oidcProviderIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("33b7df9b-fa0a-4d9f-b327-cb6d4a3eb72f"),
				ColumnUId = new Guid("0d60d647-f0a7-48bb-9137-867fff194aa7"),
				CreatedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				ModifiedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				CreatedInPackageId = new Guid("f5b82e2a-9817-41b3-ae8d-14fc2ef74a61"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(oidcProviderIdIndexColumn);
			EntitySchemaIndexColumn subIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("b1ef3847-2888-435d-bd7f-25e302368bef"),
				ColumnUId = new Guid("95d3e324-8eb2-468b-b6ff-7d4ae161a357"),
				CreatedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				ModifiedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				CreatedInPackageId = new Guid("f5b82e2a-9817-41b3-ae8d-14fc2ef74a61"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(subIndexColumn);
			return index;
		}

		private EntitySchemaIndex CreateIX_OidcUserIdentity_SubIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("b7721e43-e572-4441-a7c6-b1fb5eb6d37c");
			index.Name = "IX_OidcUserIdentity_Sub";
			index.CreatedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			index.ModifiedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			index.CreatedInPackageId = new Guid("f5b82e2a-9817-41b3-ae8d-14fc2ef74a61");
			EntitySchemaIndexColumn subIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("0ab1f676-abf6-4f34-acf6-bcaa13fa48c3"),
				ColumnUId = new Guid("95d3e324-8eb2-468b-b6ff-7d4ae161a357"),
				CreatedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				ModifiedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				CreatedInPackageId = new Guid("f5b82e2a-9817-41b3-ae8d-14fc2ef74a61"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(subIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("07a25e8c-17bc-4e9a-9654-3c9290fe57ee");
			RealUId = new Guid("07a25e8c-17bc-4e9a-9654-3c9290fe57ee");
			Name = "OidcUserIdentity";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("f5b82e2a-9817-41b3-ae8d-14fc2ef74a61");
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
			if (Columns.FindByUId(new Guid("09480516-e7aa-4860-bee6-b4e2c32625f3")) == null) {
				Columns.Add(CreateUserColumn());
			}
			if (Columns.FindByUId(new Guid("0d60d647-f0a7-48bb-9137-867fff194aa7")) == null) {
				Columns.Add(CreateOidcProviderColumn());
			}
			if (Columns.FindByUId(new Guid("95d3e324-8eb2-468b-b6ff-7d4ae161a357")) == null) {
				Columns.Add(CreateSubColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateUserColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("09480516-e7aa-4860-bee6-b4e2c32625f3"),
				Name = @"User",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				IsValueCloneable = false,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("07a25e8c-17bc-4e9a-9654-3c9290fe57ee"),
				ModifiedInSchemaUId = new Guid("07a25e8c-17bc-4e9a-9654-3c9290fe57ee"),
				CreatedInPackageId = new Guid("f5b82e2a-9817-41b3-ae8d-14fc2ef74a61")
			};
		}

		protected virtual EntitySchemaColumn CreateOidcProviderColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("0d60d647-f0a7-48bb-9137-867fff194aa7"),
				Name = @"OidcProvider",
				ReferenceSchemaUId = new Guid("1e5b03af-036d-47c4-b8a6-d51aef0e795f"),
				IsValueCloneable = false,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("07a25e8c-17bc-4e9a-9654-3c9290fe57ee"),
				ModifiedInSchemaUId = new Guid("07a25e8c-17bc-4e9a-9654-3c9290fe57ee"),
				CreatedInPackageId = new Guid("f5b82e2a-9817-41b3-ae8d-14fc2ef74a61")
			};
		}

		protected virtual EntitySchemaColumn CreateSubColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("95d3e324-8eb2-468b-b6ff-7d4ae161a357"),
				Name = @"Sub",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("07a25e8c-17bc-4e9a-9654-3c9290fe57ee"),
				ModifiedInSchemaUId = new Guid("07a25e8c-17bc-4e9a-9654-3c9290fe57ee"),
				CreatedInPackageId = new Guid("f5b82e2a-9817-41b3-ae8d-14fc2ef74a61")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateUX_OidcUserIdentity_UserProviderIndex());
			Indexes.Add(CreateUX_OidcUserIdentity_ProviderSubIndex());
			Indexes.Add(CreateIX_OidcUserIdentity_SubIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new OidcUserIdentity(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OidcUserIdentity_SsoSettingsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OidcUserIdentitySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OidcUserIdentitySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("07a25e8c-17bc-4e9a-9654-3c9290fe57ee"));
		}

		#endregion

	}

	#endregion

	#region Class: OidcUserIdentity

	/// <summary>
	/// OIDC user identity.
	/// </summary>
	public class OidcUserIdentity : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public OidcUserIdentity(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OidcUserIdentity";
		}

		public OidcUserIdentity(OidcUserIdentity source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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

		/// <exclude/>
		public Guid OidcProviderId {
			get {
				return GetTypedColumnValue<Guid>("OidcProviderId");
			}
			set {
				SetColumnValue("OidcProviderId", value);
				_oidcProvider = null;
			}
		}

		/// <exclude/>
		public string OidcProviderName {
			get {
				return GetTypedColumnValue<string>("OidcProviderName");
			}
			set {
				SetColumnValue("OidcProviderName", value);
				if (_oidcProvider != null) {
					_oidcProvider.Name = value;
				}
			}
		}

		private SsoProvider _oidcProvider;
		/// <summary>
		/// OIDC provider.
		/// </summary>
		public SsoProvider OidcProvider {
			get {
				return _oidcProvider ??
					(_oidcProvider = LookupColumnEntities.GetEntity("OidcProvider") as SsoProvider);
			}
		}

		/// <summary>
		/// Subject (sub).
		/// </summary>
		public string Sub {
			get {
				return GetTypedColumnValue<string>("Sub");
			}
			set {
				SetColumnValue("Sub", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OidcUserIdentity_SsoSettingsEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("OidcUserIdentityDeleted", e);
			Deleting += (s, e) => ThrowEvent("OidcUserIdentityDeleting", e);
			Inserted += (s, e) => ThrowEvent("OidcUserIdentityInserted", e);
			Inserting += (s, e) => ThrowEvent("OidcUserIdentityInserting", e);
			Saved += (s, e) => ThrowEvent("OidcUserIdentitySaved", e);
			Saving += (s, e) => ThrowEvent("OidcUserIdentitySaving", e);
			Validating += (s, e) => ThrowEvent("OidcUserIdentityValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new OidcUserIdentity(this);
		}

		#endregion

	}

	#endregion

	#region Class: OidcUserIdentity_SsoSettingsEventsProcess

	/// <exclude/>
	public partial class OidcUserIdentity_SsoSettingsEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : OidcUserIdentity
	{

		public OidcUserIdentity_SsoSettingsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OidcUserIdentity_SsoSettingsEventsProcess";
			SchemaUId = new Guid("07a25e8c-17bc-4e9a-9654-3c9290fe57ee");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("07a25e8c-17bc-4e9a-9654-3c9290fe57ee");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		public virtual Object ProcessListeners {
			get;
			set;
		}

		public virtual Object ProcessSchemaListeners {
			get;
			set;
		}

		public virtual bool NextProcessElementReady {
			get;
			set;
		}

		public virtual bool IsProcessModeSave {
			get;
			set;
		}

		public virtual bool CanUseDcm {
			get;
			set;
		}

		public virtual Object DcmEntityUtil {
			get;
			set;
		}

		private ProcessFlowElement _baseEntityDeletingEventSubProcess2;
		public ProcessFlowElement BaseEntityDeletingEventSubProcess2 {
			get {
				return _baseEntityDeletingEventSubProcess2 ?? (_baseEntityDeletingEventSubProcess2 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "BaseEntityDeletingEventSubProcess2",
					SchemaElementUId = new Guid("08594d74-60b0-45ce-bf17-bac1a8b127f7"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _baseEntityDeletingStartMessage2;
		public ProcessFlowElement BaseEntityDeletingStartMessage2 {
			get {
				return _baseEntityDeletingStartMessage2 ?? (_baseEntityDeletingStartMessage2 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "BaseEntityDeletingStartMessage2",
					SchemaElementUId = new Guid("496d4a3c-b644-4a65-b0ed-2534d9236da5"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _tryProcessCompleteScriptTask2;
		public ProcessScriptTask TryProcessCompleteScriptTask2 {
			get {
				return _tryProcessCompleteScriptTask2 ?? (_tryProcessCompleteScriptTask2 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "TryProcessCompleteScriptTask2",
					SchemaElementUId = new Guid("441daff4-4808-48db-ac28-d9a42d61ac31"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = TryProcessCompleteScriptTask2Execute,
				});
			}
		}

		private ProcessFlowElement _baseEntityEventSubProcess1;
		public ProcessFlowElement BaseEntityEventSubProcess1 {
			get {
				return _baseEntityEventSubProcess1 ?? (_baseEntityEventSubProcess1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "BaseEntityEventSubProcess1",
					SchemaElementUId = new Guid("90027ac8-c9c3-4d21-a4f9-da1cde752cd1"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _baseEntityStartMessage1;
		public ProcessFlowElement BaseEntityStartMessage1 {
			get {
				return _baseEntityStartMessage1 ?? (_baseEntityStartMessage1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "BaseEntityStartMessage1",
					SchemaElementUId = new Guid("d8b8410f-5c8a-4ddc-8fc2-353483452aed"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _tryProcessCompleteScriptTask1;
		public ProcessScriptTask TryProcessCompleteScriptTask1 {
			get {
				return _tryProcessCompleteScriptTask1 ?? (_tryProcessCompleteScriptTask1 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "TryProcessCompleteScriptTask1",
					SchemaElementUId = new Guid("9494818b-220e-4e19-a635-fdca641dde5f"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = TryProcessCompleteScriptTask1Execute,
				});
			}
		}

		private ProcessScriptTask _baseEntitySavedIndexingTask;
		public ProcessScriptTask BaseEntitySavedIndexingTask {
			get {
				return _baseEntitySavedIndexingTask ?? (_baseEntitySavedIndexingTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "BaseEntitySavedIndexingTask",
					SchemaElementUId = new Guid("b8ff0739-6ead-4da7-ac8d-538cfc641fcf"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = BaseEntitySavedIndexingTaskExecute,
				});
			}
		}

		private ProcessFlowElement _baseInsertedEventSubProcess;
		public ProcessFlowElement BaseInsertedEventSubProcess {
			get {
				return _baseInsertedEventSubProcess ?? (_baseInsertedEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "BaseInsertedEventSubProcess",
					SchemaElementUId = new Guid("5f3bfbbe-1820-44ca-92f1-6f993169b2dd"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _insertedStartMessage1;
		public ProcessFlowElement InsertedStartMessage1 {
			get {
				return _insertedStartMessage1 ?? (_insertedStartMessage1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "InsertedStartMessage1",
					SchemaElementUId = new Guid("d7c806b7-a29b-4ce5-9167-b3319472e772"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptTaskInsertedBaseEntity;
		public ProcessScriptTask ScriptTaskInsertedBaseEntity {
			get {
				return _scriptTaskInsertedBaseEntity ?? (_scriptTaskInsertedBaseEntity = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTaskInsertedBaseEntity",
					SchemaElementUId = new Guid("5528724d-213b-4ae6-88d5-aa7301a1dbb0"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTaskInsertedBaseEntityExecute,
				});
			}
		}

		private ProcessFlowElement _baseEntitySavingEventSubProcess;
		public ProcessFlowElement BaseEntitySavingEventSubProcess {
			get {
				return _baseEntitySavingEventSubProcess ?? (_baseEntitySavingEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "BaseEntitySavingEventSubProcess",
					SchemaElementUId = new Guid("dbf48103-dcf6-4f53-a052-d727a95ea0b4"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _baseEntitySavingStartMessage;
		public ProcessFlowElement BaseEntitySavingStartMessage {
			get {
				return _baseEntitySavingStartMessage ?? (_baseEntitySavingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "BaseEntitySavingStartMessage",
					SchemaElementUId = new Guid("933bf2fc-d052-40c8-a3e0-bf60049da5d8"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _baseEntitySavingScriptTask;
		public ProcessScriptTask BaseEntitySavingScriptTask {
			get {
				return _baseEntitySavingScriptTask ?? (_baseEntitySavingScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "BaseEntitySavingScriptTask",
					SchemaElementUId = new Guid("9b990da0-84e4-4aa1-ab8f-219ff3a429fa"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = BaseEntitySavingScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _baseEnityValidatingEventSubProcess_f0646c74f291474f9a10143ee868f1c9;
		public ProcessFlowElement BaseEnityValidatingEventSubProcess_f0646c74f291474f9a10143ee868f1c9 {
			get {
				return _baseEnityValidatingEventSubProcess_f0646c74f291474f9a10143ee868f1c9 ?? (_baseEnityValidatingEventSubProcess_f0646c74f291474f9a10143ee868f1c9 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "BaseEnityValidatingEventSubProcess_f0646c74f291474f9a10143ee868f1c9",
					SchemaElementUId = new Guid("f0646c74-f291-474f-9a10-143ee868f1c9"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _baseEnityValidatingStartMessage_b3d5b61f7afe48b5a8cc40317ea9c428;
		public ProcessFlowElement BaseEnityValidatingStartMessage_b3d5b61f7afe48b5a8cc40317ea9c428 {
			get {
				return _baseEnityValidatingStartMessage_b3d5b61f7afe48b5a8cc40317ea9c428 ?? (_baseEnityValidatingStartMessage_b3d5b61f7afe48b5a8cc40317ea9c428 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "BaseEnityValidatingStartMessage_b3d5b61f7afe48b5a8cc40317ea9c428",
					SchemaElementUId = new Guid("b3d5b61f-7afe-48b5-a8cc-40317ea9c428"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _baseEnityValidatingScriptTask_a553628ef6dc4e09bdcf27e446fdc16f;
		public ProcessScriptTask BaseEnityValidatingScriptTask_a553628ef6dc4e09bdcf27e446fdc16f {
			get {
				return _baseEnityValidatingScriptTask_a553628ef6dc4e09bdcf27e446fdc16f ?? (_baseEnityValidatingScriptTask_a553628ef6dc4e09bdcf27e446fdc16f = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "BaseEnityValidatingScriptTask_a553628ef6dc4e09bdcf27e446fdc16f",
					SchemaElementUId = new Guid("a553628e-f6dc-4e09-bdcf-27e446fdc16f"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = BaseEnityValidatingScriptTask_a553628ef6dc4e09bdcf27e446fdc16fExecute,
				});
			}
		}

		private ProcessFlowElement _baseEntityDeletedSubProcess;
		public ProcessFlowElement BaseEntityDeletedSubProcess {
			get {
				return _baseEntityDeletedSubProcess ?? (_baseEntityDeletedSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "BaseEntityDeletedSubProcess",
					SchemaElementUId = new Guid("8140d7e7-fb91-4999-8347-543345440efb"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _baseEntityDeletedStartMessage;
		public ProcessFlowElement BaseEntityDeletedStartMessage {
			get {
				return _baseEntityDeletedStartMessage ?? (_baseEntityDeletedStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "BaseEntityDeletedStartMessage",
					SchemaElementUId = new Guid("c803a450-c8dc-47a4-b704-7125c23db317"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _baseEntityDeletedScriptTask;
		public ProcessScriptTask BaseEntityDeletedScriptTask {
			get {
				return _baseEntityDeletedScriptTask ?? (_baseEntityDeletedScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "BaseEntityDeletedScriptTask",
					SchemaElementUId = new Guid("60f96d87-85be-4d31-856d-8edd6bb953c1"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = BaseEntityDeletedScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[BaseEntityDeletingEventSubProcess2.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseEntityDeletingEventSubProcess2 };
			FlowElements[BaseEntityDeletingStartMessage2.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseEntityDeletingStartMessage2 };
			FlowElements[TryProcessCompleteScriptTask2.SchemaElementUId] = new Collection<ProcessFlowElement> { TryProcessCompleteScriptTask2 };
			FlowElements[BaseEntityEventSubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseEntityEventSubProcess1 };
			FlowElements[BaseEntityStartMessage1.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseEntityStartMessage1 };
			FlowElements[TryProcessCompleteScriptTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { TryProcessCompleteScriptTask1 };
			FlowElements[BaseEntitySavedIndexingTask.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseEntitySavedIndexingTask };
			FlowElements[BaseInsertedEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseInsertedEventSubProcess };
			FlowElements[InsertedStartMessage1.SchemaElementUId] = new Collection<ProcessFlowElement> { InsertedStartMessage1 };
			FlowElements[ScriptTaskInsertedBaseEntity.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTaskInsertedBaseEntity };
			FlowElements[BaseEntitySavingEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseEntitySavingEventSubProcess };
			FlowElements[BaseEntitySavingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseEntitySavingStartMessage };
			FlowElements[BaseEntitySavingScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseEntitySavingScriptTask };
			FlowElements[BaseEnityValidatingEventSubProcess_f0646c74f291474f9a10143ee868f1c9.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseEnityValidatingEventSubProcess_f0646c74f291474f9a10143ee868f1c9 };
			FlowElements[BaseEnityValidatingStartMessage_b3d5b61f7afe48b5a8cc40317ea9c428.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseEnityValidatingStartMessage_b3d5b61f7afe48b5a8cc40317ea9c428 };
			FlowElements[BaseEnityValidatingScriptTask_a553628ef6dc4e09bdcf27e446fdc16f.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseEnityValidatingScriptTask_a553628ef6dc4e09bdcf27e446fdc16f };
			FlowElements[BaseEntityDeletedSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseEntityDeletedSubProcess };
			FlowElements[BaseEntityDeletedStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseEntityDeletedStartMessage };
			FlowElements[BaseEntityDeletedScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseEntityDeletedScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "BaseEntityDeletingEventSubProcess2":
						break;
					case "BaseEntityDeletingStartMessage2":
						e.Context.QueueTasks.Enqueue("TryProcessCompleteScriptTask2");
						break;
					case "TryProcessCompleteScriptTask2":
						break;
					case "BaseEntityEventSubProcess1":
						break;
					case "BaseEntityStartMessage1":
						e.Context.QueueTasks.Enqueue("TryProcessCompleteScriptTask1");
						e.Context.QueueTasks.Enqueue("BaseEntitySavedIndexingTask");
						break;
					case "TryProcessCompleteScriptTask1":
						break;
					case "BaseEntitySavedIndexingTask":
						break;
					case "BaseInsertedEventSubProcess":
						break;
					case "InsertedStartMessage1":
						e.Context.QueueTasks.Enqueue("ScriptTaskInsertedBaseEntity");
						break;
					case "ScriptTaskInsertedBaseEntity":
						break;
					case "BaseEntitySavingEventSubProcess":
						break;
					case "BaseEntitySavingStartMessage":
						e.Context.QueueTasks.Enqueue("BaseEntitySavingScriptTask");
						break;
					case "BaseEntitySavingScriptTask":
						break;
					case "BaseEnityValidatingEventSubProcess_f0646c74f291474f9a10143ee868f1c9":
						break;
					case "BaseEnityValidatingStartMessage_b3d5b61f7afe48b5a8cc40317ea9c428":
						e.Context.QueueTasks.Enqueue("BaseEnityValidatingScriptTask_a553628ef6dc4e09bdcf27e446fdc16f");
						break;
					case "BaseEnityValidatingScriptTask_a553628ef6dc4e09bdcf27e446fdc16f":
						break;
					case "BaseEntityDeletedSubProcess":
						break;
					case "BaseEntityDeletedStartMessage":
						e.Context.QueueTasks.Enqueue("BaseEntityDeletedScriptTask");
						break;
					case "BaseEntityDeletedScriptTask":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("BaseEntityDeletingStartMessage2");
			ActivatedEventElements.Add("BaseEntityStartMessage1");
			ActivatedEventElements.Add("InsertedStartMessage1");
			ActivatedEventElements.Add("BaseEntitySavingStartMessage");
			ActivatedEventElements.Add("BaseEnityValidatingStartMessage_b3d5b61f7afe48b5a8cc40317ea9c428");
			ActivatedEventElements.Add("BaseEntityDeletedStartMessage");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "BaseEntityDeletingEventSubProcess2":
					context.QueueTasks.Dequeue();
					break;
				case "BaseEntityDeletingStartMessage2":
					context.QueueTasks.Dequeue();
					context.SenderName = "BaseEntityDeletingStartMessage2";
					result = BaseEntityDeletingStartMessage2.Execute(context);
					break;
				case "TryProcessCompleteScriptTask2":
					context.QueueTasks.Dequeue();
					context.SenderName = "TryProcessCompleteScriptTask2";
					result = TryProcessCompleteScriptTask2.Execute(context, TryProcessCompleteScriptTask2Execute);
					break;
				case "BaseEntityEventSubProcess1":
					context.QueueTasks.Dequeue();
					break;
				case "BaseEntityStartMessage1":
					context.QueueTasks.Dequeue();
					context.SenderName = "BaseEntityStartMessage1";
					result = BaseEntityStartMessage1.Execute(context);
					break;
				case "TryProcessCompleteScriptTask1":
					context.QueueTasks.Dequeue();
					context.SenderName = "TryProcessCompleteScriptTask1";
					result = TryProcessCompleteScriptTask1.Execute(context, TryProcessCompleteScriptTask1Execute);
					break;
				case "BaseEntitySavedIndexingTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "BaseEntitySavedIndexingTask";
					result = BaseEntitySavedIndexingTask.Execute(context, BaseEntitySavedIndexingTaskExecute);
					break;
				case "BaseInsertedEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "InsertedStartMessage1":
					context.QueueTasks.Dequeue();
					context.SenderName = "InsertedStartMessage1";
					result = InsertedStartMessage1.Execute(context);
					break;
				case "ScriptTaskInsertedBaseEntity":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTaskInsertedBaseEntity";
					result = ScriptTaskInsertedBaseEntity.Execute(context, ScriptTaskInsertedBaseEntityExecute);
					break;
				case "BaseEntitySavingEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "BaseEntitySavingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "BaseEntitySavingStartMessage";
					result = BaseEntitySavingStartMessage.Execute(context);
					break;
				case "BaseEntitySavingScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "BaseEntitySavingScriptTask";
					result = BaseEntitySavingScriptTask.Execute(context, BaseEntitySavingScriptTaskExecute);
					break;
				case "BaseEnityValidatingEventSubProcess_f0646c74f291474f9a10143ee868f1c9":
					context.QueueTasks.Dequeue();
					break;
				case "BaseEnityValidatingStartMessage_b3d5b61f7afe48b5a8cc40317ea9c428":
					context.QueueTasks.Dequeue();
					context.SenderName = "BaseEnityValidatingStartMessage_b3d5b61f7afe48b5a8cc40317ea9c428";
					result = BaseEnityValidatingStartMessage_b3d5b61f7afe48b5a8cc40317ea9c428.Execute(context);
					break;
				case "BaseEnityValidatingScriptTask_a553628ef6dc4e09bdcf27e446fdc16f":
					context.QueueTasks.Dequeue();
					context.SenderName = "BaseEnityValidatingScriptTask_a553628ef6dc4e09bdcf27e446fdc16f";
					result = BaseEnityValidatingScriptTask_a553628ef6dc4e09bdcf27e446fdc16f.Execute(context, BaseEnityValidatingScriptTask_a553628ef6dc4e09bdcf27e446fdc16fExecute);
					break;
				case "BaseEntityDeletedSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "BaseEntityDeletedStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "BaseEntityDeletedStartMessage";
					result = BaseEntityDeletedStartMessage.Execute(context);
					break;
				case "BaseEntityDeletedScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "BaseEntityDeletedScriptTask";
					result = BaseEntityDeletedScriptTask.Execute(context, BaseEntityDeletedScriptTaskExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool TryProcessCompleteScriptTask2Execute(ProcessExecutingContext context) {
			TryProcessComplete(EntityChangeType.Deleted);
			LocalMessageExecuting(EntityChangeType.Deleted);
			ProcessCompleteExecuting();
			return true;
		}

		public virtual bool TryProcessCompleteScriptTask1Execute(ProcessExecutingContext context) {
			ProcessCompleteExecuting();
			return true;
		}

		public virtual bool BaseEntitySavedIndexingTaskExecute(ProcessExecutingContext context) {
			IndexEntity(IndexingOperationType.Index, Entity.PrimaryColumnValue);
			return true;
		}

		public virtual bool ScriptTaskInsertedBaseEntityExecute(ProcessExecutingContext context) {
			TryProcessComplete(EntityChangeType.Inserted);
			LocalMessageExecuting(EntityChangeType.Inserted);
			ProcessCompleteExecuting();
			return true;
		}

		public virtual bool BaseEntitySavingScriptTaskExecute(ProcessExecutingContext context) {
			if (Entity.StoringState == StoringObjectState.New
					|| Entity.StoringState == StoringObjectState.Deleted) {
				return true;
			}
			InitDcmOnEntityChanging();
			TryProcessComplete(EntityChangeType.Updated);
			LocalMessageExecuting(EntityChangeType.Updated);
			return true;
		}

		public virtual bool BaseEnityValidatingScriptTask_a553628ef6dc4e09bdcf27e446fdc16fExecute(ProcessExecutingContext context) {
			if (CanUseDcm) {
				DcmEntityUtilities dcmEntityUtilities = GetDcmEntityUtilities();
				dcmEntityUtilities.ValidateDcmRequiredElement(Entity, (Collection<ProcessListener>)ProcessListeners);
				if (UserConnection.GetIsFeatureEnabled("DcmStagesPermissions")) {
					dcmEntityUtilities.ValidateDcmStagePermissions(Entity, (Collection<ProcessListener>)ProcessListeners);
				}
			}
			return true;
		}

		public virtual bool BaseEntityDeletedScriptTaskExecute(ProcessExecutingContext context) {
			IndexEntity(IndexingOperationType.Delete, Entity.PrimaryColumnValue);
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "BaseEntityDeleting":
							if (ActivatedEventElements.Contains("BaseEntityDeletingStartMessage2")) {
							context.QueueTasks.Enqueue("BaseEntityDeletingStartMessage2");
						}
						break;
					case "BaseEntitySaved":
							if (ActivatedEventElements.Contains("BaseEntityStartMessage1")) {
							context.QueueTasks.Enqueue("BaseEntityStartMessage1");
						}
						break;
					case "BaseEntityInserted":
							if (ActivatedEventElements.Contains("InsertedStartMessage1")) {
							context.QueueTasks.Enqueue("InsertedStartMessage1");
						}
						break;
					case "BaseEntitySaving":
							if (ActivatedEventElements.Contains("BaseEntitySavingStartMessage")) {
							context.QueueTasks.Enqueue("BaseEntitySavingStartMessage");
						}
						break;
					case "BaseEntityValidating":
							if (ActivatedEventElements.Contains("BaseEnityValidatingStartMessage_b3d5b61f7afe48b5a8cc40317ea9c428")) {
							context.QueueTasks.Enqueue("BaseEnityValidatingStartMessage_b3d5b61f7afe48b5a8cc40317ea9c428");
						}
						break;
					case "BaseEntityDeleted":
							if (ActivatedEventElements.Contains("BaseEntityDeletedStartMessage")) {
							context.QueueTasks.Enqueue("BaseEntityDeletedStartMessage");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: OidcUserIdentity_SsoSettingsEventsProcess

	/// <exclude/>
	public class OidcUserIdentity_SsoSettingsEventsProcess : OidcUserIdentity_SsoSettingsEventsProcess<OidcUserIdentity>
	{

		public OidcUserIdentity_SsoSettingsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OidcUserIdentity_SsoSettingsEventsProcess

	public partial class OidcUserIdentity_SsoSettingsEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual void TryProcessComplete(EntityChangeType changeType) {
			var processEngine = UserConnection.ProcessEngine;
			ProcessListeners = processEngine.GetProcessListeners(UserConnection, Entity, changeType);
			ProcessSchemaListeners = processEngine.GetProcessSchemaListeners(Entity, changeType);
		}

		public virtual bool IsConditionDataMatch(string conditionData) {
			if (string.IsNullOrEmpty(conditionData)) {
				return true;
			}
			var esq = new EntitySchemaQuery(Entity.Schema);
			IEntitySchemaQueryFilterItem filterCollection = null;
			try {
				var userConnectionArgument = new ConstructorArgument("userConnection", UserConnection);
				var processDataContractFilterConverter = ClassFactory
					.Get<IProcessDataContractFilterConverter>(userConnectionArgument);
				filterCollection = processDataContractFilterConverter.ConvertToEntitySchemaQueryFilterItem(esq, conditionData);
			} catch {
				var oldConditionData = ConditionData.Deserialize(conditionData);
				bool oldConditionCompleted = oldConditionData == null || oldConditionData.Count == 0;
				if (!oldConditionCompleted) {
					foreach (var condition in oldConditionData) {
						oldConditionCompleted = Entity.GetColumnValue(Entity.Schema.Columns.GetByUId(condition.Key)).Equals(condition.Value);
						if (oldConditionCompleted) {
							break;
						}
					}
				}
				return oldConditionCompleted;
			}
			if (filterCollection != null) {
				esq.AddColumn(Entity.Schema.PrimaryColumn.Name);
				esq.Filters.Add(filterCollection);
				var entity = esq.GetEntity(UserConnection, Entity.PrimaryColumnValue);
				return entity != null;
			}
			return true;
		}

		public virtual bool IsChangedColumnsMatch(string changedColumns) {
			if (string.IsNullOrEmpty(changedColumns)) {
				return true;
			}
			var changedColumnsMetaPaths = JsonConvert.DeserializeObject<Collection<string>>(changedColumns);
			foreach(var columnMetaPath in changedColumnsMetaPaths){
				var changedColumn = Entity.Schema.GetSchemaColumnByMetaPath(columnMetaPath);
				foreach (var columnValue in Entity.GetChangedColumnValues()) {
					if (Guid.Equals(columnValue.Column.UId, changedColumn.UId)) {
						return true;
					}
				}
			}
			return false;
		}

		public virtual void ProcessCompleteExecuting() {
			var processEngine = UserConnection.ProcessEngine;
			var processListeners = (Collection<ProcessListener>)ProcessListeners;
			var processSchemaListeners = (Collection<ProcessSchemaListener>)ProcessSchemaListeners;
			processEngine.ActualizeProcessSchemaListeners(Entity, processSchemaListeners);
			Collection<ProcessDescriptor> processDescriptors;
			bool nextPrcElReady = false;
			IList<ProcessListener> clonedProcessListeners = null;
			if (processListeners != null && processListeners.Count > 0) {
				clonedProcessListeners = new List<ProcessListener>(processListeners);
				processDescriptors = processEngine.ContinueExecuting(UserConnection, Entity, processListeners);
				foreach (ProcessDescriptor processDescriptor in processDescriptors) {
					nextPrcElReady = nextPrcElReady || processDescriptor.IsNextElementReady;
				}
				processListeners.Clear();
			}
			if (CanUseDcm) {
				processEngine.RunDcmProcesses(Entity, clonedProcessListeners);
			}
			bool nextPrcElReadyBySignal = false;
			if (processSchemaListeners != null && processSchemaListeners.Count > 0) {
				processDescriptors = processEngine.RunProcesses(UserConnection, Entity, processSchemaListeners);
				foreach (ProcessDescriptor processDescriptor in processDescriptors) {
					nextPrcElReadyBySignal = nextPrcElReadyBySignal || processDescriptor.IsNextElementReady;
				}
				processSchemaListeners.Clear();
			}
			if (!nextPrcElReady) {
				nextPrcElReady = nextPrcElReadyBySignal;
			}
			NextProcessElementReady = NextProcessElementReady || nextPrcElReady;
		}

		public virtual bool GetNextPrcElReadyPropertyValue(Entity entity) {
			if (entity != null && entity.Process != null) {
				object nextPrcElReady;
				if (entity.Process.TryGetPropertyValue("NextProcessElementReady", out nextPrcElReady)) {
					return (bool)nextPrcElReady;
				}
			}
			return false;
		}

		public virtual void LocalMessageExecuting(EntityChangeType changeType) {
			return;
		}

		public virtual void InitDcmOnEntityChanging() {
			if (!CanInitDcmForEntity()) {
				return;
			}
			var dcmEntityUtilities = GetDcmEntityUtilities();
			CanUseDcm = dcmEntityUtilities.GetCanEntityUseDcm(Entity.Schema.UId, Entity.GetChangedColumnValues());
			CancelNotEnabledDcmProcess();
		}

		public virtual void CancelNotEnabledDcmProcess() {
			if (CanUseDcm) {
				UserConnection.IProcessEngine.CancelNotEnabledDcmProcess(Entity.Schema.UId, Entity.PrimaryColumnValue);
			}
		}

		public virtual DcmEntityUtilities GetDcmEntityUtilities() {
			if (DcmEntityUtil == null) {
				DcmEntityUtil = new DcmEntityUtilities(UserConnection);
			}
			return (DcmEntityUtilities)DcmEntityUtil;
		}

		public virtual bool CanInitDcmForEntity() {
			var schema = Entity.Schema;
			return schema != null &&
				schema.Name != "AdminUnitFeatureState" &&
				schema.Name != "Feature";
		}

		public virtual void IndexEntity(IndexingOperationType indexingOperationType, Guid primaryColumnValue) {
		}

		#endregion

	}

	#endregion


	#region Class: OidcUserIdentityEventsProcess

	/// <exclude/>
	public class OidcUserIdentityEventsProcess : OidcUserIdentity_SsoSettingsEventsProcess
	{

		public OidcUserIdentityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

