define("CustomerLanguagesLookupSection", [],
		function() {
			return {
				entitySchemaName: "SysLanguage",
				attributes: {
					"IsAddMode": {
						"dataValueType": Terrasoft.DataValueType.BOOLEAN,
						"value": false
					}
				},
				diff: /**SCHEMA_DIFF*/[
					{
						"operation": "remove",
						"name": "SeparateModeAddRecordButton"
					}
				]/**SCHEMA_DIFF*/,
				mixins: {
					"ConfigurationGridUtilities": "Terrasoft.ConfigurationGridUtilities"
				},
				messages: {},
				methods: {

					/**
					 * @inheritdoc Terrasoft.ConfigurationGridUtilities#getCellControlsConfig
					 * @overridden
					 */
					getCellControlsConfig: function(entitySchemaColumn) {
						var controlsConfig =
								this.mixins.ConfigurationGridUtilities.getCellControlsConfig.apply(this, arguments);
						if (!this.get("IsAddMode")) {
							var enabled = (entitySchemaColumn.name !== "Code");
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
