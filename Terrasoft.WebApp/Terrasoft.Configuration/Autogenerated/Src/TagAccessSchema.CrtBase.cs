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

	#region Class: TagAccessSchema

	/// <exclude/>
	public class TagAccessSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public TagAccessSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public TagAccessSchema(TagAccessSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public TagAccessSchema(TagAccessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("1fc1e003-8083-44da-ba4b-7b77186968e0");
			RealUId = new Guid("1fc1e003-8083-44da-ba4b-7b77186968e0");
			Name = "TagAccess";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = false;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
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
			return new TagAccess(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new TagAccess_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new TagAccessSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new TagAccessSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1fc1e003-8083-44da-ba4b-7b77186968e0"));
		}

		#endregion

	}

	#endregion

	#region Class: TagAccess

	/// <summary>
	/// Access to tag.
	/// </summary>
	public class TagAccess : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public TagAccess(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "TagAccess";
		}

		public TagAccess(TagAccess source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new TagAccess_CrtBaseEventsProcess(UserConnection);
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
			return new TagAccess(this);
		}

		#endregion

	}

	#endregion

	#region Class: TagAccess_CrtBaseEventsProcess

	/// <exclude/>
	public partial class TagAccess_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : TagAccess
	{

		public TagAccess_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "TagAccess_CrtBaseEventsProcess";
			SchemaUId = new Guid("1fc1e003-8083-44da-ba4b-7b77186968e0");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("1fc1e003-8083-44da-ba4b-7b77186968e0");
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

	#region Class: TagAccess_CrtBaseEventsProcess

	/// <exclude/>
	public class TagAccess_CrtBaseEventsProcess : TagAccess_CrtBaseEventsProcess<TagAccess>
	{

		public TagAccess_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: TagAccess_CrtBaseEventsProcess

	public partial class TagAccess_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: TagAccessEventsProcess

	/// <exclude/>
	public class TagAccessEventsProcess : TagAccess_CrtBaseEventsProcess
	{

		public TagAccessEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

