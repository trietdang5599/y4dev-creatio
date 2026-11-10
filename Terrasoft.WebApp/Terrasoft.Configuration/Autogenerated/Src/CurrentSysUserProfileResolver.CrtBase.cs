namespace Terrasoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Text;
	using Newtonsoft.Json;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using CoreSysSettings = Core.Configuration.SysSettings;
	using Terrasoft.Core.Entities;
	using Terrasoft.UI.WebControls.ResourceHandlers;
	using System.Globalization;
	using Creatio.FeatureToggling;

	#region Class: CurrentSysUserProfileResolver

	public class CurrentSysUserProfileResolver
	{

		#region Constants: Private

		private const string EnablePopupsKey = "DesktopPopupNotification";

		#endregion

		#region Fields: Private

		private readonly UserConnection _userConnection;

		private readonly string _entitySchemaName = "SysUserProfile";

		#endregion

		#region Properties: Protected

		protected UserConnection UserConnection => _userConnection;

		protected EntitySchemaManager EntitySchemaManager => UserConnection.EntitySchemaManager;

		#endregion

		#region Properties: Public

		public EntitySchema EntitySchema => EntitySchemaManager.GetInstanceByName(_entitySchemaName);

		#endregion

		#region Constructors: Public

		public CurrentSysUserProfileResolver(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private bool TryGetTimeZone(Dictionary<string, object> conditions, out Entity timeZoneEntity) {
			var timeZonesSchema = UserConnection.EntitySchemaManager.GetInstanceByName("TimeZone");
			timeZoneEntity = timeZonesSchema.CreateEntity(UserConnection);
			timeZoneEntity.UseAdminRights = false;
			return timeZoneEntity.FetchFromDB(conditions);
		}

		private string ConvertServerTimeZone(string timeZoneId) {
			timeZoneId.CheckArgumentNullOrEmpty(nameof(timeZoneId));
			string windowsOrIanaTimeZoneId = timeZoneId;
			const string posix = "posix/";
			if (timeZoneId.StartsWith(posix)) {
				windowsOrIanaTimeZoneId = timeZoneId.Substring(posix.Length, timeZoneId.Length - posix.Length);
			}
			const string easternEuropeanStandardTime = "Eastern European Standard Time";
			if (string.Compare(timeZoneId, easternEuropeanStandardTime, StringComparison.OrdinalIgnoreCase) == 0) {
				windowsOrIanaTimeZoneId = "E. Europe Standard Time";
			}
			const string newEuropeKyivTimeZone = "Europe/Kyiv";
			if (string.Compare(timeZoneId, newEuropeKyivTimeZone, StringComparison.OrdinalIgnoreCase) == 0) {
				windowsOrIanaTimeZoneId = "Europe/Kiev";
			}
			return windowsOrIanaTimeZoneId;
		}
		
		private void SetTimeZone(Entity entity, string timeZoneId) {
			Dictionary<string, object> timeZoneConditions;
			string displayValue = "";
			if (timeZoneId.IsNullOrEmpty()) {
				var timeZoneSysSettingValue = CoreSysSettings.GetDefValue(UserConnection, "DefaultTimeZone");
				if (timeZoneSysSettingValue != null && (Guid)timeZoneSysSettingValue != Guid.Empty) {
					timeZoneConditions = new Dictionary<string, object> {
						{ "Id", timeZoneSysSettingValue }
					};
				} else {
					TimeZoneInfo userTimeZoneInfo = entity.UserConnection.CurrentUser.TimeZone;
					displayValue = userTimeZoneInfo.DisplayName;
					timeZoneConditions = new Dictionary<string, object> {
						{ "Code", ConvertServerTimeZone(userTimeZoneInfo.StandardName) }
					};
				}
			} else {
				timeZoneConditions = new Dictionary<string, object> {
					{ "Code", timeZoneId }
				};
			}
			if (!TryGetTimeZone(timeZoneConditions, out Entity timeZoneEntity)) {
				entity.LoadColumnValue("TimeZoneName", displayValue);
				timeZoneConditions = new Dictionary<string, object> {
					{ "Code", "UTC" }
				};
				if (!TryGetTimeZone(timeZoneConditions, out timeZoneEntity)) {
					return;
				}
			} else {
				displayValue = timeZoneEntity.PrimaryDisplayColumnValue;
			}
			object valueId = timeZoneEntity.PrimaryColumnValue;
			entity.LoadColumnValue("TimeZoneId", valueId);
			entity.LoadColumnValue("TimeZoneName", displayValue);
		}

		private void FillFieldsFromContact(Entity resultEntity, Guid contactId) {
			EntitySchema contactSchema = _userConnection.EntitySchemaManager.FindInstanceByName("Contact");
			Entity contact = contactSchema.CreateEntity(_userConnection);
			contact.PrimaryColumnValue = contactId;
			contact.UseAdminRights = false;
			if (!contact.FetchFromDB(new[] { "Name", "GivenName", "MiddleName", "Surname", "Photo" }, false)) {
				return;
			}
			string fullName = contact.GetTypedColumnValue<string>("Name");
			string firstName = contact.GetTypedColumnValue<string>("GivenName");
			string middleName = contact.GetTypedColumnValue<string>("MiddleName");
			string lastName = contact.GetTypedColumnValue<string>("Surname");
			resultEntity.LoadColumnValue("FullName", fullName);
			resultEntity.LoadColumnValue("FirstName", firstName);
			resultEntity.LoadColumnValue("MiddleName", middleName);
			resultEntity.LoadColumnValue("LastName", lastName);
			var contactPhotoId = contact.GetTypedColumnValue<Guid>("PhotoId");
			if (contactPhotoId.IsNotEmpty() ) {
				resultEntity.SetColumnValue("PhotoId", contactPhotoId);	
			} else {
				resultEntity.SetColumnValue("PhotoId", null);
			}
			resultEntity.LoadColumnValue("ContactId", contactId);
			resultEntity.LoadColumnValue("ContactName", fullName);	
		}

		private void FillFieldsFromSysAdminUnit(Entity resultEntity, Guid currentUserId) {
			EntitySchema sysAdminUnitSchema = _userConnection.EntitySchemaManager.FindInstanceByName("SysAdminUnit");
			Entity sysAdminUnitEntity = sysAdminUnitSchema.CreateEntity(_userConnection);
			sysAdminUnitEntity.PrimaryColumnValue = currentUserId;
			sysAdminUnitEntity.UseAdminRights = false;
			string[] columnNamesToFetch = new[] {
				"Email",
				"Name",
				"SysCulture",
				"DateTimeFormat",
				"TimeZoneId",
				"NumberFormat",
				"WeekFirstDay"
			};
			if (!sysAdminUnitEntity.FetchFromDB(columnNamesToFetch, true)) {
				return;
			}
			resultEntity.SetColumnValue("Email", sysAdminUnitEntity.GetColumnValue("Email"));
			var timeZoneId = sysAdminUnitEntity.GetTypedColumnValue<string>("TimeZoneId");
			SetTimeZone(resultEntity, timeZoneId);
			resultEntity.LoadColumnValue("Username", sysAdminUnitEntity.GetColumnValue("Name"));
			var cultureId = sysAdminUnitEntity.GetTypedColumnValue<Guid>("SysCultureId");
			if (cultureId.IsNotEmpty()) {
				FillFieldsFromSysCulture(resultEntity, cultureId);
			}
			var dateTimeFormatId = sysAdminUnitEntity.GetTypedColumnValue<Guid>("DateTimeFormatId");
			if (dateTimeFormatId.IsEmpty()) {
				if (TryLoadSysCultureWithLanguage(cultureId, out Entity sysCultureWithLanguage)) {
					SetColumnBothValuesByName(sysCultureWithLanguage, resultEntity, "Language", "DateTimeFormat");
				}
			} else {
				SetColumnBothValuesByName(sysAdminUnitEntity, resultEntity, "DateTimeFormat");
			}
			var numberFormatId = sysAdminUnitEntity.GetTypedColumnValue<Guid>("NumberFormatId");
			if (!numberFormatId.IsEmpty()) {
				SetColumnBothValuesByName(sysAdminUnitEntity, resultEntity, "NumberFormat");
			}
			if (Features.GetIsEnabled("EnableWeekFirstDayConfiguration")) {
				SetWeekFirstDay(resultEntity, sysAdminUnitEntity, cultureId);
			}
		}

		private void SetWeekFirstDay(Entity resultEntity, Entity sysAdminUnitEntity, Guid cultureId) {
			var weekFirstDayId = sysAdminUnitEntity.GetTypedColumnValue<Guid>("WeekFirstDayId");
			if (weekFirstDayId.IsEmpty()) {
				if (CoreSysSettings.TryGetValue(_userConnection, "DefaultFirstDayOfTheWeek", out var sysSettingValue)
						&& sysSettingValue != null) {
					weekFirstDayId = Guid.Parse(sysSettingValue.ToString());
					var weekFirstDaySchema = UserConnection.EntitySchemaManager.GetInstanceByName("WeekFirstDay");
					var weekFirstDayEntity = weekFirstDaySchema.CreateEntity(UserConnection);
					if (weekFirstDayEntity.FetchFromDB(weekFirstDayId)) {
						var weekFirstDayName = weekFirstDayEntity.GetTypedColumnValue<string>("Name");
						SetColumnBothValuesByName(resultEntity, "WeekFirstDay", weekFirstDayId, weekFirstDayName);
					}
				} else if (cultureId.IsNotEmpty()) {
					var cultureName = sysAdminUnitEntity.GetTypedColumnValue<string>("SysCultureName");
					FillWeekFirstDayByCultureCode(resultEntity, cultureName);
				}
			} else {
				SetColumnBothValuesByName(sysAdminUnitEntity, resultEntity, "WeekFirstDay");
			}
		}

		private void FillWeekFirstDayByCultureCode(Entity resultEntity, string cultureCode) {	
			try {
				var culture = CultureInfo.GetCultureInfo(cultureCode);
				var weekFirstDay = culture.DateTimeFormat.FirstDayOfWeek;
				var weekFirstDaySchema = UserConnection.EntitySchemaManager.GetInstanceByName("WeekFirstDay");
				var weekFirstDayEntity = weekFirstDaySchema.CreateEntity(UserConnection);
				if (weekFirstDayEntity.FetchFromDB("Code", weekFirstDay.ToString())) {
					var weekFirstDayId = weekFirstDayEntity.GetTypedColumnValue<Guid>("Id");
					var weekFirstDayName = weekFirstDayEntity.GetTypedColumnValue<string>("Name");
					SetColumnBothValuesByName(resultEntity, "WeekFirstDay", weekFirstDayId, weekFirstDayName);
				}
			} catch (Exception) {
			}
		}

		private bool TryLoadSysCultureWithLanguage(Guid cultureId, out Entity sysCultureWithLanguage) {
			EntitySchema sysCultureSchema = _userConnection.EntitySchemaManager.FindInstanceByName("SysCulture");
			sysCultureWithLanguage = sysCultureSchema.CreateEntity(_userConnection);
			sysCultureWithLanguage.PrimaryColumnValue = cultureId;
			sysCultureWithLanguage.UseAdminRights = false;
			if (!sysCultureWithLanguage.FetchFromDB(new[] { "Language" }, true)) {
				return false;
			}
			return true;
		}

		private void FillFieldsFromSysCulture(Entity resultEntity, Guid cultureId) {
			if (!TryLoadSysCultureWithLanguage(cultureId, out Entity sysCulture)) {
				return;
			}
			SetColumnBothValuesByName(sysCulture, resultEntity, "Language");
		}

		private void FillFieldsFromSysProfileData(Entity resultEntity) {
			FillThemeFieldFromSysProfile(resultEntity);
			FillEnablePopupsFieldFromSysProfile(resultEntity);
		}

		private void FillThemeFieldFromSysProfile(Entity resultEntity) {
			if (Features.GetIsEnabled("DisableChangeTheme")) {
				return;
			}
			if (!_userConnection.LicHelper.GetHasOperationLicense("CanCustomizeBranding")) {
				return;
			}
			var jsonData = GetUserProfileDataValue("Theme", new { ThemeId = "" });
			if (jsonData != null) {
				resultEntity.LoadColumnValue("Theme", jsonData.ThemeId);
			}
		}

		private void FillEnablePopupsFieldFromSysProfile(Entity resultEntity) {
			var jsonData = GetUserProfileDataValue(EnablePopupsKey, new { Enabled = false });
			if (jsonData != null) {
				resultEntity.LoadColumnValue("EnablePopups", jsonData.Enabled);
			}
		}

		private T GetUserProfileDataValue<T>(string key, T anonymousTypeObject) where T : class {
			var resourceHandler = new UserProfileResourceHandler(_userConnection, key);
			byte[] byteData = resourceHandler.Fetch();
			if (byteData == null || byteData.Length == 0) {
				return null;
			}
			string textData = Encoding.UTF8.GetString(byteData);
			if (textData.IsNullOrEmpty()) {
				return null;
			}
			return JsonConvert.DeserializeAnonymousType(textData, anonymousTypeObject);
		}
		
		private void FillFieldsFromSysSettings(Entity resultEntity) {
			if (CoreSysSettings.TryGetValue(_userConnection, "OptimizeComponentsAccessibilityBehavior",
						out object OptimizeComponentsAccessibilityBehavior))
			{
				resultEntity.LoadColumnValue("OptimizeComponentsAccessibilityBehavior", OptimizeComponentsAccessibilityBehavior);
			}
			if (CoreSysSettings.TryGetValue(_userConnection, "DisableAdvancedVisualEffects",
					out object disableAdvancedVisualEffects)) {
				resultEntity.LoadColumnValue("DisableAdvancedVisualEffects", disableAdvancedVisualEffects);
			}
			if (CoreSysSettings.TryGetValue(_userConnection, "UseAccessibleDesktopColor",
					out object useAccessibleDesktopColor)) {
				resultEntity.LoadColumnValue("UseAccessibleDesktopColor", useAccessibleDesktopColor);
			}
			if (CoreSysSettings.TryGetValue(_userConnection, "UseDefaultBrowserScrollbarStyles",
					out object useDefaultBrowserScrollbarStyles)) {
				resultEntity.LoadColumnValue("UseDefaultBrowserScrollbarStyles", useDefaultBrowserScrollbarStyles);
			}
		}

		#endregion

		#region Methods: Protected

		protected void SetColumnBothValuesByName(Entity sourceEntity, Entity destination, string columnName) {
			SetColumnBothValuesByName(sourceEntity, destination, columnName, columnName);
		}
		
		protected void SetColumnBothValuesByName(Entity sourceEntity, Entity destination, string sourceColumnName,
				string destinationColumnName) {
			EntitySchema sourceSchema = sourceEntity.Schema;
			EntitySchemaColumn sourceColumn = sourceSchema.Columns.FindByName(sourceColumnName);
			object valueId = sourceEntity.GetColumnValue(sourceColumn);
			string displayValue = sourceEntity.GetColumnDisplayValue(sourceColumn);
			destination.LoadColumnValue(destinationColumnName+"Id", valueId);
			destination.LoadColumnValue(destinationColumnName+"Name", displayValue);
		}

		protected void SetColumnBothValuesByName(Entity destination, string columnName, Guid value, string displayValue) {
			destination.LoadColumnValue(columnName + "Id", value);
			destination.LoadColumnValue(columnName + "Name", displayValue);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns SysUserProfile Entity filled with the current user properties.
		/// </summary>
		/// <returns>SysUserProfile entity.</returns>
		public virtual Entity GetCurrentUserProfile() {
			SysUserInfo currentUser = _userConnection.CurrentUser;
			Entity entity = EntitySchema.CreateEntity(UserConnection);
			Guid currentUserId = currentUser.Id;
			entity.LoadColumnValue("Id", currentUserId);
			FillFieldsFromContact(entity, currentUser.ContactId);
			FillFieldsFromSysAdminUnit(entity, currentUserId);
			FillFieldsFromSysProfileData(entity);
			FillFieldsFromSysSettings(entity);
			return entity;
		}

		#endregion

	}

	#endregion

}

