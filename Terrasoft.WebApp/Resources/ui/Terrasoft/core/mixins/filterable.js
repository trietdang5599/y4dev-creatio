/**
 * Mixin, which adds filtering capabilities to the collection, array, any item store.
 * Used in {@link Terrasoft.Collection}.
 * To mix a mixin, the class must implement the filterByFn method, where the bust and filtering will be implemented
 * elements, by filtering function and return of the result
 */
Ext.define("Terrasoft.core.mixins.Filterable", {
	alternateClassName: "Terrasoft.Filterable",

	/**
	 * A regular expression pattern to check that the search string begins with a filter
	 * @private
	 * @type {String}
	 */
	startWithRE: "^{test_string}",

	/**
	 * A regular expression pattern to check that the search string includes a filter
	 * @private
	 * @type {String}
	 */
	containRE: "{test_string}",

	/**
	 * Type of filter operation
	 * @type {Terrasoft.StringFilterType}
	 */
	filterType: Terrasoft.StringFilterType.START_WITH,

	/**
	 * Sort list by start with results if filter type equal to contain.
	 * @param {Terrasoft.Collection} list Collection
	 * @param {String} property Filter element property
	 * @param {String/Number} value Value-Filter
	 * @param {Terrasoft.StringFilterType} filterType Type of filtration
	 */
	sortByStartWith: function(list, property, value, filterType) {
		if (list && list.getCount() > 0 && filterType === Terrasoft.StringFilterType.CONTAIN) {
			const fn = this.generateFilterFn(property, value, Terrasoft.StringFilterType.START_WITH);
			const resultStartWith = this.filterByFn(fn);
			Terrasoft.each(resultStartWith, (item, newIndex) => {
				const oldIndex = list.indexOf(item);
				list.move(oldIndex, newIndex);
			}, this);
		}
	},

	/**
	 * Returns the standard filter function
	 * @private
	 * @param  {String} property Element property fir filtering
	 * @param  {RegExp} filterRE A regular expression for checking compliance
	 * @return {Function} Returns the filter function
	 */
	getDefaultFilterFn: function(property, filterRE) {
		const fn = function(item) {
			const propertyValue = item[property];
			return filterRE.test(propertyValue);
		};
		return fn;
	},

	/**
	 * Generates a filter function
	 * @private
	 * @param  {String} property Filter element property
	 * @param  {String/Number} value Value-Filter
	 * @param  {Terrasoft.StringFilterType} filterType Type of filtration
	 * @return {Function} Returns the filter function
	 */
	generateFilterFn: function(property, value, filterType) {
		value = Ext.String.escapeRegex(value);
		const filterOperationType = filterType || this.filterType;
		let stringFilterRE = (filterOperationType === Terrasoft.StringFilterType.START_WITH)
			? this.startWithRE
			: this.containRE;
		stringFilterRE = stringFilterRE.replace("{test_string}", value);
		const filterRE = new RegExp(stringFilterRE, "i");
		return this.getDefaultFilterFn(property, filterRE);
	},

	/**
	 * Filter the collection \ array of elements and return a new filtered collection.
	 *
	 * Example 1:
	 * <pre><code>
		 var collection = Ext.create('Terrasoft.Collection');
		collection.add('key1', {Name: 'Texas'});
		collection.add('key2', {Name: 'Wisconsin'});
		collection.add('key3', {Name: 'Alaska'});
		collection.add('key4', {Name: 'Alabama'});

		// Returns a new collection with two elements: Alaska and Alabama
		var filteredCollection = collection.filter('Name', 'Ala');
		</code></pre>
	 * Example 2, using a custom filter function:
	 * <pre><code>
		var collection = Ext.create('Terrasoft.Collection');
		collection.add('key1', {Name: 'Mercedes'});
		collection.add('key2', {Name: 'Bentley'});
		collection.add('key3', {Name: 'Mitsubishi'});
		collection.add('key4', {Name: 'Volvo'});

		// Return a new collection with elements that include the letter 'e': Mercedes and Bentley
		var filteredCollection = collection.filter(function(item, key) {
		 return (item.indexOf('e') > -1);
		});
		</code></pre>
	 * @param  {String} property Filter element property
	 * @param  {String/Number} value Value-Filter
	 * @param  {Terrasoft.StringFilterType} filterType Type of filtration
	 * @param  {Object} [options] Options of filtration
	 * @param  {Boolean} [options].sortByStartWith Sort items by startWith, enabled by default.
	 * @return {Terrasoft.Collection|Array|Object} Returns the collection \ an array of the original type
	 */
	filter: function(property, value, filterType, options = {sortByStartWith:true}) {
		if (arguments.length === 1 && Ext.isFunction(arguments[0])) {
			return this.filterByFn(arguments[0]);
		}
		const fn = this.generateFilterFn(property, value, filterType);
		const result = this.filterByFn(fn);
		if (options?.sortByStartWith) {
			this.sortByStartWith(result, property, value, filterType);
		}
		return result;
	}
});
