Terrasoft.configuration.Structures["AgeActualizationModalTimeEditModuleSchema"] = {innerHierarchyStack: ["AgeActualizationModalTimeEditModuleSchema"], structureParent: "BaseModalTimeEditModuleSchema"};
define('AgeActualizationModalTimeEditModuleSchemaStructure', ['AgeActualizationModalTimeEditModuleSchemaResources'], function(resources) {return {schemaUId:'1fb9eed7-138b-4088-a2c8-364de3c84aa9',schemaCaption: "AgeActualizationModalTimeEditModuleSchema", parentSchemaName: "BaseModalTimeEditModuleSchema", packageName: "CrtUIv2", schemaName:'AgeActualizationModalTimeEditModuleSchema',parentSchemaUId:'5297710c-8fed-4202-a00a-4b780bb8f04f',extendParent:false,type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
define("AgeActualizationModalTimeEditModuleSchema", ["ProcessModuleUtilities"], function(ProcessModuleUtilities) {
	return {
		methods: {

			//region Methods: Public

			/**
			 * @inheritDoc Terrasoft.BaseModalTimeEditModuleSchema#initSelectedTimeValue
			 * @overridden
			 */
			initSelectedTimeValue: function() {
				Terrasoft.SysSettings.querySysSettingsItem("AutomaticAgeActualizationTime",
					this.initSelectedTimeValueCallback, this);
			},

			/**
			 * @inheritDoc Terrasoft.BaseModalTimeEditModuleSchema#saveSelectedTimeValue
			 * @overridden
			 */
			saveSelectedTimeValue: function() {
				Terrasoft.SysSettings.postSysSettingsValue("AutomaticAgeActualizationTime", this.$SelectedTimeValue,
					this.saveSelectedTimeValueCallback, this);
			},

			/**
			 * @inheritDoc Terrasoft.BaseModalTimeEditModuleSchema#saveSelectedTimeValueCallback
			 * @overridden
			 */
			saveSelectedTimeValueCallback: function() {
				this.callParent(arguments);
				ProcessModuleUtilities.executeProcess({
					"sysProcessName": "ContactAgeActualizationJobRestartProcess"
				});
			}

			//endregion

		}
	};
});

