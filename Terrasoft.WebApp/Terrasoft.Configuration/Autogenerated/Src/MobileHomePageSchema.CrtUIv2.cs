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

	#region Class: MobileHomePageSchema

	/// <exclude/>
	public class MobileHomePageSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public MobileHomePageSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public MobileHomePageSchema(MobileHomePageSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public MobileHomePageSchema(MobileHomePageSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("8b654f1c-38b6-488e-9812-9225928fcd27");
			RealUId = new Guid("8b654f1c-38b6-488e-9812-9225928fcd27");
			Name = "MobileHomePage";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("f4e67bb8-a45c-4fad-9829-cd5fbcd9c40f");
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

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateTitleColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("38a2315a-b576-49c1-826a-b9b9440285e3")) == null) {
				Columns.Add(CreateMobileHomePageSchemaNameColumn());
			}
			if (Columns.FindByUId(new Guid("5f55a0a8-6f49-44df-8077-79a0c766b1b8")) == null) {
				Columns.Add(CreateSchemaUIdColumn());
			}
			if (Columns.FindByUId(new Guid("ee1c64d1-f476-4e38-aa43-93ae40e932f8")) == null) {
				Columns.Add(CreateSchemaRealUIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateTitleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("20e4ba0e-76d4-45b7-a393-2f9791e7dffb"),
				Name = @"Title",
				CreatedInSchemaUId = new Guid("8b654f1c-38b6-488e-9812-9225928fcd27"),
				ModifiedInSchemaUId = new Guid("8b654f1c-38b6-488e-9812-9225928fcd27"),
				CreatedInPackageId = new Guid("f4e67bb8-a45c-4fad-9829-cd5fbcd9c40f"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateMobileHomePageSchemaNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("38a2315a-b576-49c1-826a-b9b9440285e3"),
				Name = @"MobileHomePageSchemaName",
				CreatedInSchemaUId = new Guid("8b654f1c-38b6-488e-9812-9225928fcd27"),
				ModifiedInSchemaUId = new Guid("8b654f1c-38b6-488e-9812-9225928fcd27"),
				CreatedInPackageId = new Guid("f4e67bb8-a45c-4fad-9829-cd5fbcd9c40f")
			};
		}

		protected virtual EntitySchemaColumn CreateSchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("5f55a0a8-6f49-44df-8077-79a0c766b1b8"),
				Name = @"SchemaUId",
				CreatedInSchemaUId = new Guid("8b654f1c-38b6-488e-9812-9225928fcd27"),
				ModifiedInSchemaUId = new Guid("8b654f1c-38b6-488e-9812-9225928fcd27"),
				CreatedInPackageId = new Guid("b31a9a60-0e8b-4cb1-9b7e-d30387f0f7b1")
			};
		}

		protected virtual EntitySchemaColumn CreateSchemaRealUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("ee1c64d1-f476-4e38-aa43-93ae40e932f8"),
				Name = @"SchemaRealUId",
				CreatedInSchemaUId = new Guid("8b654f1c-38b6-488e-9812-9225928fcd27"),
				ModifiedInSchemaUId = new Guid("8b654f1c-38b6-488e-9812-9225928fcd27"),
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
			return new MobileHomePage(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new MobileHomePage_CrtUIv2EventsProcess(userConnection);
		}

		public override object Clone() {
			return new MobileHomePageSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new MobileHomePageSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("8b654f1c-38b6-488e-9812-9225928fcd27"));
		}

		#endregion

	}

	#endregion

	#region Class: MobileHomePage

	/// <summary>
	/// Mobile home page.
	/// </summary>
	public class MobileHomePage : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public MobileHomePage(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MobileHomePage";
		}

		public MobileHomePage(MobileHomePage source)
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
		/// Mobile home page schema name.
		/// </summary>
		public string MobileHomePageSchemaName {
			get {
				return GetTypedColumnValue<string>("MobileHomePageSchemaName");
			}
			set {
				SetColumnValue("MobileHomePageSchemaName", value);
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
		/// Schema uId.
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
			var process = new MobileHomePage_CrtUIv2EventsProcess(UserConnection);
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
			return new MobileHomePage(this);
		}

		#endregion

	}

	#endregion

	#region Class: MobileHomePage_CrtUIv2EventsProcess

	/// <exclude/>
	public partial class MobileHomePage_CrtUIv2EventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : MobileHomePage
	{

		public MobileHomePage_CrtUIv2EventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "MobileHomePage_CrtUIv2EventsProcess";
			SchemaUId = new Guid("8b654f1c-38b6-488e-9812-9225928fcd27");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("8b654f1c-38b6-488e-9812-9225928fcd27");
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

	#region Class: MobileHomePage_CrtUIv2EventsProcess

	/// <exclude/>
	public class MobileHomePage_CrtUIv2EventsProcess : MobileHomePage_CrtUIv2EventsProcess<MobileHomePage>
	{

		public MobileHomePage_CrtUIv2EventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: MobileHomePage_CrtUIv2EventsProcess

	public partial class MobileHomePage_CrtUIv2EventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: MobileHomePageEventsProcess

	/// <exclude/>
	public class MobileHomePageEventsProcess : MobileHomePage_CrtUIv2EventsProcess
	{

		public MobileHomePageEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

