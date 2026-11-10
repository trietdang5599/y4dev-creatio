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

	#region Class: QuickAddMenuSettingsSchema

	/// <exclude/>
	public class QuickAddMenuSettingsSchema : Terrasoft.Configuration.QuickAddMenuSettings_CrtCoreBase_CreatioSchema
	{

		#region Constructors: Public

		public QuickAddMenuSettingsSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public QuickAddMenuSettingsSchema(QuickAddMenuSettingsSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public QuickAddMenuSettingsSchema(QuickAddMenuSettingsSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("e8baafc3-fd02-4d16-955e-4cc2f240e914");
			Name = "QuickAddMenuSettings";
			ParentSchemaUId = new Guid("4aa8a1e1-77b5-421c-9e74-303810fbc561");
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
			return new QuickAddMenuSettings(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new QuickAddMenuSettings_SSPEventsProcess(userConnection);
		}

		public override object Clone() {
			return new QuickAddMenuSettingsSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new QuickAddMenuSettingsSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e8baafc3-fd02-4d16-955e-4cc2f240e914"));
		}

		#endregion

	}

	#endregion

	#region Class: QuickAddMenuSettings

	/// <summary>
	/// Group of quick add menu.
	/// </summary>
	public class QuickAddMenuSettings : Terrasoft.Configuration.QuickAddMenuSettings_CrtCoreBase_Creatio
	{

		#region Constructors: Public

		public QuickAddMenuSettings(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "QuickAddMenuSettings";
		}

		public QuickAddMenuSettings(QuickAddMenuSettings source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new QuickAddMenuSettings_SSPEventsProcess(UserConnection);
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
			return new QuickAddMenuSettings(this);
		}

		#endregion

	}

	#endregion

	#region Class: QuickAddMenuSettings_SSPEventsProcess

	/// <exclude/>
	public partial class QuickAddMenuSettings_SSPEventsProcess<TEntity> : Terrasoft.Configuration.QuickAddMenuSettings_CrtCoreBaseEventsProcess<TEntity> where TEntity : QuickAddMenuSettings
	{

		public QuickAddMenuSettings_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "QuickAddMenuSettings_SSPEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("e8baafc3-fd02-4d16-955e-4cc2f240e914");
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

	#region Class: QuickAddMenuSettings_SSPEventsProcess

	/// <exclude/>
	public class QuickAddMenuSettings_SSPEventsProcess : QuickAddMenuSettings_SSPEventsProcess<QuickAddMenuSettings>
	{

		public QuickAddMenuSettings_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: QuickAddMenuSettings_SSPEventsProcess

	public partial class QuickAddMenuSettings_SSPEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: QuickAddMenuSettingsEventsProcess

	/// <exclude/>
	public class QuickAddMenuSettingsEventsProcess : QuickAddMenuSettings_SSPEventsProcess
	{

		public QuickAddMenuSettingsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

