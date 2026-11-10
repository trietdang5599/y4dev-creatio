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

	#region Class: HtmlEditorMacrosSchema

	/// <exclude/>
	public class HtmlEditorMacrosSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public HtmlEditorMacrosSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public HtmlEditorMacrosSchema(HtmlEditorMacrosSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public HtmlEditorMacrosSchema(HtmlEditorMacrosSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a6744b2f-4781-4753-bb19-089b143dca02");
			RealUId = new Guid("a6744b2f-4781-4753-bb19-089b143dca02");
			Name = "HtmlEditorMacros";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("2e25ab49-5dc6-4f9d-b82e-b54253963d38");
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
			if (Columns.FindByUId(new Guid("dd403d2c-4823-3014-3a30-285849232d6d")) == null) {
				Columns.Add(CreatePositionColumn());
			}
			if (Columns.FindByUId(new Guid("f56134cd-ac33-bd9c-cbaf-30c4ff474f4b")) == null) {
				Columns.Add(CreatePathColumn());
			}
			if (Columns.FindByUId(new Guid("6b2f73ac-09d6-acf9-29ee-65f62142b8e4")) == null) {
				Columns.Add(CreateEntitySchemaNameColumn());
			}
		}

		protected virtual EntitySchemaColumn CreatePositionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("dd403d2c-4823-3014-3a30-285849232d6d"),
				Name = @"Position",
				CreatedInSchemaUId = new Guid("a6744b2f-4781-4753-bb19-089b143dca02"),
				ModifiedInSchemaUId = new Guid("a6744b2f-4781-4753-bb19-089b143dca02"),
				CreatedInPackageId = new Guid("2e25ab49-5dc6-4f9d-b82e-b54253963d38")
			};
		}

		protected virtual EntitySchemaColumn CreatePathColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("f56134cd-ac33-bd9c-cbaf-30c4ff474f4b"),
				Name = @"Path",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("a6744b2f-4781-4753-bb19-089b143dca02"),
				ModifiedInSchemaUId = new Guid("a6744b2f-4781-4753-bb19-089b143dca02"),
				CreatedInPackageId = new Guid("2e25ab49-5dc6-4f9d-b82e-b54253963d38")
			};
		}

		protected virtual EntitySchemaColumn CreateEntitySchemaNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("6b2f73ac-09d6-acf9-29ee-65f62142b8e4"),
				Name = @"EntitySchemaName",
				CreatedInSchemaUId = new Guid("a6744b2f-4781-4753-bb19-089b143dca02"),
				ModifiedInSchemaUId = new Guid("a6744b2f-4781-4753-bb19-089b143dca02"),
				CreatedInPackageId = new Guid("2e25ab49-5dc6-4f9d-b82e-b54253963d38")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new HtmlEditorMacros(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new HtmlEditorMacros_CrtMacrosBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new HtmlEditorMacrosSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new HtmlEditorMacrosSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a6744b2f-4781-4753-bb19-089b143dca02"));
		}

		#endregion

	}

	#endregion

	#region Class: HtmlEditorMacros

	/// <summary>
	/// HtmlEditorMacros.
	/// </summary>
	public class HtmlEditorMacros : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public HtmlEditorMacros(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "HtmlEditorMacros";
		}

		public HtmlEditorMacros(HtmlEditorMacros source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Position.
		/// </summary>
		public int Position {
			get {
				return GetTypedColumnValue<int>("Position");
			}
			set {
				SetColumnValue("Position", value);
			}
		}

		/// <summary>
		/// Path.
		/// </summary>
		public string Path {
			get {
				return GetTypedColumnValue<string>("Path");
			}
			set {
				SetColumnValue("Path", value);
			}
		}

		/// <summary>
		/// EntitySchemaName.
		/// </summary>
		public string EntitySchemaName {
			get {
				return GetTypedColumnValue<string>("EntitySchemaName");
			}
			set {
				SetColumnValue("EntitySchemaName", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new HtmlEditorMacros_CrtMacrosBaseEventsProcess(UserConnection);
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
			return new HtmlEditorMacros(this);
		}

		#endregion

	}

	#endregion

	#region Class: HtmlEditorMacros_CrtMacrosBaseEventsProcess

	/// <exclude/>
	public partial class HtmlEditorMacros_CrtMacrosBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : HtmlEditorMacros
	{

		public HtmlEditorMacros_CrtMacrosBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "HtmlEditorMacros_CrtMacrosBaseEventsProcess";
			SchemaUId = new Guid("a6744b2f-4781-4753-bb19-089b143dca02");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("a6744b2f-4781-4753-bb19-089b143dca02");
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

	#region Class: HtmlEditorMacros_CrtMacrosBaseEventsProcess

	/// <exclude/>
	public class HtmlEditorMacros_CrtMacrosBaseEventsProcess : HtmlEditorMacros_CrtMacrosBaseEventsProcess<HtmlEditorMacros>
	{

		public HtmlEditorMacros_CrtMacrosBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: HtmlEditorMacros_CrtMacrosBaseEventsProcess

	public partial class HtmlEditorMacros_CrtMacrosBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: HtmlEditorMacrosEventsProcess

	/// <exclude/>
	public class HtmlEditorMacrosEventsProcess : HtmlEditorMacros_CrtMacrosBaseEventsProcess
	{

		public HtmlEditorMacrosEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

