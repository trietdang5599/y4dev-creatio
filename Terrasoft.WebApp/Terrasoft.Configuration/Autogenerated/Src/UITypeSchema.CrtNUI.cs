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

	#region Class: UIType_CrtNUI_CreatioSchema

	/// <exclude/>
	public class UIType_CrtNUI_CreatioSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public UIType_CrtNUI_CreatioSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public UIType_CrtNUI_CreatioSchema(UIType_CrtNUI_CreatioSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public UIType_CrtNUI_CreatioSchema(UIType_CrtNUI_CreatioSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f3a7bafb-bf85-4726-a929-191f14b63d45");
			RealUId = new Guid("f3a7bafb-bf85-4726-a929-191f14b63d45");
			Name = "UIType_CrtNUI_Creatio";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("cfb40756-6398-4eeb-936f-d3fcb2d92010");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
			UseLiveEditing = false;
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
			return new UIType_CrtNUI_Creatio(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new UIType_CrtNUIEventsProcess(userConnection);
		}

		public override object Clone() {
			return new UIType_CrtNUI_CreatioSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new UIType_CrtNUI_CreatioSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f3a7bafb-bf85-4726-a929-191f14b63d45"));
		}

		#endregion

	}

	#endregion

	#region Class: UIType_CrtNUI_Creatio

	/// <summary>
	/// Edit page UI.
	/// </summary>
	public class UIType_CrtNUI_Creatio : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public UIType_CrtNUI_Creatio(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "UIType_CrtNUI_Creatio";
		}

		public UIType_CrtNUI_Creatio(UIType_CrtNUI_Creatio source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new UIType_CrtNUIEventsProcess(UserConnection);
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
			return new UIType_CrtNUI_Creatio(this);
		}

		#endregion

	}

	#endregion

	#region Class: UIType_CrtNUIEventsProcess

	/// <exclude/>
	public partial class UIType_CrtNUIEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : UIType_CrtNUI_Creatio
	{

		public UIType_CrtNUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "UIType_CrtNUIEventsProcess";
			SchemaUId = new Guid("f3a7bafb-bf85-4726-a929-191f14b63d45");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("f3a7bafb-bf85-4726-a929-191f14b63d45");
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

	#region Class: UIType_CrtNUIEventsProcess

	/// <exclude/>
	public class UIType_CrtNUIEventsProcess : UIType_CrtNUIEventsProcess<UIType_CrtNUI_Creatio>
	{

		public UIType_CrtNUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: UIType_CrtNUIEventsProcess

	public partial class UIType_CrtNUIEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

