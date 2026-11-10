namespace Terrasoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Core;
	using Core.Entities;
	using Core.Entities.AsyncOperations;
	using Core.Entities.AsyncOperations.Interfaces;
	using Core.Factories;
	using Terrasoft.Common;
	using Terrasoft.Core.DcmProcess;

	#region Class: SaveStageHistoryAsyncOperation

	/// <inheritdoc />
	public class SaveStageHistoryAsyncOperation : IEntityEventAsyncOperation
	{

		public Guid DcmSchemaUId { get; set; }

		#region Methods: Private

		private IEntityStageManagerV2 GetEntityStageManager(UserConnection userConnection,
				StageHistorySetting setting, IGetRepository<CommonStageData> stageRepository) {
			var entityInStageRepository = ClassFactory.Get<ICommonEntityInStageRepository<EntityInHistoricalStage>>(
				new ConstructorArgument("userConnection", userConnection),
				new ConstructorArgument("stageHistorySetting", setting));
			return ClassFactory.Get<IEntityStageManagerV2>(new ConstructorArgument("userConnection", userConnection),
				new ConstructorArgument("entityStageRepository", stageRepository),
				new ConstructorArgument("entityInStageRepository", entityInStageRepository),
				new ConstructorArgument("stageHistorySetting", setting));
		}

		private ISysModuleStageHistoryRepository GetHistorySettingsRepository(UserConnection userConnection) {
			return ClassFactory
				.Get<ISysModuleStageHistoryRepository>(new ConstructorArgument("userConnection", userConnection));
		}

		private StageHistorySetting GetActiveStageHistorySetting(UserConnection userConnection, Guid schemaUId) {
			var historySettingsRepository = GetHistorySettingsRepository(userConnection);
			var historySetting = historySettingsRepository.Find(schemaUId);
			if (historySetting == null) {
				return null;
			}
			return historySetting.IsActive ? historySetting : null;
		}

		private IEnumerable<EntityColumnValue> GetEntityColumnOldValues(UserConnection userConnection,
				EntityEventAsyncOperationArgs arguments) {
			var columnValues = arguments.EntityColumnValues.Select(e => {
				arguments.OldEntityColumnValues.TryGetValue(e.Key, out var oldValue);
				return new EntityColumnValue(userConnection) {
					Value = e.Value,
					OldValue = oldValue,
					Name = e.Key,
					IsLoaded = true
				};
			});
			return columnValues;
		}

		private void FillEntityColumnValues(Entity entity, EntityEventAsyncOperationArgs arguments) {
			foreach (var column in arguments.EntityColumnValues) {
				entity.SetColumnValue(column.Key, column.Value);
			}
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc />
		public virtual void Execute(UserConnection userConnection, EntityEventAsyncOperationArgs arguments) {
			var entitySchema = userConnection.EntitySchemaManager.GetInstanceByName(arguments.EntitySchemaName);
			var setting = GetActiveStageHistorySetting(userConnection, entitySchema.UId);
			if (setting == null || entitySchema == null) {
				return;
			}
			IGetRepository<CommonStageData> stageRepository = null;
			if (DcmSchemaUId.IsNotEmpty() && userConnection.GetIsFeatureEnabled("SynchronizeStagesByDcm")) {
				var dcmSchema = userConnection.DcmSchemaManager.GetInstanceByUId(DcmSchemaUId);
				stageRepository = ClassFactory.Get<IGetRepository<CommonStageData>>("DcmStageGetRepository",
					new ConstructorArgument("userConnection", userConnection),
					new ConstructorArgument("dcmSchema", dcmSchema));
			} else {
				var entityStageRepository = ClassFactory.Get<IGetRepository<CommonStageData>>("StageGetRepository",
					new ConstructorArgument("userConnection", userConnection),
					new ConstructorArgument("stageHistorySetting", setting));
				stageRepository = ClassFactory.Get<CacheGetRepositoryProxy<CommonStageData>>(
					new ConstructorArgument("userConnection", userConnection),
					new ConstructorArgument("repository", entityStageRepository),
					new ConstructorArgument("schemaName", setting.StageSchemaName));
			}
			var entity = entitySchema.CreateEntity(userConnection);
			FillEntityColumnValues(entity, arguments);
			entity.SetColumnValue(entitySchema.PrimaryColumn.Name, arguments.EntityId);
			var columnOldValues = GetEntityColumnOldValues(userConnection, arguments);
			var stageManager = GetEntityStageManager(userConnection, setting, stageRepository);
			stageManager.SynchronizeStage(entity, columnOldValues);
		}

		#endregion

	}

	#endregion

}

