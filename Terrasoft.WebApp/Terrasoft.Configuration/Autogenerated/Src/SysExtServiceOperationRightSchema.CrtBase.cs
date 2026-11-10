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

	#region Class: SysExtServiceOperationRightSchema

	/// <exclude/>
	public class SysExtServiceOperationRightSchema : Terrasoft.Configuration.SysEntitySchemaOperationRightSchema
	{

		#region Constructors: Public

		public SysExtServiceOperationRightSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysExtServiceOperationRightSchema(SysExtServiceOperationRightSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysExtServiceOperationRightSchema(SysExtServiceOperationRightSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("1eecc3f6-0c95-4e15-a18f-7c1400d7bc51");
			RealUId = new Guid("1eecc3f6-0c95-4e15-a18f-7c1400d7bc51");
			Name = "SysExtServiceOperationRight";
			ParentSchemaUId = new Guid("f028c2c5-facc-4109-8cfa-75b2b6620527");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreatePositionColumn() {
			EntitySchemaColumn column = base.CreatePositionColumn();
			column.ModifiedInSchemaUId = new Guid("1eecc3f6-0c95-4e15-a18f-7c1400d7bc51");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override EntitySchemaColumn CreateSysAdminUnitColumn() {
			EntitySchemaColumn column = base.CreateSysAdminUnitColumn();
			column.ModifiedInSchemaUId = new Guid("1eecc3f6-0c95-4e15-a18f-7c1400d7bc51");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override EntitySchemaColumn CreateCanReadColumn() {
			EntitySchemaColumn column = base.CreateCanReadColumn();
			column.ModifiedInSchemaUId = new Guid("1eecc3f6-0c95-4e15-a18f-7c1400d7bc51");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override EntitySchemaColumn CreateCanAppendColumn() {
			EntitySchemaColumn column = base.CreateCanAppendColumn();
			column.ModifiedInSchemaUId = new Guid("1eecc3f6-0c95-4e15-a18f-7c1400d7bc51");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override EntitySchemaColumn CreateCanEditColumn() {
			EntitySchemaColumn column = base.CreateCanEditColumn();
			column.ModifiedInSchemaUId = new Guid("1eecc3f6-0c95-4e15-a18f-7c1400d7bc51");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override EntitySchemaColumn CreateCanDeleteColumn() {
			EntitySchemaColumn column = base.CreateCanDeleteColumn();
			column.ModifiedInSchemaUId = new Guid("1eecc3f6-0c95-4e15-a18f-7c1400d7bc51");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysExtServiceOperationRight(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysExtServiceOperationRight_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysExtServiceOperationRightSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysExtServiceOperationRightSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1eecc3f6-0c95-4e15-a18f-7c1400d7bc51"));
		}

		#endregion

	}

	#endregion

	#region Class: SysExtServiceOperationRight

	/// <summary>
	/// Operations permissions for external services.
	/// </summary>
	public class SysExtServiceOperationRight : Terrasoft.Configuration.SysEntitySchemaOperationRight
	{

		#region Constructors: Public

		public SysExtServiceOperationRight(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysExtServiceOperationRight";
		}

		public SysExtServiceOperationRight(SysExtServiceOperationRight source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysExtServiceOperationRight_CrtBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysExtServiceOperationRightDeleted", e);
			Inserting += (s, e) => ThrowEvent("SysExtServiceOperationRightInserting", e);
			Validating += (s, e) => ThrowEvent("SysExtServiceOperationRightValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysExtServiceOperationRight(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysExtServiceOperationRight_CrtBaseEventsProcess

	/// <exclude/>
	public partial class SysExtServiceOperationRight_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.SysEntitySchemaOperationRight_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysExtServiceOperationRight
	{

		public SysExtServiceOperationRight_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysExtServiceOperationRight_CrtBaseEventsProcess";
			SchemaUId = new Guid("1eecc3f6-0c95-4e15-a18f-7c1400d7bc51");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("1eecc3f6-0c95-4e15-a18f-7c1400d7bc51");
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

	#region Class: SysExtServiceOperationRight_CrtBaseEventsProcess

	/// <exclude/>
	public class SysExtServiceOperationRight_CrtBaseEventsProcess : SysExtServiceOperationRight_CrtBaseEventsProcess<SysExtServiceOperationRight>
	{

		public SysExtServiceOperationRight_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysExtServiceOperationRight_CrtBaseEventsProcess

	public partial class SysExtServiceOperationRight_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysExtServiceOperationRightEventsProcess

	/// <exclude/>
	public class SysExtServiceOperationRightEventsProcess : SysExtServiceOperationRight_CrtBaseEventsProcess
	{

		public SysExtServiceOperationRightEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

