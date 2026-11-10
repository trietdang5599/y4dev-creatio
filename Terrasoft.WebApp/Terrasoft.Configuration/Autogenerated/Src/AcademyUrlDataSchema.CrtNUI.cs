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

	#region Class: AcademyUrlDataSchema

	/// <exclude/>
	[IsVirtual]
	public class AcademyUrlDataSchema : Terrasoft.Core.Entities.EntitySchema
	{

		#region Constructors: Public

		public AcademyUrlDataSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public AcademyUrlDataSchema(AcademyUrlDataSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public AcademyUrlDataSchema(AcademyUrlDataSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("6ebcd9a3-4075-c977-9ff2-0905420c2ee8");
			RealUId = new Guid("6ebcd9a3-4075-c977-9ff2-0905420c2ee8");
			Name = "AcademyUrlData";
			ParentSchemaUId = new Guid("1b56b061-4e91-4974-9038-df8340e534f2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("ee75749b-5184-4f75-a3ec-dd2e096c705e");
			IsDBView = false;
			UseDenyRecordRights = false;
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
			PrimaryDisplayColumn = CreateContextHelpIdColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("96c8943c-0046-8034-b640-567284d3d47a")) == null) {
				Columns.Add(CreateUseLmsDocumentationColumn());
			}
			if (Columns.FindByUId(new Guid("9d67317d-8393-94b0-7e9b-31925aa9f79d")) == null) {
				Columns.Add(CreateConfigurationVersionColumn());
			}
			if (Columns.FindByUId(new Guid("ff48e8bc-0811-7ef9-630c-0da7f0a93ec1")) == null) {
				Columns.Add(CreateProductEditionColumn());
			}
			if (Columns.FindByUId(new Guid("900e6c57-ba9c-fd9b-e463-46e8ab560a73")) == null) {
				Columns.Add(CreateEnableContextHelpColumn());
			}
			if (Columns.FindByUId(new Guid("a3997651-3d01-e060-f334-3f0d0e53601a")) == null) {
				Columns.Add(CreateLMSUrlColumn());
			}
			if (Columns.FindByUId(new Guid("f5589e0f-b171-42c8-9c8e-447a2ff1b611")) == null) {
				Columns.Add(CreateCodeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("e3449fea-35c6-c2e8-7cfd-4246960d49c3"),
				Name = @"Id",
				CreatedInSchemaUId = new Guid("6ebcd9a3-4075-c977-9ff2-0905420c2ee8"),
				ModifiedInSchemaUId = new Guid("6ebcd9a3-4075-c977-9ff2-0905420c2ee8"),
				CreatedInPackageId = new Guid("ee75749b-5184-4f75-a3ec-dd2e096c705e")
			};
		}

		protected virtual EntitySchemaColumn CreateUseLmsDocumentationColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("96c8943c-0046-8034-b640-567284d3d47a"),
				Name = @"UseLmsDocumentation",
				CreatedInSchemaUId = new Guid("6ebcd9a3-4075-c977-9ff2-0905420c2ee8"),
				ModifiedInSchemaUId = new Guid("6ebcd9a3-4075-c977-9ff2-0905420c2ee8"),
				CreatedInPackageId = new Guid("ee75749b-5184-4f75-a3ec-dd2e096c705e")
			};
		}

		protected virtual EntitySchemaColumn CreateConfigurationVersionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("9d67317d-8393-94b0-7e9b-31925aa9f79d"),
				Name = @"ConfigurationVersion",
				CreatedInSchemaUId = new Guid("6ebcd9a3-4075-c977-9ff2-0905420c2ee8"),
				ModifiedInSchemaUId = new Guid("6ebcd9a3-4075-c977-9ff2-0905420c2ee8"),
				CreatedInPackageId = new Guid("ee75749b-5184-4f75-a3ec-dd2e096c705e")
			};
		}

		protected virtual EntitySchemaColumn CreateProductEditionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("ff48e8bc-0811-7ef9-630c-0da7f0a93ec1"),
				Name = @"ProductEdition",
				CreatedInSchemaUId = new Guid("6ebcd9a3-4075-c977-9ff2-0905420c2ee8"),
				ModifiedInSchemaUId = new Guid("6ebcd9a3-4075-c977-9ff2-0905420c2ee8"),
				CreatedInPackageId = new Guid("ee75749b-5184-4f75-a3ec-dd2e096c705e")
			};
		}

		protected virtual EntitySchemaColumn CreateContextHelpIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("49637441-35e4-cdda-9400-c8085fc2da68"),
				Name = @"ContextHelpId",
				CreatedInSchemaUId = new Guid("6ebcd9a3-4075-c977-9ff2-0905420c2ee8"),
				ModifiedInSchemaUId = new Guid("6ebcd9a3-4075-c977-9ff2-0905420c2ee8"),
				CreatedInPackageId = new Guid("ee75749b-5184-4f75-a3ec-dd2e096c705e")
			};
		}

		protected virtual EntitySchemaColumn CreateEnableContextHelpColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("900e6c57-ba9c-fd9b-e463-46e8ab560a73"),
				Name = @"EnableContextHelp",
				CreatedInSchemaUId = new Guid("6ebcd9a3-4075-c977-9ff2-0905420c2ee8"),
				ModifiedInSchemaUId = new Guid("6ebcd9a3-4075-c977-9ff2-0905420c2ee8"),
				CreatedInPackageId = new Guid("ee75749b-5184-4f75-a3ec-dd2e096c705e")
			};
		}

		protected virtual EntitySchemaColumn CreateLMSUrlColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("a3997651-3d01-e060-f334-3f0d0e53601a"),
				Name = @"LMSUrl",
				CreatedInSchemaUId = new Guid("6ebcd9a3-4075-c977-9ff2-0905420c2ee8"),
				ModifiedInSchemaUId = new Guid("6ebcd9a3-4075-c977-9ff2-0905420c2ee8"),
				CreatedInPackageId = new Guid("ee75749b-5184-4f75-a3ec-dd2e096c705e")
			};
		}

		protected virtual EntitySchemaColumn CreateCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("f5589e0f-b171-42c8-9c8e-447a2ff1b611"),
				Name = @"Code",
				CreatedInSchemaUId = new Guid("6ebcd9a3-4075-c977-9ff2-0905420c2ee8"),
				ModifiedInSchemaUId = new Guid("6ebcd9a3-4075-c977-9ff2-0905420c2ee8"),
				CreatedInPackageId = new Guid("ee75749b-5184-4f75-a3ec-dd2e096c705e")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new AcademyUrlData(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new AcademyUrlData_CrtNUIEventsProcess(userConnection);
		}

		public override object Clone() {
			return new AcademyUrlDataSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new AcademyUrlDataSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6ebcd9a3-4075-c977-9ff2-0905420c2ee8"));
		}

		#endregion

	}

	#endregion

	#region Class: AcademyUrlData

	/// <summary>
	/// Academy URL data.
	/// </summary>
	public class AcademyUrlData : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public AcademyUrlData(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "AcademyUrlData";
		}

		public AcademyUrlData(AcademyUrlData source)
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
		/// Use Lms documentation.
		/// </summary>
		public bool UseLmsDocumentation {
			get {
				return GetTypedColumnValue<bool>("UseLmsDocumentation");
			}
			set {
				SetColumnValue("UseLmsDocumentation", value);
			}
		}

		/// <summary>
		/// Configuration Version.
		/// </summary>
		public string ConfigurationVersion {
			get {
				return GetTypedColumnValue<string>("ConfigurationVersion");
			}
			set {
				SetColumnValue("ConfigurationVersion", value);
			}
		}

		/// <summary>
		/// Product Edition.
		/// </summary>
		public string ProductEdition {
			get {
				return GetTypedColumnValue<string>("ProductEdition");
			}
			set {
				SetColumnValue("ProductEdition", value);
			}
		}

		/// <summary>
		/// Context Help Id.
		/// </summary>
		public string ContextHelpId {
			get {
				return GetTypedColumnValue<string>("ContextHelpId");
			}
			set {
				SetColumnValue("ContextHelpId", value);
			}
		}

		/// <summary>
		/// Enable context help.
		/// </summary>
		public bool EnableContextHelp {
			get {
				return GetTypedColumnValue<bool>("EnableContextHelp");
			}
			set {
				SetColumnValue("EnableContextHelp", value);
			}
		}

		/// <summary>
		/// Lms Url.
		/// </summary>
		public string LMSUrl {
			get {
				return GetTypedColumnValue<string>("LMSUrl");
			}
			set {
				SetColumnValue("LMSUrl", value);
			}
		}

		/// <summary>
		/// Context Help Code.
		/// </summary>
		public string Code {
			get {
				return GetTypedColumnValue<string>("Code");
			}
			set {
				SetColumnValue("Code", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new AcademyUrlData_CrtNUIEventsProcess(UserConnection);
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
			return new AcademyUrlData(this);
		}

		#endregion

	}

	#endregion

	#region Class: AcademyUrlData_CrtNUIEventsProcess

	/// <exclude/>
	public partial class AcademyUrlData_CrtNUIEventsProcess<TEntity> : Terrasoft.Core.Process.EmbeddedProcess where TEntity : AcademyUrlData
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

		public AcademyUrlData_CrtNUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "AcademyUrlData_CrtNUIEventsProcess";
			SchemaUId = new Guid("6ebcd9a3-4075-c977-9ff2-0905420c2ee8");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("6ebcd9a3-4075-c977-9ff2-0905420c2ee8");
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

	#region Class: AcademyUrlData_CrtNUIEventsProcess

	/// <exclude/>
	public class AcademyUrlData_CrtNUIEventsProcess : AcademyUrlData_CrtNUIEventsProcess<AcademyUrlData>
	{

		public AcademyUrlData_CrtNUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: AcademyUrlData_CrtNUIEventsProcess

	public partial class AcademyUrlData_CrtNUIEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: AcademyUrlDataEventsProcess

	/// <exclude/>
	public class AcademyUrlDataEventsProcess : AcademyUrlData_CrtNUIEventsProcess
	{

		public AcademyUrlDataEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

