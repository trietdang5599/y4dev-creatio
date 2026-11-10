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

	#region Class: SetDetailFilter

	[DesignModeProperty(Name = "DetailPageContainer", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "f2200aba2944475db8dce9bc7f9e2d84", CaptionResourceItem = "Parameters.DetailPageContainer.Caption", DescriptionResourceItem = "Parameters.DetailPageContainer.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "PageDataSource", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "f2200aba2944475db8dce9bc7f9e2d84", CaptionResourceItem = "Parameters.PageDataSource.Caption", DescriptionResourceItem = "Parameters.PageDataSource.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "DetailPageFilterName", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "f2200aba2944475db8dce9bc7f9e2d84", CaptionResourceItem = "Parameters.DetailPageFilterName.Caption", DescriptionResourceItem = "Parameters.DetailPageFilterName.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ThrowEventName", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "f2200aba2944475db8dce9bc7f9e2d84", CaptionResourceItem = "Parameters.ThrowEventName.Caption", DescriptionResourceItem = "Parameters.ThrowEventName.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "FilterLeftExpressions", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "f2200aba2944475db8dce9bc7f9e2d84", CaptionResourceItem = "Parameters.FilterLeftExpressions.Caption", DescriptionResourceItem = "Parameters.FilterLeftExpressions.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "FilterRightValue", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "f2200aba2944475db8dce9bc7f9e2d84", CaptionResourceItem = "Parameters.FilterRightValue.Caption", DescriptionResourceItem = "Parameters.FilterRightValue.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "FilterName", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "f2200aba2944475db8dce9bc7f9e2d84", CaptionResourceItem = "Parameters.FilterName.Caption", DescriptionResourceItem = "Parameters.FilterName.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ParentColumnMetaPath", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "f2200aba2944475db8dce9bc7f9e2d84", CaptionResourceItem = "Parameters.ParentColumnMetaPath.Caption", DescriptionResourceItem = "Parameters.ParentColumnMetaPath.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "SysEntitySchemaId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "f2200aba2944475db8dce9bc7f9e2d84", CaptionResourceItem = "Parameters.SysEntitySchemaId.Caption", DescriptionResourceItem = "Parameters.SysEntitySchemaId.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public class SetDetailFilter : ProcessUserTask
	{

		#region Constructors: Public

		public SetDetailFilter(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("f2200aba-2944-475d-b8dc-e9bc7f9e2d84");
		}

		#endregion

		#region Properties: Public

		public virtual Object DetailPageContainer {
			get;
			set;
		}

		public virtual Object PageDataSource {
			get;
			set;
		}

		public virtual string DetailPageFilterName {
			get;
			set;
		}

		public virtual string ThrowEventName {
			get;
			set;
		}

		public virtual Object FilterLeftExpressions {
			get;
			set;
		}

		public virtual Object FilterRightValue {
			get;
			set;
		}

		public virtual string FilterName {
			get;
			set;
		}

		public virtual string ParentColumnMetaPath {
			get;
			set;
		}

		public virtual Guid SysEntitySchemaId {
			get;
			set;
		}

		#endregion

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
			var detailPageContainer = DetailPageContainer as Terrasoft.UI.WebControls.Controls.PageContainer;
			if (detailPageContainer == null) {
				return true;
			}
			if (string.IsNullOrEmpty(ThrowEventName)) {
				ThrowEventName = "GridPageRefreshRow";
			}
			if (FilterLeftExpressions != null) {
				var userConnection = context.UserConnection;
				var detailDataSource = (detailPageContainer.FindPageControlByName("DataSource")) as Terrasoft.UI.WebControls.Controls.DataSource;
				if (detailDataSource != null) {
					//Код, который компилируется только в Workspace CR173347
					Terrasoft.UI.WebControls.Controls.DataSourceFilterCollection filter = CreateFilter(detailDataSource, userConnection.Workspace.Id, userConnection);
					SetFilter(detailPageContainer.PageInstance, filter);
				}
			}
			detailPageContainer.PageInstance.ThrowEvent(ThrowEventName);
			DetailPageContainer = null;
			PageDataSource = null;
			return true;
		}

		#endregion

		#region Methods: Public

		public virtual Terrasoft.UI.WebControls.Controls.DataSourceFilterCollection CreateFilter(Terrasoft.UI.WebControls.Controls.DataSource detailDataSource, Guid solutionId, UserConnection userConnection) {
			var detailSchema = detailDataSource.Schema;
			Terrasoft.UI.WebControls.Utilities.EntityDataSourceUtilities.InitializeAutoDefStructure(detailDataSource as Terrasoft.UI.WebControls.Controls.EntityDataSource);
			Terrasoft.UI.WebControls.Controls.DataSourceStructure structure = detailDataSource.CurrentStructure;
			var filterLeftExpressions = FilterLeftExpressions as Array;
			if (filterLeftExpressions == null || filterLeftExpressions.Length == 0) {
				return null;
			}
			Terrasoft.UI.WebControls.Controls.DataSourceFilterCollection filters = structure.CreateFiltersGroup(FilterName, LogicalOperationStrict.Or);
			foreach(string expression in filterLeftExpressions) {
				if (expression == null) {
					continue;
				}
				var objectParams = GetFilterRightValue(userConnection) as object[];
				if (objectParams != null) {
					filters.Add(
					structure.CreateFilterWithParameters(detailSchema, Terrasoft.Core.Entities.FilterComparisonType.Equal,
						expression, objectParams));
				} else {
					filters.Add(
						structure.CreateFilterWithParameters(detailSchema, Terrasoft.Core.Entities.FilterComparisonType.Equal,
							expression, GetFilterRightValue(userConnection)));
				}
			}
			return filters;
		}

		public virtual void SetFilter(Terrasoft.UI.WebControls.PageSchemaUserControl pageInstance, Terrasoft.UI.WebControls.Controls.DataSourceFilterCollection filter) {
			pageInstance.Process.SetPropertyValue(DetailPageFilterName, filter);
		}

		public virtual object GetFilterRightValue(UserConnection userConnection) {
			if (SysEntitySchemaId != Guid.Empty && !string.IsNullOrEmpty(ParentColumnMetaPath)) {
				var entitySchemaManager = userConnection.EntitySchemaManager;
				var entitySchema = entitySchemaManager.GetInstanceByUId(SysEntitySchemaId);
				var parentColumn = entitySchema.FindSchemaColumnByPath(ParentColumnMetaPath);
				if (parentColumn == null) {
					try {
						parentColumn = entitySchema.GetSchemaColumnByMetaPath(ParentColumnMetaPath);
					} catch {}
				}
				if (parentColumn != null && parentColumn.Name != entitySchema.GetPrimaryColumnName()) {
					var entitySchemaQuery = new EntitySchemaQuery(entitySchemaManager, entitySchema.Name);
					var rightValueColumnName = entitySchemaQuery.AddColumn(parentColumn.Name).Name;
					entitySchemaQuery.Filters.Add(entitySchemaQuery.CreateFilterWithParameters(FilterComparisonType.Equal, 
						entitySchemaQuery.RootSchema.GetPrimaryColumnName(), FilterRightValue));
					var collection = entitySchemaQuery.GetEntityCollection(UserConnection);
					if (collection.Count == 1) {
						var columnValueName = entitySchemaQuery.GetSchema().Columns.GetByName(rightValueColumnName).ColumnValueName;
						return collection[0].GetColumnValue(columnValueName) ?? Guid.Empty;
					}
				}
			}
			return FilterRightValue;
		}

		public override void WritePropertiesData(DataWriter writer) {
			writer.WriteStartObject(Name);
			base.WritePropertiesData(writer);
			if (Status == Core.Process.ProcessStatus.Inactive) {
				writer.WriteFinishObject();
				return;
			}
			if (UseFlowEngineMode) {
				if (DetailPageContainer != null) {
					if (DetailPageContainer.GetType().IsSerializable || DetailPageContainer.GetType().GetInterface("ISerializable") != null) {
						WriteSerializableObject(writer, "DetailPageContainer", DetailPageContainer, null);
					}
				}
			}
			if (UseFlowEngineMode) {
				if (PageDataSource != null) {
					if (PageDataSource.GetType().IsSerializable || PageDataSource.GetType().GetInterface("ISerializable") != null) {
						WriteSerializableObject(writer, "PageDataSource", PageDataSource, null);
					}
				}
			}
			if (!HasMapping("DetailPageFilterName")) {
				writer.WriteValue("DetailPageFilterName", DetailPageFilterName, null);
			}
			if (!HasMapping("ThrowEventName")) {
				writer.WriteValue("ThrowEventName", ThrowEventName, null);
			}
			if (FilterLeftExpressions != null) {
				if (FilterLeftExpressions.GetType().IsSerializable || FilterLeftExpressions.GetType().GetInterface("ISerializable") != null) {
					WriteSerializableObject(writer, "FilterLeftExpressions", FilterLeftExpressions, null);
				}
			}
			if (FilterRightValue != null) {
				if (FilterRightValue.GetType().IsSerializable || FilterRightValue.GetType().GetInterface("ISerializable") != null) {
					WriteSerializableObject(writer, "FilterRightValue", FilterRightValue, null);
				}
			}
			if (!HasMapping("FilterName")) {
				writer.WriteValue("FilterName", FilterName, null);
			}
			if (!HasMapping("ParentColumnMetaPath")) {
				writer.WriteValue("ParentColumnMetaPath", ParentColumnMetaPath, null);
			}
			if (!HasMapping("SysEntitySchemaId")) {
				writer.WriteValue("SysEntitySchemaId", SysEntitySchemaId, Guid.Empty);
			}
			writer.WriteFinishObject();
		}

		#endregion

		#region Methods: Protected

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			switch (reader.CurrentName) {
				case "DetailPageContainer":
					if (!UseFlowEngineMode) {
						break;
					}
					DetailPageContainer = GetSerializableObject(reader);
				break;
				case "PageDataSource":
					if (!UseFlowEngineMode) {
						break;
					}
					PageDataSource = GetSerializableObject(reader);
				break;
				case "DetailPageFilterName":
					DetailPageFilterName = reader.GetStringValue();
				break;
				case "ThrowEventName":
					ThrowEventName = reader.GetStringValue();
				break;
				case "FilterLeftExpressions":
					FilterLeftExpressions = GetSerializableObject(reader);
				break;
				case "FilterRightValue":
					FilterRightValue = GetSerializableObject(reader);
				break;
				case "FilterName":
					FilterName = reader.GetStringValue();
				break;
				case "ParentColumnMetaPath":
					ParentColumnMetaPath = reader.GetStringValue();
				break;
				case "SysEntitySchemaId":
					SysEntitySchemaId = reader.GetGuidValue();
				break;
			}
		}

		#endregion

	}

	#endregion

}

