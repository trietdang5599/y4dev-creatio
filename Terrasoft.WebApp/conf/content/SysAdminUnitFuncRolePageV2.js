Terrasoft.configuration.Structures["SysAdminUnitFuncRolePageV2"] = {innerHierarchyStack: ["SysAdminUnitFuncRolePageV2"], structureParent: "SysAdminUnitRoleBasePageV2"};
define('SysAdminUnitFuncRolePageV2Structure', ['SysAdminUnitFuncRolePageV2Resources'], function(resources) {return {schemaUId:'21fcfcc2-669a-49ce-b1cd-d0c90ff05afb',schemaCaption: "Section edit page schema - \"Functional roles\"", parentSchemaName: "SysAdminUnitRoleBasePageV2", packageName: "CrtUIv2", schemaName:'SysAdminUnitFuncRolePageV2',parentSchemaUId:'c98b8faa-d678-4c2c-a043-efe41d5e1ddf',extendParent:false,type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
define("SysAdminUnitFuncRolePageV2", ["SysAdminUnitFuncRolePageV2Resources"],
	function(resources) {
		return {
			details: /**SCHEMA_DETAILS*/{
				SysFuncRoleInOrgRoleDetailV2: {
					filter: {
						detailColumn: "FuncRole"
					},
					captionName: "SysFuncRoleInOrgRoleDetailCaption"
				}
			}/**SCHEMA_DETAILS*/,
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"index": 10,
					"name": "OrgRolesTab",
					"values": {
						"caption": { "bindTo": "Resources.Strings.RolesTabCaption" },
						"items": []
					}
				},
				{
					"operation": "move",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"index": 0,
					"name": "UsersTab"
				},
				{
					"operation": "move",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"index": 30,
					"name": "LicensesTab"
				},
				{
					"operation": "insert",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"index": 40,
					"name": "IPRangeTab",
					"values": {
						"caption": {"bindTo": "Resources.Strings.IPRangeTabCaption"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "OrgRolesTab",
					"propertyName": "items",
					"name": "SysFuncRoleInOrgRoleDetailV2",
					"values": {
						"itemType": this.Terrasoft.ViewItemType.DETAIL
					}
				},
				{
					"operation": "insert",
					"parentName": "IPRangeTab",
					"propertyName": "items",
					"name": "SysAdminUnitIPRangeDetailV2",
					"values": {
						"itemType": this.Terrasoft.ViewItemType.DETAIL
					}
				}
			]/**SCHEMA_DIFF*/,
			methods: {
				/**
				 * ########## ######### ########
				 * @protected
				 * @virtual
				 */
				getHeader: function() {
					return this.get("Resources.Strings.HeaderCaption");
				}
			}
		};
	});


