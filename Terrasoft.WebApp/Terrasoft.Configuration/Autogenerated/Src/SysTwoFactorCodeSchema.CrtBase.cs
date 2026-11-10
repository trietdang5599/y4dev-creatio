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

	#region Class: SysTwoFactorCodeSchema

	/// <exclude/>
	public class SysTwoFactorCodeSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysTwoFactorCodeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysTwoFactorCodeSchema(SysTwoFactorCodeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysTwoFactorCodeSchema(SysTwoFactorCodeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("cb5790f2-b1b6-4cec-aeb9-65b9cb3348ac");
			RealUId = new Guid("cb5790f2-b1b6-4cec-aeb9-65b9cb3348ac");
			Name = "SysTwoFactorCode";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("60d2ad76-a9cc-4cf5-8319-1f95d5126d02");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = false;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("a55f1576-bd1d-f195-f50b-c602653890e0")) == null) {
				Columns.Add(CreateValueColumn());
			}
			if (Columns.FindByUId(new Guid("35d8903b-2247-6230-e52a-0a847c973504")) == null) {
				Columns.Add(CreateSysAdminUnitColumn());
			}
			if (Columns.FindByUId(new Guid("33996b9c-b32d-96dc-c37e-c521134916b0")) == null) {
				Columns.Add(CreateProviderColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("SecureText")) {
				UId = new Guid("a55f1576-bd1d-f195-f50b-c602653890e0"),
				Name = @"Value",
				CreatedInSchemaUId = new Guid("cb5790f2-b1b6-4cec-aeb9-65b9cb3348ac"),
				ModifiedInSchemaUId = new Guid("cb5790f2-b1b6-4cec-aeb9-65b9cb3348ac"),
				CreatedInPackageId = new Guid("60d2ad76-a9cc-4cf5-8319-1f95d5126d02")
			};
		}

		protected virtual EntitySchemaColumn CreateSysAdminUnitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("35d8903b-2247-6230-e52a-0a847c973504"),
				Name = @"SysAdminUnit",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("cb5790f2-b1b6-4cec-aeb9-65b9cb3348ac"),
				ModifiedInSchemaUId = new Guid("cb5790f2-b1b6-4cec-aeb9-65b9cb3348ac"),
				CreatedInPackageId = new Guid("60d2ad76-a9cc-4cf5-8319-1f95d5126d02")
			};
		}

		protected virtual EntitySchemaColumn CreateProviderColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("33996b9c-b32d-96dc-c37e-c521134916b0"),
				Name = @"Provider",
				CreatedInSchemaUId = new Guid("cb5790f2-b1b6-4cec-aeb9-65b9cb3348ac"),
				ModifiedInSchemaUId = new Guid("cb5790f2-b1b6-4cec-aeb9-65b9cb3348ac"),
				CreatedInPackageId = new Guid("50f552a9-0668-454a-8ecf-9cb468aabd1f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysTwoFactorCode(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysTwoFactorCode_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysTwoFactorCodeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysTwoFactorCodeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("cb5790f2-b1b6-4cec-aeb9-65b9cb3348ac"));
		}

		#endregion

	}

	#endregion

	#region Class: SysTwoFactorCode

	/// <summary>
	/// Two-Factor authentication code.
	/// </summary>
	public class SysTwoFactorCode : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysTwoFactorCode(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysTwoFactorCode";
		}

		public SysTwoFactorCode(SysTwoFactorCode source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Value.
		/// </summary>
		public string Value {
			get {
				return GetTypedColumnValue<string>("Value");
			}
			set {
				SetColumnValue("Value", value);
			}
		}

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
		/// Provider.
		/// </summary>
		public string Provider {
			get {
				return GetTypedColumnValue<string>("Provider");
			}
			set {
				SetColumnValue("Provider", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysTwoFactorCode_CrtBaseEventsProcess(UserConnection);
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
			return new SysTwoFactorCode(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysTwoFactorCode_CrtBaseEventsProcess

	/// <exclude/>
	public partial class SysTwoFactorCode_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysTwoFactorCode
	{

		public SysTwoFactorCode_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysTwoFactorCode_CrtBaseEventsProcess";
			SchemaUId = new Guid("cb5790f2-b1b6-4cec-aeb9-65b9cb3348ac");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("cb5790f2-b1b6-4cec-aeb9-65b9cb3348ac");
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

	#region Class: SysTwoFactorCode_CrtBaseEventsProcess

	/// <exclude/>
	public class SysTwoFactorCode_CrtBaseEventsProcess : SysTwoFactorCode_CrtBaseEventsProcess<SysTwoFactorCode>
	{

		public SysTwoFactorCode_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysTwoFactorCode_CrtBaseEventsProcess

	public partial class SysTwoFactorCode_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysTwoFactorCodeEventsProcess

	/// <exclude/>
	public class SysTwoFactorCodeEventsProcess : SysTwoFactorCode_CrtBaseEventsProcess
	{

		public SysTwoFactorCodeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

