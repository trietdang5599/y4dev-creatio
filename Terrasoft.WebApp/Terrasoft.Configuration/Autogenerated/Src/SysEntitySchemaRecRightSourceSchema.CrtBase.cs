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

	#region Class: SysEntitySchemaRecRightSourceSchema

	/// <exclude/>
	public class SysEntitySchemaRecRightSourceSchema : Terrasoft.Configuration.BaseCodeLookupSchema
	{

		#region Constructors: Public

		public SysEntitySchemaRecRightSourceSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysEntitySchemaRecRightSourceSchema(SysEntitySchemaRecRightSourceSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysEntitySchemaRecRightSourceSchema(SysEntitySchemaRecRightSourceSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f990ac27-1b3c-4090-bea2-694e259c8c2c");
			RealUId = new Guid("f990ac27-1b3c-4090-bea2-694e259c8c2c");
			Name = "SysEntitySchemaRecRightSource";
			ParentSchemaUId = new Guid("2681062b-df59-4e52-89ed-f9b7dc909ab2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
			DesignLocalizationSchemaName = @"SysEntitySchRecRightSourceLcz";
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
			return new SysEntitySchemaRecRightSource(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysEntitySchemaRecRightSource_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysEntitySchemaRecRightSourceSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysEntitySchemaRecRightSourceSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f990ac27-1b3c-4090-bea2-694e259c8c2c"));
		}

		#endregion

	}

	#endregion

	#region Class: SysEntitySchemaRecRightSource

	/// <summary>
	/// Record Permission.
	/// </summary>
	public class SysEntitySchemaRecRightSource : Terrasoft.Configuration.BaseCodeLookup
	{

		#region Constructors: Public

		public SysEntitySchemaRecRightSource(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysEntitySchemaRecRightSource";
		}

		public SysEntitySchemaRecRightSource(SysEntitySchemaRecRightSource source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysEntitySchemaRecRightSource_CrtBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysEntitySchemaRecRightSourceDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysEntitySchemaRecRightSourceDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysEntitySchemaRecRightSourceInserted", e);
			Inserting += (s, e) => ThrowEvent("SysEntitySchemaRecRightSourceInserting", e);
			Saved += (s, e) => ThrowEvent("SysEntitySchemaRecRightSourceSaved", e);
			Saving += (s, e) => ThrowEvent("SysEntitySchemaRecRightSourceSaving", e);
			Validating += (s, e) => ThrowEvent("SysEntitySchemaRecRightSourceValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysEntitySchemaRecRightSource(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysEntitySchemaRecRightSource_CrtBaseEventsProcess

	/// <exclude/>
	public partial class SysEntitySchemaRecRightSource_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseCodeLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysEntitySchemaRecRightSource
	{

		public SysEntitySchemaRecRightSource_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysEntitySchemaRecRightSource_CrtBaseEventsProcess";
			SchemaUId = new Guid("f990ac27-1b3c-4090-bea2-694e259c8c2c");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("f990ac27-1b3c-4090-bea2-694e259c8c2c");
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

	#region Class: SysEntitySchemaRecRightSource_CrtBaseEventsProcess

	/// <exclude/>
	public class SysEntitySchemaRecRightSource_CrtBaseEventsProcess : SysEntitySchemaRecRightSource_CrtBaseEventsProcess<SysEntitySchemaRecRightSource>
	{

		public SysEntitySchemaRecRightSource_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysEntitySchemaRecRightSource_CrtBaseEventsProcess

	public partial class SysEntitySchemaRecRightSource_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysEntitySchemaRecRightSourceEventsProcess

	/// <exclude/>
	public class SysEntitySchemaRecRightSourceEventsProcess : SysEntitySchemaRecRightSource_CrtBaseEventsProcess
	{

		public SysEntitySchemaRecRightSourceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

