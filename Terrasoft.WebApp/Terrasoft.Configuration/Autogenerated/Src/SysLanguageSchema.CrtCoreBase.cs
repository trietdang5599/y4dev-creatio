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

	#region Class: SysLanguageSchema

	/// <exclude/>
	public class SysLanguageSchema : Terrasoft.Configuration.BaseCodeLookupSchema
	{

		#region Constructors: Public

		public SysLanguageSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysLanguageSchema(SysLanguageSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysLanguageSchema(SysLanguageSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("2f96cb61-7e14-41e5-980a-bcb856edab51");
			RealUId = new Guid("2f96cb61-7e14-41e5-980a-bcb856edab51");
			Name = "SysLanguage";
			ParentSchemaUId = new Guid("2681062b-df59-4e52-89ed-f9b7dc909ab2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("d6f595db-31d2-468d-b812-fe27697687f7");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
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
			if (Columns.FindByUId(new Guid("affb1d22-3058-4c56-828a-1b49e64ef89e")) == null) {
				Columns.Add(CreateIsUsedColumn());
			}
			if (Columns.FindByUId(new Guid("a55a2255-9b82-d01f-c145-44ef77060ceb")) == null) {
				Columns.Add(CreateSysCultureDefIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateIsUsedColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("affb1d22-3058-4c56-828a-1b49e64ef89e"),
				Name = @"IsUsed",
				CreatedInSchemaUId = new Guid("2f96cb61-7e14-41e5-980a-bcb856edab51"),
				ModifiedInSchemaUId = new Guid("2f96cb61-7e14-41e5-980a-bcb856edab51"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateSysCultureDefIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("a55a2255-9b82-d01f-c145-44ef77060ceb"),
				Name = @"SysCultureDefId",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("2f96cb61-7e14-41e5-980a-bcb856edab51"),
				ModifiedInSchemaUId = new Guid("2f96cb61-7e14-41e5-980a-bcb856edab51"),
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"AutoGuid")
				}
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysLanguage(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysLanguage_CrtCoreBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysLanguageSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysLanguageSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2f96cb61-7e14-41e5-980a-bcb856edab51"));
		}

		#endregion

	}

	#endregion

	#region Class: SysLanguage

	/// <summary>
	/// Language.
	/// </summary>
	public class SysLanguage : Terrasoft.Configuration.BaseCodeLookup
	{

		#region Constructors: Public

		public SysLanguage(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysLanguage";
		}

		public SysLanguage(SysLanguage source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Is used.
		/// </summary>
		public bool IsUsed {
			get {
				return GetTypedColumnValue<bool>("IsUsed");
			}
			set {
				SetColumnValue("IsUsed", value);
			}
		}

		/// <summary>
		/// SysCultureDefId.
		/// </summary>
		public Guid SysCultureDefId {
			get {
				return GetTypedColumnValue<Guid>("SysCultureDefId");
			}
			set {
				SetColumnValue("SysCultureDefId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysLanguage_CrtCoreBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysLanguageDeleted", e);
			Validating += (s, e) => ThrowEvent("SysLanguageValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysLanguage(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysLanguage_CrtCoreBaseEventsProcess

	/// <exclude/>
	public partial class SysLanguage_CrtCoreBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseCodeLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysLanguage
	{

		public SysLanguage_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysLanguage_CrtCoreBaseEventsProcess";
			SchemaUId = new Guid("2f96cb61-7e14-41e5-980a-bcb856edab51");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("2f96cb61-7e14-41e5-980a-bcb856edab51");
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

	#region Class: SysLanguage_CrtCoreBaseEventsProcess

	/// <exclude/>
	public class SysLanguage_CrtCoreBaseEventsProcess : SysLanguage_CrtCoreBaseEventsProcess<SysLanguage>
	{

		public SysLanguage_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysLanguage_CrtCoreBaseEventsProcess

	public partial class SysLanguage_CrtCoreBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysLanguageEventsProcess

	/// <exclude/>
	public class SysLanguageEventsProcess : SysLanguage_CrtCoreBaseEventsProcess
	{

		public SysLanguageEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

