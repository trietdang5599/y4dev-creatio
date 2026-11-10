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
	using Terrasoft.Messaging.Common;
	using Terrasoft.UI.WebControls.Controls;

	#region Class: PostUserMessageUserTask

	[DesignModeProperty(Name = "SendForAll", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4b1606b826b2466b91351167317fea23", CaptionResourceItem = "Parameters.SendForAll.Caption", DescriptionResourceItem = "Parameters.SendForAll.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "TargetUserIdsKey", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4b1606b826b2466b91351167317fea23", CaptionResourceItem = "Parameters.TargetUserIdsKey.Caption", DescriptionResourceItem = "Parameters.TargetUserIdsKey.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "SenderName", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4b1606b826b2466b91351167317fea23", CaptionResourceItem = "Parameters.SenderName.Caption", DescriptionResourceItem = "Parameters.SenderName.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "MessageText", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4b1606b826b2466b91351167317fea23", CaptionResourceItem = "Parameters.MessageText.Caption", DescriptionResourceItem = "Parameters.MessageText.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "TargetUserId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4b1606b826b2466b91351167317fea23", CaptionResourceItem = "Parameters.TargetUserId.Caption", DescriptionResourceItem = "Parameters.TargetUserId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ReceiversIds", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4b1606b826b2466b91351167317fea23", CaptionResourceItem = "Parameters.ReceiversIds.Caption", DescriptionResourceItem = "Parameters.ReceiversIds.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "IgnoreNotFoundChannels", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4b1606b826b2466b91351167317fea23", CaptionResourceItem = "Parameters.IgnoreNotFoundChannels.Caption", DescriptionResourceItem = "Parameters.IgnoreNotFoundChannels.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public partial class PostUserMessageUserTask : ProcessUserTask
	{

		#region Constructors: Public

		public PostUserMessageUserTask(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("4b1606b8-26b2-466b-9135-1167317fea23");
		}

		#endregion

		#region Properties: Public

		public virtual bool SendForAll {
			get;
			set;
		}

		public virtual string TargetUserIdsKey {
			get;
			set;
		}

		public virtual string SenderName {
			get;
			set;
		}

		public virtual string MessageText {
			get;
			set;
		}

		public virtual Guid TargetUserId {
			get;
			set;
		}

		public virtual ICompositeObjectList<ICompositeObject> ReceiversIds {
			get;
			set;
		}

		public virtual bool IgnoreNotFoundChannels {
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
			if (!HasMapping("SendForAll")) {
				writer.WriteValue("SendForAll", SendForAll, false);
			}
			if (!HasMapping("TargetUserIdsKey")) {
				writer.WriteValue("TargetUserIdsKey", TargetUserIdsKey, null);
			}
			if (!HasMapping("SenderName")) {
				writer.WriteValue("SenderName", SenderName, null);
			}
			if (!HasMapping("MessageText")) {
				writer.WriteValue("MessageText", MessageText, null);
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("TargetUserId")) {
					writer.WriteValue("TargetUserId", TargetUserId, Guid.Empty);
				}
			}
			if (UseFlowEngineMode) {
				WriteSerializableObject<ICompositeObjectList<ICompositeObject>>(writer, "ReceiversIds", ReceiversIds);
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("IgnoreNotFoundChannels")) {
					writer.WriteValue("IgnoreNotFoundChannels", IgnoreNotFoundChannels, false);
				}
			}
			writer.WriteFinishObject();
		}

		#endregion

		#region Methods: Protected

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			switch (reader.CurrentName) {
				case "SendForAll":
					SendForAll = reader.GetBoolValue();
				break;
				case "TargetUserIdsKey":
					TargetUserIdsKey = reader.GetStringValue();
				break;
				case "SenderName":
					SenderName = reader.GetStringValue();
				break;
				case "MessageText":
					MessageText = reader.GetStringValue();
				break;
				case "TargetUserId":
					if (!UseFlowEngineMode) {
						break;
					}
					TargetUserId = reader.GetGuidValue();
				break;
				case "ReceiversIds":
					if (!UseFlowEngineMode) {
						break;
					}
					ReceiversIds = ReadSerializableObject<ICompositeObjectList<ICompositeObject>>(reader);
				break;
				case "IgnoreNotFoundChannels":
					if (!UseFlowEngineMode) {
						break;
					}
					IgnoreNotFoundChannels = reader.GetBoolValue();
				break;
			}
		}

		#endregion

	}

	#endregion

}

