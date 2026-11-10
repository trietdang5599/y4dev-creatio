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
	using System.Security;
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

	#region Class: AnniversaryTypeSchema

	/// <exclude/>
	public class AnniversaryTypeSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public AnniversaryTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public AnniversaryTypeSchema(AnniversaryTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public AnniversaryTypeSchema(AnniversaryTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b8215eaa-bf43-4a00-8bca-8eea8a5a0c14");
			RealUId = new Guid("b8215eaa-bf43-4a00-8bca-8eea8a5a0c14");
			Name = "AnniversaryType";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("b8215eaa-bf43-4a00-8bca-8eea8a5a0c14");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("b8215eaa-bf43-4a00-8bca-8eea8a5a0c14");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new AnniversaryType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new AnniversaryType_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new AnniversaryTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new AnniversaryTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b8215eaa-bf43-4a00-8bca-8eea8a5a0c14"));
		}

		#endregion

	}

	#endregion

	#region Class: AnniversaryType

	/// <summary>
	/// Noteworthy event type.
	/// </summary>
	public class AnniversaryType : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public AnniversaryType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "AnniversaryType";
		}

		public AnniversaryType(AnniversaryType source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new AnniversaryType_CrtBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("AnniversaryTypeDeleted", e);
			Deleting += (s, e) => ThrowEvent("AnniversaryTypeDeleting", e);
			Inserted += (s, e) => ThrowEvent("AnniversaryTypeInserted", e);
			Inserting += (s, e) => ThrowEvent("AnniversaryTypeInserting", e);
			Saved += (s, e) => ThrowEvent("AnniversaryTypeSaved", e);
			Saving += (s, e) => ThrowEvent("AnniversaryTypeSaving", e);
			Validating += (s, e) => ThrowEvent("AnniversaryTypeValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new AnniversaryType(this);
		}

		#endregion

	}

	#endregion

	#region Class: AnniversaryType_CrtBaseEventsProcess

	/// <exclude/>
	public partial class AnniversaryType_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : AnniversaryType
	{

		public AnniversaryType_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "AnniversaryType_CrtBaseEventsProcess";
			SchemaUId = new Guid("b8215eaa-bf43-4a00-8bca-8eea8a5a0c14");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("b8215eaa-bf43-4a00-8bca-8eea8a5a0c14");
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

	#region Class: AnniversaryType_CrtBaseEventsProcess

	/// <exclude/>
	public class AnniversaryType_CrtBaseEventsProcess : AnniversaryType_CrtBaseEventsProcess<AnniversaryType>
	{

		public AnniversaryType_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: AnniversaryType_CrtBaseEventsProcess

	public partial class AnniversaryType_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: AnniversaryTypeEventsProcess

	/// <exclude/>
	public class AnniversaryTypeEventsProcess : AnniversaryType_CrtBaseEventsProcess
	{

		public AnniversaryTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

