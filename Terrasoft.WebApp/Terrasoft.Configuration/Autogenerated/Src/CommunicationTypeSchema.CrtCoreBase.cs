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

	#region Class: CommunicationType_CrtCoreBase_CreatioSchema

	/// <exclude/>
	public class CommunicationType_CrtCoreBase_CreatioSchema : Terrasoft.Configuration.BaseImageLookupSchema
	{

		#region Constructors: Public

		public CommunicationType_CrtCoreBase_CreatioSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CommunicationType_CrtCoreBase_CreatioSchema(CommunicationType_CrtCoreBase_CreatioSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CommunicationType_CrtCoreBase_CreatioSchema(CommunicationType_CrtCoreBase_CreatioSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d846cb4f-f18d-469e-83ff-e961f3fba873");
			RealUId = new Guid("d846cb4f-f18d-469e-83ff-e961f3fba873");
			Name = "CommunicationType_CrtCoreBase_Creatio";
			ParentSchemaUId = new Guid("b4a781bd-bacd-4ba1-a16b-48c09a21f087");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
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
			if (Columns.FindByUId(new Guid("0da3b0de-9d19-47e8-89e4-e113dde44a8c")) == null) {
				Columns.Add(CreateHyperlinkTemplateColumn());
			}
			if (Columns.FindByUId(new Guid("9583d17a-064d-402d-bdb1-7d377628d64b")) == null) {
				Columns.Add(CreateUseforAccountsColumn());
			}
			if (Columns.FindByUId(new Guid("07748e81-b1d1-4cdb-9e41-d5e0be2e13d9")) == null) {
				Columns.Add(CreateUseforContactsColumn());
			}
			if (Columns.FindByUId(new Guid("a292e328-3ae0-5f4b-aa43-2cac81b9f2a7")) == null) {
				Columns.Add(CreateImageLinkColumn());
			}
			if (Columns.FindByUId(new Guid("3fb6cbe6-a28d-058b-c946-bc899d193fc2")) == null) {
				Columns.Add(CreateDisplayFormatColumn());
			}
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("d846cb4f-f18d-469e-83ff-e961f3fba873");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("d846cb4f-f18d-469e-83ff-e961f3fba873");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override EntitySchemaColumn CreateImageColumn() {
			EntitySchemaColumn column = base.CreateImageColumn();
			column.ModifiedInSchemaUId = new Guid("d846cb4f-f18d-469e-83ff-e961f3fba873");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected virtual EntitySchemaColumn CreateHyperlinkTemplateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("0da3b0de-9d19-47e8-89e4-e113dde44a8c"),
				Name = @"HyperlinkTemplate",
				CreatedInSchemaUId = new Guid("d846cb4f-f18d-469e-83ff-e961f3fba873"),
				ModifiedInSchemaUId = new Guid("d846cb4f-f18d-469e-83ff-e961f3fba873"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateUseforAccountsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("9583d17a-064d-402d-bdb1-7d377628d64b"),
				Name = @"UseforAccounts",
				CreatedInSchemaUId = new Guid("d846cb4f-f18d-469e-83ff-e961f3fba873"),
				ModifiedInSchemaUId = new Guid("d846cb4f-f18d-469e-83ff-e961f3fba873"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateUseforContactsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("07748e81-b1d1-4cdb-9e41-d5e0be2e13d9"),
				Name = @"UseforContacts",
				CreatedInSchemaUId = new Guid("d846cb4f-f18d-469e-83ff-e961f3fba873"),
				ModifiedInSchemaUId = new Guid("d846cb4f-f18d-469e-83ff-e961f3fba873"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateImageLinkColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ImageLookup")) {
				UId = new Guid("a292e328-3ae0-5f4b-aa43-2cac81b9f2a7"),
				Name = @"ImageLink",
				ReferenceSchemaUId = new Guid("93986bfe-2dbd-46bc-9bf9-d03dfefbf3b8"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("d846cb4f-f18d-469e-83ff-e961f3fba873"),
				ModifiedInSchemaUId = new Guid("d846cb4f-f18d-469e-83ff-e961f3fba873"),
				CreatedInPackageId = new Guid("acb004d0-c421-4dff-b075-f4fdc1c90074")
			};
		}

		protected virtual EntitySchemaColumn CreateDisplayFormatColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("3fb6cbe6-a28d-058b-c946-bc899d193fc2"),
				Name = @"DisplayFormat",
				CreatedInSchemaUId = new Guid("d846cb4f-f18d-469e-83ff-e961f3fba873"),
				ModifiedInSchemaUId = new Guid("d846cb4f-f18d-469e-83ff-e961f3fba873"),
				CreatedInPackageId = new Guid("acb004d0-c421-4dff-b075-f4fdc1c90074"),
				IsFormatValidated = true,
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"text"
				}
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new CommunicationType_CrtCoreBase_Creatio(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CommunicationType_CrtCoreBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CommunicationType_CrtCoreBase_CreatioSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CommunicationType_CrtCoreBase_CreatioSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d846cb4f-f18d-469e-83ff-e961f3fba873"));
		}

		#endregion

	}

	#endregion

	#region Class: CommunicationType_CrtCoreBase_Creatio

	/// <summary>
	/// Communication option type.
	/// </summary>
	public class CommunicationType_CrtCoreBase_Creatio : Terrasoft.Configuration.BaseImageLookup
	{

		#region Constructors: Public

		public CommunicationType_CrtCoreBase_Creatio(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CommunicationType_CrtCoreBase_Creatio";
		}

		public CommunicationType_CrtCoreBase_Creatio(CommunicationType_CrtCoreBase_Creatio source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Template for creating a hyperlink in text.
		/// </summary>
		public string HyperlinkTemplate {
			get {
				return GetTypedColumnValue<string>("HyperlinkTemplate");
			}
			set {
				SetColumnValue("HyperlinkTemplate", value);
			}
		}

		/// <summary>
		/// Use for accounts.
		/// </summary>
		public bool UseforAccounts {
			get {
				return GetTypedColumnValue<bool>("UseforAccounts");
			}
			set {
				SetColumnValue("UseforAccounts", value);
			}
		}

		/// <summary>
		/// Use for contacts.
		/// </summary>
		public bool UseforContacts {
			get {
				return GetTypedColumnValue<bool>("UseforContacts");
			}
			set {
				SetColumnValue("UseforContacts", value);
			}
		}

		/// <exclude/>
		public Guid ImageLinkId {
			get {
				return GetTypedColumnValue<Guid>("ImageLinkId");
			}
			set {
				SetColumnValue("ImageLinkId", value);
				_imageLink = null;
			}
		}

		/// <exclude/>
		public string ImageLinkName {
			get {
				return GetTypedColumnValue<string>("ImageLinkName");
			}
			set {
				SetColumnValue("ImageLinkName", value);
				if (_imageLink != null) {
					_imageLink.Name = value;
				}
			}
		}

		private SysImage _imageLink;
		/// <summary>
		/// Image.
		/// </summary>
		/// <remarks>
		/// Only .svg images allowed.
		/// </remarks>
		public SysImage ImageLink {
			get {
				return _imageLink ??
					(_imageLink = LookupColumnEntities.GetEntity("ImageLink") as SysImage);
			}
		}

		/// <summary>
		/// Display format.
		/// </summary>
		public string DisplayFormat {
			get {
				return GetTypedColumnValue<string>("DisplayFormat");
			}
			set {
				SetColumnValue("DisplayFormat", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CommunicationType_CrtCoreBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("CommunicationType_CrtCoreBase_CreatioDeleted", e);
			Deleting += (s, e) => ThrowEvent("CommunicationType_CrtCoreBase_CreatioDeleting", e);
			Inserted += (s, e) => ThrowEvent("CommunicationType_CrtCoreBase_CreatioInserted", e);
			Inserting += (s, e) => ThrowEvent("CommunicationType_CrtCoreBase_CreatioInserting", e);
			Saved += (s, e) => ThrowEvent("CommunicationType_CrtCoreBase_CreatioSaved", e);
			Saving += (s, e) => ThrowEvent("CommunicationType_CrtCoreBase_CreatioSaving", e);
			Validating += (s, e) => ThrowEvent("CommunicationType_CrtCoreBase_CreatioValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new CommunicationType_CrtCoreBase_Creatio(this);
		}

		#endregion

	}

	#endregion

	#region Class: CommunicationType_CrtCoreBaseEventsProcess

	/// <exclude/>
	public partial class CommunicationType_CrtCoreBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseImageLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : CommunicationType_CrtCoreBase_Creatio
	{

		public CommunicationType_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CommunicationType_CrtCoreBaseEventsProcess";
			SchemaUId = new Guid("d846cb4f-f18d-469e-83ff-e961f3fba873");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("d846cb4f-f18d-469e-83ff-e961f3fba873");
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

	#region Class: CommunicationType_CrtCoreBaseEventsProcess

	/// <exclude/>
	public class CommunicationType_CrtCoreBaseEventsProcess : CommunicationType_CrtCoreBaseEventsProcess<CommunicationType_CrtCoreBase_Creatio>
	{

		public CommunicationType_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CommunicationType_CrtCoreBaseEventsProcess

	public partial class CommunicationType_CrtCoreBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void CheckCanManageLookups() {
		}

		#endregion

	}

	#endregion

}

