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

	#region Class: OpenIdFieldNameMapSchema

	/// <exclude/>
	public class OpenIdFieldNameMapSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public OpenIdFieldNameMapSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OpenIdFieldNameMapSchema(OpenIdFieldNameMapSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OpenIdFieldNameMapSchema(OpenIdFieldNameMapSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("21bc0031-f482-47ea-9b0f-74608db8d2c1");
			RealUId = new Guid("21bc0031-f482-47ea-9b0f-74608db8d2c1");
			Name = "OpenIdFieldNameMap";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("85dd5d35-051c-4dc7-bcb8-3155c57f38aa");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
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
			if (Columns.FindByUId(new Guid("1c89f638-0ee2-c27d-a7b9-e347f7606862")) == null) {
				Columns.Add(CreateEntityFieldNameColumn());
			}
			if (Columns.FindByUId(new Guid("2fa8557d-005e-23d9-dc3f-4eafeb768a5a")) == null) {
				Columns.Add(CreateOpenIdClaimNameColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateEntityFieldNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("1c89f638-0ee2-c27d-a7b9-e347f7606862"),
				Name = @"EntityFieldName",
				CreatedInSchemaUId = new Guid("21bc0031-f482-47ea-9b0f-74608db8d2c1"),
				ModifiedInSchemaUId = new Guid("21bc0031-f482-47ea-9b0f-74608db8d2c1"),
				CreatedInPackageId = new Guid("85dd5d35-051c-4dc7-bcb8-3155c57f38aa")
			};
		}

		protected virtual EntitySchemaColumn CreateOpenIdClaimNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("2fa8557d-005e-23d9-dc3f-4eafeb768a5a"),
				Name = @"OpenIdClaimName",
				CreatedInSchemaUId = new Guid("21bc0031-f482-47ea-9b0f-74608db8d2c1"),
				ModifiedInSchemaUId = new Guid("21bc0031-f482-47ea-9b0f-74608db8d2c1"),
				CreatedInPackageId = new Guid("85dd5d35-051c-4dc7-bcb8-3155c57f38aa")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new OpenIdFieldNameMap(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OpenIdFieldNameMap_OpenIdAuthEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OpenIdFieldNameMapSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OpenIdFieldNameMapSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("21bc0031-f482-47ea-9b0f-74608db8d2c1"));
		}

		#endregion

	}

	#endregion

	#region Class: OpenIdFieldNameMap

	/// <summary>
	/// Mapping OpenID claims to entity fields.
	/// </summary>
	public class OpenIdFieldNameMap : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public OpenIdFieldNameMap(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OpenIdFieldNameMap";
		}

		public OpenIdFieldNameMap(OpenIdFieldNameMap source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Entity field name.
		/// </summary>
		public string EntityFieldName {
			get {
				return GetTypedColumnValue<string>("EntityFieldName");
			}
			set {
				SetColumnValue("EntityFieldName", value);
			}
		}

		/// <summary>
		/// OpenId claim name/type.
		/// </summary>
		public string OpenIdClaimName {
			get {
				return GetTypedColumnValue<string>("OpenIdClaimName");
			}
			set {
				SetColumnValue("OpenIdClaimName", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OpenIdFieldNameMap_OpenIdAuthEventsProcess(UserConnection);
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
			return new OpenIdFieldNameMap(this);
		}

		#endregion

	}

	#endregion

	#region Class: OpenIdFieldNameMap_OpenIdAuthEventsProcess

	/// <exclude/>
	public partial class OpenIdFieldNameMap_OpenIdAuthEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : OpenIdFieldNameMap
	{

		public OpenIdFieldNameMap_OpenIdAuthEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OpenIdFieldNameMap_OpenIdAuthEventsProcess";
			SchemaUId = new Guid("21bc0031-f482-47ea-9b0f-74608db8d2c1");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("21bc0031-f482-47ea-9b0f-74608db8d2c1");
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

	#region Class: OpenIdFieldNameMap_OpenIdAuthEventsProcess

	/// <exclude/>
	public class OpenIdFieldNameMap_OpenIdAuthEventsProcess : OpenIdFieldNameMap_OpenIdAuthEventsProcess<OpenIdFieldNameMap>
	{

		public OpenIdFieldNameMap_OpenIdAuthEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OpenIdFieldNameMap_OpenIdAuthEventsProcess

	public partial class OpenIdFieldNameMap_OpenIdAuthEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: OpenIdFieldNameMapEventsProcess

	/// <exclude/>
	public class OpenIdFieldNameMapEventsProcess : OpenIdFieldNameMap_OpenIdAuthEventsProcess
	{

		public OpenIdFieldNameMapEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

