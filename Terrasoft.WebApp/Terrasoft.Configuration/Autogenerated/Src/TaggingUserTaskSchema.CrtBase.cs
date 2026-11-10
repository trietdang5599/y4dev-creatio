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

	#region Class: TaggingUserTask

	[DesignModeProperty(Name = "RecordsEsqSerialized", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "9264a575bfd8458d8951f330a3f86088", CaptionResourceItem = "Parameters.RecordsEsqSerialized.Caption", DescriptionResourceItem = "Parameters.RecordsEsqSerialized.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "TagsEsqSerialized", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "9264a575bfd8458d8951f330a3f86088", CaptionResourceItem = "Parameters.TagsEsqSerialized.Caption", DescriptionResourceItem = "Parameters.TagsEsqSerialized.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ProcessedRecordsCount", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "9264a575bfd8458d8951f330a3f86088", CaptionResourceItem = "Parameters.ProcessedRecordsCount.Caption", DescriptionResourceItem = "Parameters.ProcessedRecordsCount.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "TaggingAction", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "9264a575bfd8458d8951f330a3f86088", CaptionResourceItem = "Parameters.TaggingAction.Caption", DescriptionResourceItem = "Parameters.TaggingAction.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ProcessedExceptionMessage", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "9264a575bfd8458d8951f330a3f86088", CaptionResourceItem = "Parameters.ProcessedExceptionMessage.Caption", DescriptionResourceItem = "Parameters.ProcessedExceptionMessage.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "TagInRecordSchemaName", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "9264a575bfd8458d8951f330a3f86088", CaptionResourceItem = "Parameters.TagInRecordSchemaName.Caption", DescriptionResourceItem = "Parameters.TagInRecordSchemaName.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "RecordColumnName", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "9264a575bfd8458d8951f330a3f86088", CaptionResourceItem = "Parameters.RecordColumnName.Caption", DescriptionResourceItem = "Parameters.RecordColumnName.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "TagColumnName", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "9264a575bfd8458d8951f330a3f86088", CaptionResourceItem = "Parameters.TagColumnName.Caption", DescriptionResourceItem = "Parameters.TagColumnName.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "DefaultValues", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "9264a575bfd8458d8951f330a3f86088", CaptionResourceItem = "Parameters.DefaultValues.Caption", DescriptionResourceItem = "Parameters.DefaultValues.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public partial class TaggingUserTask : ProcessUserTask
	{

		#region Constructors: Public

		public TaggingUserTask(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("9264a575-bfd8-458d-8951-f330a3f86088");
		}

		#endregion

		#region Properties: Public

		public virtual string RecordsEsqSerialized {
			get;
			set;
		}

		public virtual string TagsEsqSerialized {
			get;
			set;
		}

		public virtual int ProcessedRecordsCount {
			get;
			set;
		}

		public virtual string TaggingAction {
			get;
			set;
		}

		public virtual string ProcessedExceptionMessage {
			get;
			set;
		}

		public virtual string TagInRecordSchemaName {
			get;
			set;
		}

		public virtual string RecordColumnName {
			get;
			set;
		}

		public virtual string TagColumnName {
			get;
			set;
		}

		public virtual string DefaultValues {
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
				if (!HasMapping("RecordsEsqSerialized")) {
					writer.WriteValue("RecordsEsqSerialized", RecordsEsqSerialized, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("TagsEsqSerialized")) {
					writer.WriteValue("TagsEsqSerialized", TagsEsqSerialized, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("ProcessedRecordsCount")) {
					writer.WriteValue("ProcessedRecordsCount", ProcessedRecordsCount, 0);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("TaggingAction")) {
					writer.WriteValue("TaggingAction", TaggingAction, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("ProcessedExceptionMessage")) {
					writer.WriteValue("ProcessedExceptionMessage", ProcessedExceptionMessage, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("TagInRecordSchemaName")) {
					writer.WriteValue("TagInRecordSchemaName", TagInRecordSchemaName, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("RecordColumnName")) {
					writer.WriteValue("RecordColumnName", RecordColumnName, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("TagColumnName")) {
					writer.WriteValue("TagColumnName", TagColumnName, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("DefaultValues")) {
					writer.WriteValue("DefaultValues", DefaultValues, null);
				}
			}
			writer.WriteFinishObject();
		}

		#endregion

		#region Methods: Protected

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			switch (reader.CurrentName) {
				case "RecordsEsqSerialized":
					if (!UseFlowEngineMode) {
						break;
					}
					RecordsEsqSerialized = reader.GetStringValue();
				break;
				case "TagsEsqSerialized":
					if (!UseFlowEngineMode) {
						break;
					}
					TagsEsqSerialized = reader.GetStringValue();
				break;
				case "ProcessedRecordsCount":
					if (!UseFlowEngineMode) {
						break;
					}
					ProcessedRecordsCount = reader.GetIntValue();
				break;
				case "TaggingAction":
					if (!UseFlowEngineMode) {
						break;
					}
					TaggingAction = reader.GetStringValue();
				break;
				case "ProcessedExceptionMessage":
					if (!UseFlowEngineMode) {
						break;
					}
					ProcessedExceptionMessage = reader.GetStringValue();
				break;
				case "TagInRecordSchemaName":
					if (!UseFlowEngineMode) {
						break;
					}
					TagInRecordSchemaName = reader.GetStringValue();
				break;
				case "RecordColumnName":
					if (!UseFlowEngineMode) {
						break;
					}
					RecordColumnName = reader.GetStringValue();
				break;
				case "TagColumnName":
					if (!UseFlowEngineMode) {
						break;
					}
					TagColumnName = reader.GetStringValue();
				break;
				case "DefaultValues":
					if (!UseFlowEngineMode) {
						break;
					}
					DefaultValues = reader.GetStringValue();
				break;
			}
		}

		#endregion

	}

	#endregion

}

