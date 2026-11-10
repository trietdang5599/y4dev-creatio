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

	#region Class: SysQueryStackTraceSchema

	/// <exclude/>
	public class SysQueryStackTraceSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysQueryStackTraceSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysQueryStackTraceSchema(SysQueryStackTraceSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysQueryStackTraceSchema(SysQueryStackTraceSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("104ee061-3cc4-4b03-94ce-27f57c2cdd4a");
			RealUId = new Guid("104ee061-3cc4-4b03-94ce-27f57c2cdd4a");
			Name = "SysQueryStackTrace";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("cbbe32d2-4c63-434f-845b-1ea3b7a1b0d4");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("26f39c76-4f20-96b1-fe1c-a78f85b873a7")) == null) {
				Columns.Add(CreateChecksumColumn());
			}
			if (Columns.FindByUId(new Guid("472e4b5e-177b-4f46-d6cd-092dad96b004")) == null) {
				Columns.Add(CreateStackTraceColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateChecksumColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("26f39c76-4f20-96b1-fe1c-a78f85b873a7"),
				Name = @"Checksum",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("104ee061-3cc4-4b03-94ce-27f57c2cdd4a"),
				ModifiedInSchemaUId = new Guid("104ee061-3cc4-4b03-94ce-27f57c2cdd4a"),
				CreatedInPackageId = new Guid("cbbe32d2-4c63-434f-845b-1ea3b7a1b0d4")
			};
		}

		protected virtual EntitySchemaColumn CreateStackTraceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("472e4b5e-177b-4f46-d6cd-092dad96b004"),
				Name = @"StackTrace",
				CreatedInSchemaUId = new Guid("104ee061-3cc4-4b03-94ce-27f57c2cdd4a"),
				ModifiedInSchemaUId = new Guid("104ee061-3cc4-4b03-94ce-27f57c2cdd4a"),
				CreatedInPackageId = new Guid("cbbe32d2-4c63-434f-845b-1ea3b7a1b0d4")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysQueryStackTrace(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysQueryStackTrace_QueryExecutionRulesEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysQueryStackTraceSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysQueryStackTraceSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("104ee061-3cc4-4b03-94ce-27f57c2cdd4a"));
		}

		#endregion

	}

	#endregion

	#region Class: SysQueryStackTrace

	/// <summary>
	/// Query stack trace.
	/// </summary>
	public class SysQueryStackTrace : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysQueryStackTrace(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysQueryStackTrace";
		}

		public SysQueryStackTrace(SysQueryStackTrace source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Checksum.
		/// </summary>
		public string Checksum {
			get {
				return GetTypedColumnValue<string>("Checksum");
			}
			set {
				SetColumnValue("Checksum", value);
			}
		}

		/// <summary>
		/// Stack trace.
		/// </summary>
		public string StackTrace {
			get {
				return GetTypedColumnValue<string>("StackTrace");
			}
			set {
				SetColumnValue("StackTrace", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysQueryStackTrace_QueryExecutionRulesEventsProcess(UserConnection);
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
			return new SysQueryStackTrace(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysQueryStackTrace_QueryExecutionRulesEventsProcess

	/// <exclude/>
	public partial class SysQueryStackTrace_QueryExecutionRulesEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysQueryStackTrace
	{

		public SysQueryStackTrace_QueryExecutionRulesEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysQueryStackTrace_QueryExecutionRulesEventsProcess";
			SchemaUId = new Guid("104ee061-3cc4-4b03-94ce-27f57c2cdd4a");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("104ee061-3cc4-4b03-94ce-27f57c2cdd4a");
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

	#region Class: SysQueryStackTrace_QueryExecutionRulesEventsProcess

	/// <exclude/>
	public class SysQueryStackTrace_QueryExecutionRulesEventsProcess : SysQueryStackTrace_QueryExecutionRulesEventsProcess<SysQueryStackTrace>
	{

		public SysQueryStackTrace_QueryExecutionRulesEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysQueryStackTrace_QueryExecutionRulesEventsProcess

	public partial class SysQueryStackTrace_QueryExecutionRulesEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysQueryStackTraceEventsProcess

	/// <exclude/>
	public class SysQueryStackTraceEventsProcess : SysQueryStackTrace_QueryExecutionRulesEventsProcess
	{

		public SysQueryStackTraceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

