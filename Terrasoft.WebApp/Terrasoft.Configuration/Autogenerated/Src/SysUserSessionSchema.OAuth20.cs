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

	#region Class: SysUserSessionSchema

	/// <exclude/>
	public class SysUserSessionSchema : Terrasoft.Configuration.SysUserSession_ExternalAccess_CreatioSchema
	{

		#region Constructors: Public

		public SysUserSessionSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysUserSessionSchema(SysUserSessionSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysUserSessionSchema(SysUserSessionSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateISysUserSessEndDateIdIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("97fc6e87-0eac-4738-a3a0-cded3ee2affe");
			index.Name = "ISysUserSessEndDateId";
			index.CreatedInSchemaUId = new Guid("43e6cdb7-e6fd-4218-bd45-278a1ce03339");
			index.ModifiedInSchemaUId = new Guid("43e6cdb7-e6fd-4218-bd45-278a1ce03339");
			index.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			EntitySchemaIndexColumn sessionEndDateIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("99d28ef5-8120-4605-a15c-a47bf3268905"),
				ColumnUId = new Guid("86a0a1f4-7d2d-45da-b313-8f96c983215c"),
				CreatedInSchemaUId = Guid.Empty,
				ModifiedInSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(sessionEndDateIndexColumn);
			EntitySchemaIndexColumn sessionIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("97d387d1-2969-4331-8bd8-cc9cac20c9c7"),
				ColumnUId = new Guid("f443b1a3-3c1c-4a25-8add-b3255ea19099"),
				CreatedInSchemaUId = Guid.Empty,
				ModifiedInSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(sessionIdIndexColumn);
			return index;
		}

		private EntitySchemaIndex CreateISysUserSessionUserIdIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("e1f2730f-03f5-4526-acf1-cd929fdbb3a0");
			index.Name = "ISysUserSessionUserId";
			index.CreatedInSchemaUId = new Guid("43e6cdb7-e6fd-4218-bd45-278a1ce03339");
			index.ModifiedInSchemaUId = new Guid("43e6cdb7-e6fd-4218-bd45-278a1ce03339");
			index.CreatedInPackageId = new Guid("6ff020f5-e34d-4da9-8c0d-3678e6f20dbf");
			EntitySchemaIndexColumn sysUserIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("cdda2024-8137-4a11-ad6f-11d702d8a8f6"),
				ColumnUId = new Guid("61b6df7e-99db-458f-980d-68308d2dd08c"),
				CreatedInSchemaUId = new Guid("43e6cdb7-e6fd-4218-bd45-278a1ce03339"),
				ModifiedInSchemaUId = new Guid("43e6cdb7-e6fd-4218-bd45-278a1ce03339"),
				CreatedInPackageId = new Guid("6ff020f5-e34d-4da9-8c0d-3678e6f20dbf"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(sysUserIdIndexColumn);
			EntitySchemaIndexColumn sessionEndDateIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("ffcfaa0a-d163-4978-bf5d-73a7e781472a"),
				ColumnUId = new Guid("86a0a1f4-7d2d-45da-b313-8f96c983215c"),
				CreatedInSchemaUId = new Guid("43e6cdb7-e6fd-4218-bd45-278a1ce03339"),
				ModifiedInSchemaUId = new Guid("43e6cdb7-e6fd-4218-bd45-278a1ce03339"),
				CreatedInPackageId = new Guid("6ff020f5-e34d-4da9-8c0d-3678e6f20dbf"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(sessionEndDateIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("545794e2-fbb1-49e2-b564-272f231d6b26");
			Name = "SysUserSession";
			ParentSchemaUId = new Guid("43e6cdb7-e6fd-4218-bd45-278a1ce03339");
			ExtendParent = true;
			CreatedInPackageId = new Guid("49af2168-effb-4b7f-bce2-28e45d430d96");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = false;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("b91b0bdd-4639-e7d5-d107-7581640cab30")) == null) {
				Columns.Add(CreateOAuthClientAppColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateOAuthClientAppColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("b91b0bdd-4639-e7d5-d107-7581640cab30"),
				Name = @"OAuthClientApp",
				ReferenceSchemaUId = new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed"),
				IsValueCloneable = false,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("545794e2-fbb1-49e2-b564-272f231d6b26"),
				ModifiedInSchemaUId = new Guid("545794e2-fbb1-49e2-b564-272f231d6b26"),
				CreatedInPackageId = new Guid("49af2168-effb-4b7f-bce2-28e45d430d96"),
				IsSimpleLookup = true
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateISysUserSessEndDateIdIndex());
			Indexes.Add(CreateISysUserSessionUserIdIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysUserSession(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysUserSession_OAuth20EventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysUserSessionSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysUserSessionSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("545794e2-fbb1-49e2-b564-272f231d6b26"));
		}

		#endregion

	}

	#endregion

	#region Class: SysUserSession

	/// <summary>
	/// User session.
	/// </summary>
	public class SysUserSession : Terrasoft.Configuration.SysUserSession_ExternalAccess_Creatio
	{

		#region Constructors: Public

		public SysUserSession(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysUserSession";
		}

		public SysUserSession(SysUserSession source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid OAuthClientAppId {
			get {
				return GetTypedColumnValue<Guid>("OAuthClientAppId");
			}
			set {
				SetColumnValue("OAuthClientAppId", value);
				_oAuthClientApp = null;
			}
		}

		/// <exclude/>
		public string OAuthClientAppName {
			get {
				return GetTypedColumnValue<string>("OAuthClientAppName");
			}
			set {
				SetColumnValue("OAuthClientAppName", value);
				if (_oAuthClientApp != null) {
					_oAuthClientApp.Name = value;
				}
			}
		}

		private OAuthClientApp _oAuthClientApp;
		/// <summary>
		/// External application.
		/// </summary>
		public OAuthClientApp OAuthClientApp {
			get {
				return _oAuthClientApp ??
					(_oAuthClientApp = LookupColumnEntities.GetEntity("OAuthClientApp") as OAuthClientApp);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysUserSession_OAuth20EventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysUserSessionDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysUserSessionDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysUserSessionInserted", e);
			Inserting += (s, e) => ThrowEvent("SysUserSessionInserting", e);
			Saved += (s, e) => ThrowEvent("SysUserSessionSaved", e);
			Saving += (s, e) => ThrowEvent("SysUserSessionSaving", e);
			Validating += (s, e) => ThrowEvent("SysUserSessionValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysUserSession(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysUserSession_OAuth20EventsProcess

	/// <exclude/>
	public partial class SysUserSession_OAuth20EventsProcess<TEntity> : Terrasoft.Configuration.SysUserSession_ExternalAccessEventsProcess<TEntity> where TEntity : SysUserSession
	{

		public SysUserSession_OAuth20EventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysUserSession_OAuth20EventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("545794e2-fbb1-49e2-b564-272f231d6b26");
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

	#region Class: SysUserSession_OAuth20EventsProcess

	/// <exclude/>
	public class SysUserSession_OAuth20EventsProcess : SysUserSession_OAuth20EventsProcess<SysUserSession>
	{

		public SysUserSession_OAuth20EventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysUserSession_OAuth20EventsProcess

	public partial class SysUserSession_OAuth20EventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysUserSessionEventsProcess

	/// <exclude/>
	public class SysUserSessionEventsProcess : SysUserSession_OAuth20EventsProcess
	{

		public SysUserSessionEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

