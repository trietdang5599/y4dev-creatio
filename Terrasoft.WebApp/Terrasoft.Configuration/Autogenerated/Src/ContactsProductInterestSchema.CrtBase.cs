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

	#region Class: ContactsProductInterestSchema

	/// <exclude/>
	public class ContactsProductInterestSchema : Terrasoft.Configuration.BaseProductInterestSchema
	{

		#region Constructors: Public

		public ContactsProductInterestSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ContactsProductInterestSchema(ContactsProductInterestSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ContactsProductInterestSchema(ContactsProductInterestSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d8381a92-7870-47b5-8e5b-73f3f571fe57");
			RealUId = new Guid("d8381a92-7870-47b5-8e5b-73f3f571fe57");
			Name = "ContactsProductInterest";
			ParentSchemaUId = new Guid("3f1650f6-0086-4d7d-8a8e-003fa7bb64e7");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("78481c5a-262a-420d-b404-71c315129b37")) == null) {
				Columns.Add(CreateContactColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("78481c5a-262a-420d-b404-71c315129b37"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				CreatedInSchemaUId = new Guid("d8381a92-7870-47b5-8e5b-73f3f571fe57"),
				ModifiedInSchemaUId = new Guid("d8381a92-7870-47b5-8e5b-73f3f571fe57"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ContactsProductInterest(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ContactsProductInterest_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ContactsProductInterestSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ContactsProductInterestSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d8381a92-7870-47b5-8e5b-73f3f571fe57"));
		}

		#endregion

	}

	#endregion

	#region Class: ContactsProductInterest

	/// <summary>
	/// Contact interest to products.
	/// </summary>
	public class ContactsProductInterest : Terrasoft.Configuration.BaseProductInterest
	{

		#region Constructors: Public

		public ContactsProductInterest(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ContactsProductInterest";
		}

		public ContactsProductInterest(ContactsProductInterest source)
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

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ContactsProductInterest_CrtBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ContactsProductInterestDeleted", e);
			Deleting += (s, e) => ThrowEvent("ContactsProductInterestDeleting", e);
			Inserted += (s, e) => ThrowEvent("ContactsProductInterestInserted", e);
			Inserting += (s, e) => ThrowEvent("ContactsProductInterestInserting", e);
			Saved += (s, e) => ThrowEvent("ContactsProductInterestSaved", e);
			Saving += (s, e) => ThrowEvent("ContactsProductInterestSaving", e);
			Validating += (s, e) => ThrowEvent("ContactsProductInterestValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ContactsProductInterest(this);
		}

		#endregion

	}

	#endregion

	#region Class: ContactsProductInterest_CrtBaseEventsProcess

	/// <exclude/>
	public partial class ContactsProductInterest_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseProductInterest_CrtBaseEventsProcess<TEntity> where TEntity : ContactsProductInterest
	{

		public ContactsProductInterest_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ContactsProductInterest_CrtBaseEventsProcess";
			SchemaUId = new Guid("d8381a92-7870-47b5-8e5b-73f3f571fe57");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("d8381a92-7870-47b5-8e5b-73f3f571fe57");
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

	#region Class: ContactsProductInterest_CrtBaseEventsProcess

	/// <exclude/>
	public class ContactsProductInterest_CrtBaseEventsProcess : ContactsProductInterest_CrtBaseEventsProcess<ContactsProductInterest>
	{

		public ContactsProductInterest_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ContactsProductInterest_CrtBaseEventsProcess

	public partial class ContactsProductInterest_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ContactsProductInterestEventsProcess

	/// <exclude/>
	public class ContactsProductInterestEventsProcess : ContactsProductInterest_CrtBaseEventsProcess
	{

		public ContactsProductInterestEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

