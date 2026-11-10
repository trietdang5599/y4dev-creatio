namespace Terrasoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using System.Text;
	using System.Web.SessionState;
	using Terrasoft.Common;
	using Terrasoft.Common.Messaging;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.FeatureToggling;
	using Terrasoft.Web.Common;

	#region Class: FeatureService

	/// <summary>
	/// Provides web-service for work with features.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class FeatureService : BaseService, IReadOnlySessionState
	{

		#region Methods: Private

		private string ClearFeaturesCache(string featureName, SysUserInfo user) {
			string name = featureName.IsNullOrWhiteSpace() ? null : featureName;
			var notification = new FeatureChangedNotification(name, null, user?.Id);
			MessageHub.Instance.Publish(notification);
			string featureNameInMessage = name == null ? "all features" : $"feature {name}";
			string userNameInMessage = user == null ? string.Empty : $"for user {user.Name} ";
			return $"Cache cleared {userNameInMessage}for {featureNameInMessage}";
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns feature state by code.
		/// </summary>
		/// <param name="code">Feature code.</param>
		/// <returns>Feature state.</returns>
		/// <remarks>Result parameter name "FeatureState".</remarks>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetFeatureState", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "FeatureState")]
		public int GetFeatureState(string code) {
			return UserConnection.GetFeatureState(code);
		}

		/// <summary>
		/// Sets feature state for current user.
		/// </summary>
		/// <param name="code">Feature code.</param>
		/// <param name="state">New feature state.</param>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "SetFeatureState", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "result")]
		public ConfigurationServiceResponse SetFeatureState(string code, int state) {
			try {
				UserConnection.SetFeatureState(code, state);
				return new ConfigurationServiceResponse();
			} catch (Exception e) {
				return new ConfigurationServiceResponse(e);
			}
			
		}

		/// <summary>
		/// Sets features state for current user.
		/// </summary>
		/// <param name="features">Features list</param>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "SetFeaturesState", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "result")]
		public ConfigurationServiceResponse SetFeaturesState(List<FeatureStateInfo> features) {
			try {
				foreach (FeatureStateInfo item in features) {
					UserConnection.SetFeatureState(item.Code, item.State);
				}
				return new ConfigurationServiceResponse();
			} catch (Exception e) {
				return new ConfigurationServiceResponse(e);
			}
		}

		/// <summary>
		/// Sets feature state for all users.
		/// </summary>
		/// <param name="code">Feature code.</param>
		/// <param name="state">New feature state.</param>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "SetFeatureStateForAllUsers", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "result")]
		public void SetFeatureStateForAllUsers(string code, int state) {
			UserConnection.SetFeatureState(code, state, forAllUsers: true);
		}

		/// <summary>
		/// Creates feature.
		/// </summary>
		/// <param name="code">Feature code.</param>
		/// <param name="name">Feature name.</param>
		/// <param name="description">Feature description.</param>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "CreateFeature", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "result")]
		public ConfigurationServiceResponse CreateFeature(string code, string name, string description) {
			try {
				UserConnection.CreateFeature(code, name, description);
				return new ConfigurationServiceResponse();
			} catch (Exception e) {
				return new ConfigurationServiceResponse(e);
			}
		}

		/// <summary>
		/// Returns features and their states information.
		/// </summary>
		/// <returns>List of the all features with their states.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetFeaturesInfo", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public List<FeatureInfo> GetFeaturesInfo() {
			return UserConnection.GetFeaturesInfo();
		}

		/// <summary>
		/// Returns requested or all feature states.
		/// </summary>
		/// <param name="codes">Feature codes. If null or empty, all feature states will be returned.</param>
		/// <returns>List of features.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetFeatureStates", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public Dictionary<string, int> GetFeatureStates(string[] codes = null) {
			var allFeatureStates = UserConnection.GetFeatureStates();
			if (codes == null || codes.Length == 0) {
				return allFeatureStates;
			}
			return allFeatureStates
				.Where(kvp => codes.Contains(kvp.Key))
				.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
		}

		/// <summary>
		/// Clears features cache for all users.
		/// </summary>
		/// <param name="featureName">Feature name in Base64.</param>
		/// <returns>Operation status description.</returns>
		[OperationContract]
		[WebGet(UriTemplate = "ClearFeaturesCacheForAllUsers/{*featureName}", BodyStyle = WebMessageBodyStyle.Bare,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string ClearFeaturesCacheForAllUsers(string featureName) {
			byte[] byteArray = Convert.FromBase64String(featureName);
			string decodedFeatureName = Encoding.UTF8.GetString(byteArray);
			return ClearFeaturesCache(decodedFeatureName, null);
		}

		/// <summary>
		/// Clears features cache for current user.
		/// </summary>
		/// <param name="featureName">Feature name.</param>
		/// <returns>Operation status description.</returns>
		[OperationContract]
		[WebGet(UriTemplate = "ClearFeaturesCacheForCurrentUser/{*featureName}", BodyStyle = WebMessageBodyStyle.Bare,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string ClearFeaturesCacheForCurrentUser(string featureName) =>
			ClearFeaturesCache(featureName, UserConnection.CurrentUser);

		#endregion

	}

	#endregion

}

