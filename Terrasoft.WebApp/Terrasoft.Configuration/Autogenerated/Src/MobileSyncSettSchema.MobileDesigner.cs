namespace Terrasoft.Configuration
{

	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.IO;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;

	#region Class: MobileSyncSettSchema

	/// <exclude/>
	[IsVirtual]
	public class MobileSyncSettSchema : Terrasoft.Core.Entities.EntitySchema
	{

		#region Constructors: Public

		public MobileSyncSettSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public MobileSyncSettSchema(MobileSyncSettSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public MobileSyncSettSchema(MobileSyncSettSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7412bbef-fe51-4fbf-8a61-a64c133e6095");
			RealUId = new Guid("7412bbef-fe51-4fbf-8a61-a64c133e6095");
			Name = "MobileSyncSett";
			ParentSchemaUId = new Guid("1b56b061-4e91-4974-9038-df8340e534f2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("4205749e-ab4a-4904-a4f5-6104a67c5ae5");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryColumn() {
			base.InitializePrimaryColumn();
			PrimaryColumn = CreateIdColumn();
			if (Columns.FindByUId(PrimaryColumn.UId) == null) {
				Columns.Add(PrimaryColumn);
			}
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateEntityCaptionColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("d24a8d81-94b4-4376-d10f-ae650a6574ce")) == null) {
				Columns.Add(CreateWorkplaceCodeColumn());
			}
			if (Columns.FindByUId(new Guid("16e56b05-b9f6-8af7-d8ab-9bceee1d2b85")) == null) {
				Columns.Add(CreateIsEnabledColumn());
			}
			if (Columns.FindByUId(new Guid("088daa1e-4a55-73d7-9d24-81292b6d95e2")) == null) {
				Columns.Add(CreateCountColumn());
			}
			if (Columns.FindByUId(new Guid("d50c8ad1-d40e-ed5e-c16c-82ab948b8838")) == null) {
				Columns.Add(CreateTotalCountColumn());
			}
			if (Columns.FindByUId(new Guid("0c873556-e74a-6646-a122-93516c704b0f")) == null) {
				Columns.Add(CreateEntityNameColumn());
			}
			if (Columns.FindByUId(new Guid("aa3cb291-9c64-d8c0-b817-64e6b5fa4a76")) == null) {
				Columns.Add(CreateFilterDataColumn());
			}
			if (Columns.FindByUId(new Guid("842a1580-765b-5631-9565-74339f862451")) == null) {
				Columns.Add(CreateWorkplaceNameColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("0e501436-cf6e-20e1-c369-e48a86046079"),
				Name = @"Id",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("7412bbef-fe51-4fbf-8a61-a64c133e6095"),
				ModifiedInSchemaUId = new Guid("7412bbef-fe51-4fbf-8a61-a64c133e6095"),
				CreatedInPackageId = new Guid("4259b019-4b0a-46c5-a1eb-719d779d8049")
			};
		}

		protected virtual EntitySchemaColumn CreateWorkplaceCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("d24a8d81-94b4-4376-d10f-ae650a6574ce"),
				Name = @"WorkplaceCode",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("7412bbef-fe51-4fbf-8a61-a64c133e6095"),
				ModifiedInSchemaUId = new Guid("7412bbef-fe51-4fbf-8a61-a64c133e6095"),
				CreatedInPackageId = new Guid("4205749e-ab4a-4904-a4f5-6104a67c5ae5")
			};
		}

		protected virtual EntitySchemaColumn CreateIsEnabledColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("16e56b05-b9f6-8af7-d8ab-9bceee1d2b85"),
				Name = @"IsEnabled",
				CreatedInSchemaUId = new Guid("7412bbef-fe51-4fbf-8a61-a64c133e6095"),
				ModifiedInSchemaUId = new Guid("7412bbef-fe51-4fbf-8a61-a64c133e6095"),
				CreatedInPackageId = new Guid("4205749e-ab4a-4904-a4f5-6104a67c5ae5")
			};
		}

		protected virtual EntitySchemaColumn CreateCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("088daa1e-4a55-73d7-9d24-81292b6d95e2"),
				Name = @"Count",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("7412bbef-fe51-4fbf-8a61-a64c133e6095"),
				ModifiedInSchemaUId = new Guid("7412bbef-fe51-4fbf-8a61-a64c133e6095"),
				CreatedInPackageId = new Guid("4205749e-ab4a-4904-a4f5-6104a67c5ae5")
			};
		}

		protected virtual EntitySchemaColumn CreateTotalCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("d50c8ad1-d40e-ed5e-c16c-82ab948b8838"),
				Name = @"TotalCount",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("7412bbef-fe51-4fbf-8a61-a64c133e6095"),
				ModifiedInSchemaUId = new Guid("7412bbef-fe51-4fbf-8a61-a64c133e6095"),
				CreatedInPackageId = new Guid("4205749e-ab4a-4904-a4f5-6104a67c5ae5")
			};
		}

		protected virtual EntitySchemaColumn CreateEntityNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("0c873556-e74a-6646-a122-93516c704b0f"),
				Name = @"EntityName",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("7412bbef-fe51-4fbf-8a61-a64c133e6095"),
				ModifiedInSchemaUId = new Guid("7412bbef-fe51-4fbf-8a61-a64c133e6095"),
				CreatedInPackageId = new Guid("4205749e-ab4a-4904-a4f5-6104a67c5ae5")
			};
		}

		protected virtual EntitySchemaColumn CreateEntityCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("8b1006a1-0ba1-9810-17eb-b7bc6edca2b9"),
				Name = @"EntityCaption",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("7412bbef-fe51-4fbf-8a61-a64c133e6095"),
				ModifiedInSchemaUId = new Guid("7412bbef-fe51-4fbf-8a61-a64c133e6095"),
				CreatedInPackageId = new Guid("4205749e-ab4a-4904-a4f5-6104a67c5ae5")
			};
		}

		protected virtual EntitySchemaColumn CreateFilterDataColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("aa3cb291-9c64-d8c0-b817-64e6b5fa4a76"),
				Name = @"FilterData",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("7412bbef-fe51-4fbf-8a61-a64c133e6095"),
				ModifiedInSchemaUId = new Guid("7412bbef-fe51-4fbf-8a61-a64c133e6095"),
				CreatedInPackageId = new Guid("4259b019-4b0a-46c5-a1eb-719d779d8049")
			};
		}

		protected virtual EntitySchemaColumn CreateWorkplaceNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("842a1580-765b-5631-9565-74339f862451"),
				Name = @"WorkplaceName",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("7412bbef-fe51-4fbf-8a61-a64c133e6095"),
				ModifiedInSchemaUId = new Guid("7412bbef-fe51-4fbf-8a61-a64c133e6095"),
				CreatedInPackageId = new Guid("4259b019-4b0a-46c5-a1eb-719d779d8049")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new MobileSyncSett(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new MobileSyncSett_MobileDesignerEventsProcess(userConnection);
		}

		public override object Clone() {
			return new MobileSyncSettSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new MobileSyncSettSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7412bbef-fe51-4fbf-8a61-a64c133e6095"));
		}

		#endregion

	}

	#endregion

	#region Class: MobileSyncSett

	/// <summary>
	/// MobileSyncSettings.
	/// </summary>
	public class MobileSyncSett : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public MobileSyncSett(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MobileSyncSett";
		}

		public MobileSyncSett(MobileSyncSett source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Id.
		/// </summary>
		public Guid Id {
			get {
				return GetTypedColumnValue<Guid>("Id");
			}
			set {
				SetColumnValue("Id", value);
			}
		}

		/// <summary>
		/// Workplace code.
		/// </summary>
		public string WorkplaceCode {
			get {
				return GetTypedColumnValue<string>("WorkplaceCode");
			}
			set {
				SetColumnValue("WorkplaceCode", value);
			}
		}

		/// <summary>
		/// Enabled.
		/// </summary>
		public bool IsEnabled {
			get {
				return GetTypedColumnValue<bool>("IsEnabled");
			}
			set {
				SetColumnValue("IsEnabled", value);
			}
		}

		/// <summary>
		/// Filtered records count.
		/// </summary>
		public int Count {
			get {
				return GetTypedColumnValue<int>("Count");
			}
			set {
				SetColumnValue("Count", value);
			}
		}

		/// <summary>
		/// Total records count.
		/// </summary>
		public int TotalCount {
			get {
				return GetTypedColumnValue<int>("TotalCount");
			}
			set {
				SetColumnValue("TotalCount", value);
			}
		}

		/// <summary>
		/// Object name.
		/// </summary>
		public string EntityName {
			get {
				return GetTypedColumnValue<string>("EntityName");
			}
			set {
				SetColumnValue("EntityName", value);
			}
		}

		/// <summary>
		/// Object caption.
		/// </summary>
		public string EntityCaption {
			get {
				return GetTypedColumnValue<string>("EntityCaption");
			}
			set {
				SetColumnValue("EntityCaption", value);
			}
		}

		/// <summary>
		/// FilterData.
		/// </summary>
		public string FilterData {
			get {
				return GetTypedColumnValue<string>("FilterData");
			}
			set {
				SetColumnValue("FilterData", value);
			}
		}

		/// <summary>
		/// Workplace name.
		/// </summary>
		public string WorkplaceName {
			get {
				return GetTypedColumnValue<string>("WorkplaceName");
			}
			set {
				SetColumnValue("WorkplaceName", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new MobileSyncSett_MobileDesignerEventsProcess(UserConnection);
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
			return new MobileSyncSett(this);
		}

		#endregion

	}

	#endregion

	#region Class: MobileSyncSett_MobileDesignerEventsProcess

	/// <exclude/>
	public partial class MobileSyncSett_MobileDesignerEventsProcess<TEntity> : Terrasoft.Core.Process.EmbeddedProcess where TEntity : MobileSyncSett
	{

		private TEntity _entity;
		public TEntity Entity {
			get {
				return _entity;
			}
			set {
				_entity = value;
			}
		}

		public MobileSyncSett_MobileDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "MobileSyncSett_MobileDesignerEventsProcess";
			SchemaUId = new Guid("7412bbef-fe51-4fbf-8a61-a64c133e6095");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("7412bbef-fe51-4fbf-8a61-a64c133e6095");
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

	#region Class: MobileSyncSett_MobileDesignerEventsProcess

	/// <exclude/>
	public class MobileSyncSett_MobileDesignerEventsProcess : MobileSyncSett_MobileDesignerEventsProcess<MobileSyncSett>
	{

		public MobileSyncSett_MobileDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: MobileSyncSett_MobileDesignerEventsProcess

	public partial class MobileSyncSett_MobileDesignerEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: MobileSyncSettEventsProcess

	/// <exclude/>
	public class MobileSyncSettEventsProcess : MobileSyncSett_MobileDesignerEventsProcess
	{

		public MobileSyncSettEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

