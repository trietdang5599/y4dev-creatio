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

	#region Class: ApplicationEntitySchema

	/// <exclude/>
	[IsVirtual]
	public class ApplicationEntitySchema : Terrasoft.Configuration.ApplicationSchemaSchema
	{

		#region Constructors: Public

		public ApplicationEntitySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ApplicationEntitySchema(ApplicationEntitySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ApplicationEntitySchema(ApplicationEntitySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("82d5e065-b604-443d-a3ac-86f03bb98ee7");
			RealUId = new Guid("82d5e065-b604-443d-a3ac-86f03bb98ee7");
			Name = "ApplicationEntity";
			ParentSchemaUId = new Guid("51fab605-6f0c-4ff7-8398-b933f6a09128");
			ExtendParent = false;
			CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ApplicationEntity(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ApplicationEntity_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ApplicationEntitySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ApplicationEntitySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("82d5e065-b604-443d-a3ac-86f03bb98ee7"));
		}

		#endregion

	}

	#endregion

	#region Class: ApplicationEntity

	/// <summary>
	/// Application entity.
	/// </summary>
	public class ApplicationEntity : Terrasoft.Configuration.ApplicationSchema
	{

		#region Constructors: Public

		public ApplicationEntity(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ApplicationEntity";
		}

		public ApplicationEntity(ApplicationEntity source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ApplicationEntity_CrtBaseEventsProcess(UserConnection);
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
			return new ApplicationEntity(this);
		}

		#endregion

	}

	#endregion

	#region Class: ApplicationEntity_CrtBaseEventsProcess

	/// <exclude/>
	public partial class ApplicationEntity_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.ApplicationSchema_CrtBaseEventsProcess<TEntity> where TEntity : ApplicationEntity
	{

		public ApplicationEntity_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ApplicationEntity_CrtBaseEventsProcess";
			SchemaUId = new Guid("82d5e065-b604-443d-a3ac-86f03bb98ee7");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("82d5e065-b604-443d-a3ac-86f03bb98ee7");
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

	#region Class: ApplicationEntity_CrtBaseEventsProcess

	/// <exclude/>
	public class ApplicationEntity_CrtBaseEventsProcess : ApplicationEntity_CrtBaseEventsProcess<ApplicationEntity>
	{

		public ApplicationEntity_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ApplicationEntity_CrtBaseEventsProcess

	public partial class ApplicationEntity_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ApplicationEntityEventsProcess

	/// <exclude/>
	public class ApplicationEntityEventsProcess : ApplicationEntity_CrtBaseEventsProcess
	{

		public ApplicationEntityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

