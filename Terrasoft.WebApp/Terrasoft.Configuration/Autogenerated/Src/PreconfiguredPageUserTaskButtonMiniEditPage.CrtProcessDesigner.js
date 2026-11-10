 /**
 * Parent: BaseProcessMiniEditPage
 */
define("PreconfiguredPageUserTaskButtonMiniEditPage", ["terrasoft",
		"PreconfiguredPageUserTaskButtonMiniEditPageResources"],
	function(Terrasoft, resources) {
	return {
		attributes: {

			/**
			 * Title of button.
			 * @type {Terrasoft.dataValueType.TEXT}
			 */
			"Caption": {
				"dataValueType": this.Terrasoft.DataValueType.TEXT,
				"type": this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"caption": resources.localizableStrings.NameCaption,
				"isRequired": true
			},

			/**
			 * Code of button
			 * @type {Terrasoft.dataValueType.TEXT}
			 */
			"Name": {
				"dataValueType": this.Terrasoft.DataValueType.TEXT,
				"type": this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"caption": resources.localizableStrings.CodeCaption,
				"isRequired": true
			},

			/**
			 * Performs page close.
			 * @type {Terrasoft.dataValueType.BOOLEAN}
			 */
			"PerformsPageCompletion": {
				"dataValueType": this.Terrasoft.DataValueType.BOOLEAN,
				"type": this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"caption": resources.localizableStrings.PerformsPageCompletionCaption,
				"doAutoSave": true,
				"initMethod": "initProperty"
			},

			/**
			 * Perform validation property of button.
			 * @type {Terrasoft.dataValueType.BOOLEAN}
			 */
			"PerformsValidation": {
				"dataValueType": this.Terrasoft.DataValueType.BOOLEAN,
				"type": this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"caption": resources.localizableStrings.PerformsValidationCaption,
				"doAutoSave": true,
				"initMethod": "initProperty"
			},

			/**
			 * Parent view model's collection.
			 * @type {Terrasoft.dataValueType.COLLECTION}
			 */
			"ParentCollection": {
				"dataValueType": this.Terrasoft.DataValueType.COLLECTION,
				"type": this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Determines whether the user can set up the button to skip validation.
			 * @type {Terrasoft.dataValueType.BOOLEAN}
			 */
			"AllowSkipValidation": {
				"dataValueType": this.Terrasoft.DataValueType.BOOLEAN,
				"type": this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"value": true
			}
		},
		methods: {
			/**
			 * @inheritdoc Terrasoft.BaseSchemaViewModel#init
			 * @overridden
			 */
			init: function() {
				this.set(
					"AllowSkipValidation",
					Terrasoft.Features.getIsEnabled("PreconfiguredPageUserTask.AllowSkipValidation")
				);
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc Terrasoft.BaseProcessMiniEditPage#getShowSaveButton
			 * @overridden
			 */
			getShowSaveButton: function() {
				return true;
			},

		},
		diff: /**SCHEMA_DIFF*/ [{
			"operation": "insert",
			"parentName": "Controls",
			"propertyName": "items",
			"name": "Caption",
			"values": {
				"itemType": this.Terrasoft.ViewItemType.TEXT,
				"value": {
					"bindTo": "Caption"
				},
				"isRequired": true,
				"enabled": { "bindTo": "IsEditable" },
				"classes": {
					"labelClass": ["t-label-proc"]
				},
				"layout": {
					"column": 0,
					"row": 0,
					"colSpan": 24
				},
				"wrapClass": ["top-caption-control"]
			}
		}, {
			"operation": "insert",
			"parentName": "Controls",
			"propertyName": "items",
			"name": "Name",
			"values": {
				"itemType": this.Terrasoft.ViewItemType.TEXT,
				"value": {
					"bindTo": "Name"
				},
				"isRequired": true,
				"enabled": { "bindTo": "IsEditable" },
				"classes": {
					"labelClass": ["t-label-proc"]
				},
				"layout": {
					"column": 0,
					"row": 1,
					"colSpan": 24
				},
				"wrapClass": ["top-caption-control"]
			}
		}, {
			"operation": "insert",
			"parentName": "Controls",
			"propertyName": "items",
			"name": "PerformsPageCompletion",
			"values": {
				"layout": {
					"column": 0,
					"row": 2,
					"colSpan": 24
				},
				"wrapClass": ["t-checkbox-control"]
			}
		}, {
			"operation": "insert",
			"parentName": "Controls",
			"propertyName": "items",
			"name": "PerformsValidation",
			"values": {
				"enabled": {
					"bindTo": "AllowSkipValidation",
				},
				"layout": {
					"column": 0,
					"row": 3,
					"colSpan": 24
				},
				"wrapClass": ["t-checkbox-control"]
			}
		}] /**SCHEMA_DIFF*/
	};
});
