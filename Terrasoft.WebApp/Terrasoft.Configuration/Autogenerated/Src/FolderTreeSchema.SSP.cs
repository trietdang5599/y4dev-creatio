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

	#region Class: FolderTreeSchema

	/// <exclude/>
	public class FolderTreeSchema : Terrasoft.Configuration.FolderTree_FolderTree_CreatioSchema
	{

		#region Constructors: Public

		public FolderTreeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public FolderTreeSchema(FolderTreeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public FolderTreeSchema(FolderTreeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("f3c322de-ba54-f61e-4be6-a82d56c28226");
			Name = "FolderTree";
			ParentSchemaUId = new Guid("8fcd0c68-a67e-4cef-8ce2-a3b810652f85");
			ExtendParent = true;
			CreatedInPackageId = new Guid("a3c0ad90-a816-44cb-9224-9868ff320060");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
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
			return new FolderTree(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new FolderTree_SSPEventsProcess(userConnection);
		}

		public override object Clone() {
			return new FolderTreeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new FolderTreeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f3c322de-ba54-f61e-4be6-a82d56c28226"));
		}

		#endregion

	}

	#endregion

	#region Class: FolderTree

	/// <summary>
	/// Folder tree.
	/// </summary>
	public class FolderTree : Terrasoft.Configuration.FolderTree_FolderTree_Creatio
	{

		#region Constructors: Public

		public FolderTree(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "FolderTree";
		}

		public FolderTree(FolderTree source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new FolderTree_SSPEventsProcess(UserConnection);
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
			return new FolderTree(this);
		}

		#endregion

	}

	#endregion

	#region Class: FolderTree_SSPEventsProcess

	/// <exclude/>
	public partial class FolderTree_SSPEventsProcess<TEntity> : Terrasoft.Configuration.FolderTree_FolderTreeEventsProcess<TEntity> where TEntity : FolderTree
	{

		public FolderTree_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "FolderTree_SSPEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("f3c322de-ba54-f61e-4be6-a82d56c28226");
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

	#region Class: FolderTree_SSPEventsProcess

	/// <exclude/>
	public class FolderTree_SSPEventsProcess : FolderTree_SSPEventsProcess<FolderTree>
	{

		public FolderTree_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: FolderTree_SSPEventsProcess

	public partial class FolderTree_SSPEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: FolderTreeEventsProcess

	/// <exclude/>
	public class FolderTreeEventsProcess : FolderTree_SSPEventsProcess
	{

		public FolderTreeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

