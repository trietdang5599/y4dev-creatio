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

	#region Class: EnrchTypeMappingSchema

	/// <exclude/>
	public class EnrchTypeMappingSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public EnrchTypeMappingSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public EnrchTypeMappingSchema(EnrchTypeMappingSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public EnrchTypeMappingSchema(EnrchTypeMappingSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("13100437-8e76-4668-8ef8-a899c9525400");
			RealUId = new Guid("13100437-8e76-4668-8ef8-a899c9525400");
			Name = "EnrchTypeMapping";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("c9ff5cbb-cb0e-4041-b483-395260757ab0");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("b80e3c1d-9737-4a57-9869-e302e39ad48e")) == null) {
				Columns.Add(CreateEnrchTypeColumn());
			}
			if (Columns.FindByUId(new Guid("07453a96-2a4c-4874-b67c-ec6142f2d671")) == null) {
				Columns.Add(CreateCommunicationTypeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateEnrchTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("b80e3c1d-9737-4a57-9869-e302e39ad48e"),
				Name = @"EnrchType",
				CreatedInSchemaUId = new Guid("13100437-8e76-4668-8ef8-a899c9525400"),
				ModifiedInSchemaUId = new Guid("13100437-8e76-4668-8ef8-a899c9525400"),
				CreatedInPackageId = new Guid("c9ff5cbb-cb0e-4041-b483-395260757ab0")
			};
		}

		protected virtual EntitySchemaColumn CreateCommunicationTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("07453a96-2a4c-4874-b67c-ec6142f2d671"),
				Name = @"CommunicationType",
				ReferenceSchemaUId = new Guid("d846cb4f-f18d-469e-83ff-e961f3fba873"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("13100437-8e76-4668-8ef8-a899c9525400"),
				ModifiedInSchemaUId = new Guid("13100437-8e76-4668-8ef8-a899c9525400"),
				CreatedInPackageId = new Guid("c9ff5cbb-cb0e-4041-b483-395260757ab0")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new EnrchTypeMapping(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new EnrchTypeMapping_EmailMiningEventsProcess(userConnection);
		}

		public override object Clone() {
			return new EnrchTypeMappingSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new EnrchTypeMappingSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("13100437-8e76-4668-8ef8-a899c9525400"));
		}

		#endregion

	}

	#endregion

	#region Class: EnrchTypeMapping

	/// <summary>
	/// EnrchTypeMapping.
	/// </summary>
	public class EnrchTypeMapping : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public EnrchTypeMapping(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "EnrchTypeMapping";
		}

		public EnrchTypeMapping(EnrchTypeMapping source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// EnrchType.
		/// </summary>
		public string EnrchType {
			get {
				return GetTypedColumnValue<string>("EnrchType");
			}
			set {
				SetColumnValue("EnrchType", value);
			}
		}

		/// <exclude/>
		public Guid CommunicationTypeId {
			get {
				return GetTypedColumnValue<Guid>("CommunicationTypeId");
			}
			set {
				SetColumnValue("CommunicationTypeId", value);
				_communicationType = null;
			}
		}

		/// <exclude/>
		public string CommunicationTypeName {
			get {
				return GetTypedColumnValue<string>("CommunicationTypeName");
			}
			set {
				SetColumnValue("CommunicationTypeName", value);
				if (_communicationType != null) {
					_communicationType.Name = value;
				}
			}
		}

		private CommunicationType _communicationType;
		/// <summary>
		/// CommunicationType.
		/// </summary>
		public CommunicationType CommunicationType {
			get {
				return _communicationType ??
					(_communicationType = LookupColumnEntities.GetEntity("CommunicationType") as CommunicationType);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new EnrchTypeMapping_EmailMiningEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("EnrchTypeMappingDeleted", e);
			Validating += (s, e) => ThrowEvent("EnrchTypeMappingValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new EnrchTypeMapping(this);
		}

		#endregion

	}

	#endregion

	#region Class: EnrchTypeMapping_EmailMiningEventsProcess

	/// <exclude/>
	public partial class EnrchTypeMapping_EmailMiningEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : EnrchTypeMapping
	{

		public EnrchTypeMapping_EmailMiningEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "EnrchTypeMapping_EmailMiningEventsProcess";
			SchemaUId = new Guid("13100437-8e76-4668-8ef8-a899c9525400");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("13100437-8e76-4668-8ef8-a899c9525400");
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

	#region Class: EnrchTypeMapping_EmailMiningEventsProcess

	/// <exclude/>
	public class EnrchTypeMapping_EmailMiningEventsProcess : EnrchTypeMapping_EmailMiningEventsProcess<EnrchTypeMapping>
	{

		public EnrchTypeMapping_EmailMiningEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: EnrchTypeMapping_EmailMiningEventsProcess

	public partial class EnrchTypeMapping_EmailMiningEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: EnrchTypeMappingEventsProcess

	/// <exclude/>
	public class EnrchTypeMappingEventsProcess : EnrchTypeMapping_EmailMiningEventsProcess
	{

		public EnrchTypeMappingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

