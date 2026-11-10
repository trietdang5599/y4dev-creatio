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

	#region Class: DayType_Calendar_CreatioSchema

	/// <exclude/>
	public class DayType_Calendar_CreatioSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public DayType_Calendar_CreatioSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public DayType_Calendar_CreatioSchema(DayType_Calendar_CreatioSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public DayType_Calendar_CreatioSchema(DayType_Calendar_CreatioSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("1ad5f24a-ea0a-416e-a275-f0a79291d552");
			RealUId = new Guid("1ad5f24a-ea0a-416e-a275-f0a79291d552");
			Name = "DayType_Calendar_Creatio";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("449c4d55-5697-4701-9604-5ea63b8481a1")) == null) {
				Columns.Add(CreateColorColumn());
			}
			if (Columns.FindByUId(new Guid("6e46722f-6e70-4173-98cf-a82eecd437c0")) == null) {
				Columns.Add(CreateIsWeekendColumn());
			}
			if (Columns.FindByUId(new Guid("2d6290df-36da-4860-9d50-e537bbfaad4c")) == null) {
				Columns.Add(CreateNonWorkingColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("1ad5f24a-ea0a-416e-a275-f0a79291d552");
			column.CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("1ad5f24a-ea0a-416e-a275-f0a79291d552");
			column.CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("1ad5f24a-ea0a-416e-a275-f0a79291d552");
			column.CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("1ad5f24a-ea0a-416e-a275-f0a79291d552");
			column.CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("1ad5f24a-ea0a-416e-a275-f0a79291d552");
			column.CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("1ad5f24a-ea0a-416e-a275-f0a79291d552");
			column.CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("1ad5f24a-ea0a-416e-a275-f0a79291d552");
			column.CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("1ad5f24a-ea0a-416e-a275-f0a79291d552");
			column.CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862");
			return column;
		}

		protected virtual EntitySchemaColumn CreateColorColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Color")) {
				UId = new Guid("449c4d55-5697-4701-9604-5ea63b8481a1"),
				Name = @"Color",
				UsageType = EntitySchemaColumnUsageType.Advanced,
				CreatedInSchemaUId = new Guid("1ad5f24a-ea0a-416e-a275-f0a79291d552"),
				ModifiedInSchemaUId = new Guid("1ad5f24a-ea0a-416e-a275-f0a79291d552"),
				CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"#FFFFFF"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateIsWeekendColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("6e46722f-6e70-4173-98cf-a82eecd437c0"),
				Name = @"IsWeekend",
				CreatedInSchemaUId = new Guid("1ad5f24a-ea0a-416e-a275-f0a79291d552"),
				ModifiedInSchemaUId = new Guid("1ad5f24a-ea0a-416e-a275-f0a79291d552"),
				CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485")
			};
		}

		protected virtual EntitySchemaColumn CreateNonWorkingColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("2d6290df-36da-4860-9d50-e537bbfaad4c"),
				Name = @"NonWorking",
				CreatedInSchemaUId = new Guid("1ad5f24a-ea0a-416e-a275-f0a79291d552"),
				ModifiedInSchemaUId = new Guid("1ad5f24a-ea0a-416e-a275-f0a79291d552"),
				CreatedInPackageId = new Guid("d2179f89-6a33-4745-96ee-fd30f06a5c1f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new DayType_Calendar_Creatio(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new DayType_CalendarEventsProcess(userConnection);
		}

		public override object Clone() {
			return new DayType_Calendar_CreatioSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new DayType_Calendar_CreatioSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1ad5f24a-ea0a-416e-a275-f0a79291d552"));
		}

		#endregion

	}

	#endregion

	#region Class: DayType_Calendar_Creatio

	/// <summary>
	/// Day type.
	/// </summary>
	public class DayType_Calendar_Creatio : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public DayType_Calendar_Creatio(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "DayType_Calendar_Creatio";
		}

		public DayType_Calendar_Creatio(DayType_Calendar_Creatio source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Color.
		/// </summary>
		public Color Color {
			get {
				return GetTypedColumnValue<Color>("Color");
			}
			set {
				SetColumnValue("Color", value);
			}
		}

		/// <summary>
		/// Day off.
		/// </summary>
		public bool IsWeekend {
			get {
				return GetTypedColumnValue<bool>("IsWeekend");
			}
			set {
				SetColumnValue("IsWeekend", value);
			}
		}

		/// <summary>
		/// Non working day.
		/// </summary>
		public bool NonWorking {
			get {
				return GetTypedColumnValue<bool>("NonWorking");
			}
			set {
				SetColumnValue("NonWorking", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new DayType_CalendarEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("DayType_Calendar_CreatioDeleted", e);
			Inserting += (s, e) => ThrowEvent("DayType_Calendar_CreatioInserting", e);
			Validating += (s, e) => ThrowEvent("DayType_Calendar_CreatioValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new DayType_Calendar_Creatio(this);
		}

		#endregion

	}

	#endregion

	#region Class: DayType_CalendarEventsProcess

	/// <exclude/>
	public partial class DayType_CalendarEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : DayType_Calendar_Creatio
	{

		public DayType_CalendarEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "DayType_CalendarEventsProcess";
			SchemaUId = new Guid("1ad5f24a-ea0a-416e-a275-f0a79291d552");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("1ad5f24a-ea0a-416e-a275-f0a79291d552");
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

	#region Class: DayType_CalendarEventsProcess

	/// <exclude/>
	public class DayType_CalendarEventsProcess : DayType_CalendarEventsProcess<DayType_Calendar_Creatio>
	{

		public DayType_CalendarEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: DayType_CalendarEventsProcess

	public partial class DayType_CalendarEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

