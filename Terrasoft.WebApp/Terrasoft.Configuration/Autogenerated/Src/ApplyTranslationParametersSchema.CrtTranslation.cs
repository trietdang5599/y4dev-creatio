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

	#region Class: ApplyTranslationParametersSchema

	/// <exclude/>
	public class ApplyTranslationParametersSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ApplyTranslationParametersSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ApplyTranslationParametersSchema(ApplyTranslationParametersSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ApplyTranslationParametersSchema(ApplyTranslationParametersSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("95152e06-88ad-49f6-b391-f1a85fd07214");
			RealUId = new Guid("95152e06-88ad-49f6-b391-f1a85fd07214");
			Name = "ApplyTranslationParameters";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("2f244451-ec5e-494f-9790-8d930a80007c");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
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
			if (Columns.FindByUId(new Guid("a4e1496b-02bb-55a9-e456-4f8c842ae683")) == null) {
				Columns.Add(CreateApplyParametersColumn());
			}
			if (Columns.FindByUId(new Guid("b7e4203e-c372-6702-006e-e0e45bc114e2")) == null) {
				Columns.Add(CreateStageColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateApplyParametersColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Binary")) {
				UId = new Guid("a4e1496b-02bb-55a9-e456-4f8c842ae683"),
				Name = @"ApplyParameters",
				CreatedInSchemaUId = new Guid("95152e06-88ad-49f6-b391-f1a85fd07214"),
				ModifiedInSchemaUId = new Guid("95152e06-88ad-49f6-b391-f1a85fd07214"),
				CreatedInPackageId = new Guid("2f244451-ec5e-494f-9790-8d930a80007c")
			};
		}

		protected virtual EntitySchemaColumn CreateStageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("b7e4203e-c372-6702-006e-e0e45bc114e2"),
				Name = @"Stage",
				CreatedInSchemaUId = new Guid("95152e06-88ad-49f6-b391-f1a85fd07214"),
				ModifiedInSchemaUId = new Guid("95152e06-88ad-49f6-b391-f1a85fd07214"),
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
			return new ApplyTranslationParameters(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ApplyTranslationParameters_CrtTranslationEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ApplyTranslationParametersSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ApplyTranslationParametersSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("95152e06-88ad-49f6-b391-f1a85fd07214"));
		}

		#endregion

	}

	#endregion

	#region Class: ApplyTranslationParameters

	/// <summary>
	/// Apply translation parameters.
	/// </summary>
	public class ApplyTranslationParameters : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ApplyTranslationParameters(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ApplyTranslationParameters";
		}

		public ApplyTranslationParameters(ApplyTranslationParameters source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Stage.
		/// </summary>
		public int Stage {
			get {
				return GetTypedColumnValue<int>("Stage");
			}
			set {
				SetColumnValue("Stage", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ApplyTranslationParameters_CrtTranslationEventsProcess(UserConnection);
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
			return new ApplyTranslationParameters(this);
		}

		#endregion

	}

	#endregion

	#region Class: ApplyTranslationParameters_CrtTranslationEventsProcess

	/// <exclude/>
	public partial class ApplyTranslationParameters_CrtTranslationEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : ApplyTranslationParameters
	{

		public ApplyTranslationParameters_CrtTranslationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ApplyTranslationParameters_CrtTranslationEventsProcess";
			SchemaUId = new Guid("95152e06-88ad-49f6-b391-f1a85fd07214");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("95152e06-88ad-49f6-b391-f1a85fd07214");
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

	#region Class: ApplyTranslationParameters_CrtTranslationEventsProcess

	/// <exclude/>
	public class ApplyTranslationParameters_CrtTranslationEventsProcess : ApplyTranslationParameters_CrtTranslationEventsProcess<ApplyTranslationParameters>
	{

		public ApplyTranslationParameters_CrtTranslationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ApplyTranslationParameters_CrtTranslationEventsProcess

	public partial class ApplyTranslationParameters_CrtTranslationEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ApplyTranslationParametersEventsProcess

	/// <exclude/>
	public class ApplyTranslationParametersEventsProcess : ApplyTranslationParameters_CrtTranslationEventsProcess
	{

		public ApplyTranslationParametersEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

