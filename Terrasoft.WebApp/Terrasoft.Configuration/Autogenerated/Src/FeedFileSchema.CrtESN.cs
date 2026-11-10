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
	using Terrasoft.Configuration;
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

	#region Class: FeedFileSchema

	/// <exclude/>
	public class FeedFileSchema : Terrasoft.Configuration.SysFileSchema
	{

		#region Constructors: Public

		public FeedFileSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public FeedFileSchema(FeedFileSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public FeedFileSchema(FeedFileSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("45492972-212b-4785-b5fc-fc5769c15cf9");
			RealUId = new Guid("45492972-212b-4785-b5fc-fc5769c15cf9");
			Name = "FeedFile";
			ParentSchemaUId = new Guid("70ec5d9f-a55e-4f5c-8f59-30d2c5149c4a");
			ExtendParent = false;
			CreatedInPackageId = new Guid("f0db0304-dc6c-40c0-a3bb-97ab97632500");
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
			return new FeedFile(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new FeedFile_CrtESNEventsProcess(userConnection);
		}

		public override object Clone() {
			return new FeedFileSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new FeedFileSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("45492972-212b-4785-b5fc-fc5769c15cf9"));
		}

		#endregion

	}

	#endregion

	#region Class: FeedFile

	/// <summary>
	/// Feed uploaded file.
	/// </summary>
	public class FeedFile : Terrasoft.Configuration.SysFile
	{

		#region Constructors: Public

		public FeedFile(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "FeedFile";
		}

		public FeedFile(FeedFile source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new FeedFile_CrtESNEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("FeedFileDeleted", e);
			Deleting += (s, e) => ThrowEvent("FeedFileDeleting", e);
			Inserted += (s, e) => ThrowEvent("FeedFileInserted", e);
			Inserting += (s, e) => ThrowEvent("FeedFileInserting", e);
			Saved += (s, e) => ThrowEvent("FeedFileSaved", e);
			Saving += (s, e) => ThrowEvent("FeedFileSaving", e);
			Updated += (s, e) => ThrowEvent("FeedFileUpdated", e);
			Validating += (s, e) => ThrowEvent("FeedFileValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new FeedFile(this);
		}

		#endregion

	}

	#endregion

	#region Class: FeedFile_CrtESNEventsProcess

	/// <exclude/>
	public partial class FeedFile_CrtESNEventsProcess<TEntity> : Terrasoft.Configuration.SysFile_SSPEventsProcess<TEntity> where TEntity : FeedFile
	{

		public FeedFile_CrtESNEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "FeedFile_CrtESNEventsProcess";
			SchemaUId = new Guid("45492972-212b-4785-b5fc-fc5769c15cf9");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("45492972-212b-4785-b5fc-fc5769c15cf9");
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

	#region Class: FeedFile_CrtESNEventsProcess

	/// <exclude/>
	public class FeedFile_CrtESNEventsProcess : FeedFile_CrtESNEventsProcess<FeedFile>
	{

		public FeedFile_CrtESNEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: FeedFile_CrtESNEventsProcess

	public partial class FeedFile_CrtESNEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: FeedFileEventsProcess

	/// <exclude/>
	public class FeedFileEventsProcess : FeedFile_CrtESNEventsProcess
	{

		public FeedFileEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

