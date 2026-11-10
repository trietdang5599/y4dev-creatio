Terrasoft.configuration.Structures["ConfigurationGridUtilitiesV2"] = {innerHierarchyStack: ["ConfigurationGridUtilitiesV2"]};
define('ConfigurationGridUtilitiesV2Structure', ['ConfigurationGridUtilitiesV2Resources'], function(resources) {return {schemaUId:'79eefe3e-ec57-4d80-a9e7-813e165c9a99',schemaCaption: "Utilities module for configuration grid", parentSchemaName: "", packageName: "CrtUIv2", schemaName:'ConfigurationGridUtilitiesV2',parentSchemaUId:'',extendParent:false,type:Terrasoft.SchemaType.MODULE_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
define("ConfigurationGridUtilitiesV2", ["ConfigurationGridUtilities"], function() {

	Ext.define("Terrasoft.configuration.mixins.ConfigurationGridUtilitiesV2", {
		extend: "Terrasoft.ConfigurationGridUtilities",
		alternateClassName: "Terrasoft.ConfigurationGridUtilitiesV2",

		/**
		 * @inheritdoc Terrasoft.ConfigurationGridUtilities#onActiveRowAction
		 * @override
		 */
		onActiveRowAction: function(buttonTag, primaryColumnValue) {
			if (buttonTag === "copy") {
				this.copyRow(primaryColumnValue);
			} else if (buttonTag === "card") {
				const gridData = this.getGridData();
				const row = gridData.get(primaryColumnValue);
				this.saveRowChanges(row, () => {
					this.editRecord(row);
				});
			} else {
				this.callParent(arguments);
			}
		}

	});

	return Ext.create("Terrasoft.ConfigurationGridUtilitiesV2");
});


