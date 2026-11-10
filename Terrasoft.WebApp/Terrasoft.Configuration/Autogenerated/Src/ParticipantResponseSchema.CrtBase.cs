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

	#region Class: ParticipantResponseSchema

	/// <exclude/>
	public class ParticipantResponseSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ParticipantResponseSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ParticipantResponseSchema(ParticipantResponseSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ParticipantResponseSchema(ParticipantResponseSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("55767d4d-fb71-40c3-8140-2bfeb8dff693");
			RealUId = new Guid("55767d4d-fb71-40c3-8140-2bfeb8dff693");
			Name = "ParticipantResponse";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("9dae2167-8d3b-4948-9812-c7a970f9490e");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateNameColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("e320b15f-9a10-44b9-9a94-74c4b6712f4c"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("55767d4d-fb71-40c3-8140-2bfeb8dff693"),
				ModifiedInSchemaUId = new Guid("55767d4d-fb71-40c3-8140-2bfeb8dff693"),
				CreatedInPackageId = new Guid("9dae2167-8d3b-4948-9812-c7a970f9490e")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ParticipantResponse(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ParticipantResponse_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ParticipantResponseSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ParticipantResponseSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("55767d4d-fb71-40c3-8140-2bfeb8dff693"));
		}

		#endregion

	}

	#endregion

	#region Class: ParticipantResponse

	/// <summary>
	/// Activity participant invite response.
	/// </summary>
	public class ParticipantResponse : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ParticipantResponse(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ParticipantResponse";
		}

		public ParticipantResponse(ParticipantResponse source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Name.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ParticipantResponse_CrtBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ParticipantResponseDeleted", e);
			Validating += (s, e) => ThrowEvent("ParticipantResponseValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ParticipantResponse(this);
		}

		#endregion

	}

	#endregion

	#region Class: ParticipantResponse_CrtBaseEventsProcess

	/// <exclude/>
	public partial class ParticipantResponse_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : ParticipantResponse
	{

		public ParticipantResponse_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ParticipantResponse_CrtBaseEventsProcess";
			SchemaUId = new Guid("55767d4d-fb71-40c3-8140-2bfeb8dff693");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("55767d4d-fb71-40c3-8140-2bfeb8dff693");
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

	#region Class: ParticipantResponse_CrtBaseEventsProcess

	/// <exclude/>
	public class ParticipantResponse_CrtBaseEventsProcess : ParticipantResponse_CrtBaseEventsProcess<ParticipantResponse>
	{

		public ParticipantResponse_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ParticipantResponse_CrtBaseEventsProcess

	public partial class ParticipantResponse_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ParticipantResponseEventsProcess

	/// <exclude/>
	public class ParticipantResponseEventsProcess : ParticipantResponse_CrtBaseEventsProcess
	{

		public ParticipantResponseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

