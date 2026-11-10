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

	#region Class: SectionUITypeSchema

	/// <exclude/>
	public class SectionUITypeSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public SectionUITypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SectionUITypeSchema(SectionUITypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SectionUITypeSchema(SectionUITypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("6f16c12a-edae-4b35-a4d9-a103bfe850cd");
			RealUId = new Guid("6f16c12a-edae-4b35-a4d9-a103bfe850cd");
			Name = "SectionUIType";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("d699061b-815e-49b9-8730-21a5e5db2044");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("d5fc7e7e-6937-db9b-305d-534d1f6e1438")) == null) {
				Columns.Add(CreateCodeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("d5fc7e7e-6937-db9b-305d-534d1f6e1438"),
				Name = @"Code",
				CreatedInSchemaUId = new Guid("6f16c12a-edae-4b35-a4d9-a103bfe850cd"),
				ModifiedInSchemaUId = new Guid("6f16c12a-edae-4b35-a4d9-a103bfe850cd"),
				CreatedInPackageId = new Guid("d699061b-815e-49b9-8730-21a5e5db2044")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SectionUIType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SectionUIType_CrtUIv2EventsProcess(userConnection);
		}

		public override object Clone() {
			return new SectionUITypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SectionUITypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6f16c12a-edae-4b35-a4d9-a103bfe850cd"));
		}

		#endregion

	}

	#endregion

	#region Class: SectionUIType

	/// <summary>
	/// Section UI type.
	/// </summary>
	/// <remarks>
	/// Section UI type.
	/// </remarks>
	public class SectionUIType : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public SectionUIType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SectionUIType";
		}

		public SectionUIType(SectionUIType source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Code.
		/// </summary>
		/// <remarks>
		/// Code.
		/// </remarks>
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
			var process = new SectionUIType_CrtUIv2EventsProcess(UserConnection);
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
			return new SectionUIType(this);
		}

		#endregion

	}

	#endregion

	#region Class: SectionUIType_CrtUIv2EventsProcess

	/// <exclude/>
	public partial class SectionUIType_CrtUIv2EventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : SectionUIType
	{

		public SectionUIType_CrtUIv2EventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SectionUIType_CrtUIv2EventsProcess";
			SchemaUId = new Guid("6f16c12a-edae-4b35-a4d9-a103bfe850cd");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("6f16c12a-edae-4b35-a4d9-a103bfe850cd");
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

	#region Class: SectionUIType_CrtUIv2EventsProcess

	/// <exclude/>
	public class SectionUIType_CrtUIv2EventsProcess : SectionUIType_CrtUIv2EventsProcess<SectionUIType>
	{

		public SectionUIType_CrtUIv2EventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SectionUIType_CrtUIv2EventsProcess

	public partial class SectionUIType_CrtUIv2EventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SectionUITypeEventsProcess

	/// <exclude/>
	public class SectionUITypeEventsProcess : SectionUIType_CrtUIv2EventsProcess
	{

		public SectionUITypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

