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

	#region Class: OAuthAppExtraParamsSchema

	/// <exclude/>
	public class OAuthAppExtraParamsSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public OAuthAppExtraParamsSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OAuthAppExtraParamsSchema(OAuthAppExtraParamsSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OAuthAppExtraParamsSchema(OAuthAppExtraParamsSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("00705b76-7505-4b60-961d-5bb48ced2b3f");
			RealUId = new Guid("00705b76-7505-4b60-961d-5bb48ced2b3f");
			Name = "OAuthAppExtraParams";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("2edbb51e-c9d1-4cf1-8a57-d1ab275de319");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = false;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("88fc4b2c-9775-bcef-1f2e-dee3a95c1b98")) == null) {
				Columns.Add(CreateOAuth20AppColumn());
			}
			if (Columns.FindByUId(new Guid("eb4e985e-09fa-a732-e263-160ae8616b4d")) == null) {
				Columns.Add(CreateValueColumn());
			}
			if (Columns.FindByUId(new Guid("09a52f7b-1bb7-e838-f457-b9c1703db5ea")) == null) {
				Columns.Add(CreateKeyColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateOAuth20AppColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("88fc4b2c-9775-bcef-1f2e-dee3a95c1b98"),
				Name = @"OAuth20App",
				ReferenceSchemaUId = new Guid("2d30ef0a-87fb-474a-a348-a8cb46e23e6e"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("00705b76-7505-4b60-961d-5bb48ced2b3f"),
				ModifiedInSchemaUId = new Guid("00705b76-7505-4b60-961d-5bb48ced2b3f"),
				CreatedInPackageId = new Guid("2edbb51e-c9d1-4cf1-8a57-d1ab275de319"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("eb4e985e-09fa-a732-e263-160ae8616b4d"),
				Name = @"Value",
				CreatedInSchemaUId = new Guid("00705b76-7505-4b60-961d-5bb48ced2b3f"),
				ModifiedInSchemaUId = new Guid("00705b76-7505-4b60-961d-5bb48ced2b3f"),
				CreatedInPackageId = new Guid("2edbb51e-c9d1-4cf1-8a57-d1ab275de319")
			};
		}

		protected virtual EntitySchemaColumn CreateKeyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("09a52f7b-1bb7-e838-f457-b9c1703db5ea"),
				Name = @"Key",
				CreatedInSchemaUId = new Guid("00705b76-7505-4b60-961d-5bb48ced2b3f"),
				ModifiedInSchemaUId = new Guid("00705b76-7505-4b60-961d-5bb48ced2b3f"),
				CreatedInPackageId = new Guid("2edbb51e-c9d1-4cf1-8a57-d1ab275de319")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new OAuthAppExtraParams(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OAuthAppExtraParams_OAuth20IntegrationEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OAuthAppExtraParamsSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OAuthAppExtraParamsSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("00705b76-7505-4b60-961d-5bb48ced2b3f"));
		}

		#endregion

	}

	#endregion

	#region Class: OAuthAppExtraParams

	/// <summary>
	/// Additional parameters.
	/// </summary>
	public class OAuthAppExtraParams : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public OAuthAppExtraParams(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OAuthAppExtraParams";
		}

		public OAuthAppExtraParams(OAuthAppExtraParams source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid OAuth20AppId {
			get {
				return GetTypedColumnValue<Guid>("OAuth20AppId");
			}
			set {
				SetColumnValue("OAuth20AppId", value);
				_oAuth20App = null;
			}
		}

		/// <exclude/>
		public string OAuth20AppName {
			get {
				return GetTypedColumnValue<string>("OAuth20AppName");
			}
			set {
				SetColumnValue("OAuth20AppName", value);
				if (_oAuth20App != null) {
					_oAuth20App.Name = value;
				}
			}
		}

		private OAuthApplications _oAuth20App;
		/// <summary>
		/// OAuth 2.0 application.
		/// </summary>
		public OAuthApplications OAuth20App {
			get {
				return _oAuth20App ??
					(_oAuth20App = LookupColumnEntities.GetEntity("OAuth20App") as OAuthApplications);
			}
		}

		/// <summary>
		/// Value.
		/// </summary>
		public string Value {
			get {
				return GetTypedColumnValue<string>("Value");
			}
			set {
				SetColumnValue("Value", value);
			}
		}

		/// <summary>
		/// Key.
		/// </summary>
		public string Key {
			get {
				return GetTypedColumnValue<string>("Key");
			}
			set {
				SetColumnValue("Key", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OAuthAppExtraParams_OAuth20IntegrationEventsProcess(UserConnection);
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
			return new OAuthAppExtraParams(this);
		}

		#endregion

	}

	#endregion

	#region Class: OAuthAppExtraParams_OAuth20IntegrationEventsProcess

	/// <exclude/>
	public partial class OAuthAppExtraParams_OAuth20IntegrationEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : OAuthAppExtraParams
	{

		public OAuthAppExtraParams_OAuth20IntegrationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OAuthAppExtraParams_OAuth20IntegrationEventsProcess";
			SchemaUId = new Guid("00705b76-7505-4b60-961d-5bb48ced2b3f");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("00705b76-7505-4b60-961d-5bb48ced2b3f");
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

	#region Class: OAuthAppExtraParams_OAuth20IntegrationEventsProcess

	/// <exclude/>
	public class OAuthAppExtraParams_OAuth20IntegrationEventsProcess : OAuthAppExtraParams_OAuth20IntegrationEventsProcess<OAuthAppExtraParams>
	{

		public OAuthAppExtraParams_OAuth20IntegrationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OAuthAppExtraParams_OAuth20IntegrationEventsProcess

	public partial class OAuthAppExtraParams_OAuth20IntegrationEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: OAuthAppExtraParamsEventsProcess

	/// <exclude/>
	public class OAuthAppExtraParamsEventsProcess : OAuthAppExtraParams_OAuth20IntegrationEventsProcess
	{

		public OAuthAppExtraParamsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

