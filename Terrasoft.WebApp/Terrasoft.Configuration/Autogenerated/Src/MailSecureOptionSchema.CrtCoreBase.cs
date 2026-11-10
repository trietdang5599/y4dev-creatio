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

	#region Class: MailSecureOptionSchema

	/// <exclude/>
	public class MailSecureOptionSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public MailSecureOptionSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public MailSecureOptionSchema(MailSecureOptionSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public MailSecureOptionSchema(MailSecureOptionSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d9ed1a20-c984-4528-a3fe-7dfb9b3a83ec");
			RealUId = new Guid("d9ed1a20-c984-4528-a3fe-7dfb9b3a83ec");
			Name = "MailSecureOption";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
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

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateNameColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("f3241d8e-4d91-20d5-8548-f10c15899aea"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("d9ed1a20-c984-4528-a3fe-7dfb9b3a83ec"),
				ModifiedInSchemaUId = new Guid("d9ed1a20-c984-4528-a3fe-7dfb9b3a83ec"),
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
			return new MailSecureOption(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new MailSecureOption_CrtCoreBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new MailSecureOptionSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new MailSecureOptionSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d9ed1a20-c984-4528-a3fe-7dfb9b3a83ec"));
		}

		#endregion

	}

	#endregion

	#region Class: MailSecureOption

	/// <summary>
	/// Secure option for connection to mail server.
	/// </summary>
	public class MailSecureOption : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public MailSecureOption(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MailSecureOption";
		}

		public MailSecureOption(MailSecureOption source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Mail secure options name.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new MailSecureOption_CrtCoreBaseEventsProcess(UserConnection);
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
			return new MailSecureOption(this);
		}

		#endregion

	}

	#endregion

	#region Class: MailSecureOption_CrtCoreBaseEventsProcess

	/// <exclude/>
	public partial class MailSecureOption_CrtCoreBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : MailSecureOption
	{

		public MailSecureOption_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "MailSecureOption_CrtCoreBaseEventsProcess";
			SchemaUId = new Guid("d9ed1a20-c984-4528-a3fe-7dfb9b3a83ec");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("d9ed1a20-c984-4528-a3fe-7dfb9b3a83ec");
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

	#region Class: MailSecureOption_CrtCoreBaseEventsProcess

	/// <exclude/>
	public class MailSecureOption_CrtCoreBaseEventsProcess : MailSecureOption_CrtCoreBaseEventsProcess<MailSecureOption>
	{

		public MailSecureOption_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: MailSecureOption_CrtCoreBaseEventsProcess

	public partial class MailSecureOption_CrtCoreBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: MailSecureOptionEventsProcess

	/// <exclude/>
	public class MailSecureOptionEventsProcess : MailSecureOption_CrtCoreBaseEventsProcess
	{

		public MailSecureOptionEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

