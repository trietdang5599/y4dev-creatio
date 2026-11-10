Terrasoft.configuration.Structures["PageWithTabsAndActionDashboardFreedomTemplate"] = {innerHierarchyStack: ["PageWithTabsAndActionDashboardFreedomTemplate"], structureParent: "PageWithTabsFreedomTemplate"};
define('PageWithTabsAndActionDashboardFreedomTemplateStructure', ['PageWithTabsAndActionDashboardFreedomTemplateResources'], function(resources) {return {schemaUId:'f3600f35-4e3d-4dd3-882e-3404ab515e38',schemaCaption: "Tabbed page with action dashboard", parentSchemaName: "PageWithTabsFreedomTemplate", packageName: "CrtUIv2", schemaName:'PageWithTabsAndActionDashboardFreedomTemplate',parentSchemaUId:'3b2e117f-8c6b-4ca5-80a2-7ebb497cddf9',extendParent:false,type:Terrasoft.SchemaType.ANGULAR_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},parameters:{},schemaDifferences:function(){

}};});
define("PageWithTabsAndActionDashboardFreedomTemplate", /**SCHEMA_DEPS*/["ActionDashboardComponent"]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/()/**SCHEMA_ARGS*/ {
	return {
		viewConfigDiff: /**SCHEMA_VIEW_CONFIG_DIFF*/[
			{
				"operation": "insert",
				"name": "ActionDashboard",
				"values": {
					"type": "crt.ActionDashboard"
				},
				"parentName": "CardContentContainer",
				"propertyName": "items",
				"index": 0
			}
		]/**SCHEMA_VIEW_CONFIG_DIFF*/,
		viewModelConfigDiff: /**SCHEMA_VIEW_MODEL_CONFIG_DIFF*/[]/**SCHEMA_VIEW_MODEL_CONFIG_DIFF*/,
		modelConfigDiff: /**SCHEMA_MODEL_CONFIG_DIFF*/[]/**SCHEMA_MODEL_CONFIG_DIFF*/,
		handlers: /**SCHEMA_HANDLERS*/[]/**SCHEMA_HANDLERS*/,
		converters: /**SCHEMA_CONVERTERS*/{}/**SCHEMA_CONVERTERS*/,
		validators: /**SCHEMA_VALIDATORS*/{}/**SCHEMA_VALIDATORS*/
	};
});

