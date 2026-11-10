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

	#region Class: EmployeeInTagSchema

	/// <exclude/>
	public class EmployeeInTagSchema : Terrasoft.Configuration.BaseEntityInTagSchema
	{

		#region Constructors: Public

		public EmployeeInTagSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public EmployeeInTagSchema(EmployeeInTagSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public EmployeeInTagSchema(EmployeeInTagSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("9f4af312-e66e-4ffa-91a1-5a540a9745ab");
			RealUId = new Guid("9f4af312-e66e-4ffa-91a1-5a540a9745ab");
			Name = "EmployeeInTag";
			ParentSchemaUId = new Guid("5894a2b0-51d5-419a-82bb-238674634270");
			ExtendParent = false;
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateTagColumn() {
			EntitySchemaColumn column = base.CreateTagColumn();
			column.ReferenceSchemaUId = new Guid("31b7da55-8bcf-4eb6-878b-24ad1a26b8e4");
			column.ColumnValueName = @"TagId";
			column.DisplayColumnValueName = @"TagName";
			column.ModifiedInSchemaUId = new Guid("9f4af312-e66e-4ffa-91a1-5a540a9745ab");
			return column;
		}

		protected override EntitySchemaColumn CreateEntityColumn() {
			EntitySchemaColumn column = base.CreateEntityColumn();
			column.ReferenceSchemaUId = new Guid("fb1c2bed-91d4-4b06-a28c-621a3d187008");
			column.ColumnValueName = @"EntityId";
			column.DisplayColumnValueName = @"EntityName";
			column.ModifiedInSchemaUId = new Guid("9f4af312-e66e-4ffa-91a1-5a540a9745ab");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new EmployeeInTag(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new EmployeeInTag_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new EmployeeInTagSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new EmployeeInTagSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9f4af312-e66e-4ffa-91a1-5a540a9745ab"));
		}

		#endregion

	}

	#endregion

	#region Class: EmployeeInTag

	/// <summary>
	/// Employee section record tag.
	/// </summary>
	public class EmployeeInTag : Terrasoft.Configuration.BaseEntityInTag
	{

		#region Constructors: Public

		public EmployeeInTag(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "EmployeeInTag";
		}

		public EmployeeInTag(EmployeeInTag source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new EmployeeInTag_CrtBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("EmployeeInTagDeleted", e);
			Deleting += (s, e) => ThrowEvent("EmployeeInTagDeleting", e);
			Inserted += (s, e) => ThrowEvent("EmployeeInTagInserted", e);
			Inserting += (s, e) => ThrowEvent("EmployeeInTagInserting", e);
			Saved += (s, e) => ThrowEvent("EmployeeInTagSaved", e);
			Saving += (s, e) => ThrowEvent("EmployeeInTagSaving", e);
			Validating += (s, e) => ThrowEvent("EmployeeInTagValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new EmployeeInTag(this);
		}

		#endregion

	}

	#endregion

	#region Class: EmployeeInTag_CrtBaseEventsProcess

	/// <exclude/>
	public partial class EmployeeInTag_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntityInTag_CrtCoreBaseEventsProcess<TEntity> where TEntity : EmployeeInTag
	{

		public EmployeeInTag_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "EmployeeInTag_CrtBaseEventsProcess";
			SchemaUId = new Guid("9f4af312-e66e-4ffa-91a1-5a540a9745ab");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("9f4af312-e66e-4ffa-91a1-5a540a9745ab");
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

	#region Class: EmployeeInTag_CrtBaseEventsProcess

	/// <exclude/>
	public class EmployeeInTag_CrtBaseEventsProcess : EmployeeInTag_CrtBaseEventsProcess<EmployeeInTag>
	{

		public EmployeeInTag_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: EmployeeInTag_CrtBaseEventsProcess

	public partial class EmployeeInTag_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: EmployeeInTagEventsProcess

	/// <exclude/>
	public class EmployeeInTagEventsProcess : EmployeeInTag_CrtBaseEventsProcess
	{

		public EmployeeInTagEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

