using Newtonsoft.Json;
using System;
using System.Text;
using System.Collections.Generic;
using System.Drawing;
using Terrasoft.Common;
using Terrasoft.Common.Json;
using Terrasoft.Core;
using Terrasoft.Core.DB;
using Terrasoft.Core.Entities;
using Terrasoft.Core.Profiles;
using Terrasoft.Core.Store;
using Terrasoft.UI.WebControls;
using Terrasoft.UI.WebControls.Controls;
using Terrasoft.UI.WebControls.Utilities.Json.Converters;
using TSConfiguration = Terrasoft.Configuration;

namespace Terrasoft.Configuration
{
	public static class VideoHelpUtilities 
	{
		private static bool HasVideoCode = false;

		#region Methods: Private

		private static bool UseLmsDocumantation(UserConnection userConnection) {
			object settingsValue = GetSysSettingValue(userConnection, "UseLMSDocumentation");
			if (settingsValue != null) {
				return Convert.ToBoolean(settingsValue);
			}
			return false;
		}

		private static string GetProductEdition(UserConnection userConnection) {
			object settingsValue = GetSysSettingValue(userConnection, "ProductEdition");
			if (settingsValue != null) {
				return settingsValue.ToString();
			}
			return string.Empty;
		}

		private static string GetConfigurationVersion(UserConnection userConnection) {
			object settingsValue = GetSysSettingValue(userConnection, "ConfigurationVersion");
			if (settingsValue != null) {
				return settingsValue.ToString();
			}
			return string.Empty;
		}

		private static string GetLmsUrl(UserConnection userConnection) {
			object settingsValue = GetSysSettingValue(userConnection, "LMSUrl");
			if (settingsValue != null) {
				return settingsValue.ToString();
			}
			return string.Empty;
		}

		private static object GetSysSettingValue(UserConnection userConnection, string sysSettingsName) {
			object settingsValue;
			if (Terrasoft.Core.Configuration.SysSettings.TryGetValue(userConnection, sysSettingsName, out settingsValue)) {
				return settingsValue;
			}
			return null;
		}

		#endregion

		#region Methods: Public

		public static string GetVideoCode(string helpContextId, UserConnection userConnection) {
			var entitySchemaManager = userConnection.GetSchemaManager("EntitySchemaManager") as EntitySchemaManager;
			var videoHelpSchemaQuery = new EntitySchemaQuery(entitySchemaManager, "VideoHelp");
			videoHelpSchemaQuery.Cache = userConnection.SessionCache.WithLocalCaching(TSConfiguration.CacheUtilities.GlobalModuleCacheGroup);
			var videoIdField = videoHelpSchemaQuery.AddColumn("Id");
			var helpContextIdField = videoHelpSchemaQuery.AddColumn("HelpContextId");
			var videoCodeField = videoHelpSchemaQuery.AddColumn("VideoCode");
			videoHelpSchemaQuery.Filters.Add(videoHelpSchemaQuery.CreateFilterWithParameters(FilterComparisonType.Equal, helpContextIdField.Name, helpContextId));
			videoHelpSchemaQuery.CacheItemName = "VideoHelpContextId_" + helpContextId;
			var videoCollection = videoHelpSchemaQuery.GetEntityCollection(userConnection);
			string videoCode = "";
			if (videoCollection.Count > 0) {
				videoCode = videoCollection[0].GetTypedColumnValue<string>(videoCodeField.Name);
				if (!string.IsNullOrEmpty(videoCode)) {
					HasVideoCode = true;
				} else {
					HasVideoCode = false;
				}
			} else {
				HasVideoCode = false;
			}
			return videoCode;
		}

		public static void SetWebControlHelpProperties(WebControl webControl, string helpContextId, UserConnection userConnection) {
			string productEdition = GetProductEdition(userConnection);
			webControl.HelpContextId = helpContextId;
			webControl.ProductEdition = productEdition;
		}

		public static string GetHelpUrl(WebControl webControl, string helpContextId, UserConnection userConnection) {
			if (UseLmsDocumantation(userConnection)) {
				string lmsUrl = GetLmsUrl(userConnection);
				string productEdition = GetProductEdition(userConnection);
				string configurationVersion = GetConfigurationVersion(userConnection);
				string helpUrl = lmsUrl + "?product=" + productEdition + "&ver=" + configurationVersion;
				if (!helpContextId.IsNullOrEmpty()) {
					helpUrl += ("&id=" + helpContextId);
				}
				return helpUrl;
			}
			return string.Empty;
		}

		public static void InitializeContextHelpButton(Button helpContextButton, string helpContextId, string menuHelpItemCaption, string menuVideoHelpItemCaption, UserConnection userConnection) {
			string videoCode = GetVideoCode(helpContextId, userConnection);
			helpContextButton.Hidden = false;
			helpContextButton.Image.Source = ControlImageSource.ResourceManager;
			helpContextButton.Image.ResourceManagerName = "Terrasoft.WebApp";
			if (HasVideoCode) {
				helpContextButton.Image.ResourceItemName = "video_help_btn.png";
				var menu = helpContextButton.Menu as Terrasoft.UI.WebControls.Controls.MenuBaseCollection;
				if (menu != null) {
					var videoMenuItem = new Terrasoft.UI.WebControls.Controls.MenuItem();
					videoMenuItem.ID = "VideoHelpMenuItem";
					videoMenuItem.UId = Guid.NewGuid();
					videoMenuItem.Caption = menuVideoHelpItemCaption;
					videoMenuItem.CaptionColor = Color.FromArgb(0,2,77,156);
					videoMenuItem.Tag = "ref";
					videoMenuItem.AjaxEvents.Click.OnClientEvent = "Terrasoft.HelpContext.showVideoHelp(" + Json.Serialize(videoCode) + ")";
					menu.Add(videoMenuItem);
					var menuItem = new Terrasoft.UI.WebControls.Controls.MenuItem();
					menuItem.ID = "HelpMenuItem";
					menuItem.UId = Guid.NewGuid();
					menuItem.Caption = menuHelpItemCaption;
					menuItem.CaptionColor = Color.FromArgb(0,2,77,156);
					menuItem.Tag = "ref";
					menuItem.AjaxEvents.Click.OnClientEvent = "Terrasoft.HelpContext.showHelp(" + Json.Serialize((string.IsNullOrEmpty(helpContextId) ?  "null" : helpContextId)) + ",'" + helpContextButton.ClientID + "')";
					menu.Add(menuItem);
				}
			} else {
				helpContextButton.Image.ResourceItemName = "help.png";
				string buttonClientEvent;
				if (!helpContextId.IsNullOrEmpty()) {
					string helpUrl = GetHelpUrl(helpContextButton, helpContextId, userConnection);
					buttonClientEvent = "Terrasoft.HelpContext.showHelp(null, null, '" + helpUrl + @"')";
				} else {
					buttonClientEvent = "Terrasoft.HelpContext.showHelp(" + Json.Serialize((string.IsNullOrEmpty(helpContextId) ?  "null" : helpContextId)) + ",'" + helpContextButton.ClientID + "')";
				}
				helpContextButton.AjaxEvents.Click.OnClientEvent = buttonClientEvent;
				SetWebControlHelpProperties(helpContextButton, helpContextId, userConnection);
			}
		}

		public static void InitializeContextHelpButton(Button helpContextButton, string helpContextId, UserConnection userConnection) {
			string videoCode = GetVideoCode(helpContextId, userConnection);
			string formatString = "{0}.on('click', function(el) {{ {1} }}, this)";
			helpContextButton.Hidden = false;
			helpContextButton.Image.Source = ControlImageSource.ResourceManager;
			helpContextButton.Image.ResourceManagerName = "Terrasoft.WebApp";
			if (HasVideoCode) {
				helpContextButton.Image.ResourceItemName = "video_help_btn.png";
				var menu = helpContextButton.Menu as Terrasoft.UI.WebControls.Controls.MenuBaseCollection;
				if (menu != null) {
					var videoMenuItem = new Terrasoft.UI.WebControls.Controls.MenuItem();
					videoMenuItem.ID = "VideoHelpMenuItem";	
					videoMenuItem.UId = Guid.NewGuid();
					videoMenuItem.Caption = new LocalizableString(userConnection.ResourceStorage, "VideoHelpUtilities",
						"LocalizableStrings.MenuVideoHelpItemCaption.Value").ToString();
					videoMenuItem.CaptionColor = Color.FromArgb(0, 2, 77, 156);
					videoMenuItem.Tag = "ref";
					string function = "Terrasoft.HelpContext.showVideoHelp(" + Json.Serialize(videoCode) + ")";
					menu.Add(videoMenuItem);
					helpContextButton.AddScript(formatString, videoMenuItem.ClientID, function);
					var menuItem = new Terrasoft.UI.WebControls.Controls.MenuItem();
					menuItem.ID = "HelpMenuItem";
					menuItem.UId = Guid.NewGuid();
					menuItem.Caption = new LocalizableString(userConnection.ResourceStorage, "VideoHelpUtilities",
						"LocalizableStrings.MenuHelpItemCaption.Value").ToString();
					menuItem.CaptionColor = Color.FromArgb(0, 2, 77, 156);
					menuItem.Tag = "ref";
					function = "Terrasoft.HelpContext.showHelp(" + Json.Serialize((string.IsNullOrEmpty(helpContextId) ?  "null" : helpContextId)) + ",'" +helpContextButton.ClientID + "')";
					menu.Add(menuItem);
					helpContextButton.AddScript(formatString, menuItem.ClientID, function);
				}
			} else {
				helpContextButton.Image.ResourceItemName = "help.png";
				string buttonClientEvent;
				if (!helpContextId.IsNullOrEmpty()) {
					string helpUrl = GetHelpUrl(helpContextButton, helpContextId, userConnection);
					buttonClientEvent = "Terrasoft.HelpContext.showHelp(null, null, '" + helpUrl + @"')";
				} else {
					buttonClientEvent = "Terrasoft.HelpContext.showHelp(" + Json.Serialize((string.IsNullOrEmpty(helpContextId) ?  "null" : helpContextId)) + ",'" + helpContextButton.ClientID + "')";
				}
				helpContextButton.AjaxEvents.Click.OnClientEvent = buttonClientEvent;
				SetWebControlHelpProperties(helpContextButton, helpContextId, userConnection);
			}
		}

		public static string GetVideoHelpScript(string helpContextId) {
			return string.Empty;
		}

		#endregion

	}
}
