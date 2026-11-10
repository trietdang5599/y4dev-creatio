Terrasoft.configuration.Structures["BaseModulePageV2"] = {innerHierarchyStack: ["BaseModulePageV2CrtUIPlatform7x", "BaseModulePageV2SSP", "BaseModulePageV2"], structureParent: "BaseSectionPage"};
define('BaseModulePageV2CrtUIPlatform7xStructure', ['BaseModulePageV2CrtUIPlatform7xResources'], function(resources) {return {schemaUId:'d62293c0-7f14-44b1-b547-735fb40499cd',schemaCaption: "BaseModulePageV2", parentSchemaName: "BaseSectionPage", packageName: "Timeline", schemaName:'BaseModulePageV2CrtUIPlatform7x',parentSchemaUId:'d7862464-6710-4c5c-b896-e8187803dd6e',extendParent:false,type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
define('BaseModulePageV2SSPStructure', ['BaseModulePageV2SSPResources'], function(resources) {return {schemaUId:'13cc2478-d852-45fd-968e-f2c5483a373e',schemaCaption: "BaseModulePageV2", parentSchemaName: "BaseModulePageV2CrtUIPlatform7x", packageName: "Timeline", schemaName:'BaseModulePageV2SSP',parentSchemaUId:'d62293c0-7f14-44b1-b547-735fb40499cd',extendParent:true,type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:"BaseModulePageV2CrtUIPlatform7x",schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
define('BaseModulePageV2Structure', ['BaseModulePageV2Resources'], function(resources) {return {schemaUId:'3ec85f94-bbfc-4597-bf34-c7118dcb1910',schemaCaption: "BaseModulePageV2", parentSchemaName: "BaseModulePageV2SSP", packageName: "Timeline", schemaName:'BaseModulePageV2',parentSchemaUId:'13cc2478-d852-45fd-968e-f2c5483a373e',extendParent:true,type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:"BaseModulePageV2SSP",schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
define('BaseModulePageV2CrtUIPlatform7xResources', ['terrasoft'], function(Terrasoft) {
var localizableStrings={

};
var parametersLocalizableStrings={};
var localizableImages={

};
return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});
define("BaseModulePageV2CrtUIPlatform7x", [], function() {
	return {
		diff: /**SCHEMA_DIFF*/[ ]/**SCHEMA_DIFF*/,
		methods: {
			//region Methods: Private

			/**
			 * Adds edit right menu item.
			 * @private
			 * @param {Terrasoft.BaseViewModelCollection} actionMenuItems Action button menu items collection.
			 */
			_addEditRightsMenuItem: function(actionMenuItems) {
				if (!this.getSchemaAdministratedByRecords()) {
					return;
				}
				actionMenuItems.addItem(this.getButtonMenuItem({
					"Caption": {"bindTo": "Resources.Strings.EditRightsCaption"},
					"Tag": "editRights",
					"Visible": {"bindTo": "getSchemaAdministratedByRecords"}
				}));
			},

			/**
			 * Adds button drop-down item that is responsible for switching to the change log.
			 * @private
			 * @param {Terrasoft.BaseViewModelCollection} actionMenuItems Action button menu items collection.
			 */
			_addOpenChangeLogMenuItem: function(actionMenuItems) {
				if (!this.$CanShowChangeLog) {
					return;
				}
				actionMenuItems.addItem(this.getButtonMenuItem({
					"Caption": {"bindTo": "Resources.Strings.OpenChangeLogMenuCaption"},
					"Tag": "openChangeLog",
					"ImageConfig": this.get("Resources.Images.OpenChangeLogBtnImage")
				}));
			},

			//endregion

			//region Methods: Protected

			/**
			 * @inheritdoc Terrasoft.BasePageV2#getActions
			 * @override
			 */
			getActions: function() {
				var actionMenuItems = this.callParent(arguments);
				this._addEditRightsMenuItem(actionMenuItems);
				this._addOpenChangeLogMenuItem(actionMenuItems);
				return actionMenuItems;
			}

			//endregion
		}
	};
});

define('BaseModulePageV2SSPResources', ['terrasoft'], function(Terrasoft) {
var localizableStrings={

};
var parametersLocalizableStrings={};
var localizableImages={

};
return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});
define("BaseModulePageV2SSP", ["SspMiniPageListener"], function() {
	return {
		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/,
		methods: {}
	};
});

define("BaseModulePageV2", ["TimelineManager"],
	function() {
		return {
			methods: {

				// region Methods: Private

				/**
				 * Hides Timeline tab from page tabs collection.
				 * @private
				 */
				_removeTimelineTab: function() {
					var tabs = this.get("TabsCollection");
					tabs.removeByKey("TimelineTab");
				},

				// endregion

				// region Methods: Protected

				/**
				 * Checks if timeline config for current page exists.
				 * @protected
				 * @return {Boolean} True if timeline config for current page is defined, otherwise false.
				 */
				hasTimelineConfig: function() {
					var timelinePageConfig = this.Terrasoft.TimelineManager.getTimelinePageConfig(this.name);
					return !this.isEmpty(timelinePageConfig);
				},

				/**
				 * @inheritdoc Terrasoft.BasePageV2#initTabs
				 * @override
				 */
				initTabs: function() {
					if (!this.hasTimelineConfig()) {
						this._removeTimelineTab();
					}
					this.callParent(arguments);
				},

				/**
				 * @inheritdoc Terrasoft.BasePageV2#init
				 * @override
				 */
				init: function(callback, scope) {
					var parentInitMethod = this.getParentMethod();
					this.Terrasoft.TimelineManager.initialize(function() {
						parentInitMethod.call(this, callback, scope);
					}, this);
				}

				// endregion

			},
			modules: /**SCHEMA_MODULES*/ {
				"Timeline": {
					"config": {
						"schemaName": "TimelineSchema",
						"isSchemaConfigInitialized": true,
						"useHistoryState": false,
						"parameters": {
							"viewModelConfig": {
								"CardSchemaName": {
									"propertyValue": "name"
								},
								"ReferenceSchemaName": {
									"propertyValue": "entitySchemaName"
								},
								"InitialConfig": {
									"entities": []
								}
							}
						}
					}
				}
			} /**SCHEMA_MODULES*/,
			diff: /**SCHEMA_DIFF*/ [{
				"operation": "insert",
				"name": "TimelineTab",
				"parentName": "Tabs",
				"propertyName": "tabs",
				"values": {
					"caption": {
						"bindTo": "Resources.Strings.TimelineTabCaption"
					},
					"items": [],
					"order": 3
				}
			}, {
				"operation": "insert",
				"parentName": "TimelineTab",
				"name": "TimelineTabContainer",
				"propertyName": "items",
				"values": {
					"itemType": this.Terrasoft.ViewItemType.CONTAINER,
					"items": []
				}
			}, {
				"operation": "insert",
				"parentName": "TimelineTabContainer",
				"propertyName": "items",
				"name": "Timeline",
				"values": {
					"itemType": this.Terrasoft.ViewItemType.MODULE
				}
			}] /**SCHEMA_DIFF*/
		};
	});


