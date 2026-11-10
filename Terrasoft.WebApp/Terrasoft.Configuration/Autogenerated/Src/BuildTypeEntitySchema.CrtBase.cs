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

	#region Class: BuildTypeEntitySchema

	/// <exclude/>
	public class BuildTypeEntitySchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public BuildTypeEntitySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public BuildTypeEntitySchema(BuildTypeEntitySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public BuildTypeEntitySchema(BuildTypeEntitySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5efab9d3-ebd4-4b5d-acc2-b8f3d04b45a7");
			RealUId = new Guid("5efab9d3-ebd4-4b5d-acc2-b8f3d04b45a7");
			Name = "BuildTypeEntity";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("d8b043ab-1ada-4e1f-9921-a7610c352117");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("5efab9d3-ebd4-4b5d-acc2-b8f3d04b45a7");
			column.CreatedInPackageId = new Guid("d8b043ab-1ada-4e1f-9921-a7610c352117");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("5efab9d3-ebd4-4b5d-acc2-b8f3d04b45a7");
			column.CreatedInPackageId = new Guid("d8b043ab-1ada-4e1f-9921-a7610c352117");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("5efab9d3-ebd4-4b5d-acc2-b8f3d04b45a7");
			column.CreatedInPackageId = new Guid("d8b043ab-1ada-4e1f-9921-a7610c352117");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("5efab9d3-ebd4-4b5d-acc2-b8f3d04b45a7");
			column.CreatedInPackageId = new Guid("d8b043ab-1ada-4e1f-9921-a7610c352117");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("5efab9d3-ebd4-4b5d-acc2-b8f3d04b45a7");
			column.CreatedInPackageId = new Guid("d8b043ab-1ada-4e1f-9921-a7610c352117");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("5efab9d3-ebd4-4b5d-acc2-b8f3d04b45a7");
			column.CreatedInPackageId = new Guid("d8b043ab-1ada-4e1f-9921-a7610c352117");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("5efab9d3-ebd4-4b5d-acc2-b8f3d04b45a7");
			column.CreatedInPackageId = new Guid("d8b043ab-1ada-4e1f-9921-a7610c352117");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("5efab9d3-ebd4-4b5d-acc2-b8f3d04b45a7");
			column.CreatedInPackageId = new Guid("d8b043ab-1ada-4e1f-9921-a7610c352117");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new BuildTypeEntity(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new BuildTypeEntity_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new BuildTypeEntitySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new BuildTypeEntitySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5efab9d3-ebd4-4b5d-acc2-b8f3d04b45a7"));
		}

		#endregion

	}

	#endregion

	#region Class: BuildTypeEntity

	/// <summary>
	/// Build type.
	/// </summary>
	public class BuildTypeEntity : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public BuildTypeEntity(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BuildTypeEntity";
		}

		public BuildTypeEntity(BuildTypeEntity source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new BuildTypeEntity_CrtBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("BuildTypeEntityDeleted", e);
			Inserting += (s, e) => ThrowEvent("BuildTypeEntityInserting", e);
			Validating += (s, e) => ThrowEvent("BuildTypeEntityValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new BuildTypeEntity(this);
		}

		#endregion

	}

	#endregion

	#region Class: BuildTypeEntity_CrtBaseEventsProcess

	/// <exclude/>
	public partial class BuildTypeEntity_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : BuildTypeEntity
	{

		public BuildTypeEntity_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "BuildTypeEntity_CrtBaseEventsProcess";
			SchemaUId = new Guid("5efab9d3-ebd4-4b5d-acc2-b8f3d04b45a7");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("5efab9d3-ebd4-4b5d-acc2-b8f3d04b45a7");
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

	#region Class: BuildTypeEntity_CrtBaseEventsProcess

	/// <exclude/>
	public class BuildTypeEntity_CrtBaseEventsProcess : BuildTypeEntity_CrtBaseEventsProcess<BuildTypeEntity>
	{

		public BuildTypeEntity_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: BuildTypeEntity_CrtBaseEventsProcess

	public partial class BuildTypeEntity_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: BuildTypeEntityEventsProcess

	/// <exclude/>
	public class BuildTypeEntityEventsProcess : BuildTypeEntity_CrtBaseEventsProcess
	{

		public BuildTypeEntityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

