namespace Terrasoft.Configuration
{
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using System.Text.RegularExpressions;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;
	using Terrasoft.Web.Common;

	#region Class: SequenceSettingsService

	/// <summary>
	/// Sequence settings service.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class SequenceSettingsService: BaseService
	{

		#region Constructor: Public

		public SequenceSettingsService(): base() {
		}

		public SequenceSettingsService(UserConnection userConnection): base() {
			UserConnection = userConnection;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Get Sequence current value.
		/// </summary>
		/// <param name="sysSettingName">Code of syssetting</param>
		/// <returns>Sequence value</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
		ResponseFormat = WebMessageFormat.Json)]
		public int GetSequenceValue(string sysSettingName) {
			if (Core.Configuration.SysSettings.TryGetValue(UserConnection, sysSettingName, out object value) && value is int 
				&& Regex.IsMatch(sysSettingName, @"^[a-zA-Z0-9_]+$")) {
				var sequenceMap = new SequenceMap(UserConnection);
				var sequence = sequenceMap.GetByNameOrDefault(sysSettingName);
				return sequence.GetCurrentValue();
			}
			return 0;
		}

		/// <summary>
		/// Set Sequence value.
		/// </summary>
		/// <param name="sysSettingName">Code of sequence</param>
		/// <param name="startValue">Value of sequence</param>
		/// <returns>Sequence value</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
		ResponseFormat = WebMessageFormat.Json)]
		public void SetSequenceValue(string sysSettingName, int startValue) {
			if (Core.Configuration.SysSettings.TryGetValue(UserConnection, sysSettingName, out object value) && value is int
				&& Regex.IsMatch(sysSettingName, @"^[a-zA-Z0-9_]+$")) {
				var sequenceMap = new SequenceMap(UserConnection);
				sequenceMap.CreateOrAlterSequence(sysSettingName, startValue);
			}
		}

		#endregion

	}

	#endregion

}
