namespace Terrasoft.Configuration
{

	using DataContract = Terrasoft.Nui.ServiceModel.DataContract;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Data;
	using System.Drawing;
	using System.Globalization;
	using System.IO;
	using System.Linq;
	using System.Text;
	using System.Text.RegularExpressions;
	using Terrasoft.Common;
	using Terrasoft.Common.Json;
	using Terrasoft.Configuration.RightsService;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.DcmProcess;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;
	using Terrasoft.Mail;
	using Terrasoft.Messaging.Common;
	using Terrasoft.UI.WebControls.Controls;
	using Terrasoft.UI.WebControls.Utilities.Json.Converters;

	#region Class: SysApprovalSchema

	/// <exclude/>
	public class SysApprovalSchema : Terrasoft.Configuration.BaseVisaSchema
	{

		#region Constructors: Public

		public SysApprovalSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysApprovalSchema(SysApprovalSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysApprovalSchema(SysApprovalSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("9800f45d-7d2e-44c7-85e5-053c06c8c2d4");
			RealUId = new Guid("9800f45d-7d2e-44c7-85e5-053c06c8c2d4");
			Name = "SysApproval";
			ParentSchemaUId = new Guid("5fa90d0d-64eb-4f52-8d3d-c51fa6443b66");
			ExtendParent = false;
			CreatedInPackageId = new Guid("0d469eb7-f74c-4325-a1d2-7fa6cad8b3a6");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("beb54bb3-056b-1fb9-73d0-708b22de9efc")) == null) {
				Columns.Add(CreateReferenceSchemaNameColumn());
			}
			if (Columns.FindByUId(new Guid("8b79ff0d-705f-964d-0f05-2f0ce0599bcc")) == null) {
				Columns.Add(CreateEntityIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateReferenceSchemaNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("beb54bb3-056b-1fb9-73d0-708b22de9efc"),
				Name = @"ReferenceSchemaName",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("9800f45d-7d2e-44c7-85e5-053c06c8c2d4"),
				ModifiedInSchemaUId = new Guid("9800f45d-7d2e-44c7-85e5-053c06c8c2d4"),
				CreatedInPackageId = new Guid("0d469eb7-f74c-4325-a1d2-7fa6cad8b3a6")
			};
		}

		protected virtual EntitySchemaColumn CreateEntityIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("8b79ff0d-705f-964d-0f05-2f0ce0599bcc"),
				Name = @"EntityId",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("9800f45d-7d2e-44c7-85e5-053c06c8c2d4"),
				ModifiedInSchemaUId = new Guid("9800f45d-7d2e-44c7-85e5-053c06c8c2d4"),
				CreatedInPackageId = new Guid("0d469eb7-f74c-4325-a1d2-7fa6cad8b3a6")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysApproval(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysApproval_ApprovalEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysApprovalSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysApprovalSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9800f45d-7d2e-44c7-85e5-053c06c8c2d4"));
		}

		#endregion

	}

	#endregion

	#region Class: SysApproval

	/// <summary>
	/// Approval.
	/// </summary>
	public class SysApproval : Terrasoft.Configuration.BaseVisa
	{

		#region Constructors: Public

		public SysApproval(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysApproval";
		}

		public SysApproval(SysApproval source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Reference schema name.
		/// </summary>
		public string ReferenceSchemaName {
			get {
				return GetTypedColumnValue<string>("ReferenceSchemaName");
			}
			set {
				SetColumnValue("ReferenceSchemaName", value);
			}
		}

		/// <summary>
		/// Entity identifier.
		/// </summary>
		public Guid EntityId {
			get {
				return GetTypedColumnValue<Guid>("EntityId");
			}
			set {
				SetColumnValue("EntityId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysApproval_ApprovalEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysApprovalDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysApprovalDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysApprovalInserted", e);
			Inserting += (s, e) => ThrowEvent("SysApprovalInserting", e);
			Saved += (s, e) => ThrowEvent("SysApprovalSaved", e);
			Saving += (s, e) => ThrowEvent("SysApprovalSaving", e);
			Validating += (s, e) => ThrowEvent("SysApprovalValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysApproval(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysApproval_ApprovalEventsProcess

	/// <exclude/>
	public partial class SysApproval_ApprovalEventsProcess<TEntity> : Terrasoft.Configuration.BaseVisa_CrtProcessDesignerEventsProcess<TEntity> where TEntity : SysApproval
	{

		public SysApproval_ApprovalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysApproval_ApprovalEventsProcess";
			SchemaUId = new Guid("9800f45d-7d2e-44c7-85e5-053c06c8c2d4");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("9800f45d-7d2e-44c7-85e5-053c06c8c2d4");
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

	#region Class: SysApproval_ApprovalEventsProcess

	/// <exclude/>
	public class SysApproval_ApprovalEventsProcess : SysApproval_ApprovalEventsProcess<SysApproval>
	{

		public SysApproval_ApprovalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion


	#region Class: SysApprovalEventsProcess

	/// <exclude/>
	public class SysApprovalEventsProcess : SysApproval_ApprovalEventsProcess
	{

		public SysApprovalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

