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

	#region Class: DesktopSchema

	/// <exclude/>
	public class DesktopSchema : Terrasoft.Configuration.Desktop_CrtUIv2_CreatioSchema
	{

		#region Constructors: Public

		public DesktopSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public DesktopSchema(DesktopSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public DesktopSchema(DesktopSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("4d651ad9-3575-437d-8de2-ecc3a6475a46");
			Name = "Desktop";
			ParentSchemaUId = new Guid("d2a75817-ac9a-4c95-bcaf-bd2e237bf11c");
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
			return new Desktop(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Desktop_SSPEventsProcess(userConnection);
		}

		public override object Clone() {
			return new DesktopSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new DesktopSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4d651ad9-3575-437d-8de2-ecc3a6475a46"));
		}

		#endregion

	}

	#endregion

	#region Class: Desktop

	/// <summary>
	/// Desktop.
	/// </summary>
	public class Desktop : Terrasoft.Configuration.Desktop_CrtUIv2_Creatio
	{

		#region Constructors: Public

		public Desktop(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Desktop";
		}

		public Desktop(Desktop source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Desktop_SSPEventsProcess(UserConnection);
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
			return new Desktop(this);
		}

		#endregion

	}

	#endregion

	#region Class: Desktop_SSPEventsProcess

	/// <exclude/>
	public partial class Desktop_SSPEventsProcess<TEntity> : Terrasoft.Configuration.Desktop_CrtUIv2EventsProcess<TEntity> where TEntity : Desktop
	{

		public Desktop_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Desktop_SSPEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("4d651ad9-3575-437d-8de2-ecc3a6475a46");
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

	#region Class: Desktop_SSPEventsProcess

	/// <exclude/>
	public class Desktop_SSPEventsProcess : Desktop_SSPEventsProcess<Desktop>
	{

		public Desktop_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Desktop_SSPEventsProcess

	public partial class Desktop_SSPEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: DesktopEventsProcess

	/// <exclude/>
	public class DesktopEventsProcess : Desktop_SSPEventsProcess
	{

		public DesktopEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

