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

	#region Class: OAuthTokenExchangeTrustedClientAppSchema

	/// <exclude/>
	public class OAuthTokenExchangeTrustedClientAppSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public OAuthTokenExchangeTrustedClientAppSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OAuthTokenExchangeTrustedClientAppSchema(OAuthTokenExchangeTrustedClientAppSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OAuthTokenExchangeTrustedClientAppSchema(OAuthTokenExchangeTrustedClientAppSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateOAuthTokenExchangeTrustedClientAppUniquePairIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = true
			};
			index.UId = new Guid("7e0d1a40-9c1f-4b2a-8e51-0a1b2c3d4e30");
			index.Name = "OAuthTokenExchangeTrustedClientAppUniquePair";
			index.CreatedInSchemaUId = new Guid("7e0d1a40-9c1f-4b2a-8e51-0a1b2c3d4e01");
			index.ModifiedInSchemaUId = new Guid("7e0d1a40-9c1f-4b2a-8e51-0a1b2c3d4e01");
			index.CreatedInPackageId = new Guid("49af2168-effb-4b7f-bce2-28e45d430d96");
			EntitySchemaIndexColumn oAuthClientAppIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("7e0d1a40-9c1f-4b2a-8e51-0a1b2c3d4e31"),
				ColumnUId = new Guid("7e0d1a40-9c1f-4b2a-8e51-0a1b2c3d4e21"),
				CreatedInSchemaUId = new Guid("7e0d1a40-9c1f-4b2a-8e51-0a1b2c3d4e01"),
				ModifiedInSchemaUId = new Guid("7e0d1a40-9c1f-4b2a-8e51-0a1b2c3d4e01"),
				CreatedInPackageId = new Guid("49af2168-effb-4b7f-bce2-28e45d430d96"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(oAuthClientAppIdIndexColumn);
			EntitySchemaIndexColumn sysUserIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("7e0d1a40-9c1f-4b2a-8e51-0a1b2c3d4e32"),
				ColumnUId = new Guid("7e0d1a40-9c1f-4b2a-8e51-0a1b2c3d4e20"),
				CreatedInSchemaUId = new Guid("7e0d1a40-9c1f-4b2a-8e51-0a1b2c3d4e01"),
				ModifiedInSchemaUId = new Guid("7e0d1a40-9c1f-4b2a-8e51-0a1b2c3d4e01"),
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
			UId = new Guid("7e0d1a40-9c1f-4b2a-8e51-0a1b2c3d4e01");
			RealUId = new Guid("7e0d1a40-9c1f-4b2a-8e51-0a1b2c3d4e01");
			Name = "OAuthTokenExchangeTrustedClientApp";
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
			if (Columns.FindByUId(new Guid("7e0d1a40-9c1f-4b2a-8e51-0a1b2c3d4e20")) == null) {
				Columns.Add(CreateSysUserColumn());
			}
			if (Columns.FindByUId(new Guid("7e0d1a40-9c1f-4b2a-8e51-0a1b2c3d4e21")) == null) {
				Columns.Add(CreateOAuthClientAppColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysUserColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("7e0d1a40-9c1f-4b2a-8e51-0a1b2c3d4e20"),
				Name = @"SysUser",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("7e0d1a40-9c1f-4b2a-8e51-0a1b2c3d4e01"),
				ModifiedInSchemaUId = new Guid("7e0d1a40-9c1f-4b2a-8e51-0a1b2c3d4e01"),
				CreatedInPackageId = new Guid("49af2168-effb-4b7f-bce2-28e45d430d96"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateOAuthClientAppColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("7e0d1a40-9c1f-4b2a-8e51-0a1b2c3d4e21"),
				Name = @"OAuthClientApp",
				ReferenceSchemaUId = new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("7e0d1a40-9c1f-4b2a-8e51-0a1b2c3d4e01"),
				ModifiedInSchemaUId = new Guid("7e0d1a40-9c1f-4b2a-8e51-0a1b2c3d4e01"),
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
			Indexes.Add(CreateOAuthTokenExchangeTrustedClientAppUniquePairIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new OAuthTokenExchangeTrustedClientApp(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OAuthTokenExchangeTrustedClientApp_OAuth20EventsProcess(userConnection);
		}

		public override object Clone() {
			return new OAuthTokenExchangeTrustedClientAppSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OAuthTokenExchangeTrustedClientAppSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7e0d1a40-9c1f-4b2a-8e51-0a1b2c3d4e01"));
		}

		#endregion

	}

	#endregion

	#region Class: OAuthTokenExchangeTrustedClientApp

	/// <summary>
	/// Base object.
	/// </summary>
	public class OAuthTokenExchangeTrustedClientApp : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public OAuthTokenExchangeTrustedClientApp(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OAuthTokenExchangeTrustedClientApp";
		}

		public OAuthTokenExchangeTrustedClientApp(OAuthTokenExchangeTrustedClientApp source)
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

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OAuthTokenExchangeTrustedClientApp_OAuth20EventsProcess(UserConnection);
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
			return new OAuthTokenExchangeTrustedClientApp(this);
		}

		#endregion

	}

	#endregion

	#region Class: OAuthTokenExchangeTrustedClientApp_OAuth20EventsProcess

	/// <exclude/>
	public partial class OAuthTokenExchangeTrustedClientApp_OAuth20EventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : OAuthTokenExchangeTrustedClientApp
	{

		public OAuthTokenExchangeTrustedClientApp_OAuth20EventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OAuthTokenExchangeTrustedClientApp_OAuth20EventsProcess";
			SchemaUId = new Guid("7e0d1a40-9c1f-4b2a-8e51-0a1b2c3d4e01");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("7e0d1a40-9c1f-4b2a-8e51-0a1b2c3d4e01");
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

	#region Class: OAuthTokenExchangeTrustedClientApp_OAuth20EventsProcess

	/// <exclude/>
	public class OAuthTokenExchangeTrustedClientApp_OAuth20EventsProcess : OAuthTokenExchangeTrustedClientApp_OAuth20EventsProcess<OAuthTokenExchangeTrustedClientApp>
	{

		public OAuthTokenExchangeTrustedClientApp_OAuth20EventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OAuthTokenExchangeTrustedClientApp_OAuth20EventsProcess

	public partial class OAuthTokenExchangeTrustedClientApp_OAuth20EventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: OAuthTokenExchangeTrustedClientAppEventsProcess

	/// <exclude/>
	public class OAuthTokenExchangeTrustedClientAppEventsProcess : OAuthTokenExchangeTrustedClientApp_OAuth20EventsProcess
	{

		public OAuthTokenExchangeTrustedClientAppEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

