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

	#region Class: EntityEditPagesUITypesSchema

	/// <exclude/>
	public class EntityEditPagesUITypesSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public EntityEditPagesUITypesSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public EntityEditPagesUITypesSchema(EntityEditPagesUITypesSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public EntityEditPagesUITypesSchema(EntityEditPagesUITypesSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateEntitySchemaNameIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = true
			};
			index.UId = new Guid("b361841f-5ea7-41db-bd8d-256254c5838a");
			index.Name = "EntitySchemaName";
			index.CreatedInSchemaUId = new Guid("153c5bc4-7e41-4ab5-91b6-0a54a3075b96");
			index.ModifiedInSchemaUId = new Guid("153c5bc4-7e41-4ab5-91b6-0a54a3075b96");
			index.CreatedInPackageId = new Guid("a9901a66-d58b-42c5-b270-d8f44a8fd449");
			EntitySchemaIndexColumn entitySchemaNameIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("c420b5ab-593e-89d1-830a-c22dd9ae8ed5"),
				ColumnUId = new Guid("31b1777e-9ef5-03fa-e2ed-7194499154d0"),
				CreatedInSchemaUId = new Guid("153c5bc4-7e41-4ab5-91b6-0a54a3075b96"),
				ModifiedInSchemaUId = new Guid("153c5bc4-7e41-4ab5-91b6-0a54a3075b96"),
				CreatedInPackageId = new Guid("a9901a66-d58b-42c5-b270-d8f44a8fd449"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(entitySchemaNameIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("153c5bc4-7e41-4ab5-91b6-0a54a3075b96");
			RealUId = new Guid("153c5bc4-7e41-4ab5-91b6-0a54a3075b96");
			Name = "EntityEditPagesUITypes";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("cfb40756-6398-4eeb-936f-d3fcb2d92010");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = false;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateEntitySchemaNameColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("ca44f8a6-408c-32e1-800d-e2c32171f38c")) == null) {
				Columns.Add(CreateEXTColumn());
			}
			if (Columns.FindByUId(new Guid("0138a065-5152-54be-0e75-e868e2f2aa01")) == null) {
				Columns.Add(CreateFreedomColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateEXTColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ca44f8a6-408c-32e1-800d-e2c32171f38c"),
				Name = @"EXT",
				ReferenceSchemaUId = new Guid("f3a7bafb-bf85-4726-a929-191f14b63d45"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("153c5bc4-7e41-4ab5-91b6-0a54a3075b96"),
				ModifiedInSchemaUId = new Guid("153c5bc4-7e41-4ab5-91b6-0a54a3075b96"),
				CreatedInPackageId = new Guid("cfb40756-6398-4eeb-936f-d3fcb2d92010"),
				IsSimpleLookup = true,
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"d823260d-75be-44ee-8e3a-669bb83a5ce4"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateFreedomColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("0138a065-5152-54be-0e75-e868e2f2aa01"),
				Name = @"Freedom",
				ReferenceSchemaUId = new Guid("f3a7bafb-bf85-4726-a929-191f14b63d45"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("153c5bc4-7e41-4ab5-91b6-0a54a3075b96"),
				ModifiedInSchemaUId = new Guid("153c5bc4-7e41-4ab5-91b6-0a54a3075b96"),
				CreatedInPackageId = new Guid("cfb40756-6398-4eeb-936f-d3fcb2d92010"),
				IsSimpleLookup = true,
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"f4d757e1-2aeb-496f-b751-3d5b39708ea3"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateEntitySchemaNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("31b1777e-9ef5-03fa-e2ed-7194499154d0"),
				Name = @"EntitySchemaName",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("153c5bc4-7e41-4ab5-91b6-0a54a3075b96"),
				ModifiedInSchemaUId = new Guid("153c5bc4-7e41-4ab5-91b6-0a54a3075b96"),
				CreatedInPackageId = new Guid("cfb40756-6398-4eeb-936f-d3fcb2d92010"),
				IsFormatValidated = true
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateEntitySchemaNameIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new EntityEditPagesUITypes(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new EntityEditPagesUITypes_CrtNUIEventsProcess(userConnection);
		}

		public override object Clone() {
			return new EntityEditPagesUITypesSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new EntityEditPagesUITypesSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("153c5bc4-7e41-4ab5-91b6-0a54a3075b96"));
		}

		#endregion

	}

	#endregion

	#region Class: EntityEditPagesUITypes

	/// <summary>
	/// Edit pages in UIs by object.
	/// </summary>
	public class EntityEditPagesUITypes : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public EntityEditPagesUITypes(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "EntityEditPagesUITypes";
		}

		public EntityEditPagesUITypes(EntityEditPagesUITypes source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid EXTId {
			get {
				return GetTypedColumnValue<Guid>("EXTId");
			}
			set {
				SetColumnValue("EXTId", value);
				_eXT = null;
			}
		}

		/// <exclude/>
		public string EXTName {
			get {
				return GetTypedColumnValue<string>("EXTName");
			}
			set {
				SetColumnValue("EXTName", value);
				if (_eXT != null) {
					_eXT.Name = value;
				}
			}
		}

		private UIType _eXT;
		/// <summary>
		/// Classic UI shell.
		/// </summary>
		public UIType EXT {
			get {
				return _eXT ??
					(_eXT = LookupColumnEntities.GetEntity("EXT") as UIType);
			}
		}

		/// <exclude/>
		public Guid FreedomId {
			get {
				return GetTypedColumnValue<Guid>("FreedomId");
			}
			set {
				SetColumnValue("FreedomId", value);
				_freedom = null;
			}
		}

		/// <exclude/>
		public string FreedomName {
			get {
				return GetTypedColumnValue<string>("FreedomName");
			}
			set {
				SetColumnValue("FreedomName", value);
				if (_freedom != null) {
					_freedom.Name = value;
				}
			}
		}

		private UIType _freedom;
		/// <summary>
		/// Freedom UI shell.
		/// </summary>
		public UIType Freedom {
			get {
				return _freedom ??
					(_freedom = LookupColumnEntities.GetEntity("Freedom") as UIType);
			}
		}

		/// <summary>
		/// Object code.
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
			var process = new EntityEditPagesUITypes_CrtNUIEventsProcess(UserConnection);
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
			return new EntityEditPagesUITypes(this);
		}

		#endregion

	}

	#endregion

	#region Class: EntityEditPagesUITypes_CrtNUIEventsProcess

	/// <exclude/>
	public partial class EntityEditPagesUITypes_CrtNUIEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : EntityEditPagesUITypes
	{

		public EntityEditPagesUITypes_CrtNUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "EntityEditPagesUITypes_CrtNUIEventsProcess";
			SchemaUId = new Guid("153c5bc4-7e41-4ab5-91b6-0a54a3075b96");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("153c5bc4-7e41-4ab5-91b6-0a54a3075b96");
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

	#region Class: EntityEditPagesUITypes_CrtNUIEventsProcess

	/// <exclude/>
	public class EntityEditPagesUITypes_CrtNUIEventsProcess : EntityEditPagesUITypes_CrtNUIEventsProcess<EntityEditPagesUITypes>
	{

		public EntityEditPagesUITypes_CrtNUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: EntityEditPagesUITypes_CrtNUIEventsProcess

	public partial class EntityEditPagesUITypes_CrtNUIEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: EntityEditPagesUITypesEventsProcess

	/// <exclude/>
	public class EntityEditPagesUITypesEventsProcess : EntityEditPagesUITypes_CrtNUIEventsProcess
	{

		public EntityEditPagesUITypesEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

