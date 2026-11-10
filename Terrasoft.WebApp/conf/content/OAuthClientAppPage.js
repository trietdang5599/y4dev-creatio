Terrasoft.configuration.Structures["OAuthClientAppPage"] = {innerHierarchyStack: ["OAuthClientAppPage"], structureParent: "BaseModulePageV2"};
define('OAuthClientAppPageStructure', ['OAuthClientAppPageResources'], function(resources) {return {schemaUId:'70f75070-3460-4385-a32c-8511ac1ecceb',schemaCaption: "OAuthClientAppPage", parentSchemaName: "BaseModulePageV2", packageName: "OAuth20", schemaName:'OAuthClientAppPage',parentSchemaUId:'d62293c0-7f14-44b1-b547-735fb40499cd',extendParent:false,type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
 define("OAuthClientAppPage", ["ConfigurationConstants","OAuthClientAppPageResources"], function(ConfigurationConstants, resources) {
	return {
		entitySchemaName: "OAuthClientApp",
		attributes: {
			"SystemUser": {
				lookupListConfig: {
					filter: function() {
						var technicalUserEnabled = this.getIsFeatureEnabled("EnableTechnicalUser");
                        var userTypes = [ConfigurationConstants.SysAdminUnit.Type.User];
    					if(technicalUserEnabled) {
    						userTypes.push(ConfigurationConstants.SysAdminUnit.Type.TechnicalUser);
    					}
						var filterGroup = this.Terrasoft.createFilterGroup();
						filterGroup.add("UserFilter", this.Terrasoft.createColumnInFilterWithParameters("SysAdminUnitTypeValue", userTypes));
						return filterGroup;
					}
				},
				isRequired: true
			}
		},
		properties: {

		},
		modules: /**SCHEMA_MODULES*/{}/**SCHEMA_MODULES*/,
		details: /**SCHEMA_DETAILS*/{
		}/**SCHEMA_DETAILS*/,
		businessRules: /**SCHEMA_BUSINESS_RULES*/{}/**SCHEMA_BUSINESS_RULES*/,
		methods: { 

			initActionButtonMenu: Terrasoft.emptyFn,

			onEntityInitialized: function() {
				this.callParent(arguments);
				this.callService({
					serviceName: "OAuthConfigService",
					methodName: "GetClientSecret",
					data: {
						clientAppId: this.get("Id")
					}
				}, function(response) {
					if (response.GetClientSecretResult.success) {
						this.set("SecretKey", response.GetClientSecretResult.clientSecret);
					}
				}, this);
			},

			setValidationConfig: function() {
				this.callParent(arguments);
				this.addColumnValidator("ApplicationUrl", this.urlValidator);
				this.addColumnValidator("RedirectUrl", this.urlValidator);
			},

			urlValidator: function(value) {
				var invalidMessage = "";
				var isValid = true;
				isValid = (Ext.isEmpty(value) || Terrasoft.isUrl(value));
				if (!isValid) {
					invalidMessage = this.get("Resources.Strings.InvalidUrlFormat");
				}
				return {
					invalidMessage: invalidMessage
				};
			}

		},
		dataModels: /**SCHEMA_DATA_MODELS*/{}/**SCHEMA_DATA_MODELS*/,
		diff: /**SCHEMA_DIFF*/[
			{
			"operation": "remove",
				"name": "ESNTab"
			},
			{
				"operation": "insert",
				"parentName": "Header",
				"name": "GeneralInfoControlGroup",
				"propertyName": "items",
				"values": {
					"caption": {
							"bindTo": "Resources.Strings.GeneralInfoGroupCaption"
						},
					"itemType": Terrasoft.ViewItemType.CONTROL_GROUP,
					"items": [],
					"layout": {
						"colSpan": 24,
						"rowSpan": 1,
						"column": 0,
						"row": 0,
						"layoutName": "Header"
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "GeneralInfoControlGroup",
				"propertyName": "items",
				"name": "GeneralInfoBlock",
				"values": {
					"itemType": Terrasoft.ViewItemType.GRID_LAYOUT,
					"items": [],
					"collapseEmptyRow": true
				}
			},
			{
				"operation": "insert",
				"name": "IsActive",
				"values": {
					"layout": {
						"colSpan": 3,
						"rowSpan": 1,
						"column": 10,
						"row": 5,
						"layoutName": "GeneralInfoBlock"
					},
					"bindTo": "IsActive",
					"enabled": true,
					"tip": {
						"content": {
							"bindTo": "Resources.Strings.IsActiveTip"
						}
					}
				},
				"parentName": "GeneralInfoBlock",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "Name",
				"values": {
					"layout": {
						"colSpan": 14,
						"rowSpan": 1,
						"column": 0,
						"row": 1,
						"layoutName": "GeneralInfoBlock"
					},
					"bindTo": "Name",
					"enabled": true,
					"isRequired": true
				},
				"parentName": "GeneralInfoBlock",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "RedirectUrl",
				"values": {
					"layout": {
						"colSpan": 14,
						"rowSpan": 1,
						"column": 0,
						"row": 2,
						"layoutName": "GeneralInfoBlock"
					},
					"bindTo": "RedirectUrl",
					"visible": false,
					"isRequired": false,
					"tip": {
						"content": {
							"bindTo": "Resources.Strings.RedirectUrlTip"
						}
					}
				},
				"parentName": "GeneralInfoBlock",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "ApplicationUrl",
				"values": {
					"layout": {
						"colSpan": 14,
						"rowSpan": 1,
						"column": 0,
						"row": 3,
						"layoutName": "GeneralInfoBlock"
					},
					"bindTo": "ApplicationUrl",
					"enabled": true,
					"isRequired": true,
					"tip": {
						"content": {
							"bindTo": "Resources.Strings.ApplicationUrlTip"
						}
					}
				},
				"parentName": "GeneralInfoBlock",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "Description",
				"values": {
					"layout": {
						"colSpan": 14,
						"rowSpan": 1,
						"column": 0,
						"row": 4,
						"layoutName": "GeneralInfoBlock"
					},
					"bindTo": "Description",
					"enabled": true,
					"isRequired": false
				},
				"parentName": "GeneralInfoBlock",
				"propertyName": "items",
				"index": 4
			},
			{
				"operation": "insert",
				"name": "CreatedOn",
				"values": {
					"layout": {
						"colSpan": 9,
						"rowSpan": 1,
						"column": 0,
						"row": 5,
						"layoutName": "GeneralInfoBlock"
					},
					"bindTo": "CreatedOn",
					"enabled": false
				},
				"parentName": "GeneralInfoBlock",
				"propertyName": "items",
				"index": 5
			},
			{
				"operation": "insert",
				"parentName": "Header",
				"name": "SecurityInfoControlGroup",
				"propertyName": "items",
				"values": {
					"caption": {
							"bindTo": "Resources.Strings.SecurityInfoGroupCaption"
						},
					"itemType": Terrasoft.ViewItemType.CONTROL_GROUP,
					"items": [],
					"layout": {
						"colSpan": 24,
						"rowSpan": 1,
						"column": 0,
						"row": 1,
						"layoutName": "Header"
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "SecurityInfoControlGroup",
				"propertyName": "items",
				"name": "SecurityInfoBlock",
				"values": {
					"itemType": Terrasoft.ViewItemType.GRID_LAYOUT,
					"items": [],
					"collapseEmptyRow": true
				}
			},
			{
				"operation": "insert",
				"name": "ClientId",
				"values": {
					"layout": {
						"colSpan": 14,
						"rowSpan": 1,
						"column": 0,
						"row": 6,
						"layoutName": "SecurityInfoBlock"
					},
					"bindTo": "ClientId",
					"enabled": false,
					"isRequired": false,
					"tip": {
						"content": {
							"bindTo": "Resources.Strings.ClientIdSecretTip"
						}
					}
				},
				"parentName": "SecurityInfoBlock",
				"propertyName": "items",
				"index": 6
			},
			{
				"operation": "insert",
				"name": "ClientSecret",
				"values": {
					"layout": {
						"colSpan": 14,
						"rowSpan": 1,
						"column": 0,
						"row": 7,
						"layoutName": "SecurityInfoBlock"
					},
					"value": { bindTo: "SecretKey" },
					"caption": { bindTo: "Resources.Strings.ClientSecretCaption" },
					"enabled": false,
					"isRequired": false,
					"itemType": this.Terrasoft.ViewItemType.TEXT,
					"tip": {
						"content": {
							"bindTo": "Resources.Strings.ClientIdSecretTip"
						}
					}
				},
				"parentName": "SecurityInfoBlock",
				"propertyName": "items",
				"index": 7
			},
			{
				"operation": "insert",
				"name": "SystemUser",
				"values": {
					"layout": {
						"colSpan": 14,
						"rowSpan": 1,
						"column": 0,
						"row": 8,
						"layoutName": "SecurityInfoBlock"
					},
					"bindTo": "SystemUser",
					"enabled": true,
					"isRequired": true,
					"tip": {
						"content": {
							"bindTo": "Resources.Strings.SystemUserTip"
						}
					}
				},
				"parentName": "SecurityInfoBlock",
				"propertyName": "items",
				"index": 8
			}
		]/**SCHEMA_DIFF*/
	};
});


