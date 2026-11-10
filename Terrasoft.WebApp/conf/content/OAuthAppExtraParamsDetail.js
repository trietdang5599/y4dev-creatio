Terrasoft.configuration.Structures["OAuthAppExtraParamsDetail"] = {innerHierarchyStack: ["OAuthAppExtraParamsDetail"], structureParent: "BaseGridDetailV2"};
define('OAuthAppExtraParamsDetailStructure', ['OAuthAppExtraParamsDetailResources'], function(resources) {return {schemaUId:'3f262b5d-b730-4076-829c-1e2e544c1c90',schemaCaption: "OAuthAppExtraParamsDetail", parentSchemaName: "BaseGridDetailV2", packageName: "OAuth20Integration", schemaName:'OAuthAppExtraParamsDetail',parentSchemaUId:'01eb38ee-668a-42f0-999d-c2534f979089',extendParent:false,type:Terrasoft.SchemaType.GRID_DETAIL_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
define("OAuthAppExtraParamsDetail", [
	"InformationButtonResources", "DefaultProfileHelper", "ConfigurationGrid", "ConfigurationGridGenerator",
	"ConfigurationGridUtilities", "css!OAuth20AppStyles"
], function(InformationButtonResources, DefaultProfileHelper) {
	return {
		entitySchemaName: "OAuthAppExtraParams",
		attributes: {
			"IsEditable": {
				dataValueType: Terrasoft.DataValueType.TEXT,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: true
			}
		},
		mixins: {
			ConfigurationGridUtilities: "Terrasoft.ConfigurationGridUtilities"
		},
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "merge",
				"name": "DataGrid",
				"values": {
					"className": "Terrasoft.ConfigurationGrid",
					"generator": "ConfigurationGridGenerator.generatePartial",
					"generateControlsConfig": {"bindTo": "generateActiveRowControlsConfig"},
					"changeRow": {"bindTo": "changeRow"},
					"unSelectRow": {"bindTo": "unSelectRow"},
					"onGridClick": {"bindTo": "onGridClick"},
					"activeRowActions": [
						{
							"className": "Terrasoft.Button",
							"style": this.Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
							"tag": "save",
							"markerValue": "save",
							"imageConfig": {"bindTo": "Resources.Images.SaveIcon"}
						},
						{
							"className": "Terrasoft.Button",
							"style": this.Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
							"tag": "cancel",
							"markerValue": "cancel",
							"imageConfig": {"bindTo": "Resources.Images.CancelIcon"}
						},
						{
							"className": "Terrasoft.Button",
							"style": this.Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
							"tag": "remove",
							"markerValue": "remove",
							"imageConfig": {"bindTo": "Resources.Images.RemoveIcon"}
						}
					],
					"initActiveRowKeyMap": {"bindTo": "initActiveRowKeyMap"},
					"activeRowAction": {"bindTo": "onActiveRowAction"},
					"multiSelect": false
				}
			},
			{
				"operation": "insert",
				"name": "ExtraParamsInfo",
				"parentName": "Detail",
				"propertyName": "tools",
				"values": {
					"itemType": Terrasoft.ViewItemType.INFORMATION_BUTTON,
					"behaviour": {"displayEvent": Terrasoft.TipDisplayEvent.HOVER},
					"content": {"bindTo": "Resources.Strings.ExtraParamsInfoTip"},
					"style": Terrasoft.TipStyle.GREEN,
					"controlConfig": {
						"imageConfig": InformationButtonResources.localizableImages.DefaultIcon,
						"classes": {"wrapperClass": ["extra-params-info-btn"]}
					}
				}
			}
		]/**SCHEMA_DIFF*/,
		methods: {

			getEditRecordMenuItem: Terrasoft.emptyFn,

			initDetailOptions: function() {
				this.callParent(arguments);
				this.set("IsDetailCollapsed", false);
			},

			generateEntityProfile: function() {
				const entitySchema = this.getGridEntitySchema();
				if (entitySchema) {
					const defaultCOlumns = [
						Terrasoft.deepClone(this.columns['Key']), 
						Terrasoft.deepClone(this.columns['Value'])
					];
					return DefaultProfileHelper.getEntityProfile(this.getProfileKey(),
							entitySchema.name, this.Terrasoft.GridType.LISTED, defaultCOlumns);
				} else {
					return {};
				}
			},

		}
	};
});


