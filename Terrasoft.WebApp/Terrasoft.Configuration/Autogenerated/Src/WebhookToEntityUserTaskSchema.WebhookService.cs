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

	#region Class: WebhookToEntityUserTask

	[DesignModeProperty(Name = "Webhooks", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "28a6d4c6a2f4419baa81718d706756db", CaptionResourceItem = "Parameters.Webhooks.Caption", DescriptionResourceItem = "Parameters.Webhooks.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "EntityIdentifiers", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "28a6d4c6a2f4419baa81718d706756db", CaptionResourceItem = "Parameters.EntityIdentifiers.Caption", DescriptionResourceItem = "Parameters.EntityIdentifiers.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public partial class WebhookToEntityUserTask : ProcessUserTask
	{

		#region Constructors: Public

		public WebhookToEntityUserTask(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("28a6d4c6-a2f4-419b-aa81-718d706756db");
		}

		#endregion

		#region Properties: Public

		public virtual ICompositeObjectList<ICompositeObject> Webhooks {
			get;
			set;
		}

		public virtual ICompositeObjectList<ICompositeObject> EntityIdentifiers {
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
				WriteSerializableObject<ICompositeObjectList<ICompositeObject>>(writer, "Webhooks", Webhooks);
			}
			if (UseFlowEngineMode) {
				WriteSerializableObject<ICompositeObjectList<ICompositeObject>>(writer, "EntityIdentifiers", EntityIdentifiers);
			}
			writer.WriteFinishObject();
		}

		#endregion

		#region Methods: Protected

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			switch (reader.CurrentName) {
				case "Webhooks":
					if (!UseFlowEngineMode) {
						break;
					}
					Webhooks = ReadSerializableObject<ICompositeObjectList<ICompositeObject>>(reader);
				break;
				case "EntityIdentifiers":
					if (!UseFlowEngineMode) {
						break;
					}
					EntityIdentifiers = ReadSerializableObject<ICompositeObjectList<ICompositeObject>>(reader);
				break;
			}
		}

		#endregion

	}

	#endregion

}

