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

	#region Class: DisplayDateFormatSchema

	/// <exclude/>
	public class DisplayDateFormatSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public DisplayDateFormatSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public DisplayDateFormatSchema(DisplayDateFormatSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public DisplayDateFormatSchema(DisplayDateFormatSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ce4fa92e-0e75-414f-b1e6-80d5acf3fa56");
			RealUId = new Guid("ce4fa92e-0e75-414f-b1e6-80d5acf3fa56");
			Name = "DisplayDateFormat";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("ae62e634-fbce-473f-afeb-ae2f3fadfe02");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateFormatColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected virtual EntitySchemaColumn CreateFormatColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("7d253e86-83f1-41da-9a8b-e9c8077b78ff"),
				Name = @"Format",
				CreatedInSchemaUId = new Guid("ce4fa92e-0e75-414f-b1e6-80d5acf3fa56"),
				ModifiedInSchemaUId = new Guid("ce4fa92e-0e75-414f-b1e6-80d5acf3fa56"),
				CreatedInPackageId = new Guid("ae62e634-fbce-473f-afeb-ae2f3fadfe02")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new DisplayDateFormat(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new DisplayDateFormat_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new DisplayDateFormatSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new DisplayDateFormatSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ce4fa92e-0e75-414f-b1e6-80d5acf3fa56"));
		}

		#endregion

	}

	#endregion

	#region Class: DisplayDateFormat

	/// <summary>
	/// Display date format.
	/// </summary>
	public class DisplayDateFormat : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public DisplayDateFormat(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "DisplayDateFormat";
		}

		public DisplayDateFormat(DisplayDateFormat source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Display format datetime.
		/// </summary>
		public string Format {
			get {
				return GetTypedColumnValue<string>("Format");
			}
			set {
				SetColumnValue("Format", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new DisplayDateFormat_CrtBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("DisplayDateFormatDeleted", e);
			Validating += (s, e) => ThrowEvent("DisplayDateFormatValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new DisplayDateFormat(this);
		}

		#endregion

	}

	#endregion

	#region Class: DisplayDateFormat_CrtBaseEventsProcess

	/// <exclude/>
	public partial class DisplayDateFormat_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : DisplayDateFormat
	{

		public DisplayDateFormat_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "DisplayDateFormat_CrtBaseEventsProcess";
			SchemaUId = new Guid("ce4fa92e-0e75-414f-b1e6-80d5acf3fa56");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ce4fa92e-0e75-414f-b1e6-80d5acf3fa56");
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

	#region Class: DisplayDateFormat_CrtBaseEventsProcess

	/// <exclude/>
	public class DisplayDateFormat_CrtBaseEventsProcess : DisplayDateFormat_CrtBaseEventsProcess<DisplayDateFormat>
	{

		public DisplayDateFormat_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: DisplayDateFormat_CrtBaseEventsProcess

	public partial class DisplayDateFormat_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: DisplayDateFormatEventsProcess

	/// <exclude/>
	public class DisplayDateFormatEventsProcess : DisplayDateFormat_CrtBaseEventsProcess
	{

		public DisplayDateFormatEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

