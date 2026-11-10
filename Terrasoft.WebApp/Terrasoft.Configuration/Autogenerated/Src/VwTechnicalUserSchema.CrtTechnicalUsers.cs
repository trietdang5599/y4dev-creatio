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

	#region Class: VwTechnicalUserSchema

	/// <exclude/>
	public class VwTechnicalUserSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public VwTechnicalUserSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwTechnicalUserSchema(VwTechnicalUserSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwTechnicalUserSchema(VwTechnicalUserSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("833a4cc0-4849-44e3-90a0-f35b015fd060");
			RealUId = new Guid("833a4cc0-4849-44e3-90a0-f35b015fd060");
			Name = "VwTechnicalUser";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("12195dca-1b7f-42ca-9a53-a3a7e5005031");
			IsDBView = true;
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
			if (Columns.FindByUId(new Guid("97dd2c22-b862-88db-6969-0d4004fc9f2b")) == null) {
				Columns.Add(CreateSysCultureColumn());
			}
			if (Columns.FindByUId(new Guid("03178c8c-ee13-2b8e-8f7b-b4793cd5de4e")) == null) {
				Columns.Add(CreateActiveColumn());
			}
			if (Columns.FindByUId(new Guid("7e974978-7b60-de84-d4fe-733d59b7f8ef")) == null) {
				Columns.Add(CreateContactColumn());
			}
			if (Columns.FindByUId(new Guid("bb3f756c-3995-abef-dc48-2b5d0dcb17c2")) == null) {
				Columns.Add(CreateTimeZoneColumn());
			}
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.IsLocalizable = false;
			column.ModifiedInSchemaUId = new Guid("833a4cc0-4849-44e3-90a0-f35b015fd060");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.IsLocalizable = false;
			column.ModifiedInSchemaUId = new Guid("833a4cc0-4849-44e3-90a0-f35b015fd060");
			return column;
		}

		protected virtual EntitySchemaColumn CreateSysCultureColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("97dd2c22-b862-88db-6969-0d4004fc9f2b"),
				Name = @"SysCulture",
				ReferenceSchemaUId = new Guid("2f96cb61-7e14-41e5-980a-bcb856edab51"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("833a4cc0-4849-44e3-90a0-f35b015fd060"),
				ModifiedInSchemaUId = new Guid("833a4cc0-4849-44e3-90a0-f35b015fd060"),
				CreatedInPackageId = new Guid("12195dca-1b7f-42ca-9a53-a3a7e5005031"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateActiveColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("03178c8c-ee13-2b8e-8f7b-b4793cd5de4e"),
				Name = @"Active",
				CreatedInSchemaUId = new Guid("833a4cc0-4849-44e3-90a0-f35b015fd060"),
				ModifiedInSchemaUId = new Guid("833a4cc0-4849-44e3-90a0-f35b015fd060"),
				CreatedInPackageId = new Guid("12195dca-1b7f-42ca-9a53-a3a7e5005031"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"True"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("7e974978-7b60-de84-d4fe-733d59b7f8ef"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("833a4cc0-4849-44e3-90a0-f35b015fd060"),
				ModifiedInSchemaUId = new Guid("833a4cc0-4849-44e3-90a0-f35b015fd060"),
				CreatedInPackageId = new Guid("12195dca-1b7f-42ca-9a53-a3a7e5005031"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateTimeZoneColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("bb3f756c-3995-abef-dc48-2b5d0dcb17c2"),
				Name = @"TimeZone",
				ReferenceSchemaUId = new Guid("a394a569-92d6-44d0-bdda-fa0578373b4f"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("833a4cc0-4849-44e3-90a0-f35b015fd060"),
				ModifiedInSchemaUId = new Guid("833a4cc0-4849-44e3-90a0-f35b015fd060"),
				CreatedInPackageId = new Guid("12195dca-1b7f-42ca-9a53-a3a7e5005031"),
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
			return new VwTechnicalUser(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwTechnicalUser_CrtTechnicalUsersEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwTechnicalUserSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwTechnicalUserSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("833a4cc0-4849-44e3-90a0-f35b015fd060"));
		}

		#endregion

	}

	#endregion

	#region Class: VwTechnicalUser

	/// <summary>
	/// TechnicalUser.
	/// </summary>
	public class VwTechnicalUser : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public VwTechnicalUser(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwTechnicalUser";
		}

		public VwTechnicalUser(VwTechnicalUser source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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

		private SysLanguage _sysCulture;
		/// <summary>
		/// Language.
		/// </summary>
		public SysLanguage SysCulture {
			get {
				return _sysCulture ??
					(_sysCulture = LookupColumnEntities.GetEntity("SysCulture") as SysLanguage);
			}
		}

		/// <summary>
		/// Active.
		/// </summary>
		public bool Active {
			get {
				return GetTypedColumnValue<bool>("Active");
			}
			set {
				SetColumnValue("Active", value);
			}
		}

		/// <exclude/>
		public Guid ContactId {
			get {
				return GetTypedColumnValue<Guid>("ContactId");
			}
			set {
				SetColumnValue("ContactId", value);
				_contact = null;
			}
		}

		/// <exclude/>
		public string ContactName {
			get {
				return GetTypedColumnValue<string>("ContactName");
			}
			set {
				SetColumnValue("ContactName", value);
				if (_contact != null) {
					_contact.Name = value;
				}
			}
		}

		private Contact _contact;
		/// <summary>
		/// Contact.
		/// </summary>
		public Contact Contact {
			get {
				return _contact ??
					(_contact = LookupColumnEntities.GetEntity("Contact") as Contact);
			}
		}

		/// <exclude/>
		public Guid TimeZoneId {
			get {
				return GetTypedColumnValue<Guid>("TimeZoneId");
			}
			set {
				SetColumnValue("TimeZoneId", value);
				_timeZone = null;
			}
		}

		/// <exclude/>
		public string TimeZoneName {
			get {
				return GetTypedColumnValue<string>("TimeZoneName");
			}
			set {
				SetColumnValue("TimeZoneName", value);
				if (_timeZone != null) {
					_timeZone.Name = value;
				}
			}
		}

		private TimeZone _timeZone;
		/// <summary>
		/// Time zone.
		/// </summary>
		public TimeZone TimeZone {
			get {
				return _timeZone ??
					(_timeZone = LookupColumnEntities.GetEntity("TimeZone") as TimeZone);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwTechnicalUser_CrtTechnicalUsersEventsProcess(UserConnection);
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
			return new VwTechnicalUser(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwTechnicalUser_CrtTechnicalUsersEventsProcess

	/// <exclude/>
	public partial class VwTechnicalUser_CrtTechnicalUsersEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : VwTechnicalUser
	{

		public VwTechnicalUser_CrtTechnicalUsersEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwTechnicalUser_CrtTechnicalUsersEventsProcess";
			SchemaUId = new Guid("833a4cc0-4849-44e3-90a0-f35b015fd060");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("833a4cc0-4849-44e3-90a0-f35b015fd060");
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

	#region Class: VwTechnicalUser_CrtTechnicalUsersEventsProcess

	/// <exclude/>
	public class VwTechnicalUser_CrtTechnicalUsersEventsProcess : VwTechnicalUser_CrtTechnicalUsersEventsProcess<VwTechnicalUser>
	{

		public VwTechnicalUser_CrtTechnicalUsersEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwTechnicalUser_CrtTechnicalUsersEventsProcess

	public partial class VwTechnicalUser_CrtTechnicalUsersEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwTechnicalUserEventsProcess

	/// <exclude/>
	public class VwTechnicalUserEventsProcess : VwTechnicalUser_CrtTechnicalUsersEventsProcess
	{

		public VwTechnicalUserEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

