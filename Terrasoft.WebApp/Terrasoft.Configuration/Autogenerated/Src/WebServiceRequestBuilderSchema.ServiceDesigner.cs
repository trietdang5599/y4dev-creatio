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

	#region Class: WebServiceRequestBuilderSchema

	/// <exclude/>
	public class WebServiceRequestBuilderSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public WebServiceRequestBuilderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public WebServiceRequestBuilderSchema(WebServiceRequestBuilderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public WebServiceRequestBuilderSchema(WebServiceRequestBuilderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5edbb411-bda6-4b46-9130-2e6acc8a23aa");
			RealUId = new Guid("5edbb411-bda6-4b46-9130-2e6acc8a23aa");
			Name = "WebServiceRequestBuilder";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("73951534-6fa4-4e40-b925-a1e2e4e079e3");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("8473e005-7154-eb28-c19d-6ad404061ef9")) == null) {
				Columns.Add(CreateTypeNameColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateTypeNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("8473e005-7154-eb28-c19d-6ad404061ef9"),
				Name = @"TypeName",
				CreatedInSchemaUId = new Guid("5edbb411-bda6-4b46-9130-2e6acc8a23aa"),
				ModifiedInSchemaUId = new Guid("5edbb411-bda6-4b46-9130-2e6acc8a23aa"),
				CreatedInPackageId = new Guid("73951534-6fa4-4e40-b925-a1e2e4e079e3")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new WebServiceRequestBuilder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new WebServiceRequestBuilder_ServiceDesignerEventsProcess(userConnection);
		}

		public override object Clone() {
			return new WebServiceRequestBuilderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new WebServiceRequestBuilderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5edbb411-bda6-4b46-9130-2e6acc8a23aa"));
		}

		#endregion

	}

	#endregion

	#region Class: WebServiceRequestBuilder

	/// <summary>
	/// Web service request builder.
	/// </summary>
	public class WebServiceRequestBuilder : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public WebServiceRequestBuilder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "WebServiceRequestBuilder";
		}

		public WebServiceRequestBuilder(WebServiceRequestBuilder source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Builder type name.
		/// </summary>
		public string TypeName {
			get {
				return GetTypedColumnValue<string>("TypeName");
			}
			set {
				SetColumnValue("TypeName", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new WebServiceRequestBuilder_ServiceDesignerEventsProcess(UserConnection);
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
			return new WebServiceRequestBuilder(this);
		}

		#endregion

	}

	#endregion

	#region Class: WebServiceRequestBuilder_ServiceDesignerEventsProcess

	/// <exclude/>
	public partial class WebServiceRequestBuilder_ServiceDesignerEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : WebServiceRequestBuilder
	{

		public WebServiceRequestBuilder_ServiceDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "WebServiceRequestBuilder_ServiceDesignerEventsProcess";
			SchemaUId = new Guid("5edbb411-bda6-4b46-9130-2e6acc8a23aa");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("5edbb411-bda6-4b46-9130-2e6acc8a23aa");
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

	#region Class: WebServiceRequestBuilder_ServiceDesignerEventsProcess

	/// <exclude/>
	public class WebServiceRequestBuilder_ServiceDesignerEventsProcess : WebServiceRequestBuilder_ServiceDesignerEventsProcess<WebServiceRequestBuilder>
	{

		public WebServiceRequestBuilder_ServiceDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: WebServiceRequestBuilder_ServiceDesignerEventsProcess

	public partial class WebServiceRequestBuilder_ServiceDesignerEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: WebServiceRequestBuilderEventsProcess

	/// <exclude/>
	public class WebServiceRequestBuilderEventsProcess : WebServiceRequestBuilder_ServiceDesignerEventsProcess
	{

		public WebServiceRequestBuilderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

