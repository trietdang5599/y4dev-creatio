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

	#region Class: SysDateTimeFormatSchema

	/// <exclude/>
	public class SysDateTimeFormatSchema : Terrasoft.Configuration.BaseCodeLookupSchema
	{

		#region Constructors: Public

		public SysDateTimeFormatSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysDateTimeFormatSchema(SysDateTimeFormatSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysDateTimeFormatSchema(SysDateTimeFormatSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("eac650f2-6b46-44d3-8f44-095ef2cd62d4");
			RealUId = new Guid("eac650f2-6b46-44d3-8f44-095ef2cd62d4");
			Name = "SysDateTimeFormat";
			ParentSchemaUId = new Guid("2681062b-df59-4e52-89ed-f9b7dc909ab2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("eac650f2-6b46-44d3-8f44-095ef2cd62d4");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("eac650f2-6b46-44d3-8f44-095ef2cd62d4");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override EntitySchemaColumn CreateCodeColumn() {
			EntitySchemaColumn column = base.CreateCodeColumn();
			column.ModifiedInSchemaUId = new Guid("eac650f2-6b46-44d3-8f44-095ef2cd62d4");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysDateTimeFormat(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysDateTimeFormat_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysDateTimeFormatSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysDateTimeFormatSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("eac650f2-6b46-44d3-8f44-095ef2cd62d4"));
		}

		#endregion

	}

	#endregion

	#region Class: SysDateTimeFormat

	/// <summary>
	/// Date Format.
	/// </summary>
	public class SysDateTimeFormat : Terrasoft.Configuration.BaseCodeLookup
	{

		#region Constructors: Public

		public SysDateTimeFormat(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysDateTimeFormat";
		}

		public SysDateTimeFormat(SysDateTimeFormat source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysDateTimeFormat_CrtBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysDateTimeFormatDeleted", e);
			Inserting += (s, e) => ThrowEvent("SysDateTimeFormatInserting", e);
			Validating += (s, e) => ThrowEvent("SysDateTimeFormatValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysDateTimeFormat(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysDateTimeFormat_CrtBaseEventsProcess

	/// <exclude/>
	public partial class SysDateTimeFormat_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseCodeLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysDateTimeFormat
	{

		public SysDateTimeFormat_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysDateTimeFormat_CrtBaseEventsProcess";
			SchemaUId = new Guid("eac650f2-6b46-44d3-8f44-095ef2cd62d4");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("eac650f2-6b46-44d3-8f44-095ef2cd62d4");
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

	#region Class: SysDateTimeFormat_CrtBaseEventsProcess

	/// <exclude/>
	public class SysDateTimeFormat_CrtBaseEventsProcess : SysDateTimeFormat_CrtBaseEventsProcess<SysDateTimeFormat>
	{

		public SysDateTimeFormat_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysDateTimeFormat_CrtBaseEventsProcess

	public partial class SysDateTimeFormat_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysDateTimeFormatEventsProcess

	/// <exclude/>
	public class SysDateTimeFormatEventsProcess : SysDateTimeFormat_CrtBaseEventsProcess
	{

		public SysDateTimeFormatEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

