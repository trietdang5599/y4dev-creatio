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

	#region Class: LogStackTraceUserTask

	[DesignModeProperty(Name = "Sys_StackTrace", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "260927a906d24444a73a404f3cce7c06", CaptionResourceItem = "Parameters.Sys_StackTrace.Caption", DescriptionResourceItem = "Parameters.Sys_StackTrace.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public partial class LogStackTraceUserTask : ProcessUserTask
	{

		#region Constructors: Public

		public LogStackTraceUserTask(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("260927a9-06d2-4444-a73a-404f3cce7c06");
		}

		#endregion

		#region Properties: Public

		public virtual string Sys_StackTrace {
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
			if (!HasMapping("Sys_StackTrace")) {
				writer.WriteValue("Sys_StackTrace", Sys_StackTrace, null);
			}
			writer.WriteFinishObject();
		}

		#endregion

		#region Methods: Protected

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			switch (reader.CurrentName) {
				case "Sys_StackTrace":
					Sys_StackTrace = reader.GetStringValue();
				break;
			}
		}

		#endregion

	}

	#endregion

}

