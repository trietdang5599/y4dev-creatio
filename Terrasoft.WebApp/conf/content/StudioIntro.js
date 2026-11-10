Terrasoft.configuration.Structures["StudioIntro"] = {innerHierarchyStack: ["StudioIntro"], structureParent: "SimpleIntro"};
define('StudioIntroStructure', ['StudioIntroResources'], function(resources) {return {schemaUId:'fbbfa34c-f1a1-4c4e-b52d-74cc0d879e5b',schemaCaption: "Applications intro page", parentSchemaName: "SimpleIntro", packageName: "Studio", schemaName:'StudioIntro',parentSchemaUId:'bb057159-e980-45c5-9e98-e93dc287e20a',extendParent:false,type:Terrasoft.SchemaType.MODULE_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
define("StudioIntro", ["StudioIntroResources"], function(resources) {
	return {
		attributes: {},
		methods: {},
		diff: [
			{
				"operation": "remove",
				"name": "KnowledgeBaseSectionV2"
			}
		]
	};
});


