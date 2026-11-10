Terrasoft.configuration.Structures["PageWithTabsAndActionDashboardTemplate"] = {innerHierarchyStack: ["PageWithTabsAndActionDashboardTemplate"], structureParent: "PageWithTabsTemplate"};
define('PageWithTabsAndActionDashboardTemplateStructure', ['PageWithTabsAndActionDashboardTemplateResources'], function(resources) {return {schemaUId:'126f25c9-1c1d-43b3-9372-ac1903348ef4',schemaCaption: "Tabbed page with action dashboard", parentSchemaName: "PageWithTabsTemplate", packageName: "CrtUIv2", schemaName:'PageWithTabsAndActionDashboardTemplate',parentSchemaUId:'05477cbd-1ca8-4658-b427-971fc58bbc08',extendParent:false,type:Terrasoft.SchemaType.ANGULAR_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},parameters:{},schemaDifferences:function(){

}};});
define("PageWithTabsAndActionDashboardTemplate", /**SCHEMA_DEPS*/["ActionDashboardComponent"]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/()/**SCHEMA_ARGS*/ {
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

