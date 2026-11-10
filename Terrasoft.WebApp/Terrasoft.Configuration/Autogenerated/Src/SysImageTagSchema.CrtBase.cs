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

	#region Class: SysImageTagSchema

	/// <exclude/>
	public class SysImageTagSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysImageTagSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysImageTagSchema(SysImageTagSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysImageTagSchema(SysImageTagSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("639a7449-ad50-45ba-9b53-53adf46197ad");
			RealUId = new Guid("639a7449-ad50-45ba-9b53-53adf46197ad");
			Name = "SysImageTag";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("c70416a1-d180-47d0-9b53-90527ee8764a");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
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
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("bbae216d-d00d-df79-b396-16268ae83e84"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("639a7449-ad50-45ba-9b53-53adf46197ad"),
				ModifiedInSchemaUId = new Guid("639a7449-ad50-45ba-9b53-53adf46197ad"),
				CreatedInPackageId = new Guid("c70416a1-d180-47d0-9b53-90527ee8764a")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysImageTag(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysImageTag_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysImageTagSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysImageTagSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("639a7449-ad50-45ba-9b53-53adf46197ad"));
		}

		#endregion

	}

	#endregion

	#region Class: SysImageTag

	/// <summary>
	/// Object.
	/// </summary>
	public class SysImageTag : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysImageTag(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysImageTag";
		}

		public SysImageTag(SysImageTag source)
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
			var process = new SysImageTag_CrtBaseEventsProcess(UserConnection);
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
			return new SysImageTag(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysImageTag_CrtBaseEventsProcess

	/// <exclude/>
	public partial class SysImageTag_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysImageTag
	{

		public SysImageTag_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysImageTag_CrtBaseEventsProcess";
			SchemaUId = new Guid("639a7449-ad50-45ba-9b53-53adf46197ad");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("639a7449-ad50-45ba-9b53-53adf46197ad");
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

	#region Class: SysImageTag_CrtBaseEventsProcess

	/// <exclude/>
	public class SysImageTag_CrtBaseEventsProcess : SysImageTag_CrtBaseEventsProcess<SysImageTag>
	{

		public SysImageTag_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysImageTag_CrtBaseEventsProcess

	public partial class SysImageTag_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysImageTagEventsProcess

	/// <exclude/>
	public class SysImageTagEventsProcess : SysImageTag_CrtBaseEventsProcess
	{

		public SysImageTagEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

