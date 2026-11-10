Terrasoft.configuration.Structures["AccessControlWhitelistEditPage"] = {innerHierarchyStack: ["AccessControlWhitelistEditPage"], structureParent: "BaseLookupEditPage"};
define('AccessControlWhitelistEditPageStructure', ['AccessControlWhitelistEditPageResources'], function(resources) {return {schemaUId:'afc418a4-8bf6-4252-96b1-1eaa35a5599c',schemaCaption: "Edit page for AccessControlWhitelist", parentSchemaName: "BaseLookupEditPage", packageName: "CrtUIv2", schemaName:'AccessControlWhitelistEditPage',parentSchemaUId:'a8479d18-f601-4d5b-8f75-ec1f6bf2c15d',extendParent:false,type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
 define("AccessControlWhitelistEditPage", [],
	function() {
		return {
			entitySchemaName: "AccessControlWhitelist",
			attributes: {
				"Page": {
					lookupListConfig: {
						filter: function() {
							return this.getSysSchemaFilter();
						}
					}
				}
			},
			methods: {
				getSysSchemaFilter: function () {
					const filters = this.Ext.create("Terrasoft.FilterGroup");
					filters.add("clientUnitSchemaManager", Terrasoft.createColumnFilterWithParameter(
						Terrasoft.ComparisonType.EQUAL,
						"ManagerName",
						"ClientUnitSchemaManager"
					));
					filters.add("notExistingSysSchemaFilter",
						this.Terrasoft.createColumnIsNullFilter(
							">[AccessControlWhitelist:Page:Id].Page"));
					return filters;
				}
			},
			diff: []
		};
	});


