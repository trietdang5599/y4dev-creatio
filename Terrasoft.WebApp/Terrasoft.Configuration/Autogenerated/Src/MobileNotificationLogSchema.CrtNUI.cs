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

	#region Class: MobileNotificationLogSchema

	/// <exclude/>
	public class MobileNotificationLogSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public MobileNotificationLogSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public MobileNotificationLogSchema(MobileNotificationLogSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public MobileNotificationLogSchema(MobileNotificationLogSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d56edc3c-276d-4c50-b878-372c12027e33");
			RealUId = new Guid("d56edc3c-276d-4c50-b878-372c12027e33");
			Name = "MobileNotificationLog";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("387c4408-6999-4c3c-b31a-582581f83238");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateMessageColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("cd526a73-7696-2246-0b9d-bd09f1fd2879")) == null) {
				Columns.Add(CreateAdditionalDataColumn());
			}
			if (Columns.FindByUId(new Guid("396d7422-23a1-165b-cdee-cf7868652ea4")) == null) {
				Columns.Add(CreateSysAdminUnitIdColumn());
			}
			if (Columns.FindByUId(new Guid("1c115694-16d8-a666-9131-b4c2ee0fdebf")) == null) {
				Columns.Add(CreateTitleColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateMessageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("12386f52-f6c6-2145-b4a9-24c73a3b06a9"),
				Name = @"Message",
				CreatedInSchemaUId = new Guid("d56edc3c-276d-4c50-b878-372c12027e33"),
				ModifiedInSchemaUId = new Guid("d56edc3c-276d-4c50-b878-372c12027e33"),
				CreatedInPackageId = new Guid("387c4408-6999-4c3c-b31a-582581f83238"),
				IsFormatValidated = true
			};
		}

		protected virtual EntitySchemaColumn CreateAdditionalDataColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("cd526a73-7696-2246-0b9d-bd09f1fd2879"),
				Name = @"AdditionalData",
				CreatedInSchemaUId = new Guid("d56edc3c-276d-4c50-b878-372c12027e33"),
				ModifiedInSchemaUId = new Guid("d56edc3c-276d-4c50-b878-372c12027e33"),
				CreatedInPackageId = new Guid("387c4408-6999-4c3c-b31a-582581f83238"),
				IsFormatValidated = true
			};
		}

		protected virtual EntitySchemaColumn CreateSysAdminUnitIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("396d7422-23a1-165b-cdee-cf7868652ea4"),
				Name = @"SysAdminUnitId",
				CreatedInSchemaUId = new Guid("d56edc3c-276d-4c50-b878-372c12027e33"),
				ModifiedInSchemaUId = new Guid("d56edc3c-276d-4c50-b878-372c12027e33"),
				CreatedInPackageId = new Guid("387c4408-6999-4c3c-b31a-582581f83238")
			};
		}

		protected virtual EntitySchemaColumn CreateTitleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("1c115694-16d8-a666-9131-b4c2ee0fdebf"),
				Name = @"Title",
				CreatedInSchemaUId = new Guid("d56edc3c-276d-4c50-b878-372c12027e33"),
				ModifiedInSchemaUId = new Guid("d56edc3c-276d-4c50-b878-372c12027e33"),
				CreatedInPackageId = new Guid("387c4408-6999-4c3c-b31a-582581f83238"),
				IsFormatValidated = true
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new MobileNotificationLog(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new MobileNotificationLog_CrtNUIEventsProcess(userConnection);
		}

		public override object Clone() {
			return new MobileNotificationLogSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new MobileNotificationLogSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d56edc3c-276d-4c50-b878-372c12027e33"));
		}

		#endregion

	}

	#endregion

	#region Class: MobileNotificationLog

	/// <summary>
	/// Mobile notification log.
	/// </summary>
	public class MobileNotificationLog : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public MobileNotificationLog(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MobileNotificationLog";
		}

		public MobileNotificationLog(MobileNotificationLog source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Message.
		/// </summary>
		public string Message {
			get {
				return GetTypedColumnValue<string>("Message");
			}
			set {
				SetColumnValue("Message", value);
			}
		}

		/// <summary>
		/// Additional parameters.
		/// </summary>
		public string AdditionalData {
			get {
				return GetTypedColumnValue<string>("AdditionalData");
			}
			set {
				SetColumnValue("AdditionalData", value);
			}
		}

		/// <summary>
		/// SysAdminUnitId.
		/// </summary>
		public Guid SysAdminUnitId {
			get {
				return GetTypedColumnValue<Guid>("SysAdminUnitId");
			}
			set {
				SetColumnValue("SysAdminUnitId", value);
			}
		}

		/// <summary>
		/// Title.
		/// </summary>
		public string Title {
			get {
				return GetTypedColumnValue<string>("Title");
			}
			set {
				SetColumnValue("Title", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new MobileNotificationLog_CrtNUIEventsProcess(UserConnection);
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
			return new MobileNotificationLog(this);
		}

		#endregion

	}

	#endregion

	#region Class: MobileNotificationLog_CrtNUIEventsProcess

	/// <exclude/>
	public partial class MobileNotificationLog_CrtNUIEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : MobileNotificationLog
	{

		public MobileNotificationLog_CrtNUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "MobileNotificationLog_CrtNUIEventsProcess";
			SchemaUId = new Guid("d56edc3c-276d-4c50-b878-372c12027e33");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("d56edc3c-276d-4c50-b878-372c12027e33");
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

	#region Class: MobileNotificationLog_CrtNUIEventsProcess

	/// <exclude/>
	public class MobileNotificationLog_CrtNUIEventsProcess : MobileNotificationLog_CrtNUIEventsProcess<MobileNotificationLog>
	{

		public MobileNotificationLog_CrtNUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: MobileNotificationLog_CrtNUIEventsProcess

	public partial class MobileNotificationLog_CrtNUIEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: MobileNotificationLogEventsProcess

	/// <exclude/>
	public class MobileNotificationLogEventsProcess : MobileNotificationLog_CrtNUIEventsProcess
	{

		public MobileNotificationLogEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

