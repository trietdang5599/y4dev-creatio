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

	#region Class: MobileRulesModeSchema

	/// <exclude/>
	public class MobileRulesModeSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public MobileRulesModeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public MobileRulesModeSchema(MobileRulesModeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public MobileRulesModeSchema(MobileRulesModeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("51cbeda2-8902-47a7-ab7d-c719f29be08d");
			RealUId = new Guid("51cbeda2-8902-47a7-ab7d-c719f29be08d");
			Name = "MobileRulesMode";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("42d46b9b-0e9b-4c59-9e77-931ed51c08eb");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = false;
			UseLiveEditing = false;
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
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("192201fa-eaba-998c-4f79-5c59d6aac830"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("51cbeda2-8902-47a7-ab7d-c719f29be08d"),
				ModifiedInSchemaUId = new Guid("51cbeda2-8902-47a7-ab7d-c719f29be08d"),
				CreatedInPackageId = new Guid("42d46b9b-0e9b-4c59-9e77-931ed51c08eb"),
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
			return new MobileRulesMode(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new MobileRulesMode_CrtMobile7xEventsProcess(userConnection);
		}

		public override object Clone() {
			return new MobileRulesModeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new MobileRulesModeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("51cbeda2-8902-47a7-ab7d-c719f29be08d"));
		}

		#endregion

	}

	#endregion

	#region Class: MobileRulesMode

	/// <summary>
	/// Mode of business rules (used in mobile app).
	/// </summary>
	public class MobileRulesMode : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public MobileRulesMode(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MobileRulesMode";
		}

		public MobileRulesMode(MobileRulesMode source)
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
			var process = new MobileRulesMode_CrtMobile7xEventsProcess(UserConnection);
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
			return new MobileRulesMode(this);
		}

		#endregion

	}

	#endregion

	#region Class: MobileRulesMode_CrtMobile7xEventsProcess

	/// <exclude/>
	public partial class MobileRulesMode_CrtMobile7xEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : MobileRulesMode
	{

		public MobileRulesMode_CrtMobile7xEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "MobileRulesMode_CrtMobile7xEventsProcess";
			SchemaUId = new Guid("51cbeda2-8902-47a7-ab7d-c719f29be08d");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("51cbeda2-8902-47a7-ab7d-c719f29be08d");
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

	#region Class: MobileRulesMode_CrtMobile7xEventsProcess

	/// <exclude/>
	public class MobileRulesMode_CrtMobile7xEventsProcess : MobileRulesMode_CrtMobile7xEventsProcess<MobileRulesMode>
	{

		public MobileRulesMode_CrtMobile7xEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: MobileRulesMode_CrtMobile7xEventsProcess

	public partial class MobileRulesMode_CrtMobile7xEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: MobileRulesModeEventsProcess

	/// <exclude/>
	public class MobileRulesModeEventsProcess : MobileRulesMode_CrtMobile7xEventsProcess
	{

		public MobileRulesModeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

