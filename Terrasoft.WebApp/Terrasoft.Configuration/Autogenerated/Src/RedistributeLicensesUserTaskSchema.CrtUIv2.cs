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

	#region Class: RedistributeLicensesUserTask

	[DesignModeProperty(Name = "RedistributeLicencesForSpecificRole", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "197179b8b7ba45638a3d7d87e5be35ac", CaptionResourceItem = "Parameters.RedistributeLicencesForSpecificRole.Caption", DescriptionResourceItem = "Parameters.RedistributeLicencesForSpecificRole.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "RedistributeManuallyAssignedLicences", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "197179b8b7ba45638a3d7d87e5be35ac", CaptionResourceItem = "Parameters.RedistributeManuallyAssignedLicences.Caption", DescriptionResourceItem = "Parameters.RedistributeManuallyAssignedLicences.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "RoleId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "197179b8b7ba45638a3d7d87e5be35ac", CaptionResourceItem = "Parameters.RoleId.Caption", DescriptionResourceItem = "Parameters.RoleId.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public partial class RedistributeLicensesUserTask : ProcessUserTask
	{

		#region Constructors: Public

		public RedistributeLicensesUserTask(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("197179b8-b7ba-4563-8a3d-7d87e5be35ac");
		}

		#endregion

		#region Properties: Public

		public virtual bool RedistributeLicencesForSpecificRole {
			get;
			set;
		}

		public virtual bool RedistributeManuallyAssignedLicences {
			get;
			set;
		}

		public virtual Guid RoleId {
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
				if (!HasMapping("RedistributeLicencesForSpecificRole")) {
					writer.WriteValue("RedistributeLicencesForSpecificRole", RedistributeLicencesForSpecificRole, false);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("RedistributeManuallyAssignedLicences")) {
					writer.WriteValue("RedistributeManuallyAssignedLicences", RedistributeManuallyAssignedLicences, false);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("RoleId")) {
					writer.WriteValue("RoleId", RoleId, Guid.Empty);
				}
			}
			writer.WriteFinishObject();
		}

		#endregion

		#region Methods: Protected

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			switch (reader.CurrentName) {
				case "RedistributeLicencesForSpecificRole":
					if (!UseFlowEngineMode) {
						break;
					}
					RedistributeLicencesForSpecificRole = reader.GetBoolValue();
				break;
				case "RedistributeManuallyAssignedLicences":
					if (!UseFlowEngineMode) {
						break;
					}
					RedistributeManuallyAssignedLicences = reader.GetBoolValue();
				break;
				case "RoleId":
					if (!UseFlowEngineMode) {
						break;
					}
					RoleId = reader.GetGuidValue();
				break;
			}
		}

		#endregion

	}

	#endregion

}

