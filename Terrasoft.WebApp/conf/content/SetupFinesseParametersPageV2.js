Terrasoft.configuration.Structures["SetupFinesseParametersPageV2"] = {innerHierarchyStack: ["SetupFinesseParametersPageV2"], structureParent: "SetupFinesseParametersPage"};
define('SetupFinesseParametersPageV2Structure', ['SetupFinesseParametersPageV2Resources'], function(resources) {return {schemaUId:'980fc5d4-1a2a-4f8a-a0c3-5131323768f9',schemaCaption: "Finesse parameters setup page V2", parentSchemaName: "SetupFinesseParametersPage", packageName: "Finesse", schemaName:'SetupFinesseParametersPageV2',parentSchemaUId:'b5693abb-35ba-485f-bd12-9ea6c3e89082',extendParent:false,type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
define("SetupFinesseParametersPageV2", ["terrasoft"],
function(Terrasoft) {
	return {
		attributes: {

			/**
			 * Finesse server address.
			 * @type {String}
			 */
			"Domain": {
				"isRequired": false
			}
		},
		methods: {

			/**
			 * @inheritdoc Terrasoft.SetupFinesseParametersPage#getConnectionParamsConfig
			 * @overridden
			 */
			getConnectionParamsConfig: function() {
				var baseConnectionParams = this.callParent();
				delete baseConnectionParams.Domain;
				return baseConnectionParams;
			}

		},
		diff: [
			{
				"operation": "remove",
				"name": "Domain"
			},
			{
				"operation": "move",
				"name": "AgentId",
				"parentName": "controlsContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "move",
				"name": "Password",
				"parentName": "controlsContainer",
				"propertyName": "items",
				"index": 1
			}
		]
	};
});


