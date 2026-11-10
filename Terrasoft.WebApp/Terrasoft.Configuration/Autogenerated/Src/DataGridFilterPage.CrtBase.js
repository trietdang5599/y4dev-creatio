define("DataGridFilterPage", ["DataGridFilterPageResources", "FilterModuleMixin"],
	function(resources) {
	return {
		modules: {},
		attributes: {
			FilterData: {
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				dataValueType: Terrasoft.DataValueType.TEXT,
				value: ""
			},
			SchemaName: {
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				dataValueType: Terrasoft.DataValueType.TEXT,
				value: ""
			},
		},
		messages: {
			"GetFilterModuleConfig": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.SUBSCRIBE
			},
			"OnFiltersChanged": {
				mode: Terrasoft.MessageMode.BROADCAST,
				direction: Terrasoft.MessageDirectionType.SUBSCRIBE
			},
			"SetFilterModuleConfig": {
				mode: Terrasoft.MessageMode.BROADCAST,
				direction: Terrasoft.MessageDirectionType.PUBLISH
			}
		},
		methods: {
			/**
			 * Returns sandbox's FilterEditModule Id.
			 * @private
			 * @return {string} Id of FilterEditModule.
			 */
			_getFilterEditModuleId: function() {
				return this.sandbox.id + "_FilterEditModule";
			},
			/**
			 * Hides mask
			 * @private
			 */
			_hidePlaceholder: function() {
				var body = Ext.getBody();
				body.set({
					"maskState": "none"
				});
			},
			/**
			 * Loads Filter module to display filters.
			 * @protected
			 */
			loadFilterModule: function() {
				var moduleId = this._getFilterEditModuleId();
				var sandbox = this.sandbox;
				sandbox.subscribe("OnFiltersChanged", this.onFiltersChanged, this, [moduleId]);
				sandbox.subscribe("GetFilterModuleConfig",
					this.onGetConditionFilterModuleConfig, this, [moduleId]);
				sandbox.loadModule("FilterEditModule", {renderTo: "GridFiltersContainer", id: moduleId});
			},
			/**
			 * Listener on filters changed.
			 * Sets value of FilterData attribute.
			 * @param {object} args { filter: object, serializedFilter: string } Filters.
			 * @protected
			 */
			onFiltersChanged: function(args) {
				this.set("FilterData", args.serializedFilter);
			},
			/**
			 * Returns FilterModuleConfig to load filter module.
			 * @protected
			 * @return {object} Filter module config.
			 */
			onGetConditionFilterModuleConfig: function() {
				return {
					rootSchemaName: this.get("SchemaName"),
					rightExpressionMenuAligned: true,
					filters: this.get("FilterData"),
					filterProviderClassName: "Terrasoft.EntitySchemaFilterProvider"
				};
			},
			/**
			 * @inheritdoc Terrasoft.BaseViewModule#init
			 * @overridde
			 */
			init: function() {
				this.callParent(arguments);
				this._hidePlaceholder();
				var historyState = this.sandbox.publish("GetHistoryState");
				var schemaName = historyState.hash.operationType || "BaseObject";
				this.set("SchemaName", schemaName);
				this.set("FilterData", window.FilterData || null);
			},
			/**
			 * @inheritdoc Terrasoft.BaseViewModel#onRender
			 * @override
			 */
			onRender: function() {
				this.loadFilterModule();
			},
			/**
			 * Saves the filter to the parent window
			 * @protected
			 */
			save: function() {
				// TODO Post message to Window.
				var filterData =  this.get("FilterData") || null;
				window.FilterData = filterData;
				console.log(filterData);
			},
			/**
			 * #ancels filter changes
			 * @protected
			 */
			cancel: function() {
				// TODO Post message to Window.
				console.log("Cancel button pressed ...");
			}
		},
		diff: [
			
			{
				"operation": "insert",
				"name": "HeaderContainer",
				"values": {
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "SaveButton",
				"parentName": "HeaderContainer",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.BUTTON,
					"style": Terrasoft.controls.ButtonEnums.style.BLUE,
					"classes": {
						"textClass": "actions-button-margin-right"
					},
					"click": {"bindTo": "save"},
					"caption": {"bindTo": "Resources.Strings.SaveButtonCaption"}
				}
			},
			{
				"operation": "insert",
				"name": "CancelButton",
				"parentName": "HeaderContainer",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.BUTTON,
					"style": Terrasoft.controls.ButtonEnums.style.BLUE,
					"classes": {
						"textClass": "actions-button-margin-right"
					},
					"click": {"bindTo": "cancel"},
					"caption": {"bindTo": "Resources.Strings.CancelButtonCaption"}
				}
			},
			{
				"operation": "insert",
				"name": "MainContainer",
				"values": {
					"classes": {
						"textClass": "center-panel",
						"wrapClassName": ["data-grid-filter-page-wrap"]
					},
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "MainContainer",
				"propertyName": "items",
				"name": "FiltersContainer",
				"values": {
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "GridFiltersContainer",
				"parentName": "FiltersContainer",
				"propertyName": "items",
				"values": {
					"id": "GridFiltersContainer",
					"selectors": {"wrapEl": "#GridFiltersContainer"},
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"items": []
				}
			}
		]
	};
});
