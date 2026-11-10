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
	using System.Security;
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
	using TSConfiguration = Terrasoft.Configuration;

	#region Class: EmployeeTagSchema

	/// <exclude/>
	public class EmployeeTagSchema : Terrasoft.Configuration.BaseTagSchema
	{

		#region Constructors: Public

		public EmployeeTagSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public EmployeeTagSchema(EmployeeTagSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public EmployeeTagSchema(EmployeeTagSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("31b7da55-8bcf-4eb6-878b-24ad1a26b8e4");
			RealUId = new Guid("31b7da55-8bcf-4eb6-878b-24ad1a26b8e4");
			Name = "EmployeeTag";
			ParentSchemaUId = new Guid("9e3f203c-e905-4de5-9468-335b193f2439");
			ExtendParent = false;
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
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
			return new EmployeeTag(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new EmployeeTag_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new EmployeeTagSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new EmployeeTagSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("31b7da55-8bcf-4eb6-878b-24ad1a26b8e4"));
		}

		#endregion

	}

	#endregion

	#region Class: EmployeeTag

	/// <summary>
	/// Employee section tag.
	/// </summary>
	public class EmployeeTag : Terrasoft.Configuration.BaseTag
	{

		#region Constructors: Public

		public EmployeeTag(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "EmployeeTag";
		}

		public EmployeeTag(EmployeeTag source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new EmployeeTag_CrtBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("EmployeeTagDeleted", e);
			Inserted += (s, e) => ThrowEvent("EmployeeTagInserted", e);
			Validating += (s, e) => ThrowEvent("EmployeeTagValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new EmployeeTag(this);
		}

		#endregion

	}

	#endregion

	#region Class: EmployeeTag_CrtBaseEventsProcess

	/// <exclude/>
	public partial class EmployeeTag_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseTag_SSPEventsProcess<TEntity> where TEntity : EmployeeTag
	{

		public EmployeeTag_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "EmployeeTag_CrtBaseEventsProcess";
			SchemaUId = new Guid("31b7da55-8bcf-4eb6-878b-24ad1a26b8e4");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("31b7da55-8bcf-4eb6-878b-24ad1a26b8e4");
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

	#region Class: EmployeeTag_CrtBaseEventsProcess

	/// <exclude/>
	public class EmployeeTag_CrtBaseEventsProcess : EmployeeTag_CrtBaseEventsProcess<EmployeeTag>
	{

		public EmployeeTag_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: EmployeeTag_CrtBaseEventsProcess

	public partial class EmployeeTag_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: EmployeeTagEventsProcess

	/// <exclude/>
	public class EmployeeTagEventsProcess : EmployeeTag_CrtBaseEventsProcess
	{

		public EmployeeTagEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

