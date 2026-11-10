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

	#region Class: QuickAddItemSchema

	/// <exclude/>
	public class QuickAddItemSchema : Terrasoft.Configuration.QuickAddItem_CrtCoreBase_CreatioSchema
	{

		#region Constructors: Public

		public QuickAddItemSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public QuickAddItemSchema(QuickAddItemSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public QuickAddItemSchema(QuickAddItemSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("07d22177-0012-4a3a-bf28-15679c96baf1");
			Name = "QuickAddItem";
			ParentSchemaUId = new Guid("bfb1b574-dfc8-4ee5-9ad2-a7fc8c1f5cdf");
			ExtendParent = true;
			CreatedInPackageId = new Guid("7cc31540-fa76-4c79-9b86-a6eabd8e662c");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = false;
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
			return new QuickAddItem(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new QuickAddItem_SSPEventsProcess(userConnection);
		}

		public override object Clone() {
			return new QuickAddItemSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new QuickAddItemSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("07d22177-0012-4a3a-bf28-15679c96baf1"));
		}

		#endregion

	}

	#endregion

	#region Class: QuickAddItem

	/// <summary>
	/// Quick add records menu.
	/// </summary>
	public class QuickAddItem : Terrasoft.Configuration.QuickAddItem_CrtCoreBase_Creatio
	{

		#region Constructors: Public

		public QuickAddItem(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "QuickAddItem";
		}

		public QuickAddItem(QuickAddItem source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new QuickAddItem_SSPEventsProcess(UserConnection);
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
			return new QuickAddItem(this);
		}

		#endregion

	}

	#endregion

	#region Class: QuickAddItem_SSPEventsProcess

	/// <exclude/>
	public partial class QuickAddItem_SSPEventsProcess<TEntity> : Terrasoft.Configuration.QuickAddItem_CrtCoreBaseEventsProcess<TEntity> where TEntity : QuickAddItem
	{

		public QuickAddItem_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "QuickAddItem_SSPEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("07d22177-0012-4a3a-bf28-15679c96baf1");
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

	#region Class: QuickAddItem_SSPEventsProcess

	/// <exclude/>
	public class QuickAddItem_SSPEventsProcess : QuickAddItem_SSPEventsProcess<QuickAddItem>
	{

		public QuickAddItem_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: QuickAddItem_SSPEventsProcess

	public partial class QuickAddItem_SSPEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: QuickAddItemEventsProcess

	/// <exclude/>
	public class QuickAddItemEventsProcess : QuickAddItem_SSPEventsProcess
	{

		public QuickAddItemEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

