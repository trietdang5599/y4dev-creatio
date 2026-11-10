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
	using System.Security;
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
	using TSConfiguration = Terrasoft.Configuration;

	#region Class: GeneratedWebFormTagSchema

	/// <exclude/>
	public class GeneratedWebFormTagSchema : Terrasoft.Configuration.BaseTagSchema
	{

		#region Constructors: Public

		public GeneratedWebFormTagSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public GeneratedWebFormTagSchema(GeneratedWebFormTagSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public GeneratedWebFormTagSchema(GeneratedWebFormTagSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("905e1ada-1a66-4f65-8950-78cf26fbb800");
			RealUId = new Guid("905e1ada-1a66-4f65-8950-78cf26fbb800");
			Name = "GeneratedWebFormTag";
			ParentSchemaUId = new Guid("9e3f203c-e905-4de5-9468-335b193f2439");
			ExtendParent = false;
			CreatedInPackageId = new Guid("dfe2c6b5-61e8-4e57-95ae-a3c34fa0908f");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
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
			return new GeneratedWebFormTag(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new GeneratedWebFormTag_WebFormEventsProcess(userConnection);
		}

		public override object Clone() {
			return new GeneratedWebFormTagSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new GeneratedWebFormTagSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("905e1ada-1a66-4f65-8950-78cf26fbb800"));
		}

		#endregion

	}

	#endregion

	#region Class: GeneratedWebFormTag

	/// <summary>
	/// Landing pages section tag.
	/// </summary>
	public class GeneratedWebFormTag : Terrasoft.Configuration.BaseTag
	{

		#region Constructors: Public

		public GeneratedWebFormTag(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "GeneratedWebFormTag";
		}

		public GeneratedWebFormTag(GeneratedWebFormTag source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new GeneratedWebFormTag_WebFormEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("GeneratedWebFormTagDeleted", e);
			Inserted += (s, e) => ThrowEvent("GeneratedWebFormTagInserted", e);
			Validating += (s, e) => ThrowEvent("GeneratedWebFormTagValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new GeneratedWebFormTag(this);
		}

		#endregion

	}

	#endregion

	#region Class: GeneratedWebFormTag_WebFormEventsProcess

	/// <exclude/>
	public partial class GeneratedWebFormTag_WebFormEventsProcess<TEntity> : Terrasoft.Configuration.BaseTag_SSPEventsProcess<TEntity> where TEntity : GeneratedWebFormTag
	{

		public GeneratedWebFormTag_WebFormEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "GeneratedWebFormTag_WebFormEventsProcess";
			SchemaUId = new Guid("905e1ada-1a66-4f65-8950-78cf26fbb800");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("905e1ada-1a66-4f65-8950-78cf26fbb800");
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

	#region Class: GeneratedWebFormTag_WebFormEventsProcess

	/// <exclude/>
	public class GeneratedWebFormTag_WebFormEventsProcess : GeneratedWebFormTag_WebFormEventsProcess<GeneratedWebFormTag>
	{

		public GeneratedWebFormTag_WebFormEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: GeneratedWebFormTag_WebFormEventsProcess

	public partial class GeneratedWebFormTag_WebFormEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: GeneratedWebFormTagEventsProcess

	/// <exclude/>
	public class GeneratedWebFormTagEventsProcess : GeneratedWebFormTag_WebFormEventsProcess
	{

		public GeneratedWebFormTagEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

