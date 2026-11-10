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

	#region Class: SysDcmSchemaInSettingsSchema

	/// <exclude/>
	public class SysDcmSchemaInSettingsSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysDcmSchemaInSettingsSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysDcmSchemaInSettingsSchema(SysDcmSchemaInSettingsSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysDcmSchemaInSettingsSchema(SysDcmSchemaInSettingsSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("91b4bc57-8490-442f-9036-62eaefe28ef0");
			RealUId = new Guid("91b4bc57-8490-442f-9036-62eaefe28ef0");
			Name = "SysDcmSchemaInSettings";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("60220118-8883-44e1-afa4-8845f944d697");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("a18861e7-c840-4cae-9dd6-30277b513dc9")) == null) {
				Columns.Add(CreateSysDcmSettingsColumn());
			}
			if (Columns.FindByUId(new Guid("cec2ae4b-d2de-4c80-99a0-a59dc2a154cd")) == null) {
				Columns.Add(CreateSysDcmSchemaUIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysDcmSettingsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("a18861e7-c840-4cae-9dd6-30277b513dc9"),
				Name = @"SysDcmSettings",
				ReferenceSchemaUId = new Guid("ee9f7e0e-eab3-45ba-ae0d-67ab41858d5c"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("91b4bc57-8490-442f-9036-62eaefe28ef0"),
				ModifiedInSchemaUId = new Guid("91b4bc57-8490-442f-9036-62eaefe28ef0"),
				CreatedInPackageId = new Guid("60220118-8883-44e1-afa4-8845f944d697")
			};
		}

		protected virtual EntitySchemaColumn CreateSysDcmSchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("cec2ae4b-d2de-4c80-99a0-a59dc2a154cd"),
				Name = @"SysDcmSchemaUId",
				CreatedInSchemaUId = new Guid("91b4bc57-8490-442f-9036-62eaefe28ef0"),
				ModifiedInSchemaUId = new Guid("91b4bc57-8490-442f-9036-62eaefe28ef0"),
				CreatedInPackageId = new Guid("60220118-8883-44e1-afa4-8845f944d697")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysDcmSchemaInSettings(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysDcmSchemaInSettings_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysDcmSchemaInSettingsSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysDcmSchemaInSettingsSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("91b4bc57-8490-442f-9036-62eaefe28ef0"));
		}

		#endregion

	}

	#endregion

	#region Class: SysDcmSchemaInSettings

	/// <summary>
	/// SysDcmSchemaInSettings.
	/// </summary>
	public class SysDcmSchemaInSettings : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysDcmSchemaInSettings(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysDcmSchemaInSettings";
		}

		public SysDcmSchemaInSettings(SysDcmSchemaInSettings source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SysDcmSettingsId {
			get {
				return GetTypedColumnValue<Guid>("SysDcmSettingsId");
			}
			set {
				SetColumnValue("SysDcmSettingsId", value);
				_sysDcmSettings = null;
			}
		}

		private SysDcmSettings _sysDcmSettings;
		/// <summary>
		/// Case schema settings.
		/// </summary>
		public SysDcmSettings SysDcmSettings {
			get {
				return _sysDcmSettings ??
					(_sysDcmSettings = LookupColumnEntities.GetEntity("SysDcmSettings") as SysDcmSettings);
			}
		}

		/// <summary>
		/// Case schema identifier.
		/// </summary>
		public Guid SysDcmSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("SysDcmSchemaUId");
			}
			set {
				SetColumnValue("SysDcmSchemaUId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysDcmSchemaInSettings_CrtBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysDcmSchemaInSettingsDeleted", e);
			Validating += (s, e) => ThrowEvent("SysDcmSchemaInSettingsValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysDcmSchemaInSettings(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysDcmSchemaInSettings_CrtBaseEventsProcess

	/// <exclude/>
	public partial class SysDcmSchemaInSettings_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysDcmSchemaInSettings
	{

		public SysDcmSchemaInSettings_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysDcmSchemaInSettings_CrtBaseEventsProcess";
			SchemaUId = new Guid("91b4bc57-8490-442f-9036-62eaefe28ef0");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("91b4bc57-8490-442f-9036-62eaefe28ef0");
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

	#region Class: SysDcmSchemaInSettings_CrtBaseEventsProcess

	/// <exclude/>
	public class SysDcmSchemaInSettings_CrtBaseEventsProcess : SysDcmSchemaInSettings_CrtBaseEventsProcess<SysDcmSchemaInSettings>
	{

		public SysDcmSchemaInSettings_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysDcmSchemaInSettings_CrtBaseEventsProcess

	public partial class SysDcmSchemaInSettings_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysDcmSchemaInSettingsEventsProcess

	/// <exclude/>
	public class SysDcmSchemaInSettingsEventsProcess : SysDcmSchemaInSettings_CrtBaseEventsProcess
	{

		public SysDcmSchemaInSettingsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

