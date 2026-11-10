namespace Terrasoft.Configuration.GenAI
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text.RegularExpressions;
	using Creatio.FeatureToggling;
	using global::Common.Logging;
	using Newtonsoft.Json;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Applications.Abstractions.Content;
	using Terrasoft.Core.Applications.Abstractions.Creation;
	using Terrasoft.Core.Applications.GenAI;
	using Terrasoft.Core.Factories;
	using Terrasoft.Enrichment.Interfaces.GenAI;
	using DataValueType = Terrasoft.Nui.ServiceModel.DataContract.DataValueType;

	#region Class: GenAIApplicationContentGenerator

	[DefaultBinding(typeof(IGenAIApplicationContentGenerator))]
	public class GenAIApplicationContentGenerator : IGenAIApplicationContentGenerator
	{

		#region Fields: Private

		private static readonly ILog _log = LogManager.GetLogger("GenAI");
		private readonly IGenAIAppServiceProxy _genAiServiceProxy;
		private readonly IGeneratedEntitySaver _generatedEntitySaver;
		private readonly IGenAICardSchemaGenerator _cardSchemaGenerator;
		private readonly IPackageSchemaDataCreator _packageSchemaDataCreator;
		private readonly IGeneratedDcmSaver _generatedDcmSaver;

		#endregion

		#region Properties: Protected

		protected virtual Dictionary<string, DataValueType> NameToTypeMapper =>
			new Dictionary<string, DataValueType> {
				{ "date", DataValueType.Date },
				{ "mail", DataValueType.EmailText },
				{ "phone", DataValueType.PhoneText }
			};

		#endregion

		#region Constructors: Public

		public GenAIApplicationContentGenerator(IGenAIAppServiceProxy genAiServiceProxy,
				IGeneratedEntitySaver generatedEntitySaver, IGenAICardSchemaGenerator cardSchemaGenerator,
				IPackageSchemaDataCreator packageSchemaDataCreator, IGeneratedDcmSaver generatedDcmSaver) {
			_genAiServiceProxy = genAiServiceProxy;
			_generatedEntitySaver = generatedEntitySaver;
			_cardSchemaGenerator = cardSchemaGenerator;
			_packageSchemaDataCreator = packageSchemaDataCreator;
			_generatedDcmSaver = generatedDcmSaver;
		}

		#endregion

		#region Methods: Private

		private DataValueType GetTypeByName(string name, DataValueType defaultType) {
			if (string.IsNullOrWhiteSpace(name)) {
				return defaultType;
			}
			const StringComparison comparisonType = StringComparison.OrdinalIgnoreCase;
			string key = NameToTypeMapper.Keys.FirstOrDefault(k => name.EndsWith(k, comparisonType));
			return key == null ? defaultType : NameToTypeMapper[key];
		}

		private static GenAIEntity GetMainEntity(IReadOnlyCollection<GenAIEntity> entities) {
			IEnumerable<string> referencedEntities = entities
				.Where(x => !x.IsDetail)
				.SelectMany(x => x.Columns
					.Select(e => e.ReferenceEntityName)
					.Where(e => e != null));
			return entities
				.OrderByDescending(x => !referencedEntities.Contains(x.Name))
				.ThenByDescending(x => x.IsMain)
				.ThenBy(x => x.IsDetail)
				.ThenByDescending(x => x.Details?.Count)
				.ThenByDescending(x => x.Columns?.Count)
				.First();
		}

		private int GetDataValueType(GenAIEntityColumn column) {
			if (column.IsEmail) {
				return (int)DataValueType.EmailText;
			}
			if (column.IsPhone) {
				return (int)DataValueType.PhoneText;
			}
			DataValueType dataValueType;
			switch (column.Type) {
				case GenAIEntityColumnType.Bool:
					dataValueType = DataValueType.Boolean;
					break;
				case GenAIEntityColumnType.DateTime:
					dataValueType = DataValueType.DateTime;
					break;
				case GenAIEntityColumnType.Date:
					dataValueType = DataValueType.Date;
					break;
				case GenAIEntityColumnType.Time:
					dataValueType = DataValueType.Time;
					break;
				case GenAIEntityColumnType.Float:
					dataValueType = DataValueType.Float;
					break;
				case GenAIEntityColumnType.Integer:
					dataValueType = DataValueType.Integer;
					break;
				case GenAIEntityColumnType.Lookup:
					dataValueType = DataValueType.Lookup;
					break;
				case GenAIEntityColumnType.String:
				default:
					dataValueType = DataValueType.MediumText;
					break;
			}
			dataValueType = GetTypeByName(column.Name, dataValueType);
			return (int)dataValueType;
		}

		private GeneratedEntity ToGeneratedEntity(GenAIEntity entity) {
			return new GeneratedEntity {
				EntitySchemaName = entity.Name,
				Caption = entity.Caption,
				Columns = entity.Columns.Select(col => new GeneratedEntityColumn {
					Name = col.Name,
					Caption = col.Caption,
					Type = GetDataValueType(col),
					ReferenceSchemaName = col.ReferenceEntityName
				}).ToList()
			};
		}

		private static string AdjustNamePrefix(string name) {
			string prefix = UserConnection.Current.SchemaNamePrefix;
			if (prefix.IsNullOrWhiteSpace()) {
				return name;
			}
			return name.StartsWith(prefix) ? name : prefix + name;
		}

		private static string GenerateRandomString(int length) {
			const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			var random = new Random();
			return new string(Enumerable.Repeat(chars, length)
				.Select(s => s[random.Next(s.Length)]).ToArray());
		}

		private static string AdjustSchemaName(string name, Dictionary<string, string> schemaNameMapping) {
			if (name.IsNullOrEmpty()) {
				name = GenerateRandomString(8);
			}
			if (schemaNameMapping.TryGetValue(name, out string newName)) {
				return newName;
			}
			string nameWithPrefix = AdjustNamePrefix(name);
			string uniqueName = GetUniqueEntitySchemaName(nameWithPrefix);
			schemaNameMapping[name] = uniqueName;
			return uniqueName;
		}

		private static string GetUniqueEntitySchemaName(string name) {
			string newName = name;
			int i = 2;
			while (UserConnection.Current.EntitySchemaManager.FindItemByName(newName) != null) {
				newName = name + i;
				i++;
			}
			return newName;
		}

		private static void AdjustNames(List<GenAIEntity> entities) {
			Dictionary<string, string> schemaNameMapping = new Dictionary<string, string>();
			foreach (GenAIEntity entity in entities) {
				entity.Name = AdjustSchemaName(entity.Name, schemaNameMapping);
				foreach (GenAIEntityColumn column in entity.Columns) {
					if (column.Name.IsNullOrEmpty()) {
						column.Name = GenerateRandomString(8);
					}
					column.Name = AdjustNamePrefix(column.Name);
					column.ReferenceEntityName = column.ReferenceEntityName.IsNullOrWhiteSpace()
						? string.Empty
						: AdjustSchemaName(column.ReferenceEntityName, schemaNameMapping);
					if (column.Type == GenAIEntityColumnType.Lookup) {
						column.Name = EraseIdSuffix(column.Name);
					}
				}
			}
			foreach (GenAIEntity entity in entities) {
				entity.Details = entity.Details?.Select(
					detail => schemaNameMapping.GetValueOrDefault(detail ?? string.Empty, detail)).ToList();
			}
		}

		private static void AdjustCaptions(List<GenAIEntity> entities) {
			foreach (GenAIEntity entity in entities) {
				entity.Caption = (entity.Caption.IsNullOrWhiteSpace() ? entity.Name : entity.Caption)
					?.ToLowerInvariant().ToCamelCase();
				foreach (GenAIEntityColumn column in entity.Columns) {
					string columnCaption = column.Caption.IsNullOrWhiteSpace() ? column.Name : column.Caption;
					if (column.Type == GenAIEntityColumnType.Lookup) {
						columnCaption = EraseIdSuffix(columnCaption);
					}
					column.Caption = columnCaption?.ToLowerInvariant().ToCamelCase();
				}
			}
		}

		private static void RemoveInvalidColumns(List<GenAIEntity> generatedEntities) {
			foreach (GenAIEntity generatedEntity in generatedEntities) {
				HashSet<string> invalidLookupColumns = generatedEntity.Columns.Where(col =>
						col.Type == GenAIEntityColumnType.Lookup && col.ReferenceEntityName.IsNotNullOrEmpty() &&
						generatedEntities.All(refEntity => refEntity.Name != col.ReferenceEntityName))
					.Select(col => col.Name)
					.ToHashSet();
				if (invalidLookupColumns.IsNotEmpty()) {
					_log.Warn($"Entity '{generatedEntity.Name}' had lookup columns with invalid reference: " +
						$"[{string.Join(", ", invalidLookupColumns)}]");
				}
				generatedEntity.Columns = generatedEntity.Columns
					.Where(col => !invalidLookupColumns.Contains(col.Name) &&
						!IsNonLookupIdColumn(col))
					.ToList();
			}
		}

		private static bool IsNonLookupIdColumn(GenAIEntityColumn column) {
			string columnName = column.Name;
			if (columnName == null) {
				return false;
			}
			const StringComparison comparer = StringComparison.OrdinalIgnoreCase;
			return column.Type != GenAIEntityColumnType.Lookup && (columnName.Equals("id", comparer) ||
				columnName.EndsWith("Id") || columnName.EndsWith("ID"));
		}

		private void RemoveCyclicRefColumns(List<GenAIEntity> generatedEntities) {
			foreach (GenAIEntity generatedEntity in generatedEntities
						.OrderByDescending(entity => entity.IsDetail)
						.ThenBy(entity => entity.IsMain)) {
				HashSet<string> cyclicLookupColumns = generatedEntity.Columns.Where(col =>
						col.Type == GenAIEntityColumnType.Lookup && col.ReferenceEntityName.IsNotNullOrEmpty() &&
						generatedEntities.Any(referencedEntity => referencedEntity.Name == col.ReferenceEntityName &&
								referencedEntity.Columns.Any(referencedEntityCol =>
									referencedEntityCol.ReferenceEntityName == generatedEntity.Name)))
					.Select(col => col.Name)
					.ToHashSet();
				if (cyclicLookupColumns.IsEmpty()) {
					continue;
				}
				generatedEntity.Columns = generatedEntity.Columns
					.Where(col => !cyclicLookupColumns.Contains(col.Name))
					.ToList();
				_log.Warn($"Entity '{generatedEntity.Name}' had lookup columns with cyclic references: " +
					$"[{string.Join(", ", cyclicLookupColumns)}]");
			}
		}

		private static (Guid? lookupFolderId, List<(Guid id, string Name, Guid lookupInFolderId)> lookups)
				RegisterLookups(List<GeneratedEntity> sections, string appName) {
			if (!sections.Any(section => section.Lookups.Any())) {
				return (null, null);
			}
			Guid lookupFolderId = AddLookupFolder(appName);
			var lookups = new List<(Guid id, string Name, Guid lookupInFolderId)>();
			var registeredLookupEntitySchemaUIds = new HashSet<Guid>();
			foreach (GeneratedEntity section in sections) {
				foreach (GeneratedEntity lookup in section.Lookups) {
					if (lookup.UId.IsEmpty() || registeredLookupEntitySchemaUIds.Contains(lookup.UId)) {
						continue;
					}
					var (lookupId, lookupInFolderId) = RegisterLookup(lookup, lookupFolderId);
					if (lookupId != null) {
						lookups.Add((lookupId.Value, lookup.EntitySchemaName, lookupInFolderId));
					}
					registeredLookupEntitySchemaUIds.Add(lookup.UId);
				}
			}
			return (lookupFolderId, lookups);
		}

		private static Guid AddLookupFolder(string folderName) {
			const string staticFolderTypeId = "9DC5F6E6-2A61-4DE8-A059-DE30F4E74F24";
			var folderId = Guid.NewGuid();
			var userConnection = UserConnection.Current;
			var lookupFolder = userConnection.EntitySchemaManager.GetEntityByName("LookupFolder", userConnection);
			lookupFolder.SetDefColumnValues();
			lookupFolder.SetColumnValue("Id", folderId);
			lookupFolder.SetColumnValue("Name", folderName);
			lookupFolder.SetColumnValue("Description", "Generated by AI");
			lookupFolder.SetColumnValue("FolderTypeId", new Guid(staticFolderTypeId));
			if (lookupFolder.Save()) {
				return folderId;
			}
			return Guid.Empty;
		}

		private static (Guid? id, Guid lookupInFolderId) RegisterLookup(GeneratedEntity lookupEntity, Guid lookupFolderId) {
			var userConnection = UserConnection.Current;
			var lookup = userConnection.EntitySchemaManager.GetEntityByName("Lookup", userConnection);
			if (lookup.ExistInDB("SysEntitySchemaUId", lookupEntity.UId)) {
				return (null, Guid.Empty);
			}
			Guid lookupId = Guid.NewGuid();
			lookup.SetDefColumnValues();
			lookup.SetColumnValue("Id", lookupId);
			lookup.SetColumnValue("Name", lookupEntity.Caption);
			lookup.SetColumnValue("Description", "Generated by AI");
			lookup.SetColumnValue("SysEntitySchemaUId", lookupEntity.UId);
			if (lookupEntity.PageSchemaUId.IsNotEmpty()) {
				lookup.SetColumnValue("SysEditPageSchemaUId", lookupEntity.PageSchemaUId);
			}
			lookup.Save();
			var lookupInFolderId = Guid.Empty;
			if (lookupFolderId.IsNotEmpty()) {
				lookupInFolderId = AddLookupToFolder(lookupId, lookupFolderId);
			}
			return (lookupId, lookupInFolderId);
		}

		private static Guid AddLookupToFolder(Guid lookupId, Guid folderId) {
			var userConnection = UserConnection.Current;
			var lookupInFolder = userConnection.EntitySchemaManager.GetEntityByName("LookupInFolder", userConnection);
			Guid id = Guid.NewGuid();
			lookupInFolder.SetDefColumnValues();
			lookupInFolder.SetColumnValue("Id", id);
			lookupInFolder.SetColumnValue("LookupId", lookupId);
			lookupInFolder.SetColumnValue("FolderId", folderId);
			lookupInFolder.Save();
			return id;
		}

		private void SaveLookupsPackageSchemaData(Guid packageUId, string appCode,
				Guid? lookupFolderId, List<(Guid id, string Name, Guid lookupInFolderId)> lookups) {
			if (lookupFolderId != null) {
				_packageSchemaDataCreator.CreatePackageSchemaData($"LookupFolder_{appCode}", packageUId,
					new[] { lookupFolderId.Value }, "LookupFolder");
			}
			if (lookups != null) {
				foreach ((Guid Id, string Name, Guid lookupInFolderId) lookup in lookups) {
					_packageSchemaDataCreator.CreatePackageSchemaData($"Lookup_{lookup.Name}_{appCode}",
						packageUId, new[] { lookup.Id }, "Lookup");
					_packageSchemaDataCreator.CreatePackageSchemaData($"LookupInFolder_{lookup.Name}_{appCode}",
						packageUId, new[] { lookup.lookupInFolderId }, "LookupInFolder");
				}
			}
		}

		private static string EraseIdSuffix(string text) {
			if (text.IsNullOrEmpty()) {
				return text;
			}
			const string pattern = @"(?i)id$";
			return text.EndsWith("id") ? text : Regex.Replace(text, pattern, string.Empty);
		}

		private GeneratedEntity ConvertToGeneratedEntity(GenAIEntity genAIEntity, List<GenAIEntity> allEntities,
				bool doGenerateDetails = false) {
			GeneratedEntity mainGeneratedEntity = ToGeneratedEntity(genAIEntity);
			if (doGenerateDetails) {
				// TODO RND-43443 Add frontend support for generating details of details and of lookups. Remove this arg
				mainGeneratedEntity.Details = ConvertToGeneratedEntityDetails(genAIEntity, allEntities);
			}
			return mainGeneratedEntity;
		}

		private List<GeneratedEntity> ConvertToGeneratedEntityDetails(GenAIEntity parentEntity,
				List<GenAIEntity> allEntities) {
			var details = allEntities.Where(detail => parentEntity.Details?.Contains(detail.Name) == true
					&& detail.Columns.Any(col => col.ReferenceEntityName == parentEntity.Name
					&& detail.Name != parentEntity.Name));
			var generatedEntityDetails = details
				.Select(entity => ConvertToGeneratedEntity(entity, allEntities)).ToList();
			return generatedEntityDetails;
		}

		private List<GeneratedEntity> GetSectionLookups(GeneratedEntity mainSection, List<GenAIEntity> allEntities) {
			IEnumerable<GenAIEntity> lookupsGenAIEntities = allEntities
				.Where(entity => entity.Name != mainSection.EntitySchemaName && mainSection.Details?.All(
					detail => detail.EntitySchemaName != entity.Name) == true);
			List<GeneratedEntity> generatedEntityLookups = lookupsGenAIEntities
				.Select(entity => ConvertToGeneratedEntity(entity, allEntities)).ToList();
			return generatedEntityLookups;
		}

		#endregion

		#region Methods: Public

		public ApplicationGenerationResult GenerateApplicationByDescription(string description) {
			List<GenAIEntity> generatedEntities = _genAiServiceProxy.GenerateEntitiesByDescription(description);
			//This log is added temporarily for getting more details why 
			//"RND-T19250. Create and run mocking app with primary display column" protractor test is failing
			//TODO: needs to be removed after clarification is done
			try {
				string json = JsonConvert.SerializeObject(generatedEntities, Formatting.Indented);
				_log.Info($"Generated entities: {json}");
			} catch (Exception ex) {
				_log.Error("Generated entities could not be serialized.", ex);
			}
			if (!generatedEntities.Any()) {
				throw new GenAIException(GenAIServiceErrorCode.NoEntities,
					$"No entities were generated for the provided description: {description}");
			}
			RemoveInvalidColumns(generatedEntities);
			RemoveCyclicRefColumns(generatedEntities);
			AdjustCaptions(generatedEntities);
			AdjustNames(generatedEntities);
			GenAIEntity mainEntity = GetMainEntity(generatedEntities);
			GeneratedEntity mainSection = ConvertToGeneratedEntity(mainEntity, generatedEntities, true);
			mainSection.Lookups = GetSectionLookups(mainSection, generatedEntities);
			GeneratedDcm generatedDcm = null;
			if (Features.GetIsEnabled<GenAIFeatures.GenerateDcm>()) {
				List<string> stages = _genAiServiceProxy.GenerateDcmStages(description);
				generatedDcm = _generatedDcmSaver.CreateGeneratedDcm(stages, mainSection);
				_generatedDcmSaver.SetStageColumnDefaultValue(generatedDcm, mainSection);
			}
			mainSection.HasDcm = generatedDcm != null;
			return new ApplicationGenerationResult {
				Sections = new List<GeneratedEntity> {
					mainSection
				},
				Dcm = generatedDcm
			};
		}

		public void SaveContentBeforeBuild(ApplicationGenerationResult generationResult, string appCode,
				string appName) {
			if (generationResult.Sections.IsEmpty()) {
				return;
			}
			_generatedEntitySaver.SaveEntities(generationResult.Sections.First(), generationResult.PackageUId,
				appCode);
			_cardSchemaGenerator.GenerateCards(generationResult, appCode);
			var (lookupFolderId, lookups) = RegisterLookups(generationResult.Sections, appName);
			SaveLookupsPackageSchemaData(generationResult.PackageUId, appCode, lookupFolderId, lookups);
			_generatedDcmSaver.SaveDcmSchema(generationResult.Dcm, generationResult.Sections[0],
				generationResult.PackageUId);
			var savedDataList = _generatedDcmSaver.SaveDcmSettings(generationResult.Dcm);
			savedDataList?.ForEach(savedData => {
				_packageSchemaDataCreator.CreatePackageSchemaData(savedData.SchemaName, generationResult.PackageUId,
					savedData.RecordIds.ToArray(), savedData.SchemaName);
			});
		}

		public void SaveContentAfterBuild(ApplicationGenerationResult generationResult, string appCode, string appName) {
			var savedData = _generatedDcmSaver.SaveDcmStagesData(generationResult.Dcm);
			if (savedData.SchemaName != null) {
				_packageSchemaDataCreator.CreatePackageSchemaData(savedData.SchemaName, generationResult.PackageUId,
					savedData.RecordIds.ToArray(), savedData.SchemaName);
			}
		}

		#endregion

	}

	#endregion

}

