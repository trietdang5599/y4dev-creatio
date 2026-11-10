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

	#region Class: SysCspDirectiveNameSchema

	/// <exclude/>
	public class SysCspDirectiveNameSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public SysCspDirectiveNameSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysCspDirectiveNameSchema(SysCspDirectiveNameSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysCspDirectiveNameSchema(SysCspDirectiveNameSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("6f41fcd7-41d1-412d-bb4c-30ef57b00e5e");
			RealUId = new Guid("6f41fcd7-41d1-412d-bb4c-30ef57b00e5e");
			Name = "SysCspDirectiveName";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("a0471b24-7f70-454a-8569-189894383a57");
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
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.IsLocalizable = false;
			column.ModifiedInSchemaUId = new Guid("6f41fcd7-41d1-412d-bb4c-30ef57b00e5e");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.IsLocalizable = false;
			column.ModifiedInSchemaUId = new Guid("6f41fcd7-41d1-412d-bb4c-30ef57b00e5e");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysCspDirectiveName(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysCspDirectiveName_CSPEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysCspDirectiveNameSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysCspDirectiveNameSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6f41fcd7-41d1-412d-bb4c-30ef57b00e5e"));
		}

		#endregion

	}

	#endregion

	#region Class: SysCspDirectiveName

	/// <summary>
	/// Directive name.
	/// </summary>
	/// <remarks>
	/// CSP directive names.
	/// </remarks>
	public class SysCspDirectiveName : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public SysCspDirectiveName(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysCspDirectiveName";
		}

		public SysCspDirectiveName(SysCspDirectiveName source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysCspDirectiveName_CSPEventsProcess(UserConnection);
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
			return new SysCspDirectiveName(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysCspDirectiveName_CSPEventsProcess

	/// <exclude/>
	public partial class SysCspDirectiveName_CSPEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysCspDirectiveName
	{

		public SysCspDirectiveName_CSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysCspDirectiveName_CSPEventsProcess";
			SchemaUId = new Guid("6f41fcd7-41d1-412d-bb4c-30ef57b00e5e");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("6f41fcd7-41d1-412d-bb4c-30ef57b00e5e");
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

	#region Class: SysCspDirectiveName_CSPEventsProcess

	/// <exclude/>
	public class SysCspDirectiveName_CSPEventsProcess : SysCspDirectiveName_CSPEventsProcess<SysCspDirectiveName>
	{

		public SysCspDirectiveName_CSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysCspDirectiveName_CSPEventsProcess

	public partial class SysCspDirectiveName_CSPEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysCspDirectiveNameEventsProcess

	/// <exclude/>
	public class SysCspDirectiveNameEventsProcess : SysCspDirectiveName_CSPEventsProcess
	{

		public SysCspDirectiveNameEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

