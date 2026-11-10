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

	#region Class: SysFileSchema

	/// <exclude/>
	public class SysFileSchema : Terrasoft.Configuration.SysFile_CrtCoreBase_CreatioSchema
	{

		#region Constructors: Public

		public SysFileSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysFileSchema(SysFileSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysFileSchema(SysFileSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("90d40ddb-2e95-4223-b000-91fa00431c71");
			Name = "SysFile";
			ParentSchemaUId = new Guid("70ec5d9f-a55e-4f5c-8f59-30d2c5149c4a");
			ExtendParent = true;
			CreatedInPackageId = new Guid("a3c0ad90-a816-44cb-9224-9868ff320060");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
			UseRecordDeactivation = false;
			RightSchemaName = @"SystemFileRight";
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
			return new SysFile(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysFile_SSPEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysFileSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysFileSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("90d40ddb-2e95-4223-b000-91fa00431c71"));
		}

		#endregion

	}

	#endregion

	#region Class: SysFile

	/// <summary>
	/// Uploaded file.
	/// </summary>
	public class SysFile : Terrasoft.Configuration.SysFile_CrtCoreBase_Creatio
	{

		#region Constructors: Public

		public SysFile(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysFile";
		}

		public SysFile(SysFile source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysFile_SSPEventsProcess(UserConnection);
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
			return new SysFile(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysFile_SSPEventsProcess

	/// <exclude/>
	public partial class SysFile_SSPEventsProcess<TEntity> : Terrasoft.Configuration.SysFile_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysFile
	{

		public SysFile_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysFile_SSPEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("90d40ddb-2e95-4223-b000-91fa00431c71");
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

	#region Class: SysFile_SSPEventsProcess

	/// <exclude/>
	public class SysFile_SSPEventsProcess : SysFile_SSPEventsProcess<SysFile>
	{

		public SysFile_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysFile_SSPEventsProcess

	public partial class SysFile_SSPEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysFileEventsProcess

	/// <exclude/>
	public class SysFileEventsProcess : SysFile_SSPEventsProcess
	{

		public SysFileEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

