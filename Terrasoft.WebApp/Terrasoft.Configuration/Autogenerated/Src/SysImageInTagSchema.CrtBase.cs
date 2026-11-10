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

	#region Class: SysImageInTagSchema

	/// <exclude/>
	public class SysImageInTagSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysImageInTagSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysImageInTagSchema(SysImageInTagSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysImageInTagSchema(SysImageInTagSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0ec9b2ce-8269-4ad8-bfc2-1b64cebd222a");
			RealUId = new Guid("0ec9b2ce-8269-4ad8-bfc2-1b64cebd222a");
			Name = "SysImageInTag";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("c70416a1-d180-47d0-9b53-90527ee8764a");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("d91c10e6-ad50-7c41-6832-a27a6ea0359b")) == null) {
				Columns.Add(CreateEntityColumn());
			}
			if (Columns.FindByUId(new Guid("203d4062-bc4d-71d4-72a7-5c4cf729dd11")) == null) {
				Columns.Add(CreateTagColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateEntityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("d91c10e6-ad50-7c41-6832-a27a6ea0359b"),
				Name = @"Entity",
				ReferenceSchemaUId = new Guid("93986bfe-2dbd-46bc-9bf9-d03dfefbf3b8"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("0ec9b2ce-8269-4ad8-bfc2-1b64cebd222a"),
				ModifiedInSchemaUId = new Guid("0ec9b2ce-8269-4ad8-bfc2-1b64cebd222a"),
				CreatedInPackageId = new Guid("c70416a1-d180-47d0-9b53-90527ee8764a")
			};
		}

		protected virtual EntitySchemaColumn CreateTagColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("203d4062-bc4d-71d4-72a7-5c4cf729dd11"),
				Name = @"Tag",
				ReferenceSchemaUId = new Guid("639a7449-ad50-45ba-9b53-53adf46197ad"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("0ec9b2ce-8269-4ad8-bfc2-1b64cebd222a"),
				ModifiedInSchemaUId = new Guid("0ec9b2ce-8269-4ad8-bfc2-1b64cebd222a"),
				CreatedInPackageId = new Guid("c70416a1-d180-47d0-9b53-90527ee8764a")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysImageInTag(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysImageInTag_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysImageInTagSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysImageInTagSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0ec9b2ce-8269-4ad8-bfc2-1b64cebd222a"));
		}

		#endregion

	}

	#endregion

	#region Class: SysImageInTag

	/// <summary>
	/// Object.
	/// </summary>
	public class SysImageInTag : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysImageInTag(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysImageInTag";
		}

		public SysImageInTag(SysImageInTag source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid EntityId {
			get {
				return GetTypedColumnValue<Guid>("EntityId");
			}
			set {
				SetColumnValue("EntityId", value);
				_entity = null;
			}
		}

		/// <exclude/>
		public string EntityName {
			get {
				return GetTypedColumnValue<string>("EntityName");
			}
			set {
				SetColumnValue("EntityName", value);
				if (_entity != null) {
					_entity.Name = value;
				}
			}
		}

		private SysImage _entity;
		/// <summary>
		/// Sys Image.
		/// </summary>
		public SysImage Entity {
			get {
				return _entity ??
					(_entity = LookupColumnEntities.GetEntity("Entity") as SysImage);
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

		private SysImageTag _tag;
		/// <summary>
		/// Sys Image Tag.
		/// </summary>
		public SysImageTag Tag {
			get {
				return _tag ??
					(_tag = LookupColumnEntities.GetEntity("Tag") as SysImageTag);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysImageInTag_CrtBaseEventsProcess(UserConnection);
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
			return new SysImageInTag(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysImageInTag_CrtBaseEventsProcess

	/// <exclude/>
	public partial class SysImageInTag_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysImageInTag
	{

		public SysImageInTag_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysImageInTag_CrtBaseEventsProcess";
			SchemaUId = new Guid("0ec9b2ce-8269-4ad8-bfc2-1b64cebd222a");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("0ec9b2ce-8269-4ad8-bfc2-1b64cebd222a");
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

	#region Class: SysImageInTag_CrtBaseEventsProcess

	/// <exclude/>
	public class SysImageInTag_CrtBaseEventsProcess : SysImageInTag_CrtBaseEventsProcess<SysImageInTag>
	{

		public SysImageInTag_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysImageInTag_CrtBaseEventsProcess

	public partial class SysImageInTag_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysImageInTagEventsProcess

	/// <exclude/>
	public class SysImageInTagEventsProcess : SysImageInTag_CrtBaseEventsProcess
	{

		public SysImageInTagEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

