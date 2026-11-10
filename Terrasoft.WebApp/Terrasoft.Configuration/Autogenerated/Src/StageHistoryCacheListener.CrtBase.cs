namespace Terrasoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Entities.Events;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Store;

	#region Class: StageHistoryCacheListener

	[EntityEventListener(IsGlobal = true)]
	public class StageHistoryCacheListener : BaseEntityEventListener
	{

		#region Fields: Private

		private UserConnection _userConnection;

		#endregion

		#region Methods: Private

		private void ClearStageLookupCache(Entity entity) {
			_userConnection = entity.UserConnection;
			ISysModuleStageHistoryRepository stageHistoryRepository = 
				ClassFactory.Get<ISysModuleStageHistoryRepository>(
				new ConstructorArgument("userConnection", _userConnection));
			IEnumerable<StageHistorySetting> stageHistorySettings = stageHistoryRepository.GetAll();
			var currentSchemaSetting = stageHistorySettings
				.FirstOrDefault(setting => setting.StageSchemaUId == entity.Schema.UId);
			if (currentSchemaSetting != null) {
				ClearStageSchemaCache(currentSchemaSetting);
			}
		}

		private void ClearStageSchemaCache(StageHistorySetting currentSchemaSetting) {
			string schemaName = currentSchemaSetting.StageSchemaName;
			_userConnection.ApplicationCache.ExpireGroup(schemaName);
		}

		#endregion

		#region Methods: Public

		public override void OnSaving(object sender, EntityBeforeEventArgs e) {
			base.OnSaving(sender, e);
			var entity = (Entity)sender;
			ClearStageLookupCache(entity);
		}

		public override void OnDeleting(object sender, EntityBeforeEventArgs e) {
			base.OnDeleting(sender, e);
			var entity = (Entity)sender;
			ClearStageLookupCache(entity);
		}

		#endregion
	}

	#endregion
} 
