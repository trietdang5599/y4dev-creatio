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

	#region Class: SysAppTemplateInfoItemSchema

	/// <exclude/>
	public class SysAppTemplateInfoItemSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysAppTemplateInfoItemSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysAppTemplateInfoItemSchema(SysAppTemplateInfoItemSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysAppTemplateInfoItemSchema(SysAppTemplateInfoItemSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("bf3678b3-63d8-4e11-849d-f07534e0fe2b");
			RealUId = new Guid("bf3678b3-63d8-4e11-849d-f07534e0fe2b");
			Name = "SysAppTemplateInfoItem";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
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
			if (Columns.FindByUId(new Guid("34cf7344-0961-493d-cc6e-1ae06739b0d9")) == null) {
				Columns.Add(CreatePositionColumn());
			}
			if (Columns.FindByUId(new Guid("3f0a76c5-82ee-51e7-6936-4407ad81351c")) == null) {
				Columns.Add(CreateSysAppTemplateColumn());
			}
			if (Columns.FindByUId(new Guid("a48edb68-a4c4-f55d-af8d-baa612c1e325")) == null) {
				Columns.Add(CreateImageColumn());
			}
			if (Columns.FindByUId(new Guid("80cef8fa-628f-d5e5-1219-c1a7c7bc4ac7")) == null) {
				Columns.Add(CreateDescriptionColumn());
			}
		}

		protected virtual EntitySchemaColumn CreatePositionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("34cf7344-0961-493d-cc6e-1ae06739b0d9"),
				Name = @"Position",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("bf3678b3-63d8-4e11-849d-f07534e0fe2b"),
				ModifiedInSchemaUId = new Guid("bf3678b3-63d8-4e11-849d-f07534e0fe2b"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"0"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateSysAppTemplateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("3f0a76c5-82ee-51e7-6936-4407ad81351c"),
				Name = @"SysAppTemplate",
				ReferenceSchemaUId = new Guid("97e71819-5bc7-45a7-b0d9-f22f154dd0e2"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("bf3678b3-63d8-4e11-849d-f07534e0fe2b"),
				ModifiedInSchemaUId = new Guid("bf3678b3-63d8-4e11-849d-f07534e0fe2b"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected virtual EntitySchemaColumn CreateImageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("a48edb68-a4c4-f55d-af8d-baa612c1e325"),
				Name = @"Image",
				ReferenceSchemaUId = new Guid("93986bfe-2dbd-46bc-9bf9-d03dfefbf3b8"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("bf3678b3-63d8-4e11-849d-f07534e0fe2b"),
				ModifiedInSchemaUId = new Guid("bf3678b3-63d8-4e11-849d-f07534e0fe2b"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected virtual EntitySchemaColumn CreateDescriptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("80cef8fa-628f-d5e5-1219-c1a7c7bc4ac7"),
				Name = @"Description",
				CreatedInSchemaUId = new Guid("bf3678b3-63d8-4e11-849d-f07534e0fe2b"),
				ModifiedInSchemaUId = new Guid("bf3678b3-63d8-4e11-849d-f07534e0fe2b"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("0914a653-3927-250a-fc34-647d9b234fcf"),
				Name = @"Name",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("bf3678b3-63d8-4e11-849d-f07534e0fe2b"),
				ModifiedInSchemaUId = new Guid("bf3678b3-63d8-4e11-849d-f07534e0fe2b"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f"),
				IsLocalizable = true
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysAppTemplateInfoItem(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysAppTemplateInfoItem_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysAppTemplateInfoItemSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysAppTemplateInfoItemSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("bf3678b3-63d8-4e11-849d-f07534e0fe2b"));
		}

		#endregion

	}

	#endregion

	#region Class: SysAppTemplateInfoItem

	/// <summary>
	/// Application template info item.
	/// </summary>
	public class SysAppTemplateInfoItem : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysAppTemplateInfoItem(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysAppTemplateInfoItem";
		}

		public SysAppTemplateInfoItem(SysAppTemplateInfoItem source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Position.
		/// </summary>
		public int Position {
			get {
				return GetTypedColumnValue<int>("Position");
			}
			set {
				SetColumnValue("Position", value);
			}
		}

		/// <exclude/>
		public Guid SysAppTemplateId {
			get {
				return GetTypedColumnValue<Guid>("SysAppTemplateId");
			}
			set {
				SetColumnValue("SysAppTemplateId", value);
				_sysAppTemplate = null;
			}
		}

		/// <exclude/>
		public string SysAppTemplateName {
			get {
				return GetTypedColumnValue<string>("SysAppTemplateName");
			}
			set {
				SetColumnValue("SysAppTemplateName", value);
				if (_sysAppTemplate != null) {
					_sysAppTemplate.Name = value;
				}
			}
		}

		private SysAppTemplate _sysAppTemplate;
		/// <summary>
		/// Application template.
		/// </summary>
		public SysAppTemplate SysAppTemplate {
			get {
				return _sysAppTemplate ??
					(_sysAppTemplate = LookupColumnEntities.GetEntity("SysAppTemplate") as SysAppTemplate);
			}
		}

		/// <exclude/>
		public Guid ImageId {
			get {
				return GetTypedColumnValue<Guid>("ImageId");
			}
			set {
				SetColumnValue("ImageId", value);
				_image = null;
			}
		}

		/// <exclude/>
		public string ImageName {
			get {
				return GetTypedColumnValue<string>("ImageName");
			}
			set {
				SetColumnValue("ImageName", value);
				if (_image != null) {
					_image.Name = value;
				}
			}
		}

		private SysImage _image;
		/// <summary>
		/// Image.
		/// </summary>
		public SysImage Image {
			get {
				return _image ??
					(_image = LookupColumnEntities.GetEntity("Image") as SysImage);
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

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysAppTemplateInfoItem_CrtBaseEventsProcess(UserConnection);
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
			return new SysAppTemplateInfoItem(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysAppTemplateInfoItem_CrtBaseEventsProcess

	/// <exclude/>
	public partial class SysAppTemplateInfoItem_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysAppTemplateInfoItem
	{

		public SysAppTemplateInfoItem_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysAppTemplateInfoItem_CrtBaseEventsProcess";
			SchemaUId = new Guid("bf3678b3-63d8-4e11-849d-f07534e0fe2b");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("bf3678b3-63d8-4e11-849d-f07534e0fe2b");
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

	#region Class: SysAppTemplateInfoItem_CrtBaseEventsProcess

	/// <exclude/>
	public class SysAppTemplateInfoItem_CrtBaseEventsProcess : SysAppTemplateInfoItem_CrtBaseEventsProcess<SysAppTemplateInfoItem>
	{

		public SysAppTemplateInfoItem_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysAppTemplateInfoItem_CrtBaseEventsProcess

	public partial class SysAppTemplateInfoItem_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysAppTemplateInfoItemEventsProcess

	/// <exclude/>
	public class SysAppTemplateInfoItemEventsProcess : SysAppTemplateInfoItem_CrtBaseEventsProcess
	{

		public SysAppTemplateInfoItemEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

