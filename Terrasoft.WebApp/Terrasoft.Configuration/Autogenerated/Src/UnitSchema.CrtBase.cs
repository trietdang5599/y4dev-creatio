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

	#region Class: UnitSchema

	/// <exclude/>
	public class UnitSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public UnitSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public UnitSchema(UnitSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public UnitSchema(UnitSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("38f2220e-7085-494d-b4c9-396666b6327b");
			RealUId = new Guid("38f2220e-7085-494d-b4c9-396666b6327b");
			Name = "Unit";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("4a41775a-ee6f-4bb5-9725-025397d02775")) == null) {
				Columns.Add(CreateShortNameColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateShortNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("4a41775a-ee6f-4bb5-9725-025397d02775"),
				Name = @"ShortName",
				CreatedInSchemaUId = new Guid("38f2220e-7085-494d-b4c9-396666b6327b"),
				ModifiedInSchemaUId = new Guid("38f2220e-7085-494d-b4c9-396666b6327b"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f"),
				IsLocalizable = true
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Unit(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Unit_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new UnitSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new UnitSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("38f2220e-7085-494d-b4c9-396666b6327b"));
		}

		#endregion

	}

	#endregion

	#region Class: Unit

	/// <summary>
	/// Units of Measure.
	/// </summary>
	public class Unit : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public Unit(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Unit";
		}

		public Unit(Unit source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Short Name.
		/// </summary>
		public string ShortName {
			get {
				return GetTypedColumnValue<string>("ShortName");
			}
			set {
				SetColumnValue("ShortName", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Unit_CrtBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("UnitDeleted", e);
			Deleting += (s, e) => ThrowEvent("UnitDeleting", e);
			Inserted += (s, e) => ThrowEvent("UnitInserted", e);
			Inserting += (s, e) => ThrowEvent("UnitInserting", e);
			Saved += (s, e) => ThrowEvent("UnitSaved", e);
			Saving += (s, e) => ThrowEvent("UnitSaving", e);
			Validating += (s, e) => ThrowEvent("UnitValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Unit(this);
		}

		#endregion

	}

	#endregion

	#region Class: Unit_CrtBaseEventsProcess

	/// <exclude/>
	public partial class Unit_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : Unit
	{

		public Unit_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Unit_CrtBaseEventsProcess";
			SchemaUId = new Guid("38f2220e-7085-494d-b4c9-396666b6327b");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("38f2220e-7085-494d-b4c9-396666b6327b");
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

	#region Class: Unit_CrtBaseEventsProcess

	/// <exclude/>
	public class Unit_CrtBaseEventsProcess : Unit_CrtBaseEventsProcess<Unit>
	{

		public Unit_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Unit_CrtBaseEventsProcess

	public partial class Unit_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: UnitEventsProcess

	/// <exclude/>
	public class UnitEventsProcess : Unit_CrtBaseEventsProcess
	{

		public UnitEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

