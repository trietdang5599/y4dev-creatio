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

	#region Class: FolderTreeStaticFolderSchemasSchema

	/// <exclude/>
	public class FolderTreeStaticFolderSchemasSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public FolderTreeStaticFolderSchemasSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public FolderTreeStaticFolderSchemasSchema(FolderTreeStaticFolderSchemasSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public FolderTreeStaticFolderSchemasSchema(FolderTreeStaticFolderSchemasSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("59135cda-39ae-4805-86d8-347127b1cd25");
			RealUId = new Guid("59135cda-39ae-4805-86d8-347127b1cd25");
			Name = "FolderTreeStaticFolderSchemas";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = false;
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
			if (Columns.FindByUId(new Guid("a0ddfb38-86f7-be34-ac11-100240a67779")) == null) {
				Columns.Add(CreateEntitySchemaNameColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateEntitySchemaNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("a0ddfb38-86f7-be34-ac11-100240a67779"),
				Name = @"EntitySchemaName",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("59135cda-39ae-4805-86d8-347127b1cd25"),
				ModifiedInSchemaUId = new Guid("59135cda-39ae-4805-86d8-347127b1cd25"),
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
			return new FolderTreeStaticFolderSchemas(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new FolderTreeStaticFolderSchemas_CrtCoreBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new FolderTreeStaticFolderSchemasSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new FolderTreeStaticFolderSchemasSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("59135cda-39ae-4805-86d8-347127b1cd25"));
		}

		#endregion

	}

	#endregion

	#region Class: FolderTreeStaticFolderSchemas

	/// <summary>
	/// Schemas for enable static folder in folder tree.
	/// </summary>
	public class FolderTreeStaticFolderSchemas : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public FolderTreeStaticFolderSchemas(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "FolderTreeStaticFolderSchemas";
		}

		public FolderTreeStaticFolderSchemas(FolderTreeStaticFolderSchemas source)
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

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new FolderTreeStaticFolderSchemas_CrtCoreBaseEventsProcess(UserConnection);
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
			return new FolderTreeStaticFolderSchemas(this);
		}

		#endregion

	}

	#endregion

	#region Class: FolderTreeStaticFolderSchemas_CrtCoreBaseEventsProcess

	/// <exclude/>
	public partial class FolderTreeStaticFolderSchemas_CrtCoreBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : FolderTreeStaticFolderSchemas
	{

		public FolderTreeStaticFolderSchemas_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "FolderTreeStaticFolderSchemas_CrtCoreBaseEventsProcess";
			SchemaUId = new Guid("59135cda-39ae-4805-86d8-347127b1cd25");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("59135cda-39ae-4805-86d8-347127b1cd25");
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

	#region Class: FolderTreeStaticFolderSchemas_CrtCoreBaseEventsProcess

	/// <exclude/>
	public class FolderTreeStaticFolderSchemas_CrtCoreBaseEventsProcess : FolderTreeStaticFolderSchemas_CrtCoreBaseEventsProcess<FolderTreeStaticFolderSchemas>
	{

		public FolderTreeStaticFolderSchemas_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: FolderTreeStaticFolderSchemas_CrtCoreBaseEventsProcess

	public partial class FolderTreeStaticFolderSchemas_CrtCoreBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: FolderTreeStaticFolderSchemasEventsProcess

	/// <exclude/>
	public class FolderTreeStaticFolderSchemasEventsProcess : FolderTreeStaticFolderSchemas_CrtCoreBaseEventsProcess
	{

		public FolderTreeStaticFolderSchemasEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

