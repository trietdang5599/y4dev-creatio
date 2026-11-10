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

	#region Class: ApplicationProcessSchema

	/// <exclude/>
	[IsVirtual]
	public class ApplicationProcessSchema : Terrasoft.Configuration.ApplicationSchemaSchema
	{

		#region Constructors: Public

		public ApplicationProcessSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ApplicationProcessSchema(ApplicationProcessSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ApplicationProcessSchema(ApplicationProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("cbf39435-679b-4fe1-8046-2a5f5f6b6b5c");
			RealUId = new Guid("cbf39435-679b-4fe1-8046-2a5f5f6b6b5c");
			Name = "ApplicationProcess";
			ParentSchemaUId = new Guid("51fab605-6f0c-4ff7-8398-b933f6a09128");
			ExtendParent = false;
			CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("b56d06ff-679e-6d38-9030-77aabbf0bec7")) == null) {
				Columns.Add(CreateIsEnabledColumn());
			}
			if (Columns.FindByUId(new Guid("8015c5c7-79fc-fb6b-a13b-ba6bae76752d")) == null) {
				Columns.Add(CreateIsActualColumn());
			}
			if (Columns.FindByUId(new Guid("7dc541bb-a28b-678d-149b-ac7c8b1a0364")) == null) {
				Columns.Add(CreateVersionColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateIsEnabledColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("b56d06ff-679e-6d38-9030-77aabbf0bec7"),
				Name = @"IsEnabled",
				CreatedInSchemaUId = new Guid("cbf39435-679b-4fe1-8046-2a5f5f6b6b5c"),
				ModifiedInSchemaUId = new Guid("cbf39435-679b-4fe1-8046-2a5f5f6b6b5c"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected virtual EntitySchemaColumn CreateIsActualColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("8015c5c7-79fc-fb6b-a13b-ba6bae76752d"),
				Name = @"IsActual",
				CreatedInSchemaUId = new Guid("cbf39435-679b-4fe1-8046-2a5f5f6b6b5c"),
				ModifiedInSchemaUId = new Guid("cbf39435-679b-4fe1-8046-2a5f5f6b6b5c"),
				CreatedInPackageId = new Guid("50f552a9-0668-454a-8ecf-9cb468aabd1f")
			};
		}

		protected virtual EntitySchemaColumn CreateVersionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("7dc541bb-a28b-678d-149b-ac7c8b1a0364"),
				Name = @"Version",
				CreatedInSchemaUId = new Guid("cbf39435-679b-4fe1-8046-2a5f5f6b6b5c"),
				ModifiedInSchemaUId = new Guid("cbf39435-679b-4fe1-8046-2a5f5f6b6b5c"),
				CreatedInPackageId = new Guid("50f552a9-0668-454a-8ecf-9cb468aabd1f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ApplicationProcess(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ApplicationProcess_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ApplicationProcessSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ApplicationProcessSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("cbf39435-679b-4fe1-8046-2a5f5f6b6b5c"));
		}

		#endregion

	}

	#endregion

	#region Class: ApplicationProcess

	/// <summary>
	/// Application process.
	/// </summary>
	public class ApplicationProcess : Terrasoft.Configuration.ApplicationSchema
	{

		#region Constructors: Public

		public ApplicationProcess(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ApplicationProcess";
		}

		public ApplicationProcess(ApplicationProcess source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// IsEnabled.
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
		/// Actual version.
		/// </summary>
		public bool IsActual {
			get {
				return GetTypedColumnValue<bool>("IsActual");
			}
			set {
				SetColumnValue("IsActual", value);
			}
		}

		/// <summary>
		/// Version.
		/// </summary>
		public int Version {
			get {
				return GetTypedColumnValue<int>("Version");
			}
			set {
				SetColumnValue("Version", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ApplicationProcess_CrtBaseEventsProcess(UserConnection);
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
			return new ApplicationProcess(this);
		}

		#endregion

	}

	#endregion

	#region Class: ApplicationProcess_CrtBaseEventsProcess

	/// <exclude/>
	public partial class ApplicationProcess_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.ApplicationSchema_CrtBaseEventsProcess<TEntity> where TEntity : ApplicationProcess
	{

		public ApplicationProcess_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ApplicationProcess_CrtBaseEventsProcess";
			SchemaUId = new Guid("cbf39435-679b-4fe1-8046-2a5f5f6b6b5c");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("cbf39435-679b-4fe1-8046-2a5f5f6b6b5c");
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

	#region Class: ApplicationProcess_CrtBaseEventsProcess

	/// <exclude/>
	public class ApplicationProcess_CrtBaseEventsProcess : ApplicationProcess_CrtBaseEventsProcess<ApplicationProcess>
	{

		public ApplicationProcess_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ApplicationProcess_CrtBaseEventsProcess

	public partial class ApplicationProcess_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ApplicationProcessEventsProcess

	/// <exclude/>
	public class ApplicationProcessEventsProcess : ApplicationProcess_CrtBaseEventsProcess
	{

		public ApplicationProcessEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

