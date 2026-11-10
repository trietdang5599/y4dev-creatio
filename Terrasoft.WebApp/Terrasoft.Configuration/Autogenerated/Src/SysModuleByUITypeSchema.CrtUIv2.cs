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

	#region Class: SysModuleByUITypeSchema

	/// <exclude/>
	[IsVirtual]
	public class SysModuleByUITypeSchema : Terrasoft.Configuration.SysModuleSchema
	{

		#region Constructors: Public

		public SysModuleByUITypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysModuleByUITypeSchema(SysModuleByUITypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysModuleByUITypeSchema(SysModuleByUITypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b02292c4-77b7-4cc9-b9a9-9d7e544e4f97");
			RealUId = new Guid("b02292c4-77b7-4cc9-b9a9-9d7e544e4f97");
			Name = "SysModuleByUIType";
			ParentSchemaUId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5");
			ExtendParent = false;
			CreatedInPackageId = new Guid("d699061b-815e-49b9-8730-21a5e5db2044");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = false;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("b0480a1a-2b85-03b6-ec9c-60e0bb3eab5c")) == null) {
				Columns.Add(CreateSectionUITypeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSectionUITypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("b0480a1a-2b85-03b6-ec9c-60e0bb3eab5c"),
				Name = @"SectionUIType",
				ReferenceSchemaUId = new Guid("6f16c12a-edae-4b35-a4d9-a103bfe850cd"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("b02292c4-77b7-4cc9-b9a9-9d7e544e4f97"),
				ModifiedInSchemaUId = new Guid("b02292c4-77b7-4cc9-b9a9-9d7e544e4f97"),
				CreatedInPackageId = new Guid("d699061b-815e-49b9-8730-21a5e5db2044"),
				IsSimpleLookup = true
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysModuleByUIType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysModuleByUIType_CrtUIv2EventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysModuleByUITypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysModuleByUITypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b02292c4-77b7-4cc9-b9a9-9d7e544e4f97"));
		}

		#endregion

	}

	#endregion

	#region Class: SysModuleByUIType

	/// <summary>
	/// Section by UI type.
	/// </summary>
	/// <remarks>
	/// Section by UI type.
	/// </remarks>
	public class SysModuleByUIType : Terrasoft.Configuration.SysModule
	{

		#region Constructors: Public

		public SysModuleByUIType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysModuleByUIType";
		}

		public SysModuleByUIType(SysModuleByUIType source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SectionUITypeId {
			get {
				return GetTypedColumnValue<Guid>("SectionUITypeId");
			}
			set {
				SetColumnValue("SectionUITypeId", value);
				_sectionUIType = null;
			}
		}

		/// <exclude/>
		public string SectionUITypeName {
			get {
				return GetTypedColumnValue<string>("SectionUITypeName");
			}
			set {
				SetColumnValue("SectionUITypeName", value);
				if (_sectionUIType != null) {
					_sectionUIType.Name = value;
				}
			}
		}

		private SectionUIType _sectionUIType;
		/// <summary>
		/// UI type.
		/// </summary>
		/// <remarks>
		/// UI type of section.
		/// </remarks>
		public SectionUIType SectionUIType {
			get {
				return _sectionUIType ??
					(_sectionUIType = LookupColumnEntities.GetEntity("SectionUIType") as SectionUIType);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysModuleByUIType_CrtUIv2EventsProcess(UserConnection);
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
			return new SysModuleByUIType(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysModuleByUIType_CrtUIv2EventsProcess

	/// <exclude/>
	public partial class SysModuleByUIType_CrtUIv2EventsProcess<TEntity> : Terrasoft.Configuration.SysModule_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysModuleByUIType
	{

		public SysModuleByUIType_CrtUIv2EventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysModuleByUIType_CrtUIv2EventsProcess";
			SchemaUId = new Guid("b02292c4-77b7-4cc9-b9a9-9d7e544e4f97");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("b02292c4-77b7-4cc9-b9a9-9d7e544e4f97");
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

	#region Class: SysModuleByUIType_CrtUIv2EventsProcess

	/// <exclude/>
	public class SysModuleByUIType_CrtUIv2EventsProcess : SysModuleByUIType_CrtUIv2EventsProcess<SysModuleByUIType>
	{

		public SysModuleByUIType_CrtUIv2EventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysModuleByUIType_CrtUIv2EventsProcess

	public partial class SysModuleByUIType_CrtUIv2EventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysModuleByUITypeEventsProcess

	/// <exclude/>
	public class SysModuleByUITypeEventsProcess : SysModuleByUIType_CrtUIv2EventsProcess
	{

		public SysModuleByUITypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

