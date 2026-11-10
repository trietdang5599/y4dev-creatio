namespace Terrasoft.Core.Process.Configuration
{

	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
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
	using Terrasoft.UI.WebControls.Controls;

	#region Class: OAuthResourceMaintenanceUserTask

	[DesignModeProperty(Name = "ExecutionStatus", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "964232fe6e484742a5a8f67ae31f1fb5", CaptionResourceItem = "Parameters.ExecutionStatus.Caption", DescriptionResourceItem = "Parameters.ExecutionStatus.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public partial class OAuthResourceMaintenanceUserTask : ProcessUserTask
	{

		#region Constructors: Public

		public OAuthResourceMaintenanceUserTask(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("964232fe-6e48-4742-a5a8-f67ae31f1fb5");
		}

		#endregion

		#region Properties: Public

		public virtual bool ExecutionStatus {
			get;
			set;
		}

		#endregion

		#region Methods: Public

		public override void WritePropertiesData(DataWriter writer) {
			writer.WriteStartObject(Name);
			base.WritePropertiesData(writer);
			if (Status == Core.Process.ProcessStatus.Inactive) {
				writer.WriteFinishObject();
				return;
			}
			if (!HasMapping("ExecutionStatus")) {
				writer.WriteValue("ExecutionStatus", ExecutionStatus, false);
			}
			writer.WriteFinishObject();
		}

		#endregion

		#region Methods: Protected

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			switch (reader.CurrentName) {
				case "ExecutionStatus":
					ExecutionStatus = reader.GetBoolValue();
				break;
			}
		}

		#endregion

	}

	#endregion

}

