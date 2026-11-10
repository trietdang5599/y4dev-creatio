/**
 * Used to register process execution data created when processes started.
 * Registered process execution data used to open process pages etc.
 */
Ext.define("Terrasoft.Core.Process.ExecutionDataCollector", {
	alternateClassName: "Terrasoft.ProcessExecutionDataCollector",
	extend: "Terrasoft.BaseObject",
	singleton: true,

	// region Fields: Private

	_buffer: null,

	//endregion

	// region Constructors: Public

	/**
	 * @inheritdoc Terrasoft.BaseObject#constructor
	 * @override
	 */
	constructor: function() {
		this.callParent(arguments);
		this.addEvents("executionDataReady");
		this._buffer = [];
		if (!Boolean(window.creatio)) {
			window['creatio'] = {};
		}
		if (!Boolean(window.creatio.tabId)) {
			window.creatio.tabId = Terrasoft.generateGUID();
		}
		this.sessionId = window.creatio.tabId;
	},

	//endregion

	sessionId: null,

	// region Methods: Private

	/**
	 * @private
	 * @param item
	 * @private
	 */
	_addItem: function(item) {
		if (this.hasListener("executionDataReady")) {
			this.fireEvent("executionDataReady", item);
		} else {
			this._buffer.push(item);
		}
	},

	//endregion

	// region Methods: Private

	/**
	 * Used to register process execution data.
	 * @param {Array} executionData Process execution data.
	 * @param {Object} options Options.
	 */
	add: function(executionData, options) {
		if (!executionData) {
			return;
		}
		const item = {executionData: executionData};
		if (options) {
			Ext.apply(item, options);
		}
		this._addItem(item);
	},

	/**
	 * Used internally to get all published but not processed items.
	 */
	flushBufferedItems: function() {
		const items = this._buffer.splice(0);
		let item;
		while ((item = items.pop())) {
			this._addItem(item);
		}
	}

	//endregion

});
