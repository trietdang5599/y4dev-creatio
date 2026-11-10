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

	#region Class: UITypeSchema

	/// <exclude/>
	public class UITypeSchema : Terrasoft.Configuration.UIType_CrtNUI_CreatioSchema
	{

		#region Constructors: Public

		public UITypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public UITypeSchema(UITypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public UITypeSchema(UITypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("bab02ef5-8ea0-4c57-952a-98c67b9dfdbf");
			Name = "UIType";
			ParentSchemaUId = new Guid("f3a7bafb-bf85-4726-a929-191f14b63d45");
			ExtendParent = true;
			CreatedInPackageId = new Guid("c337f396-fbc1-46b3-9fcc-15ed3f47e91f");
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

		protected override void InitializePrimaryColorColumn() {
			base.InitializePrimaryColorColumn();
			PrimaryColorColumn = CreateColorColumn();
			if (Columns.FindByUId(PrimaryColorColumn.UId) == null) {
				Columns.Add(PrimaryColorColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected virtual EntitySchemaColumn CreateColorColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Color")) {
				UId = new Guid("ca7f634c-d666-c173-a8a0-f7b466075d19"),
				Name = @"Color",
				CreatedInSchemaUId = new Guid("bab02ef5-8ea0-4c57-952a-98c67b9dfdbf"),
				ModifiedInSchemaUId = new Guid("bab02ef5-8ea0-4c57-952a-98c67b9dfdbf"),
				CreatedInPackageId = new Guid("c337f396-fbc1-46b3-9fcc-15ed3f47e91f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new UIType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new UIType_CrtUISwitcherEventsProcess(userConnection);
		}

		public override object Clone() {
			return new UITypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new UITypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("bab02ef5-8ea0-4c57-952a-98c67b9dfdbf"));
		}

		#endregion

	}

	#endregion

	#region Class: UIType

	/// <summary>
	/// Edit page UI.
	/// </summary>
	public class UIType : Terrasoft.Configuration.UIType_CrtNUI_Creatio
	{

		#region Constructors: Public

		public UIType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "UIType";
		}

		public UIType(UIType source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Color.
		/// </summary>
		public Color Color {
			get {
				return GetTypedColumnValue<Color>("Color");
			}
			set {
				SetColumnValue("Color", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new UIType_CrtUISwitcherEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("UITypeDeleted", e);
			Deleting += (s, e) => ThrowEvent("UITypeDeleting", e);
			Inserted += (s, e) => ThrowEvent("UITypeInserted", e);
			Inserting += (s, e) => ThrowEvent("UITypeInserting", e);
			Saved += (s, e) => ThrowEvent("UITypeSaved", e);
			Saving += (s, e) => ThrowEvent("UITypeSaving", e);
			Validating += (s, e) => ThrowEvent("UITypeValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new UIType(this);
		}

		#endregion

	}

	#endregion

	#region Class: UIType_CrtUISwitcherEventsProcess

	/// <exclude/>
	public partial class UIType_CrtUISwitcherEventsProcess<TEntity> : Terrasoft.Configuration.UIType_CrtNUIEventsProcess<TEntity> where TEntity : UIType
	{

		public UIType_CrtUISwitcherEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "UIType_CrtUISwitcherEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("bab02ef5-8ea0-4c57-952a-98c67b9dfdbf");
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

	#region Class: UIType_CrtUISwitcherEventsProcess

	/// <exclude/>
	public class UIType_CrtUISwitcherEventsProcess : UIType_CrtUISwitcherEventsProcess<UIType>
	{

		public UIType_CrtUISwitcherEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: UIType_CrtUISwitcherEventsProcess

	public partial class UIType_CrtUISwitcherEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: UITypeEventsProcess

	/// <exclude/>
	public class UITypeEventsProcess : UIType_CrtUISwitcherEventsProcess
	{

		public UITypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

