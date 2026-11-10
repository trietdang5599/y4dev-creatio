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

	#region Class: CopilotIntCapabilitySchema

	/// <exclude/>
	[IsVirtual]
	public class CopilotIntCapabilitySchema : Terrasoft.Configuration.CopilotIntentSchema
	{

		#region Constructors: Public

		public CopilotIntCapabilitySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CopilotIntCapabilitySchema(CopilotIntCapabilitySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CopilotIntCapabilitySchema(CopilotIntCapabilitySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("05b16f08-c1f9-434e-b530-b71e0d456884");
			RealUId = new Guid("05b16f08-c1f9-434e-b530-b71e0d456884");
			Name = "CopilotIntCapability";
			ParentSchemaUId = new Guid("7cd7a99a-b22e-4e50-af02-6ee4ac8612ec");
			ExtendParent = false;
			CreatedInPackageId = new Guid("c23dfaf0-0051-4966-86f8-cbe8197258d0");
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
			if (Columns.FindByUId(new Guid("98184aab-f089-4353-8b4b-a03c99f76185")) == null) {
				Columns.Add(CreateIntentColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateIntentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("98184aab-f089-4353-8b4b-a03c99f76185"),
				Name = @"Intent",
				ReferenceSchemaUId = new Guid("7cd7a99a-b22e-4e50-af02-6ee4ac8612ec"),
				IsIndexed = true,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("05b16f08-c1f9-434e-b530-b71e0d456884"),
				ModifiedInSchemaUId = new Guid("05b16f08-c1f9-434e-b530-b71e0d456884"),
				CreatedInPackageId = new Guid("c23dfaf0-0051-4966-86f8-cbe8197258d0"),
				IsSimpleLookup = true
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new CopilotIntCapability(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CopilotIntCapability_CrtCopilotEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CopilotIntCapabilitySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CopilotIntCapabilitySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("05b16f08-c1f9-434e-b530-b71e0d456884"));
		}

		#endregion

	}

	#endregion

	#region Class: CopilotIntCapability

	/// <summary>
	/// Creatio.ai intent's capability.
	/// </summary>
	public class CopilotIntCapability : Terrasoft.Configuration.CopilotIntent
	{

		#region Constructors: Public

		public CopilotIntCapability(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CopilotIntCapability";
		}

		public CopilotIntCapability(CopilotIntCapability source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid IntentId {
			get {
				return GetTypedColumnValue<Guid>("IntentId");
			}
			set {
				SetColumnValue("IntentId", value);
				_intent = null;
			}
		}

		/// <exclude/>
		public string IntentName {
			get {
				return GetTypedColumnValue<string>("IntentName");
			}
			set {
				SetColumnValue("IntentName", value);
				if (_intent != null) {
					_intent.Name = value;
				}
			}
		}

		private CopilotIntent _intent;
		public CopilotIntent Intent {
			get {
				return _intent ??
					(_intent = LookupColumnEntities.GetEntity("Intent") as CopilotIntent);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CopilotIntCapability_CrtCopilotEventsProcess(UserConnection);
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
			return new CopilotIntCapability(this);
		}

		#endregion

	}

	#endregion

	#region Class: CopilotIntCapability_CrtCopilotEventsProcess

	/// <exclude/>
	public partial class CopilotIntCapability_CrtCopilotEventsProcess<TEntity> : Terrasoft.Configuration.CopilotIntent_CrtCopilotEventsProcess<TEntity> where TEntity : CopilotIntCapability
	{

		public CopilotIntCapability_CrtCopilotEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CopilotIntCapability_CrtCopilotEventsProcess";
			SchemaUId = new Guid("05b16f08-c1f9-434e-b530-b71e0d456884");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("05b16f08-c1f9-434e-b530-b71e0d456884");
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

	#region Class: CopilotIntCapability_CrtCopilotEventsProcess

	/// <exclude/>
	public class CopilotIntCapability_CrtCopilotEventsProcess : CopilotIntCapability_CrtCopilotEventsProcess<CopilotIntCapability>
	{

		public CopilotIntCapability_CrtCopilotEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CopilotIntCapability_CrtCopilotEventsProcess

	public partial class CopilotIntCapability_CrtCopilotEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CopilotIntCapabilityEventsProcess

	/// <exclude/>
	public class CopilotIntCapabilityEventsProcess : CopilotIntCapability_CrtCopilotEventsProcess
	{

		public CopilotIntCapabilityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

