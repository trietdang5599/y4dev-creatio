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

	#region Class: Desktop_CrtUIv2_CreatioSchema

	/// <exclude/>
	public class Desktop_CrtUIv2_CreatioSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public Desktop_CrtUIv2_CreatioSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Desktop_CrtUIv2_CreatioSchema(Desktop_CrtUIv2_CreatioSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Desktop_CrtUIv2_CreatioSchema(Desktop_CrtUIv2_CreatioSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d2a75817-ac9a-4c95-bcaf-bd2e237bf11c");
			RealUId = new Guid("d2a75817-ac9a-4c95-bcaf-bd2e237bf11c");
			Name = "Desktop_CrtUIv2_Creatio";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("f4e67bb8-a45c-4fad-9829-cd5fbcd9c40f");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateTitleColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("6e3bf11b-4374-7162-1c58-765220d82b39")) == null) {
				Columns.Add(CreateDesktopSchemaNameColumn());
			}
			if (Columns.FindByUId(new Guid("dac94e49-4b76-c94f-ec0a-a4ad01fa595e")) == null) {
				Columns.Add(CreateSchemaUIdColumn());
			}
			if (Columns.FindByUId(new Guid("ff7f6a08-034a-3552-44a0-2f1948a271ad")) == null) {
				Columns.Add(CreateSchemaRealUIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateTitleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("fae07e8b-55ee-0491-a814-2012ea476a78"),
				Name = @"Title",
				CreatedInSchemaUId = new Guid("d2a75817-ac9a-4c95-bcaf-bd2e237bf11c"),
				ModifiedInSchemaUId = new Guid("d2a75817-ac9a-4c95-bcaf-bd2e237bf11c"),
				CreatedInPackageId = new Guid("f4e67bb8-a45c-4fad-9829-cd5fbcd9c40f"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateDesktopSchemaNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("6e3bf11b-4374-7162-1c58-765220d82b39"),
				Name = @"DesktopSchemaName",
				CreatedInSchemaUId = new Guid("d2a75817-ac9a-4c95-bcaf-bd2e237bf11c"),
				ModifiedInSchemaUId = new Guid("d2a75817-ac9a-4c95-bcaf-bd2e237bf11c"),
				CreatedInPackageId = new Guid("f4e67bb8-a45c-4fad-9829-cd5fbcd9c40f")
			};
		}

		protected virtual EntitySchemaColumn CreateSchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("dac94e49-4b76-c94f-ec0a-a4ad01fa595e"),
				Name = @"SchemaUId",
				CreatedInSchemaUId = new Guid("d2a75817-ac9a-4c95-bcaf-bd2e237bf11c"),
				ModifiedInSchemaUId = new Guid("d2a75817-ac9a-4c95-bcaf-bd2e237bf11c"),
				CreatedInPackageId = new Guid("b31a9a60-0e8b-4cb1-9b7e-d30387f0f7b1")
			};
		}

		protected virtual EntitySchemaColumn CreateSchemaRealUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("ff7f6a08-034a-3552-44a0-2f1948a271ad"),
				Name = @"SchemaRealUId",
				CreatedInSchemaUId = new Guid("d2a75817-ac9a-4c95-bcaf-bd2e237bf11c"),
				ModifiedInSchemaUId = new Guid("d2a75817-ac9a-4c95-bcaf-bd2e237bf11c"),
				CreatedInPackageId = new Guid("b31a9a60-0e8b-4cb1-9b7e-d30387f0f7b1")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Desktop_CrtUIv2_Creatio(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Desktop_CrtUIv2EventsProcess(userConnection);
		}

		public override object Clone() {
			return new Desktop_CrtUIv2_CreatioSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Desktop_CrtUIv2_CreatioSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d2a75817-ac9a-4c95-bcaf-bd2e237bf11c"));
		}

		#endregion

	}

	#endregion

	#region Class: Desktop_CrtUIv2_Creatio

	/// <summary>
	/// Desktop.
	/// </summary>
	public class Desktop_CrtUIv2_Creatio : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public Desktop_CrtUIv2_Creatio(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Desktop_CrtUIv2_Creatio";
		}

		public Desktop_CrtUIv2_Creatio(Desktop_CrtUIv2_Creatio source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Title.
		/// </summary>
		public string Title {
			get {
				return GetTypedColumnValue<string>("Title");
			}
			set {
				SetColumnValue("Title", value);
			}
		}

		/// <summary>
		/// Desktop schema name.
		/// </summary>
		public string DesktopSchemaName {
			get {
				return GetTypedColumnValue<string>("DesktopSchemaName");
			}
			set {
				SetColumnValue("DesktopSchemaName", value);
			}
		}

		/// <summary>
		/// Schema uId.
		/// </summary>
		public Guid SchemaUId {
			get {
				return GetTypedColumnValue<Guid>("SchemaUId");
			}
			set {
				SetColumnValue("SchemaUId", value);
			}
		}

		/// <summary>
		/// Schema real uId.
		/// </summary>
		public Guid SchemaRealUId {
			get {
				return GetTypedColumnValue<Guid>("SchemaRealUId");
			}
			set {
				SetColumnValue("SchemaRealUId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Desktop_CrtUIv2EventsProcess(UserConnection);
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
			return new Desktop_CrtUIv2_Creatio(this);
		}

		#endregion

	}

	#endregion

	#region Class: Desktop_CrtUIv2EventsProcess

	/// <exclude/>
	public partial class Desktop_CrtUIv2EventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : Desktop_CrtUIv2_Creatio
	{

		public Desktop_CrtUIv2EventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Desktop_CrtUIv2EventsProcess";
			SchemaUId = new Guid("d2a75817-ac9a-4c95-bcaf-bd2e237bf11c");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("d2a75817-ac9a-4c95-bcaf-bd2e237bf11c");
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

	#region Class: Desktop_CrtUIv2EventsProcess

	/// <exclude/>
	public class Desktop_CrtUIv2EventsProcess : Desktop_CrtUIv2EventsProcess<Desktop_CrtUIv2_Creatio>
	{

		public Desktop_CrtUIv2EventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Desktop_CrtUIv2EventsProcess

	public partial class Desktop_CrtUIv2EventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

