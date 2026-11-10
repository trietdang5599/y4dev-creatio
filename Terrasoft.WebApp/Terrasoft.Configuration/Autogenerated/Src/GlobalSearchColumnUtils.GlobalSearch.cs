namespace Terrasoft.Configuration.GlobalSearchColumnUtils {

	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Terrasoft.Common;
	using Terrasoft.Common.Json;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.GlobalSearch;

	#region Class: GlobalSearchColumnUtils

	public class GlobalSearchColumnUtils
	{

		#region Fields: Private

		/// <summary>
		/// List of entity phone columns.
		/// </summary>
		private Dictionary<string, HashSet<string>> _numberColumns;

		#endregion

		#region Properties: Public

		/// <summary>
		/// Single instance of this class.
		/// </summary>
		private static GlobalSearchColumnUtils _instance;
		public static GlobalSearchColumnUtils Instance {
			get {
				if (_instance == null ) {
					_instance = ClassFactory.Get<GlobalSearchColumnUtils>();
				}
				return _instance;
			}
		}

		/// <summary>
		/// Pattern for relation columns field names.
		/// </summary>
		public virtual string RelationColumnsFieldPattern => "*_*_id";

		#endregion

		#region Methods: Private

		private Dictionary<string, HashSet<string>> GetNumberColumns(UserConnection userConnection) {
			if (_numberColumns != null) {
				return _numberColumns;
			}
			string jsonSettingsValue = Core.Configuration.SysSettings.GetValue(userConnection,
				"GlobalSearchTelephoneNumberColumns", string.Empty);
			_numberColumns = !jsonSettingsValue.IsNullOrWhiteSpace()
				? Json.Deserialize<Dictionary<string, HashSet<string>>>(jsonSettingsValue)
				: new Dictionary<string, HashSet<string>> {
					{
						"Contact", new HashSet<string> {
							"Phone",
							"MobilePhone",
							"HomePhone"
						}
					}, {
						"Account", new HashSet<string> {
							"Phone",
							"AdditionalPhone"
						}
					}, {
						"Lead", new HashSet<string> {
							"MobilePhone",
							"BusinesPhone"
						}
					}
				};
			return _numberColumns;
		}

		private bool IsNumberColumn(EntitySchemaColumn column, EntitySchema entitySchema) {
			Dictionary<string, HashSet<string>> numberColumns = GetNumberColumns(entitySchema.SystemUserConnection);
			return numberColumns.Any(pc => pc.Key == entitySchema.Name && pc.Value.Contains(column.Name));
		}

		private string GetAliasFormat(EntitySchema entitySchema, EntitySchemaColumn entitySchemaColumn) {
			var entityColumnFormat = "{0}_{1}";
			if (entitySchema.PrimaryDisplayColumn?.UId != entitySchemaColumn.UId && !entitySchemaColumn.IsLookupType)
				return IsNumberColumn(entitySchemaColumn, entitySchema)
					? $"{entityColumnFormat}{ESConstants.NumberColumnSuffix}"
					: entityColumnFormat;
			if (GlobalAppSettings.FeatureIndexCommunicationOptionsAndLookupsBy2Symbols 
					&& !GetIsSysImageLookupColumn(entitySchemaColumn)) {
				return $"{entityColumnFormat}{ESConstants.PrimaryColumnsSuffix}";
			}
			return entityColumnFormat;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Get primary lookup column name for indexable column.
		/// </summary>
		/// <param name="column"><see cref="EntitySchemaColumn"/> instance of indexable column.</param>
		/// <returns>Correct column name.</returns>
		public string GetPrimaryLookupColumn(EntitySchemaColumn column) {
			var columnRefSchema = column.ReferenceSchema;
			var primaryColumn = columnRefSchema.PrimaryColumn;
			if (primaryColumn == null) {
				return string.Empty;
			}
			return $"{column.Name}.{primaryColumn.Name}";
		}

		/// <summary>
		/// Get image lookup column name for indexable column.
		/// </summary>
		/// <param name="column"><see cref="EntitySchemaColumn"/> instance of indexable column.</param>
		/// <returns>Correct column name.</returns>
		public string GetImageLookupColumn(EntitySchemaColumn column) {
			var columnRefSchema = column.ReferenceSchema;
			var primaryImageColumn = columnRefSchema.PrimaryImageColumn;
			if (primaryImageColumn == null || !primaryImageColumn.DataValueType.IsLookup) {
				return string.Empty;
			}
			return $"{column.Name}.{primaryImageColumn.Name}.Id";
		}

		/// <summary>
		/// Get column name for indexable column.
		/// </summary>
		/// <param name="column"><see cref="EntitySchemaColumn"/> instance of indexable column.</param>
		/// <returns>Correct column name.</returns>
		public string GetColumnName(EntitySchemaColumn column) {
			string columnName = column.Name;
			if (column.DataValueType.IsLookup) {
				var columnRefSchema = column.ReferenceSchema;
				var primaryDisplayColumn = columnRefSchema.PrimaryDisplayColumn;
				columnName = primaryDisplayColumn != null ? $"{columnName}.{primaryDisplayColumn.Name}" : string.Empty;
			}
			return columnName;
		}

		/// <summary>
		/// Get alias of indexable column for logstash.
		/// </summary>
		/// <param name="column"><see cref="EntitySchemaColumn"/> column for what alias creates.</param>
		/// <param name="entitySchema"><see cref="EntitySchema"/> instance.</param>
		/// <returns>Alias for indexable column.</returns>
		public string GetAlias(EntitySchemaColumn column, EntitySchema entitySchema) {
			var schemaName = entitySchema.Name;
			var isPrimaryColumn = entitySchema.PrimaryColumn.Name == column.Name;
			if (isPrimaryColumn) {
				return column.Name;
			}
			string aliasFormat = GetAliasFormat(entitySchema, column);
			return string.Format(aliasFormat, schemaName, column.Name).ToLowerInvariant();
		}

		/// <summary>
		/// Get alias of indexable lookup primary column column for logstash.
		/// </summary>
		/// <param name="column"><see cref="EntitySchemaColumn"/> column for what alias creates.</param>
		/// <param name="schemaName">Column entitySchema name.</param>
		/// <returns>Alias for indexable column.</returns>
		public string GetPrimaryColumnAlias(EntitySchemaColumn column, string schemaName) {
			return $"{schemaName}_{column.Name}_id".ToLowerInvariant();
		}

		/// <summary>
		/// Get alias of indexable lookup image column for logstash.
		/// </summary>
		/// <param name="column"><see cref="EntitySchemaColumn"/> column for what alias creates.</param>
		/// <param name="schemaName">Column entitySchema name.</param>
		/// <returns>Alias for indexable column.</returns>
		public string GetPrimaryImageColumnAlias(EntitySchemaColumn column, string schemaName) {
			return $"{schemaName}_{column.Name}_image".ToLowerInvariant();
		}

		/// <summary>
		/// Returns true when column is sys image lookup.
		/// </summary>
		/// <param name="column"><see cref="EntitySchemaColumn"/> instance.</param>
		/// <returns>Sys image lookup column tag.</returns>
		public bool GetIsSysImageLookupColumn(EntitySchemaColumn column) {
			return column.DataValueType.IsLookup && column.ReferenceSchema != null && column.ReferenceSchema.Name == "SysImage";
		}

		/// <summary>
		/// Returns true when column is indexed data value type.
		/// </summary>
		/// <param name="column"><see cref="EntitySchemaColumn"/> instance.</param>
		/// <returns>Is indexed column data value type.</returns>
		public bool IsIndexedColumnType(EntitySchemaColumn column) {
			bool isText = column.DataValueType is TextDataValueType;
			bool isLookup = column.DataValueType.IsLookup;
			return isText || isLookup;
		}

		/// <summary>
		/// Gets column is primary.
		/// </summary>
		/// <param name="entitySchema"><see cref="EntitySchema"/> schema.</param>
		/// <param name="column"><see cref="EntitySchemaColumn"/> column.</param>
		/// <returns>True if column is primary.</returns>
		public bool IsPrimaryColumn(EntitySchema entitySchema, EntitySchemaColumn column) {
			return entitySchema.PrimaryColumn != null && entitySchema.PrimaryColumn.Name == column.Name;
		}

		#endregion

	}

	#endregion

}

