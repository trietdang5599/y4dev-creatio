namespace Terrasoft.Configuration.SysSettingsService
{
	using System;
	using System.ServiceModel;
	using System.ServiceModel.Web;
	using System.ServiceModel.Activation;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;
	using Terrasoft.Web.Common;
	using CoreSysSettings = Terrasoft.Core.Configuration.SysSettings;

	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class SysSettingsService : BaseService
	{
		
		#region Methods: Public
		
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public int GetIncrementValue(string sysSettingName) {
			int resultValue = 0;
			if (CoreSysSettings.TryGetValueWithRightsChecking(UserConnection, sysSettingName, out object value)) 
			{
				int sysSettingsLastNumber = Convert.ToInt32(value);
				++sysSettingsLastNumber;
				CoreSysSettings.SetDefValue(UserConnection, sysSettingName, sysSettingsLastNumber);
				resultValue = sysSettingsLastNumber;
			}
			return resultValue;
		}
		
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string GetIncrementValueVsMask(string sysSettingName, string sysSettingMaskName) {
			string result = string.Empty;
			if (CoreSysSettings.TryGetValueWithRightsChecking(UserConnection, sysSettingMaskName, out object value))
			{
				string sysSettingsCodeMask = (string)value;
				if (GlobalAppSettings.UseDBSequence)
				{
					var sequenceMap = new SequenceMap(UserConnection);
					var sequence = sequenceMap.GetByNameOrDefault(sysSettingName);
					result = string.Format(sysSettingsCodeMask, sequence.GetNextValue());
					return result;
				}
				if (CoreSysSettings.TryGetValueWithRightsChecking(UserConnection, sysSettingName, out object valueBySettingName))
				{
					int sysSettingsLastNumber = Convert.ToInt32(valueBySettingName);
					++sysSettingsLastNumber;
					CoreSysSettings.SetDefValue(UserConnection, sysSettingName, sysSettingsLastNumber);
					result = string.Format(sysSettingsCodeMask, sysSettingsLastNumber);
				}
			}
			return result;
		}
		
		#endregion
	}
}

