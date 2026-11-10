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

	#region Class: SysModuleInWorkplaceByUITypeSchema

	/// <exclude/>
	[IsVirtual]
	public class SysModuleInWorkplaceByUITypeSchema : Terrasoft.Configuration.SysModuleInWorkplaceSchema
	{

		#region Constructors: Public

		public SysModuleInWorkplaceByUITypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysModuleInWorkplaceByUITypeSchema(SysModuleInWorkplaceByUITypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysModuleInWorkplaceByUITypeSchema(SysModuleInWorkplaceByUITypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("053a2304-fdcb-4bc0-9532-3903f0835e76");
			RealUId = new Guid("053a2304-fdcb-4bc0-9532-3903f0835e76");
			Name = "SysModuleInWorkplaceByUIType";
			ParentSchemaUId = new Guid("a8b20179-02be-4a13-8908-9fc51cb9f66d");
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
			if (Columns.FindByUId(new Guid("c91677da-7055-0b7f-19fe-e542b20cdfbe")) == null) {
				Columns.Add(CreateSectionUITypeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSectionUITypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("c91677da-7055-0b7f-19fe-e542b20cdfbe"),
				Name = @"SectionUIType",
				ReferenceSchemaUId = new Guid("6f16c12a-edae-4b35-a4d9-a103bfe850cd"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("053a2304-fdcb-4bc0-9532-3903f0835e76"),
				ModifiedInSchemaUId = new Guid("053a2304-fdcb-4bc0-9532-3903f0835e76"),
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
			return new SysModuleInWorkplaceByUIType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysModuleInWorkplaceByUIType_CrtUIv2EventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysModuleInWorkplaceByUITypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysModuleInWorkplaceByUITypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("053a2304-fdcb-4bc0-9532-3903f0835e76"));
		}

		#endregion

	}

	#endregion

	#region Class: SysModuleInWorkplaceByUIType

	/// <summary>
	/// Section in workplace by UI type.
	/// </summary>
	/// <remarks>
	/// Section in workplace by UI type.
	/// </remarks>
	public class SysModuleInWorkplaceByUIType : Terrasoft.Configuration.SysModuleInWorkplace
	{

		#region Constructors: Public

		public SysModuleInWorkplaceByUIType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysModuleInWorkplaceByUIType";
		}

		public SysModuleInWorkplaceByUIType(SysModuleInWorkplaceByUIType source)
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
			var process = new SysModuleInWorkplaceByUIType_CrtUIv2EventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysModuleInWorkplaceByUITypeDeleted", e);
			Inserting += (s, e) => ThrowEvent("SysModuleInWorkplaceByUITypeInserting", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysModuleInWorkplaceByUIType(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysModuleInWorkplaceByUIType_CrtUIv2EventsProcess

	/// <exclude/>
	public partial class SysModuleInWorkplaceByUIType_CrtUIv2EventsProcess<TEntity> : Terrasoft.Configuration.SysModuleInWorkplace_CrtNUIEventsProcess<TEntity> where TEntity : SysModuleInWorkplaceByUIType
	{

		public SysModuleInWorkplaceByUIType_CrtUIv2EventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysModuleInWorkplaceByUIType_CrtUIv2EventsProcess";
			SchemaUId = new Guid("053a2304-fdcb-4bc0-9532-3903f0835e76");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("053a2304-fdcb-4bc0-9532-3903f0835e76");
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

	#region Class: SysModuleInWorkplaceByUIType_CrtUIv2EventsProcess

	/// <exclude/>
	public class SysModuleInWorkplaceByUIType_CrtUIv2EventsProcess : SysModuleInWorkplaceByUIType_CrtUIv2EventsProcess<SysModuleInWorkplaceByUIType>
	{

		public SysModuleInWorkplaceByUIType_CrtUIv2EventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysModuleInWorkplaceByUIType_CrtUIv2EventsProcess

	public partial class SysModuleInWorkplaceByUIType_CrtUIv2EventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysModuleInWorkplaceByUITypeEventsProcess

	/// <exclude/>
	public class SysModuleInWorkplaceByUITypeEventsProcess : SysModuleInWorkplaceByUIType_CrtUIv2EventsProcess
	{

		public SysModuleInWorkplaceByUITypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

