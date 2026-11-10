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

	#region Class: ESDuplicateEntitySchema

	/// <exclude/>
	public class ESDuplicateEntitySchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ESDuplicateEntitySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ESDuplicateEntitySchema(ESDuplicateEntitySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ESDuplicateEntitySchema(ESDuplicateEntitySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("cd1c811c-c9d9-401b-be0e-daea14f97215");
			RealUId = new Guid("cd1c811c-c9d9-401b-be0e-daea14f97215");
			Name = "ESDuplicateEntity";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("4c53ad23-c903-414d-89cd-b08703861304");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("b835d308-a411-e85a-f4fb-eaac60140841")) == null) {
				Columns.Add(CreateHasErrorsColumn());
			}
			if (Columns.FindByUId(new Guid("dfb719f8-ca48-18ee-00df-e87ac954de08")) == null) {
				Columns.Add(CreateEntityIdColumn());
			}
			if (Columns.FindByUId(new Guid("d237e56d-7ca4-b33f-d956-3a6464aa0546")) == null) {
				Columns.Add(CreateSysSchemaUIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateHasErrorsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("b835d308-a411-e85a-f4fb-eaac60140841"),
				Name = @"HasErrors",
				CreatedInSchemaUId = new Guid("cd1c811c-c9d9-401b-be0e-daea14f97215"),
				ModifiedInSchemaUId = new Guid("cd1c811c-c9d9-401b-be0e-daea14f97215"),
				CreatedInPackageId = new Guid("4c53ad23-c903-414d-89cd-b08703861304")
			};
		}

		protected virtual EntitySchemaColumn CreateEntityIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("dfb719f8-ca48-18ee-00df-e87ac954de08"),
				Name = @"EntityId",
				CreatedInSchemaUId = new Guid("cd1c811c-c9d9-401b-be0e-daea14f97215"),
				ModifiedInSchemaUId = new Guid("cd1c811c-c9d9-401b-be0e-daea14f97215"),
				CreatedInPackageId = new Guid("4c53ad23-c903-414d-89cd-b08703861304")
			};
		}

		protected virtual EntitySchemaColumn CreateSysSchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("d237e56d-7ca4-b33f-d956-3a6464aa0546"),
				Name = @"SysSchemaUId",
				CreatedInSchemaUId = new Guid("cd1c811c-c9d9-401b-be0e-daea14f97215"),
				ModifiedInSchemaUId = new Guid("cd1c811c-c9d9-401b-be0e-daea14f97215"),
				CreatedInPackageId = new Guid("4c53ad23-c903-414d-89cd-b08703861304")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ESDuplicateEntity(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ESDuplicateEntity_CrtDeduplicationEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ESDuplicateEntitySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ESDuplicateEntitySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("cd1c811c-c9d9-401b-be0e-daea14f97215"));
		}

		#endregion

	}

	#endregion

	#region Class: ESDuplicateEntity

	/// <summary>
	/// ESDuplicateEntity.
	/// </summary>
	public class ESDuplicateEntity : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ESDuplicateEntity(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ESDuplicateEntity";
		}

		public ESDuplicateEntity(ESDuplicateEntity source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Has errors.
		/// </summary>
		public bool HasErrors {
			get {
				return GetTypedColumnValue<bool>("HasErrors");
			}
			set {
				SetColumnValue("HasErrors", value);
			}
		}

		/// <summary>
		/// Entity unique identifier.
		/// </summary>
		public Guid EntityId {
			get {
				return GetTypedColumnValue<Guid>("EntityId");
			}
			set {
				SetColumnValue("EntityId", value);
			}
		}

		/// <summary>
		/// Schema unique identifier.
		/// </summary>
		public Guid SysSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("SysSchemaUId");
			}
			set {
				SetColumnValue("SysSchemaUId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ESDuplicateEntity_CrtDeduplicationEventsProcess(UserConnection);
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
			return new ESDuplicateEntity(this);
		}

		#endregion

	}

	#endregion

	#region Class: ESDuplicateEntity_CrtDeduplicationEventsProcess

	/// <exclude/>
	public partial class ESDuplicateEntity_CrtDeduplicationEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : ESDuplicateEntity
	{

		public ESDuplicateEntity_CrtDeduplicationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ESDuplicateEntity_CrtDeduplicationEventsProcess";
			SchemaUId = new Guid("cd1c811c-c9d9-401b-be0e-daea14f97215");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("cd1c811c-c9d9-401b-be0e-daea14f97215");
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

	#region Class: ESDuplicateEntity_CrtDeduplicationEventsProcess

	/// <exclude/>
	public class ESDuplicateEntity_CrtDeduplicationEventsProcess : ESDuplicateEntity_CrtDeduplicationEventsProcess<ESDuplicateEntity>
	{

		public ESDuplicateEntity_CrtDeduplicationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ESDuplicateEntity_CrtDeduplicationEventsProcess

	public partial class ESDuplicateEntity_CrtDeduplicationEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ESDuplicateEntityEventsProcess

	/// <exclude/>
	public class ESDuplicateEntityEventsProcess : ESDuplicateEntity_CrtDeduplicationEventsProcess
	{

		public ESDuplicateEntityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

