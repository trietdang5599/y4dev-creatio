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

	#region Class: SysIdentityProviderSchema

	/// <exclude/>
	public class SysIdentityProviderSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public SysIdentityProviderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysIdentityProviderSchema(SysIdentityProviderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysIdentityProviderSchema(SysIdentityProviderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateNameIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = true
			};
			index.UId = new Guid("9c98c5e6-d350-01d3-6d78-e208c897c1e1");
			index.Name = "Name";
			index.CreatedInSchemaUId = new Guid("69b7d2ca-4864-45d1-8a0b-d0fe4b6bc12d");
			index.ModifiedInSchemaUId = new Guid("69b7d2ca-4864-45d1-8a0b-d0fe4b6bc12d");
			index.CreatedInPackageId = new Guid("5c5d2e15-85e3-46de-ba5d-56368b920cde");
			EntitySchemaIndexColumn nameIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("fa324290-b476-8820-5972-f5c17cf91231"),
				ColumnUId = new Guid("736c30a7-c0ec-4fa9-b034-2552b319b633"),
				CreatedInSchemaUId = new Guid("69b7d2ca-4864-45d1-8a0b-d0fe4b6bc12d"),
				ModifiedInSchemaUId = new Guid("69b7d2ca-4864-45d1-8a0b-d0fe4b6bc12d"),
				CreatedInPackageId = new Guid("5c5d2e15-85e3-46de-ba5d-56368b920cde"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(nameIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("69b7d2ca-4864-45d1-8a0b-d0fe4b6bc12d");
			RealUId = new Guid("69b7d2ca-4864-45d1-8a0b-d0fe4b6bc12d");
			Name = "SysIdentityProvider";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("564abb0b-7665-4246-9a99-40c2c6eb2580");
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
			if (Columns.FindByUId(new Guid("8bdff767-e5f9-d64c-d396-6fe773f32576")) == null) {
				Columns.Add(CreateClientIdColumn());
			}
			if (Columns.FindByUId(new Guid("4377b12e-c50e-8f88-b7a7-3a62626b4953")) == null) {
				Columns.Add(CreateServerUrlColumn());
			}
			if (Columns.FindByUId(new Guid("8d20021e-ad47-1f33-b502-e4d885451fcf")) == null) {
				Columns.Add(CreateClientSecretColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateClientIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("8bdff767-e5f9-d64c-d396-6fe773f32576"),
				Name = @"ClientId",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("69b7d2ca-4864-45d1-8a0b-d0fe4b6bc12d"),
				ModifiedInSchemaUId = new Guid("69b7d2ca-4864-45d1-8a0b-d0fe4b6bc12d"),
				CreatedInPackageId = new Guid("564abb0b-7665-4246-9a99-40c2c6eb2580")
			};
		}

		protected virtual EntitySchemaColumn CreateServerUrlColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("4377b12e-c50e-8f88-b7a7-3a62626b4953"),
				Name = @"ServerUrl",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("69b7d2ca-4864-45d1-8a0b-d0fe4b6bc12d"),
				ModifiedInSchemaUId = new Guid("69b7d2ca-4864-45d1-8a0b-d0fe4b6bc12d"),
				CreatedInPackageId = new Guid("564abb0b-7665-4246-9a99-40c2c6eb2580")
			};
		}

		protected virtual EntitySchemaColumn CreateClientSecretColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("SecureText")) {
				UId = new Guid("8d20021e-ad47-1f33-b502-e4d885451fcf"),
				Name = @"ClientSecret",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("69b7d2ca-4864-45d1-8a0b-d0fe4b6bc12d"),
				ModifiedInSchemaUId = new Guid("69b7d2ca-4864-45d1-8a0b-d0fe4b6bc12d"),
				CreatedInPackageId = new Guid("564abb0b-7665-4246-9a99-40c2c6eb2580")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateNameIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysIdentityProvider(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysIdentityProvider_CrtIdentityManagementEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysIdentityProviderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysIdentityProviderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("69b7d2ca-4864-45d1-8a0b-d0fe4b6bc12d"));
		}

		#endregion

	}

	#endregion

	#region Class: SysIdentityProvider

	/// <summary>
	/// Identity provider.
	/// </summary>
	public class SysIdentityProvider : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public SysIdentityProvider(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysIdentityProvider";
		}

		public SysIdentityProvider(SysIdentityProvider source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Client Id.
		/// </summary>
		public string ClientId {
			get {
				return GetTypedColumnValue<string>("ClientId");
			}
			set {
				SetColumnValue("ClientId", value);
			}
		}

		/// <summary>
		/// Base URL.
		/// </summary>
		public string ServerUrl {
			get {
				return GetTypedColumnValue<string>("ServerUrl");
			}
			set {
				SetColumnValue("ServerUrl", value);
			}
		}

		/// <summary>
		/// Client secret.
		/// </summary>
		public string ClientSecret {
			get {
				return GetTypedColumnValue<string>("ClientSecret");
			}
			set {
				SetColumnValue("ClientSecret", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysIdentityProvider_CrtIdentityManagementEventsProcess(UserConnection);
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
			return new SysIdentityProvider(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysIdentityProvider_CrtIdentityManagementEventsProcess

	/// <exclude/>
	public partial class SysIdentityProvider_CrtIdentityManagementEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysIdentityProvider
	{

		public SysIdentityProvider_CrtIdentityManagementEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysIdentityProvider_CrtIdentityManagementEventsProcess";
			SchemaUId = new Guid("69b7d2ca-4864-45d1-8a0b-d0fe4b6bc12d");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("69b7d2ca-4864-45d1-8a0b-d0fe4b6bc12d");
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

	#region Class: SysIdentityProvider_CrtIdentityManagementEventsProcess

	/// <exclude/>
	public class SysIdentityProvider_CrtIdentityManagementEventsProcess : SysIdentityProvider_CrtIdentityManagementEventsProcess<SysIdentityProvider>
	{

		public SysIdentityProvider_CrtIdentityManagementEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysIdentityProvider_CrtIdentityManagementEventsProcess

	public partial class SysIdentityProvider_CrtIdentityManagementEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysIdentityProviderEventsProcess

	/// <exclude/>
	public class SysIdentityProviderEventsProcess : SysIdentityProvider_CrtIdentityManagementEventsProcess
	{

		public SysIdentityProviderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

