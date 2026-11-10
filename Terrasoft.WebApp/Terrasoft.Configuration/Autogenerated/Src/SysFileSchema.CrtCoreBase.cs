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
	using Terrasoft.Configuration;
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

	#region Class: SysFile_CrtCoreBase_CreatioSchema

	/// <exclude/>
	public class SysFile_CrtCoreBase_CreatioSchema : Terrasoft.Configuration.FileSchema
	{

		#region Constructors: Public

		public SysFile_CrtCoreBase_CreatioSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysFile_CrtCoreBase_CreatioSchema(SysFile_CrtCoreBase_CreatioSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysFile_CrtCoreBase_CreatioSchema(SysFile_CrtCoreBase_CreatioSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("70ec5d9f-a55e-4f5c-8f59-30d2c5149c4a");
			RealUId = new Guid("70ec5d9f-a55e-4f5c-8f59-30d2c5149c4a");
			Name = "SysFile_CrtCoreBase_Creatio";
			ParentSchemaUId = new Guid("556c5867-60a7-4456-aae1-a57a122bef70");
			ExtendParent = false;
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
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
			RightSchemaName = @"SystemFileRight";
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("789fa023-8511-adc3-cb3d-4c1e67c6db5a")) == null) {
				Columns.Add(CreateRecordSchemaNameColumn());
			}
			if (Columns.FindByUId(new Guid("5d2bc4fd-dcd0-2e6a-d194-76812388ad13")) == null) {
				Columns.Add(CreateRecordIdColumn());
			}
			if (Columns.FindByUId(new Guid("a86980d7-9467-e8f5-fe45-deb9ef94cdc0")) == null) {
				Columns.Add(CreateToDeleteColumn());
			}
			if (Columns.FindByUId(new Guid("a593d15e-97a2-ee24-8562-57ea10c21943")) == null) {
				Columns.Add(CreateLastErrorColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateRecordSchemaNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("789fa023-8511-adc3-cb3d-4c1e67c6db5a"),
				Name = @"RecordSchemaName",
				CreatedInSchemaUId = new Guid("70ec5d9f-a55e-4f5c-8f59-30d2c5149c4a"),
				ModifiedInSchemaUId = new Guid("70ec5d9f-a55e-4f5c-8f59-30d2c5149c4a"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateRecordIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("5d2bc4fd-dcd0-2e6a-d194-76812388ad13"),
				Name = @"RecordId",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("70ec5d9f-a55e-4f5c-8f59-30d2c5149c4a"),
				ModifiedInSchemaUId = new Guid("70ec5d9f-a55e-4f5c-8f59-30d2c5149c4a"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateToDeleteColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("a86980d7-9467-e8f5-fe45-deb9ef94cdc0"),
				Name = @"ToDelete",
				CreatedInSchemaUId = new Guid("70ec5d9f-a55e-4f5c-8f59-30d2c5149c4a"),
				ModifiedInSchemaUId = new Guid("70ec5d9f-a55e-4f5c-8f59-30d2c5149c4a"),
				CreatedInPackageId = new Guid("acb004d0-c421-4dff-b075-f4fdc1c90074")
			};
		}

		protected virtual EntitySchemaColumn CreateLastErrorColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("a593d15e-97a2-ee24-8562-57ea10c21943"),
				Name = @"LastError",
				CreatedInSchemaUId = new Guid("70ec5d9f-a55e-4f5c-8f59-30d2c5149c4a"),
				ModifiedInSchemaUId = new Guid("70ec5d9f-a55e-4f5c-8f59-30d2c5149c4a"),
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
			return new SysFile_CrtCoreBase_Creatio(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysFile_CrtCoreBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysFile_CrtCoreBase_CreatioSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysFile_CrtCoreBase_CreatioSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("70ec5d9f-a55e-4f5c-8f59-30d2c5149c4a"));
		}

		#endregion

	}

	#endregion

	#region Class: SysFile_CrtCoreBase_Creatio

	/// <summary>
	/// Uploaded file.
	/// </summary>
	public class SysFile_CrtCoreBase_Creatio : Terrasoft.Configuration.File
	{

		#region Constructors: Public

		public SysFile_CrtCoreBase_Creatio(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysFile_CrtCoreBase_Creatio";
		}

		public SysFile_CrtCoreBase_Creatio(SysFile_CrtCoreBase_Creatio source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Record schema name.
		/// </summary>
		public string RecordSchemaName {
			get {
				return GetTypedColumnValue<string>("RecordSchemaName");
			}
			set {
				SetColumnValue("RecordSchemaName", value);
			}
		}

		/// <summary>
		/// Record Id.
		/// </summary>
		public Guid RecordId {
			get {
				return GetTypedColumnValue<Guid>("RecordId");
			}
			set {
				SetColumnValue("RecordId", value);
			}
		}

		/// <summary>
		/// To delete.
		/// </summary>
		public bool ToDelete {
			get {
				return GetTypedColumnValue<bool>("ToDelete");
			}
			set {
				SetColumnValue("ToDelete", value);
			}
		}

		/// <summary>
		/// Last error.
		/// </summary>
		public string LastError {
			get {
				return GetTypedColumnValue<string>("LastError");
			}
			set {
				SetColumnValue("LastError", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysFile_CrtCoreBaseEventsProcess(UserConnection);
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
			return new SysFile_CrtCoreBase_Creatio(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysFile_CrtCoreBaseEventsProcess

	/// <exclude/>
	public partial class SysFile_CrtCoreBaseEventsProcess<TEntity> : Terrasoft.Configuration.File_LinkPreviewEventsProcess<TEntity> where TEntity : SysFile_CrtCoreBase_Creatio
	{

		public SysFile_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysFile_CrtCoreBaseEventsProcess";
			SchemaUId = new Guid("70ec5d9f-a55e-4f5c-8f59-30d2c5149c4a");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("70ec5d9f-a55e-4f5c-8f59-30d2c5149c4a");
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

	#region Class: SysFile_CrtCoreBaseEventsProcess

	/// <exclude/>
	public class SysFile_CrtCoreBaseEventsProcess : SysFile_CrtCoreBaseEventsProcess<SysFile_CrtCoreBase_Creatio>
	{

		public SysFile_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysFile_CrtCoreBaseEventsProcess

	public partial class SysFile_CrtCoreBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

