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

	#region Class: OAuthDelegationGrantSchema

	/// <exclude/>
	public class OAuthDelegationGrantSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public OAuthDelegationGrantSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OAuthDelegationGrantSchema(OAuthDelegationGrantSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OAuthDelegationGrantSchema(OAuthDelegationGrantSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5c2b9f10-3d44-4e6a-9b22-0a1b2c3d4f01");
			RealUId = new Guid("5c2b9f10-3d44-4e6a-9b22-0a1b2c3d4f01");
			Name = "OAuthDelegationGrant";
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
			if (Columns.FindByUId(new Guid("5c2b9f10-3d44-4e6a-9b22-0a1b2c3d4f20")) == null) {
				Columns.Add(CreateSysUserColumn());
			}
			if (Columns.FindByUId(new Guid("5c2b9f10-3d44-4e6a-9b22-0a1b2c3d4f21")) == null) {
				Columns.Add(CreateOAuthClientAppColumn());
			}
			if (Columns.FindByUId(new Guid("5c2b9f10-3d44-4e6a-9b22-0a1b2c3d4f12")) == null) {
				Columns.Add(CreateRunIdColumn());
			}
			if (Columns.FindByUId(new Guid("5c2b9f10-3d44-4e6a-9b22-0a1b2c3d4f22")) == null) {
				Columns.Add(CreateCallerOAuthClientAppColumn());
			}
			if (Columns.FindByUId(new Guid("5c2b9f10-3d44-4e6a-9b22-0a1b2c3d4f14")) == null) {
				Columns.Add(CreateIssuedAtColumn());
			}
			if (Columns.FindByUId(new Guid("5c2b9f10-3d44-4e6a-9b22-0a1b2c3d4f15")) == null) {
				Columns.Add(CreateExpiresAtColumn());
			}
			if (Columns.FindByUId(new Guid("5c2b9f10-3d44-4e6a-9b22-0a1b2c3d4f16")) == null) {
				Columns.Add(CreateRevokedAtColumn());
			}
			if (Columns.FindByUId(new Guid("5c2b9f10-3d44-4e6a-9b22-0a1b2c3d4f17")) == null) {
				Columns.Add(CreateAccessTokenJtiColumn());
			}
			if (Columns.FindByUId(new Guid("5c2b9f10-3d44-4e6a-9b22-0a1b2c3d4f18")) == null) {
				Columns.Add(CreateScopeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysUserColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("5c2b9f10-3d44-4e6a-9b22-0a1b2c3d4f20"),
				Name = @"SysUser",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsWeakReference = true,
				CreatedInSchemaUId = new Guid("5c2b9f10-3d44-4e6a-9b22-0a1b2c3d4f01"),
				ModifiedInSchemaUId = new Guid("5c2b9f10-3d44-4e6a-9b22-0a1b2c3d4f01"),
				CreatedInPackageId = new Guid("49af2168-effb-4b7f-bce2-28e45d430d96"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateOAuthClientAppColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("5c2b9f10-3d44-4e6a-9b22-0a1b2c3d4f21"),
				Name = @"OAuthClientApp",
				ReferenceSchemaUId = new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsWeakReference = true,
				CreatedInSchemaUId = new Guid("5c2b9f10-3d44-4e6a-9b22-0a1b2c3d4f01"),
				ModifiedInSchemaUId = new Guid("5c2b9f10-3d44-4e6a-9b22-0a1b2c3d4f01"),
				CreatedInPackageId = new Guid("49af2168-effb-4b7f-bce2-28e45d430d96"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateRunIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("5c2b9f10-3d44-4e6a-9b22-0a1b2c3d4f12"),
				Name = @"RunId",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("5c2b9f10-3d44-4e6a-9b22-0a1b2c3d4f01"),
				ModifiedInSchemaUId = new Guid("5c2b9f10-3d44-4e6a-9b22-0a1b2c3d4f01"),
				CreatedInPackageId = new Guid("49af2168-effb-4b7f-bce2-28e45d430d96")
			};
		}

		protected virtual EntitySchemaColumn CreateCallerOAuthClientAppColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("5c2b9f10-3d44-4e6a-9b22-0a1b2c3d4f22"),
				Name = @"CallerOAuthClientApp",
				ReferenceSchemaUId = new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsWeakReference = true,
				CreatedInSchemaUId = new Guid("5c2b9f10-3d44-4e6a-9b22-0a1b2c3d4f01"),
				ModifiedInSchemaUId = new Guid("5c2b9f10-3d44-4e6a-9b22-0a1b2c3d4f01"),
				CreatedInPackageId = new Guid("49af2168-effb-4b7f-bce2-28e45d430d96"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateIssuedAtColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("5c2b9f10-3d44-4e6a-9b22-0a1b2c3d4f14"),
				Name = @"IssuedAt",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("5c2b9f10-3d44-4e6a-9b22-0a1b2c3d4f01"),
				ModifiedInSchemaUId = new Guid("5c2b9f10-3d44-4e6a-9b22-0a1b2c3d4f01"),
				CreatedInPackageId = new Guid("49af2168-effb-4b7f-bce2-28e45d430d96")
			};
		}

		protected virtual EntitySchemaColumn CreateExpiresAtColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("5c2b9f10-3d44-4e6a-9b22-0a1b2c3d4f15"),
				Name = @"ExpiresAt",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("5c2b9f10-3d44-4e6a-9b22-0a1b2c3d4f01"),
				ModifiedInSchemaUId = new Guid("5c2b9f10-3d44-4e6a-9b22-0a1b2c3d4f01"),
				CreatedInPackageId = new Guid("49af2168-effb-4b7f-bce2-28e45d430d96")
			};
		}

		protected virtual EntitySchemaColumn CreateRevokedAtColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("5c2b9f10-3d44-4e6a-9b22-0a1b2c3d4f16"),
				Name = @"RevokedAt",
				CreatedInSchemaUId = new Guid("5c2b9f10-3d44-4e6a-9b22-0a1b2c3d4f01"),
				ModifiedInSchemaUId = new Guid("5c2b9f10-3d44-4e6a-9b22-0a1b2c3d4f01"),
				CreatedInPackageId = new Guid("49af2168-effb-4b7f-bce2-28e45d430d96")
			};
		}

		protected virtual EntitySchemaColumn CreateAccessTokenJtiColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("5c2b9f10-3d44-4e6a-9b22-0a1b2c3d4f17"),
				Name = @"AccessTokenJti",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("5c2b9f10-3d44-4e6a-9b22-0a1b2c3d4f01"),
				ModifiedInSchemaUId = new Guid("5c2b9f10-3d44-4e6a-9b22-0a1b2c3d4f01"),
				CreatedInPackageId = new Guid("49af2168-effb-4b7f-bce2-28e45d430d96")
			};
		}

		protected virtual EntitySchemaColumn CreateScopeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("5c2b9f10-3d44-4e6a-9b22-0a1b2c3d4f18"),
				Name = @"Scope",
				CreatedInSchemaUId = new Guid("5c2b9f10-3d44-4e6a-9b22-0a1b2c3d4f01"),
				ModifiedInSchemaUId = new Guid("5c2b9f10-3d44-4e6a-9b22-0a1b2c3d4f01"),
				CreatedInPackageId = new Guid("49af2168-effb-4b7f-bce2-28e45d430d96")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new OAuthDelegationGrant(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OAuthDelegationGrant_OAuth20EventsProcess(userConnection);
		}

		public override object Clone() {
			return new OAuthDelegationGrantSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OAuthDelegationGrantSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5c2b9f10-3d44-4e6a-9b22-0a1b2c3d4f01"));
		}

		#endregion

	}

	#endregion

	#region Class: OAuthDelegationGrant

	/// <summary>
	/// Base object.
	/// </summary>
	public class OAuthDelegationGrant : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public OAuthDelegationGrant(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OAuthDelegationGrant";
		}

		public OAuthDelegationGrant(OAuthDelegationGrant source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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
		public SysAdminUnit SysUser {
			get {
				return _sysUser ??
					(_sysUser = LookupColumnEntities.GetEntity("SysUser") as SysAdminUnit);
			}
		}

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
		public OAuthClientApp OAuthClientApp {
			get {
				return _oAuthClientApp ??
					(_oAuthClientApp = LookupColumnEntities.GetEntity("OAuthClientApp") as OAuthClientApp);
			}
		}

		public string RunId {
			get {
				return GetTypedColumnValue<string>("RunId");
			}
			set {
				SetColumnValue("RunId", value);
			}
		}

		/// <exclude/>
		public Guid CallerOAuthClientAppId {
			get {
				return GetTypedColumnValue<Guid>("CallerOAuthClientAppId");
			}
			set {
				SetColumnValue("CallerOAuthClientAppId", value);
				_callerOAuthClientApp = null;
			}
		}

		/// <exclude/>
		public string CallerOAuthClientAppName {
			get {
				return GetTypedColumnValue<string>("CallerOAuthClientAppName");
			}
			set {
				SetColumnValue("CallerOAuthClientAppName", value);
				if (_callerOAuthClientApp != null) {
					_callerOAuthClientApp.Name = value;
				}
			}
		}

		private OAuthClientApp _callerOAuthClientApp;
		public OAuthClientApp CallerOAuthClientApp {
			get {
				return _callerOAuthClientApp ??
					(_callerOAuthClientApp = LookupColumnEntities.GetEntity("CallerOAuthClientApp") as OAuthClientApp);
			}
		}

		public DateTime IssuedAt {
			get {
				return GetTypedColumnValue<DateTime>("IssuedAt");
			}
			set {
				SetColumnValue("IssuedAt", value);
			}
		}

		public DateTime ExpiresAt {
			get {
				return GetTypedColumnValue<DateTime>("ExpiresAt");
			}
			set {
				SetColumnValue("ExpiresAt", value);
			}
		}

		public DateTime RevokedAt {
			get {
				return GetTypedColumnValue<DateTime>("RevokedAt");
			}
			set {
				SetColumnValue("RevokedAt", value);
			}
		}

		public string AccessTokenJti {
			get {
				return GetTypedColumnValue<string>("AccessTokenJti");
			}
			set {
				SetColumnValue("AccessTokenJti", value);
			}
		}

		public string Scope {
			get {
				return GetTypedColumnValue<string>("Scope");
			}
			set {
				SetColumnValue("Scope", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OAuthDelegationGrant_OAuth20EventsProcess(UserConnection);
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
			return new OAuthDelegationGrant(this);
		}

		#endregion

	}

	#endregion

	#region Class: OAuthDelegationGrant_OAuth20EventsProcess

	/// <exclude/>
	public partial class OAuthDelegationGrant_OAuth20EventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : OAuthDelegationGrant
	{

		public OAuthDelegationGrant_OAuth20EventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OAuthDelegationGrant_OAuth20EventsProcess";
			SchemaUId = new Guid("5c2b9f10-3d44-4e6a-9b22-0a1b2c3d4f01");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("5c2b9f10-3d44-4e6a-9b22-0a1b2c3d4f01");
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

	#region Class: OAuthDelegationGrant_OAuth20EventsProcess

	/// <exclude/>
	public class OAuthDelegationGrant_OAuth20EventsProcess : OAuthDelegationGrant_OAuth20EventsProcess<OAuthDelegationGrant>
	{

		public OAuthDelegationGrant_OAuth20EventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OAuthDelegationGrant_OAuth20EventsProcess

	public partial class OAuthDelegationGrant_OAuth20EventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: OAuthDelegationGrantEventsProcess

	/// <exclude/>
	public class OAuthDelegationGrantEventsProcess : OAuthDelegationGrant_OAuth20EventsProcess
	{

		public OAuthDelegationGrantEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

