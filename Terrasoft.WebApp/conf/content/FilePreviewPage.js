Terrasoft.configuration.Structures["FilePreviewPage"] = {innerHierarchyStack: ["FilePreviewPage"], structureParent: "BlankPageTemplate"};
define('FilePreviewPageStructure', ['FilePreviewPageResources'], function(resources) {return {schemaUId:'0d69b1dc-03de-43ca-a6d0-59dd67cca8f3',schemaCaption: "File preview page", parentSchemaName: "BlankPageTemplate", packageName: "CrtCoreFilePreview", schemaName:'FilePreviewPage',parentSchemaUId:'f691e828-0b36-42a7-898f-c337e9af67d0',extendParent:false,type:Terrasoft.SchemaType.ANGULAR_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},parameters:{"FilePreviewComponent_File":{"dataValueTypeName":"Text","direction":2,"uId":"e6ff4798-b0f1-49f8-a369-7117dce43fe9","isRequired":false,"referenceSchemaName":null},"FilePreviewComponent_Options":{"dataValueTypeName":"Text","direction":2,"uId":"2fb6a1e3-5ceb-f4a8-8cd0-e640497253cf","isRequired":false,"referenceSchemaName":null}},schemaVersion:1,optionalProperties:[],schemaDifferences:function(){

}};});
define("FilePreviewPage", /**SCHEMA_DEPS*/['css!FilePreviewPageCSS']/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/()/**SCHEMA_ARGS*/ {
	return {
		viewConfigDiff: /**SCHEMA_VIEW_CONFIG_DIFF*/[
			{
				"operation": "insert",
				"name": "FilePreviewHeader",
				"values": {
					"type": "crt.GridContainer",
					"columns": [
						"minmax(32px, 1fr)",
						"minmax(32px, 1fr)",
						"minmax(32px, 1fr)",
						"minmax(32px, 1fr)",
						"minmax(32px, 1fr)",
						"minmax(32px, 1fr)",
						"minmax(32px, 1fr)",
						"minmax(32px, 1fr)",
						"minmax(32px, 1fr)",
						"minmax(32px, 1fr)",
						"minmax(32px, 1fr)",
						"minmax(32px, 1fr)"
					],
					"rows": "minmax(max-content, 32px)",
					"gap": {
						"columnGap": "small",
						"rowGap": "none"
					},
					"items": [],
					"fitContent": true,
					"padding": {
						"top": "extra-small",
						"bottom": "none",
						"right": "small",
						"left": "small"
					},
					"color": "primary",
					"borderRadius": "none",
					"visible": true,
					"alignItems": "stretch"
				},
				"parentName": "MainContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "ToolbarLeftFlexContainer",
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
					"alignItems": "center",
					"justifyContent": "start",
					"gap": "small",
					"wrap": "wrap",
					"layoutConfig": {
						"column": 1,
						"colSpan": 3,
						"row": 1,
						"rowSpan": 1
					}
				},
				"parentName": "FilePreviewHeader",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "ToolbarCenterFlexContainer",
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
					"alignItems": "center",
					"justifyContent": "center",
					"gap": "small",
					"wrap": "wrap",
					"layoutConfig": {
						"column": 4,
						"colSpan": 6,
						"row": 1,
						"rowSpan": 1
					}
				},
				"parentName": "FilePreviewHeader",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "FilePreviewLabel",
				"values": {
					"type": "crt.Label",
					"caption": "$FilePreviewComponent_File_Parameter  | crt.ToObjectProp : 'displayValue'",
					"labelType": "headline-3",
					"labelThickness": "default",
					"labelEllipsis": true,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "center",
					"headingLevel": "label",
					"visible": true
				},
				"parentName": "ToolbarCenterFlexContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "ToolbarRightFlexContainer",
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
					"alignItems": "center",
					"justifyContent": "end",
					"gap": "small",
					"wrap": "wrap",
					"layoutConfig": {
						"column": 10,
						"colSpan": 3,
						"row": 1,
						"rowSpan": 1
					}
				},
				"parentName": "FilePreviewHeader",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "CloseButton",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(CloseButton_caption)#",
					"color": "default",
					"disabled": false,
					"size": "medium",
					"iconPosition": "only-icon",
					"visible": true,
					"icon": "close-button-icon",
					"clicked": {
						"request": "crt.ClosePageRequest"
					},
					"clickMode": "default"
				},
				"parentName": "ToolbarRightFlexContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "FilePreviewFrameContainer",
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
						"right": "small",
						"bottom": "none",
						"left": "small"
					},
					"alignItems": "center",
					"justifyContent": "center",
					"gap": "extra-small",
					"wrap": "nowrap"
				},
				"parentName": "MainContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "FilePreviewComponent",
				"values": {
					"type": "crt.FilePreview",
					"file": "$FilePreviewComponent_File_Parameter",
					"options": "$FilePreviewComponent_Options_Parameter",
				},
				"parentName": "FilePreviewFrameContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "BottomFlexContainer",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "row",
					"items": [],
					"fitContent": true,
					"visible": true,
					"color": "primary",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "small",
						"bottom": "extra-small",
						"left": "small"
					},
					"alignItems": "center",
					"justifyContent": "start",
					"gap": "extra-small",
					"wrap": "wrap"
				},
				"parentName": "MainContainer",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "FilePreviewWatermark",
				"values": {
					"type": "crt.Link",
					"caption": "#MacrosTemplateString(#ResourceString(FilePreviewWatermark_caption)#)#",
					"labelType": "caption",
					"labelThickness": "light",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"headingLevel": "label",
					"visible": true,
					"href": "https://apryse.com/?utm_source=partner&utm_medium=referral&utm_campaign=creatio_2026",
					"target": "_blank"
				},
				"parentName": "BottomFlexContainer",
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
					"FilePreviewComponent_File_Parameter": {
						"modelConfig": {
							"path": "PageParameters.FilePreviewComponent_File"
						}
					},
					"FilePreviewComponent_Options_Parameter": {
						"modelConfig": {
							"path": "PageParameters.FilePreviewComponent_Options"
						}
					}
				}
			}
		]/**SCHEMA_VIEW_MODEL_CONFIG_DIFF*/,
		modelConfigDiff: /**SCHEMA_MODEL_CONFIG_DIFF*/[]/**SCHEMA_MODEL_CONFIG_DIFF*/,
		handlers: /**SCHEMA_HANDLERS*/[
			{
				request: 'crt.CanDiscardUnsavedDataRequest',
				handler: async (request, next) => {
					return Promise.resolve(true);
				}
			}
		]/**SCHEMA_HANDLERS*/,
		converters: /**SCHEMA_CONVERTERS*/{}/**SCHEMA_CONVERTERS*/,
		validators: /**SCHEMA_VALIDATORS*/{}/**SCHEMA_VALIDATORS*/
	};
});


