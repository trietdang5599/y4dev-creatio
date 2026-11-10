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

	#region Class: SysAdminOperationInFolderSchema

	/// <exclude/>
	public class SysAdminOperationInFolderSchema : Terrasoft.Configuration.BaseItemInFolderSchema
	{

		#region Constructors: Public

		public SysAdminOperationInFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysAdminOperationInFolderSchema(SysAdminOperationInFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysAdminOperationInFolderSchema(SysAdminOperationInFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("9880e08e-a3a7-4699-9eab-2960d6058612");
			RealUId = new Guid("9880e08e-a3a7-4699-9eab-2960d6058612");
			Name = "SysAdminOperationInFolder";
			ParentSchemaUId = new Guid("4f63bafb-e9e7-4082-b92e-66b97c14017c");
			ExtendParent = false;
			CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = false;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("ad54545a-07d7-5248-3d97-09227c52367f")) == null) {
				Columns.Add(CreateSysAdminOperationColumn());
			}
		}

		protected override EntitySchemaColumn CreateFolderColumn() {
			EntitySchemaColumn column = base.CreateFolderColumn();
			column.ReferenceSchemaUId = new Guid("a3421ccc-16ab-4ef5-a941-a868bba1aefd");
			column.ColumnValueName = @"FolderId";
			column.DisplayColumnValueName = @"FolderName";
			column.ModifiedInSchemaUId = new Guid("9880e08e-a3a7-4699-9eab-2960d6058612");
			return column;
		}

		protected virtual EntitySchemaColumn CreateSysAdminOperationColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ad54545a-07d7-5248-3d97-09227c52367f"),
				Name = @"SysAdminOperation",
				ReferenceSchemaUId = new Guid("c8fd2fd0-1f44-48c7-84e4-045250b9a638"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("9880e08e-a3a7-4699-9eab-2960d6058612"),
				ModifiedInSchemaUId = new Guid("9880e08e-a3a7-4699-9eab-2960d6058612"),
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysAdminOperationInFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysAdminOperationInFolder_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysAdminOperationInFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysAdminOperationInFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9880e08e-a3a7-4699-9eab-2960d6058612"));
		}

		#endregion

	}

	#endregion

	#region Class: SysAdminOperationInFolder

	/// <summary>
	/// Administrated operation in folder.
	/// </summary>
	public class SysAdminOperationInFolder : Terrasoft.Configuration.BaseItemInFolder
	{

		#region Constructors: Public

		public SysAdminOperationInFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysAdminOperationInFolder";
		}

		public SysAdminOperationInFolder(SysAdminOperationInFolder source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SysAdminOperationId {
			get {
				return GetTypedColumnValue<Guid>("SysAdminOperationId");
			}
			set {
				SetColumnValue("SysAdminOperationId", value);
				_sysAdminOperation = null;
			}
		}

		/// <exclude/>
		public string SysAdminOperationName {
			get {
				return GetTypedColumnValue<string>("SysAdminOperationName");
			}
			set {
				SetColumnValue("SysAdminOperationName", value);
				if (_sysAdminOperation != null) {
					_sysAdminOperation.Name = value;
				}
			}
		}

		private SysAdminOperation _sysAdminOperation;
		/// <summary>
		/// Administrated operation.
		/// </summary>
		public SysAdminOperation SysAdminOperation {
			get {
				return _sysAdminOperation ??
					(_sysAdminOperation = LookupColumnEntities.GetEntity("SysAdminOperation") as SysAdminOperation);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysAdminOperationInFolder_CrtBaseEventsProcess(UserConnection);
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
			return new SysAdminOperationInFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysAdminOperationInFolder_CrtBaseEventsProcess

	/// <exclude/>
	public partial class SysAdminOperationInFolder_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseItemInFolder_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysAdminOperationInFolder
	{

		public SysAdminOperationInFolder_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysAdminOperationInFolder_CrtBaseEventsProcess";
			SchemaUId = new Guid("9880e08e-a3a7-4699-9eab-2960d6058612");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("9880e08e-a3a7-4699-9eab-2960d6058612");
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

	#region Class: SysAdminOperationInFolder_CrtBaseEventsProcess

	/// <exclude/>
	public class SysAdminOperationInFolder_CrtBaseEventsProcess : SysAdminOperationInFolder_CrtBaseEventsProcess<SysAdminOperationInFolder>
	{

		public SysAdminOperationInFolder_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysAdminOperationInFolder_CrtBaseEventsProcess

	public partial class SysAdminOperationInFolder_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysAdminOperationInFolderEventsProcess

	/// <exclude/>
	public class SysAdminOperationInFolderEventsProcess : SysAdminOperationInFolder_CrtBaseEventsProcess
	{

		public SysAdminOperationInFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

