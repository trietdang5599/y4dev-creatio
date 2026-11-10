define("TimeZoneLookupPage", ["TimeZoneLookupPageResources"],
	function() {
		return {
			entitySchemaName: "TimeZone",
			attributes: {
				"IsAddMode": {
					"dataValueType": Terrasoft.DataValueType.BOOLEAN,
					"value": false
				}
			},
			mixins: {
				"ConfigurationGridUtilities": "Terrasoft.ConfigurationGridUtilities"
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "activeRowActionRemove",
					"values": {
						"visible": false
					}
				},
				{
					"operation": "merge",
					"name": "activeRowActionCopy",
					"values": {
						"visible": false
					}
				},
				{
					"operation": "merge",
					"name": "SeparateModeAddRecordButton",
					"values": {
						"visible": false
					}
				},
				{
					"operation": "merge",
					"name": "SeparateModeBackButton",
					"values": {
						"style": Terrasoft.controls.ButtonEnums.style.BLUE
					}
				}
			],/**SCHEMA_DIFF*/
			methods: {
				/**
				 * @inheritdoc Terrasoft.ConfigurationGridUtilities#getCellControlsConfig
				 * @overridden
				 */
				getCellControlsConfig: function(entitySchemaColumn) {
					var controlsConfig =
							this.mixins.ConfigurationGridUtilities.getCellControlsConfig.apply(this, arguments);
					if (!this.get("IsAddMode")) {
						var enabled = (entitySchemaColumn.name === "Name");
						this.Ext.apply(controlsConfig, {
							enabled: enabled
						});
					}
					return controlsConfig;
				},

				/**
				 * @inheritdoc Terrasoft.ConfigurationGridUtilities#createNewRow
				 * @overridden
				 */
				createNewRow: function() {
					this.set("IsAddMode", true);
					this.mixins.ConfigurationGridUtilities.createNewRow.apply(this, arguments);
					this.set("IsAddMode", false);
				}
			}
		};
	});
