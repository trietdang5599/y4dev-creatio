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

	#region Class: AppFeatureSchema

	/// <exclude/>
	[IsVirtual]
	public class AppFeatureSchema : Terrasoft.Configuration.BaseCodeLookupSchema
	{

		#region Constructors: Public

		public AppFeatureSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public AppFeatureSchema(AppFeatureSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public AppFeatureSchema(AppFeatureSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("1b221c58-4d4d-47ed-82ce-416181e775bf");
			RealUId = new Guid("1b221c58-4d4d-47ed-82ce-416181e775bf");
			Name = "AppFeature";
			ParentSchemaUId = new Guid("2681062b-df59-4e52-89ed-f9b7dc909ab2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("6f71e54c-1960-40c9-94f6-073fd67699ab");
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

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateCodeColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("41d5e584-f537-31da-76b1-2073906110ac")) == null) {
				Columns.Add(CreateStateColumn());
			}
			if (Columns.FindByUId(new Guid("f21a1aba-6304-bce3-1e1e-6f52eb412477")) == null) {
				Columns.Add(CreateStateForCurrentUserColumn());
			}
			if (Columns.FindByUId(new Guid("6a6b1e32-6de6-8e41-5f61-9681d9fb5128")) == null) {
				Columns.Add(CreateSourceColumn());
			}
		}

		protected override EntitySchemaColumn CreateCodeColumn() {
			EntitySchemaColumn column = base.CreateCodeColumn();
			column.DataValueType = DataValueTypeManager.GetInstanceByName("MediumText");
			column.ModifiedInSchemaUId = new Guid("1b221c58-4d4d-47ed-82ce-416181e775bf");
			return column;
		}

		protected virtual EntitySchemaColumn CreateStateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("41d5e584-f537-31da-76b1-2073906110ac"),
				Name = @"State",
				CreatedInSchemaUId = new Guid("1b221c58-4d4d-47ed-82ce-416181e775bf"),
				ModifiedInSchemaUId = new Guid("1b221c58-4d4d-47ed-82ce-416181e775bf"),
				CreatedInPackageId = new Guid("f0644392-b69e-4e52-90a7-66f9509f0134")
			};
		}

		protected virtual EntitySchemaColumn CreateStateForCurrentUserColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("f21a1aba-6304-bce3-1e1e-6f52eb412477"),
				Name = @"StateForCurrentUser",
				CreatedInSchemaUId = new Guid("1b221c58-4d4d-47ed-82ce-416181e775bf"),
				ModifiedInSchemaUId = new Guid("1b221c58-4d4d-47ed-82ce-416181e775bf"),
				CreatedInPackageId = new Guid("f0644392-b69e-4e52-90a7-66f9509f0134")
			};
		}

		protected virtual EntitySchemaColumn CreateSourceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("6a6b1e32-6de6-8e41-5f61-9681d9fb5128"),
				Name = @"Source",
				CreatedInSchemaUId = new Guid("1b221c58-4d4d-47ed-82ce-416181e775bf"),
				ModifiedInSchemaUId = new Guid("1b221c58-4d4d-47ed-82ce-416181e775bf"),
				CreatedInPackageId = new Guid("f56dd55e-5084-4296-932e-a32f081a1593")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new AppFeature(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new AppFeature_FeatureTogglingEventsProcess(userConnection);
		}

		public override object Clone() {
			return new AppFeatureSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new AppFeatureSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1b221c58-4d4d-47ed-82ce-416181e775bf"));
		}

		#endregion

	}

	#endregion

	#region Class: AppFeature

	/// <summary>
	/// Feature toggling.
	/// </summary>
	public class AppFeature : Terrasoft.Configuration.BaseCodeLookup
	{

		#region Constructors: Public

		public AppFeature(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "AppFeature";
		}

		public AppFeature(AppFeature source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Is enabled.
		/// </summary>
		public bool State {
			get {
				return GetTypedColumnValue<bool>("State");
			}
			set {
				SetColumnValue("State", value);
			}
		}

		/// <summary>
		/// Is enabled for current user.
		/// </summary>
		public bool StateForCurrentUser {
			get {
				return GetTypedColumnValue<bool>("StateForCurrentUser");
			}
			set {
				SetColumnValue("StateForCurrentUser", value);
			}
		}

		/// <summary>
		/// Source.
		/// </summary>
		public string Source {
			get {
				return GetTypedColumnValue<string>("Source");
			}
			set {
				SetColumnValue("Source", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new AppFeature_FeatureTogglingEventsProcess(UserConnection);
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
			return new AppFeature(this);
		}

		#endregion

	}

	#endregion

	#region Class: AppFeature_FeatureTogglingEventsProcess

	/// <exclude/>
	public partial class AppFeature_FeatureTogglingEventsProcess<TEntity> : Terrasoft.Configuration.BaseCodeLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : AppFeature
	{

		public AppFeature_FeatureTogglingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "AppFeature_FeatureTogglingEventsProcess";
			SchemaUId = new Guid("1b221c58-4d4d-47ed-82ce-416181e775bf");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("1b221c58-4d4d-47ed-82ce-416181e775bf");
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

	#region Class: AppFeature_FeatureTogglingEventsProcess

	/// <exclude/>
	public class AppFeature_FeatureTogglingEventsProcess : AppFeature_FeatureTogglingEventsProcess<AppFeature>
	{

		public AppFeature_FeatureTogglingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: AppFeature_FeatureTogglingEventsProcess

	public partial class AppFeature_FeatureTogglingEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: AppFeatureEventsProcess

	/// <exclude/>
	public class AppFeatureEventsProcess : AppFeature_FeatureTogglingEventsProcess
	{

		public AppFeatureEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

