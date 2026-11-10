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

	#region Class: SysUserRoleNotInhByMngSchema

	/// <exclude/>
	public class SysUserRoleNotInhByMngSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysUserRoleNotInhByMngSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysUserRoleNotInhByMngSchema(SysUserRoleNotInhByMngSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysUserRoleNotInhByMngSchema(SysUserRoleNotInhByMngSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIUsrRoleNotInhByMngSysAdmUnitIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = true
			};
			index.UId = new Guid("505d2a25-f602-4bae-ab18-91b600637056");
			index.Name = "IUsrRoleNotInhByMngSysAdmUnit";
			index.CreatedInSchemaUId = new Guid("d3ef7613-15bd-445f-bc19-dde5fb43a98b");
			index.ModifiedInSchemaUId = new Guid("d3ef7613-15bd-445f-bc19-dde5fb43a98b");
			index.CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f");
			EntitySchemaIndexColumn sysAdminUnitIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("54630af8-385d-bfa2-f403-55b7b04535fe"),
				ColumnUId = new Guid("77a7d480-4ed4-27a1-f673-2b73a87b81b8"),
				CreatedInSchemaUId = new Guid("d3ef7613-15bd-445f-bc19-dde5fb43a98b"),
				ModifiedInSchemaUId = new Guid("d3ef7613-15bd-445f-bc19-dde5fb43a98b"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(sysAdminUnitIdIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d3ef7613-15bd-445f-bc19-dde5fb43a98b");
			RealUId = new Guid("d3ef7613-15bd-445f-bc19-dde5fb43a98b");
			Name = "SysUserRoleNotInhByMng";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("77a7d480-4ed4-27a1-f673-2b73a87b81b8")) == null) {
				Columns.Add(CreateSysAdminUnitColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysAdminUnitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("77a7d480-4ed4-27a1-f673-2b73a87b81b8"),
				Name = @"SysAdminUnit",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				CreatedInSchemaUId = new Guid("d3ef7613-15bd-445f-bc19-dde5fb43a98b"),
				ModifiedInSchemaUId = new Guid("d3ef7613-15bd-445f-bc19-dde5fb43a98b"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIUsrRoleNotInhByMngSysAdmUnitIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysUserRoleNotInhByMng(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysUserRoleNotInhByMng_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysUserRoleNotInhByMngSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysUserRoleNotInhByMngSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d3ef7613-15bd-445f-bc19-dde5fb43a98b"));
		}

		#endregion

	}

	#endregion

	#region Class: SysUserRoleNotInhByMng

	/// <summary>
	/// User roles not inherited by managers.
	/// </summary>
	public class SysUserRoleNotInhByMng : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysUserRoleNotInhByMng(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysUserRoleNotInhByMng";
		}

		public SysUserRoleNotInhByMng(SysUserRoleNotInhByMng source)
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

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysUserRoleNotInhByMng_CrtBaseEventsProcess(UserConnection);
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
			return new SysUserRoleNotInhByMng(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysUserRoleNotInhByMng_CrtBaseEventsProcess

	/// <exclude/>
	public partial class SysUserRoleNotInhByMng_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysUserRoleNotInhByMng
	{

		public SysUserRoleNotInhByMng_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysUserRoleNotInhByMng_CrtBaseEventsProcess";
			SchemaUId = new Guid("d3ef7613-15bd-445f-bc19-dde5fb43a98b");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("d3ef7613-15bd-445f-bc19-dde5fb43a98b");
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

	#region Class: SysUserRoleNotInhByMng_CrtBaseEventsProcess

	/// <exclude/>
	public class SysUserRoleNotInhByMng_CrtBaseEventsProcess : SysUserRoleNotInhByMng_CrtBaseEventsProcess<SysUserRoleNotInhByMng>
	{

		public SysUserRoleNotInhByMng_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysUserRoleNotInhByMng_CrtBaseEventsProcess

	public partial class SysUserRoleNotInhByMng_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysUserRoleNotInhByMngEventsProcess

	/// <exclude/>
	public class SysUserRoleNotInhByMngEventsProcess : SysUserRoleNotInhByMng_CrtBaseEventsProcess
	{

		public SysUserRoleNotInhByMngEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

