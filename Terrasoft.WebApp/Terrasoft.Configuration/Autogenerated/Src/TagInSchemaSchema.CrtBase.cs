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

	#region Class: TagInSchemaSchema

	/// <exclude/>
	public class TagInSchemaSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public TagInSchemaSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public TagInSchemaSchema(TagInSchemaSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public TagInSchemaSchema(TagInSchemaSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("2eec542d-573b-4f08-a481-3c5dfbfe4da7");
			RealUId = new Guid("2eec542d-573b-4f08-a481-3c5dfbfe4da7");
			Name = "TagInSchema";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("4d8362de-2c78-4645-bbfb-2bade80768b8");
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
			if (Columns.FindByUId(new Guid("24cd6f4f-3dee-00b0-aa16-c92718056bac")) == null) {
				Columns.Add(CreateEntitySchemaNameColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateTagColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("fb0c7c11-32c5-232e-2df7-bdd7bafafc46"),
				Name = @"Tag",
				ReferenceSchemaUId = new Guid("1e5969aa-6901-40af-ac78-b141dd322235"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("2eec542d-573b-4f08-a481-3c5dfbfe4da7"),
				ModifiedInSchemaUId = new Guid("2eec542d-573b-4f08-a481-3c5dfbfe4da7"),
				CreatedInPackageId = new Guid("4d8362de-2c78-4645-bbfb-2bade80768b8"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateEntitySchemaNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("24cd6f4f-3dee-00b0-aa16-c92718056bac"),
				Name = @"EntitySchemaName",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("2eec542d-573b-4f08-a481-3c5dfbfe4da7"),
				ModifiedInSchemaUId = new Guid("2eec542d-573b-4f08-a481-3c5dfbfe4da7"),
				CreatedInPackageId = new Guid("4d8362de-2c78-4645-bbfb-2bade80768b8")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new TagInSchema(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new TagInSchema_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new TagInSchemaSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new TagInSchemaSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2eec542d-573b-4f08-a481-3c5dfbfe4da7"));
		}

		#endregion

	}

	#endregion

	#region Class: TagInSchema

	/// <summary>
	/// Tag in schema.
	/// </summary>
	public class TagInSchema : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public TagInSchema(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "TagInSchema";
		}

		public TagInSchema(TagInSchema source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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
			var process = new TagInSchema_CrtBaseEventsProcess(UserConnection);
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
			return new TagInSchema(this);
		}

		#endregion

	}

	#endregion

	#region Class: TagInSchema_CrtBaseEventsProcess

	/// <exclude/>
	public partial class TagInSchema_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : TagInSchema
	{

		public TagInSchema_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "TagInSchema_CrtBaseEventsProcess";
			SchemaUId = new Guid("2eec542d-573b-4f08-a481-3c5dfbfe4da7");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("2eec542d-573b-4f08-a481-3c5dfbfe4da7");
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

	#region Class: TagInSchema_CrtBaseEventsProcess

	/// <exclude/>
	public class TagInSchema_CrtBaseEventsProcess : TagInSchema_CrtBaseEventsProcess<TagInSchema>
	{

		public TagInSchema_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: TagInSchema_CrtBaseEventsProcess

	public partial class TagInSchema_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: TagInSchemaEventsProcess

	/// <exclude/>
	public class TagInSchemaEventsProcess : TagInSchema_CrtBaseEventsProcess
	{

		public TagInSchemaEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

