namespace Terrasoft.Configuration.GlobalSearch
{

	using System;
	using System.Collections.Generic;
	using global::Common.Logging;
	using Terrasoft.Configuration.GlobalSearchColumnUtils;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using Terrasoft.Common;
	using Terrasoft.ElasticSearch;

	#region Class: ESManager

	public class ESSearchProvider : ISearchProvider
	{

		#region Fields: Private

		private readonly IElasticSearchRepository _elasticSearchRepository;
		private readonly IESQueryBuilder _queryBuilder;
		private readonly GlobalSearchColumnUtils _globalSearchColumnUtils;
		private readonly UserConnection _userConnection;
		private static readonly ILog _log = LogManager.GetLogger("GlobalSearch");
		private Dictionary<string, string> _schemaColumnAliases;

		#endregion

		#region Constructors: Public

		public ESSearchProvider(IElasticSearchRepository elasticSearchRepository,
				IESQueryBuilder queryBuilder, UserConnection userConnection) {
			_elasticSearchRepository = elasticSearchRepository;
			_queryBuilder = queryBuilder;
			_globalSearchColumnUtils = GlobalSearchColumnUtils.Instance;
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private Dictionary<string, string> GetResponseItem(Dictionary<string, object> item) {
			var responseItem = new Dictionary<string, string>();
			foreach (var fieldName in item.Keys) {
				if (_schemaColumnAliases.ContainsKey(fieldName)) {
					var itemFieldString = (string)item.GetValueOrDefault(fieldName, string.Empty);
					if (!string.IsNullOrEmpty(itemFieldString)) {
						responseItem.Add(_schemaColumnAliases[fieldName], itemFieldString);
					}
				}
			}
			return responseItem;
		}

		private IEnumerable<Dictionary<string, string>> GetResponseCollection(
				IEnumerable<Dictionary<string, object>> objectCollection) {
			foreach (var item in objectCollection) {
				var responseItem = GetResponseItem(item);
				if (responseItem.Count > 0) {
					yield return responseItem;
				}
			}
		}

		private EntitySchema SetSchemaColumnAliases(SearchQuery request) {
			var entitySchema = _userConnection.EntitySchemaManager.GetInstanceByName(request.SchemaName);
			_schemaColumnAliases = new Dictionary<string, string>();
			foreach (string column in request.Columns) {
				var entitySchemaColumn = entitySchema.Columns.FindByName(column);
				if (entitySchemaColumn != null) {
					var columnAlias = _globalSearchColumnUtils.GetAlias(entitySchemaColumn, entitySchema);
					if (entitySchemaColumn.Name == entitySchema.PrimaryColumn.Name) {
						columnAlias = columnAlias.ToLowerInvariant();
					}
					_schemaColumnAliases[columnAlias] = column;
				}
			}
			return entitySchema;
		}

		private IEnumerable<Dictionary<string, string>> FilterCollectionByPrimaryColumnValue(
				IEnumerable<Dictionary<string, string>> collection, Guid primaryColumnValue,
				EntitySchema entitySchema) {
			var primaryColumnName = entitySchema.PrimaryColumn.Name;
			foreach (var item in collection) {
				if (item.ContainsKey(primaryColumnName)) {
					if (item[primaryColumnName].ToString() != primaryColumnValue.ToString()) {
						yield return item;
					}
				} else {
					yield return item;
				}
			}
		}

		private IEnumerable<Dictionary<string, object>> GetElasticCollection(PageableElasticQuery query) {
			IEnumerable<Dictionary<string, object>> elasticCollection;
			try {
				elasticCollection = _elasticSearchRepository.GetCollection(query);
			} catch (Exception exception) { 
				elasticCollection = new List<Dictionary<string, object>>();
				_log.Error($"There is error during querying elastic. Message is {exception.Message}", exception);
				throw exception;
			}
			return elasticCollection;
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc cref="ISearchProvider.Search"/>
		public virtual IEnumerable<Dictionary<string, string>> Search(SearchQuery request) {
			var entitySchema = SetSchemaColumnAliases(request);
			var query = _queryBuilder.BuildQuery(request);
			if (query == null) {
				_log.Error($"There is empty request. RootSchema is {request.SchemaName}");
				return null;
			}
			var elasticCollection = GetElasticCollection(query);
			var resultCollection = GetResponseCollection(elasticCollection);
			if (request.PrimaryColumnValue.HasValue) {
				resultCollection = FilterCollectionByPrimaryColumnValue(resultCollection, request.PrimaryColumnValue.Value,
					entitySchema);
			}
			return resultCollection;
		}

		#endregion

	}

	#endregion

}
