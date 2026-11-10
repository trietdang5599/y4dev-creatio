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

	#region Class: CopilotIntentModeSchema

	/// <exclude/>
	public class CopilotIntentModeSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public CopilotIntentModeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CopilotIntentModeSchema(CopilotIntentModeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CopilotIntentModeSchema(CopilotIntentModeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c541ee8e-5939-4e57-be5b-9c252fe968cf");
			RealUId = new Guid("c541ee8e-5939-4e57-be5b-9c252fe968cf");
			Name = "CopilotIntentMode";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("a5645ea0-1b73-4b60-b012-23b3100050d4");
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
			if (Columns.FindByUId(new Guid("1efbdafd-fee5-7836-1184-afef71ab2682")) == null) {
				Columns.Add(CreateCodeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("1efbdafd-fee5-7836-1184-afef71ab2682"),
				Name = @"Code",
				CreatedInSchemaUId = new Guid("c541ee8e-5939-4e57-be5b-9c252fe968cf"),
				ModifiedInSchemaUId = new Guid("c541ee8e-5939-4e57-be5b-9c252fe968cf"),
				CreatedInPackageId = new Guid("a5645ea0-1b73-4b60-b012-23b3100050d4")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new CopilotIntentMode(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CopilotIntentMode_CrtCopilotEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CopilotIntentModeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CopilotIntentModeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c541ee8e-5939-4e57-be5b-9c252fe968cf"));
		}

		#endregion

	}

	#endregion

	#region Class: CopilotIntentMode

	/// <summary>
	/// Creatio.ai sub-agent mode.
	/// </summary>
	public class CopilotIntentMode : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public CopilotIntentMode(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CopilotIntentMode";
		}

		public CopilotIntentMode(CopilotIntentMode source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Code.
		/// </summary>
		public string Code {
			get {
				return GetTypedColumnValue<string>("Code");
			}
			set {
				SetColumnValue("Code", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CopilotIntentMode_CrtCopilotEventsProcess(UserConnection);
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
			return new CopilotIntentMode(this);
		}

		#endregion

	}

	#endregion

	#region Class: CopilotIntentMode_CrtCopilotEventsProcess

	/// <exclude/>
	public partial class CopilotIntentMode_CrtCopilotEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : CopilotIntentMode
	{

		public CopilotIntentMode_CrtCopilotEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CopilotIntentMode_CrtCopilotEventsProcess";
			SchemaUId = new Guid("c541ee8e-5939-4e57-be5b-9c252fe968cf");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("c541ee8e-5939-4e57-be5b-9c252fe968cf");
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

	#region Class: CopilotIntentMode_CrtCopilotEventsProcess

	/// <exclude/>
	public class CopilotIntentMode_CrtCopilotEventsProcess : CopilotIntentMode_CrtCopilotEventsProcess<CopilotIntentMode>
	{

		public CopilotIntentMode_CrtCopilotEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CopilotIntentMode_CrtCopilotEventsProcess

	public partial class CopilotIntentMode_CrtCopilotEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CopilotIntentModeEventsProcess

	/// <exclude/>
	public class CopilotIntentModeEventsProcess : CopilotIntentMode_CrtCopilotEventsProcess
	{

		public CopilotIntentModeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

