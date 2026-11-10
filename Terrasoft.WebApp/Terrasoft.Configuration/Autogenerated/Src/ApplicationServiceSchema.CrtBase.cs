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

	#region Class: ApplicationServiceSchema

	/// <exclude/>
	[IsVirtual]
	public class ApplicationServiceSchema : Terrasoft.Configuration.ApplicationSchemaSchema
	{

		#region Constructors: Public

		public ApplicationServiceSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ApplicationServiceSchema(ApplicationServiceSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ApplicationServiceSchema(ApplicationServiceSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("cc8add0a-92b5-4564-af0b-baf9ab06c8c9");
			RealUId = new Guid("cc8add0a-92b5-4564-af0b-baf9ab06c8c9");
			Name = "ApplicationService";
			ParentSchemaUId = new Guid("51fab605-6f0c-4ff7-8398-b933f6a09128");
			ExtendParent = false;
			CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("7d5ce88c-c8f7-6766-3b24-b53f995c92bc")) == null) {
				Columns.Add(CreateBaseUriColumn());
			}
			if (Columns.FindByUId(new Guid("45a33a62-1cdf-1075-4e19-67b9f3c3ce76")) == null) {
				Columns.Add(CreateTypeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateBaseUriColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("7d5ce88c-c8f7-6766-3b24-b53f995c92bc"),
				Name = @"BaseUri",
				CreatedInSchemaUId = new Guid("cc8add0a-92b5-4564-af0b-baf9ab06c8c9"),
				ModifiedInSchemaUId = new Guid("cc8add0a-92b5-4564-af0b-baf9ab06c8c9"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected virtual EntitySchemaColumn CreateTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("45a33a62-1cdf-1075-4e19-67b9f3c3ce76"),
				Name = @"Type",
				CreatedInSchemaUId = new Guid("cc8add0a-92b5-4564-af0b-baf9ab06c8c9"),
				ModifiedInSchemaUId = new Guid("cc8add0a-92b5-4564-af0b-baf9ab06c8c9"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ApplicationService(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ApplicationService_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ApplicationServiceSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ApplicationServiceSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("cc8add0a-92b5-4564-af0b-baf9ab06c8c9"));
		}

		#endregion

	}

	#endregion

	#region Class: ApplicationService

	/// <summary>
	/// Application service.
	/// </summary>
	public class ApplicationService : Terrasoft.Configuration.ApplicationSchema
	{

		#region Constructors: Public

		public ApplicationService(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ApplicationService";
		}

		public ApplicationService(ApplicationService source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// BaseUri.
		/// </summary>
		public string BaseUri {
			get {
				return GetTypedColumnValue<string>("BaseUri");
			}
			set {
				SetColumnValue("BaseUri", value);
			}
		}

		/// <summary>
		/// Type.
		/// </summary>
		public int Type {
			get {
				return GetTypedColumnValue<int>("Type");
			}
			set {
				SetColumnValue("Type", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ApplicationService_CrtBaseEventsProcess(UserConnection);
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
			return new ApplicationService(this);
		}

		#endregion

	}

	#endregion

	#region Class: ApplicationService_CrtBaseEventsProcess

	/// <exclude/>
	public partial class ApplicationService_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.ApplicationSchema_CrtBaseEventsProcess<TEntity> where TEntity : ApplicationService
	{

		public ApplicationService_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ApplicationService_CrtBaseEventsProcess";
			SchemaUId = new Guid("cc8add0a-92b5-4564-af0b-baf9ab06c8c9");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("cc8add0a-92b5-4564-af0b-baf9ab06c8c9");
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

	#region Class: ApplicationService_CrtBaseEventsProcess

	/// <exclude/>
	public class ApplicationService_CrtBaseEventsProcess : ApplicationService_CrtBaseEventsProcess<ApplicationService>
	{

		public ApplicationService_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ApplicationService_CrtBaseEventsProcess

	public partial class ApplicationService_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ApplicationServiceEventsProcess

	/// <exclude/>
	public class ApplicationServiceEventsProcess : ApplicationService_CrtBaseEventsProcess
	{

		public ApplicationServiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

