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

	#region Class: SysInstalledAppRunTypeSchema

	/// <exclude/>
	public class SysInstalledAppRunTypeSchema : Terrasoft.Configuration.BaseCodeLookupSchema
	{

		#region Constructors: Public

		public SysInstalledAppRunTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysInstalledAppRunTypeSchema(SysInstalledAppRunTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysInstalledAppRunTypeSchema(SysInstalledAppRunTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a135004f-e6dd-4c3c-b7a9-652d6abafe31");
			RealUId = new Guid("a135004f-e6dd-4c3c-b7a9-652d6abafe31");
			Name = "SysInstalledAppRunType";
			ParentSchemaUId = new Guid("2681062b-df59-4e52-89ed-f9b7dc909ab2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723");
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
			return new SysInstalledAppRunType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysInstalledAppRunType_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysInstalledAppRunTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysInstalledAppRunTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a135004f-e6dd-4c3c-b7a9-652d6abafe31"));
		}

		#endregion

	}

	#endregion

	#region Class: SysInstalledAppRunType

	/// <summary>
	/// Application run type.
	/// </summary>
	public class SysInstalledAppRunType : Terrasoft.Configuration.BaseCodeLookup
	{

		#region Constructors: Public

		public SysInstalledAppRunType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysInstalledAppRunType";
		}

		public SysInstalledAppRunType(SysInstalledAppRunType source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysInstalledAppRunType_CrtBaseEventsProcess(UserConnection);
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
			return new SysInstalledAppRunType(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysInstalledAppRunType_CrtBaseEventsProcess

	/// <exclude/>
	public partial class SysInstalledAppRunType_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseCodeLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysInstalledAppRunType
	{

		public SysInstalledAppRunType_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysInstalledAppRunType_CrtBaseEventsProcess";
			SchemaUId = new Guid("a135004f-e6dd-4c3c-b7a9-652d6abafe31");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("a135004f-e6dd-4c3c-b7a9-652d6abafe31");
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

	#region Class: SysInstalledAppRunType_CrtBaseEventsProcess

	/// <exclude/>
	public class SysInstalledAppRunType_CrtBaseEventsProcess : SysInstalledAppRunType_CrtBaseEventsProcess<SysInstalledAppRunType>
	{

		public SysInstalledAppRunType_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysInstalledAppRunType_CrtBaseEventsProcess

	public partial class SysInstalledAppRunType_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysInstalledAppRunTypeEventsProcess

	/// <exclude/>
	public class SysInstalledAppRunTypeEventsProcess : SysInstalledAppRunType_CrtBaseEventsProcess
	{

		public SysInstalledAppRunTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

