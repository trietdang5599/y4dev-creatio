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

	#region Class: VwSysCspViolationSchema

	/// <exclude/>
	public class VwSysCspViolationSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public VwSysCspViolationSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwSysCspViolationSchema(VwSysCspViolationSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwSysCspViolationSchema(VwSysCspViolationSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7ac15cd2-19cd-4dcc-9688-df259e35e95b");
			RealUId = new Guid("7ac15cd2-19cd-4dcc-9688-df259e35e95b");
			Name = "VwSysCspViolation";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("9acc6780-473e-4622-a1b4-a9672747b2c4");
			IsDBView = true;
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
			PrimaryDisplayColumn = CreateBlockedHostColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("a2075b1d-019b-af93-dfb4-c25244bd719d")) == null) {
				Columns.Add(CreateLastViolationDateColumn());
			}
			if (Columns.FindByUId(new Guid("0ce3f9af-a3f9-5e55-10a2-a8a4c14f98d2")) == null) {
				Columns.Add(CreateViolatedDirectiveColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateLastViolationDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("a2075b1d-019b-af93-dfb4-c25244bd719d"),
				Name = @"LastViolationDate",
				CreatedInSchemaUId = new Guid("7ac15cd2-19cd-4dcc-9688-df259e35e95b"),
				ModifiedInSchemaUId = new Guid("7ac15cd2-19cd-4dcc-9688-df259e35e95b"),
				CreatedInPackageId = new Guid("9acc6780-473e-4622-a1b4-a9672747b2c4")
			};
		}

		protected virtual EntitySchemaColumn CreateBlockedHostColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("f7a8b321-aa3a-bd85-ac1f-0b058f5d02c0"),
				Name = @"BlockedHost",
				CreatedInSchemaUId = new Guid("7ac15cd2-19cd-4dcc-9688-df259e35e95b"),
				ModifiedInSchemaUId = new Guid("7ac15cd2-19cd-4dcc-9688-df259e35e95b"),
				CreatedInPackageId = new Guid("9acc6780-473e-4622-a1b4-a9672747b2c4")
			};
		}

		protected virtual EntitySchemaColumn CreateViolatedDirectiveColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("0ce3f9af-a3f9-5e55-10a2-a8a4c14f98d2"),
				Name = @"ViolatedDirective",
				CreatedInSchemaUId = new Guid("7ac15cd2-19cd-4dcc-9688-df259e35e95b"),
				ModifiedInSchemaUId = new Guid("7ac15cd2-19cd-4dcc-9688-df259e35e95b"),
				CreatedInPackageId = new Guid("9acc6780-473e-4622-a1b4-a9672747b2c4")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwSysCspViolation(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwSysCspViolation_CSPEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwSysCspViolationSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwSysCspViolationSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7ac15cd2-19cd-4dcc-9688-df259e35e95b"));
		}

		#endregion

	}

	#endregion

	#region Class: VwSysCspViolation

	/// <summary>
	/// VwSysCspViolation.
	/// </summary>
	public class VwSysCspViolation : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public VwSysCspViolation(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwSysCspViolation";
		}

		public VwSysCspViolation(VwSysCspViolation source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Last violation date.
		/// </summary>
		public DateTime LastViolationDate {
			get {
				return GetTypedColumnValue<DateTime>("LastViolationDate");
			}
			set {
				SetColumnValue("LastViolationDate", value);
			}
		}

		/// <summary>
		/// Blocked host.
		/// </summary>
		public string BlockedHost {
			get {
				return GetTypedColumnValue<string>("BlockedHost");
			}
			set {
				SetColumnValue("BlockedHost", value);
			}
		}

		/// <summary>
		/// Violated directive.
		/// </summary>
		public string ViolatedDirective {
			get {
				return GetTypedColumnValue<string>("ViolatedDirective");
			}
			set {
				SetColumnValue("ViolatedDirective", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwSysCspViolation_CSPEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwSysCspViolationDeleted", e);
			Deleting += (s, e) => ThrowEvent("VwSysCspViolationDeleting", e);
			Inserted += (s, e) => ThrowEvent("VwSysCspViolationInserted", e);
			Inserting += (s, e) => ThrowEvent("VwSysCspViolationInserting", e);
			Saved += (s, e) => ThrowEvent("VwSysCspViolationSaved", e);
			Saving += (s, e) => ThrowEvent("VwSysCspViolationSaving", e);
			Validating += (s, e) => ThrowEvent("VwSysCspViolationValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwSysCspViolation(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwSysCspViolation_CSPEventsProcess

	/// <exclude/>
	public partial class VwSysCspViolation_CSPEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : VwSysCspViolation
	{

		public VwSysCspViolation_CSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwSysCspViolation_CSPEventsProcess";
			SchemaUId = new Guid("7ac15cd2-19cd-4dcc-9688-df259e35e95b");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("7ac15cd2-19cd-4dcc-9688-df259e35e95b");
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

	#region Class: VwSysCspViolation_CSPEventsProcess

	/// <exclude/>
	public class VwSysCspViolation_CSPEventsProcess : VwSysCspViolation_CSPEventsProcess<VwSysCspViolation>
	{

		public VwSysCspViolation_CSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwSysCspViolation_CSPEventsProcess

	public partial class VwSysCspViolation_CSPEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwSysCspViolationEventsProcess

	/// <exclude/>
	public class VwSysCspViolationEventsProcess : VwSysCspViolation_CSPEventsProcess
	{

		public VwSysCspViolationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

