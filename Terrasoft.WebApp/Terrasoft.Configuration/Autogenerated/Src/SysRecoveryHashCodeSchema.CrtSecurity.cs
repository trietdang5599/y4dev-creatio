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

	#region Class: SysRecoveryHashCodeSchema

	/// <exclude/>
	public class SysRecoveryHashCodeSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysRecoveryHashCodeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysRecoveryHashCodeSchema(SysRecoveryHashCodeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysRecoveryHashCodeSchema(SysRecoveryHashCodeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c0b2a09b-fbaa-4715-93a2-c792066b2c75");
			RealUId = new Guid("c0b2a09b-fbaa-4715-93a2-c792066b2c75");
			Name = "SysRecoveryHashCode";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("fe6820da-14e3-44bf-aa3b-b3cc5706a8c9");
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
			if (Columns.FindByUId(new Guid("c23b29a0-df49-9ce0-4551-e249c055b79d")) == null) {
				Columns.Add(CreateSysAdminUnitColumn());
			}
			if (Columns.FindByUId(new Guid("e0d89439-4d17-7e8a-bd8b-9320d9249d2c")) == null) {
				Columns.Add(CreateHashedCodeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysAdminUnitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("c23b29a0-df49-9ce0-4551-e249c055b79d"),
				Name = @"SysAdminUnit",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("c0b2a09b-fbaa-4715-93a2-c792066b2c75"),
				ModifiedInSchemaUId = new Guid("c0b2a09b-fbaa-4715-93a2-c792066b2c75"),
				CreatedInPackageId = new Guid("fe6820da-14e3-44bf-aa3b-b3cc5706a8c9"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateHashedCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("e0d89439-4d17-7e8a-bd8b-9320d9249d2c"),
				Name = @"HashedCode",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("c0b2a09b-fbaa-4715-93a2-c792066b2c75"),
				ModifiedInSchemaUId = new Guid("c0b2a09b-fbaa-4715-93a2-c792066b2c75"),
				CreatedInPackageId = new Guid("fe6820da-14e3-44bf-aa3b-b3cc5706a8c9")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysRecoveryHashCode(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysRecoveryHashCode_CrtSecurityEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysRecoveryHashCodeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysRecoveryHashCodeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c0b2a09b-fbaa-4715-93a2-c792066b2c75"));
		}

		#endregion

	}

	#endregion

	#region Class: SysRecoveryHashCode

	/// <summary>
	/// SysRecoveryHashCode.
	/// </summary>
	public class SysRecoveryHashCode : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysRecoveryHashCode(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysRecoveryHashCode";
		}

		public SysRecoveryHashCode(SysRecoveryHashCode source)
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
		/// User.
		/// </summary>
		public SysAdminUnit SysAdminUnit {
			get {
				return _sysAdminUnit ??
					(_sysAdminUnit = LookupColumnEntities.GetEntity("SysAdminUnit") as SysAdminUnit);
			}
		}

		/// <summary>
		/// Hashed code.
		/// </summary>
		public string HashedCode {
			get {
				return GetTypedColumnValue<string>("HashedCode");
			}
			set {
				SetColumnValue("HashedCode", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysRecoveryHashCode_CrtSecurityEventsProcess(UserConnection);
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
			return new SysRecoveryHashCode(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysRecoveryHashCode_CrtSecurityEventsProcess

	/// <exclude/>
	public partial class SysRecoveryHashCode_CrtSecurityEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysRecoveryHashCode
	{

		public SysRecoveryHashCode_CrtSecurityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysRecoveryHashCode_CrtSecurityEventsProcess";
			SchemaUId = new Guid("c0b2a09b-fbaa-4715-93a2-c792066b2c75");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("c0b2a09b-fbaa-4715-93a2-c792066b2c75");
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

	#region Class: SysRecoveryHashCode_CrtSecurityEventsProcess

	/// <exclude/>
	public class SysRecoveryHashCode_CrtSecurityEventsProcess : SysRecoveryHashCode_CrtSecurityEventsProcess<SysRecoveryHashCode>
	{

		public SysRecoveryHashCode_CrtSecurityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysRecoveryHashCode_CrtSecurityEventsProcess

	public partial class SysRecoveryHashCode_CrtSecurityEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysRecoveryHashCodeEventsProcess

	/// <exclude/>
	public class SysRecoveryHashCodeEventsProcess : SysRecoveryHashCode_CrtSecurityEventsProcess
	{

		public SysRecoveryHashCodeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

