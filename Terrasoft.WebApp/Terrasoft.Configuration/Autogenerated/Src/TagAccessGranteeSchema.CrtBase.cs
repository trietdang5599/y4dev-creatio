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

	#region Class: TagAccessGranteeSchema

	/// <exclude/>
	public class TagAccessGranteeSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public TagAccessGranteeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public TagAccessGranteeSchema(TagAccessGranteeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public TagAccessGranteeSchema(TagAccessGranteeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("2e22405c-0d87-4f4f-aa68-684d1ab99820");
			RealUId = new Guid("2e22405c-0d87-4f4f-aa68-684d1ab99820");
			Name = "TagAccessGrantee";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = false;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("b352ae9e-a455-8e75-b59d-ea258208f675")) == null) {
				Columns.Add(CreateSysAdminUnitColumn());
			}
			if (Columns.FindByUId(new Guid("48f40fd8-0da3-c530-1c01-be6610fbf822")) == null) {
				Columns.Add(CreateTagAccessColumn());
			}
			if (Columns.FindByUId(new Guid("5dd37048-048e-6298-3e5c-55298ddf0ddf")) == null) {
				Columns.Add(CreateCanTagColumn());
			}
			if (Columns.FindByUId(new Guid("152caade-4d1c-ceed-ed10-3d42c45f9240")) == null) {
				Columns.Add(CreateCanCreateColumn());
			}
			if (Columns.FindByUId(new Guid("19fbc7bb-c040-f170-f43a-b812b957df48")) == null) {
				Columns.Add(CreateCanDeleteColumn());
			}
			if (Columns.FindByUId(new Guid("898109e6-f4a5-7159-1bf2-2d7967a7b5f6")) == null) {
				Columns.Add(CreateCanEditColumn());
			}
			if (Columns.FindByUId(new Guid("ec7f2b32-b6a8-80d0-94af-fe78b95011b1")) == null) {
				Columns.Add(CreateCanReadColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysAdminUnitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("b352ae9e-a455-8e75-b59d-ea258208f675"),
				Name = @"SysAdminUnit",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("2e22405c-0d87-4f4f-aa68-684d1ab99820"),
				ModifiedInSchemaUId = new Guid("2e22405c-0d87-4f4f-aa68-684d1ab99820"),
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723")
			};
		}

		protected virtual EntitySchemaColumn CreateTagAccessColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("48f40fd8-0da3-c530-1c01-be6610fbf822"),
				Name = @"TagAccess",
				ReferenceSchemaUId = new Guid("1fc1e003-8083-44da-ba4b-7b77186968e0"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("2e22405c-0d87-4f4f-aa68-684d1ab99820"),
				ModifiedInSchemaUId = new Guid("2e22405c-0d87-4f4f-aa68-684d1ab99820"),
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723")
			};
		}

		protected virtual EntitySchemaColumn CreateCanTagColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("5dd37048-048e-6298-3e5c-55298ddf0ddf"),
				Name = @"CanTag",
				CreatedInSchemaUId = new Guid("2e22405c-0d87-4f4f-aa68-684d1ab99820"),
				ModifiedInSchemaUId = new Guid("2e22405c-0d87-4f4f-aa68-684d1ab99820"),
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"True"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateCanCreateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("152caade-4d1c-ceed-ed10-3d42c45f9240"),
				Name = @"CanCreate",
				CreatedInSchemaUId = new Guid("2e22405c-0d87-4f4f-aa68-684d1ab99820"),
				ModifiedInSchemaUId = new Guid("2e22405c-0d87-4f4f-aa68-684d1ab99820"),
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"True"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateCanDeleteColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("19fbc7bb-c040-f170-f43a-b812b957df48"),
				Name = @"CanDelete",
				CreatedInSchemaUId = new Guid("2e22405c-0d87-4f4f-aa68-684d1ab99820"),
				ModifiedInSchemaUId = new Guid("2e22405c-0d87-4f4f-aa68-684d1ab99820"),
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"True"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateCanEditColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("898109e6-f4a5-7159-1bf2-2d7967a7b5f6"),
				Name = @"CanEdit",
				CreatedInSchemaUId = new Guid("2e22405c-0d87-4f4f-aa68-684d1ab99820"),
				ModifiedInSchemaUId = new Guid("2e22405c-0d87-4f4f-aa68-684d1ab99820"),
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"True"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateCanReadColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("ec7f2b32-b6a8-80d0-94af-fe78b95011b1"),
				Name = @"CanRead",
				CreatedInSchemaUId = new Guid("2e22405c-0d87-4f4f-aa68-684d1ab99820"),
				ModifiedInSchemaUId = new Guid("2e22405c-0d87-4f4f-aa68-684d1ab99820"),
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723"),
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
			return new TagAccessGrantee(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new TagAccessGrantee_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new TagAccessGranteeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new TagAccessGranteeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2e22405c-0d87-4f4f-aa68-684d1ab99820"));
		}

		#endregion

	}

	#endregion

	#region Class: TagAccessGrantee

	/// <summary>
	/// Access to tag grantee.
	/// </summary>
	public class TagAccessGrantee : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public TagAccessGrantee(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "TagAccessGrantee";
		}

		public TagAccessGrantee(TagAccessGrantee source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SysAdminUnitId {
			get {
				return GetTypedColumnValue<Guid>("SysAdminUnitId");
			}
			set {
				SetColumnValue("SysAdminUnitId", value);
				_sysAdminUnit = null;
			}
		}

		/// <exclude/>
		public string SysAdminUnitName {
			get {
				return GetTypedColumnValue<string>("SysAdminUnitName");
			}
			set {
				SetColumnValue("SysAdminUnitName", value);
				if (_sysAdminUnit != null) {
					_sysAdminUnit.Name = value;
				}
			}
		}

		private SysAdminUnit _sysAdminUnit;
		/// <summary>
		/// System administration object.
		/// </summary>
		public SysAdminUnit SysAdminUnit {
			get {
				return _sysAdminUnit ??
					(_sysAdminUnit = LookupColumnEntities.GetEntity("SysAdminUnit") as SysAdminUnit);
			}
		}

		/// <exclude/>
		public Guid TagAccessId {
			get {
				return GetTypedColumnValue<Guid>("TagAccessId");
			}
			set {
				SetColumnValue("TagAccessId", value);
				_tagAccess = null;
			}
		}

		/// <exclude/>
		public string TagAccessName {
			get {
				return GetTypedColumnValue<string>("TagAccessName");
			}
			set {
				SetColumnValue("TagAccessName", value);
				if (_tagAccess != null) {
					_tagAccess.Name = value;
				}
			}
		}

		private TagAccess _tagAccess;
		/// <summary>
		/// Access to tag.
		/// </summary>
		public TagAccess TagAccess {
			get {
				return _tagAccess ??
					(_tagAccess = LookupColumnEntities.GetEntity("TagAccess") as TagAccess);
			}
		}

		/// <summary>
		/// Tagging.
		/// </summary>
		public bool CanTag {
			get {
				return GetTypedColumnValue<bool>("CanTag");
			}
			set {
				SetColumnValue("CanTag", value);
			}
		}

		/// <summary>
		/// Create.
		/// </summary>
		public bool CanCreate {
			get {
				return GetTypedColumnValue<bool>("CanCreate");
			}
			set {
				SetColumnValue("CanCreate", value);
			}
		}

		/// <summary>
		/// Delete.
		/// </summary>
		public bool CanDelete {
			get {
				return GetTypedColumnValue<bool>("CanDelete");
			}
			set {
				SetColumnValue("CanDelete", value);
			}
		}

		/// <summary>
		/// Edit.
		/// </summary>
		public bool CanEdit {
			get {
				return GetTypedColumnValue<bool>("CanEdit");
			}
			set {
				SetColumnValue("CanEdit", value);
			}
		}

		/// <summary>
		/// Read.
		/// </summary>
		public bool CanRead {
			get {
				return GetTypedColumnValue<bool>("CanRead");
			}
			set {
				SetColumnValue("CanRead", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new TagAccessGrantee_CrtBaseEventsProcess(UserConnection);
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
			return new TagAccessGrantee(this);
		}

		#endregion

	}

	#endregion

	#region Class: TagAccessGrantee_CrtBaseEventsProcess

	/// <exclude/>
	public partial class TagAccessGrantee_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : TagAccessGrantee
	{

		public TagAccessGrantee_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "TagAccessGrantee_CrtBaseEventsProcess";
			SchemaUId = new Guid("2e22405c-0d87-4f4f-aa68-684d1ab99820");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("2e22405c-0d87-4f4f-aa68-684d1ab99820");
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

	#region Class: TagAccessGrantee_CrtBaseEventsProcess

	/// <exclude/>
	public class TagAccessGrantee_CrtBaseEventsProcess : TagAccessGrantee_CrtBaseEventsProcess<TagAccessGrantee>
	{

		public TagAccessGrantee_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: TagAccessGrantee_CrtBaseEventsProcess

	public partial class TagAccessGrantee_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: TagAccessGranteeEventsProcess

	/// <exclude/>
	public class TagAccessGranteeEventsProcess : TagAccessGrantee_CrtBaseEventsProcess
	{

		public TagAccessGranteeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

