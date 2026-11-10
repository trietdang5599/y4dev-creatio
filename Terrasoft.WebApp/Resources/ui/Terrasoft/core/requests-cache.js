Ext.define("Terrasoft.core.RequestsCache", {
	extend: "Terrasoft.DynamicCache",
	alternateClassName: "Terrasoft.RequestsCache",
	singleton: true,

	/**
	 * @private
	 */
	_maxRequestsCachingTtl: 5000,

	/**
	 * Constructor.
	 */
	constructor: function() {
		this._setExpirationInterval();
		this.callParent(arguments);
	},

	/**
	 * @private
	 */
	_setExpirationInterval: function() {
		const expirationInterval = Terrasoft.RequestsCachingSettings && Terrasoft.RequestsCachingSettings.ttl;
		if(expirationInterval > 0 && expirationInterval <= this._maxRequestsCachingTtl) {
			this.expirationInterval = expirationInterval;
		} else {
			console.warn(
				`Unsupported requests caching TTL: ${expirationInterval}. ` +
				`The value must be greater than 0 and less than or equal to ${this._maxRequestsCachingTtl}. ` +
				`By default the TTL was set to ${this.expirationInterval}.`
			);
		}
	},

	/**
	 * @private
	 */
	_getRequestOrThrow: function(options) {
		const cachedRequest = this.getRequest(options);
		if(cachedRequest) {
			return cachedRequest;
		}
		throw `The '${this.getKey(options)}' request not found.`;
	},

	/**
	 * @private
	 */
	_getJsonBody: function(jsonData) {
		const jsonObj = typeof jsonData === "string" ? JSON.parse(jsonData) : jsonData;
		const jsonStr = JSON.stringify(jsonObj);
		if(this._hasDynamicKeys(jsonObj)) {
			return this._cutDynamicKeys(jsonStr);
		}
		return jsonStr;
	},

	/**
	 * @private
	 */
	_hasDynamicKeys: function(jsonObj) {
		return Boolean(jsonObj.rootSchemaName);
	},

	/**
	 * @private
	 */
	_cutDynamicKeys: function(jsonStr) {
		const guidPattern = /"[0-9a-f]{8}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{12}":/gi;
		let match = 0;
		return jsonStr.replace(guidPattern, () => {
			match++;
			return `"#${match}":`;
		});
	},

	/**
	 * @inheritDoc Terrasoft.DynamicCache#canRemoveValue
	 * @overridden
	 */
	canRemoveValue: function(value) {
		return Boolean(value && value.completed);
	},

	/**
	 * Gets a cache key by a specified request options.
	 * @param {Object} options The request options.
	 * @return {String} Returns the cache key.
	 */
	getKey: function(options) {
		if(!options) {
			throw "Cannot create cache key: invalid options.";
		}
		let key = '';
		if(options.method) {
			key += options.method;
		}
		if(options.url) {
			key += options.url;
		}
		if(options.jsonData) {
			key += this._getJsonBody(options.jsonData)
		}
		return key;
	},

	/**
	 * Gets a cached request by a specified request options.
	 * @param {Object} options The request options.
	 * @return {Object} Returns the cache request.
	 */
	getRequest: function(options) {
		const cacheKey = this.getKey(options);
		return this.getValue(cacheKey);
	},

	/**
	 * Gets a cached request by a specified request options.
	 * @param {Object} options The request options.
	 * @return {String[]} Returns the cache request.
	 */
	initRequest: function(options) {
		this.log('INIT CACHING REQUEST: ' + options?.url);
		const cacheKey = this.getKey(options);
		const cachedRequest = {
			queue: [],
			completed: false,
		};
		this.setValue(cacheKey, cachedRequest);
	},

	/**
	 * Queues a request to the cached request by a specified options.
	 * @param {Object} options The request options.
	 * @returns {Number} The request position in the queue.
	 */
	queueRequest: function(options) {
		const cachedRequest = this._getRequestOrThrow(options);
		const queuedRequestOptions = Object.assign({}, options);
		const queueLength = cachedRequest.queue.push(queuedRequestOptions);
		this.updateRequest(options, cachedRequest);
		const queuePosition = queueLength - 1;
		this.log('QUEUE REQUEST (queuePosition = ' + queuePosition + '): ' + options?.url);
		return queuePosition;
	},

	/**
	 * Dequeues a request from the cached request by a specified options.
	 * @param {Object} options The request options.
	 * @param {Number} options The request position in the queue.
	 * @returns {Object} The request from the queue.
	 */
	dequeueRequest: function(options, queuePosition) {
		if(queuePosition == null) {
			queuePosition = 0;
		}
		const cachedRequest = this._getRequestOrThrow(options);
		const queuedRequest = cachedRequest.queue[queuePosition];
		if(queuedRequest == null) {
			return;
		}
		this.log('DEQUEUE REQUEST (queuePosition = ' + queuePosition + '): ' + options?.url);
		cachedRequest.queue.splice(queuePosition, 1);
		this.updateRequest(options, cachedRequest);
		return queuedRequest;
	},

	/**
	 * Updates a cached request by a specified options.
	 * @param {Object} options The request options.
	 * @param {Number} value The request value to be assigned on a cached request value.
	 */
	updateRequest: function(options, value) {
		this.log('UPDATE REQUEST: ' + options?.url);
		const cacheKey = this.getKey(options);
		this.updateValue(cacheKey, value);
	},

	/**
	 * Removes a request from the cache by a specified options.
	 * @param {Object} options The request options.
	 */
	removeRequest: function(options) {
		this.log('REMOVE REQUEST: ' + options?.url);
		const cacheKey = this.getKey(options);
		this.removeValue(cacheKey);
	}
});