Ext.define("Terrasoft.core.DynamicCache", {
	extend: "Terrasoft.BaseObject",
	alternateClassName: "Terrasoft.DynamicCache",

	/**
	 * @private
	 */
	_store: null,

	/**
	 * @public
	 * @type {Number}
	 */
	expirationInterval: 1000,

	/**
	 * @private
	 */
	_initStore: function() {
		this._store = this._getStore() || {};
	},

	/**
	 * @private
	 */
	_setStoreFlushTimer: function() {
		setInterval(() => {
			const now = new Date().getTime();
			const cacheKeys = this.getKeys();
			cacheKeys.forEach((key) => {
				const value = this._getValue(key);
				const valueLifetime = now - value.cacheTime;
				const isValueTimeExpired = valueLifetime > this.expirationInterval;
				if (isValueTimeExpired && this.canRemoveValue(value.value)) {
					this.log('CLEAR DYNAMIC CACHE: ' + key);
					this.removeValue(key);
				}
			});
		}, this.expirationInterval);
	},

	/**
	 * @private
	 */
	_getStore: function() {
		return this._store;
	},

	/**
	 * @private
	 */
	_getValue: function(key) {
		if(key != null) {
			return this._getStore()[key];
		}
	},

	/**
	 * @protected
	 * Logs a specified message to browser console only in DEBUG mode.
	 * @param {String} message The messsage to log.
	 */
	log: function(message) {
		if(Terrasoft.isDebug) {
			console.log(message);
		}
	},

	/**
	 * @protected
	 * Gets a value indicating whether the value can be removed from cache.
	 * @param {Object} value The cached value.
	 * @return {Boolean} Returns the value indicating whether the value can be removed from cache.
	 */
	canRemoveValue: function(value) {
		return true;
	},

	/**
	 * Constructor.
	 */
	constructor: function() {
		this.callParent(arguments);
		this._initStore();
		this._setStoreFlushTimer();
	},

	/**
	 * Gets a collection of all keys.
	 * @return {String[]} Returns the collection of all cache keys.
	 */
	getKeys: function() {
		const cacheStore = this._getStore();
		return Object.keys(cacheStore);
	},

	/**
	 * Gets a cached value by the specified key.
	 * @param {String} key The key to access a cached value.
	 * @return {*} Returns cached value by the specified key.
	 */
	getValue: function(key) {
		const cachedValue = this._getValue(key);
		return cachedValue && cachedValue.value;
	},

	/**
	 * Sets a value to cache by a specified key.
	 * @param {String} key The key to access a cached value.
	 * @param {*} value The cache value.
	 */
	setValue: function(key, value) {
		if(!key) {
			return;
		}
		const cacheStore = this._getStore();
		const cachedValue = cacheStore[key];
		if(cachedValue) {
			throw `The '${key}' key already exists in the cache.`;
		}
		cacheStore[key] = {
			value: value,
			cacheTime: new Date().getTime()
		};
	},

	/**
	 * Updates a cached value be a specified key.
	 * @param {String} key The key to access a cached value.
	 * @param {Object} value The value to be assigned on a cached value.
	 */
	updateValue: function(key, value) {
		if(!key) {
			return;
		}
		const cacheStore = this._getStore();
		const cachedValue = cacheStore[key];
		if(cachedValue == null) {
			return;
		}
		cacheStore[key].value = value;
	},

	/**
	 * Removes a cached value be a specified key.
	 * @param {String} key The key to access a cached value.
	 */
	removeValue: function(key) {
		if(!key) {
			return;
		}
		const cacheStore = this._getStore();
		delete cacheStore[key];
	}
});