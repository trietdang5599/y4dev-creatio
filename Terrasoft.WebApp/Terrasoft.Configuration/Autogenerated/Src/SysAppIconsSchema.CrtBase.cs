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

	#region Class: SysAppIconsSchema

	/// <exclude/>
	public class SysAppIconsSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysAppIconsSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysAppIconsSchema(SysAppIconsSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysAppIconsSchema(SysAppIconsSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateINameIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = true
			};
			index.UId = new Guid("f817ac42-51d3-46d5-b5fe-be71eb789397");
			index.Name = "IName";
			index.CreatedInSchemaUId = new Guid("ce7f2913-9b5f-4b7b-ade8-4f4da0392965");
			index.ModifiedInSchemaUId = new Guid("ce7f2913-9b5f-4b7b-ade8-4f4da0392965");
			index.CreatedInPackageId = new Guid("2a50de0f-c3f4-4ade-85bf-55e7c5620bda");
			EntitySchemaIndexColumn nameIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("1aa887e8-c198-9de7-1d3d-5d6950dba099"),
				ColumnUId = new Guid("bd03e7f2-800b-8f90-a002-a5dd237d517a"),
				CreatedInSchemaUId = new Guid("ce7f2913-9b5f-4b7b-ade8-4f4da0392965"),
				ModifiedInSchemaUId = new Guid("ce7f2913-9b5f-4b7b-ade8-4f4da0392965"),
				CreatedInPackageId = new Guid("2a50de0f-c3f4-4ade-85bf-55e7c5620bda"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(nameIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ce7f2913-9b5f-4b7b-ade8-4f4da0392965");
			RealUId = new Guid("ce7f2913-9b5f-4b7b-ade8-4f4da0392965");
			Name = "SysAppIcons";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
			UseLiveEditing = false;
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
			if (Columns.FindByUId(new Guid("136c0144-a9de-fe78-7d66-1a53f8fbe7d3")) == null) {
				Columns.Add(CreatePositionColumn());
			}
			if (Columns.FindByUId(new Guid("16d9fc31-48bb-2f2a-90d4-c35b89a41ef5")) == null) {
				Columns.Add(CreateDataColumn());
			}
		}

		protected virtual EntitySchemaColumn CreatePositionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("136c0144-a9de-fe78-7d66-1a53f8fbe7d3"),
				Name = @"Position",
				CreatedInSchemaUId = new Guid("ce7f2913-9b5f-4b7b-ade8-4f4da0392965"),
				ModifiedInSchemaUId = new Guid("ce7f2913-9b5f-4b7b-ade8-4f4da0392965"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected virtual EntitySchemaColumn CreateDataColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Image")) {
				UId = new Guid("16d9fc31-48bb-2f2a-90d4-c35b89a41ef5"),
				Name = @"Data",
				CreatedInSchemaUId = new Guid("ce7f2913-9b5f-4b7b-ade8-4f4da0392965"),
				ModifiedInSchemaUId = new Guid("ce7f2913-9b5f-4b7b-ade8-4f4da0392965"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("bd03e7f2-800b-8f90-a002-a5dd237d517a"),
				Name = @"Name",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("ce7f2913-9b5f-4b7b-ade8-4f4da0392965"),
				ModifiedInSchemaUId = new Guid("ce7f2913-9b5f-4b7b-ade8-4f4da0392965"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateINameIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysAppIcons(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysAppIcons_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysAppIconsSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysAppIconsSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ce7f2913-9b5f-4b7b-ade8-4f4da0392965"));
		}

		#endregion

	}

	#endregion

	#region Class: SysAppIcons

	/// <summary>
	/// Application icons.
	/// </summary>
	public class SysAppIcons : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysAppIcons(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysAppIcons";
		}

		public SysAppIcons(SysAppIcons source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Position.
		/// </summary>
		public int Position {
			get {
				return GetTypedColumnValue<int>("Position");
			}
			set {
				SetColumnValue("Position", value);
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
			var process = new SysAppIcons_CrtBaseEventsProcess(UserConnection);
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
			return new SysAppIcons(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysAppIcons_CrtBaseEventsProcess

	/// <exclude/>
	public partial class SysAppIcons_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysAppIcons
	{

		public SysAppIcons_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysAppIcons_CrtBaseEventsProcess";
			SchemaUId = new Guid("ce7f2913-9b5f-4b7b-ade8-4f4da0392965");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ce7f2913-9b5f-4b7b-ade8-4f4da0392965");
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

	#region Class: SysAppIcons_CrtBaseEventsProcess

	/// <exclude/>
	public class SysAppIcons_CrtBaseEventsProcess : SysAppIcons_CrtBaseEventsProcess<SysAppIcons>
	{

		public SysAppIcons_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysAppIcons_CrtBaseEventsProcess

	public partial class SysAppIcons_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysAppIconsEventsProcess

	/// <exclude/>
	public class SysAppIconsEventsProcess : SysAppIcons_CrtBaseEventsProcess
	{

		public SysAppIconsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

