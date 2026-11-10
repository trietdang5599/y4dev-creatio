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

	#region Class: OmniMesMacrosDetailsSchema

	/// <exclude/>
	public class OmniMesMacrosDetailsSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public OmniMesMacrosDetailsSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OmniMesMacrosDetailsSchema(OmniMesMacrosDetailsSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OmniMesMacrosDetailsSchema(OmniMesMacrosDetailsSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("1041f84e-a031-486d-b50f-e653cc97538b");
			RealUId = new Guid("1041f84e-a031-486d-b50f-e653cc97538b");
			Name = "OmniMesMacrosDetails";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("f4d2410e-0606-46e8-a991-9e265303d628");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = false;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("fbeb15ec-24be-365e-fbe6-bbe3233f9ac7")) == null) {
				Columns.Add(CreateMacrosColumn());
			}
			if (Columns.FindByUId(new Guid("3e93bbba-c573-d0f7-6ec6-c764e8a6d7c4")) == null) {
				Columns.Add(CreateMetadataColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateMacrosColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("fbeb15ec-24be-365e-fbe6-bbe3233f9ac7"),
				Name = @"Macros",
				ReferenceSchemaUId = new Guid("4b9aeea6-e0ef-4bdf-adfc-2afd1cb75a92"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("1041f84e-a031-486d-b50f-e653cc97538b"),
				ModifiedInSchemaUId = new Guid("1041f84e-a031-486d-b50f-e653cc97538b"),
				CreatedInPackageId = new Guid("f4d2410e-0606-46e8-a991-9e265303d628"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateMetadataColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("3e93bbba-c573-d0f7-6ec6-c764e8a6d7c4"),
				Name = @"Metadata",
				CreatedInSchemaUId = new Guid("1041f84e-a031-486d-b50f-e653cc97538b"),
				ModifiedInSchemaUId = new Guid("1041f84e-a031-486d-b50f-e653cc97538b"),
				CreatedInPackageId = new Guid("f4d2410e-0606-46e8-a991-9e265303d628")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new OmniMesMacrosDetails(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OmniMesMacrosDetails_OmnichannelMessagingEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OmniMesMacrosDetailsSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OmniMesMacrosDetailsSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1041f84e-a031-486d-b50f-e653cc97538b"));
		}

		#endregion

	}

	#endregion

	#region Class: OmniMesMacrosDetails

	/// <summary>
	/// OmniMesMacrosDetails.
	/// </summary>
	/// <remarks>
	/// Details for OmniMessageMacros.
	/// </remarks>
	public class OmniMesMacrosDetails : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public OmniMesMacrosDetails(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OmniMesMacrosDetails";
		}

		public OmniMesMacrosDetails(OmniMesMacrosDetails source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid MacrosId {
			get {
				return GetTypedColumnValue<Guid>("MacrosId");
			}
			set {
				SetColumnValue("MacrosId", value);
				_macros = null;
			}
		}

		private OmniMessageMacros _macros;
		/// <summary>
		/// Macros.
		/// </summary>
		/// <remarks>
		/// Foreign key to OmniMessageMacros.
		/// </remarks>
		public OmniMessageMacros Macros {
			get {
				return _macros ??
					(_macros = LookupColumnEntities.GetEntity("Macros") as OmniMessageMacros);
			}
		}

		/// <summary>
		/// Metadata.
		/// </summary>
		/// <remarks>
		/// Array of values for macros placeholders.
		/// </remarks>
		public string Metadata {
			get {
				return GetTypedColumnValue<string>("Metadata");
			}
			set {
				SetColumnValue("Metadata", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OmniMesMacrosDetails_OmnichannelMessagingEventsProcess(UserConnection);
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
			return new OmniMesMacrosDetails(this);
		}

		#endregion

	}

	#endregion

	#region Class: OmniMesMacrosDetails_OmnichannelMessagingEventsProcess

	/// <exclude/>
	public partial class OmniMesMacrosDetails_OmnichannelMessagingEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : OmniMesMacrosDetails
	{

		public OmniMesMacrosDetails_OmnichannelMessagingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OmniMesMacrosDetails_OmnichannelMessagingEventsProcess";
			SchemaUId = new Guid("1041f84e-a031-486d-b50f-e653cc97538b");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("1041f84e-a031-486d-b50f-e653cc97538b");
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

	#region Class: OmniMesMacrosDetails_OmnichannelMessagingEventsProcess

	/// <exclude/>
	public class OmniMesMacrosDetails_OmnichannelMessagingEventsProcess : OmniMesMacrosDetails_OmnichannelMessagingEventsProcess<OmniMesMacrosDetails>
	{

		public OmniMesMacrosDetails_OmnichannelMessagingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OmniMesMacrosDetails_OmnichannelMessagingEventsProcess

	public partial class OmniMesMacrosDetails_OmnichannelMessagingEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: OmniMesMacrosDetailsEventsProcess

	/// <exclude/>
	public class OmniMesMacrosDetailsEventsProcess : OmniMesMacrosDetails_OmnichannelMessagingEventsProcess
	{

		public OmniMesMacrosDetailsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

