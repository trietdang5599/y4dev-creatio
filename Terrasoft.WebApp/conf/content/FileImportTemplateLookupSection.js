Terrasoft.configuration.Structures["FileImportTemplateLookupSection"] = {innerHierarchyStack: ["FileImportTemplateLookupSection"], structureParent: "BaseLookupConfigurationSection"};
define('FileImportTemplateLookupSectionStructure', ['FileImportTemplateLookupSectionResources'], function(resources) {return {schemaUId:'3795246a-55be-4604-ae7d-19425ab6000c',schemaCaption: "FileImportTemplateLookupSection", parentSchemaName: "BaseLookupConfigurationSection", packageName: "FileImport", schemaName:'FileImportTemplateLookupSection',parentSchemaUId:'c8c39e3b-de05-4d01-814a-45c7981e139f',extendParent:false,type:Terrasoft.SchemaType.MODULE_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
 define("FileImportTemplateLookupSection", [],
	function() {
		return {
			entitySchemaName: "FileImportTemplate",
			methods: {
				getDataImportMenuItemVisible: function() {
					return false;
				}
			},
			diff: /**SCHEMA_DIFF*/[{
				"operation": "merge",
				"name": "SeparateModeAddRecordButton",
				"values": {
					"visible": false
				}
			}]/**SCHEMA_DIFF*/
		};
	});


