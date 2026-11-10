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

	#region Class: FileLinkSchema

	/// <exclude/>
	public class FileLinkSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public FileLinkSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public FileLinkSchema(FileLinkSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public FileLinkSchema(FileLinkSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("746283f6-dc12-4c4d-871e-785a8d399ad1");
			RealUId = new Guid("746283f6-dc12-4c4d-871e-785a8d399ad1");
			Name = "FileLink";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateNameColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("c5a00d7b-9bb2-b4e7-aa4d-ee7b46b9a1be")) == null) {
				Columns.Add(CreateFileSchemaNameColumn());
			}
			if (Columns.FindByUId(new Guid("91113192-a8fa-e4ee-7959-ebbc8c3a4fe1")) == null) {
				Columns.Add(CreateFileRecordIdColumn());
			}
			if (Columns.FindByUId(new Guid("eeb58535-770d-bbd3-2aaf-5249921f1429")) == null) {
				Columns.Add(CreateRecordSchemaNameColumn());
			}
			if (Columns.FindByUId(new Guid("3c993b65-c03f-148e-a488-890edf2e142a")) == null) {
				Columns.Add(CreateRecordIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateFileSchemaNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("c5a00d7b-9bb2-b4e7-aa4d-ee7b46b9a1be"),
				Name = @"FileSchemaName",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("746283f6-dc12-4c4d-871e-785a8d399ad1"),
				ModifiedInSchemaUId = new Guid("746283f6-dc12-4c4d-871e-785a8d399ad1"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"CommonFile"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateFileRecordIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("91113192-a8fa-e4ee-7959-ebbc8c3a4fe1"),
				Name = @"FileRecordId",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("746283f6-dc12-4c4d-871e-785a8d399ad1"),
				ModifiedInSchemaUId = new Guid("746283f6-dc12-4c4d-871e-785a8d399ad1"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateRecordSchemaNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("eeb58535-770d-bbd3-2aaf-5249921f1429"),
				Name = @"RecordSchemaName",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("746283f6-dc12-4c4d-871e-785a8d399ad1"),
				ModifiedInSchemaUId = new Guid("746283f6-dc12-4c4d-871e-785a8d399ad1"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateRecordIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("3c993b65-c03f-148e-a488-890edf2e142a"),
				Name = @"RecordId",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("746283f6-dc12-4c4d-871e-785a8d399ad1"),
				ModifiedInSchemaUId = new Guid("746283f6-dc12-4c4d-871e-785a8d399ad1"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("2a0aaefd-4fdf-77fa-1062-4473e88db7a1"),
				Name = @"Name",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("746283f6-dc12-4c4d-871e-785a8d399ad1"),
				ModifiedInSchemaUId = new Guid("746283f6-dc12-4c4d-871e-785a8d399ad1"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new FileLink(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new FileLink_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new FileLinkSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new FileLinkSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("746283f6-dc12-4c4d-871e-785a8d399ad1"));
		}

		#endregion

	}

	#endregion

	#region Class: FileLink

	/// <summary>
	/// Attached file.
	/// </summary>
	public class FileLink : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public FileLink(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "FileLink";
		}

		public FileLink(FileLink source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// File entity schema name.
		/// </summary>
		public string FileSchemaName {
			get {
				return GetTypedColumnValue<string>("FileSchemaName");
			}
			set {
				SetColumnValue("FileSchemaName", value);
			}
		}

		/// <summary>
		/// File record identifier.
		/// </summary>
		public Guid FileRecordId {
			get {
				return GetTypedColumnValue<Guid>("FileRecordId");
			}
			set {
				SetColumnValue("FileRecordId", value);
			}
		}

		/// <summary>
		/// Schema name.
		/// </summary>
		public string RecordSchemaName {
			get {
				return GetTypedColumnValue<string>("RecordSchemaName");
			}
			set {
				SetColumnValue("RecordSchemaName", value);
			}
		}

		/// <summary>
		/// Record identifier.
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

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new FileLink_CrtBaseEventsProcess(UserConnection);
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
			return new FileLink(this);
		}

		#endregion

	}

	#endregion

	#region Class: FileLink_CrtBaseEventsProcess

	/// <exclude/>
	public partial class FileLink_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : FileLink
	{

		public FileLink_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "FileLink_CrtBaseEventsProcess";
			SchemaUId = new Guid("746283f6-dc12-4c4d-871e-785a8d399ad1");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("746283f6-dc12-4c4d-871e-785a8d399ad1");
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

	#region Class: FileLink_CrtBaseEventsProcess

	/// <exclude/>
	public class FileLink_CrtBaseEventsProcess : FileLink_CrtBaseEventsProcess<FileLink>
	{

		public FileLink_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: FileLink_CrtBaseEventsProcess

	public partial class FileLink_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: FileLinkEventsProcess

	/// <exclude/>
	public class FileLinkEventsProcess : FileLink_CrtBaseEventsProcess
	{

		public FileLinkEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

