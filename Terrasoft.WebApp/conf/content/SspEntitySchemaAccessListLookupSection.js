Terrasoft.configuration.Structures["SspEntitySchemaAccessListLookupSection"] = {innerHierarchyStack: ["SspEntitySchemaAccessListLookupSection"], structureParent: "BaseLookupConfigurationSection"};
define('SspEntitySchemaAccessListLookupSectionStructure', ['SspEntitySchemaAccessListLookupSectionResources'], function(resources) {return {schemaUId:'eb8f94b5-1443-4c58-bda8-3f8e6fbd04c6',schemaCaption: "SspEntitySchemaAccessListLookupSection", parentSchemaName: "BaseLookupConfigurationSection", packageName: "SSP", schemaName:'SspEntitySchemaAccessListLookupSection',parentSchemaUId:'c8c39e3b-de05-4d01-814a-45c7981e139f',extendParent:false,type:Terrasoft.SchemaType.MODULE_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
define("SspEntitySchemaAccessListLookupSection", ["ConfigurationGridUtilities"],
	function() {
		return {
			entitySchemaName: "VwSysSSPEntitySchemaAccessList",
			mixins: {
				ConfigurationGridUtilites: "Terrasoft.ConfigurationGridUtilities"
			},
			attributes: {},
			methods: {
				
				_isPresetSchema: function(activeRow) {
					if (activeRow && activeRow.isNew) {
						return false;
					}
					return activeRow && activeRow.$IsPreset;
				},

				/**
				 * @inheritdoc Terrasoft.ConfigurationGridUtilites#getCellControlsConfig
				 * @overridden
				 */
				getCellControlsConfig: function() {
					let controlsConfig =
						this.mixins.ConfigurationGridUtilities.getCellControlsConfig.apply(this, arguments);
					let activeRow = this.getActiveRow();
					if (!(activeRow && activeRow.isNew)) {
						this.Ext.apply(controlsConfig, {
							enabled: false
						});
					}
					return controlsConfig;
				},

				/**
				 * @inheritDoc Terrasoft.BaseSection#isSeparateModeActionsButtonVisible
				 * @overridden
				 */
				isSeparateModeActionsButtonVisible: function () {
					return false;
				},

				/**
				 * @inheritdoc Terrasoft.GridUtilities#initQueryColumns
				 * @overridden
				 */
				initQueryColumns: function(esq) {
					this.callParent(arguments);
					esq.addColumn("[SysSSPEntitySchemaAccessList:Id:Id].IsPreset", "IsPreset");
				},

				/**
				 * @inheritdoc Terrasoft.BaseGridDetailV2#deleteRecords
				 * @overridden
				 * */
				deleteRecords: function() {
					const activeRow = this.getActiveRow();
					if (this._isPresetSchema(activeRow)) {
						this.showInformationDialog(this.get("Resources.Strings.DeletePresetSchemaErrorMessage"));
						return;
					}
					this.callParent(arguments);
				},

				/**
				 * @inheritDoc BaseDataView#loadFiltersModule
				 * @overridden
				 */
				loadFiltersModule: this.Terrasoft.emptyFn
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "remove",
					"name": "activeRowActionCopy"
				},
				{
					"operation": "remove",
					"name": "activeRowActionCard"
				}
			]/**SCHEMA_DIFF*/
		};
	});


