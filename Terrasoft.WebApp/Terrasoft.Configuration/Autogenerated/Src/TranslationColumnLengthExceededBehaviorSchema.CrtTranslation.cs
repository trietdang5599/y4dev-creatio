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

	#region Class: TranslationColumnLengthExceededBehaviorSchema

	/// <exclude/>
	public class TranslationColumnLengthExceededBehaviorSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public TranslationColumnLengthExceededBehaviorSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public TranslationColumnLengthExceededBehaviorSchema(TranslationColumnLengthExceededBehaviorSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public TranslationColumnLengthExceededBehaviorSchema(TranslationColumnLengthExceededBehaviorSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7245b397-5576-4587-96d9-debd742a6a77");
			RealUId = new Guid("7245b397-5576-4587-96d9-debd742a6a77");
			Name = "TranslationColumnLengthExceededBehavior";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("7f54b679-3b0b-4660-b8f9-58edcf67599e");
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
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new TranslationColumnLengthExceededBehavior(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new TranslationColumnLengthExceededBehavior_CrtTranslationEventsProcess(userConnection);
		}

		public override object Clone() {
			return new TranslationColumnLengthExceededBehaviorSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new TranslationColumnLengthExceededBehaviorSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7245b397-5576-4587-96d9-debd742a6a77"));
		}

		#endregion

	}

	#endregion

	#region Class: TranslationColumnLengthExceededBehavior

	/// <summary>
	/// Translation exceeds the column length behavior.
	/// </summary>
	public class TranslationColumnLengthExceededBehavior : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public TranslationColumnLengthExceededBehavior(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "TranslationColumnLengthExceededBehavior";
		}

		public TranslationColumnLengthExceededBehavior(TranslationColumnLengthExceededBehavior source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new TranslationColumnLengthExceededBehavior_CrtTranslationEventsProcess(UserConnection);
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
			return new TranslationColumnLengthExceededBehavior(this);
		}

		#endregion

	}

	#endregion

	#region Class: TranslationColumnLengthExceededBehavior_CrtTranslationEventsProcess

	/// <exclude/>
	public partial class TranslationColumnLengthExceededBehavior_CrtTranslationEventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : TranslationColumnLengthExceededBehavior
	{

		public TranslationColumnLengthExceededBehavior_CrtTranslationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "TranslationColumnLengthExceededBehavior_CrtTranslationEventsProcess";
			SchemaUId = new Guid("7245b397-5576-4587-96d9-debd742a6a77");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("7245b397-5576-4587-96d9-debd742a6a77");
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

	#region Class: TranslationColumnLengthExceededBehavior_CrtTranslationEventsProcess

	/// <exclude/>
	public class TranslationColumnLengthExceededBehavior_CrtTranslationEventsProcess : TranslationColumnLengthExceededBehavior_CrtTranslationEventsProcess<TranslationColumnLengthExceededBehavior>
	{

		public TranslationColumnLengthExceededBehavior_CrtTranslationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: TranslationColumnLengthExceededBehavior_CrtTranslationEventsProcess

	public partial class TranslationColumnLengthExceededBehavior_CrtTranslationEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: TranslationColumnLengthExceededBehaviorEventsProcess

	/// <exclude/>
	public class TranslationColumnLengthExceededBehaviorEventsProcess : TranslationColumnLengthExceededBehavior_CrtTranslationEventsProcess
	{

		public TranslationColumnLengthExceededBehaviorEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

