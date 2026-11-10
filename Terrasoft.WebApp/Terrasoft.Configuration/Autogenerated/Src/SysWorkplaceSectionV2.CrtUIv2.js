define("SysWorkplaceSectionV2", ["LocalizableHelper", "ServiceHelper", "ConfigurationEnums",
		"SysWorkplaceSectionGridRowViewModel", "SysWorkplaceUtilitiesModuleV2", "css!SysWorkplaceUtilitiesModuleV2"],
function(LocalizableHelper, ServiceHelper, ConfigurationEnums) {
	return {
		entitySchemaName: "SysWorkplace",

		messages: {
			"RefreshWorkplace": {
				mode: this.Terrasoft.MessageMode.PTP,
				direction: this.Terrasoft.MessageDirectionType.PUBLISH
			}
		},

		attributes: {
			"SecurityOperationName": {
				"dataValueType": this.Terrasoft.DataValueType.STRING,
				"value": "CanManageWorkplaceSettings"
			},

			/**
			 * List of typed workplaces edit pages.
			 */
			"WorkplaceTypedPages": {
				"dataValueType": Terrasoft.DataValueType.COLLECTION
			}
		},

		methods: {

			/**
			 * @overridden
			 */
			getGridRowViewModelClassName: function() {
				return "Terrasoft.SysWorkplaceSectionGridRowViewModel";
			},

			/**
			* ########## ############# ####### ## #########.
			* ######, #########
			* @protected
			* @return {Object} ############# ####### ## #########
			*/
			getDefaultDataViews: function() {
				var gridDataView = {
					name: "GridDataView",
					active: true,
					caption: this.getDefaultGridDataViewCaption(),
					icon: this.getDefaultGridDataViewIcon()
				};
				return {
					"GridDataView": gridDataView
				};
			},

			/**
			* @override
			* @returns {string}
			*/
			getDefaultGridDataViewCaption: function() {
				return this.get("Resources.Strings.HeaderCaption");
			},

			/**
			 * @override
			 */
			initSeparateModeActionsButtonHeaderMenuItemCaption: function() {
				this.set("SeparateModeActionsButtonHeaderMenuItemCaption", this.get("Resources.Strings.HeaderCaption"));
				this.set("IsIncludeInFolderButtonVisible", false);
			},

			/**
			 * ##### ######### ######## ### ########## ####### # ############ ## tag
			 * @private
			 */
			onActiveRowAction: function(tag, id) {
				if (tag === "delete" || tag === "edit") {
					this.callParent(arguments);
				} else {
					var gridData = this.getGridData();
					var activeRow = gridData.get(id);
					var position = activeRow.get("Position");
					if (tag === "up" && position > 0) {
						position--;
					}
					if (tag === "down") {
						position++;
					}
					this.setPosition(id, position, function() {
						gridData.clear();
						this.loadGridData();
					}, this);
				}
			},

			/**
			 * ######## #######, ####### ###### ########## ########
			 * @protected
			 * @overridden
			 * @return {Object} ########## #######, ####### ###### ########## ########
			 */
			getGridDataColumns: function() {
				var gridDataColumns = this.callParent(arguments);
				if (!gridDataColumns.Position) {
					gridDataColumns.Position = {
						path: "Position",
						orderPosition: 0,
						orderDirection: Terrasoft.OrderDirection.ASC
					};
				}
				return gridDataColumns;
			},

			/**
			 * ############# ####### ######.
			 * @protected
			 * @virtual
			 * @param {String} recordId ########## ############# ######.
			 * @param {Number} position ##### ####### ######.
			 * @param {Function} callback #######, ####### ##### ####### ## ##########.
			 * @param {Object} scope ########, # ####### ##### ####### ####### callback.
			 */
			setPosition: function(recordId, position, callback, scope) {
				var data = {
					tableName: this.entitySchemaName,
					primaryColumnValue: recordId,
					position: position,
					grouppingColumnNames: ""
				};
				Terrasoft.chain(
					function(next) {
						if (this.getIsFeatureDisabled("EnableReloadAppCacheForWorkplacesByDefault")) {
							ServiceHelper.callService("WorkplaceService", "ResetWorkplaceCache", next, {}, this);
						} else {
							next();
						}
					},
					function() {
						ServiceHelper.callService("RightsService", "SetCustomRecordPosition", callback, data, scope);
					},
					this
				);
			},

			/**
			 * @inheritdoc GridUtilitiesV2#onDelete
			 * @override
			 */
			onDelete: function(returnCode) {
				if (this.getIsFeatureDisabled("EnableReloadAppCacheForWorkplacesByDefault")) {
					ServiceHelper.callService("WorkplaceService", "ResetWorkplaceCache");
				}
				this.callParent(arguments);
			},

			/**
			* ######### ######## ########### ##### ########### ########.
			* @protected
			* @overridden
			*/
			onRender: function() {
				if (!this.get("Restored")) {
					this.loadActiveViewData();
				}
				this.callParent(arguments);
			},

			/**
			 * @inheritDoc BasePageV2#init
			 * @overridden
			 */
			init: function(callback, scope) {
				this.callParent([function() {
					this.initWorkplaceTypes(callback, scope);
				}, this]);
			},

			/**
			 * Initialize types of workplaces and corresponding edit pages.
			 * @param {Function} callback Callback method on init complete.
			 * @param {Object} scope Callback scope.
			 */
			initWorkplaceTypes: function(callback, scope) {
				this.$WorkplaceTypedPages = this.Ext.create("Terrasoft.BaseViewModelCollection");
				const workplacesEsq = this._getWorkplaceTypesEsq();
				workplacesEsq.getEntityCollection(function(result) {
					if (result.success) {
						result.collection.each(function(item) {
							this.$WorkplaceTypedPages.addItem(this._getEditPagesMenuItem(item));
						}, this);
					}
					this.Ext.callback(callback, scope);
				}, this);
			},

			_getWorkplaceTypesEsq: function() {
				const select = Ext.create("Terrasoft.EntitySchemaQuery", {
					rootSchemaName: "SysWorkplaceType"
				});
				select.addColumn("Id");
				select.addColumn("Name");
				select.addColumn("Code");
				return select;
			},

			/**
			 * get edit page button config.
			 * @returns {Terrasoft.BaseViewModel}
			 * @private
			 */
			_getEditPagesMenuItem: function(workplacesQueryResultItem) {
				return this.Ext.create("Terrasoft.BaseViewModel", {
					values: {
						Click: {"bindTo": "addNewWorkplace"},
						Caption: workplacesQueryResultItem.$Name,
						Tag: {
							TypeId: workplacesQueryResultItem.$Id,
							TypeCode: workplacesQueryResultItem.$Code
						},
						MarkerValue: workplacesQueryResultItem.$Name
					}
				});
			},

			/**
			 * Add new typed workplace.
			 * @param {Object} tag Button tag for typed pages.
			 */
			addNewWorkplace: function(tag) {
				const schemaName = this.getEditPageSchemaName();
				this.openCardInChain({
					schemaName: schemaName,
					operation: ConfigurationEnums.CardStateV2.ADD,
					moduleId: this.getChainCardModuleSandboxId(this.Terrasoft.GUID_EMPTY),
					defaultValues: [
						{
							name: "Type",
							value: tag.TypeId
						}, {
							name: "Code",
							value: tag.TypeCode
					}]
				});
			}

		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "merge",
				"name": "DataGrid",
				"values": {
					"activeRowAction": {bindTo: "onActiveRowAction"},
					"type": "tiled",
					"listedConfig": {
						"name": "DataGridListedConfig",
						"items": [
							{
								"name": "NameListedGridColumn",
								"bindTo": "Name",
								"type": Terrasoft.GridCellType.TEXT,
								"position": {"column": 1, "colSpan": 14}
							}
						]
					},
					"tiledConfig": {
						"name": "DataGridTiledConfig",
						"grid": {"columns": 24, "rows": 1},
						"items": [
							{
								"name": "NameTiledGridColumn",
								"bindTo": "Name",
								"type": Terrasoft.GridCellType.TEXT,
								"position": {"row": 1, "column": 1, "colSpan": 10},
								"captionConfig": {"visible": false}
							}
						]
					},
					"sortColumnIndex": null
				}
			},
			{
				"operation": "merge",
				"name": "DataViewsContainer",
				"values": {
					"wrapClass": ["workplace-data-views-container-wrapClass"]
				}
			},
			{
				"operation": "insert",
				"name": "DataGridActiveRowMoveUpAction",
				"parentName": "DataGrid",
				"propertyName": "activeRowActions",
				"values": {
					"className": "Terrasoft.Button",
					"style": Terrasoft.controls.ButtonEnums.style.BLUE,
					"hint": LocalizableHelper.localizableStrings.UpButtonHint,
					"imageConfig": LocalizableHelper.localizableImages.Up,
					"tag": "up"
				}
			},
			{
				"operation": "insert",
				"name": "DataGridActiveRowMoveDownAction",
				"parentName": "DataGrid",
				"propertyName": "activeRowActions",
				"values": {
					"className": "Terrasoft.Button",
					"style": Terrasoft.controls.ButtonEnums.style.BLUE,
					"hint": LocalizableHelper.localizableStrings.DownButtonHint,
					"imageConfig": LocalizableHelper.localizableImages.Down,
					"tag": "down"
				}
			},
			{
				"operation": "remove",
				"name": "DataGridActiveRowCopyAction"
			},
			{
				"operation": "remove",
				"name": "SeparateModePrintButton"
			},
			{
				"operation": "merge",
				"name": "DataGridActiveRowOpenAction",
				"values": {
					"style": Terrasoft.controls.ButtonEnums.style.GREY
				}
			},
			{
				"operation": "remove",
				"name": "CombinedModePrintButton"
			},
			{
				"operation": "remove",
				"name": "CombinedModeViewOptionsButton"
			},
			{
				"operation": "remove",
				"name": "SeparateModeViewOptionsButton"
			},
			{
				"operation": "remove",
				"name": "SeparateModeActionsButton"
			},
			{
				"operation": "remove",
				"name": "FiltersContainer"
			},
			{
				"operation": "merge",
				"name": "SeparateModeAddRecordButton",
				"parentName": "SeparateModeActionButtonsLeftContainer",
				"propertyName": "items",
				"values": {
					"visible": {
						"bindTo": "IsAddRecordButtonVisible",
						"bindConfig": {
							"converter": function(value) {
								return value && this.getIsFeatureDisabled("UseTypedWorkplaces");
							}
						}
					}
				}
			},
			{
				"operation": "insert",
				"name": "SeparateModeAddTypedRecordButton",
				"parentName": "SeparateModeActionButtonsLeftContainer",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.BUTTON,
					"style": Terrasoft.controls.ButtonEnums.style.GREEN,
					"caption": {"bindTo": "AddRecordButtonCaption"},
					"visible": {
						"bindTo": "IsAddRecordButtonVisible",
						"bindConfig": {
							"converter": function(value) {
								return value && this.getIsFeatureEnabled("UseTypedWorkplaces");
							}
						}
					},
					"classes": {
						"textClass": ["actions-button-margin-right"],
						"wrapperClass": ["actions-button-margin-right"]
					},
					"controlConfig": {
						"menu": {
							"items": {
								"bindTo": "WorkplaceTypedPages"
							}
						}
					}
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
