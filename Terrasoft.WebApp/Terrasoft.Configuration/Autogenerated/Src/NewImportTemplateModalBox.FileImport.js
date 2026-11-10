define("NewImportTemplateModalBox", ["ModalBox"], function(ModalBox) {
	return {
		attributes: {
			/**
			 * Flag that indicates when to save template as new version.
			 */
			"Name": {
				"dataValueType": Terrasoft.DataValueType.TEXT,
				"isRequired": true
			},
		},
		messages: {
			/**
			 * @message SetNewTemplateName
			 * Publish new template name.
			 */
			"SetNewTemplateName": {
				"mode": Terrasoft.MessageMode.PTP,
				"direction": Terrasoft.MessageDirectionType.PUBLISH
			}
		},
		methods: {

			//region Methods: Public

			/**
			 * Save button click handler.
			 * @public
			 */
			onSaveClick: function() {
				if (this.validate()) {
					this.sandbox.publish("SetNewTemplateName",  this.get("Name"), [this.sandbox.id]);
					ModalBox.close();
				}
			},

			/**
			 * Cancel button click handler.
			 * @public
			 */
			onCancelClick: function() {
				ModalBox.close();
			},

			/**
			 * Returns modal box initial config.
			 * @public
			 * @return {Object}
			 */
			getModalBoxInitialConfig: function() {
				return {
					"initialSize": {
						"width": 500,
						"height": 215
					}
				};
			}

			//endregion

		},
		diff: [
			{
				"operation": "insert",
				"name": "MainWrap",
				"values": {
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"wrapClass": ["new-import-template-message-box"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "MainWrap",
				"propertyName": "items",
				"name": "HeaderWrap",
				"values": {
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "HeaderWrap",
				"propertyName": "items",
				"name": "TitleWrap",
				"values": {
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"wrapClass": ["ts-inputbox-caption"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "TitleWrap",
				"propertyName": "items",
				"name": "Title",
				"values": {
					"itemType": Terrasoft.ViewItemType.LABEL,
					"caption": {"bindTo": "Resources.Strings.Title"}
				}
			},
			{
				"operation": "insert",
				"parentName": "MainWrap",
				"propertyName": "items",
				"name": "NameWrap",
				"values": {
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"wrapClass": ["inner-content-group"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "NameLabel",
				"parentName": "NameWrap",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.LABEL,
					"caption": {"bindTo": "Resources.Strings.NameCaption"},
					"labelClass": ["control-caption"],
				}
			},
			{
				"operation": "insert",
				"name": "Name",
				"parentName": "NameWrap",
				"propertyName": "items",
				"values": {
					"dataValueType": Terrasoft.DataValueType.TEXT,
					"markerValue": "NewTemplateNameTextEdit",
					"controlConfig": {
						"className": "Terrasoft.TextEdit",
						"value": {"bindTo": "Name"},
					},
					"labelConfig": {
						"visible": false
					}
				}
			},
			{
				"operation": "insert",
				"name": "ButtonsWrap",
				"parentName": "MainWrap",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"wrapClass": ["buttons-wrap"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "Save",
				"parentName": "ButtonsWrap",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.BUTTON,
					"caption": {"bindTo": "Resources.Strings.Save"},
					"style": Terrasoft.controls.ButtonEnums.style.BLUE,
					"click": {"bindTo": "onSaveClick"},
					"classes": {"textClass": ["button-margin-right"]},
				}
			},
			{
				"operation": "insert",
				"name": "Cancel",
				"parentName": "ButtonsWrap",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.BUTTON,
					"caption": {"bindTo": "Resources.Strings.Cancel"},
					"click": {"bindTo": "onCancelClick"},
					"classes": {"textClass": ["button-margin-right"]}
				}
			}
		]
	};
});
