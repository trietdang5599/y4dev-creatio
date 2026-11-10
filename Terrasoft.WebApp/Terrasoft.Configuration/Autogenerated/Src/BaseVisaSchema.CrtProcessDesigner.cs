namespace Terrasoft.Configuration
{

	using DataContract = Terrasoft.Nui.ServiceModel.DataContract;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Data;
	using System.Drawing;
	using System.Globalization;
	using System.IO;
	using System.Linq;
	using System.Text;
	using System.Text.RegularExpressions;
	using Terrasoft.Common;
	using Terrasoft.Common.Json;
	using Terrasoft.Configuration.RightsService;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.DcmProcess;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;
	using Terrasoft.Mail;
	using Terrasoft.Messaging.Common;
	using Terrasoft.UI.WebControls.Controls;
	using Terrasoft.UI.WebControls.Utilities.Json.Converters;

	#region Class: BaseVisaSchema

	/// <exclude/>
	[IsVirtual]
	public class BaseVisaSchema : Terrasoft.Configuration.BaseVisa_CrtNUI_CreatioSchema
	{

		#region Constructors: Public

		public BaseVisaSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public BaseVisaSchema(BaseVisaSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public BaseVisaSchema(BaseVisaSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("fb8205af-1629-49e9-85b5-03ed0e030a02");
			Name = "BaseVisa";
			ParentSchemaUId = new Guid("5fa90d0d-64eb-4f52-8d3d-c51fa6443b66");
			ExtendParent = true;
			CreatedInPackageId = new Guid("8b1c57bf-1ff6-4af0-890b-4cc1ace5ccaa");
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

		protected override EntitySchemaColumn CreateStatusColumn() {
			EntitySchemaColumn column = base.CreateStatusColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.Const,
				ValueSource = @"3462594d-77a7-4b0a-874a-6d8b54b293bc"
			};
			column.ModifiedInSchemaUId = new Guid("fb8205af-1629-49e9-85b5-03ed0e030a02");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new BaseVisa(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new BaseVisa_CrtProcessDesignerEventsProcess(userConnection);
		}

		public override object Clone() {
			return new BaseVisaSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new BaseVisaSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("fb8205af-1629-49e9-85b5-03ed0e030a02"));
		}

		#endregion

	}

	#endregion

	#region Class: BaseVisa

	/// <summary>
	/// Base approval.
	/// </summary>
	public class BaseVisa : Terrasoft.Configuration.BaseVisa_CrtNUI_Creatio
	{

		#region Constructors: Public

		public BaseVisa(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BaseVisa";
		}

		public BaseVisa(BaseVisa source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new BaseVisa_CrtProcessDesignerEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("BaseVisaDeleted", e);
			Deleting += (s, e) => ThrowEvent("BaseVisaDeleting", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new BaseVisa(this);
		}

		#endregion

	}

	#endregion

	#region Class: BaseVisa_CrtProcessDesignerEventsProcess

	/// <exclude/>
	public partial class BaseVisa_CrtProcessDesignerEventsProcess<TEntity> : Terrasoft.Configuration.BaseVisa_CrtNUIEventsProcess<TEntity> where TEntity : BaseVisa
	{

		public BaseVisa_CrtProcessDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "BaseVisa_CrtProcessDesignerEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("fb8205af-1629-49e9-85b5-03ed0e030a02");
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

	#region Class: BaseVisa_CrtProcessDesignerEventsProcess

	/// <exclude/>
	public class BaseVisa_CrtProcessDesignerEventsProcess : BaseVisa_CrtProcessDesignerEventsProcess<BaseVisa>
	{

		public BaseVisa_CrtProcessDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion


	#region Class: BaseVisaEventsProcess

	/// <exclude/>
	public class BaseVisaEventsProcess : BaseVisa_CrtProcessDesignerEventsProcess
	{

		public BaseVisaEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

