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

	#region Class: DuplicatesRuleTagSchema

	/// <exclude/>
	public class DuplicatesRuleTagSchema : Terrasoft.Configuration.BaseTagSchema
	{

		#region Constructors: Public

		public DuplicatesRuleTagSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public DuplicatesRuleTagSchema(DuplicatesRuleTagSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public DuplicatesRuleTagSchema(DuplicatesRuleTagSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("655501e6-0dd8-48a2-91ad-1d67671dfc00");
			RealUId = new Guid("655501e6-0dd8-48a2-91ad-1d67671dfc00");
			Name = "DuplicatesRuleTag";
			ParentSchemaUId = new Guid("9e3f203c-e905-4de5-9468-335b193f2439");
			ExtendParent = false;
			CreatedInPackageId = new Guid("cddb02cf-8a8b-4af9-b5f2-4f81a4f916c1");
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
			return new DuplicatesRuleTag(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new DuplicatesRuleTag_CrtDeduplicationEventsProcess(userConnection);
		}

		public override object Clone() {
			return new DuplicatesRuleTagSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new DuplicatesRuleTagSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("655501e6-0dd8-48a2-91ad-1d67671dfc00"));
		}

		#endregion

	}

	#endregion

	#region Class: DuplicatesRuleTag

	/// <summary>
	/// "Duplicates rule" section tag.
	/// </summary>
	public class DuplicatesRuleTag : Terrasoft.Configuration.BaseTag
	{

		#region Constructors: Public

		public DuplicatesRuleTag(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "DuplicatesRuleTag";
		}

		public DuplicatesRuleTag(DuplicatesRuleTag source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new DuplicatesRuleTag_CrtDeduplicationEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("DuplicatesRuleTagDeleted", e);
			Inserted += (s, e) => ThrowEvent("DuplicatesRuleTagInserted", e);
			Validating += (s, e) => ThrowEvent("DuplicatesRuleTagValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new DuplicatesRuleTag(this);
		}

		#endregion

	}

	#endregion

	#region Class: DuplicatesRuleTag_CrtDeduplicationEventsProcess

	/// <exclude/>
	public partial class DuplicatesRuleTag_CrtDeduplicationEventsProcess<TEntity> : Terrasoft.Configuration.BaseTag_SSPEventsProcess<TEntity> where TEntity : DuplicatesRuleTag
	{

		public DuplicatesRuleTag_CrtDeduplicationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "DuplicatesRuleTag_CrtDeduplicationEventsProcess";
			SchemaUId = new Guid("655501e6-0dd8-48a2-91ad-1d67671dfc00");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("655501e6-0dd8-48a2-91ad-1d67671dfc00");
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

	#region Class: DuplicatesRuleTag_CrtDeduplicationEventsProcess

	/// <exclude/>
	public class DuplicatesRuleTag_CrtDeduplicationEventsProcess : DuplicatesRuleTag_CrtDeduplicationEventsProcess<DuplicatesRuleTag>
	{

		public DuplicatesRuleTag_CrtDeduplicationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: DuplicatesRuleTag_CrtDeduplicationEventsProcess

	public partial class DuplicatesRuleTag_CrtDeduplicationEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: DuplicatesRuleTagEventsProcess

	/// <exclude/>
	public class DuplicatesRuleTagEventsProcess : DuplicatesRuleTag_CrtDeduplicationEventsProcess
	{

		public DuplicatesRuleTagEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

