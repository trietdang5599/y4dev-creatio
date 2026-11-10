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

	#region Class: ActualizeSysAdminUnitInRoleAsyncOperation

	/// <inheritdoc />
	public class ActualizeSysAdminUnitInRoleAsyncOperation : IEntityEventAsyncOperation
	{

		#region Methods: Public

		/// <inheritdoc />
		public void Execute(UserConnection userConnection, EntityEventAsyncOperationArgs arguments) {
			Terrasoft.Core.OrgStructure.IOrgStructureManager orgStructureManager = new OrgStructureManager(userConnection);
			orgStructureManager.ActualizeSysAdminUnitInRole();
		}

		#endregion

	}

	#endregion

	#region Class: ChangeOrgStructureListener

	[EntityEventListener(SchemaName = "SysAdminUnitGrantedRight")]
	[EntityEventListener(SchemaName = "SysFuncRoleInOrgRole")]
	public class ChangeOrgStructureListener : BaseEntityEventListener
	{

		#region Methods: Private

		private static void ExecuteActualizeSysAdminUnitInRoleAsyncOperation(Entity entity) {
			if (!Terrasoft.Core.GlobalAppSettings.EnableImediateActualizeSysAdminUnitInRole) {
				return;
			}
			var asyncExecutor = ClassFactory.Get<IEntityEventAsyncExecutor>(
				new ConstructorArgument("userConnection", entity.UserConnection));
			var operationArgs = new EntityEventAsyncOperationArgs(entity, null);
			asyncExecutor.ExecuteAsync<ActualizeSysAdminUnitInRoleAsyncOperation>(operationArgs);
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
			ExecuteActualizeSysAdminUnitInRoleAsyncOperation(entity);
			ClearCaches();
		}

		public override void OnDeleted(object sender, EntityAfterEventArgs e) {
			base.OnDeleted(sender, e);
			var entity = (Entity)sender;
			ExecuteActualizeSysAdminUnitInRoleAsyncOperation(entity);
			ClearCaches();
		}

		#endregion

	}

	#endregion

}

