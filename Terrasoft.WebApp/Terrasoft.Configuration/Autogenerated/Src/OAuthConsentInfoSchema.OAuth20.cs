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

	#region Class: OAuthConsentInfoSchema

	/// <exclude/>
	public class OAuthConsentInfoSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public OAuthConsentInfoSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OAuthConsentInfoSchema(OAuthConsentInfoSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OAuthConsentInfoSchema(OAuthConsentInfoSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("54a1dccb-9f6d-4a75-b619-9fb91f42c44c");
			RealUId = new Guid("54a1dccb-9f6d-4a75-b619-9fb91f42c44c");
			Name = "OAuthConsentInfo";
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
			if (Columns.FindByUId(new Guid("bb24a325-98b5-3cdb-90ea-48f7f4553f8c")) == null) {
				Columns.Add(CreateTTLColumn());
			}
			if (Columns.FindByUId(new Guid("adf24246-89fb-496d-f180-e450642f8878")) == null) {
				Columns.Add(CreateConsentDataColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateTTLColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("bb24a325-98b5-3cdb-90ea-48f7f4553f8c"),
				Name = @"TTL",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("54a1dccb-9f6d-4a75-b619-9fb91f42c44c"),
				ModifiedInSchemaUId = new Guid("54a1dccb-9f6d-4a75-b619-9fb91f42c44c"),
				CreatedInPackageId = new Guid("49af2168-effb-4b7f-bce2-28e45d430d96")
			};
		}

		protected virtual EntitySchemaColumn CreateConsentDataColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("SecureText")) {
				UId = new Guid("adf24246-89fb-496d-f180-e450642f8878"),
				Name = @"ConsentData",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("54a1dccb-9f6d-4a75-b619-9fb91f42c44c"),
				ModifiedInSchemaUId = new Guid("54a1dccb-9f6d-4a75-b619-9fb91f42c44c"),
				CreatedInPackageId = new Guid("49af2168-effb-4b7f-bce2-28e45d430d96")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new OAuthConsentInfo(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OAuthConsentInfo_OAuth20EventsProcess(userConnection);
		}

		public override object Clone() {
			return new OAuthConsentInfoSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OAuthConsentInfoSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("54a1dccb-9f6d-4a75-b619-9fb91f42c44c"));
		}

		#endregion

	}

	#endregion

	#region Class: OAuthConsentInfo

	/// <summary>
	/// Consent info for OAuth applications.
	/// </summary>
	public class OAuthConsentInfo : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public OAuthConsentInfo(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OAuthConsentInfo";
		}

		public OAuthConsentInfo(OAuthConsentInfo source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Time to live (UTC).
		/// </summary>
		public DateTime TTL {
			get {
				return GetTypedColumnValue<DateTime>("TTL");
			}
			set {
				SetColumnValue("TTL", value);
			}
		}

		/// <summary>
		/// Consent data.
		/// </summary>
		public string ConsentData {
			get {
				return GetTypedColumnValue<string>("ConsentData");
			}
			set {
				SetColumnValue("ConsentData", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OAuthConsentInfo_OAuth20EventsProcess(UserConnection);
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
			return new OAuthConsentInfo(this);
		}

		#endregion

	}

	#endregion

	#region Class: OAuthConsentInfo_OAuth20EventsProcess

	/// <exclude/>
	public partial class OAuthConsentInfo_OAuth20EventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : OAuthConsentInfo
	{

		public OAuthConsentInfo_OAuth20EventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OAuthConsentInfo_OAuth20EventsProcess";
			SchemaUId = new Guid("54a1dccb-9f6d-4a75-b619-9fb91f42c44c");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("54a1dccb-9f6d-4a75-b619-9fb91f42c44c");
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

	#region Class: OAuthConsentInfo_OAuth20EventsProcess

	/// <exclude/>
	public class OAuthConsentInfo_OAuth20EventsProcess : OAuthConsentInfo_OAuth20EventsProcess<OAuthConsentInfo>
	{

		public OAuthConsentInfo_OAuth20EventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OAuthConsentInfo_OAuth20EventsProcess

	public partial class OAuthConsentInfo_OAuth20EventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: OAuthConsentInfoEventsProcess

	/// <exclude/>
	public class OAuthConsentInfoEventsProcess : OAuthConsentInfo_OAuth20EventsProcess
	{

		public OAuthConsentInfoEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

