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

	#region Class: FileSecurityMimeTypeExtensionSchema

	/// <exclude/>
	public class FileSecurityMimeTypeExtensionSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public FileSecurityMimeTypeExtensionSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public FileSecurityMimeTypeExtensionSchema(FileSecurityMimeTypeExtensionSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public FileSecurityMimeTypeExtensionSchema(FileSecurityMimeTypeExtensionSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("47f1ad5d-9ee5-45a1-a97f-c4ad85079d31");
			RealUId = new Guid("47f1ad5d-9ee5-45a1-a97f-c4ad85079d31");
			Name = "FileSecurityMimeTypeExtension";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("2edc5c83-f3cb-4c2f-af15-29fa964d8f29");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("a4342e39-9b92-698f-df06-ff34e2baf598")) == null) {
				Columns.Add(CreateMimeTypeColumn());
			}
			if (Columns.FindByUId(new Guid("e88dedb0-c47a-3383-1d48-21fba2a47399")) == null) {
				Columns.Add(CreateExtensionColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateMimeTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("a4342e39-9b92-698f-df06-ff34e2baf598"),
				Name = @"MimeType",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("47f1ad5d-9ee5-45a1-a97f-c4ad85079d31"),
				ModifiedInSchemaUId = new Guid("47f1ad5d-9ee5-45a1-a97f-c4ad85079d31"),
				CreatedInPackageId = new Guid("2edc5c83-f3cb-4c2f-af15-29fa964d8f29"),
				IsFormatValidated = true
			};
		}

		protected virtual EntitySchemaColumn CreateExtensionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("e88dedb0-c47a-3383-1d48-21fba2a47399"),
				Name = @"Extension",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("47f1ad5d-9ee5-45a1-a97f-c4ad85079d31"),
				ModifiedInSchemaUId = new Guid("47f1ad5d-9ee5-45a1-a97f-c4ad85079d31"),
				CreatedInPackageId = new Guid("2edc5c83-f3cb-4c2f-af15-29fa964d8f29"),
				IsFormatValidated = true
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new FileSecurityMimeTypeExtension(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new FileSecurityMimeTypeExtension_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new FileSecurityMimeTypeExtensionSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new FileSecurityMimeTypeExtensionSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("47f1ad5d-9ee5-45a1-a97f-c4ad85079d31"));
		}

		#endregion

	}

	#endregion

	#region Class: FileSecurityMimeTypeExtension

	/// <summary>
	/// FileSecurityMimeTypeExtension.
	/// </summary>
	public class FileSecurityMimeTypeExtension : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public FileSecurityMimeTypeExtension(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "FileSecurityMimeTypeExtension";
		}

		public FileSecurityMimeTypeExtension(FileSecurityMimeTypeExtension source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// MimeType.
		/// </summary>
		public string MimeType {
			get {
				return GetTypedColumnValue<string>("MimeType");
			}
			set {
				SetColumnValue("MimeType", value);
			}
		}

		/// <summary>
		/// Extension.
		/// </summary>
		public string Extension {
			get {
				return GetTypedColumnValue<string>("Extension");
			}
			set {
				SetColumnValue("Extension", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new FileSecurityMimeTypeExtension_CrtBaseEventsProcess(UserConnection);
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
			return new FileSecurityMimeTypeExtension(this);
		}

		#endregion

	}

	#endregion

	#region Class: FileSecurityMimeTypeExtension_CrtBaseEventsProcess

	/// <exclude/>
	public partial class FileSecurityMimeTypeExtension_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : FileSecurityMimeTypeExtension
	{

		public FileSecurityMimeTypeExtension_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "FileSecurityMimeTypeExtension_CrtBaseEventsProcess";
			SchemaUId = new Guid("47f1ad5d-9ee5-45a1-a97f-c4ad85079d31");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("47f1ad5d-9ee5-45a1-a97f-c4ad85079d31");
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

	#region Class: FileSecurityMimeTypeExtension_CrtBaseEventsProcess

	/// <exclude/>
	public class FileSecurityMimeTypeExtension_CrtBaseEventsProcess : FileSecurityMimeTypeExtension_CrtBaseEventsProcess<FileSecurityMimeTypeExtension>
	{

		public FileSecurityMimeTypeExtension_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: FileSecurityMimeTypeExtension_CrtBaseEventsProcess

	public partial class FileSecurityMimeTypeExtension_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: FileSecurityMimeTypeExtensionEventsProcess

	/// <exclude/>
	public class FileSecurityMimeTypeExtensionEventsProcess : FileSecurityMimeTypeExtension_CrtBaseEventsProcess
	{

		public FileSecurityMimeTypeExtensionEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

