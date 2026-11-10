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

	#region Class: RedirectUrlInOAuthClientAppSchema

	/// <exclude/>
	public class RedirectUrlInOAuthClientAppSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public RedirectUrlInOAuthClientAppSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public RedirectUrlInOAuthClientAppSchema(RedirectUrlInOAuthClientAppSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public RedirectUrlInOAuthClientAppSchema(RedirectUrlInOAuthClientAppSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateUniquePairIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = true
			};
			index.UId = new Guid("7a96705b-a140-49b1-846e-a445c27da992");
			index.Name = "UniquePair";
			index.CreatedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			index.ModifiedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			index.CreatedInPackageId = new Guid("49af2168-effb-4b7f-bce2-28e45d430d96");
			EntitySchemaIndexColumn redirectUrlIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("478ae6dc-5e11-fbd7-e96a-22c6a1ddaa72"),
				ColumnUId = new Guid("d66875df-5ae8-d22f-b339-0c09f67cad99"),
				CreatedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				ModifiedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				CreatedInPackageId = new Guid("49af2168-effb-4b7f-bce2-28e45d430d96"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(redirectUrlIndexColumn);
			EntitySchemaIndexColumn oAuthClientAppIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("64d56ea5-c292-c2cd-74ea-372f7cf079d8"),
				ColumnUId = new Guid("53d08ec2-8806-5df1-daea-2e93e32304f5"),
				CreatedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				ModifiedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				CreatedInPackageId = new Guid("49af2168-effb-4b7f-bce2-28e45d430d96"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(oAuthClientAppIdIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("8261de4d-5576-4b48-ad3e-c67de0ec2a65");
			RealUId = new Guid("8261de4d-5576-4b48-ad3e-c67de0ec2a65");
			Name = "RedirectUrlInOAuthClientApp";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("49af2168-effb-4b7f-bce2-28e45d430d96");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("d66875df-5ae8-d22f-b339-0c09f67cad99")) == null) {
				Columns.Add(CreateRedirectUrlColumn());
			}
			if (Columns.FindByUId(new Guid("53d08ec2-8806-5df1-daea-2e93e32304f5")) == null) {
				Columns.Add(CreateOAuthClientAppColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateRedirectUrlColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("WebText")) {
				UId = new Guid("d66875df-5ae8-d22f-b339-0c09f67cad99"),
				Name = @"RedirectUrl",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("8261de4d-5576-4b48-ad3e-c67de0ec2a65"),
				ModifiedInSchemaUId = new Guid("8261de4d-5576-4b48-ad3e-c67de0ec2a65"),
				CreatedInPackageId = new Guid("49af2168-effb-4b7f-bce2-28e45d430d96")
			};
		}

		protected virtual EntitySchemaColumn CreateOAuthClientAppColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("53d08ec2-8806-5df1-daea-2e93e32304f5"),
				Name = @"OAuthClientApp",
				ReferenceSchemaUId = new Guid("2372e343-8d09-4fc4-a1ca-b7f708eaafed"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("8261de4d-5576-4b48-ad3e-c67de0ec2a65"),
				ModifiedInSchemaUId = new Guid("8261de4d-5576-4b48-ad3e-c67de0ec2a65"),
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
			Indexes.Add(CreateUniquePairIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new RedirectUrlInOAuthClientApp(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new RedirectUrlInOAuthClientApp_OAuth20EventsProcess(userConnection);
		}

		public override object Clone() {
			return new RedirectUrlInOAuthClientAppSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new RedirectUrlInOAuthClientAppSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("8261de4d-5576-4b48-ad3e-c67de0ec2a65"));
		}

		#endregion

	}

	#endregion

	#region Class: RedirectUrlInOAuthClientApp

	/// <summary>
	/// Authorized redirect URIs of OAuth integration .
	/// </summary>
	public class RedirectUrlInOAuthClientApp : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public RedirectUrlInOAuthClientApp(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "RedirectUrlInOAuthClientApp";
		}

		public RedirectUrlInOAuthClientApp(RedirectUrlInOAuthClientApp source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Redirect URI.
		/// </summary>
		public string RedirectUrl {
			get {
				return GetTypedColumnValue<string>("RedirectUrl");
			}
			set {
				SetColumnValue("RedirectUrl", value);
			}
		}

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
		/// OAuth client application.
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
			var process = new RedirectUrlInOAuthClientApp_OAuth20EventsProcess(UserConnection);
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
			return new RedirectUrlInOAuthClientApp(this);
		}

		#endregion

	}

	#endregion

	#region Class: RedirectUrlInOAuthClientApp_OAuth20EventsProcess

	/// <exclude/>
	public partial class RedirectUrlInOAuthClientApp_OAuth20EventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : RedirectUrlInOAuthClientApp
	{

		public RedirectUrlInOAuthClientApp_OAuth20EventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "RedirectUrlInOAuthClientApp_OAuth20EventsProcess";
			SchemaUId = new Guid("8261de4d-5576-4b48-ad3e-c67de0ec2a65");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("8261de4d-5576-4b48-ad3e-c67de0ec2a65");
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

	#region Class: RedirectUrlInOAuthClientApp_OAuth20EventsProcess

	/// <exclude/>
	public class RedirectUrlInOAuthClientApp_OAuth20EventsProcess : RedirectUrlInOAuthClientApp_OAuth20EventsProcess<RedirectUrlInOAuthClientApp>
	{

		public RedirectUrlInOAuthClientApp_OAuth20EventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: RedirectUrlInOAuthClientApp_OAuth20EventsProcess

	public partial class RedirectUrlInOAuthClientApp_OAuth20EventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: RedirectUrlInOAuthClientAppEventsProcess

	/// <exclude/>
	public class RedirectUrlInOAuthClientAppEventsProcess : RedirectUrlInOAuthClientApp_OAuth20EventsProcess
	{

		public RedirectUrlInOAuthClientAppEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

