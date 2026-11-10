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
	using Terrasoft.Configuration;
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

	#region Class: Account_Completeness_CreatioSchema

	/// <exclude/>
	public class Account_Completeness_CreatioSchema : Terrasoft.Configuration.Account_RelationshipDesigner_CreatioSchema
	{

		#region Constructors: Public

		public Account_Completeness_CreatioSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Account_Completeness_CreatioSchema(Account_Completeness_CreatioSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Account_Completeness_CreatioSchema(Account_Completeness_CreatioSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("cc642965-191f-4b55-b1ea-fb8336e623b9");
			Name = "Account_Completeness_Creatio";
			ParentSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e");
			ExtendParent = true;
			CreatedInPackageId = new Guid("c7634d9a-901d-4a66-9f11-34c80c5250ce");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("58210e36-46cd-4a12-934c-c97e96ed4160")) == null) {
				Columns.Add(CreateCompletenessColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCompletenessColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("58210e36-46cd-4a12-934c-c97e96ed4160"),
				Name = @"Completeness",
				CreatedInSchemaUId = new Guid("cc642965-191f-4b55-b1ea-fb8336e623b9"),
				ModifiedInSchemaUId = new Guid("cc642965-191f-4b55-b1ea-fb8336e623b9"),
				CreatedInPackageId = new Guid("c7634d9a-901d-4a66-9f11-34c80c5250ce"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"0"
				}
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Account_Completeness_Creatio(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Account_CompletenessEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Account_Completeness_CreatioSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Account_Completeness_CreatioSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("cc642965-191f-4b55-b1ea-fb8336e623b9"));
		}

		#endregion

	}

	#endregion

	#region Class: Account_Completeness_Creatio

	/// <summary>
	/// Account.
	/// </summary>
	public class Account_Completeness_Creatio : Terrasoft.Configuration.Account_RelationshipDesigner_Creatio
	{

		#region Constructors: Public

		public Account_Completeness_Creatio(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Account_Completeness_Creatio";
		}

		public Account_Completeness_Creatio(Account_Completeness_Creatio source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Data entry compliance.
		/// </summary>
		public int Completeness {
			get {
				return GetTypedColumnValue<int>("Completeness");
			}
			set {
				SetColumnValue("Completeness", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Account_CompletenessEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("Account_Completeness_CreatioDeleted", e);
			Validating += (s, e) => ThrowEvent("Account_Completeness_CreatioValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Account_Completeness_Creatio(this);
		}

		#endregion

	}

	#endregion

	#region Class: Account_CompletenessEventsProcess

	/// <exclude/>
	public partial class Account_CompletenessEventsProcess<TEntity> : Terrasoft.Configuration.Account_RelationshipDesignerEventsProcess<TEntity> where TEntity : Account_Completeness_Creatio
	{

		public Account_CompletenessEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Account_CompletenessEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("cc642965-191f-4b55-b1ea-fb8336e623b9");
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

	#region Class: Account_CompletenessEventsProcess

	/// <exclude/>
	public class Account_CompletenessEventsProcess : Account_CompletenessEventsProcess<Account_Completeness_Creatio>
	{

		public Account_CompletenessEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Account_CompletenessEventsProcess

	public partial class Account_CompletenessEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

