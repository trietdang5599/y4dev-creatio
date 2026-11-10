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

	#region Class: SysSettingsFolderSchema

	/// <exclude/>
	public class SysSettingsFolderSchema : Terrasoft.Configuration.BaseFolderSchema
	{

		#region Constructors: Public

		public SysSettingsFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysSettingsFolderSchema(SysSettingsFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysSettingsFolderSchema(SysSettingsFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("81996156-45e6-40de-931e-6ddc6f75cd7e");
			RealUId = new Guid("81996156-45e6-40de-931e-6ddc6f75cd7e");
			Name = "SysSettingsFolder";
			ParentSchemaUId = new Guid("d602bf96-d029-4b07-9755-63c8f5cb5ed5");
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
		}

		protected override EntitySchemaColumn CreateParentColumn() {
			EntitySchemaColumn column = base.CreateParentColumn();
			column.ReferenceSchemaUId = new Guid("81996156-45e6-40de-931e-6ddc6f75cd7e");
			column.ColumnValueName = @"ParentId";
			column.DisplayColumnValueName = @"ParentName";
			column.ModifiedInSchemaUId = new Guid("81996156-45e6-40de-931e-6ddc6f75cd7e");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysSettingsFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysSettingsFolder_CrtCoreBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysSettingsFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysSettingsFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("81996156-45e6-40de-931e-6ddc6f75cd7e"));
		}

		#endregion

	}

	#endregion

	#region Class: SysSettingsFolder

	/// <summary>
	/// System settings folder.
	/// </summary>
	public class SysSettingsFolder : Terrasoft.Configuration.BaseFolder
	{

		#region Constructors: Public

		public SysSettingsFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysSettingsFolder";
		}

		public SysSettingsFolder(SysSettingsFolder source)
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

		private SysSettingsFolder _parent;
		/// <summary>
		/// Parent.
		/// </summary>
		public SysSettingsFolder Parent {
			get {
				return _parent ??
					(_parent = LookupColumnEntities.GetEntity("Parent") as SysSettingsFolder);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysSettingsFolder_CrtCoreBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysSettingsFolderDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysSettingsFolderDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysSettingsFolderInserted", e);
			Inserting += (s, e) => ThrowEvent("SysSettingsFolderInserting", e);
			Saved += (s, e) => ThrowEvent("SysSettingsFolderSaved", e);
			Saving += (s, e) => ThrowEvent("SysSettingsFolderSaving", e);
			Validating += (s, e) => ThrowEvent("SysSettingsFolderValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysSettingsFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysSettingsFolder_CrtCoreBaseEventsProcess

	/// <exclude/>
	public partial class SysSettingsFolder_CrtCoreBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseFolder_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysSettingsFolder
	{

		public SysSettingsFolder_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysSettingsFolder_CrtCoreBaseEventsProcess";
			SchemaUId = new Guid("81996156-45e6-40de-931e-6ddc6f75cd7e");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("81996156-45e6-40de-931e-6ddc6f75cd7e");
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

	#region Class: SysSettingsFolder_CrtCoreBaseEventsProcess

	/// <exclude/>
	public class SysSettingsFolder_CrtCoreBaseEventsProcess : SysSettingsFolder_CrtCoreBaseEventsProcess<SysSettingsFolder>
	{

		public SysSettingsFolder_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysSettingsFolder_CrtCoreBaseEventsProcess

	public partial class SysSettingsFolder_CrtCoreBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysSettingsFolderEventsProcess

	/// <exclude/>
	public class SysSettingsFolderEventsProcess : SysSettingsFolder_CrtCoreBaseEventsProcess
	{

		public SysSettingsFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

