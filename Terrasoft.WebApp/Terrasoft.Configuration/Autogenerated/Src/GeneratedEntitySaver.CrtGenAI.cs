namespace Terrasoft.Configuration.GenAI
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Creatio.FeatureToggling;
	using global::Common.Logging;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Applications.Abstractions.Creation;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Packages;
	using Terrasoft.Nui.ServiceModel.Extensions;
	using DataValueType = Terrasoft.Nui.ServiceModel.DataContract.DataValueType;

	#region Interface: IGeneratedEntitySaver

	public interface IGeneratedEntitySaver
	{
		void SaveEntities(GeneratedEntity section, Guid packageUId, string appCode);
	}

	#endregion

	#region Class: GeneratedEntitySaver

	[DefaultBinding(typeof(IGeneratedEntitySaver))]
	public class GeneratedEntitySaver: IGeneratedEntitySaver
	{

		#region Field: Private

		private static readonly ILog _log = LogManager.GetLogger("GenAI");
		private static readonly Guid _activitySchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89");

		#endregion

		#region Methods: Private

		private static void AddColumnToTop(GeneratedEntity generatedEntity, EntitySchemaColumn entitySchemaColumn) {
			GeneratedEntityColumn generatedEntityColumn =
				generatedEntity.Columns.Find(column => column.Name == entitySchemaColumn.Name);
			if (generatedEntityColumn == null) {
				generatedEntityColumn = new GeneratedEntityColumn {
					Name = entitySchemaColumn.Name,
					Caption = entitySchemaColumn.Caption,
					Type = (int)entitySchemaColumn.DataValueType.ToEnum()
				};
			} else {
				generatedEntity.Columns.Remove(generatedEntityColumn);
			}
			generatedEntity.Columns.Insert(0, generatedEntityColumn);
		}

		private static string FindPrimaryDisplayGeneratedColumn(List<GeneratedEntityColumn> generatedEntityColumns,
				string prefix) {
			var stringColumns = generatedEntityColumns.Where(col => col.Type == (int)DataValueType.MediumText).ToList();
			GeneratedEntityColumn primaryDisplayColumn =
				stringColumns.FirstOrDefault(col => col.Name == prefix + "Name") ?? stringColumns.FirstOrDefault();
			return primaryDisplayColumn?.Name;
		}

		private static string DefinePrimaryDisplayColumnForSchema(EntitySchema entitySchema,
				GeneratedEntity generatedEntity) {
			string primaryDisplayColumnName = entitySchema.PrimaryDisplayColumn?.Name;
			string primaryDisplayColumnCandidateName = FindPrimaryDisplayGeneratedColumn(generatedEntity.Columns,
				entitySchema.SchemaNamePrefix);
			if (primaryDisplayColumnCandidateName == null || 
					generatedEntity.Columns.Any(col => col.Name == primaryDisplayColumnName)) {
				return primaryDisplayColumnName;
			}
			return primaryDisplayColumnCandidateName;
		}

		private static void RemoveExistingNameColumnIfNeeded(EntitySchema entitySchema) {
			EntitySchemaColumn nameColumn = entitySchema.Columns.FindByName(entitySchema.SchemaNamePrefix + "Name");
			if (nameColumn == null) {
				return;
			}
			if (entitySchema.PrimaryDisplayColumn == nameColumn) {
				return;
			}
			entitySchema.Columns.Remove(nameColumn);
		}

		private static void SetPrimaryDisplayColumn(EntitySchema entitySchema, GeneratedEntity generatedEntity) {
			string primaryDisplayColumnName = DefinePrimaryDisplayColumnForSchema(entitySchema, generatedEntity);
			if (primaryDisplayColumnName == null) {
				return;
			}
			var entitySchemaPrimaryDisplayColumn = entitySchema.Columns.FindByName(primaryDisplayColumnName);
			if (entitySchemaPrimaryDisplayColumn == null) {
				return;
			}
			AddColumnToTop(generatedEntity, entitySchemaPrimaryDisplayColumn);
			entitySchema.PrimaryDisplayColumn = entitySchemaPrimaryDisplayColumn;
			entitySchema.PrimaryDisplayColumn.RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel;
			GeneratedEntityColumn generatedEntityColumn =
				generatedEntity.Columns.FirstOrDefault(column => column.Name == primaryDisplayColumnName);
			if (generatedEntityColumn != null) {
				generatedEntityColumn.IsPrimaryDisplayColumn = true;
			}
		}

		private static EntitySchemaColumn CreateEntitySchemaColumn(string name, DataValueType type, string caption,
				string referenceSchemaName, object defaultValue, Guid entitySchemaUId) {
			EntitySchemaManager entitySchemaManager = UserConnection.Current.EntitySchemaManager;
			EntitySchema referenceSchema = null;
			if (referenceSchemaName.IsNotNullOrEmpty()) {
				Guid uId = entitySchemaManager.GetItemByName(referenceSchemaName).UId;
				referenceSchema = entitySchemaManager.GetRuntimeInstanceFromMetadata(uId);
			}
			var entitySchemaColumn = new EntitySchemaColumn {
				Name = name,
				UId = Guid.NewGuid(),
				ReferenceSchema = referenceSchema,
				CreatedInSchemaUId = entitySchemaUId,
				ModifiedInSchemaUId = entitySchemaUId,
				DataValueType = type.ToDataValueType(UserConnection.Current),
				ReferenceSchemaUId = referenceSchema?.UId ?? Guid.Empty,
				RequirementType = EntitySchemaColumnRequirementType.None,
				Caption = new LocalizableString(caption),
				IsDeserializedFromMetaData = true,
			};
			if (defaultValue != null) {
				entitySchemaColumn.DefValue = new EntitySchemaColumnDef {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = defaultValue
				};
			}
			return entitySchemaColumn;
		}

		private static void SetEventsProcessSchemaToEntitySchema(EntitySchema entitySchema,
				UserConnection userConnection) {
			if (entitySchema.EventsProcessSchema != null) {
				return;
			}
			entitySchema.EventsProcessSchema =
				userConnection.ProcessSchemaManager.CreateDefEventHandlerSchema(entitySchema,
					new DesignModeEventDescriptor());
			entitySchema.EventsProcessSchema.Name = entitySchema.Name + "EventsProcess";
		}

		private static void SaveEntitySchemaItem(ISchemaManagerItem<EntitySchema> schemaItem,
				UserConnection userConnection) {
			EntitySchemaManager manager = userConnection.EntitySchemaManager;
			schemaItem.Instance.PackageUId = schemaItem.PackageUId;
			schemaItem.ParentUId = schemaItem.Instance.ParentSchemaUId;
			manager.SaveSchema(schemaItem, userConnection, true, false, false, true);
			manager.SaveDesignedItemIdInSessionData(userConnection, schemaItem.RealUId, schemaItem.Id);
			manager.SaveDesignedItemPackageUIdInSessionData(userConnection, schemaItem.RealUId, schemaItem.PackageUId);
			manager.SaveDesignedItemInSessionData(userConnection, schemaItem.Instance, schemaItem.RealUId);
			_log.Debug($"Entity schema item was saved: {schemaItem.Name}");
			var schema = manager.GetEntityByName(schemaItem.Name, userConnection);
			_log.Debug($"Entity schema got from manager: {schema.SchemaName}");
		}

		private static void EntitySchemaAssignPackage(ISchemaManagerItem<EntitySchema> entitySchemaItem,
				Guid packageUId) {
			entitySchemaItem.PackageUId = packageUId;
			entitySchemaItem.Instance.PackageUId = entitySchemaItem.PackageUId;
		}

		private static void EntitySchemaAssignParent(ISchemaManagerItem<EntitySchema> entitySchemaItem,
				UserConnection userConnection) {
			EntitySchema parentSchema = userConnection.EntitySchemaManager.GetInstanceByName("BaseEntity");
			entitySchemaItem.Instance.AssignParentSchema(parentSchema);
		}

		private void SaveGeneratedEntitySchema(GeneratedEntity generatedEntity, Guid packageUId,
				string appCode, List<GeneratedEntity> allGenEntities, HashSet<Guid> savedEntitySchemaUIds) {
			if (savedEntitySchemaUIds.Contains(generatedEntity.UId)) {
				return;
			}
			UserConnection userConnection = UserConnection.Current;
			EntitySchemaManager entitySchemaManager = userConnection.EntitySchemaManager;
			ISchemaManagerItem<EntitySchema> entitySchemaItem =
				entitySchemaManager.FindItemByName(generatedEntity.EntitySchemaName);
			if (generatedEntity.TryFindExistingEntity && entitySchemaItem != null
					&& entitySchemaItem.PackageUId == packageUId) {
				entitySchemaManager.TryDesignItem(UserConnection.Current, entitySchemaItem.RealUId,
					out entitySchemaItem);
				entitySchemaItem.Id = entitySchemaManager.GetItemIdByUId(entitySchemaItem.RealUId);
				entitySchemaItem.Instance.Id = entitySchemaItem.Id;
			} else {
				string entityName = entitySchemaItem != null
					? generatedEntity.EntitySchemaName + appCode
					: generatedEntity.EntitySchemaName;
				entitySchemaItem = entitySchemaManager.CreateSchema(entityName, null, userConnection,
					Guid.NewGuid(), true);
				EntitySchemaAssignPackage(entitySchemaItem, packageUId);
				EntitySchemaAssignParent(entitySchemaItem, userConnection);
			}
			EntitySchema entitySchema = entitySchemaItem.Instance; 
			entitySchema.Caption = new LocalizableString(generatedEntity.Caption);
			generatedEntity.UId = entitySchemaItem.RealUId;
			foreach (GeneratedEntityColumn column in generatedEntity.Columns) {
				if (entitySchema.Columns.Any(e => e.Name == column.Name)) {
					continue;
				}
				if (!SaveReferenceEntitySchema(column, packageUId, appCode, allGenEntities, savedEntitySchemaUIds)) {
					continue;
				}
				EntitySchemaColumn entitySchemaColumn = CreateEntitySchemaColumn(column.Name,
					(DataValueType)column.Type, column.Caption, column.ReferenceSchemaName, column.DefaultValue,
					entitySchema.UId);
				entitySchema.Columns.Add(entitySchemaColumn);
			}
			SetPrimaryDisplayColumn(entitySchema, generatedEntity);
			RemoveExistingNameColumnIfNeeded(entitySchema);
			SetEventsProcessSchemaToEntitySchema(entitySchema, userConnection);
			SaveEntitySchemaItem(entitySchemaItem, userConnection);
			savedEntitySchemaUIds.Add(entitySchema.UId);
		}

		private bool SaveReferenceEntitySchema(GeneratedEntityColumn column, Guid packageUId, string appCode,
				List<GeneratedEntity> allGenEntities, HashSet<Guid> savedEntitySchemaUIds) {
			if (column.ReferenceSchemaName.IsNullOrEmpty()) {
				return true;
			}
			GeneratedEntity refGenEntity = allGenEntities.Find(e => e.EntitySchemaName == column.ReferenceSchemaName);
			if (refGenEntity == null) {
				return false;
			}
			if (savedEntitySchemaUIds.Contains(refGenEntity.UId)) {
				return true;
			}
			if (refGenEntity.UId.IsNotEmpty()) {
				_log.Warn($"Cyclic reference detected while trying to create column {column.Name}. " +
					$"Referenced entity: {refGenEntity.EntitySchemaName}");
				return false;
			}
			SaveGeneratedEntitySchema(refGenEntity, packageUId, appCode, allGenEntities, savedEntitySchemaUIds);
			return true;
		}

		private static Guid CreateActivityReplacingObject(string columnReferenceSchemaName, Guid packageUId,
				HashSet<Guid> savedEntitySchemaUIds) {
			UserConnection userConnection = UserConnection.Current;
			EntitySchemaManager entitySchemaManager = userConnection.EntitySchemaManager;
			ISchemaManagerItem<EntitySchema> designItem = entitySchemaManager.CreateDesignSchema(userConnection,
				_activitySchemaUId, packageUId, true);
			EntitySchemaAssignPackage(designItem, packageUId);
			EntitySchema designSchema = designItem.Instance;
			EntitySchemaColumn entitySchemaColumn = CreateEntitySchemaColumn(columnReferenceSchemaName,
				DataValueType.Lookup, columnReferenceSchemaName, columnReferenceSchemaName, null, designSchema.UId);
			designSchema.Columns.Add(entitySchemaColumn);
			SaveEntitySchemaItem(designItem, userConnection);
			savedEntitySchemaUIds.Add(designItem.RealUId);
			return entitySchemaColumn.UId;
		}

		private static void CreateNewEntityConnection(Guid columnUId) {
			UserConnection userConnection = UserConnection.Current;
			EntitySchema entityConnectionSchema =
				userConnection.EntitySchemaManager.GetInstanceByName("EntityConnection");
			Entity entityConnection = entityConnectionSchema.CreateEntity(userConnection);
			entityConnection.SetDefColumnValues();
			entityConnection.SetColumnValue("Id", Guid.NewGuid());
			entityConnection.SetColumnValue("SysEntitySchemaUId", _activitySchemaUId);
			entityConnection.SetColumnValue("ColumnUId", columnUId);
			entityConnection.Save(false);
			userConnection.SessionCache.Remove("EntityConnectionColumns");
		}

		#endregion

		#region Methods: Public

		public void SaveEntities(GeneratedEntity section, Guid packageUId, string appCode) {
			var allEntities = new List<GeneratedEntity> { section };
			allEntities.AddRange(section.Lookups);
			allEntities.AddRange(section.Details);
			section.TryFindExistingEntity = true;
			var savedEntitySchemaUIds = new HashSet<Guid>();
			foreach (GeneratedEntity entity in section.Lookups) {
				SaveGeneratedEntitySchema(entity, packageUId, appCode, allEntities, savedEntitySchemaUIds);
			}
			SaveGeneratedEntitySchema(section, packageUId, appCode, allEntities, savedEntitySchemaUIds);
			foreach (GeneratedEntity entity in section.Details) {
				SaveGeneratedEntitySchema(entity, packageUId, appCode, allEntities, savedEntitySchemaUIds);
			}
			if (Features.GetIsEnabled<GenAIFeatures.GenerateNextSteps>()) {
				Guid columnUId = CreateActivityReplacingObject(section.EntitySchemaName, packageUId,
					savedEntitySchemaUIds);
				CreateNewEntityConnection(columnUId);
			}
			var packageInstallUtilities = new PackageInstallUtilities(UserConnection.Current);
			packageInstallUtilities.SaveSchemaDBStructure(savedEntitySchemaUIds, false);
		}

		#endregion

	}

	#endregion

}

