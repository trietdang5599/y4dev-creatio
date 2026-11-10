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

	#region Class: MockableServiceUrlSchema

	/// <exclude/>
	public class MockableServiceUrlSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public MockableServiceUrlSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public MockableServiceUrlSchema(MockableServiceUrlSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public MockableServiceUrlSchema(MockableServiceUrlSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b0067da8-d3f7-4e36-930d-0fe569f561ec");
			RealUId = new Guid("b0067da8-d3f7-4e36-930d-0fe569f561ec");
			Name = "MockableServiceUrl";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("bfdf3d96-e43f-4660-bbd5-b1d1e334ffc7");
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
			if (Columns.FindByUId(new Guid("8263a20d-9398-4845-931e-813bc4ec0d01")) == null) {
				Columns.Add(CreateHttpMethodColumn());
			}
			if (Columns.FindByUId(new Guid("c8b8f123-fc68-4b45-9b25-cdc580f972d3")) == null) {
				Columns.Add(CreateUrlColumn());
			}
			if (Columns.FindByUId(new Guid("b338a2c1-9321-43ec-a6c8-cadea2fda86a")) == null) {
				Columns.Add(CreateResponseCodeColumn());
			}
			if (Columns.FindByUId(new Guid("5367dce9-4e04-4e48-b5ac-0ff268d6c9ab")) == null) {
				Columns.Add(CreateResponseBodyColumn());
			}
			if (Columns.FindByUId(new Guid("a802d17a-30e7-27b1-b8ec-8e09396a7dc2")) == null) {
				Columns.Add(CreateExecCountColumn());
			}
			if (Columns.FindByUId(new Guid("7fa0a835-e536-5af8-f770-dac9f90707c0")) == null) {
				Columns.Add(CreateRequestBodyPatternColumn());
			}
			if (Columns.FindByUId(new Guid("70828107-9e78-69d8-7e31-70443d929264")) == null) {
				Columns.Add(CreateRequestBodyAntiPatternColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateHttpMethodColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("8263a20d-9398-4845-931e-813bc4ec0d01"),
				Name = @"HttpMethod",
				CreatedInSchemaUId = new Guid("b0067da8-d3f7-4e36-930d-0fe569f561ec"),
				ModifiedInSchemaUId = new Guid("b0067da8-d3f7-4e36-930d-0fe569f561ec"),
				CreatedInPackageId = new Guid("bfdf3d96-e43f-4660-bbd5-b1d1e334ffc7")
			};
		}

		protected virtual EntitySchemaColumn CreateUrlColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("c8b8f123-fc68-4b45-9b25-cdc580f972d3"),
				Name = @"Url",
				CreatedInSchemaUId = new Guid("b0067da8-d3f7-4e36-930d-0fe569f561ec"),
				ModifiedInSchemaUId = new Guid("b0067da8-d3f7-4e36-930d-0fe569f561ec"),
				CreatedInPackageId = new Guid("bfdf3d96-e43f-4660-bbd5-b1d1e334ffc7")
			};
		}

		protected virtual EntitySchemaColumn CreateResponseCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("b338a2c1-9321-43ec-a6c8-cadea2fda86a"),
				Name = @"ResponseCode",
				CreatedInSchemaUId = new Guid("b0067da8-d3f7-4e36-930d-0fe569f561ec"),
				ModifiedInSchemaUId = new Guid("b0067da8-d3f7-4e36-930d-0fe569f561ec"),
				CreatedInPackageId = new Guid("bfdf3d96-e43f-4660-bbd5-b1d1e334ffc7")
			};
		}

		protected virtual EntitySchemaColumn CreateResponseBodyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("5367dce9-4e04-4e48-b5ac-0ff268d6c9ab"),
				Name = @"ResponseBody",
				CreatedInSchemaUId = new Guid("b0067da8-d3f7-4e36-930d-0fe569f561ec"),
				ModifiedInSchemaUId = new Guid("b0067da8-d3f7-4e36-930d-0fe569f561ec"),
				CreatedInPackageId = new Guid("bfdf3d96-e43f-4660-bbd5-b1d1e334ffc7")
			};
		}

		protected virtual EntitySchemaColumn CreateExecCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("a802d17a-30e7-27b1-b8ec-8e09396a7dc2"),
				Name = @"ExecCount",
				CreatedInSchemaUId = new Guid("b0067da8-d3f7-4e36-930d-0fe569f561ec"),
				ModifiedInSchemaUId = new Guid("b0067da8-d3f7-4e36-930d-0fe569f561ec"),
				CreatedInPackageId = new Guid("bfb11bac-8dd4-4464-ad0d-b061668c431c")
			};
		}

		protected virtual EntitySchemaColumn CreateRequestBodyPatternColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("7fa0a835-e536-5af8-f770-dac9f90707c0"),
				Name = @"RequestBodyPattern",
				CreatedInSchemaUId = new Guid("b0067da8-d3f7-4e36-930d-0fe569f561ec"),
				ModifiedInSchemaUId = new Guid("b0067da8-d3f7-4e36-930d-0fe569f561ec"),
				CreatedInPackageId = new Guid("d86d8ed8-8106-4968-b2d6-c81af08e5d35"),
				IsMultiLineText = true
			};
		}

		protected virtual EntitySchemaColumn CreateRequestBodyAntiPatternColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("70828107-9e78-69d8-7e31-70443d929264"),
				Name = @"RequestBodyAntiPattern",
				CreatedInSchemaUId = new Guid("b0067da8-d3f7-4e36-930d-0fe569f561ec"),
				ModifiedInSchemaUId = new Guid("b0067da8-d3f7-4e36-930d-0fe569f561ec"),
				CreatedInPackageId = new Guid("a5e2b265-8078-4de9-a58f-70804c80c57f"),
				IsMultiLineText = true
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new MockableServiceUrl(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new MockableServiceUrl_CrtCoreBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new MockableServiceUrlSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new MockableServiceUrlSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b0067da8-d3f7-4e36-930d-0fe569f561ec"));
		}

		#endregion

	}

	#endregion

	#region Class: MockableServiceUrl

	/// <summary>
	/// MockableServiceUrl.
	/// </summary>
	public class MockableServiceUrl : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public MockableServiceUrl(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MockableServiceUrl";
		}

		public MockableServiceUrl(MockableServiceUrl source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// HttpMethod.
		/// </summary>
		public string HttpMethod {
			get {
				return GetTypedColumnValue<string>("HttpMethod");
			}
			set {
				SetColumnValue("HttpMethod", value);
			}
		}

		/// <summary>
		/// Url.
		/// </summary>
		public string Url {
			get {
				return GetTypedColumnValue<string>("Url");
			}
			set {
				SetColumnValue("Url", value);
			}
		}

		/// <summary>
		/// ResponseCode.
		/// </summary>
		public int ResponseCode {
			get {
				return GetTypedColumnValue<int>("ResponseCode");
			}
			set {
				SetColumnValue("ResponseCode", value);
			}
		}

		/// <summary>
		/// ResponseBody.
		/// </summary>
		public string ResponseBody {
			get {
				return GetTypedColumnValue<string>("ResponseBody");
			}
			set {
				SetColumnValue("ResponseBody", value);
			}
		}

		/// <summary>
		/// ExecCount.
		/// </summary>
		public int ExecCount {
			get {
				return GetTypedColumnValue<int>("ExecCount");
			}
			set {
				SetColumnValue("ExecCount", value);
			}
		}

		/// <summary>
		/// RequestBodyPattern.
		/// </summary>
		public string RequestBodyPattern {
			get {
				return GetTypedColumnValue<string>("RequestBodyPattern");
			}
			set {
				SetColumnValue("RequestBodyPattern", value);
			}
		}

		/// <summary>
		/// RequestBodyAntiPattern.
		/// </summary>
		public string RequestBodyAntiPattern {
			get {
				return GetTypedColumnValue<string>("RequestBodyAntiPattern");
			}
			set {
				SetColumnValue("RequestBodyAntiPattern", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new MockableServiceUrl_CrtCoreBaseEventsProcess(UserConnection);
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
			return new MockableServiceUrl(this);
		}

		#endregion

	}

	#endregion

	#region Class: MockableServiceUrl_CrtCoreBaseEventsProcess

	/// <exclude/>
	public partial class MockableServiceUrl_CrtCoreBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : MockableServiceUrl
	{

		public MockableServiceUrl_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "MockableServiceUrl_CrtCoreBaseEventsProcess";
			SchemaUId = new Guid("b0067da8-d3f7-4e36-930d-0fe569f561ec");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("b0067da8-d3f7-4e36-930d-0fe569f561ec");
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

	#region Class: MockableServiceUrl_CrtCoreBaseEventsProcess

	/// <exclude/>
	public class MockableServiceUrl_CrtCoreBaseEventsProcess : MockableServiceUrl_CrtCoreBaseEventsProcess<MockableServiceUrl>
	{

		public MockableServiceUrl_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: MockableServiceUrl_CrtCoreBaseEventsProcess

	public partial class MockableServiceUrl_CrtCoreBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: MockableServiceUrlEventsProcess

	/// <exclude/>
	public class MockableServiceUrlEventsProcess : MockableServiceUrl_CrtCoreBaseEventsProcess
	{

		public MockableServiceUrlEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

