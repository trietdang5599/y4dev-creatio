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

	#region Class: WeakPasswordSchema

	/// <exclude/>
	public class WeakPasswordSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public WeakPasswordSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public WeakPasswordSchema(WeakPasswordSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public WeakPasswordSchema(WeakPasswordSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("dce2278e-cadc-4e45-abac-30d3ccd9456b");
			RealUId = new Guid("dce2278e-cadc-4e45-abac-30d3ccd9456b");
			Name = "WeakPassword";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
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
			if (Columns.FindByUId(new Guid("6abc3568-1c77-f45a-4a91-71aa6d03b5a5")) == null) {
				Columns.Add(CreatePasswordColumn());
			}
		}

		protected virtual EntitySchemaColumn CreatePasswordColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("6abc3568-1c77-f45a-4a91-71aa6d03b5a5"),
				Name = @"Password",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("dce2278e-cadc-4e45-abac-30d3ccd9456b"),
				ModifiedInSchemaUId = new Guid("dce2278e-cadc-4e45-abac-30d3ccd9456b"),
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723"),
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
			return new WeakPassword(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new WeakPassword_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new WeakPasswordSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new WeakPasswordSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("dce2278e-cadc-4e45-abac-30d3ccd9456b"));
		}

		#endregion

	}

	#endregion

	#region Class: WeakPassword

	/// <summary>
	/// Weak password.
	/// </summary>
	public class WeakPassword : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public WeakPassword(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "WeakPassword";
		}

		public WeakPassword(WeakPassword source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Password.
		/// </summary>
		public string Password {
			get {
				return GetTypedColumnValue<string>("Password");
			}
			set {
				SetColumnValue("Password", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new WeakPassword_CrtBaseEventsProcess(UserConnection);
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
			return new WeakPassword(this);
		}

		#endregion

	}

	#endregion

	#region Class: WeakPassword_CrtBaseEventsProcess

	/// <exclude/>
	public partial class WeakPassword_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : WeakPassword
	{

		public WeakPassword_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "WeakPassword_CrtBaseEventsProcess";
			SchemaUId = new Guid("dce2278e-cadc-4e45-abac-30d3ccd9456b");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("dce2278e-cadc-4e45-abac-30d3ccd9456b");
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

	#region Class: WeakPassword_CrtBaseEventsProcess

	/// <exclude/>
	public class WeakPassword_CrtBaseEventsProcess : WeakPassword_CrtBaseEventsProcess<WeakPassword>
	{

		public WeakPassword_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: WeakPassword_CrtBaseEventsProcess

	public partial class WeakPassword_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: WeakPasswordEventsProcess

	/// <exclude/>
	public class WeakPasswordEventsProcess : WeakPassword_CrtBaseEventsProcess
	{

		public WeakPasswordEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

