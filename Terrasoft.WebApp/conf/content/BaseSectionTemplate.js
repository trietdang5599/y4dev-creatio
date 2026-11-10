Terrasoft.configuration.Structures["BaseSectionTemplate"] = {innerHierarchyStack: ["BaseSectionTemplate"], structureParent: "BaseTemplate"};
define('BaseSectionTemplateStructure', ['BaseSectionTemplateResources'], function(resources) {return {schemaUId:'9d0fd8cc-431b-455a-beeb-3bb93c64cb38',schemaCaption: "Base section template", parentSchemaName: "BaseTemplate", packageName: "CrtUIPlatform", schemaName:'BaseSectionTemplate',parentSchemaUId:'c6a6e333-21c2-4f43-b6fb-cf4b0369b09f',extendParent:false,type:Terrasoft.SchemaType.ANGULAR_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},parameters:{},schemaDifferences:function(){

}};});
define("BaseSectionTemplate", /**SCHEMA_DEPS*/[]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/()/**SCHEMA_ARGS*/ {
	return {
		viewConfigDiff: /**SCHEMA_VIEW_CONFIG_DIFF*/[
			{
				"operation": "insert",
				"name": "AddButton",
				"values": {
					"type": "crt.Button",
					"clicked": {
						"request": "crt.CreateRecordRequest",
						"params": {
							"itemsAttributeName": "Items"
						}
					},
					"color": "accent",
					"caption": "$Resources.Strings.AddButton"
				},
				"parentName": "ActionButtonsContainer",
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

