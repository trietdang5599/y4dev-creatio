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

	#region Class: MeetingTranscriptSchema

	/// <exclude/>
	public class MeetingTranscriptSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public MeetingTranscriptSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public MeetingTranscriptSchema(MeetingTranscriptSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public MeetingTranscriptSchema(MeetingTranscriptSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("8caf837f-419c-490e-8dab-da20f9632cff");
			RealUId = new Guid("8caf837f-419c-490e-8dab-da20f9632cff");
			Name = "MeetingTranscript";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("d699061b-815e-49b9-8730-21a5e5db2044");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = false;
			UseLiveEditing = true;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateMeetingSummaryColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("e9244c5f-4fb8-8325-1769-c7228f82e0b5")) == null) {
				Columns.Add(CreateTranscriptColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateMeetingSummaryColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("RichText")) {
				UId = new Guid("5972d373-3e34-4446-cdb8-a860e074cb71"),
				Name = @"MeetingSummary",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("8caf837f-419c-490e-8dab-da20f9632cff"),
				ModifiedInSchemaUId = new Guid("8caf837f-419c-490e-8dab-da20f9632cff"),
				CreatedInPackageId = new Guid("d699061b-815e-49b9-8730-21a5e5db2044")
			};
		}

		protected virtual EntitySchemaColumn CreateTranscriptColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("e9244c5f-4fb8-8325-1769-c7228f82e0b5"),
				Name = @"Transcript",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("8caf837f-419c-490e-8dab-da20f9632cff"),
				ModifiedInSchemaUId = new Guid("8caf837f-419c-490e-8dab-da20f9632cff"),
				CreatedInPackageId = new Guid("d699061b-815e-49b9-8730-21a5e5db2044"),
				IsMultiLineText = true
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new MeetingTranscript(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new MeetingTranscript_CrtUIv2EventsProcess(userConnection);
		}

		public override object Clone() {
			return new MeetingTranscriptSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new MeetingTranscriptSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("8caf837f-419c-490e-8dab-da20f9632cff"));
		}

		#endregion

	}

	#endregion

	#region Class: MeetingTranscript

	/// <summary>
	/// Meeting transcript.
	/// </summary>
	public class MeetingTranscript : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public MeetingTranscript(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MeetingTranscript";
		}

		public MeetingTranscript(MeetingTranscript source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Meeting summary.
		/// </summary>
		public string MeetingSummary {
			get {
				return GetTypedColumnValue<string>("MeetingSummary");
			}
			set {
				SetColumnValue("MeetingSummary", value);
			}
		}

		/// <summary>
		/// Transcript.
		/// </summary>
		public string Transcript {
			get {
				return GetTypedColumnValue<string>("Transcript");
			}
			set {
				SetColumnValue("Transcript", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new MeetingTranscript_CrtUIv2EventsProcess(UserConnection);
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
			return new MeetingTranscript(this);
		}

		#endregion

	}

	#endregion

	#region Class: MeetingTranscript_CrtUIv2EventsProcess

	/// <exclude/>
	public partial class MeetingTranscript_CrtUIv2EventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : MeetingTranscript
	{

		public MeetingTranscript_CrtUIv2EventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "MeetingTranscript_CrtUIv2EventsProcess";
			SchemaUId = new Guid("8caf837f-419c-490e-8dab-da20f9632cff");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("8caf837f-419c-490e-8dab-da20f9632cff");
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

	#region Class: MeetingTranscript_CrtUIv2EventsProcess

	/// <exclude/>
	public class MeetingTranscript_CrtUIv2EventsProcess : MeetingTranscript_CrtUIv2EventsProcess<MeetingTranscript>
	{

		public MeetingTranscript_CrtUIv2EventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: MeetingTranscript_CrtUIv2EventsProcess

	public partial class MeetingTranscript_CrtUIv2EventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: MeetingTranscriptEventsProcess

	/// <exclude/>
	public class MeetingTranscriptEventsProcess : MeetingTranscript_CrtUIv2EventsProcess
	{

		public MeetingTranscriptEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

