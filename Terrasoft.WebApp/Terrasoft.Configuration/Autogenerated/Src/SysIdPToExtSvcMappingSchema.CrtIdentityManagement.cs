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

	#region Class: SysIdPToExtSvcMappingSchema

	/// <exclude/>
	public class SysIdPToExtSvcMappingSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysIdPToExtSvcMappingSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysIdPToExtSvcMappingSchema(SysIdPToExtSvcMappingSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysIdPToExtSvcMappingSchema(SysIdPToExtSvcMappingSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIdentityProviderToServiceIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = true
			};
			index.UId = new Guid("0bf04483-94d0-d33a-62b9-e874c7de53dd");
			index.Name = "IdentityProviderToService";
			index.CreatedInSchemaUId = new Guid("ac137ff1-0dc3-438f-bac4-6b50ae035732");
			index.ModifiedInSchemaUId = new Guid("ac137ff1-0dc3-438f-bac4-6b50ae035732");
			index.CreatedInPackageId = new Guid("cff97e97-8c0b-42df-8103-46a7d5ed8084");
			EntitySchemaIndexColumn identityProviderIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("47ea3e1f-cd89-f3a4-2be0-c52b547ac8d0"),
				ColumnUId = new Guid("0816c280-1e06-d02c-5e52-1add7af9e1fb"),
				CreatedInSchemaUId = new Guid("ac137ff1-0dc3-438f-bac4-6b50ae035732"),
				ModifiedInSchemaUId = new Guid("ac137ff1-0dc3-438f-bac4-6b50ae035732"),
				CreatedInPackageId = new Guid("cff97e97-8c0b-42df-8103-46a7d5ed8084"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(identityProviderIdIndexColumn);
			EntitySchemaIndexColumn serviceIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("b3c07495-0936-a9c8-7998-9fb84c478342"),
				ColumnUId = new Guid("efc207cb-dd9c-8fe2-1374-fa8ccfe6cf62"),
				CreatedInSchemaUId = new Guid("ac137ff1-0dc3-438f-bac4-6b50ae035732"),
				ModifiedInSchemaUId = new Guid("ac137ff1-0dc3-438f-bac4-6b50ae035732"),
				CreatedInPackageId = new Guid("cff97e97-8c0b-42df-8103-46a7d5ed8084"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(serviceIdIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ac137ff1-0dc3-438f-bac4-6b50ae035732");
			RealUId = new Guid("ac137ff1-0dc3-438f-bac4-6b50ae035732");
			Name = "SysIdPToExtSvcMapping";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("564abb0b-7665-4246-9a99-40c2c6eb2580");
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
			if (Columns.FindByUId(new Guid("0816c280-1e06-d02c-5e52-1add7af9e1fb")) == null) {
				Columns.Add(CreateIdentityProviderColumn());
			}
			if (Columns.FindByUId(new Guid("efc207cb-dd9c-8fe2-1374-fa8ccfe6cf62")) == null) {
				Columns.Add(CreateServiceColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateIdentityProviderColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("0816c280-1e06-d02c-5e52-1add7af9e1fb"),
				Name = @"IdentityProvider",
				ReferenceSchemaUId = new Guid("69b7d2ca-4864-45d1-8a0b-d0fe4b6bc12d"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ac137ff1-0dc3-438f-bac4-6b50ae035732"),
				ModifiedInSchemaUId = new Guid("ac137ff1-0dc3-438f-bac4-6b50ae035732"),
				CreatedInPackageId = new Guid("564abb0b-7665-4246-9a99-40c2c6eb2580"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateServiceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("efc207cb-dd9c-8fe2-1374-fa8ccfe6cf62"),
				Name = @"Service",
				ReferenceSchemaUId = new Guid("037ac083-5c69-4554-9b4d-03bec28e270b"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ac137ff1-0dc3-438f-bac4-6b50ae035732"),
				ModifiedInSchemaUId = new Guid("ac137ff1-0dc3-438f-bac4-6b50ae035732"),
				CreatedInPackageId = new Guid("46b5d340-da4e-42c2-88d7-181b4faa73e9"),
				IsSimpleLookup = true
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIdentityProviderToServiceIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysIdPToExtSvcMapping(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysIdPToExtSvcMapping_CrtIdentityManagementEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysIdPToExtSvcMappingSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysIdPToExtSvcMappingSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ac137ff1-0dc3-438f-bac4-6b50ae035732"));
		}

		#endregion

	}

	#endregion

	#region Class: SysIdPToExtSvcMapping

	/// <summary>
	/// Identity provider to external service mapping.
	/// </summary>
	public class SysIdPToExtSvcMapping : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysIdPToExtSvcMapping(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysIdPToExtSvcMapping";
		}

		public SysIdPToExtSvcMapping(SysIdPToExtSvcMapping source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid IdentityProviderId {
			get {
				return GetTypedColumnValue<Guid>("IdentityProviderId");
			}
			set {
				SetColumnValue("IdentityProviderId", value);
				_identityProvider = null;
			}
		}

		/// <exclude/>
		public string IdentityProviderName {
			get {
				return GetTypedColumnValue<string>("IdentityProviderName");
			}
			set {
				SetColumnValue("IdentityProviderName", value);
				if (_identityProvider != null) {
					_identityProvider.Name = value;
				}
			}
		}

		private SysIdentityProvider _identityProvider;
		/// <summary>
		/// Identity Provider.
		/// </summary>
		public SysIdentityProvider IdentityProvider {
			get {
				return _identityProvider ??
					(_identityProvider = LookupColumnEntities.GetEntity("IdentityProvider") as SysIdentityProvider);
			}
		}

		/// <exclude/>
		public Guid ServiceId {
			get {
				return GetTypedColumnValue<Guid>("ServiceId");
			}
			set {
				SetColumnValue("ServiceId", value);
				_service = null;
			}
		}

		/// <exclude/>
		public string ServiceName {
			get {
				return GetTypedColumnValue<string>("ServiceName");
			}
			set {
				SetColumnValue("ServiceName", value);
				if (_service != null) {
					_service.Name = value;
				}
			}
		}

		private SysExternalService _service;
		/// <summary>
		/// Service.
		/// </summary>
		public SysExternalService Service {
			get {
				return _service ??
					(_service = LookupColumnEntities.GetEntity("Service") as SysExternalService);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysIdPToExtSvcMapping_CrtIdentityManagementEventsProcess(UserConnection);
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
			return new SysIdPToExtSvcMapping(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysIdPToExtSvcMapping_CrtIdentityManagementEventsProcess

	/// <exclude/>
	public partial class SysIdPToExtSvcMapping_CrtIdentityManagementEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysIdPToExtSvcMapping
	{

		public SysIdPToExtSvcMapping_CrtIdentityManagementEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysIdPToExtSvcMapping_CrtIdentityManagementEventsProcess";
			SchemaUId = new Guid("ac137ff1-0dc3-438f-bac4-6b50ae035732");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ac137ff1-0dc3-438f-bac4-6b50ae035732");
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

	#region Class: SysIdPToExtSvcMapping_CrtIdentityManagementEventsProcess

	/// <exclude/>
	public class SysIdPToExtSvcMapping_CrtIdentityManagementEventsProcess : SysIdPToExtSvcMapping_CrtIdentityManagementEventsProcess<SysIdPToExtSvcMapping>
	{

		public SysIdPToExtSvcMapping_CrtIdentityManagementEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysIdPToExtSvcMapping_CrtIdentityManagementEventsProcess

	public partial class SysIdPToExtSvcMapping_CrtIdentityManagementEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysIdPToExtSvcMappingEventsProcess

	/// <exclude/>
	public class SysIdPToExtSvcMappingEventsProcess : SysIdPToExtSvcMapping_CrtIdentityManagementEventsProcess
	{

		public SysIdPToExtSvcMappingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

