 define("ProcessUserTaskActivityEditSchema", [],
	function() {
		return {
			attributes: {
				/**
				 * Show in scheduler.
				 * @type {Boolean}
				 */
				"ShowInScheduler": {
					dataValueType: this.Terrasoft.DataValueType.BOOLEAN,
					type: this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					doAutoSave: true,
					initMethod: "initProperty"
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "ShowInScheduler",
					"parentName": "ActivityEditContainer",
					"propertyName": "items",
					"values": {
						"layout": { "column": 0, "row": 7, "colSpan": 24 },
						"caption": { "bindTo": "Resources.Strings.ShowInSchedulerCaption" },
						"wrapClass": ["t-checkbox-control"]
					}
				}
			]/**SCHEMA_DIFF*/
		};
	});
