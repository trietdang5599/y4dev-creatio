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
	using Terrasoft.Configuration;
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

	#region Class: KnwSourceFileSchema

	/// <exclude/>
	public class KnwSourceFileSchema : Terrasoft.Configuration.FileSchema
	{

		#region Constructors: Public

		public KnwSourceFileSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public KnwSourceFileSchema(KnwSourceFileSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public KnwSourceFileSchema(KnwSourceFileSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("9c302c6e-32a0-4220-a0dd-40f41e3e3c70");
			RealUId = new Guid("9c302c6e-32a0-4220-a0dd-40f41e3e3c70");
			Name = "KnwSourceFile";
			ParentSchemaUId = new Guid("556c5867-60a7-4456-aae1-a57a122bef70");
			ExtendParent = false;
			CreatedInPackageId = new Guid("0f5fed43-399b-4ea4-b68d-ee5a1a9b0d5a");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = false;
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
			if (Columns.FindByUId(new Guid("bbbd5a21-475e-d063-8662-956bf60fb838")) == null) {
				Columns.Add(CreateKnwSourceColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateKnwSourceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("bbbd5a21-475e-d063-8662-956bf60fb838"),
				Name = @"KnwSource",
				ReferenceSchemaUId = new Guid("6ec4827f-1e9a-4077-8c37-b7e97686fb92"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("9c302c6e-32a0-4220-a0dd-40f41e3e3c70"),
				ModifiedInSchemaUId = new Guid("9c302c6e-32a0-4220-a0dd-40f41e3e3c70"),
				CreatedInPackageId = new Guid("2c4cab0f-1fe9-47b5-95fa-4053b7ea1637"),
				IsSimpleLookup = true
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new KnwSourceFile(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new KnwSourceFile_CrtAIKnwLibAppEventsProcess(userConnection);
		}

		public override object Clone() {
			return new KnwSourceFileSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new KnwSourceFileSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9c302c6e-32a0-4220-a0dd-40f41e3e3c70"));
		}

		#endregion

	}

	#endregion

	#region Class: KnwSourceFile

	/// <summary>
	/// Knowledge source file.
	/// </summary>
	public class KnwSourceFile : Terrasoft.Configuration.File
	{

		#region Constructors: Public

		public KnwSourceFile(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "KnwSourceFile";
		}

		public KnwSourceFile(KnwSourceFile source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid KnwSourceId {
			get {
				return GetTypedColumnValue<Guid>("KnwSourceId");
			}
			set {
				SetColumnValue("KnwSourceId", value);
				_knwSource = null;
			}
		}

		/// <exclude/>
		public string KnwSourceName {
			get {
				return GetTypedColumnValue<string>("KnwSourceName");
			}
			set {
				SetColumnValue("KnwSourceName", value);
				if (_knwSource != null) {
					_knwSource.Name = value;
				}
			}
		}

		private KnwSource _knwSource;
		/// <summary>
		/// Knowledge source.
		/// </summary>
		public KnwSource KnwSource {
			get {
				return _knwSource ??
					(_knwSource = LookupColumnEntities.GetEntity("KnwSource") as KnwSource);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new KnwSourceFile_CrtAIKnwLibAppEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleting += (s, e) => ThrowEvent("KnwSourceFileDeleting", e);
			Inserted += (s, e) => ThrowEvent("KnwSourceFileInserted", e);
			Inserting += (s, e) => ThrowEvent("KnwSourceFileInserting", e);
			Saved += (s, e) => ThrowEvent("KnwSourceFileSaved", e);
			Saving += (s, e) => ThrowEvent("KnwSourceFileSaving", e);
			Validating += (s, e) => ThrowEvent("KnwSourceFileValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new KnwSourceFile(this);
		}

		#endregion

	}

	#endregion

	#region Class: KnwSourceFile_CrtAIKnwLibAppEventsProcess

	/// <exclude/>
	public partial class KnwSourceFile_CrtAIKnwLibAppEventsProcess<TEntity> : Terrasoft.Configuration.File_LinkPreviewEventsProcess<TEntity> where TEntity : KnwSourceFile
	{

		public KnwSourceFile_CrtAIKnwLibAppEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "KnwSourceFile_CrtAIKnwLibAppEventsProcess";
			SchemaUId = new Guid("9c302c6e-32a0-4220-a0dd-40f41e3e3c70");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("9c302c6e-32a0-4220-a0dd-40f41e3e3c70");
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

	#region Class: KnwSourceFile_CrtAIKnwLibAppEventsProcess

	/// <exclude/>
	public class KnwSourceFile_CrtAIKnwLibAppEventsProcess : KnwSourceFile_CrtAIKnwLibAppEventsProcess<KnwSourceFile>
	{

		public KnwSourceFile_CrtAIKnwLibAppEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: KnwSourceFile_CrtAIKnwLibAppEventsProcess

	public partial class KnwSourceFile_CrtAIKnwLibAppEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: KnwSourceFileEventsProcess

	/// <exclude/>
	public class KnwSourceFileEventsProcess : KnwSourceFile_CrtAIKnwLibAppEventsProcess
	{

		public KnwSourceFileEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

