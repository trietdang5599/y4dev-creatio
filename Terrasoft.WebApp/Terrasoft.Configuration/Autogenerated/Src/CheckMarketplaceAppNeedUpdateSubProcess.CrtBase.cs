namespace Terrasoft.Core.Process
{

	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.Text;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;

	#region Class: CheckMarketplaceAppNeedUpdateSubProcessMethodsWrapper

	/// <exclude/>
	public class CheckMarketplaceAppNeedUpdateSubProcessMethodsWrapper : ProcessModel
	{

		public CheckMarketplaceAppNeedUpdateSubProcessMethodsWrapper(Process process)
			: base(process) {
			AddScriptTaskMethod("CalculateNeedUpdateScriptTaskExecute", CalculateNeedUpdateScriptTaskExecute);
			AddScriptTaskMethod("SetPreviousInstalledAppModifiedOnValueScriptTaskExecute", SetPreviousInstalledAppModifiedOnValueScriptTaskExecute);
		}

		#region Methods: Private

		private bool CalculateNeedUpdateScriptTaskExecute(ProcessExecutingContext context) {
			Set("CalculatedNeedUpdate", CalculateNeedUpdate());
			return true;
		}

		private bool SetPreviousInstalledAppModifiedOnValueScriptTaskExecute(ProcessExecutingContext context) {
			SetPreviousInstalledAppModifiedOnValue();
			return true;
		}

			private bool CalculateNeedUpdate() {
				string installedAppVersionString = Get<string>("InstalledAppVersion");
				string receivedPublishedVersionString = Get<string>("ReceivedPublishedVersion");
				if (Version.TryParse(installedAppVersionString , out Version installedAppVersion) &&
						Version.TryParse(receivedPublishedVersionString , out Version receivedPublishedVersion)) {
					return receivedPublishedVersion > installedAppVersion;
				}
				string receivedLastUpdateStringValue = Get<string>("ReceivedLastUpdateStringValue");
				if (DateTime.TryParse(receivedLastUpdateStringValue , out DateTime receivedLastUpdateValue)) {
					DateTime installedAppModifiedOn = Get<DateTime>("InstalledAppModifiedOn");
					return receivedLastUpdateValue > installedAppModifiedOn;
				}
				return false;
			}
			
			private void SetPreviousInstalledAppModifiedOnValue() {
				Guid appId = Get<Guid>("InstalledApp");
				DateTime installedAppModifiedOn = Get<DateTime>("InstalledAppModifiedOn");
				DateTime modifiedOnUTC = installedAppModifiedOn.ToUniversalTime();
				var update = new Update(UserConnection, "SysInstalledApp")
					.Set("ModifiedOn", Column.Parameter(modifiedOnUTC))
					.Where("Id").IsEqual(new QueryParameter(appId)) as Update;
				update.Execute();
			}

		#endregion

	}

	#endregion

}

