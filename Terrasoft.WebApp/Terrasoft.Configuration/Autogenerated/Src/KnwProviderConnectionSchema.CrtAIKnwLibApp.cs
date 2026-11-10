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

	#region Class: KnwProviderConnectionSchema

	/// <exclude/>
	public class KnwProviderConnectionSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public KnwProviderConnectionSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public KnwProviderConnectionSchema(KnwProviderConnectionSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public KnwProviderConnectionSchema(KnwProviderConnectionSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b081050d-8817-4d00-87c5-9c26c5c4fff6");
			RealUId = new Guid("b081050d-8817-4d00-87c5-9c26c5c4fff6");
			Name = "KnwProviderConnection";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("0f5fed43-399b-4ea4-b68d-ee5a1a9b0d5a");
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
			if (Columns.FindByUId(new Guid("6063d8cd-021e-1aa9-91b7-15caa50f5d32")) == null) {
				Columns.Add(CreateKnwProviderColumn());
			}
			if (Columns.FindByUId(new Guid("7f77b6e5-a193-7493-23a6-ed51476ef4da")) == null) {
				Columns.Add(CreateConnectionParamsColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateKnwProviderColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("6063d8cd-021e-1aa9-91b7-15caa50f5d32"),
				Name = @"KnwProvider",
				ReferenceSchemaUId = new Guid("51aed477-551c-4521-9a27-e296dea692c4"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("b081050d-8817-4d00-87c5-9c26c5c4fff6"),
				ModifiedInSchemaUId = new Guid("b081050d-8817-4d00-87c5-9c26c5c4fff6"),
				CreatedInPackageId = new Guid("0f5fed43-399b-4ea4-b68d-ee5a1a9b0d5a"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateConnectionParamsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("SecureText")) {
				UId = new Guid("7f77b6e5-a193-7493-23a6-ed51476ef4da"),
				Name = @"ConnectionParams",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("b081050d-8817-4d00-87c5-9c26c5c4fff6"),
				ModifiedInSchemaUId = new Guid("b081050d-8817-4d00-87c5-9c26c5c4fff6"),
				CreatedInPackageId = new Guid("4b4f6d9f-1234-44a2-bd3b-b64923d93c0c")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new KnwProviderConnection(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new KnwProviderConnection_CrtAIKnwLibAppEventsProcess(userConnection);
		}

		public override object Clone() {
			return new KnwProviderConnectionSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new KnwProviderConnectionSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b081050d-8817-4d00-87c5-9c26c5c4fff6"));
		}

		#endregion

	}

	#endregion

	#region Class: KnwProviderConnection

	/// <summary>
	/// Knowledge provider connection.
	/// </summary>
	public class KnwProviderConnection : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public KnwProviderConnection(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "KnwProviderConnection";
		}

		public KnwProviderConnection(KnwProviderConnection source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid KnwProviderId {
			get {
				return GetTypedColumnValue<Guid>("KnwProviderId");
			}
			set {
				SetColumnValue("KnwProviderId", value);
				_knwProvider = null;
			}
		}

		/// <exclude/>
		public string KnwProviderName {
			get {
				return GetTypedColumnValue<string>("KnwProviderName");
			}
			set {
				SetColumnValue("KnwProviderName", value);
				if (_knwProvider != null) {
					_knwProvider.Name = value;
				}
			}
		}

		private KnwProvider _knwProvider;
		/// <summary>
		/// KnowledgeProvider.
		/// </summary>
		public KnwProvider KnwProvider {
			get {
				return _knwProvider ??
					(_knwProvider = LookupColumnEntities.GetEntity("KnwProvider") as KnwProvider);
			}
		}

		/// <summary>
		/// ConnectionParams.
		/// </summary>
		public string ConnectionParams {
			get {
				return GetTypedColumnValue<string>("ConnectionParams");
			}
			set {
				SetColumnValue("ConnectionParams", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new KnwProviderConnection_CrtAIKnwLibAppEventsProcess(UserConnection);
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
			return new KnwProviderConnection(this);
		}

		#endregion

	}

	#endregion

	#region Class: KnwProviderConnection_CrtAIKnwLibAppEventsProcess

	/// <exclude/>
	public partial class KnwProviderConnection_CrtAIKnwLibAppEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : KnwProviderConnection
	{

		public KnwProviderConnection_CrtAIKnwLibAppEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "KnwProviderConnection_CrtAIKnwLibAppEventsProcess";
			SchemaUId = new Guid("b081050d-8817-4d00-87c5-9c26c5c4fff6");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("b081050d-8817-4d00-87c5-9c26c5c4fff6");
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

	#region Class: KnwProviderConnection_CrtAIKnwLibAppEventsProcess

	/// <exclude/>
	public class KnwProviderConnection_CrtAIKnwLibAppEventsProcess : KnwProviderConnection_CrtAIKnwLibAppEventsProcess<KnwProviderConnection>
	{

		public KnwProviderConnection_CrtAIKnwLibAppEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: KnwProviderConnection_CrtAIKnwLibAppEventsProcess

	public partial class KnwProviderConnection_CrtAIKnwLibAppEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: KnwProviderConnectionEventsProcess

	/// <exclude/>
	public class KnwProviderConnectionEventsProcess : KnwProviderConnection_CrtAIKnwLibAppEventsProcess
	{

		public KnwProviderConnectionEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

