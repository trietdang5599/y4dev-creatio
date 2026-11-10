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

	#region Class: VwSysProcessFileSchema

	/// <exclude/>
	public class VwSysProcessFileSchema : Terrasoft.Configuration.FileSchema
	{

		#region Constructors: Public

		public VwSysProcessFileSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwSysProcessFileSchema(VwSysProcessFileSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwSysProcessFileSchema(VwSysProcessFileSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("45e3e868-0867-4e64-99fc-e03a63c57aa5");
			RealUId = new Guid("45e3e868-0867-4e64-99fc-e03a63c57aa5");
			Name = "VwSysProcessFile";
			ParentSchemaUId = new Guid("556c5867-60a7-4456-aae1-a57a122bef70");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("b89763dc-b135-47fc-9b6b-3224cfc5c09b")) == null) {
				Columns.Add(CreateVwSysProcessColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateVwSysProcessColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("b89763dc-b135-47fc-9b6b-3224cfc5c09b"),
				Name = @"VwSysProcess",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("45e3e868-0867-4e64-99fc-e03a63c57aa5"),
				ModifiedInSchemaUId = new Guid("45e3e868-0867-4e64-99fc-e03a63c57aa5"),
				CreatedInPackageId = new Guid("47d9f451-70d6-4014-b0c9-4ad37a1eb8b7")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwSysProcessFile(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwSysProcessFile_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwSysProcessFileSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwSysProcessFileSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("45e3e868-0867-4e64-99fc-e03a63c57aa5"));
		}

		#endregion

	}

	#endregion

	#region Class: VwSysProcessFile

	/// <summary>
	/// Process attachment.
	/// </summary>
	public class VwSysProcessFile : Terrasoft.Configuration.File
	{

		#region Constructors: Public

		public VwSysProcessFile(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwSysProcessFile";
		}

		public VwSysProcessFile(VwSysProcessFile source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Process (view).
		/// </summary>
		public Guid VwSysProcess {
			get {
				return GetTypedColumnValue<Guid>("VwSysProcess");
			}
			set {
				SetColumnValue("VwSysProcess", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwSysProcessFile_CrtBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwSysProcessFileDeleted", e);
			Inserting += (s, e) => ThrowEvent("VwSysProcessFileInserting", e);
			Updated += (s, e) => ThrowEvent("VwSysProcessFileUpdated", e);
			Validating += (s, e) => ThrowEvent("VwSysProcessFileValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwSysProcessFile(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwSysProcessFile_CrtBaseEventsProcess

	/// <exclude/>
	public partial class VwSysProcessFile_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.File_LinkPreviewEventsProcess<TEntity> where TEntity : VwSysProcessFile
	{

		public VwSysProcessFile_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwSysProcessFile_CrtBaseEventsProcess";
			SchemaUId = new Guid("45e3e868-0867-4e64-99fc-e03a63c57aa5");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("45e3e868-0867-4e64-99fc-e03a63c57aa5");
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

	#region Class: VwSysProcessFile_CrtBaseEventsProcess

	/// <exclude/>
	public class VwSysProcessFile_CrtBaseEventsProcess : VwSysProcessFile_CrtBaseEventsProcess<VwSysProcessFile>
	{

		public VwSysProcessFile_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwSysProcessFile_CrtBaseEventsProcess

	public partial class VwSysProcessFile_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwSysProcessFileEventsProcess

	/// <exclude/>
	public class VwSysProcessFileEventsProcess : VwSysProcessFile_CrtBaseEventsProcess
	{

		public VwSysProcessFileEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

