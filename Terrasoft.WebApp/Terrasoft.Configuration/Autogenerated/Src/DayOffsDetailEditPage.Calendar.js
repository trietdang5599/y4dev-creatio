define("DayOffsDetailEditPage", ["DayOffsDetailEditPageResources"],
		function(resources) {
			return {
				entitySchemaName: "DayOff",
				attributes: {
					"Date": {
						"columnPath": "Date",
						"dataValueType": this.Terrasoft.DataValueType.DATE,
						"caption": resources.localizableStrings.DateCaption,
						"isRequired": true,
						"type": this.Terrasoft.ViewModelColumnType.ENTITY_COLUMN
					},
					"DayType": {
						"columnPath": "DayType",
						"dataValueType": this.Terrasoft.DataValueType.LOOKUP.GUID,
						"caption": resources.localizableStrings.DayTypeCaption,
						"isRequired": true,
						"type": this.Terrasoft.ViewModelColumnType.ENTITY_COLUMN,
						"lookupListConfig": {
							"columns": ["NonWorking"]
						},
						"dependencies": [
							{
								"columns": ["DayType"],
								"methodName": "onDayTypeChanged"
							}
						]
					},
					"WorkingIntervals": {
						"dataValueType": this.Terrasoft.DataValueType.TEXT,
						"caption": resources.localizableStrings.WorkingIntervalsCaption,
						"type": this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
					},
					"DayType.NonWorking": {
						"dataValueType": this.Terrasoft.DataValueType.BOOLEAN,
						"type": this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
					}
				},
				methods: {
					/**
					 * Sets attribute DayType.NonWorking when DayType changes
					 * @private
					 */
					onDayTypeChanged: function() {
						if(this.get("DayType")) {
							var nonWorking = this.get("DayType").NonWorking;
							this.set("DayType.NonWorking", nonWorking);
						}
					}
				}
			};
		});
