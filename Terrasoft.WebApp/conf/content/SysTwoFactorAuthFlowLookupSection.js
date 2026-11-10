Terrasoft.configuration.Structures["SysTwoFactorAuthFlowLookupSection"] = {innerHierarchyStack: ["SysTwoFactorAuthFlowLookupSection"], structureParent: "BaseLookupConfigurationSection"};
define('SysTwoFactorAuthFlowLookupSectionStructure', ['SysTwoFactorAuthFlowLookupSectionResources'], function(resources) {return {schemaUId:'107dafdc-c7af-4274-a4df-fb696a2e46c0',schemaCaption: "Two-Factor authentication flow lookup page", parentSchemaName: "BaseLookupConfigurationSection", packageName: "CrtSecurity7x", schemaName:'SysTwoFactorAuthFlowLookupSection',parentSchemaUId:'c8c39e3b-de05-4d01-814a-45c7981e139f',extendParent:false,type:Terrasoft.SchemaType.MODULE_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
 define("SysTwoFactorAuthFlowLookupSection", [],
	function() {
		return {
			entitySchemaName: "SysTwoFactorAuthFlow",
			methods: {
				saveDataRow: function(row, callback, scope) {
                  if(row.getChangedEntityColumns().filter(column => column === 'Primary'
                          || column === 'Enabled').length > 0) {
                      row.save({
						callback: function() {
							callback.call();
							this.reloadGridData();
						},
						isSilent: true,
						scope: scope
					});
                  } else {
                    this.callParent(arguments);
                  }
        		}
			}
		};
	});

