define("BaseModalTimeEditModuleSchema", ["BaseModalTimeEditModuleSchemaResources", "ModalBox",
		"css!BaseModalTimeEditModuleSchemaCSS"],
	function(resources, ModalBox) {
		return {
			attributes: {
				"SelectedTimeValue": {
					"dataValueType": Terrasoft.DataValueType.TIME,
					"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
				}
			},
			methods: {

				//region Methods: Public

				/**
				 * @inheritdoc Terrasoft.BaseSchemaViewModel#init
				 * @override
				 */
				init: function() {
					this.callParent(arguments);
					this.initSelectedTimeValue();
				},

				/**
				 * Loads value to SelectedTimeValue attribute
				 */
				initSelectedTimeValue: Terrasoft.emptyFn,

				/**
				 * Callback for initSelectedTimeValue.
				 * @param {Object} value Value.
				 */
				initSelectedTimeValueCallback: function(value) {
					this.$SelectedTimeValue = value;
				},

				/**
				 * Saves new value of SelectedTimeValue attribute.
				 */
				saveSelectedTimeValue: Terrasoft.emptyFn,

				/**
				 * Callback for saveSelectedTimeValue.
				 */
				saveSelectedTimeValueCallback: function() {
					ModalBox.close();
				},

				/**
				 * Save button handler.
				 */
				onSaveButtonClick: function() {
					this.saveSelectedTimeValue();
				},

				/**
				 * Cancel button handler.
				 */
				onCancelClick: function() {
					ModalBox.close();
				}

				//endregion

			},
			diff: [
				{
					"operation": "insert",
					"name": "ModalTimeEditContainer",
					"values": {
						"itemType": this.Terrasoft.ViewItemType.CONTAINER,
						"classes": {
							"wrapClassName": ["modal-time-edit-container"]
						},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "ModalTimeEditCaption",
					"parentName": "ModalTimeEditContainer",
					"propertyName": "items",
					"values": {
						"itemType": Terrasoft.ViewItemType.LABEL,
						"caption": {
							"bindTo": "Resources.Strings.TimeZoneModalBoxCaption"
						},
						"classes": {
							"labelClass": ["modal-time-edit-caption"]
						}
					}
				},
				{
					"operation": "insert",
					"name": "SelectedTimeValueField",
					"parentName": "ModalTimeEditContainer",
					"propertyName": "items",
					"values": {
						"bindTo": "SelectedTimeValue",
						"caption": {
							"bindTo": "Resources.Strings.SelectedTimeValueFieldCaption"
						},
						"controlConfig": {
							"classes": ["modal-time-edit-value-field"]
						}
					}
				},
				{
					"operation": "insert",
					"name": "ModalTimeEditButtonContainer",
					"values": {
						"itemType": this.Terrasoft.ViewItemType.CONTAINER,
						"classes": {
							"wrapClassName": ["modal-time-edit-button-container"]
						},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "SaveButton",
					"parentName": "ModalTimeEditButtonContainer",
					"propertyName": "items",
					"values": {
						"itemType": Terrasoft.ViewItemType.BUTTON,
						"caption": {
							"bindTo": "Resources.Strings.SaveButtonCaption"
						},
						"click": {"bindTo": "onSaveButtonClick"},
						"style": Terrasoft.controls.ButtonEnums.style.BLUE,
						"classes": {"textClass": "actions-button-margin-right"}
					}
				},
				{
					"operation": "insert",
					"name": "CancelButton",
					"parentName": "ModalTimeEditButtonContainer",
					"propertyName": "items",
					"values": {
						"itemType": Terrasoft.ViewItemType.BUTTON,
						"caption": {
							"bindTo": "Resources.Strings.CancelButtonCaption"
						},
						"click": {"bindTo": "onCancelClick"},
						"style": Terrasoft.controls.ButtonEnums.style.GRAY,
						"classes": {"textClass": "actions-button-margin-right"}
					}
				}
			]
		};
	});
