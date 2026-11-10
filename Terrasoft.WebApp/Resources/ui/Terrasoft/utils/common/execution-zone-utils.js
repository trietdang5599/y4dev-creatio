Ext.ns("Terrasoft.utils.executionZone");

/**
 * @singleton
 */

const targetExecutionZoneKey = Symbol('targetExecutionZone');

Terrasoft.utils.executionZone.attach = function(contextHolder, zone) {
	if (!zone) return;
	if (contextHolder[targetExecutionZoneKey]) return;
	Object.defineProperty(contextHolder, targetExecutionZoneKey, {
		get: function() {
			return zone;
		}
	});
}

Terrasoft.utils.executionZone.safeExecute = function(contextHolder, callback) {
	const zone = contextHolder[targetExecutionZoneKey];
	if (zone) {
		return zone.run(callback);
	} else {
		return callback();
	}
}