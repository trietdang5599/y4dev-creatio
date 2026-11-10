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

	#region Class: ReferralChasingOptionsSchema

	/// <exclude/>
	public class ReferralChasingOptionsSchema : Terrasoft.Configuration.BaseValueLookupSchema
	{

		#region Constructors: Public

		public ReferralChasingOptionsSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ReferralChasingOptionsSchema(ReferralChasingOptionsSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ReferralChasingOptionsSchema(ReferralChasingOptionsSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("25ada658-96f0-457c-8b0c-56eca7fc17f4");
			RealUId = new Guid("25ada658-96f0-457c-8b0c-56eca7fc17f4");
			Name = "ReferralChasingOptions";
			ParentSchemaUId = new Guid("04f67f0c-0a27-4616-987e-60e378854b0f");
			ExtendParent = false;
			CreatedInPackageId = new Guid("7c904ad4-e292-4453-b17c-60a3882c9384");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = false;
			UseLiveEditing = false;
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
			return new ReferralChasingOptions(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ReferralChasingOptions_LDAPEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ReferralChasingOptionsSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ReferralChasingOptionsSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("25ada658-96f0-457c-8b0c-56eca7fc17f4"));
		}

		#endregion

	}

	#endregion

	#region Class: ReferralChasingOptions

	/// <summary>
	/// Referral chasing options.
	/// </summary>
	public class ReferralChasingOptions : Terrasoft.Configuration.BaseValueLookup
	{

		#region Constructors: Public

		public ReferralChasingOptions(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ReferralChasingOptions";
		}

		public ReferralChasingOptions(ReferralChasingOptions source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ReferralChasingOptions_LDAPEventsProcess(UserConnection);
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
			return new ReferralChasingOptions(this);
		}

		#endregion

	}

	#endregion

	#region Class: ReferralChasingOptions_LDAPEventsProcess

	/// <exclude/>
	public partial class ReferralChasingOptions_LDAPEventsProcess<TEntity> : Terrasoft.Configuration.BaseValueLookup_CrtBaseEventsProcess<TEntity> where TEntity : ReferralChasingOptions
	{

		public ReferralChasingOptions_LDAPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ReferralChasingOptions_LDAPEventsProcess";
			SchemaUId = new Guid("25ada658-96f0-457c-8b0c-56eca7fc17f4");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("25ada658-96f0-457c-8b0c-56eca7fc17f4");
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

	#region Class: ReferralChasingOptions_LDAPEventsProcess

	/// <exclude/>
	public class ReferralChasingOptions_LDAPEventsProcess : ReferralChasingOptions_LDAPEventsProcess<ReferralChasingOptions>
	{

		public ReferralChasingOptions_LDAPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ReferralChasingOptions_LDAPEventsProcess

	public partial class ReferralChasingOptions_LDAPEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ReferralChasingOptionsEventsProcess

	/// <exclude/>
	public class ReferralChasingOptionsEventsProcess : ReferralChasingOptions_LDAPEventsProcess
	{

		public ReferralChasingOptionsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

