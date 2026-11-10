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

	#region Class: SysEntitySchemaDbInfoSchema

	/// <exclude/>
	public class SysEntitySchemaDbInfoSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysEntitySchemaDbInfoSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysEntitySchemaDbInfoSchema(SysEntitySchemaDbInfoSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysEntitySchemaDbInfoSchema(SysEntitySchemaDbInfoSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f55c6213-f4fe-4b6e-890e-7f3838a2dbd1");
			RealUId = new Guid("f55c6213-f4fe-4b6e-890e-7f3838a2dbd1");
			Name = "SysEntitySchemaDbInfo";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateNameColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("b5ee0c1c-053f-71af-e19a-33540ca0832c")) == null) {
				Columns.Add(CreateRowCountColumn());
			}
			if (Columns.FindByUId(new Guid("2596f727-bd70-94ac-0a25-746e888139e4")) == null) {
				Columns.Add(CreateTypeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateRowCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("b5ee0c1c-053f-71af-e19a-33540ca0832c"),
				Name = @"RowCount",
				CreatedInSchemaUId = new Guid("f55c6213-f4fe-4b6e-890e-7f3838a2dbd1"),
				ModifiedInSchemaUId = new Guid("f55c6213-f4fe-4b6e-890e-7f3838a2dbd1"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected virtual EntitySchemaColumn CreateTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("2596f727-bd70-94ac-0a25-746e888139e4"),
				Name = @"Type",
				CreatedInSchemaUId = new Guid("f55c6213-f4fe-4b6e-890e-7f3838a2dbd1"),
				ModifiedInSchemaUId = new Guid("f55c6213-f4fe-4b6e-890e-7f3838a2dbd1"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("c2450df5-c198-70e0-f5e9-f9b5eeafe5bf"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("f55c6213-f4fe-4b6e-890e-7f3838a2dbd1"),
				ModifiedInSchemaUId = new Guid("f55c6213-f4fe-4b6e-890e-7f3838a2dbd1"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysEntitySchemaDbInfo(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysEntitySchemaDbInfo_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysEntitySchemaDbInfoSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysEntitySchemaDbInfoSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f55c6213-f4fe-4b6e-890e-7f3838a2dbd1"));
		}

		#endregion

	}

	#endregion

	#region Class: SysEntitySchemaDbInfo

	/// <summary>
	/// Entity schema database info.
	/// </summary>
	public class SysEntitySchemaDbInfo : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysEntitySchemaDbInfo(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysEntitySchemaDbInfo";
		}

		public SysEntitySchemaDbInfo(SysEntitySchemaDbInfo source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Row сount.
		/// </summary>
		public int RowCount {
			get {
				return GetTypedColumnValue<int>("RowCount");
			}
			set {
				SetColumnValue("RowCount", value);
			}
		}

		/// <summary>
		/// Type.
		/// </summary>
		public int Type {
			get {
				return GetTypedColumnValue<int>("Type");
			}
			set {
				SetColumnValue("Type", value);
			}
		}

		/// <summary>
		/// Name.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysEntitySchemaDbInfo_CrtBaseEventsProcess(UserConnection);
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
			return new SysEntitySchemaDbInfo(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysEntitySchemaDbInfo_CrtBaseEventsProcess

	/// <exclude/>
	public partial class SysEntitySchemaDbInfo_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysEntitySchemaDbInfo
	{

		public SysEntitySchemaDbInfo_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysEntitySchemaDbInfo_CrtBaseEventsProcess";
			SchemaUId = new Guid("f55c6213-f4fe-4b6e-890e-7f3838a2dbd1");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("f55c6213-f4fe-4b6e-890e-7f3838a2dbd1");
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

	#region Class: SysEntitySchemaDbInfo_CrtBaseEventsProcess

	/// <exclude/>
	public class SysEntitySchemaDbInfo_CrtBaseEventsProcess : SysEntitySchemaDbInfo_CrtBaseEventsProcess<SysEntitySchemaDbInfo>
	{

		public SysEntitySchemaDbInfo_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysEntitySchemaDbInfo_CrtBaseEventsProcess

	public partial class SysEntitySchemaDbInfo_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysEntitySchemaDbInfoEventsProcess

	/// <exclude/>
	public class SysEntitySchemaDbInfoEventsProcess : SysEntitySchemaDbInfo_CrtBaseEventsProcess
	{

		public SysEntitySchemaDbInfoEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

