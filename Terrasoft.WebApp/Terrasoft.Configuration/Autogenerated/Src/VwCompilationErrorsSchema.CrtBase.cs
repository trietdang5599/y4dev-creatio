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

	#region Class: VwCompilationErrorsSchema

	/// <exclude/>
	public class VwCompilationErrorsSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public VwCompilationErrorsSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwCompilationErrorsSchema(VwCompilationErrorsSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwCompilationErrorsSchema(VwCompilationErrorsSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("9dd72e0f-fb3b-4a75-a2ed-41c41ce34c45");
			RealUId = new Guid("9dd72e0f-fb3b-4a75-a2ed-41c41ce34c45");
			Name = "VwCompilationErrors";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723");
			IsDBView = true;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = false;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("517f49be-ab37-7f96-ecc9-2046dfacac39")) == null) {
				Columns.Add(CreateErrorsWarningsColumn());
			}
			if (Columns.FindByUId(new Guid("ca2c22db-18bd-ad5a-fb12-55d6fd80342a")) == null) {
				Columns.Add(CreateProjectNameColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateErrorsWarningsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("517f49be-ab37-7f96-ecc9-2046dfacac39"),
				Name = @"ErrorsWarnings",
				CreatedInSchemaUId = new Guid("9dd72e0f-fb3b-4a75-a2ed-41c41ce34c45"),
				ModifiedInSchemaUId = new Guid("9dd72e0f-fb3b-4a75-a2ed-41c41ce34c45"),
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723")
			};
		}

		protected virtual EntitySchemaColumn CreateProjectNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("ca2c22db-18bd-ad5a-fb12-55d6fd80342a"),
				Name = @"ProjectName",
				CreatedInSchemaUId = new Guid("9dd72e0f-fb3b-4a75-a2ed-41c41ce34c45"),
				ModifiedInSchemaUId = new Guid("9dd72e0f-fb3b-4a75-a2ed-41c41ce34c45"),
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwCompilationErrors(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwCompilationErrors_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwCompilationErrorsSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwCompilationErrorsSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9dd72e0f-fb3b-4a75-a2ed-41c41ce34c45"));
		}

		#endregion

	}

	#endregion

	#region Class: VwCompilationErrors

	/// <summary>
	/// Compilation errors.
	/// </summary>
	public class VwCompilationErrors : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public VwCompilationErrors(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwCompilationErrors";
		}

		public VwCompilationErrors(VwCompilationErrors source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Errors/Warnings.
		/// </summary>
		public string ErrorsWarnings {
			get {
				return GetTypedColumnValue<string>("ErrorsWarnings");
			}
			set {
				SetColumnValue("ErrorsWarnings", value);
			}
		}

		/// <summary>
		/// Project name.
		/// </summary>
		public string ProjectName {
			get {
				return GetTypedColumnValue<string>("ProjectName");
			}
			set {
				SetColumnValue("ProjectName", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwCompilationErrors_CrtBaseEventsProcess(UserConnection);
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
			return new VwCompilationErrors(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwCompilationErrors_CrtBaseEventsProcess

	/// <exclude/>
	public partial class VwCompilationErrors_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : VwCompilationErrors
	{

		public VwCompilationErrors_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwCompilationErrors_CrtBaseEventsProcess";
			SchemaUId = new Guid("9dd72e0f-fb3b-4a75-a2ed-41c41ce34c45");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("9dd72e0f-fb3b-4a75-a2ed-41c41ce34c45");
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

	#region Class: VwCompilationErrors_CrtBaseEventsProcess

	/// <exclude/>
	public class VwCompilationErrors_CrtBaseEventsProcess : VwCompilationErrors_CrtBaseEventsProcess<VwCompilationErrors>
	{

		public VwCompilationErrors_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwCompilationErrors_CrtBaseEventsProcess

	public partial class VwCompilationErrors_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwCompilationErrorsEventsProcess

	/// <exclude/>
	public class VwCompilationErrorsEventsProcess : VwCompilationErrors_CrtBaseEventsProcess
	{

		public VwCompilationErrorsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

