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

	#region Class: SecuredFolderFavoriteSchema

	/// <exclude/>
	[IsVirtual]
	public class SecuredFolderFavoriteSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SecuredFolderFavoriteSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SecuredFolderFavoriteSchema(SecuredFolderFavoriteSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SecuredFolderFavoriteSchema(SecuredFolderFavoriteSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("af86b29d-bcf6-4299-a72a-51b62c8bc525");
			RealUId = new Guid("af86b29d-bcf6-4299-a72a-51b62c8bc525");
			Name = "SecuredFolderFavorite";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("dd00e878-1009-445f-bd06-4d0e05a51d60");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = false;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("82976762-32fd-52c7-3e56-4ac511fa2599")) == null) {
				Columns.Add(CreateSysAdminUnitColumn());
			}
			if (Columns.FindByUId(new Guid("062270c7-7746-7830-362d-99ea095f66f6")) == null) {
				Columns.Add(CreateFolderIdColumn());
			}
			if (Columns.FindByUId(new Guid("152bc6b0-df40-c2e5-f2ca-b3ad4775b5ee")) == null) {
				Columns.Add(CreateFolderEntitySchemaUIdColumn());
			}
			if (Columns.FindByUId(new Guid("ad3c1658-18f6-d5b8-0b29-4bb2681f90af")) == null) {
				Columns.Add(CreateFolderEntitySchemaNameColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysAdminUnitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("82976762-32fd-52c7-3e56-4ac511fa2599"),
				Name = @"SysAdminUnit",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("af86b29d-bcf6-4299-a72a-51b62c8bc525"),
				ModifiedInSchemaUId = new Guid("af86b29d-bcf6-4299-a72a-51b62c8bc525"),
				CreatedInPackageId = new Guid("dd00e878-1009-445f-bd06-4d0e05a51d60"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateFolderIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("062270c7-7746-7830-362d-99ea095f66f6"),
				Name = @"FolderId",
				CreatedInSchemaUId = new Guid("af86b29d-bcf6-4299-a72a-51b62c8bc525"),
				ModifiedInSchemaUId = new Guid("af86b29d-bcf6-4299-a72a-51b62c8bc525"),
				CreatedInPackageId = new Guid("dd00e878-1009-445f-bd06-4d0e05a51d60")
			};
		}

		protected virtual EntitySchemaColumn CreateFolderEntitySchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("152bc6b0-df40-c2e5-f2ca-b3ad4775b5ee"),
				Name = @"FolderEntitySchemaUId",
				CreatedInSchemaUId = new Guid("af86b29d-bcf6-4299-a72a-51b62c8bc525"),
				ModifiedInSchemaUId = new Guid("af86b29d-bcf6-4299-a72a-51b62c8bc525"),
				CreatedInPackageId = new Guid("dd00e878-1009-445f-bd06-4d0e05a51d60")
			};
		}

		protected virtual EntitySchemaColumn CreateFolderEntitySchemaNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("ad3c1658-18f6-d5b8-0b29-4bb2681f90af"),
				Name = @"FolderEntitySchemaName",
				CreatedInSchemaUId = new Guid("af86b29d-bcf6-4299-a72a-51b62c8bc525"),
				ModifiedInSchemaUId = new Guid("af86b29d-bcf6-4299-a72a-51b62c8bc525"),
				CreatedInPackageId = new Guid("dd00e878-1009-445f-bd06-4d0e05a51d60")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SecuredFolderFavorite(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SecuredFolderFavorite_FolderTreeEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SecuredFolderFavoriteSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SecuredFolderFavoriteSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("af86b29d-bcf6-4299-a72a-51b62c8bc525"));
		}

		#endregion

	}

	#endregion

	#region Class: SecuredFolderFavorite

	/// <summary>
	/// Secured folder favorite.
	/// </summary>
	public class SecuredFolderFavorite : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SecuredFolderFavorite(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SecuredFolderFavorite";
		}

		public SecuredFolderFavorite(SecuredFolderFavorite source)
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

		/// <summary>
		/// Folder.
		/// </summary>
		public Guid FolderId {
			get {
				return GetTypedColumnValue<Guid>("FolderId");
			}
			set {
				SetColumnValue("FolderId", value);
			}
		}

		/// <summary>
		/// Folder schema.
		/// </summary>
		public Guid FolderEntitySchemaUId {
			get {
				return GetTypedColumnValue<Guid>("FolderEntitySchemaUId");
			}
			set {
				SetColumnValue("FolderEntitySchemaUId", value);
			}
		}

		/// <summary>
		/// Folder entity schema name.
		/// </summary>
		public string FolderEntitySchemaName {
			get {
				return GetTypedColumnValue<string>("FolderEntitySchemaName");
			}
			set {
				SetColumnValue("FolderEntitySchemaName", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SecuredFolderFavorite_FolderTreeEventsProcess(UserConnection);
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
			return new SecuredFolderFavorite(this);
		}

		#endregion

	}

	#endregion

	#region Class: SecuredFolderFavorite_FolderTreeEventsProcess

	/// <exclude/>
	public partial class SecuredFolderFavorite_FolderTreeEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : SecuredFolderFavorite
	{

		public SecuredFolderFavorite_FolderTreeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SecuredFolderFavorite_FolderTreeEventsProcess";
			SchemaUId = new Guid("af86b29d-bcf6-4299-a72a-51b62c8bc525");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("af86b29d-bcf6-4299-a72a-51b62c8bc525");
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

	#region Class: SecuredFolderFavorite_FolderTreeEventsProcess

	/// <exclude/>
	public class SecuredFolderFavorite_FolderTreeEventsProcess : SecuredFolderFavorite_FolderTreeEventsProcess<SecuredFolderFavorite>
	{

		public SecuredFolderFavorite_FolderTreeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SecuredFolderFavorite_FolderTreeEventsProcess

	public partial class SecuredFolderFavorite_FolderTreeEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SecuredFolderFavoriteEventsProcess

	/// <exclude/>
	public class SecuredFolderFavoriteEventsProcess : SecuredFolderFavorite_FolderTreeEventsProcess
	{

		public SecuredFolderFavoriteEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

