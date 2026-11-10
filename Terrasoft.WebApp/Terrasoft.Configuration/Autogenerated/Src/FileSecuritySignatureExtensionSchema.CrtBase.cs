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

	#region Class: FileSecuritySignatureExtensionSchema

	/// <exclude/>
	public class FileSecuritySignatureExtensionSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public FileSecuritySignatureExtensionSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public FileSecuritySignatureExtensionSchema(FileSecuritySignatureExtensionSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public FileSecuritySignatureExtensionSchema(FileSecuritySignatureExtensionSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f774b34c-69de-4844-9319-8fd303e43b85");
			RealUId = new Guid("f774b34c-69de-4844-9319-8fd303e43b85");
			Name = "FileSecuritySignatureExtension";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("11c768bc-fae6-4a11-84ba-23628061715e");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("9639c055-5fb7-1c83-26ea-93e3f47494d3")) == null) {
				Columns.Add(CreateExtensionColumn());
			}
			if (Columns.FindByUId(new Guid("57305380-63d5-a8dc-bbad-1e2bc8a85330")) == null) {
				Columns.Add(CreateSignatureColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateExtensionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("9639c055-5fb7-1c83-26ea-93e3f47494d3"),
				Name = @"Extension",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("f774b34c-69de-4844-9319-8fd303e43b85"),
				ModifiedInSchemaUId = new Guid("f774b34c-69de-4844-9319-8fd303e43b85"),
				CreatedInPackageId = new Guid("11c768bc-fae6-4a11-84ba-23628061715e"),
				IsFormatValidated = true
			};
		}

		protected virtual EntitySchemaColumn CreateSignatureColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("57305380-63d5-a8dc-bbad-1e2bc8a85330"),
				Name = @"Signature",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("f774b34c-69de-4844-9319-8fd303e43b85"),
				ModifiedInSchemaUId = new Guid("f774b34c-69de-4844-9319-8fd303e43b85"),
				CreatedInPackageId = new Guid("11c768bc-fae6-4a11-84ba-23628061715e"),
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
			return new FileSecuritySignatureExtension(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new FileSecuritySignatureExtension_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new FileSecuritySignatureExtensionSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new FileSecuritySignatureExtensionSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f774b34c-69de-4844-9319-8fd303e43b85"));
		}

		#endregion

	}

	#endregion

	#region Class: FileSecuritySignatureExtension

	/// <summary>
	/// FileSecuritySignatureExtension.
	/// </summary>
	public class FileSecuritySignatureExtension : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public FileSecuritySignatureExtension(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "FileSecuritySignatureExtension";
		}

		public FileSecuritySignatureExtension(FileSecuritySignatureExtension source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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

		/// <summary>
		/// Signature.
		/// </summary>
		public string Signature {
			get {
				return GetTypedColumnValue<string>("Signature");
			}
			set {
				SetColumnValue("Signature", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new FileSecuritySignatureExtension_CrtBaseEventsProcess(UserConnection);
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
			return new FileSecuritySignatureExtension(this);
		}

		#endregion

	}

	#endregion

	#region Class: FileSecuritySignatureExtension_CrtBaseEventsProcess

	/// <exclude/>
	public partial class FileSecuritySignatureExtension_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : FileSecuritySignatureExtension
	{

		public FileSecuritySignatureExtension_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "FileSecuritySignatureExtension_CrtBaseEventsProcess";
			SchemaUId = new Guid("f774b34c-69de-4844-9319-8fd303e43b85");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("f774b34c-69de-4844-9319-8fd303e43b85");
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

	#region Class: FileSecuritySignatureExtension_CrtBaseEventsProcess

	/// <exclude/>
	public class FileSecuritySignatureExtension_CrtBaseEventsProcess : FileSecuritySignatureExtension_CrtBaseEventsProcess<FileSecuritySignatureExtension>
	{

		public FileSecuritySignatureExtension_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: FileSecuritySignatureExtension_CrtBaseEventsProcess

	public partial class FileSecuritySignatureExtension_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: FileSecuritySignatureExtensionEventsProcess

	/// <exclude/>
	public class FileSecuritySignatureExtensionEventsProcess : FileSecuritySignatureExtension_CrtBaseEventsProcess
	{

		public FileSecuritySignatureExtensionEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

