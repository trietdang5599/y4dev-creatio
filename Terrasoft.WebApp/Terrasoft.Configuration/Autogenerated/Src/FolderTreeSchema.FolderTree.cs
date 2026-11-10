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

	#region Class: FolderTree_FolderTree_CreatioSchema

	/// <exclude/>
	public class FolderTree_FolderTree_CreatioSchema : Terrasoft.Configuration.BaseHierarchicalLookupSchema
	{

		#region Constructors: Public

		public FolderTree_FolderTree_CreatioSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public FolderTree_FolderTree_CreatioSchema(FolderTree_FolderTree_CreatioSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public FolderTree_FolderTree_CreatioSchema(FolderTree_FolderTree_CreatioSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("8fcd0c68-a67e-4cef-8ce2-a3b810652f85");
			RealUId = new Guid("8fcd0c68-a67e-4cef-8ce2-a3b810652f85");
			Name = "FolderTree_FolderTree_Creatio";
			ParentSchemaUId = new Guid("5a39bd7c-8880-456c-aaf7-7645ce114e62");
			ExtendParent = false;
			CreatedInPackageId = new Guid("664e4609-25d5-4eea-86dd-c510652b91ea");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("3eeccc43-40ef-720b-61dd-0ec7d5266fd1")) == null) {
				Columns.Add(CreateFilterDataColumn());
			}
			if (Columns.FindByUId(new Guid("6035e08c-6eb9-7544-dd2d-b150723f609b")) == null) {
				Columns.Add(CreateEntitySchemaNameColumn());
			}
		}

		protected override EntitySchemaColumn CreateParentColumn() {
			EntitySchemaColumn column = base.CreateParentColumn();
			column.ReferenceSchemaUId = new Guid("8fcd0c68-a67e-4cef-8ce2-a3b810652f85");
			column.ColumnValueName = @"ParentId";
			column.DisplayColumnValueName = @"ParentName";
			column.ModifiedInSchemaUId = new Guid("8fcd0c68-a67e-4cef-8ce2-a3b810652f85");
			return column;
		}

		protected virtual EntitySchemaColumn CreateFilterDataColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Binary")) {
				UId = new Guid("3eeccc43-40ef-720b-61dd-0ec7d5266fd1"),
				Name = @"FilterData",
				CreatedInSchemaUId = new Guid("8fcd0c68-a67e-4cef-8ce2-a3b810652f85"),
				ModifiedInSchemaUId = new Guid("8fcd0c68-a67e-4cef-8ce2-a3b810652f85"),
				CreatedInPackageId = new Guid("664e4609-25d5-4eea-86dd-c510652b91ea")
			};
		}

		protected virtual EntitySchemaColumn CreateEntitySchemaNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("6035e08c-6eb9-7544-dd2d-b150723f609b"),
				Name = @"EntitySchemaName",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("8fcd0c68-a67e-4cef-8ce2-a3b810652f85"),
				ModifiedInSchemaUId = new Guid("8fcd0c68-a67e-4cef-8ce2-a3b810652f85"),
				CreatedInPackageId = new Guid("664e4609-25d5-4eea-86dd-c510652b91ea")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new FolderTree_FolderTree_Creatio(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new FolderTree_FolderTreeEventsProcess(userConnection);
		}

		public override object Clone() {
			return new FolderTree_FolderTree_CreatioSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new FolderTree_FolderTree_CreatioSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("8fcd0c68-a67e-4cef-8ce2-a3b810652f85"));
		}

		#endregion

	}

	#endregion

	#region Class: FolderTree_FolderTree_Creatio

	/// <summary>
	/// Folder tree.
	/// </summary>
	public class FolderTree_FolderTree_Creatio : Terrasoft.Configuration.BaseHierarchicalLookup
	{

		#region Constructors: Public

		public FolderTree_FolderTree_Creatio(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "FolderTree_FolderTree_Creatio";
		}

		public FolderTree_FolderTree_Creatio(FolderTree_FolderTree_Creatio source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ParentId {
			get {
				return GetTypedColumnValue<Guid>("ParentId");
			}
			set {
				SetColumnValue("ParentId", value);
				_parent = null;
			}
		}

		/// <exclude/>
		public string ParentName {
			get {
				return GetTypedColumnValue<string>("ParentName");
			}
			set {
				SetColumnValue("ParentName", value);
				if (_parent != null) {
					_parent.Name = value;
				}
			}
		}

		private FolderTree _parent;
		/// <summary>
		/// Parent.
		/// </summary>
		public FolderTree Parent {
			get {
				return _parent ??
					(_parent = LookupColumnEntities.GetEntity("Parent") as FolderTree);
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

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new FolderTree_FolderTreeEventsProcess(UserConnection);
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
			return new FolderTree_FolderTree_Creatio(this);
		}

		#endregion

	}

	#endregion

	#region Class: FolderTree_FolderTreeEventsProcess

	/// <exclude/>
	public partial class FolderTree_FolderTreeEventsProcess<TEntity> : Terrasoft.Configuration.BaseHierarchicalLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : FolderTree_FolderTree_Creatio
	{

		public FolderTree_FolderTreeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "FolderTree_FolderTreeEventsProcess";
			SchemaUId = new Guid("8fcd0c68-a67e-4cef-8ce2-a3b810652f85");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("8fcd0c68-a67e-4cef-8ce2-a3b810652f85");
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

	#region Class: FolderTree_FolderTreeEventsProcess

	/// <exclude/>
	public class FolderTree_FolderTreeEventsProcess : FolderTree_FolderTreeEventsProcess<FolderTree_FolderTree_Creatio>
	{

		public FolderTree_FolderTreeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

