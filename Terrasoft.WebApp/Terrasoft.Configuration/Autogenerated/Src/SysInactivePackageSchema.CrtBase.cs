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

	#region Class: SysInactivePackageSchema

	/// <exclude/>
	public class SysInactivePackageSchema : Terrasoft.Configuration.SysPackageSchema
	{

		#region Constructors: Public

		public SysInactivePackageSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysInactivePackageSchema(SysInactivePackageSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysInactivePackageSchema(SysInactivePackageSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5d496d77-eb2c-d0a5-3ac1-6d283af2fc13");
			RealUId = new Guid("5d496d77-eb2c-d0a5-3ac1-6d283af2fc13");
			Name = "SysInactivePackage";
			ParentSchemaUId = new Guid("ca400a85-ec48-4b42-8e50-271929d27871");
			ExtendParent = false;
			CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = false;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("aba72fb5-e7a2-14e7-cee6-724f89201d41")) == null) {
				Columns.Add(CreateDeactivationSourceColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateDeactivationSourceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("aba72fb5-e7a2-14e7-cee6-724f89201d41"),
				Name = @"DeactivationSource",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("5d496d77-eb2c-d0a5-3ac1-6d283af2fc13"),
				ModifiedInSchemaUId = new Guid("5d496d77-eb2c-d0a5-3ac1-6d283af2fc13"),
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysInactivePackage(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysInactivePackage_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysInactivePackageSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysInactivePackageSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5d496d77-eb2c-d0a5-3ac1-6d283af2fc13"));
		}

		#endregion

	}

	#endregion

	#region Class: SysInactivePackage

	/// <summary>
	/// Inactive package.
	/// </summary>
	public class SysInactivePackage : Terrasoft.Configuration.SysPackage
	{

		#region Constructors: Public

		public SysInactivePackage(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysInactivePackage";
		}

		public SysInactivePackage(SysInactivePackage source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Deactivation source.
		/// </summary>
		/// <remarks>
		/// Auto = 0, Manual = 1.
		/// </remarks>
		public int DeactivationSource {
			get {
				return GetTypedColumnValue<int>("DeactivationSource");
			}
			set {
				SetColumnValue("DeactivationSource", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysInactivePackage_CrtBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleting += (s, e) => ThrowEvent("SysInactivePackageDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysInactivePackageInserted", e);
			Saved += (s, e) => ThrowEvent("SysInactivePackageSaved", e);
			Saving += (s, e) => ThrowEvent("SysInactivePackageSaving", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysInactivePackage(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysInactivePackage_CrtBaseEventsProcess

	/// <exclude/>
	public partial class SysInactivePackage_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.SysPackage_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysInactivePackage
	{

		public SysInactivePackage_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysInactivePackage_CrtBaseEventsProcess";
			SchemaUId = new Guid("5d496d77-eb2c-d0a5-3ac1-6d283af2fc13");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("5d496d77-eb2c-d0a5-3ac1-6d283af2fc13");
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

	#region Class: SysInactivePackage_CrtBaseEventsProcess

	/// <exclude/>
	public class SysInactivePackage_CrtBaseEventsProcess : SysInactivePackage_CrtBaseEventsProcess<SysInactivePackage>
	{

		public SysInactivePackage_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysInactivePackage_CrtBaseEventsProcess

	public partial class SysInactivePackage_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysInactivePackageEventsProcess

	/// <exclude/>
	public class SysInactivePackageEventsProcess : SysInactivePackage_CrtBaseEventsProcess
	{

		public SysInactivePackageEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

