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

	#region Class: SysClientUnitSchemaSourceSchema

	/// <exclude/>
	public class SysClientUnitSchemaSourceSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysClientUnitSchemaSourceSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysClientUnitSchemaSourceSchema(SysClientUnitSchemaSourceSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysClientUnitSchemaSourceSchema(SysClientUnitSchemaSourceSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("44bfe0c6-8ca0-4bf6-a328-f6bcd2245fe9");
			RealUId = new Guid("44bfe0c6-8ca0-4bf6-a328-f6bcd2245fe9");
			Name = "SysClientUnitSchemaSource";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("ca6aab00-833f-4b20-920a-99a0c1105b5d");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("80e498aa-64f9-44f0-ac2a-989495c51d2d")) == null) {
				Columns.Add(CreateSysSchemaColumn());
			}
			if (Columns.FindByUId(new Guid("243d1a9e-2de3-46b9-b0eb-e11cbf0c6ef7")) == null) {
				Columns.Add(CreateBodyRawColumn());
			}
			if (Columns.FindByUId(new Guid("993cfe91-fb84-440e-a527-3eec4a1ce7e1")) == null) {
				Columns.Add(CreateHashColumn());
			}
			if (Columns.FindByUId(new Guid("1b482250-e5fe-4ff0-ab76-4b942a07c337")) == null) {
				Columns.Add(CreateSysCultureColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysSchemaColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("80e498aa-64f9-44f0-ac2a-989495c51d2d"),
				Name = @"SysSchema",
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("44bfe0c6-8ca0-4bf6-a328-f6bcd2245fe9"),
				ModifiedInSchemaUId = new Guid("44bfe0c6-8ca0-4bf6-a328-f6bcd2245fe9"),
				CreatedInPackageId = new Guid("ca6aab00-833f-4b20-920a-99a0c1105b5d")
			};
		}

		protected virtual EntitySchemaColumn CreateBodyRawColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Binary")) {
				UId = new Guid("243d1a9e-2de3-46b9-b0eb-e11cbf0c6ef7"),
				Name = @"BodyRaw",
				CreatedInSchemaUId = new Guid("44bfe0c6-8ca0-4bf6-a328-f6bcd2245fe9"),
				ModifiedInSchemaUId = new Guid("44bfe0c6-8ca0-4bf6-a328-f6bcd2245fe9"),
				CreatedInPackageId = new Guid("ca6aab00-833f-4b20-920a-99a0c1105b5d")
			};
		}

		protected virtual EntitySchemaColumn CreateHashColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("993cfe91-fb84-440e-a527-3eec4a1ce7e1"),
				Name = @"Hash",
				CreatedInSchemaUId = new Guid("44bfe0c6-8ca0-4bf6-a328-f6bcd2245fe9"),
				ModifiedInSchemaUId = new Guid("44bfe0c6-8ca0-4bf6-a328-f6bcd2245fe9"),
				CreatedInPackageId = new Guid("ca6aab00-833f-4b20-920a-99a0c1105b5d")
			};
		}

		protected virtual EntitySchemaColumn CreateSysCultureColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("1b482250-e5fe-4ff0-ab76-4b942a07c337"),
				Name = @"SysCulture",
				ReferenceSchemaUId = new Guid("ffc193e1-04bc-472b-bdc0-3333d1df84e4"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("44bfe0c6-8ca0-4bf6-a328-f6bcd2245fe9"),
				ModifiedInSchemaUId = new Guid("44bfe0c6-8ca0-4bf6-a328-f6bcd2245fe9"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysClientUnitSchemaSource(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysClientUnitSchemaSource_CrtBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysClientUnitSchemaSourceSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysClientUnitSchemaSourceSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("44bfe0c6-8ca0-4bf6-a328-f6bcd2245fe9"));
		}

		#endregion

	}

	#endregion

	#region Class: SysClientUnitSchemaSource

	/// <summary>
	/// Client schemas source code.
	/// </summary>
	public class SysClientUnitSchemaSource : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysClientUnitSchemaSource(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysClientUnitSchemaSource";
		}

		public SysClientUnitSchemaSource(SysClientUnitSchemaSource source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SysSchemaId {
			get {
				return GetTypedColumnValue<Guid>("SysSchemaId");
			}
			set {
				SetColumnValue("SysSchemaId", value);
				_sysSchema = null;
			}
		}

		/// <exclude/>
		public string SysSchemaCaption {
			get {
				return GetTypedColumnValue<string>("SysSchemaCaption");
			}
			set {
				SetColumnValue("SysSchemaCaption", value);
				if (_sysSchema != null) {
					_sysSchema.Caption = value;
				}
			}
		}

		private SysSchema _sysSchema;
		/// <summary>
		/// Schema.
		/// </summary>
		public SysSchema SysSchema {
			get {
				return _sysSchema ??
					(_sysSchema = LookupColumnEntities.GetEntity("SysSchema") as SysSchema);
			}
		}

		/// <summary>
		/// Hash.
		/// </summary>
		public string Hash {
			get {
				return GetTypedColumnValue<string>("Hash");
			}
			set {
				SetColumnValue("Hash", value);
			}
		}

		/// <exclude/>
		public Guid SysCultureId {
			get {
				return GetTypedColumnValue<Guid>("SysCultureId");
			}
			set {
				SetColumnValue("SysCultureId", value);
				_sysCulture = null;
			}
		}

		/// <exclude/>
		public string SysCultureName {
			get {
				return GetTypedColumnValue<string>("SysCultureName");
			}
			set {
				SetColumnValue("SysCultureName", value);
				if (_sysCulture != null) {
					_sysCulture.Name = value;
				}
			}
		}

		private SysCulture _sysCulture;
		/// <summary>
		/// SysCulture.
		/// </summary>
		public SysCulture SysCulture {
			get {
				return _sysCulture ??
					(_sysCulture = LookupColumnEntities.GetEntity("SysCulture") as SysCulture);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysClientUnitSchemaSource_CrtBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysClientUnitSchemaSourceDeleted", e);
			Validating += (s, e) => ThrowEvent("SysClientUnitSchemaSourceValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysClientUnitSchemaSource(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysClientUnitSchemaSource_CrtBaseEventsProcess

	/// <exclude/>
	public partial class SysClientUnitSchemaSource_CrtBaseEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysClientUnitSchemaSource
	{

		public SysClientUnitSchemaSource_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysClientUnitSchemaSource_CrtBaseEventsProcess";
			SchemaUId = new Guid("44bfe0c6-8ca0-4bf6-a328-f6bcd2245fe9");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("44bfe0c6-8ca0-4bf6-a328-f6bcd2245fe9");
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

	#region Class: SysClientUnitSchemaSource_CrtBaseEventsProcess

	/// <exclude/>
	public class SysClientUnitSchemaSource_CrtBaseEventsProcess : SysClientUnitSchemaSource_CrtBaseEventsProcess<SysClientUnitSchemaSource>
	{

		public SysClientUnitSchemaSource_CrtBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysClientUnitSchemaSource_CrtBaseEventsProcess

	public partial class SysClientUnitSchemaSource_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysClientUnitSchemaSourceEventsProcess

	/// <exclude/>
	public class SysClientUnitSchemaSourceEventsProcess : SysClientUnitSchemaSource_CrtBaseEventsProcess
	{

		public SysClientUnitSchemaSourceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

