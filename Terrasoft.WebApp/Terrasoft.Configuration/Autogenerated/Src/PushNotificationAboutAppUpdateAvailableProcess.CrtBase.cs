namespace Terrasoft.Core.Process
{

	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Data;
	using System.Drawing;
	using System.Globalization;
	using System.Linq;
	using System.Text;
	using Terrasoft.Common;
	using Terrasoft.Configuration;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;

	#region Class: PushNotificationAboutAppUpdateAvailableProcessMethodsWrapper

	/// <exclude/>
	public class PushNotificationAboutAppUpdateAvailableProcessMethodsWrapper : ProcessModel
	{

		public PushNotificationAboutAppUpdateAvailableProcessMethodsWrapper(Process process)
			: base(process) {
			AddScriptTaskMethod("PushNotificationsScriptTaskExecute", PushNotificationsScriptTaskExecute);
		}

		#region Methods: Private

		private bool PushNotificationsScriptTaskExecute(ProcessExecutingContext context) {
			SendAppUpdatesAvailableNotifications();
			return true;
		}

			private Guid GetInstalledAppEntitySchemaUId() =>
				UserConnection.SystemEntitySchemaManager.GetItemByName("SysInstalledApp").UId;
			
			private Guid GetPushNotificationAboutAppUpdateAvailableProcessUId() => UserConnection.ProcessSchemaManager
				.GetItemByName("PushNotificationAboutAppUpdateAvailableProcess").UId;
			
			private RemindingUtilities GetRemindingUtilities() => ClassFactory.Get<RemindingUtilities>();
			
			private List<(Guid ContactId, string CultureName)> GetContactsToReceiveReminding() {
				var sysAdminUsers = Get<ICompositeObjectList<ICompositeObject>>("SystemAdministratorUsers");
				List<Guid> sysAdminIdsList = sysAdminUsers
					.Select(sysAdminUser => {
						sysAdminUser.TryGetValue("SysAdminUnit", out Guid sysAdminUserId);
						return sysAdminUserId;
					})
					.Where(sysAdminUnitId => sysAdminUnitId.IsNotEmpty())
					.ToList();
				var select = (Select)new Select(UserConnection)
						.Column("sau", "ContactId")
						.Column("sc", "Name").As("CultureName")
					.From("SysAdminUnit").As("sau")
					.InnerJoin("SysCulture").As("sc").On("sc", "Id").IsEqual("sau", "SysCultureId")
					.Where("sau", "Id").In(Column.Parameters(sysAdminIdsList));
				var result = new List<(Guid ContactId, string CultureName)>();
				select.ExecuteReader(reader => {
					result.Add((reader.GetColumnValue<Guid>("ContactId"), reader.GetColumnValue<string>("CultureName")));
				});
				return result;
			}
			
			private string GetLczString(string parameterName, string cultureName) {
				string localizableStringName = $"Parameters.{parameterName}.Value";
				var result = new LocalizableString(UserConnection.Workspace.ResourceStorage,
					"PushNotificationAboutAppUpdateAvailableProcess", localizableStringName);
				CultureInfo cultureInfo = CultureInfo.GetCultureInfo(cultureName);
				return result.HasCultureValue(cultureInfo) ? result.GetCultureValue(cultureInfo) : (string)result;
			}
			
			private string GetRemindingDescription(bool isSingleAppUpdateAvailable, string installedAppName,
					string cultureName) {
				string descriptionParameterName = isSingleAppUpdateAvailable
					? "SingleAppUpdateRemindingDescription"
					: "MultiAppUpdateRemindingDescription";
				string descriptionParameterValue = GetLczString(descriptionParameterName, cultureName);
				return isSingleAppUpdateAvailable
					? string.Format(descriptionParameterValue, installedAppName)
					: descriptionParameterValue;
			}
			
			private void CreateRemindings(IEnumerable<RemindingConfig> remindingConfigs) {
				RemindingUtilities remindingUtilities = GetRemindingUtilities();
				foreach (RemindingConfig remindingConfig in remindingConfigs) {
					remindingUtilities.CreateReminding(UserConnection, remindingConfig);
				}
			}
			
			private void SendAppUpdatesAvailableNotifications() {
				var appsToNotifyAbout = Get<ICompositeObjectList<ICompositeObject>>("InstalledAppsToNotifyAbout");
				ICompositeObject firstAppToNotifyAbout = appsToNotifyAbout.First();
				List<(Guid ContactId, string CultureName)> contactsToReceiveReminding = GetContactsToReceiveReminding();
				Guid sysInstalledAppSchemaUId = GetInstalledAppEntitySchemaUId();
				bool isSingleUpdateAvailable = appsToNotifyAbout.Count == 1;
				firstAppToNotifyAbout.TryGetValue("Id", out Guid installedAppId);
				firstAppToNotifyAbout.TryGetValue("MarketplaceAppId", out string marketplaceAppId);
				firstAppToNotifyAbout.TryGetValue("Name", out string installedAppName);
				IEnumerable<RemindingConfig> remindingConfigs = contactsToReceiveReminding.Select((contact) =>
					new RemindingConfig(sysInstalledAppSchemaUId) {
						AuthorId = UserConnection.CurrentUser.ContactId,
						ContactId = contact.ContactId,
						SubjectId = installedAppId,
						Description = GetRemindingDescription(isSingleUpdateAvailable, installedAppName, contact.CultureName),
						RemindTime = DateTime.UtcNow,
						LoaderId = GetPushNotificationAboutAppUpdateAvailableProcessUId(),
						Config = new Dictionary<string, object> {
							{ "isSingleUpdateAvailable", isSingleUpdateAvailable },
							{ "marketplaceAppId", marketplaceAppId }
						}
					});
				CreateRemindings(remindingConfigs);
			}

		#endregion

	}

	#endregion

}

