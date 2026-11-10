namespace Terrasoft.Configuration
{
	using System;
	using Terrasoft.AppFeatures;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using SystemSettings = Core.Configuration.SysSettings;

	#region Class: BaseWorkplaceByUITypeQueryExecutor
	[DefaultBinding(typeof(IEntityQueryExecutor), Name = "NotifySettingsByUserQueryExecutor")]
	public class NotifySettingsByUserQueryExecutor : BaseQueryExecutor, IEntityQueryExecutor
	{

		#region Fields: Private

		private string _sysSettingsId;
		private string _sysSettingsCode;
		private string _sysSettingsName;

		#endregion

		#region Constructors: Protected

		public NotifySettingsByUserQueryExecutor(UserConnection userConnection)
			: base(userConnection, "NotifySettingsByUser") { }

		#endregion

		#region Methods: Private

		private EntityCollection GetSettingsInFolderEntities(EntitySchemaQuery initialEsq) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SysSettingsInFolder") {
				UseAdminRights = false
			};
			_sysSettingsId = esq.AddColumn("SysSettings.Id").Name;
			_sysSettingsCode = esq.AddColumn("SysSettings.Code").Name;
			_sysSettingsName = esq.AddColumn("SysSettings.Name").Name;
			QueryFilterInfo filterInfo = initialEsq.Filters.ParseFilters();
			if (GetIsPrimaryColumnValueFilter(filterInfo, out Guid sysSettingsId)) {
				esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "SysSettings.Id",
					sysSettingsId));
			}
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Folder",
				PopupNotificationsConsts.SysSettingsFolderId));
			return esq.GetEntityCollection(UserConnection);
		}

		private Entity CreateEntityFromSettings(Entity settingsEntity) {
			var entity = EntitySchema.CreateEntity(UserConnection);
			var sysSettingCode = settingsEntity.GetTypedColumnValue<string>(_sysSettingsCode);
			entity.SetColumnValue("Id", settingsEntity.GetTypedColumnValue<Guid>(_sysSettingsId));
			entity.SetColumnValue("Code", sysSettingCode);
			entity.SetColumnValue("Name", settingsEntity.GetTypedColumnValue<string>(_sysSettingsName));
			if (SystemSettings.TryGetValue(UserConnection, sysSettingCode, out object value)) {
				entity.SetColumnValue("State", value);
			}
			return entity;
		}

		#endregion

		#region Methods: Public

		public EntityCollection GetEntityCollection(EntitySchemaQuery esq) {
			var collection = new EntityCollection(UserConnection, EntitySchema);
			EntityCollection settingsInFolderEntities = GetSettingsInFolderEntities(esq);
			foreach (Entity settingsEntity in settingsInFolderEntities) {
				collection.Add(CreateEntityFromSettings(settingsEntity));
			}
			return collection;
		}

		#endregion

	}

	#endregion

}
