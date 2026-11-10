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

	#region Class: SocialChannelInTagSchema

	/// <exclude/>
	public class SocialChannelInTagSchema : Terrasoft.Configuration.BaseEntityInTagSchema
	{

		#region Constructors: Public

		public SocialChannelInTagSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SocialChannelInTagSchema(SocialChannelInTagSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SocialChannelInTagSchema(SocialChannelInTagSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("be02c76f-11ae-4537-aeb4-db7cf9d8d971");
			RealUId = new Guid("be02c76f-11ae-4537-aeb4-db7cf9d8d971");
			Name = "SocialChannelInTag";
			ParentSchemaUId = new Guid("5894a2b0-51d5-419a-82bb-238674634270");
			ExtendParent = false;
			CreatedInPackageId = new Guid("323cd82b-b42c-461b-a2e0-e7cefd565455");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = true;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateTagColumn() {
			EntitySchemaColumn column = base.CreateTagColumn();
			column.ReferenceSchemaUId = new Guid("a9b2ff8c-09f7-4577-a961-ac4b87c1ea19");
			column.ColumnValueName = @"TagId";
			column.DisplayColumnValueName = @"TagName";
			column.ModifiedInSchemaUId = new Guid("be02c76f-11ae-4537-aeb4-db7cf9d8d971");
			return column;
		}

		protected override EntitySchemaColumn CreateEntityColumn() {
			EntitySchemaColumn column = base.CreateEntityColumn();
			column.ReferenceSchemaUId = new Guid("dd74c060-eb4b-4f15-b381-db91ca5ac483");
			column.ColumnValueName = @"EntityId";
			column.DisplayColumnValueName = @"EntityTitle";
			column.ModifiedInSchemaUId = new Guid("be02c76f-11ae-4537-aeb4-db7cf9d8d971");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SocialChannelInTag(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SocialChannelInTag_CrtESNEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SocialChannelInTagSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SocialChannelInTagSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("be02c76f-11ae-4537-aeb4-db7cf9d8d971"));
		}

		#endregion

	}

	#endregion

	#region Class: SocialChannelInTag

	/// <summary>
	/// Feed section record tag.
	/// </summary>
	public class SocialChannelInTag : Terrasoft.Configuration.BaseEntityInTag
	{

		#region Constructors: Public

		public SocialChannelInTag(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SocialChannelInTag";
		}

		public SocialChannelInTag(SocialChannelInTag source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SocialChannelInTag_CrtESNEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SocialChannelInTagDeleted", e);
			Deleting += (s, e) => ThrowEvent("SocialChannelInTagDeleting", e);
			Inserted += (s, e) => ThrowEvent("SocialChannelInTagInserted", e);
			Inserting += (s, e) => ThrowEvent("SocialChannelInTagInserting", e);
			Saved += (s, e) => ThrowEvent("SocialChannelInTagSaved", e);
			Saving += (s, e) => ThrowEvent("SocialChannelInTagSaving", e);
			Validating += (s, e) => ThrowEvent("SocialChannelInTagValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SocialChannelInTag(this);
		}

		#endregion

	}

	#endregion

	#region Class: SocialChannelInTag_CrtESNEventsProcess

	/// <exclude/>
	public partial class SocialChannelInTag_CrtESNEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntityInTag_CrtCoreBaseEventsProcess<TEntity> where TEntity : SocialChannelInTag
	{

		public SocialChannelInTag_CrtESNEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SocialChannelInTag_CrtESNEventsProcess";
			SchemaUId = new Guid("be02c76f-11ae-4537-aeb4-db7cf9d8d971");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("be02c76f-11ae-4537-aeb4-db7cf9d8d971");
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

	#region Class: SocialChannelInTag_CrtESNEventsProcess

	/// <exclude/>
	public class SocialChannelInTag_CrtESNEventsProcess : SocialChannelInTag_CrtESNEventsProcess<SocialChannelInTag>
	{

		public SocialChannelInTag_CrtESNEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SocialChannelInTag_CrtESNEventsProcess

	public partial class SocialChannelInTag_CrtESNEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SocialChannelInTagEventsProcess

	/// <exclude/>
	public class SocialChannelInTagEventsProcess : SocialChannelInTag_CrtESNEventsProcess
	{

		public SocialChannelInTagEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

