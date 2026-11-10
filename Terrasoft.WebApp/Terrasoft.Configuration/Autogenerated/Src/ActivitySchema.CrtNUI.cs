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

	#region Class: Activity_CrtNUI_CreatioSchema

	/// <exclude/>
	public class Activity_CrtNUI_CreatioSchema : Terrasoft.Configuration.Activity_CrtCoreBase_CreatioSchema
	{

		#region Constructors: Public

		public Activity_CrtNUI_CreatioSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Activity_CrtNUI_CreatioSchema(Activity_CrtNUI_CreatioSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Activity_CrtNUI_CreatioSchema(Activity_CrtNUI_CreatioSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("1b116491-abef-40e6-b627-93ff5c45ab7e");
			Name = "Activity_CrtNUI_Creatio";
			ParentSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89");
			ExtendParent = true;
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
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
			return new Activity_CrtNUI_Creatio(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Activity_CrtNUIEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Activity_CrtNUI_CreatioSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Activity_CrtNUI_CreatioSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1b116491-abef-40e6-b627-93ff5c45ab7e"));
		}

		#endregion

	}

	#endregion

	#region Class: Activity_CrtNUI_Creatio

	/// <summary>
	/// Activity.
	/// </summary>
	public class Activity_CrtNUI_Creatio : Terrasoft.Configuration.Activity_CrtCoreBase_Creatio
	{

		#region Constructors: Public

		public Activity_CrtNUI_Creatio(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Activity_CrtNUI_Creatio";
		}

		public Activity_CrtNUI_Creatio(Activity_CrtNUI_Creatio source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Activity_CrtNUIEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("Activity_CrtNUI_CreatioDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Activity_CrtNUI_Creatio(this);
		}

		#endregion

	}

	#endregion

	#region Class: Activity_CrtNUIEventsProcess

	/// <exclude/>
	public partial class Activity_CrtNUIEventsProcess<TEntity> : Terrasoft.Configuration.Activity_CrtCoreBaseEventsProcess<TEntity> where TEntity : Activity_CrtNUI_Creatio
	{

		public Activity_CrtNUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Activity_CrtNUIEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("1b116491-abef-40e6-b627-93ff5c45ab7e");
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

	#region Class: Activity_CrtNUIEventsProcess

	/// <exclude/>
	public class Activity_CrtNUIEventsProcess : Activity_CrtNUIEventsProcess<Activity_CrtNUI_Creatio>
	{

		public Activity_CrtNUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Activity_CrtNUIEventsProcess

	public partial class Activity_CrtNUIEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void PrepereSynchronizeSubjectRemindingUserTask(SynchronizeSubjectRemindingUserTask userTask, Guid contact, DateTime remindTime, bool active, Guid source) {
			base.PrepereSynchronizeSubjectRemindingUserTask(userTask, contact, remindTime, active, source);
			bool isFeatureEnabled = FeatureUtilities.GetIsFeatureEnabled(UserConnection, "NotificationV2");
			if (isFeatureEnabled && active) {
				IRemindingTextFormer textFormer = ClassFactory.Get<ActivityRemindingTextFormer>(
					new ConstructorArgument("userConnection", UserConnection));
				string accountName = GetLookupDisplayColumnValue(Entity, "Account");
				string contactName = GetLookupDisplayColumnValue(Entity, "Contact");
				string title = Entity.GetTypedColumnValue<string>("Title");
				userTask.SubjectCaption = textFormer.GetBody(new Dictionary<string, object> {
					{"AccountName", accountName},
					{"ContactName", contactName},
					{"Title", title}
				});
				userTask.PopupTitle = textFormer.GetTitle(new Dictionary<string, object>());
			}
		}

		public virtual string GetLookupDisplayColumnValue(Entity entity, string lookupName) {
			var rootEntitySchema = entity.Schema;
			var result = string.Empty;
			try {
				var rootEntityColumn = rootEntitySchema.Columns.GetByName(lookupName);
				var recordId = entity.GetTypedColumnValue<Guid>(rootEntityColumn.ColumnValueName);
				result = recordId.IsNotEmpty() 
					? GetFetchedDisplayColumnValue(entity, lookupName, recordId)
					: string.Empty;
			} catch (Exception ex) {
				result = string.Empty;
			}
			return result;
		}

		public virtual string GetFetchedDisplayColumnValue(Entity entity, string lookupName, Guid recordId) {
			var userConnection = entity.UserConnection;
			var lookupEntitySchema = userConnection.EntitySchemaManager.FindInstanceByName(lookupName);
			var lookupEntity = lookupEntitySchema.CreateEntity(userConnection);
			lookupEntity.FetchPrimaryInfoFromDB(lookupEntitySchema.GetPrimaryColumnName(), recordId);
			return lookupEntity.PrimaryDisplayColumnValue;
		}

		#endregion

	}

	#endregion

}

