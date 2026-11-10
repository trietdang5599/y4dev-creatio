namespace Terrasoft.Configuration.GenAI
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Net;
	using System.Threading;
	using System.Threading.Tasks;
	using Creatio.FeatureToggling;
	using global::Common.Logging;
	using Terrasoft.Common;
	using Terrasoft.Common.Json;
	using Terrasoft.Common.Threading;
	using Terrasoft.Configuration.Enrichment;
	using Terrasoft.Core;
	using Terrasoft.Core.Applications.GenAI;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Requests;
	using Terrasoft.Enrichment.Interfaces.ChatCompletion.Requests;
	using Terrasoft.Enrichment.Interfaces.ChatCompletion.Responses;
	using Terrasoft.Enrichment.Interfaces.GenAI;
	using Terrasoft.Enrichment.Interfaces.GenAI.Model;
	using Terrasoft.Enrichment.Interfaces.GenAI.Requests;
	using Terrasoft.Enrichment.Interfaces.GenAI.Responses;
	using Terrasoft.OAuthIntegration;
	using Terrasoft.OAuthIntegration.Exception;
	using Terrasoft.Core.Entities;

	#region Class: GenAiServiceProxy

	[DefaultBinding(typeof(IGenAIAppServiceProxy))]
	[DefaultBinding(typeof(IGenAICompletionServiceProxy))]
	[DefaultBinding(typeof(IGenAILlmConfigurationServiceProxy))]
	public class GenAiServiceProxy: IGenAIAppServiceProxy, IGenAICompletionServiceProxy, IGenAILlmConfigurationServiceProxy
	{

		#region Constants: Private

		private const string ObsoleteServiceUrlSettingsName = "AccountEnrichmentServiceUrl";
		private const string GenAiServiceUrlSettingsName = "GenAIServiceUrl";
		private const string GenerateEntitiesByDescriptionPath = "/generateEntitiesByDescription";
		private const string GenerateDcmStagesByDescriptionPath = "/generateDcmStagesByDescription";
		private const string GenerateDataPath = "/generateData";
		private const string ChatCompletionPath = "/getChatCompletion";
		private const string ClientQuotaPath = "/clientQuota";
		private const string LlmModelConfigurationCreatePath = "/llmmodelconfiguration/create";
		private const string LlmModelConfigurationUpdatePath = "/llmmodelconfiguration/update";
		private const string LlmModelConfigurationDeletePath = "/llmmodelconfiguration/delete";
		private const int DefaultTimeoutSec = 240;
		private const int DefaultMaxUserQueryLength = 8000;

		#endregion

		#region Fields: Private

		private readonly ILlmModelCategoryRepository _modelCategoryRepository;
		private static readonly ILog _log = LogManager.GetLogger("Enrichment");
		private readonly UserConnection _userConnection;
		private string _baseUrl;

		#endregion

		#region Properties: Protected

		private IIdentityServiceWrapper _identityServiceWrapper;

		protected virtual IIdentityServiceWrapper IdentityServiceWrapper => _identityServiceWrapper ??
			(_identityServiceWrapper = IdentityServiceWrapperHelper.GetInstance());

		#endregion

		#region Constructors: Public

		public GenAiServiceProxy(UserConnection userConnection, ILlmModelCategoryRepository modelCategoryRepository) {
			_userConnection = userConnection;
			_modelCategoryRepository = modelCategoryRepository;
		}

		#endregion

		#region Methods: Private

		private string GetServiceUrl() {
			string result = SysSettings.GetValue(_userConnection, GenAiServiceUrlSettingsName, string.Empty);
			if (result.IsNotNullOrEmpty()) {
				return result;
			}
			result = SysSettings.GetValue(_userConnection, ObsoleteServiceUrlSettingsName, string.Empty);
			if (result.IsNotNullOrEmpty()) {
				_log.Debug($"Using '{ObsoleteServiceUrlSettingsName}' instead of '{GenAiServiceUrlSettingsName}'");
				return result;
			}
			throw new IncorrectConfigurationException(GenAiServiceUrlSettingsName);
		}

		private IHttpRequestClient CreateClient() {
			_baseUrl = GetServiceUrl();
			return HttpRequestClientFactory.TryGetNamedInstance("EnrichmentServiceHttpClient", out var client)
				? client
				: HttpRequestClientFactory.GetInstanceFromDI();
		}

		private HttpRequestConfig CreateRequest(object body, string resource, HttpRequestMethod method, CancellationToken token = default) {
			var requestConfig = new HttpRequestConfig(_baseUrl, resource) {
				Body = body,
				Method = method,
				CancellationToken = token
			};
			if (Features.GetIsEnabled<GenAIFeatures.UseMockServiceForAIRequest>()) {
				SysSettings.TryGetValue(_userConnection, "GenAIMockServerId", out object mockServerIdHeader);
				requestConfig.Headers.Add("x-mock-server-id", mockServerIdHeader?.ToString() ?? "true");
				requestConfig.Headers.Add("UseMockServer", "true");
			}
			return requestConfig.WithOAuth<EnrichmentFeatures.UseOAuth>(IdentityServiceWrapper, "use_enrichment");
		}

		private LocalizableString GetLocalizedString(string resourceName) {
			var localizableString = $"LocalizableStrings.{resourceName}.Value";
			return new LocalizableString(_userConnection.ResourceStorage, GetType().Name, localizableString);
		}

		private string GetErrorMessage(GenAIServiceError? genAIServiceError) {
			var errorMapping = new Dictionary<GenAIServiceError, string> {
				{ GenAIServiceError.MissingApiKey, "Error_401_AuthError" },
				{ GenAIServiceError.InvalidRequest, "Error_401_AuthError" },
				{ GenAIServiceError.ServerError, "Error_500_Unknown" },
				{ GenAIServiceError.RateLimitReached, "Error_508_QuotaExceed" },
				{ GenAIServiceError.InsufficientQuota, "Error_508_QuotaExceed" },
				{ GenAIServiceError.QuotaExceeded, "Error_508_QuotaExceed" },
				{ GenAIServiceError.ModelNotFound, "Error_500_Unknown" },
				{ GenAIServiceError.ModelError, "Error_500_Unknown" },
				{ GenAIServiceError.InvalidResponse, "Error_500_WrongAnswer" },
				{ GenAIServiceError.UnauthorizedClient, "Error_401_AuthError" },
				{ GenAIServiceError.UnsupportedGrantType, "Error_401_AuthError" },
				{ GenAIServiceError.InvalidScope, "Error_401_AuthError" },
				{ GenAIServiceError.RequestTimeout, "Error_504_Timeout" },
				{ GenAIServiceError.NetworkError, "Error_503_GenAIUnavailable" },
				{ GenAIServiceError.InvalidJson, "Error_500_Unknown" },
				{ GenAIServiceError.EngineOverloaded, "Error_503_GenAIUnavailable" },
				{ GenAIServiceError.InvalidApiKey, "Error_401_AuthError" },
				{ GenAIServiceError.Unknown, "Error_500_Unknown" },
				{ GenAIServiceError.ActionsRateLimitReached, "Error_508_QuotaExceed" },
				{ GenAIServiceError.ActionsInsufficientQuota, "Error_508_QuotaExceed" },
				{ GenAIServiceError.ActionsQuotaExceeded, "Error_508_QuotaExceed" },
				{ GenAIServiceError.ActionsLimitExceeded, "Error_508_QuotaExceed" }
			};
			if (!genAIServiceError.HasValue ||
					!errorMapping.TryGetValue(genAIServiceError.Value, out string resourceName)) {
				resourceName = "Error_500_Unknown";
			}
			return GetLocalizedString(resourceName);
		}

		private void HandleError(IHttpResponse response) {
			if (response.StatusCode != HttpStatusCode.OK) {
				GenAIErrorResponse errorResponse = null;
				try {
					errorResponse = Json.Deserialize<GenAIErrorResponse>(response.Content);
				} catch (Exception e) {
					_log.Error(response?.Content);
					_log.Error(e);
				}
				if (errorResponse?.Error.HasValue == true) {
					_log.Error($"GenAI error occurred with status code = {response.StatusCode.ToString()}. " +
						$"Error: {errorResponse.Error.ToString()}, message: {errorResponse.Message}");
					if (errorResponse.Error == GenAIServiceError.InternalQuotaExceeded) {
						throw new GenAIException(GenAIServiceErrorCode.LimitExceeded, "You have reached quota limit: " +
							$"{errorResponse.Message} \nTry again later or ask administrator for help");
					}
					if (errorResponse.Error == GenAIServiceError.ModelConfigurationError) {
						throw new GenAIException(GenAIServiceErrorCode.ModelConfigurationError,
							"An error occurred while processing the model configuration: " + $"{errorResponse.Message}");
					}
					string errorMessage = GetErrorMessage(errorResponse.Error);
					throw new GenAIException(errorResponse.Error.ToString(), errorMessage) {
						RawError = errorResponse.Message
					};
				}
			}
			response.HandleError();
		}

		private IHttpResponse CreateAndExecutePostRequest(string resource, object body) {
			return AsyncPump.Run(() => CreateAndExecuteRequestAsync(resource, body, HttpRequestMethod.POST, CancellationToken.None));
		}

		private IHttpResponse CreateAndExecutePutRequest(string resource, object body) {
			return AsyncPump.Run(() => CreateAndExecuteRequestAsync(resource, body, HttpRequestMethod.PUT, CancellationToken.None));
		}

		private IHttpResponse CreateAndExecuteDeleteRequest(string resource, object body) {
			return AsyncPump.Run(() => CreateAndExecuteRequestAsync(resource, body, HttpRequestMethod.DELETE, CancellationToken.None));
		}

		private IHttpResponse CreateAndExecuteGetRequest(string resource) {
			return AsyncPump.Run(() => CreateAndExecuteRequestAsync(resource, null, HttpRequestMethod.GET, CancellationToken.None));
		}

		private async Task<IHttpResponse> CreateAndExecuteRequestAsync(string resource, object body,
				HttpRequestMethod method, CancellationToken token = default) {
			IHttpResponse response = null;
			try {
				IHttpRequestClient client = CreateClient();
				HttpRequestConfig request = CreateRequest(body, resource, method, token);
				request.RequestTimeout = DefaultTimeoutSec * 1000;
				response = method == HttpRequestMethod.GET
					? client.Send(request)
					: await client.SendWithJsonBodyAsync(request);
				HandleError(response);
				return response;
			} catch (GenAIException e) {
				_log.Error(e.RawError, e);
				throw;
			} catch (UnauthorizedAccessException e) {
				throw new GenAIException(GenAIServiceErrorCode.Unauthorized, e.Message, e);
			} catch (UriFormatException e) {
				_log.Error($"Invalid uri while using GenAI '{resource}': {_baseUrl}", e);
				throw new GenAIException(GenAIServiceErrorCode.InvalidUri,
					"Incorrect service URL. Check system settings or ask administrator", e) {
					RawError = e.Message
				};
			} catch (Exception e) {
				if (e is IncorrectConfigurationException
						|| e is ApiServerException || e is ApiServerConnectivityException) {
					_log.Error(e.Message);
					string message = e is IncorrectConfigurationException
						? e.Message
						: "Incorrect OAuth settings. Check system settings or ask administrator";
					throw new GenAIException(GenAIServiceErrorCode.IncorrectConfiguration, message, e) {
						RawError = e.Message
					};
				}
				if (e is WebException || e.InnerException is WebException || response?.StatusCode == HttpStatusCode.NotFound
						|| response?.StatusCode == HttpStatusCode.ServiceUnavailable) {
					string errorMessage = $"Server ({_baseUrl}) is not available while generating data using " +
						$"{resource}. Status code: {response?.StatusCode}. \n\nCheck system settings or ask administrator";
					_log.Error(errorMessage, e);
					throw new GenAIException(GenAIServiceErrorCode.ServerNotAvailable, errorMessage, e) {
						RawError = e.Message
					};
				}
				_log.Error($"Unknown error while generating data using '{resource}'", e);
				throw new GenAIException(GenAIServiceErrorCode.UnknownError,
					$"An error occurred while generating data: " + $"{e.Message}", e) {
					RawError = e.Message
				};
			}
		}

		private void ApplyCustomProviderParams(ChatCompletionRequest completionRequest) {
			if (SysSettings.TryGetValue(_userConnection, "GenAIProviderType", out object providerTypeObj)
					&& Enum.TryParse((string)providerTypeObj, out GenAIProviderType providerType)
					&& providerType != GenAIProviderType.Default) {
				completionRequest.ProviderType = providerType;
			} else {
				return;
			}
			ApplyCustomApiKeyAndModel(completionRequest);
			if (providerType == GenAIProviderType.Azure) {
				ApplyCustomAzureParams(completionRequest);
			}
		}

		private void ApplyCustomAzureParams(ChatCompletionRequest completionRequest) {
			if (SysSettings.TryGetValue(_userConnection, "GenAIAzureDeploymentId", out object azureDeploymentIdObj)) {
				var azureDeploymentId = (string)azureDeploymentIdObj;
				if (azureDeploymentId.IsNotNullOrEmpty()) {
					completionRequest.AzureDeploymentId = azureDeploymentId;
				}
			}
			if (SysSettings.TryGetValue(_userConnection, "GenAIAzureResourceName", out object azureResourceNameObj)) {
				var azureResourceName = (string)azureResourceNameObj;
				if (azureResourceName.IsNotNullOrEmpty()) {
					completionRequest.AzureResourceName = azureResourceName;
				}
			}
		}

		private void ApplyCustomApiKeyAndModel(ChatCompletionRequest completionRequest) {
			if (!SysSettings.TryGetValue(_userConnection, "GenAIApiKey", out object apiKeyObj)) {
				return;
			}
			var apiKey = (string)apiKeyObj;
			if (apiKey.IsNullOrWhiteSpace()) {
				return;
			}
			completionRequest.GenAIServiceApiKey = apiKey;
			if (!SysSettings.TryGetValue(_userConnection, "GenAIModel", out object modelObj)) {
				return;
			}
			var model = (string)modelObj;
			if (model.IsNotNullOrEmpty()) {
				completionRequest.Model = model;
			}
		}

		private void ValidateChatCompletionRequest(ChatCompletionRequest request) {
			try {
				CheckMessageLength(request);
			}
			catch (GenAIException e) {
				_log.Error(e.RawError, e);
				throw;
			}
		}

		private void CheckMessageLength(ChatCompletionRequest request) {
			var maxUserQueryLength = SysSettings.GetValue(_userConnection, "CreatioAIMaxUserQueryLength", DefaultMaxUserQueryLength);
			var userMessage = request.Messages
				?.LastOrDefault(m => m.Role.Equals("user", StringComparison.OrdinalIgnoreCase))
				?.Content ?? string.Empty;
			if (userMessage.Length > maxUserQueryLength) {
				throw new GenAIException(GenAIServiceErrorCode.CharacterLimitExceededError,
					$"Query text length exceeds the maximum limit ({maxUserQueryLength}).");
			}
		}
		
		private string GetDefaultLlmModelCode() {
			return _modelCategoryRepository.FindByCategory(LlmModelCategoryCode.Default)?.Code;
		}

		#endregion

		#region Methods: Public

		public List<GenAIEntity> GenerateEntitiesByDescription(string description) {
			var response = CreateAndExecutePostRequest(GenerateEntitiesByDescriptionPath,
				new GenerateContentByDescriptionRequest {
					Description = description
				});
			var responseObj = response.GetResult<GenerateEntitiesByDescriptionResponse>();
			return responseObj.Entities ?? new List<GenAIEntity>();
		}

		public List<string> GenerateDcmStages(string description) {
			var response = CreateAndExecutePostRequest(GenerateDcmStagesByDescriptionPath,
				new GenerateContentByDescriptionRequest {
					Description = description
				});
			var responseObj = response.GetResult<GenerateDcmStagesByDescriptionResponse>();
			return responseObj.DcmStages?.Select(x => x.ToLowerInvariant().ToCamelCase()).ToList() ?? new List<string>();
		}

		public List<GenAIEntityData> GenerateData(string description, List<GenAIEntity> entities) {
			var response = CreateAndExecutePostRequest(GenerateDataPath,
				new GenerateDataRequest {
					Description = description,
					Entities = entities
				});
			var responseObj = response.GetResult<GenerateDataResponse>();
			return responseObj.Data ?? new List<GenAIEntityData>();
		}

		public ChatCompletionResponse ChatCompletion(ChatCompletionRequest request,
				ChatCompletionRequestOptions options = null) {
			return AsyncPump.Run(() => ChatCompletionAsync(request, CancellationToken.None, options));
		}

		public async Task<ChatCompletionResponse> ChatCompletionAsync(ChatCompletionRequest request,
				CancellationToken token = default, ChatCompletionRequestOptions options = null) {
			options = options ?? ChatCompletionRequestOptions.Default;
			if (!options.SkipValidation) {
				ValidateChatCompletionRequest(request);
			}
			if (string.IsNullOrEmpty(request.Model)) {
				request.Model = GetDefaultLlmModelCode();
			}
			ApplyCustomProviderParams(request);
			IHttpResponse response = await CreateAndExecuteRequestAsync(ChatCompletionPath, request, HttpRequestMethod.POST, token);
			return response.GetResult<ChatCompletionResponse>();
		}

		public ClientQuotaResponse GetClientQuotaByClientId() {
			IHttpResponse response = CreateAndExecuteGetRequest(ClientQuotaPath);
			return response.GetResult<ClientQuotaResponse>();
		}

		public void AddLlmConfiguration(ModelConfiguration configuration) {
			var request = configuration.ToAddRequest();
			CreateAndExecutePostRequest(LlmModelConfigurationCreatePath, request);
		}

		public void UpdateLlmConfiguration(ModelConfiguration configuration) {
			var request = configuration.ToUpdateRequest();
			CreateAndExecutePutRequest(LlmModelConfigurationUpdatePath, request);
		}

		public void DeleteLlmConfiguration(ModelConfiguration configuration) {
			var request = configuration.ToDeleteRequest();
			CreateAndExecuteDeleteRequest(LlmModelConfigurationDeletePath, request);
		}

		#endregion

	}

	#endregion

}

