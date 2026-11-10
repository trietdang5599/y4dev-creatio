Terrasoft.configuration.Structures["UISwitcherBaseSwitchUIDialog"] = {innerHierarchyStack: ["UISwitcherBaseSwitchUIDialog"], structureParent: "UISwitcherBaseConfirmationDialog"};
define('UISwitcherBaseSwitchUIDialogStructure', ['UISwitcherBaseSwitchUIDialogResources'], function(resources) {return {schemaUId:'54c8d9bb-05c0-4f54-8b60-048533092a7b',schemaCaption: "Base switch UI dialog in UI management section", parentSchemaName: "UISwitcherBaseConfirmationDialog", packageName: "CrtUISwitcher", schemaName:'UISwitcherBaseSwitchUIDialog',parentSchemaUId:'5da36354-d454-4231-a517-0e312444e5d4',extendParent:false,type:Terrasoft.SchemaType.ANGULAR_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},parameters:{},schemaDifferences:function(){

}};});
define("UISwitcherBaseSwitchUIDialog", /**SCHEMA_DEPS*/[]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/()/**SCHEMA_ARGS*/ {
	return {
		viewConfigDiff: /**SCHEMA_VIEW_CONFIG_DIFF*/[
			{
				"operation": "insert",
				"name": "Label_89kznbr",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_89kznbr_caption)#)#",
					"labelType": "caption",
					"labelThickness": "semibold",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true
				},
				"parentName": "FlexContainer_ForLabels",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "Label_QuestionMark",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_QuestionMark_caption)#)#",
					"labelType": "caption",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true
				},
				"parentName": "FlexContainer_ForLabels",
				"propertyName": "items",
				"index": 2
			}
		]/**SCHEMA_VIEW_CONFIG_DIFF*/,
		viewModelConfigDiff: /**SCHEMA_VIEW_MODEL_CONFIG_DIFF*/[]/**SCHEMA_VIEW_MODEL_CONFIG_DIFF*/,
		modelConfigDiff: /**SCHEMA_MODEL_CONFIG_DIFF*/[]/**SCHEMA_MODEL_CONFIG_DIFF*/,
		handlers: /**SCHEMA_HANDLERS*/[]/**SCHEMA_HANDLERS*/,
		converters: /**SCHEMA_CONVERTERS*/{}/**SCHEMA_CONVERTERS*/,
		validators: /**SCHEMA_VALIDATORS*/{}/**SCHEMA_VALIDATORS*/
	};
});

