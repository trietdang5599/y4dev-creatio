namespace Terrasoft.Configuration.Social
{
	using System;
	using System.Collections.Generic;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using System.Web.SessionState;

	#region Class: FacebookService

	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class FacebookService : SocialNetworkService<FacebookServerConnector>, IFacebookService, IReadOnlySessionState
	{

		#region Methods: Public

		public BaseCommandResult RevokeCurrentAccessToken(SocialNetworkServiceRequest request) {
			try {
				return ServerConnector.RevokeCurrentAccessToken(request);
			} catch (Exception e) {
				return ServerConnector.HandleException<BaseCommandResult>(e);
			}
		}

		public BaseCommandResult ExecuteCommand(SocialNetworkServiceRequest request) {
			try {
				return ServerConnector.ExecuteCommand(request);
			} catch (Exception e) {
				return ServerConnector.HandleException<BaseCommandResult>(e);
			}
		}

		public BaseCommandResult ExecuteBatchCommand(SocialNetworkServiceRequest request) {
			try {
				return ServerConnector.ExecuteBatchCommand(request);
			} catch (Exception e) {
				return ServerConnector.HandleException<BaseCommandResult>(e);
			}
		}

		public SearchResult ExecuteSearch(SocialNetworkServiceRequest request) {
			try {
				List<FacebookEntity> entities = ServerConnector.ExecuteSearch(request);
				return new SearchResult {
					Entities = entities
				};
			} catch (Exception e) {
				return ServerConnector.HandleException<SearchResult>(e);
			}
		}

		public FacebookEntitiesResponse GetNodesData(SocialNetworkServiceRequest request) {
			try {
				List<FacebookEntity> entities = ServerConnector.GetNodesData(request);
				return new FacebookEntitiesResponse {
					Entities = entities
				};
			} catch (Exception e) {
				return ServerConnector.HandleException<FacebookEntitiesResponse>(e);
			}
		}

		public DebugAccessTokenResponse DebugCurrentAccessToken(SocialNetworkServiceRequest request) {
			try {
				AccessTokenInfo currentAccessTokenInfo = ServerConnector.DebugCurrentAccessToken(request);
				return new DebugAccessTokenResponse() {
					AccessTokenInfo = currentAccessTokenInfo
				};
			} catch (Exception e) {
				return ServerConnector.HandleException<DebugAccessTokenResponse>(e);
			}
		}

		public DebugAccessTokenResponse DebugAccessToken(SocialNetworkServiceRequest request) {
			try {
				AccessTokenInfo accessTokenInfo = ServerConnector.DebugAccessToken(request);
				return new DebugAccessTokenResponse() {
					AccessTokenInfo = accessTokenInfo
				};
			} catch (Exception e) {
				return ServerConnector.HandleException<DebugAccessTokenResponse>(e);
			}
		}

		public ConfigurationServiceResponse CheckCanOperate(SocialNetworkServiceRequest request) {
			try {
				ServerConnector.CheckCanOperate(request);
				return new ConfigurationServiceResponse();
			} catch (Exception e) {
				return ServerConnector.HandleException<ConfigurationServiceResponse>(e);
			}
		}

		#endregion

	}

	#endregion

	#region Class: DebugAccessTokenResponse

	[DataContract]
	public class DebugAccessTokenResponse : ConfigurationServiceResponse
	{

		#region Properties: Public

		[DataMember(Name = "accessTokenInfo")]
		public AccessTokenInfo AccessTokenInfo {
			get;
			set;
		}

		#endregion

	}

	#endregion

	#region Class: SearchResult

	[DataContract]
	public class SearchResult : ConfigurationServiceResponse
	{

		#region Properties: Public

		[DataMember(Name = "entities")]
		public List<FacebookEntity> Entities {
			get;
			set;
		}

		[DataMember(Name = "rowConfig")]
		public Dictionary<string, object> RowConfig {
			get;
			set;
		}

		#endregion

	}

	#endregion

	#region Class: FacebookEntitiesResponse

	[DataContract]
	public class FacebookEntitiesResponse : ConfigurationServiceResponse
	{

		#region Properties: Public

		[DataMember(Name = "entities")]
		public List<FacebookEntity> Entities;

		#endregion

	}

	#endregion

}
