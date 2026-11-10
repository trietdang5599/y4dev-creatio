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

	#region Class: CopilotIntentTypeSchema

	/// <exclude/>
	[IsVirtual]
	public class CopilotIntentTypeSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public CopilotIntentTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CopilotIntentTypeSchema(CopilotIntentTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CopilotIntentTypeSchema(CopilotIntentTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("98aeb3cf-5caf-4a0e-964b-a9c40a043104");
			RealUId = new Guid("98aeb3cf-5caf-4a0e-964b-a9c40a043104");
			Name = "CopilotIntentType";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("800f00c8-04db-4ed1-bc94-0c44b7e5e4f0");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = false;
			UseLiveEditing = false;
			Paging.IsPageable = true;
			Filtering.IsFilterable = true;
			Sorting.IsSortable = true;
			Write.IsInsertable = true;
			Write.IsUpdatable = true;
			Write.IsDeletable = true;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryColorColumn() {
			base.InitializePrimaryColorColumn();
			PrimaryColorColumn = CreateColorColumn();
			if (Columns.FindByUId(PrimaryColorColumn.UId) == null) {
				Columns.Add(PrimaryColorColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("a4889ad8-ca47-8f5b-eaaf-536ab42e27cc")) == null) {
				Columns.Add(CreateCodeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateColorColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Color")) {
				UId = new Guid("bc0fd068-98fb-be3c-27d4-8506d86921ad"),
				Name = @"Color",
				CreatedInSchemaUId = new Guid("98aeb3cf-5caf-4a0e-964b-a9c40a043104"),
				ModifiedInSchemaUId = new Guid("98aeb3cf-5caf-4a0e-964b-a9c40a043104"),
				CreatedInPackageId = new Guid("800f00c8-04db-4ed1-bc94-0c44b7e5e4f0")
			};
		}

		protected virtual EntitySchemaColumn CreateCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("a4889ad8-ca47-8f5b-eaaf-536ab42e27cc"),
				Name = @"Code",
				CreatedInSchemaUId = new Guid("98aeb3cf-5caf-4a0e-964b-a9c40a043104"),
				ModifiedInSchemaUId = new Guid("98aeb3cf-5caf-4a0e-964b-a9c40a043104"),
				CreatedInPackageId = new Guid("800f00c8-04db-4ed1-bc94-0c44b7e5e4f0")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new CopilotIntentType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CopilotIntentType_CrtCopilotEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CopilotIntentTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CopilotIntentTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("98aeb3cf-5caf-4a0e-964b-a9c40a043104"));
		}

		#endregion

	}

	#endregion

	#region Class: CopilotIntentType

	/// <summary>
	/// Creatio.ai skill type.
	/// </summary>
	public class CopilotIntentType : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public CopilotIntentType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CopilotIntentType";
		}

		public CopilotIntentType(CopilotIntentType source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Color.
		/// </summary>
		public Color Color {
			get {
				return GetTypedColumnValue<Color>("Color");
			}
			set {
				SetColumnValue("Color", value);
			}
		}

		/// <summary>
		/// Code.
		/// </summary>
		public string Code {
			get {
				return GetTypedColumnValue<string>("Code");
			}
			set {
				SetColumnValue("Code", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CopilotIntentType_CrtCopilotEventsProcess(UserConnection);
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
			return new CopilotIntentType(this);
		}

		#endregion

	}

	#endregion

	#region Class: CopilotIntentType_CrtCopilotEventsProcess

	/// <exclude/>
	public partial class CopilotIntentType_CrtCopilotEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : CopilotIntentType
	{

		public CopilotIntentType_CrtCopilotEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CopilotIntentType_CrtCopilotEventsProcess";
			SchemaUId = new Guid("98aeb3cf-5caf-4a0e-964b-a9c40a043104");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("98aeb3cf-5caf-4a0e-964b-a9c40a043104");
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

	#region Class: CopilotIntentType_CrtCopilotEventsProcess

	/// <exclude/>
	public class CopilotIntentType_CrtCopilotEventsProcess : CopilotIntentType_CrtCopilotEventsProcess<CopilotIntentType>
	{

		public CopilotIntentType_CrtCopilotEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CopilotIntentType_CrtCopilotEventsProcess

	public partial class CopilotIntentType_CrtCopilotEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CopilotIntentTypeEventsProcess

	/// <exclude/>
	public class CopilotIntentTypeEventsProcess : CopilotIntentType_CrtCopilotEventsProcess
	{

		public CopilotIntentTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

