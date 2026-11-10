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

	#region Class: EmailTemplateMacrosSchema

	/// <exclude/>
	public class EmailTemplateMacrosSchema : Terrasoft.Configuration.EmailTemplateMacros_CrtCoreBase_CreatioSchema
	{

		#region Constructors: Public

		public EmailTemplateMacrosSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public EmailTemplateMacrosSchema(EmailTemplateMacrosSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public EmailTemplateMacrosSchema(EmailTemplateMacrosSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("6fdf871c-b594-42a5-b617-3d14f4b313a7");
			Name = "EmailTemplateMacros";
			ParentSchemaUId = new Guid("e92a62ec-f0bb-422f-9a33-6d79532edc21");
			ExtendParent = true;
			CreatedInPackageId = new Guid("7cc31540-fa76-4c79-9b86-a6eabd8e662c");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = false;
			UseLiveEditing = false;
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
			return new EmailTemplateMacros(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new EmailTemplateMacros_SSPEventsProcess(userConnection);
		}

		public override object Clone() {
			return new EmailTemplateMacrosSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new EmailTemplateMacrosSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6fdf871c-b594-42a5-b617-3d14f4b313a7"));
		}

		#endregion

	}

	#endregion

	#region Class: EmailTemplateMacros

	/// <summary>
	/// Message template macro.
	/// </summary>
	public class EmailTemplateMacros : Terrasoft.Configuration.EmailTemplateMacros_CrtCoreBase_Creatio
	{

		#region Constructors: Public

		public EmailTemplateMacros(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "EmailTemplateMacros";
		}

		public EmailTemplateMacros(EmailTemplateMacros source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new EmailTemplateMacros_SSPEventsProcess(UserConnection);
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
			return new EmailTemplateMacros(this);
		}

		#endregion

	}

	#endregion

	#region Class: EmailTemplateMacros_SSPEventsProcess

	/// <exclude/>
	public partial class EmailTemplateMacros_SSPEventsProcess<TEntity> : Terrasoft.Configuration.EmailTemplateMacros_CrtCoreBaseEventsProcess<TEntity> where TEntity : EmailTemplateMacros
	{

		public EmailTemplateMacros_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "EmailTemplateMacros_SSPEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("6fdf871c-b594-42a5-b617-3d14f4b313a7");
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

	#region Class: EmailTemplateMacros_SSPEventsProcess

	/// <exclude/>
	public class EmailTemplateMacros_SSPEventsProcess : EmailTemplateMacros_SSPEventsProcess<EmailTemplateMacros>
	{

		public EmailTemplateMacros_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: EmailTemplateMacros_SSPEventsProcess

	public partial class EmailTemplateMacros_SSPEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: EmailTemplateMacrosEventsProcess

	/// <exclude/>
	public class EmailTemplateMacrosEventsProcess : EmailTemplateMacros_SSPEventsProcess
	{

		public EmailTemplateMacrosEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

