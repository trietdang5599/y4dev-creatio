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

	#region Class: DisableDefValueSchema

	/// <exclude/>
	public class DisableDefValueSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public DisableDefValueSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public DisableDefValueSchema(DisableDefValueSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public DisableDefValueSchema(DisableDefValueSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a55705cc-0d47-481c-ba37-8688126461fd");
			RealUId = new Guid("a55705cc-0d47-481c-ba37-8688126461fd");
			Name = "DisableDefValue";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("c70416a1-d180-47d0-9b53-90527ee8764a");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("ce3779cd-c5be-996b-a677-043cfc111ec9")) == null) {
				Columns.Add(CreateColumnNameColumn());
			}
			if (Columns.FindByUId(new Guid("a4b1a289-712a-2491-4884-46852e14523f")) == null) {
				Columns.Add(CreateEntityNameColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateColumnNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("ce3779cd-c5be-996b-a677-043cfc111ec9"),
				Name = @"ColumnName",
				CreatedInSchemaUId = new Guid("a55705cc-0d47-481c-ba37-8688126461fd"),
				ModifiedInSchemaUId = new Guid("a55705cc-0d47-481c-ba37-8688126461fd"),
				CreatedInPackageId = new Guid("c70416a1-d180-47d0-9b53-90527ee8764a"),
				IsFormatValidated = true
			};
		}

		protected virtual EntitySchemaColumn CreateEntityNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("a4b1a289-712a-2491-4884-46852e14523f"),
				Name = @"EntityName",
				CreatedInSchemaUId = new Guid("a55705cc-0d47-481c-ba37-8688126461fd"),
				ModifiedInSchemaUId = new Guid("a55705cc-0d47-481c-ba37-8688126461fd"),
				CreatedInPackageId = new Guid("c70416a1-d180-47d0-9b53-90527ee8764a"),
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
			return new DisableDefValue(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new DisableDefValue_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new DisableDefValueSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new DisableDefValueSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a55705cc-0d47-481c-ba37-8688126461fd"));
		}

		#endregion

	}

	#endregion

	#region Class: DisableDefValue

	/// <summary>
	/// Object.
	/// </summary>
	/// <remarks>
	/// Adding entities to this table will cause HasDefValue to be false for according entity and column.
	/// </remarks>
	public class DisableDefValue : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public DisableDefValue(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "DisableDefValue";
		}

		public DisableDefValue(DisableDefValue source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Column name.
		/// </summary>
		public string ColumnName {
			get {
				return GetTypedColumnValue<string>("ColumnName");
			}
			set {
				SetColumnValue("ColumnName", value);
			}
		}

		/// <summary>
		/// Entity name.
		/// </summary>
		public string EntityName {
			get {
				return GetTypedColumnValue<string>("EntityName");
			}
			set {
				SetColumnValue("EntityName", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new DisableDefValue_CrtBaseEventsProcess(UserConnection);
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
			return new DisableDefValue(this);
		}

		#endregion

	}

	#endregion

	#region Class: DisableDefValue_CrtBaseEventsProcess

	/// <exclude/>
	public partial class DisableDefValue_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : DisableDefValue
	{

		public DisableDefValue_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "DisableDefValue_CrtBaseEventsProcess";
			SchemaUId = new Guid("a55705cc-0d47-481c-ba37-8688126461fd");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("a55705cc-0d47-481c-ba37-8688126461fd");
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

	#region Class: DisableDefValue_CrtBaseEventsProcess

	/// <exclude/>
	public class DisableDefValue_CrtBaseEventsProcess : DisableDefValue_CrtBaseEventsProcess<DisableDefValue>
	{

		public DisableDefValue_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: DisableDefValue_CrtBaseEventsProcess

	public partial class DisableDefValue_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: DisableDefValueEventsProcess

	/// <exclude/>
	public class DisableDefValueEventsProcess : DisableDefValue_CrtBaseEventsProcess
	{

		public DisableDefValueEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

