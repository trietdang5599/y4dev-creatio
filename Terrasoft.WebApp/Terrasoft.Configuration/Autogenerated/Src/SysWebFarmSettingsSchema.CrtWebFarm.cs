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

	#region Class: SysWebFarmSettingsSchema

	/// <exclude/>
	public class SysWebFarmSettingsSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysWebFarmSettingsSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysWebFarmSettingsSchema(SysWebFarmSettingsSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysWebFarmSettingsSchema(SysWebFarmSettingsSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0225918a-c8fd-48a3-82f9-8720302b7961");
			RealUId = new Guid("0225918a-c8fd-48a3-82f9-8720302b7961");
			Name = "SysWebFarmSettings";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("c82d1860-5544-4f6b-a90c-8f0bca662882");
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
			if (Columns.FindByUId(new Guid("8dc19f3d-dc5d-4d48-8066-b2a473cd6fcb")) == null) {
				Columns.Add(CreateValueColumn());
			}
			if (Columns.FindByUId(new Guid("f842bcef-ce30-4fe4-9b18-784869a83611")) == null) {
				Columns.Add(CreateKeyColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("8dc19f3d-dc5d-4d48-8066-b2a473cd6fcb"),
				Name = @"Value",
				CreatedInSchemaUId = new Guid("0225918a-c8fd-48a3-82f9-8720302b7961"),
				ModifiedInSchemaUId = new Guid("0225918a-c8fd-48a3-82f9-8720302b7961"),
				CreatedInPackageId = new Guid("c82d1860-5544-4f6b-a90c-8f0bca662882")
			};
		}

		protected virtual EntitySchemaColumn CreateKeyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("f842bcef-ce30-4fe4-9b18-784869a83611"),
				Name = @"Key",
				CreatedInSchemaUId = new Guid("0225918a-c8fd-48a3-82f9-8720302b7961"),
				ModifiedInSchemaUId = new Guid("0225918a-c8fd-48a3-82f9-8720302b7961"),
				CreatedInPackageId = new Guid("c82d1860-5544-4f6b-a90c-8f0bca662882")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysWebFarmSettings(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysWebFarmSettings_CrtWebFarmEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysWebFarmSettingsSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysWebFarmSettingsSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0225918a-c8fd-48a3-82f9-8720302b7961"));
		}

		#endregion

	}

	#endregion

	#region Class: SysWebFarmSettings

	/// <summary>
	/// Web farm settings.
	/// </summary>
	public class SysWebFarmSettings : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysWebFarmSettings(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysWebFarmSettings";
		}

		public SysWebFarmSettings(SysWebFarmSettings source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Value.
		/// </summary>
		public string Value {
			get {
				return GetTypedColumnValue<string>("Value");
			}
			set {
				SetColumnValue("Value", value);
			}
		}

		/// <summary>
		/// Key.
		/// </summary>
		public string Key {
			get {
				return GetTypedColumnValue<string>("Key");
			}
			set {
				SetColumnValue("Key", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysWebFarmSettings_CrtWebFarmEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleting += (s, e) => ThrowEvent("SysWebFarmSettingsDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysWebFarmSettingsInserted", e);
			Inserting += (s, e) => ThrowEvent("SysWebFarmSettingsInserting", e);
			Saved += (s, e) => ThrowEvent("SysWebFarmSettingsSaved", e);
			Saving += (s, e) => ThrowEvent("SysWebFarmSettingsSaving", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysWebFarmSettings(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysWebFarmSettings_CrtWebFarmEventsProcess

	/// <exclude/>
	public partial class SysWebFarmSettings_CrtWebFarmEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysWebFarmSettings
	{

		public SysWebFarmSettings_CrtWebFarmEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysWebFarmSettings_CrtWebFarmEventsProcess";
			SchemaUId = new Guid("0225918a-c8fd-48a3-82f9-8720302b7961");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("0225918a-c8fd-48a3-82f9-8720302b7961");
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

	#region Class: SysWebFarmSettings_CrtWebFarmEventsProcess

	/// <exclude/>
	public class SysWebFarmSettings_CrtWebFarmEventsProcess : SysWebFarmSettings_CrtWebFarmEventsProcess<SysWebFarmSettings>
	{

		public SysWebFarmSettings_CrtWebFarmEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysWebFarmSettings_CrtWebFarmEventsProcess

	public partial class SysWebFarmSettings_CrtWebFarmEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysWebFarmSettingsEventsProcess

	/// <exclude/>
	public class SysWebFarmSettingsEventsProcess : SysWebFarmSettings_CrtWebFarmEventsProcess
	{

		public SysWebFarmSettingsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

