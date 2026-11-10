namespace Terrasoft.Configuration
{
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Entities.Events;
	using SystemSettings = Terrasoft.Core.Configuration.SysSettings;

	#region Class: NotifySettingsByUserEventListener

	[EntityEventListener(SchemaName = "NotifySettingsByUser")]
	public class NotifySettingsByUserEventListener : BaseEntityEventListener
	{

		#region Methods: Private

		private static void UpdateSysSetting(Entity notifySettingEntity) {
			var settingCode = notifySettingEntity.GetTypedColumnValue<string>("Code");
			var settingValue = notifySettingEntity.GetTypedColumnValue<bool>("State");
			SystemSettings.SetValue(notifySettingEntity.UserConnection, settingCode, settingValue);
		}

		#endregion

		#region Methods: Public


		/// <inheritdoc />
		public override void OnSaving(object sender, EntityBeforeEventArgs e) {
			base.OnSaving(sender, e);
			UpdateSysSetting((Entity)sender);
		}

		#endregion

	}

	#endregion

}

