Terrasoft.configuration.Structures["CentralAreaDesktopTemplate"] = {innerHierarchyStack: ["CentralAreaDesktopTemplate"], structureParent: "BaseDesktop"};
define('CentralAreaDesktopTemplateStructure', ['CentralAreaDesktopTemplateResources'], function(resources) {return {schemaUId:'fbc98c89-0691-479c-bc25-59c11ac2365f',schemaCaption: "Central area desktop template", parentSchemaName: "BaseDesktop", packageName: "CrtUIPlatform", schemaName:'CentralAreaDesktopTemplate',parentSchemaUId:'c47278cc-0296-4e9e-8491-1cf4b943e95c',extendParent:false,type:Terrasoft.SchemaType.ANGULAR_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
define("CentralAreaDesktopTemplate", /**SCHEMA_DEPS*/[]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/()/**SCHEMA_ARGS*/ {
	return {
		viewConfigDiff: /**SCHEMA_VIEW_CONFIG_DIFF*/[
			{
				"operation": "insert",
				"name": "FixedGridSlot_qwe4asds",
				"values": {
					"type": "crt.GridContainer",
					"layoutConfig": {
						"column": 2,
						"row": 2,
						"colSpan": 8,
						"rowSpan": 10
					},
					"rows": "60px",
					"columns": [
						"minmax(35px, 1fr)",
						"minmax(35px, 1fr)",
						"minmax(35px, 1fr)",
						"minmax(35px, 1fr)",
						"minmax(35px, 1fr)",
						"minmax(35px, 1fr)",
						"minmax(35px, 1fr)",
						"minmax(35px, 1fr)"
					],
					"gap": 8,
					"items": [],
					"elementResponsiveWidth": 600
				},
				"parentName": "Main",
				"propertyName": "items",
				"index": 0
			}
		]/**SCHEMA_VIEW_CONFIG_DIFF*/,
		viewModelConfig: /**SCHEMA_VIEW_MODEL_CONFIG*/{}/**SCHEMA_VIEW_MODEL_CONFIG*/,
		modelConfig: /**SCHEMA_MODEL_CONFIG*/{}/**SCHEMA_MODEL_CONFIG*/,
		handlers: /**SCHEMA_HANDLERS*/[]/**SCHEMA_HANDLERS*/,
		converters: /**SCHEMA_CONVERTERS*/{}/**SCHEMA_CONVERTERS*/,
		validators: /**SCHEMA_VALIDATORS*/{}/**SCHEMA_VALIDATORS*/
	};
});


