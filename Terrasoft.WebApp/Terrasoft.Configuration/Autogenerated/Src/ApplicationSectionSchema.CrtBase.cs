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

	#region Class: ApplicationSectionSchema

	/// <exclude/>
	[IsVirtual]
	public class ApplicationSectionSchema : Terrasoft.Core.Entities.EntitySchema
	{

		#region Constructors: Public

		public ApplicationSectionSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ApplicationSectionSchema(ApplicationSectionSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ApplicationSectionSchema(ApplicationSectionSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("12a20dab-8fb7-464f-af4c-7cb5bf6e1f8d");
			RealUId = new Guid("12a20dab-8fb7-464f-af4c-7cb5bf6e1f8d");
			Name = "ApplicationSection";
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

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateCaptionColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("e222d9e3-9d8b-b489-db62-cb969726b935")) == null) {
				Columns.Add(CreateApplicationIdColumn());
			}
			if (Columns.FindByUId(new Guid("541d11ae-52f4-55c6-7b75-db60467790b8")) == null) {
				Columns.Add(CreateSchemaTypeColumn());
			}
			if (Columns.FindByUId(new Guid("070999ac-79ba-19b1-6c82-176b517a228d")) == null) {
				Columns.Add(CreateSectionSchemaUIdColumn());
			}
			if (Columns.FindByUId(new Guid("dac70b92-7fc8-59bd-22ce-8fad8b4a33b6")) == null) {
				Columns.Add(CreateCodeColumn());
			}
			if (Columns.FindByUId(new Guid("377c946b-d567-7fa0-6d9c-9e3d42e82822")) == null) {
				Columns.Add(CreateLogoIdColumn());
			}
			if (Columns.FindByUId(new Guid("6294424a-ff0d-a552-c9a4-106c17ec3b22")) == null) {
				Columns.Add(CreateTypeColumn());
			}
			if (Columns.FindByUId(new Guid("23812baa-f4bc-6eac-a98b-9e7a933f8e09")) == null) {
				Columns.Add(CreateDescriptionColumn());
			}
			if (Columns.FindByUId(new Guid("a838da6f-a251-df9a-c124-15534aeef0c5")) == null) {
				Columns.Add(CreateModifiedOnColumn());
			}
			if (Columns.FindByUId(new Guid("55a950dc-04d9-f174-0f39-23f87c1ca4a6")) == null) {
				Columns.Add(CreateEntitySchemaNameColumn());
			}
			if (Columns.FindByUId(new Guid("1a6be5b1-cc2d-b4fd-3eb5-978d2d108faa")) == null) {
				Columns.Add(CreateIconBackgroundColumn());
			}
			if (Columns.FindByUId(new Guid("60c7e536-b414-63cc-3f59-0dcb4c2d20db")) == null) {
				Columns.Add(CreatePackageIdColumn());
			}
			if (Columns.FindByUId(new Guid("895186fd-0bfd-19e8-0e31-fa498163a29b")) == null) {
				Columns.Add(CreateClientTypeIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateApplicationIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("e222d9e3-9d8b-b489-db62-cb969726b935"),
				Name = @"ApplicationId",
				CreatedInSchemaUId = new Guid("12a20dab-8fb7-464f-af4c-7cb5bf6e1f8d"),
				ModifiedInSchemaUId = new Guid("12a20dab-8fb7-464f-af4c-7cb5bf6e1f8d"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected virtual EntitySchemaColumn CreateCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("bb77df05-4141-81ae-05a1-37d8ba1f0abf"),
				Name = @"Caption",
				CreatedInSchemaUId = new Guid("12a20dab-8fb7-464f-af4c-7cb5bf6e1f8d"),
				ModifiedInSchemaUId = new Guid("12a20dab-8fb7-464f-af4c-7cb5bf6e1f8d"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("ae907638-8379-fc62-3309-011276491aaf"),
				Name = @"Id",
				CreatedInSchemaUId = new Guid("12a20dab-8fb7-464f-af4c-7cb5bf6e1f8d"),
				ModifiedInSchemaUId = new Guid("12a20dab-8fb7-464f-af4c-7cb5bf6e1f8d"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected virtual EntitySchemaColumn CreateSchemaTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("541d11ae-52f4-55c6-7b75-db60467790b8"),
				Name = @"SchemaType",
				CreatedInSchemaUId = new Guid("12a20dab-8fb7-464f-af4c-7cb5bf6e1f8d"),
				ModifiedInSchemaUId = new Guid("12a20dab-8fb7-464f-af4c-7cb5bf6e1f8d"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected virtual EntitySchemaColumn CreateSectionSchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("070999ac-79ba-19b1-6c82-176b517a228d"),
				Name = @"SectionSchemaUId",
				CreatedInSchemaUId = new Guid("12a20dab-8fb7-464f-af4c-7cb5bf6e1f8d"),
				ModifiedInSchemaUId = new Guid("12a20dab-8fb7-464f-af4c-7cb5bf6e1f8d"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected virtual EntitySchemaColumn CreateCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("dac70b92-7fc8-59bd-22ce-8fad8b4a33b6"),
				Name = @"Code",
				CreatedInSchemaUId = new Guid("12a20dab-8fb7-464f-af4c-7cb5bf6e1f8d"),
				ModifiedInSchemaUId = new Guid("12a20dab-8fb7-464f-af4c-7cb5bf6e1f8d"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected virtual EntitySchemaColumn CreateLogoIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("377c946b-d567-7fa0-6d9c-9e3d42e82822"),
				Name = @"LogoId",
				CreatedInSchemaUId = new Guid("12a20dab-8fb7-464f-af4c-7cb5bf6e1f8d"),
				ModifiedInSchemaUId = new Guid("12a20dab-8fb7-464f-af4c-7cb5bf6e1f8d"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected virtual EntitySchemaColumn CreateTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("6294424a-ff0d-a552-c9a4-106c17ec3b22"),
				Name = @"Type",
				CreatedInSchemaUId = new Guid("12a20dab-8fb7-464f-af4c-7cb5bf6e1f8d"),
				ModifiedInSchemaUId = new Guid("12a20dab-8fb7-464f-af4c-7cb5bf6e1f8d"),
				CreatedInPackageId = new Guid("a5664658-26d5-4600-862a-86467fd59244")
			};
		}

		protected virtual EntitySchemaColumn CreateDescriptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("23812baa-f4bc-6eac-a98b-9e7a933f8e09"),
				Name = @"Description",
				CreatedInSchemaUId = new Guid("12a20dab-8fb7-464f-af4c-7cb5bf6e1f8d"),
				ModifiedInSchemaUId = new Guid("12a20dab-8fb7-464f-af4c-7cb5bf6e1f8d"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected virtual EntitySchemaColumn CreateModifiedOnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("a838da6f-a251-df9a-c124-15534aeef0c5"),
				Name = @"ModifiedOn",
				CreatedInSchemaUId = new Guid("12a20dab-8fb7-464f-af4c-7cb5bf6e1f8d"),
				ModifiedInSchemaUId = new Guid("12a20dab-8fb7-464f-af4c-7cb5bf6e1f8d"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateEntitySchemaNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("55a950dc-04d9-f174-0f39-23f87c1ca4a6"),
				Name = @"EntitySchemaName",
				CreatedInSchemaUId = new Guid("12a20dab-8fb7-464f-af4c-7cb5bf6e1f8d"),
				ModifiedInSchemaUId = new Guid("12a20dab-8fb7-464f-af4c-7cb5bf6e1f8d"),
				CreatedInPackageId = new Guid("13b9c287-707b-4588-95dc-f40709dfb679")
			};
		}

		protected virtual EntitySchemaColumn CreateIconBackgroundColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("1a6be5b1-cc2d-b4fd-3eb5-978d2d108faa"),
				Name = @"IconBackground",
				CreatedInSchemaUId = new Guid("12a20dab-8fb7-464f-af4c-7cb5bf6e1f8d"),
				ModifiedInSchemaUId = new Guid("12a20dab-8fb7-464f-af4c-7cb5bf6e1f8d"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected virtual EntitySchemaColumn CreatePackageIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("60c7e536-b414-63cc-3f59-0dcb4c2d20db"),
				Name = @"PackageId",
				CreatedInSchemaUId = new Guid("12a20dab-8fb7-464f-af4c-7cb5bf6e1f8d"),
				ModifiedInSchemaUId = new Guid("12a20dab-8fb7-464f-af4c-7cb5bf6e1f8d"),
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723")
			};
		}

		protected virtual EntitySchemaColumn CreateClientTypeIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("895186fd-0bfd-19e8-0e31-fa498163a29b"),
				Name = @"ClientTypeId",
				CreatedInSchemaUId = new Guid("12a20dab-8fb7-464f-af4c-7cb5bf6e1f8d"),
				ModifiedInSchemaUId = new Guid("12a20dab-8fb7-464f-af4c-7cb5bf6e1f8d"),
				CreatedInPackageId = new Guid("acb004d0-c421-4dff-b075-f4fdc1c90074")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ApplicationSection(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ApplicationSection_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ApplicationSectionSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ApplicationSectionSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("12a20dab-8fb7-464f-af4c-7cb5bf6e1f8d"));
		}

		#endregion

	}

	#endregion

	#region Class: ApplicationSection

	/// <summary>
	/// Application section.
	/// </summary>
	public class ApplicationSection : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public ApplicationSection(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ApplicationSection";
		}

		public ApplicationSection(ApplicationSection source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Application Id.
		/// </summary>
		public Guid ApplicationId {
			get {
				return GetTypedColumnValue<Guid>("ApplicationId");
			}
			set {
				SetColumnValue("ApplicationId", value);
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
		/// Schema type.
		/// </summary>
		public string SchemaType {
			get {
				return GetTypedColumnValue<string>("SchemaType");
			}
			set {
				SetColumnValue("SchemaType", value);
			}
		}

		/// <summary>
		/// Section schema UId.
		/// </summary>
		public Guid SectionSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("SectionSchemaUId");
			}
			set {
				SetColumnValue("SectionSchemaUId", value);
			}
		}

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
		/// Logo id.
		/// </summary>
		public Guid LogoId {
			get {
				return GetTypedColumnValue<Guid>("LogoId");
			}
			set {
				SetColumnValue("LogoId", value);
			}
		}

		/// <summary>
		/// Type.
		/// </summary>
		public int Type {
			get {
				return GetTypedColumnValue<int>("Type");
			}
			set {
				SetColumnValue("Type", value);
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
		/// Entity schema name.
		/// </summary>
		public string EntitySchemaName {
			get {
				return GetTypedColumnValue<string>("EntitySchemaName");
			}
			set {
				SetColumnValue("EntitySchemaName", value);
			}
		}

		/// <summary>
		/// Icon background.
		/// </summary>
		/// <remarks>
		/// Icon background.
		/// </remarks>
		public string IconBackground {
			get {
				return GetTypedColumnValue<string>("IconBackground");
			}
			set {
				SetColumnValue("IconBackground", value);
			}
		}

		/// <summary>
		/// PackageId.
		/// </summary>
		public Guid PackageId {
			get {
				return GetTypedColumnValue<Guid>("PackageId");
			}
			set {
				SetColumnValue("PackageId", value);
			}
		}

		/// <summary>
		/// Application client type.
		/// </summary>
		public Guid ClientTypeId {
			get {
				return GetTypedColumnValue<Guid>("ClientTypeId");
			}
			set {
				SetColumnValue("ClientTypeId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ApplicationSection_CrtBaseEventsProcess(UserConnection);
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
			return new ApplicationSection(this);
		}

		#endregion

	}

	#endregion

	#region Class: ApplicationSection_CrtBaseEventsProcess

	/// <exclude/>
	public partial class ApplicationSection_CrtBaseEventsProcess<TEntity> : Terrasoft.Core.Process.EmbeddedProcess where TEntity : ApplicationSection
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

		public ApplicationSection_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ApplicationSection_CrtBaseEventsProcess";
			SchemaUId = new Guid("12a20dab-8fb7-464f-af4c-7cb5bf6e1f8d");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("12a20dab-8fb7-464f-af4c-7cb5bf6e1f8d");
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

	#region Class: ApplicationSection_CrtBaseEventsProcess

	/// <exclude/>
	public class ApplicationSection_CrtBaseEventsProcess : ApplicationSection_CrtBaseEventsProcess<ApplicationSection>
	{

		public ApplicationSection_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ApplicationSection_CrtBaseEventsProcess

	public partial class ApplicationSection_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ApplicationSectionEventsProcess

	/// <exclude/>
	public class ApplicationSectionEventsProcess : ApplicationSection_CrtBaseEventsProcess
	{

		public ApplicationSectionEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

