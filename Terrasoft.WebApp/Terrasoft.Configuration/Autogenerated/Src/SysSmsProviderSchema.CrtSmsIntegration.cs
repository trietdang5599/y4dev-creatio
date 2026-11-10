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

	#region Class: SysSmsProviderSchema

	/// <exclude/>
	public class SysSmsProviderSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public SysSmsProviderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysSmsProviderSchema(SysSmsProviderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysSmsProviderSchema(SysSmsProviderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIUniqueCodeIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = true
			};
			index.UId = new Guid("b9fbbe92-3a23-4f6d-8aff-7e7155da6939");
			index.Name = "IUniqueCode";
			index.CreatedInSchemaUId = new Guid("bed39b05-c1eb-4563-aca1-31a2e53f071c");
			index.ModifiedInSchemaUId = new Guid("bed39b05-c1eb-4563-aca1-31a2e53f071c");
			index.CreatedInPackageId = new Guid("8072a16c-3346-4584-9d8f-d4154fb2b290");
			EntitySchemaIndexColumn codeIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("f17e968e-74a8-34c0-78fb-60f97b85d1e2"),
				ColumnUId = new Guid("8c53ad32-e9d9-abae-cf3b-fb594d1836f5"),
				CreatedInSchemaUId = new Guid("bed39b05-c1eb-4563-aca1-31a2e53f071c"),
				ModifiedInSchemaUId = new Guid("bed39b05-c1eb-4563-aca1-31a2e53f071c"),
				CreatedInPackageId = new Guid("8072a16c-3346-4584-9d8f-d4154fb2b290"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(codeIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("bed39b05-c1eb-4563-aca1-31a2e53f071c");
			RealUId = new Guid("bed39b05-c1eb-4563-aca1-31a2e53f071c");
			Name = "SysSmsProvider";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("8072a16c-3346-4584-9d8f-d4154fb2b290");
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
			if (Columns.FindByUId(new Guid("8c53ad32-e9d9-abae-cf3b-fb594d1836f5")) == null) {
				Columns.Add(CreateCodeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("8c53ad32-e9d9-abae-cf3b-fb594d1836f5"),
				Name = @"Code",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("bed39b05-c1eb-4563-aca1-31a2e53f071c"),
				ModifiedInSchemaUId = new Guid("bed39b05-c1eb-4563-aca1-31a2e53f071c"),
				CreatedInPackageId = new Guid("8072a16c-3346-4584-9d8f-d4154fb2b290")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIUniqueCodeIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysSmsProvider(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysSmsProvider_CrtSmsIntegrationEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysSmsProviderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysSmsProviderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("bed39b05-c1eb-4563-aca1-31a2e53f071c"));
		}

		#endregion

	}

	#endregion

	#region Class: SysSmsProvider

	/// <summary>
	/// SMS providers.
	/// </summary>
	public class SysSmsProvider : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public SysSmsProvider(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysSmsProvider";
		}

		public SysSmsProvider(SysSmsProvider source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Code.
		/// </summary>
		public string Code {
			get {
				return GetTypedColumnValue<string>("Code");
			}
			set {
				SetColumnValue("Code", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysSmsProvider_CrtSmsIntegrationEventsProcess(UserConnection);
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
			return new SysSmsProvider(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysSmsProvider_CrtSmsIntegrationEventsProcess

	/// <exclude/>
	public partial class SysSmsProvider_CrtSmsIntegrationEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysSmsProvider
	{

		public SysSmsProvider_CrtSmsIntegrationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysSmsProvider_CrtSmsIntegrationEventsProcess";
			SchemaUId = new Guid("bed39b05-c1eb-4563-aca1-31a2e53f071c");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("bed39b05-c1eb-4563-aca1-31a2e53f071c");
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

	#region Class: SysSmsProvider_CrtSmsIntegrationEventsProcess

	/// <exclude/>
	public class SysSmsProvider_CrtSmsIntegrationEventsProcess : SysSmsProvider_CrtSmsIntegrationEventsProcess<SysSmsProvider>
	{

		public SysSmsProvider_CrtSmsIntegrationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysSmsProvider_CrtSmsIntegrationEventsProcess

	public partial class SysSmsProvider_CrtSmsIntegrationEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysSmsProviderEventsProcess

	/// <exclude/>
	public class SysSmsProviderEventsProcess : SysSmsProvider_CrtSmsIntegrationEventsProcess
	{

		public SysSmsProviderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

