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

	#region Class: EmailMetadataSchema

	/// <exclude/>
	public class EmailMetadataSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public EmailMetadataSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public EmailMetadataSchema(EmailMetadataSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public EmailMetadataSchema(EmailMetadataSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIX_EMD_CreatedOn_DescIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("2b3216b7-1b29-4ab0-9034-692d3f11e4d6");
			index.Name = "IX_EMD_CreatedOn_Desc";
			index.CreatedInSchemaUId = new Guid("1a04fa82-7723-4c4f-86dc-d2196296b90e");
			index.ModifiedInSchemaUId = new Guid("1a04fa82-7723-4c4f-86dc-d2196296b90e");
			index.CreatedInPackageId = new Guid("95a133a1-cd5f-4df8-af8f-ad440775d7d1");
			EntitySchemaIndexColumn createdOnIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("8d8d8a76-60e8-2d3e-c5d0-0e0471287bde"),
				ColumnUId = new Guid("e80190a5-03b2-4095-90f7-a193a960adee"),
				CreatedInSchemaUId = new Guid("1a04fa82-7723-4c4f-86dc-d2196296b90e"),
				ModifiedInSchemaUId = new Guid("1a04fa82-7723-4c4f-86dc-d2196296b90e"),
				CreatedInPackageId = new Guid("95a133a1-cd5f-4df8-af8f-ad440775d7d1"),
				OrderDirection = OrderDirectionStrict.Descending
			};
			index.Columns.Add(createdOnIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("1a04fa82-7723-4c4f-86dc-d2196296b90e");
			RealUId = new Guid("1a04fa82-7723-4c4f-86dc-d2196296b90e");
			Name = "EmailMetadata";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("95a133a1-cd5f-4df8-af8f-ad440775d7d1");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = false;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeMasterRecordColumn() {
			base.InitializeMasterRecordColumn();
			MasterRecordColumn = CreateActivityColumn();
			if (Columns.FindByUId(MasterRecordColumn.UId) == null) {
				Columns.Add(MasterRecordColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("1c33fed8-70c2-89f5-300f-93f7d18897ac")) == null) {
				Columns.Add(CreatePreviewColumn());
			}
		}

		protected virtual EntitySchemaColumn CreatePreviewColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("1c33fed8-70c2-89f5-300f-93f7d18897ac"),
				Name = @"Preview",
				CreatedInSchemaUId = new Guid("1a04fa82-7723-4c4f-86dc-d2196296b90e"),
				ModifiedInSchemaUId = new Guid("1a04fa82-7723-4c4f-86dc-d2196296b90e"),
				CreatedInPackageId = new Guid("95a133a1-cd5f-4df8-af8f-ad440775d7d1")
			};
		}

		protected virtual EntitySchemaColumn CreateActivityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("783e9ecf-dcb0-69eb-945c-07b568d00ce6"),
				Name = @"Activity",
				ReferenceSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("1a04fa82-7723-4c4f-86dc-d2196296b90e"),
				ModifiedInSchemaUId = new Guid("1a04fa82-7723-4c4f-86dc-d2196296b90e"),
				CreatedInPackageId = new Guid("95a133a1-cd5f-4df8-af8f-ad440775d7d1"),
				IsSimpleLookup = true
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIX_EMD_CreatedOn_DescIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new EmailMetadata(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new EmailMetadata_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new EmailMetadataSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new EmailMetadataSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1a04fa82-7723-4c4f-86dc-d2196296b90e"));
		}

		#endregion

	}

	#endregion

	#region Class: EmailMetadata

	/// <summary>
	/// Email metadata.
	/// </summary>
	public class EmailMetadata : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public EmailMetadata(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "EmailMetadata";
		}

		public EmailMetadata(EmailMetadata source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Email preview.
		/// </summary>
		public string Preview {
			get {
				return GetTypedColumnValue<string>("Preview");
			}
			set {
				SetColumnValue("Preview", value);
			}
		}

		/// <exclude/>
		public Guid ActivityId {
			get {
				return GetTypedColumnValue<Guid>("ActivityId");
			}
			set {
				SetColumnValue("ActivityId", value);
				_activity = null;
			}
		}

		/// <exclude/>
		public string ActivityTitle {
			get {
				return GetTypedColumnValue<string>("ActivityTitle");
			}
			set {
				SetColumnValue("ActivityTitle", value);
				if (_activity != null) {
					_activity.Title = value;
				}
			}
		}

		private Activity _activity;
		/// <summary>
		/// Activity.
		/// </summary>
		public Activity Activity {
			get {
				return _activity ??
					(_activity = LookupColumnEntities.GetEntity("Activity") as Activity);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new EmailMetadata_CrtBaseEventsProcess(UserConnection);
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
			return new EmailMetadata(this);
		}

		#endregion

	}

	#endregion

	#region Class: EmailMetadata_CrtBaseEventsProcess

	/// <exclude/>
	public partial class EmailMetadata_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : EmailMetadata
	{

		public EmailMetadata_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "EmailMetadata_CrtBaseEventsProcess";
			SchemaUId = new Guid("1a04fa82-7723-4c4f-86dc-d2196296b90e");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("1a04fa82-7723-4c4f-86dc-d2196296b90e");
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

	#region Class: EmailMetadata_CrtBaseEventsProcess

	/// <exclude/>
	public class EmailMetadata_CrtBaseEventsProcess : EmailMetadata_CrtBaseEventsProcess<EmailMetadata>
	{

		public EmailMetadata_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: EmailMetadata_CrtBaseEventsProcess

	public partial class EmailMetadata_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: EmailMetadataEventsProcess

	/// <exclude/>
	public class EmailMetadataEventsProcess : EmailMetadata_CrtBaseEventsProcess
	{

		public EmailMetadataEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

