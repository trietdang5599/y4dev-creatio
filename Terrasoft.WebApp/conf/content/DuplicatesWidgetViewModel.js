Terrasoft.configuration.Structures["DuplicatesWidgetViewModel"] = {innerHierarchyStack: ["DuplicatesWidgetViewModel"]};
define("DuplicatesWidgetViewModel", ["DuplicatesWidgetViewModelResources", "GoogleTagManagerUtilities", "RightUtilities", "SystemOperationsPermissionsMixin"],
	function(resources, GoogleTagManagerUtilities, RightUtilities) {
		Ext.define("Terrasoft.configuration.DuplicatesWidgetViewModel", {
			extend: "Terrasoft.BaseViewModel",
			alternateClassName: "Terrasoft.DuplicatesWidgetViewModel",
			Ext: null,
			Terrasoft: null,
			sandbox: null,
			isOpeningPage: false,
			
			columns: {
				EntitySchemaName: { dataValueType: Terrasoft.DataValueType.TEXT },
				EntityId: { dataValueType: Terrasoft.DataValueType.TEXT },
				Duplicates: { dataValueType: Terrasoft.DataValueType.COLLECTION },
				IsLoading: { dataValueType: Terrasoft.DataValueType.BOOLEAN },
			},
			mixins: {
				SystemOperationsPermissionsMixin: "Terrasoft.SystemOperationsPermissionsMixin",
			},
			messages: {},

			/**
			 * Handles widget click event.
			 * @param {Object} data Widget data.
			 */
			onWidgetClick: function(data) {
				Terrasoft.chain(
					function(next) {
						RightUtilities.checkCanExecuteOperation({
							operation: "CanMergeDuplicates"
						}, function(canExecute) {
							this.$CanMergeDuplicates = canExecute;
							this.Ext.callback(next, this);
						}.bind(this), this);
					},
					function(next) {
						this._checkCanUserReadAnyEntityRecord(next, data);
					},
					function(next, isAnyRecordReaded) {
						if (isAnyRecordReaded) {
							this._openDuplicatesCard(data);
						} else {
							const message = resources.localizableStrings.UserHasNoRightToReadRecords;
							Terrasoft.showInformation(message, null, null, {buttons: ["OK"]});
						}
					},
					this
				);
			},

			/**
			 * Check can user read any entity record.
			 * @param {function} callback Function.
			 * @param {object} data Widget data.
			 * @private
			 */
			_checkCanUserReadAnyEntityRecord(callback, data) {
				const esq = this._getEntityEsq(data);
				esq.getEntityCollection(function(result) {
					if (result.success) {
						Ext.callback(callback, this, [result.collection.getCount() > 0]);
					}
				}, this);
			},

			/**
			 * @private
			 */
			_addGTMForDuplicatesWidget: function() {
				var data = this._getGTMDuplicatesWidgetData();
				GoogleTagManagerUtilities.actionModule(data);
			},

			/**
			 * @private
			 */
			_getGTMDuplicatesWidgetData: function() {
				return {
					action: "DuplicatesWidgetClick",
					moduleName: "DuplicatesWidgetModule",
					schemaName: "DuplicateWidget",
					virtualUrl: this.Terrasoft.workspaceBaseUrl + "/" + this.sandbox.id
				};
			},

			/**
			 * Returns entity schema query with filter.
			 * @param {object} data Widget data.
			 * @return {Terrasoft.EntitySchemaQuery} Entity schema query.
			 * @private
			 */
			_getEntityEsq(data) {
				const esq = Ext.create("Terrasoft.EntitySchemaQuery", {
					rootSchemaName: data.entitySchemaName
				});
				esq.addColumn("Id");
				esq.filters.add("EntityIdInFilter", Terrasoft.createColumnInFilterWithParameters("Id", data.duplicates));
				return esq;
			},

			/**
			 * Opens duplicates card.
			 * @param {object} data Widget data.
			 * @private
			 */
			_openDuplicatesCard: function(data) {
				if (!this.$CanMergeDuplicates && Terrasoft.Features.getIsEnabled("DenyDuplicatesWidgetMergeWithOperation")) {
					this.showPermissionsErrorMessage("CanMergeDuplicates");
					return;
				}
				const duplicatesIds = data.duplicates || [];
				if (duplicatesIds.length === 0) {
					return;
				}
				if (this.isOpeningPage) {
					return;
				}
				this._addGTMForDuplicatesWidget();
				this.isOpeningPage = true;
				const currentEntityId = data.entityId;
				const hash = "CardModuleV2/WidgetDuplicatesPage/" + data.entitySchemaName;
				this.sandbox.publish("PushHistoryState", {
					hash: hash,
					stateObj: {
						DuplicateEntitiesIds: duplicatesIds,
						CurrentEntityId: currentEntityId,
						IsLoading: data.isLoading,
						EntitySchemaName: data.entitySchemaName,
						BackHash: Terrasoft.router.Router.getHash(),
						BackState: Terrasoft.router.Router.getState()
					}
				});
			},
		});

		return Terrasoft.DuplicatesWidgetViewModel;

	});

