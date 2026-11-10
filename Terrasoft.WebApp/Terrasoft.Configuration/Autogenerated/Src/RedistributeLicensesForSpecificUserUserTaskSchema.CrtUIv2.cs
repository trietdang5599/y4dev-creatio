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

	#region Class: RedistributeLicensesForSpecificUserUserTask

	[DesignModeProperty(Name = "UserId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "95c532df66764afb9fd7e907ed924c50", CaptionResourceItem = "Parameters.UserId.Caption", DescriptionResourceItem = "Parameters.UserId.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public partial class RedistributeLicensesForSpecificUserUserTask : ProcessUserTask
	{

		#region Constructors: Public

		public RedistributeLicensesForSpecificUserUserTask(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("95c532df-6676-4afb-9fd7-e907ed924c50");
		}

		#endregion

		#region Properties: Public

		public virtual Guid UserId {
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
			if (UseFlowEngineMode) {
				if (!HasMapping("UserId")) {
					writer.WriteValue("UserId", UserId, Guid.Empty);
				}
			}
			writer.WriteFinishObject();
		}

		#endregion

		#region Methods: Protected

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			switch (reader.CurrentName) {
				case "UserId":
					if (!UseFlowEngineMode) {
						break;
					}
					UserId = reader.GetGuidValue();
				break;
			}
		}

		#endregion

	}

	#endregion

}

