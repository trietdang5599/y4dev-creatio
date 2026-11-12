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

	#region Class: ContactType_CrtCoreBase_CreatioSchema

	/// <exclude/>
	public class ContactType_CrtCoreBase_CreatioSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public ContactType_CrtCoreBase_CreatioSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ContactType_CrtCoreBase_CreatioSchema(ContactType_CrtCoreBase_CreatioSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ContactType_CrtCoreBase_CreatioSchema(ContactType_CrtCoreBase_CreatioSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0b5ff414-e00a-4115-af0c-fe872e826f07");
			RealUId = new Guid("0b5ff414-e00a-4115-af0c-fe872e826f07");
			Name = "ContactType_CrtCoreBase_Creatio";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
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

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("0b5ff414-e00a-4115-af0c-fe872e826f07");
			column.CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("0b5ff414-e00a-4115-af0c-fe872e826f07");
			column.CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ContactType_CrtCoreBase_Creatio(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ContactType_CrtCoreBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ContactType_CrtCoreBase_CreatioSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ContactType_CrtCoreBase_CreatioSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0b5ff414-e00a-4115-af0c-fe872e826f07"));
		}

		#endregion

	}

	#endregion

	#region Class: ContactType_CrtCoreBase_Creatio

	/// <summary>
	/// Contact type.
	/// </summary>
	public class ContactType_CrtCoreBase_Creatio : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public ContactType_CrtCoreBase_Creatio(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ContactType_CrtCoreBase_Creatio";
		}

		public ContactType_CrtCoreBase_Creatio(ContactType_CrtCoreBase_Creatio source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ContactType_CrtCoreBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ContactType_CrtCoreBase_CreatioDeleted", e);
			Deleting += (s, e) => ThrowEvent("ContactType_CrtCoreBase_CreatioDeleting", e);
			Inserted += (s, e) => ThrowEvent("ContactType_CrtCoreBase_CreatioInserted", e);
			Inserting += (s, e) => ThrowEvent("ContactType_CrtCoreBase_CreatioInserting", e);
			Saved += (s, e) => ThrowEvent("ContactType_CrtCoreBase_CreatioSaved", e);
			Saving += (s, e) => ThrowEvent("ContactType_CrtCoreBase_CreatioSaving", e);
			Validating += (s, e) => ThrowEvent("ContactType_CrtCoreBase_CreatioValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ContactType_CrtCoreBase_Creatio(this);
		}

		#endregion

	}

	#endregion

	#region Class: ContactType_CrtCoreBaseEventsProcess

	/// <exclude/>
	public partial class ContactType_CrtCoreBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : ContactType_CrtCoreBase_Creatio
	{

		public ContactType_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ContactType_CrtCoreBaseEventsProcess";
			SchemaUId = new Guid("0b5ff414-e00a-4115-af0c-fe872e826f07");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("0b5ff414-e00a-4115-af0c-fe872e826f07");
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

	#region Class: ContactType_CrtCoreBaseEventsProcess

	/// <exclude/>
	public class ContactType_CrtCoreBaseEventsProcess : ContactType_CrtCoreBaseEventsProcess<ContactType_CrtCoreBase_Creatio>
	{

		public ContactType_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ContactType_CrtCoreBaseEventsProcess

	public partial class ContactType_CrtCoreBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

