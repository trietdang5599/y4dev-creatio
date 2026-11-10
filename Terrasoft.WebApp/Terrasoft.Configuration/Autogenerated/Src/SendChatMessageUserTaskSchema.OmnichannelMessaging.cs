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

	#region Class: SendChatMessageUserTask

	[DesignModeProperty(Name = "Channel", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "eb39d4a655db40eea8e7705b5ad7b9c0", CaptionResourceItem = "Parameters.Channel.Caption", DescriptionResourceItem = "Parameters.Channel.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Contact", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "eb39d4a655db40eea8e7705b5ad7b9c0", CaptionResourceItem = "Parameters.Contact.Caption", DescriptionResourceItem = "Parameters.Contact.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Message", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "eb39d4a655db40eea8e7705b5ad7b9c0", CaptionResourceItem = "Parameters.Message.Caption", DescriptionResourceItem = "Parameters.Message.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "MessageType", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "eb39d4a655db40eea8e7705b5ad7b9c0", CaptionResourceItem = "Parameters.MessageType.Caption", DescriptionResourceItem = "Parameters.MessageType.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Template", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "eb39d4a655db40eea8e7705b5ad7b9c0", CaptionResourceItem = "Parameters.Template.Caption", DescriptionResourceItem = "Parameters.Template.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "IgnoreErrors", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "eb39d4a655db40eea8e7705b5ad7b9c0", CaptionResourceItem = "Parameters.IgnoreErrors.Caption", DescriptionResourceItem = "Parameters.IgnoreErrors.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "SendStatus", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "eb39d4a655db40eea8e7705b5ad7b9c0", CaptionResourceItem = "Parameters.SendStatus.Caption", DescriptionResourceItem = "Parameters.SendStatus.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "SendStatusDetails", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "eb39d4a655db40eea8e7705b5ad7b9c0", CaptionResourceItem = "Parameters.SendStatusDetails.Caption", DescriptionResourceItem = "Parameters.SendStatusDetails.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "RecordColumnValues", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "eb39d4a655db40eea8e7705b5ad7b9c0", CaptionResourceItem = "Parameters.RecordColumnValues.Caption", DescriptionResourceItem = "Parameters.RecordColumnValues.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public partial class SendChatMessageUserTask : ProcessUserTask
	{

		#region Constructors: Public

		public SendChatMessageUserTask(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("eb39d4a6-55db-40ee-a8e7-705b5ad7b9c0");
		}

		#endregion

		#region Properties: Public

		public virtual Guid Channel {
			get;
			set;
		}

		public virtual Guid Contact {
			get;
			set;
		}

		public virtual string Message {
			get;
			set;
		}

		public virtual int MessageType {
			get;
			set;
		}

		public virtual Guid Template {
			get;
			set;
		}

		public virtual bool IgnoreErrors {
			get;
			set;
		}

		public virtual string SendStatus {
			get;
			set;
		}

		public virtual string SendStatusDetails {
			get;
			set;
		}

		private EntityColumnMappingValues _recordColumnValues;
		public virtual EntityColumnMappingValues RecordColumnValues {
			get {
				return _recordColumnValues ?? ( _recordColumnValues = new EntityColumnMappingValues (
					new Dictionary<string, object>(),
					new Dictionary<string, string>()));
			}
			set {
				_recordColumnValues = value;
			}
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
			if (!HasMapping("Channel")) {
				writer.WriteValue("Channel", Channel, Guid.Empty);
			}
			if (!HasMapping("Contact")) {
				writer.WriteValue("Contact", Contact, Guid.Empty);
			}
			if (!HasMapping("Message")) {
				writer.WriteValue("Message", Message, null);
			}
			if (!HasMapping("MessageType")) {
				writer.WriteValue("MessageType", MessageType, 0);
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("Template")) {
					writer.WriteValue("Template", Template, Guid.Empty);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("IgnoreErrors")) {
					writer.WriteValue("IgnoreErrors", IgnoreErrors, false);
				}
			}
			if (!HasMapping("SendStatus")) {
				writer.WriteValue("SendStatus", SendStatus, null);
			}
			if (!HasMapping("SendStatusDetails")) {
				writer.WriteValue("SendStatusDetails", SendStatusDetails, null);
			}
			writer.WriteFinishObject();
		}

		#endregion

		#region Methods: Protected

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			switch (reader.CurrentName) {
				case "Channel":
					Channel = reader.GetGuidValue();
				break;
				case "Contact":
					Contact = reader.GetGuidValue();
				break;
				case "Message":
					Message = reader.GetStringValue();
				break;
				case "MessageType":
					MessageType = reader.GetIntValue();
				break;
				case "Template":
					if (!UseFlowEngineMode) {
						break;
					}
					Template = reader.GetGuidValue();
				break;
				case "IgnoreErrors":
					if (!UseFlowEngineMode) {
						break;
					}
					IgnoreErrors = reader.GetBoolValue();
				break;
				case "SendStatus":
					SendStatus = reader.GetStringValue();
				break;
				case "SendStatusDetails":
					SendStatusDetails = reader.GetStringValue();
				break;
				case "RecordColumnValues":
					if (UseFlowEngineMode) {
						RecordColumnValues = reader.GetValue<EntityColumnMappingValues>();
					}
				break;
			}
		}

		#endregion

	}

	#endregion

}

