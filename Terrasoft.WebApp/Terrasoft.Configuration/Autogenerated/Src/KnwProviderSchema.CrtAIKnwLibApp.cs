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

	#region Class: KnwProviderSchema

	/// <exclude/>
	public class KnwProviderSchema : Terrasoft.Configuration.BaseCodeLookupSchema
	{

		#region Constructors: Public

		public KnwProviderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public KnwProviderSchema(KnwProviderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public KnwProviderSchema(KnwProviderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("51aed477-551c-4521-9a27-e296dea692c4");
			RealUId = new Guid("51aed477-551c-4521-9a27-e296dea692c4");
			Name = "KnwProvider";
			ParentSchemaUId = new Guid("2681062b-df59-4e52-89ed-f9b7dc909ab2");
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
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new KnwProvider(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new KnwProvider_CrtAIKnwLibAppEventsProcess(userConnection);
		}

		public override object Clone() {
			return new KnwProviderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new KnwProviderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("51aed477-551c-4521-9a27-e296dea692c4"));
		}

		#endregion

	}

	#endregion

	#region Class: KnwProvider

	/// <summary>
	/// Knowledge provider.
	/// </summary>
	public class KnwProvider : Terrasoft.Configuration.BaseCodeLookup
	{

		#region Constructors: Public

		public KnwProvider(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "KnwProvider";
		}

		public KnwProvider(KnwProvider source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new KnwProvider_CrtAIKnwLibAppEventsProcess(UserConnection);
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
			return new KnwProvider(this);
		}

		#endregion

	}

	#endregion

	#region Class: KnwProvider_CrtAIKnwLibAppEventsProcess

	/// <exclude/>
	public partial class KnwProvider_CrtAIKnwLibAppEventsProcess<TEntity> : Terrasoft.Configuration.BaseCodeLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : KnwProvider
	{

		public KnwProvider_CrtAIKnwLibAppEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "KnwProvider_CrtAIKnwLibAppEventsProcess";
			SchemaUId = new Guid("51aed477-551c-4521-9a27-e296dea692c4");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("51aed477-551c-4521-9a27-e296dea692c4");
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

	#region Class: KnwProvider_CrtAIKnwLibAppEventsProcess

	/// <exclude/>
	public class KnwProvider_CrtAIKnwLibAppEventsProcess : KnwProvider_CrtAIKnwLibAppEventsProcess<KnwProvider>
	{

		public KnwProvider_CrtAIKnwLibAppEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: KnwProvider_CrtAIKnwLibAppEventsProcess

	public partial class KnwProvider_CrtAIKnwLibAppEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: KnwProviderEventsProcess

	/// <exclude/>
	public class KnwProviderEventsProcess : KnwProvider_CrtAIKnwLibAppEventsProcess
	{

		public KnwProviderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

