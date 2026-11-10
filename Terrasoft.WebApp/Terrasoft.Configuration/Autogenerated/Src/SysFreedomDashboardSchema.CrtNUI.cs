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

	#region Class: SysFreedomDashboardSchema

	/// <exclude/>
	[IsVirtual]
	public class SysFreedomDashboardSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysFreedomDashboardSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysFreedomDashboardSchema(SysFreedomDashboardSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysFreedomDashboardSchema(SysFreedomDashboardSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c263cc98-19cb-4c96-8f5c-72b4485c592e");
			RealUId = new Guid("c263cc98-19cb-4c96-8f5c-72b4485c592e");
			Name = "SysFreedomDashboard";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("0c6d5769-8079-4d44-b72c-713dda089a12");
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

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("ad367aad-d3c7-53a8-e9df-feda58843fb5")) == null) {
				Columns.Add(CreateCodeColumn());
			}
			if (Columns.FindByUId(new Guid("2ac45d5e-5023-c87e-5840-d5fc63302599")) == null) {
				Columns.Add(CreateDashboardsElementNameColumn());
			}
			if (Columns.FindByUId(new Guid("94398e50-01ae-684f-f9b9-8f29280c2ccf")) == null) {
				Columns.Add(CreatePackageUIdColumn());
			}
			if (Columns.FindByUId(new Guid("e01ba49d-715d-d92a-e38b-d202eba06d41")) == null) {
				Columns.Add(CreateExtendParentColumn());
			}
			if (Columns.FindByUId(new Guid("1621cad0-ad2f-96f7-5260-db40af71f92b")) == null) {
				Columns.Add(CreateDashboardsEntitySchemaNameColumn());
			}
			if (Columns.FindByUId(new Guid("429d77c0-8d0b-7a4e-ec39-4215873f05c6")) == null) {
				Columns.Add(CreateUserLevelSchemaColumn());
			}
			if (Columns.FindByUId(new Guid("2742129a-d786-2100-b1bb-a6fd2648ace9")) == null) {
				Columns.Add(CreateUIdColumn());
			}
			if (Columns.FindByUId(new Guid("cd462262-6181-7f72-06f2-3e923cfd021f")) == null) {
				Columns.Add(CreateDashboardsClientUnitSchemaUIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("ad367aad-d3c7-53a8-e9df-feda58843fb5"),
				Name = @"Code",
				CreatedInSchemaUId = new Guid("c263cc98-19cb-4c96-8f5c-72b4485c592e"),
				ModifiedInSchemaUId = new Guid("c263cc98-19cb-4c96-8f5c-72b4485c592e"),
				CreatedInPackageId = new Guid("0c6d5769-8079-4d44-b72c-713dda089a12")
			};
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("f4efb896-7d9a-ede9-b99a-32b5dee9da2c"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("c263cc98-19cb-4c96-8f5c-72b4485c592e"),
				ModifiedInSchemaUId = new Guid("c263cc98-19cb-4c96-8f5c-72b4485c592e"),
				CreatedInPackageId = new Guid("0c6d5769-8079-4d44-b72c-713dda089a12")
			};
		}

		protected virtual EntitySchemaColumn CreateDashboardsElementNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("2ac45d5e-5023-c87e-5840-d5fc63302599"),
				Name = @"DashboardsElementName",
				CreatedInSchemaUId = new Guid("c263cc98-19cb-4c96-8f5c-72b4485c592e"),
				ModifiedInSchemaUId = new Guid("c263cc98-19cb-4c96-8f5c-72b4485c592e"),
				CreatedInPackageId = new Guid("0c6d5769-8079-4d44-b72c-713dda089a12")
			};
		}

		protected virtual EntitySchemaColumn CreatePackageUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("94398e50-01ae-684f-f9b9-8f29280c2ccf"),
				Name = @"PackageUId",
				CreatedInSchemaUId = new Guid("c263cc98-19cb-4c96-8f5c-72b4485c592e"),
				ModifiedInSchemaUId = new Guid("c263cc98-19cb-4c96-8f5c-72b4485c592e"),
				CreatedInPackageId = new Guid("0c6d5769-8079-4d44-b72c-713dda089a12")
			};
		}

		protected virtual EntitySchemaColumn CreateExtendParentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("e01ba49d-715d-d92a-e38b-d202eba06d41"),
				Name = @"ExtendParent",
				CreatedInSchemaUId = new Guid("c263cc98-19cb-4c96-8f5c-72b4485c592e"),
				ModifiedInSchemaUId = new Guid("c263cc98-19cb-4c96-8f5c-72b4485c592e"),
				CreatedInPackageId = new Guid("0c6d5769-8079-4d44-b72c-713dda089a12")
			};
		}

		protected virtual EntitySchemaColumn CreateDashboardsEntitySchemaNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("1621cad0-ad2f-96f7-5260-db40af71f92b"),
				Name = @"DashboardsEntitySchemaName",
				CreatedInSchemaUId = new Guid("c263cc98-19cb-4c96-8f5c-72b4485c592e"),
				ModifiedInSchemaUId = new Guid("c263cc98-19cb-4c96-8f5c-72b4485c592e"),
				CreatedInPackageId = new Guid("cb307258-3a76-44c9-ba03-f25bdd404252")
			};
		}

		protected virtual EntitySchemaColumn CreateUserLevelSchemaColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("429d77c0-8d0b-7a4e-ec39-4215873f05c6"),
				Name = @"UserLevelSchema",
				CreatedInSchemaUId = new Guid("c263cc98-19cb-4c96-8f5c-72b4485c592e"),
				ModifiedInSchemaUId = new Guid("c263cc98-19cb-4c96-8f5c-72b4485c592e"),
				CreatedInPackageId = new Guid("cb307258-3a76-44c9-ba03-f25bdd404252")
			};
		}

		protected virtual EntitySchemaColumn CreateUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("2742129a-d786-2100-b1bb-a6fd2648ace9"),
				Name = @"UId",
				CreatedInSchemaUId = new Guid("c263cc98-19cb-4c96-8f5c-72b4485c592e"),
				ModifiedInSchemaUId = new Guid("c263cc98-19cb-4c96-8f5c-72b4485c592e"),
				CreatedInPackageId = new Guid("cb307258-3a76-44c9-ba03-f25bdd404252")
			};
		}

		protected virtual EntitySchemaColumn CreateDashboardsClientUnitSchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("cd462262-6181-7f72-06f2-3e923cfd021f"),
				Name = @"DashboardsClientUnitSchemaUId",
				CreatedInSchemaUId = new Guid("c263cc98-19cb-4c96-8f5c-72b4485c592e"),
				ModifiedInSchemaUId = new Guid("c263cc98-19cb-4c96-8f5c-72b4485c592e"),
				CreatedInPackageId = new Guid("cb307258-3a76-44c9-ba03-f25bdd404252")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysFreedomDashboard(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysFreedomDashboard_CrtNUIEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysFreedomDashboardSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysFreedomDashboardSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c263cc98-19cb-4c96-8f5c-72b4485c592e"));
		}

		#endregion

	}

	#endregion

	#region Class: SysFreedomDashboard

	/// <summary>
	/// Dashboard.
	/// </summary>
	public class SysFreedomDashboard : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysFreedomDashboard(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysFreedomDashboard";
		}

		public SysFreedomDashboard(SysFreedomDashboard source)
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
		/// Dashboards element name.
		/// </summary>
		public string DashboardsElementName {
			get {
				return GetTypedColumnValue<string>("DashboardsElementName");
			}
			set {
				SetColumnValue("DashboardsElementName", value);
			}
		}

		/// <summary>
		/// Package.
		/// </summary>
		public Guid PackageUId {
			get {
				return GetTypedColumnValue<Guid>("PackageUId");
			}
			set {
				SetColumnValue("PackageUId", value);
			}
		}

		/// <summary>
		/// Replace parent.
		/// </summary>
		public bool ExtendParent {
			get {
				return GetTypedColumnValue<bool>("ExtendParent");
			}
			set {
				SetColumnValue("ExtendParent", value);
			}
		}

		/// <summary>
		/// Dashboards entity schema name.
		/// </summary>
		public string DashboardsEntitySchemaName {
			get {
				return GetTypedColumnValue<string>("DashboardsEntitySchemaName");
			}
			set {
				SetColumnValue("DashboardsEntitySchemaName", value);
			}
		}

		/// <summary>
		/// User level schema.
		/// </summary>
		public bool UserLevelSchema {
			get {
				return GetTypedColumnValue<bool>("UserLevelSchema");
			}
			set {
				SetColumnValue("UserLevelSchema", value);
			}
		}

		/// <summary>
		/// Schema UId.
		/// </summary>
		public Guid UId {
			get {
				return GetTypedColumnValue<Guid>("UId");
			}
			set {
				SetColumnValue("UId", value);
			}
		}

		/// <summary>
		/// Dashboards сlient unit schema UId.
		/// </summary>
		public Guid DashboardsClientUnitSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("DashboardsClientUnitSchemaUId");
			}
			set {
				SetColumnValue("DashboardsClientUnitSchemaUId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysFreedomDashboard_CrtNUIEventsProcess(UserConnection);
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
			return new SysFreedomDashboard(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysFreedomDashboard_CrtNUIEventsProcess

	/// <exclude/>
	public partial class SysFreedomDashboard_CrtNUIEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysFreedomDashboard
	{

		public SysFreedomDashboard_CrtNUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysFreedomDashboard_CrtNUIEventsProcess";
			SchemaUId = new Guid("c263cc98-19cb-4c96-8f5c-72b4485c592e");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("c263cc98-19cb-4c96-8f5c-72b4485c592e");
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

	#region Class: SysFreedomDashboard_CrtNUIEventsProcess

	/// <exclude/>
	public class SysFreedomDashboard_CrtNUIEventsProcess : SysFreedomDashboard_CrtNUIEventsProcess<SysFreedomDashboard>
	{

		public SysFreedomDashboard_CrtNUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysFreedomDashboard_CrtNUIEventsProcess

	public partial class SysFreedomDashboard_CrtNUIEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysFreedomDashboardEventsProcess

	/// <exclude/>
	public class SysFreedomDashboardEventsProcess : SysFreedomDashboard_CrtNUIEventsProcess
	{

		public SysFreedomDashboardEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

