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

	#region Class: CopilotAgentSchema

	/// <exclude/>
	[IsVirtual]
	public class CopilotAgentSchema : Terrasoft.Configuration.BaseCopilotIntentSchema
	{

		#region Constructors: Public

		public CopilotAgentSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CopilotAgentSchema(CopilotAgentSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CopilotAgentSchema(CopilotAgentSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c0e6c4a9-a85f-477b-8f8a-2d67fed07d02");
			RealUId = new Guid("c0e6c4a9-a85f-477b-8f8a-2d67fed07d02");
			Name = "CopilotAgent";
			ParentSchemaUId = new Guid("a90230c0-2973-4d2a-b38e-935c9631258d");
			ExtendParent = false;
			CreatedInPackageId = new Guid("c23dfaf0-0051-4966-86f8-cbe8197258d0");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
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
			if (Columns.FindByUId(new Guid("f774d5f2-1572-bdba-c4e4-0964dac9338c")) == null) {
				Columns.Add(CreateRestrictionsColumn());
			}
			if (Columns.FindByUId(new Guid("0c47e4a2-f2b5-92c6-5ebb-99538e6222c5")) == null) {
				Columns.Add(CreateRoleDescriptionColumn());
			}
			if (Columns.FindByUId(new Guid("2bee5ee7-842a-6299-dba0-3a79cac64390")) == null) {
				Columns.Add(CreateParamsColumn());
			}
		}

		protected override EntitySchemaColumn CreatePromptColumn() {
			EntitySchemaColumn column = base.CreatePromptColumn();
			column.RequirementType = EntitySchemaColumnRequirementType.None;
			column.ModifiedInSchemaUId = new Guid("c0e6c4a9-a85f-477b-8f8a-2d67fed07d02");
			return column;
		}

		protected virtual EntitySchemaColumn CreateRestrictionsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("RichText")) {
				UId = new Guid("f774d5f2-1572-bdba-c4e4-0964dac9338c"),
				Name = @"Restrictions",
				CreatedInSchemaUId = new Guid("c0e6c4a9-a85f-477b-8f8a-2d67fed07d02"),
				ModifiedInSchemaUId = new Guid("c0e6c4a9-a85f-477b-8f8a-2d67fed07d02"),
				CreatedInPackageId = new Guid("c23dfaf0-0051-4966-86f8-cbe8197258d0")
			};
		}

		protected virtual EntitySchemaColumn CreateRoleDescriptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("RichText")) {
				UId = new Guid("0c47e4a2-f2b5-92c6-5ebb-99538e6222c5"),
				Name = @"RoleDescription",
				CreatedInSchemaUId = new Guid("c0e6c4a9-a85f-477b-8f8a-2d67fed07d02"),
				ModifiedInSchemaUId = new Guid("c0e6c4a9-a85f-477b-8f8a-2d67fed07d02"),
				CreatedInPackageId = new Guid("c23dfaf0-0051-4966-86f8-cbe8197258d0")
			};
		}

		protected virtual EntitySchemaColumn CreateParamsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("2bee5ee7-842a-6299-dba0-3a79cac64390"),
				Name = @"Params",
				CreatedInSchemaUId = new Guid("c0e6c4a9-a85f-477b-8f8a-2d67fed07d02"),
				ModifiedInSchemaUId = new Guid("c0e6c4a9-a85f-477b-8f8a-2d67fed07d02"),
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
			return new CopilotAgent(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CopilotAgent_CrtCopilotEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CopilotAgentSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CopilotAgentSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c0e6c4a9-a85f-477b-8f8a-2d67fed07d02"));
		}

		#endregion

	}

	#endregion

	#region Class: CopilotAgent

	/// <summary>
	/// Creatio.ai Agent.
	/// </summary>
	public class CopilotAgent : Terrasoft.Configuration.BaseCopilotIntent
	{

		#region Constructors: Public

		public CopilotAgent(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CopilotAgent";
		}

		public CopilotAgent(CopilotAgent source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Restrictions.
		/// </summary>
		public string Restrictions {
			get {
				return GetTypedColumnValue<string>("Restrictions");
			}
			set {
				SetColumnValue("Restrictions", value);
			}
		}

		/// <summary>
		/// RoleDescription.
		/// </summary>
		public string RoleDescription {
			get {
				return GetTypedColumnValue<string>("RoleDescription");
			}
			set {
				SetColumnValue("RoleDescription", value);
			}
		}

		/// <summary>
		/// Params.
		/// </summary>
		public string Params {
			get {
				return GetTypedColumnValue<string>("Params");
			}
			set {
				SetColumnValue("Params", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CopilotAgent_CrtCopilotEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("CopilotAgentDeleted", e);
			Deleting += (s, e) => ThrowEvent("CopilotAgentDeleting", e);
			Inserted += (s, e) => ThrowEvent("CopilotAgentInserted", e);
			Inserting += (s, e) => ThrowEvent("CopilotAgentInserting", e);
			Saved += (s, e) => ThrowEvent("CopilotAgentSaved", e);
			Saving += (s, e) => ThrowEvent("CopilotAgentSaving", e);
			Validating += (s, e) => ThrowEvent("CopilotAgentValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new CopilotAgent(this);
		}

		#endregion

	}

	#endregion

	#region Class: CopilotAgent_CrtCopilotEventsProcess

	/// <exclude/>
	public partial class CopilotAgent_CrtCopilotEventsProcess<TEntity> : Terrasoft.Configuration.BaseCopilotIntent_CrtCopilotEventsProcess<TEntity> where TEntity : CopilotAgent
	{

		public CopilotAgent_CrtCopilotEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CopilotAgent_CrtCopilotEventsProcess";
			SchemaUId = new Guid("c0e6c4a9-a85f-477b-8f8a-2d67fed07d02");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("c0e6c4a9-a85f-477b-8f8a-2d67fed07d02");
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

	#region Class: CopilotAgent_CrtCopilotEventsProcess

	/// <exclude/>
	public class CopilotAgent_CrtCopilotEventsProcess : CopilotAgent_CrtCopilotEventsProcess<CopilotAgent>
	{

		public CopilotAgent_CrtCopilotEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CopilotAgent_CrtCopilotEventsProcess

	public partial class CopilotAgent_CrtCopilotEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CopilotAgentEventsProcess

	/// <exclude/>
	public class CopilotAgentEventsProcess : CopilotAgent_CrtCopilotEventsProcess
	{

		public CopilotAgentEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

