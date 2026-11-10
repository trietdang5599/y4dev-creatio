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

	#region Class: SysLookupSearchColumnSchema

	/// <exclude/>
	public class SysLookupSearchColumnSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysLookupSearchColumnSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysLookupSearchColumnSchema(SysLookupSearchColumnSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysLookupSearchColumnSchema(SysLookupSearchColumnSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("91353b2b-6f92-4ad2-bfa1-bda3b93bd690");
			RealUId = new Guid("91353b2b-6f92-4ad2-bfa1-bda3b93bd690");
			Name = "SysLookupSearchColumn";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("dfcb0d52-6d2f-499f-aedd-f189dd4db0dc")) == null) {
				Columns.Add(CreateSysLookupColumn());
			}
			if (Columns.FindByUId(new Guid("e7138fd6-89b1-4aab-9838-8f7b33e8633f")) == null) {
				Columns.Add(CreateMetaPathColumn());
			}
			if (Columns.FindByUId(new Guid("20e6666c-a813-49ed-b4ac-f927f9936d2b")) == null) {
				Columns.Add(CreatePositionColumn());
			}
			if (Columns.FindByUId(new Guid("f0ef986d-aa55-4583-a24e-9331b41526b5")) == null) {
				Columns.Add(CreateMetaCaptionColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysLookupColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("dfcb0d52-6d2f-499f-aedd-f189dd4db0dc"),
				Name = @"SysLookup",
				ReferenceSchemaUId = new Guid("aa3cc352-3095-43c9-ace8-6301f50a0a80"),
				IsCascade = true,
				CreatedInSchemaUId = new Guid("91353b2b-6f92-4ad2-bfa1-bda3b93bd690"),
				ModifiedInSchemaUId = new Guid("91353b2b-6f92-4ad2-bfa1-bda3b93bd690"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c")
			};
		}

		protected virtual EntitySchemaColumn CreateMetaPathColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("e7138fd6-89b1-4aab-9838-8f7b33e8633f"),
				Name = @"MetaPath",
				CreatedInSchemaUId = new Guid("91353b2b-6f92-4ad2-bfa1-bda3b93bd690"),
				ModifiedInSchemaUId = new Guid("91353b2b-6f92-4ad2-bfa1-bda3b93bd690"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c")
			};
		}

		protected virtual EntitySchemaColumn CreatePositionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("20e6666c-a813-49ed-b4ac-f927f9936d2b"),
				Name = @"Position",
				CreatedInSchemaUId = new Guid("91353b2b-6f92-4ad2-bfa1-bda3b93bd690"),
				ModifiedInSchemaUId = new Guid("91353b2b-6f92-4ad2-bfa1-bda3b93bd690"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c")
			};
		}

		protected virtual EntitySchemaColumn CreateMetaCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("f0ef986d-aa55-4583-a24e-9331b41526b5"),
				Name = @"MetaCaption",
				CreatedInSchemaUId = new Guid("91353b2b-6f92-4ad2-bfa1-bda3b93bd690"),
				ModifiedInSchemaUId = new Guid("91353b2b-6f92-4ad2-bfa1-bda3b93bd690"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysLookupSearchColumn(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysLookupSearchColumn_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysLookupSearchColumnSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysLookupSearchColumnSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("91353b2b-6f92-4ad2-bfa1-bda3b93bd690"));
		}

		#endregion

	}

	#endregion

	#region Class: SysLookupSearchColumn

	/// <summary>
	/// Columns for search in lookup.
	/// </summary>
	public class SysLookupSearchColumn : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysLookupSearchColumn(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysLookupSearchColumn";
		}

		public SysLookupSearchColumn(SysLookupSearchColumn source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SysLookupId {
			get {
				return GetTypedColumnValue<Guid>("SysLookupId");
			}
			set {
				SetColumnValue("SysLookupId", value);
				_sysLookup = null;
			}
		}

		/// <exclude/>
		public string SysLookupName {
			get {
				return GetTypedColumnValue<string>("SysLookupName");
			}
			set {
				SetColumnValue("SysLookupName", value);
				if (_sysLookup != null) {
					_sysLookup.Name = value;
				}
			}
		}

		private SysLookup _sysLookup;
		/// <summary>
		/// Lookup.
		/// </summary>
		public SysLookup SysLookup {
			get {
				return _sysLookup ??
					(_sysLookup = LookupColumnEntities.GetEntity("SysLookup") as SysLookup);
			}
		}

		/// <summary>
		/// Column.
		/// </summary>
		public string MetaPath {
			get {
				return GetTypedColumnValue<string>("MetaPath");
			}
			set {
				SetColumnValue("MetaPath", value);
			}
		}

		/// <summary>
		/// Position.
		/// </summary>
		public int Position {
			get {
				return GetTypedColumnValue<int>("Position");
			}
			set {
				SetColumnValue("Position", value);
			}
		}

		/// <summary>
		/// Column name.
		/// </summary>
		public string MetaCaption {
			get {
				return GetTypedColumnValue<string>("MetaCaption");
			}
			set {
				SetColumnValue("MetaCaption", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysLookupSearchColumn_CrtBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysLookupSearchColumnDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysLookupSearchColumnDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysLookupSearchColumnInserted", e);
			Inserting += (s, e) => ThrowEvent("SysLookupSearchColumnInserting", e);
			Saved += (s, e) => ThrowEvent("SysLookupSearchColumnSaved", e);
			Saving += (s, e) => ThrowEvent("SysLookupSearchColumnSaving", e);
			Validating += (s, e) => ThrowEvent("SysLookupSearchColumnValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysLookupSearchColumn(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysLookupSearchColumn_CrtBaseEventsProcess

	/// <exclude/>
	public partial class SysLookupSearchColumn_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysLookupSearchColumn
	{

		public SysLookupSearchColumn_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysLookupSearchColumn_CrtBaseEventsProcess";
			SchemaUId = new Guid("91353b2b-6f92-4ad2-bfa1-bda3b93bd690");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("91353b2b-6f92-4ad2-bfa1-bda3b93bd690");
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

	#region Class: SysLookupSearchColumn_CrtBaseEventsProcess

	/// <exclude/>
	public class SysLookupSearchColumn_CrtBaseEventsProcess : SysLookupSearchColumn_CrtBaseEventsProcess<SysLookupSearchColumn>
	{

		public SysLookupSearchColumn_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysLookupSearchColumn_CrtBaseEventsProcess

	public partial class SysLookupSearchColumn_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysLookupSearchColumnEventsProcess

	/// <exclude/>
	public class SysLookupSearchColumnEventsProcess : SysLookupSearchColumn_CrtBaseEventsProcess
	{

		public SysLookupSearchColumnEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

