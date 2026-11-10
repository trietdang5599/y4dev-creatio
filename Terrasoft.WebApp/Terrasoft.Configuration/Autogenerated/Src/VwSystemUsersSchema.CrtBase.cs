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

	#region Class: VwSystemUsersSchema

	/// <exclude/>
	public class VwSystemUsersSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public VwSystemUsersSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwSystemUsersSchema(VwSystemUsersSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwSystemUsersSchema(VwSystemUsersSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("333b1380-a40f-4972-9650-f3a51ead1a45");
			RealUId = new Guid("333b1380-a40f-4972-9650-f3a51ead1a45");
			Name = "VwSystemUsers";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("33751fbd-e7b0-4cc3-84b5-5ebd1b255698")) == null) {
				Columns.Add(CreateContactColumn());
			}
			if (Columns.FindByUId(new Guid("db038df6-07b4-454b-8593-e9569dd63948")) == null) {
				Columns.Add(CreateConnectionTypeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("33751fbd-e7b0-4cc3-84b5-5ebd1b255698"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("333b1380-a40f-4972-9650-f3a51ead1a45"),
				ModifiedInSchemaUId = new Guid("333b1380-a40f-4972-9650-f3a51ead1a45"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateConnectionTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("db038df6-07b4-454b-8593-e9569dd63948"),
				Name = @"ConnectionType",
				CreatedInSchemaUId = new Guid("333b1380-a40f-4972-9650-f3a51ead1a45"),
				ModifiedInSchemaUId = new Guid("333b1380-a40f-4972-9650-f3a51ead1a45"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwSystemUsers(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwSystemUsers_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwSystemUsersSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwSystemUsersSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("333b1380-a40f-4972-9650-f3a51ead1a45"));
		}

		#endregion

	}

	#endregion

	#region Class: VwSystemUsers

	/// <summary>
	/// System users (view).
	/// </summary>
	public class VwSystemUsers : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public VwSystemUsers(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwSystemUsers";
		}

		public VwSystemUsers(VwSystemUsers source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ContactId {
			get {
				return GetTypedColumnValue<Guid>("ContactId");
			}
			set {
				SetColumnValue("ContactId", value);
				_contact = null;
			}
		}

		/// <exclude/>
		public string ContactName {
			get {
				return GetTypedColumnValue<string>("ContactName");
			}
			set {
				SetColumnValue("ContactName", value);
				if (_contact != null) {
					_contact.Name = value;
				}
			}
		}

		private Contact _contact;
		/// <summary>
		/// Contact.
		/// </summary>
		public Contact Contact {
			get {
				return _contact ??
					(_contact = LookupColumnEntities.GetEntity("Contact") as Contact);
			}
		}

		/// <summary>
		/// Connection type.
		/// </summary>
		public int ConnectionType {
			get {
				return GetTypedColumnValue<int>("ConnectionType");
			}
			set {
				SetColumnValue("ConnectionType", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwSystemUsers_CrtBaseEventsProcess(UserConnection);
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
			return new VwSystemUsers(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwSystemUsers_CrtBaseEventsProcess

	/// <exclude/>
	public partial class VwSystemUsers_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : VwSystemUsers
	{

		public VwSystemUsers_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwSystemUsers_CrtBaseEventsProcess";
			SchemaUId = new Guid("333b1380-a40f-4972-9650-f3a51ead1a45");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("333b1380-a40f-4972-9650-f3a51ead1a45");
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

	#region Class: VwSystemUsers_CrtBaseEventsProcess

	/// <exclude/>
	public class VwSystemUsers_CrtBaseEventsProcess : VwSystemUsers_CrtBaseEventsProcess<VwSystemUsers>
	{

		public VwSystemUsers_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwSystemUsers_CrtBaseEventsProcess

	public partial class VwSystemUsers_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwSystemUsersEventsProcess

	/// <exclude/>
	public class VwSystemUsersEventsProcess : VwSystemUsers_CrtBaseEventsProcess
	{

		public VwSystemUsersEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

