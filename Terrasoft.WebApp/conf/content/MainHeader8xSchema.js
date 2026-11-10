Terrasoft.configuration.Structures["MainHeader8xSchema"] = {innerHierarchyStack: ["MainHeader8xSchema"], structureParent: "MainHeaderSchema"};
define('MainHeader8xSchemaStructure', ['MainHeader8xSchemaResources'], function(resources) {return {schemaUId:'46e15f48-b8d1-4b05-9794-9e717aff99fa',schemaCaption: "MainHeader8xSchema", parentSchemaName: "MainHeaderSchema", packageName: "CrtUIv2", schemaName:'MainHeader8xSchema',parentSchemaUId:'52446ecf-4b3e-41ce-8962-e48c63d583f8',extendParent:false,type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
define("MainHeader8xSchema", [], function () {
	return {
		methods: {},
		diff: [{
			"operation": "remove",
			"name": "RightButtonsContainer"
		}, {
			"operation": "remove",
			"name": "CommandLineContainer"
		}, {
			"operation": "remove",
			"name": "RightLogoContainer"
		}, {
			"operation": "merge",
			"name": "MainHeaderContainer",
			"values": {
				"wrapClass": ["main-header", "angular-shell"]
			}
		}]
	};
});


