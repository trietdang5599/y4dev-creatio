Terrasoft.configuration.Structures["SetupVirtualParametersPage"] = {innerHierarchyStack: ["SetupVirtualParametersPage"], structureParent: "BaseSetupTelephonyParametersPage"};
define('SetupVirtualParametersPageStructure', ['SetupVirtualParametersPageResources'], function(resources) {return {schemaUId:'ec368c7c-99ec-4d8e-9f88-9b7451840310',schemaCaption: "SetupVirtualParametersPage", parentSchemaName: "BaseSetupTelephonyParametersPage", packageName: "CTIVirtualProvider", schemaName:'SetupVirtualParametersPage',parentSchemaUId:'22849db5-f5d9-4326-8fbc-af1f1888a90e',extendParent:false,type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
define("SetupVirtualParametersPage", [],
	function() {
		return {
			methods: {
				getConnectionParamsConfig: function() {
					return  {
						"DisableCallCentre": "disableCallCentre"
					};
				}
			},
			diff: [
				{
					"operation": "remove",
					"name": "DebugMode"
				},
				{
					"operation": "remove",
					"name": "UseBlindTransfer"
				}
			]
		};
	});


