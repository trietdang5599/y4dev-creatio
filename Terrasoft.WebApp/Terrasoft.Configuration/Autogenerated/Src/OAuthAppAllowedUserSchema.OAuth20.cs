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

	#region Class: OAuthAppAllowedUserSchema

	/// <exclude/>
	public class OAuthAppAllowedUserSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public OAuthAppAllowedUserSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OAuthAppAllowedUserSchema(OAuthAppAllowedUserSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OAuthAppAllowedUserSchema(OAuthAppAllowedUserSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateOAuthAppAllowedUserUniquePairIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("92294447-29df-432b-bb76-358cc26c13d6");
			index.Name = "OAuthAppAllowedUserUniquePair";
			index.CreatedInSchemaUId = new Guid("c5da8445-797a-4afd-bc9a-8600a0955a26");
			index.ModifiedInSchemaUId = new Guid("c5da8445-797a-4afd-bc9a-8600a0955a26");
			index.CreatedInPackageId = new Guid("49af2168-effb-4b7f-bce2-28e45d430d96");
			EntitySchemaIndexColumn oAuthClientAppIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("29ed65f7-df69-33a3-8bb0-d86336560327"),
				ColumnUId = new Guid("7784e127-6b94-de11-50f7-4d7854e2664c"),
				CreatedInSchemaUId = new Guid("c5da8445-797a-4afd-bc9a-8600a0955a26"),
				ModifiedInSchemaUId = new Guid("c5da8445-797a-4afd-bc9a-8600a0955a26"),
				CreatedInPackageId = new Guid("49af2168-effb-4b7f-bce2-28e45d430d96"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(oAuthClientAppIdIndexColumn);
			EntitySchemaIndexColumn sysUserIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("3196cfc1-3434-15b5-2d58-3eb02ceb8ead"),
				ColumnUId = new Guid("e5343492-7bcf-7cf9-b15a-97e5b3bbd27f"),
				CreatedInSchemaUId = new Guid("c5da8445-797a-4afd-bc9a-8600a0955a26"),
				ModifiedInSchemaUId = new Guid("c5da8445-797a-4afd-bc9a-8600a0955a26"),
				CreatedInPackageId = new Guid("49af2168-effb-4b7f-bce2-28e45d430d96"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(sysUserIdIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c5da8445-797a-4afd-bc9a-8600a0955a26");
			RealUId = new Guid("c5da8445-797a-4afd-bc9a-8600a0955a26");
			Name = "OAuthAppAllowedUser";
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
			if (Columns.FindByUId(new Guid("7784e127-6b94-de11-50f7-4d7854e2664c")) == null) {
				Columns.Add(CreateOAuthClientAppColumn());
			}
			if (Columns.FindByUId(new Guid("e5343492-7bcf-7cf9-b15a-97e5b3bbd27f")) == null) {
				Columns.Add(CreateSysUserColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateOAuthClientAppColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("7784e127-6b94-de11-50f7-4d7854e2664c"),
				Name = @"OAuthClientApp",
				ReferenceSchemaUId = new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("c5da8445-797a-4afd-bc9a-8600a0955a26"),
				ModifiedInSchemaUId = new Guid("c5da8445-797a-4afd-bc9a-8600a0955a26"),
				CreatedInPackageId = new Guid("49af2168-effb-4b7f-bce2-28e45d430d96"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateSysUserColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e5343492-7bcf-7cf9-b15a-97e5b3bbd27f"),
				Name = @"SysUser",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("c5da8445-797a-4afd-bc9a-8600a0955a26"),
				ModifiedInSchemaUId = new Guid("c5da8445-797a-4afd-bc9a-8600a0955a26"),
				CreatedInPackageId = new Guid("49af2168-effb-4b7f-bce2-28e45d430d96"),
				IsSimpleLookup = true
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateOAuthAppAllowedUserUniquePairIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new OAuthAppAllowedUser(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OAuthAppAllowedUser_OAuth20EventsProcess(userConnection);
		}

		public override object Clone() {
			return new OAuthAppAllowedUserSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OAuthAppAllowedUserSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c5da8445-797a-4afd-bc9a-8600a0955a26"));
		}

		#endregion

	}

	#endregion

	#region Class: OAuthAppAllowedUser

	/// <summary>
	/// OAuth client app allowed user.
	/// </summary>
	public class OAuthAppAllowedUser : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public OAuthAppAllowedUser(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OAuthAppAllowedUser";
		}

		public OAuthAppAllowedUser(OAuthAppAllowedUser source)
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

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OAuthAppAllowedUser_OAuth20EventsProcess(UserConnection);
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
			return new OAuthAppAllowedUser(this);
		}

		#endregion

	}

	#endregion

	#region Class: OAuthAppAllowedUser_OAuth20EventsProcess

	/// <exclude/>
	public partial class OAuthAppAllowedUser_OAuth20EventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : OAuthAppAllowedUser
	{

		public OAuthAppAllowedUser_OAuth20EventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OAuthAppAllowedUser_OAuth20EventsProcess";
			SchemaUId = new Guid("c5da8445-797a-4afd-bc9a-8600a0955a26");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("c5da8445-797a-4afd-bc9a-8600a0955a26");
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

	#region Class: OAuthAppAllowedUser_OAuth20EventsProcess

	/// <exclude/>
	public class OAuthAppAllowedUser_OAuth20EventsProcess : OAuthAppAllowedUser_OAuth20EventsProcess<OAuthAppAllowedUser>
	{

		public OAuthAppAllowedUser_OAuth20EventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OAuthAppAllowedUser_OAuth20EventsProcess

	public partial class OAuthAppAllowedUser_OAuth20EventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: OAuthAppAllowedUserEventsProcess

	/// <exclude/>
	public class OAuthAppAllowedUserEventsProcess : OAuthAppAllowedUser_OAuth20EventsProcess
	{

		public OAuthAppAllowedUserEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

