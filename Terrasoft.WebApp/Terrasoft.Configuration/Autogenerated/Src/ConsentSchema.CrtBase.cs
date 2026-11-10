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

	#region Class: ConsentSchema

	/// <exclude/>
	public class ConsentSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public ConsentSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ConsentSchema(ConsentSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ConsentSchema(ConsentSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("cb0bdb95-22b9-4c9f-aea4-3f3e4cafb2d1");
			RealUId = new Guid("cb0bdb95-22b9-4c9f-aea4-3f3e4cafb2d1");
			Name = "Consent";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
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
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("6328c529-9f2f-2ef1-531a-5b3e2606f5c8")) == null) {
				Columns.Add(CreateConsentTextColumn());
			}
			if (Columns.FindByUId(new Guid("b4d3ce34-1774-1750-c71a-1a7aad4c7609")) == null) {
				Columns.Add(CreateCodeColumn());
			}
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.DataValueType = DataValueTypeManager.GetInstanceByName("LongText");
			column.ModifiedInSchemaUId = new Guid("cb0bdb95-22b9-4c9f-aea4-3f3e4cafb2d1");
			return column;
		}

		protected virtual EntitySchemaColumn CreateConsentTextColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("RichText")) {
				UId = new Guid("6328c529-9f2f-2ef1-531a-5b3e2606f5c8"),
				Name = @"ConsentText",
				CreatedInSchemaUId = new Guid("cb0bdb95-22b9-4c9f-aea4-3f3e4cafb2d1"),
				ModifiedInSchemaUId = new Guid("cb0bdb95-22b9-4c9f-aea4-3f3e4cafb2d1"),
				CreatedInPackageId = new Guid("95a133a1-cd5f-4df8-af8f-ad440775d7d1"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("b4d3ce34-1774-1750-c71a-1a7aad4c7609"),
				Name = @"Code",
				CreatedInSchemaUId = new Guid("cb0bdb95-22b9-4c9f-aea4-3f3e4cafb2d1"),
				ModifiedInSchemaUId = new Guid("cb0bdb95-22b9-4c9f-aea4-3f3e4cafb2d1"),
				CreatedInPackageId = new Guid("95a133a1-cd5f-4df8-af8f-ad440775d7d1")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Consent(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Consent_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ConsentSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ConsentSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("cb0bdb95-22b9-4c9f-aea4-3f3e4cafb2d1"));
		}

		#endregion

	}

	#endregion

	#region Class: Consent

	/// <summary>
	/// Consent.
	/// </summary>
	public class Consent : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public Consent(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Consent";
		}

		public Consent(Consent source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Consent text.
		/// </summary>
		public string ConsentText {
			get {
				return GetTypedColumnValue<string>("ConsentText");
			}
			set {
				SetColumnValue("ConsentText", value);
			}
		}

		/// <summary>
		/// Code.
		/// </summary>
		public string Code {
			get {
				return GetTypedColumnValue<string>("Code");
			}
			set {
				SetColumnValue("Code", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Consent_CrtBaseEventsProcess(UserConnection);
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
			return new Consent(this);
		}

		#endregion

	}

	#endregion

	#region Class: Consent_CrtBaseEventsProcess

	/// <exclude/>
	public partial class Consent_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : Consent
	{

		public Consent_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Consent_CrtBaseEventsProcess";
			SchemaUId = new Guid("cb0bdb95-22b9-4c9f-aea4-3f3e4cafb2d1");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("cb0bdb95-22b9-4c9f-aea4-3f3e4cafb2d1");
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

	#region Class: Consent_CrtBaseEventsProcess

	/// <exclude/>
	public class Consent_CrtBaseEventsProcess : Consent_CrtBaseEventsProcess<Consent>
	{

		public Consent_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Consent_CrtBaseEventsProcess

	public partial class Consent_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ConsentEventsProcess

	/// <exclude/>
	public class ConsentEventsProcess : Consent_CrtBaseEventsProcess
	{

		public ConsentEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

