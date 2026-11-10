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

	#region Class: LocalizationChangeLogSchema

	/// <exclude/>
	public class LocalizationChangeLogSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public LocalizationChangeLogSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public LocalizationChangeLogSchema(LocalizationChangeLogSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public LocalizationChangeLogSchema(LocalizationChangeLogSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("dc0231be-93ea-49e9-99f6-1297b39c6d14");
			RealUId = new Guid("dc0231be-93ea-49e9-99f6-1297b39c6d14");
			Name = "LocalizationChangeLog";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("cd1bb618-6314-4183-aaef-bc4cbac4380a");
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
			if (Columns.FindByUId(new Guid("d46b3d03-a844-6a61-9739-d6aa3998e85a")) == null) {
				Columns.Add(CreateNewValueColumn());
			}
			if (Columns.FindByUId(new Guid("b01d6ed2-1992-2394-37fd-049845663f78")) == null) {
				Columns.Add(CreateOldValueColumn());
			}
			if (Columns.FindByUId(new Guid("2c8cde49-baf3-30b2-51c4-f76665ef815d")) == null) {
				Columns.Add(CreateKeyColumn());
			}
			if (Columns.FindByUId(new Guid("1a5a077a-d795-a186-a99b-4842d0358bc4")) == null) {
				Columns.Add(CreateConfActivityLogColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateNewValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("d46b3d03-a844-6a61-9739-d6aa3998e85a"),
				Name = @"NewValue",
				CreatedInSchemaUId = new Guid("dc0231be-93ea-49e9-99f6-1297b39c6d14"),
				ModifiedInSchemaUId = new Guid("dc0231be-93ea-49e9-99f6-1297b39c6d14"),
				CreatedInPackageId = new Guid("cd1bb618-6314-4183-aaef-bc4cbac4380a")
			};
		}

		protected virtual EntitySchemaColumn CreateOldValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("b01d6ed2-1992-2394-37fd-049845663f78"),
				Name = @"OldValue",
				CreatedInSchemaUId = new Guid("dc0231be-93ea-49e9-99f6-1297b39c6d14"),
				ModifiedInSchemaUId = new Guid("dc0231be-93ea-49e9-99f6-1297b39c6d14"),
				CreatedInPackageId = new Guid("cd1bb618-6314-4183-aaef-bc4cbac4380a")
			};
		}

		protected virtual EntitySchemaColumn CreateKeyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("2c8cde49-baf3-30b2-51c4-f76665ef815d"),
				Name = @"Key",
				CreatedInSchemaUId = new Guid("dc0231be-93ea-49e9-99f6-1297b39c6d14"),
				ModifiedInSchemaUId = new Guid("dc0231be-93ea-49e9-99f6-1297b39c6d14"),
				CreatedInPackageId = new Guid("cd1bb618-6314-4183-aaef-bc4cbac4380a")
			};
		}

		protected virtual EntitySchemaColumn CreateConfActivityLogColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("1a5a077a-d795-a186-a99b-4842d0358bc4"),
				Name = @"ConfActivityLog",
				CreatedInSchemaUId = new Guid("dc0231be-93ea-49e9-99f6-1297b39c6d14"),
				ModifiedInSchemaUId = new Guid("dc0231be-93ea-49e9-99f6-1297b39c6d14"),
				CreatedInPackageId = new Guid("cd1bb618-6314-4183-aaef-bc4cbac4380a")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new LocalizationChangeLog(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new LocalizationChangeLog_CrtConfActivityLogEventsProcess(userConnection);
		}

		public override object Clone() {
			return new LocalizationChangeLogSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new LocalizationChangeLogSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("dc0231be-93ea-49e9-99f6-1297b39c6d14"));
		}

		#endregion

	}

	#endregion

	#region Class: LocalizationChangeLog

	/// <summary>
	/// Localization change log.
	/// </summary>
	public class LocalizationChangeLog : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public LocalizationChangeLog(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "LocalizationChangeLog";
		}

		public LocalizationChangeLog(LocalizationChangeLog source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// New value.
		/// </summary>
		public string NewValue {
			get {
				return GetTypedColumnValue<string>("NewValue");
			}
			set {
				SetColumnValue("NewValue", value);
			}
		}

		/// <summary>
		/// Old value.
		/// </summary>
		public string OldValue {
			get {
				return GetTypedColumnValue<string>("OldValue");
			}
			set {
				SetColumnValue("OldValue", value);
			}
		}

		/// <summary>
		/// Key.
		/// </summary>
		public string Key {
			get {
				return GetTypedColumnValue<string>("Key");
			}
			set {
				SetColumnValue("Key", value);
			}
		}

		/// <summary>
		/// ConfActivityLog.
		/// </summary>
		public Guid ConfActivityLog {
			get {
				return GetTypedColumnValue<Guid>("ConfActivityLog");
			}
			set {
				SetColumnValue("ConfActivityLog", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new LocalizationChangeLog_CrtConfActivityLogEventsProcess(UserConnection);
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
			return new LocalizationChangeLog(this);
		}

		#endregion

	}

	#endregion

	#region Class: LocalizationChangeLog_CrtConfActivityLogEventsProcess

	/// <exclude/>
	public partial class LocalizationChangeLog_CrtConfActivityLogEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : LocalizationChangeLog
	{

		public LocalizationChangeLog_CrtConfActivityLogEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "LocalizationChangeLog_CrtConfActivityLogEventsProcess";
			SchemaUId = new Guid("dc0231be-93ea-49e9-99f6-1297b39c6d14");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("dc0231be-93ea-49e9-99f6-1297b39c6d14");
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

	#region Class: LocalizationChangeLog_CrtConfActivityLogEventsProcess

	/// <exclude/>
	public class LocalizationChangeLog_CrtConfActivityLogEventsProcess : LocalizationChangeLog_CrtConfActivityLogEventsProcess<LocalizationChangeLog>
	{

		public LocalizationChangeLog_CrtConfActivityLogEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: LocalizationChangeLog_CrtConfActivityLogEventsProcess

	public partial class LocalizationChangeLog_CrtConfActivityLogEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: LocalizationChangeLogEventsProcess

	/// <exclude/>
	public class LocalizationChangeLogEventsProcess : LocalizationChangeLog_CrtConfActivityLogEventsProcess
	{

		public LocalizationChangeLogEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

