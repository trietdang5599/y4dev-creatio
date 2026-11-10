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

	#region Class: AcademyURL_CrtBase_CreatioSchema

	/// <exclude/>
	public class AcademyURL_CrtBase_CreatioSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public AcademyURL_CrtBase_CreatioSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public AcademyURL_CrtBase_CreatioSchema(AcademyURL_CrtBase_CreatioSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public AcademyURL_CrtBase_CreatioSchema(AcademyURL_CrtBase_CreatioSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("2db09028-bfa5-4314-929d-0f149f348452");
			RealUId = new Guid("2db09028-bfa5-4314-929d-0f149f348452");
			Name = "AcademyURL_CrtBase_Creatio";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			IsDBView = false;
			UseDenyRecordRights = false;
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
			return new AcademyURL_CrtBase_Creatio(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new AcademyURL_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new AcademyURL_CrtBase_CreatioSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new AcademyURL_CrtBase_CreatioSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2db09028-bfa5-4314-929d-0f149f348452"));
		}

		#endregion

	}

	#endregion

	#region Class: AcademyURL_CrtBase_Creatio

	/// <summary>
	/// Academy URL.
	/// </summary>
	public class AcademyURL_CrtBase_Creatio : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public AcademyURL_CrtBase_Creatio(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "AcademyURL_CrtBase_Creatio";
		}

		public AcademyURL_CrtBase_Creatio(AcademyURL_CrtBase_Creatio source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new AcademyURL_CrtBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("AcademyURL_CrtBase_CreatioDeleted", e);
			Validating += (s, e) => ThrowEvent("AcademyURL_CrtBase_CreatioValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new AcademyURL_CrtBase_Creatio(this);
		}

		#endregion

	}

	#endregion

	#region Class: AcademyURL_CrtBaseEventsProcess

	/// <exclude/>
	public partial class AcademyURL_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : AcademyURL_CrtBase_Creatio
	{

		public AcademyURL_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "AcademyURL_CrtBaseEventsProcess";
			SchemaUId = new Guid("2db09028-bfa5-4314-929d-0f149f348452");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("2db09028-bfa5-4314-929d-0f149f348452");
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

	#region Class: AcademyURL_CrtBaseEventsProcess

	/// <exclude/>
	public class AcademyURL_CrtBaseEventsProcess : AcademyURL_CrtBaseEventsProcess<AcademyURL_CrtBase_Creatio>
	{

		public AcademyURL_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: AcademyURL_CrtBaseEventsProcess

	public partial class AcademyURL_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

