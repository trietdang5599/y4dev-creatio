Ext.define("Terrasoft.configuration.ActivityCacheManager", {
	extend: "Terrasoft.core.SynchronizableCacheManager",

	/**
	 * @private
	 */
	 cacheSysAdminUnitIfNeeded: function(record) {
		var ownerId = record.get("Owner.Id");
		if (!record.dirty || !record.modified.hasOwnProperty("Owner") || !ownerId) {
			return Promise.resolve();
		} else {
			var manager = Terrasoft.ModelCache.getManager("SysAdminUnit");
			return manager.putRecord(record.get("Owner"));
		}
	},

	/**
	 * @inheritdoc
	 * @overridden
	 */
	getIsCached: function() {
		return Promise.resolve(true);
	},

	/**
	 * @inheritdoc
	 * @overridden
	 */
	getIsCachedWithFilters: function() {
		return Promise.resolve(true);
	},

	/**
	 * @inheritdoc
	 * @overridden
	 */
	synchronizeFromCache: function() {
		return Promise.resolve();
	},

	/**
	 * @inheritdoc
	 * @overridden
	 */
	synchronizeToCache: function() {
		return Promise.resolve();
	},

	/**
	 * @inheritdoc
	 * @overridden
	 */
	cacheRelatedRecords: function(record) {
		var args = arguments;
		return this.cacheSysAdminUnitIfNeeded(record).then(function() {
			return Terrasoft.configuration.ActivityCacheManager.superclass.cacheRelatedRecords.apply(this, args);
		}.bind(this));
	}

});

Terrasoft.ModelCache.registerManagerClassName("Activity", "Terrasoft.configuration.ActivityCacheManager");
