define("SaveSchemaVersionMessageBox", ["SaveSchemaVersionMessageBoxResources", "ModalBox"
], function(resources, ModalBox) {
	return {
		attributes: {
			/**
			 * Message box title.
			 */
			"Title": {
				dataValueType: Terrasoft.DataValueType.TEXT,
				value: resources.localizableStrings.Message
			},
			/**
			 * Displayed message to the user.
			 */
			"Message": {
				dataValueType: Terrasoft.DataValueType.TEXT,
				value: resources.localizableStrings.Message
			},
			/**
			 * Flag that indicates when to save schema as new version.
			 */
			"SaveNewVersion": {
				dataValueType: Terrasoft.DataValueType.BOOLEAN,
				value: true
			},
			/**
			 * Flag indicates that the current schema should be saved as new version.
			 */
			"IsForceSaveNewVersion": {
				dataValueType: Terrasoft.DataValueType.BOOLEAN,
				value: false
			}
		},
		messages: {
			"OnVersionDialogButtonClick": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.PUBLISH
			}
		},
		methods: {

			// region Methods: Private

			/**
			 * @private
			 */
			_closeDialog: function(result) {
				const args = {
					canceled: result,
					saveAsNewVersion: this.get("SaveNewVersion")
				};
				this.sandbox.publish("OnVersionDialogButtonClick", args, [this.sandbox.id]);
				ModalBox.close(true);
			},
			
			// endregion
			
			// region Methods: Protected

			/**
			 * @inheritdoc Terrasoft.BaseSchemaViewModel#onRender
			 * @override
			 */
			onRender: function() {
				this.callParent(arguments);
				ModalBox.updateSizeByContent();
			},

			/**
			 * Handles Cancel button click. Closes page.
			 * @protected
			 */
			onCancelClick: function() {
				this._closeDialog(true);
			},

			/**
			 * Handles Save button click.
			 * @protected
			 */
			onSaveClick: function() {
				this._closeDialog(false);
			}

			// endregion

		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "MainWrap",
				"values": {
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"wrapClass": ["save-schema-version-message-box"],
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
					"caption": {"bindTo": "Title"}
				}
			},
			{
				"operation": "insert",
				"parentName": "HeaderWrap",
				"propertyName": "items",
				"name": "MessageWrap",
				"values": {
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"wrapClass": ["message-wrap"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "MessageWrap",
				"propertyName": "items",
				"name": "Message",
				"values": {
					"itemType": Terrasoft.ViewItemType.LABEL,
					"caption": {"bindTo": "Message"}
				}
			},
			{
				"operation": "insert",
				"parentName": "MainWrap",
				"propertyName": "items",
				"name": "SaveAsWrap",
				"values": {
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"wrapClass": ["save-as-radio-wrap"],
					"visible": {
						"bindTo": "IsForceSaveNewVersion",
						"bindConfig": {
							"converter": "invertBooleanValue"
						}
					},
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "SaveAsWrap",
				"propertyName": "items",
				"name": "SaveAsRadioGroup",
				"values": {
					"itemType": Terrasoft.ViewItemType.RADIO_GROUP,
					"value": {"bindTo": "SaveNewVersion"},
					"wrapClass": ["save-as-radio-group"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "SaveNewVersion",
				"parentName": "SaveAsRadioGroup",
				"propertyName": "items",
				"values": {
					"caption": {"bindTo": "Resources.Strings.SaveNewVersion"},
					"markerValue": "SaveNewVersion",
					"value": true
				}
			},
			{
				"operation": "insert",
				"name": "SetAsCurrentVersion",
				"parentName": "SaveAsRadioGroup",
				"propertyName": "items",
				"values": {
					"caption": {"bindTo": "Resources.Strings.SaveCurrentVersion"},
					"markerValue": "SaveCurrentVersion",
					"value": false
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
					"visible": {
						"bindTo": "IsForceSaveNewVersion",
						"bindConfig": {
							"converter": "invertBooleanValue"
						}
					}
				}
			},
			{
				"operation": "insert",
				"name": "ForceSave",
				"parentName": "ButtonsWrap",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.BUTTON,
					"caption": {"bindTo": "Resources.Strings.SaveNewVersion"},
					"style": Terrasoft.controls.ButtonEnums.style.BLUE,
					"click": {"bindTo": "onSaveClick"},
					"classes": {"textClass": ["button-margin-right"]},
					"visible": {"bindTo": "IsForceSaveNewVersion"}
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
		]/**SCHEMA_DIFF*/
	};
});
