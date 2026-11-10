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

	#region Class: SysNumberFormatSchema

	/// <exclude/>
	public class SysNumberFormatSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public SysNumberFormatSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysNumberFormatSchema(SysNumberFormatSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysNumberFormatSchema(SysNumberFormatSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("8a9a3dc6-1537-427f-bf7e-e18ee638d21f");
			RealUId = new Guid("8a9a3dc6-1537-427f-bf7e-e18ee638d21f");
			Name = "SysNumberFormat";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723");
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
			if (Columns.FindByUId(new Guid("0b522504-4f38-b781-d203-d88230a20764")) == null) {
				Columns.Add(CreateDecimalSeparatorColumn());
			}
			if (Columns.FindByUId(new Guid("80a7c5ff-83b1-7e3b-adf3-c8f7fb407db4")) == null) {
				Columns.Add(CreateThousandSeparatorColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateDecimalSeparatorColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("0b522504-4f38-b781-d203-d88230a20764"),
				Name = @"DecimalSeparator",
				CreatedInSchemaUId = new Guid("8a9a3dc6-1537-427f-bf7e-e18ee638d21f"),
				ModifiedInSchemaUId = new Guid("8a9a3dc6-1537-427f-bf7e-e18ee638d21f"),
				CreatedInPackageId = new Guid("9cc3d920-8a68-437c-9367-c8131a0a7723")
			};
		}

		protected virtual EntitySchemaColumn CreateThousandSeparatorColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("80a7c5ff-83b1-7e3b-adf3-c8f7fb407db4"),
				Name = @"ThousandSeparator",
				CreatedInSchemaUId = new Guid("8a9a3dc6-1537-427f-bf7e-e18ee638d21f"),
				ModifiedInSchemaUId = new Guid("8a9a3dc6-1537-427f-bf7e-e18ee638d21f"),
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
			return new SysNumberFormat(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysNumberFormat_CrtCoreBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysNumberFormatSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysNumberFormatSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("8a9a3dc6-1537-427f-bf7e-e18ee638d21f"));
		}

		#endregion

	}

	#endregion

	#region Class: SysNumberFormat

	/// <summary>
	/// Number format.
	/// </summary>
	public class SysNumberFormat : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public SysNumberFormat(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysNumberFormat";
		}

		public SysNumberFormat(SysNumberFormat source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Decimal separator.
		/// </summary>
		public string DecimalSeparator {
			get {
				return GetTypedColumnValue<string>("DecimalSeparator");
			}
			set {
				SetColumnValue("DecimalSeparator", value);
			}
		}

		/// <summary>
		/// Thousand separator.
		/// </summary>
		public string ThousandSeparator {
			get {
				return GetTypedColumnValue<string>("ThousandSeparator");
			}
			set {
				SetColumnValue("ThousandSeparator", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysNumberFormat_CrtCoreBaseEventsProcess(UserConnection);
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
			return new SysNumberFormat(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysNumberFormat_CrtCoreBaseEventsProcess

	/// <exclude/>
	public partial class SysNumberFormat_CrtCoreBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysNumberFormat
	{

		public SysNumberFormat_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysNumberFormat_CrtCoreBaseEventsProcess";
			SchemaUId = new Guid("8a9a3dc6-1537-427f-bf7e-e18ee638d21f");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("8a9a3dc6-1537-427f-bf7e-e18ee638d21f");
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

	#region Class: SysNumberFormat_CrtCoreBaseEventsProcess

	/// <exclude/>
	public class SysNumberFormat_CrtCoreBaseEventsProcess : SysNumberFormat_CrtCoreBaseEventsProcess<SysNumberFormat>
	{

		public SysNumberFormat_CrtCoreBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysNumberFormat_CrtCoreBaseEventsProcess

	public partial class SysNumberFormat_CrtCoreBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysNumberFormatEventsProcess

	/// <exclude/>
	public class SysNumberFormatEventsProcess : SysNumberFormat_CrtCoreBaseEventsProcess
	{

		public SysNumberFormatEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

