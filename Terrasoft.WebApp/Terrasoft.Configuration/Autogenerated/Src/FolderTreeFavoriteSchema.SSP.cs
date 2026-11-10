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

	#region Class: FolderTreeFavoriteSchema

	/// <exclude/>
	public class FolderTreeFavoriteSchema : Terrasoft.Configuration.FolderTreeFavorite_FolderTree_CreatioSchema
	{

		#region Constructors: Public

		public FolderTreeFavoriteSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public FolderTreeFavoriteSchema(FolderTreeFavoriteSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public FolderTreeFavoriteSchema(FolderTreeFavoriteSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("0557dda4-6ef4-9333-c49d-101d568174c5");
			Name = "FolderTreeFavorite";
			ParentSchemaUId = new Guid("cc0f83fd-9407-4131-8702-42e90903e391");
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
			return new FolderTreeFavorite(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new FolderTreeFavorite_SSPEventsProcess(userConnection);
		}

		public override object Clone() {
			return new FolderTreeFavoriteSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new FolderTreeFavoriteSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0557dda4-6ef4-9333-c49d-101d568174c5"));
		}

		#endregion

	}

	#endregion

	#region Class: FolderTreeFavorite

	/// <summary>
	/// Favorite folder tree.
	/// </summary>
	public class FolderTreeFavorite : Terrasoft.Configuration.FolderTreeFavorite_FolderTree_Creatio
	{

		#region Constructors: Public

		public FolderTreeFavorite(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "FolderTreeFavorite";
		}

		public FolderTreeFavorite(FolderTreeFavorite source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new FolderTreeFavorite_SSPEventsProcess(UserConnection);
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
			return new FolderTreeFavorite(this);
		}

		#endregion

	}

	#endregion

	#region Class: FolderTreeFavorite_SSPEventsProcess

	/// <exclude/>
	public partial class FolderTreeFavorite_SSPEventsProcess<TEntity> : Terrasoft.Configuration.FolderTreeFavorite_FolderTreeEventsProcess<TEntity> where TEntity : FolderTreeFavorite
	{

		public FolderTreeFavorite_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "FolderTreeFavorite_SSPEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("0557dda4-6ef4-9333-c49d-101d568174c5");
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

	#region Class: FolderTreeFavorite_SSPEventsProcess

	/// <exclude/>
	public class FolderTreeFavorite_SSPEventsProcess : FolderTreeFavorite_SSPEventsProcess<FolderTreeFavorite>
	{

		public FolderTreeFavorite_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: FolderTreeFavorite_SSPEventsProcess

	public partial class FolderTreeFavorite_SSPEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: FolderTreeFavoriteEventsProcess

	/// <exclude/>
	public class FolderTreeFavoriteEventsProcess : FolderTreeFavorite_SSPEventsProcess
	{

		public FolderTreeFavoriteEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

