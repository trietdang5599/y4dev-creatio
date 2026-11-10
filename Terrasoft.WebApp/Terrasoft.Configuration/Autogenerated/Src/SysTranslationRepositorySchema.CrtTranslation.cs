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

	#region Class: SysTranslationRepositorySchema

	/// <exclude/>
	public class SysTranslationRepositorySchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysTranslationRepositorySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysTranslationRepositorySchema(SysTranslationRepositorySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysTranslationRepositorySchema(SysTranslationRepositorySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ad3291e6-a096-46ae-b7b0-a713d384eca5");
			RealUId = new Guid("ad3291e6-a096-46ae-b7b0-a713d384eca5");
			Name = "SysTranslationRepository";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("e6c02023-b16a-4dae-a68b-e87240cf3334");
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
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysTranslationRepository(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysTranslationRepository_CrtTranslationEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysTranslationRepositorySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysTranslationRepositorySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ad3291e6-a096-46ae-b7b0-a713d384eca5"));
		}

		#endregion

	}

	#endregion

	#region Class: SysTranslationRepository

	/// <summary>
	/// History of source files for core translations.
	/// </summary>
	public class SysTranslationRepository : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysTranslationRepository(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysTranslationRepository";
		}

		public SysTranslationRepository(SysTranslationRepository source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysTranslationRepository_CrtTranslationEventsProcess(UserConnection);
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
			return new SysTranslationRepository(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysTranslationRepository_CrtTranslationEventsProcess

	/// <exclude/>
	public partial class SysTranslationRepository_CrtTranslationEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : SysTranslationRepository
	{

		public SysTranslationRepository_CrtTranslationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysTranslationRepository_CrtTranslationEventsProcess";
			SchemaUId = new Guid("ad3291e6-a096-46ae-b7b0-a713d384eca5");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ad3291e6-a096-46ae-b7b0-a713d384eca5");
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

	#region Class: SysTranslationRepository_CrtTranslationEventsProcess

	/// <exclude/>
	public class SysTranslationRepository_CrtTranslationEventsProcess : SysTranslationRepository_CrtTranslationEventsProcess<SysTranslationRepository>
	{

		public SysTranslationRepository_CrtTranslationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysTranslationRepository_CrtTranslationEventsProcess

	public partial class SysTranslationRepository_CrtTranslationEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysTranslationRepositoryEventsProcess

	/// <exclude/>
	public class SysTranslationRepositoryEventsProcess : SysTranslationRepository_CrtTranslationEventsProcess
	{

		public SysTranslationRepositoryEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

