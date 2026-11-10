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

	#region Class: MessageComposerChannelSchema

	/// <exclude/>
	public class MessageComposerChannelSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public MessageComposerChannelSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public MessageComposerChannelSchema(MessageComposerChannelSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public MessageComposerChannelSchema(MessageComposerChannelSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateSchemaTypeIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = true
			};
			index.UId = new Guid("faea37cc-9e19-4654-a790-5de515676192");
			index.Name = "SchemaType";
			index.CreatedInSchemaUId = new Guid("2c1625bf-e966-4b92-afd4-8ab921bcd2f1");
			index.ModifiedInSchemaUId = new Guid("2c1625bf-e966-4b92-afd4-8ab921bcd2f1");
			index.CreatedInPackageId = new Guid("d699061b-815e-49b9-8730-21a5e5db2044");
			EntitySchemaIndexColumn schemaTypeIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("f829e102-6024-a872-7f73-5510f8397772"),
				ColumnUId = new Guid("d0285974-bb58-0c9e-d096-3b8e486834cc"),
				CreatedInSchemaUId = new Guid("2c1625bf-e966-4b92-afd4-8ab921bcd2f1"),
				ModifiedInSchemaUId = new Guid("2c1625bf-e966-4b92-afd4-8ab921bcd2f1"),
				CreatedInPackageId = new Guid("d699061b-815e-49b9-8730-21a5e5db2044"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(schemaTypeIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("2c1625bf-e966-4b92-afd4-8ab921bcd2f1");
			RealUId = new Guid("2c1625bf-e966-4b92-afd4-8ab921bcd2f1");
			Name = "MessageComposerChannel";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("d699061b-815e-49b9-8730-21a5e5db2044");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = false;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("5c7bf0ac-19ab-c4b9-b723-5781c2d50247")) == null) {
				Columns.Add(CreateIconColumn());
			}
			if (Columns.FindByUId(new Guid("406bc615-559c-5683-ed88-55c719374dc8")) == null) {
				Columns.Add(CreateTypeColumn());
			}
			if (Columns.FindByUId(new Guid("d0285974-bb58-0c9e-d096-3b8e486834cc")) == null) {
				Columns.Add(CreateSchemaTypeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateIconColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("5c7bf0ac-19ab-c4b9-b723-5781c2d50247"),
				Name = @"Icon",
				CreatedInSchemaUId = new Guid("2c1625bf-e966-4b92-afd4-8ab921bcd2f1"),
				ModifiedInSchemaUId = new Guid("2c1625bf-e966-4b92-afd4-8ab921bcd2f1"),
				CreatedInPackageId = new Guid("d699061b-815e-49b9-8730-21a5e5db2044")
			};
		}

		protected virtual EntitySchemaColumn CreateTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("406bc615-559c-5683-ed88-55c719374dc8"),
				Name = @"Type",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("2c1625bf-e966-4b92-afd4-8ab921bcd2f1"),
				ModifiedInSchemaUId = new Guid("2c1625bf-e966-4b92-afd4-8ab921bcd2f1"),
				CreatedInPackageId = new Guid("d699061b-815e-49b9-8730-21a5e5db2044")
			};
		}

		protected virtual EntitySchemaColumn CreateSchemaTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("d0285974-bb58-0c9e-d096-3b8e486834cc"),
				Name = @"SchemaType",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("2c1625bf-e966-4b92-afd4-8ab921bcd2f1"),
				ModifiedInSchemaUId = new Guid("2c1625bf-e966-4b92-afd4-8ab921bcd2f1"),
				CreatedInPackageId = new Guid("d699061b-815e-49b9-8730-21a5e5db2044")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateSchemaTypeIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new MessageComposerChannel(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new MessageComposerChannel_CrtUIv2EventsProcess(userConnection);
		}

		public override object Clone() {
			return new MessageComposerChannelSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new MessageComposerChannelSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2c1625bf-e966-4b92-afd4-8ab921bcd2f1"));
		}

		#endregion

	}

	#endregion

	#region Class: MessageComposerChannel

	/// <summary>
	/// Message composer channel.
	/// </summary>
	public class MessageComposerChannel : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public MessageComposerChannel(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MessageComposerChannel";
		}

		public MessageComposerChannel(MessageComposerChannel source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Icon name.
		/// </summary>
		public string Icon {
			get {
				return GetTypedColumnValue<string>("Icon");
			}
			set {
				SetColumnValue("Icon", value);
			}
		}

		/// <summary>
		/// Type name.
		/// </summary>
		public string Type {
			get {
				return GetTypedColumnValue<string>("Type");
			}
			set {
				SetColumnValue("Type", value);
			}
		}

		/// <summary>
		/// Schema type.
		/// </summary>
		public string SchemaType {
			get {
				return GetTypedColumnValue<string>("SchemaType");
			}
			set {
				SetColumnValue("SchemaType", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new MessageComposerChannel_CrtUIv2EventsProcess(UserConnection);
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
			return new MessageComposerChannel(this);
		}

		#endregion

	}

	#endregion

	#region Class: MessageComposerChannel_CrtUIv2EventsProcess

	/// <exclude/>
	public partial class MessageComposerChannel_CrtUIv2EventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : MessageComposerChannel
	{

		public MessageComposerChannel_CrtUIv2EventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "MessageComposerChannel_CrtUIv2EventsProcess";
			SchemaUId = new Guid("2c1625bf-e966-4b92-afd4-8ab921bcd2f1");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("2c1625bf-e966-4b92-afd4-8ab921bcd2f1");
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

	#region Class: MessageComposerChannel_CrtUIv2EventsProcess

	/// <exclude/>
	public class MessageComposerChannel_CrtUIv2EventsProcess : MessageComposerChannel_CrtUIv2EventsProcess<MessageComposerChannel>
	{

		public MessageComposerChannel_CrtUIv2EventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: MessageComposerChannel_CrtUIv2EventsProcess

	public partial class MessageComposerChannel_CrtUIv2EventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: MessageComposerChannelEventsProcess

	/// <exclude/>
	public class MessageComposerChannelEventsProcess : MessageComposerChannel_CrtUIv2EventsProcess
	{

		public MessageComposerChannelEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

