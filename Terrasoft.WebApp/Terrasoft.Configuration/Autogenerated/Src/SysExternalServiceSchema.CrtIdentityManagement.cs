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

	#region Class: SysExternalServiceSchema

	/// <exclude/>
	public class SysExternalServiceSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public SysExternalServiceSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysExternalServiceSchema(SysExternalServiceSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysExternalServiceSchema(SysExternalServiceSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateCodeIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = true
			};
			index.UId = new Guid("a8671673-a31e-c7f7-6602-29646eb794e4");
			index.Name = "Code";
			index.CreatedInSchemaUId = new Guid("037ac083-5c69-4554-9b4d-03bec28e270b");
			index.ModifiedInSchemaUId = new Guid("037ac083-5c69-4554-9b4d-03bec28e270b");
			index.CreatedInPackageId = new Guid("cff97e97-8c0b-42df-8103-46a7d5ed8084");
			EntitySchemaIndexColumn codeIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("84418d07-f4ea-a690-312e-6e339f6c03e0"),
				ColumnUId = new Guid("20e929bc-0b82-be93-16a9-9f9260a6aeb5"),
				CreatedInSchemaUId = new Guid("037ac083-5c69-4554-9b4d-03bec28e270b"),
				ModifiedInSchemaUId = new Guid("037ac083-5c69-4554-9b4d-03bec28e270b"),
				CreatedInPackageId = new Guid("cff97e97-8c0b-42df-8103-46a7d5ed8084"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(codeIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("037ac083-5c69-4554-9b4d-03bec28e270b");
			RealUId = new Guid("037ac083-5c69-4554-9b4d-03bec28e270b");
			Name = "SysExternalService";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("f6b38227-1ecd-47c0-a4e5-182a47ac5e27");
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
			if (Columns.FindByUId(new Guid("20e929bc-0b82-be93-16a9-9f9260a6aeb5")) == null) {
				Columns.Add(CreateCodeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("20e929bc-0b82-be93-16a9-9f9260a6aeb5"),
				Name = @"Code",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("037ac083-5c69-4554-9b4d-03bec28e270b"),
				ModifiedInSchemaUId = new Guid("037ac083-5c69-4554-9b4d-03bec28e270b"),
				CreatedInPackageId = new Guid("f6b38227-1ecd-47c0-a4e5-182a47ac5e27")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateCodeIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysExternalService(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysExternalService_CrtIdentityManagementEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysExternalServiceSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysExternalServiceSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("037ac083-5c69-4554-9b4d-03bec28e270b"));
		}

		#endregion

	}

	#endregion

	#region Class: SysExternalService

	/// <summary>
	/// External service.
	/// </summary>
	public class SysExternalService : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public SysExternalService(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysExternalService";
		}

		public SysExternalService(SysExternalService source)
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
			var process = new SysExternalService_CrtIdentityManagementEventsProcess(UserConnection);
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
			return new SysExternalService(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysExternalService_CrtIdentityManagementEventsProcess

	/// <exclude/>
	public partial class SysExternalService_CrtIdentityManagementEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysExternalService
	{

		public SysExternalService_CrtIdentityManagementEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysExternalService_CrtIdentityManagementEventsProcess";
			SchemaUId = new Guid("037ac083-5c69-4554-9b4d-03bec28e270b");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("037ac083-5c69-4554-9b4d-03bec28e270b");
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

	#region Class: SysExternalService_CrtIdentityManagementEventsProcess

	/// <exclude/>
	public class SysExternalService_CrtIdentityManagementEventsProcess : SysExternalService_CrtIdentityManagementEventsProcess<SysExternalService>
	{

		public SysExternalService_CrtIdentityManagementEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysExternalService_CrtIdentityManagementEventsProcess

	public partial class SysExternalService_CrtIdentityManagementEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysExternalServiceEventsProcess

	/// <exclude/>
	public class SysExternalServiceEventsProcess : SysExternalService_CrtIdentityManagementEventsProcess
	{

		public SysExternalServiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

