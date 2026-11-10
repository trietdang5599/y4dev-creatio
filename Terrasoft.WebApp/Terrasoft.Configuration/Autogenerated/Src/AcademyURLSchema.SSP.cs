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

	#region Class: AcademyURLSchema

	/// <exclude/>
	public class AcademyURLSchema : Terrasoft.Configuration.AcademyURL_CrtBase_CreatioSchema
	{

		#region Constructors: Public

		public AcademyURLSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public AcademyURLSchema(AcademyURLSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public AcademyURLSchema(AcademyURLSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("5d32b714-042e-4fbf-9fc4-80725c46c3d8");
			Name = "AcademyURL";
			ParentSchemaUId = new Guid("2db09028-bfa5-4314-929d-0f149f348452");
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
			return new AcademyURL(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new AcademyURL_SSPEventsProcess(userConnection);
		}

		public override object Clone() {
			return new AcademyURLSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new AcademyURLSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5d32b714-042e-4fbf-9fc4-80725c46c3d8"));
		}

		#endregion

	}

	#endregion

	#region Class: AcademyURL

	/// <summary>
	/// Academy URL.
	/// </summary>
	public class AcademyURL : Terrasoft.Configuration.AcademyURL_CrtBase_Creatio
	{

		#region Constructors: Public

		public AcademyURL(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "AcademyURL";
		}

		public AcademyURL(AcademyURL source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new AcademyURL_SSPEventsProcess(UserConnection);
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
			return new AcademyURL(this);
		}

		#endregion

	}

	#endregion

	#region Class: AcademyURL_SSPEventsProcess

	/// <exclude/>
	public partial class AcademyURL_SSPEventsProcess<TEntity> : Terrasoft.Configuration.AcademyURL_CrtBaseEventsProcess<TEntity> where TEntity : AcademyURL
	{

		public AcademyURL_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "AcademyURL_SSPEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("5d32b714-042e-4fbf-9fc4-80725c46c3d8");
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

	#region Class: AcademyURL_SSPEventsProcess

	/// <exclude/>
	public class AcademyURL_SSPEventsProcess : AcademyURL_SSPEventsProcess<AcademyURL>
	{

		public AcademyURL_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: AcademyURL_SSPEventsProcess

	public partial class AcademyURL_SSPEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: AcademyURLEventsProcess

	/// <exclude/>
	public class AcademyURLEventsProcess : AcademyURL_SSPEventsProcess
	{

		public AcademyURLEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

