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

	#region Class: FolderTreeFavorite_FolderTree_CreatioSchema

	/// <exclude/>
	public class FolderTreeFavorite_FolderTree_CreatioSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public FolderTreeFavorite_FolderTree_CreatioSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public FolderTreeFavorite_FolderTree_CreatioSchema(FolderTreeFavorite_FolderTree_CreatioSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public FolderTreeFavorite_FolderTree_CreatioSchema(FolderTreeFavorite_FolderTree_CreatioSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("cc0f83fd-9407-4131-8702-42e90903e391");
			RealUId = new Guid("cc0f83fd-9407-4131-8702-42e90903e391");
			Name = "FolderTreeFavorite_FolderTree_Creatio";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("8ebdf725-55cc-430c-bec3-b7599e262e52");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("221404f3-222e-a11d-a4ad-bc9f108999d0")) == null) {
				Columns.Add(CreateSysAdminUnitColumn());
			}
			if (Columns.FindByUId(new Guid("b0096a06-b5e7-67ab-e7d8-6248e62918bb")) == null) {
				Columns.Add(CreateFolderTreeColumn());
			}
			if (Columns.FindByUId(new Guid("a5391758-3c84-c36d-51d4-ebcb9b220cba")) == null) {
				Columns.Add(CreateEntitySchemaNameColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysAdminUnitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("221404f3-222e-a11d-a4ad-bc9f108999d0"),
				Name = @"SysAdminUnit",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("cc0f83fd-9407-4131-8702-42e90903e391"),
				ModifiedInSchemaUId = new Guid("cc0f83fd-9407-4131-8702-42e90903e391"),
				CreatedInPackageId = new Guid("8ebdf725-55cc-430c-bec3-b7599e262e52"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"CurrentUser")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateFolderTreeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("b0096a06-b5e7-67ab-e7d8-6248e62918bb"),
				Name = @"FolderTree",
				ReferenceSchemaUId = new Guid("8fcd0c68-a67e-4cef-8ce2-a3b810652f85"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("cc0f83fd-9407-4131-8702-42e90903e391"),
				ModifiedInSchemaUId = new Guid("cc0f83fd-9407-4131-8702-42e90903e391"),
				CreatedInPackageId = new Guid("8ebdf725-55cc-430c-bec3-b7599e262e52")
			};
		}

		protected virtual EntitySchemaColumn CreateEntitySchemaNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("a5391758-3c84-c36d-51d4-ebcb9b220cba"),
				Name = @"EntitySchemaName",
				CreatedInSchemaUId = new Guid("cc0f83fd-9407-4131-8702-42e90903e391"),
				ModifiedInSchemaUId = new Guid("cc0f83fd-9407-4131-8702-42e90903e391"),
				CreatedInPackageId = new Guid("8ebdf725-55cc-430c-bec3-b7599e262e52")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new FolderTreeFavorite_FolderTree_Creatio(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new FolderTreeFavorite_FolderTreeEventsProcess(userConnection);
		}

		public override object Clone() {
			return new FolderTreeFavorite_FolderTree_CreatioSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new FolderTreeFavorite_FolderTree_CreatioSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("cc0f83fd-9407-4131-8702-42e90903e391"));
		}

		#endregion

	}

	#endregion

	#region Class: FolderTreeFavorite_FolderTree_Creatio

	/// <summary>
	/// Favorite folder tree.
	/// </summary>
	public class FolderTreeFavorite_FolderTree_Creatio : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public FolderTreeFavorite_FolderTree_Creatio(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "FolderTreeFavorite_FolderTree_Creatio";
		}

		public FolderTreeFavorite_FolderTree_Creatio(FolderTreeFavorite_FolderTree_Creatio source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SysAdminUnitId {
			get {
				return GetTypedColumnValue<Guid>("SysAdminUnitId");
			}
			set {
				SetColumnValue("SysAdminUnitId", value);
				_sysAdminUnit = null;
			}
		}

		/// <exclude/>
		public string SysAdminUnitName {
			get {
				return GetTypedColumnValue<string>("SysAdminUnitName");
			}
			set {
				SetColumnValue("SysAdminUnitName", value);
				if (_sysAdminUnit != null) {
					_sysAdminUnit.Name = value;
				}
			}
		}

		private SysAdminUnit _sysAdminUnit;
		/// <summary>
		/// User.
		/// </summary>
		public SysAdminUnit SysAdminUnit {
			get {
				return _sysAdminUnit ??
					(_sysAdminUnit = LookupColumnEntities.GetEntity("SysAdminUnit") as SysAdminUnit);
			}
		}

		/// <exclude/>
		public Guid FolderTreeId {
			get {
				return GetTypedColumnValue<Guid>("FolderTreeId");
			}
			set {
				SetColumnValue("FolderTreeId", value);
				_folderTree = null;
			}
		}

		/// <exclude/>
		public string FolderTreeName {
			get {
				return GetTypedColumnValue<string>("FolderTreeName");
			}
			set {
				SetColumnValue("FolderTreeName", value);
				if (_folderTree != null) {
					_folderTree.Name = value;
				}
			}
		}

		private FolderTree _folderTree;
		/// <summary>
		/// Folder tree.
		/// </summary>
		public FolderTree FolderTree {
			get {
				return _folderTree ??
					(_folderTree = LookupColumnEntities.GetEntity("FolderTree") as FolderTree);
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
			var process = new FolderTreeFavorite_FolderTreeEventsProcess(UserConnection);
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
			return new FolderTreeFavorite_FolderTree_Creatio(this);
		}

		#endregion

	}

	#endregion

	#region Class: FolderTreeFavorite_FolderTreeEventsProcess

	/// <exclude/>
	public partial class FolderTreeFavorite_FolderTreeEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : FolderTreeFavorite_FolderTree_Creatio
	{

		public FolderTreeFavorite_FolderTreeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "FolderTreeFavorite_FolderTreeEventsProcess";
			SchemaUId = new Guid("cc0f83fd-9407-4131-8702-42e90903e391");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("cc0f83fd-9407-4131-8702-42e90903e391");
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

	#region Class: FolderTreeFavorite_FolderTreeEventsProcess

	/// <exclude/>
	public class FolderTreeFavorite_FolderTreeEventsProcess : FolderTreeFavorite_FolderTreeEventsProcess<FolderTreeFavorite_FolderTree_Creatio>
	{

		public FolderTreeFavorite_FolderTreeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: FolderTreeFavorite_FolderTreeEventsProcess

	public partial class FolderTreeFavorite_FolderTreeEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

