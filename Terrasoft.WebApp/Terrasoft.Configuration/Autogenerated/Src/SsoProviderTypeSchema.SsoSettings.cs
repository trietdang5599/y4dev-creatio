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

	#region Class: SsoProviderTypeSchema

	/// <exclude/>
	public class SsoProviderTypeSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public SsoProviderTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SsoProviderTypeSchema(SsoProviderTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SsoProviderTypeSchema(SsoProviderTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("92ecd864-36c7-48ad-a8c2-2aad861077b9");
			RealUId = new Guid("92ecd864-36c7-48ad-a8c2-2aad861077b9");
			Name = "SsoProviderType";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("e5aa7639-5b66-4d72-9308-0563d89b2353");
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

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("0607fd92-fbdd-ff50-7982-aa3216f398a9")) == null) {
				Columns.Add(CreateStartSsoClientProviderColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateStartSsoClientProviderColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("0607fd92-fbdd-ff50-7982-aa3216f398a9"),
				Name = @"StartSsoClientProvider",
				CreatedInSchemaUId = new Guid("92ecd864-36c7-48ad-a8c2-2aad861077b9"),
				ModifiedInSchemaUId = new Guid("92ecd864-36c7-48ad-a8c2-2aad861077b9"),
				CreatedInPackageId = new Guid("e5aa7639-5b66-4d72-9308-0563d89b2353"),
				IsFormatValidated = true
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SsoProviderType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SsoProviderType_SsoSettingsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SsoProviderTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SsoProviderTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("92ecd864-36c7-48ad-a8c2-2aad861077b9"));
		}

		#endregion

	}

	#endregion

	#region Class: SsoProviderType

	/// <summary>
	/// SsoProviderType.
	/// </summary>
	public class SsoProviderType : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public SsoProviderType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SsoProviderType";
		}

		public SsoProviderType(SsoProviderType source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// StartSsoClientProvider.
		/// </summary>
		public string StartSsoClientProvider {
			get {
				return GetTypedColumnValue<string>("StartSsoClientProvider");
			}
			set {
				SetColumnValue("StartSsoClientProvider", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SsoProviderType_SsoSettingsEventsProcess(UserConnection);
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
			return new SsoProviderType(this);
		}

		#endregion

	}

	#endregion

	#region Class: SsoProviderType_SsoSettingsEventsProcess

	/// <exclude/>
	public partial class SsoProviderType_SsoSettingsEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : SsoProviderType
	{

		public SsoProviderType_SsoSettingsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SsoProviderType_SsoSettingsEventsProcess";
			SchemaUId = new Guid("92ecd864-36c7-48ad-a8c2-2aad861077b9");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("92ecd864-36c7-48ad-a8c2-2aad861077b9");
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

	#region Class: SsoProviderType_SsoSettingsEventsProcess

	/// <exclude/>
	public class SsoProviderType_SsoSettingsEventsProcess : SsoProviderType_SsoSettingsEventsProcess<SsoProviderType>
	{

		public SsoProviderType_SsoSettingsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SsoProviderType_SsoSettingsEventsProcess

	public partial class SsoProviderType_SsoSettingsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SsoProviderTypeEventsProcess

	/// <exclude/>
	public class SsoProviderTypeEventsProcess : SsoProviderType_SsoSettingsEventsProcess
	{

		public SsoProviderTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

