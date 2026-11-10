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

	#region Class: SsoIdentityTypeSchema

	/// <exclude/>
	public class SsoIdentityTypeSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public SsoIdentityTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SsoIdentityTypeSchema(SsoIdentityTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SsoIdentityTypeSchema(SsoIdentityTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("614855f4-259f-41de-8a81-a98f27c12126");
			RealUId = new Guid("614855f4-259f-41de-8a81-a98f27c12126");
			Name = "SsoIdentityType";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("0c0cefaa-76d3-43d9-b05f-e48aa147439f");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
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
			if (Columns.FindByUId(new Guid("056fd0b6-3627-f01b-a6f6-0dcf939b0c8d")) == null) {
				Columns.Add(CreateStartSsoClientProviderColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateStartSsoClientProviderColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("056fd0b6-3627-f01b-a6f6-0dcf939b0c8d"),
				Name = @"StartSsoClientProvider",
				CreatedInSchemaUId = new Guid("614855f4-259f-41de-8a81-a98f27c12126"),
				ModifiedInSchemaUId = new Guid("614855f4-259f-41de-8a81-a98f27c12126"),
				CreatedInPackageId = new Guid("e8fcf94c-c989-4493-bb03-10b5c86c0b32")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SsoIdentityType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SsoIdentityType_SsoSettingsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SsoIdentityTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SsoIdentityTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("614855f4-259f-41de-8a81-a98f27c12126"));
		}

		#endregion

	}

	#endregion

	#region Class: SsoIdentityType

	/// <summary>
	/// Sso identity type.
	/// </summary>
	public class SsoIdentityType : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public SsoIdentityType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SsoIdentityType";
		}

		public SsoIdentityType(SsoIdentityType source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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
			var process = new SsoIdentityType_SsoSettingsEventsProcess(UserConnection);
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
			return new SsoIdentityType(this);
		}

		#endregion

	}

	#endregion

	#region Class: SsoIdentityType_SsoSettingsEventsProcess

	/// <exclude/>
	public partial class SsoIdentityType_SsoSettingsEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : SsoIdentityType
	{

		public SsoIdentityType_SsoSettingsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SsoIdentityType_SsoSettingsEventsProcess";
			SchemaUId = new Guid("614855f4-259f-41de-8a81-a98f27c12126");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("614855f4-259f-41de-8a81-a98f27c12126");
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

	#region Class: SsoIdentityType_SsoSettingsEventsProcess

	/// <exclude/>
	public class SsoIdentityType_SsoSettingsEventsProcess : SsoIdentityType_SsoSettingsEventsProcess<SsoIdentityType>
	{

		public SsoIdentityType_SsoSettingsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SsoIdentityType_SsoSettingsEventsProcess

	public partial class SsoIdentityType_SsoSettingsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SsoIdentityTypeEventsProcess

	/// <exclude/>
	public class SsoIdentityTypeEventsProcess : SsoIdentityType_SsoSettingsEventsProcess
	{

		public SsoIdentityTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

