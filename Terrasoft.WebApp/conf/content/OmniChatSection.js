Terrasoft.configuration.Structures["OmniChatSection"] = {innerHierarchyStack: ["OmniChatSection"], structureParent: "BaseSectionV2"};
define('OmniChatSectionStructure', ['OmniChatSectionResources'], function(resources) {return {schemaUId:'7ff2401e-3693-4b2a-958f-563426891328',schemaCaption: "Section schema: \"Chat\"", parentSchemaName: "BaseSectionV2", packageName: "OmnichannelMessaging", schemaName:'OmniChatSection',parentSchemaUId:'7912fb69-4fee-429f-8b23-93943c35d66d',extendParent:false,type:Terrasoft.SchemaType.MODULE_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
define("OmniChatSection", ["ConfigurationConstants"], function(ConfigurationConstants) {
	return {
		entitySchemaName: "OmniChat",
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "merge",
				"name": "SeparateModeAddRecordButton",
				"values": {
					"visible": false
				}
			},

			{
				"operation": "merge",
				"name": "CombinedModeAddRecordButton",
				"values": {
					"visible": false
				}
			}
		]/**SCHEMA_DIFF*/,
		methods: {

			/**
			 * @inheritdoc BaseSectionV2#initFixedFiltersConfig
			 * @overridden
			 */
			initFixedFiltersConfig: function() {
				var fixedFilterConfig = {
					entitySchema: this.entitySchema,
					filters: [{
						name: "PeriodFilter",
						caption: this.get("Resources.Strings.PeriodFilterCaption"),
						dataValueType: this.Terrasoft.DataValueType.DATE,
						columnName: "CreatedOn",
						startDate: {
							defValue: this.Terrasoft.startOfWeek(new Date())
						},
						dueDate: {
							defValue: this.Terrasoft.endOfWeek(new Date())
						}
					}, {
						name: "Owner",
						caption: this.get("Resources.Strings.OwnerFilterCaption"),
						dataValueType: this.Terrasoft.DataValueType.LOOKUP,
						appendCurrentContactMenuItem: false,
						columnName: "Operator",
						filter: function() {
							var filters = Ext.create("Terrasoft.FilterGroup");
							const employeesFilter = Terrasoft.createColumnFilterWithParameter(Terrasoft.ComparisonType.EQUAL,
									"SysAdminUnitTypeValue",
									ConfigurationConstants.SysAdminUnit.Type.User);
							filters.addItem(employeesFilter);
							return filters;
						}
					}]
				};
				this.set("FixedFilterConfig", fixedFilterConfig);
			}
		}
	};
});


