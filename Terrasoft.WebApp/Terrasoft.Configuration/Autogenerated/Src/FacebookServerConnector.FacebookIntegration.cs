namespace Terrasoft.Configuration.Social
{
	using System;
	using System.Collections.Generic;
	using System.Globalization;
	using System.Linq;
	using System.Security.Cryptography;
	using System.Text;
	using System.Reflection;
	using Facebook;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using Terrasoft.Common;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.Store;

	#region Class: FacebookServerConnector

	public class FacebookServerConnector : BaseServerConnector
	{

		#region Constants: Private

		private const string PageFields = "name,about,category,cover,emails,founded,location,phone,picture.type(large).width(100).height(100),website";
		private const string UserFields = "id,name,about,birthday,cover,email,location,picture.type(large).width(100).height(100),website";

		#endregion

		#region Properties: Private

		private string _appSecretProof;
		private string AppSecretProof {
			get {
				return _appSecretProof;
			}
			set {
				_appSecretProof = value;
			}
		}

		private ICacheStore ApplicationCache {
			get {
				return Store.Cache[CacheLevel.Application];
			}
		}

		private Dictionary<string, AccessTokenInfo> _accessTokenInfoCache;
		private Dictionary<string, AccessTokenInfo> AccessTokenInfoCache {
			get {
				if (_accessTokenInfoCache == null) {
					_accessTokenInfoCache = ApplicationCache.GetValue<Dictionary<string, AccessTokenInfo>>("FacebookAccessTokenInfoDictionary");
					if (_accessTokenInfoCache == null) {
						_accessTokenInfoCache = new  Dictionary<string, AccessTokenInfo>();
					}
				}
				return _accessTokenInfoCache;
			}
		}

		#endregion

		#region Properties: Protected

		protected override string ConsumerKeySysSettingName {
			get {
				return "FacebookConsumerKey";
			}
		}

		protected override string ConsumerSecretSysSettingName {
			get {
				return "FacebookConsumerSecret";
			}
		}

		protected override string ConsumerVersionSysSettingName {
			get {
				return "FacebookApiVersion";
			}
		}

		protected override bool UseSharedApplication {
			get {
				return GetSysSettingValue<bool>("UseFacebookSharedApplication");
			}
		}

		protected virtual bool UseLongLivedAccessToken {
			get {
				return GetSysSettingValue<bool>("UseFacebookLongLivedAccessToken");
			}
		}

		#endregion

		#region Properties: Public

		private FacebookClient _client;
		public FacebookClient Client { 
			get {
				return _client;
			}
			set {
				_client = value;
			}
		}

		#endregion

		#region Methods: Private

		private bool HandleAsExpiredToken(FacebookOAuthException exception) {
			bool handleAsExpiredToken = false;
			if (exception.ErrorCode == 190) { // OAuthException
				switch (exception.ErrorSubcode) {
					case 458: // App Not Installed
					case 459: // User Checkpointed
					case 460: // Password Changed
					case 463: // Expired
					case 464: // Unconfirmed User
					case 467: // Invalid Access Token
						handleAsExpiredToken = true;
						break;
					default:
						handleAsExpiredToken = false;
						break;
				}
			} else if (exception.ErrorCode == 102) {
				// API Session. Login status or access token has expired, been revoked, or is otherwise invalid
				handleAsExpiredToken = true;
			} else if (exception.ErrorCode == 10) {
				// API Permission Denied. Permission is either not granted or has been removed - Handle the missing permissions
				handleAsExpiredToken = false;
			} else if (exception.ErrorCode >= 200 && exception.ErrorCode <= 299) {
				// API Permission (Multiple values depending on permission). Permission is either not granted or has been removed - Handle the missing permissions
				handleAsExpiredToken = false;
			}
			return handleAsExpiredToken;
		}

		private IDictionary<string, object> GetObjectProperties(dynamic dynamicObject) {
			return (IDictionary<string, object>)dynamicObject;
		}

		private object GetObjectProperties(JToken token) {
			if (token.Type == JTokenType.Object) {
				Dictionary<string, object> dict = new Dictionary<string, object>();
				foreach (JProperty prop in ((JObject)token).Properties()) {
					dict.Add(prop.Name, GetObjectProperties(prop.Value));
				}
				return dict;
			} else if (token.Type == JTokenType.Array) {
				List<object> list = new List<object>();
				foreach (JToken value in token.Values()) {
					list.Add(GetObjectProperties(value));
				}
				return list;
			} else {
				return ((JValue)token).Value;
			}
		}

		private string GetFacebookLookupKey(FacebookMapping facebookMapAttribute) {
			string key = string.Empty;
			string propertyName = facebookMapAttribute.Name;
			string parentPropertyName = facebookMapAttribute.Parent;
			if (parentPropertyName.IsNullOrEmpty()) {
				key = propertyName;
			} else {
				key = string.Format("{0}_{1}", parentPropertyName, propertyName);
			}
			return key;
		}

		private Dictionary<string, PropertyContainer> GetMatchingProperties<T>(T destination) {
			var matches = new Dictionary<string, PropertyContainer>();
			var destinationProperties = (
					from PropertyInfo property in destination.GetType().GetProperties()
					where property.GetCustomAttributes(typeof(FacebookMapping), true).Length > 0
					select property
				).ToList();
			foreach (PropertyInfo destinationProperty in destinationProperties) {
				foreach (FacebookMapping facebookMapAttribute in destinationProperty.GetCustomAttributes(typeof(FacebookMapping))) {
					if (facebookMapAttribute == null) {
						continue;
					}
					string facebookLookupKey = GetFacebookLookupKey(facebookMapAttribute);
					if (matches.ContainsKey(facebookLookupKey)) {
						continue;
					}
					matches.Add(facebookLookupKey, new PropertyContainer {
						FacebookField = facebookMapAttribute.Name,
						FacebookParent = facebookMapAttribute.Parent,
						FacebookMappedProperty = destinationProperty
					});
				}
			}
			return matches;
		}

		private T ToStatic<T>(dynamic dynamicObject) {
			T destination = Activator.CreateInstance<T>();
			IDictionary<string, object> sourceProperties = GetObjectProperties(dynamicObject);
			if (sourceProperties == null) {
				return destination;
			}
			Dictionary<string, PropertyContainer> matches = GetMatchingProperties<T>(destination);
			foreach (KeyValuePair<string, object> sourceProperty in sourceProperties) {
				foreach (KeyValuePair<string, PropertyContainer> match in matches.Where(m => m.Key.StartsWith(sourceProperty.Key))) {
					var destinationPropertyInfo = match.Value;
					if (destinationPropertyInfo == null) {
						continue;
					}
					object mappedValue;
					if (sourceProperty.Value is JsonObject) {
						mappedValue = FindChildProperties(sourceProperty, destinationPropertyInfo);
						if (mappedValue == null && destinationPropertyInfo.FacebookField == sourceProperty.Key) {
							mappedValue = sourceProperty.Value;
						}
					} else {
						mappedValue = sourceProperty.Value;
					}
					var mappedProperty = destinationPropertyInfo.FacebookMappedProperty;
					if (mappedProperty.PropertyType == typeof(DateTime)) {
						mappedProperty.SetValue(destination, DateTime.Parse(mappedValue?.ToString()), null);
					} else {
						mappedProperty.SetValue(destination, mappedValue, null);
					}
				}
			}
			return destination;
		}

		private object FindChildProperties(KeyValuePair<string, object> source, PropertyContainer destinationPropertyInfo) {
			IDictionary<string, object> childProperties = GetObjectProperties(source.Value);
			object mappedValue = (
					from KeyValuePair<string, object> item in childProperties
					where item.Key == destinationPropertyInfo.FacebookField
					select item.Value
				).FirstOrDefault();
			if (mappedValue == null) {
				foreach (KeyValuePair<string, object> item in childProperties) {
					if (item.Value is JsonObject) {
						mappedValue = FindChildProperties(item, destinationPropertyInfo);
					}
				}
			}
			return mappedValue;
		}

		private List<FacebookEntityMetadata> GetNodesMetadata(SocialNetworkServiceRequest request) {
			List<FacebookEntityMetadata> entitiesMetadata = new List<FacebookEntityMetadata>();
			request.Commands = GetNodesMetadataCommands(request.SocialIds);
			BaseCommandResult batchResults = ExecuteBatchCommand(request);
			foreach (dynamic batchResult in batchResults.Raw) {
				FacebookEntityMetadata facebookEntityMetadata = ToStatic<FacebookEntityMetadata>(batchResult);
				entitiesMetadata.Add(facebookEntityMetadata);
			}
			return entitiesMetadata;
		}

		private IEnumerable<BaseCommand> GetNodesMetadataCommands(string[] socialIds) {
			List<BaseCommand> commands = new List<BaseCommand>();
			foreach (string socialId in socialIds) {
				commands.Add(new BaseCommand {
					Name = socialId,
					Parameters = new List<BaseCommandParameter> {
						new BaseCommandParameter {
							Name = "metadata",
							Value = "1"
						},
						new BaseCommandParameter {
							Name = "fields",
							Value = "metadata{{type}}"
						}
					}
				});
			}
			return commands;
		}

		private IEnumerable<BaseCommand> GetNodesDataCommands(IEnumerable<FacebookEntityMetadata> entitiesMetadata) {
			List<BaseCommand> commands = new List<BaseCommand>();
			foreach (FacebookEntityMetadata entityMetadata in entitiesMetadata) {
				commands.Add(GetNodeDataCommand(entityMetadata));
			}
			return commands;
		}

		private BaseCommand GetNodeDataCommand(FacebookEntityMetadata entityMetadata) {
			string entityType = entityMetadata.Type;
			if (entityType == "page") {
				return GetPageDataCommand(entityMetadata);
			} else if (entityType == "user") {
				return GetUserDataCommand(entityMetadata);
			} else {
				throw new UnsupportedTypeException(entityType);
			}
		}

		private BaseCommand GetPageDataCommand(FacebookEntityMetadata entityMetadata) {
			return new BaseCommand {
				Name = entityMetadata.Id,
				Parameters = new List<BaseCommandParameter> {
					new BaseCommandParameter {
						Name = "fields",
						Value = PageFields
					}
				}
			};
		}

		private BaseCommand GetUserDataCommand(FacebookEntityMetadata entityMetadata) {
			return new BaseCommand {
				Name = entityMetadata.Id,
				Parameters = new List<BaseCommandParameter> {
					new BaseCommandParameter {
						Name = "fields",
						Value = UserFields
					}
				}
			};
		}

		#endregion

		#region Methods: Protected

		protected string GenerateAppSecretProof(string accessToken, string appSecret) {
			if (accessToken.IsNullOrEmpty()) {
				throw new ArgumentNullException("accessToken");
			}
			if (appSecret.IsNullOrEmpty()) {
				throw new ArgumentNullException("appSecret");
			}
			using (HMACSHA256 algorithm = new HMACSHA256(Encoding.ASCII.GetBytes(appSecret))) {
				byte[] hash = algorithm.ComputeHash(Encoding.ASCII.GetBytes(accessToken));
				StringBuilder builder = new StringBuilder();
				for (int i = 0; i < hash.Length; i++) {
					builder.Append(hash[i].ToString("x2", CultureInfo.InvariantCulture));
				}
				return builder.ToString();
			}
		}

		protected string GetAppSecretProof(SocialNetworkServiceRequest request) {
			if (UseSharedApplication) {
				return GetAppSecretProofRemotely(request);
			}
			string accessToken = GetAccessToken(request);
			string consumerSecret = GetConsumerSecret(request);
			return GenerateAppSecretProof(accessToken, consumerSecret);
		}

		protected string GetAppSecretProofRemotely(SocialNetworkServiceRequest request) {
			string accessToken = GetAccessToken(request);
			return ExecuteConsumerInfoServiceMethod<string>("GetAppSecretProofFacebook", accessToken);
		}
		
		protected override ConsumerInfo GetConsumerInfoRemotely(SocialNetworkServiceRequest request) {
			return ExecuteConsumerInfoServiceMethod<ConsumerInfo>("GetConsumerInfoFacebook");
		}

		protected override void InitSocialNetworkClient(SocialNetworkServiceRequest request) {
			base.InitSocialNetworkClient(request);
			AppSecretProof = GetAppSecretProof(request);
			ClientVersion = GetConsumerVersion(request);
			Client = new FacebookClient(AccessToken);
		}

		protected List<BasePermission> GetCurrentUserPermissions(SocialNetworkServiceRequest request) {
			return new List<BasePermission>();
		}

		protected dynamic ExecuteGetCommand(string commandText) {
			return Client.Get(commandText);
		}

		protected T ExecuteGetCommand<T>(string commandText) {
			return Client.Get<T>(commandText);
		}

		protected dynamic ExecuteGetCommand(string path, object parameters) {
			return Client.Get(path, parameters);
		}

		protected dynamic ExecutePostCommand(string commandText) {
			return Client.Post(commandText);
		}

		protected dynamic ExecuteDeleteCommand(string commandText) {
			return Client.Delete(commandText);
		}

		protected virtual void CheckCommandPermissions(SocialNetworkServiceRequest request) {
			BaseCommand command = request.Command;
			List<BasePermission> requiredPermissions = command.Permissions;
			List<BasePermission> currentUserPermissions = GetCurrentUserPermissions(request);
			IEnumerable<BasePermission> missingPermissions = requiredPermissions.Except(currentUserPermissions);
			if (missingPermissions.Any()) {
				throw new MissingPermissionsException();
			}
		}

		protected string GetCommandText(BaseCommand command) {
			string commandText = command.GetText();
			return DecorateCommandText(commandText);
		}

		protected virtual dynamic GetCommandResult(SocialNetworkServiceRequest request) {
			string commandText = GetCommandText(request.Command);
			return ExecuteGetCommand(commandText);
		}

		protected virtual T GetCommandResult<T>(SocialNetworkServiceRequest request) {
			dynamic apiCallResult = GetCommandResult(request);
			return ToStatic<T>(apiCallResult.data ?? apiCallResult);
		}

		protected virtual dynamic GetBatchResult(SocialNetworkServiceRequest request) {
			IEnumerable<BaseCommand> commands = request.Commands;
			var commandResult = new BaseCommandResult();
			FacebookBatchParameter[] batchParameters = commands.Select(c =>
				new FacebookBatchParameter {
					HttpMethod = HttpMethod.Get,
					Path = DecorateCommandText(c.GetText())
				}).ToArray();
			return Client.Batch(batchParameters);
		}

		protected string DecorateCommandText(string baseGraphApiCall) {
			if (string.IsNullOrEmpty(baseGraphApiCall)) {
				return string.Empty;
			}
			string graphApiCall = string.Empty;
			if (baseGraphApiCall.Contains("?")) {
				graphApiCall = string.Format(baseGraphApiCall + "&appsecret_proof={0}", AppSecretProof);
			} else {
				graphApiCall = string.Format(baseGraphApiCall + "?appsecret_proof={0}", AppSecretProof);
			}
			return string.Format("{0}/{1}", ClientVersion, graphApiCall);
		}

		protected string GetAppAccessToken(SocialNetworkServiceRequest request) {
			AccessTokenInfo appAccessTokenInfo = GetAppAccessTokenInfo(request);
			return appAccessTokenInfo.AccessToken;
		}

		protected AccessTokenInfo GetAppAccessTokenInfo(SocialNetworkServiceRequest request) {
			string consumerKey = GetConsumerKey(request);
			string consumerSecret = GetConsumerSecret(request);
			request.Command = GetAppAccessTokenInfoCommand(consumerKey, consumerSecret);
			return ExecuteCommand<AccessTokenInfo>(request);
		}

		protected virtual string GetLongLivedAccessToken(SocialNetworkServiceRequest request) {
			AccessTokenInfo accessTokenInfo = GetLongLivedAccessTokenInfo(request);
			string longLivedAccessToken = accessTokenInfo.AccessToken;
			if (longLivedAccessToken.IsNullOrEmpty()) {
				throw new ItemNotFoundException("LongLivedAccessToken");
			}
			return longLivedAccessToken;
		}

		protected AccessTokenInfo GetLongLivedAccessTokenInfo(SocialNetworkServiceRequest request) {
			if (UseSharedApplication) {
				return GetLongLivedAccessTokenInfoRemotely(request);
			}
			string consumerKey = GetConsumerKey(request);
			string consumerSecret = GetConsumerSecret(request);
			string accessToken = GetRequestAccessToken(request);
			request.Command = GetLongLivedAccessTokenInfoCommand(consumerKey, consumerSecret, accessToken);
			return ExecuteCommand<AccessTokenInfo>(request);
		}

		protected AccessTokenInfo GetLongLivedAccessTokenInfoRemotely(SocialNetworkServiceRequest request) {
			string accessToken = GetRequestAccessToken(request);
			string longLivedAccessTokenString = ExecuteConsumerInfoServiceMethod<string>("GetLongLivedAccessTokenInfoFacebook", accessToken);
			JObject accessTokenInfo = JObject.Parse(longLivedAccessTokenString);
			JValue longLivedAccessToken = (JValue)accessTokenInfo["access_token"];
			return new AccessTokenInfo {
				AccessToken = longLivedAccessToken.Value.ToString()
			};
		}

		protected string GetSocialAccountLogin(SocialNetworkServiceRequest request) {
			request.Command = GetSocialAccountLoginCommand(request.SocialId);
			FacebookEntity facebookEntity = ExecuteCommand<FacebookEntity>(request);
			return facebookEntity.Name;
		}

		protected virtual bool SetInitialSocialAccountProperties(SocialNetworkServiceRequest request) {
			SocialAccount socialAccount = GetSocialAccount(request);
			if (UseLongLivedAccessToken) {
				socialAccount.AccessToken = GetLongLivedAccessToken(request);
			}
			socialAccount.Login = GetSocialAccountLogin(request);
			return socialAccount.Save();
		}

		protected BaseCommand GetDebugAccessTokenCommand(string accessToken, string appAccessToken) {
			return new BaseCommand {
				Name = "debug_token",
				Parameters = new List<BaseCommandParameter> {
					new BaseCommandParameter {
						Name = "input_token",
						Value = accessToken
					},
					new BaseCommandParameter {
						Name = "access_token",
						Value = appAccessToken
					}
				}
			};
		}

		protected BaseCommand GetAppAccessTokenInfoCommand(string consumerKey, string consumerSecret) {
			return new BaseCommand {
				Name = "oauth/access_token",
				Parameters = new List<BaseCommandParameter> {
					new BaseCommandParameter {
						Name = "client_id",
						Value = consumerKey
					},
					new BaseCommandParameter {
						Name = "client_secret",
						Value = consumerSecret
					},
					new BaseCommandParameter {
						Name = "grant_type",
						Value = "client_credentials"
					}
				}
			};
		}

		protected BaseCommand GetSocialAccountLoginCommand(string node) {
			return new BaseCommand {
				Name = node,
				Parameters = new List<BaseCommandParameter> {
					new BaseCommandParameter {
						Name = "fields",
						Value = "name"
					}
				}
			};
		}

		protected BaseCommand GetLongLivedAccessTokenInfoCommand(string consumerKey, string consumerSecret, string accessToken) {
			return new BaseCommand {
				Name = "oauth/access_token",
				Parameters = new List<BaseCommandParameter> {
					new BaseCommandParameter {
						Name = "grant_type",
						Value = "fb_exchange_token"
					},
					new BaseCommandParameter {
						Name = "client_id",
						Value = consumerKey
					},
					new BaseCommandParameter {
						Name = "client_secret",
						Value = consumerSecret
					},
					new BaseCommandParameter {
						Name = "fb_exchange_token",
						Value = accessToken
					}
				}
			};
		}

		/// <summary>
		/// ############## ######## ########## #######.
		/// </summary>
		/// <param name="request">######, ######## ######### #######.</param>
		protected override void PrepareCommandExecutionContext(SocialNetworkServiceRequest request) {
			base.PrepareCommandExecutionContext(request);
//			CheckCommandPermissions(request);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// ############ ##########.
		/// </summary>
		/// <param name="exception">##########.</param>
		public override T HandleException<T>(Exception e) {
			return base.HandleException<T>(e);
		}

		/// <summary>
		/// ########## ####### ###### #######.
		/// </summary>
		/// <param name="request">######, ######## ######### ######### ####### #######.</param>
		/// <returns>######### ########## #######.</returns>
		public BaseCommandResult RevokeCurrentAccessToken(SocialNetworkServiceRequest request) {
			PrepareCommandExecutionContext(request);
			string commandText = DecorateCommandText("me/permissions");
			dynamic apiCallResult = ExecuteDeleteCommand(commandText);
			return new BaseCommandResult() {
				Text = apiCallResult.ToString()
			};
		}

		/// <summary>
		/// ######### ######### # ######## #######.
		/// </summary>
		/// <param name="request">######, ######## ######### #######.</param>
		/// <returns>######### ########## #######.</returns>
		public virtual BaseCommandResult ExecuteCommand(SocialNetworkServiceRequest request) {
			PrepareCommandExecutionContext(request);
			return new BaseCommandResult {
				Raw = GetCommandResult(request)
			};
		}

		/// <summary>
		/// ######### ######### # ######## #######.
		/// </summary>
		/// <param name="request">######, ######## ######### #######.</param>
		/// <returns>######### ########## #######.</returns>
		public BaseCommandResult ExecuteBatchCommand(SocialNetworkServiceRequest request) {
			PrepareCommandExecutionContext(request);
			return new BaseCommandResult {
				Raw = GetBatchResult(request)
			};
		}

		/// <summary>
		/// ######### ######### # ######## #######.
		/// </summary>
		/// <typeparam name="T">### ############### ########.</typeparam>
		/// <param name="request">######, ######## ######### #######.</param>
		/// <returns>######### ########## #######.</returns>
		public virtual T ExecuteCommand<T>(SocialNetworkServiceRequest request) {
			PrepareCommandExecutionContext(request);
			return GetCommandResult<T>(request);
		}

		/// <summary>
		/// ########## ##### ## ####### #######.
		/// </summary>
		/// <param name="request">######, ######## ######### ######.</param>
		/// <returns>########## ###### ## ####### #######.</returns>
		public virtual List<FacebookEntity> ExecuteSearch(SocialNetworkServiceRequest request) {
			List<FacebookEntity> entities = new List<FacebookEntity>();
			BaseCommandResult batchResults = ExecuteBatchCommand(request);
			foreach (dynamic batchResult in batchResults.Raw) {
				foreach (dynamic entity in batchResult.data) {
					FacebookEntity facebookEntity = ToStatic<FacebookEntity>(entity);
					entities.Add(facebookEntity);
				}
			}
			return entities;
		}

		public virtual List<FacebookEntity> GetNodesData(SocialNetworkServiceRequest request) {
			List<FacebookEntity> entities = new List<FacebookEntity>();
			List<FacebookEntityMetadata> entitiesMetadata = GetNodesMetadata(request);
			request.Commands = GetNodesDataCommands(entitiesMetadata);
			BaseCommandResult batchResults = ExecuteBatchCommand(request);
			foreach (dynamic batchResult in batchResults.Raw) {
				FacebookEntity facebookEntity = ToStatic<FacebookEntity>(batchResult);
				entities.Add(facebookEntity);
			}
			return entities;
		}

		/// <summary>
		/// ########## ########## # ####### #######.
		/// </summary>
		/// <param name="request">######, ######## ###### #######.</param>
		/// <returns>########## # ####### #######.</returns>
		public AccessTokenInfo DebugAccessToken(SocialNetworkServiceRequest request) {
			string accessToken = request.AccessToken;
			if (accessToken.IsNullOrEmpty()) {
				throw new ArgumentEmptyException("AccessToken");
			}
			if (UseSharedApplication) {
				return DebugAccessTokenRemotely(accessToken);
			}
			string appAccessToken = GetAppAccessToken(request);
			request.Command = GetDebugAccessTokenCommand(accessToken, appAccessToken);
			return ExecuteCommand<AccessTokenInfo>(request);
		}
		
		/// <summary>
		/// Returns information about access marker from service.
		/// </summary>
		/// <param name="accessToken">Access marker</param>
		/// <returns>Information about access marker.</returns>
		public AccessTokenInfo DebugAccessTokenRemotely(string accessToken) {
			AccessTokenInfo accessTokenInfo;
			if (!AccessTokenInfoCache.TryGetValue(accessToken, out accessTokenInfo)) {
				string debugAccessTokenString = ExecuteConsumerInfoServiceMethod<string>("DebugAccessTokenFacebook", accessToken);
				dynamic debugAccessTokenObject = JObject.Parse(debugAccessTokenString);
				dynamic debugAccessToken = debugAccessTokenObject["data"];
				accessTokenInfo = ToStatic<AccessTokenInfo>(debugAccessToken);
				AccessTokenInfoCache.Add(accessToken, accessTokenInfo);
			}
			return accessTokenInfo;
		}

		/// <summary>
		/// ########## ########## # ####### ####### #######.
		/// </summary>
		/// <param name="request">######, ######## ######### ######### ####### #######.</param>
		/// <returns>########## # ####### ####### #######.</returns>
		public AccessTokenInfo DebugCurrentAccessToken(SocialNetworkServiceRequest request) {
			string accessToken = GetAccessToken(request);
			request.AccessToken = accessToken;
			return DebugAccessToken(request);
		}

		/// <summary>
		/// ######### ############ ######## ####### #######.
		/// </summary>
		/// <param name="request">######, ######## ######### ######### ####### #######.</param>
		public virtual void CheckCurrentAccessToken(SocialNetworkServiceRequest request) {
			AccessTokenInfo accessTokenInfo = DebugCurrentAccessToken(request);
			if (!accessTokenInfo.IsValid) {
				throw new InvalidAccessTokenException();
			}
		}

		/// <summary>
		/// ######### ########### ########### # ######## #######.
		/// </summary>
		/// <param name="request">######, ######## ######### ###########.</param>
		public override void CheckCanOperate(SocialNetworkServiceRequest request) {
			base.CheckCanOperate(request);
			CheckCurrentAccessToken(request);
		}

		/// <summary>
		/// ####### ####### ###### ## ####### #######.
		/// </summary>
		/// <param name="request">######, ######## ######### ########.</param>
		/// <returns>######### ########## ######.</returns>
		public override bool CreateSocialAccount(SocialNetworkServiceRequest request) {
			bool saveResult = base.CreateSocialAccount(request);
			if (saveResult) {
				SetInitialSocialAccountProperties(request);
			}
			return saveResult;
		}

		#endregion

	}

	#endregion

}
