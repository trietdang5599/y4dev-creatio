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

	#region Class: SenderDomainsInfoSchema

	/// <exclude/>
	public class SenderDomainsInfoSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SenderDomainsInfoSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SenderDomainsInfoSchema(SenderDomainsInfoSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SenderDomainsInfoSchema(SenderDomainsInfoSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("fe7368cb-c4c8-417b-beb1-d5a848d468e9");
			RealUId = new Guid("fe7368cb-c4c8-417b-beb1-d5a848d468e9");
			Name = "SenderDomainsInfo";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("5f5fe385-d25b-4c17-9585-cfaff007abaf");
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
			if (Columns.FindByUId(new Guid("f9e0786f-ad2c-0da5-2a45-846653783bb4")) == null) {
				Columns.Add(CreateMessageColumn());
			}
			if (Columns.FindByUId(new Guid("593b2b8c-8881-9132-bca0-14a499a7bf08")) == null) {
				Columns.Add(CreateCodeColumn());
			}
			if (Columns.FindByUId(new Guid("86b21a21-1db8-a662-8a72-983eea58d420")) == null) {
				Columns.Add(CreateStatusColumn());
			}
			if (Columns.FindByUId(new Guid("a8486542-7e0b-efc3-7e3a-ad8c83fc9e73")) == null) {
				Columns.Add(CreateDomainValidationRecordColumn());
			}
			if (Columns.FindByUId(new Guid("55503c53-ac6e-dc24-7618-8ba2aea566c9")) == null) {
				Columns.Add(CreateDmarkValueColumn());
			}
			if (Columns.FindByUId(new Guid("48048411-ebf2-32c3-2df7-883ca61dc6a7")) == null) {
				Columns.Add(CreateSpfValueColumn());
			}
			if (Columns.FindByUId(new Guid("c2626e4f-6662-b1a2-8def-f469ae5d7c4e")) == null) {
				Columns.Add(CreateDKIMRecordColumn());
			}
			if (Columns.FindByUId(new Guid("5570dfa8-33a3-00c1-1462-901edbf5883e")) == null) {
				Columns.Add(CreateDefaultDKIMKeyColumn());
			}
			if (Columns.FindByUId(new Guid("61c59795-554b-2227-4478-abdfbf2b0007")) == null) {
				Columns.Add(CreateCacheKeyColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateMessageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("f9e0786f-ad2c-0da5-2a45-846653783bb4"),
				Name = @"Message",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("fe7368cb-c4c8-417b-beb1-d5a848d468e9"),
				ModifiedInSchemaUId = new Guid("fe7368cb-c4c8-417b-beb1-d5a848d468e9"),
				CreatedInPackageId = new Guid("5f5fe385-d25b-4c17-9585-cfaff007abaf")
			};
		}

		protected virtual EntitySchemaColumn CreateCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("593b2b8c-8881-9132-bca0-14a499a7bf08"),
				Name = @"Code",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("fe7368cb-c4c8-417b-beb1-d5a848d468e9"),
				ModifiedInSchemaUId = new Guid("fe7368cb-c4c8-417b-beb1-d5a848d468e9"),
				CreatedInPackageId = new Guid("5f5fe385-d25b-4c17-9585-cfaff007abaf")
			};
		}

		protected virtual EntitySchemaColumn CreateStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("86b21a21-1db8-a662-8a72-983eea58d420"),
				Name = @"Status",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("fe7368cb-c4c8-417b-beb1-d5a848d468e9"),
				ModifiedInSchemaUId = new Guid("fe7368cb-c4c8-417b-beb1-d5a848d468e9"),
				CreatedInPackageId = new Guid("5f5fe385-d25b-4c17-9585-cfaff007abaf")
			};
		}

		protected virtual EntitySchemaColumn CreateDomainValidationRecordColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("a8486542-7e0b-efc3-7e3a-ad8c83fc9e73"),
				Name = @"DomainValidationRecord",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("fe7368cb-c4c8-417b-beb1-d5a848d468e9"),
				ModifiedInSchemaUId = new Guid("fe7368cb-c4c8-417b-beb1-d5a848d468e9"),
				CreatedInPackageId = new Guid("5f5fe385-d25b-4c17-9585-cfaff007abaf")
			};
		}

		protected virtual EntitySchemaColumn CreateDmarkValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("55503c53-ac6e-dc24-7618-8ba2aea566c9"),
				Name = @"DmarkValue",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("fe7368cb-c4c8-417b-beb1-d5a848d468e9"),
				ModifiedInSchemaUId = new Guid("fe7368cb-c4c8-417b-beb1-d5a848d468e9"),
				CreatedInPackageId = new Guid("5f5fe385-d25b-4c17-9585-cfaff007abaf")
			};
		}

		protected virtual EntitySchemaColumn CreateSpfValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("48048411-ebf2-32c3-2df7-883ca61dc6a7"),
				Name = @"SpfValue",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("fe7368cb-c4c8-417b-beb1-d5a848d468e9"),
				ModifiedInSchemaUId = new Guid("fe7368cb-c4c8-417b-beb1-d5a848d468e9"),
				CreatedInPackageId = new Guid("5f5fe385-d25b-4c17-9585-cfaff007abaf")
			};
		}

		protected virtual EntitySchemaColumn CreateDKIMRecordColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("c2626e4f-6662-b1a2-8def-f469ae5d7c4e"),
				Name = @"DKIMRecord",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("fe7368cb-c4c8-417b-beb1-d5a848d468e9"),
				ModifiedInSchemaUId = new Guid("fe7368cb-c4c8-417b-beb1-d5a848d468e9"),
				CreatedInPackageId = new Guid("5f5fe385-d25b-4c17-9585-cfaff007abaf")
			};
		}

		protected virtual EntitySchemaColumn CreateDefaultDKIMKeyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("5570dfa8-33a3-00c1-1462-901edbf5883e"),
				Name = @"DefaultDKIMKey",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("fe7368cb-c4c8-417b-beb1-d5a848d468e9"),
				ModifiedInSchemaUId = new Guid("fe7368cb-c4c8-417b-beb1-d5a848d468e9"),
				CreatedInPackageId = new Guid("5f5fe385-d25b-4c17-9585-cfaff007abaf")
			};
		}

		protected virtual EntitySchemaColumn CreateCacheKeyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("61c59795-554b-2227-4478-abdfbf2b0007"),
				Name = @"CacheKey",
				CreatedInSchemaUId = new Guid("fe7368cb-c4c8-417b-beb1-d5a848d468e9"),
				ModifiedInSchemaUId = new Guid("fe7368cb-c4c8-417b-beb1-d5a848d468e9"),
				CreatedInPackageId = new Guid("5f5fe385-d25b-4c17-9585-cfaff007abaf")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SenderDomainsInfo(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SenderDomainsInfo_CrtCloudIntegrationEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SenderDomainsInfoSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SenderDomainsInfoSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("fe7368cb-c4c8-417b-beb1-d5a848d468e9"));
		}

		#endregion

	}

	#endregion

	#region Class: SenderDomainsInfo

	/// <summary>
	/// Sender domains info.
	/// </summary>
	public class SenderDomainsInfo : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SenderDomainsInfo(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SenderDomainsInfo";
		}

		public SenderDomainsInfo(SenderDomainsInfo source)
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
		/// Code.
		/// </summary>
		public int Code {
			get {
				return GetTypedColumnValue<int>("Code");
			}
			set {
				SetColumnValue("Code", value);
			}
		}

		/// <summary>
		/// Status.
		/// </summary>
		public string Status {
			get {
				return GetTypedColumnValue<string>("Status");
			}
			set {
				SetColumnValue("Status", value);
			}
		}

		/// <summary>
		/// Domain validation record.
		/// </summary>
		public string DomainValidationRecord {
			get {
				return GetTypedColumnValue<string>("DomainValidationRecord");
			}
			set {
				SetColumnValue("DomainValidationRecord", value);
			}
		}

		/// <summary>
		/// Dmark value.
		/// </summary>
		public string DmarkValue {
			get {
				return GetTypedColumnValue<string>("DmarkValue");
			}
			set {
				SetColumnValue("DmarkValue", value);
			}
		}

		/// <summary>
		/// SPF value.
		/// </summary>
		public string SpfValue {
			get {
				return GetTypedColumnValue<string>("SpfValue");
			}
			set {
				SetColumnValue("SpfValue", value);
			}
		}

		/// <summary>
		/// DKIM record.
		/// </summary>
		public string DKIMRecord {
			get {
				return GetTypedColumnValue<string>("DKIMRecord");
			}
			set {
				SetColumnValue("DKIMRecord", value);
			}
		}

		/// <summary>
		/// Default DKIM key.
		/// </summary>
		public string DefaultDKIMKey {
			get {
				return GetTypedColumnValue<string>("DefaultDKIMKey");
			}
			set {
				SetColumnValue("DefaultDKIMKey", value);
			}
		}

		/// <summary>
		/// Cache key.
		/// </summary>
		public string CacheKey {
			get {
				return GetTypedColumnValue<string>("CacheKey");
			}
			set {
				SetColumnValue("CacheKey", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SenderDomainsInfo_CrtCloudIntegrationEventsProcess(UserConnection);
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
			return new SenderDomainsInfo(this);
		}

		#endregion

	}

	#endregion

	#region Class: SenderDomainsInfo_CrtCloudIntegrationEventsProcess

	/// <exclude/>
	public partial class SenderDomainsInfo_CrtCloudIntegrationEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : SenderDomainsInfo
	{

		public SenderDomainsInfo_CrtCloudIntegrationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SenderDomainsInfo_CrtCloudIntegrationEventsProcess";
			SchemaUId = new Guid("fe7368cb-c4c8-417b-beb1-d5a848d468e9");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("fe7368cb-c4c8-417b-beb1-d5a848d468e9");
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

	#region Class: SenderDomainsInfo_CrtCloudIntegrationEventsProcess

	/// <exclude/>
	public class SenderDomainsInfo_CrtCloudIntegrationEventsProcess : SenderDomainsInfo_CrtCloudIntegrationEventsProcess<SenderDomainsInfo>
	{

		public SenderDomainsInfo_CrtCloudIntegrationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SenderDomainsInfo_CrtCloudIntegrationEventsProcess

	public partial class SenderDomainsInfo_CrtCloudIntegrationEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SenderDomainsInfoEventsProcess

	/// <exclude/>
	public class SenderDomainsInfoEventsProcess : SenderDomainsInfo_CrtCloudIntegrationEventsProcess
	{

		public SenderDomainsInfoEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

