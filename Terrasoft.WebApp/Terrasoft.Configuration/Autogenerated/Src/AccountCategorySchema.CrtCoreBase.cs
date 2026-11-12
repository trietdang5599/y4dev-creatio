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

	#region Class: AccountCategory_CrtCoreBase_CreatioSchema

	/// <exclude/>
	public class AccountCategory_CrtCoreBase_CreatioSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public AccountCategory_CrtCoreBase_CreatioSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public AccountCategory_CrtCoreBase_CreatioSchema(AccountCategory_CrtCoreBase_CreatioSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public AccountCategory_CrtCoreBase_CreatioSchema(AccountCategory_CrtCoreBase_CreatioSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a6ff9860-2b37-4da2-9537-5cd6cedf9665");
			RealUId = new Guid("a6ff9860-2b37-4da2-9537-5cd6cedf9665");
			Name = "AccountCategory_CrtCoreBase_Creatio";
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

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new AccountCategory_CrtCoreBase_Creatio(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new AccountCategory_CrtCoreBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new AccountCategory_CrtCoreBase_CreatioSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new AccountCategory_CrtCoreBase_CreatioSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a6ff9860-2b37-4da2-9537-5cd6cedf9665"));
		}

		#endregion

	}

	#endregion

	#region Class: AccountCategory_CrtCoreBase_Creatio

	/// <summary>
	/// Category of Account.
	/// </summary>
	public class AccountCategory_CrtCoreBase_Creatio : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public AccountCategory_CrtCoreBase_Creatio(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "AccountCategory_CrtCoreBase_Creatio";
		}

		public AccountCategory_CrtCoreBase_Creatio(AccountCategory_CrtCoreBase_Creatio source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new AccountCategory_CrtCoreBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("AccountCategory_CrtCoreBase_CreatioDeleted", e);
			Deleting += (s, e) => ThrowEvent("AccountCategory_CrtCoreBase_CreatioDeleting", e);
			Inserted += (s, e) => ThrowEvent("AccountCategory_CrtCoreBase_CreatioInserted", e);
			Inserting += (s, e) => ThrowEvent("AccountCategory_CrtCoreBase_CreatioInserting", e);
			Saved += (s, e) => ThrowEvent("AccountCategory_CrtCoreBase_CreatioSaved", e);
			Saving += (s, e) => ThrowEvent("AccountCategory_CrtCoreBase_CreatioSaving", e);
			Validating += (s, e) => ThrowEvent("AccountCategory_CrtCoreBase_CreatioValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new AccountCategory_CrtCoreBase_Creatio(this);
		}

		#endregion

	}

	#endregion

	#region Class: AccountCategory_CrtCoreBaseEventsProcess

	/// <exclude/>
	public partial class AccountCategory_CrtCoreBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : AccountCategory_CrtCoreBase_Creatio
	{

		public AccountCategory_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "AccountCategory_CrtCoreBaseEventsProcess";
			SchemaUId = new Guid("a6ff9860-2b37-4da2-9537-5cd6cedf9665");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("a6ff9860-2b37-4da2-9537-5cd6cedf9665");
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

	#region Class: AccountCategory_CrtCoreBaseEventsProcess

	/// <exclude/>
	public class AccountCategory_CrtCoreBaseEventsProcess : AccountCategory_CrtCoreBaseEventsProcess<AccountCategory_CrtCoreBase_Creatio>
	{

		public AccountCategory_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: AccountCategory_CrtCoreBaseEventsProcess

	public partial class AccountCategory_CrtCoreBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

