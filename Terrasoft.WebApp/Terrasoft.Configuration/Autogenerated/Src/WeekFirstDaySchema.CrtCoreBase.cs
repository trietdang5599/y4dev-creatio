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

	#region Class: WeekFirstDaySchema

	/// <exclude/>
	public class WeekFirstDaySchema : Terrasoft.Configuration.BaseCodeLookupSchema
	{

		#region Constructors: Public

		public WeekFirstDaySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public WeekFirstDaySchema(WeekFirstDaySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public WeekFirstDaySchema(WeekFirstDaySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("268b91f8-f520-4a48-9864-f2350d841216");
			RealUId = new Guid("268b91f8-f520-4a48-9864-f2350d841216");
			Name = "WeekFirstDay";
			ParentSchemaUId = new Guid("2681062b-df59-4e52-89ed-f9b7dc909ab2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("95a133a1-cd5f-4df8-af8f-ad440775d7d1");
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
			UseRecordDeactivation = true;
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
			return new WeekFirstDay(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new WeekFirstDay_CrtCoreBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new WeekFirstDaySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new WeekFirstDaySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("268b91f8-f520-4a48-9864-f2350d841216"));
		}

		#endregion

	}

	#endregion

	#region Class: WeekFirstDay

	/// <summary>
	/// First day of week.
	/// </summary>
	public class WeekFirstDay : Terrasoft.Configuration.BaseCodeLookup
	{

		#region Constructors: Public

		public WeekFirstDay(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "WeekFirstDay";
		}

		public WeekFirstDay(WeekFirstDay source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new WeekFirstDay_CrtCoreBaseEventsProcess(UserConnection);
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
			return new WeekFirstDay(this);
		}

		#endregion

	}

	#endregion

	#region Class: WeekFirstDay_CrtCoreBaseEventsProcess

	/// <exclude/>
	public partial class WeekFirstDay_CrtCoreBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseCodeLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : WeekFirstDay
	{

		public WeekFirstDay_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "WeekFirstDay_CrtCoreBaseEventsProcess";
			SchemaUId = new Guid("268b91f8-f520-4a48-9864-f2350d841216");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("268b91f8-f520-4a48-9864-f2350d841216");
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

	#region Class: WeekFirstDay_CrtCoreBaseEventsProcess

	/// <exclude/>
	public class WeekFirstDay_CrtCoreBaseEventsProcess : WeekFirstDay_CrtCoreBaseEventsProcess<WeekFirstDay>
	{

		public WeekFirstDay_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: WeekFirstDay_CrtCoreBaseEventsProcess

	public partial class WeekFirstDay_CrtCoreBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: WeekFirstDayEventsProcess

	/// <exclude/>
	public class WeekFirstDayEventsProcess : WeekFirstDay_CrtCoreBaseEventsProcess
	{

		public WeekFirstDayEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

