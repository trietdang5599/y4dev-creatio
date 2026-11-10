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

	#region Class: KnowledgeBaseTagV2Schema

	/// <exclude/>
	public class KnowledgeBaseTagV2Schema : Terrasoft.Configuration.BaseTagSchema
	{

		#region Constructors: Public

		public KnowledgeBaseTagV2Schema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public KnowledgeBaseTagV2Schema(KnowledgeBaseTagV2Schema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public KnowledgeBaseTagV2Schema(KnowledgeBaseTagV2Schema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e79650e0-3a80-465e-ba8c-9b0372cb04b1");
			RealUId = new Guid("e79650e0-3a80-465e-ba8c-9b0372cb04b1");
			Name = "KnowledgeBaseTagV2";
			ParentSchemaUId = new Guid("9e3f203c-e905-4de5-9468-335b193f2439");
			ExtendParent = false;
			CreatedInPackageId = new Guid("7ef175d1-30fa-42f5-9f26-d5b1d45b0001");
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
			return new KnowledgeBaseTagV2(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new KnowledgeBaseTagV2_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new KnowledgeBaseTagV2Schema(this);
		}

		public override EntitySchema CloneShallow() {
			return new KnowledgeBaseTagV2Schema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e79650e0-3a80-465e-ba8c-9b0372cb04b1"));
		}

		#endregion

	}

	#endregion

	#region Class: KnowledgeBaseTagV2

	/// <summary>
	/// Knowledge base section tag.
	/// </summary>
	public class KnowledgeBaseTagV2 : Terrasoft.Configuration.BaseTag
	{

		#region Constructors: Public

		public KnowledgeBaseTagV2(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "KnowledgeBaseTagV2";
		}

		public KnowledgeBaseTagV2(KnowledgeBaseTagV2 source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new KnowledgeBaseTagV2_CrtBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("KnowledgeBaseTagV2Deleted", e);
			Inserted += (s, e) => ThrowEvent("KnowledgeBaseTagV2Inserted", e);
			Validating += (s, e) => ThrowEvent("KnowledgeBaseTagV2Validating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new KnowledgeBaseTagV2(this);
		}

		#endregion

	}

	#endregion

	#region Class: KnowledgeBaseTagV2_CrtBaseEventsProcess

	/// <exclude/>
	public partial class KnowledgeBaseTagV2_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseTag_SSPEventsProcess<TEntity> where TEntity : KnowledgeBaseTagV2
	{

		public KnowledgeBaseTagV2_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "KnowledgeBaseTagV2_CrtBaseEventsProcess";
			SchemaUId = new Guid("e79650e0-3a80-465e-ba8c-9b0372cb04b1");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("e79650e0-3a80-465e-ba8c-9b0372cb04b1");
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

	#region Class: KnowledgeBaseTagV2_CrtBaseEventsProcess

	/// <exclude/>
	public class KnowledgeBaseTagV2_CrtBaseEventsProcess : KnowledgeBaseTagV2_CrtBaseEventsProcess<KnowledgeBaseTagV2>
	{

		public KnowledgeBaseTagV2_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: KnowledgeBaseTagV2_CrtBaseEventsProcess

	public partial class KnowledgeBaseTagV2_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: KnowledgeBaseTagV2EventsProcess

	/// <exclude/>
	public class KnowledgeBaseTagV2EventsProcess : KnowledgeBaseTagV2_CrtBaseEventsProcess
	{

		public KnowledgeBaseTagV2EventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

