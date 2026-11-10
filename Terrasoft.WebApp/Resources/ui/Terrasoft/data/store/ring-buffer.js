/**
 * Ring-buffer storage at the JavaScript level
 */
Ext.define("Terrasoft.data.store.RingBuffer", {
	extend: "Terrasoft.core.BaseObject",
	alternateClassName: "Terrasoft.RingBuffer",

	/**
	 * Data storage.
	 * @private
	 * @type {Object}
	 */
	_storage: null,

	/**
	 * Max storage items count.
	 * @private
	 * @type {Integer}
	 */
	_maxLength: 0,

	/**
	 * Tail index of the ring-buffer (first free item index).
	 * @private
	 * @type {Integer}
	 */
	_tail: 0,

	/**
	 * Stores only unique items.
	 * @private
	 * @type {Boolean}
	 */
	_isOnlyUniqueItems: false,

	/**
	 * @inheritdoc Terrasoft.BaseObject#constructor
	 * @param {Object} config Initial parameters for configuring the ring-buffer.
	 * @param {Integer} config.maxLength Max storage items count.
	 * @param {Boolean} config.isOnlyUniqueItems Flag indicating not to save duplicate items to the storage.
	 */
	constructor: function(config) {
		Terrasoft.checkArguments(arguments, "config");
		this._maxLength = config.maxLength;
		this._storage = new Array(this._maxLength);
		this._isOnlyUniqueItems = Boolean(config.isOnlyUniqueItems);
	},

	/**
	 * Saves the item at the tail of the ring-buffer.
	 * @param {Object} item Pushed item.
	 */
	pushItem: function(item) {
		Terrasoft.checkArgumentsDefined(arguments, "item");
		if (this._isOnlyUniqueItems && this.getIsItemExists(item)) {
			return;
		}
		this._storage[this._tail++] = item;
		if (this._tail === this._maxLength) {
			this._tail = 0;
		}
	},

	/**
	 * Finds item in the ring-buffer.
	 * @param {Object} item Searched item.
	 * @return {Boolean} True when item found, otherwise false.
	 */
	getIsItemExists: function(item) {
		Terrasoft.checkArgumentsDefined(arguments, "item");
		return Boolean(this._storage.indexOf(item) >= 0);
	},

	/**
	 * Clears all items in the ring-buffer.
	 */
	clear: function() {
		this._storage.fill(undefined);
		this._tail = 0;
	}
});
