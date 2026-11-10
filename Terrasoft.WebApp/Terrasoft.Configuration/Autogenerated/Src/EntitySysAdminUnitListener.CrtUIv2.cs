namespace Terrasoft.Configuration
{
	using System;
	using System.Linq;
	using Core;
	using Core.Entities;
	using Core.Entities.AsyncOperations;
	using Core.Entities.AsyncOperations.Interfaces;
	using Core.Entities.Events;
	using Core.Factories;
	using Core.OrgStructure;

	#region Class: ActualizeSysAdminUnitInRoleByUserIdAsyncOperation

	/// <summary>
	/// Actualizes roles for a specific user by calling
	/// <see cref="OrgStructureManager.ActualizeSysAdminUnitInRoleByUserId"/>.
	/// The caller is responsible for ensuring the entity is a user type.
	/// </summary>
	public class ActualizeSysAdminUnitInRoleByUserIdAsyncOperation : IEntityEventAsyncOperation
	{

		#region Methods: Public

		/// <inheritdoc />
		public void Execute(UserConnection userConnection, EntityEventAsyncOperationArgs arguments) {
			IOrgStructureManager orgStructureManager = new OrgStructureManager(userConnection);
			if (arguments is ActualizeSysAdminUnitInRoleByUserIdAsyncOperationArgs roleArgs
					&& roleArgs.UserId != Guid.Empty) {
				orgStructureManager.ActualizeSysAdminUnitInRoleByUserId(roleArgs.UserId);
				return;
			}
			orgStructureManager.ActualizeSysAdminUnitInRole();
		}

		#endregion

	}

	#endregion

	#region Class: EntitySysAdminUnitListener

	[EntityEventListener(SchemaName = "SysAdminUnit")]
	public class EntitySysAdminUnitListener : BaseEntityEventListener
	{

		#region Methods: Private

		private static bool IsUserSysAdminUnitType(int sysAdminUnitTypeValue) {
			return sysAdminUnitTypeValue == (int)Core.DB.SysAdminUnitType.User
				|| sysAdminUnitTypeValue == (int)Core.DB.SysAdminUnitType.SelfServicePortalUser
				|| sysAdminUnitTypeValue == (int)Core.DB.SysAdminUnitType.TechnicalUser;
		}

		private static int GetSysAdminUnitTypeValue(Entity entity) {
			const string columnName = "SysAdminUnitTypeValue";
			if (!entity.IsColumnValueLoaded(columnName)) {
				var tempEntity = entity.Schema.CreateEntity(entity.UserConnection);
				tempEntity.FetchFromDB(entity.Schema.GetPrimaryColumnName(), entity.PrimaryColumnValue,
					new[] { columnName });
				entity.LoadColumnValue(columnName, tempEntity.GetColumnValue(columnName));
			}
			return entity.GetTypedColumnValue<int>(columnName);
		}

		private static void ExecuteActualizeAsyncOperation(Entity entity) {
			if (!GlobalAppSettings.EnableImediateActualizeSysAdminUnitInRole) {
				return;
			}
			var asyncExecutor = ClassFactory.Get<IEntityEventAsyncExecutor>(
				new ConstructorArgument("userConnection", entity.UserConnection));
			int sysAdminUnitTypeValue = GetSysAdminUnitTypeValue(entity);
			if (entity.UserConnection.GetIsFeatureEnabled("EnableRoleActualizationForSingleUserOnly")
					&& IsUserSysAdminUnitType(sysAdminUnitTypeValue)) {
				var operationArgs = new ActualizeSysAdminUnitInRoleByUserIdAsyncOperationArgs(entity, null) {
					UserId = entity.GetTypedColumnValue<Guid>("Id")
				};
				asyncExecutor.ExecuteAsync<ActualizeSysAdminUnitInRoleByUserIdAsyncOperation>(operationArgs);
			} else {
				var operationArgs = new EntityEventAsyncOperationArgs(entity, null);
				asyncExecutor.ExecuteAsync<ActualizeSysAdminUnitInRoleAsyncOperation>(operationArgs);
			}
		}

		#endregion

		#region Methods: Public

		public override void OnInserted(object sender, EntityAfterEventArgs e) {
			base.OnInserted(sender, e);
			var entity = (Entity)sender;
			ExecuteActualizeAsyncOperation(entity);
		}

		public override void OnDeleted(object sender, EntityAfterEventArgs e) {
			base.OnDeleted(sender, e);
			var entity = (Entity)sender;
			ExecuteActualizeAsyncOperation(entity);
		}

		public override void OnUpdated(object sender, EntityAfterEventArgs e) {
			base.OnUpdated(sender, e);
			if (e.ModifiedColumnValues.Any(x => x.Name == "SysAdminUnitTypeValue" || x.Name == "ConnectionType" ||
					x.Name == "ParentRoleId")) {
				var entity = (Entity)sender;
				ExecuteActualizeAsyncOperation(entity);
			}
		}

		#endregion

	}

	#endregion

}

