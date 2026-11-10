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

	#region Class: EmailTemplateSendFlagSchema

	/// <exclude/>
	public class EmailTemplateSendFlagSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public EmailTemplateSendFlagSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public EmailTemplateSendFlagSchema(EmailTemplateSendFlagSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public EmailTemplateSendFlagSchema(EmailTemplateSendFlagSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4faa5635-4485-41d9-bd19-6692a41c4e19");
			RealUId = new Guid("4faa5635-4485-41d9-bd19-6692a41c4e19");
			Name = "EmailTemplateSendFlag";
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
			column.ModifiedInSchemaUId = new Guid("4faa5635-4485-41d9-bd19-6692a41c4e19");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("4faa5635-4485-41d9-bd19-6692a41c4e19");
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
			return new EmailTemplateSendFlag(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new EmailTemplateSendFlag_CrtCoreBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new EmailTemplateSendFlagSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new EmailTemplateSendFlagSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4faa5635-4485-41d9-bd19-6692a41c4e19"));
		}

		#endregion

	}

	#endregion

	#region Class: EmailTemplateSendFlag

	/// <summary>
	/// Message sent indicator in email template.
	/// </summary>
	public class EmailTemplateSendFlag : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public EmailTemplateSendFlag(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "EmailTemplateSendFlag";
		}

		public EmailTemplateSendFlag(EmailTemplateSendFlag source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new EmailTemplateSendFlag_CrtCoreBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("EmailTemplateSendFlagDeleted", e);
			Inserting += (s, e) => ThrowEvent("EmailTemplateSendFlagInserting", e);
			Validating += (s, e) => ThrowEvent("EmailTemplateSendFlagValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new EmailTemplateSendFlag(this);
		}

		#endregion

	}

	#endregion

	#region Class: EmailTemplateSendFlag_CrtCoreBaseEventsProcess

	/// <exclude/>
	public partial class EmailTemplateSendFlag_CrtCoreBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : EmailTemplateSendFlag
	{

		public EmailTemplateSendFlag_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "EmailTemplateSendFlag_CrtCoreBaseEventsProcess";
			SchemaUId = new Guid("4faa5635-4485-41d9-bd19-6692a41c4e19");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("4faa5635-4485-41d9-bd19-6692a41c4e19");
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

	#region Class: EmailTemplateSendFlag_CrtCoreBaseEventsProcess

	/// <exclude/>
	public class EmailTemplateSendFlag_CrtCoreBaseEventsProcess : EmailTemplateSendFlag_CrtCoreBaseEventsProcess<EmailTemplateSendFlag>
	{

		public EmailTemplateSendFlag_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: EmailTemplateSendFlag_CrtCoreBaseEventsProcess

	public partial class EmailTemplateSendFlag_CrtCoreBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: EmailTemplateSendFlagEventsProcess

	/// <exclude/>
	public class EmailTemplateSendFlagEventsProcess : EmailTemplateSendFlag_CrtCoreBaseEventsProcess
	{

		public EmailTemplateSendFlagEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

