namespace Terrasoft.Configuration.Translation
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;
	using global::Common.Logging;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Factories;

	#region Class: TranslationCleaningService

	[DefaultBinding(typeof(ITranslationCleaningService))]
	public class TranslationCleaningService : ITranslationCleaningService
	{

		#region Class: Private

		private class TypedResourceKeys
		{
			public List<TypedResourceKey> ConfigurationResources { get; } = new List<TypedResourceKey>();

			public List<TypedResourceKey> DataResources { get; } = new List<TypedResourceKey>();
			
			public List<Guid> InvalidTranslationsIds { get; } = new List<Guid>();

			public void AddResourceKey(TypedResourceKey resourceKey) {
				var collection = resourceKey.ResourceType == "Data" ? DataResources : ConfigurationResources;
				collection.Add(resourceKey);
			}
		}

		private class TypedResourceKey
		{
			public string KeyValue { get; set; }

			public string ResourceType { get; set; }
			
			public string SchemaName { get; set; }

			public string SchemaColumnName { get; set; }

			public bool? DeleteRequired { get; set; }

			public Guid TranslationId { get; set; }
		}

		#endregion

		#region Fields: Private
		
		private const int MaxQueryBatchSize = 100;
		private readonly UserConnection _userConnection;
		private readonly ILog _logger;

		private readonly Lazy<int> _maxDegreeOfParallelism = new Lazy<int>(() =>
			TranslationParallelOptions.GetMaxDegreeOfParallelism(
				UserConnection.Current, "ApplyTranslationConcurrencyLimit"));

		#endregion
		
		#region Constructors: Public

		public TranslationCleaningService(UserConnection userConnection) {
			_userConnection = userConnection;
			_logger = LogManager.GetLogger(nameof(TranslationCleaningService));
		}

		#endregion

		#region Methods: Private

		private ParallelOptions GetParallelOptions() {
			var maxDegreeOfParallelism = _maxDegreeOfParallelism.Value;
			_logger.InfoFormat("Cleaning translations unused resources in parallel with {0} threads",
				maxDegreeOfParallelism);
			return new ParallelOptions { MaxDegreeOfParallelism = maxDegreeOfParallelism };
		}

		private TypedResourceKeys GetTypedResourceKeys() {
			var resourceKeys = new TypedResourceKeys();
			var select = 
				new Select(_userConnection)
						.Column("Key")
						.Column("Id")
						.From("SysTranslation");
			select.ExecuteReader(dataReader => {
				var translationId = dataReader.GetColumnValue<Guid>("Id");
				var key = dataReader.GetColumnValue<string>("Key");
				var isValidResourceKey = TryBuildTypedResourceKey(translationId, key, out var resourceKey);
				if (isValidResourceKey) {
					resourceKeys.AddResourceKey(resourceKey);
				} else {
					resourceKeys.InvalidTranslationsIds.Add(translationId);
				}
			});
			var translationsCount = resourceKeys.ConfigurationResources.Count + resourceKeys.DataResources.Count;
			_logger.InfoFormat("Loaded {0} translation keys. Start searching unsued resources...", translationsCount);
			return resourceKeys;
		}

		/// <summary>
		/// If the resource type is "Configuration", keys should be in format "Configuration:{Schema}:{ColumnKey}".
		/// If the resource type is "Data", keys should be in format "Data:{Schema}.{Column}:{RecordId}"
		/// </summary>
		private bool TryBuildTypedResourceKey(Guid translationId, string key, out TypedResourceKey result) {
			result = null;
			string[] parts = key.Split(':');
			if (parts.Length != 3) {
				return false;
			}
			string resourceType = parts[0];
			string schemaName = parts[1];
			string keyValue = parts[2];
			string schemaColumnName = null;
			bool isDataResource = resourceType == "Data";
			bool isSupportedDataResource = isDataResource || resourceType == "Configuration";
			if (!isSupportedDataResource || string.IsNullOrEmpty(schemaName) || string.IsNullOrEmpty(keyValue)) {
				return false;
			}
			if (isDataResource) {
				string[] schemaParts = schemaName.Split('.');
				if (schemaParts.Length != 2 ||
					string.IsNullOrEmpty(schemaParts[0]) ||
					string.IsNullOrEmpty(schemaParts[1])) {
					return false;
				}
				schemaName = schemaParts[0];
				schemaColumnName = schemaParts[1];
			}
			result = new TypedResourceKey {
				TranslationId = translationId,
				ResourceType = resourceType,
				SchemaName = schemaName,
				SchemaColumnName = schemaColumnName,
				KeyValue = keyValue,
			};
			return true;
		}

		private void MarkUnusedConfigurationResources(IEnumerable<TypedResourceKey> resourceKeys) {
			var groupedBySchemaName = resourceKeys.GroupBy(val => val.SchemaName);
			Parallel.ForEach(groupedBySchemaName, GetParallelOptions(), schemaGroup => {
				var chunks = schemaGroup.SplitOnChunks(MaxQueryBatchSize);
				foreach (var chunk in chunks) {
					var schemaResourceKeys = chunk as TypedResourceKey[] ?? chunk.ToArray();
					var foundKeys = new HashSet<string>();
					var select = 
						new Select(_userConnection)
							.Distinct()
							.Column("Key")
							.From("SysLocalizableValue")
							.InnerJoin("SysSchema").On("SysSchema", "Id").IsEqual("SysLocalizableValue", "SysSchemaId")
							.Where("SysSchema", "Name").IsEqual(Column.Parameter(schemaGroup.Key))
							.And("Key").In(Column.Parameters(schemaResourceKeys.Select(c => c.KeyValue)))
						as Select;
					select?.ExecuteReader(dataReader => foundKeys.Add(dataReader.GetColumnValue<string>("Key")));
					foreach (var resourceKey in schemaResourceKeys) {
						resourceKey.DeleteRequired = !foundKeys.Contains(resourceKey.KeyValue);
					}
				}
			});
		}

		private void MarkUnusedDataResources(IEnumerable<TypedResourceKey> resourceKeys) {
			var groupedBySchemaName = resourceKeys.GroupBy(val => val.SchemaName);
			Parallel.ForEach(groupedBySchemaName, GetParallelOptions(), schemaGroup => {
				var schemaName = schemaGroup.Key;
				if (string.IsNullOrEmpty(schemaName)) {
					_logger.InfoFormat("Empty schema name in data resource group; marking {0} keys for deletion.",
						schemaGroup.Count());
					schemaGroup.ForEach(resourceKey => resourceKey.DeleteRequired = true);
					return;
				}
				var entitySchemaManagerItem = _userConnection.EntitySchemaManager.FindItemByName(schemaName);
				if (entitySchemaManagerItem == null) {
					_logger.InfoFormat("Schema '{0}' not found in EntitySchemaManager.", schemaName);
					schemaGroup.ForEach(resourceKey => resourceKey.DeleteRequired = true);
					return;
				}
				var columnsInTranslations = schemaGroup.Select(s => s.SchemaColumnName).Distinct();
				var localizableColumnNames = entitySchemaManagerItem.SafeInstance.Columns
					.FindByNames(columnsInTranslations)
					.Where(col => col?.IsLocalizable == true)
					.Select(col => col.Name)
					.ToHashSet();
				foreach (var resourceKey in schemaGroup) {
					resourceKey.DeleteRequired = !localizableColumnNames.Contains(resourceKey.SchemaColumnName);
				}
				var itemsToProcess = schemaGroup.Where(item => item.DeleteRequired != true);
				MarkUnusedDataResourcesForSchema(schemaName, itemsToProcess);
			});
		}

		private void MarkUnusedDataResourcesForSchema(string schemaName, IEnumerable<TypedResourceKey> resourceKeys) {
			var chunks = resourceKeys.SplitOnChunks(MaxQueryBatchSize);
			foreach (var chunk in chunks) {
				var schemaResourceKeys = chunk as TypedResourceKey[] ?? chunk.ToArray();
				var foundKeys = new HashSet<string>();
				var select = 
					new Select(_userConnection)
						.Column("Id")
						.From(schemaName)
						.Where("Id").In(Column.Parameters(schemaResourceKeys.Select(c => Guid.Parse(c.KeyValue)))) 
					as Select;
				select?.ExecuteReader(reader => foundKeys.Add(reader.GetColumnValue<Guid>("Id").ToString()));
				foreach (var resourceKey in schemaResourceKeys) {
					resourceKey.DeleteRequired = !foundKeys.Contains(resourceKey.KeyValue);
				}
			}
		}

		private void DeleteUnusedTranslations(TypedResourceKeys resourceKeys) {
			var translationIdsToDeleteChunks = resourceKeys.DataResources
				.Where(r => r.DeleteRequired == true)
				.Concat(resourceKeys.ConfigurationResources.Where(r => r.DeleteRequired == true))
				.Select(r => r.TranslationId)
				.Concat(resourceKeys.InvalidTranslationsIds)
				.SplitOnChunks(MaxQueryBatchSize);
			Parallel.ForEach(translationIdsToDeleteChunks, GetParallelOptions(), deletionChunk => {
				var delete =
					new Delete(_userConnection)
						.From("SysTranslation")
						.Where("Id").In(Column.Parameters(deletionChunk))
					as Delete;
				delete?.Execute();
			});
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc/>
		public void ClearUnusedReferences() {
			TypedResourceKeys resourceKeys = GetTypedResourceKeys();
			MarkUnusedConfigurationResources(resourceKeys.ConfigurationResources);
			MarkUnusedDataResources(resourceKeys.DataResources);
			DeleteUnusedTranslations(resourceKeys);
		}

		#endregion

	}

	#endregion

}

