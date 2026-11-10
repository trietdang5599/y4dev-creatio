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

	#region Class: ChannelSchema

	/// <exclude/>
	public class ChannelSchema : Terrasoft.Configuration.Channel_OmnichannelMessaging_CreatioSchema
	{

		#region Constructors: Public

		public ChannelSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ChannelSchema(ChannelSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ChannelSchema(ChannelSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("db1ac3eb-a772-4e92-8e30-8326bcd512e1");
			Name = "Channel";
			ParentSchemaUId = new Guid("a26e0c98-9a52-4e80-9a04-75221742fed7");
			ExtendParent = true;
			CreatedInPackageId = new Guid("d8bd3670-48ca-4dba-8e6f-255949d3c62e");
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

		protected override EntitySchemaColumn CreateIsActiveColumn() {
			EntitySchemaColumn column = base.CreateIsActiveColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.Const,
				ValueSource = @"True"
			};
			column.ModifiedInSchemaUId = new Guid("db1ac3eb-a772-4e92-8e30-8326bcd512e1");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Channel(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Channel_CrtOmnichannelAppEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ChannelSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ChannelSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("db1ac3eb-a772-4e92-8e30-8326bcd512e1"));
		}

		#endregion

	}

	#endregion

	#region Class: Channel

	/// <summary>
	/// Chat channel.
	/// </summary>
	/// <remarks>
	/// Defines the list of chat channels to receive messages from various messengers and social media platforms for centralized communication management.
	/// </remarks>
	public class Channel : Terrasoft.Configuration.Channel_OmnichannelMessaging_Creatio
	{

		#region Constructors: Public

		public Channel(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Channel";
		}

		public Channel(Channel source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Channel_CrtOmnichannelAppEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ChannelDeleted", e);
			Deleting += (s, e) => ThrowEvent("ChannelDeleting", e);
			Inserted += (s, e) => ThrowEvent("ChannelInserted", e);
			Inserting += (s, e) => ThrowEvent("ChannelInserting", e);
			Saved += (s, e) => ThrowEvent("ChannelSaved", e);
			Saving += (s, e) => ThrowEvent("ChannelSaving", e);
			Validating += (s, e) => ThrowEvent("ChannelValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Channel(this);
		}

		#endregion

	}

	#endregion

	#region Class: Channel_CrtOmnichannelAppEventsProcess

	/// <exclude/>
	public partial class Channel_CrtOmnichannelAppEventsProcess<TEntity> : Terrasoft.Configuration.Channel_OmnichannelMessagingEventsProcess<TEntity> where TEntity : Channel
	{

		public Channel_CrtOmnichannelAppEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Channel_CrtOmnichannelAppEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("db1ac3eb-a772-4e92-8e30-8326bcd512e1");
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

	#region Class: Channel_CrtOmnichannelAppEventsProcess

	/// <exclude/>
	public class Channel_CrtOmnichannelAppEventsProcess : Channel_CrtOmnichannelAppEventsProcess<Channel>
	{

		public Channel_CrtOmnichannelAppEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Channel_CrtOmnichannelAppEventsProcess

	public partial class Channel_CrtOmnichannelAppEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ChannelEventsProcess

	/// <exclude/>
	public class ChannelEventsProcess : Channel_CrtOmnichannelAppEventsProcess
	{

		public ChannelEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

