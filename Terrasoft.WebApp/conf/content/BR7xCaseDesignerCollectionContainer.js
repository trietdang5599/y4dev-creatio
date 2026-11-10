Terrasoft.configuration.Structures["BR7xCaseDesignerCollectionContainer"] = {innerHierarchyStack: ["BR7xCaseDesignerCollectionContainer"]};
define('BR7xCaseDesignerCollectionContainerStructure', ['BR7xCaseDesignerCollectionContainerResources'], function(resources) {return {schemaUId:'d9b5f370-ec6f-43ae-a6a6-bb325e21d43c',schemaCaption: "BR7xCaseDesignerCollectionContainer", parentSchemaName: "", packageName: "BusinessRuleDesigner7x", schemaName:'BR7xCaseDesignerCollectionContainer',parentSchemaUId:'',extendParent:false,type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
 define("BR7xCaseDesignerCollectionContainer", ["BR7xCaseDesignerCollectionContainerResources",
	"BR7xCaseDesignerContainer", "BR7xConditionGroupDesignerContainer"], function(resources) {

		Ext.define("Terrasoft.controls.BR7xCaseDesignerCollectionContainer", {
			alternateClassName: "Terrasoft.BR7xCaseDesignerCollectionContainer",
			extend: "Terrasoft.ReorderableContainer",

			/**
			 * @inheritdoc Terrasoft.core.mixins.ReorderableContainer#itemClassName
			 * @overridden
			 */
			itemClassName: "Terrasoft.BR7xCaseDesignerContainer",

			/**
			 * Returns condition group config.
			 * @private
			 * @return {Object} Condition group config.
			 */
			getConditionGroup: function() {
				return {
					"className": "Terrasoft.BR7xConditionGroupDesignerContainer",
					"items": {"bindTo": "Items"},
					"operationType": {"bindTo": "OperationType"},
					"visible": {"bindTo": "Visible"},
					"itemActions": [{
						"className": "Terrasoft.Button",
						"style": Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
						"tag": "remove",
						"classes": {"wrapperClass": ["case-condition-remove-button"]},
						"imageConfig": resources.localizableImages.RemoveConditionIcon
					}],
					"itemActionClick": {"bindTo": "onItemActionClick"},
					"bindingContext": "ConditionGroup"
				};
			},

			/**
			 * Returns add condition button config.
			 * @private
			 * @return {Object} Add condition button config.
			 */
			getAddConditionButton: function() {
				return {
					"className": "Terrasoft.Button",
					"style": Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
					"caption": {"bindTo": "AddConditionButtonCaption"},
					"imageConfig": {"bindTo": "getConditionIcon"},
					"iconAlign": Terrasoft.controls.ButtonEnums.iconAlign.LEFT,
					"click": {"bindTo": "addCondition"},
					"markerValue": "AddCondition",
				};
			},

			/**
			 * @inheritdoc Terrasoft.core.mixins.Reorderable#getItemConfig
			 * @overridden
			 */
			getItemConfig: function(itemViewModel) {
				var config = this.callParent(arguments);
				return Ext.apply(config, {
					"id": itemViewModel.get("Id"),
					"conditionGroup": this.getConditionGroup(),
					"addConditionButton": this.getAddConditionButton(),
				});
			}
		});
		return Terrasoft.BR7xCaseDesignerCollectionContainer;
	});


