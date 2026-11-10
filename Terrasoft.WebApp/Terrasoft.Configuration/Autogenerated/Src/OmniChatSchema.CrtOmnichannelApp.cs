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

	#region Class: OmniChatSchema

	/// <exclude/>
	public class OmniChatSchema : Terrasoft.Configuration.OmniChat_OmnichannelMessaging_CreatioSchema
	{

		#region Constructors: Public

		public OmniChatSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OmniChatSchema(OmniChatSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OmniChatSchema(OmniChatSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("2859821e-df14-4c8c-8d55-e857c038f818");
			Name = "OmniChat";
			ParentSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a");
			ExtendParent = true;
			CreatedInPackageId = new Guid("ff0148ae-a5d1-4359-9d88-692d9a10c8de");
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
			return new OmniChat(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OmniChat_CrtOmnichannelAppEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OmniChatSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OmniChatSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2859821e-df14-4c8c-8d55-e857c038f818"));
		}

		#endregion

	}

	#endregion

	#region Class: OmniChat

	/// <summary>
	/// Chat.
	/// </summary>
	/// <remarks>
	/// Represents chat conversations between customers and support agents across integrated channels to manage real-time communication and issue resolution.
	/// </remarks>
	public class OmniChat : Terrasoft.Configuration.OmniChat_OmnichannelMessaging_Creatio
	{

		#region Constructors: Public

		public OmniChat(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OmniChat";
		}

		public OmniChat(OmniChat source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OmniChat_CrtOmnichannelAppEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("OmniChatDeleted", e);
			Deleting += (s, e) => ThrowEvent("OmniChatDeleting", e);
			Inserted += (s, e) => ThrowEvent("OmniChatInserted", e);
			Inserting += (s, e) => ThrowEvent("OmniChatInserting", e);
			Saved += (s, e) => ThrowEvent("OmniChatSaved", e);
			Validating += (s, e) => ThrowEvent("OmniChatValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new OmniChat(this);
		}

		#endregion

	}

	#endregion

	#region Class: OmniChat_CrtOmnichannelAppEventsProcess

	/// <exclude/>
	public partial class OmniChat_CrtOmnichannelAppEventsProcess<TEntity> : Terrasoft.Configuration.OmniChat_OmnichannelMessagingEventsProcess<TEntity> where TEntity : OmniChat
	{

		public OmniChat_CrtOmnichannelAppEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OmniChat_CrtOmnichannelAppEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("2859821e-df14-4c8c-8d55-e857c038f818");
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

	#region Class: OmniChat_CrtOmnichannelAppEventsProcess

	/// <exclude/>
	public class OmniChat_CrtOmnichannelAppEventsProcess : OmniChat_CrtOmnichannelAppEventsProcess<OmniChat>
	{

		public OmniChat_CrtOmnichannelAppEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OmniChat_CrtOmnichannelAppEventsProcess

	public partial class OmniChat_CrtOmnichannelAppEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: OmniChatEventsProcess

	/// <exclude/>
	public class OmniChatEventsProcess : OmniChat_CrtOmnichannelAppEventsProcess
	{

		public OmniChatEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

