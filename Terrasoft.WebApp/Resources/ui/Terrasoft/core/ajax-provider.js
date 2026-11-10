/**
  * The transport layer for querying the server
 */
Ext.define("Terrasoft.core.AjaxProvider", {
	extend: "Terrasoft.BaseObject",
	alternateClassName: "Terrasoft.AjaxProvider",
	singleton: true,

	/**
	 * @private
	 */
	_requestsCachingOptions: null,

	/**
	 * @private
	 */
	_deferredExecutionDispatcher: null,

	/**
  * Provider for execution of Ajax-requests
  * @private
  * @type {Object}
  */
	extAjax: Ext.Ajax,

	/**
  * The maximum length of a string of data output to the log when the query error is logged.
  * @private
  * @type {Number}
  */
	maxDataLogSize: 150,

	/**
	 * Request store.
	 * @private
	 * @type {Object}
	 */
	requests: {},

	/**
	 * Array of active requests.
	 * @private
	 * @type {Array}
	 */
	_activeRequests: null,

	/**
	 * JWT token storage key.
	 * @private
	 * @type {String}
	 */
	jwtTokenStorageKey: "accessToken",

	/**
	 * The name of the header that contains the authorization token.
	 * @private
	 * @type {String}
	 */
	authorizationHeader: "Authorization",

	/**
	 * The template for the authorization header value.
	 * @private
	 * @type {String}
	 */
	authorizationHeaderValueTpl: "Bearer {0}",

	/**
	 * The dynamic requests cache.
	 * @protected
	 * @type {Terrasoft.RequestsCache}
	 */
	requestsCache: Terrasoft.RequestsCache,

	/**
	 * @private
	 */
	_log: function(message) {
		if(Terrasoft.isDebug) {
			console.log(message);
		}
	},

	/**
	 * Gets the CSRF cookie name.
	 * @private
	 * @return {String}
	 */
	_getCsrfCookieName: function() {
		return Terrasoft.csrfCookieName;
	},

	/**
	 * @private
	 */
	_markRequestAsNotActive: function(requestObj) {
		const index = this._activeRequests.indexOf(requestObj);
		if (index > -1) {
			this._activeRequests.splice(index, 1);
		}
	},

	/**
	 * @private
	 */
	_dequeueCachedRequest: function(requestObj) {
		const requestConfig = requestObj.options;
		const queuePosition = requestObj.queueId;
		if(this._isRequestCachingDisabled(requestConfig) || queuePosition == null) {
			return;
		}
		this._log('DEQUEUEU REQUEST: ' + requestConfig.url, ', queueId: ' + queuePosition);
		this.requestsCache.dequeueRequest(requestObj.options, queuePosition);
	},

	/**
	 * @private
	 */
	_setResponseToCachedRequest: function(options, success, response) {
		if(this._isRequestCachingDisabled(options)) {
			return;
		}
		this._log('SET RESPONSE TO CACHED REQUEST: ' + options.url);
		var cachedRequest = this.requestsCache.getRequest(options);
		if(cachedRequest == null) {
			return;
		}
		var cachedQueueRequests = cachedRequest.queue.concat([]);
		cachedRequest.queue = [];
		cachedRequest.response = {
			body: response,
			success: success,
		};
		cachedRequest.completed = true;
		this.requestsCache.updateRequest(options, cachedRequest);
		this._log('CALL CALLBACK FOR QUEUED REQUESTS: ' + options.url + ', sucess: ' + success)
		cachedQueueRequests.forEach((requestConfig) => {
			const scope = requestConfig.scope;
			const callback = requestConfig.callback;
			if (!scope.destroyed && Ext.isFunction(callback)) {
				callback.call(scope, requestConfig, success, response);
			} else {
				Terrasoft.Mask.clearAllMasks();
			}
		});
	},

	/**
	 * @private
	 */
	_sendNextQueuedCachedRequest: function(options) {
		if(this._isRequestCachingDisabled(options)) {
			return;
		}
		this._log('SEND NEXT REQUEST FROM QUEUE: ' + options.url);
		const cachedRequest = this.requestsCache.getRequest(options);
		if(cachedRequest == null) {
			return;
		}
		var cachedQueueRequests = cachedRequest.queue.concat([]);
		this._log('QUEUEUD REQUESTS: ' + cachedQueueRequests.length);
		this.requestsCache.removeRequest(options);
		cachedQueueRequests.forEach((requestConfig) => {
			this.request(requestConfig);
		}, this);
	},

	/**
	 * @private
	 */
	_isRequestCachingDisabled: function(requestObj) {
		return !this._isRequestCachingEnabled(requestObj);
	},

	/**
	 * @private
	 */
	_isRequestCachingEnabled: function(requestObj) {
		const requestsCachingOptions = this._requestsCachingOptions;
		if(!requestsCachingOptions) {
			return false;
		}
		const isRequestIncluded = this._isRequestExistInConfig(requestObj, requestsCachingOptions.included || []);
		const isRequestExcluded = this._isRequestExistInConfig(requestObj, requestsCachingOptions.excluded || []);
		return isRequestIncluded && !isRequestExcluded;
	},

	/**
	 * @private
	 */
	_isRequestExistInConfig: function(requestObj, requestConfigs) {
		return requestConfigs.some((config) => {
			const expectedUrl = config.url;
			const expectedBody = config.body;
			const expectedMethod = config.method;
			let isRequestMatch = false;
			if(expectedUrl) {
				try {
					isRequestMatch = new RegExp(expectedUrl).test(requestObj.url);
				} catch(error) {
					console.error(error);
					isRequestMatch = false;
				}
			}
			if(expectedBody) {
				try {
					isRequestMatch = new RegExp(expectedBody).test(requestObj.jsonData);
				} catch(error) {
					console.error(error);
					isRequestMatch = false;
				}
			}
			if(expectedMethod) {
				isRequestMatch = requestObj.method === expectedMethod;
			}
			return isRequestMatch;
		});
	},

	/**
	 * @private
	 */
	_setRequestsCachingOptions: function() {
		const requestsCachingOptionsJson = Terrasoft.RequestsCachingSettings && Terrasoft.RequestsCachingSettings.options;
		if(!requestsCachingOptionsJson) {
			return;
		}
		try {
			this._requestsCachingOptions = JSON.parse(requestsCachingOptionsJson);
		} catch(error) {
			console.error(error);
		}
	},

	/**
	 * @private
	 */
	_sendResponseToCallback: function(options, success, response) {
		const scope = options.scope || {};
		const callback = options.callback;
		callback.apply(scope, [options, success, response]);
		/* jshint ignore:start */
		performanceManager.stop(options.url);
		/* jshint ignore:end */
	},

	/**
	 * @private
	 */
	_truncString: function (str) {
		return str.length > 1024 ? `${str.substring(0, 1024)}...` : str;
	},

	/**
	 * @private
	 */
	_getLogMessage: function (options, requestObj, response) {
		const jsonData = options.jsonData;
		const jsonStr = typeof jsonData === "string" ? jsonData : JSON.stringify(jsonData);
		return `<${Terrasoft.SysValue.CURRENT_USER.displayValue}> ` +
			`${requestObj.options.url}\n${this._truncString(jsonStr)}\n--->\n[${response.status}] ` +
			`${this._truncString(response.responseText)}`;
	},

	_processResponse: function(options, success, response, requestObj, instanceId, callback, scope) {
		const serverChannel = Terrasoft.ServerChannel;
		if (success && serverChannel.getConnectionState() === Terrasoft.SocketConnectionState.CLOSED) {
			serverChannel.init();
		}
		success = this.validateResponse(options, success, response);
		if (!scope.destroyed && Ext.isFunction(callback)) {
			callback.call(scope, options, success, response);
			this.setResponseToCache(options, response);
			this._setResponseToCachedRequest(options, success, response);
		} else {
			Terrasoft.Mask.clearAllMasks();
		}
		requestObj.completed = true;
		if (instanceId) {
			delete this.requests[instanceId];
		}
	},

	_getIsSecondFactorNeeded: function(response) {
		return Terrasoft.useSeparatedPage2FA
			&& response.getResponseHeader
			&& response.getResponseHeader('X-Second-Factor-Validation-Status') === 'SecondFactorCodeRequired';
	},

	/**
	 * Constructor.
	 */
	constructor: function() {
		this.callParent(arguments);
		this.addEvents("requestaborted");
		this._activeRequests = [];
		this._deferredExecutionDispatcher = Ext.create("Terrasoft.DeferredExecution.Dispatcher", {
			allowExecutionPredicate: () => this._activeRequests.length === 0
		});
		this._setRequestsCachingOptions();
	},

	/**
	 * Cancels the request if the request is not specified, cancels the last request.
	 * @param {Object} request The request object.
	 */
	abortRequest: function(request) {
		this._dequeueCachedRequest(request);
		this._markRequestAsNotActive(request);
		this._deferredExecutionDispatcher.notify();
		this.extAjax.abort(request);
		/* jshint ignore:start */
		if (typeof performanceManager !== "undefined") {
			performanceManager.stop(request.url);
		}
		/* jshint ignore:end */
		request.terminated = true;
		this.fireEvent("requestaborted", request);
	},

	/**
	 * Cancels execution of the request by the ID of the object requester.
	 * @param {String} instanceId Object instance id.
	 */
	abortRequestByInstanceId: function(instanceId) {
		var request = this.requests[instanceId];
		if (request) {
			this.abortRequest(request);
		}
	},

	/**
	 * Sends an HTTP request to a remote server.
	 * @param {Object} config The configuration object that describes the parameters of AJAX-request.
	 * @param {Object} [config.instanceId] ID of the object requester.
	 * @return {Object} Returns instance of the request.
	 */
	request: function(config) {
		var callback = config.callback;
		var scope = config.scope || {};
		var headers = config.headers = config.headers || {};
		var instanceId = config.instanceId;
		var requestObj;
		var cachedResponse = this.getResponseFromCache(config);
		if (cachedResponse) {
			this._sendResponseToCallback(config, true, cachedResponse);
			return requestObj;
		}
		if (this._isRequestCachingEnabled(config)) {
			var cachedRequest = this.requestsCache.getRequest(config);
			if (cachedRequest) {
				cachedResponse = cachedRequest.response;
				if (cachedResponse) {
					this.warning(
						'GET RESPONSE FROM CACHED REQUEST: ' + config.url + ', success: ' + cachedResponse.success);
					this._sendResponseToCallback(config, cachedResponse.success, cachedResponse.body);
				} else {
					requestObj = {
						options: config,
						queueId: this.requestsCache.queueRequest(config),
					};
					this._log('ADD REQUEST TO QUEUE: ' + config.url + ', queueId: ' + requestObj.queueId);
				}
				return requestObj;
			}
			this._log('INIT CACHING REQUEST: ' + config.url);
			this.requestsCache.initRequest(config);
		}
		config.scope = this;
		config.callback = function(options, success, response) {
			this._markRequestAsNotActive(requestObj);
			this._deferredExecutionDispatcher.notify();
			/* jshint ignore:start */
			performanceManager.stop(options.url);
			/* jshint ignore:end */
			if (requestObj.aborted || requestObj.terminated) {
				this._sendNextQueuedCachedRequest(requestObj.options);
				return;
			}
			if (this._getIsSecondFactorNeeded(response)) {
				Terrasoft.Mask.clearAllMasks();
				const isShell = Terrasoft.isAngularHost;
				window.TwoFactorDialogService.resendRequestWithTwoFactor(options, "AjaxProvider", !isShell)
					.then(response => {
						const replayedResponseSuccess = response.resultCode === 1;
						if (config.forceCallbackOn2FAFail || response.resultCode !== 2) {
							this._processResponse(options, replayedResponseSuccess, response.response, requestObj,
								instanceId, callback, scope);
						}
					});
			} else {
				this._processResponse(options, success, response, requestObj, instanceId, callback, scope);
			}
		};
		if (config.useDefaultHeaders === false) {
			Ext.Ajax.useDefaultXhrHeader = false;
		} else {
			headers["X-Request-Source"] = "ajax-provider";
		}
		this.addCsrfTokenToHeaders(headers);
		this.addJwtTokenToHeaders(headers);
		try {
			/* jshint ignore:start */
			performanceManager.start(config.url);
			/* jshint ignore:end */
			requestObj = this.extAjax.request(config);
		}
		finally {
			Ext.Ajax.useDefaultXhrHeader = true;
		}
		if (instanceId) {
			this.requests[instanceId] = requestObj;
		}
		this._activeRequests.push(requestObj);
		return requestObj;
	},

	/**
  * Generates and logs a query execution error message.
  * @private
  * @param {Object} response Server response.
  * @param {String} errorText The query result error text.
  */
	logResponseError: function(response, errorText) {
		var logMessage = Terrasoft.Resources.AjaxProvider.RequestErrorTemplate;
		logMessage = logMessage.replace("{errorText}", errorText);
		logMessage = logMessage.replace("{errorStatus}", response.status);
		logMessage = logMessage.replace("{errorStatusText}", response.statusText);
		var requestOptions = response.request.options;
		logMessage = logMessage.replace("{requestUrl}", requestOptions.url);
		logMessage = logMessage.replace("{requestMethod}", requestOptions.method);
		var requestDataText, requestData;
		requestData  = requestOptions.jsonData || requestOptions.xmlData || requestOptions.binaryData;
		if (requestData) {
			if (Ext.isObject(requestData) || Ext.isArray(requestData)) {
				var securitySensitiveFields = requestOptions.securitySensitiveFields || [];
				Terrasoft.each(securitySensitiveFields, function(securitySensitiveField) {
						if (requestData[securitySensitiveField]) {
							requestData[securitySensitiveField] = "*******";
						}
				});
				requestDataText = Ext.encode(requestData);
			} else {
				requestDataText = requestData;
			}
		}
		if (requestDataText && (requestDataText.length > this.maxDataLogSize)) {
			requestDataText = requestDataText.substring(0, this.maxDataLogSize) + "...";
		}
		logMessage = logMessage.replace("{requestData}", requestDataText);
		this.error(logMessage);
	},

	/**
  * Performs the validation of the response from the transport server.
  * @private
  * @param {Object} request Request instance.
  * @param {Boolean} success Indicates a successful server response.
  * @param {Object} response Server response.
  * @return {Boolean} true - the response is correct, else - false.
  */
	validateResponse: function(request, success, response) {
		if (success) {
			return true;
		}
		var errorText = "";
		if (response.status === 401) {
			window.location = Terrasoft.loaderBaseUrl;
		} else if (response.status === 0) {
			this.extAjax.abort(request);
			if (response.timedout) {
				errorText = Terrasoft.Resources.AjaxProvider.RequestTimeout;
			} else {
				errorText = Terrasoft.Resources.AjaxProvider.ServerUnavailable;
			}
		}
		if (response.status !== 499) {
			this.logResponseError(response, errorText);
		}
		return false;
	},

	/**
  * Saves the result of the AJAX request to the cache
  * @private
  * @param {Object} options A configuration object that describes the parameters of the AJAX request
  * @param {Object} options.cacheLevel Caching Level
  * @param {Object} options.cacheKey Caching level key
  * @param {Object} response AJAX Request Response Object
  */
	setResponseToCache: function(options, response) {
		if (options.cacheLevel && options.cacheKey) {
			var cache = Terrasoft[options.cacheLevel];
			cache.setItem(options.cacheKey, response);
		}
	},

	/**
  * Gets the result of an AJAX request from the cache
  * @private
  * @param {Object} options A configuration object that describes the parameters of the AJAX request
  * @param {Object} options.cacheLevel Caching Level
  * @param {Object} options.cacheKey Caching level key
  * @return {Object} AJAX Request Response Object
  */
	getResponseFromCache: function(options) {
		var response = null;
		if (options.cacheLevel && options.cacheKey) {
			var cache = Terrasoft[options.cacheLevel];
			response = cache.getItem(options.cacheKey);
		}
		return response;
	},

	/**
	 * Adds Jwt token to header if exist.
	 * @private
	 * @param {Object} headers Request headers.
	 */
	addJwtTokenToHeaders: function(headers) {
		const token = localStorage.getItem(this.jwtTokenStorageKey);
		if (token !== null) {
			headers[this.authorizationHeader] = Ext.String.format(
				this.authorizationHeaderValueTpl, token);
		}
	},

	/**
	 * Adds CSRF token to header if exist.
	 * @private
	 * @param {Object} headers Request headers.
	 */
	addCsrfTokenToHeaders: function(headers) {
		var csrfCookieName = this._getCsrfCookieName();
		var csrfToken = Ext.util.Cookies.get(csrfCookieName);
		if (csrfToken !== null) {
			headers[csrfCookieName] = csrfToken;
		}
	},

	/**
	 * Returns Terrasoft.DeferredExecution.Dispatcher instance that executes callbacks only when there is no active
	 * AJAX request.
	 * @returns {Terrasoft.DeferredExecution.Dispatcher}
	 */
	getDeferredExecutionDispatcher: function() {
		return this._deferredExecutionDispatcher;
	}
});
