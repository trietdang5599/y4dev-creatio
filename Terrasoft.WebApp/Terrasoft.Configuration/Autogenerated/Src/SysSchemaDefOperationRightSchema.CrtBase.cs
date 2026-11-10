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

	#region Class: SysSchemaDefOperationRightSchema

	/// <exclude/>
	public class SysSchemaDefOperationRightSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public SysSchemaDefOperationRightSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysSchemaDefOperationRightSchema(SysSchemaDefOperationRightSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysSchemaDefOperationRightSchema(SysSchemaDefOperationRightSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c8a613f3-a069-4914-85b4-a1c612d481ef");
			RealUId = new Guid("c8a613f3-a069-4914-85b4-a1c612d481ef");
			Name = "SysSchemaDefOperationRight";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("acb004d0-c421-4dff-b075-f4fdc1c90074");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("33dd9daf-c3ba-1d4b-7ab8-e256c875b17f")) == null) {
				Columns.Add(CreateSysAdminUnitColumn());
			}
			if (Columns.FindByUId(new Guid("5158356c-b82c-6c68-f1a9-5ded31109d5e")) == null) {
				Columns.Add(CreateOperationTypeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysAdminUnitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("33dd9daf-c3ba-1d4b-7ab8-e256c875b17f"),
				Name = @"SysAdminUnit",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("c8a613f3-a069-4914-85b4-a1c612d481ef"),
				ModifiedInSchemaUId = new Guid("c8a613f3-a069-4914-85b4-a1c612d481ef"),
				CreatedInPackageId = new Guid("acb004d0-c421-4dff-b075-f4fdc1c90074"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateOperationTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("5158356c-b82c-6c68-f1a9-5ded31109d5e"),
				Name = @"OperationType",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("c8a613f3-a069-4914-85b4-a1c612d481ef"),
				ModifiedInSchemaUId = new Guid("c8a613f3-a069-4914-85b4-a1c612d481ef"),
				CreatedInPackageId = new Guid("acb004d0-c421-4dff-b075-f4fdc1c90074")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysSchemaDefOperationRight(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysSchemaDefOperationRight_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysSchemaDefOperationRightSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysSchemaDefOperationRightSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c8a613f3-a069-4914-85b4-a1c612d481ef"));
		}

		#endregion

	}

	#endregion

	#region Class: SysSchemaDefOperationRight

	/// <summary>
	/// Default schema operation right.
	/// </summary>
	public class SysSchemaDefOperationRight : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public SysSchemaDefOperationRight(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysSchemaDefOperationRight";
		}

		public SysSchemaDefOperationRight(SysSchemaDefOperationRight source)
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
		/// User/role.
		/// </summary>
		public SysAdminUnit SysAdminUnit {
			get {
				return _sysAdminUnit ??
					(_sysAdminUnit = LookupColumnEntities.GetEntity("SysAdminUnit") as SysAdminUnit);
			}
		}

		/// <summary>
		/// Operation type.
		/// </summary>
		public int OperationType {
			get {
				return GetTypedColumnValue<int>("OperationType");
			}
			set {
				SetColumnValue("OperationType", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysSchemaDefOperationRight_CrtBaseEventsProcess(UserConnection);
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
			return new SysSchemaDefOperationRight(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysSchemaDefOperationRight_CrtBaseEventsProcess

	/// <exclude/>
	public partial class SysSchemaDefOperationRight_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysSchemaDefOperationRight
	{

		public SysSchemaDefOperationRight_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysSchemaDefOperationRight_CrtBaseEventsProcess";
			SchemaUId = new Guid("c8a613f3-a069-4914-85b4-a1c612d481ef");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("c8a613f3-a069-4914-85b4-a1c612d481ef");
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

	#region Class: SysSchemaDefOperationRight_CrtBaseEventsProcess

	/// <exclude/>
	public class SysSchemaDefOperationRight_CrtBaseEventsProcess : SysSchemaDefOperationRight_CrtBaseEventsProcess<SysSchemaDefOperationRight>
	{

		public SysSchemaDefOperationRight_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysSchemaDefOperationRight_CrtBaseEventsProcess

	public partial class SysSchemaDefOperationRight_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysSchemaDefOperationRightEventsProcess

	/// <exclude/>
	public class SysSchemaDefOperationRightEventsProcess : SysSchemaDefOperationRight_CrtBaseEventsProcess
	{

		public SysSchemaDefOperationRightEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

