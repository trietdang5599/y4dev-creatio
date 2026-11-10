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
	using System.Runtime.Remoting;
	using SystemSettings = Terrasoft.Core.Configuration.SysSettings;
	using Terrasoft.Common;
	using Terrasoft.Common.Json;
	using Terrasoft.Configuration;
	using Terrasoft.Configuration.EntitySynchronization;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.DcmProcess;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.ImageAPI;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;
	using Terrasoft.GlobalSearch.Indexing;
	using Terrasoft.Messaging.Common;
	using Terrasoft.UI.WebControls.Controls;
	using Terrasoft.UI.WebControls.Utilities.Json.Converters;

	#region Class: Contact_MLangContent_CreatioSchema

	/// <exclude/>
	public class Contact_MLangContent_CreatioSchema : Terrasoft.Configuration.Contact_RelationshipDesigner_CreatioSchema
	{

		#region Constructors: Public

		public Contact_MLangContent_CreatioSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Contact_MLangContent_CreatioSchema(Contact_MLangContent_CreatioSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Contact_MLangContent_CreatioSchema(Contact_MLangContent_CreatioSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("d32f53dd-783a-4e71-b094-b84f4caf68fd");
			Name = "Contact_MLangContent_Creatio";
			ParentSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3");
			ExtendParent = true;
			CreatedInPackageId = new Guid("f767c979-312c-4d92-9d28-97b2835309c5");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateLanguageColumn() {
			EntitySchemaColumn column = base.CreateLanguageColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.Settings,
				ValueSource = @"DefaultMessageLanguage"
			};
			column.ModifiedInSchemaUId = new Guid("d32f53dd-783a-4e71-b094-b84f4caf68fd");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Contact_MLangContent_Creatio(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Contact_MLangContentEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Contact_MLangContent_CreatioSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Contact_MLangContent_CreatioSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d32f53dd-783a-4e71-b094-b84f4caf68fd"));
		}

		#endregion

	}

	#endregion

	#region Class: Contact_MLangContent_Creatio

	/// <summary>
	/// Contact.
	/// </summary>
	public class Contact_MLangContent_Creatio : Terrasoft.Configuration.Contact_RelationshipDesigner_Creatio
	{

		#region Constructors: Public

		public Contact_MLangContent_Creatio(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Contact_MLangContent_Creatio";
		}

		public Contact_MLangContent_Creatio(Contact_MLangContent_Creatio source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Contact_MLangContentEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Inserting += (s, e) => ThrowEvent("Contact_MLangContent_CreatioInserting", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Contact_MLangContent_Creatio(this);
		}

		#endregion

	}

	#endregion

	#region Class: Contact_MLangContentEventsProcess

	/// <exclude/>
	public partial class Contact_MLangContentEventsProcess<TEntity> : Terrasoft.Configuration.Contact_RelationshipDesignerEventsProcess<TEntity> where TEntity : Contact_MLangContent_Creatio
	{

		public Contact_MLangContentEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Contact_MLangContentEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("d32f53dd-783a-4e71-b094-b84f4caf68fd");
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

	#region Class: Contact_MLangContentEventsProcess

	/// <exclude/>
	public class Contact_MLangContentEventsProcess : Contact_MLangContentEventsProcess<Contact_MLangContent_Creatio>
	{

		public Contact_MLangContentEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Contact_MLangContentEventsProcess

	public partial class Contact_MLangContentEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

