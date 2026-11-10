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

	#region Class: VwProcessLibSchema

	/// <exclude/>
	public class VwProcessLibSchema : Terrasoft.Configuration.VwProcessLib_CrtCoreBase_CreatioSchema
	{

		#region Constructors: Public

		public VwProcessLibSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwProcessLibSchema(VwProcessLibSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwProcessLibSchema(VwProcessLibSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("bdd7c9c0-a282-49d9-ba85-5286707d83e8");
			Name = "VwProcessLib";
			ParentSchemaUId = new Guid("e6e68ac1-495d-4727-a7a7-9b531ab9f849");
			ExtendParent = true;
			CreatedInPackageId = new Guid("7cc31540-fa76-4c79-9b86-a6eabd8e662c");
			IsDBView = true;
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
			return new VwProcessLib(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwProcessLib_SSPEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwProcessLibSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwProcessLibSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("bdd7c9c0-a282-49d9-ba85-5286707d83e8"));
		}

		#endregion

	}

	#endregion

	#region Class: VwProcessLib

	/// <summary>
	/// Process library (view).
	/// </summary>
	public class VwProcessLib : Terrasoft.Configuration.VwProcessLib_CrtCoreBase_Creatio
	{

		#region Constructors: Public

		public VwProcessLib(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwProcessLib";
		}

		public VwProcessLib(VwProcessLib source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwProcessLib_SSPEventsProcess(UserConnection);
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
			return new VwProcessLib(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwProcessLib_SSPEventsProcess

	/// <exclude/>
	public partial class VwProcessLib_SSPEventsProcess<TEntity> : Terrasoft.Configuration.VwProcessLib_CrtCoreBaseEventsProcess<TEntity> where TEntity : VwProcessLib
	{

		public VwProcessLib_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwProcessLib_SSPEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("bdd7c9c0-a282-49d9-ba85-5286707d83e8");
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

	#region Class: VwProcessLib_SSPEventsProcess

	/// <exclude/>
	public class VwProcessLib_SSPEventsProcess : VwProcessLib_SSPEventsProcess<VwProcessLib>
	{

		public VwProcessLib_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwProcessLib_SSPEventsProcess

	public partial class VwProcessLib_SSPEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwProcessLibEventsProcess

	/// <exclude/>
	public class VwProcessLibEventsProcess : VwProcessLib_SSPEventsProcess
	{

		public VwProcessLibEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

