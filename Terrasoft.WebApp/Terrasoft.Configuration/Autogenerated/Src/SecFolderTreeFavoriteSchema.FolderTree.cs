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

	#region Class: SecFolderTreeFavoriteSchema

	/// <exclude/>
	[IsVirtual]
	public class SecFolderTreeFavoriteSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SecFolderTreeFavoriteSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SecFolderTreeFavoriteSchema(SecFolderTreeFavoriteSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SecFolderTreeFavoriteSchema(SecFolderTreeFavoriteSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7a59a4b0-6354-4f65-9fdb-c7d6daf5a087");
			RealUId = new Guid("7a59a4b0-6354-4f65-9fdb-c7d6daf5a087");
			Name = "SecFolderTreeFavorite";
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
			if (Columns.FindByUId(new Guid("4aa7db9f-2440-e7df-5272-7bdb4c8618f5")) == null) {
				Columns.Add(CreateEntitySchemaNameColumn());
			}
			if (Columns.FindByUId(new Guid("8651c3c6-5768-7c36-2726-6f4e09945d2b")) == null) {
				Columns.Add(CreateSysAdminUnitColumn());
			}
			if (Columns.FindByUId(new Guid("9265911b-9ede-2f2b-fd48-f477cebaf10b")) == null) {
				Columns.Add(CreateFolderTreeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateEntitySchemaNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("4aa7db9f-2440-e7df-5272-7bdb4c8618f5"),
				Name = @"EntitySchemaName",
				CreatedInSchemaUId = new Guid("7a59a4b0-6354-4f65-9fdb-c7d6daf5a087"),
				ModifiedInSchemaUId = new Guid("7a59a4b0-6354-4f65-9fdb-c7d6daf5a087"),
				CreatedInPackageId = new Guid("dd00e878-1009-445f-bd06-4d0e05a51d60")
			};
		}

		protected virtual EntitySchemaColumn CreateSysAdminUnitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("8651c3c6-5768-7c36-2726-6f4e09945d2b"),
				Name = @"SysAdminUnit",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("7a59a4b0-6354-4f65-9fdb-c7d6daf5a087"),
				ModifiedInSchemaUId = new Guid("7a59a4b0-6354-4f65-9fdb-c7d6daf5a087"),
				CreatedInPackageId = new Guid("dd00e878-1009-445f-bd06-4d0e05a51d60"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateFolderTreeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("9265911b-9ede-2f2b-fd48-f477cebaf10b"),
				Name = @"FolderTree",
				ReferenceSchemaUId = new Guid("8fcd0c68-a67e-4cef-8ce2-a3b810652f85"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("7a59a4b0-6354-4f65-9fdb-c7d6daf5a087"),
				ModifiedInSchemaUId = new Guid("7a59a4b0-6354-4f65-9fdb-c7d6daf5a087"),
				CreatedInPackageId = new Guid("dd00e878-1009-445f-bd06-4d0e05a51d60"),
				IsSimpleLookup = true
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SecFolderTreeFavorite(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SecFolderTreeFavorite_FolderTreeEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SecFolderTreeFavoriteSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SecFolderTreeFavoriteSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7a59a4b0-6354-4f65-9fdb-c7d6daf5a087"));
		}

		#endregion

	}

	#endregion

	#region Class: SecFolderTreeFavorite

	/// <summary>
	/// Secured favorite folder tree.
	/// </summary>
	public class SecFolderTreeFavorite : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SecFolderTreeFavorite(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SecFolderTreeFavorite";
		}

		public SecFolderTreeFavorite(SecFolderTreeFavorite source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SecFolderTreeFavorite_FolderTreeEventsProcess(UserConnection);
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
			return new SecFolderTreeFavorite(this);
		}

		#endregion

	}

	#endregion

	#region Class: SecFolderTreeFavorite_FolderTreeEventsProcess

	/// <exclude/>
	public partial class SecFolderTreeFavorite_FolderTreeEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : SecFolderTreeFavorite
	{

		public SecFolderTreeFavorite_FolderTreeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SecFolderTreeFavorite_FolderTreeEventsProcess";
			SchemaUId = new Guid("7a59a4b0-6354-4f65-9fdb-c7d6daf5a087");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("7a59a4b0-6354-4f65-9fdb-c7d6daf5a087");
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

	#region Class: SecFolderTreeFavorite_FolderTreeEventsProcess

	/// <exclude/>
	public class SecFolderTreeFavorite_FolderTreeEventsProcess : SecFolderTreeFavorite_FolderTreeEventsProcess<SecFolderTreeFavorite>
	{

		public SecFolderTreeFavorite_FolderTreeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SecFolderTreeFavorite_FolderTreeEventsProcess

	public partial class SecFolderTreeFavorite_FolderTreeEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SecFolderTreeFavoriteEventsProcess

	/// <exclude/>
	public class SecFolderTreeFavoriteEventsProcess : SecFolderTreeFavorite_FolderTreeEventsProcess
	{

		public SecFolderTreeFavoriteEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

