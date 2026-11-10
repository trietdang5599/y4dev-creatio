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

	#region Class: DeduplicationFavoriteColumnsSchema

	/// <exclude/>
	public class DeduplicationFavoriteColumnsSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public DeduplicationFavoriteColumnsSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public DeduplicationFavoriteColumnsSchema(DeduplicationFavoriteColumnsSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public DeduplicationFavoriteColumnsSchema(DeduplicationFavoriteColumnsSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b509cee5-d891-4b6c-a26f-3b2c64cab6de");
			RealUId = new Guid("b509cee5-d891-4b6c-a26f-3b2c64cab6de");
			Name = "DeduplicationFavoriteColumns";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("2fe07405-a892-4851-93bf-f64b9dac2200");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("1f2b6664-211b-5af9-eb7b-82e958802e09")) == null) {
				Columns.Add(CreateObjectNameColumn());
			}
			if (Columns.FindByUId(new Guid("81bd612a-aeea-57db-9ee8-cae4842c7865")) == null) {
				Columns.Add(CreateColumnNameColumn());
			}
			if (Columns.FindByUId(new Guid("263c2273-e60f-2ebf-de66-b214854018b5")) == null) {
				Columns.Add(CreatePositionColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateObjectNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("1f2b6664-211b-5af9-eb7b-82e958802e09"),
				Name = @"ObjectName",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("b509cee5-d891-4b6c-a26f-3b2c64cab6de"),
				ModifiedInSchemaUId = new Guid("b509cee5-d891-4b6c-a26f-3b2c64cab6de"),
				CreatedInPackageId = new Guid("2fe07405-a892-4851-93bf-f64b9dac2200")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("81bd612a-aeea-57db-9ee8-cae4842c7865"),
				Name = @"ColumnName",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("b509cee5-d891-4b6c-a26f-3b2c64cab6de"),
				ModifiedInSchemaUId = new Guid("b509cee5-d891-4b6c-a26f-3b2c64cab6de"),
				CreatedInPackageId = new Guid("2fe07405-a892-4851-93bf-f64b9dac2200")
			};
		}

		protected virtual EntitySchemaColumn CreatePositionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("263c2273-e60f-2ebf-de66-b214854018b5"),
				Name = @"Position",
				CreatedInSchemaUId = new Guid("b509cee5-d891-4b6c-a26f-3b2c64cab6de"),
				ModifiedInSchemaUId = new Guid("b509cee5-d891-4b6c-a26f-3b2c64cab6de"),
				CreatedInPackageId = new Guid("32aabc39-f9dd-46d7-bd87-4753cb3e9db8"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"0"
				}
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new DeduplicationFavoriteColumns(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new DeduplicationFavoriteColumns_CrtDeduplicationEventsProcess(userConnection);
		}

		public override object Clone() {
			return new DeduplicationFavoriteColumnsSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new DeduplicationFavoriteColumnsSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b509cee5-d891-4b6c-a26f-3b2c64cab6de"));
		}

		#endregion

	}

	#endregion

	#region Class: DeduplicationFavoriteColumns

	/// <summary>
	/// Favorite columns for deduplication.
	/// </summary>
	public class DeduplicationFavoriteColumns : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public DeduplicationFavoriteColumns(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "DeduplicationFavoriteColumns";
		}

		public DeduplicationFavoriteColumns(DeduplicationFavoriteColumns source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Object name.
		/// </summary>
		public string ObjectName {
			get {
				return GetTypedColumnValue<string>("ObjectName");
			}
			set {
				SetColumnValue("ObjectName", value);
			}
		}

		/// <summary>
		/// Column Name.
		/// </summary>
		public string ColumnName {
			get {
				return GetTypedColumnValue<string>("ColumnName");
			}
			set {
				SetColumnValue("ColumnName", value);
			}
		}

		/// <summary>
		/// Position.
		/// </summary>
		public int Position {
			get {
				return GetTypedColumnValue<int>("Position");
			}
			set {
				SetColumnValue("Position", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new DeduplicationFavoriteColumns_CrtDeduplicationEventsProcess(UserConnection);
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
			return new DeduplicationFavoriteColumns(this);
		}

		#endregion

	}

	#endregion

	#region Class: DeduplicationFavoriteColumns_CrtDeduplicationEventsProcess

	/// <exclude/>
	public partial class DeduplicationFavoriteColumns_CrtDeduplicationEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : DeduplicationFavoriteColumns
	{

		public DeduplicationFavoriteColumns_CrtDeduplicationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "DeduplicationFavoriteColumns_CrtDeduplicationEventsProcess";
			SchemaUId = new Guid("b509cee5-d891-4b6c-a26f-3b2c64cab6de");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("b509cee5-d891-4b6c-a26f-3b2c64cab6de");
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

	#region Class: DeduplicationFavoriteColumns_CrtDeduplicationEventsProcess

	/// <exclude/>
	public class DeduplicationFavoriteColumns_CrtDeduplicationEventsProcess : DeduplicationFavoriteColumns_CrtDeduplicationEventsProcess<DeduplicationFavoriteColumns>
	{

		public DeduplicationFavoriteColumns_CrtDeduplicationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: DeduplicationFavoriteColumns_CrtDeduplicationEventsProcess

	public partial class DeduplicationFavoriteColumns_CrtDeduplicationEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: DeduplicationFavoriteColumnsEventsProcess

	/// <exclude/>
	public class DeduplicationFavoriteColumnsEventsProcess : DeduplicationFavoriteColumns_CrtDeduplicationEventsProcess
	{

		public DeduplicationFavoriteColumnsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

