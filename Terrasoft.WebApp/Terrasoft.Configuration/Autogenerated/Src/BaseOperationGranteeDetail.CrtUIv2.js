define("BaseOperationGranteeDetail",
	["LocalizableHelper", "ConfigurationEnums", "BaseOperationGranteeDetailResources", "ConfigurationGrid",
		"ConfigurationGridGenerator", "ConfigurationGridUtilities", "RightsServiceHelper"],
	function(LocalizableHelper, enums) {
		return {
			attributes: {
				IsEditable: {
					"type": this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": true,
					"dataValueType": this.Terrasoft.DataValueType.BOOLEAN
				}
			},
			properties: {
				disableCachedActiveRow: false
			},
			mixins: {
				ConfigurationGridUtilities: "Terrasoft.ConfigurationGridUtilities"
			},
			methods: {

				//region Methods: Private

				/**
				 * #########, ######### ## ######## ##############, # ###### ######## ########.
				 * @return {Boolean} ######### ########.
				 * @private
				 */
				isPageInAddState: function() {
					const state = this.sandbox.publish("GetCardState", null, [this.sandbox.id]);
					return state.state === enums.CardStateV2.ADD;
				},

				/**
				 * ######### ##### ######## # ####### ######.
				 * @private
				 */
				silentSaveOperation: function() {
					const args = {
						"isSilent": true,
						"messageTags": [this.sandbox.id]
					};
					this.sandbox.publish("SaveRecord", args, [this.sandbox.id]);
				},

				/**
				 * ########## ####### ###### #####/####.
				 * @param {Object} a1 ignore
				 * @param {Object} a2 ignore
				 * @param {Object} a3 ignore
				 * @param {String} tag Tag ####### ######.
				 * @private
				 */
				onUpDownButtonClick: function(a1, a2, a3, tag) {
					const count = this.getGridData().getCount();
					if (count < 2) {
						return;
					}
					const activeRow = this.getActiveRow();
					if (activeRow) {
						let position = activeRow.get("Position");
						switch (tag) {
							case "up":
								if (position === 0) {
									return;
								}
								position--;
								break;
							case "down":
								position++;
								break;
						}
						this.setGranteePosition(activeRow.get("Id"), position, function() {
							this.reloadGridData();
						}, this);
					}
				},

				/**
				 * ######### ########## ############/####.
				 * @param {Object} config ######### ###########.
				 * #### ######### ###########, ##### ######### ########### ######### (##. getAdminUnitLookupConfig).
				 * @private
				 */
				openAdminUnitLookup: function(config) {
					this.showBodyMask();
					if (!config) {
						config = this.getAdminUnitLookupConfig();
					}
					this.openLookup(config, this.onAdminUnitLookupClosed, this);
				},

				/**
				 * ######### ###### #######.
				 * ########### ##### ########## ####### # ##.
				 * @private
				 */
				onInsertComplete: function() {
					this.hideBodyMask();
					this.reloadGridData();
				},

				/**
				 * ####### ###### ## #######.
				 * ########### ##### ######## ####### ## ##.
				 * @private
				 */
				onDeleteComplete: function() {
					this.hideBodyMask();
					this.reloadGridData();
				},

				/**
				 * ########### ##### ######## ########### ############/####.
				 * @param {Object} args ######## ######### ####### ######### # ########### ############/####.
				 * @private
				 */
				onAdminUnitLookupClosed: function(args) {
					this.hideBodyMask();
					if (args) {
						const items = args.selectedRows.getItems();
						if (items.length > 0) {
							const itemIds = [];
							this.Terrasoft.each(items, function(item) {
								itemIds.push(item.value);
							}, this);
							this.setOperationGrantees(itemIds, true, this.onInsertComplete, this);
						}
					}
				},

				/**
				 * ########## ######### ### ########### ############/####.
				 * @param {Boolean} multi ######### ## ############# #####. ## ######### — ##.
				 * @param {Boolean} actions ########## ## ###### ########. ## ######### — ###.
				 * @param {Terrasoft.FilterGroup} filtersGroup ######### ########.
				 * #### ######### ###########, ##### ######## ########### ###### (##. getAdminUnitLookupFilters).
				 * @return {Object} ######### ########### ############/####.
				 * @private
				 */
				getAdminUnitLookupConfig: function(multi, actions, filtersGroup) {
					return {
						"multiSelect": this.Ext.isEmpty(multi) ? true : multi,
						"hideActions": this.Ext.isEmpty(actions) ? true : actions,
						"filters": !filtersGroup ? this.getAdminUnitLookupFilters() : filtersGroup,
						"entitySchemaName": "SysAdminUnit"
					};
				},

				/**
				 * ########## ########## #### # ############ ######### ########.
				 * @param {Function} callback ####### ######### ######.
				 * ###########, #### ###### ###### ##.
				 * @private
				 */
				showConfirmSaveOperationDialog: function(callback) {
					const caption = this.get("Resources.Strings.SaveConfirmationMessage");
					const configs = {
						"buttons":
							[this.Terrasoft.MessageBoxButtons.YES.returnCode,
								this.Terrasoft.MessageBoxButtons.NO.returnCode],
						"defaultButton": 0
					};
					this.showInformationDialog(caption, function(result) {
						if (result === this.Terrasoft.MessageBoxButtons.YES.returnCode) {
							if (this.Ext.isFunction(callback)) {
								callback.call(this);
							}
						}
					}, configs);
				},

				//endregion

				//region Methods: Protected

				/**
				 * @inheritdoc Terrasoft.BaseGridDetailV2#getGridSettingsMenuItem
				 * @overridden
				 */
				getGridSettingsMenuItem: this.Terrasoft.emptyFn,

				/**
				 * @inheritdoc Terrasoft.BaseGridDetailV2#sortColumn
				 * @overridden
				 */
				sortColumn: this.Terrasoft.emptyFn,

				/**
				 * @inheritdoc Terrasoft.BaseGridDetailV2#getGridSortMenuItem
				 * @overridden
				 */
				getGridSortMenuItem: this.Terrasoft.emptyFn,

				/**
				 * @inheritdoc Terrasoft.BaseGridDetailV2#getCopyRecordMenuItem
				 * @overridden
				 */
				getCopyRecordMenuItem: this.Terrasoft.emptyFn,

				/**
				 * @inheritdoc Terrasoft.BaseGridDetailV2#getEditRecordMenuItem
				 * @overridden
				 */
				getEditRecordMenuItem: this.Terrasoft.emptyFn,

				/**
				 * @inheritdoc Terrasoft.BaseGridDetailV2#getSwitchGridModeMenuItem
				 * @overridden
				 */
				getSwitchGridModeMenuItem: this.Terrasoft.emptyFn,

				/**
				 * @inheritdoc Terrasoft.BaseGridDetailV2#addDetailWizardMenuItems
				 * @overridden
				 */
				addDetailWizardMenuItems: this.Terrasoft.emptyFn,

				/**
				 * ########## ######### ####### #######.
				 * ############# ########### ########## ### ####### #######.
				 * @inheritdoc GridUtilitiesV2#getGridDataColumns
				 * @overridden
				 */
				getGridDataColumns: function() {
					const configs = this.callParent(arguments);
					if (!configs.ModifiedOn) {
						configs.ModifiedOn = {
							"path": "ModifiedOn",
							"orderPosition": 1,
							"orderDirection": this.Terrasoft.OrderDirection.DESC
						};
					}
					if (!configs.Position) {
						configs.Position = {
							"path": "Position",
							"orderPosition": 0,
							"orderDirection": this.Terrasoft.OrderDirection.ASC
						};
					}
					return configs;
				},

				/**
				 * ########## ####### ######### ########## # ####### ######.
				 * @inheritdoc BaseGridDetailV2#onCardSaved
				 * @overridden
				 */
				onCardSaved: function() {
					this.openAdminUnitLookup(null);
				},

				/**
				 * ########## ######### ###### ########.
				 * @inheritdoc BaseGridDetailV2#getAddRecordButtonVisible
				 * @overridden
				 */
				getAddRecordButtonVisible: function() {
					return this.getToolsVisible();
				},

				/**
				 * ########## ######.
				 * @inheritdoc BaseGridDetailV2#addRecord
				 * @overridden
				 */
				addRecord: function() {
					this.checkCanChangeGrantee(function() {
						if (this.isPageInAddState()) {
							this.showConfirmSaveOperationDialog(function() {
								this.silentSaveOperation();
							});
						} else {
							this.openAdminUnitLookup(null);
						}
					}, null, this);
				},

				/**
				 * ######## #######.
				 * @inheritdoc GridUtilitiesV2#deleteRecords
				 * @overridden
				 */
				deleteRecords: function() {
					const items = this.getSelectedItems();
					if (items && items.length > 0) {
						this.showConfirmationDialog(this.get("Resources.Strings.DeleteConfirmationMessage"),
							function(result) {
								if (result === this.Terrasoft.MessageBoxButtons.YES.returnCode) {
									this.deleteGrantees(items, function() {
										this.onDeleteComplete(items);
									}, this);
								}
							}, [this.Terrasoft.MessageBoxButtons.YES.returnCode,
								this.Terrasoft.MessageBoxButtons.NO.returnCode], null);
					}
				},

				/**
				 * Returns filters for the SysAdminUnit lookup.
				 * @return {Terrasoft.FilterGroup} Filter group.
				 * @protected
				 */
				getAdminUnitLookupFilters: function() {
					const filtersGroup = this.Terrasoft.createFilterGroup();
					const notExistsFilter = this.Terrasoft.createNotExistsFilter("[" + this.entitySchemaName +
						":SysAdminUnit:Id].Id");
					return filtersGroup.addItem(notExistsFilter);
				},

				/**
				 * Assumes that the current user has an ability to change operation grantee.
				 * @param {Function} callbackAllow Allow callback.
				 * @param {Function} callbackDenied Deny callback.
				 * @param {Object} scope Scope object.
				 * @protected
				 */
				checkCanChangeGrantee: Terrasoft.abstractFn,

				/**
				 * Removes access rights to operations.
				 * @param {Array} itemIds Access rights identifiers array.
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Scope object.
				 * @protected
				 */
				deleteGrantees: Terrasoft.abstractFn,

				/**
				 * Changes access rights to for specified users.
				 * @param {Array} adminUnitIds Array of SysAdminUnit identifiers.
				 * @param {Boolean} canExecute Determines whether an operation access is granted or not.
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Scope object.
				 * @protected
				 */
				setOperationGrantees: Terrasoft.abstractFn,

				/**
				 * Sets the access right position.
				 * @param {String} itemId Access right identifier.
				 * @param {Number} position Position value to set.
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Scope object.
				 * @protected
				 */
				setGranteePosition: Terrasoft.abstractFn,

				//endregion

			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "MoveUpButton",
					"index": 0,
					"parentName": "Detail",
					"propertyName": "tools",
					"values": {
						"tag": "up",
						"click": {"bindTo": "onUpDownButtonClick"},
						"visible": {"bindTo": "getToolsVisible"},
						"itemType": this.Terrasoft.ViewItemType.BUTTON,
						"className": this.Terrasoft.controls.Button,
						"markerValue": "buttonUp",
						"imageConfig": LocalizableHelper.localizableImages.ButtonUp
					}
				},
				{
					"operation": "insert",
					"name": "MoveDownButton",
					"index": 1,
					"parentName": "Detail",
					"propertyName": "tools",
					"values": {
						"tag": "down",
						"click": {"bindTo": "onUpDownButtonClick"},
						"visible": {"bindTo": "getToolsVisible"},
						"itemType": this.Terrasoft.ViewItemType.BUTTON,
						"className": this.Terrasoft.controls.Button,
						"markerValue": "buttonDown",
						"imageConfig": LocalizableHelper.localizableImages.ButtonDown
					}
				},
				{
					"operation": "merge",
					"name": "DataGrid",
					"values": {
						"type": "listed",
						"className": "Terrasoft.ConfigurationGrid",
						"generator": "ConfigurationGridGenerator.generatePartial",
						"generateControlsConfig": {"bindTo": "generateActiveRowControlsConfig"},
						"changeRow": {"bindTo": "changeRow"},
						"unSelectRow": {"bindTo": "unSelectRow"},
						"onGridClick": {"bindTo": "onGridClick"},
						"listedZebra": true,
						"activeRowAction": {"bindTo": "onActiveRowAction"},
						"activeRowActions": [
							{
								"tag": "save",
								"style": this.Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
								"className": this.Terrasoft.controls.Button,
								"markerValue": "buttonSave",
								"imageConfig": {"bindTo": "Resources.Images.SaveIcon"}
							},
							{
								"tag": "cancel",
								"style": this.Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
								"className": this.Terrasoft.controls.Button,
								"markerValue": "buttonCancel",
								"imageConfig": {"bindTo": "Resources.Images.CancelIcon"}
							},
							{
								"tag": "remove",
								"style": this.Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
								"className": this.Terrasoft.controls.Button,
								"markerValue": "buttonRemove",
								"imageConfig": {"bindTo": "Resources.Images.RemoveIcon"}
							}
						],
						"initActiveRowKeyMap": {"bindTo": "initActiveRowKeyMap"}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	});
