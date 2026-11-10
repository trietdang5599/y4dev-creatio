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

	#region Class: OmniMessageMacrosSchema

	/// <exclude/>
	public class OmniMessageMacrosSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public OmniMessageMacrosSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OmniMessageMacrosSchema(OmniMessageMacrosSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OmniMessageMacrosSchema(OmniMessageMacrosSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4b9aeea6-e0ef-4bdf-adfc-2afd1cb75a92");
			RealUId = new Guid("4b9aeea6-e0ef-4bdf-adfc-2afd1cb75a92");
			Name = "OmniMessageMacros";
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
			if (Columns.FindByUId(new Guid("f997317e-bc7a-ca1b-26d1-768ed2dc639b")) == null) {
				Columns.Add(CreateDescriptionColumn());
			}
			if (Columns.FindByUId(new Guid("261707f9-41e7-404b-0f4b-13b34867a55a")) == null) {
				Columns.Add(CreateConvertorClassColumn());
			}
			if (Columns.FindByUId(new Guid("957ba833-7a84-f61b-dc8c-14ec7f2dd07d")) == null) {
				Columns.Add(CreateMacrosColumn());
			}
			if (Columns.FindByUId(new Guid("7d23fdf3-6fa3-008c-ff75-9b7eda26cfa8")) == null) {
				Columns.Add(CreateCodeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateDescriptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("f997317e-bc7a-ca1b-26d1-768ed2dc639b"),
				Name = @"Description",
				CreatedInSchemaUId = new Guid("4b9aeea6-e0ef-4bdf-adfc-2afd1cb75a92"),
				ModifiedInSchemaUId = new Guid("4b9aeea6-e0ef-4bdf-adfc-2afd1cb75a92"),
				CreatedInPackageId = new Guid("f4d2410e-0606-46e8-a991-9e265303d628")
			};
		}

		protected virtual EntitySchemaColumn CreateConvertorClassColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("261707f9-41e7-404b-0f4b-13b34867a55a"),
				Name = @"ConvertorClass",
				CreatedInSchemaUId = new Guid("4b9aeea6-e0ef-4bdf-adfc-2afd1cb75a92"),
				ModifiedInSchemaUId = new Guid("4b9aeea6-e0ef-4bdf-adfc-2afd1cb75a92"),
				CreatedInPackageId = new Guid("f4d2410e-0606-46e8-a991-9e265303d628")
			};
		}

		protected virtual EntitySchemaColumn CreateMacrosColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("957ba833-7a84-f61b-dc8c-14ec7f2dd07d"),
				Name = @"Macros",
				CreatedInSchemaUId = new Guid("4b9aeea6-e0ef-4bdf-adfc-2afd1cb75a92"),
				ModifiedInSchemaUId = new Guid("4b9aeea6-e0ef-4bdf-adfc-2afd1cb75a92"),
				CreatedInPackageId = new Guid("f4d2410e-0606-46e8-a991-9e265303d628"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("7d23fdf3-6fa3-008c-ff75-9b7eda26cfa8"),
				Name = @"Code",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("4b9aeea6-e0ef-4bdf-adfc-2afd1cb75a92"),
				ModifiedInSchemaUId = new Guid("4b9aeea6-e0ef-4bdf-adfc-2afd1cb75a92"),
				CreatedInPackageId = new Guid("08afff10-3d0c-4f3d-b6a0-28a42952a988")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new OmniMessageMacros(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OmniMessageMacros_OmnichannelMessagingEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OmniMessageMacrosSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OmniMessageMacrosSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4b9aeea6-e0ef-4bdf-adfc-2afd1cb75a92"));
		}

		#endregion

	}

	#endregion

	#region Class: OmniMessageMacros

	/// <summary>
	/// OmniMessageMacros.
	/// </summary>
	/// <remarks>
	/// Macros message entity.
	/// </remarks>
	public class OmniMessageMacros : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public OmniMessageMacros(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OmniMessageMacros";
		}

		public OmniMessageMacros(OmniMessageMacros source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Description.
		/// </summary>
		/// <remarks>
		/// Explanation of macros parameters.
		/// </remarks>
		public string Description {
			get {
				return GetTypedColumnValue<string>("Description");
			}
			set {
				SetColumnValue("Description", value);
			}
		}

		/// <summary>
		/// ConvertorClass.
		/// </summary>
		/// <remarks>
		/// Name of the C# class for processing macros.
		/// </remarks>
		public string ConvertorClass {
			get {
				return GetTypedColumnValue<string>("ConvertorClass");
			}
			set {
				SetColumnValue("ConvertorClass", value);
			}
		}

		/// <summary>
		/// Macros.
		/// </summary>
		/// <remarks>
		/// Message template with placeholders (e.g., {0}).
		/// </remarks>
		public string Macros {
			get {
				return GetTypedColumnValue<string>("Macros");
			}
			set {
				SetColumnValue("Macros", value);
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
			var process = new OmniMessageMacros_OmnichannelMessagingEventsProcess(UserConnection);
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
			return new OmniMessageMacros(this);
		}

		#endregion

	}

	#endregion

	#region Class: OmniMessageMacros_OmnichannelMessagingEventsProcess

	/// <exclude/>
	public partial class OmniMessageMacros_OmnichannelMessagingEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : OmniMessageMacros
	{

		public OmniMessageMacros_OmnichannelMessagingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OmniMessageMacros_OmnichannelMessagingEventsProcess";
			SchemaUId = new Guid("4b9aeea6-e0ef-4bdf-adfc-2afd1cb75a92");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("4b9aeea6-e0ef-4bdf-adfc-2afd1cb75a92");
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

	#region Class: OmniMessageMacros_OmnichannelMessagingEventsProcess

	/// <exclude/>
	public class OmniMessageMacros_OmnichannelMessagingEventsProcess : OmniMessageMacros_OmnichannelMessagingEventsProcess<OmniMessageMacros>
	{

		public OmniMessageMacros_OmnichannelMessagingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OmniMessageMacros_OmnichannelMessagingEventsProcess

	public partial class OmniMessageMacros_OmnichannelMessagingEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: OmniMessageMacrosEventsProcess

	/// <exclude/>
	public class OmniMessageMacrosEventsProcess : OmniMessageMacros_OmnichannelMessagingEventsProcess
	{

		public OmniMessageMacrosEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

