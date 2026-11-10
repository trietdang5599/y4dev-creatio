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

	#region Class: TranslationStatusSchema

	/// <exclude/>
	public class TranslationStatusSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public TranslationStatusSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public TranslationStatusSchema(TranslationStatusSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public TranslationStatusSchema(TranslationStatusSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("9a6e017b-b97e-4c15-ac65-37f60138027e");
			RealUId = new Guid("9a6e017b-b97e-4c15-ac65-37f60138027e");
			Name = "TranslationStatus";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("2f244451-ec5e-494f-9790-8d930a80007c");
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
			if (Columns.FindByUId(new Guid("81c105b3-59a1-56e6-5970-c78dbd826eb3")) == null) {
				Columns.Add(CreateSysCultureColumn());
			}
			if (Columns.FindByUId(new Guid("d076030f-fa49-705f-7f95-0ea00d3aa64d")) == null) {
				Columns.Add(CreateStaticContentValueColumn());
			}
			if (Columns.FindByUId(new Guid("9c853231-78d4-4a2f-bef8-30f7a0fccaaa")) == null) {
				Columns.Add(CreateActualLocalizationValueColumn());
			}
			if (Columns.FindByUId(new Guid("157c10fd-1071-91eb-80d3-43f8b65c88d7")) == null) {
				Columns.Add(CreateExpectedLocalizationValueColumn());
			}
			if (Columns.FindByUId(new Guid("b245c627-4f5d-c6f5-81c4-ed66df3e62e2")) == null) {
				Columns.Add(CreateTranslationKeyColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysCultureColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("81c105b3-59a1-56e6-5970-c78dbd826eb3"),
				Name = @"SysCulture",
				ReferenceSchemaUId = new Guid("ffc193e1-04bc-472b-bdc0-3333d1df84e4"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("9a6e017b-b97e-4c15-ac65-37f60138027e"),
				ModifiedInSchemaUId = new Guid("9a6e017b-b97e-4c15-ac65-37f60138027e"),
				CreatedInPackageId = new Guid("2f244451-ec5e-494f-9790-8d930a80007c"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateStaticContentValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("d076030f-fa49-705f-7f95-0ea00d3aa64d"),
				Name = @"StaticContentValue",
				CreatedInSchemaUId = new Guid("9a6e017b-b97e-4c15-ac65-37f60138027e"),
				ModifiedInSchemaUId = new Guid("9a6e017b-b97e-4c15-ac65-37f60138027e"),
				CreatedInPackageId = new Guid("2f244451-ec5e-494f-9790-8d930a80007c")
			};
		}

		protected virtual EntitySchemaColumn CreateActualLocalizationValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("9c853231-78d4-4a2f-bef8-30f7a0fccaaa"),
				Name = @"ActualLocalizationValue",
				CreatedInSchemaUId = new Guid("9a6e017b-b97e-4c15-ac65-37f60138027e"),
				ModifiedInSchemaUId = new Guid("9a6e017b-b97e-4c15-ac65-37f60138027e"),
				CreatedInPackageId = new Guid("2f244451-ec5e-494f-9790-8d930a80007c")
			};
		}

		protected virtual EntitySchemaColumn CreateExpectedLocalizationValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("157c10fd-1071-91eb-80d3-43f8b65c88d7"),
				Name = @"ExpectedLocalizationValue",
				CreatedInSchemaUId = new Guid("9a6e017b-b97e-4c15-ac65-37f60138027e"),
				ModifiedInSchemaUId = new Guid("9a6e017b-b97e-4c15-ac65-37f60138027e"),
				CreatedInPackageId = new Guid("2f244451-ec5e-494f-9790-8d930a80007c")
			};
		}

		protected virtual EntitySchemaColumn CreateTranslationKeyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("b245c627-4f5d-c6f5-81c4-ed66df3e62e2"),
				Name = @"TranslationKey",
				CreatedInSchemaUId = new Guid("9a6e017b-b97e-4c15-ac65-37f60138027e"),
				ModifiedInSchemaUId = new Guid("9a6e017b-b97e-4c15-ac65-37f60138027e"),
				CreatedInPackageId = new Guid("2f244451-ec5e-494f-9790-8d930a80007c")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new TranslationStatus(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new TranslationStatus_CrtTranslationEventsProcess(userConnection);
		}

		public override object Clone() {
			return new TranslationStatusSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new TranslationStatusSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9a6e017b-b97e-4c15-ac65-37f60138027e"));
		}

		#endregion

	}

	#endregion

	#region Class: TranslationStatus

	/// <summary>
	/// Translation validation result.
	/// </summary>
	public class TranslationStatus : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public TranslationStatus(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "TranslationStatus";
		}

		public TranslationStatus(TranslationStatus source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SysCultureId {
			get {
				return GetTypedColumnValue<Guid>("SysCultureId");
			}
			set {
				SetColumnValue("SysCultureId", value);
				_sysCulture = null;
			}
		}

		/// <exclude/>
		public string SysCultureName {
			get {
				return GetTypedColumnValue<string>("SysCultureName");
			}
			set {
				SetColumnValue("SysCultureName", value);
				if (_sysCulture != null) {
					_sysCulture.Name = value;
				}
			}
		}

		private SysCulture _sysCulture;
		/// <summary>
		/// Culture.
		/// </summary>
		public SysCulture SysCulture {
			get {
				return _sysCulture ??
					(_sysCulture = LookupColumnEntities.GetEntity("SysCulture") as SysCulture);
			}
		}

		/// <summary>
		/// Static content value.
		/// </summary>
		public string StaticContentValue {
			get {
				return GetTypedColumnValue<string>("StaticContentValue");
			}
			set {
				SetColumnValue("StaticContentValue", value);
			}
		}

		/// <summary>
		/// Actual value.
		/// </summary>
		public string ActualLocalizationValue {
			get {
				return GetTypedColumnValue<string>("ActualLocalizationValue");
			}
			set {
				SetColumnValue("ActualLocalizationValue", value);
			}
		}

		/// <summary>
		/// Expected value.
		/// </summary>
		public string ExpectedLocalizationValue {
			get {
				return GetTypedColumnValue<string>("ExpectedLocalizationValue");
			}
			set {
				SetColumnValue("ExpectedLocalizationValue", value);
			}
		}

		/// <summary>
		/// Translation key.
		/// </summary>
		public string TranslationKey {
			get {
				return GetTypedColumnValue<string>("TranslationKey");
			}
			set {
				SetColumnValue("TranslationKey", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new TranslationStatus_CrtTranslationEventsProcess(UserConnection);
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
			return new TranslationStatus(this);
		}

		#endregion

	}

	#endregion

	#region Class: TranslationStatus_CrtTranslationEventsProcess

	/// <exclude/>
	public partial class TranslationStatus_CrtTranslationEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : TranslationStatus
	{

		public TranslationStatus_CrtTranslationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "TranslationStatus_CrtTranslationEventsProcess";
			SchemaUId = new Guid("9a6e017b-b97e-4c15-ac65-37f60138027e");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("9a6e017b-b97e-4c15-ac65-37f60138027e");
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

	#region Class: TranslationStatus_CrtTranslationEventsProcess

	/// <exclude/>
	public class TranslationStatus_CrtTranslationEventsProcess : TranslationStatus_CrtTranslationEventsProcess<TranslationStatus>
	{

		public TranslationStatus_CrtTranslationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: TranslationStatus_CrtTranslationEventsProcess

	public partial class TranslationStatus_CrtTranslationEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: TranslationStatusEventsProcess

	/// <exclude/>
	public class TranslationStatusEventsProcess : TranslationStatus_CrtTranslationEventsProcess
	{

		public TranslationStatusEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

