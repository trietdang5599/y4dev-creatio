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

	#region Class: AccessControlWhitelistSchema

	/// <exclude/>
	public class AccessControlWhitelistSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public AccessControlWhitelistSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public AccessControlWhitelistSchema(AccessControlWhitelistSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public AccessControlWhitelistSchema(AccessControlWhitelistSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7ee28945-5f73-43da-96f1-10664573cc0e");
			RealUId = new Guid("7ee28945-5f73-43da-96f1-10664573cc0e");
			Name = "AccessControlWhitelist";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("be64f413-e46e-44a8-8668-e024a58440fd");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = false;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("63c73dc6-01b8-a691-07af-497374e90181")) == null) {
				Columns.Add(CreatePageColumn());
			}
		}

		protected virtual EntitySchemaColumn CreatePageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("63c73dc6-01b8-a691-07af-497374e90181"),
				Name = @"Page",
				ReferenceSchemaUId = new Guid("90fa6d02-3e93-45d6-a72b-58dcffa411ae"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				IsIndexed = true,
				IsWeakReference = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("7ee28945-5f73-43da-96f1-10664573cc0e"),
				ModifiedInSchemaUId = new Guid("7ee28945-5f73-43da-96f1-10664573cc0e"),
				CreatedInPackageId = new Guid("be64f413-e46e-44a8-8668-e024a58440fd")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new AccessControlWhitelist(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new AccessControlWhitelist_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new AccessControlWhitelistSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new AccessControlWhitelistSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7ee28945-5f73-43da-96f1-10664573cc0e"));
		}

		#endregion

	}

	#endregion

	#region Class: AccessControlWhitelist

	/// <summary>
	/// AccessControlWhitelist.
	/// </summary>
	public class AccessControlWhitelist : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public AccessControlWhitelist(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "AccessControlWhitelist";
		}

		public AccessControlWhitelist(AccessControlWhitelist source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid PageId {
			get {
				return GetTypedColumnValue<Guid>("PageId");
			}
			set {
				SetColumnValue("PageId", value);
				_page = null;
			}
		}

		/// <exclude/>
		public string PageCaption {
			get {
				return GetTypedColumnValue<string>("PageCaption");
			}
			set {
				SetColumnValue("PageCaption", value);
				if (_page != null) {
					_page.Caption = value;
				}
			}
		}

		private VwSysSchemaInfo _page;
		/// <summary>
		/// Page.
		/// </summary>
		/// <remarks>
		/// Allowed page.
		/// </remarks>
		public VwSysSchemaInfo Page {
			get {
				return _page ??
					(_page = LookupColumnEntities.GetEntity("Page") as VwSysSchemaInfo);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new AccessControlWhitelist_CrtBaseEventsProcess(UserConnection);
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
			return new AccessControlWhitelist(this);
		}

		#endregion

	}

	#endregion

	#region Class: AccessControlWhitelist_CrtBaseEventsProcess

	/// <exclude/>
	public partial class AccessControlWhitelist_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : AccessControlWhitelist
	{

		public AccessControlWhitelist_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "AccessControlWhitelist_CrtBaseEventsProcess";
			SchemaUId = new Guid("7ee28945-5f73-43da-96f1-10664573cc0e");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("7ee28945-5f73-43da-96f1-10664573cc0e");
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

	#region Class: AccessControlWhitelist_CrtBaseEventsProcess

	/// <exclude/>
	public class AccessControlWhitelist_CrtBaseEventsProcess : AccessControlWhitelist_CrtBaseEventsProcess<AccessControlWhitelist>
	{

		public AccessControlWhitelist_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: AccessControlWhitelist_CrtBaseEventsProcess

	public partial class AccessControlWhitelist_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: AccessControlWhitelistEventsProcess

	/// <exclude/>
	public class AccessControlWhitelistEventsProcess : AccessControlWhitelist_CrtBaseEventsProcess
	{

		public AccessControlWhitelistEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

