Terrasoft.configuration.Structures["OAuthClientAppAuthCodeMiniPage"] = {innerHierarchyStack: ["OAuthClientAppAuthCodeMiniPage"], structureParent: "BaseMiniPageTemplate"};
define('OAuthClientAppAuthCodeMiniPageStructure', ['OAuthClientAppAuthCodeMiniPageResources'], function(resources) {return {schemaUId:'bffa5284-7d04-4d9e-98ab-5a5117dbc4f8',schemaCaption: "OAuth client app auth code mini page", parentSchemaName: "BaseMiniPageTemplate", packageName: "OAuth20", schemaName:'OAuthClientAppAuthCodeMiniPage',parentSchemaUId:'ecdcc8ff-272c-4957-9381-7d74ce17e140',extendParent:false,type:Terrasoft.SchemaType.ANGULAR_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},parameters:{},schemaVersion:1,optionalProperties:[],schemaDifferences:function(){

}};});
define("OAuthClientAppAuthCodeMiniPage", /**SCHEMA_DEPS*/["@creatio-devkit/common"]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/(sdk)/**SCHEMA_ARGS*/ {
	return {
		viewConfigDiff: /**SCHEMA_VIEW_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"name": "PageTitle",
				"values": {
					"headingLevel": "label",
					"visible": "$CanUseAuthorizationCodeFlow"
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
					"visible": "$CanUseAuthorizationCodeFlow",
					"alignItems": "stretch"
				}
			},
			{
				"operation": "merge",
				"name": "CancelButton",
				"values": {
					"caption": "#ResourceString(CancelButton_caption)#",
					"visible": "$CanUseAuthorizationCodeFlow",
					"color": "default",
					"size": "large",
					"iconPosition": "only-text",
					"clickMode": "default"
				}
			},
			{
				"operation": "merge",
				"name": "SaveButton",
				"values": {
					"clicked": {
						"request": "crt.SaveRecordRequest",
						"params": {
							"preventCardClose": false
						}
					},
					"caption": "#ResourceString(SaveButton_caption)#",
					"visible": "$CanUseAuthorizationCodeFlow"
				}
			},
			{
				"operation": "insert",
				"name": "PageTitleError",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(PageTitleError_caption)#)#",
					"labelType": "headline-2",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "#0D2E4E",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"headingLevel": "label",
					"visible": "$CanUseAuthorizationCodeFlow | crt.InvertBooleanValue"
				},
				"parentName": "TitleContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "Input_Name",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 1,
						"colSpan": 1,
						"rowSpan": 1
					},
					"type": "crt.Input",
					"multiline": false,
					"label": "$Resources.Strings.OAuthClientAppDS_Name_n61sz0u",
					"labelPosition": "above",
					"control": "$OAuthClientAppDS_Name_n61sz0u"
				},
				"parentName": "MainContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Input_ApplicationURL",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 2,
						"colSpan": 1,
						"rowSpan": 1
					},
					"type": "crt.WebInput",
					"multiline": false,
					"label": "$Resources.Strings.OAuthClientAppDS_ApplicationUrl_zny7b5n",
					"labelPosition": "above",
					"control": "$OAuthClientAppDS_ApplicationUrl_zny7b5n"
				},
				"parentName": "MainContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "Input_Description",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 3,
						"colSpan": 1,
						"rowSpan": 1
					},
					"type": "crt.Input",
					"multiline": false,
					"label": "$Resources.Strings.OAuthClientAppDS_Description_rpizhgz",
					"labelPosition": "above",
					"control": "$OAuthClientAppDS_Description_rpizhgz"
				},
				"parentName": "MainContainer",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "Checkbox_qtngvc0",
				"values": {
					"layoutConfig": {
						"column": 1,
						"colSpan": 1,
						"row": 4,
						"rowSpan": 1
					},
					"type": "crt.Checkbox",
					"value": true,
					"disabled": false,
					"inversed": false,
					"label": "$Resources.Strings.OAuthClientAppDS_IsPublic_v763jf4",
					"ariaLabel": "",
					"labelPosition": "right",
					"tooltip": "#ResourceString(Checkbox_qtngvc0_tooltip)#",
					"control": "$OAuthClientAppDS_IsPublic_v763jf4",
					"visible": "$IsPkceSupportEnabled",
					"readonly": false,
					"placeholder": ""
				},
				"parentName": "MainContainer",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "FlexContainer_IdentityUpdateRequired",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "column",
					"items": [],
					"fitContent": true,
					"visible": "$CanUseAuthorizationCodeFlow | crt.InvertBooleanValue",
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "medium",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"alignItems": "stretch",
					"justifyContent": "start",
					"gap": "small",
					"wrap": "nowrap"
				},
				"parentName": "Main",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "Label_MainDescription",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_MainDescription_caption)#)#",
					"labelType": "body",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"headingLevel": "label",
					"visible": true
				},
				"parentName": "FlexContainer_IdentityUpdateRequired",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Label_CloudCaseHint",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_CloudCaseHint_caption)#)#",
					"labelType": "body",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"headingLevel": "label",
					"visible": true
				},
				"parentName": "FlexContainer_IdentityUpdateRequired",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "FlexContainer_OnSiteCaseHint",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "column",
					"items": [],
					"fitContent": true,
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"alignItems": "stretch",
					"justifyContent": "start",
					"gap": "none",
					"wrap": "nowrap"
				},
				"parentName": "FlexContainer_IdentityUpdateRequired",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "Label_OnSiteCaseHintFirstLine",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_OnSiteCaseHintFirstLine_caption)#)#",
					"labelType": "body",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"headingLevel": "label",
					"visible": true
				},
				"parentName": "FlexContainer_OnSiteCaseHint",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "FlexContainer_OnSiteCaseHintSecondLine",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "row",
					"items": [],
					"fitContent": true,
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"alignItems": "stretch",
					"justifyContent": "start",
					"gap": "extra-small",
					"wrap": "wrap"
				},
				"parentName": "FlexContainer_OnSiteCaseHint",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "Label_OnSiteCaseHintSecondLine",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_OnSiteCaseHintSecondLine_caption)#)#",
					"labelType": "body",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"headingLevel": "label",
					"visible": true
				},
				"parentName": "FlexContainer_OnSiteCaseHintSecondLine",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "AcademyURL",
				"values": {
					"type": "crt.Link",
					"caption": "#ResourceString(AcademyLink)#",
					"href": "https://academy.creatio.com/documents?id=2468",
					"target": "_blank",
					"visible": true,
					"layoutConfig": {},
					"linkType": "body"
				},
				"parentName": "FlexContainer_OnSiteCaseHintSecondLine",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "Button_Close",
				"values": {
					"type": "crt.Button",
					"clicked": {
						"request": "crt.CancelRecordChangesRequest"
					},
					"caption": "#ResourceString(Button_Close_caption)#",
					"color": "default",
					"size": "large",
					"iconPosition": "only-text",
					"clickMode": "default",
					"visible": "$CanUseAuthorizationCodeFlow | crt.InvertBooleanValue"
				},
				"parentName": "FooterContainer",
				"propertyName": "items",
				"index": 0
			}
		]/**SCHEMA_VIEW_CONFIG_DIFF*/,
		viewModelConfigDiff: /**SCHEMA_VIEW_MODEL_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"path": [
					"attributes"
				],
				"values": {
					"OAuthClientAppDS_Name_n61sz0u": {
						"modelConfig": {
							"path": "OAuthClientAppDS.Name"
						}
					},
					"OAuthClientAppDS_Description_rpizhgz": {
						"modelConfig": {
							"path": "OAuthClientAppDS.Description"
						}
					},
					"OAuthClientAppDS_ApplicationUrl_zny7b5n": {
						"modelConfig": {
							"path": "OAuthClientAppDS.ApplicationUrl"
						}
					},
					"CanUseAuthorizationCodeFlow": {
						"value": false
					},
					"IsPkceSupportEnabled": {
						"value": false
					},
					"OAuthClientAppDS_IsPublic_v763jf4": {
						"modelConfig": {
							"path": "OAuthClientAppDS.IsPublic"
						}
					}
				}
			}
		]/**SCHEMA_VIEW_MODEL_CONFIG_DIFF*/,
		modelConfigDiff: /**SCHEMA_MODEL_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"path": [],
				"values": {
					"dataSources": {
						"OAuthClientAppDS": {
							"type": "crt.EntityDataSource",
							"scope": "page",
							"config": {
								"entitySchemaName": "OAuthClientApp",
								"loadParameters": {
									"options": {
										"pagingConfig": {
											"rowCount": 1,
											"rowsOffset": -1
										}
									}
								},
								"allowCopyingRecords": false
							}
						}
					},
					"primaryDataSourceName": "OAuthClientAppDS"
				}
			}
		]/**SCHEMA_MODEL_CONFIG_DIFF*/,
		handlers: /**SCHEMA_HANDLERS*/[
			{
                request: "crt.HandleViewModelInitRequest",
                handler: async (request, next) => {
                    await next?.handle(request);
                    const featureService = new sdk.FeatureService();
					request.$context.IsPkceSupportEnabled = await featureService.getFeatureState("EnablePkceSupport");
                }
            }
		]/**SCHEMA_HANDLERS*/,
		converters: /**SCHEMA_CONVERTERS*/{}/**SCHEMA_CONVERTERS*/,
		validators: /**SCHEMA_VALIDATORS*/{}/**SCHEMA_VALIDATORS*/
	};
});

