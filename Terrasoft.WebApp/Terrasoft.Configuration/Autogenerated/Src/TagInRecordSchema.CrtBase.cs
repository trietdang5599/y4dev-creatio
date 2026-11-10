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

	#region Class: TagInRecordSchema

	/// <exclude/>
	public class TagInRecordSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public TagInRecordSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public TagInRecordSchema(TagInRecordSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public TagInRecordSchema(TagInRecordSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIUnique_RecordId_TagRecordIdIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = true
			};
			index.UId = new Guid("2f7e3bc8-ca08-4c27-952c-fa605841f78c");
			index.Name = "IUnique_RecordId_TagRecordId";
			index.CreatedInSchemaUId = new Guid("3dc43601-d0dd-4608-997a-e6990a582126");
			index.ModifiedInSchemaUId = new Guid("3dc43601-d0dd-4608-997a-e6990a582126");
			index.CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723");
			EntitySchemaIndexColumn recordIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("cfc3e0eb-8fc5-43b7-ea36-5562391a3492"),
				ColumnUId = new Guid("e35c4641-ed42-d050-ef58-12e38d9e3151"),
				CreatedInSchemaUId = new Guid("3dc43601-d0dd-4608-997a-e6990a582126"),
				ModifiedInSchemaUId = new Guid("3dc43601-d0dd-4608-997a-e6990a582126"),
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(recordIdIndexColumn);
			EntitySchemaIndexColumn tagRecordIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("bca21ab0-b44a-d8b0-dbce-6997cbd1e80e"),
				ColumnUId = new Guid("754ee985-b8a4-f230-2530-25926e8e2f0c"),
				CreatedInSchemaUId = new Guid("3dc43601-d0dd-4608-997a-e6990a582126"),
				ModifiedInSchemaUId = new Guid("3dc43601-d0dd-4608-997a-e6990a582126"),
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(tagRecordIdIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("3dc43601-d0dd-4608-997a-e6990a582126");
			RealUId = new Guid("3dc43601-d0dd-4608-997a-e6990a582126");
			Name = "TagInRecord";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = false;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeMasterRecordColumn() {
			base.InitializeMasterRecordColumn();
			MasterRecordColumn = CreateTagColumn();
			if (Columns.FindByUId(MasterRecordColumn.UId) == null) {
				Columns.Add(MasterRecordColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("5bb56c95-050e-da62-a22f-d720739fbc92")) == null) {
				Columns.Add(CreateRecordSchemaNameColumn());
			}
			if (Columns.FindByUId(new Guid("e35c4641-ed42-d050-ef58-12e38d9e3151")) == null) {
				Columns.Add(CreateRecordIdColumn());
			}
			if (Columns.FindByUId(new Guid("754ee985-b8a4-f230-2530-25926e8e2f0c")) == null) {
				Columns.Add(CreateTagRecordIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateRecordSchemaNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("5bb56c95-050e-da62-a22f-d720739fbc92"),
				Name = @"RecordSchemaName",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("3dc43601-d0dd-4608-997a-e6990a582126"),
				ModifiedInSchemaUId = new Guid("3dc43601-d0dd-4608-997a-e6990a582126"),
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723")
			};
		}

		protected virtual EntitySchemaColumn CreateTagColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("f7192f2c-14c2-7979-bf74-64daed0fd4c3"),
				Name = @"Tag",
				ReferenceSchemaUId = new Guid("1e5969aa-6901-40af-ac78-b141dd322235"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("3dc43601-d0dd-4608-997a-e6990a582126"),
				ModifiedInSchemaUId = new Guid("3dc43601-d0dd-4608-997a-e6990a582126"),
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateRecordIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("e35c4641-ed42-d050-ef58-12e38d9e3151"),
				Name = @"RecordId",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("3dc43601-d0dd-4608-997a-e6990a582126"),
				ModifiedInSchemaUId = new Guid("3dc43601-d0dd-4608-997a-e6990a582126"),
				CreatedInPackageId = new Guid("eb06010e-82d3-4c3d-868a-b0185dcaa8d1")
			};
		}

		protected virtual EntitySchemaColumn CreateTagRecordIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("754ee985-b8a4-f230-2530-25926e8e2f0c"),
				Name = @"TagRecordId",
				CreatedInSchemaUId = new Guid("3dc43601-d0dd-4608-997a-e6990a582126"),
				ModifiedInSchemaUId = new Guid("3dc43601-d0dd-4608-997a-e6990a582126"),
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIUnique_RecordId_TagRecordIdIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new TagInRecord(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new TagInRecord_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new TagInRecordSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new TagInRecordSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3dc43601-d0dd-4608-997a-e6990a582126"));
		}

		#endregion

	}

	#endregion

	#region Class: TagInRecord

	/// <summary>
	/// Tag in record.
	/// </summary>
	public class TagInRecord : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public TagInRecord(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "TagInRecord";
		}

		public TagInRecord(TagInRecord source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Record schema name.
		/// </summary>
		public string RecordSchemaName {
			get {
				return GetTypedColumnValue<string>("RecordSchemaName");
			}
			set {
				SetColumnValue("RecordSchemaName", value);
			}
		}

		/// <exclude/>
		public Guid TagId {
			get {
				return GetTypedColumnValue<Guid>("TagId");
			}
			set {
				SetColumnValue("TagId", value);
				_tag = null;
			}
		}

		/// <exclude/>
		public string TagName {
			get {
				return GetTypedColumnValue<string>("TagName");
			}
			set {
				SetColumnValue("TagName", value);
				if (_tag != null) {
					_tag.Name = value;
				}
			}
		}

		private Tag _tag;
		/// <summary>
		/// Tag.
		/// </summary>
		public Tag Tag {
			get {
				return _tag ??
					(_tag = LookupColumnEntities.GetEntity("Tag") as Tag);
			}
		}

		/// <summary>
		/// Record id.
		/// </summary>
		public Guid RecordId {
			get {
				return GetTypedColumnValue<Guid>("RecordId");
			}
			set {
				SetColumnValue("RecordId", value);
			}
		}

		/// <summary>
		/// Tag record id.
		/// </summary>
		public Guid TagRecordId {
			get {
				return GetTypedColumnValue<Guid>("TagRecordId");
			}
			set {
				SetColumnValue("TagRecordId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new TagInRecord_CrtBaseEventsProcess(UserConnection);
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
			return new TagInRecord(this);
		}

		#endregion

	}

	#endregion

	#region Class: TagInRecord_CrtBaseEventsProcess

	/// <exclude/>
	public partial class TagInRecord_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : TagInRecord
	{

		public TagInRecord_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "TagInRecord_CrtBaseEventsProcess";
			SchemaUId = new Guid("3dc43601-d0dd-4608-997a-e6990a582126");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("3dc43601-d0dd-4608-997a-e6990a582126");
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

	#region Class: TagInRecord_CrtBaseEventsProcess

	/// <exclude/>
	public class TagInRecord_CrtBaseEventsProcess : TagInRecord_CrtBaseEventsProcess<TagInRecord>
	{

		public TagInRecord_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: TagInRecord_CrtBaseEventsProcess

	public partial class TagInRecord_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: TagInRecordEventsProcess

	/// <exclude/>
	public class TagInRecordEventsProcess : TagInRecord_CrtBaseEventsProcess
	{

		public TagInRecordEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

