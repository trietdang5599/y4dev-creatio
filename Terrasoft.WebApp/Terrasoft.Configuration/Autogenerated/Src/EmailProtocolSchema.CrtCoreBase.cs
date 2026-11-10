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

	#region Class: EmailProtocolSchema

	/// <exclude/>
	public class EmailProtocolSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public EmailProtocolSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public EmailProtocolSchema(EmailProtocolSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public EmailProtocolSchema(EmailProtocolSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("23b9470a-2e03-472b-b609-eff6e0339dd4");
			RealUId = new Guid("23b9470a-2e03-472b-b609-eff6e0339dd4");
			Name = "EmailProtocol";
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
			column.ModifiedInSchemaUId = new Guid("23b9470a-2e03-472b-b609-eff6e0339dd4");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("23b9470a-2e03-472b-b609-eff6e0339dd4");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new EmailProtocol(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new EmailProtocol_CrtCoreBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new EmailProtocolSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new EmailProtocolSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("23b9470a-2e03-472b-b609-eff6e0339dd4"));
		}

		#endregion

	}

	#endregion

	#region Class: EmailProtocol

	/// <summary>
	/// Connection protocol.
	/// </summary>
	public class EmailProtocol : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public EmailProtocol(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "EmailProtocol";
		}

		public EmailProtocol(EmailProtocol source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new EmailProtocol_CrtCoreBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("EmailProtocolDeleted", e);
			Inserting += (s, e) => ThrowEvent("EmailProtocolInserting", e);
			Validating += (s, e) => ThrowEvent("EmailProtocolValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new EmailProtocol(this);
		}

		#endregion

	}

	#endregion

	#region Class: EmailProtocol_CrtCoreBaseEventsProcess

	/// <exclude/>
	public partial class EmailProtocol_CrtCoreBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : EmailProtocol
	{

		public EmailProtocol_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "EmailProtocol_CrtCoreBaseEventsProcess";
			SchemaUId = new Guid("23b9470a-2e03-472b-b609-eff6e0339dd4");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("23b9470a-2e03-472b-b609-eff6e0339dd4");
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

	#region Class: EmailProtocol_CrtCoreBaseEventsProcess

	/// <exclude/>
	public class EmailProtocol_CrtCoreBaseEventsProcess : EmailProtocol_CrtCoreBaseEventsProcess<EmailProtocol>
	{

		public EmailProtocol_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: EmailProtocol_CrtCoreBaseEventsProcess

	public partial class EmailProtocol_CrtCoreBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: EmailProtocolEventsProcess

	/// <exclude/>
	public class EmailProtocolEventsProcess : EmailProtocol_CrtCoreBaseEventsProcess
	{

		public EmailProtocolEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

