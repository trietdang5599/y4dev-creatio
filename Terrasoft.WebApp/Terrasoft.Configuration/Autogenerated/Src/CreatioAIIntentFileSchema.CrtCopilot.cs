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

	#region Class: CreatioAIIntentFileSchema

	/// <exclude/>
	public class CreatioAIIntentFileSchema : Terrasoft.Configuration.FileSchema
	{

		#region Constructors: Public

		public CreatioAIIntentFileSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CreatioAIIntentFileSchema(CreatioAIIntentFileSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CreatioAIIntentFileSchema(CreatioAIIntentFileSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("513b42c9-6e8e-4ae6-92f4-24934ed04a02");
			RealUId = new Guid("513b42c9-6e8e-4ae6-92f4-24934ed04a02");
			Name = "CreatioAIIntentFile";
			ParentSchemaUId = new Guid("556c5867-60a7-4456-aae1-a57a122bef70");
			ExtendParent = false;
			CreatedInPackageId = new Guid("ed753793-30d5-4797-a3f9-3019dcc6e358");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = false;
			UseLiveEditing = false;
			Paging.IsPageable = true;
			Filtering.IsFilterable = true;
			Sorting.IsSortable = true;
			Write.IsInsertable = true;
			Write.IsUpdatable = true;
			Write.IsDeletable = true;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("6765e262-55d0-681c-df73-f1559fe03646")) == null) {
				Columns.Add(CreateIntentUIdColumn());
			}
			if (Columns.FindByUId(new Guid("89259e22-458e-5be0-a08b-022642fb162e")) == null) {
				Columns.Add(CreateContentSizeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateIntentUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("6765e262-55d0-681c-df73-f1559fe03646"),
				Name = @"IntentUId",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("513b42c9-6e8e-4ae6-92f4-24934ed04a02"),
				ModifiedInSchemaUId = new Guid("513b42c9-6e8e-4ae6-92f4-24934ed04a02"),
				CreatedInPackageId = new Guid("ed753793-30d5-4797-a3f9-3019dcc6e358")
			};
		}

		protected virtual EntitySchemaColumn CreateContentSizeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("89259e22-458e-5be0-a08b-022642fb162e"),
				Name = @"ContentSize",
				CreatedInSchemaUId = new Guid("513b42c9-6e8e-4ae6-92f4-24934ed04a02"),
				ModifiedInSchemaUId = new Guid("513b42c9-6e8e-4ae6-92f4-24934ed04a02"),
				CreatedInPackageId = new Guid("ed753793-30d5-4797-a3f9-3019dcc6e358")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new CreatioAIIntentFile(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CreatioAIIntentFile_CrtCopilotEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CreatioAIIntentFileSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CreatioAIIntentFileSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("513b42c9-6e8e-4ae6-92f4-24934ed04a02"));
		}

		#endregion

	}

	#endregion

	#region Class: CreatioAIIntentFile

	/// <summary>
	/// Skill or agent file.
	/// </summary>
	public class CreatioAIIntentFile : Terrasoft.Configuration.File
	{

		#region Constructors: Public

		public CreatioAIIntentFile(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CreatioAIIntentFile";
		}

		public CreatioAIIntentFile(CreatioAIIntentFile source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Intent unique identifier.
		/// </summary>
		public Guid IntentUId {
			get {
				return GetTypedColumnValue<Guid>("IntentUId");
			}
			set {
				SetColumnValue("IntentUId", value);
			}
		}

		/// <summary>
		/// Content size.
		/// </summary>
		public int ContentSize {
			get {
				return GetTypedColumnValue<int>("ContentSize");
			}
			set {
				SetColumnValue("ContentSize", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CreatioAIIntentFile_CrtCopilotEventsProcess(UserConnection);
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
			return new CreatioAIIntentFile(this);
		}

		#endregion

	}

	#endregion

	#region Class: CreatioAIIntentFile_CrtCopilotEventsProcess

	/// <exclude/>
	public partial class CreatioAIIntentFile_CrtCopilotEventsProcess<TEntity> : Terrasoft.Configuration.File_LinkPreviewEventsProcess<TEntity> where TEntity : CreatioAIIntentFile
	{

		public CreatioAIIntentFile_CrtCopilotEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CreatioAIIntentFile_CrtCopilotEventsProcess";
			SchemaUId = new Guid("513b42c9-6e8e-4ae6-92f4-24934ed04a02");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("513b42c9-6e8e-4ae6-92f4-24934ed04a02");
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

	#region Class: CreatioAIIntentFile_CrtCopilotEventsProcess

	/// <exclude/>
	public class CreatioAIIntentFile_CrtCopilotEventsProcess : CreatioAIIntentFile_CrtCopilotEventsProcess<CreatioAIIntentFile>
	{

		public CreatioAIIntentFile_CrtCopilotEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CreatioAIIntentFile_CrtCopilotEventsProcess

	public partial class CreatioAIIntentFile_CrtCopilotEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CreatioAIIntentFileEventsProcess

	/// <exclude/>
	public class CreatioAIIntentFileEventsProcess : CreatioAIIntentFile_CrtCopilotEventsProcess
	{

		public CreatioAIIntentFileEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

