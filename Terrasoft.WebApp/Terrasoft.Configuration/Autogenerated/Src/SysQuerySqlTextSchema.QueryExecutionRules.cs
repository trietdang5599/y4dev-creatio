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

	#region Class: SysQuerySqlTextSchema

	/// <exclude/>
	public class SysQuerySqlTextSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysQuerySqlTextSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysQuerySqlTextSchema(SysQuerySqlTextSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysQuerySqlTextSchema(SysQuerySqlTextSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("6d570bdd-5c1f-4bf2-a8ce-2195c9a638b2");
			RealUId = new Guid("6d570bdd-5c1f-4bf2-a8ce-2195c9a638b2");
			Name = "SysQuerySqlText";
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
			if (Columns.FindByUId(new Guid("645d2d90-1790-49e5-c2f1-24cef07c0865")) == null) {
				Columns.Add(CreateChecksumColumn());
			}
			if (Columns.FindByUId(new Guid("b2a07813-c611-1396-d6d6-1485dffb0b8e")) == null) {
				Columns.Add(CreateSqlTextColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateChecksumColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("645d2d90-1790-49e5-c2f1-24cef07c0865"),
				Name = @"Checksum",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("6d570bdd-5c1f-4bf2-a8ce-2195c9a638b2"),
				ModifiedInSchemaUId = new Guid("6d570bdd-5c1f-4bf2-a8ce-2195c9a638b2"),
				CreatedInPackageId = new Guid("cbbe32d2-4c63-434f-845b-1ea3b7a1b0d4")
			};
		}

		protected virtual EntitySchemaColumn CreateSqlTextColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("b2a07813-c611-1396-d6d6-1485dffb0b8e"),
				Name = @"SqlText",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("6d570bdd-5c1f-4bf2-a8ce-2195c9a638b2"),
				ModifiedInSchemaUId = new Guid("6d570bdd-5c1f-4bf2-a8ce-2195c9a638b2"),
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
			return new SysQuerySqlText(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysQuerySqlText_QueryExecutionRulesEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysQuerySqlTextSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysQuerySqlTextSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6d570bdd-5c1f-4bf2-a8ce-2195c9a638b2"));
		}

		#endregion

	}

	#endregion

	#region Class: SysQuerySqlText

	/// <summary>
	/// Query sql text.
	/// </summary>
	public class SysQuerySqlText : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysQuerySqlText(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysQuerySqlText";
		}

		public SysQuerySqlText(SysQuerySqlText source)
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
		/// Sql text.
		/// </summary>
		public string SqlText {
			get {
				return GetTypedColumnValue<string>("SqlText");
			}
			set {
				SetColumnValue("SqlText", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysQuerySqlText_QueryExecutionRulesEventsProcess(UserConnection);
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
			return new SysQuerySqlText(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysQuerySqlText_QueryExecutionRulesEventsProcess

	/// <exclude/>
	public partial class SysQuerySqlText_QueryExecutionRulesEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysQuerySqlText
	{

		public SysQuerySqlText_QueryExecutionRulesEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysQuerySqlText_QueryExecutionRulesEventsProcess";
			SchemaUId = new Guid("6d570bdd-5c1f-4bf2-a8ce-2195c9a638b2");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("6d570bdd-5c1f-4bf2-a8ce-2195c9a638b2");
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

	#region Class: SysQuerySqlText_QueryExecutionRulesEventsProcess

	/// <exclude/>
	public class SysQuerySqlText_QueryExecutionRulesEventsProcess : SysQuerySqlText_QueryExecutionRulesEventsProcess<SysQuerySqlText>
	{

		public SysQuerySqlText_QueryExecutionRulesEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysQuerySqlText_QueryExecutionRulesEventsProcess

	public partial class SysQuerySqlText_QueryExecutionRulesEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysQuerySqlTextEventsProcess

	/// <exclude/>
	public class SysQuerySqlTextEventsProcess : SysQuerySqlText_QueryExecutionRulesEventsProcess
	{

		public SysQuerySqlTextEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

