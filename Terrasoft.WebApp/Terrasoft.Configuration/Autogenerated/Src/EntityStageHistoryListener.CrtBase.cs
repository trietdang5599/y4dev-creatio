namespace Terrasoft.Configuration
{
	using System;
	using Core;
	using Core.Entities;
	using Core.Entities.AsyncOperations;
	using Core.Entities.AsyncOperations.Interfaces;
	using Core.Entities.Events;
	using Core.Factories;
	using Terrasoft.Common;
	using Terrasoft.Core.DcmProcess;

	#region Class: EntityStageHistoryListener

	[EntityEventListener(IsGlobal = true)]
	public class EntityStageHistoryListener : BaseEntityEventListener
	{

		public GetEntityRunningProcessResult ActiveDcm { get; set; }

		#region Methods: Private
		
		private static ISysModuleStageHistoryRepository GetHistorySettingsRepository(UserConnection userConnection) {
			return ClassFactory
				.Get<ISysModuleStageHistoryRepository>(new ConstructorArgument("userConnection", userConnection));
		}

		private static bool IsStagedEntity(Entity entity, StageHistorySetting setting) {
			return setting?.IsActive ?? false;
		}
		
		private static bool IsChangedColumn(EntityAfterEventArgs entityAfterEventArgs, StageHistorySetting setting) {
			var column = entityAfterEventArgs?.ModifiedColumnValues?.FindByName(setting.StageColumnName + "Id");
			return column != null;
		}
		
		private static StageHistorySetting GetStageHistorySetting(Entity entity) {
			var historySettingsRepository = GetHistorySettingsRepository(entity.UserConnection);
			var setting = historySettingsRepository.Find(entity.Schema.UId);
			return setting;
		}

		private void ExecuteStageHistoryAsyncOperation(EventArgs e, Entity entity) {
			var operationArgs = new EntityEventAsyncOperationArgs(entity, e);
			if (entity.UserConnection.GetIsFeatureEnabled("DisableAsyncStageSave")) {
				var saveStageHistorySyncOperation = CreateOperation();
				saveStageHistorySyncOperation.Execute(entity.UserConnection, operationArgs);
			} else {
				var asyncExecutor =
					ClassFactory.Get<IEntityEventAsyncExecutor>(new ConstructorArgument("userConnection", entity.UserConnection));
				asyncExecutor.ExecuteAsync<SaveStageHistoryAsyncOperation>(operationArgs);
			}
		}

		private SaveStageHistoryAsyncOperation CreateOperation() {
			var saveStageHistorySyncOperation = ClassFactory.Get<SaveStageHistoryAsyncOperation>();
			saveStageHistorySyncOperation.DcmSchemaUId = ActiveDcm?.UId ?? Guid.Empty;
			return saveStageHistorySyncOperation;
		}

		private void LoadActiveDcm(EventArgs e, Entity entity) {
			var operationArgs = new EntityEventAsyncOperationArgs(entity, e);
			var getEntityRunningProcessAction = ClassFactory.Get<IGetEntityRunningProcess>();
			var entitySchema = entity.UserConnection.EntitySchemaManager.GetInstanceByName(operationArgs.EntitySchemaName);
			ActiveDcm = getEntityRunningProcessAction.GetEntityRunningProcess(entity.UserConnection, new GetEntityRunningProcessRequest {
				RecordId = operationArgs.EntityId,
				EntitySchemaUId = entitySchema.UId
			});
		}


		#endregion
		
		#region Methods: Public

		/// <summary>Handles entity Saving event.</summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:Terrasoft.Core.Entities.EntityBeforeEventArgs" /> instance containing the event data.</param>
		public override void OnSaving(object sender, EntityBeforeEventArgs e) {
			base.OnSaving(sender, e);
			var entity = (Entity) sender;
			if (!entity.UserConnection.GetIsFeatureEnabled("EntityStageHistoryJournaling") || !entity.IsColumnValueLoaded("Id")) {
				return;
			}
			var setting = GetStageHistorySetting(entity);
			if (IsStagedEntity(entity, setting)) {
				LoadActiveDcm(e, entity);
			}
		}

		public override void OnSaved(object sender, EntityAfterEventArgs e) {
			base.OnSaved(sender, e);
			var entity = (Entity) sender;
			if (!entity.UserConnection.GetIsFeatureEnabled("EntityStageHistoryJournaling")|| !entity.IsColumnValueLoaded("Id")) {
				return;
			}
			var setting = GetStageHistorySetting(entity);
			if (IsStagedEntity(entity, setting) && IsChangedColumn(e, setting)) {
				if (ActiveDcm?.UId.IsEmpty() == true) {
					LoadActiveDcm(e, entity);
				}
				ExecuteStageHistoryAsyncOperation(e, entity);
			}
		}

		#endregion
		
	}

	#endregion
	
}

