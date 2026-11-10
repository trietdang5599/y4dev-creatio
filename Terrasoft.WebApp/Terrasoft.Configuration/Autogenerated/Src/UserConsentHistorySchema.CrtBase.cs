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

	#region Class: UserConsentHistorySchema

	/// <exclude/>
	public class UserConsentHistorySchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public UserConsentHistorySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public UserConsentHistorySchema(UserConsentHistorySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public UserConsentHistorySchema(UserConsentHistorySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("1672bd75-53f1-4fb0-9c61-0290ab704f7e");
			RealUId = new Guid("1672bd75-53f1-4fb0-9c61-0290ab704f7e");
			Name = "UserConsentHistory";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("95a133a1-cd5f-4df8-af8f-ad440775d7d1");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = false;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("945912b7-967e-7fc8-8a5b-25fbb8dffed3")) == null) {
				Columns.Add(CreateExpirationDateColumn());
			}
			if (Columns.FindByUId(new Guid("ac0e8313-dc05-fb85-b248-d41bd360f3a7")) == null) {
				Columns.Add(CreateConsentCodeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateExpirationDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("945912b7-967e-7fc8-8a5b-25fbb8dffed3"),
				Name = @"ExpirationDate",
				CreatedInSchemaUId = new Guid("1672bd75-53f1-4fb0-9c61-0290ab704f7e"),
				ModifiedInSchemaUId = new Guid("1672bd75-53f1-4fb0-9c61-0290ab704f7e"),
				CreatedInPackageId = new Guid("95a133a1-cd5f-4df8-af8f-ad440775d7d1")
			};
		}

		protected virtual EntitySchemaColumn CreateConsentCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ac0e8313-dc05-fb85-b248-d41bd360f3a7"),
				Name = @"ConsentCode",
				ReferenceSchemaUId = new Guid("cb0bdb95-22b9-4c9f-aea4-3f3e4cafb2d1"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("1672bd75-53f1-4fb0-9c61-0290ab704f7e"),
				ModifiedInSchemaUId = new Guid("1672bd75-53f1-4fb0-9c61-0290ab704f7e"),
				CreatedInPackageId = new Guid("95a133a1-cd5f-4df8-af8f-ad440775d7d1"),
				IsSimpleLookup = true
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new UserConsentHistory(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new UserConsentHistory_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new UserConsentHistorySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new UserConsentHistorySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1672bd75-53f1-4fb0-9c61-0290ab704f7e"));
		}

		#endregion

	}

	#endregion

	#region Class: UserConsentHistory

	/// <summary>
	/// User consent history.
	/// </summary>
	public class UserConsentHistory : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public UserConsentHistory(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "UserConsentHistory";
		}

		public UserConsentHistory(UserConsentHistory source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Consent expiration date.
		/// </summary>
		public DateTime ExpirationDate {
			get {
				return GetTypedColumnValue<DateTime>("ExpirationDate");
			}
			set {
				SetColumnValue("ExpirationDate", value);
			}
		}

		/// <exclude/>
		public Guid ConsentCodeId {
			get {
				return GetTypedColumnValue<Guid>("ConsentCodeId");
			}
			set {
				SetColumnValue("ConsentCodeId", value);
				_consentCode = null;
			}
		}

		/// <exclude/>
		public string ConsentCodeName {
			get {
				return GetTypedColumnValue<string>("ConsentCodeName");
			}
			set {
				SetColumnValue("ConsentCodeName", value);
				if (_consentCode != null) {
					_consentCode.Name = value;
				}
			}
		}

		private Consent _consentCode;
		/// <summary>
		/// Consent code.
		/// </summary>
		public Consent ConsentCode {
			get {
				return _consentCode ??
					(_consentCode = LookupColumnEntities.GetEntity("ConsentCode") as Consent);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new UserConsentHistory_CrtBaseEventsProcess(UserConnection);
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
			return new UserConsentHistory(this);
		}

		#endregion

	}

	#endregion

	#region Class: UserConsentHistory_CrtBaseEventsProcess

	/// <exclude/>
	public partial class UserConsentHistory_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : UserConsentHistory
	{

		public UserConsentHistory_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "UserConsentHistory_CrtBaseEventsProcess";
			SchemaUId = new Guid("1672bd75-53f1-4fb0-9c61-0290ab704f7e");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("1672bd75-53f1-4fb0-9c61-0290ab704f7e");
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

	#region Class: UserConsentHistory_CrtBaseEventsProcess

	/// <exclude/>
	public class UserConsentHistory_CrtBaseEventsProcess : UserConsentHistory_CrtBaseEventsProcess<UserConsentHistory>
	{

		public UserConsentHistory_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: UserConsentHistory_CrtBaseEventsProcess

	public partial class UserConsentHistory_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: UserConsentHistoryEventsProcess

	/// <exclude/>
	public class UserConsentHistoryEventsProcess : UserConsentHistory_CrtBaseEventsProcess
	{

		public UserConsentHistoryEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

