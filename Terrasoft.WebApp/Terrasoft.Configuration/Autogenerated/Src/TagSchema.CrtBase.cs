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

	#region Class: TagSchema

	/// <exclude/>
	public class TagSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public TagSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public TagSchema(TagSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public TagSchema(TagSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("1e5969aa-6901-40af-ac78-b141dd322235");
			RealUId = new Guid("1e5969aa-6901-40af-ac78-b141dd322235");
			Name = "Tag";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = false;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateNameColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializePrimaryColorColumn() {
			base.InitializePrimaryColorColumn();
			PrimaryColorColumn = CreateColorColumn();
			if (Columns.FindByUId(PrimaryColorColumn.UId) == null) {
				Columns.Add(PrimaryColorColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("5d5c60a6-45df-3fe5-d342-767f7dc2187a")) == null) {
				Columns.Add(CreateTagAccessColumn());
			}
			if (Columns.FindByUId(new Guid("892d8f7d-9979-1d13-aa41-017194c72955")) == null) {
				Columns.Add(CreateEntitySchemaNameColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateColorColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Color")) {
				UId = new Guid("1aebe73a-7e5e-ec74-39ce-de9e943c7946"),
				Name = @"Color",
				CreatedInSchemaUId = new Guid("1e5969aa-6901-40af-ac78-b141dd322235"),
				ModifiedInSchemaUId = new Guid("1e5969aa-6901-40af-ac78-b141dd322235"),
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Settings,
					ValueSource = @"DefaultTagColor"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("6e1b14e5-8b97-9bfa-dee0-793f0a3316df"),
				Name = @"Name",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("1e5969aa-6901-40af-ac78-b141dd322235"),
				ModifiedInSchemaUId = new Guid("1e5969aa-6901-40af-ac78-b141dd322235"),
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723")
			};
		}

		protected virtual EntitySchemaColumn CreateTagAccessColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("5d5c60a6-45df-3fe5-d342-767f7dc2187a"),
				Name = @"TagAccess",
				ReferenceSchemaUId = new Guid("1fc1e003-8083-44da-ba4b-7b77186968e0"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("1e5969aa-6901-40af-ac78-b141dd322235"),
				ModifiedInSchemaUId = new Guid("1e5969aa-6901-40af-ac78-b141dd322235"),
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723"),
				IsSimpleLookup = true,
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"54c3c9a0-adba-423f-990b-673b903e2a38"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateEntitySchemaNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("892d8f7d-9979-1d13-aa41-017194c72955"),
				Name = @"EntitySchemaName",
				IsValueCloneable = false,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("1e5969aa-6901-40af-ac78-b141dd322235"),
				ModifiedInSchemaUId = new Guid("1e5969aa-6901-40af-ac78-b141dd322235"),
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Tag(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Tag_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new TagSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new TagSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1e5969aa-6901-40af-ac78-b141dd322235"));
		}

		#endregion

	}

	#endregion

	#region Class: Tag

	/// <summary>
	/// Tag.
	/// </summary>
	public class Tag : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public Tag(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Tag";
		}

		public Tag(Tag source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Color.
		/// </summary>
		public Color Color {
			get {
				return GetTypedColumnValue<Color>("Color");
			}
			set {
				SetColumnValue("Color", value);
			}
		}

		/// <summary>
		/// Name.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
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
		/// Entity schema name.
		/// </summary>
		public string EntitySchemaName {
			get {
				return GetTypedColumnValue<string>("EntitySchemaName");
			}
			set {
				SetColumnValue("EntitySchemaName", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Tag_CrtBaseEventsProcess(UserConnection);
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
			return new Tag(this);
		}

		#endregion

	}

	#endregion

	#region Class: Tag_CrtBaseEventsProcess

	/// <exclude/>
	public partial class Tag_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : Tag
	{

		public Tag_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Tag_CrtBaseEventsProcess";
			SchemaUId = new Guid("1e5969aa-6901-40af-ac78-b141dd322235");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("1e5969aa-6901-40af-ac78-b141dd322235");
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

	#region Class: Tag_CrtBaseEventsProcess

	/// <exclude/>
	public class Tag_CrtBaseEventsProcess : Tag_CrtBaseEventsProcess<Tag>
	{

		public Tag_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Tag_CrtBaseEventsProcess

	public partial class Tag_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: TagEventsProcess

	/// <exclude/>
	public class TagEventsProcess : Tag_CrtBaseEventsProcess
	{

		public TagEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

