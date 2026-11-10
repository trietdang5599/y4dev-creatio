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

	#region Class: CopilotToolCallEntSchema

	/// <exclude/>
	public class CopilotToolCallEntSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public CopilotToolCallEntSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CopilotToolCallEntSchema(CopilotToolCallEntSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CopilotToolCallEntSchema(CopilotToolCallEntSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("65615179-62f4-4b57-a9b1-d50a62a2267a");
			RealUId = new Guid("65615179-62f4-4b57-a9b1-d50a62a2267a");
			Name = "CopilotToolCallEnt";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("7a3a8162-4be1-46b5-bd50-b3efc2df6d2e");
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
			if (Columns.FindByUId(new Guid("4e1ed1e7-d2b3-81b0-7f08-60838bffe9d8")) == null) {
				Columns.Add(CreateArgumentsColumn());
			}
			if (Columns.FindByUId(new Guid("e64f44dc-d0bd-1a0a-c92a-83e4606e7d1d")) == null) {
				Columns.Add(CreateFunctionNameColumn());
			}
			if (Columns.FindByUId(new Guid("bd5bdaf9-0aec-2bd4-9a92-0bc25e9fb989")) == null) {
				Columns.Add(CreateCopilotMessageColumn());
			}
			if (Columns.FindByUId(new Guid("64e6584a-f8c9-37e7-f907-c13ed0c7db2b")) == null) {
				Columns.Add(CreateToolCallIdColumn());
			}
			if (Columns.FindByUId(new Guid("2f68561f-1ccd-c143-603c-f1da8b3bcbd8")) == null) {
				Columns.Add(CreateConfirmationResultColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateArgumentsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("4e1ed1e7-d2b3-81b0-7f08-60838bffe9d8"),
				Name = @"Arguments",
				CreatedInSchemaUId = new Guid("65615179-62f4-4b57-a9b1-d50a62a2267a"),
				ModifiedInSchemaUId = new Guid("65615179-62f4-4b57-a9b1-d50a62a2267a"),
				CreatedInPackageId = new Guid("7a3a8162-4be1-46b5-bd50-b3efc2df6d2e")
			};
		}

		protected virtual EntitySchemaColumn CreateFunctionNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("e64f44dc-d0bd-1a0a-c92a-83e4606e7d1d"),
				Name = @"FunctionName",
				CreatedInSchemaUId = new Guid("65615179-62f4-4b57-a9b1-d50a62a2267a"),
				ModifiedInSchemaUId = new Guid("65615179-62f4-4b57-a9b1-d50a62a2267a"),
				CreatedInPackageId = new Guid("7a3a8162-4be1-46b5-bd50-b3efc2df6d2e")
			};
		}

		protected virtual EntitySchemaColumn CreateCopilotMessageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("bd5bdaf9-0aec-2bd4-9a92-0bc25e9fb989"),
				Name = @"CopilotMessage",
				ReferenceSchemaUId = new Guid("427e6cd6-9696-4887-a905-5cfc48217c0a"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("65615179-62f4-4b57-a9b1-d50a62a2267a"),
				ModifiedInSchemaUId = new Guid("65615179-62f4-4b57-a9b1-d50a62a2267a"),
				CreatedInPackageId = new Guid("7a3a8162-4be1-46b5-bd50-b3efc2df6d2e")
			};
		}

		protected virtual EntitySchemaColumn CreateToolCallIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("64e6584a-f8c9-37e7-f907-c13ed0c7db2b"),
				Name = @"ToolCallId",
				CreatedInSchemaUId = new Guid("65615179-62f4-4b57-a9b1-d50a62a2267a"),
				ModifiedInSchemaUId = new Guid("65615179-62f4-4b57-a9b1-d50a62a2267a"),
				CreatedInPackageId = new Guid("7a3a8162-4be1-46b5-bd50-b3efc2df6d2e")
			};
		}

		protected virtual EntitySchemaColumn CreateConfirmationResultColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("2f68561f-1ccd-c143-603c-f1da8b3bcbd8"),
				Name = @"ConfirmationResult",
				CreatedInSchemaUId = new Guid("65615179-62f4-4b57-a9b1-d50a62a2267a"),
				ModifiedInSchemaUId = new Guid("65615179-62f4-4b57-a9b1-d50a62a2267a"),
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
			return new CopilotToolCallEnt(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CopilotToolCallEnt_CrtCopilotEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CopilotToolCallEntSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CopilotToolCallEntSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("65615179-62f4-4b57-a9b1-d50a62a2267a"));
		}

		#endregion

	}

	#endregion

	#region Class: CopilotToolCallEnt

	/// <summary>
	/// Creatio.ai Tool call.
	/// </summary>
	public class CopilotToolCallEnt : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public CopilotToolCallEnt(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CopilotToolCallEnt";
		}

		public CopilotToolCallEnt(CopilotToolCallEnt source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Arguments.
		/// </summary>
		public string Arguments {
			get {
				return GetTypedColumnValue<string>("Arguments");
			}
			set {
				SetColumnValue("Arguments", value);
			}
		}

		/// <summary>
		/// Function name.
		/// </summary>
		public string FunctionName {
			get {
				return GetTypedColumnValue<string>("FunctionName");
			}
			set {
				SetColumnValue("FunctionName", value);
			}
		}

		/// <exclude/>
		public Guid CopilotMessageId {
			get {
				return GetTypedColumnValue<Guid>("CopilotMessageId");
			}
			set {
				SetColumnValue("CopilotMessageId", value);
				_copilotMessage = null;
			}
		}

		private CopilotMessageEnt _copilotMessage;
		/// <summary>
		/// Creatio.ai Message.
		/// </summary>
		public CopilotMessageEnt CopilotMessage {
			get {
				return _copilotMessage ??
					(_copilotMessage = LookupColumnEntities.GetEntity("CopilotMessage") as CopilotMessageEnt);
			}
		}

		/// <summary>
		/// ToolCallId.
		/// </summary>
		public string ToolCallId {
			get {
				return GetTypedColumnValue<string>("ToolCallId");
			}
			set {
				SetColumnValue("ToolCallId", value);
			}
		}

		/// <summary>
		/// Confirmation result.
		/// </summary>
		public string ConfirmationResult {
			get {
				return GetTypedColumnValue<string>("ConfirmationResult");
			}
			set {
				SetColumnValue("ConfirmationResult", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CopilotToolCallEnt_CrtCopilotEventsProcess(UserConnection);
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
			return new CopilotToolCallEnt(this);
		}

		#endregion

	}

	#endregion

	#region Class: CopilotToolCallEnt_CrtCopilotEventsProcess

	/// <exclude/>
	public partial class CopilotToolCallEnt_CrtCopilotEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : CopilotToolCallEnt
	{

		public CopilotToolCallEnt_CrtCopilotEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CopilotToolCallEnt_CrtCopilotEventsProcess";
			SchemaUId = new Guid("65615179-62f4-4b57-a9b1-d50a62a2267a");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("65615179-62f4-4b57-a9b1-d50a62a2267a");
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

	#region Class: CopilotToolCallEnt_CrtCopilotEventsProcess

	/// <exclude/>
	public class CopilotToolCallEnt_CrtCopilotEventsProcess : CopilotToolCallEnt_CrtCopilotEventsProcess<CopilotToolCallEnt>
	{

		public CopilotToolCallEnt_CrtCopilotEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CopilotToolCallEnt_CrtCopilotEventsProcess

	public partial class CopilotToolCallEnt_CrtCopilotEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CopilotToolCallEntEventsProcess

	/// <exclude/>
	public class CopilotToolCallEntEventsProcess : CopilotToolCallEnt_CrtCopilotEventsProcess
	{

		public CopilotToolCallEntEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

