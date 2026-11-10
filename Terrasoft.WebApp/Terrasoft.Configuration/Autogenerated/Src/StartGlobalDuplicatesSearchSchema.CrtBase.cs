namespace Terrasoft.Core.Process.Configuration
{

	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using Quartz;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Scheduler;
	using Terrasoft.UI.WebControls.Controls;

	#region Class: StartGlobalDuplicatesSearch

	[DesignModeProperty(Name = "SchemaName", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "a7f280e43d724bb29a46fa819c9fcdf1", CaptionResourceItem = "Parameters.SchemaName.Caption", DescriptionResourceItem = "Parameters.SchemaName.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public class StartGlobalDuplicatesSearch : ProcessUserTask
	{

		#region Constructors: Public

		public StartGlobalDuplicatesSearch(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("a7f280e4-3d72-4bb2-9a46-fa819c9fcdf1");
		}

		#endregion

		#region Properties: Public

		public virtual string SchemaName {
			get;
			set;
		}

		#endregion

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
			string jobProcessName = (SchemaName == "Account") ? "StartGlobalAccountDuplicatesSearch" : "StartGlobalContactDuplicatesSearch";
			AppScheduler.ScheduleImmediateProcessJob("DuplicatesSearchJob", "DuplicatesSearchGroup", 
				jobProcessName, UserConnection.Workspace.Name, UserConnection.CurrentUser.Name);
			return true;
		}

		#endregion

		#region Methods: Public

		public override bool CompleteExecuting(params object[] parameters) {
			return base.CompleteExecuting(parameters);
		}

		public override void WritePropertiesData(DataWriter writer) {
			writer.WriteStartObject(Name);
			base.WritePropertiesData(writer);
			if (Status == Core.Process.ProcessStatus.Inactive) {
				writer.WriteFinishObject();
				return;
			}
			if (!HasMapping("SchemaName")) {
				writer.WriteValue("SchemaName", SchemaName, null);
			}
			writer.WriteFinishObject();
		}

		#endregion

		#region Methods: Protected

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			switch (reader.CurrentName) {
				case "SchemaName":
					SchemaName = reader.GetStringValue();
				break;
			}
		}

		#endregion

	}

	#endregion

}

