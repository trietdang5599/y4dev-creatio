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

	#region Class: SysMsgUserStateSchema

	/// <exclude/>
	public class SysMsgUserStateSchema : Terrasoft.Configuration.BaseCodeImageLookupSchema
	{

		#region Constructors: Public

		public SysMsgUserStateSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysMsgUserStateSchema(SysMsgUserStateSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysMsgUserStateSchema(SysMsgUserStateSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("bb85a556-c9b9-41ee-acfa-eabc9bfb84ac");
			RealUId = new Guid("bb85a556-c9b9-41ee-acfa-eabc9bfb84ac");
			Name = "SysMsgUserState";
			ParentSchemaUId = new Guid("c21771d2-01fa-4646-96b0-e4b69e582b44");
			ExtendParent = false;
			CreatedInPackageId = new Guid("3644c994-8f85-41ec-8125-47013bac161f");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryImageColumn() {
			base.InitializePrimaryImageColumn();
			PrimaryImageColumn = CreateImageColumn();
			if (Columns.FindByUId(PrimaryImageColumn.UId) == null) {
				Columns.Add(PrimaryImageColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("e67359d9-76c4-4118-a79c-46e421b11c62")) == null) {
				Columns.Add(CreateIsDisplayOnlyColumn());
			}
			if (Columns.FindByUId(new Guid("a987423b-a858-4feb-885e-00db8293f227")) == null) {
				Columns.Add(CreateIconColumn());
			}
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("bb85a556-c9b9-41ee-acfa-eabc9bfb84ac");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("bb85a556-c9b9-41ee-acfa-eabc9bfb84ac");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("bb85a556-c9b9-41ee-acfa-eabc9bfb84ac");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("bb85a556-c9b9-41ee-acfa-eabc9bfb84ac");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.DataValueType = DataValueTypeManager.GetInstanceByName("ShortText");
			column.ModifiedInSchemaUId = new Guid("bb85a556-c9b9-41ee-acfa-eabc9bfb84ac");
			return column;
		}

		protected virtual EntitySchemaColumn CreateIsDisplayOnlyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("e67359d9-76c4-4118-a79c-46e421b11c62"),
				Name = @"IsDisplayOnly",
				CreatedInSchemaUId = new Guid("bb85a556-c9b9-41ee-acfa-eabc9bfb84ac"),
				ModifiedInSchemaUId = new Guid("bb85a556-c9b9-41ee-acfa-eabc9bfb84ac"),
				CreatedInPackageId = new Guid("cc041c70-8b15-43b4-a62a-30f4563cef27")
			};
		}

		protected virtual EntitySchemaColumn CreateIconColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("a987423b-a858-4feb-885e-00db8293f227"),
				Name = @"Icon",
				ReferenceSchemaUId = new Guid("14169d59-d673-4d47-a481-2b98bec51aec"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("bb85a556-c9b9-41ee-acfa-eabc9bfb84ac"),
				ModifiedInSchemaUId = new Guid("bb85a556-c9b9-41ee-acfa-eabc9bfb84ac"),
				CreatedInPackageId = new Guid("099a46f5-4272-4576-a215-4895a200b20c")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysMsgUserState(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysMsgUserState_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysMsgUserStateSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysMsgUserStateSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("bb85a556-c9b9-41ee-acfa-eabc9bfb84ac"));
		}

		#endregion

	}

	#endregion

	#region Class: SysMsgUserState

	/// <summary>
	/// User status when exchanging messages.
	/// </summary>
	public class SysMsgUserState : Terrasoft.Configuration.BaseCodeImageLookup
	{

		#region Constructors: Public

		public SysMsgUserState(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysMsgUserState";
		}

		public SysMsgUserState(SysMsgUserState source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Display only.
		/// </summary>
		public bool IsDisplayOnly {
			get {
				return GetTypedColumnValue<bool>("IsDisplayOnly");
			}
			set {
				SetColumnValue("IsDisplayOnly", value);
			}
		}

		/// <exclude/>
		public Guid IconId {
			get {
				return GetTypedColumnValue<Guid>("IconId");
			}
			set {
				SetColumnValue("IconId", value);
				_icon = null;
			}
		}

		/// <exclude/>
		public string IconName {
			get {
				return GetTypedColumnValue<string>("IconName");
			}
			set {
				SetColumnValue("IconName", value);
				if (_icon != null) {
					_icon.Name = value;
				}
			}
		}

		private SysMsgUserStateIcon _icon;
		/// <summary>
		/// Icon.
		/// </summary>
		public SysMsgUserStateIcon Icon {
			get {
				return _icon ??
					(_icon = LookupColumnEntities.GetEntity("Icon") as SysMsgUserStateIcon);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysMsgUserState_CrtBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysMsgUserStateDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysMsgUserStateDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysMsgUserStateInserted", e);
			Inserting += (s, e) => ThrowEvent("SysMsgUserStateInserting", e);
			Saved += (s, e) => ThrowEvent("SysMsgUserStateSaved", e);
			Saving += (s, e) => ThrowEvent("SysMsgUserStateSaving", e);
			Validating += (s, e) => ThrowEvent("SysMsgUserStateValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysMsgUserState(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysMsgUserState_CrtBaseEventsProcess

	/// <exclude/>
	public partial class SysMsgUserState_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseCodeImageLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysMsgUserState
	{

		public SysMsgUserState_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysMsgUserState_CrtBaseEventsProcess";
			SchemaUId = new Guid("bb85a556-c9b9-41ee-acfa-eabc9bfb84ac");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("bb85a556-c9b9-41ee-acfa-eabc9bfb84ac");
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

	#region Class: SysMsgUserState_CrtBaseEventsProcess

	/// <exclude/>
	public class SysMsgUserState_CrtBaseEventsProcess : SysMsgUserState_CrtBaseEventsProcess<SysMsgUserState>
	{

		public SysMsgUserState_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysMsgUserState_CrtBaseEventsProcess

	public partial class SysMsgUserState_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void CheckCanManageLookups() {
		}

		#endregion

	}

	#endregion


	#region Class: SysMsgUserStateEventsProcess

	/// <exclude/>
	public class SysMsgUserStateEventsProcess : SysMsgUserState_CrtBaseEventsProcess
	{

		public SysMsgUserStateEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

