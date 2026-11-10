Terrasoft.configuration.Structures["SoapServiceResponseParameterPage"] = {innerHierarchyStack: ["SoapServiceResponseParameterPage"], structureParent: "ServiceResponseParameterPage"};
define('SoapServiceResponseParameterPageStructure', ['SoapServiceResponseParameterPageResources'], function(resources) {return {schemaUId:'ce4244de-3397-5723-30a4-281057ab1a4e',schemaCaption: "SoapServiceResponseParameterPage", parentSchemaName: "ServiceResponseParameterPage", packageName: "ServiceDesigner", schemaName:'SoapServiceResponseParameterPage',parentSchemaUId:'1d9d7a82-c300-4416-aa19-2e18e4662edc',extendParent:false,type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
define("SoapServiceResponseParameterPage", ["ServiceEnums"], function() {
	return {
		modules: {
		},
		attributes: {
			/**
			 * Sequence element name.
			 */
			"SequenceElementName": {
				"dataValueType": Terrasoft.DataValueType.TEXT,
				"type": this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

		},
		methods: {

			//region Methods: Protected

			/**
			 * @inheritdoc Terrasoft.ServiceParameterPage#getPathPlaceholder
			 * @override
			 */
			getPathPlaceholder: function() {
				if (this.$ParameterType === Terrasoft.services.enums.ServiceParameterType.BODY) {
					return "";
				}
				return this.callParent(arguments);
			},

			/**
			 * @inheritdoc Terrasoft.ServiceParameterPage#getTrackedAttributes
			 * @override
			 */
			getTrackedAttributes: function() {
				const attributes = this.callParent(arguments);
				attributes.push("SequenceElementName");
				return attributes;
			},

			/**
			 * @inheritdoc Terrasoft.ServiceParameterPage#getAttributeMap
			 * @override
			 */
			getAttributeMap: function() {
				const attributeMap = this.callParent(arguments);
				return Ext.apply(attributeMap, {
					sequenceElementName: "SequenceElementName",
				});
			},

			/**
			 * Returns true if sequence item type allowed for parameter.
			 */
			isSequenceElementNameVisible: function() {
				return this.$Schema && 
					this.$IsArray && 
					this.$DataValueTypeName === Terrasoft.services.enums.DataValueTypeName.Object;
			},

			//endregion

		},
		diff: [
			{
				"operation": "insert",
				"parentName": "ParameterEditContainer",
				"propertyName": "items",
				"name": "SequenceElementName",
				"index": 6,
				"values": {
					"layout": {"column": 0, "row": 3, "colSpan": 8},
					"bindTo": "SequenceElementName",
					"caption": "$Resources.Strings.SequenceElementNameCaption",
					"enabled": "$CanEditSchema",
					"classes": {"wrapClassName": ["grid-layout-row"]},
					"visible": {"bindTo": "isSequenceElementNameVisible"},
					"tip": {"content": {"bindTo":"Resources.Strings.SequenceObjectElementNameTip"}}
				}
			},
		]
	};
});


