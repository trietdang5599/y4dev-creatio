Terrasoft.configuration.Structures["AccessControlWhitelistLookupSection"] = {innerHierarchyStack: ["AccessControlWhitelistLookupSection"], structureParent: "BaseLookupConfigurationSection"};
define('AccessControlWhitelistLookupSectionStructure', ['AccessControlWhitelistLookupSectionResources'], function(resources) {return {schemaUId:'4c3794f2-6980-47e6-b17a-9934694668ea',schemaCaption: "Lookup section for AccessControlWhitelist", parentSchemaName: "BaseLookupConfigurationSection", packageName: "CrtUIv2", schemaName:'AccessControlWhitelistLookupSection',parentSchemaUId:'c8c39e3b-de05-4d01-814a-45c7981e139f',extendParent:false,type:Terrasoft.SchemaType.MODULE_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
 define("AccessControlWhitelistLookupSection", ["ConfigurationGridUtilities"],
	function() {
		return {
			entitySchemaName: "AccessControlWhitelist",
			mixins: {
				ConfigurationGridUtilites: "Terrasoft.ConfigurationGridUtilities"
			},
			attributes: {},
			methods: {
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
				 * @inheritdoc Terrasoft.ConfigurationGridUtilities#activeRowSaved
				 * @override
				 */
				activeRowSaved: function(row, callback, scope) {
					const savedRow = row;
					this.mixins.ConfigurationGridUtilities.activeRowSaved.apply(this, [row, function() {
						callback.call(scope);
						if (savedRow != null) {
							this.reloadGridData();
						}
					}, scope]);
				},
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


