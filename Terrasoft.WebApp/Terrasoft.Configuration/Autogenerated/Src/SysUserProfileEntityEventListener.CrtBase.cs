namespace Terrasoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Security;
	using Creatio.FeatureToggling;
	using Newtonsoft.Json;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Entities.Events;
	using Terrasoft.UI.WebControls.ResourceHandlers;
	using CoreSysSettings = Core.Configuration.SysSettings;

	#region Class: SysUserProfileEntityEventListener

	/// <summary>
	/// Listener for 'SysUserProfile' entity events.
	/// </summary>
	[EntityEventListener(SchemaName = "SysUserProfile")]
	public class SysUserProfileEntityEventListener : BaseEntityEventListener
	{

		#region Constants: Private

		private const string SysUserProfileSchemaName = "SysUserProfile";

		#endregion

		#region Methods: Private

		private bool TryGetContact(Guid recordId, UserConnection userConnection, out Entity contact) {
			contact = GetEntityByName("Contact", userConnection);
			contact.UseAdminRights = false;
			return contact.FetchFromDB(recordId);
		}

		private bool TryGetSysAdminUnit(Guid recordId, UserConnection userConnection, out Entity sysAdminUnit) {
			sysAdminUnit = GetEntityByName("SysAdminUnit", userConnection);
			sysAdminUnit.UseAdminRights = false;
			return sysAdminUnit.FetchFromDB(recordId);
		}

		private Entity GetEntityByName(string entityName, UserConnection userConnection) {
			EntitySchemaManager entitySchemaManager = userConnection.EntitySchemaManager;
			var schema = entitySchemaManager.GetInstanceByName(entityName);
			Entity sysAdminUnit = schema.CreateEntity(userConnection);
			return sysAdminUnit;
		}

		private string GetTimeZoneCodeById(Guid recordId, UserConnection userConnection) {
			Entity timeZoneEntity = GetEntityByName("TimeZone", userConnection);
			if (timeZoneEntity.FetchFromDB(recordId)) {
				return timeZoneEntity.GetTypedColumnValue<string>("Code");
			}
			return string.Empty;
		}

		private void UpdateStringColumnValueIfChanged(Entity userProfile, Entity targetEntity, string profileColumnName,
				string targetColumnName) {
			var oldValue = targetEntity.GetTypedColumnValue<string>(targetColumnName);
			var newValue = userProfile.GetTypedColumnValue<string>(profileColumnName);
			if (!string.Equals(oldValue, newValue, StringComparison.InvariantCulture)) {
				CheckEntityEditColumnRights(profileColumnName, userProfile.UserConnection);
				targetEntity.SetColumnValue(targetColumnName, newValue);
			}
		}

		private void UpdateLookupColumnValueIfChanged(Entity userProfile, Entity targetEntity, string profileColumnName,
				string targetColumnName) {
			var newValue = userProfile.GetTypedColumnValue<Guid>(profileColumnName);
			UpdateLookupColumnValueIfChanged(targetEntity, targetColumnName, profileColumnName, newValue);
		}

		private void UpdateLookupColumnValueIfChanged(Entity targetEntity, string targetColumnName,
				string profileColumnName, Guid newValue) {
			var oldValue = targetEntity.GetTypedColumnValue<Guid>(targetColumnName);
			if (oldValue != newValue) {
				CheckEntityEditColumnRights(profileColumnName, targetEntity.UserConnection);
				if (newValue != Guid.Empty) {
					targetEntity.SetColumnValue(targetColumnName, newValue);
				} else {
					targetEntity.SetColumnValue(targetColumnName, null);
				}
			}
		}

		private void UpdateSysAdminUnitCulture(Entity userProfile, Entity sysAdminUnit) {
			var languageId = userProfile.GetTypedColumnValue<Guid>("LanguageId");
			var userConnection = userProfile.UserConnection;
			var cultureId = GetCultureIdByLanguage(languageId, userConnection);
			UpdateLookupColumnValueIfChanged(sysAdminUnit, "SysCultureId", "LanguageId", cultureId);
		}

		private Guid GetCultureIdByLanguage(Guid languageId, UserConnection userConnection) {
			var select = new Select(userConnection)
					.Column("Id")
				.From("SysCulture")
				.Where("LanguageId").IsEqual(Column.Parameter(languageId)) as Select;
			var cultureId = select.ExecuteScalar<Guid>();
			return cultureId;
		}

		private void CheckEntityEditColumnRights(string columnName, UserConnection userConnection) {
			var hasRights =
				userConnection.DBSecurityEngine.GetIsEntitySchemaColumnEditingAllowed(SysUserProfileSchemaName,
					columnName);
			if (!hasRights) {
				var errorMessage = string.Format(new LocalizableString("Terrasoft.Core",
					"Entity.Exception.NoRightFor.ColumnEdit"), columnName, SysUserProfileSchemaName);
				throw new SecurityException(errorMessage);
			}
		}

		private void SaveSysAdminUnitProperties(Entity userProfile, Entity sysAdminUnit) {
			sysAdminUnit.UseAdminRights = false;
			IReadOnlyDictionary<string, object> columns = userProfile.GetColumnValues();
			foreach (var column in columns) {
				switch (column.Key) {
					case "Username":
						UpdateStringColumnValueIfChanged(userProfile, sysAdminUnit, column.Key, "Name");
						break;
					case "Email":
						UpdateStringColumnValueIfChanged(userProfile, sysAdminUnit, column.Key, "Email");
						break;
					case "LanguageId":
						UpdateSysAdminUnitCulture(userProfile, sysAdminUnit);
						break;
					case "TimeZoneId":
						Guid timeZoneId = Guid.Empty;
						if (column.Value != null) {
							timeZoneId = (Guid)column.Value;
						}
						string newTimeZoneValue = GetTimeZoneCodeById(timeZoneId, userProfile.UserConnection);
						var oldTimeZoneValue = sysAdminUnit.GetTypedColumnValue<string>("TimeZoneId");
						if (!string.Equals(oldTimeZoneValue, newTimeZoneValue, StringComparison.InvariantCulture)) {
							CheckEntityEditColumnRights("TimeZoneId", userProfile.UserConnection);
							sysAdminUnit.SetColumnValue("TimeZoneId", newTimeZoneValue);
						}
						break;
					case "DateTimeFormatId":
						UpdateLookupColumnValueIfChanged(userProfile, sysAdminUnit, column.Key, "DateTimeFormatId");
						break;
					case "NumberFormatId":
						UpdateLookupColumnValueIfChanged(userProfile, sysAdminUnit, column.Key, "NumberFormatId");
						break;
					case "WeekFirstDayId":
						if (Features.GetIsEnabled("EnableWeekFirstDayConfiguration")) {
							UpdateLookupColumnValueIfChanged(userProfile, sysAdminUnit, column.Key, "WeekFirstDayId");
						}
						break;
				}
			}
			sysAdminUnit.Save(true, false);
		}

		private void SaveContactProperties(Entity userProfile, Entity contact) {
			contact.UseAdminRights = false;
			IReadOnlyDictionary<string, object> columns = userProfile.GetColumnValues();
			foreach (var column in columns) {
				switch (column.Key) {
					case "FullName":
						UpdateStringColumnValueIfChanged(userProfile, contact, column.Key, "Name");
						break;
					case "FirstName":
						UpdateStringColumnValueIfChanged(userProfile, contact, column.Key, "GivenName");
						break;
					case "MiddleName":
						UpdateStringColumnValueIfChanged(userProfile, contact, column.Key, "MiddleName");
						break;
					case "LastName":
						UpdateStringColumnValueIfChanged(userProfile, contact, column.Key, "Surname");
						break;
					case "PhotoId":
						UpdateLookupColumnValueIfChanged(userProfile, contact, column.Key, "PhotoId");
						break;
				}
			}
			contact.Save(true, false);
		}

		private void SaveSysProfileData(Entity userProfile) {
			SaveThemeFieldToSysProfile(userProfile);
			SaveEnablePopupsFieldToSysProfile(userProfile);
		}

		private void SaveThemeFieldToSysProfile(Entity userProfileEntity) {
			if (Features.GetIsEnabled("DisableChangeTheme")) {
				return;
			}
			IReadOnlyDictionary<string, object> columns = userProfileEntity.GetColumnValues();
			if (!columns.ContainsKey("Theme")) {
				return;
			}
			var userConnection = userProfileEntity.UserConnection;
			userConnection.LicHelper.CheckHasOperationLicense("CanCustomizeBranding");
			userConnection.DBSecurityEngine.CheckCanExecuteOperation("CanChangeOwnTheme");
			string theme = userProfileEntity.GetTypedColumnValue<string>("Theme");
			var userProfile = new UserProfile {
				Key = "Theme",
				Data = JsonConvert.SerializeObject(new { ThemeId = theme }),
			};
			UserProfileResourceHandler.SaveUserProfile(userConnection, userProfile);
		}

		private void SaveEnablePopupsFieldToSysProfile(Entity userProfileEntity) {
			IReadOnlyDictionary<string, object> columns = userProfileEntity.GetColumnValues();
			if (!columns.ContainsKey("EnablePopups")) {
				return;
			}
			bool enablePopups = userProfileEntity.GetTypedColumnValue<bool>("EnablePopups");
			var enablePopupsObject = new { Enabled = enablePopups };
			string data = JsonConvert.SerializeObject(enablePopupsObject);
			var userProfile = new UserProfile {
				Key = "DesktopPopupNotification",
				Data = data
			};
			var userConnection = userProfileEntity.UserConnection;
			UserProfileResourceHandler.SaveUserProfile(userConnection, userProfile);
		}

		private void SaveSysSettings(Entity userProfile) {
			IReadOnlyDictionary<string, object> columns = userProfile.GetColumnValues();
			foreach (var column in columns) {
				switch (column.Key) {
					case "OptimizeComponentsAccessibilityBehavior":
						CoreSysSettings.SetValue(userProfile.UserConnection, "OptimizeComponentsAccessibilityBehavior", column.Value);
						break;
					case "DisableAdvancedVisualEffects":
						CoreSysSettings.SetValue(userProfile.UserConnection, "DisableAdvancedVisualEffects", column.Value);
						break;
					case "UseAccessibleDesktopColor":
						CoreSysSettings.SetValue(userProfile.UserConnection, "UseAccessibleDesktopColor", column.Value);
						break;
					case "UseDefaultBrowserScrollbarStyles":
						CoreSysSettings.SetValue(userProfile.UserConnection, "UseDefaultBrowserScrollbarStyles", column.Value);
						break;
				}
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>Handles entity Saving event.</summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:Terrasoft.Core.Entities.EntityBeforeEventArgs" />
		/// instance containing the event data.</param>
		public override void OnSaving(object sender, EntityBeforeEventArgs e) {
			base.OnSaving(sender, e);
			var userProfile = (Entity)sender;
			var listeners = new Collection<ProcessSchemaListener>();
			userProfile.Process.SetPropertyValue("ProcessSchemaListeners", listeners);
			Guid sysAdminUnitId = userProfile.PrimaryColumnValue;
			UserConnection userConnection = userProfile.UserConnection;
			if (TryGetSysAdminUnit(sysAdminUnitId, userConnection, out Entity sysAdminUnit)) {
				var contactId = sysAdminUnit.GetTypedColumnValue<Guid>("ContactId");
				if (TryGetContact(contactId, userConnection, out Entity contact)) {
					SaveSysAdminUnitProperties(userProfile, sysAdminUnit);
					SaveContactProperties(userProfile, contact);
					SaveSysProfileData(userProfile);
					SaveSysSettings(userProfile);
				}
			}
		}

		#endregion

	}

	#endregion

}

