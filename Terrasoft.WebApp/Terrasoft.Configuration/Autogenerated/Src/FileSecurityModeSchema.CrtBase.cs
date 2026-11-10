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

	#region Class: FileSecurityModeSchema

	/// <exclude/>
	public class FileSecurityModeSchema : Terrasoft.Configuration.LookupSchema
	{

		#region Constructors: Public

		public FileSecurityModeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public FileSecurityModeSchema(FileSecurityModeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public FileSecurityModeSchema(FileSecurityModeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("cd7ee836-7650-4817-804c-560f86b21d29");
			RealUId = new Guid("cd7ee836-7650-4817-804c-560f86b21d29");
			Name = "FileSecurityMode";
			ParentSchemaUId = new Guid("2aecdb97-990e-4c17-96f4-240ca6531c84");
			ExtendParent = false;
			CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
			UseLiveEditing = false;
			UseRecordDeactivation = true;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new FileSecurityMode(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new FileSecurityMode_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new FileSecurityModeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new FileSecurityModeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("cd7ee836-7650-4817-804c-560f86b21d29"));
		}

		#endregion

	}

	#endregion

	#region Class: FileSecurityMode

	/// <summary>
	/// File Security Mode.
	/// </summary>
	public class FileSecurityMode : Terrasoft.Configuration.Lookup
	{

		#region Constructors: Public

		public FileSecurityMode(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "FileSecurityMode";
		}

		public FileSecurityMode(FileSecurityMode source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new FileSecurityMode_CrtBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleting += (s, e) => ThrowEvent("FileSecurityModeDeleting", e);
			Inserted += (s, e) => ThrowEvent("FileSecurityModeInserted", e);
			Inserting += (s, e) => ThrowEvent("FileSecurityModeInserting", e);
			Saved += (s, e) => ThrowEvent("FileSecurityModeSaved", e);
			Saving += (s, e) => ThrowEvent("FileSecurityModeSaving", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new FileSecurityMode(this);
		}

		#endregion

	}

	#endregion

	#region Class: FileSecurityMode_CrtBaseEventsProcess

	/// <exclude/>
	public partial class FileSecurityMode_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.Lookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : FileSecurityMode
	{

		public FileSecurityMode_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "FileSecurityMode_CrtBaseEventsProcess";
			SchemaUId = new Guid("cd7ee836-7650-4817-804c-560f86b21d29");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("cd7ee836-7650-4817-804c-560f86b21d29");
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

	#region Class: FileSecurityMode_CrtBaseEventsProcess

	/// <exclude/>
	public class FileSecurityMode_CrtBaseEventsProcess : FileSecurityMode_CrtBaseEventsProcess<FileSecurityMode>
	{

		public FileSecurityMode_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: FileSecurityMode_CrtBaseEventsProcess

	public partial class FileSecurityMode_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: FileSecurityModeEventsProcess

	/// <exclude/>
	public class FileSecurityModeEventsProcess : FileSecurityMode_CrtBaseEventsProcess
	{

		public FileSecurityModeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

