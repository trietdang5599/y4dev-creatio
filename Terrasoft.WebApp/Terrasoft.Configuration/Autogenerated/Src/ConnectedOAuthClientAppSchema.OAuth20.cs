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

	#region Class: ConnectedOAuthClientAppSchema

	/// <exclude/>
	[IsVirtual]
	public class ConnectedOAuthClientAppSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ConnectedOAuthClientAppSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ConnectedOAuthClientAppSchema(ConnectedOAuthClientAppSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ConnectedOAuthClientAppSchema(ConnectedOAuthClientAppSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0c1659d6-7f93-4a73-b13f-4554450b4ad6");
			RealUId = new Guid("0c1659d6-7f93-4a73-b13f-4554450b4ad6");
			Name = "ConnectedOAuthClientApp";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("49af2168-effb-4b7f-bce2-28e45d430d96");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = false;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateNameColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializePrimaryImageColumn() {
			base.InitializePrimaryImageColumn();
			PrimaryImageColumn = CreateLogoColumn();
			if (Columns.FindByUId(PrimaryImageColumn.UId) == null) {
				Columns.Add(PrimaryImageColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("9506339f-09a5-1748-7cc1-dd7ab599a0b2")) == null) {
				Columns.Add(CreateActiveColumn());
			}
			if (Columns.FindByUId(new Guid("d35004f8-9205-2f2e-6a74-470ec9c8be3c")) == null) {
				Columns.Add(CreateAccessSharedOnColumn());
			}
			if (Columns.FindByUId(new Guid("ee49ce0f-5cae-ef69-0149-834e2bcdd402")) == null) {
				Columns.Add(CreateDescriptionColumn());
			}
			if (Columns.FindByUId(new Guid("05732138-8477-628b-3ae9-81682cf6c3fb")) == null) {
				Columns.Add(CreateApplicationUrlColumn());
			}
			if (Columns.FindByUId(new Guid("6aba8f8a-0e5c-0e2c-8ba8-37b19e518b6d")) == null) {
				Columns.Add(CreateClientIdColumn());
			}
			if (Columns.FindByUId(new Guid("307fdc68-01f7-3e41-878d-2585f6dc4bd0")) == null) {
				Columns.Add(CreateSysUserColumn());
			}
			if (Columns.FindByUId(new Guid("69a3a231-a932-f1f9-f974-f162287540c0")) == null) {
				Columns.Add(CreateAccessSharedColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateActiveColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("9506339f-09a5-1748-7cc1-dd7ab599a0b2"),
				Name = @"Active",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("0c1659d6-7f93-4a73-b13f-4554450b4ad6"),
				ModifiedInSchemaUId = new Guid("0c1659d6-7f93-4a73-b13f-4554450b4ad6"),
				CreatedInPackageId = new Guid("49af2168-effb-4b7f-bce2-28e45d430d96")
			};
		}

		protected virtual EntitySchemaColumn CreateAccessSharedOnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("d35004f8-9205-2f2e-6a74-470ec9c8be3c"),
				Name = @"AccessSharedOn",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("0c1659d6-7f93-4a73-b13f-4554450b4ad6"),
				ModifiedInSchemaUId = new Guid("0c1659d6-7f93-4a73-b13f-4554450b4ad6"),
				CreatedInPackageId = new Guid("49af2168-effb-4b7f-bce2-28e45d430d96")
			};
		}

		protected virtual EntitySchemaColumn CreateLogoColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ImageLookup")) {
				UId = new Guid("7cd51d73-be95-9057-db47-13300c4c52e6"),
				Name = @"Logo",
				ReferenceSchemaUId = new Guid("93986bfe-2dbd-46bc-9bf9-d03dfefbf3b8"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("0c1659d6-7f93-4a73-b13f-4554450b4ad6"),
				ModifiedInSchemaUId = new Guid("0c1659d6-7f93-4a73-b13f-4554450b4ad6"),
				CreatedInPackageId = new Guid("49af2168-effb-4b7f-bce2-28e45d430d96"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateDescriptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("ee49ce0f-5cae-ef69-0149-834e2bcdd402"),
				Name = @"Description",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("0c1659d6-7f93-4a73-b13f-4554450b4ad6"),
				ModifiedInSchemaUId = new Guid("0c1659d6-7f93-4a73-b13f-4554450b4ad6"),
				CreatedInPackageId = new Guid("49af2168-effb-4b7f-bce2-28e45d430d96")
			};
		}

		protected virtual EntitySchemaColumn CreateApplicationUrlColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("WebText")) {
				UId = new Guid("05732138-8477-628b-3ae9-81682cf6c3fb"),
				Name = @"ApplicationUrl",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("0c1659d6-7f93-4a73-b13f-4554450b4ad6"),
				ModifiedInSchemaUId = new Guid("0c1659d6-7f93-4a73-b13f-4554450b4ad6"),
				CreatedInPackageId = new Guid("49af2168-effb-4b7f-bce2-28e45d430d96")
			};
		}

		protected virtual EntitySchemaColumn CreateClientIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("6aba8f8a-0e5c-0e2c-8ba8-37b19e518b6d"),
				Name = @"ClientId",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("0c1659d6-7f93-4a73-b13f-4554450b4ad6"),
				ModifiedInSchemaUId = new Guid("0c1659d6-7f93-4a73-b13f-4554450b4ad6"),
				CreatedInPackageId = new Guid("49af2168-effb-4b7f-bce2-28e45d430d96")
			};
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("cb1da024-c6ec-6484-8339-36ca7661de11"),
				Name = @"Name",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("0c1659d6-7f93-4a73-b13f-4554450b4ad6"),
				ModifiedInSchemaUId = new Guid("0c1659d6-7f93-4a73-b13f-4554450b4ad6"),
				CreatedInPackageId = new Guid("49af2168-effb-4b7f-bce2-28e45d430d96")
			};
		}

		protected virtual EntitySchemaColumn CreateSysUserColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("307fdc68-01f7-3e41-878d-2585f6dc4bd0"),
				Name = @"SysUser",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("0c1659d6-7f93-4a73-b13f-4554450b4ad6"),
				ModifiedInSchemaUId = new Guid("0c1659d6-7f93-4a73-b13f-4554450b4ad6"),
				CreatedInPackageId = new Guid("49af2168-effb-4b7f-bce2-28e45d430d96"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateAccessSharedColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("69a3a231-a932-f1f9-f974-f162287540c0"),
				Name = @"AccessShared",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("0c1659d6-7f93-4a73-b13f-4554450b4ad6"),
				ModifiedInSchemaUId = new Guid("0c1659d6-7f93-4a73-b13f-4554450b4ad6"),
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
			return new ConnectedOAuthClientApp(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ConnectedOAuthClientApp_OAuth20EventsProcess(userConnection);
		}

		public override object Clone() {
			return new ConnectedOAuthClientAppSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ConnectedOAuthClientAppSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0c1659d6-7f93-4a73-b13f-4554450b4ad6"));
		}

		#endregion

	}

	#endregion

	#region Class: ConnectedOAuthClientApp

	/// <summary>
	/// Connected external applications.
	/// </summary>
	public class ConnectedOAuthClientApp : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ConnectedOAuthClientApp(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ConnectedOAuthClientApp";
		}

		public ConnectedOAuthClientApp(ConnectedOAuthClientApp source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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

		/// <summary>
		/// Access granted on.
		/// </summary>
		public DateTime AccessSharedOn {
			get {
				return GetTypedColumnValue<DateTime>("AccessSharedOn");
			}
			set {
				SetColumnValue("AccessSharedOn", value);
			}
		}

		/// <exclude/>
		public Guid LogoId {
			get {
				return GetTypedColumnValue<Guid>("LogoId");
			}
			set {
				SetColumnValue("LogoId", value);
				_logo = null;
			}
		}

		/// <exclude/>
		public string LogoName {
			get {
				return GetTypedColumnValue<string>("LogoName");
			}
			set {
				SetColumnValue("LogoName", value);
				if (_logo != null) {
					_logo.Name = value;
				}
			}
		}

		private SysImage _logo;
		/// <summary>
		/// Logo.
		/// </summary>
		public SysImage Logo {
			get {
				return _logo ??
					(_logo = LookupColumnEntities.GetEntity("Logo") as SysImage);
			}
		}

		/// <summary>
		/// Description.
		/// </summary>
		public string Description {
			get {
				return GetTypedColumnValue<string>("Description");
			}
			set {
				SetColumnValue("Description", value);
			}
		}

		/// <summary>
		/// Application URL.
		/// </summary>
		public string ApplicationUrl {
			get {
				return GetTypedColumnValue<string>("ApplicationUrl");
			}
			set {
				SetColumnValue("ApplicationUrl", value);
			}
		}

		/// <summary>
		/// Client Id.
		/// </summary>
		public string ClientId {
			get {
				return GetTypedColumnValue<string>("ClientId");
			}
			set {
				SetColumnValue("ClientId", value);
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
		/// Access granted.
		/// </summary>
		public bool AccessShared {
			get {
				return GetTypedColumnValue<bool>("AccessShared");
			}
			set {
				SetColumnValue("AccessShared", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ConnectedOAuthClientApp_OAuth20EventsProcess(UserConnection);
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
			return new ConnectedOAuthClientApp(this);
		}

		#endregion

	}

	#endregion

	#region Class: ConnectedOAuthClientApp_OAuth20EventsProcess

	/// <exclude/>
	public partial class ConnectedOAuthClientApp_OAuth20EventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : ConnectedOAuthClientApp
	{

		public ConnectedOAuthClientApp_OAuth20EventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ConnectedOAuthClientApp_OAuth20EventsProcess";
			SchemaUId = new Guid("0c1659d6-7f93-4a73-b13f-4554450b4ad6");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("0c1659d6-7f93-4a73-b13f-4554450b4ad6");
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

	#region Class: ConnectedOAuthClientApp_OAuth20EventsProcess

	/// <exclude/>
	public class ConnectedOAuthClientApp_OAuth20EventsProcess : ConnectedOAuthClientApp_OAuth20EventsProcess<ConnectedOAuthClientApp>
	{

		public ConnectedOAuthClientApp_OAuth20EventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ConnectedOAuthClientApp_OAuth20EventsProcess

	public partial class ConnectedOAuthClientApp_OAuth20EventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ConnectedOAuthClientAppEventsProcess

	/// <exclude/>
	public class ConnectedOAuthClientAppEventsProcess : ConnectedOAuthClientApp_OAuth20EventsProcess
	{

		public ConnectedOAuthClientAppEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

