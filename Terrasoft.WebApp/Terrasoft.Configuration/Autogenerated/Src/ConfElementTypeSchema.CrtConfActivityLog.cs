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

	#region Class: ConfElementTypeSchema

	/// <exclude/>
	public class ConfElementTypeSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public ConfElementTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ConfElementTypeSchema(ConfElementTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ConfElementTypeSchema(ConfElementTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b4f21ac3-d20a-4817-bdda-9e2a12a5c88e");
			RealUId = new Guid("b4f21ac3-d20a-4817-bdda-9e2a12a5c88e");
			Name = "ConfElementType";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("b442e8fe-c84e-419d-bd0d-cf5572b3d3f7");
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
			return new ConfElementType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ConfElementType_CrtConfActivityLogEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ConfElementTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ConfElementTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b4f21ac3-d20a-4817-bdda-9e2a12a5c88e"));
		}

		#endregion

	}

	#endregion

	#region Class: ConfElementType

	/// <summary>
	/// Configuration element type.
	/// </summary>
	public class ConfElementType : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public ConfElementType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ConfElementType";
		}

		public ConfElementType(ConfElementType source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ConfElementType_CrtConfActivityLogEventsProcess(UserConnection);
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
			return new ConfElementType(this);
		}

		#endregion

	}

	#endregion

	#region Class: ConfElementType_CrtConfActivityLogEventsProcess

	/// <exclude/>
	public partial class ConfElementType_CrtConfActivityLogEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : ConfElementType
	{

		public ConfElementType_CrtConfActivityLogEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ConfElementType_CrtConfActivityLogEventsProcess";
			SchemaUId = new Guid("b4f21ac3-d20a-4817-bdda-9e2a12a5c88e");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("b4f21ac3-d20a-4817-bdda-9e2a12a5c88e");
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

	#region Class: ConfElementType_CrtConfActivityLogEventsProcess

	/// <exclude/>
	public class ConfElementType_CrtConfActivityLogEventsProcess : ConfElementType_CrtConfActivityLogEventsProcess<ConfElementType>
	{

		public ConfElementType_CrtConfActivityLogEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ConfElementType_CrtConfActivityLogEventsProcess

	public partial class ConfElementType_CrtConfActivityLogEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ConfElementTypeEventsProcess

	/// <exclude/>
	public class ConfElementTypeEventsProcess : ConfElementType_CrtConfActivityLogEventsProcess
	{

		public ConfElementTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

