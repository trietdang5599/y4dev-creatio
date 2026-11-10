namespace Terrasoft.Configuration
{

	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.IO;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;

	#region Class: ApplicationSchemaSchema

	/// <exclude/>
	[IsVirtual]
	public class ApplicationSchemaSchema : Terrasoft.Core.Entities.EntitySchema
	{

		#region Constructors: Public

		public ApplicationSchemaSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ApplicationSchemaSchema(ApplicationSchemaSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ApplicationSchemaSchema(ApplicationSchemaSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("51fab605-6f0c-4ff7-8398-b933f6a09128");
			RealUId = new Guid("51fab605-6f0c-4ff7-8398-b933f6a09128");
			Name = "ApplicationSchema";
			ParentSchemaUId = new Guid("1b56b061-4e91-4974-9038-df8340e534f2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryColumn() {
			base.InitializePrimaryColumn();
			PrimaryColumn = CreateIdColumn();
			if (Columns.FindByUId(PrimaryColumn.UId) == null) {
				Columns.Add(PrimaryColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("f5fd2219-389e-3e60-e95c-dc22be46d406")) == null) {
				Columns.Add(CreatePackageUIdColumn());
			}
			if (Columns.FindByUId(new Guid("14ac57c1-5195-558b-ef35-4fa49d31bb23")) == null) {
				Columns.Add(CreateUIdColumn());
			}
			if (Columns.FindByUId(new Guid("d8eb7579-e1c4-3e88-b0eb-094d967c9091")) == null) {
				Columns.Add(CreateModifiedOnColumn());
			}
			if (Columns.FindByUId(new Guid("6eb5acae-3d96-0bf5-4d99-87d116ef914c")) == null) {
				Columns.Add(CreateCaptionColumn());
			}
			if (Columns.FindByUId(new Guid("251fc201-caf9-3f60-75a5-4ef63df7d403")) == null) {
				Columns.Add(CreateNameColumn());
			}
			if (Columns.FindByUId(new Guid("44e4b2a2-7b6b-37ad-e441-6c77a1f4d2d9")) == null) {
				Columns.Add(CreateApplicationColumn());
			}
			if (Columns.FindByUId(new Guid("b954fdf8-e061-162c-42c6-e997686069c8")) == null) {
				Columns.Add(CreatePackageColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("5a25e41d-f073-771a-0eb2-2da08ca742a2"),
				Name = @"Id",
				CreatedInSchemaUId = new Guid("51fab605-6f0c-4ff7-8398-b933f6a09128"),
				ModifiedInSchemaUId = new Guid("51fab605-6f0c-4ff7-8398-b933f6a09128"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected virtual EntitySchemaColumn CreatePackageUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("f5fd2219-389e-3e60-e95c-dc22be46d406"),
				Name = @"PackageUId",
				CreatedInSchemaUId = new Guid("51fab605-6f0c-4ff7-8398-b933f6a09128"),
				ModifiedInSchemaUId = new Guid("51fab605-6f0c-4ff7-8398-b933f6a09128"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected virtual EntitySchemaColumn CreateUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("14ac57c1-5195-558b-ef35-4fa49d31bb23"),
				Name = @"UId",
				CreatedInSchemaUId = new Guid("51fab605-6f0c-4ff7-8398-b933f6a09128"),
				ModifiedInSchemaUId = new Guid("51fab605-6f0c-4ff7-8398-b933f6a09128"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected virtual EntitySchemaColumn CreateModifiedOnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("d8eb7579-e1c4-3e88-b0eb-094d967c9091"),
				Name = @"ModifiedOn",
				CreatedInSchemaUId = new Guid("51fab605-6f0c-4ff7-8398-b933f6a09128"),
				ModifiedInSchemaUId = new Guid("51fab605-6f0c-4ff7-8398-b933f6a09128"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected virtual EntitySchemaColumn CreateCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("6eb5acae-3d96-0bf5-4d99-87d116ef914c"),
				Name = @"Caption",
				CreatedInSchemaUId = new Guid("51fab605-6f0c-4ff7-8398-b933f6a09128"),
				ModifiedInSchemaUId = new Guid("51fab605-6f0c-4ff7-8398-b933f6a09128"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("251fc201-caf9-3f60-75a5-4ef63df7d403"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("51fab605-6f0c-4ff7-8398-b933f6a09128"),
				ModifiedInSchemaUId = new Guid("51fab605-6f0c-4ff7-8398-b933f6a09128"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected virtual EntitySchemaColumn CreateApplicationColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("44e4b2a2-7b6b-37ad-e441-6c77a1f4d2d9"),
				Name = @"Application",
				ReferenceSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("51fab605-6f0c-4ff7-8398-b933f6a09128"),
				ModifiedInSchemaUId = new Guid("51fab605-6f0c-4ff7-8398-b933f6a09128"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreatePackageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("b954fdf8-e061-162c-42c6-e997686069c8"),
				Name = @"Package",
				ReferenceSchemaUId = new Guid("ca400a85-ec48-4b42-8e50-271929d27871"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("51fab605-6f0c-4ff7-8398-b933f6a09128"),
				ModifiedInSchemaUId = new Guid("51fab605-6f0c-4ff7-8398-b933f6a09128"),
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723"),
				IsSimpleLookup = true
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ApplicationSchema(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ApplicationSchema_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ApplicationSchemaSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ApplicationSchemaSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("51fab605-6f0c-4ff7-8398-b933f6a09128"));
		}

		#endregion

	}

	#endregion

	#region Class: ApplicationSchema

	/// <summary>
	/// Application schema.
	/// </summary>
	public class ApplicationSchema : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public ApplicationSchema(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ApplicationSchema";
		}

		public ApplicationSchema(ApplicationSchema source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Id.
		/// </summary>
		public Guid Id {
			get {
				return GetTypedColumnValue<Guid>("Id");
			}
			set {
				SetColumnValue("Id", value);
			}
		}

		/// <summary>
		/// PackageUId.
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
		/// UId.
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
		/// ModifiedOn.
		/// </summary>
		public DateTime ModifiedOn {
			get {
				return GetTypedColumnValue<DateTime>("ModifiedOn");
			}
			set {
				SetColumnValue("ModifiedOn", value);
			}
		}

		/// <summary>
		/// Caption.
		/// </summary>
		public string Caption {
			get {
				return GetTypedColumnValue<string>("Caption");
			}
			set {
				SetColumnValue("Caption", value);
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
		public Guid ApplicationId {
			get {
				return GetTypedColumnValue<Guid>("ApplicationId");
			}
			set {
				SetColumnValue("ApplicationId", value);
				_application = null;
			}
		}

		/// <exclude/>
		public string ApplicationName {
			get {
				return GetTypedColumnValue<string>("ApplicationName");
			}
			set {
				SetColumnValue("ApplicationName", value);
				if (_application != null) {
					_application.Name = value;
				}
			}
		}

		private SysInstalledApp _application;
		/// <summary>
		/// Application.
		/// </summary>
		public SysInstalledApp Application {
			get {
				return _application ??
					(_application = LookupColumnEntities.GetEntity("Application") as SysInstalledApp);
			}
		}

		/// <exclude/>
		public Guid PackageId {
			get {
				return GetTypedColumnValue<Guid>("PackageId");
			}
			set {
				SetColumnValue("PackageId", value);
				_package = null;
			}
		}

		/// <exclude/>
		public string PackageName {
			get {
				return GetTypedColumnValue<string>("PackageName");
			}
			set {
				SetColumnValue("PackageName", value);
				if (_package != null) {
					_package.Name = value;
				}
			}
		}

		private SysPackage _package;
		/// <summary>
		/// Package.
		/// </summary>
		public SysPackage Package {
			get {
				return _package ??
					(_package = LookupColumnEntities.GetEntity("Package") as SysPackage);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ApplicationSchema_CrtBaseEventsProcess(UserConnection);
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
			return new ApplicationSchema(this);
		}

		#endregion

	}

	#endregion

	#region Class: ApplicationSchema_CrtBaseEventsProcess

	/// <exclude/>
	public partial class ApplicationSchema_CrtBaseEventsProcess<TEntity> : Terrasoft.Core.Process.EmbeddedProcess where TEntity : ApplicationSchema
	{

		private TEntity _entity;
		public TEntity Entity {
			get {
				return _entity;
			}
			set {
				_entity = value;
			}
		}

		public ApplicationSchema_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ApplicationSchema_CrtBaseEventsProcess";
			SchemaUId = new Guid("51fab605-6f0c-4ff7-8398-b933f6a09128");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("51fab605-6f0c-4ff7-8398-b933f6a09128");
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

	#region Class: ApplicationSchema_CrtBaseEventsProcess

	/// <exclude/>
	public class ApplicationSchema_CrtBaseEventsProcess : ApplicationSchema_CrtBaseEventsProcess<ApplicationSchema>
	{

		public ApplicationSchema_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ApplicationSchema_CrtBaseEventsProcess

	public partial class ApplicationSchema_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ApplicationSchemaEventsProcess

	/// <exclude/>
	public class ApplicationSchemaEventsProcess : ApplicationSchema_CrtBaseEventsProcess
	{

		public ApplicationSchemaEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

