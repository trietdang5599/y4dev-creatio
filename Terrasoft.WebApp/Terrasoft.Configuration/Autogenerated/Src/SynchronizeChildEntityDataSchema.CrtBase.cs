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

	#region Class: SynchronizeChildEntityData

	[DesignModeProperty(Name = "ChildEntitySchemaUId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "15b17a1609c543509636904aade4b5aa", CaptionResourceItem = "Parameters.ChildEntitySchemaUId.Caption", DescriptionResourceItem = "Parameters.ChildEntitySchemaUId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "SingleRowSearchFilters", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "15b17a1609c543509636904aade4b5aa", CaptionResourceItem = "Parameters.SingleRowSearchFilters.Caption", DescriptionResourceItem = "Parameters.SingleRowSearchFilters.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "MultiRowsSearchFilters", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "15b17a1609c543509636904aade4b5aa", CaptionResourceItem = "Parameters.MultiRowsSearchFilters.Caption", DescriptionResourceItem = "Parameters.MultiRowsSearchFilters.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "MappingColumns", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "15b17a1609c543509636904aade4b5aa", CaptionResourceItem = "Parameters.MappingColumns.Caption", DescriptionResourceItem = "Parameters.MappingColumns.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "DefaultValues", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "15b17a1609c543509636904aade4b5aa", CaptionResourceItem = "Parameters.DefaultValues.Caption", DescriptionResourceItem = "Parameters.DefaultValues.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "RequiredAllFields", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "15b17a1609c543509636904aade4b5aa", CaptionResourceItem = "Parameters.RequiredAllFields.Caption", DescriptionResourceItem = "Parameters.RequiredAllFields.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "RequiredFields", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "15b17a1609c543509636904aade4b5aa", CaptionResourceItem = "Parameters.RequiredFields.Caption", DescriptionResourceItem = "Parameters.RequiredFields.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "DeletingFilters", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "15b17a1609c543509636904aade4b5aa", CaptionResourceItem = "Parameters.DeletingFilters.Caption", DescriptionResourceItem = "Parameters.DeletingFilters.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public class SynchronizeChildEntityData : ProcessUserTask
	{

		#region Constructors: Public

		public SynchronizeChildEntityData(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("15b17a16-09c5-4350-9636-904aade4b5aa");
		}

		#endregion

		#region Properties: Public

		public virtual Guid ChildEntitySchemaUId {
			get;
			set;
		}

		public virtual Object SingleRowSearchFilters {
			get;
			set;
		}

		public virtual Object MultiRowsSearchFilters {
			get;
			set;
		}

		public virtual Object MappingColumns {
			get;
			set;
		}

		public virtual Object DefaultValues {
			get;
			set;
		}

		public virtual bool RequiredAllFields {
			get;
			set;
		}

		public virtual Object RequiredFields {
			get;
			set;
		}

		public virtual Object DeletingFilters {
			get;
			set;
		}

		#endregion

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
			if (ChildEntitySchemaUId != Guid.Empty) {
				var mappingCoulmns = MappingColumns as System.Collections.Generic.Dictionary<
				Guid, System.Collections.Generic.Dictionary<
				Guid, object>>;
				var deletingFilters = DeletingFilters as System.Collections.Generic.Dictionary<
				Guid, System.Collections.Generic.Dictionary<
				Guid, object>>;
				var defaultValues = DefaultValues as System.Collections.Generic.Dictionary<
				Guid, object>;
				var singleRowSearchFilters = SingleRowSearchFilters as System.Collections.Generic.Dictionary<
				Guid, object>;
				Terrasoft.Core.Entities.EntitySchema entitySchema = GetDependentEntity(ChildEntitySchemaUId, context.UserConnection);
				if (singleRowSearchFilters.Count != 0) {
					SynchronizeSingleRow(entitySchema, context);
				} else {
					SynchronizeMultiRows(entitySchema, context);
				}
				if (deletingFilters != null){
					if (deletingFilters.Count > 0){
						DeleteRows(deletingFilters, entitySchema, context);
					}
				}
			}
			return true;
		}

		#endregion

		#region Methods: Public

		public virtual Terrasoft.Core.Entities.EntitySchema GetDependentEntity(Guid dependentEntitySchemaUId, UserConnection userConnection) {
			return userConnection.EntitySchemaManager.GetInstanceByUId(dependentEntitySchemaUId);
		}

		public virtual Terrasoft.Core.DB.Select CreateSelect(Terrasoft.Core.Entities.EntitySchema entitySchema, object searchFilters, UserConnection userConnection) {
			var filters = searchFilters as System.Collections.Generic.Dictionary<
			Guid, object>;
			
			Terrasoft.Core.DB.Select select =
				new Terrasoft.Core.DB.Select(userConnection).
					Column(Terrasoft.Core.DB.Func.Count(Terrasoft.Core.DB.Column.Asterisk())).
				From(entitySchema.Name);
			if (filters == null) {
				return select;
			}
			string columnName = "";
			Terrasoft.Core.Entities.EntitySchemaColumn column = null;
			if (filters.Count != 0) {
				bool isFirst = true;
				foreach (Guid key in filters.Keys) {
					column = entitySchema.Columns.GetByUId(key);
					columnName = entitySchema.Columns.GetByUId(key).ColumnValueName;
					if (isFirst) {
						if (filters[key] != null) {
							select.Where(columnName).IsEqual(Terrasoft.Core.DB.Column.Parameter(filters[key], column.DataValueType));
						} else {
							select.Where(columnName).IsNull();
						}
						isFirst = false;
						continue;
					}
					if (filters[key] != null) {
						select.And(columnName).IsEqual(Terrasoft.Core.DB.Column.Parameter(filters[key], column.DataValueType));
					} else {
						select.And(columnName).IsNull();
					}
				}
			}
			return select;
		}

		public virtual Terrasoft.Core.DB.Insert CreateInsertQuery(Terrasoft.Core.Entities.EntitySchema entitySchema, object values, UserConnection userConnection) {
			var parameters = values as System.Collections.Generic.Dictionary<
			Guid, object>;
			
			Terrasoft.Core.DB.Insert insert = new Terrasoft.Core.DB.Insert(userConnection).Into(entitySchema.Name);
			
			string columnName = "";
			Terrasoft.Core.Entities.EntitySchemaColumn column = null;
			foreach (Guid key in parameters.Keys) {
				column = entitySchema.Columns.GetByUId(key);
				columnName = column.ColumnValueName;
				insert = insert.Set(columnName, Terrasoft.Core.DB.Column.Parameter(parameters[key], column.DataValueType));
			}
			
			insert = insert.Set("CreatedById", Terrasoft.Core.DB.Column.Parameter(
				UserConnection.CurrentUser.ContactId, 
			        entitySchema.Columns.GetByName("CreatedBy").DataValueType));
			insert = insert.Set("CreatedOn", Terrasoft.Core.DB.Column.Parameter(
				UserConnection.CurrentUser.GetCurrentDateTime(), 
			        entitySchema.Columns.GetByName("CreatedOn").DataValueType));
			insert = insert.Set("ModifiedById", Terrasoft.Core.DB.Column.Parameter(
				UserConnection.CurrentUser.ContactId, 
			        entitySchema.Columns.GetByName("ModifiedBy").DataValueType));
			insert = insert.Set("ModifiedOn", Terrasoft.Core.DB.Column.Parameter(
				UserConnection.CurrentUser.GetCurrentDateTime(), 
			       entitySchema.Columns.GetByName("ModifiedOn").DataValueType));
			return insert;
		}

		public virtual object CreateParameters(ProcessExecutingContext context) {
			var mappingCoulmns = MappingColumns as System.Collections.Generic.Dictionary<
			Guid, System.Collections.Generic.Dictionary<
			Guid, object>>;
			var defaultValues = DefaultValues as System.Collections.Generic.Dictionary<
			Guid, object>;
			System.Collections.Generic.Dictionary<
			Guid, object> parameters = new System.Collections.Generic.Dictionary<
			Guid, object>();
			
			var entity = context.Process.GetPropertyValue("Entity") as Terrasoft.Core.Entities.Entity;
			Terrasoft.Core.Entities.EntitySchemaColumn column = null;
			foreach (Guid key in mappingCoulmns.Keys) {
				var destinationDictionary = mappingCoulmns[key] as System.Collections.Generic.Dictionary<
			Guid, object>;
				foreach (Guid destKey in destinationDictionary.Keys) {
					if (destinationDictionary[destKey] is Guid && (Guid)destinationDictionary[destKey] == key) {
						column = entity.Schema.Columns.GetByUId(key);
						parameters.Add(destKey, entity.GetColumnValue(column));
						continue;
					}
					parameters.Add(destKey, destinationDictionary[destKey]);
				}
			}
			foreach (Guid key in defaultValues.Keys) {
				if (parameters.ContainsKey(key)) {
					continue;
				}
				parameters.Add(key, defaultValues[key]);
			}
			return parameters;
		}

		public virtual Terrasoft.Core.DB.Update CreateUpdateQuery(Terrasoft.Core.Entities.EntitySchema entitySchema, object searchFilters, object values, UserConnection userConnection) {
			var parameters = values as System.Collections.Generic.Dictionary<
			Guid, object>;
			var filters = searchFilters as System.Collections.Generic.Dictionary<
			Guid, object>;
			
			Terrasoft.Core.DB.Update update = new Terrasoft.Core.DB.Update(userConnection, entitySchema.Name);
			
			string columnName = "";
			Terrasoft.Core.Entities.EntitySchemaColumn column = null;
			foreach (Guid key in parameters.Keys) {
				column = entitySchema.Columns.GetByUId(key);
				columnName = column.ColumnValueName;
				update.Set(columnName, Terrasoft.Core.DB.Column.Parameter(parameters[key], column.DataValueType));
			}
			
			update.Set("ModifiedById", Terrasoft.Core.DB.Column.Parameter(
				UserConnection.CurrentUser.ContactId, 
			        entitySchema.Columns.GetByName("ModifiedBy").DataValueType));
			update.Set("ModifiedOn", Terrasoft.Core.DB.Column.Parameter(
				UserConnection.CurrentUser.GetCurrentDateTime(), 
			       entitySchema.Columns.GetByName("ModifiedOn").DataValueType));
			
			
			if (filters.Count != 0) {
				bool isFirst = true;
				foreach (Guid key in filters.Keys) {
					if (isFirst) {
						column = entitySchema.Columns.GetByUId(key);
						columnName = column.ColumnValueName;
						if (filters[key] != null) {
							update.Where(columnName).IsEqual(Terrasoft.Core.DB.Column.Parameter(filters[key], column.DataValueType));
						} else {
							update.Where(columnName).IsNull();
						}
						isFirst = false;
						continue;
					}
					column = entitySchema.Columns.GetByUId(key);
					columnName = column.ColumnValueName;
					if (filters[key] != null) {
						update.And(columnName).IsEqual(Terrasoft.Core.DB.Column.Parameter(filters[key], column.DataValueType));
					} else {
						update.And(columnName).IsNull();
					}
				}
			}
			return update;
		}

		public virtual void SynchronizeSingleRow(Terrasoft.Core.Entities.EntitySchema entitySchema, ProcessExecutingContext context) {
			var parameters = CreateParameters(context);
			SynchronizeObject(entitySchema, SingleRowSearchFilters, parameters, context);
		}

		public virtual void SynchronizeMultiRows(Terrasoft.Core.Entities.EntitySchema entitySchema, ProcessExecutingContext context) {
			var mappingCoulmns = MappingColumns as System.Collections.Generic.Dictionary<
			Guid, System.Collections.Generic.Dictionary<
			Guid, object>>;
			
			var multiRowsSearchFilters = MultiRowsSearchFilters as System.Collections.Generic.Dictionary<
			Guid, System.Collections.Generic.Dictionary<
			Guid, object>>;
			
			var defaultValues = DefaultValues as System.Collections.Generic.Dictionary<
			Guid, object>;
			
			var entity = context.Process.GetPropertyValue("Entity") as Terrasoft.Core.Entities.Entity;
			Terrasoft.Core.Entities.EntitySchemaColumn column = null;
			
			foreach (Guid key in mappingCoulmns.Keys) {
				var parameters = new System.Collections.Generic.Dictionary<
			Guid, object>();
				var destinationDictionary = mappingCoulmns[key] as System.Collections.Generic.Dictionary<
			Guid, object>;
				foreach (Guid destKey in destinationDictionary.Keys) {
					if (destinationDictionary[destKey] is Guid && (Guid)destinationDictionary[destKey] == key) {
						if (entity.Schema.Columns.FindByUId(key) != null){
							column = entity.Schema.Columns.GetByUId(key);
							parameters.Add(destKey, entity.GetColumnValue(column));
						}
						else{
							parameters.Add(destKey, null);
						}	
						continue;
					}
					parameters.Add(destKey, destinationDictionary[destKey]);
				}
				foreach (Guid defKey in defaultValues.Keys) {
					if (parameters.ContainsKey(defKey)) {
						continue;
					}
					parameters.Add(defKey, defaultValues[defKey]);
				}
			
				SynchronizeObject(entitySchema, multiRowsSearchFilters[key], parameters, context);
			}
		}

		public virtual void SynchronizeObject(Terrasoft.Core.Entities.EntitySchema entitySchema, object searchFilters, object parameters, ProcessExecutingContext context) {
			var filters = searchFilters as System.Collections.Generic.Dictionary<
			Guid, object>;
			var columnValues = parameters as System.Collections.Generic.Dictionary<
			Guid, object>;
			
			Terrasoft.Core.DB.Select select = CreateSelect(entitySchema, filters, context.UserConnection);
			int rowsCount = 0;
			using (var dbExecutor = context.UserConnection.EnsureDBConnection()) {
				using(var reader = select.ExecuteReader(dbExecutor)){
					if (!reader.Read()) {
						return;
					}
					rowsCount = UserConnection.DBTypeConverter.DBValueToInt(reader[0]);
				}
			}
			var dataExist = AllowRow(parameters,RequiredFields,RequiredAllFields,entitySchema);
			if (rowsCount == 0) {
				if(dataExist){
					Terrasoft.Core.DB.Insert insert = CreateInsertQuery(entitySchema, columnValues, context.UserConnection);
					insert.Execute();
				}
			} else {
				if (dataExist){
					Terrasoft.Core.DB.Update update = CreateUpdateQuery(entitySchema, filters, columnValues, context.UserConnection);
					update.Execute();
				}
				else{
					Terrasoft.Core.DB.Delete delete = CreateDeleteQuery(entitySchema, filters,context.UserConnection);
					delete.Execute();
				}
			}
		}

		public virtual bool CheckValue(object checkValue) {
			if (checkValue == null){
				return false;
			}
			if (String.IsNullOrEmpty(checkValue.ToString())){
				return false;
			}
			return true;
		}

		public virtual bool AllowRow(object parameters, object requiredColumns, bool requiredAllColumns, Terrasoft.Core.Entities.EntitySchema entitySchema) {
			if (requiredColumns == null){
				return true;
			}
			var allFields = requiredAllColumns;
			var dataExist = true;
			var dataPresent = false;
			var columnValues = parameters as System.Collections.Generic.Dictionary<Guid, object>;
			var verifiedColumns = requiredColumns as string[];
			var verifiedColumnsUId = new List<Guid>();
			foreach (var columnName in verifiedColumns){
					foreach(var schemaColumn in entitySchema.Columns){
						if (schemaColumn.Name == columnName){
							verifiedColumnsUId.Add(schemaColumn.UId);
							break;
						}
					}
			}
			foreach (var columnUId in verifiedColumnsUId){
				if (columnValues.ContainsKey(columnUId)){
					if (!CheckValue(columnValues[columnUId])){
						if (allFields){
							dataExist = false;
							break;
						}	
					}
					else{
						dataPresent =true;
					}
				}
				else{
					if (allFields){
						dataExist = false;
						break;
					}
				}
			}
			return (dataPresent && !allFields) || (allFields && dataExist);
		}

		public virtual Terrasoft.Core.DB.Delete CreateDeleteQuery(Terrasoft.Core.Entities.EntitySchema entitySchema, object searchFilters, UserConnection userConnection) {
			var filters = searchFilters as System.Collections.Generic.Dictionary<
			Guid, object>;
			Terrasoft.Core.DB.Delete delete = new Terrasoft.Core.DB.Delete(userConnection);
			string columnName = "";
			Terrasoft.Core.Entities.EntitySchemaColumn column = null;
			delete.From(entitySchema.Name);
			if (filters.Count != 0) {
				bool isFirst = true;
				foreach (Guid key in filters.Keys) {
					if (isFirst) {
							column = entitySchema.Columns.GetByUId(key);
							columnName = column.ColumnValueName;
							delete.Where(columnName).IsEqual(Terrasoft.Core.DB.Column.Parameter(filters[key], column.DataValueType));
						isFirst = false;
						continue;
					}
					column = entitySchema.Columns.GetByUId(key);
					columnName = column.ColumnValueName;
					delete.And(columnName).IsEqual(Terrasoft.Core.DB.Column.Parameter(filters[key], column.DataValueType));
				}
			}
			return delete;
		}

		public virtual void DeleteRows(object deletingFilters, Terrasoft.Core.Entities.EntitySchema entitySchema, ProcessExecutingContext context) {
			var filters = deletingFilters as System.Collections.Generic.Dictionary<
			Guid, System.Collections.Generic.Dictionary<
			Guid, object>>;
			foreach (var key in filters.Keys){
				var delete = CreateDeleteQuery(entitySchema, filters[key], context.UserConnection);
					delete.Execute();
			}
		}

		public override void WritePropertiesData(DataWriter writer) {
			writer.WriteStartObject(Name);
			base.WritePropertiesData(writer);
			if (Status == Core.Process.ProcessStatus.Inactive) {
				writer.WriteFinishObject();
				return;
			}
			if (!HasMapping("ChildEntitySchemaUId")) {
				writer.WriteValue("ChildEntitySchemaUId", ChildEntitySchemaUId, Guid.Empty);
			}
			if (SingleRowSearchFilters != null) {
				if (SingleRowSearchFilters.GetType().IsSerializable || SingleRowSearchFilters.GetType().GetInterface("ISerializable") != null) {
					WriteSerializableObject(writer, "SingleRowSearchFilters", SingleRowSearchFilters, null);
				}
			}
			if (MultiRowsSearchFilters != null) {
				if (MultiRowsSearchFilters.GetType().IsSerializable || MultiRowsSearchFilters.GetType().GetInterface("ISerializable") != null) {
					WriteSerializableObject(writer, "MultiRowsSearchFilters", MultiRowsSearchFilters, null);
				}
			}
			if (MappingColumns != null) {
				if (MappingColumns.GetType().IsSerializable || MappingColumns.GetType().GetInterface("ISerializable") != null) {
					WriteSerializableObject(writer, "MappingColumns", MappingColumns, null);
				}
			}
			if (DefaultValues != null) {
				if (DefaultValues.GetType().IsSerializable || DefaultValues.GetType().GetInterface("ISerializable") != null) {
					WriteSerializableObject(writer, "DefaultValues", DefaultValues, null);
				}
			}
			if (!HasMapping("RequiredAllFields")) {
				writer.WriteValue("RequiredAllFields", RequiredAllFields, false);
			}
			if (RequiredFields != null) {
				if (RequiredFields.GetType().IsSerializable || RequiredFields.GetType().GetInterface("ISerializable") != null) {
					WriteSerializableObject(writer, "RequiredFields", RequiredFields, null);
				}
			}
			if (DeletingFilters != null) {
				if (DeletingFilters.GetType().IsSerializable || DeletingFilters.GetType().GetInterface("ISerializable") != null) {
					WriteSerializableObject(writer, "DeletingFilters", DeletingFilters, null);
				}
			}
			writer.WriteFinishObject();
		}

		#endregion

		#region Methods: Protected

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			switch (reader.CurrentName) {
				case "ChildEntitySchemaUId":
					ChildEntitySchemaUId = reader.GetGuidValue();
				break;
				case "SingleRowSearchFilters":
					SingleRowSearchFilters = GetSerializableObject(reader);
				break;
				case "MultiRowsSearchFilters":
					MultiRowsSearchFilters = GetSerializableObject(reader);
				break;
				case "MappingColumns":
					MappingColumns = GetSerializableObject(reader);
				break;
				case "DefaultValues":
					DefaultValues = GetSerializableObject(reader);
				break;
				case "RequiredAllFields":
					RequiredAllFields = reader.GetBoolValue();
				break;
				case "RequiredFields":
					RequiredFields = GetSerializableObject(reader);
				break;
				case "DeletingFilters":
					DeletingFilters = GetSerializableObject(reader);
				break;
			}
		}

		#endregion

	}

	#endregion

}

