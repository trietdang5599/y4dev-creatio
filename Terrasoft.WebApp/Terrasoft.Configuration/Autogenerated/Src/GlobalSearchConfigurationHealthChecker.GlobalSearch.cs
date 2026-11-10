namespace Terrasoft.Configuration.GlobalSearch
{
	using System.Text;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.Factories;

	#region Interface: IGlobalSearchConfigurationHealthChecker

	public interface IGlobalSearchConfigurationHealthChecker
	{

		#region Methods: Public

		/// <summary>
		/// Get Global Search configuration problems as single compiled string.
		/// </summary>
		string GetCompiledConfigurationProblems(UserConnection userConnection);

		#endregion

	}

	#endregion

	#region Class: GlobalSearchConfigurationHealthChecker

	[DefaultBinding(typeof(IGlobalSearchConfigurationHealthChecker))]
	public class GlobalSearchConfigurationHealthChecker: IGlobalSearchConfigurationHealthChecker
	{

		#region Methods: Private

		private static void CheckRequiredSysSettingState(UserConnection userConnection, string code,
				StringBuilder errorLogger) {
			var value = (string)SysSettings.GetValue(userConnection, code);
			if (value.IsNullOrWhiteSpace()) {
				errorLogger.AppendLine($"Required system settings {code} is not filled in.");
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Get Global Search configuration problems as single compiled string.
		/// </summary>
		public string GetCompiledConfigurationProblems(UserConnection userConnection) {
			var messages = new StringBuilder();
			CheckRequiredSysSettingState(userConnection, "GlobalSearchUrl", messages);
			CheckRequiredSysSettingState(userConnection, "GlobalSearchConfigServiceUrl", messages);
			CheckRequiredSysSettingState(userConnection, "GlobalSearchIndexingApiUrl", messages);
			if (!userConnection.GetIsFeatureEnabled("GlobalSearch_V2")) {
				messages.AppendLine("Feature GlobalSearch_V2 is not enabled.");
			}
			return messages.ToString();
		}

		#endregion

	}

	#endregion

} 
