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

	#region Class: SysCspUsrSrcInDirectvSchema

	/// <exclude/>
	public class SysCspUsrSrcInDirectvSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysCspUsrSrcInDirectvSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysCspUsrSrcInDirectvSchema(SysCspUsrSrcInDirectvSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysCspUsrSrcInDirectvSchema(SysCspUsrSrcInDirectvSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0c11bdf1-22aa-431a-90db-cf6e2d34ba0d");
			RealUId = new Guid("0c11bdf1-22aa-431a-90db-cf6e2d34ba0d");
			Name = "SysCspUsrSrcInDirectv";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("dbae63b3-eab2-4127-8e3e-deebbfbf14cd");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = false;
			UseLiveEditing = true;
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
			if (Columns.FindByUId(new Guid("6450bb25-1f34-aa31-0a4d-a3312837e2eb")) == null) {
				Columns.Add(CreateCspUserTrustedSourceColumn());
			}
			if (Columns.FindByUId(new Guid("c7328a14-e19f-b711-1b16-8b6776f7e3d1")) == null) {
				Columns.Add(CreateCspDirectiveNameColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCspUserTrustedSourceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("6450bb25-1f34-aa31-0a4d-a3312837e2eb"),
				Name = @"CspUserTrustedSource",
				ReferenceSchemaUId = new Guid("c42f486b-5b2e-4a87-832b-da62372fadeb"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("0c11bdf1-22aa-431a-90db-cf6e2d34ba0d"),
				ModifiedInSchemaUId = new Guid("0c11bdf1-22aa-431a-90db-cf6e2d34ba0d"),
				CreatedInPackageId = new Guid("dbae63b3-eab2-4127-8e3e-deebbfbf14cd")
			};
		}

		protected virtual EntitySchemaColumn CreateCspDirectiveNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("c7328a14-e19f-b711-1b16-8b6776f7e3d1"),
				Name = @"CspDirectiveName",
				ReferenceSchemaUId = new Guid("6f41fcd7-41d1-412d-bb4c-30ef57b00e5e"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("0c11bdf1-22aa-431a-90db-cf6e2d34ba0d"),
				ModifiedInSchemaUId = new Guid("0c11bdf1-22aa-431a-90db-cf6e2d34ba0d"),
				CreatedInPackageId = new Guid("dbae63b3-eab2-4127-8e3e-deebbfbf14cd")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysCspUsrSrcInDirectv(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysCspUsrSrcInDirectv_CSPEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysCspUsrSrcInDirectvSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysCspUsrSrcInDirectvSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0c11bdf1-22aa-431a-90db-cf6e2d34ba0d"));
		}

		#endregion

	}

	#endregion

	#region Class: SysCspUsrSrcInDirectv

	/// <summary>
	/// Trusted source in directive.
	/// </summary>
	public class SysCspUsrSrcInDirectv : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysCspUsrSrcInDirectv(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysCspUsrSrcInDirectv";
		}

		public SysCspUsrSrcInDirectv(SysCspUsrSrcInDirectv source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid CspUserTrustedSourceId {
			get {
				return GetTypedColumnValue<Guid>("CspUserTrustedSourceId");
			}
			set {
				SetColumnValue("CspUserTrustedSourceId", value);
				_cspUserTrustedSource = null;
			}
		}

		/// <exclude/>
		public string CspUserTrustedSourceSource {
			get {
				return GetTypedColumnValue<string>("CspUserTrustedSourceSource");
			}
			set {
				SetColumnValue("CspUserTrustedSourceSource", value);
				if (_cspUserTrustedSource != null) {
					_cspUserTrustedSource.Source = value;
				}
			}
		}

		private SysCspUserTrustedSrc _cspUserTrustedSource;
		/// <summary>
		/// Trusted source.
		/// </summary>
		public SysCspUserTrustedSrc CspUserTrustedSource {
			get {
				return _cspUserTrustedSource ??
					(_cspUserTrustedSource = LookupColumnEntities.GetEntity("CspUserTrustedSource") as SysCspUserTrustedSrc);
			}
		}

		/// <exclude/>
		public Guid CspDirectiveNameId {
			get {
				return GetTypedColumnValue<Guid>("CspDirectiveNameId");
			}
			set {
				SetColumnValue("CspDirectiveNameId", value);
				_cspDirectiveName = null;
			}
		}

		/// <exclude/>
		public string CspDirectiveNameName {
			get {
				return GetTypedColumnValue<string>("CspDirectiveNameName");
			}
			set {
				SetColumnValue("CspDirectiveNameName", value);
				if (_cspDirectiveName != null) {
					_cspDirectiveName.Name = value;
				}
			}
		}

		private SysCspDirectiveName _cspDirectiveName;
		/// <summary>
		/// Directive.
		/// </summary>
		public SysCspDirectiveName CspDirectiveName {
			get {
				return _cspDirectiveName ??
					(_cspDirectiveName = LookupColumnEntities.GetEntity("CspDirectiveName") as SysCspDirectiveName);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysCspUsrSrcInDirectv_CSPEventsProcess(UserConnection);
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
			return new SysCspUsrSrcInDirectv(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysCspUsrSrcInDirectv_CSPEventsProcess

	/// <exclude/>
	public partial class SysCspUsrSrcInDirectv_CSPEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysCspUsrSrcInDirectv
	{

		public SysCspUsrSrcInDirectv_CSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysCspUsrSrcInDirectv_CSPEventsProcess";
			SchemaUId = new Guid("0c11bdf1-22aa-431a-90db-cf6e2d34ba0d");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("0c11bdf1-22aa-431a-90db-cf6e2d34ba0d");
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

	#region Class: SysCspUsrSrcInDirectv_CSPEventsProcess

	/// <exclude/>
	public class SysCspUsrSrcInDirectv_CSPEventsProcess : SysCspUsrSrcInDirectv_CSPEventsProcess<SysCspUsrSrcInDirectv>
	{

		public SysCspUsrSrcInDirectv_CSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysCspUsrSrcInDirectv_CSPEventsProcess

	public partial class SysCspUsrSrcInDirectv_CSPEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysCspUsrSrcInDirectvEventsProcess

	/// <exclude/>
	public class SysCspUsrSrcInDirectvEventsProcess : SysCspUsrSrcInDirectv_CSPEventsProcess
	{

		public SysCspUsrSrcInDirectvEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

