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

	#region Class: SysExtensionCombinationModeSchema

	/// <exclude/>
	public class SysExtensionCombinationModeSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public SysExtensionCombinationModeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysExtensionCombinationModeSchema(SysExtensionCombinationModeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysExtensionCombinationModeSchema(SysExtensionCombinationModeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("2683bf9d-7fdb-4666-a438-46064658787f");
			RealUId = new Guid("2683bf9d-7fdb-4666-a438-46064658787f");
			Name = "SysExtensionCombinationMode";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("a5e2b265-8078-4de9-a58f-70804c80c57f");
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
			if (Columns.FindByUId(new Guid("5d5be869-1f12-8494-a03e-0264330e7803")) == null) {
				Columns.Add(CreateCodeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("5d5be869-1f12-8494-a03e-0264330e7803"),
				Name = @"Code",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("2683bf9d-7fdb-4666-a438-46064658787f"),
				ModifiedInSchemaUId = new Guid("2683bf9d-7fdb-4666-a438-46064658787f"),
				CreatedInPackageId = new Guid("a5e2b265-8078-4de9-a58f-70804c80c57f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysExtensionCombinationMode(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysExtensionCombinationMode_CrtCoreBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysExtensionCombinationModeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysExtensionCombinationModeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2683bf9d-7fdb-4666-a438-46064658787f"));
		}

		#endregion

	}

	#endregion

	#region Class: SysExtensionCombinationMode

	/// <summary>
	/// Extension combination mode.
	/// </summary>
	public class SysExtensionCombinationMode : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public SysExtensionCombinationMode(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysExtensionCombinationMode";
		}

		public SysExtensionCombinationMode(SysExtensionCombinationMode source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Code.
		/// </summary>
		public int Code {
			get {
				return GetTypedColumnValue<int>("Code");
			}
			set {
				SetColumnValue("Code", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysExtensionCombinationMode_CrtCoreBaseEventsProcess(UserConnection);
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
			return new SysExtensionCombinationMode(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysExtensionCombinationMode_CrtCoreBaseEventsProcess

	/// <exclude/>
	public partial class SysExtensionCombinationMode_CrtCoreBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysExtensionCombinationMode
	{

		public SysExtensionCombinationMode_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysExtensionCombinationMode_CrtCoreBaseEventsProcess";
			SchemaUId = new Guid("2683bf9d-7fdb-4666-a438-46064658787f");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("2683bf9d-7fdb-4666-a438-46064658787f");
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

	#region Class: SysExtensionCombinationMode_CrtCoreBaseEventsProcess

	/// <exclude/>
	public class SysExtensionCombinationMode_CrtCoreBaseEventsProcess : SysExtensionCombinationMode_CrtCoreBaseEventsProcess<SysExtensionCombinationMode>
	{

		public SysExtensionCombinationMode_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysExtensionCombinationMode_CrtCoreBaseEventsProcess

	public partial class SysExtensionCombinationMode_CrtCoreBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysExtensionCombinationModeEventsProcess

	/// <exclude/>
	public class SysExtensionCombinationModeEventsProcess : SysExtensionCombinationMode_CrtCoreBaseEventsProcess
	{

		public SysExtensionCombinationModeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

