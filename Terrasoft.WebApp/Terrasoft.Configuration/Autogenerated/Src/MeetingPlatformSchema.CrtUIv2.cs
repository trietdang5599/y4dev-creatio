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

	#region Class: MeetingPlatformSchema

	/// <exclude/>
	public class MeetingPlatformSchema : Terrasoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public MeetingPlatformSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public MeetingPlatformSchema(MeetingPlatformSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public MeetingPlatformSchema(MeetingPlatformSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c2f3532e-5134-486b-a085-54728b8e1f22");
			RealUId = new Guid("c2f3532e-5134-486b-a085-54728b8e1f22");
			Name = "MeetingPlatform";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
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
			if (Columns.FindByUId(new Guid("2a010f0a-07f5-cb08-75f5-6c403bc4bba3")) == null) {
				Columns.Add(CreateCodeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("2a010f0a-07f5-cb08-75f5-6c403bc4bba3"),
				Name = @"Code",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("c2f3532e-5134-486b-a085-54728b8e1f22"),
				ModifiedInSchemaUId = new Guid("c2f3532e-5134-486b-a085-54728b8e1f22"),
				CreatedInPackageId = new Guid("d699061b-815e-49b9-8730-21a5e5db2044")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new MeetingPlatform(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new MeetingPlatform_CrtUIv2EventsProcess(userConnection);
		}

		public override object Clone() {
			return new MeetingPlatformSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new MeetingPlatformSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c2f3532e-5134-486b-a085-54728b8e1f22"));
		}

		#endregion

	}

	#endregion

	#region Class: MeetingPlatform

	/// <summary>
	/// Meeting platform.
	/// </summary>
	public class MeetingPlatform : Terrasoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public MeetingPlatform(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MeetingPlatform";
		}

		public MeetingPlatform(MeetingPlatform source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Code.
		/// </summary>
		public string Code {
			get {
				return GetTypedColumnValue<string>("Code");
			}
			set {
				SetColumnValue("Code", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new MeetingPlatform_CrtUIv2EventsProcess(UserConnection);
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
			return new MeetingPlatform(this);
		}

		#endregion

	}

	#endregion

	#region Class: MeetingPlatform_CrtUIv2EventsProcess

	/// <exclude/>
	public partial class MeetingPlatform_CrtUIv2EventsProcess<TEntity> : Terrasoft.Configuration.BaseLookup_CrtCoreBaseEventsProcess<TEntity> where TEntity : MeetingPlatform
	{

		public MeetingPlatform_CrtUIv2EventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "MeetingPlatform_CrtUIv2EventsProcess";
			SchemaUId = new Guid("c2f3532e-5134-486b-a085-54728b8e1f22");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("c2f3532e-5134-486b-a085-54728b8e1f22");
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

	#region Class: MeetingPlatform_CrtUIv2EventsProcess

	/// <exclude/>
	public class MeetingPlatform_CrtUIv2EventsProcess : MeetingPlatform_CrtUIv2EventsProcess<MeetingPlatform>
	{

		public MeetingPlatform_CrtUIv2EventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: MeetingPlatform_CrtUIv2EventsProcess

	public partial class MeetingPlatform_CrtUIv2EventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: MeetingPlatformEventsProcess

	/// <exclude/>
	public class MeetingPlatformEventsProcess : MeetingPlatform_CrtUIv2EventsProcess
	{

		public MeetingPlatformEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

