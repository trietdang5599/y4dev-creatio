Terrasoft.configuration.Structures["TwoFaRecoveryCodesPage"] = {innerHierarchyStack: ["TwoFaRecoveryCodesPage"], structureParent: "BaseMiniPageTemplate"};
define('TwoFaRecoveryCodesPageStructure', ['TwoFaRecoveryCodesPageResources'], function(resources) {return {schemaUId:'2240f045-b59c-43da-8056-937cb43dfaa2',schemaCaption: "Second factor recovery codes page", parentSchemaName: "BaseMiniPageTemplate", packageName: "CrtUIv2", schemaName:'TwoFaRecoveryCodesPage',parentSchemaUId:'ecdcc8ff-272c-4957-9381-7d74ce17e140',extendParent:false,type:Terrasoft.SchemaType.ANGULAR_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},parameters:{},schemaDifferences:function(){

}};});
define("TwoFaRecoveryCodesPage", /**SCHEMA_DEPS*/["@creatio-devkit/common"]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/(devkit)/**SCHEMA_ARGS*/ {
	return {
		viewConfigDiff: /**SCHEMA_VIEW_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"name": "PageTitle",
				"values": {
					"caption": "#MacrosTemplateString(#ResourceString(PageTitle_caption)#)#",
					"visible": true
				}
			},
			{
				"operation": "remove",
				"name": "ContinueInOtherPageButton"
			},
			{
				"operation": "merge",
				"name": "MainContainer",
				"values": {
					"padding": {
						"top": "small",
						"right": "none",
						"bottom": "medium",
						"left": "none"
					},
					"alignItems": "stretch"
				}
			},
			{
				"operation": "remove",
				"name": "CancelButton"
			},
			{
				"operation": "remove",
				"name": "SaveButton"
			},
			{
				"operation": "insert",
				"name": "GridContainer_i9r5ks1",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 1,
						"colSpan": 1,
						"rowSpan": 1
					},
					"type": "crt.GridContainer",
					"columns": [
						"minmax(32px, 1fr)"
					],
					"rows": "minmax(max-content, 32px)",
					"gap": {
						"columnGap": "large",
						"rowGap": "none"
					},
					"items": [],
					"fitContent": true,
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "small",
						"left": "none"
					},
					"alignItems": "stretch"
				},
				"parentName": "MainContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Label_2x3n55a",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 1,
						"colSpan": 1,
						"rowSpan": 1
					},
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_2x3n55a_caption)#)#",
					"labelType": "body",
					"labelThickness": "normal",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "justify",
					"visible": true
				},
				"parentName": "GridContainer_i9r5ks1",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "RecoveryCodesDataGrid",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 2,
						"colSpan": 1,
						"rowSpan": 1
					},
					"headerToolbarItems": [],
					"rowToolbarItems": [],
					"type": "crt.DataGrid",
					"features": {
						"columns": {
							"toolbar": false,
							"editing": false,
							"adding": false
						},
						"rows": {
							"selection": false,
							"numeration": false,
							"toolbar": false
						},
						"operations": {
							"delete": false,
							"add": false,
							"edit": false
						},
						"selection": {
							"enable": false,
							"multiple": false
						},
						"editable": {
							"enable": false,
							"itemsCreation": false,
							"floatingEditPanel": false
						}
					},
					"items": "$RecoveryCodesCollection",
					"visible": true,
					"fitContent": true,
					"primaryColumnName": "Id",
					"columns": [
						{
							"id": "b427b38b-4e73-8046-5f0a-0c504443bebc",
							"code": "RecoveryCode",
							"caption": "#ResourceString(RecoveryCodesDataGrid_RecoveryCodeColumnCaption)#",
							"dataValueType": 28,
							"width": 320
						}
					],
					"placeholder": false
				},
				"parentName": "MainContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "CopyButton",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(CopyButton_caption)#",
					"color": "default",
					"disabled": false,
					"size": "large",
					"iconPosition": "left-icon",
					"visible": true,
					"icon": "copy-icon",
					"clicked": {
						"request": "crt.CopyRecoveryCodesRequest",
						"params": {
							"recoveryCodes": "$PageParameters_RecoveryCodes"
						}
					},
					"clickMode": "default"
				},
				"parentName": "FooterContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "DownloadButton",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(DownloadButton_caption)#",
					"color": "primary",
					"disabled": false,
					"size": "large",
					"iconPosition": "left-icon",
					"visible": true,
					"icon": "download-button-icon",
					"clicked": {
						"request": "crt.DownloadRecoveryCodesRequest",
						"params": {
							"recoveryCodes": "$PageParameters_RecoveryCodes"
						}
					}
				},
				"parentName": "FooterContainer",
				"propertyName": "items",
				"index": 1
			}
		]/**SCHEMA_VIEW_CONFIG_DIFF*/,
		viewModelConfigDiff: /**SCHEMA_VIEW_MODEL_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"path": [
					"attributes"
				],
				"values": {
					"PageParameters_RecoveryCodes": {
						"modelConfig": {
							"path": "PageParameters.RecoveryCodes"
						}
					},
					"RecoveryCodesCollection": {
						"isCollection": true,
						"viewModelConfig": {
							"attributes": {
								"RecoveryCode": {},
								"Id": {}
							}
						},
						"modelConfig": {
							"sortingConfig": {
								"default": []
							}
						}
					}
				}
			}
		]/**SCHEMA_VIEW_MODEL_CONFIG_DIFF*/,
		modelConfigDiff: /**SCHEMA_MODEL_CONFIG_DIFF*/[]/**SCHEMA_MODEL_CONFIG_DIFF*/,
		handlers: /**SCHEMA_HANDLERS*/[
			{
				request: 'crt.HandleViewModelAttributeChangeRequest',
				handler: async (request, next) => {
					if(request.attributeName === "PageParameters_RecoveryCodes") {
						const handlerChain = devkit.HandlerChainService.instance;
						await handlerChain.process({
							type: 'crt.LoadRecoveryCodeRequest',
							recoveryCodes: await request.$context.PageParameters_RecoveryCodes,
							$context: request.$context
						});
					}
					return next?.handle(request);;
				}
			},
		]/**SCHEMA_HANDLERS*/,
		converters: /**SCHEMA_CONVERTERS*/{}/**SCHEMA_CONVERTERS*/,
		validators: /**SCHEMA_VALIDATORS*/{}/**SCHEMA_VALIDATORS*/
	};
});

