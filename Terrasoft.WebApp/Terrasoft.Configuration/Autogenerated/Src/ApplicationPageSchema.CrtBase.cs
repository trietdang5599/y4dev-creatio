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

	#region Class: ApplicationPageSchema

	/// <exclude/>
	[IsVirtual]
	public class ApplicationPageSchema : Terrasoft.Configuration.ApplicationSchemaSchema
	{

		#region Constructors: Public

		public ApplicationPageSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ApplicationPageSchema(ApplicationPageSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ApplicationPageSchema(ApplicationPageSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("6e3987b3-c3d6-4902-9ba7-4f28c6f8f029");
			RealUId = new Guid("6e3987b3-c3d6-4902-9ba7-4f28c6f8f029");
			Name = "ApplicationPage";
			ParentSchemaUId = new Guid("51fab605-6f0c-4ff7-8398-b933f6a09128");
			ExtendParent = false;
			CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("0e22d10d-38de-c1c1-0827-89ed74e20326")) == null) {
				Columns.Add(CreatePreviewImageColumn());
			}
			if (Columns.FindByUId(new Guid("0f6bb402-6c2b-52d3-77fe-89673b17ab96")) == null) {
				Columns.Add(CreateSchemaTypeColumn());
			}
		}

		protected override EntitySchemaColumn CreateCaptionColumn() {
			EntitySchemaColumn column = base.CreateCaptionColumn();
			column.IsLocalizable = true;
			column.ModifiedInSchemaUId = new Guid("6e3987b3-c3d6-4902-9ba7-4f28c6f8f029");
			return column;
		}

		protected virtual EntitySchemaColumn CreatePreviewImageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("0e22d10d-38de-c1c1-0827-89ed74e20326"),
				Name = @"PreviewImage",
				ReferenceSchemaUId = new Guid("93986bfe-2dbd-46bc-9bf9-d03dfefbf3b8"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("6e3987b3-c3d6-4902-9ba7-4f28c6f8f029"),
				ModifiedInSchemaUId = new Guid("6e3987b3-c3d6-4902-9ba7-4f28c6f8f029"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"c65fd9dc-80e2-4a03-8984-61b5a013de11"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateSchemaTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("0f6bb402-6c2b-52d3-77fe-89673b17ab96"),
				Name = @"SchemaType",
				CreatedInSchemaUId = new Guid("6e3987b3-c3d6-4902-9ba7-4f28c6f8f029"),
				ModifiedInSchemaUId = new Guid("6e3987b3-c3d6-4902-9ba7-4f28c6f8f029"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ApplicationPage(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ApplicationPage_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ApplicationPageSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ApplicationPageSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6e3987b3-c3d6-4902-9ba7-4f28c6f8f029"));
		}

		#endregion

	}

	#endregion

	#region Class: ApplicationPage

	/// <summary>
	/// Application page.
	/// </summary>
	public class ApplicationPage : Terrasoft.Configuration.ApplicationSchema
	{

		#region Constructors: Public

		public ApplicationPage(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ApplicationPage";
		}

		public ApplicationPage(ApplicationPage source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid PreviewImageId {
			get {
				return GetTypedColumnValue<Guid>("PreviewImageId");
			}
			set {
				SetColumnValue("PreviewImageId", value);
				_previewImage = null;
			}
		}

		/// <exclude/>
		public string PreviewImageName {
			get {
				return GetTypedColumnValue<string>("PreviewImageName");
			}
			set {
				SetColumnValue("PreviewImageName", value);
				if (_previewImage != null) {
					_previewImage.Name = value;
				}
			}
		}

		private SysImage _previewImage;
		/// <summary>
		/// PreviewImage.
		/// </summary>
		public SysImage PreviewImage {
			get {
				return _previewImage ??
					(_previewImage = LookupColumnEntities.GetEntity("PreviewImage") as SysImage);
			}
		}

		/// <summary>
		/// Client unit schema type.
		/// </summary>
		public int SchemaType {
			get {
				return GetTypedColumnValue<int>("SchemaType");
			}
			set {
				SetColumnValue("SchemaType", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ApplicationPage_CrtBaseEventsProcess(UserConnection);
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
			return new ApplicationPage(this);
		}

		#endregion

	}

	#endregion

	#region Class: ApplicationPage_CrtBaseEventsProcess

	/// <exclude/>
	public partial class ApplicationPage_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.ApplicationSchema_CrtBaseEventsProcess<TEntity> where TEntity : ApplicationPage
	{

		public ApplicationPage_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ApplicationPage_CrtBaseEventsProcess";
			SchemaUId = new Guid("6e3987b3-c3d6-4902-9ba7-4f28c6f8f029");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("6e3987b3-c3d6-4902-9ba7-4f28c6f8f029");
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

	#region Class: ApplicationPage_CrtBaseEventsProcess

	/// <exclude/>
	public class ApplicationPage_CrtBaseEventsProcess : ApplicationPage_CrtBaseEventsProcess<ApplicationPage>
	{

		public ApplicationPage_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ApplicationPage_CrtBaseEventsProcess

	public partial class ApplicationPage_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ApplicationPageEventsProcess

	/// <exclude/>
	public class ApplicationPageEventsProcess : ApplicationPage_CrtBaseEventsProcess
	{

		public ApplicationPageEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

