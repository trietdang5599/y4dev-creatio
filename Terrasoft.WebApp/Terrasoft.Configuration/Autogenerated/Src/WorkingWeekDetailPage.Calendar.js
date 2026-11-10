define("WorkingWeekDetailPage", ["WorkingWeekDetailPageResources"],
		function(resources) {
			return {
				entitySchemaName: "DayInCalendar",
				mixins: {},
				attributes: {
					"DayOfWeek": {
						"columnPath": "DayOfWeek",
						"dataValueType": this.Terrasoft.DataValueType.LOOKUP.GUID,
						"caption": resources.localizableStrings.DayOfWeekCaption,
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
				diff: [],
				methods: {
					/**
					 * Sets attribute DayType.NonWorking when DayType changes
					 * @private
					 */
					onDayTypeChanged: function() {
						var nonWorking = this.get("DayType").NonWorking;
						this.set("DayType.NonWorking", nonWorking);
					}
				}
			};
		});
