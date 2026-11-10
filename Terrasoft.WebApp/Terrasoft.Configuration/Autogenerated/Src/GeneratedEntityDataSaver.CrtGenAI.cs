namespace Terrasoft.Configuration.GenAI
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.Enrichment.Interfaces.GenAI;

	public interface IGeneratedEntityDataSaver
	{
		void SaveData(List<GenAIEntityData> data, List<GenAIEntity> entities);
	}

	[DefaultBinding(typeof(IGeneratedEntityDataSaver))]
	public class GeneratedEntityDataSaver : IGeneratedEntityDataSaver
	{
		private class LookupHash : Dictionary<(string EntityName, string DisplayValue), Guid>
		{
		}

		private class LookupColumnsUpdateList : List<(string EntityName, string ColumnName, string RefEntityName, 
			Guid Id, string DisplayValue)>
		{
		}

		#region Fields: Private

		private readonly UserConnection _userConnection;

		#endregion

		#region Constructors: Public

		public GeneratedEntityDataSaver(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private static bool TryGetColumnValue(object generatedValue, GenAIEntityColumn column, LookupHash lookupHash,
				out object value) {
			value = null;
			switch (column.Type) {
				case GenAIEntityColumnType.DateTime:
				case GenAIEntityColumnType.Date:
				case GenAIEntityColumnType.Time:
					if (generatedValue is DateTime dateTimeValue) {
						value = dateTimeValue;
						return true;
					}
					if (DateTime.TryParse((string)generatedValue, out DateTime dateTime)) {
						value = dateTime;
						return true;
					}
					break;
				case GenAIEntityColumnType.Lookup:
					if (lookupHash.TryGetValue((column.ReferenceEntityName, generatedValue?.ToString()),
							out Guid lookupId)) {
						value = lookupId;
						return true;
					}
					break; 
				default:
					value = generatedValue;
					return true;
			}
			return false;
		}

		private void SaveEntityData(GenAIEntityData entityData, List<GenAIEntity> entities,
				LookupHash lookupHash, LookupColumnsUpdateList lookupUpdateList) {
			GenAIEntity genAIEntity = entities.FirstOrDefault(aiEntity => aiEntity.Name == entityData.EntityName);
			if (genAIEntity == null) {
				return;
			}
			Entity entity = _userConnection.EntitySchemaManager.GetEntityByName(entityData.EntityName, _userConnection);
			Guid id = Guid.NewGuid();
			entity.SetDefColumnValues();
			entity.PrimaryColumnValue = id;
			string primaryDisplayValue = null;
			foreach (KeyValuePair<string, object> kv in entityData.ColumnValues) {
				string columnName = kv.Key;
				GenAIEntityColumn column = genAIEntity.Columns.FirstOrDefault(col => col.Name == columnName);
				if (column == null) {
					continue;
				}
				if (TryGetColumnValue(kv.Value, column, lookupHash, out object value)) {
					EntitySchemaColumn entitySchemaColumn = entity.Schema.Columns.FindByName(columnName);
					if (entitySchemaColumn == null) {
						continue;
					}
					entity.SetColumnValue(entitySchemaColumn, value);
					if (column.IsPrimaryDisplayColumn && column.Type == GenAIEntityColumnType.String) {
						primaryDisplayValue = value?.ToString();
					}
					continue;
				}
				if (column.Type == GenAIEntityColumnType.Lookup) {
					lookupUpdateList.Add((entityData.EntityName, columnName, column.ReferenceEntityName, id, 
						kv.Value?.ToString()));
				}
			}
			entity.Save(false);
			if (primaryDisplayValue != null) {
				lookupHash[(entityData.EntityName, primaryDisplayValue)] = id;
			}
		}

		private void UpdateLookupValues(LookupColumnsUpdateList lookupUpdateList, LookupHash lookupHash) {
			foreach (var lookupCfg in lookupUpdateList) {
				if (!lookupHash.TryGetValue((lookupCfg.RefEntityName, lookupCfg.DisplayValue), out Guid lookupId)) {
					continue;
				}
				string entityName = lookupCfg.EntityName;
				Entity entity = _userConnection.EntitySchemaManager.GetEntityByName(entityName, _userConnection);
				if (!entity.FetchFromDB(lookupCfg.Id, false)) {
					continue;
				}
				EntitySchemaColumn entitySchemaColumn = entity.Schema.Columns.FindByName(lookupCfg.ColumnName);
				if (entitySchemaColumn == null) {
					continue;
				}
				entity.SetColumnValue(entitySchemaColumn, lookupId);
				entity.Save(false);
			}
		}

		#endregion

		#region Methods: Public

		public void SaveData(List<GenAIEntityData> data, List<GenAIEntity> entities) {
			var lookupHash = new LookupHash();
			var lookupUpdateList = new LookupColumnsUpdateList();
			foreach (GenAIEntityData genAIEntityData in data) {
				SaveEntityData(genAIEntityData, entities, lookupHash, lookupUpdateList);
			}
			UpdateLookupValues(lookupUpdateList, lookupHash);
		}

		#endregion

	}

}

