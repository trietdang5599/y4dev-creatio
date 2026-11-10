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

	#region Class: SysSchemaAdminUnitSchema

	/// <exclude/>
	[IsVirtual]
	public class SysSchemaAdminUnitSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysSchemaAdminUnitSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysSchemaAdminUnitSchema(SysSchemaAdminUnitSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysSchemaAdminUnitSchema(SysSchemaAdminUnitSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("779d0fa6-bf4d-46d6-87bb-0685c613e5b9");
			RealUId = new Guid("779d0fa6-bf4d-46d6-87bb-0685c613e5b9");
			Name = "SysSchemaAdminUnit";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
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
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysSchemaAdminUnit(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysSchemaAdminUnit_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysSchemaAdminUnitSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysSchemaAdminUnitSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("779d0fa6-bf4d-46d6-87bb-0685c613e5b9"));
		}

		#endregion

	}

	#endregion

	#region Class: SysSchemaAdminUnit

	/// <summary>
	/// Schema admin unit operation.
	/// </summary>
	public class SysSchemaAdminUnit : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysSchemaAdminUnit(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysSchemaAdminUnit";
		}

		public SysSchemaAdminUnit(SysSchemaAdminUnit source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysSchemaAdminUnit_CrtBaseEventsProcess(UserConnection);
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
			return new SysSchemaAdminUnit(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysSchemaAdminUnit_CrtBaseEventsProcess

	/// <exclude/>
	public partial class SysSchemaAdminUnit_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysSchemaAdminUnit
	{

		public SysSchemaAdminUnit_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysSchemaAdminUnit_CrtBaseEventsProcess";
			SchemaUId = new Guid("779d0fa6-bf4d-46d6-87bb-0685c613e5b9");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("779d0fa6-bf4d-46d6-87bb-0685c613e5b9");
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

	#region Class: SysSchemaAdminUnit_CrtBaseEventsProcess

	/// <exclude/>
	public class SysSchemaAdminUnit_CrtBaseEventsProcess : SysSchemaAdminUnit_CrtBaseEventsProcess<SysSchemaAdminUnit>
	{

		public SysSchemaAdminUnit_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysSchemaAdminUnit_CrtBaseEventsProcess

	public partial class SysSchemaAdminUnit_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysSchemaAdminUnitEventsProcess

	/// <exclude/>
	public class SysSchemaAdminUnitEventsProcess : SysSchemaAdminUnit_CrtBaseEventsProcess
	{

		public SysSchemaAdminUnitEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

