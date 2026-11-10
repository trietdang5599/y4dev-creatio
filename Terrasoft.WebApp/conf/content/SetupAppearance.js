Terrasoft.configuration.Structures["SetupAppearance"] = {innerHierarchyStack: ["SetupAppearance"], structureParent: "BlankPageTemplate"};
define('SetupAppearanceStructure', ['SetupAppearanceResources'], function(resources) {return {schemaUId:'4cfae938-3b5c-40d5-bb16-7c6a62789baf',schemaCaption: "Appearance setup", parentSchemaName: "BlankPageTemplate", packageName: "CrtUIv2", schemaName:'SetupAppearance',parentSchemaUId:'f691e828-0b36-42a7-898f-c337e9af67d0',extendParent:false,type:Terrasoft.SchemaType.ANGULAR_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},parameters:{},schemaVersion:1,optionalProperties:[],schemaDifferences:function(){

}};});
define("SetupAppearance", /**SCHEMA_DEPS*/["@creatio-devkit/common", "SetupAppearanceResources", "css!SetupAppearanceCSS"]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/(sdk, resources)/**SCHEMA_ARGS*/ {
	return {
		viewConfigDiff: /**SCHEMA_VIEW_CONFIG_DIFF*/[
			{
				"operation": "insert",
				"name": "FlexContainer_lwyxklr",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "column",
					"items": [],
					"visible": true,
					"color": "primary",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"justifyContent": "start",
					"alignItems": "stretch",
					"gap": "small",
					"wrap": "nowrap",
					"fitContent": false
				},
				"parentName": "MainContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "SetupAppearanceHeaderFlex",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "column",
					"items": [],
					"fitContent": true,
					"visible": true,
					"color": "primary",
					"borderRadius": "none",
					"padding": {
						"top": "large",
						"right": "large",
						"bottom": "large",
						"left": "large"
					},
					"justifyContent": "start",
					"alignItems": "stretch",
					"gap": "small",
					"wrap": "nowrap"
				},
				"parentName": "FlexContainer_lwyxklr",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "SetupAppearanceHeaderGrid",
				"values": {
					"layoutConfig": {},
					"type": "crt.GridContainer",
					"columns": [
						"minmax(32px, 1fr)",
						"minmax(32px, 1fr)"
					],
					"rows": "minmax(max-content, 32px)",
					"gap": {
						"columnGap": "large",
						"rowGap": "none"
					},
					"items": [],
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "none"
					}
				},
				"parentName": "SetupAppearanceHeaderFlex",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "SetupAppearanceHeaderTitleFlex",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 1,
						"colSpan": 1,
						"rowSpan": 1
					},
					"type": "crt.FlexContainer",
					"direction": "row",
					"items": [],
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"justifyContent": "start",
					"alignItems": "stretch",
					"gap": "small",
					"wrap": "wrap"
				},
				"parentName": "SetupAppearanceHeaderGrid",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "CancelIconButton",
				"values": {
					"layoutConfig": {},
					"type": "crt.Button",
					"color": "default",
					"disabled": false,
					"size": "large",
					"iconPosition": "only-icon",
					"visible": true,
					"icon": "back-button-icon",
					"clicked": {
						"request": "crt.SetupAppearanceCancelChangesRequest"
					}
				},
				"parentName": "SetupAppearanceHeaderTitleFlex",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "SetupAppearanceTitleLabel",
				"values": {
					"layoutConfig": {},
					"type": "crt.Label",
					"caption": "#ResourceString(SetupAppearanceTitleLabel)#",
					"labelType": "headline-1",
					"labelThickness": "bold",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true
				},
				"parentName": "SetupAppearanceHeaderTitleFlex",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "SetupAppearanceHeaderActionsFlex",
				"values": {
					"layoutConfig": {
						"column": 2,
						"row": 1,
						"colSpan": 1,
						"rowSpan": 1
					},
					"type": "crt.FlexContainer",
					"direction": "row",
					"items": [],
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"justifyContent": "end",
					"alignItems": "stretch",
					"gap": "small",
					"wrap": "wrap"
				},
				"parentName": "SetupAppearanceHeaderGrid",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "SaveButton",
				"values": {
					"layoutConfig": {},
					"type": "crt.Button",
					"caption": "#ResourceString(SaveButtonCaption)#",
					"color": "primary",
					"disabled": false,
					"size": "large",
					"iconPosition": "only-text",
					"visible": true,
					"clicked": {
						"request": "crt.SetupAppearanceApplyChangesRequest"
					},
					"clickMode": "default"
				},
				"parentName": "SetupAppearanceHeaderActionsFlex",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "CancelButton",
				"values": {
					"layoutConfig": {},
					"type": "crt.Button",
					"caption": "#ResourceString(CancelButtonCaption)#",
					"color": "default",
					"disabled": false,
					"size": "large",
					"iconPosition": "only-text",
					"visible": true,
					"clicked": {
						"request": "crt.SetupAppearanceCancelChangesRequest"
					},
					"clickMode": "default"
				},
				"parentName": "SetupAppearanceHeaderActionsFlex",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "SetupAppearanceGridContent",
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
						"minmax(32px, 1fr)"
					],
					"rows": "minmax(max-content, 32px)",
					"gap": {
						"columnGap": "large",
						"rowGap": "none"
					},
					"items": [],
					"padding": {
						"top": "medium",
						"right": "large",
						"bottom": "medium",
						"left": "large"
					},
					"color": "primary",
					"borderRadius": "none",
					"stretch": true,
					"fitContent": false,
					"visible": true
				},
				"parentName": "FlexContainer_lwyxklr",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "GridContainer_2c333zl",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 1,
						"colSpan": 6,
						"rowSpan": 1
					},
					"type": "crt.GridContainer",
					"columns": [
						"minmax(32px, 1fr)"
					],
					"gap": {
						"columnGap": "large",
						"rowGap": "none"
					},
					"styles": {
						"align-content": "baseline"
					},
					"items": [],
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "none"
					}
				},
				"parentName": "SetupAppearanceGridContent",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "BackgroundImageSettingsExpansionPanel",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 1,
						"colSpan": 1,
						"rowSpan": 1
					},
					"type": "crt.ExpansionPanel",
					"tools": [],
					"items": [],
					"title": "#ResourceString(BackgroundImageSettingsExpansionPanel)#",
					"toggleType": "default",
					"togglePosition": "before",
					"expanded": true,
					"labelColor": "auto",
					"fullWidthHeader": false,
					"titleWidth": 20,
					"visible": true,
					"padding": {
						"top": "small",
						"bottom": "small",
						"left": "medium",
						"right": "medium"
					}
				},
				"parentName": "GridContainer_2c333zl",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "BackgroundImageSettingsExpansionPanelHeaderGrid",
				"values": {
					"type": "crt.GridContainer",
					"rows": "minmax(max-content, 24px)",
					"columns": [
						"minmax(32px, 1fr)"
					],
					"gap": {
						"columnGap": "large",
						"rowGap": "none"
					},
					"styles": {
						"overflow-x": "hidden"
					},
					"items": [],
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "none"
					}
				},
				"parentName": "BackgroundImageSettingsExpansionPanel",
				"propertyName": "tools",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "BackgroundImageSettingsExpansionPanelHeaderGridFlex",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "row",
					"gap": "none",
					"alignItems": "center",
					"items": [],
					"layoutConfig": {
						"colSpan": 1,
						"column": 1,
						"row": 1,
						"rowSpan": 1
					}
				},
				"parentName": "BackgroundImageSettingsExpansionPanelHeaderGrid",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "BackgroundImageSettingsExpansionPanelContentGrid",
				"values": {
					"type": "crt.GridContainer",
					"rows": "minmax(max-content, 32px)",
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
						"minmax(32px, 1fr)"
					],
					"gap": {
						"columnGap": "large",
						"rowGap": "none"
					},
					"styles": {
						"overflow-x": "hidden"
					},
					"items": [],
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "medium"
					},
					"alignItems": "stretch"
				},
				"parentName": "BackgroundImageSettingsExpansionPanel",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "BackgroundModeToggle",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 1,
						"colSpan": 10,
						"rowSpan": 1
					},
					"type": "crt.ButtonToggleGroup",
					"allowUntoggle": false,
					"value": "$SelectedBackgroundMode",
					"items": [
						{
							"displayValue": "#ResourceString(Button_mlebss6_caption)#",
							"icon": "empty-image-placeholder",
							"value": "UsePicture"
						},
						{
							"displayValue": "#ResourceString(Button_npcxjg2_caption)#",
							"icon": "paint-brush",
							"value": "UseColor"
						}
					]
				},
				"parentName": "BackgroundImageSettingsExpansionPanelContentGrid",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "SelectColorGrid",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 2,
						"colSpan": 10,
						"rowSpan": 1
					},
					"rows": "minmax(max-content, 32px)",
					"gap": {
						"columnGap": "large",
						"rowGap": "none"
					},
					"type": "crt.GridContainer",
					"items": [],
					"visible": "$UseBackgroundColor",
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"alignItems": "stretch"
				},
				"parentName": "BackgroundImageSettingsExpansionPanelContentGrid",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "BackgroundColorPicker",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 2,
						"colSpan": 1,
						"rowSpan": 1
					},
					"type": "crt.ColorPicker",
					"labelPosition": "auto",
					"control": "$BackgroundColor",
					"pickerMode": "extended"
				},
				"parentName": "SelectColorGrid",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "ChooseYourColorLabel",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 1,
						"colSpan": 10,
						"rowSpan": 1
					},
					"type": "crt.Label",
					"caption": "#ResourceString(ChooseYourColorLabel)#",
					"labelType": "caption",
					"labelThickness": "light",
					"labelEllipsis": false,
					"labelColor": "#757575",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true
				},
				"parentName": "SelectColorGrid",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "SelectImageGrid",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 3,
						"colSpan": 10,
						"rowSpan": 8
					},
					"classes": [
						"image-gallery-grid"
					],
					"rows": "minmax(max-content, 32px)",
					"gap": {
						"columnGap": "large",
						"rowGap": "none"
					},
					"type": "crt.GridContainer",
					"items": [],
					"visible": "$UseBackgroundImage",
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"alignItems": "stretch"
				},
				"parentName": "BackgroundImageSettingsExpansionPanelContentGrid",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "ChooseYourPictureLabel",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 1,
						"colSpan": 10,
						"rowSpan": 1
					},
					"type": "crt.Label",
					"caption": "#ResourceString(ChooseYourPictureLabel)#",
					"labelType": "caption",
					"labelThickness": "light",
					"labelEllipsis": false,
					"labelColor": "#757575",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true
				},
				"parentName": "SelectImageGrid",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "AddPictureButton",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 10,
						"colSpan": 6,
						"rowSpan": 1
					},
					"type": "crt.Button",
					"caption": "#ResourceString(AddPictureButtonCaption)#",
					"color": "default",
					"disabled": false,
					"size": "large",
					"iconPosition": "left-icon",
					"visible": true,
					"clicked": {
						"request": "crt.SetupAppearanceAddImageRequest"
					},
					"clickMode": "default",
					"icon": "add-button-icon"
				},
				"parentName": "SelectImageGrid",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "BackgroundImagesGallery",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 2,
						"colSpan": 10,
						"rowSpan": 8
					},
					"gap": {
						"columnGap": "large",
						"rowGap": "none"
					},
					"type": "crt.Gallery",
					"items": "$BackgroundImagesGallery",
					"selectedItemId": "$SelectedBackgroundImage",
					"itemClick": {
						"request": "crt.SetupAppearanceSelectedBackgroundImageRequest",
						"params": {
							"selectedGalleryItem": "@event"
						}
					},
					"itemConfig": {
						"templateValuesMapping": {
							"image": "SelectedGalleryItemBackground",
							"id": "SelectedGalleryItemId"
						},
						"defaultSize": "small",
						"actions": [
							{
								"type": "crt.MenuItem",
								"caption": "#ResourceString(SetBackgroundMenuItemCaption)#",
								"icon": "message-composer-checkmark",
								"visible": true,
								"clicked": {
									"request": "crt.SetupAppearanceApplyChangesRequest",
									"params": {
										"selectedImageId": "$BackgroundImagesGallery.SelectedGalleryItemBackground.value"
									}
								}
							},
							{
								"type": "crt.MenuItem",
								"caption": "#ResourceString(DeleteBackgroundImageMenuItemCaption)#",
								"icon": "delete-button-icon",
								"visible": true,
								"clicked": {
									"request": "crt.DeleteBackgroundImage",
									"params": {
										"ImageId": "$BackgroundImagesGallery.SelectedGalleryItemBackground.value"
									}
								}
							}
						]
					},
					"selectable": true
				},
				"parentName": "SelectImageGrid",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "AccessibleColorMainContainer",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "column",
					"items": [],
					"fitContent": true,
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "small",
						"right": "none",
						"bottom": "none",
						"left": "medium"
					},
					"alignItems": "stretch",
					"justifyContent": "start",
					"gap": "medium",
					"wrap": "nowrap"
				},
				"parentName": "BackgroundImageSettingsExpansionPanel",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "AccessibleColorLabelContainer",
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
					"alignItems": "flex-start",
					"justifyContent": "start",
					"gap": "none",
					"wrap": "wrap"
				},
				"parentName": "AccessibleColorMainContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "AccessibleColorLabel",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(AccessibleColorLabel_caption)#)#",
					"labelType": "caption",
					"labelThickness": "light",
					"labelEllipsis": false,
					"labelColor": "#757575",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true
				},
				"parentName": "AccessibleColorLabelContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "AccessibleColorLabelInfoButton",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(AccessibleColorLabelInfoButton_caption)#",
					"color": "default",
					"disabled": true,
					"size": "small",
					"iconPosition": "only-icon",
					"visible": true,
					"icon": "info-icon"
				},
				"parentName": "AccessibleColorLabelContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "AccessibleColorPickerContainer",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "row",
					"items": [],
					"fitContent": true
				},
				"parentName": "AccessibleColorMainContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "AccessibleColorPicker",
				"values": {
					"type": "crt.ColorPicker",
					"labelPosition": "hidden",
					"control": "$AccessibleBackgroundColor",
					"pickerMode": "extended",
					"visible": true,
					"label": "$Resources.Strings.AccessibleBackgroundColor",
					"disabled": false,
					"placeholder": "",
					"tooltip": ""
				},
				"parentName": "AccessibleColorPickerContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "DesktopSettingsExpansionPanel",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 2,
						"colSpan": 1,
						"rowSpan": 1
					},
					"type": "crt.ExpansionPanel",
					"tools": [],
					"items": [],
					"title": "#ResourceString(DesktopSettingsExpansionPanel_title)#",
					"toggleType": "default",
					"togglePosition": "before",
					"expanded": true,
					"labelColor": "auto",
					"fullWidthHeader": false,
					"titleWidth": 20,
					"visible": true,
					"padding": {
						"top": "small",
						"bottom": "small",
						"left": "medium",
						"right": "medium"
					}
				},
				"parentName": "GridContainer_2c333zl",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "DesktopSettingsExpansionPanelHeaderGrid",
				"values": {
					"type": "crt.GridContainer",
					"rows": "minmax(max-content, 24px)",
					"columns": [
						"minmax(32px, 1fr)"
					],
					"gap": {
						"columnGap": "large",
						"rowGap": 0
					},
					"styles": {
						"overflow-x": "hidden"
					},
					"items": []
				},
				"parentName": "DesktopSettingsExpansionPanel",
				"propertyName": "tools",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "DesktopSettingsExpansionPanelHeaderGridFlex",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "row",
					"gap": "none",
					"alignItems": "center",
					"items": [],
					"layoutConfig": {
						"colSpan": 1,
						"column": 1,
						"row": 1,
						"rowSpan": 1
					}
				},
				"parentName": "DesktopSettingsExpansionPanelHeaderGrid",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "DesktopSettingsExpansionPanelContentGrid",
				"values": {
					"type": "crt.GridContainer",
					"rows": "minmax(max-content, 32px)",
					"columns": [
						"minmax(32px, 1fr)",
						"minmax(32px, 1fr)"
					],
					"gap": {
						"columnGap": "large",
						"rowGap": "none"
					},
					"styles": {
						"overflow-x": "hidden"
					},
					"classes": [
						"appearence-desktops-preview"
					],
					"items": [],
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "none"
					}
				},
				"parentName": "DesktopSettingsExpansionPanel",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "DesktopSettingsGallery",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 1,
						"colSpan": 6,
						"rowSpan": 8
					},
					"type": "crt.Gallery",
					"items": "$DesktopList",
					"itemClick": {
						"request": "crt.SetupAppearanceEditDesktopRequest",
						"params": {
							"desktopSchemaName": "@event.DesktopSchemaName"
						}
					},
					"itemConfig": {
						"templateValuesMapping": {
							"image": "Image",
							"caption": "DesktopTitle",
							"id": "DesktopId"
						},
						"defaultSize": "small",
						"actions": [
							{
								"type": "crt.MenuItem",
								"caption": "#ResourceString(EditDesktopMenuItemCaption)#",
								"icon": "pencil-button-icon",
								"visible": true,
								"clicked": {
									"request": "crt.SetupAppearanceEditDesktopRequest",
									"params": {
										"desktopSchemaName": "$DesktopList.DesktopSchemaName"
									}
								}
							},
							{
								"type": "crt.MenuItem",
								"caption": "#ResourceString(EditDesktopRightsCaption)#",
								"icon": "lock-button-icon",
								"visible": true,
								"clicked": {
									"request": "crt.LoadRightsModuleRequest",
									"params": {
										"payload": {
											"entitySchemaName": "Desktop",
											"primaryColumnValue": "$DesktopList.DesktopId",
											"primaryDisplayColumnValue": "$DesktopList.DesktopTitle"
										}
									}
								}
							},
							{
								"type": "crt.MenuItem",
								"caption": "#ResourceString(DeleteDesktopButtonCaption)#",
								"icon": "delete-button-icon",
								"visible": "$DesktopList.CanDelete",
								"clicked": {
									"request": "crt.SetupAppearanceDeleteDesktopRequest",
									"params": {
										"schemaRealUid": "$DesktopList.SchemaRealUId",
										"schemaName": "$DesktopList.DesktopSchemaName",
										"desktopTitle": "$DesktopList.DesktopTitle"
									}
								}
							},
							{
								"type": "crt.MenuItem",
								"caption": "#ResourceString(RestoreDesktopPreviousVersionButtonCaption)#",
								"icon": "delete-button-icon",
								"visible": "$DesktopList.CanRevert",
								"clicked": {
									"request": "crt.SetupAppearanceDeleteDesktopRequest",
									"params": {
										"schemaRealUid": "$DesktopList.SchemaRealUId",
										"schemaName": "$DesktopList.DesktopSchemaName",
										"desktopTitle": "$DesktopList.DesktopTitle"
									}
								}
							}
						]
					},
					"selectable": false
				},
				"parentName": "DesktopSettingsExpansionPanelContentGrid",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "AddDesktopButton",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 9,
						"colSpan": 2,
						"rowSpan": 1
					},
					"type": "crt.Button",
					"caption": "#ResourceString(AddDesktopButtonCaption)#",
					"color": "default",
					"disabled": false,
					"size": "large",
					"iconPosition": "left-icon",
					"visible": true,
					"icon": "add-button-icon",
					"clicked": {
						"request": "crt.SetupAppearanceAddDesktopRequest"
					}
				},
				"parentName": "DesktopSettingsExpansionPanelContentGrid",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "MobileHomePagesExpansionPanel",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 3,
						"colSpan": 1,
						"rowSpan": 1
					},
					"type": "crt.ExpansionPanel",
					"tools": [],
					"items": [],
					"title": "#ResourceString(MobileHomePagesExpansionPanel_title)#",
					"toggleType": "default",
					"togglePosition": "before",
					"expanded": true,
					"labelColor": "auto",
					"fullWidthHeader": false,
					"titleWidth": 20,
					"visible": true,
					"padding": {
						"top": "small",
						"bottom": "small",
						"left": "medium",
						"right": "medium"
					},
					"alignItems": "stretch"
				},
				"parentName": "GridContainer_2c333zl",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "MobileHomePagesExpansionPanelContentGrid",
				"values": {
					"type": "crt.GridContainer",
					"rows": "minmax(max-content, 32px)",
					"columns": [
						"minmax(32px, 1fr)",
						"minmax(32px, 1fr)"
					],
					"gap": {
						"columnGap": "large",
						"rowGap": "none"
					},
					"styles": {
						"overflow-x": "hidden"
					},
					"classes": [
						"appearence-desktops-preview"
					],
					"items": [],
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "none"
					}
				},
				"parentName": "MobileHomePagesExpansionPanel",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "MobileHomePagesGallery",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 1,
						"colSpan": 6,
						"rowSpan": 8
					},
					"type": "crt.Gallery",
					"items": "$HomePageList",
					"itemClick": {
						"request": "crt.SetupAppearanceEditMobileHomePageRequest",
						"params": {
							"homePageSchemaUid": "@event.HomePageUId"
						}
					},
					"itemConfig": {
						"templateValuesMapping": {
							"image": "Image",
							"caption": "HomePageTitle",
							"id": "HomePageId"
						},
						"defaultSize": "small",
						"actions": [
							{
								"type": "crt.MenuItem",
								"caption": "#ResourceString(EditMobileHomePageMenuItemCaption)#",
								"icon": "pencil-button-icon",
								"visible": true,
								"clicked": {
									"request": "crt.SetupAppearanceEditMobileHomePageRequest",
									"params": {
										"homePageSchemaUid": "$HomePageList.HomePageUId"
									}
								}
							},
							{
								"type": "crt.MenuItem",
								"caption": "#ResourceString(EditMobileHomePageRightsCaption)#",
								"icon": "lock-button-icon",
								"visible": true,
								"clicked": {
									"request": "crt.LoadRightsModuleRequest",
									"params": {
										"payload": {
											"entitySchemaName": "MobileHomePage",
											"primaryColumnValue": "$HomePageList.HomePageId",
											"primaryDisplayColumnValue": "$HomePageList.HomePageTitle"
										}
									}
								}
							},
							{
								"type": "crt.MenuItem",
								"caption": "#ResourceString(DeleteMobileHomePageButtonCaption)#",
								"icon": "delete-button-icon",
								"visible": "$HomePageList.CanDelete",
								"clicked": {
									"request": "crt.SetupAppearanceDeleteMobileHomePageRequest",
									"params": {
										"schemaRealUid": "$HomePageList.SchemaRealUId",
										"schemaName": "$HomePageList.HomePageSchemaName",
										"homePageTitle": "$HomePageList.HomePageTitle"
									}
								}
							}
						]
					},
					"selectable": false
				},
				"parentName": "MobileHomePagesExpansionPanelContentGrid",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "AddMobileHomePageButton",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 9,
						"colSpan": 2,
						"rowSpan": 1
					},
					"type": "crt.Button",
					"caption": "#ResourceString(AddMobileHomePageButton_caption)#",
					"color": "default",
					"disabled": false,
					"size": "large",
					"iconPosition": "left-icon",
					"visible": true,
					"icon": "add-button-icon",
					"clicked": {
						"request": "crt.SetupAppearanceAddMobileHomePageRequest"
					},
					"clickMode": "default"
				},
				"parentName": "MobileHomePagesExpansionPanelContentGrid",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "AdvancedExpansionPanel",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 4,
						"colSpan": 1,
						"rowSpan": 1
					},
					"type": "crt.ExpansionPanel",
					"tools": [],
					"items": [],
					"title": "#ResourceString(AdvancedExpansionPanelTitle)#",
					"toggleType": "default",
					"togglePosition": "before",
					"expanded": true,
					"labelColor": "auto",
					"fullWidthHeader": false,
					"titleWidth": 20,
					"visible": true
				},
				"parentName": "GridContainer_2c333zl",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "AdvancedExpansionPanelContentGrid",
				"values": {
					"type": "crt.GridContainer",
					"rows": "minmax(max-content, 32px)",
					"columns": [
						"minmax(32px, 1fr)",
						"minmax(32px, 1fr)"
					],
					"gap": {
						"columnGap": "large",
						"rowGap": "none"
					},
					"styles": {
						"overflow-x": "hidden",
						"padding-inline-start": "16px"
					},
					"classes": [
						"appearence-desktops-preview"
					],
					"items": [],
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "none"
					}
				},
				"parentName": "AdvancedExpansionPanel",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "DisableAdvancedVisualEffects",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 1,
						"colSpan": 2,
						"rowSpan": 1
					},
					"type": "crt.Checkbox",
					"label": "#ResourceString(DisableAdvancedVisualEffectsLabel)#",
					"labelPosition": "right",
					"control": "$DisableAdvancedVisualEffects",
					"tooltip": "#ResourceString(DisableAdvancedVisualEffectsTooltip)#"
				},
				"parentName": "AdvancedExpansionPanelContentGrid",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "HideSplashScreenLogoImage",
				"values": {
					"layoutConfig": {
						"column": 1,
						"colSpan": 1,
						"row": 2,
						"rowSpan": 1
					},
					"type": "crt.Checkbox",
					"value": true,
					"disabled": false,
					"inversed": false,
					"label": "#ResourceString(HideSplashScreenLogoImageLabel)#",
					"ariaLabel": "#ResourceString(HideSplashScreenLogoImageAriaLabel)#",
					"labelPosition": "right",
					"control": "$HideSplashScreenLogoImage",
					"tooltip": "#ResourceString(HideSplashScreenLogoImageTooltip)#",
					"visible": true,
					"readonly": false,
					"placeholder": ""
				},
				"parentName": "AdvancedExpansionPanelContentGrid",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "GridContainer_fi1ra6p",
				"values": {
					"layoutConfig": {
						"column": 7,
						"row": 1,
						"colSpan": 4,
						"rowSpan": 1
					},
					"type": "crt.GridContainer",
					"columns": [
						"minmax(32px, 1fr)"
					],
					"classes": [
						"appearence-main-preview"
					],
					"rows": "minmax(max-content, 52px)",
					"gap": {
						"columnGap": "large",
						"rowGap": "none"
					},
					"items": [],
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "4em",
						"right": "none",
						"bottom": "none",
						"left": "none"
					}
				},
				"parentName": "SetupAppearanceGridContent",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "ColorPreview",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 1,
						"colSpan": 1,
						"rowSpan": 16
					},
					"type": "crt.GridContainer",
					"items": [],
					"visible": "$UseBackgroundColor",
					"color": "$BackgroundColor",
					"classes": [
						"background-preview"
					],
					"borderRadius": "medium",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "none"
					}
				},
				"parentName": "GridContainer_fi1ra6p",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "SelectedBackgroundImagePreview",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 17,
						"colSpan": 1,
						"rowSpan": 16
					},
					"classes": [
						"background-preview"
					],
					"type": "crt.ImageInput",
					"value": "$SelectedBackgroundImageURL",
					"readonly": true,
					"placeholder": "",
					"labelPosition": "auto",
					"size": "default",
					"borderRadius": "medium",
					"positioning": "cover",
					"visible": "$UseBackgroundImage",
					"tooltip": "",
					"label": "$Resources.Strings.null"
				},
				"parentName": "GridContainer_fi1ra6p",
				"propertyName": "items",
				"index": 1
			}
		]/**SCHEMA_VIEW_CONFIG_DIFF*/,
		viewModelConfigDiff: /**SCHEMA_VIEW_MODEL_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"path": [],
				"values": {
					"attributes": {
						"DisableAdvancedVisualEffects": {
							"value": null
						},
						"HideSplashScreenLogoImage": {
							"value": null,
							"modelConfig": {}
						},
						"SelectedBackgroundMode": {},
						"UseBackgroundImage": {},
						"UseBackgroundColor": {},
						"BackgroundColor": {
							"modelConfig": {}
						},
						"AccessibleBackgroundColor": {
							"modelConfig": {}
						},
						"HideDeleteDesktopOptions": {},
						"BackgroundImagesSorting": {
							"value": [
								{
									"columnName": "Entity.UploadedOn",
									"direction": "asc"
								}
							]
						},
						"BackgroundImagesGallery": {
							"isCollection": true,
							"modelConfig": {
								"path": "BackgroundImagesGalleryDS",
								"sortingConfig": {
									"attributeName": "BackgroundImagesSorting"
								},
								"filterAttributes": [
									{
										"loadOnChange": true,
										"name": "BackgroundImagesGalleryLoadFilter"
									}
								]
							},
							"viewModelConfig": {
								"attributes": {
									"SelectedGalleryItemBackground": {
										"modelConfig": {
											"path": "BackgroundImagesGalleryDS.Entity"
										}
									},
									"SelectedGalleryItemId": {
										"modelConfig": {
											"path": "BackgroundImagesGalleryDS.Id"
										}
									}
								}
							}
						},
						"ConfiguredBackground": {},
						"LastConfiguredBackground": {},
						"SelectedBackgroundImage": {},
						"BackgroundChanged": {},
						"SelectedBackgroundImageURL": {},
						"BackgroundImagesGalleryLoadFilter": {
							"value": {
								"items": {
									"7f621bb0-729c-403f-90fc-9e01396f7149": {
										"filterType": 1,
										"comparisonType": 3,
										"isEnabled": true,
										"trimDateTimeParameterToDate": false,
										"leftExpression": {
											"expressionType": 0,
											"columnPath": "Tag.Name"
										},
										"isAggregative": false,
										"dataValueType": 1,
										"rightExpression": {
											"expressionType": 2,
											"parameter": {
												"dataValueType": 1,
												"value": "shell_background"
											}
										}
									}
								},
								"logicalOperation": 0,
								"isEnabled": true,
								"filterType": 6,
								"rootSchemaName": "SysImageInTag"
							}
						},
						"CurrentBackgroundImageUrl": {},
						"DesktopListUpdatedSubscription": {},
						"HomePageListUpdatedSubscription": {},
						"DesktopList": {
							"isCollection": true,
							"modelConfig": {
								"path": "DesktopListDS"
							},
							"viewModelConfig": {
								"attributes": {
									"Image": {},
									"DesktopTitle": {
										"modelConfig": {
											"path": "DesktopListDS.Title"
										}
									},
									"DesktopSchemaName": {
										"modelConfig": {
											"path": "DesktopListDS.DesktopSchemaName"
										}
									},
									"DesktopId": {
										"modelConfig": {
											"path": "DesktopListDS.Id"
										}
									},
									"SchemaUId": {
										"modelConfig": {
											"path": "DesktopListDS.SchemaUId"
										}
									},
									"SchemaRealUId": {
										"modelConfig": {
											"path": "DesktopListDS.SchemaRealUId"
										}
									},
									"CanDelete": {
										"value": true
									},
									"CanRevert": {
										"value": true
									}
								}
							}
						},
						"HomePageList": {
							"isCollection": true,
							"modelConfig": {
								"path": "HomePageListDS"
							},
							"viewModelConfig": {
								"attributes": {
									"Image": {},
									"HomePageTitle": {
										"modelConfig": {
											"path": "HomePageListDS.Title"
										}
									},
									"HomePageSchemaName": {
										"modelConfig": {
											"path": "HomePageListDS.MobileHomePageSchemaName"
										}
									},
									"HomePageId": {
										"modelConfig": {
											"path": "HomePageListDS.Id"
										}
									},
									"HomePageUId": {
										"modelConfig": {
											"path": "HomePageListDS.SchemaUId"
										}
									},
									"SchemaUId": {
										"modelConfig": {
											"path": "HomePageListDS.SchemaUId"
										}
									},
									"SchemaRealUId": {
										"modelConfig": {
											"path": "HomePageListDS.SchemaRealUId"
										}
									},
									"CanDelete": {
										"value": false
									}
								}
							}
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
						"BackgroundImagesGalleryDS": {
							"type": "crt.EntityDataSource",
							"scope": "viewElement",
							"config": {
								"entitySchemaName": "SysImageInTag",
								"attributes": {
									"Entity": {
										"path": "Entity"
									},
									"Id": {
										"path": "Id"
									}
								}
							}
						},
						"DesktopListDS": {
							"type": "crt.EntityDataSource",
							"scope": "viewElement",
							"config": {
								"entitySchemaName": "Desktop",
								"attributes": {
									"DesktopSchemaName": {
										"path": "DesktopSchemaName"
									},
									"Title": {
										"path": "Title"
									},
									"Id": {
										"path": "Id"
									}
								}
							}
						},
						"HomePageListDS": {
							"type": "crt.EntityDataSource",
							"scope": "viewElement",
							"config": {
								"entitySchemaName": "MobileHomePage",
								"attributes": {
									"MobileHomePageSchemaName": {
										"path": "MobileHomePageSchemaName"
									},
									"Title": {
										"path": "Title"
									},
									"Id": {
										"path": "Id"
									},
									"SchemaUId": {
										"path": "SchemaUId"
									},
									"SchemaRealUId": {
										"path": "SchemaRealUId"
									}
								}
							}
						}
					}
				}
			}
		]/**SCHEMA_MODEL_CONFIG_DIFF*/,
		handlers: /**SCHEMA_HANDLERS*/[]/**SCHEMA_HANDLERS*/,
		converters: /**SCHEMA_CONVERTERS*/{}/**SCHEMA_CONVERTERS*/,
		validators: /**SCHEMA_VALIDATORS*/{}/**SCHEMA_VALIDATORS*/
	};
});


