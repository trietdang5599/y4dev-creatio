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

	#region Class: ApplySessionSchema

	/// <exclude/>
	public class ApplySessionSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ApplySessionSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ApplySessionSchema(ApplySessionSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ApplySessionSchema(ApplySessionSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e6f79157-4b1c-486b-8f22-ce50f9e1351d");
			RealUId = new Guid("e6f79157-4b1c-486b-8f22-ce50f9e1351d");
			Name = "ApplySession";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("2f244451-ec5e-494f-9790-8d930a80007c");
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

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("4605ea70-840e-90a8-e89f-93831ed5edf1")) == null) {
				Columns.Add(CreateProcessIdColumn());
			}
			if (Columns.FindByUId(new Guid("9f09eede-57c3-b23b-2a16-640c885b6512")) == null) {
				Columns.Add(CreateIsCanceledColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateProcessIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("4605ea70-840e-90a8-e89f-93831ed5edf1"),
				Name = @"ProcessId",
				CreatedInSchemaUId = new Guid("e6f79157-4b1c-486b-8f22-ce50f9e1351d"),
				ModifiedInSchemaUId = new Guid("e6f79157-4b1c-486b-8f22-ce50f9e1351d"),
				CreatedInPackageId = new Guid("2f244451-ec5e-494f-9790-8d930a80007c")
			};
		}

		protected virtual EntitySchemaColumn CreateIsCanceledColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("9f09eede-57c3-b23b-2a16-640c885b6512"),
				Name = @"IsCanceled",
				CreatedInSchemaUId = new Guid("e6f79157-4b1c-486b-8f22-ce50f9e1351d"),
				ModifiedInSchemaUId = new Guid("e6f79157-4b1c-486b-8f22-ce50f9e1351d"),
				CreatedInPackageId = new Guid("2f244451-ec5e-494f-9790-8d930a80007c")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ApplySession(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ApplySession_CrtTranslationEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ApplySessionSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ApplySessionSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e6f79157-4b1c-486b-8f22-ce50f9e1351d"));
		}

		#endregion

	}

	#endregion

	#region Class: ApplySession

	/// <summary>
	/// Translation apply session.
	/// </summary>
	public class ApplySession : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ApplySession(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ApplySession";
		}

		public ApplySession(ApplySession source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Process identifier.
		/// </summary>
		public Guid ProcessId {
			get {
				return GetTypedColumnValue<Guid>("ProcessId");
			}
			set {
				SetColumnValue("ProcessId", value);
			}
		}

		/// <summary>
		/// Is сanceled.
		/// </summary>
		public bool IsCanceled {
			get {
				return GetTypedColumnValue<bool>("IsCanceled");
			}
			set {
				SetColumnValue("IsCanceled", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ApplySession_CrtTranslationEventsProcess(UserConnection);
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
			return new ApplySession(this);
		}

		#endregion

	}

	#endregion

	#region Class: ApplySession_CrtTranslationEventsProcess

	/// <exclude/>
	public partial class ApplySession_CrtTranslationEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : ApplySession
	{

		public ApplySession_CrtTranslationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ApplySession_CrtTranslationEventsProcess";
			SchemaUId = new Guid("e6f79157-4b1c-486b-8f22-ce50f9e1351d");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("e6f79157-4b1c-486b-8f22-ce50f9e1351d");
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

	#region Class: ApplySession_CrtTranslationEventsProcess

	/// <exclude/>
	public class ApplySession_CrtTranslationEventsProcess : ApplySession_CrtTranslationEventsProcess<ApplySession>
	{

		public ApplySession_CrtTranslationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ApplySession_CrtTranslationEventsProcess

	public partial class ApplySession_CrtTranslationEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ApplySessionEventsProcess

	/// <exclude/>
	public class ApplySessionEventsProcess : ApplySession_CrtTranslationEventsProcess
	{

		public ApplySessionEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

