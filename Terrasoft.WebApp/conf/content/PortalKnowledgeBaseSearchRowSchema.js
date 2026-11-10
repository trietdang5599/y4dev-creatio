Terrasoft.configuration.Structures["PortalKnowledgeBaseSearchRowSchema"] = {innerHierarchyStack: ["PortalKnowledgeBaseSearchRowSchema"], structureParent: "BaseSearchRowSchema"};
define('PortalKnowledgeBaseSearchRowSchemaStructure', ['PortalKnowledgeBaseSearchRowSchemaResources'], function(resources) {return {schemaUId:'4b4d15df-4217-4d52-aa10-7ed84d773d32',schemaCaption: "PortalKnowledgeBaseSearchRowSchema", parentSchemaName: "BaseSearchRowSchema", packageName: "SspKnowledgeBase", schemaName:'PortalKnowledgeBaseSearchRowSchema',parentSchemaUId:'254c5d91-bad1-44be-a75e-1d511f816dc0',extendParent:false,type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
define("PortalKnowledgeBaseSearchRowSchema", [], function() {
	return {
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "remove",
				"name": "EntitySchemaCaption"
			},
			{
				"operation": "merge",
				"name": "PrimaryColumnContainer",
				"values": {
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 24
					}
				}
			},
			{
				"operation": "merge",
				"name": "FoundColumnsContainerList",
				"values": {
					"layout": {
						"column": 0,
						"row": 2,
						"colSpan": 12
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "DataContainer",
				"propertyName": "items",
				"name": "Type",
				"values": {
					"layout": {
						"column": 0,
						"row": 1,
						"colSpan": 24
					}
				}
			}
		]/**SCHEMA_DIFF*/
	};
});


