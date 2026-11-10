define("PortalSchemaAccessListLookupSection", ["BusinessRuleModule", "PortalSchemaAccessListLookupSectionResources",
			"ConfigurationEnums", "ConfigurationGrid", "ConfigurationGridGenerator",
			"ConfigurationGridUtilities"],
		function(BusinessRuleModule, resources) {
			return {
				entitySchemaName: "PortalSchemaAccessList",
				attributes: {
					"SysEntitySchema": {
						dataValueType: Terrasoft.DataValueType.LOOKUP,
						type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
					}
				},
				mixins: {
					ConfigurationGridUtilites: "Terrasoft.ConfigurationGridUtilities"
				},
				diff: /**SCHEMA_DIFF*/[
					{
						"operation": "merge",
						"name": "DataGrid",
						"parentName": "DataGridContainer",
						"propertyName": "items",
						"values": {
							"columnsConfig": [
								{
									"cols": 24,
									"key": [
										{
											"name": {"bindTo": "SysEntitySchema"}
										}
									]
								}
							],
							"captionsConfig": [
								{
									"cols": 24,
									"name": resources.localizableStrings.AccessEntitySchemaCaption
								}
							]
						}
					},
					{
						"operation": "remove",
						"name": "DataGridActiveRowCopyAction"
					},
					{
						"operation": "remove",
						"name": "activeRowActionCopy"
					},
					{
						"operation": "merge",
						"name": "SeparateModeViewOptionsButton",
						"values": {"visible": false}
					}
				]/**SCHEMA_DIFF*/,
				messages: {},
				methods: {

					/**
					 * @inheritdoc Terrasoft.GridUtilitiesV2#generateEntityProfile
					 * @overridden
					 */
					generateEntityProfile: function() {
						return {};
					},

					/**
					 * @inheritdoc Terrasoft.GridUtilities#initQueryColumns
					 * @overridden
					 */
					initQueryColumns: function(esq) {
						this.callParent(arguments);
						esq.addColumn("[VwSysSchemaInfo:UId:SchemaUId].Caption", "SysEntitySchema");
					},

					/**
					 * @inheritDoc BasePageV2#initActionButtonMenu
					 * @overridden
					 */
					initActionButtonMenu: function() {
						this.set("ActionsButtonVisible", false);
					},

					/**
					 * @inheritDoc Terrasoft.GridUtilities#getGridRowViewModelConfig
					 * @overridden
					 */
					getGridRowViewModelConfig: function(config) {
						this.applyGridRowViewModelConfig(config);
						return this.callParent(arguments);
					},

					/**
					 * Find and replace SysEntitySchema property.
					 * @private
					 * @param {Object} config Properties of the view model class.
					 */
					applyGridRowViewModelConfig: function(config) {
						var rowData = config.rawData;
						if (rowData && rowData.hasOwnProperty("SysEntitySchema")) {
							rowData.SysEntitySchema = {
								displayValue: rowData.SysEntitySchema,
								value: rowData.SysEntitySchemaUId
							};
						}
						var rowConfig = config.rowConfig;
						if (rowConfig && rowConfig.hasOwnProperty("SysEntitySchema")) {
							this.Ext.apply(rowConfig.SysEntitySchema, {
								dataValueType: this.Terrasoft.DataValueType.LOOKUP,
								isLookup: true,
								referenceSchemaName: "VwSysSchemaInfo"
							});
						}
					},

					/**
					 * @inheritdoc Terrasoft.ConfigurationGridUtilites#getCellControlsConfig
					 * @overridden
					 */
					getCellControlsConfig: function() {
						var controlsConfig =
								this.mixins.ConfigurationGridUtilities.getCellControlsConfig.apply(this, arguments);
						var activeRow = this.getActiveRow();
						if (!(activeRow && activeRow.isNew)) {	
							this.Ext.apply(controlsConfig, {
								enabled: false
							});
						}
						return controlsConfig;
					},

					/**
					 * @inheritdoc Terrasoft.GridUtilities#getDefaultGridProfile
					 * @overridden
					 */
					applyDefaultGridProfile: this.Terrasoft.emptyFn
				}
			};
		});
