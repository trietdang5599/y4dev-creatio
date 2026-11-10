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

	#region Class: FolderConverterUserTask

	[DesignModeProperty(Name = "EntitySchemaName", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "1299ba09f85c4c9dbeeb219afb4ad8e4", CaptionResourceItem = "Parameters.EntitySchemaName.Caption", DescriptionResourceItem = "Parameters.EntitySchemaName.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "NewFolderId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "1299ba09f85c4c9dbeeb219afb4ad8e4", CaptionResourceItem = "Parameters.NewFolderId.Caption", DescriptionResourceItem = "Parameters.NewFolderId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ParentFolderId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "1299ba09f85c4c9dbeeb219afb4ad8e4", CaptionResourceItem = "Parameters.ParentFolderId.Caption", DescriptionResourceItem = "Parameters.ParentFolderId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ProcessedEntriesAmount", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "1299ba09f85c4c9dbeeb219afb4ad8e4", CaptionResourceItem = "Parameters.ProcessedEntriesAmount.Caption", DescriptionResourceItem = "Parameters.ProcessedEntriesAmount.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "NotificationMessage", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "1299ba09f85c4c9dbeeb219afb4ad8e4", CaptionResourceItem = "Parameters.NotificationMessage.Caption", DescriptionResourceItem = "Parameters.NotificationMessage.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public partial class FolderConverterUserTask : ProcessUserTask
	{

		#region Constructors: Public

		public FolderConverterUserTask(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("1299ba09-f85c-4c9d-beeb-219afb4ad8e4");
		}

		#endregion

		#region Properties: Public

		public virtual string EntitySchemaName {
			get;
			set;
		}

		public virtual Guid NewFolderId {
			get;
			set;
		}

		public virtual Guid ParentFolderId {
			get;
			set;
		}

		public virtual int ProcessedEntriesAmount {
			get;
			set;
		}

		public virtual string NotificationMessage {
			get;
			set;
		}

		private LocalizableString _notificationMessageLocalized;
		public LocalizableString NotificationMessageLocalized {
			get {
				return _notificationMessageLocalized ?? (_notificationMessageLocalized = new LocalizableString(Storage, Schema.GetResourceManagerName(), "LocalizableStrings.NotificationMessageLocalized.Value"));
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
			if (UseFlowEngineMode) {
				if (!HasMapping("EntitySchemaName")) {
					writer.WriteValue("EntitySchemaName", EntitySchemaName, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("NewFolderId")) {
					writer.WriteValue("NewFolderId", NewFolderId, Guid.Empty);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("ParentFolderId")) {
					writer.WriteValue("ParentFolderId", ParentFolderId, Guid.Empty);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("ProcessedEntriesAmount")) {
					writer.WriteValue("ProcessedEntriesAmount", ProcessedEntriesAmount, 0);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("NotificationMessage")) {
					writer.WriteValue("NotificationMessage", NotificationMessage, null);
				}
			}
			writer.WriteFinishObject();
		}

		#endregion

		#region Methods: Protected

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			switch (reader.CurrentName) {
				case "EntitySchemaName":
					if (!UseFlowEngineMode) {
						break;
					}
					EntitySchemaName = reader.GetStringValue();
				break;
				case "NewFolderId":
					if (!UseFlowEngineMode) {
						break;
					}
					NewFolderId = reader.GetGuidValue();
				break;
				case "ParentFolderId":
					if (!UseFlowEngineMode) {
						break;
					}
					ParentFolderId = reader.GetGuidValue();
				break;
				case "ProcessedEntriesAmount":
					if (!UseFlowEngineMode) {
						break;
					}
					ProcessedEntriesAmount = reader.GetIntValue();
				break;
				case "NotificationMessage":
					if (!UseFlowEngineMode) {
						break;
					}
					NotificationMessage = reader.GetStringValue();
				break;
			}
		}

		#endregion

	}

	#endregion

}

