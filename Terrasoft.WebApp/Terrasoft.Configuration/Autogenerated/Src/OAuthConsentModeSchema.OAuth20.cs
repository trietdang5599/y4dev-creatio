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

	#region Class: OAuthConsentModeSchema

	/// <exclude/>
	public class OAuthConsentModeSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public OAuthConsentModeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OAuthConsentModeSchema(OAuthConsentModeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OAuthConsentModeSchema(OAuthConsentModeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("61ec9bc0-e9f4-41a1-9a2f-fd7aefb900e8");
			RealUId = new Guid("61ec9bc0-e9f4-41a1-9a2f-fd7aefb900e8");
			Name = "OAuthConsentMode";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("49af2168-effb-4b7f-bce2-28e45d430d96");
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
			if (Columns.FindByUId(new Guid("6ba9fbbe-82a7-89e4-613d-6d37ff3d9b2c")) == null) {
				Columns.Add(CreateCodeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("6ba9fbbe-82a7-89e4-613d-6d37ff3d9b2c"),
				Name = @"Code",
				CreatedInSchemaUId = new Guid("61ec9bc0-e9f4-41a1-9a2f-fd7aefb900e8"),
				ModifiedInSchemaUId = new Guid("61ec9bc0-e9f4-41a1-9a2f-fd7aefb900e8"),
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
			return new OAuthConsentMode(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OAuthConsentMode_OAuth20EventsProcess(userConnection);
		}

		public override object Clone() {
			return new OAuthConsentModeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OAuthConsentModeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("61ec9bc0-e9f4-41a1-9a2f-fd7aefb900e8"));
		}

		#endregion

	}

	#endregion

	#region Class: OAuthConsentMode

	/// <summary>
	/// Base lookup.
	/// </summary>
	public class OAuthConsentMode : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public OAuthConsentMode(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OAuthConsentMode";
		}

		public OAuthConsentMode(OAuthConsentMode source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		public string Code {
			get {
				return GetTypedColumnValue<string>("Code");
			}
			set {
				SetColumnValue("Code", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OAuthConsentMode_OAuth20EventsProcess(UserConnection);
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
			return new OAuthConsentMode(this);
		}

		#endregion

	}

	#endregion

	#region Class: OAuthConsentMode_OAuth20EventsProcess

	/// <exclude/>
	public partial class OAuthConsentMode_OAuth20EventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : OAuthConsentMode
	{

		public OAuthConsentMode_OAuth20EventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OAuthConsentMode_OAuth20EventsProcess";
			SchemaUId = new Guid("61ec9bc0-e9f4-41a1-9a2f-fd7aefb900e8");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("61ec9bc0-e9f4-41a1-9a2f-fd7aefb900e8");
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

	#region Class: OAuthConsentMode_OAuth20EventsProcess

	/// <exclude/>
	public class OAuthConsentMode_OAuth20EventsProcess : OAuthConsentMode_OAuth20EventsProcess<OAuthConsentMode>
	{

		public OAuthConsentMode_OAuth20EventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OAuthConsentMode_OAuth20EventsProcess

	public partial class OAuthConsentMode_OAuth20EventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: OAuthConsentModeEventsProcess

	/// <exclude/>
	public class OAuthConsentModeEventsProcess : OAuthConsentMode_OAuth20EventsProcess
	{

		public OAuthConsentModeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

