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

	#region Class: SyncErrorMessageSchema

	/// <exclude/>
	public class SyncErrorMessageSchema : Terrasoft.Configuration.BaseCodeLookupSchema
	{

		#region Constructors: Public

		public SyncErrorMessageSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SyncErrorMessageSchema(SyncErrorMessageSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SyncErrorMessageSchema(SyncErrorMessageSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateCodeUniqueIndexIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = true
			};
			index.UId = new Guid("135675fd-5f60-4ba0-ae57-55c4b76c0c81");
			index.Name = "CodeUniqueIndex";
			index.CreatedInSchemaUId = new Guid("ff5ba9c1-ee5d-4485-b6b4-da2865a0508d");
			index.ModifiedInSchemaUId = new Guid("ff5ba9c1-ee5d-4485-b6b4-da2865a0508d");
			index.CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			EntitySchemaIndexColumn codeIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("3b72eaa4-c829-41e7-be16-e3ef17343dd8"),
				ColumnUId = new Guid("13aad544-ec30-4e76-a373-f0cff3202e24"),
				CreatedInSchemaUId = new Guid("ff5ba9c1-ee5d-4485-b6b4-da2865a0508d"),
				ModifiedInSchemaUId = new Guid("ff5ba9c1-ee5d-4485-b6b4-da2865a0508d"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(codeIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ff5ba9c1-ee5d-4485-b6b4-da2865a0508d");
			RealUId = new Guid("ff5ba9c1-ee5d-4485-b6b4-da2865a0508d");
			Name = "SyncErrorMessage";
			ParentSchemaUId = new Guid("2681062b-df59-4e52-89ed-f9b7dc909ab2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
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
			if (Columns.FindByUId(new Guid("575478d3-e07a-449c-80f8-96eaada7ac14")) == null) {
				Columns.Add(CreateUserMessageColumn());
			}
			if (Columns.FindByUId(new Guid("1b4896a3-c6ae-411e-b9cd-551e1529fe3b")) == null) {
				Columns.Add(CreateActionColumn());
			}
		}

		protected override EntitySchemaColumn CreateCodeColumn() {
			EntitySchemaColumn column = base.CreateCodeColumn();
			column.ModifiedInSchemaUId = new Guid("ff5ba9c1-ee5d-4485-b6b4-da2865a0508d");
			return column;
		}

		protected virtual EntitySchemaColumn CreateUserMessageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("575478d3-e07a-449c-80f8-96eaada7ac14"),
				Name = @"UserMessage",
				CreatedInSchemaUId = new Guid("ff5ba9c1-ee5d-4485-b6b4-da2865a0508d"),
				ModifiedInSchemaUId = new Guid("ff5ba9c1-ee5d-4485-b6b4-da2865a0508d"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateActionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("1b4896a3-c6ae-411e-b9cd-551e1529fe3b"),
				Name = @"Action",
				CreatedInSchemaUId = new Guid("ff5ba9c1-ee5d-4485-b6b4-da2865a0508d"),
				ModifiedInSchemaUId = new Guid("ff5ba9c1-ee5d-4485-b6b4-da2865a0508d"),
				CreatedInPackageId = new Guid("7e406f3f-0514-4d14-a20b-c3a59a45194f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateCodeUniqueIndexIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SyncErrorMessage(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SyncErrorMessage_CrtCoreBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SyncErrorMessageSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SyncErrorMessageSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ff5ba9c1-ee5d-4485-b6b4-da2865a0508d"));
		}

		#endregion

	}

	#endregion

	#region Class: SyncErrorMessage

	/// <summary>
	/// Synchronization error messages.
	/// </summary>
	public class SyncErrorMessage : Terrasoft.Configuration.BaseCodeLookup
	{

		#region Constructors: Public

		public SyncErrorMessage(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SyncErrorMessage";
		}

		public SyncErrorMessage(SyncErrorMessage source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// User message.
		/// </summary>
		public string UserMessage {
			get {
				return GetTypedColumnValue<string>("UserMessage");
			}
			set {
				SetColumnValue("UserMessage", value);
			}
		}

		/// <summary>
		/// Action.
		/// </summary>
		public string Action {
			get {
				return GetTypedColumnValue<string>("Action");
			}
			set {
				SetColumnValue("Action", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SyncErrorMessage_CrtCoreBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SyncErrorMessageDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SyncErrorMessage(this);
		}

		#endregion

	}

	#endregion

	#region Class: SyncErrorMessage_CrtCoreBaseEventsProcess

	/// <exclude/>
	public partial class SyncErrorMessage_CrtCoreBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseCodeLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : SyncErrorMessage
	{

		public SyncErrorMessage_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SyncErrorMessage_CrtCoreBaseEventsProcess";
			SchemaUId = new Guid("ff5ba9c1-ee5d-4485-b6b4-da2865a0508d");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ff5ba9c1-ee5d-4485-b6b4-da2865a0508d");
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

	#region Class: SyncErrorMessage_CrtCoreBaseEventsProcess

	/// <exclude/>
	public class SyncErrorMessage_CrtCoreBaseEventsProcess : SyncErrorMessage_CrtCoreBaseEventsProcess<SyncErrorMessage>
	{

		public SyncErrorMessage_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SyncErrorMessage_CrtCoreBaseEventsProcess

	public partial class SyncErrorMessage_CrtCoreBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SyncErrorMessageEventsProcess

	/// <exclude/>
	public class SyncErrorMessageEventsProcess : SyncErrorMessage_CrtCoreBaseEventsProcess
	{

		public SyncErrorMessageEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

