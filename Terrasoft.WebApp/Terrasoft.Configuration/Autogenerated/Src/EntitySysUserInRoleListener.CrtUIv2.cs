 namespace Terrasoft.Configuration
{
	using System;
	using Core;
	using Core.Entities;
	using Core.Entities.AsyncOperations;
	using Core.Entities.AsyncOperations.Interfaces;
	using Core.Entities.Events;
	using Core.Factories;
	using Core.OrgStructure;
	using Terrasoft.Common.Messaging;
	using Terrasoft.Core.ClientCache;
	using Terrasoft.Core.FeatureToggling;
	using Constants = Terrasoft.Core.DB.ClientCache.Constants;

	#region Class: EntitySysUserInRoleListener

	[EntityEventListener(SchemaName = "SysUserInRole")]
	public class EntitySysUserInRoleListener : BaseEntityEventListener
	{

		#region Methods: Private

		private static Guid GetSysUserId(Entity entity) {
			const string columnName = "SysUserId";
			const string schemaColumnName = "SysUser";
			if (!entity.IsColumnValueLoaded(columnName)) {
				var tempEntity = entity.Schema.CreateEntity(entity.UserConnection);
				tempEntity.FetchFromDB(entity.Schema.GetPrimaryColumnName(), entity.PrimaryColumnValue,
					new[] { schemaColumnName });
				entity.LoadColumnValue(columnName, tempEntity.GetColumnValue(columnName));
			}
			return entity.GetTypedColumnValue<Guid>(columnName);
		}

		private static void ExecuteActualizeAsyncOperation(Entity entity) {
			if (!Terrasoft.Core.GlobalAppSettings.EnableImediateActualizeSysAdminUnitInRole) {
				return;
			}
			var asyncExecutor = ClassFactory.Get<IEntityEventAsyncExecutor>(
				new ConstructorArgument("userConnection", entity.UserConnection));
			if (entity.UserConnection.GetIsFeatureEnabled("EnableRoleActualizationForSingleUserOnly")) {
				var operationArgs = new ActualizeSysAdminUnitInRoleByUserIdAsyncOperationArgs(entity, null) {
					UserId = GetSysUserId(entity)
				};
				asyncExecutor.ExecuteAsync<ActualizeSysAdminUnitInRoleByUserIdAsyncOperation>(operationArgs);
			} else {
				var operationArgs = new EntityEventAsyncOperationArgs(entity, null);
				asyncExecutor.ExecuteAsync<ActualizeSysAdminUnitInRoleAsyncOperation>(operationArgs);
			}
		}

		private void ClearCaches() {
			MessageHub.Instance.Publish(new FeatureChangedNotification(null, null, null));
			var clientCacheStore = ClassFactory.Get<IClientCacheStore>();
			clientCacheStore.SetHashValue(Constants.RightsCacheHashKey, Guid.NewGuid().ToString("N"));

		}

		#endregion

		#region Methods: Public

		public override void OnInserted(object sender, EntityAfterEventArgs e) {
			base.OnInserted(sender, e);
			var entity = (Entity)sender;
			ExecuteActualizeAsyncOperation(entity);
			ClearCaches();
		}

		public override void OnDeleted(object sender, EntityAfterEventArgs e) {
			base.OnDeleted(sender, e);
			var entity = (Entity)sender;
			ExecuteActualizeAsyncOperation(entity);
			ClearCaches();
		}

		#endregion

	}

	#endregion

}

