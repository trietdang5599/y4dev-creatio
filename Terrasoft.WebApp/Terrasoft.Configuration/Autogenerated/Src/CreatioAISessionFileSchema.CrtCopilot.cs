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

	#region Class: CreatioAISessionFileSchema

	/// <exclude/>
	public class CreatioAISessionFileSchema : Terrasoft.Configuration.FileSchema
	{

		#region Constructors: Public

		public CreatioAISessionFileSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CreatioAISessionFileSchema(CreatioAISessionFileSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CreatioAISessionFileSchema(CreatioAISessionFileSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("961a7453-a8c2-4d19-b51a-1b2161714148");
			RealUId = new Guid("961a7453-a8c2-4d19-b51a-1b2161714148");
			Name = "CreatioAISessionFile";
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
			if (Columns.FindByUId(new Guid("3722258f-66bd-3ec7-bf93-bae0f05bb260")) == null) {
				Columns.Add(CreateContentSizeColumn());
			}
			if (Columns.FindByUId(new Guid("ade27241-4d54-e6ad-31ba-8309b37184dc")) == null) {
				Columns.Add(CreateSessionIdColumn());
			}
			if (Columns.FindByUId(new Guid("dc38e9bc-09d3-96c4-a8d8-f88d78cfe5be")) == null) {
				Columns.Add(CreateMessageIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateContentSizeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("3722258f-66bd-3ec7-bf93-bae0f05bb260"),
				Name = @"ContentSize",
				CreatedInSchemaUId = new Guid("961a7453-a8c2-4d19-b51a-1b2161714148"),
				ModifiedInSchemaUId = new Guid("961a7453-a8c2-4d19-b51a-1b2161714148"),
				CreatedInPackageId = new Guid("ed753793-30d5-4797-a3f9-3019dcc6e358")
			};
		}

		protected virtual EntitySchemaColumn CreateSessionIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("ade27241-4d54-e6ad-31ba-8309b37184dc"),
				Name = @"SessionId",
				CreatedInSchemaUId = new Guid("961a7453-a8c2-4d19-b51a-1b2161714148"),
				ModifiedInSchemaUId = new Guid("961a7453-a8c2-4d19-b51a-1b2161714148"),
				CreatedInPackageId = new Guid("ed753793-30d5-4797-a3f9-3019dcc6e358")
			};
		}

		protected virtual EntitySchemaColumn CreateMessageIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("dc38e9bc-09d3-96c4-a8d8-f88d78cfe5be"),
				Name = @"MessageId",
				CreatedInSchemaUId = new Guid("961a7453-a8c2-4d19-b51a-1b2161714148"),
				ModifiedInSchemaUId = new Guid("961a7453-a8c2-4d19-b51a-1b2161714148"),
				CreatedInPackageId = new Guid("c23dfaf0-0051-4966-86f8-cbe8197258d0")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new CreatioAISessionFile(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CreatioAISessionFile_CrtCopilotEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CreatioAISessionFileSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CreatioAISessionFileSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("961a7453-a8c2-4d19-b51a-1b2161714148"));
		}

		#endregion

	}

	#endregion

	#region Class: CreatioAISessionFile

	/// <summary>
	/// Creatio.ai session file.
	/// </summary>
	public class CreatioAISessionFile : Terrasoft.Configuration.File
	{

		#region Constructors: Public

		public CreatioAISessionFile(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CreatioAISessionFile";
		}

		public CreatioAISessionFile(CreatioAISessionFile source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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

		/// <summary>
		/// Session identifier.
		/// </summary>
		public Guid SessionId {
			get {
				return GetTypedColumnValue<Guid>("SessionId");
			}
			set {
				SetColumnValue("SessionId", value);
			}
		}

		/// <summary>
		/// Message identifier.
		/// </summary>
		public Guid MessageId {
			get {
				return GetTypedColumnValue<Guid>("MessageId");
			}
			set {
				SetColumnValue("MessageId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CreatioAISessionFile_CrtCopilotEventsProcess(UserConnection);
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
			return new CreatioAISessionFile(this);
		}

		#endregion

	}

	#endregion

	#region Class: CreatioAISessionFile_CrtCopilotEventsProcess

	/// <exclude/>
	public partial class CreatioAISessionFile_CrtCopilotEventsProcess<TEntity> : Terrasoft.Configuration.File_LinkPreviewEventsProcess<TEntity> where TEntity : CreatioAISessionFile
	{

		public CreatioAISessionFile_CrtCopilotEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CreatioAISessionFile_CrtCopilotEventsProcess";
			SchemaUId = new Guid("961a7453-a8c2-4d19-b51a-1b2161714148");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("961a7453-a8c2-4d19-b51a-1b2161714148");
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

	#region Class: CreatioAISessionFile_CrtCopilotEventsProcess

	/// <exclude/>
	public class CreatioAISessionFile_CrtCopilotEventsProcess : CreatioAISessionFile_CrtCopilotEventsProcess<CreatioAISessionFile>
	{

		public CreatioAISessionFile_CrtCopilotEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CreatioAISessionFile_CrtCopilotEventsProcess

	public partial class CreatioAISessionFile_CrtCopilotEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CreatioAISessionFileEventsProcess

	/// <exclude/>
	public class CreatioAISessionFileEventsProcess : CreatioAISessionFile_CrtCopilotEventsProcess
	{

		public CreatioAISessionFileEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

