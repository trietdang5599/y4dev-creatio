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

	#region Class: SysHttpHeaderSchema

	/// <exclude/>
	public class SysHttpHeaderSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysHttpHeaderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysHttpHeaderSchema(SysHttpHeaderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysHttpHeaderSchema(SysHttpHeaderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateUX_SysHttpHeader_Name_EP_MethIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = true
			};
			index.UId = new Guid("2adcaf57-0589-4b94-9d05-915d9124992c");
			index.Name = "UX_SysHttpHeader_Name_EP_Meth";
			index.CreatedInSchemaUId = new Guid("f6f871f7-f44c-42d4-9a42-fda967c24d43");
			index.ModifiedInSchemaUId = new Guid("f6f871f7-f44c-42d4-9a42-fda967c24d43");
			index.CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f");
			EntitySchemaIndexColumn nameIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("24be3a1d-32ec-d6d9-3526-397108e4a942"),
				ColumnUId = new Guid("1b4a5bc9-0788-5be9-56dc-d431708d9f2f"),
				CreatedInSchemaUId = new Guid("f6f871f7-f44c-42d4-9a42-fda967c24d43"),
				ModifiedInSchemaUId = new Guid("f6f871f7-f44c-42d4-9a42-fda967c24d43"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(nameIndexColumn);
			EntitySchemaIndexColumn endpointIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("96b84180-2f1f-f226-e28a-90d9aac1d981"),
				ColumnUId = new Guid("3f58fd0f-fc90-3ce8-eac3-b759b5059034"),
				CreatedInSchemaUId = new Guid("f6f871f7-f44c-42d4-9a42-fda967c24d43"),
				ModifiedInSchemaUId = new Guid("f6f871f7-f44c-42d4-9a42-fda967c24d43"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(endpointIndexColumn);
			EntitySchemaIndexColumn requestMethodIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("8b11d8d7-d5d0-539a-5eb9-adb27e9101c3"),
				ColumnUId = new Guid("0a9c77b7-61ff-1cad-7bfe-d46b86eb55cd"),
				CreatedInSchemaUId = new Guid("f6f871f7-f44c-42d4-9a42-fda967c24d43"),
				ModifiedInSchemaUId = new Guid("f6f871f7-f44c-42d4-9a42-fda967c24d43"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(requestMethodIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f6f871f7-f44c-42d4-9a42-fda967c24d43");
			RealUId = new Guid("f6f871f7-f44c-42d4-9a42-fda967c24d43");
			Name = "SysHttpHeader";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f");
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
			if (Columns.FindByUId(new Guid("3f58fd0f-fc90-3ce8-eac3-b759b5059034")) == null) {
				Columns.Add(CreateEndpointColumn());
			}
			if (Columns.FindByUId(new Guid("4659c3c9-e5e9-205a-f81f-7e44547b5685")) == null) {
				Columns.Add(CreateValueColumn());
			}
			if (Columns.FindByUId(new Guid("1b4a5bc9-0788-5be9-56dc-d431708d9f2f")) == null) {
				Columns.Add(CreateNameColumn());
			}
			if (Columns.FindByUId(new Guid("0a9c77b7-61ff-1cad-7bfe-d46b86eb55cd")) == null) {
				Columns.Add(CreateRequestMethodColumn());
			}
			if (Columns.FindByUId(new Guid("235611d9-ac9f-7627-5e8a-d44a527e6102")) == null) {
				Columns.Add(CreateSourceTypeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateEndpointColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("3f58fd0f-fc90-3ce8-eac3-b759b5059034"),
				Name = @"Endpoint",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("f6f871f7-f44c-42d4-9a42-fda967c24d43"),
				ModifiedInSchemaUId = new Guid("f6f871f7-f44c-42d4-9a42-fda967c24d43"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"*"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("4659c3c9-e5e9-205a-f81f-7e44547b5685"),
				Name = @"Value",
				CreatedInSchemaUId = new Guid("f6f871f7-f44c-42d4-9a42-fda967c24d43"),
				ModifiedInSchemaUId = new Guid("f6f871f7-f44c-42d4-9a42-fda967c24d43"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("1b4a5bc9-0788-5be9-56dc-d431708d9f2f"),
				Name = @"Name",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("f6f871f7-f44c-42d4-9a42-fda967c24d43"),
				ModifiedInSchemaUId = new Guid("f6f871f7-f44c-42d4-9a42-fda967c24d43"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected virtual EntitySchemaColumn CreateRequestMethodColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("0a9c77b7-61ff-1cad-7bfe-d46b86eb55cd"),
				Name = @"RequestMethod",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("f6f871f7-f44c-42d4-9a42-fda967c24d43"),
				ModifiedInSchemaUId = new Guid("f6f871f7-f44c-42d4-9a42-fda967c24d43"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"*"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateSourceTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("235611d9-ac9f-7627-5e8a-d44a527e6102"),
				Name = @"SourceType",
				IsValueCloneable = false,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("f6f871f7-f44c-42d4-9a42-fda967c24d43"),
				ModifiedInSchemaUId = new Guid("f6f871f7-f44c-42d4-9a42-fda967c24d43"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"0"
				}
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateUX_SysHttpHeader_Name_EP_MethIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysHttpHeader(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysHttpHeader_CrtCoreBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysHttpHeaderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysHttpHeaderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f6f871f7-f44c-42d4-9a42-fda967c24d43"));
		}

		#endregion

	}

	#endregion

	#region Class: SysHttpHeader

	/// <summary>
	/// HTTP response header.
	/// </summary>
	public class SysHttpHeader : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysHttpHeader(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysHttpHeader";
		}

		public SysHttpHeader(SysHttpHeader source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Endpoint URL.
		/// </summary>
		public string Endpoint {
			get {
				return GetTypedColumnValue<string>("Endpoint");
			}
			set {
				SetColumnValue("Endpoint", value);
			}
		}

		/// <summary>
		/// Header value.
		/// </summary>
		public string Value {
			get {
				return GetTypedColumnValue<string>("Value");
			}
			set {
				SetColumnValue("Value", value);
			}
		}

		/// <summary>
		/// Header name.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		/// <summary>
		/// Request method.
		/// </summary>
		public string RequestMethod {
			get {
				return GetTypedColumnValue<string>("RequestMethod");
			}
			set {
				SetColumnValue("RequestMethod", value);
			}
		}

		/// <summary>
		/// Header source type.
		/// </summary>
		public int SourceType {
			get {
				return GetTypedColumnValue<int>("SourceType");
			}
			set {
				SetColumnValue("SourceType", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysHttpHeader_CrtCoreBaseEventsProcess(UserConnection);
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
			return new SysHttpHeader(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysHttpHeader_CrtCoreBaseEventsProcess

	/// <exclude/>
	public partial class SysHttpHeader_CrtCoreBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysHttpHeader
	{

		public SysHttpHeader_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysHttpHeader_CrtCoreBaseEventsProcess";
			SchemaUId = new Guid("f6f871f7-f44c-42d4-9a42-fda967c24d43");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("f6f871f7-f44c-42d4-9a42-fda967c24d43");
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

	#region Class: SysHttpHeader_CrtCoreBaseEventsProcess

	/// <exclude/>
	public class SysHttpHeader_CrtCoreBaseEventsProcess : SysHttpHeader_CrtCoreBaseEventsProcess<SysHttpHeader>
	{

		public SysHttpHeader_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysHttpHeader_CrtCoreBaseEventsProcess

	public partial class SysHttpHeader_CrtCoreBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysHttpHeaderEventsProcess

	/// <exclude/>
	public class SysHttpHeaderEventsProcess : SysHttpHeader_CrtCoreBaseEventsProcess
	{

		public SysHttpHeaderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

