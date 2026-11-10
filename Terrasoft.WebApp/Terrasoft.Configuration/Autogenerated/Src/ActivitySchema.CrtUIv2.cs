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
	using System.Text;
	using System.Text.RegularExpressions;
	using System.Web;
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
	using Terrasoft.Core.Store;
	using Terrasoft.GlobalSearch.Indexing;
	using Terrasoft.UI.WebControls.Controls;
	using Terrasoft.UI.WebControls.Utilities.Json.Converters;

	#region Class: Activity_CrtUIv2_CreatioSchema

	/// <exclude/>
	public class Activity_CrtUIv2_CreatioSchema : Terrasoft.Configuration.Activity_CrtNUI_CreatioSchema
	{

		#region Constructors: Public

		public Activity_CrtUIv2_CreatioSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Activity_CrtUIv2_CreatioSchema(Activity_CrtUIv2_CreatioSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Activity_CrtUIv2_CreatioSchema(Activity_CrtUIv2_CreatioSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateId_StartDate_Type_ShowInSchedIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("5616f33c-a275-4edb-a072-5264b6f7e077");
			index.Name = "Id_StartDate_Type_ShowInSched";
			index.CreatedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89");
			index.ModifiedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89");
			index.CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723");
			EntitySchemaIndexColumn showInSchedulerIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("9ba50dac-d3dd-57f3-3c2c-3ec8035c8b31"),
				ColumnUId = new Guid("ff2dec51-885c-428a-8e6a-80c0c14b1434"),
				CreatedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				ModifiedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(showInSchedulerIndexColumn);
			EntitySchemaIndexColumn startDateIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("dbd9d02a-031e-a4fa-1033-6b9f10122ca4"),
				ColumnUId = new Guid("a12ca538-61b1-4907-9fdf-01969163d4dd"),
				CreatedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				ModifiedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(startDateIndexColumn);
			EntitySchemaIndexColumn typeIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("1a9e19cd-0fbc-4a81-0d2b-741666da87e0"),
				ColumnUId = new Guid("5491c33f-e927-4ca8-a579-d4810ea54c56"),
				CreatedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				ModifiedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(typeIdIndexColumn);
			EntitySchemaIndexColumn idIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("cb359a7a-c5a6-6760-3d2e-d22eb2b0730a"),
				ColumnUId = new Guid("ae0e45ca-c495-4fe7-a39d-3ab7278e1617"),
				CreatedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				ModifiedInSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(idIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("cff39bac-beb2-4e8c-9b5f-1a8dfa9e1c95");
			Name = "Activity_CrtUIv2_Creatio";
			ParentSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89");
			ExtendParent = true;
			CreatedInPackageId = new Guid("50936ed0-15b7-4fff-b442-2705f6188184");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("94b8d117-26d0-4946-82fa-c7c7a9c9547c")) == null) {
				Columns.Add(CreateMeetingPlatformColumn());
			}
			if (Columns.FindByUId(new Guid("68eb9c65-1801-998b-ea4b-96bedf911618")) == null) {
				Columns.Add(CreateMeetingTranscriptColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateMeetingPlatformColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("94b8d117-26d0-4946-82fa-c7c7a9c9547c"),
				Name = @"MeetingPlatform",
				ReferenceSchemaUId = new Guid("c2f3532e-5134-486b-a085-54728b8e1f22"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("cff39bac-beb2-4e8c-9b5f-1a8dfa9e1c95"),
				ModifiedInSchemaUId = new Guid("cff39bac-beb2-4e8c-9b5f-1a8dfa9e1c95"),
				CreatedInPackageId = new Guid("d699061b-815e-49b9-8730-21a5e5db2044"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateMeetingTranscriptColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("68eb9c65-1801-998b-ea4b-96bedf911618"),
				Name = @"MeetingTranscript",
				ReferenceSchemaUId = new Guid("8caf837f-419c-490e-8dab-da20f9632cff"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("cff39bac-beb2-4e8c-9b5f-1a8dfa9e1c95"),
				ModifiedInSchemaUId = new Guid("cff39bac-beb2-4e8c-9b5f-1a8dfa9e1c95"),
				CreatedInPackageId = new Guid("d699061b-815e-49b9-8730-21a5e5db2044"),
				IsSimpleLookup = true
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateId_StartDate_Type_ShowInSchedIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Activity_CrtUIv2_Creatio(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Activity_CrtUIv2EventsProcess(userConnection);
		}

		public override object Clone() {
			return new Activity_CrtUIv2_CreatioSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Activity_CrtUIv2_CreatioSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("cff39bac-beb2-4e8c-9b5f-1a8dfa9e1c95"));
		}

		#endregion

	}

	#endregion

	#region Class: Activity_CrtUIv2_Creatio

	/// <summary>
	/// Activity.
	/// </summary>
	public class Activity_CrtUIv2_Creatio : Terrasoft.Configuration.Activity_CrtNUI_Creatio
	{

		#region Constructors: Public

		public Activity_CrtUIv2_Creatio(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Activity_CrtUIv2_Creatio";
		}

		public Activity_CrtUIv2_Creatio(Activity_CrtUIv2_Creatio source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid MeetingPlatformId {
			get {
				return GetTypedColumnValue<Guid>("MeetingPlatformId");
			}
			set {
				SetColumnValue("MeetingPlatformId", value);
				_meetingPlatform = null;
			}
		}

		/// <exclude/>
		public string MeetingPlatformName {
			get {
				return GetTypedColumnValue<string>("MeetingPlatformName");
			}
			set {
				SetColumnValue("MeetingPlatformName", value);
				if (_meetingPlatform != null) {
					_meetingPlatform.Name = value;
				}
			}
		}

		private MeetingPlatform _meetingPlatform;
		/// <summary>
		/// Meeting platform.
		/// </summary>
		public MeetingPlatform MeetingPlatform {
			get {
				return _meetingPlatform ??
					(_meetingPlatform = LookupColumnEntities.GetEntity("MeetingPlatform") as MeetingPlatform);
			}
		}

		/// <exclude/>
		public Guid MeetingTranscriptId {
			get {
				return GetTypedColumnValue<Guid>("MeetingTranscriptId");
			}
			set {
				SetColumnValue("MeetingTranscriptId", value);
				_meetingTranscript = null;
			}
		}

		/// <exclude/>
		public string MeetingTranscriptMeetingSummary {
			get {
				return GetTypedColumnValue<string>("MeetingTranscriptMeetingSummary");
			}
			set {
				SetColumnValue("MeetingTranscriptMeetingSummary", value);
				if (_meetingTranscript != null) {
					_meetingTranscript.MeetingSummary = value;
				}
			}
		}

		private MeetingTranscript _meetingTranscript;
		/// <summary>
		/// Meeting transcript.
		/// </summary>
		public MeetingTranscript MeetingTranscript {
			get {
				return _meetingTranscript ??
					(_meetingTranscript = LookupColumnEntities.GetEntity("MeetingTranscript") as MeetingTranscript);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Activity_CrtUIv2EventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleting += (s, e) => ThrowEvent("Activity_CrtUIv2_CreatioDeleting", e);
			Inserted += (s, e) => ThrowEvent("Activity_CrtUIv2_CreatioInserted", e);
			Inserting += (s, e) => ThrowEvent("Activity_CrtUIv2_CreatioInserting", e);
			Saved += (s, e) => ThrowEvent("Activity_CrtUIv2_CreatioSaved", e);
			Saving += (s, e) => ThrowEvent("Activity_CrtUIv2_CreatioSaving", e);
			Updated += (s, e) => ThrowEvent("Activity_CrtUIv2_CreatioUpdated", e);
			Validating += (s, e) => ThrowEvent("Activity_CrtUIv2_CreatioValidating", e);
			DefColumnValuesSet += (s, e) => ThrowEvent("Activity_CrtUIv2_CreatioDefColumnValuesSet", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Activity_CrtUIv2_Creatio(this);
		}

		#endregion

	}

	#endregion

	#region Class: Activity_CrtUIv2EventsProcess

	/// <exclude/>
	public partial class Activity_CrtUIv2EventsProcess<TEntity> : Terrasoft.Configuration.Activity_CrtNUIEventsProcess<TEntity> where TEntity : Activity_CrtUIv2_Creatio
	{

		public Activity_CrtUIv2EventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Activity_CrtUIv2EventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("cff39bac-beb2-4e8c-9b5f-1a8dfa9e1c95");
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

	#region Class: Activity_CrtUIv2EventsProcess

	/// <exclude/>
	public class Activity_CrtUIv2EventsProcess : Activity_CrtUIv2EventsProcess<Activity_CrtUIv2_Creatio>
	{

		public Activity_CrtUIv2EventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Activity_CrtUIv2EventsProcess

	public partial class Activity_CrtUIv2EventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

