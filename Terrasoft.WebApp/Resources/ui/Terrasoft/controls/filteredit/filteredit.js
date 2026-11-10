/**
 * Class for filter edit control.
 */
Ext.define("Terrasoft.controls.FilterEdit", {

	alternateClassName: "Terrasoft.FilterEdit",

	extend: "Terrasoft.Component",

	uses: ["Terrasoft.Collection", "Terrasoft.ListView"],

	translate: Terrasoft.Resources.FilterEdit,

	LogicalOperatorTypeFlipped: Terrasoft.invert(Terrasoft.LogicalOperatorType),

	ComparisonTypeFlipped: Terrasoft.invert(Terrasoft.ComparisonType),

	ComparisonTypeTranslateFlipped: Terrasoft.invert(Terrasoft.Resources.ComparisonType),

	filterManager: null,

	filters: null,

	renderedGroups: null,

	renderedFilters: null,

	selectedFilters: null,

	selectedItems: null,

	openedInput: null,

	openMacrosParameter: null,

	/**
	 * Indicates filters can use process parameters for right expression.
	 * @type {Boolean}
	 */
	useProcessParameters: false,

	/**
	 * Indicates filters can use dcm main record for right expression.
	 * @type {Boolean}
	 */
	useDcmMainRecord: false,

	filterEditConfig: null,

	_scrollPosition: 0,

	/**
	 * Returns default filter config.
	 * @private
	 * @return {Object} Default filter configuration, filterClassName: "Terrasoft.FilterEdit.Filter".
	 */
	_getDefaultConfig: function() {
		return {
			filterClassName: "Terrasoft.FilterEdit.Filter"
		};
	},

	/**
	 * Indicates right expression menu should be aligned to filter element.
	 * @type {Boolean}
	 */
	rightExpressionMenuAligned: false,

	constructor: function() {
		this.callParent(arguments);
		Ext.get(window).on("click", this.onClickOutside, this);
	},

	/**
	 * Returns filter edit config, or default config.
	 * @type {String}
	 */
	getFilterEditConfig: function() {
		return this.filterEditConfig || this._getDefaultConfig();
	},

	init: function() {
		this.callParent(arguments);
		this.addEvents(
			/**
			 * @event selectedFiltersChange
			 * Triggers after 'Selecting filter condition' for executing custom action,
			 * such as group/ungroup/move up/move down.
			 * @param {Object|Array} selectedFilters Current filter or filters that selected.
			 */
			"selectedFiltersChange",

			/**
			 * @event prepareMappingParametersList
			 * Triggers after 'Compare with Parameter' action for filter right expression executed.
			 * @param {Object} config Current filter item config.
			 * @param {Terrasoft.data.filters.BaseFilter} config.filter Current filter.
			 * @param {Function} callback Callback function.
			 * @param {Object} callback.sourceValue Process schema parameter source value for filter right expression.
			 * @param {String} callback.sourceValue.value Parameter source value.
			 * @param {String} callback.sourceValue.displayValue Parameter source display value.
			 * expression.
			 */
			"prepareMappingParametersList",

			/**
			 * @event prepareMainRecordModalBox
			 * Triggers after 'Compare with main record' action for filter right expression executed.
			 * @param {Object} config Current filter item config.
			 * @param {Terrasoft.data.filters.BaseFilter} config.filter Current filter.
			 * @param {Function} callback Callback function.
			 * @param {Object} callback.sourceValue Main record macros source value for filter right expression.
			 * @param {String} callback.sourceValue.value Main record macros source value.
			 * @param {String} callback.sourceValue.displayValue Main record macros display value.
			 * expression.
			 */
			"prepareMainRecordModalBox"
		);
		this.selectors = {
			wrapEl: ""
		};
		this.classes = {
			wrapEl: ["filteredit"]
		};
		this.selectedFilters = {};
		this.selectedItems = {};
		this.renderedGroups = {};
		this.renderedFilters = {};
		this._scrollPosition = 0;
	},

	createEmptyFilterGroup: function() {
		return Ext.create("Terrasoft.FilterGroup");
	},

	onFilterAdd: function(filter) {
		this.update();
		this.processUpdatedFilter(filter);
	},

	onFilterRemove: function(filter, parentFilterGroup, filterKey) {
		const findKey = function(item, key) {
			if (key.indexOf(filterKey) !== -1) {
				this.setSelectedFilters(item);
				return false;
			}
			return true;
		};
		Terrasoft.each(this.selectedFilters, findKey, this);
		this.fireEvent("selectedFiltersChange");
		this.update();
	},

	onFilterChange: function(filter) {
		this.update();
		this.processUpdatedFilter(filter);
	},

	processUpdatedFilter: function(filter) {
		const renderedFilter = this.renderedFilters[filter.key];
		const hasRightExpressionDisplayValue = this.filterManager.getRightExpressionDisplayValue(filter);
		if (renderedFilter && renderedFilter.getIsRightExpressionMenuAllowed() && !hasRightExpressionDisplayValue) {
			renderedFilter.showRightExpressionMenu();
		}
	},

	/**
	 * Returns model binding configuration. Implements mixin interface {@link Terrasoft.Bindable}.
	 * @override
	 */
	getBindConfig: function() {
		const bindConfig = this.callParent();
		const filterEditBindConfig = {
			filterManager: {
				changeMethod: "setFilterManager"
			},
			useProcessParameters: {
				changeMethod: "setUseProcessParameters"
			},
			useDcmMainRecord: {
				changeMethod: "_setUseDcmMainRecord"
			},
			rightExpressionMenuAligned: {
				changeMethod: "setRightExpressionMenuAligned"
			},
			selectedItems: {
				changeEvent: "selectedFiltersChange"
			},
			prepareMappingParametersList: {
				changeEvent: "prepareMappingParametersList"
			},
			prepareMainRecordModalBox: {
				changeEvent: "prepareMainRecordModalBox"
			},
			filterEditConfig: {
				changeMethod: "setFilterEditConfig"
			}
		};
		Ext.apply(filterEditBindConfig, bindConfig);
		return filterEditBindConfig;
	},

	initDomEvents: function() {
		this.callParent(arguments);
		this.initGroupsDomEvents();
		this.initFiltersDomEvents();
	},

	onClickOutside: function() {
		this.fireEvent("clickOutside", this);
		this.clearSelected();
	},

	initGroupsDomEvents: function() {
		Terrasoft.each(this.renderedGroups, (group) => {
			group.initDomEvents();
		}, this);
	},

	initFiltersDomEvents: function() {
		Terrasoft.each(this.renderedFilters, (filter) => {
			filter.initDomEvents();
		}, this);
	},

	/**
	 * @private
	 */
	_getFilterEditId: function() {
		return "filteredit-" + this.id + "-wrap";
	},

	generateHtml: function() {
		const id = this._getFilterEditId();
		this.selectors.wrapEl = "#" + id;
		const htmlConfig = {
			tag: "div",
			id: id,
			cls: this.classes.wrapEl.join(" "),
			children: []
		};
		const filters = this.filters || this.createEmptyFilterGroup();
		const options = {
			filterManager: this.filterManager,
			filterEdit: this,
			groupType: filters.logicalOperation,
			groupFilters: filters,
			generateTo: htmlConfig.children
		};
		const group = Ext.create("Terrasoft.FilterEdit.Group", options);
		this.renderedGroups[group.id] = group;
		this.tpl = Ext.DomHelper.markup(htmlConfig);
		return this.callParent(arguments);
	},

	/**
	 * @private
	 */
	_saveScrollPosition: function() {
		const element = this.wrapEl;
		if (!Ext.isEmpty(element)) {
			this._scrollPosition = element.getScrollTop();
		}
	},

	/**
	 * @private
	 */
	_restoreScrollPosition: function() {
		const element = this.wrapEl;
		if (!Ext.isEmpty(element)) {
			element.setScrollTop(this._scrollPosition);
		}
	},

	update: function() {
		if (!this.rendered || !this.visible) {
			return;
		}
		this._saveScrollPosition();
		this.clear();
		this.reRender();
		this._restoreScrollPosition();
	},

	setSelectedFilters: function(filters) {
		if (Ext.isArray(filters)) {
			Terrasoft.each(filters, (filter) => {
				this.selectFilter(filter, true);
			}, this);
		} else {
			this.selectFilter(filters, false);
		}
	},

	selectFilter: function(filter, multiSelect) {
		const selectedFilter = Object.values(this.selectedFilters)[0];
		if (selectedFilter) {
			const currentGroup = selectedFilter.instance.parentCollection
				? selectedFilter.instance.parentCollection.key
				: "";
			const filterGroup = (filter.instance.parentCollection) ? filter.instance.parentCollection.key : "";
			if (currentGroup !== filterGroup) {
				Terrasoft.each(this.selectedFilters, (selectedFilter) => {
					selectedFilter.showSelected(false);
				}, this);
				this.selectedFilters = {};
				this.selectedItems = {};
			}
		}
		if (this.selectedFilters.hasOwnProperty(filter.id)) {
			filter.showSelected(false);
			delete this.selectedFilters[filter.id];
			delete this.selectedItems[filter.id];
			return;
		}
		if (!multiSelect) {
			this.clearSelected();
		}
		filter.showSelected(true);
		this.selectedFilters[filter.id] = filter;
		this.selectedItems[filter.id] = filter.instance;
	},

	clearSelected: function() {
		Terrasoft.each(this.selectedFilters, (filter) => {
			filter.showSelected(false);
		}, this);
		this.selectedFilters = {};
		this.selectedItems = {};
	},

	clear: function() {
		if (this.openedInput) {
			this.openedInput.close();
			this.openedInput = null;
		}
		Terrasoft.each(this.renderedFilters, (filter) => {
			filter.destroy();
		}, this);
		this.renderedFilters = {};
		Terrasoft.each(this.renderedGroups, (group) => {
			group.destroy();
		}, this);
		this.renderedGroups = {};
	},

	setFilterManager: function(filterManager) {
		if (this.filterManager === filterManager) {
			return;
		}
		this.unSubscribeForFilterManagerEvents();
		this.filterManager = filterManager;
		this.subscribeForFilterManagerEvents();
		const filters = (filterManager) ? filterManager.filters : null;
		this.updateFilters(filters);
	},

	/**
	 * Sets #useProcessParameters property value.
	 * @private
	 * @param {Boolean} useProcessParameters If true, filters can use process parameters in their right expressions.
	 */
	setUseProcessParameters: function(useProcessParameters) {
		this.useProcessParameters = useProcessParameters;
	},

	/**
	 * Sets #useProcessParameters property value.
	 * @private
	 * @param {Boolean} useDcmMainRecord If true, filters can use process parameters in their right expressions.
	 */
	_setUseDcmMainRecord: function(useDcmMainRecord) {
		this.useDcmMainRecord = useDcmMainRecord;
	},

	/**
	 * Sets #rightExpressionMenuAligned property value.
	 * @private
	 * @param {Boolean} isAligned If true, right expression menu will be aligned to filter element.
	 */
	setRightExpressionMenuAligned: function(isAligned) {
		this.rightExpressionMenuAligned = isAligned;
	},

	/**
	 * Sets #filterEditConfig property value.
	 * @param {Object} value New value for filterEditConfig.
	 */
	setFilterEditConfig: function(value) {
		this.filterEditConfig = value;
	},

	updateFilters: function(filters) {
		this.filters = filters;
		this.update();
	},

	subscribeForFilterManagerEvents: function() {
		const filterManager = this.filterManager;
		if (!filterManager) {
			return;
		}
		filterManager.on("addFilter", this.onFilterAdd, this);
		filterManager.on("removeFilter", this.onFilterRemove, this);
		filterManager.on("changeFilter", this.onFilterChange, this);
		filterManager.on("rootFiltersChanged", this.updateFilters, this);
	},

	unSubscribeForFilterManagerEvents: function() {
		const filterManager = this.filterManager;
		if (!filterManager) {
			return;
		}
		filterManager.un("addFilter", this.onFilterAdd, this);
		filterManager.un("removeFilter", this.onFilterRemove, this);
		filterManager.un("changeFilter", this.onFilterChange, this);
		filterManager.un("rootFiltersChanged", this.updateFilters, this);
	},

	onDestroy: function() {
		this.clear();
		this.unSubscribeForFilterManagerEvents();
		Ext.get(window).un("click", this.onClickOutside, this);
		this.callParent(arguments);
	}

});
