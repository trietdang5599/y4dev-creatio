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

	#region Class: TerritorySchema

	/// <exclude/>
	public class TerritorySchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public TerritorySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public TerritorySchema(TerritorySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public TerritorySchema(TerritorySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a0d1e591-78ee-44cb-9a58-39d6b59346f8");
			RealUId = new Guid("a0d1e591-78ee-44cb-9a58-39d6b59346f8");
			Name = "Territory";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
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
			return new Territory(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Territory_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new TerritorySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new TerritorySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a0d1e591-78ee-44cb-9a58-39d6b59346f8"));
		}

		#endregion

	}

	#endregion

	#region Class: Territory

	/// <summary>
	/// Territory.
	/// </summary>
	public class Territory : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public Territory(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Territory";
		}

		public Territory(Territory source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Territory_CrtBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("TerritoryDeleted", e);
			Deleting += (s, e) => ThrowEvent("TerritoryDeleting", e);
			Inserted += (s, e) => ThrowEvent("TerritoryInserted", e);
			Inserting += (s, e) => ThrowEvent("TerritoryInserting", e);
			Saved += (s, e) => ThrowEvent("TerritorySaved", e);
			Saving += (s, e) => ThrowEvent("TerritorySaving", e);
			Validating += (s, e) => ThrowEvent("TerritoryValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Territory(this);
		}

		#endregion

	}

	#endregion

	#region Class: Territory_CrtBaseEventsProcess

	/// <exclude/>
	public partial class Territory_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : Territory
	{

		public Territory_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Territory_CrtBaseEventsProcess";
			SchemaUId = new Guid("a0d1e591-78ee-44cb-9a58-39d6b59346f8");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("a0d1e591-78ee-44cb-9a58-39d6b59346f8");
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

	#region Class: Territory_CrtBaseEventsProcess

	/// <exclude/>
	public class Territory_CrtBaseEventsProcess : Territory_CrtBaseEventsProcess<Territory>
	{

		public Territory_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Territory_CrtBaseEventsProcess

	public partial class Territory_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: TerritoryEventsProcess

	/// <exclude/>
	public class TerritoryEventsProcess : Territory_CrtBaseEventsProcess
	{

		public TerritoryEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

