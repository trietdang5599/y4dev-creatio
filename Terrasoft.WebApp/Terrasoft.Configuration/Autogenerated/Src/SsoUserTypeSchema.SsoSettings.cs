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

	#region Class: SsoUserTypeSchema

	/// <exclude/>
	public class SsoUserTypeSchema : Terrasoft.Configuration.ConnectionTypeSchema
	{

		#region Constructors: Public

		public SsoUserTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SsoUserTypeSchema(SsoUserTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SsoUserTypeSchema(SsoUserTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c1e35112-a039-4bf4-94a0-1afce4211706");
			RealUId = new Guid("c1e35112-a039-4bf4-94a0-1afce4211706");
			Name = "SsoUserType";
			ParentSchemaUId = new Guid("15ae9439-ba1c-415d-875c-c2aa884f658e");
			ExtendParent = false;
			CreatedInPackageId = new Guid("e8fcf94c-c989-4493-bb03-10b5c86c0b32");
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
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SsoUserType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SsoUserType_SsoSettingsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SsoUserTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SsoUserTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c1e35112-a039-4bf4-94a0-1afce4211706"));
		}

		#endregion

	}

	#endregion

	#region Class: SsoUserType

	/// <summary>
	/// SSO user type .
	/// </summary>
	public class SsoUserType : Terrasoft.Configuration.ConnectionType
	{

		#region Constructors: Public

		public SsoUserType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SsoUserType";
		}

		public SsoUserType(SsoUserType source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SsoUserType_SsoSettingsEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleting += (s, e) => ThrowEvent("SsoUserTypeDeleting", e);
			Inserted += (s, e) => ThrowEvent("SsoUserTypeInserted", e);
			Inserting += (s, e) => ThrowEvent("SsoUserTypeInserting", e);
			Saved += (s, e) => ThrowEvent("SsoUserTypeSaved", e);
			Saving += (s, e) => ThrowEvent("SsoUserTypeSaving", e);
			Validating += (s, e) => ThrowEvent("SsoUserTypeValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SsoUserType(this);
		}

		#endregion

	}

	#endregion

	#region Class: SsoUserType_SsoSettingsEventsProcess

	/// <exclude/>
	public partial class SsoUserType_SsoSettingsEventsProcess<TEntity> : Terrasoft.Configuration.ConnectionType_CrtBaseEventsProcess<TEntity> where TEntity : SsoUserType
	{

		public SsoUserType_SsoSettingsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SsoUserType_SsoSettingsEventsProcess";
			SchemaUId = new Guid("c1e35112-a039-4bf4-94a0-1afce4211706");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("c1e35112-a039-4bf4-94a0-1afce4211706");
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

	#region Class: SsoUserType_SsoSettingsEventsProcess

	/// <exclude/>
	public class SsoUserType_SsoSettingsEventsProcess : SsoUserType_SsoSettingsEventsProcess<SsoUserType>
	{

		public SsoUserType_SsoSettingsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SsoUserType_SsoSettingsEventsProcess

	public partial class SsoUserType_SsoSettingsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SsoUserTypeEventsProcess

	/// <exclude/>
	public class SsoUserTypeEventsProcess : SsoUserType_SsoSettingsEventsProcess
	{

		public SsoUserTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

