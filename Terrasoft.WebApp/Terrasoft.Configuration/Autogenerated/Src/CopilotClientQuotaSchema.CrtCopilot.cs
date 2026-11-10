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

	#region Class: CopilotClientQuotaSchema

	/// <exclude/>
	[IsVirtual]
	public class CopilotClientQuotaSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public CopilotClientQuotaSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CopilotClientQuotaSchema(CopilotClientQuotaSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CopilotClientQuotaSchema(CopilotClientQuotaSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("1b315f42-07f6-47f9-9f36-aaebfe7356f7");
			RealUId = new Guid("1b315f42-07f6-47f9-9f36-aaebfe7356f7");
			Name = "CopilotClientQuota";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("800f00c8-04db-4ed1-bc94-0c44b7e5e4f0");
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
			if (Columns.FindByUId(new Guid("3e9a0c2f-db32-f640-c68c-acdca33f7160")) == null) {
				Columns.Add(CreateTokensLimitColumn());
			}
			if (Columns.FindByUId(new Guid("11592ca4-5beb-9286-4e78-3ef6e87eb2dd")) == null) {
				Columns.Add(CreateTokensUsageColumn());
			}
			if (Columns.FindByUId(new Guid("46298216-58b1-6f16-ff68-e007305e2655")) == null) {
				Columns.Add(CreateTokensAvailableColumn());
			}
			if (Columns.FindByUId(new Guid("a0c25f2e-7e3d-6038-51b7-e31a51c9b867")) == null) {
				Columns.Add(CreateActionsUsageColumn());
			}
			if (Columns.FindByUId(new Guid("b14c067f-5299-2b51-9baf-ce9bc552b26b")) == null) {
				Columns.Add(CreateActionsLimitColumn());
			}
			if (Columns.FindByUId(new Guid("f68bf44c-952d-b531-76f8-7bf01f323960")) == null) {
				Columns.Add(CreateActionsAvailableColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateTokensLimitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("3e9a0c2f-db32-f640-c68c-acdca33f7160"),
				Name = @"TokensLimit",
				CreatedInSchemaUId = new Guid("1b315f42-07f6-47f9-9f36-aaebfe7356f7"),
				ModifiedInSchemaUId = new Guid("1b315f42-07f6-47f9-9f36-aaebfe7356f7"),
				CreatedInPackageId = new Guid("800f00c8-04db-4ed1-bc94-0c44b7e5e4f0")
			};
		}

		protected virtual EntitySchemaColumn CreateTokensUsageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("11592ca4-5beb-9286-4e78-3ef6e87eb2dd"),
				Name = @"TokensUsage",
				CreatedInSchemaUId = new Guid("1b315f42-07f6-47f9-9f36-aaebfe7356f7"),
				ModifiedInSchemaUId = new Guid("1b315f42-07f6-47f9-9f36-aaebfe7356f7"),
				CreatedInPackageId = new Guid("800f00c8-04db-4ed1-bc94-0c44b7e5e4f0")
			};
		}

		protected virtual EntitySchemaColumn CreateTokensAvailableColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("46298216-58b1-6f16-ff68-e007305e2655"),
				Name = @"TokensAvailable",
				CreatedInSchemaUId = new Guid("1b315f42-07f6-47f9-9f36-aaebfe7356f7"),
				ModifiedInSchemaUId = new Guid("1b315f42-07f6-47f9-9f36-aaebfe7356f7"),
				CreatedInPackageId = new Guid("800f00c8-04db-4ed1-bc94-0c44b7e5e4f0")
			};
		}

		protected virtual EntitySchemaColumn CreateActionsUsageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("a0c25f2e-7e3d-6038-51b7-e31a51c9b867"),
				Name = @"ActionsUsage",
				CreatedInSchemaUId = new Guid("1b315f42-07f6-47f9-9f36-aaebfe7356f7"),
				ModifiedInSchemaUId = new Guid("1b315f42-07f6-47f9-9f36-aaebfe7356f7"),
				CreatedInPackageId = new Guid("c23dfaf0-0051-4966-86f8-cbe8197258d0")
			};
		}

		protected virtual EntitySchemaColumn CreateActionsLimitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("b14c067f-5299-2b51-9baf-ce9bc552b26b"),
				Name = @"ActionsLimit",
				CreatedInSchemaUId = new Guid("1b315f42-07f6-47f9-9f36-aaebfe7356f7"),
				ModifiedInSchemaUId = new Guid("1b315f42-07f6-47f9-9f36-aaebfe7356f7"),
				CreatedInPackageId = new Guid("c23dfaf0-0051-4966-86f8-cbe8197258d0")
			};
		}

		protected virtual EntitySchemaColumn CreateActionsAvailableColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("f68bf44c-952d-b531-76f8-7bf01f323960"),
				Name = @"ActionsAvailable",
				CreatedInSchemaUId = new Guid("1b315f42-07f6-47f9-9f36-aaebfe7356f7"),
				ModifiedInSchemaUId = new Guid("1b315f42-07f6-47f9-9f36-aaebfe7356f7"),
				CreatedInPackageId = new Guid("c23dfaf0-0051-4966-86f8-cbe8197258d0")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new CopilotClientQuota(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CopilotClientQuota_CrtCopilotEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CopilotClientQuotaSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CopilotClientQuotaSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1b315f42-07f6-47f9-9f36-aaebfe7356f7"));
		}

		#endregion

	}

	#endregion

	#region Class: CopilotClientQuota

	/// <summary>
	/// Creatio.ai Client Quota.
	/// </summary>
	/// <remarks>
	/// The usage and limit for client.
	/// </remarks>
	public class CopilotClientQuota : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public CopilotClientQuota(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CopilotClientQuota";
		}

		public CopilotClientQuota(CopilotClientQuota source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Tokens Limit.
		/// </summary>
		/// <remarks>
		/// The maximum number of allocated tokens.
		/// </remarks>
		public int TokensLimit {
			get {
				return GetTypedColumnValue<int>("TokensLimit");
			}
			set {
				SetColumnValue("TokensLimit", value);
			}
		}

		/// <summary>
		/// Tokens Usage.
		/// </summary>
		/// <remarks>
		/// The number of client tokens used.
		/// </remarks>
		public int TokensUsage {
			get {
				return GetTypedColumnValue<int>("TokensUsage");
			}
			set {
				SetColumnValue("TokensUsage", value);
			}
		}

		/// <summary>
		/// Tokens available.
		/// </summary>
		/// <remarks>
		/// The remaining number of available tokens.
		/// </remarks>
		public int TokensAvailable {
			get {
				return GetTypedColumnValue<int>("TokensAvailable");
			}
			set {
				SetColumnValue("TokensAvailable", value);
			}
		}

		/// <summary>
		/// Actions Usage.
		/// </summary>
		/// <remarks>
		/// The number of client actions used.
		/// </remarks>
		public int ActionsUsage {
			get {
				return GetTypedColumnValue<int>("ActionsUsage");
			}
			set {
				SetColumnValue("ActionsUsage", value);
			}
		}

		/// <summary>
		/// Actions Limit.
		/// </summary>
		/// <remarks>
		/// The maximum number of allocated actions.
		/// </remarks>
		public int ActionsLimit {
			get {
				return GetTypedColumnValue<int>("ActionsLimit");
			}
			set {
				SetColumnValue("ActionsLimit", value);
			}
		}

		/// <summary>
		/// Actions available.
		/// </summary>
		/// <remarks>
		/// The remaining number of available actions.
		/// </remarks>
		public int ActionsAvailable {
			get {
				return GetTypedColumnValue<int>("ActionsAvailable");
			}
			set {
				SetColumnValue("ActionsAvailable", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CopilotClientQuota_CrtCopilotEventsProcess(UserConnection);
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
			return new CopilotClientQuota(this);
		}

		#endregion

	}

	#endregion

	#region Class: CopilotClientQuota_CrtCopilotEventsProcess

	/// <exclude/>
	public partial class CopilotClientQuota_CrtCopilotEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : CopilotClientQuota
	{

		public CopilotClientQuota_CrtCopilotEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CopilotClientQuota_CrtCopilotEventsProcess";
			SchemaUId = new Guid("1b315f42-07f6-47f9-9f36-aaebfe7356f7");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("1b315f42-07f6-47f9-9f36-aaebfe7356f7");
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

	#region Class: CopilotClientQuota_CrtCopilotEventsProcess

	/// <exclude/>
	public class CopilotClientQuota_CrtCopilotEventsProcess : CopilotClientQuota_CrtCopilotEventsProcess<CopilotClientQuota>
	{

		public CopilotClientQuota_CrtCopilotEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CopilotClientQuota_CrtCopilotEventsProcess

	public partial class CopilotClientQuota_CrtCopilotEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CopilotClientQuotaEventsProcess

	/// <exclude/>
	public class CopilotClientQuotaEventsProcess : CopilotClientQuota_CrtCopilotEventsProcess
	{

		public CopilotClientQuotaEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

