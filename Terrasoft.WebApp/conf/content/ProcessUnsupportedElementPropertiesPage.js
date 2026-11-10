Terrasoft.configuration.Structures["ProcessUnsupportedElementPropertiesPage"] = {innerHierarchyStack: ["ProcessUnsupportedElementPropertiesPage"], structureParent: "BaseProcessSchemaElementPropertiesPage"};
define('ProcessUnsupportedElementPropertiesPageStructure', ['ProcessUnsupportedElementPropertiesPageResources'], function(resources) {return {schemaUId:'b75ce071-3815-4d23-b802-4d5395fd0cdb',schemaCaption: "ProcessUnsupportedElementPropertiesPage", parentSchemaName: "BaseProcessSchemaElementPropertiesPage", packageName: "CrtProcessDesigner", schemaName:'ProcessUnsupportedElementPropertiesPage',parentSchemaUId:'10a8efdc-8474-4a9a-b28f-ab96ec9bbe4a',extendParent:false,type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
/**
 * Edit page schema of process unsupported element.
 * Parent: BaseProcessSchemaElementPropertiesPage
 */
define("ProcessUnsupportedElementPropertiesPage", ["BaseProcessSchemaElementPropertiesPage"],
	function() {
		return {
			methods: {},
			diff: /**SCHEMA_DIFF*/ [
				{
					"operation": "insert",
					"parentName": "EditorsContainer",
					"propertyName": "items",
					"name": "UnsupportedMessage",
					"values": {
						"itemType": Terrasoft.ViewItemType.LABEL,
						"caption": {
							"bindTo": "Resources.Strings.UnsupportedMessage"
						},
						"classes": {
							"labelClass": ["unsupported-element-message"]
						}
					}
				},
				{
					"operation": "remove",
					"parentName": "ToolsContainer",
					"propertyName": "items",
					"name": "InfoButton",
				},
			] /**SCHEMA_DIFF*/
		};
	}
);


