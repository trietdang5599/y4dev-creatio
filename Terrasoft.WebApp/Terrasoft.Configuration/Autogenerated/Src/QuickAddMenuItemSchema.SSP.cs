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

	#region Class: QuickAddMenuItemSchema

	/// <exclude/>
	public class QuickAddMenuItemSchema : Terrasoft.Configuration.QuickAddMenuItem_CrtNUI_CreatioSchema
	{

		#region Constructors: Public

		public QuickAddMenuItemSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public QuickAddMenuItemSchema(QuickAddMenuItemSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public QuickAddMenuItemSchema(QuickAddMenuItemSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("30bb5d63-7df5-4998-b0c6-571ce0a74985");
			Name = "QuickAddMenuItem";
			ParentSchemaUId = new Guid("a526ee14-e5f7-4174-8f48-ad030d8862af");
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
			return new QuickAddMenuItem(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new QuickAddMenuItem_SSPEventsProcess(userConnection);
		}

		public override object Clone() {
			return new QuickAddMenuItemSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new QuickAddMenuItemSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("30bb5d63-7df5-4998-b0c6-571ce0a74985"));
		}

		#endregion

	}

	#endregion

	#region Class: QuickAddMenuItem

	/// <summary>
	/// Item of the quick add menu.
	/// </summary>
	public class QuickAddMenuItem : Terrasoft.Configuration.QuickAddMenuItem_CrtNUI_Creatio
	{

		#region Constructors: Public

		public QuickAddMenuItem(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "QuickAddMenuItem";
		}

		public QuickAddMenuItem(QuickAddMenuItem source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new QuickAddMenuItem_SSPEventsProcess(UserConnection);
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
			return new QuickAddMenuItem(this);
		}

		#endregion

	}

	#endregion

	#region Class: QuickAddMenuItem_SSPEventsProcess

	/// <exclude/>
	public partial class QuickAddMenuItem_SSPEventsProcess<TEntity> : Terrasoft.Configuration.QuickAddMenuItem_CrtNUIEventsProcess<TEntity> where TEntity : QuickAddMenuItem
	{

		public QuickAddMenuItem_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "QuickAddMenuItem_SSPEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("30bb5d63-7df5-4998-b0c6-571ce0a74985");
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

	#region Class: QuickAddMenuItem_SSPEventsProcess

	/// <exclude/>
	public class QuickAddMenuItem_SSPEventsProcess : QuickAddMenuItem_SSPEventsProcess<QuickAddMenuItem>
	{

		public QuickAddMenuItem_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: QuickAddMenuItem_SSPEventsProcess

	public partial class QuickAddMenuItem_SSPEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: QuickAddMenuItemEventsProcess

	/// <exclude/>
	public class QuickAddMenuItemEventsProcess : QuickAddMenuItem_SSPEventsProcess
	{

		public QuickAddMenuItemEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

