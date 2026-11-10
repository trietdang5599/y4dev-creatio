Terrasoft.configuration.Structures["DuplicatesRuleSectionV2"] = {innerHierarchyStack: ["DuplicatesRuleSectionV2CrtDeduplication", "DuplicatesRuleSectionV2"], structureParent: "BaseSectionV2"};
define('DuplicatesRuleSectionV2CrtDeduplicationStructure', ['DuplicatesRuleSectionV2CrtDeduplicationResources'], function(resources) {return {schemaUId:'d91f0986-796d-4b92-bee3-414ee9b99e73',schemaCaption: "\"Duplicates rules\" section page schema", parentSchemaName: "BaseSectionV2", packageName: "Deduplication", schemaName:'DuplicatesRuleSectionV2CrtDeduplication',parentSchemaUId:'7912fb69-4fee-429f-8b23-93943c35d66d',extendParent:false,type:Terrasoft.SchemaType.MODULE_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
define('DuplicatesRuleSectionV2Structure', ['DuplicatesRuleSectionV2Resources'], function(resources) {return {schemaUId:'023b04de-fd62-4324-ac94-91cdb18415f4',schemaCaption: "\"Duplicates rules\" section page schema", parentSchemaName: "DuplicatesRuleSectionV2CrtDeduplication", packageName: "Deduplication", schemaName:'DuplicatesRuleSectionV2',parentSchemaUId:'d91f0986-796d-4b92-bee3-414ee9b99e73',extendParent:true,type:Terrasoft.SchemaType.MODULE_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:"DuplicatesRuleSectionV2CrtDeduplication",schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
define('DuplicatesRuleSectionV2CrtDeduplicationResources', ['terrasoft'], function(Terrasoft) {
var localizableStrings={

};
var parametersLocalizableStrings={};
var localizableImages={

};
return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});
define("DuplicatesRuleSectionV2CrtDeduplication", ["DuplicatesRuleSectionV2Resources"],
	function() {
		return {
			entitySchemaName: "DuplicatesRule",
			attributes: {
				/**
				 * Menu sorting columns collection.
				 */
				"DuplicatesRuleTypes": {
					dataValueType: Terrasoft.DataValueType.COLLECTION
				},
				"EnableEsDeduplication": {
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					value: Terrasoft.Features.getIsEnabled("ESDeduplication")
				},
				SecurityOperationName: {
					dataValueType: Terrasoft.DataValueType.STRING,
					value: "CanManageDuplicatesRules",
				}
			},
			methods: {

				//region Methods: Public

				/**
				 * @inheritdoc
				 * @override
				 */
				checkCanDelete: function() {
					if (!this.canBeDeletedActiveRow()) {
						const message = this.get("Resources.Strings.NotPossibleDeleteRuleCaption");
						this.showInformationDialog(message);
						return false;
					}
					this.callParent(arguments);
				},

				//endregion

				//region Methods: Protected

				/*
				 * @inheritdoc Terrasoft.BaseSectionV2#getDefaultDataViews
				 * @overridden
				 */
				getDefaultDataViews: function() {
					var dataViews = this.callParent(arguments);
					delete dataViews.AnalyticsDataView;
					return dataViews;
				},

				/**
				 * @inheritdoc Terrasoft.BaseSectionV2#getSectionActions
				 * @overridden
				 */
				getSectionActions: function() {
					const actionMenuItems = this.Ext.create("Terrasoft.BaseViewModelCollection");
					actionMenuItems.addItem(this.getButtonMenuItem({
						"Caption": {
							"bindTo": "Resources.Strings.ScheduleCaption"
						},
						"Click": {
							"bindTo": "openScheduleSettingPage"
						}
					}));
					return actionMenuItems;
				},

				/**
				 * @inheritdoc BaseSectionV2#addSectionDesignerViewOptions
				 * @overridden
				 */
				addSectionDesignerViewOptions: Terrasoft.emptyFn,

				/**
				 * Opens duplicates search schedule page setup.
				 * @protected
				 */
				openScheduleSettingPage: function() {
					const scheduledDuplicatesSearchSettingsSchemaName =
						Terrasoft.Features.getIsEnabled("BulkESDeduplication")
							? "CardModuleV2/ScheduledDuplicatesSearchSettingsPage"
							: "SearchDuplicatesSettingsPage";
					this.sandbox.publish("PushHistoryState", {
						hash: scheduledDuplicatesSearchSettingsSchemaName
					});
				},

				/**
				 * @inheritdoc
				 * @override
				 */
				getGridDataColumns: function(esq) {
					const parentColumns = this.callParent(arguments);
					const columns = {
						Object: {path: "Object"},
						SearchObject: {path: "SearchObject"}
					};
					Ext.apply(parentColumns, columns);
					return parentColumns;
				},

				/**
				 * Gets is possible delete active row.
				 * @protected
				 * @return {Boolean} True if active row is can be deleted.
				 */
				canBeDeletedActiveRow: function() {
					const activeRow = this.getActiveRow();
					const object = activeRow && activeRow.get("Object") || {};
					const searchObject = activeRow && activeRow.get("SearchObject") || {};
					if (this.isEmpty(object.value) || this.isEmpty(searchObject.value)) {
						return true;
					}
					return Boolean(object.value === searchObject.value);
				},

				//endregion
			},
			diff: /**SCHEMA_DIFF*/ [
				{
					"operation": "merge",
					"name": "SeparateModeAddRecordButton",
					"values": {
						"visible": {
							"bindTo": "EnableEsDeduplication"
						}
					}
				},
				{
					"operation": "remove",
					"name": "DataGridActiveRowCopyAction"
				},
				{
					"operation": "remove",
					"name": "CombinedModeAddRecordButton"
				},
				{
					"operation": "merge",
					"name": "DataGrid",
					"values": {
						"canChangeMultiSelectWithGridClick": false
					}
				}
			] /**SCHEMA_DIFF*/
		};
	});

 define("DuplicatesRuleSectionV2", ["DuplicatesRuleSectionV2Resources"],
	function() {
		return {
			methods: {
				/**
				 * @inheritdoc Terrasoft.BaseSectionV2#getSectionActions
				 * @overridden
				 */
				getSectionActions: function() {
					var actionMenuItems = this.Ext.create("Terrasoft.BaseViewModelCollection");
					actionMenuItems.addItem(this.getButtonMenuItem({
						"Caption": {
							"bindTo": "Resources.Strings.ContactsDuplicatesSearchCaption"
						},
						"Click": {
							"bindTo": "openContactDuplicatesModule"
						}
					}));
					actionMenuItems.addItem(this.getButtonMenuItem({
						"Caption": {
							"bindTo": "Resources.Strings.AccountsDuplicatesSearchCaption"
						},
						"Click": {
							"bindTo": "openAccountDuplicatesModule"
						}
					}));
					actionMenuItems.addItem(this.getButtonMenuSeparator());
					actionMenuItems.addItem(this.getButtonMenuItem({
						"Caption": {
							"bindTo": "Resources.Strings.ScheduleCaption"
						},
						"Click": {
							"bindTo": "openScheduleSettingPage"
						}
					}));
					return actionMenuItems;
				},

				/**
				 * Goes to contact duplicates search page.
				 * @protected
				 */
				openContactDuplicatesModule: function() {
					this.openDuplicatesModule("Contact");
				},

				/**
				 * Goes to account duplicates search page.
				 * @protected
				 */
				openAccountDuplicatesModule: function() {
					this.openDuplicatesModule("Account");
				},

				/**
				 * @inheritdoc
				 * @overridden
				 */
				openDuplicatesModule: function(entityName) {
					this.mixins.DuplicatesSearchUtilities.openDuplicatesModule.call(this, entityName);
				},

				//endregion
			}
		};
	});


