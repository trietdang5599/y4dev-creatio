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

	#region Class: SysCspDefSrcInDirectvSchema

	/// <exclude/>
	public class SysCspDefSrcInDirectvSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysCspDefSrcInDirectvSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysCspDefSrcInDirectvSchema(SysCspDefSrcInDirectvSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysCspDefSrcInDirectvSchema(SysCspDefSrcInDirectvSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f74332c5-0a5c-4498-b0a1-51526f162ebe");
			RealUId = new Guid("f74332c5-0a5c-4498-b0a1-51526f162ebe");
			Name = "SysCspDefSrcInDirectv";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("8a0c5ff2-0881-4762-b701-4721e25a1ed5");
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
			if (Columns.FindByUId(new Guid("e91affd4-9e19-d91f-ffba-1ec08052d0bb")) == null) {
				Columns.Add(CreateCspDefaultSourceColumn());
			}
			if (Columns.FindByUId(new Guid("5067f3a8-d50b-0786-044b-bf6455af4f1d")) == null) {
				Columns.Add(CreateCspDirectiveNameColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCspDefaultSourceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e91affd4-9e19-d91f-ffba-1ec08052d0bb"),
				Name = @"CspDefaultSource",
				ReferenceSchemaUId = new Guid("ee4b8399-a61a-460d-a6fa-af29171c4262"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("f74332c5-0a5c-4498-b0a1-51526f162ebe"),
				ModifiedInSchemaUId = new Guid("f74332c5-0a5c-4498-b0a1-51526f162ebe"),
				CreatedInPackageId = new Guid("8a0c5ff2-0881-4762-b701-4721e25a1ed5")
			};
		}

		protected virtual EntitySchemaColumn CreateCspDirectiveNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("5067f3a8-d50b-0786-044b-bf6455af4f1d"),
				Name = @"CspDirectiveName",
				ReferenceSchemaUId = new Guid("6f41fcd7-41d1-412d-bb4c-30ef57b00e5e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("f74332c5-0a5c-4498-b0a1-51526f162ebe"),
				ModifiedInSchemaUId = new Guid("f74332c5-0a5c-4498-b0a1-51526f162ebe"),
				CreatedInPackageId = new Guid("8a0c5ff2-0881-4762-b701-4721e25a1ed5")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysCspDefSrcInDirectv(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysCspDefSrcInDirectv_CSPEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysCspDefSrcInDirectvSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysCspDefSrcInDirectvSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f74332c5-0a5c-4498-b0a1-51526f162ebe"));
		}

		#endregion

	}

	#endregion

	#region Class: SysCspDefSrcInDirectv

	/// <summary>
	/// SysCspDefaultSourceInDirectiveName.
	/// </summary>
	public class SysCspDefSrcInDirectv : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysCspDefSrcInDirectv(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysCspDefSrcInDirectv";
		}

		public SysCspDefSrcInDirectv(SysCspDefSrcInDirectv source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid CspDefaultSourceId {
			get {
				return GetTypedColumnValue<Guid>("CspDefaultSourceId");
			}
			set {
				SetColumnValue("CspDefaultSourceId", value);
				_cspDefaultSource = null;
			}
		}

		/// <exclude/>
		public string CspDefaultSourceSource {
			get {
				return GetTypedColumnValue<string>("CspDefaultSourceSource");
			}
			set {
				SetColumnValue("CspDefaultSourceSource", value);
				if (_cspDefaultSource != null) {
					_cspDefaultSource.Source = value;
				}
			}
		}

		private SysCspDefaultSrc _cspDefaultSource;
		/// <summary>
		/// Default source.
		/// </summary>
		public SysCspDefaultSrc CspDefaultSource {
			get {
				return _cspDefaultSource ??
					(_cspDefaultSource = LookupColumnEntities.GetEntity("CspDefaultSource") as SysCspDefaultSrc);
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
		/// Directive name.
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
			var process = new SysCspDefSrcInDirectv_CSPEventsProcess(UserConnection);
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
			return new SysCspDefSrcInDirectv(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysCspDefSrcInDirectv_CSPEventsProcess

	/// <exclude/>
	public partial class SysCspDefSrcInDirectv_CSPEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysCspDefSrcInDirectv
	{

		public SysCspDefSrcInDirectv_CSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysCspDefSrcInDirectv_CSPEventsProcess";
			SchemaUId = new Guid("f74332c5-0a5c-4498-b0a1-51526f162ebe");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("f74332c5-0a5c-4498-b0a1-51526f162ebe");
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

	#region Class: SysCspDefSrcInDirectv_CSPEventsProcess

	/// <exclude/>
	public class SysCspDefSrcInDirectv_CSPEventsProcess : SysCspDefSrcInDirectv_CSPEventsProcess<SysCspDefSrcInDirectv>
	{

		public SysCspDefSrcInDirectv_CSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysCspDefSrcInDirectv_CSPEventsProcess

	public partial class SysCspDefSrcInDirectv_CSPEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysCspDefSrcInDirectvEventsProcess

	/// <exclude/>
	public class SysCspDefSrcInDirectvEventsProcess : SysCspDefSrcInDirectv_CSPEventsProcess
	{

		public SysCspDefSrcInDirectvEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

