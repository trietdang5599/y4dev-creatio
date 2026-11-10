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

	#region Class: SysModuleActionLczOldSchema

	/// <exclude/>
	public class SysModuleActionLczOldSchema : Terrasoft.Configuration.BaseLczEntitySchema
	{

		#region Constructors: Public

		public SysModuleActionLczOldSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysModuleActionLczOldSchema(SysModuleActionLczOldSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysModuleActionLczOldSchema(SysModuleActionLczOldSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d999461b-4a77-4caf-9069-7bcb301d918c");
			RealUId = new Guid("d999461b-4a77-4caf-9069-7bcb301d918c");
			Name = "SysModuleActionLczOld";
			ParentSchemaUId = new Guid("b7cd8e8f-a017-4f73-b1fe-efb9e938e1d2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateRecordColumn() {
			EntitySchemaColumn column = base.CreateRecordColumn();
			column.ReferenceSchemaUId = new Guid("37eaa24a-e8e3-4020-8a16-30569db5c926");
			column.ColumnValueName = @"RecordId";
			column.DisplayColumnValueName = @"RecordCaption";
			column.ModifiedInSchemaUId = new Guid("d999461b-4a77-4caf-9069-7bcb301d918c");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysModuleActionLczOld(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysModuleActionLczOld_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysModuleActionLczOldSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysModuleActionLczOldSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d999461b-4a77-4caf-9069-7bcb301d918c"));
		}

		#endregion

	}

	#endregion

	#region Class: SysModuleActionLczOld

	/// <summary>
	/// SysModuleAction localization table.
	/// </summary>
	public class SysModuleActionLczOld : Terrasoft.Configuration.BaseLczEntity
	{

		#region Constructors: Public

		public SysModuleActionLczOld(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysModuleActionLczOld";
		}

		public SysModuleActionLczOld(SysModuleActionLczOld source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysModuleActionLczOld_CrtBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysModuleActionLczOldDeleted", e);
			Inserting += (s, e) => ThrowEvent("SysModuleActionLczOldInserting", e);
			Validating += (s, e) => ThrowEvent("SysModuleActionLczOldValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysModuleActionLczOld(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysModuleActionLczOld_CrtBaseEventsProcess

	/// <exclude/>
	public partial class SysModuleActionLczOld_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseLczEntity_CrtBaseEventsProcess<TEntity> where TEntity : SysModuleActionLczOld
	{

		public SysModuleActionLczOld_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysModuleActionLczOld_CrtBaseEventsProcess";
			SchemaUId = new Guid("d999461b-4a77-4caf-9069-7bcb301d918c");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("d999461b-4a77-4caf-9069-7bcb301d918c");
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

	#region Class: SysModuleActionLczOld_CrtBaseEventsProcess

	/// <exclude/>
	public class SysModuleActionLczOld_CrtBaseEventsProcess : SysModuleActionLczOld_CrtBaseEventsProcess<SysModuleActionLczOld>
	{

		public SysModuleActionLczOld_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysModuleActionLczOld_CrtBaseEventsProcess

	public partial class SysModuleActionLczOld_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysModuleActionLczOldEventsProcess

	/// <exclude/>
	public class SysModuleActionLczOldEventsProcess : SysModuleActionLczOld_CrtBaseEventsProcess
	{

		public SysModuleActionLczOldEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

