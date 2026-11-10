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

	#region Class: UserOAuthSharedAccessSchema

	/// <exclude/>
	public class UserOAuthSharedAccessSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public UserOAuthSharedAccessSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public UserOAuthSharedAccessSchema(UserOAuthSharedAccessSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public UserOAuthSharedAccessSchema(UserOAuthSharedAccessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateUserOAuthAppUniquePairIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = true
			};
			index.UId = new Guid("07fdc51b-99c7-4cb9-abfe-8f484b924639");
			index.Name = "UserOAuthAppUniquePair";
			index.CreatedInSchemaUId = new Guid("100bc1b4-371b-4d4b-9de5-7f62611efcd9");
			index.ModifiedInSchemaUId = new Guid("100bc1b4-371b-4d4b-9de5-7f62611efcd9");
			index.CreatedInPackageId = new Guid("49af2168-effb-4b7f-bce2-28e45d430d96");
			EntitySchemaIndexColumn sysUserIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("53f1a7e6-dc43-312f-8ecb-284dca62bd2f"),
				ColumnUId = new Guid("8d8f45e2-0843-1eba-afa3-3bd8d933bebf"),
				CreatedInSchemaUId = new Guid("100bc1b4-371b-4d4b-9de5-7f62611efcd9"),
				ModifiedInSchemaUId = new Guid("100bc1b4-371b-4d4b-9de5-7f62611efcd9"),
				CreatedInPackageId = new Guid("49af2168-effb-4b7f-bce2-28e45d430d96"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(sysUserIdIndexColumn);
			EntitySchemaIndexColumn oAuthClientAppIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("103334aa-329b-94e1-471e-8db2920249c5"),
				ColumnUId = new Guid("6b3ea96d-3bd0-4e19-04fb-648c94e5564b"),
				CreatedInSchemaUId = new Guid("100bc1b4-371b-4d4b-9de5-7f62611efcd9"),
				ModifiedInSchemaUId = new Guid("100bc1b4-371b-4d4b-9de5-7f62611efcd9"),
				CreatedInPackageId = new Guid("49af2168-effb-4b7f-bce2-28e45d430d96"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(oAuthClientAppIdIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("100bc1b4-371b-4d4b-9de5-7f62611efcd9");
			RealUId = new Guid("100bc1b4-371b-4d4b-9de5-7f62611efcd9");
			Name = "UserOAuthSharedAccess";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("49af2168-effb-4b7f-bce2-28e45d430d96");
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
			if (Columns.FindByUId(new Guid("6b3ea96d-3bd0-4e19-04fb-648c94e5564b")) == null) {
				Columns.Add(CreateOAuthClientAppColumn());
			}
			if (Columns.FindByUId(new Guid("8d8f45e2-0843-1eba-afa3-3bd8d933bebf")) == null) {
				Columns.Add(CreateSysUserColumn());
			}
			if (Columns.FindByUId(new Guid("c9af234d-7ac2-12a3-d418-0ab4e1f77f25")) == null) {
				Columns.Add(CreateAccessSharedOnColumn());
			}
			if (Columns.FindByUId(new Guid("c6236823-7bd4-8f38-d953-0143c211de33")) == null) {
				Columns.Add(CreateActiveColumn());
			}
			if (Columns.FindByUId(new Guid("35502cd3-7348-46ba-8516-28b07f27afee")) == null) {
				Columns.Add(CreateConsentGrantedOnColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateOAuthClientAppColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("6b3ea96d-3bd0-4e19-04fb-648c94e5564b"),
				Name = @"OAuthClientApp",
				ReferenceSchemaUId = new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("100bc1b4-371b-4d4b-9de5-7f62611efcd9"),
				ModifiedInSchemaUId = new Guid("100bc1b4-371b-4d4b-9de5-7f62611efcd9"),
				CreatedInPackageId = new Guid("49af2168-effb-4b7f-bce2-28e45d430d96"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateSysUserColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("8d8f45e2-0843-1eba-afa3-3bd8d933bebf"),
				Name = @"SysUser",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("100bc1b4-371b-4d4b-9de5-7f62611efcd9"),
				ModifiedInSchemaUId = new Guid("100bc1b4-371b-4d4b-9de5-7f62611efcd9"),
				CreatedInPackageId = new Guid("49af2168-effb-4b7f-bce2-28e45d430d96"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateAccessSharedOnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("c9af234d-7ac2-12a3-d418-0ab4e1f77f25"),
				Name = @"AccessSharedOn",
				CreatedInSchemaUId = new Guid("100bc1b4-371b-4d4b-9de5-7f62611efcd9"),
				ModifiedInSchemaUId = new Guid("100bc1b4-371b-4d4b-9de5-7f62611efcd9"),
				CreatedInPackageId = new Guid("49af2168-effb-4b7f-bce2-28e45d430d96"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"CurrentDateTime")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateActiveColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("c6236823-7bd4-8f38-d953-0143c211de33"),
				Name = @"Active",
				CreatedInSchemaUId = new Guid("100bc1b4-371b-4d4b-9de5-7f62611efcd9"),
				ModifiedInSchemaUId = new Guid("100bc1b4-371b-4d4b-9de5-7f62611efcd9"),
				CreatedInPackageId = new Guid("49af2168-effb-4b7f-bce2-28e45d430d96"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"True"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateConsentGrantedOnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("35502cd3-7348-46ba-8516-28b07f27afee"),
				Name = @"ConsentGrantedOn",
				CreatedInSchemaUId = new Guid("100bc1b4-371b-4d4b-9de5-7f62611efcd9"),
				ModifiedInSchemaUId = new Guid("100bc1b4-371b-4d4b-9de5-7f62611efcd9"),
				CreatedInPackageId = new Guid("49af2168-effb-4b7f-bce2-28e45d430d96")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateUserOAuthAppUniquePairIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new UserOAuthSharedAccess(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new UserOAuthSharedAccess_OAuth20EventsProcess(userConnection);
		}

		public override object Clone() {
			return new UserOAuthSharedAccessSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new UserOAuthSharedAccessSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("100bc1b4-371b-4d4b-9de5-7f62611efcd9"));
		}

		#endregion

	}

	#endregion

	#region Class: UserOAuthSharedAccess

	/// <summary>
	/// Users who granted permissions to app via OAuth .
	/// </summary>
	public class UserOAuthSharedAccess : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public UserOAuthSharedAccess(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "UserOAuthSharedAccess";
		}

		public UserOAuthSharedAccess(UserOAuthSharedAccess source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid OAuthClientAppId {
			get {
				return GetTypedColumnValue<Guid>("OAuthClientAppId");
			}
			set {
				SetColumnValue("OAuthClientAppId", value);
				_oAuthClientApp = null;
			}
		}

		/// <exclude/>
		public string OAuthClientAppName {
			get {
				return GetTypedColumnValue<string>("OAuthClientAppName");
			}
			set {
				SetColumnValue("OAuthClientAppName", value);
				if (_oAuthClientApp != null) {
					_oAuthClientApp.Name = value;
				}
			}
		}

		private OAuthClientApp _oAuthClientApp;
		/// <summary>
		/// OAuth client application.
		/// </summary>
		public OAuthClientApp OAuthClientApp {
			get {
				return _oAuthClientApp ??
					(_oAuthClientApp = LookupColumnEntities.GetEntity("OAuthClientApp") as OAuthClientApp);
			}
		}

		/// <exclude/>
		public Guid SysUserId {
			get {
				return GetTypedColumnValue<Guid>("SysUserId");
			}
			set {
				SetColumnValue("SysUserId", value);
				_sysUser = null;
			}
		}

		/// <exclude/>
		public string SysUserName {
			get {
				return GetTypedColumnValue<string>("SysUserName");
			}
			set {
				SetColumnValue("SysUserName", value);
				if (_sysUser != null) {
					_sysUser.Name = value;
				}
			}
		}

		private SysAdminUnit _sysUser;
		/// <summary>
		/// User.
		/// </summary>
		public SysAdminUnit SysUser {
			get {
				return _sysUser ??
					(_sysUser = LookupColumnEntities.GetEntity("SysUser") as SysAdminUnit);
			}
		}

		/// <summary>
		/// Last access granted on.
		/// </summary>
		public DateTime AccessSharedOn {
			get {
				return GetTypedColumnValue<DateTime>("AccessSharedOn");
			}
			set {
				SetColumnValue("AccessSharedOn", value);
			}
		}

		/// <summary>
		/// Access active.
		/// </summary>
		public bool Active {
			get {
				return GetTypedColumnValue<bool>("Active");
			}
			set {
				SetColumnValue("Active", value);
			}
		}

		public DateTime ConsentGrantedOn {
			get {
				return GetTypedColumnValue<DateTime>("ConsentGrantedOn");
			}
			set {
				SetColumnValue("ConsentGrantedOn", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new UserOAuthSharedAccess_OAuth20EventsProcess(UserConnection);
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
			return new UserOAuthSharedAccess(this);
		}

		#endregion

	}

	#endregion

	#region Class: UserOAuthSharedAccess_OAuth20EventsProcess

	/// <exclude/>
	public partial class UserOAuthSharedAccess_OAuth20EventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : UserOAuthSharedAccess
	{

		public UserOAuthSharedAccess_OAuth20EventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "UserOAuthSharedAccess_OAuth20EventsProcess";
			SchemaUId = new Guid("100bc1b4-371b-4d4b-9de5-7f62611efcd9");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("100bc1b4-371b-4d4b-9de5-7f62611efcd9");
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

	#region Class: UserOAuthSharedAccess_OAuth20EventsProcess

	/// <exclude/>
	public class UserOAuthSharedAccess_OAuth20EventsProcess : UserOAuthSharedAccess_OAuth20EventsProcess<UserOAuthSharedAccess>
	{

		public UserOAuthSharedAccess_OAuth20EventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: UserOAuthSharedAccess_OAuth20EventsProcess

	public partial class UserOAuthSharedAccess_OAuth20EventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: UserOAuthSharedAccessEventsProcess

	/// <exclude/>
	public class UserOAuthSharedAccessEventsProcess : UserOAuthSharedAccess_OAuth20EventsProcess
	{

		public UserOAuthSharedAccessEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

