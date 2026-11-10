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

	#region Class: SysPluginPackageSchema

	/// <exclude/>
	public class SysPluginPackageSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public SysPluginPackageSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysPluginPackageSchema(SysPluginPackageSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysPluginPackageSchema(SysPluginPackageSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("80567be7-99c2-41c7-923a-ee9ec17ad93c");
			RealUId = new Guid("80567be7-99c2-41c7-923a-ee9ec17ad93c");
			Name = "SysPluginPackage";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
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
			if (Columns.FindByUId(new Guid("620a1cb6-e5a1-9712-703c-b134f082fe73")) == null) {
				Columns.Add(CreateSysPackageUIdColumn());
			}
			if (Columns.FindByUId(new Guid("772d572e-6faa-2957-bad1-d68f0cf9baae")) == null) {
				Columns.Add(CreateSysPluginPackageStatusColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysPackageUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("620a1cb6-e5a1-9712-703c-b134f082fe73"),
				Name = @"SysPackageUId",
				CreatedInSchemaUId = new Guid("80567be7-99c2-41c7-923a-ee9ec17ad93c"),
				ModifiedInSchemaUId = new Guid("80567be7-99c2-41c7-923a-ee9ec17ad93c"),
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723")
			};
		}

		protected virtual EntitySchemaColumn CreateSysPluginPackageStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("772d572e-6faa-2957-bad1-d68f0cf9baae"),
				Name = @"SysPluginPackageStatus",
				ReferenceSchemaUId = new Guid("2fc5cf81-9713-4d54-8f05-8883ade66f7f"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("80567be7-99c2-41c7-923a-ee9ec17ad93c"),
				ModifiedInSchemaUId = new Guid("80567be7-99c2-41c7-923a-ee9ec17ad93c"),
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
			return new SysPluginPackage(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysPluginPackage_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysPluginPackageSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysPluginPackageSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("80567be7-99c2-41c7-923a-ee9ec17ad93c"));
		}

		#endregion

	}

	#endregion

	#region Class: SysPluginPackage

	/// <summary>
	/// Plugin package.
	/// </summary>
	public class SysPluginPackage : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public SysPluginPackage(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysPluginPackage";
		}

		public SysPluginPackage(SysPluginPackage source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Package UId.
		/// </summary>
		public Guid SysPackageUId {
			get {
				return GetTypedColumnValue<Guid>("SysPackageUId");
			}
			set {
				SetColumnValue("SysPackageUId", value);
			}
		}

		/// <exclude/>
		public Guid SysPluginPackageStatusId {
			get {
				return GetTypedColumnValue<Guid>("SysPluginPackageStatusId");
			}
			set {
				SetColumnValue("SysPluginPackageStatusId", value);
				_sysPluginPackageStatus = null;
			}
		}

		/// <exclude/>
		public string SysPluginPackageStatusName {
			get {
				return GetTypedColumnValue<string>("SysPluginPackageStatusName");
			}
			set {
				SetColumnValue("SysPluginPackageStatusName", value);
				if (_sysPluginPackageStatus != null) {
					_sysPluginPackageStatus.Name = value;
				}
			}
		}

		private SysPluginPackageStatus _sysPluginPackageStatus;
		/// <summary>
		/// Plugin package status.
		/// </summary>
		public SysPluginPackageStatus SysPluginPackageStatus {
			get {
				return _sysPluginPackageStatus ??
					(_sysPluginPackageStatus = LookupColumnEntities.GetEntity("SysPluginPackageStatus") as SysPluginPackageStatus);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysPluginPackage_CrtBaseEventsProcess(UserConnection);
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
			return new SysPluginPackage(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysPluginPackage_CrtBaseEventsProcess

	/// <exclude/>
	public partial class SysPluginPackage_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysPluginPackage
	{

		public SysPluginPackage_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysPluginPackage_CrtBaseEventsProcess";
			SchemaUId = new Guid("80567be7-99c2-41c7-923a-ee9ec17ad93c");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("80567be7-99c2-41c7-923a-ee9ec17ad93c");
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

	#region Class: SysPluginPackage_CrtBaseEventsProcess

	/// <exclude/>
	public class SysPluginPackage_CrtBaseEventsProcess : SysPluginPackage_CrtBaseEventsProcess<SysPluginPackage>
	{

		public SysPluginPackage_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysPluginPackage_CrtBaseEventsProcess

	public partial class SysPluginPackage_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysPluginPackageEventsProcess

	/// <exclude/>
	public class SysPluginPackageEventsProcess : SysPluginPackage_CrtBaseEventsProcess
	{

		public SysPluginPackageEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

