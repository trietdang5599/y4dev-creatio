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

	#region Class: CopilotRequestEntSchema

	/// <exclude/>
	public class CopilotRequestEntSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public CopilotRequestEntSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CopilotRequestEntSchema(CopilotRequestEntSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CopilotRequestEntSchema(CopilotRequestEntSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b846aaa6-f2d5-4146-9fc0-606dfd041b5e");
			RealUId = new Guid("b846aaa6-f2d5-4146-9fc0-606dfd041b5e");
			Name = "CopilotRequestEnt";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("bad99159-33f2-43af-aab2-3508b9685277");
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
			if (Columns.FindByUId(new Guid("9bed17ac-aeff-dbc4-0040-5cb42a4427b4")) == null) {
				Columns.Add(CreateTotalTokensColumn());
			}
			if (Columns.FindByUId(new Guid("3a65463e-f7ab-e773-f8e4-0b4118bb3014")) == null) {
				Columns.Add(CreateCompletionTokensColumn());
			}
			if (Columns.FindByUId(new Guid("ef72aca5-b419-ce01-32cf-21ac1d1524d7")) == null) {
				Columns.Add(CreatePromptTokensColumn());
			}
			if (Columns.FindByUId(new Guid("844c8170-18d8-3461-103b-55c3e0ce9209")) == null) {
				Columns.Add(CreateDurationColumn());
			}
			if (Columns.FindByUId(new Guid("c81793ea-398b-e9f6-7455-d4585b1ad364")) == null) {
				Columns.Add(CreateErrorColumn());
			}
			if (Columns.FindByUId(new Guid("056392a0-6240-1b53-b9b2-1d59e6ddbafa")) == null) {
				Columns.Add(CreateIsFailedColumn());
			}
			if (Columns.FindByUId(new Guid("5ed553a2-23ec-bd8a-09f3-5badb98e1f0e")) == null) {
				Columns.Add(CreateTotalActionsColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateTotalTokensColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("9bed17ac-aeff-dbc4-0040-5cb42a4427b4"),
				Name = @"TotalTokens",
				CreatedInSchemaUId = new Guid("b846aaa6-f2d5-4146-9fc0-606dfd041b5e"),
				ModifiedInSchemaUId = new Guid("b846aaa6-f2d5-4146-9fc0-606dfd041b5e"),
				CreatedInPackageId = new Guid("bad99159-33f2-43af-aab2-3508b9685277")
			};
		}

		protected virtual EntitySchemaColumn CreateCompletionTokensColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("3a65463e-f7ab-e773-f8e4-0b4118bb3014"),
				Name = @"CompletionTokens",
				CreatedInSchemaUId = new Guid("b846aaa6-f2d5-4146-9fc0-606dfd041b5e"),
				ModifiedInSchemaUId = new Guid("b846aaa6-f2d5-4146-9fc0-606dfd041b5e"),
				CreatedInPackageId = new Guid("bad99159-33f2-43af-aab2-3508b9685277")
			};
		}

		protected virtual EntitySchemaColumn CreatePromptTokensColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("ef72aca5-b419-ce01-32cf-21ac1d1524d7"),
				Name = @"PromptTokens",
				CreatedInSchemaUId = new Guid("b846aaa6-f2d5-4146-9fc0-606dfd041b5e"),
				ModifiedInSchemaUId = new Guid("b846aaa6-f2d5-4146-9fc0-606dfd041b5e"),
				CreatedInPackageId = new Guid("bad99159-33f2-43af-aab2-3508b9685277")
			};
		}

		protected virtual EntitySchemaColumn CreateDurationColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("844c8170-18d8-3461-103b-55c3e0ce9209"),
				Name = @"Duration",
				CreatedInSchemaUId = new Guid("b846aaa6-f2d5-4146-9fc0-606dfd041b5e"),
				ModifiedInSchemaUId = new Guid("b846aaa6-f2d5-4146-9fc0-606dfd041b5e"),
				CreatedInPackageId = new Guid("bad99159-33f2-43af-aab2-3508b9685277")
			};
		}

		protected virtual EntitySchemaColumn CreateErrorColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("c81793ea-398b-e9f6-7455-d4585b1ad364"),
				Name = @"Error",
				CreatedInSchemaUId = new Guid("b846aaa6-f2d5-4146-9fc0-606dfd041b5e"),
				ModifiedInSchemaUId = new Guid("b846aaa6-f2d5-4146-9fc0-606dfd041b5e"),
				CreatedInPackageId = new Guid("bad99159-33f2-43af-aab2-3508b9685277")
			};
		}

		protected virtual EntitySchemaColumn CreateIsFailedColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("056392a0-6240-1b53-b9b2-1d59e6ddbafa"),
				Name = @"IsFailed",
				CreatedInSchemaUId = new Guid("b846aaa6-f2d5-4146-9fc0-606dfd041b5e"),
				ModifiedInSchemaUId = new Guid("b846aaa6-f2d5-4146-9fc0-606dfd041b5e"),
				CreatedInPackageId = new Guid("bad99159-33f2-43af-aab2-3508b9685277")
			};
		}

		protected virtual EntitySchemaColumn CreateTotalActionsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("5ed553a2-23ec-bd8a-09f3-5badb98e1f0e"),
				Name = @"TotalActions",
				CreatedInSchemaUId = new Guid("b846aaa6-f2d5-4146-9fc0-606dfd041b5e"),
				ModifiedInSchemaUId = new Guid("b846aaa6-f2d5-4146-9fc0-606dfd041b5e"),
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
			return new CopilotRequestEnt(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CopilotRequestEnt_CrtCopilotEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CopilotRequestEntSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CopilotRequestEntSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b846aaa6-f2d5-4146-9fc0-606dfd041b5e"));
		}

		#endregion

	}

	#endregion

	#region Class: CopilotRequestEnt

	/// <summary>
	/// Creatio.ai Request Entity.
	/// </summary>
	public class CopilotRequestEnt : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public CopilotRequestEnt(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CopilotRequestEnt";
		}

		public CopilotRequestEnt(CopilotRequestEnt source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Total Tokens.
		/// </summary>
		/// <remarks>
		/// Total number of tokens used in the request (prompt + completion).
		/// </remarks>
		public int TotalTokens {
			get {
				return GetTypedColumnValue<int>("TotalTokens");
			}
			set {
				SetColumnValue("TotalTokens", value);
			}
		}

		/// <summary>
		/// Completion Tokens.
		/// </summary>
		/// <remarks>
		/// Number of tokens in the generated completion.
		/// </remarks>
		public int CompletionTokens {
			get {
				return GetTypedColumnValue<int>("CompletionTokens");
			}
			set {
				SetColumnValue("CompletionTokens", value);
			}
		}

		/// <summary>
		/// Prompt Tokens.
		/// </summary>
		/// <remarks>
		/// Number of tokens in the prompt.
		/// </remarks>
		public int PromptTokens {
			get {
				return GetTypedColumnValue<int>("PromptTokens");
			}
			set {
				SetColumnValue("PromptTokens", value);
			}
		}

		/// <summary>
		/// Duration (ms).
		/// </summary>
		/// <remarks>
		/// Duration of request in milliseconds.
		/// </remarks>
		public int Duration {
			get {
				return GetTypedColumnValue<int>("Duration");
			}
			set {
				SetColumnValue("Duration", value);
			}
		}

		/// <summary>
		/// Error.
		/// </summary>
		/// <remarks>
		/// Error message.
		/// </remarks>
		public string Error {
			get {
				return GetTypedColumnValue<string>("Error");
			}
			set {
				SetColumnValue("Error", value);
			}
		}

		/// <summary>
		/// Is Failed.
		/// </summary>
		/// <remarks>
		/// Request success indicator.
		/// </remarks>
		public bool IsFailed {
			get {
				return GetTypedColumnValue<bool>("IsFailed");
			}
			set {
				SetColumnValue("IsFailed", value);
			}
		}

		/// <summary>
		/// Total Actions.
		/// </summary>
		/// <remarks>
		/// Total number of actions used in the request.
		/// </remarks>
		public int TotalActions {
			get {
				return GetTypedColumnValue<int>("TotalActions");
			}
			set {
				SetColumnValue("TotalActions", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CopilotRequestEnt_CrtCopilotEventsProcess(UserConnection);
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
			return new CopilotRequestEnt(this);
		}

		#endregion

	}

	#endregion

	#region Class: CopilotRequestEnt_CrtCopilotEventsProcess

	/// <exclude/>
	public partial class CopilotRequestEnt_CrtCopilotEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : CopilotRequestEnt
	{

		public CopilotRequestEnt_CrtCopilotEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CopilotRequestEnt_CrtCopilotEventsProcess";
			SchemaUId = new Guid("b846aaa6-f2d5-4146-9fc0-606dfd041b5e");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("b846aaa6-f2d5-4146-9fc0-606dfd041b5e");
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

	#region Class: CopilotRequestEnt_CrtCopilotEventsProcess

	/// <exclude/>
	public class CopilotRequestEnt_CrtCopilotEventsProcess : CopilotRequestEnt_CrtCopilotEventsProcess<CopilotRequestEnt>
	{

		public CopilotRequestEnt_CrtCopilotEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CopilotRequestEnt_CrtCopilotEventsProcess

	public partial class CopilotRequestEnt_CrtCopilotEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CopilotRequestEntEventsProcess

	/// <exclude/>
	public class CopilotRequestEntEventsProcess : CopilotRequestEnt_CrtCopilotEventsProcess
	{

		public CopilotRequestEntEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

