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

	#region Class: UIRedirectBlacklistSchema

	/// <exclude/>
	public class UIRedirectBlacklistSchema : Terrasoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public UIRedirectBlacklistSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public UIRedirectBlacklistSchema(UIRedirectBlacklistSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public UIRedirectBlacklistSchema(UIRedirectBlacklistSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("49eaf5bc-9be7-4a79-bdde-f4ffba2021c8");
			RealUId = new Guid("49eaf5bc-9be7-4a79-bdde-f4ffba2021c8");
			Name = "UIRedirectBlacklist";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("c302261e-8f3d-4933-bbe5-b7b61ee66faa");
			IsDBView = false;
			UseDenyRecordRights = false;
			ShowInAdvancedMode = false;
			UseLiveEditing = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("854de376-826c-79fe-b11c-af8bf0254d17")) == null) {
				Columns.Add(CreateUrlColumn());
			}
			if (Columns.FindByUId(new Guid("580a8482-bf05-7b71-7e25-0eafd5366a93")) == null) {
				Columns.Add(CreateDescriptionColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateUrlColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("854de376-826c-79fe-b11c-af8bf0254d17"),
				Name = @"Url",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("49eaf5bc-9be7-4a79-bdde-f4ffba2021c8"),
				ModifiedInSchemaUId = new Guid("49eaf5bc-9be7-4a79-bdde-f4ffba2021c8"),
				CreatedInPackageId = new Guid("c302261e-8f3d-4933-bbe5-b7b61ee66faa"),
				IsFormatValidated = true
			};
		}

		protected virtual EntitySchemaColumn CreateDescriptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("580a8482-bf05-7b71-7e25-0eafd5366a93"),
				Name = @"Description",
				CreatedInSchemaUId = new Guid("49eaf5bc-9be7-4a79-bdde-f4ffba2021c8"),
				ModifiedInSchemaUId = new Guid("49eaf5bc-9be7-4a79-bdde-f4ffba2021c8"),
				CreatedInPackageId = new Guid("c302261e-8f3d-4933-bbe5-b7b61ee66faa"),
				IsFormatValidated = true
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new UIRedirectBlacklist(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new UIRedirectBlacklist_CrtNUIEventsProcess(userConnection);
		}

		public override object Clone() {
			return new UIRedirectBlacklistSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new UIRedirectBlacklistSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("49eaf5bc-9be7-4a79-bdde-f4ffba2021c8"));
		}

		#endregion

	}

	#endregion

	#region Class: UIRedirectBlacklist

	/// <summary>
	/// Blacklist of redirects from Classic UI.
	/// </summary>
	/// <remarks>
	/// A collection of URLs that are prohibited from being automatically redirected from the Classic UI to the new Freedom UI. When an end-user opens the direct URL to the Classic UI (ViewModule.aspx or .html), the system will first check if the requested URL is included in the blacklist. If it is, the URL will be opened without any changes. If it's not, the user will be automatically redirected to the corresponding page in the Freedom UI.
	/// 
	/// The purpose of the blacklist is to prevent certain pages from being redirected for various reasons, such as ensuring that certain features or functionality are preserved or avoiding conflicts with other systems or applications.
	/// </remarks>
	public class UIRedirectBlacklist : Terrasoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public UIRedirectBlacklist(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "UIRedirectBlacklist";
		}

		public UIRedirectBlacklist(UIRedirectBlacklist source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// URL.
		/// </summary>
		public string Url {
			get {
				return GetTypedColumnValue<string>("Url");
			}
			set {
				SetColumnValue("Url", value);
			}
		}

		/// <summary>
		/// Description.
		/// </summary>
		public string Description {
			get {
				return GetTypedColumnValue<string>("Description");
			}
			set {
				SetColumnValue("Description", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new UIRedirectBlacklist_CrtNUIEventsProcess(UserConnection);
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
			return new UIRedirectBlacklist(this);
		}

		#endregion

	}

	#endregion

	#region Class: UIRedirectBlacklist_CrtNUIEventsProcess

	/// <exclude/>
	public partial class UIRedirectBlacklist_CrtNUIEventsProcess<TEntity> : Terrasoft.Configuration.BaseEntity_CrtCoreBaseEventsProcess<TEntity> where TEntity : UIRedirectBlacklist
	{

		public UIRedirectBlacklist_CrtNUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "UIRedirectBlacklist_CrtNUIEventsProcess";
			SchemaUId = new Guid("49eaf5bc-9be7-4a79-bdde-f4ffba2021c8");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("49eaf5bc-9be7-4a79-bdde-f4ffba2021c8");
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

	#region Class: UIRedirectBlacklist_CrtNUIEventsProcess

	/// <exclude/>
	public class UIRedirectBlacklist_CrtNUIEventsProcess : UIRedirectBlacklist_CrtNUIEventsProcess<UIRedirectBlacklist>
	{

		public UIRedirectBlacklist_CrtNUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: UIRedirectBlacklist_CrtNUIEventsProcess

	public partial class UIRedirectBlacklist_CrtNUIEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: UIRedirectBlacklistEventsProcess

	/// <exclude/>
	public class UIRedirectBlacklistEventsProcess : UIRedirectBlacklist_CrtNUIEventsProcess
	{

		public UIRedirectBlacklistEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

