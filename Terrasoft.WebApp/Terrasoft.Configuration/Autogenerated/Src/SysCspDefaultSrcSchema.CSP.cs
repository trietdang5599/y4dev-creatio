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

	#region Class: SysCspDefaultSrcSchema

	/// <exclude/>
	public class SysCspDefaultSrcSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysCspDefaultSrcSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysCspDefaultSrcSchema(SysCspDefaultSrcSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysCspDefaultSrcSchema(SysCspDefaultSrcSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ee4b8399-a61a-460d-a6fa-af29171c4262");
			RealUId = new Guid("ee4b8399-a61a-460d-a6fa-af29171c4262");
			Name = "SysCspDefaultSrc";
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
			TrackChangesSchemaName = @"SysCspDefaultSrcLog";
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateSourceColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("51fbde5b-4ab3-42da-2837-27e54da5ff8c")) == null) {
				Columns.Add(CreateActiveColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSourceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("564234ce-b152-58b2-22cc-76a0168c045b"),
				Name = @"Source",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("ee4b8399-a61a-460d-a6fa-af29171c4262"),
				ModifiedInSchemaUId = new Guid("ee4b8399-a61a-460d-a6fa-af29171c4262"),
				CreatedInPackageId = new Guid("f6147369-2235-4333-9a9c-5ab3c877b226"),
				IsTrackChangesInDB = true
			};
		}

		protected virtual EntitySchemaColumn CreateActiveColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("51fbde5b-4ab3-42da-2837-27e54da5ff8c"),
				Name = @"Active",
				CreatedInSchemaUId = new Guid("ee4b8399-a61a-460d-a6fa-af29171c4262"),
				ModifiedInSchemaUId = new Guid("ee4b8399-a61a-460d-a6fa-af29171c4262"),
				CreatedInPackageId = new Guid("f6147369-2235-4333-9a9c-5ab3c877b226"),
				IsTrackChangesInDB = true,
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"True"
				}
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysCspDefaultSrc(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysCspDefaultSrc_CSPEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysCspDefaultSrcSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysCspDefaultSrcSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ee4b8399-a61a-460d-a6fa-af29171c4262"));
		}

		#endregion

	}

	#endregion

	#region Class: SysCspDefaultSrc

	/// <summary>
	/// CSP default sources.
	/// </summary>
	public class SysCspDefaultSrc : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysCspDefaultSrc(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysCspDefaultSrc";
		}

		public SysCspDefaultSrc(SysCspDefaultSrc source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Source.
		/// </summary>
		public string Source {
			get {
				return GetTypedColumnValue<string>("Source");
			}
			set {
				SetColumnValue("Source", value);
			}
		}

		/// <summary>
		/// Active.
		/// </summary>
		public bool Active {
			get {
				return GetTypedColumnValue<bool>("Active");
			}
			set {
				SetColumnValue("Active", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysCspDefaultSrc_CSPEventsProcess(UserConnection);
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
			return new SysCspDefaultSrc(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysCspDefaultSrc_CSPEventsProcess

	/// <exclude/>
	public partial class SysCspDefaultSrc_CSPEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysCspDefaultSrc
	{

		public SysCspDefaultSrc_CSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysCspDefaultSrc_CSPEventsProcess";
			SchemaUId = new Guid("ee4b8399-a61a-460d-a6fa-af29171c4262");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ee4b8399-a61a-460d-a6fa-af29171c4262");
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

	#region Class: SysCspDefaultSrc_CSPEventsProcess

	/// <exclude/>
	public class SysCspDefaultSrc_CSPEventsProcess : SysCspDefaultSrc_CSPEventsProcess<SysCspDefaultSrc>
	{

		public SysCspDefaultSrc_CSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysCspDefaultSrc_CSPEventsProcess

	public partial class SysCspDefaultSrc_CSPEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysCspDefaultSrcEventsProcess

	/// <exclude/>
	public class SysCspDefaultSrcEventsProcess : SysCspDefaultSrc_CSPEventsProcess
	{

		public SysCspDefaultSrcEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

