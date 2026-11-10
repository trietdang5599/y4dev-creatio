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

	#region Class: CheckCanExecuteOperationUserTask

	[DesignModeProperty(Name = "UserId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b9cdf58c44b24c80b6d68cb0c5c99cb9", CaptionResourceItem = "Parameters.UserId.Caption", DescriptionResourceItem = "Parameters.UserId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "CanExecuteOperation", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b9cdf58c44b24c80b6d68cb0c5c99cb9", CaptionResourceItem = "Parameters.CanExecuteOperation.Caption", DescriptionResourceItem = "Parameters.CanExecuteOperation.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "OperationCode", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b9cdf58c44b24c80b6d68cb0c5c99cb9", CaptionResourceItem = "Parameters.OperationCode.Caption", DescriptionResourceItem = "Parameters.OperationCode.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public partial class CheckCanExecuteOperationUserTask : ProcessUserTask
	{

		#region Constructors: Public

		public CheckCanExecuteOperationUserTask(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("b9cdf58c-44b2-4c80-b6d6-8cb0c5c99cb9");
		}

		#endregion

		#region Properties: Public

		public virtual Guid UserId {
			get;
			set;
		}

		public virtual bool CanExecuteOperation {
			get;
			set;
		}

		public virtual string OperationCode {
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
			if (UseFlowEngineMode) {
				if (!HasMapping("CanExecuteOperation")) {
					writer.WriteValue("CanExecuteOperation", CanExecuteOperation, false);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("OperationCode")) {
					writer.WriteValue("OperationCode", OperationCode, null);
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
				case "CanExecuteOperation":
					if (!UseFlowEngineMode) {
						break;
					}
					CanExecuteOperation = reader.GetBoolValue();
				break;
				case "OperationCode":
					if (!UseFlowEngineMode) {
						break;
					}
					OperationCode = reader.GetStringValue();
				break;
			}
		}

		#endregion

	}

	#endregion

}

